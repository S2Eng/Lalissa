using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using PMDS.BusinessLogic;
using PMDS.Global;
using System.Collections.Generic;
using PMDS.DB;
using System.Linq;
using System.Text.RegularExpressions;

namespace PMDS.GUI
{


	public class frmPatientVermerk : frmBase
    {
        public System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteSelected2 = new List<PMDS.Global.UIGlobal.eSelectedNodes>();
        public QS2.Desktop.ControlManagment.BaseLabel labInfo;
        public ucPflegeEintrag ucPflegeEintrag1;
        private QS2.Desktop.ControlManagment.BaseButton btnCancel2;
        private QS2.Desktop.ControlManagment.BaseButton btnOK2;
        private QS2.Desktop.ControlManagment.BaseButton btnSonderterminErstellen2;
		private System.ComponentModel.IContainer components;
        private ContextMenuStrip contextMenuStripSave;
        private ToolStripMenuItem klientenmehrfachauswahlToolStripMenuItem;
        public QS2.Desktop.ControlManagment.BaseButton btnSaveDekursAsEntwurf;
        private QS2.Desktop.ControlManagment.BaseButton btnLetzteDekurse;
        private TXTextControl.TextControl textControl1;
        private Panel panel1;
        public bool abort = true;

        public QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();
        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
        public QS2.Desktop.ControlManagment.BaseButton btnKlientenMehrfachauswahl;
        private QS2.Desktop.ControlManagment.BaseButton btnListEntwürfeAlias;
        private TXTextControl.TextControl textControlTmp;
        public PMDS.Global.db.ERSystem.PMDSBusinessUI PMDSBusinessUI1 = new Global.db.ERSystem.PMDSBusinessUI();


      
        









        public frmPatientVermerk(Patient pat, string DekursText, bool GegenzeichnenJN, Nullable<Guid> IDFuerUserErstellt)
		{
            System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                this.ucPflegeEintrag1.frmPatientVermerkMainWindow = this;
                labInfo.Text = string.Format(labInfo.Text, pat.FullInfo);
                if (IDFuerUserErstellt != null)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        PMDS.db.Entities.Benutzer rBenutzerFür = this.b.getUser(IDFuerUserErstellt.Value, db);
                        labInfo.Text += " (Erstellt für: " + rBenutzerFür.Nachname.Trim() + " " + rBenutzerFür.Vorname.Trim() + ")";
                    }
                }
                ucPflegeEintrag1.Eintrag = pat.NewVermerk(DekursText, GegenzeichnenJN);
                
                this.btnOK2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
                //this.btnSaveDekursAsEntwurf.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
                this.btnCancel2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abbrechen, 32, 32);

                this.ucPflegeEintrag1.IsDekursEntwurf = false;
                this.ucPflegeEintrag1.IDPflegeeintragEntwurf = null;
                this.ucPflegeEintrag1.IDPatientEntwurf = null;
                this.ucPflegeEintrag1.IDFuerUserErstellt = IDFuerUserErstellt;
                this.ucPflegeEintrag1.DekursTextRtfTemplate = "";

                if (this.ucPflegeEintrag1.IDFuerUserErstellt == null)
                {
                    this.btnListEntwürfeAlias.Visible = false;
                }
                else
                {
                    this.btnListEntwürfeAlias.Visible = true;
                }
            }
		}


		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucPflegeEintrag1 = new PMDS.GUI.ucPflegeEintrag();
            this.btnCancel2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnOK2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.contextMenuStripSave = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.klientenmehrfachauswahlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSonderterminErstellen2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSaveDekursAsEntwurf = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnLetzteDekurse = new QS2.Desktop.ControlManagment.BaseButton();
            this.textControl1 = new TXTextControl.TextControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnKlientenMehrfachauswahl = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnListEntwürfeAlias = new QS2.Desktop.ControlManagment.BaseButton();
            this.textControlTmp = new TXTextControl.TextControl();
            this.contextMenuStripSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // labInfo
            // 
            appearance8.ForeColor = System.Drawing.Color.White;
            appearance8.TextHAlignAsString = "Center";
            appearance8.TextVAlignAsString = "Middle";
            this.labInfo.Appearance = appearance8;
            this.labInfo.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(0, 0);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(836, 48);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "Dekurs für {0}";
            // 
            // ucPflegeEintrag1
            // 
            this.ucPflegeEintrag1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPflegeEintrag1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucPflegeEintrag1.Location = new System.Drawing.Point(0, 48);
            this.ucPflegeEintrag1.Margin = new System.Windows.Forms.Padding(4);
            this.ucPflegeEintrag1.Medikation = false;
            this.ucPflegeEintrag1.Name = "ucPflegeEintrag1";
            this.ucPflegeEintrag1.ReadOnly = false;
            this.ucPflegeEintrag1.RM_OPTIONAL = false;
            this.ucPflegeEintrag1.Size = new System.Drawing.Size(838, 501);
            this.ucPflegeEintrag1.TabIndex = 1;
            // 
            // btnCancel2
            // 
            this.btnCancel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel2.AutoWorkLayout = false;
            this.btnCancel2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel2.IsStandardControl = false;
            this.btnCancel2.Location = new System.Drawing.Point(679, 555);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(88, 32);
            this.btnCancel2.TabIndex = 11;
            this.btnCancel2.Text = "Abbrechen";
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // btnOK2
            // 
            this.btnOK2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance9.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK2.Appearance = appearance9;
            this.btnOK2.AutoWorkLayout = false;
            this.btnOK2.contextMenuStrip1 = this.contextMenuStripSave;
            this.btnOK2.IsStandardControl = false;
            this.btnOK2.Location = new System.Drawing.Point(769, 555);
            this.btnOK2.Name = "btnOK2";
            this.btnOK2.Size = new System.Drawing.Size(48, 32);
            this.btnOK2.TabIndex = 12;
            this.btnOK2.Click += new System.EventHandler(this.btnOK2_Click);
            // 
            // contextMenuStripSave
            // 
            this.contextMenuStripSave.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.klientenmehrfachauswahlToolStripMenuItem});
            this.contextMenuStripSave.Name = "contextMenuStripSave";
            this.contextMenuStripSave.Size = new System.Drawing.Size(212, 26);
            // 
            // klientenmehrfachauswahlToolStripMenuItem
            // 
            this.klientenmehrfachauswahlToolStripMenuItem.Name = "klientenmehrfachauswahlToolStripMenuItem";
            this.klientenmehrfachauswahlToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.klientenmehrfachauswahlToolStripMenuItem.Text = "Klientenmehrfachauswahl";
            // 
            // btnSonderterminErstellen2
            // 
            this.btnSonderterminErstellen2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSonderterminErstellen2.Appearance = appearance2;
            this.btnSonderterminErstellen2.AutoWorkLayout = false;
            this.btnSonderterminErstellen2.IsStandardControl = false;
            this.btnSonderterminErstellen2.Location = new System.Drawing.Point(7, 555);
            this.btnSonderterminErstellen2.Name = "btnSonderterminErstellen2";
            this.btnSonderterminErstellen2.Size = new System.Drawing.Size(108, 33);
            this.btnSonderterminErstellen2.TabIndex = 0;
            this.btnSonderterminErstellen2.Text = "Termin erstellen";
            this.btnSonderterminErstellen2.Click += new System.EventHandler(this.btnSonderterminErstellen2_Click);
            // 
            // btnSaveDekursAsEntwurf
            // 
            this.btnSaveDekursAsEntwurf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSaveDekursAsEntwurf.Appearance = appearance3;
            this.btnSaveDekursAsEntwurf.AutoWorkLayout = false;
            this.btnSaveDekursAsEntwurf.contextMenuStrip1 = null;
            this.btnSaveDekursAsEntwurf.IsStandardControl = false;
            this.btnSaveDekursAsEntwurf.Location = new System.Drawing.Point(541, 555);
            this.btnSaveDekursAsEntwurf.Name = "btnSaveDekursAsEntwurf";
            this.btnSaveDekursAsEntwurf.Size = new System.Drawing.Size(127, 32);
            this.btnSaveDekursAsEntwurf.TabIndex = 10;
            this.btnSaveDekursAsEntwurf.Text = "Als Entwurf speichern";
            this.btnSaveDekursAsEntwurf.Visible = false;
            this.btnSaveDekursAsEntwurf.Click += new System.EventHandler(this.btnSaveEntwurfAsDekurs_Click);
            // 
            // btnLetzteDekurse
            // 
            this.btnLetzteDekurse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnLetzteDekurse.Appearance = appearance4;
            this.btnLetzteDekurse.AutoWorkLayout = false;
            this.btnLetzteDekurse.IsStandardControl = false;
            this.btnLetzteDekurse.Location = new System.Drawing.Point(117, 555);
            this.btnLetzteDekurse.Name = "btnLetzteDekurse";
            this.btnLetzteDekurse.Size = new System.Drawing.Size(105, 33);
            this.btnLetzteDekurse.TabIndex = 1;
            this.btnLetzteDekurse.Text = "Dekurse der letzten 14 Tage";
            this.btnLetzteDekurse.Click += new System.EventHandler(this.btnLetzteDekurse_Click);
            // 
            // textControl1
            // 
            this.textControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(475, 577);
            this.textControl1.Name = "textControl1";
            this.textControl1.Size = new System.Drawing.Size(50, 35);
            this.textControl1.TabIndex = 5;
            this.textControl1.Text = "textControl1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(469, 569);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(69, 46);
            this.panel1.TabIndex = 6;
            // 
            // btnKlientenMehrfachauswahl
            // 
            this.btnKlientenMehrfachauswahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnKlientenMehrfachauswahl.Appearance = appearance5;
            this.btnKlientenMehrfachauswahl.AutoWorkLayout = false;
            this.btnKlientenMehrfachauswahl.IsStandardControl = false;
            this.btnKlientenMehrfachauswahl.Location = new System.Drawing.Point(224, 555);
            this.btnKlientenMehrfachauswahl.Name = "btnKlientenMehrfachauswahl";
            this.btnKlientenMehrfachauswahl.Size = new System.Drawing.Size(127, 33);
            this.btnKlientenMehrfachauswahl.TabIndex = 2;
            this.btnKlientenMehrfachauswahl.Text = "Klienten Mehrfachauswahl";
            this.btnKlientenMehrfachauswahl.UseAppStyling = false;
            this.btnKlientenMehrfachauswahl.Click += new System.EventHandler(this.btnKlientenMehrfachauswahl_Click);
            // 
            // btnListEntwürfeAlias
            // 
            this.btnListEntwürfeAlias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnListEntwürfeAlias.Appearance = appearance6;
            this.btnListEntwürfeAlias.AutoWorkLayout = false;
            this.btnListEntwürfeAlias.IsStandardControl = false;
            this.btnListEntwürfeAlias.Location = new System.Drawing.Point(353, 555);
            this.btnListEntwürfeAlias.Name = "btnListEntwürfeAlias";
            this.btnListEntwürfeAlias.Size = new System.Drawing.Size(105, 33);
            this.btnListEntwürfeAlias.TabIndex = 3;
            this.btnListEntwürfeAlias.Text = "Liste Entwürfe Alias";
            this.btnListEntwürfeAlias.Visible = false;
            this.btnListEntwürfeAlias.Click += new System.EventHandler(this.btnListEntwürfeAlias_Click);
            // 
            // textControlTmp
            // 
            this.textControlTmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textControlTmp.Font = new System.Drawing.Font("Arial", 10F);
            this.textControlTmp.Location = new System.Drawing.Point(493, 577);
            this.textControlTmp.Name = "textControlTmp";
            this.textControlTmp.Size = new System.Drawing.Size(48, 35);
            this.textControlTmp.TabIndex = 13;
            this.textControlTmp.Text = "textControl2";
            // 
            // frmPatientVermerk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel2;
            this.ClientSize = new System.Drawing.Size(836, 591);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textControlTmp);
            this.Controls.Add(this.btnListEntwürfeAlias);
            this.Controls.Add(this.btnKlientenMehrfachauswahl);
            this.Controls.Add(this.textControl1);
            this.Controls.Add(this.btnLetzteDekurse);
            this.Controls.Add(this.btnSaveDekursAsEntwurf);
            this.Controls.Add(this.btnSonderterminErstellen2);
            this.Controls.Add(this.btnOK2);
            this.Controls.Add(this.btnCancel2);
            this.Controls.Add(this.ucPflegeEintrag1);
            this.Controls.Add(this.labInfo);
            this.Name = "frmPatientVermerk";
            this.Text = "Dekurs";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmPatientVermerk_Load);
            this.VisibleChanged += new System.EventHandler(this.frmPatientVermerk_VisibleChanged);
            this.contextMenuStripSave.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion



		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		}


        private void frmPatientVermerk_Load(object sender, EventArgs e)
        {
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);
            this.BackColor = System.Drawing.Color.WhiteSmoke  ;
            this.labInfo.Appearance.BackColor = System.Drawing.Color.Gray ;
            //this.ucPflegeEintrag1.txtBeschreibung.Width = this.Width - this.ucPflegeEintrag1.Left - 50;    //lthxy

        }

        public void SonderterminErstellen()
        {
            try
            {
                ucSiteMapTermine ucSiteMap = null;
                GuiAction.InsertTermin(ucPflegeEintrag1.Eintrag.IDAufenthalt, false, (Form)GuiWorkflow.mainWindow, ucSiteMap, ucPflegeEintrag1.Eintrag.ID, null);
                
            }
            catch (Exception ex)
            {
                throw new Exception("SonderterminErstellen: " + ex.ToString());
            }
        }
        public void lastDekurse()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    int LastDays = 14;
                    DateTime dFrom = DateTime.Now.AddDays(LastDays * -1);
                    IQueryable<PMDS.db.Entities.vÜbergabe> tvÜbergabeRow = this.b.getvÜbergabe(dFrom, PflegeEintragTyp.DEKURS, db, ENV.CurrentIDPatient);

                    string sLine = "";
                    string LineRtf = "";
                    string LinePlain = "";
                    QS2.Desktop.Txteditor.frmTxtEditorField frmEditor = null;
                    this.PMDSBusinessUI1.initFormDekurse(ref frmEditor, ref this.textControl1, ref sLine, ref LineRtf, ref LinePlain);

                    foreach (PMDS.db.Entities.vÜbergabe rÜbergabe in tvÜbergabeRow)
                    {
                        string infoRow = rÜbergabe.Klient.Trim() + ", " + rÜbergabe.Maßnahme.Trim() + "\r\n";
                        this.PMDSBusinessUI1.printDekurse(ref frmEditor, ref this.textControl1, rÜbergabe.DekursRtf.Trim(), rÜbergabe.Dekurs.Trim(), rÜbergabe.Benutzer.Trim(),
                                                            rÜbergabe.Zusatzwerte.Trim(), rÜbergabe.Maßnahme.Trim(), rÜbergabe.Zeitpunkt.Trim(), ref infoRow, ref sLine, ref LineRtf, ref LinePlain);
                    }
                    //frmEditor.ContTxtEditor1.LinealeOnOff(false);
                    frmEditor.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurse der letzten " + LastDays.ToString() + " Tage");
                    frmEditor.ContTXTField1.TXTControlField.Selection.Start = 0;
                    frmEditor.ContTXTField1.TXTControlField.Selection.Length = 0;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmPatientVermerk.lastDekurse: " + ex.ToString());
            }
        }

        public void ReadInEditorDoLine(string txtRtf, string txtPlain,
                                ref string InfoRow, ref string sLine, TXTextControl.TextControl textControl1,
                                ref string LineRtf, ref string LinePlain)
        {
            try
            {

                //this.textControl1.Text = "";
                //this.doEditor1.showText(infoRow.Trim(), TXTextControl.StreamType.PlainText, false, TXTextControl.ViewMode.Normal, this.textControl1, ref b, ref b);
                //string InfoRtf = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.textControl1);
                //string InfoPlain = this.doEditor1.getText(TXTextControl.StringStreamType.PlainText, this.textControl1);

                if (txtRtf.Trim() == "")
                {
                    if (txtPlain.Trim() != "")
                    {
                        //this.doEditor1.appendText2(InfoPlain.Trim(), frmEditor.ContTxtEditor1.textControl1, TXTextControl.StringStreamType.PlainText);
                        this.doEditor1.appendText2(txtPlain.Trim(), textControl1, TXTextControl.StringStreamType.PlainText);
                        //this.doEditor1.insertLinebreakxy(frmEditor.ContTxtEditor1.textControl1);
                        //this.doEditor1.appendText2(LinePlain.Trim(), frmEditor.ContTxtEditor1.textControl1, TXTextControl.StringStreamType.PlainText);
                        //this.doEditor1.insertPagebreak(frmEditor.ContTxtEditor1.textControl1);
                    }
                }
                else
                {
                    //this.doEditor1.appendText2(InfoRtf.Trim(), frmEditor.ContTxtEditor1.textControl1, TXTextControl.StringStreamType.RichTextFormat);
                    try
                    {
                        this.doEditor1.appendText2(txtRtf.Trim(), textControl1, TXTextControl.StringStreamType.RichTextFormat);
                    }
                    catch (Exception ex)
                    {
                        if (txtPlain.Trim() != "")
                        {
                            this.doEditor1.appendText2(txtPlain.Trim(), textControl1, TXTextControl.StringStreamType.PlainText);
                        }
                        else
                        {
                            this.doEditor1.appendText2(txtRtf.Trim(), textControl1, TXTextControl.StringStreamType.PlainText);
                        }
                    }
                    //this.doEditor1.insertLinebreakxy(frmEditor.ContTxtEditor1.textControl1);
                    //this.doEditor1.appendText2(LineRtf.Trim(), frmEditor.ContTxtEditor1.textControl1, TXTextControl.StringStreamType.RichTextFormat);
                    //this.doEditor1.insertPagebreak(frmEditor.ContTxtEditor1.textControl1);
                }

                int Position2 = textControl1.InputPosition.TextPosition;
                this.doEditor1.appendText2(LinePlain.Trim(), textControl1, TXTextControl.StringStreamType.PlainText);
                textControl1.Select(Position2, textControl1.Text.Length - Position2);
                textControl1.Selection.FontSize = 9 * 20;
                textControl1.Selection.FontName = "Arial";
                textControl1.Selection.ForeColor = System.Drawing.Color.Black;
                textControl1.Selection.Bold = false;

            }
            catch (Exception ex)
            {
                throw new Exception("frmPatientVermerk.doLineReadEditor: " + ex.ToString());
            }
        }

        private void frmPatientVermerk_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void btnOK2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.saveDekurs(true);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        public bool validateData()
        {
            try
            {
                return PMDS.Global.db.ERSystem.PMDSBusinessUI.checkTxtRegex(this.ucPflegeEintrag1.contTXTFieldBeschreibung.TXTControlField.Text, true);

            }
            catch (Exception ex)
            {
                throw new Exception("frmPatientVermerk.validateData: " + ex.ToString());
            }
        }
        public void saveDekurs(bool SaveEntwurfAsDekurs, Nullable<DateTime> IDTimeRepeat = null)
        {
            Nullable<DateTime> IDTime = null;
            if (IDTimeRepeat != null)
            {
                IDTime = IDTimeRepeat;
            }
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();

                bool IsDekursEntwurfTmp = this.ucPflegeEintrag1.IsDekursEntwurf;
                if (SaveEntwurfAsDekurs)
                {
                    IsDekursEntwurfTmp = false;
                }

                if (!ucPflegeEintrag1.ValidateFields())
                    return;

                if (!this.validateData())
                    return;

                if (!IsDekursEntwurfTmp)
                {
                    if (!this.checkMehrfachauswahlKlienten(false))
                    {
                        return;
                    }

                    ucPflegeEintrag1.Eintrag.ID = System.Guid.NewGuid();
                    if (this.ucPflegeEintrag1.IDFuerUserErstellt != null)
                    {

                        ucPflegeEintrag1.Eintrag.IDBenutzer = ucPflegeEintrag1.IDFuerUserErstellt.Value;
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                        {
                            PMDS.db.Entities.Benutzer rBenutzerEntwurf = PMDSBusiness1.getUser(ucPflegeEintrag1.Eintrag.IDBenutzer, db);
                            if (rBenutzerEntwurf.IDBerufsstand != null)
                            {
                                ucPflegeEintrag1.Eintrag.IDBerufsstand = rBenutzerEntwurf.IDBerufsstand.Value;
                            }
                            else
                            {
                                ucPflegeEintrag1.Eintrag.IDBerufsstand = System.Guid.Empty;
                            }
                        }
                    }
                    ucPflegeEintrag1.UpdateDATA();
                    ucPflegeEintrag1.Eintrag.Write();

                    Guid IDGruppe = System.Guid.NewGuid();
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                    {
                        IQueryable<PMDS.db.Entities.PflegeEintrag> lstPEorig = db.PflegeEintrag.Where(pe => pe.ID == this.ucPflegeEintrag1.Eintrag.ID);
                        PMDS.db.Entities.PflegeEintrag rPEeOriginal = lstPEorig.First();
                        rPEeOriginal.IDGruppe = IDGruppe;
                        db.SaveChanges();
                    }

                    if (this.lstPatienteSelected2.Count > 0)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                        {
                            this.textControlTmp.Text = "";
                            PMDSBusiness1.CopyAndAddPflegeeinträgeCC2(this.ucPflegeEintrag1.Eintrag.ID, ref this.lstPatienteSelected2, db, ucPflegeEintrag1.Eintrag.IDAufenthalt, this.textControlTmp, "", ref IDGruppe);
                        }
                    }
                    System.Collections.Generic.List<Guid> lstPEToCopy = new System.Collections.Generic.List<Guid>();
                    this.ucPflegeEintrag1.auswahlGruppeComboMulti1.AddCC2(this.ucPflegeEintrag1.Eintrag.ID, this.ucPflegeEintrag1.IsNew, false, this.ucPflegeEintrag1.Eintrag.AbzeichnenJN,
                                                                            ucPflegeEintrag1.Eintrag.IDWichtig, ref lstPEToCopy, false, ref IDGruppe);

                    using (PMDS.db.Entities.ERModellPMDSEntities dbCopyPD = PMDS.DB.PMDSBusiness.getDBContext())
                    {
                        foreach (Guid IDPEToCopy in lstPEToCopy)
                        {
                            this.textControlTmp.Text = "";
                            PMDSBusiness1.CopyAndAddPflegeeinträgeCC2(IDPEToCopy, ref this.lstPatienteSelected2, dbCopyPD, ucPflegeEintrag1.Eintrag.IDAufenthalt, this.textControlTmp, this.ucPflegeEintrag1.Eintrag.PflegeplanText.Trim(), ref IDGruppe);
                        }
                    }

                    //using (PMDS.db.Entities.ERModellPMDSEntities dbZW = PMDS.DB.PMDSBusiness.getDBContext())
                    //{
                    //    PMDSBusiness1.copyUpdateZusatzwertePEIDGruppe(this.ucPflegeEintrag1.Eintrag.ID, dbZW);
                    //}

                    int iCounterArtzabrechnungen = 0;
                    PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                    if (ENV.HasRight(UserRights.AutomatischeArztabrechungseinträge))
                    {
                        DateTime dNow = DateTime.Now;
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            Guid IDPatientTmp = ENV.CurrentIDPatient;
                            if (SaveEntwurfAsDekurs && this.ucPflegeEintrag1.IDPatientEntwurf != null)
                            {
                                IDPatientTmp = ucPflegeEintrag1.IDPatientEntwurf.Value;
                            }
                            Guid IDUserArztabrechnungTmp = ENV.USERID;
                            if (SaveEntwurfAsDekurs && ucPflegeEintrag1.Eintrag.IDBenutzer != null)
                            {
                                IDUserArztabrechnungTmp = ucPflegeEintrag1.Eintrag.IDBenutzer;
                            }
                            string ProtocolHeader = "Dekurs ID " + ucPflegeEintrag1.Eintrag.ID.ToString() + ", Zeitpunkt: " + ucPflegeEintrag1.Eintrag.DatumErstellt.ToString();
                            if (b.doArztabrechnungen(db, IDPatientTmp, dNow, ref iCounterArtzabrechnungen, IDUserArztabrechnungTmp, ProtocolHeader))
                            {
                                db.SaveChanges();
                            }
                            foreach (PMDS.Global.UIGlobal.eSelectedNodes SelectedNodes in this.lstPatienteSelected2)
                            {
                                ProtocolHeader = "Dekurs (CC) ID " + ucPflegeEintrag1.Eintrag.ID.ToString() + ", Zeitpunkt: " + ucPflegeEintrag1.Eintrag.DatumErstellt.ToString();
                                if (b.doArztabrechnungen(db, SelectedNodes.IDKlient.Value, dNow, ref iCounterArtzabrechnungen, IDUserArztabrechnungTmp, ProtocolHeader))
                                {
                                    db.SaveChanges();
                                }
                            }
                        }
                    }

                    if (this.ucPflegeEintrag1.IsDekursEntwurf && this.ucPflegeEintrag1.IDPflegeeintragEntwurf != null)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            IQueryable<PMDS.db.Entities.PflegeEintragEntwurf> tPflegeEintragEntwurf = db.PflegeEintragEntwurf.Where(pe => pe.ID == this.ucPflegeEintrag1.IDPflegeeintragEntwurf.Value);

                            if (tPflegeEintragEntwurf.Count() == 1)
                            {
                                PMDS.db.Entities.PflegeEintragEntwurf rPflegeEintragEntwurf = tPflegeEintragEntwurf.First();
                                db.PflegeEintragEntwurf.Remove(rPflegeEintragEntwurf);
                                db.SaveChanges();
                            }
                        }
                        if (ucTermineEx.frmDekurseListeDistinct != null)
                        {
                            ucTermineEx.frmDekurseListeDistinct.ucDekurseListe1.loadData();
                        }
                    }

                    // do Dienstübergabe
                    this.textControlTmp.Text = "";
                    System.Collections.Generic.List<Guid> lstSelectedCC = new System.Collections.Generic.List<Guid>();
                    System.Collections.Generic.List<int> lstIntSelected = new System.Collections.Generic.List<int>();
                    System.Collections.Generic.List<string> lstStringSelected = new System.Collections.Generic.List<string>();

                    this.ucPflegeEintrag1.auswahlGruppeComboMulti1.getSelected(ref lstSelectedCC, ref lstIntSelected, ref lstStringSelected);
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                    {
                        foreach (Guid IDBerufsgruppe in lstSelectedCC)
                        {
                            if (IDBerufsgruppe.Equals(PMDSBusiness.IDSelListDienstübergabe))
                            {
                                this.textControlTmp.Text = "";
                                PMDSBusiness1.writeDienstübergabeForPatient(PMDSBusiness.IDSelListDienstübergabe, this.ucPflegeEintrag1.Eintrag.ID, db, this.textControlTmp);
                                //PMDSBusiness1.CopyAndAddPflegeeinträgeCC(db, IDPflegeEIntrag, ref lstSelectedCC, CopyAsDekurs, true, abzeichnenJN, IDWichtig, ref lstPEToCopy, IsNotfall);
                            }
                        }
                    }
                }
                else
                {
                    if (!this.checkMehrfachauswahlKlienten(true))
                    {
                        return;
                    }

                    ucPflegeEintrag1.UpdateDATA();
                    //ucPflegeEintrag1.Eintrag.Write();
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        //IQueryable<PMDS.db.Entities.PflegeEintrag> tPflegeEintragOrig = db.PflegeEintrag.Where(pe => pe.ID == ucPflegeEintrag1.Eintrag.ID);
                        //PMDS.db.Entities.PflegeEintrag rPflegeEintragOrig = tPflegeEintragOrig.First();

                        bool isNew = false;
                        PMDS.db.Entities.PflegeEintragEntwurf rPflegeEintragEntwurfAct = null;
                        if (this.ucPflegeEintrag1.IDPflegeeintragEntwurf == null)
                        {
                            rPflegeEintragEntwurfAct = PMDS.Global.db.ERSystem.EFEntities.newPflegeEintragEntwurf(db);
                            rPflegeEintragEntwurfAct.ID = System.Guid.NewGuid();
                            rPflegeEintragEntwurfAct.FuerUserErstellt = this.ucPflegeEintrag1.IDFuerUserErstellt;
                            //PMDSBusiness1.CopyPflegeEintragToDekursEntwurf(rPflegeEintragEntwurfAct, rPflegeEintragOrig, db);
                            isNew = true;
                        }
                        else
                        {
                            IQueryable<PMDS.db.Entities.PflegeEintragEntwurf> tPflegeEintragEntwurf = db.PflegeEintragEntwurf.Where(pe => pe.ID == ucPflegeEintrag1.IDPflegeeintragEntwurf.Value);
                            rPflegeEintragEntwurfAct = tPflegeEintragEntwurf.First();
                        }
                        this.ucPflegeEintrag1.saveGUIEntwurf(ref rPflegeEintragEntwurfAct, ref this.lstPatienteSelected2, db);
                        if (isNew)
                        {
                            db.PflegeEintragEntwurf.Add(rPflegeEintragEntwurfAct);
                        }
                        
                        db.SaveChanges();
                        foreach (PMDS.Global.UIGlobal.eSelectedNodes SelectedNodes in lstPatienteSelected2)
                        {
                            if (!SelectedNodes.IDAufenthalt.Equals(rPflegeEintragEntwurfAct.IDAufenthalt))
                            {
                                this.textControlTmp.Text = "";
                                PMDS.db.Entities.PflegeEintragEntwurf rPflegeEintragEntwurfNew = PMDS.Global.db.ERSystem.EFEntities.newPflegeEintragEntwurf(db);
                                this.b.CopyPflegeEintragEntwurf(rPflegeEintragEntwurfNew, rPflegeEintragEntwurfAct);
                                rPflegeEintragEntwurfNew.ID = System.Guid.NewGuid();
                                rPflegeEintragEntwurfNew.IDAufenthalt = SelectedNodes.IDAufenthalt.Value;

                                if (SelectedNodes.Txt.Trim() != "")
                                {
                                    this.b.addTxtToPE(null, rPflegeEintragEntwurfNew, SelectedNodes, db, this.textControlTmp, this.ucPflegeEintrag1.Eintrag.PflegeplanText.Trim());
                                }

                                db.PflegeEintragEntwurf.Add(rPflegeEintragEntwurfNew);
                                db.SaveChanges();
                            }
                            else
                            {
                                if (SelectedNodes.Txt.Trim() != "" && !SelectedNodes.bDone)
                                {
                                    IQueryable<PMDS.db.Entities.PflegeEintragEntwurf> lstPEEntwurf = db.PflegeEintragEntwurf.Where(pe => pe.ID == rPflegeEintragEntwurfAct.ID);
                                    PMDS.db.Entities.PflegeEintragEntwurf peOriginalEntwurf = lstPEEntwurf.First();

                                    this.b.addTxtToPE(null, peOriginalEntwurf, SelectedNodes, db, this.textControlTmp, this.ucPflegeEintrag1.Eintrag.PflegeplanText.Trim());
                                    db.SaveChanges();
                                    SelectedNodes.bDone = true;
                                }
                            }
                        }

                        //db.PflegeEintrag.Remove(rPflegeEintragOrig);
                        //db.SaveChanges();

                        if (ucTermineEx.frmDekurseListeDistinct != null)
                        {
                            ucTermineEx.frmDekurseListeDistinct.ucDekurseListe1.loadData();
                        }
                    }
                }

                this.abort = false;
                this.Close();

            }
            catch (Exception ex)
            {
                if (PMDS.DB.PMDSBusiness.handleExceptionsServerNotReachable(ref IDTime, ex, "frmPatientVermerk.saveDekurs"))
                {
                    this.saveDekurs(SaveEntwurfAsDekurs, IDTime);
                }
                throw new Exception("frmPatientVermerk.saveDekurs: " + ex.ToString());
            }
        }
        public bool checkMehrfachauswahlKlienten(bool SaveEntwürfe)
        {
            try
            {
                PMDS.DB.PMDSBusiness b1 = new DB.PMDSBusiness();
                if (this.lstPatienteSelected2.Count > 0)
                {
                    string sInfoPatients = "";
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        foreach (PMDS.Global.UIGlobal.eSelectedNodes SelectedNodes in this.lstPatienteSelected2)
                        {
                            Guid IDPatient = new Guid(SelectedNodes.IDKlient.Value.ToString());
                            var rPatInfo = (from p in db.Patient
                                            where p.ID == IDPatient
                                            select new
                                            { p.Nachname, p.Vorname }
                                               ).First();
                            //PMDS.db.Entities.Patient rPatient = b1.getPatient(SelectedNodes.IDKlient.Value, db);
                            sInfoPatients += rPatInfo.Nachname.Trim() + " " + rPatInfo.Vorname.Trim() + "\r\n";
                        }
                    }

                    string sQuest = "";
                    string sQuest2 = "";
                    if (SaveEntwürfe)
                    {
                        sQuest = QS2.Desktop.ControlManagment.ControlManagment.getRes("Für folgende Patienten werden zusätzlich aufgrund der Mehrfachauswahl Dekurs-Entwürfe erstellt:");
                        sQuest2 = QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie diese Dekurse-Entwürfe wirklich erstellen?");
                    }
                    else
                    {
                        sQuest = QS2.Desktop.ControlManagment.ControlManagment.getRes("Für folgende Patienten werden zusätzlich aufgrund der Mehrfachauswahl Dekurse erstellt:");
                        sQuest2 = QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie diese Dekurse wirklich erstellen?");
                    }

                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sQuest + "\r\n" + "\r\n" +  sInfoPatients + "\r\n" + "\r\n" + sQuest2, "", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("checkMehrfachauswahlKlienten: " + ex.ToString());
            }
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.Close();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnSonderterminErstellen2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.SonderterminErstellen();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void KlientenMehrfachauswahl()
        {
            try
            {
                PMDS.GUI.GUI.Main.frmPatientenmehrfachauswahl frmPatientenmehrfachauswahl1 = new GUI.Main.frmPatientenmehrfachauswahl();
                frmPatientenmehrfachauswahl1.lstPatienteSelected = this.lstPatienteSelected2;
                frmPatientenmehrfachauswahl1.initControl();
                frmPatientenmehrfachauswahl1.ShowDialog(this);
                if (!frmPatientenmehrfachauswahl1.abort)
                {
                    this.lstPatienteSelected2 = frmPatientenmehrfachauswahl1.lstPatienteSelected;
                    this.btnKlientenMehrfachauswahl.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Klienten Mehrfachauswahl") + " (" + this.lstPatienteSelected2.Count.ToString() + ")";
                    if (this.lstPatienteSelected2.Count > 0)
                    {
                        this.btnKlientenMehrfachauswahl.Appearance.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.btnKlientenMehrfachauswahl.Appearance.ForeColor = Color.Black;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("KlientenMehrfachauswahl: " + ex.ToString());
            }
        }

        private void btnSaveEntwurfAsDekurs_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.saveDekurs(false);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnLetzteDekurse_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.lastDekurse();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnKlientenMehrfachauswahl_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.KlientenMehrfachauswahl();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnListEntwürfeAlias_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GUI.Main.frmDekurseListe frmDekurseListe1 = new GUI.Main.frmDekurseListe();
                frmDekurseListe1.initControl(GUI.Main.ucDekurseListe.eTypeUI.Alias, this.ucPflegeEintrag1.IDFuerUserErstellt);
                frmDekurseListe1.ucDekurseListe1.loadData();
                frmDekurseListe1.Show();
                //frmDekurseListe1.Visible = true;

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

    }
}
