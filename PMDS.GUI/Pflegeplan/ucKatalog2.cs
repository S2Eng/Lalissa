//----------------------------------------------------------------------------------------------
//	ucKatalog.cs
//  Verwaltung eines Kataloges
//  Erstellt am:	15.9.2004
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;
using Infragistics.Win;
using PMDS.Data.PflegePlan;
using PMDS.Data.Global;
using PMDS.Global.db.Pflegeplan;
using PMDS.Global.db.ERSystem;

using System.Linq;
using PMDS.DB;
using S2Extensions;

namespace PMDS.GUI
{


	public class ucKatalog2 : QS2.Desktop.ControlManagment.BaseControl
	{

		public Katalog					_Katalog;		
		public event EventHandler		ValueChanged;						// Wird ausgelöst wenn sich im Datagrid was ändert inkl. hinzufügen, entfernen
		private Guid					ASZMID = Guid.Empty;				// mit dieser Guid wird immer gearbeitet
		private bool NewASZM = false;

		private bool								_preventValueChanged = false;
        private StandardProzeduren _StandardProzeduren; //Neu nach 11.06.2007 MDA
        private EintragStandardprozeduren _EintragStandardprozeduren;//Neu nach 11.06.2007 MDA
        private int _originalHeigth, _lvStProzedurenHeigth;

        private dsEintrag dsEintrag1;
		private QS2.Desktop.ControlManagment.BaseComboEditor cbSicht;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtASZM;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtWarnhinweis;
		private QS2.Desktop.ControlManagment.BaseLabel lSicht;
		private QS2.Desktop.ControlManagment.BaseLabel lASZM;
		private QS2.Desktop.ControlManagment.BaseLabel lWarnhinweis;
        private QS2.Desktop.ControlManagment.BaseLabel lblTyp;
        private QS2.Desktop.ControlManagment.BaseLabel lLinkDokument;
        private PMDS.GUI.BaseControls.LinkDokumenteCombo cbLinkDokument;
        private PMDS.GUI.BaseControls.EintragtypCombo cbEintragTyp;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbBedarfsmedikation;
        private QS2.Desktop.ControlManagment.BaseButton btnShowDocument;
        private QS2.Desktop.ControlManagment.BaseLabel lblStProzeduren;
        private Infragistics.Win.UltraWinListView.UltraListView lvStProzeduren;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbMOhnezeitbezug;
        private IContainer components;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEntferntJN;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpMain;
        private QS2.Desktop.ControlManagment.BaseLabel baseLabel1;
        internal Infragistics.Win.Misc.UltraPopupControlContainer UltraPopupControlContainer_Formulare;
        private QS2.Desktop.ControlManagment.BasePanel PanelFormulare;
        public UltraGrid gridFormulare;
        private QS2.Desktop.ControlManagment.BaseLabel lblFormulare;
        private Global.db.ERSystem.dsKlientenliste dsKlientenliste1;
        private sqlManange sqlManange1;
        public bool AlleEinträge = false;
        private Panel panelDropDownFormulare;
        internal Infragistics.Win.Misc.UltraDropDownButton dropFormulare;
        private Abrechnung.Global.dsPatientPflegestufe dsPatientPflegestufe1;
        private QS2.Desktop.ControlManagment.BaseLabel lblPflegestufeneinschaetzung;
        private BaseControls.PflegestufenEinschaetzung cbPflegestufenEinschaetzung;
        public PMDSBusiness b = new PMDSBusiness();





        public ucKatalog2()
		{
			InitializeComponent();
			
			if(ENV.AppRunning) 
			{
				cbSicht.Items.Add(ENV.String("CBPatient"));
				cbSicht.Items.Add(ENV.String("CBPfleger"));
                cbSicht.Items.Add(ENV.String("CBArzt"));
                //Neu nach 11.06.2007 MDA
                _StandardProzeduren = new StandardProzeduren();
                _StandardProzeduren.Read();
                FillStanddardprozeduren();

                this.loadFormulare();
            }
		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// Der Datatable für den Katalog
		/// </summary>
		//----------------------------------------------------------------------------
		public Katalog KATALOG 
		{
			get 
			{
				return _Katalog;
			}
			set 
			{
				if(value == null)
					return;
				_Katalog				= value;
                ShowHideFields();
			}
		}
        //Neu nach 11.06.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Listview mit alle definierte Standdardprozeduren ausfüllen
        /// </summary>
        //----------------------------------------------------------------------------
        private void FillStanddardprozeduren()
        {
            lvStProzeduren.Items.Clear();

            UltraListViewItem item;

            foreach (dsStandardProzeduren.StandardProzedurenRow r in _StandardProzeduren.ALL.StandardProzeduren)
            {
                item = lvStProzeduren.Items.Add(r.ID.ToString(), r.Name);
                item.Tag = r.ID;
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Anzeigen und verstecken der Felder
        /// 10.4.2007 rbu: M um Haken Bedarfsmedikation erweitert
        /// </summary>
        //----------------------------------------------------------------------------
        private void ShowHideFields()
        {
            bool bA = _Katalog.GROUP == 'A';
            bool bS = _Katalog.GROUP == 'S';
            bool bR = _Katalog.GROUP == 'R';
            bool bZ = _Katalog.GROUP == 'Z';
            bool bM = _Katalog.GROUP == 'M';

            cbSicht.Visible = (bS || bM);
            lSicht.Visible = (bS || bM);


            cbLinkDokument.Visible = bM;
            lLinkDokument.Visible = bM;
            btnShowDocument.Visible = bM;

            cbEintragTyp.Visible = bM;
            lblTyp.Visible = bM;

            cbPflegestufenEinschaetzung.Visible = bM && ENV.lic_PflegestufenEinschätzung;
            lblPflegestufeneinschaetzung.Visible = bM && ENV.lic_PflegestufenEinschätzung; ;

            cbBedarfsmedikation.Visible = bM;               // Checkbox nur sichtbar bei M
            cbMOhnezeitbezug.Visible    = bM;
            this.chkEntferntJN.Visible = true;

            //Neu nach 11.06.2007 MDA
            Height = (bM) ? _originalHeigth : _originalHeigth - _lvStProzedurenHeigth;
            lblStProzeduren.Visible = bM;
            lvStProzeduren.Visible = bM;
            this.lblFormulare.Visible = bM;
            this.dropFormulare.Visible = bM;
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Setzt den Eingabefocus auf den Texteditor
		/// </summary>
		//----------------------------------------------------------------------------
	

		public void FocusOnASZMText()
		{
			txtASZM.Focus();			
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Speichert die Änderungen
		/// liefert false wenn ein Fehler aufgetreten ist
		/// </summary>
		//----------------------------------------------------------------------------
		public bool Save() 
		{
			bool bError = false;
									
			if(txtASZM.Text.Trim().Length == 0)
			{
				bError = true;
				
				txtASZM.Appearance.BackColor = ENVCOLOR.ERROR_BACK_COLOR; //TextBox färben
				txtASZM.Appearance.ForeColor = ENVCOLOR.ERROR_FORE_COLOR;
			}
			else 
			{					
				txtASZM.Appearance.BackColor = Color.White;
				txtASZM.Appearance.ForeColor = Color.Black;
			}
			

			if(bError) 
			{
				QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("GUI.E_NO_TEXT"), ENV.String("DIALOGTITLE_INPUTERROR"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
				//CellUpdated();				// Signal nach außen das was schief gegangen ist
				return false;
			}
			else 
			{
                foreach (dsEintrag.EintragRow rr in _Katalog.EINTRAEGE.Rows)
                {
                    if (rr.ID.Equals(ASZMID))
                    {
                        if (cbSicht.SelectedItem != null)
                            rr.Sicht = cbSicht.SelectedItem.DisplayText;
                        
                        rr.Text                 = txtASZM.Text;
                        rr.Warnhinweis          = txtWarnhinweis.Text;
                        if (this.cbEintragTyp.IsItemInList() == false)
                        {
                            rr.flag = 0;
                        }
                        else
                        {
                            rr.flag = (int)cbEintragTyp.EintragTyp;
                        }
                        if (ENV.lic_PflegestufenEinschätzung)
                        {
                            rr.PSEKlasse = cbPflegestufenEinschaetzung.SelectedItem.DisplayText;
                        }

                        rr.BedarfsMedikationJN  = cbBedarfsmedikation.Checked;
                        rr.OhneZeitBezug        = cbMOhnezeitbezug.Checked;
                        rr.EntferntJN = this.chkEntferntJN.Checked;

                        if (cbLinkDokument.IDLinkDokument == Guid.Empty)
                            rr.SetIDLinkDokumentNull();
                        else
                            rr.IDLinkDokument   = cbLinkDokument.IDLinkDokument;

                        rr.lstFormulare = this.saveListFormulare();
                    }
                }
				_Katalog.Write();
				
                //Neu nach 11.06.2007 MDA
                //Neue Standardprozeduren speichern
                if(_Katalog.GROUP == 'M')
                    _EintragStandardprozeduren.UpdateZuordnungen(ASZMID, GetStandardprozeduren());


				NewASZM = false;
				return true;
			}
		
		}
        //Neu nach 11.06.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle ausgewählten Standardprozeduren zurückgeben.
        /// </summary>
        //----------------------------------------------------------------------------
        private Guid[] GetStandardprozeduren()
        {
            List<Guid> list = new List<Guid>();

            foreach (UltraListViewItem item in lvStProzeduren.Items)
            {
                if (item.CheckState == CheckState.Checked)
                    list.Add((Guid)item.Tag);
            }

            return list.ToArray();
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liest den aktuellen Stand wieder ein
		/// </summary>
		//----------------------------------------------------------------------------
		public void Undo() 
		{
            try
            {
                txtASZM.Appearance.BackColor = Color.White;
                txtASZM.Appearance.ForeColor = Color.Black;

                if (NewASZM)
                {
                    _Katalog.Read(this.AlleEinträge);
                    ClearFields();
                    NewASZM = false;
                    return;
                }
                _Katalog.Read(this.AlleEinträge);

                _preventValueChanged = true;
                int c = 0;

                dsEintrag.EintragRow r = _Katalog.EINTRAEGE.FindByID(ASZMID);

                txtASZM.Text = r.Text;
                txtWarnhinweis.Text = r.Warnhinweis;
                cbEintragTyp.EintragTyp = (EintragFlag)r.flag;
                if (ENV.lic_PflegestufenEinschätzung)
                {
                    cbPflegestufenEinschaetzung.PSEKlasse = r.PSEKlasse;
                }
                cbBedarfsmedikation.Checked = r.BedarfsMedikationJN;
                cbMOhnezeitbezug.Checked = r.OhneZeitBezug;
                this.chkEntferntJN.Checked = r.EntferntJN;

                cbLinkDokument.IDLinkDokument = r.IsIDLinkDokumentNull() ? Guid.Empty : r.IDLinkDokument;

                foreach (ValueListItem i in cbSicht.Items)

                    if (i.DisplayText.Equals(r.Sicht))
                    {
                        cbSicht.SelectedItem = i;
                        c++;
                    }
                
                if (c == 0) cbSicht.SelectedItem = null;

                //Neu nach 11.06.2007 MDA
                if (_Katalog.GROUP == 'M')
                {
                    _EintragStandardprozeduren = new EintragStandardprozeduren(ASZMID);
                    EditStandardprozedurenZuordnungen();
                }

                this.showListFormulare(r.lstFormulare);

                _preventValueChanged = false;
            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
		}

        public void loadFormulare()
        {
            try
            {
                this.dsKlientenliste1.Clear();
                this.gridFormulare.Refresh();

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var tFormulare = (from f in db.Formular
                                   orderby f.Name ascending
                                   where f.GUI == true && f.PDF_BLOP != null
                                   select new
                                   {
                                       Bezeichnung = f.Bezeichnung.Trim(),
                                       Name = f.Name,
                                    });


                    //System.Linq.IQueryable<db.Entities.FormularDaten> tFormulare = this.b.getAllFormularDaten(db);

                    foreach (var rFormular in tFormulare)
                    {
                        PMDS.Global.db.ERSystem.dsKlientenliste.tSelectSimpleRow rNewtSelectSimple = this.sqlManange1.getNewtSelectSimpleSelect(ref this.dsKlientenliste1);
                        rNewtSelectSimple.Text = rFormular.Bezeichnung.Trim();
                        rNewtSelectSimple.IDTxt = rFormular.Name.Trim();
                    }
                }

                this.gridFormulare.Refresh();

                this.resetFormulare();

            }
            catch (Exception ex)
            {
                throw new Exception("ucKatalog2.loadFormulare: " + ex.ToString());
            }
        }
        public void resetFormulare()
        {
            try
            {
                foreach (UltraGridRow rGrid in this.gridFormulare.Rows)
                {
                    DataRowView v = (DataRowView)rGrid.ListObject;
                    dsKlientenliste.tSelectSimpleRow rtSelectSimple = (dsKlientenliste.tSelectSimpleRow)v.Row;

                    rtSelectSimple.Select = false;
                }
                this.gridFormulare.Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception("ucKatalog2.resetFormulare: " + ex.ToString());
            }
        }

        public void showTextFormulareInDropDown()
        {
            try
            {
                this.gridFormulare.UpdateData();
                this.dropFormulare.Text = "";

                foreach (UltraGridRow rGrid in this.gridFormulare.Rows)
                {
                    DataRowView v = (DataRowView)rGrid.ListObject;
                    dsKlientenliste.tSelectSimpleRow rtSelectSimple = (dsKlientenliste.tSelectSimpleRow)v.Row;

                    if (rtSelectSimple.Select)
                    {
                        this.dropFormulare.Text += rtSelectSimple.Text.Trim() + ";";
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucKatalog2.showTextFormulareInDropDown: " + ex.ToString());
            }
        }

        public void showListFormulare(string lstFormulare)
        {
            try
            {
                this.resetFormulare();

                System.Collections.Generic.List<string> lstSelectedFormulare = qs2.core.generic.readStrVariables(lstFormulare.Trim());
                if (lstSelectedFormulare.Count > 0)
                {
                    foreach (UltraGridRow rGrid in this.gridFormulare.Rows)
                    {
                        DataRowView v = (DataRowView)rGrid.ListObject;
                        dsKlientenliste.tSelectSimpleRow rtSelectSimple = (dsKlientenliste.tSelectSimpleRow)v.Row;

                        var tFormSelected = (from f in lstSelectedFormulare
                                       where f == rtSelectSimple.IDTxt.ToString()
                                           select new
                                           {
                                               IDFormular = f
                                           });
                        if (tFormSelected.Count() > 0)
                        {
                            rtSelectSimple.Select = true;
                        }
                    }

                    this.gridFormulare.Refresh();
                }

                this.showTextFormulareInDropDown();

            }
            catch (Exception ex)
            {
                throw new Exception("ucKatalog2.showListFormulare: " + ex.ToString());
            }
        }
        public string saveListFormulare()
        {
            try
            {
                string lstFormulareTmp = "";
                foreach (UltraGridRow rGrid in this.gridFormulare.Rows)
                {
                    DataRowView v = (DataRowView)rGrid.ListObject;
                    dsKlientenliste.tSelectSimpleRow rtSelectSimple = (dsKlientenliste.tSelectSimpleRow)v.Row;

                    if (rtSelectSimple.Select)
                    {
                        lstFormulareTmp += rtSelectSimple.IDTxt.Trim() + ";";
                    }
                }

                return lstFormulareTmp.Trim();
            }
            catch (Exception ex)
            {
                throw new Exception("ucKatalog2.saveListFormulare: " + ex.ToString());
            }
        }




        public Guid AddNew() 
		{	
			txtASZM.Appearance.BackColor = Color.White;
			txtASZM.Appearance.ForeColor = Color.Black;

			ASZMID = Guid.NewGuid();
		    dsEintrag.EintragRow ROW = _Katalog.EINTRAEGE.AddEintragRow(ASZMID,KATALOG.GROUP.ToString(),false,"","","", 0, Guid.Empty, false, false, "", "");
            ClearFields();
			
			if(_Katalog.GROUP =='M') {grpMain.Text = ENV.String("New_M") + " " + ENV.String("ADD"); lASZM.Text = ENV.String("New_M") +" :";}
			if(_Katalog.GROUP =='S') {grpMain.Text = ENV.String("New_S") + " " + ENV.String("ADD"); lASZM.Text = ENV.String("New_S") +" :";}
            if(_Katalog.GROUP =='R') {grpMain.Text = ENV.String("New_R") + " " + ENV.String("ADD"); lASZM.Text = ENV.String("New_R") + " :"; }
            if(_Katalog.GROUP =='A') {grpMain.Text = ENV.String("New_A") + " " + ENV.String("ADD"); lASZM.Text = ENV.String("New_A") + " :"; }
			if(_Katalog.GROUP =='Z') {grpMain.Text = ENV.String("New_Z") + " " + ENV.String("ADD"); lASZM.Text = ENV.String("New_Z") +" :";}
			
		
			NewASZM = true;

            //Neu nach 11.06.2007 MDA
            if (_Katalog.GROUP == 'M')
                _EintragStandardprozeduren = new EintragStandardprozeduren(ASZMID);
			return ASZMID;
		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// Inhalt der Felder rücksetzen
        /// </summary>
        //----------------------------------------------------------------------------
        private void ClearFields()
        {
            txtASZM.Text = "";
            txtWarnhinweis.Text = "";
            cbLinkDokument.IDLinkDokument = Guid.Empty;
            //if (_Katalog.GROUP == 'A')
            //    cbEintragTyp.EintragTyp = EintragFlag.Aetiologie;
            //else
            cbEintragTyp.EintragTyp = EintragFlag.Einzelabzeichnung;
            if (ENV.lic_PflegestufenEinschätzung)
            {
                cbPflegestufenEinschaetzung.PSEKlasse = cbPflegestufenEinschaetzung.strDefault;
                cbPflegestufenEinschaetzung.SelectedItem = null;
            }
            cbSicht.SelectedItem = null;
            cbBedarfsmedikation.Checked = false;
            cbMOhnezeitbezug.Checked = false;
            this.chkEntferntJN.Checked = false;
            ClearStandardProzedurenZuordnungen(); //Neu nach 11.06.2007 MDA

            this.resetFormulare();
        }

        //Neu nach 11.06.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Inhalt der StandardProzeduren rücksetzen
        /// </summary>
        //----------------------------------------------------------------------------
        private void ClearStandardProzedurenZuordnungen()
        {
            foreach (UltraListViewItem item in lvStProzeduren.Items)
                item.CheckState = CheckState.Unchecked;
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Löscht den aktuell markierten Eintrag (Markiert EntferntJN)
		/// </summary>
		//----------------------------------------------------------------------------
		public void DeleteCurrent() 
		{
			foreach(dsEintrag.EintragRow r in _Katalog.EINTRAEGE.Rows)
				if(r.ID.Equals(ASZMID))
				{
					r.EntferntJN = true;
					break;
				}


            ClearFields();

			_Katalog.Write();
			
			NewASZM = false;
		}

		//----------------------------------------------------------------------------
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tSelectSimple", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Select");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Text", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDTxt");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(237479188);
            Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(249722376);
            Infragistics.Win.ValueList valueList3 = new Infragistics.Win.ValueList(180063047);
            this.cbSicht = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.txtASZM = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lSicht = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lASZM = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtWarnhinweis = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lWarnhinweis = new QS2.Desktop.ControlManagment.BaseLabel();
            this.grpMain = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.lblPflegestufeneinschaetzung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkEntferntJN = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lvStProzeduren = new Infragistics.Win.UltraWinListView.UltraListView();
            this.lblStProzeduren = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblFormulare = new QS2.Desktop.ControlManagment.BaseLabel();
            this.baseLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnShowDocument = new QS2.Desktop.ControlManagment.BaseButton();
            this.cbMOhnezeitbezug = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lLinkDokument = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblTyp = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbBedarfsmedikation = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panelDropDownFormulare = new System.Windows.Forms.Panel();
            this.dropFormulare = new Infragistics.Win.Misc.UltraDropDownButton();
            this.UltraPopupControlContainer_Formulare = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.PanelFormulare = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbPflegestufenEinschaetzung = new PMDS.GUI.BaseControls.PflegestufenEinschaetzung();
            this.cbLinkDokument = new PMDS.GUI.BaseControls.LinkDokumenteCombo();
            this.cbEintragTyp = new PMDS.GUI.BaseControls.EintragtypCombo();
            this.gridFormulare = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.dsKlientenliste1 = new PMDS.Global.db.ERSystem.dsKlientenliste();
            this.dsEintrag1 = new PMDS.Global.db.Pflegeplan.dsEintrag();
            this.sqlManange1 = new PMDS.Global.db.ERSystem.sqlManange(this.components);
            this.dsPatientPflegestufe1 = new PMDS.Abrechnung.Global.dsPatientPflegestufe();
            ((System.ComponentModel.ISupportInitialize)(this.cbSicht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtASZM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWarnhinweis)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEntferntJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvStProzeduren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMOhnezeitbezug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBedarfsmedikation)).BeginInit();
            this.panelDropDownFormulare.SuspendLayout();
            this.PanelFormulare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbPflegestufenEinschaetzung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLinkDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEintragTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFormulare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEintrag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientPflegestufe1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSicht
            // 
            this.cbSicht.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbSicht.Location = new System.Drawing.Point(120, 43);
            this.cbSicht.Name = "cbSicht";
            this.cbSicht.Size = new System.Drawing.Size(160, 24);
            this.cbSicht.TabIndex = 1;
            this.cbSicht.SelectionChanged += new System.EventHandler(this.txtASZM_ValueChanged);
            // 
            // txtASZM
            // 
            this.txtASZM.AlwaysInEditMode = true;
            this.txtASZM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtASZM.Location = new System.Drawing.Point(120, 17);
            this.txtASZM.Multiline = true;
            this.txtASZM.Name = "txtASZM";
            this.txtASZM.Size = new System.Drawing.Size(695, 23);
            this.txtASZM.TabIndex = 0;
            this.txtASZM.ValueChanged += new System.EventHandler(this.txtASZM_ValueChanged);
            // 
            // lSicht
            // 
            this.lSicht.Location = new System.Drawing.Point(16, 42);
            this.lSicht.Name = "lSicht";
            this.lSicht.Padding = new System.Drawing.Size(0, 4);
            this.lSicht.Size = new System.Drawing.Size(100, 23);
            this.lSicht.TabIndex = 10;
            this.lSicht.Text = "Sicht";
            // 
            // lASZM
            // 
            this.lASZM.Location = new System.Drawing.Point(16, 17);
            this.lASZM.Name = "lASZM";
            this.lASZM.Padding = new System.Drawing.Size(0, 4);
            this.lASZM.Size = new System.Drawing.Size(100, 23);
            this.lASZM.TabIndex = 9;
            this.lASZM.Text = "ASRZM";
            // 
            // txtWarnhinweis
            // 
            this.txtWarnhinweis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarnhinweis.Location = new System.Drawing.Point(120, 70);
            this.txtWarnhinweis.Multiline = true;
            this.txtWarnhinweis.Name = "txtWarnhinweis";
            this.txtWarnhinweis.Size = new System.Drawing.Size(695, 21);
            this.txtWarnhinweis.TabIndex = 3;
            this.txtWarnhinweis.ValueChanged += new System.EventHandler(this.txtASZM_ValueChanged);
            // 
            // lWarnhinweis
            // 
            this.lWarnhinweis.Location = new System.Drawing.Point(16, 69);
            this.lWarnhinweis.Name = "lWarnhinweis";
            this.lWarnhinweis.Padding = new System.Drawing.Size(0, 4);
            this.lWarnhinweis.Size = new System.Drawing.Size(100, 23);
            this.lWarnhinweis.TabIndex = 14;
            this.lWarnhinweis.Text = "Hinweis";
            // 
            // grpMain
            // 
            this.grpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMain.Controls.Add(this.lblPflegestufeneinschaetzung);
            this.grpMain.Controls.Add(this.cbPflegestufenEinschaetzung);
            this.grpMain.Controls.Add(this.chkEntferntJN);
            this.grpMain.Controls.Add(this.lvStProzeduren);
            this.grpMain.Controls.Add(this.lblStProzeduren);
            this.grpMain.Controls.Add(this.lblFormulare);
            this.grpMain.Controls.Add(this.baseLabel1);
            this.grpMain.Controls.Add(this.btnShowDocument);
            this.grpMain.Controls.Add(this.cbMOhnezeitbezug);
            this.grpMain.Controls.Add(this.lLinkDokument);
            this.grpMain.Controls.Add(this.cbLinkDokument);
            this.grpMain.Controls.Add(this.cbEintragTyp);
            this.grpMain.Controls.Add(this.lblTyp);
            this.grpMain.Controls.Add(this.lWarnhinweis);
            this.grpMain.Controls.Add(this.txtWarnhinweis);
            this.grpMain.Controls.Add(this.lASZM);
            this.grpMain.Controls.Add(this.lSicht);
            this.grpMain.Controls.Add(this.txtASZM);
            this.grpMain.Controls.Add(this.cbSicht);
            this.grpMain.Controls.Add(this.cbBedarfsmedikation);
            this.grpMain.Controls.Add(this.panelDropDownFormulare);
            this.grpMain.Controls.Add(this.PanelFormulare);
            this.grpMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpMain.Location = new System.Drawing.Point(16, 3);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(831, 354);
            this.grpMain.TabIndex = 15;
            this.grpMain.TabStop = false;
            // 
            // lblPflegestufeneinschaetzung
            // 
            this.lblPflegestufeneinschaetzung.Location = new System.Drawing.Point(514, 42);
            this.lblPflegestufeneinschaetzung.Name = "lblPflegestufeneinschaetzung";
            this.lblPflegestufeneinschaetzung.Padding = new System.Drawing.Size(0, 4);
            this.lblPflegestufeneinschaetzung.Size = new System.Drawing.Size(66, 23);
            this.lblPflegestufeneinschaetzung.TabIndex = 132;
            this.lblPflegestufeneinschaetzung.Text = "PSE-Krit.:";
            // 
            // chkEntferntJN
            // 
            this.chkEntferntJN.Location = new System.Drawing.Point(120, 91);
            this.chkEntferntJN.Name = "chkEntferntJN";
            this.chkEntferntJN.Size = new System.Drawing.Size(37, 23);
            this.chkEntferntJN.TabIndex = 4;
            this.chkEntferntJN.CheckedChanged += new System.EventHandler(this.chkEntferntJN_CheckedChanged);
            // 
            // lvStProzeduren
            // 
            this.lvStProzeduren.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvStProzeduren.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance1.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvStProzeduren.ItemSettings.ActiveAppearance = appearance1;
            appearance2.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvStProzeduren.ItemSettings.SelectedAppearance = appearance2;
            this.lvStProzeduren.ItemSettings.SelectionType = Infragistics.Win.UltraWinListView.SelectionType.Single;
            this.lvStProzeduren.Location = new System.Drawing.Point(120, 191);
            this.lvStProzeduren.Name = "lvStProzeduren";
            this.lvStProzeduren.Size = new System.Drawing.Size(695, 163);
            this.lvStProzeduren.TabIndex = 9;
            this.lvStProzeduren.Text = "ultraListView1";
            this.lvStProzeduren.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List;
            this.lvStProzeduren.ViewSettingsList.CheckBoxStyle = Infragistics.Win.UltraWinListView.CheckBoxStyle.CheckBox;
            this.lvStProzeduren.ViewSettingsList.ImageSize = new System.Drawing.Size(0, 0);
            this.lvStProzeduren.ItemCheckStateChanged += new Infragistics.Win.UltraWinListView.ItemCheckStateChangedEventHandler(this.lvStProzeduren_ItemCheckStateChanged);
            // 
            // lblStProzeduren
            // 
            this.lblStProzeduren.Location = new System.Drawing.Point(16, 192);
            this.lblStProzeduren.Name = "lblStProzeduren";
            this.lblStProzeduren.Padding = new System.Drawing.Size(0, 4);
            this.lblStProzeduren.Size = new System.Drawing.Size(115, 23);
            this.lblStProzeduren.TabIndex = 22;
            this.lblStProzeduren.Text = "Standardprozeduren:";
            // 
            // lblFormulare
            // 
            this.lblFormulare.Location = new System.Drawing.Point(16, 115);
            this.lblFormulare.Name = "lblFormulare";
            this.lblFormulare.Padding = new System.Drawing.Size(0, 4);
            this.lblFormulare.Size = new System.Drawing.Size(100, 23);
            this.lblFormulare.TabIndex = 129;
            this.lblFormulare.Text = "Assessments";
            // 
            // baseLabel1
            // 
            this.baseLabel1.Location = new System.Drawing.Point(16, 91);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Padding = new System.Drawing.Size(0, 4);
            this.baseLabel1.Size = new System.Drawing.Size(100, 23);
            this.baseLabel1.TabIndex = 24;
            this.baseLabel1.Text = "Entfernt J/N";
            // 
            // btnShowDocument
            // 
            this.btnShowDocument.AutoWorkLayout = false;
            this.btnShowDocument.IsStandardControl = false;
            this.btnShowDocument.Location = new System.Drawing.Point(503, 140);
            this.btnShowDocument.Name = "btnShowDocument";
            this.btnShowDocument.Size = new System.Drawing.Size(75, 26);
            this.btnShowDocument.TabIndex = 5;
            this.btnShowDocument.Text = "anzeigen";
            this.btnShowDocument.Click += new System.EventHandler(this.btnShowDocument_Click);
            // 
            // cbMOhnezeitbezug
            // 
            this.cbMOhnezeitbezug.Location = new System.Drawing.Point(120, 169);
            this.cbMOhnezeitbezug.Name = "cbMOhnezeitbezug";
            this.cbMOhnezeitbezug.Size = new System.Drawing.Size(264, 20);
            this.cbMOhnezeitbezug.TabIndex = 7;
            this.cbMOhnezeitbezug.Text = "Maßnahme ohne Zeitbezug";
            this.cbMOhnezeitbezug.CheckedChanged += new System.EventHandler(this.cbMOhnezeitbezug_CheckedChanged);
            // 
            // lLinkDokument
            // 
            this.lLinkDokument.Location = new System.Drawing.Point(16, 140);
            this.lLinkDokument.Name = "lLinkDokument";
            this.lLinkDokument.Padding = new System.Drawing.Size(0, 4);
            this.lLinkDokument.Size = new System.Drawing.Size(100, 23);
            this.lLinkDokument.TabIndex = 18;
            this.lLinkDokument.Text = "Dokument";
            // 
            // lblTyp
            // 
            this.lblTyp.Location = new System.Drawing.Point(300, 42);
            this.lblTyp.Name = "lblTyp";
            this.lblTyp.Padding = new System.Drawing.Size(0, 4);
            this.lblTyp.Size = new System.Drawing.Size(33, 23);
            this.lblTyp.TabIndex = 15;
            this.lblTyp.Text = "Typ";
            // 
            // cbBedarfsmedikation
            // 
            this.cbBedarfsmedikation.Location = new System.Drawing.Point(391, 169);
            this.cbBedarfsmedikation.Name = "cbBedarfsmedikation";
            this.cbBedarfsmedikation.Size = new System.Drawing.Size(424, 20);
            this.cbBedarfsmedikation.TabIndex = 8;
            this.cbBedarfsmedikation.Text = "Diese Maßnahme dient zum Abzeichnen von Einzelverordnungen";
            this.cbBedarfsmedikation.CheckedChanged += new System.EventHandler(this.cbBedarfsmedikation_CheckedChanged);
            // 
            // panelDropDownFormulare
            // 
            this.panelDropDownFormulare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDropDownFormulare.Controls.Add(this.dropFormulare);
            this.panelDropDownFormulare.Location = new System.Drawing.Point(120, 114);
            this.panelDropDownFormulare.Name = "panelDropDownFormulare";
            this.panelDropDownFormulare.Size = new System.Drawing.Size(380, 24);
            this.panelDropDownFormulare.TabIndex = 130;
            // 
            // dropFormulare
            // 
            this.dropFormulare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dropFormulare.Location = new System.Drawing.Point(0, 0);
            this.dropFormulare.Name = "dropFormulare";
            this.dropFormulare.PopupItemKey = "PanelFormulare";
            this.dropFormulare.PopupItemProvider = this.UltraPopupControlContainer_Formulare;
            this.dropFormulare.Size = new System.Drawing.Size(378, 22);
            this.dropFormulare.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.dropFormulare.TabIndex = 6;
            // 
            // UltraPopupControlContainer_Formulare
            // 
            this.UltraPopupControlContainer_Formulare.PopupControl = this.PanelFormulare;
            // 
            // PanelFormulare
            // 
            this.PanelFormulare.Controls.Add(this.gridFormulare);
            this.PanelFormulare.Location = new System.Drawing.Point(6, 195);
            this.PanelFormulare.Name = "PanelFormulare";
            this.PanelFormulare.Size = new System.Drawing.Size(391, 339);
            this.PanelFormulare.TabIndex = 128;
            this.PanelFormulare.Visible = false;
            // 
            // cbPflegestufenEinschaetzung
            // 
            this.cbPflegestufenEinschaetzung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPflegestufenEinschaetzung.Location = new System.Drawing.Point(584, 43);
            this.cbPflegestufenEinschaetzung.Name = "cbPflegestufenEinschaetzung";
            this.cbPflegestufenEinschaetzung.PSEKlasse = "";
            this.cbPflegestufenEinschaetzung.Size = new System.Drawing.Size(231, 24);
            this.cbPflegestufenEinschaetzung.strDefault = null;
            this.cbPflegestufenEinschaetzung.TabIndex = 131;
            this.cbPflegestufenEinschaetzung.ValueChanged += new System.EventHandler(this.cbPflegestufenEinschaetzung_ValueChanged);
            // 
            // cbLinkDokument
            // 
            this.cbLinkDokument.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbLinkDokument.IDLinkDokument = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cbLinkDokument.Location = new System.Drawing.Point(120, 141);
            this.cbLinkDokument.Name = "cbLinkDokument";
            this.cbLinkDokument.Size = new System.Drawing.Size(380, 24);
            this.cbLinkDokument.TabIndex = 6;
            this.cbLinkDokument.ValueChanged += new System.EventHandler(this.cbLinkDokument_ValueChanged);
            // 
            // cbEintragTyp
            // 
            this.cbEintragTyp.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbEintragTyp.EintragTyp = PMDS.Global.EintragFlag.Einzelabzeichnung;
            this.cbEintragTyp.Location = new System.Drawing.Point(339, 43);
            this.cbEintragTyp.Name = "cbEintragTyp";
            this.cbEintragTyp.Size = new System.Drawing.Size(160, 24);
            this.cbEintragTyp.TabIndex = 2;
            this.cbEintragTyp.ValueChanged += new System.EventHandler(this.cbEintragTyp_ValueChanged);
            // 
            // gridFormulare
            // 
            this.gridFormulare.DataMember = "tSelectSimple";
            this.gridFormulare.DataSource = this.dsKlientenliste1;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BorderColor = System.Drawing.Color.Black;
            this.gridFormulare.DisplayLayout.Appearance = appearance3;
            this.gridFormulare.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.Header.Caption = "Auswahl";
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.Caption = "Formular";
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            ultraGridBand1.SummaryFooterCaption = "Summe";
            this.gridFormulare.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            appearance4.BackColor = System.Drawing.Color.Gainsboro;
            appearance4.FontData.BoldAsString = "True";
            this.gridFormulare.DisplayLayout.CaptionAppearance = appearance4;
            this.gridFormulare.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.BorderColor = System.Drawing.SystemColors.Window;
            this.gridFormulare.DisplayLayout.GroupByBox.Appearance = appearance5;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridFormulare.DisplayLayout.GroupByBox.BandLabelAppearance = appearance6;
            this.gridFormulare.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridFormulare.DisplayLayout.GroupByBox.Prompt = "Ziehen Sie eine Spalte herein  nach der Sie gruppieren möchten:";
            appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance7.BackColor2 = System.Drawing.SystemColors.Control;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridFormulare.DisplayLayout.GroupByBox.PromptAppearance = appearance7;
            this.gridFormulare.DisplayLayout.MaxColScrollRegions = 1;
            this.gridFormulare.DisplayLayout.MaxRowScrollRegions = 1;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridFormulare.DisplayLayout.Override.ActiveCellAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance9.ForeColor = System.Drawing.Color.Blue;
            this.gridFormulare.DisplayLayout.Override.ActiveRowAppearance = appearance9;
            this.gridFormulare.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridFormulare.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            this.gridFormulare.DisplayLayout.Override.CardAreaAppearance = appearance10;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridFormulare.DisplayLayout.Override.CellAppearance = appearance11;
            this.gridFormulare.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.gridFormulare.DisplayLayout.Override.CellPadding = 0;
            appearance12.BackColor = System.Drawing.SystemColors.Control;
            appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance12.BorderColor = System.Drawing.SystemColors.Window;
            this.gridFormulare.DisplayLayout.Override.GroupByRowAppearance = appearance12;
            this.gridFormulare.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridFormulare.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridFormulare.DisplayLayout.Override.RowAlternateAppearance = appearance13;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.BorderColor = System.Drawing.Color.Silver;
            this.gridFormulare.DisplayLayout.Override.RowAppearance = appearance14;
            this.gridFormulare.DisplayLayout.Override.RowSpacingAfter = 2;
            this.gridFormulare.DisplayLayout.Override.RowSpacingBefore = 2;
            this.gridFormulare.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridFormulare.DisplayLayout.Override.TemplateAddRowAppearance = appearance15;
            valueList1.Key = "Konto";
            valueList2.Key = "Währung";
            valueList3.Key = "Status";
            this.gridFormulare.DisplayLayout.ValueLists.AddRange(new Infragistics.Win.ValueList[] {
            valueList1,
            valueList2,
            valueList3});
            this.gridFormulare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFormulare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridFormulare.Location = new System.Drawing.Point(0, 0);
            this.gridFormulare.Name = "gridFormulare";
            this.gridFormulare.Size = new System.Drawing.Size(391, 339);
            this.gridFormulare.TabIndex = 103;
            this.gridFormulare.Tag = "";
            this.gridFormulare.Text = "Ergebnis";
            this.gridFormulare.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.gridFormulare_CellChange);
            this.gridFormulare.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.gridFormulare_BeforeCellActivate);
            // 
            // dsKlientenliste1
            // 
            this.dsKlientenliste1.DataSetName = "dsKlientenliste";
            this.dsKlientenliste1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsKlientenliste1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsEintrag1
            // 
            this.dsEintrag1.DataSetName = "dsEintrag";
            this.dsEintrag1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsEintrag1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsPatientPflegestufe1
            // 
            this.dsPatientPflegestufe1.DataSetName = "dsPatientPflegestufe";
            this.dsPatientPflegestufe1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsPatientPflegestufe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucKatalog2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.grpMain);
            this.Name = "ucKatalog2";
            this.Size = new System.Drawing.Size(880, 361);
            this.Load += new System.EventHandler(this.ucKatalog2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbSicht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtASZM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWarnhinweis)).EndInit();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEntferntJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvStProzeduren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMOhnezeitbezug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBedarfsmedikation)).EndInit();
            this.panelDropDownFormulare.ResumeLayout(false);
            this.PanelFormulare.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbPflegestufenEinschaetzung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLinkDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEintragTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFormulare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenliste1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEintrag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientPflegestufe1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		//----------------------------------------------------------------------------
		/// <summary> 
		///	zeigt die ASZM  mit der mitgelieferten GUID zum bearbeiten an
		/// </summary>
		//----------------------------------------------------------------------------
		public void EditOneASZM(Guid ID)
		{
			txtASZM.Appearance.BackColor = Color.White;
			txtASZM.Appearance.ForeColor = Color.Black;

			if(_Katalog.GROUP =='M') {grpMain.Text = ENV.String("MSingle")+ " " +ENV.String("EDIT"); lASZM.Text = ENV.String("MSingle")+" :";}
			if(_Katalog.GROUP =='S') {grpMain.Text = ENV.String("SSingle")+ " " +ENV.String("EDIT"); lASZM.Text = ENV.String("SSingle")+" :";}
            if(_Katalog.GROUP =='R') { grpMain.Text = ENV.String("RSingle") + " " + ENV.String("EDIT"); lASZM.Text = ENV.String("RSingle") + " :"; }
            if(_Katalog.GROUP =='A') { grpMain.Text = ENV.String("ASingle") + " " + ENV.String("EDIT"); lASZM.Text = ENV.String("ASingle") + " :"; }
			if(_Katalog.GROUP =='Z') {grpMain.Text = ENV.String("ZSingle")+ " " +ENV.String("EDIT"); lASZM.Text = ENV.String("ZSingle")+" :";}
			

			ASZMID = ID;

			_preventValueChanged = true;
			_Katalog.Read(this.AlleEinträge);
			int c=0;
            dsEintrag.EintragRow r          = _Katalog.EINTRAEGE.FindByID(ID);
			txtASZM.Text                    = r.Text;
			txtWarnhinweis.Text             = r.Warnhinweis;
            cbEintragTyp.EintragTyp         = (EintragFlag)r.flag;
            if (ENV.lic_PflegestufenEinschätzung)
            {
                cbPflegestufenEinschaetzung.PSEKlasse = r.PSEKlasse;
            }
            cbBedarfsmedikation.Checked     = r.BedarfsMedikationJN;
            cbMOhnezeitbezug.Checked        = r.OhneZeitBezug;
            this.chkEntferntJN.Checked = r.EntferntJN;

            cbLinkDokument.IDLinkDokument   = r.IsIDLinkDokumentNull() ? Guid.Empty : r.IDLinkDokument;

			foreach(ValueListItem i in cbSicht.Items) 
				if(i.DisplayText.Equals(r.Sicht))
				{
					cbSicht.SelectedItem = i;
					c++;
				}

			if(c==0) cbSicht.SelectedItem = null;

            //Neu nach 11.06.2007 MDA
            if (_Katalog.GROUP == 'M')
            {
                _EintragStandardprozeduren = new EintragStandardprozeduren(ASZMID);
                EditStandardprozedurenZuordnungen();
            }

            this.showListFormulare(r.lstFormulare.Trim());

            _preventValueChanged = false;
		}

        //Neu nach 11.06.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary> 
        ///	Alle zugeordnete Standardprozeduren eines Eintrags werden ausgewähl
        /// </summary>
        //----------------------------------------------------------------------------
        private void EditStandardprozedurenZuordnungen()
        {
            ClearStandardProzedurenZuordnungen();
            foreach (UltraListViewItem item in lvStProzeduren.Items)
            {
                foreach (dsEintragStandardprozeduren.EintragStandardprozedurenRow row in _EintragStandardprozeduren.EintragStProzeduren)
                {
                    if (((Guid)item.Tag) == row.IDStandardProzeduren)
                    {
                        item.CheckState = CheckState.Checked;
                        break;
                    }
                }
            }
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Signalisiert das sich was geändert hat
		/// </summary>
		//----------------------------------------------------------------------------
		private void txtASZM_ValueChanged(object sender, System.EventArgs e)
		{
			DataChanged();
		}

		private void txtWarnhinweis_ValueChanged(object sender, System.EventArgs e)
		{
			DataChanged(); 
		}

		private void cbSicht_SelectionChanged(object sender, System.EventArgs e)
		{
			DataChanged(); 
		}
		private void ucPflegePlanSingleEdit21_ValueChanged(object sender, EventArgs e)
		{
			DataChanged();
		}
		
		private void DataChanged() 
		{
			if( ValueChanged != null && _preventValueChanged == false)
				ValueChanged(this,null);
			
		}

        private void ucKatalog2_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                return;
            cbEintragTyp.RefreshList();
            if (ENV.lic_PflegestufenEinschätzung)
            {
                cbPflegestufenEinschaetzung.RefreshList();
            }
            cbLinkDokument.RefreshList();

            //Neu nach 11.06.2007 MDA
            _originalHeigth = Height;
            _lvStProzedurenHeigth = lvStProzeduren.Height;
        }


        private void cbLinkDokument_ValueChanged(object sender, EventArgs e)
        {
            DataChanged();
            bool b = cbLinkDokument.IDLinkDokument != Guid.Empty;
            btnShowDocument.Enabled = b;
        }

        private void cbBedarfsmedikation_CheckedChanged(object sender, EventArgs e)
        {
            DataChanged();
        }

        private void btnShowDocument_Click(object sender, EventArgs e)
        {
            GuiUtil.ShowLinkDokument(cbLinkDokument.IDLinkDokument);
        }

        private void lvStProzeduren_ItemCheckStateChanged(object sender, ItemCheckStateChangedEventArgs e)
        {
            DataChanged();
        }

        private void chkEntferntJN_CheckedChanged(object sender, EventArgs e)
        {
            DataChanged();
        }


        private void gridFormulare_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.sEquals(this.dsKlientenliste1.tSelectSimple.SelectColumn.ColumnName))
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    e.Cell.Activation = Activation.NoEdit;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridFormulare_CellChange(object sender, CellEventArgs e)
        {
            try
            {
                this.gridFormulare.UpdateData();
                this.showTextFormulareInDropDown();
                this.DataChanged();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void cbPflegestufenEinschaetzung_ValueChanged(object sender, EventArgs e)
        {
            if (ENV.lic_PflegestufenEinschätzung)
                DataChanged();
        }

        private void cbEintragTyp_ValueChanged(object sender, EventArgs e)
        {
            DataChanged();
        }

        private void cbMOhnezeitbezug_CheckedChanged(object sender, EventArgs e)
        {
            DataChanged();
        }

    }
}
