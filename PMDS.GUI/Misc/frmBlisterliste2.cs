using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using PMDS.Global;
using System.Data.Common;
using System.Data.SqlClient;

using Syncfusion.Pdf;
using System.IO;
using PMDS.db.Entities;
using Syncfusion.Pdf.Parsing;

using Patagames.Pdf.Net;        //https://www.youtube.com/watch?v=IF9cKSUFon8
using Patagames.Pdf.Enums;


namespace PMDS.GUI.Misc
{

    public partial class frmBlisterliste2 : Form
    {
        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();




        public frmBlisterliste2()
        {
            InitializeComponent();
            PMDS.Global.db.ERSystem.PMDSBusinessUI.initPDFViewer();
        }

        private class clsBlisterListe
        {
            public Guid IDKlient;
            public Guid IDRezepteintrag;
            public DateTime GebDat;
            public string Filename;
            public byte[] PDF;
        }

        private void btnCreateBlisterliste_Click(object sender, EventArgs e)
        {
            /*
           * 
           * Grundfunktion des Service
           * 
           *Wichtig:  Der Funktionslauf muss entweder ganz oder gar nicht erfolgen. Bei Fehler darf kein DB-Update erfolgen.
           * 
              Hole Liste der langfristig vorzubereitenden Medikamente, die geändert wurden (DatumGeaendert > ZeitpunktBlisterliste): 
                  SQL-Funktion verwenden: select * from s2_Blisterliste('00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000000')
              Für jeden Klienten genau ein Crystal Reports erstellen (Blisterliste) und als PDF speichern (Crystal Reports)
              Alle Blisterliste-PDFs in ein einziges PDF zusammenfassen   (Syncfusion)
              PDF als ZIP speichern und mit Passwort verschlüsseln        (Chilkat)
              ZIP als Anhang als eMail schicken                           (eMail)
              Wenn erfolgreich (auch wenn kein PDF erstellt wurde, wei lnichts geändert wurde)
                  In jedem Medikament, das auf der Blisterliste ist, den Zeitpunkt der Blisterliste updaten
                  QS2-Protokolleintrag als Plaintext (Inhalt, was wurde gesendet) schreiben   
                  eMail an Admin mit Erfolgsmeldung (ev. Inhalt als Plaintext) zur Kontrolle
                  Update eines neuen Systemfeldes ZeitpunktBisterliste. 
                  eMail an Admin mit Fehlermeldung

          Weitere Funktionen (nicht im Service, sondern im PMDS)
              Anzeige Feld ZeitpunktBlisterliste für Admins in der Statusleiste PMDS. Wenn mehr als x Stunden seit akt. Zeitpunkt -> rot anzeigen!
              Wenn nicht erfolgreich
              Ansicht / Ausdruck Blisterlisten von - bis
              Erneutes Senden Blisterlisten von - bis
              Ansicht und Drucken QS2-Protokoll Blisterlisten von - bis 
              Service neu starten / Service beenden für Admins
          */

            try
            {
                DateTime dtStart = DateTime.Now;
                string tmpPDFDir = System.IO.Path.Combine(@"C:\Temp", "tmpBlisterlisten");          //HL: Beschreibbare Verzeichnisse außerhalb ProgramFiles aus Config verwenden
                string finalDir = System.IO.Path.Combine(@"C:\Temp", "Blisterlisten");
                string finalFileName = "Blisterliste_" + dtStart.ToString("yyyy.MM.dd_HH.mm.ss");
                int iCountAufenthalte = 0;
                bool bCreateSolidPDF = false;

                List<clsBlisterListe> lstBlisterListen = new List<clsBlisterListe>();
                string strSQl = "SELECT * FROM dbo.s2_Blisterliste(@IDKlinik, @IDAbteilung, @IDKlient)";
                DbParameter[] pars = new DbParameter[]
                {
                    new SqlParameter {ParameterName="IDKlinik", Value=System.Guid.Empty, DbType= DbType.Guid, SourceColumn= "@IDKlinik"},
                    new SqlParameter {ParameterName="IDAbteilung", Value=System.Guid.Empty, DbType= DbType.Guid, SourceColumn= "@IDAbteilung"},
                    new SqlParameter {ParameterName="IDKlient", Value=System.Guid.Empty, DbType= DbType.Guid, SourceColumn= "@IDKlient"}
                };

                IEnumerable<s2_Blisterliste_Result> bl = null;
 
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                    {
                        Guid? aktKlient = Guid.Empty;
                        bl = db.Database.SqlQuery<s2_Blisterliste_Result>(strSQl, pars);
                        foreach (s2_Blisterliste_Result rBlister in bl)
                        {
                            if (rBlister.IDKlient != aktKlient)
                            {
                                //PDFs erstellen wenn sich Klient in Blisterliste geändert hat
                                iCountAufenthalte++;
                                lbliCount.Text = iCountAufenthalte.ToString() + " / " + rBlister.Nachname + " " + rBlister.Vorname;
                                PMDS.Print.ReportManager.PrintBlisterliste(System.IO.Path.Combine(ENV.ReportPath, "Blisterliste.rpt"), Guid.Empty, Guid.Empty, (Guid)rBlister.IDKlient, tmpPDFDir, false, rBlister.Nachname + "_" + rBlister.Vorname + "_" + iCountAufenthalte.ToString());

                                //PDF als BLOP in Liste speichern (weil PrintBlisterliste keinen eindeutingen Filenamen zurückgibt, Files im Directory suchen)                              
                                List<string> lstPDFFiles = new List<string>();
                                DirectoryInfo di = new DirectoryInfo(System.IO.Path.Combine(tmpPDFDir, rBlister.Nachname + "_" + rBlister.Vorname + "_" + iCountAufenthalte.ToString()));
                                FileInfo[] pdfList = di.GetFiles("*.pdf", SearchOption.AllDirectories);
                                if (pdfList.Length == 1)
                                {
                                    using (Patagames.Pdf.Net.PdfDocument doc = Patagames.Pdf.Net.PdfDocument.Load(pdfList[0].FullName))
                                    {
                                        using (MemoryStream stream = new MemoryStream())
                                        {
                                            doc.Save(stream, SaveFlags.RemoveSecurity);

                                            clsBlisterListe cBl = new clsBlisterListe();
                                            cBl.IDKlient = (Guid)rBlister.IDKlient;
                                            cBl.IDRezepteintrag = (Guid)rBlister.IDRezepteeintrag;
                                            cBl.GebDat = (DateTime)rBlister.Geburtsdatum;
                                            cBl.PDF = stream.ToArray();
                                            cBl.Filename = rBlister.Nachname + "_" + rBlister.Vorname + "_" + cBl.GebDat.ToString("yyyyMMdd") + ".pdf";
                                            //Zulässigen Filenamen sicherstellen
                                            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                                            {
                                                cBl.Filename = cBl.Filename.Replace(c, '_');
                                            }
                                            lstBlisterListen.Add(cBl);
                                        }
                                    }
                                    //PDF wieder löschen
                                    File.Delete(pdfList[0].FullName);
                                }
                                else if (pdfList.Length == 0)
                                {
                                    //Keine Änderung in den Rezepteinträgen seit letztem Lauf, es muss nichts geschickt werden
                                }
                                else
                                {
                                    //Fehler: Info an Admin senden. Nicht abbrechen(!), sondern fortsetzen
                                    MessageBox.Show("Mehr als ein PDF gefunden!");
                                }                                
                                Application.DoEvents();
                            }
                            aktKlient = rBlister.IDKlient;
                        }

                        if (bCreateSolidPDF)
                        {
                            // Alle pdfs des temporären Verzeichnisses in ein PDF/A zusammenfassen
                            using (Syncfusion.Pdf.PdfDocument finalDoc = new Syncfusion.Pdf.PdfDocument(PdfConformanceLevel.Pdf_A1B))
                            {
                                finalDoc.Compression = PdfCompressionLevel.Best;
                                foreach (clsBlisterListe cBl in lstBlisterListen)
                                {
                                    Syncfusion.Pdf.PdfDocument.Merge(finalDoc, cBl.PDF);
                                }
                                finalDoc.Save(System.IO.Path.Combine(finalDir, finalFileName + ".PDF"));
                            }
                        }

                        //Zip erstellen
                        using (Chilkat.Zip zip = new Chilkat.Zip())
                        {                            
                            zip.UnlockComponent("S2ENGINEERZIP_SBV9zXKx4T55");
                            zip.NewZip(Path.Combine(finalDir, finalFileName + ".zip"));
                            if (bCreateSolidPDF)
                            {
                                zip.AppendFiles(Path.Combine(finalDir, finalFileName + ".PDF"), false);
                            }
                            else
                            {
                                foreach (clsBlisterListe rBlister1 in lstBlisterListen)
                                {
                                    // Blob als temporäre Datei mit aussagekräftigem Namen abspeichern
                                    // zu Zip hinzufügen
                                    // ganz am Ende wieder löschen
                                    string tmpPDFFile = System.IO.Path.Combine(tmpPDFDir, rBlister1.Filename);
                                    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(rBlister1.PDF);
                                    loadedDocument.Save(tmpPDFFile);
                                    zip.AppendFiles(tmpPDFFile, false);
                                }
                            }
                            zip.PasswordProtect = true;
                            zip.SetPassword("MZ_oD1732!");
                            zip.WriteZipAndClose();
                        }

                        //Send per eMail (hl)

                        //QS2-Protokoll schreiben (hl)

                        //Erfolgsmeldung an Admin per eMail (hl)

                        //Update Rezepteinträge (dtStart = Update für alle Rezepteinträge aus bl)
                        foreach (clsBlisterListe rBlister1 in lstBlisterListen)
                        {
                            System.Linq.IQueryable<PMDS.db.Entities.RezeptEintrag> tRezeptEintrag = b.getRezeptEintragByID(rBlister1.IDRezepteintrag, db);
                            foreach (PMDS.db.Entities.RezeptEintrag rRezepteintrag in tRezeptEintrag)
                            {
                                rRezepteintrag.ZeitpunktBlisterliste = dtStart;
                            }
                        }
                        //db.SaveChanges();
                    }
                    Directory.Delete(tmpPDFDir, true);
            
            }

            catch (Exception ex)
            {
                //Fehlermeldung an Admin per eMail
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                lbliCount.Text = "";
            }
        }
    }
}
