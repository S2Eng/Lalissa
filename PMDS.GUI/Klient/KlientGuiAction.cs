using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;
using System.Data;
using System.Drawing;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using PMDS.Klient;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Print;
using PMDS.GUI.BaseControls;
using PMDS.GUI.Klient;
using PMDS.Global.db.Global;
using PMDS.DB;
using System.Linq;

namespace PMDS.GUI
{


    public class KlientGuiAction
    {



        public KlientGuiAction()
        {

        }
        

        public static bool UpdateKontaktperson(dsKontaktpersonen.KontaktpersonRow row, KlientDetails klient, bool externerDienstleister)
        {
            Kontaktperson Kontaktperson = new Kontaktperson();
            Kontaktperson.IDPatient = klient.IDPatient;
            Kontaktperson.ExternerDienstleisterJN = externerDienstleister;

            if (row == null)
            {
                klient.KONTAKTPERSONEN.Add(Kontaktperson);
                
            }
            else
            {
                foreach (Kontaktperson kp in klient.KONTAKTPERSONEN)
                {
                    if (kp.ID == row.ID)
                    {
                        Kontaktperson = kp;
                        break;
                    }
                }
            }

            frmKontaktPerson frm = new frmKontaktPerson();
            frm.AllowEdit(ENV.HasRight(UserRights.KlientenAktStammdatenAendern));
            frm.Kontaktperson = Kontaktperson;
            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {
                string title = "";

                bool bAdded = false;
                if (row == null)
                {
                    if (!externerDienstleister)
                    {
                        row = klient.KLIENT_KONTAKTPERSONEN.Kontaktperson.AddKontaktpersonRow(Kontaktperson.ID, klient.IDPatient, Guid.NewGuid(),
                             Guid.NewGuid(), false, "", "", "", "", "");
                    }
                    else
                    {
                        row = klient.KLIENT_DIENSTLEISTER.Kontaktperson.AddKontaktpersonRow(Kontaktperson.ID, klient.IDPatient, Guid.NewGuid(),
                             Guid.NewGuid(), false, "", "", "", "", "");
                    }

                    row.SetIDAdresseNull();
                    row.SetIDKontaktNull();
                    row.SetVerstaendigenJNNull();

                    bAdded = true;
                    title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontakt hinzugefügt für Patient {0}");
                }
                else
                {
                    title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontakt geändert für Patient {0}");
                }

                string name, adresse;

                name = Kontaktperson.Nachname + " " + Kontaktperson.Vorname;

                if (Kontaktperson.Titel != "")
                    name += ", " + Kontaktperson.Titel;
                adresse = "";

                if (Kontaktperson.Kontakt.Tel != "")
                    adresse += Kontaktperson.Kontakt.Tel;
                if (Kontaktperson.Adresse.Strasse != "")
                    adresse += " " + Kontaktperson.Adresse.Strasse;
                if (Kontaktperson.Adresse.Plz != "")
                    adresse += " " + Kontaktperson.Adresse.Plz;
                if (Kontaktperson.Adresse.Ort != "")
                    adresse += " " + Kontaktperson.Adresse.Ort;
                StringBuilder sMail = new StringBuilder();
                if (Kontaktperson.Kontakt.Email != null && Kontaktperson.Kontakt.Email.Trim() != "")
                {
                    row.EMail = Kontaktperson.Kontakt.Email.Trim();
                }
                else
                {
                    row.EMail = "";
                }

                string txtDekurs = PMDSBusinessUI.getDekursKontaktperson(bAdded, Kontaktperson);
                row.Name = name;
                row.Adresse = adresse;
                row.Kontaktart = Kontaktperson.Kontaktart.Trim();
                row.VerstaendigenJN = Kontaktperson.VerstaendigenJN;
                row.Verwandtschaft = Kontaktperson.Verwandschaft;

                KlientGuiAction.addKontakteChanged2(title, txtDekurs, Kontaktperson.IDPatient);

                return true;
            }
            else if (row == null)
            {
                klient.KONTAKTPERSONEN.Remove(Kontaktperson);
            }

            return false;
        }

        public static string getTxtBool(Nullable<bool> bVal)
        {
            string sJa = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ja");
            string sNein = QS2.Desktop.ControlManagment.ControlManagment.getRes("Nein");

            if (bVal == null || bVal == false)
                return sNein;
            else
                return sJa;
        }

        public static void addKontakteChanged2(string title, string txt, Guid IDPatient)
        {
            try
            {
                Patient pat = new Patient(IDPatient);                   //new Patient(ENV.CurrentIDPatient);
                title = string.Format(title, pat.FullName.Trim());
                
                ucKlientStammdaten.cKontakteChanged newKontakteChanged = new ucKlientStammdaten.cKontakteChanged();
                newKontakteChanged.IDPatient = IDPatient;
                newKontakteChanged.title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung");
                newKontakteChanged.txt = title + "" + "\r\n"+ txt;
                ucKlientStammdaten.lstKontakteChanged.Add(newKontakteChanged);

            }
            catch (Exception ex)
            {
                throw new Exception("KlientGuiAction.addKontakteChanged: " + ex.ToString());
            }
        }
        public static bool DelKontaktperson(dsKontaktpersonen.KontaktpersonRow row, KlientDetails klient, bool externerDienstleister)
        {
            Kontaktperson Kontaktperson = null;

            foreach (Kontaktperson kp in klient.KONTAKTPERSONEN)
            {
                if (kp.ID == row.ID)
                {
                    Kontaktperson = kp;
                    break;
                }
            }

            if (Kontaktperson != null)
            {
                //HL_AddPE_KontaktPatient_02
                string title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontakt gelöscht für Patient {0}");
                string txt = "Name: " + Kontaktperson.Nachname + " " + Kontaktperson.Vorname.Trim();
                KlientGuiAction.addKontakteChanged2(title, txt, klient.IDPatient);
                Kontaktperson.Delete();

                if(!externerDienstleister)
                    klient.KLIENT_KONTAKTPERSONEN.Kontaktperson.Rows.Remove(row);
                else
                    klient.KLIENT_DIENSTLEISTER.Kontaktperson.Rows.Remove(row);
                return true;
            }
            return false;
        }

        public static bool DeleteKontakte(UltraGrid g, KlientDetails klient, bool externerDienstleister)
        {
            DataRow[] rows = CurrentSelectedRows(g);

            if (rows != null && ENV.HasRight(UserRights.PatientenVerwalten))
            {
                //
                //Sicherheitfrage
                DialogResult res = DelDialogResult(rows.Length);

                if (res == DialogResult.Yes)
                {
                    foreach (DataRow r in rows)
                    {
                        DelKontaktperson((dsKontaktpersonen.KontaktpersonRow)r, klient, externerDienstleister);
                    }
                    return true;
                }
            }

            return false;
        }

        public static bool ELGAKontaktDelegation(dsPatientAerzte.PatientAerzteRow[] rows, KlientDetails Klient)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rAufenthalt = (from a in db.Aufenthalt
                                       join p in db.Patient on a.IDPatient equals p.ID
                                       where a.ID == Klient.Aufenthalt.ID
                                       select new
                                       {
                                           IDAufenthalt = a.ID,
                                           ELGALocalID = a.ELGALocalID,
                                           ELGASOOJN = a.ELGASOOJN,
                                           ELGAAbgemeldet = p.ELGAAbgemeldet,
                                           IDPatient = p.ID,
                                           Nachname = p.Nachname.Trim(),
                                           Vorname = p.Vorname.Trim()
                                       }).First();

                    if (!ENV.lic_ELGA || 
                        rows == null || 
                        !ENV.HasRight(UserRights.PatientenVerwalten) || 
                        (bool)rAufenthalt.ELGAAbgemeldet || 
                        (bool)rAufenthalt.ELGASOOJN || 
                        String.IsNullOrWhiteSpace(rAufenthalt.ELGALocalID) ||
                        !Global.db.ERSystem.ELGABusiness.HasELGARight(Global.db.ERSystem.ELGABusiness.eELGARight.ELGAPatientenSuchen, false)
                        )
                        return false;
                    
                    
                    if (PMDS.Global.db.ERSystem.ELGABusiness.checkELGASessionActive(true))
                    {
                        string sResultOk = "Ergebnis für Kontaktdelegation\n\r\n\r";
                        string sResultNotOk = "";
                        Global.db.ERSystem.ELGABusiness ELGABusiness1 = new Global.db.ERSystem.ELGABusiness();
                        List<dsAerzte.AerzteRow> list = new List<dsAerzte.AerzteRow>();
                        foreach (dsPatientAerzte.PatientAerzteRow r in rows)
                        {
                            dsAerzte.AerzteRow rArzt = Aerzte.GetArztDetails(r.IDAerzte);
                            string sArzt = rArzt.Titel + " " + rArzt.Vorname + " " + rArzt.Nachname;

                            if (!String.IsNullOrWhiteSpace(rArzt.ELGA_OID))
                            {
                                WCFServicePMDS.BAL2.ELGABAL.ELGAParOutDto retDto = ELGABusiness1.DelegateContact(rAufenthalt.IDPatient, rAufenthalt.IDAufenthalt, rArzt.ID);
                                if (retDto.bOK)
                                {
                                    sResultOk += "Erfolgreich für " + sArzt + ".\n\r";
                                }
                                else
                                {
                                    sResultOk += "Unerwarteter Fehler für " + sArzt + ":" + retDto.MessageException + ".\n\r";
                                }
                            }
                            else
                            {
                                sResultNotOk += "Keine Delegation für " + sArzt + "möglich, weil keine OID zugeordnet wurde.\n\r";
                            }
                        }

                        using (PMDS.GUI.GenericControls.frmMessageBox frmMessageBox1 = new GenericControls.frmMessageBox())
                        {
                            frmMessageBox1.ShowAbort = false;
                            frmMessageBox1.initControl(sResultOk + "\n\r" + sResultNotOk);
                            frmMessageBox1.ShowDialog();
                        }
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in KientGuiAction.ELGAKontaktDelegation:" + ex.ToString());
            }
        }

        public static bool DeletePatientAerzteZuordnungen(dsPatientAerzte.PatientAerzteRow[] rows)
        {
            if (rows == null || !ENV.HasRight(UserRights.PatientenVerwalten))
                return false;
            bool geloescht = false;
            //Sicherheitfrage
            DialogResult res = DelDialogResult(rows.Length);

            if (res == DialogResult.Yes)
            {
                List<dsAerzte.AerzteRow> list = new List<dsAerzte.AerzteRow>();
                foreach (dsPatientAerzte.PatientAerzteRow r in rows)
                {
                    //HL_AddPE_KontaktPatient_03
                    dsAerzte.AerzteRow rAerzt = Aerzte.GetArztDetails(r.IDAerzte);
                    string title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontakt gelöscht für Patient {0}");
                    string txt = "Name: " + rAerzt.Nachname.Trim() + " " + rAerzt.Vorname.Trim();
                    KlientGuiAction.addKontakteChanged2(title, txt, r.IDPatient);

                    r.Delete();
                    geloescht = true;

                    //if (Aerzte.IsRezeptErstellt(r.IDPatient, r.IDAerzte))
                    //{
                    //    list.Add(Aerzte.GetArztDetails(r.IDAerzte));
                    //}
                    //else
                    //{
                    //    r.Delete();
                    //    geloescht = true;
                    //}
                }

                //if (list.Count > 0)
                //{
                //    StringBuilder sb = new StringBuilder();
                //    string msg = list.Count == 1 ? QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgender Arzt hat Rezepte erstellt, deshalb kann er nicht entfernt werden. ") : QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgende Ärzte haben Rezepte erstellt, deshalb können Sie nicht entfernt werden. ");
                //    sb.Append(msg);

                //    foreach (dsAerzte.AerzteRow r in list)
                //        sb.Append("\n\t- " + r.Vorname + " " + r.Nachname);

                //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sb.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information, true);
                //}
            }

            return geloescht;
        }

        public static void RefreshListPatientAerzte(UltraGrid g, KlientDetails klient)
        {
            Arzt Arzt;
            StringBuilder sbName, sbAdresse;
            g.BeginUpdate();
            
            foreach (UltraGridRow r in g.Rows)
            {
                foreach (dsAerzte.AerzteRow rr in klient.CLASS_AERZTE.AERZTE.Aerzte)
                {
                    if (rr.RowState != DataRowState.Deleted && (Guid)r.Cells["IDAerzte"].Value == rr.ID)
                    {
                        sbName = new StringBuilder();
                        sbAdresse = new StringBuilder();

                        Arzt = klient.CLASS_AERZTE.GetArzt(rr.ID);
                        sbName.Append(rr.Nachname.Trim() + " " + rr.Vorname.Trim());

                        if (!rr.IsTitelNull() && rr.Titel.Trim() != "")
                            sbName.Append(", " + rr.Titel);

                        if (Arzt.Kontakt.Tel != "")
                            sbAdresse.Append("Tel: " + Arzt.Kontakt.Tel + " /");
                        if (Arzt.Kontakt.Mobil != "")
                        {
                            if (Arzt.Kontakt.Tel != "")
                                sbAdresse.Append(" ");
                            sbAdresse.Append("Mobil: " + Arzt.Kontakt.Mobil + " /");
                        }
                        if (Arzt.Adresse.Strasse != "")
                            sbAdresse.Append(" " + Arzt.Adresse.Strasse);
                        if (Arzt.Adresse.Plz != "")
                            sbAdresse.Append(" " + Arzt.Adresse.Plz);
                        if (Arzt.Adresse.Ort != "")
                            sbAdresse.Append(" " + Arzt.Adresse.Ort);
                        
                        r.Cells["Name"].Value = sbName.ToString();
                        r.Cells["EMail"].Value = Arzt.Kontakt.Email.Trim();

                        if (!rr.IsFachrichtungNull())
                            r.Cells["Fachrichtung"].Value = rr.Fachrichtung;
                        else
                            r.Cells["Fachrichtung"].Value = DBNull.Value;

                        r.Cells["TelAdresse"].Value = sbAdresse.ToString();
                        r.Update();
                        break;
                    }
                }
            }

            g.EndUpdate();
        }

        public static bool AddPatientAerzte(Guid[] Aerzte, KlientDetails klient)
        {
            try
            {
                bool found, dataChenged = false;
                List<dsPatientAerzte.PatientAerzteRow> listDelRows = new List<dsPatientAerzte.PatientAerzteRow>();
                //Ärzte löschen
                foreach (dsPatientAerzte.PatientAerzteRow r in klient.CLASS_AERZTE.PATIENTAERZTE.PatientAerzte)
                {
                    found = false;
                    foreach (Guid id in Aerzte)
                    {
                        if (r.RowState != DataRowState.Deleted && id == r.IDAerzte)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (r.RowState != DataRowState.Deleted && !found)
                    {
                        listDelRows.Add(r);
                        dataChenged = true;
                    }
                }

                foreach (dsPatientAerzte.PatientAerzteRow r in listDelRows)
                    r.Delete();


                //Ärzte zuordnen
                foreach (Guid id in Aerzte)
                {
                    found = false;
                    foreach (dsPatientAerzte.PatientAerzteRow r in klient.CLASS_AERZTE.PATIENTAERZTE.PatientAerzte)
                    {
                        if (r.RowState != DataRowState.Deleted && id == r.IDAerzte)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        klient.CLASS_AERZTE.NewPatientAerzte(id);
                        dataChenged = true;
                    }
                }

                return dataChenged;
            }
            catch(Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
        }

        public static bool UpdateSachwalter(dsKlientSachwalter.SachwalterRow row, KlientDetails klient, UltraGrid grid)
        {
            Sachwalter Sachwalter = new Sachwalter();
            Sachwalter.IDPatient = klient.IDPatient;

            if (row == null)
            {
                klient.LIST_SACHWALTER.Add(Sachwalter);

            }
            else
            {
                foreach (Sachwalter sw in klient.LIST_SACHWALTER)
                {
                    if (sw.ID == row.ID)
                    {
                        Sachwalter = sw;
                        break;
                    }
                }
            }

            frmSachwalter frm = new frmSachwalter();
            frm.AllowEdit(ENV.HasRight(UserRights.KlientenAktStammdatenAendern));
            frm.Sachwalter = Sachwalter;
            DialogResult res = frm.ShowDialog();

            if (res == DialogResult.OK)
            {
                string title = "";

                if (row == null)
                {
                    row = klient.KLIENT_SACHWALTER.Sachwalter.AddSachwalterRow(Sachwalter.ID, klient.IDPatient, Guid.NewGuid(),
                         Guid.NewGuid(), "", "", DateTime.Now);

                    row.SetIDAdresseNull();
                    row.SetIDKontaktNull();
                    row.SetBestimmtAmNull();

                    title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontakt hinzugefügt für Patient {0}");
                }
                else
                {
                    title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontakt geändert für Patient {0}");
                }

                string name, belange;

                name = Sachwalter.Nachname + " " + Sachwalter.Vorname;

                if (Sachwalter.Titel != "")
                    name += ", " + Sachwalter.Titel;

                row.Name = name;
                
                if (Sachwalter.SachwalterJN)
                    belange = QS2.Desktop.ControlManagment.ControlManagment.getRes("Erwachsenenvertreter ");
                else
                    belange = QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorsorgevollmächtige ");

                if (Sachwalter.Belange != "")
                    belange += QS2.Desktop.ControlManagment.ControlManagment.getRes("für ") + Sachwalter.Belange.Trim();

                if (Sachwalter.Von != null)
                {
                    if (Sachwalter.Bis == null)
                        belange += QS2.Desktop.ControlManagment.ControlManagment.getRes(" seit ") + ((DateTime)Sachwalter.Von).Date.ToShortDateString();
                    else
                        belange += QS2.Desktop.ControlManagment.ControlManagment.getRes(" von ") + ((DateTime)Sachwalter.Von).Date.ToShortDateString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" bis ") + ((DateTime)Sachwalter.Bis).Date.ToShortDateString();
                }

                row.Belange = belange;

                if (Sachwalter.BestimmtAm != null)
                    row.BestimmtAm = (DateTime)Sachwalter.BestimmtAm;

                string Adresse = "";
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGridSachwalter in grid.Rows)
                {
                    DataRowView v = (DataRowView)rGridSachwalter.ListObject;
                    dsKlientSachwalter.SachwalterRow rSachwalter = (dsKlientSachwalter.SachwalterRow)v.Row;
                    if (Sachwalter.ID == rSachwalter.ID)
                    {
                        Adresse = Sachwalter.Kontakt.Tel + " / " + Sachwalter.Adresse.Ort + " " + Sachwalter.Adresse.Plz + " " + Sachwalter.Adresse.Strasse;
                        rGridSachwalter.Cells["TelAdresse"].Value = Adresse;
                        rGridSachwalter.Cells["EMail"].Value = Sachwalter.Kontakt.Email.Trim();
                        break;
                    }
                }

                //HL_AddPE_KontaktPatient_04
                string txt = "";
                PMDS.DB.PMDSBusiness b = new PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    txt += "Name: " + name.Trim() + "\r\n";
                    txt += "Adress: " + Adresse.Trim() + "\r\n";
                    txt += "Interests: " + belange.Trim() + "\r\n";
                    KlientGuiAction.addKontakteChanged2(title, txt, klient.IDPatient);
                }

                return true;
            }
            else if (row == null)
            {
                klient.LIST_SACHWALTER.Remove(Sachwalter);
            }

            return false;
        }

        public static bool DelSachwalter(dsKlientSachwalter.SachwalterRow row, KlientDetails klient)
        {
            Sachwalter Sachwalter = null;

            foreach (Sachwalter sw in klient.LIST_SACHWALTER)
            {
                if (sw.ID == row.ID)
                {
                    Sachwalter = sw;
                    break;
                }
            }

            if (Sachwalter != null)
            {
                //HL_AddPE_KontaktPatient_05
                string title = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontakt gelöscht für Patient {0}");
                string txt = "Name: " + Sachwalter.Nachname.Trim() + " " + Sachwalter.Vorname.Trim();
                KlientGuiAction.addKontakteChanged2(title, txt, klient.IDPatient);

                Sachwalter.Delete();
                klient.KLIENT_SACHWALTER.Sachwalter.Rows.Remove(row);
                return true;
            }
            return false;
        }

        public static bool DeleteAllSelectedSachwalter(UltraGrid g, KlientDetails klient)
        {
            DataRow[] rows = CurrentSelectedRows(g);

            if (rows != null && ENV.HasRight(UserRights.PatientenVerwalten))
            {
                //
                //Sicherheitfrage
                DialogResult res = DelDialogResult(rows.Length);

                if (res == DialogResult.Yes)
                {
                    foreach (DataRow r in rows)
                    {
                        DelSachwalter((dsKlientSachwalter.SachwalterRow)r, klient);
                    }
                    return true;
                }
            }

            return false;
        }

        
        public static  bool IsDouble(string value)
        {
            try
            {
                double x = Convert.ToDouble(value);

                if (x > double.MaxValue || x < double.MinValue)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsInteger(string value)
        {
            try
            {
                double x = Convert.ToInt32(value);

                if (x > int.MaxValue || x < int.MinValue)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                  (DescriptionAttribute[])fi.GetCustomAttributes(
                  typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        public static void AddTextTextValuListFromPflegestufe(dsKlientPflegegeldstufe ds, UltraGrid g, string sBoundGridColumn)
        {
            ValueList vl = new ValueList();

            foreach (dsKlientPflegegeldstufe.PflegegeldstufeRow r in ds.Pflegegeldstufe)
                vl.ValueListItems.Add(r.ID, r.Bezeichnung);


            UltraGridColumn c = g.DisplayLayout.Bands[0].Columns[sBoundGridColumn];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
        }

        public static DataRow[] CurrentSelectedRows(UltraGrid g)
        {
            DataRow[] list = null;
            UltraGridRow[] ra = UltraGridTools.GetAllRowsFromGroupedUltraGrid(g, true);

            if (ra.Length > 0)
            {
                DataRowView v;
                list = new DataRow[ra.Length];
                int i = 0;
                foreach (UltraGridRow r in ra)
                {
                    if ((r != null) && (r.ListObject != null))
                    {
                        v = (DataRowView)r.ListObject;
                        list[i] = v.Row;
                        i++;
                    }
                }

            }

            return list;
        }

        public static DialogResult DelDialogResult(int length)
        {
            DialogResult res;
            if (length > 1)
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Datensätze gelöscht werden?", "Datensätze löschen", MessageBoxButtons.YesNo);
            else
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soll der Datensatz gelöscht werden?", "Datensatz löschen", MessageBoxButtons.YesNo);
            return res;
        }

        public static void PrintDynamicReport(dsUnterbringung.UnterbringungRow r, Guid IDKlinik_current)
        {
            if (r != null)
            {
                PMDS.Print.ReportManager.PrintUnterbringungReport(r.ID, IDKlinik_current, r.Beginn);
            }
        }

        public void doUIDienstübergabe(ref System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteSelected2 , ref System.Collections.Generic.List<PMDS.DB.PMDSBusiness.cÄrzteMehrfachauswahl> lstÄrzteMehrfachauswahlReturn,
                                        Guid IDAertzeToAdd, dsPatientAerzte.PatientAerzteRow rNewPatientÄrzte, UltraGrid gridÄrzte)
        {
            try
            {
                bool bFoundÄrzteInMehrfachauswahl = false;
                foreach (PMDS.DB.PMDSBusiness.cÄrzteMehrfachauswahl ÄrzteMehrfachauswahl in lstÄrzteMehrfachauswahlReturn)
                {
                    if (ÄrzteMehrfachauswahl.IDÄrzteMehrfachauswahl.Equals(IDAertzeToAdd))
                    {
                        ÄrzteMehrfachauswahl.lstPatienteSelected2 = new List<UIGlobal.eSelectedNodes>();
                        ÄrzteMehrfachauswahl.lstPatienteSelected2 = lstPatienteSelected2;
                        ÄrzteMehrfachauswahl.IDÄrzteMehrfachauswahl = IDAertzeToAdd;
                        if (rNewPatientÄrzte != null)
                        {
                            ÄrzteMehrfachauswahl.IDÄrztePatientMehrfachauswahl = rNewPatientÄrzte.ID;
                        }

                        bFoundÄrzteInMehrfachauswahl = true;
                    }
                }

                if (!bFoundÄrzteInMehrfachauswahl)
                {
                    frmAerzteEditMehrfachauswahl frmAerzteEditMehrfachauswahl1 = new frmAerzteEditMehrfachauswahl();
                    frmAerzteEditMehrfachauswahl1.initControl();
                    frmAerzteEditMehrfachauswahl1.ShowDialog();
                    if (!frmAerzteEditMehrfachauswahl1.abort)
                    {
                        bool ELGAHausarztExists = false;
                        if (gridÄrzte != null)
                        {
                            if (!PMDSBusinessUI.checkAerzteELGAHausarztOKInDB(ENV.CurrentIDPatient, ref gridÄrzte))
                            {
                                ELGAHausarztExists = true;
                            }
                            if (frmAerzteEditMehrfachauswahl1.chkHausarztELGAJN.Checked && ELGAHausarztExists)
                            {
                                frmAerzteEditMehrfachauswahl1.chkHausarztELGAJN.Checked = false;
                                frmAerzteEditMehrfachauswahl1.chkHausarztJN.Checked = true;
                            }
                        }


                        PMDS.DB.PMDSBusiness.cÄrzteMehrfachauswahl newÄrzteMehrfachauswahl = new PMDS.DB.PMDSBusiness.cÄrzteMehrfachauswahl();
                        newÄrzteMehrfachauswahl.lstPatienteSelected2 = new List<UIGlobal.eSelectedNodes>();
                        newÄrzteMehrfachauswahl.lstPatienteSelected2 = lstPatienteSelected2;
                        newÄrzteMehrfachauswahl.IDÄrzteMehrfachauswahl = IDAertzeToAdd;
                        if (rNewPatientÄrzte != null)
                        {
                            newÄrzteMehrfachauswahl.IDÄrztePatientMehrfachauswahl = rNewPatientÄrzte.ID;
                        }

                        newÄrzteMehrfachauswahl.HausarztJN2 = frmAerzteEditMehrfachauswahl1.chkHausarztJN.Checked;
                        newÄrzteMehrfachauswahl.HausarztELGAJN = frmAerzteEditMehrfachauswahl1.chkHausarztELGAJN.Checked;
                        newÄrzteMehrfachauswahl.ZuweiserJN = frmAerzteEditMehrfachauswahl1.chkZuweiserJN.Checked;
                        newÄrzteMehrfachauswahl.AufnahmearztJN = frmAerzteEditMehrfachauswahl1.chkAufnahmearztJN.Checked;
                        newÄrzteMehrfachauswahl.BehandelnderFAJN = frmAerzteEditMehrfachauswahl1.chkBehandelnderFAJN.Checked;
                        if (frmAerzteEditMehrfachauswahl1.dteVon.Value != null)
                        {
                            newÄrzteMehrfachauswahl.Von = frmAerzteEditMehrfachauswahl1.dteVon.DateTime.Date;
                        }

                        if (rNewPatientÄrzte != null)
                        {
                            rNewPatientÄrzte.HausarztJN = newÄrzteMehrfachauswahl.HausarztJN2;
                            rNewPatientÄrzte.ELGA_HausarztJN = newÄrzteMehrfachauswahl.HausarztELGAJN;
                            rNewPatientÄrzte.ZuweiserJN = newÄrzteMehrfachauswahl.ZuweiserJN;
                            rNewPatientÄrzte.AufnahmearztJN = newÄrzteMehrfachauswahl.AufnahmearztJN;
                            rNewPatientÄrzte.BehandelnderFAJN = newÄrzteMehrfachauswahl.BehandelnderFAJN;
                            if (newÄrzteMehrfachauswahl.Von != null)
                            {
                                rNewPatientÄrzte.Von = newÄrzteMehrfachauswahl.Von.Value;
                            }
                            else
                            {
                                rNewPatientÄrzte.SetVonNull();
                            }
                        }

                        lstÄrzteMehrfachauswahlReturn.Add(newÄrzteMehrfachauswahl);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("KlientGuiAction.doUIDienstübergabe: " + ex.ToString());
            }
        }

        public void checkWriteÄrzteMehrfachauswahl(ref System.Collections.Generic.List<PMDS.DB.PMDSBusiness.cÄrzteMehrfachauswahl> lstÄrzteMehrfachauswahl, Nullable<Guid> IDKlientOrig)
        {
            try
            {
                PMDSBusiness PMDSBusiness1 = new PMDSBusiness();

                if (lstÄrzteMehrfachauswahl.Count > 0)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                    {
                        foreach (PMDS.DB.PMDSBusiness.cÄrzteMehrfachauswahl ÄrzteMehrfachauswahl in lstÄrzteMehrfachauswahl)
                        {
                            PMDSBusiness1.copyÄrzte(ÄrzteMehrfachauswahl.IDÄrzteMehrfachauswahl.Value, ref ÄrzteMehrfachauswahl.lstPatienteSelected2, IDKlientOrig, db, ÄrzteMehrfachauswahl);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("KlientGuiAction.checkWriteÄrzteMehrfachauswahl: " + ex.ToString());
            }
        }

    }

}
