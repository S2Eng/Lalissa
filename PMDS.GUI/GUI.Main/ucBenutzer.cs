using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.GUI.ELGA;

namespace PMDS.GUI
{

    public class ucBenutzer : QS2.Desktop.ControlManagment.BaseControl, IUCBase
    {
        private bool _valueChangeEnabled = true;
        private Benutzer _benutzer;
        public event EventHandler ValueChanged;

        public bool IsInitialized = false;
        public bool IsInitialized2 = false;
        public contELGAUser contELGAUser1 = null;

        public bool BenutzerdatenELGAVerwalten = false;


        private QS2.Desktop.ControlManagment.BaseLabel lblVorname;
        private QS2.Desktop.ControlManagment.BaseLabel lblNachname;
        private QS2.Desktop.ControlManagment.BaseLabel lblBenutzer;
        private QS2.Desktop.ControlManagment.BaseLabel lblBerufsstand;
        private IContainer components;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtVorname;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtNachname;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtBenutzer;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkPfleger;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkAktiv;
        private PMDS.GUI.ucAdresse ucAdresse1;
        private PMDS.GUI.ucKontakt ucKontakt1;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpBenutzer;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpAdresse;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpKontakt;
        private QS2.Desktop.ControlManagment.BaseButton btnPassword;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cbBerufsstand;
        private PMDS.GUI.ucBenutzerGruppe ucBenutzerGruppe1;
        public PMDS.GUI.ucBenutzerAbteilung ucBenutzerAbteilung1;
        private QS2.Desktop.ControlManagment.BaseTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl4;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin groupBoxSMTPAngaben;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtSMTPAbsenderAdresse;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtSMTPPwd;
        private QS2.Desktop.ControlManagment.BaseLabel lblUser;
        private QS2.Desktop.ControlManagment.BaseLabel lblServer;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtSMTPSrv;
        private QS2.Desktop.ControlManagment.BaseLabel lblPasswort;
        private QS2.Desktop.ControlManagment.BaseCheckBox uChkStandardAuthentifizierung;
        private QS2.Desktop.ControlManagment.BaseLabel lblPort;
        private QS2.Desktop.ControlManagment.BaseMaskEdit uMaskSMTPPort;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl5;
        private ucBenutzerEinrichtung ucBenutzerEinrichtung1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkAnonym;
        private QS2.Desktop.ControlManagment.BaseLabel lblIstArzt;
        private QS2.Desktop.ControlManagment.BaseComboEditor cboAerzte;
        private QS2.Desktop.ControlManagment.BaseButton btnDeleteArzt;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkArztabrechnungJN;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl6;
        public ucRechtBenutzer ucRechtBenutzer1;
        public bool _OnlyAbteilungBereiche = false;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl7;
        private Panel panelELGA;
        private BaseControls.AuswahlGruppeCombo cboELGA_AuthorSpeciality;
        private QS2.Desktop.ControlManagment.BaseLabel lblELGA_AuthorSpeciality;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkELGAActive;
        public ucBenutzerEdit mainWindow = null;








        public ucBenutzer()
        {
            InitializeComponent();
            if (DesignMode || !ENV.AppRunning)
                return;
            Benutzer = new Benutzer();
            RequiredFields();
            System.Guid newGuid = System.Guid.NewGuid();
            ENV.evBenutzerSMTPDatenSpeichern += new ENV.benutzerSMTPDatenSpeichernDelegate(this.writeSMTPData);

            PMDS.GUI.ucSiteMapPMDS ucSiteMapPMDS1 = new ucSiteMapPMDS();
            ucSiteMapPMDS1.getAllÄrzte((Infragistics.Win.UltraWinEditors.UltraComboEditor)this.cboAerzte, false, null);

            this.btnDeleteArzt.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);

            IsInitialized2 = true;
        }

        private void ucBenutzer_Load(object sender, System.EventArgs e)
        {
            // Recht notwendig
            ultraTabControl1.Tabs["Rechte"].Visible = true;
            //if (!ENV.HasRight(UserRights.ManageUserRights))
            //{
            //    ultraTabControl1.Tabs["Rechte"].Visible = false;
            //}

            if (!ENV.HasRight(UserRights.PasswordAendern))
            {
                btnPassword.Visible = false;
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            PMDS.BusinessLogic.Benutzer benutzer1 = new PMDS.BusinessLogic.Benutzer();
            PMDS.BusinessLogic.Benutzer benutzer2 = new PMDS.BusinessLogic.Benutzer();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab6 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab5 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab7 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.grpBenutzer = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.chkELGAActive = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cboELGA_AuthorSpeciality = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.lblELGA_AuthorSpeciality = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkArztabrechnungJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.btnDeleteArzt = new QS2.Desktop.ControlManagment.BaseButton();
            this.chkAnonym = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cboAerzte = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.lblIstArzt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtBenutzer = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.chkAktiv = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.btnPassword = new QS2.Desktop.ControlManagment.BaseButton();
            this.txtNachname = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblBerufsstand = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtVorname = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblNachname = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblBenutzer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblVorname = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkPfleger = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbBerufsstand = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.grpAdresse = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.ucAdresse1 = new PMDS.GUI.ucAdresse();
            this.grpKontakt = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.ucKontakt1 = new PMDS.GUI.ucKontakt();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucBenutzerGruppe1 = new PMDS.GUI.ucBenutzerGruppe();
            this.ultraTabPageControl6 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucRechtBenutzer1 = new PMDS.GUI.ucRechtBenutzer();
            this.ultraTabPageControl5 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucBenutzerEinrichtung1 = new PMDS.GUI.ucBenutzerEinrichtung();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ucBenutzerAbteilung1 = new PMDS.GUI.ucBenutzerAbteilung();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.groupBoxSMTPAngaben = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.uMaskSMTPPort = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.lblPort = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtSMTPAbsenderAdresse = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtSMTPPwd = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblUser = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblServer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtSMTPSrv = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblPasswort = new QS2.Desktop.ControlManagment.BaseLabel();
            this.uChkStandardAuthentifizierung = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.ultraTabPageControl7 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panelELGA = new System.Windows.Forms.Panel();
            this.ultraTabControl1 = new QS2.Desktop.ControlManagment.BaseTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ultraTabPageControl1.SuspendLayout();
            this.grpBenutzer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkELGAActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboELGA_AuthorSpeciality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkArztabrechnungJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAnonym)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAerzte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBenutzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNachname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPfleger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBerufsstand)).BeginInit();
            this.grpAdresse.SuspendLayout();
            this.grpKontakt.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            this.ultraTabPageControl6.SuspendLayout();
            this.ultraTabPageControl5.SuspendLayout();
            this.ultraTabPageControl3.SuspendLayout();
            this.ultraTabPageControl4.SuspendLayout();
            this.groupBoxSMTPAngaben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMTPAbsenderAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMTPPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMTPSrv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uChkStandardAuthentifizierung)).BeginInit();
            this.ultraTabPageControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.AutoScroll = true;
            this.ultraTabPageControl1.Controls.Add(this.grpBenutzer);
            this.ultraTabPageControl1.Controls.Add(this.grpAdresse);
            this.ultraTabPageControl1.Controls.Add(this.grpKontakt);
            this.ultraTabPageControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(925, 544);
            // 
            // grpBenutzer
            // 
            this.grpBenutzer.Controls.Add(this.chkELGAActive);
            this.grpBenutzer.Controls.Add(this.cboELGA_AuthorSpeciality);
            this.grpBenutzer.Controls.Add(this.lblELGA_AuthorSpeciality);
            this.grpBenutzer.Controls.Add(this.chkArztabrechnungJN);
            this.grpBenutzer.Controls.Add(this.btnDeleteArzt);
            this.grpBenutzer.Controls.Add(this.chkAnonym);
            this.grpBenutzer.Controls.Add(this.cboAerzte);
            this.grpBenutzer.Controls.Add(this.lblIstArzt);
            this.grpBenutzer.Controls.Add(this.txtBenutzer);
            this.grpBenutzer.Controls.Add(this.chkAktiv);
            this.grpBenutzer.Controls.Add(this.btnPassword);
            this.grpBenutzer.Controls.Add(this.txtNachname);
            this.grpBenutzer.Controls.Add(this.lblBerufsstand);
            this.grpBenutzer.Controls.Add(this.txtVorname);
            this.grpBenutzer.Controls.Add(this.lblNachname);
            this.grpBenutzer.Controls.Add(this.lblBenutzer);
            this.grpBenutzer.Controls.Add(this.lblVorname);
            this.grpBenutzer.Controls.Add(this.chkPfleger);
            this.grpBenutzer.Controls.Add(this.cbBerufsstand);
            this.grpBenutzer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpBenutzer.Location = new System.Drawing.Point(16, 8);
            this.grpBenutzer.Name = "grpBenutzer";
            this.grpBenutzer.Size = new System.Drawing.Size(331, 352);
            this.grpBenutzer.TabIndex = 0;
            this.grpBenutzer.TabStop = false;
            this.grpBenutzer.Text = "Benutzer";
            // 
            // chkELGAActive
            // 
            this.chkELGAActive.Location = new System.Drawing.Point(90, 322);
            this.chkELGAActive.Name = "chkELGAActive";
            this.chkELGAActive.Size = new System.Drawing.Size(137, 20);
            this.chkELGAActive.TabIndex = 20;
            this.chkELGAActive.Text = "Elga Aktiv";
            this.chkELGAActive.CheckedChanged += new System.EventHandler(this.ChkELGAActive_CheckedChanged);
            // 
            // cboELGA_AuthorSpeciality
            // 
            this.cboELGA_AuthorSpeciality.AddEmptyEntry = false;
            this.cboELGA_AuthorSpeciality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboELGA_AuthorSpeciality.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cboELGA_AuthorSpeciality.AutoOpenCBO = true;
            this.cboELGA_AuthorSpeciality.BerufsstandGruppeJNA = 0;
            this.cboELGA_AuthorSpeciality.ExactMatch = true;
            this.cboELGA_AuthorSpeciality.Group = "FAR";
            this.cboELGA_AuthorSpeciality.ID_PEP = -1;
            this.cboELGA_AuthorSpeciality.Location = new System.Drawing.Point(90, 290);
            this.cboELGA_AuthorSpeciality.Name = "cboELGA_AuthorSpeciality";
            this.cboELGA_AuthorSpeciality.PflichtJN = false;
            this.cboELGA_AuthorSpeciality.ShowAddButton = false;
            this.cboELGA_AuthorSpeciality.Size = new System.Drawing.Size(232, 24);
            this.cboELGA_AuthorSpeciality.sys = false;
            this.cboELGA_AuthorSpeciality.TabIndex = 19;
            this.cboELGA_AuthorSpeciality.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblELGA_AuthorSpeciality
            // 
            this.lblELGA_AuthorSpeciality.Location = new System.Drawing.Point(6, 289);
            this.lblELGA_AuthorSpeciality.Name = "lblELGA_AuthorSpeciality";
            this.lblELGA_AuthorSpeciality.Size = new System.Drawing.Size(96, 35);
            this.lblELGA_AuthorSpeciality.TabIndex = 18;
            this.lblELGA_AuthorSpeciality.Text = "ELGA Author speciality";
            // 
            // chkArztabrechnungJN
            // 
            this.chkArztabrechnungJN.Location = new System.Drawing.Point(90, 223);
            this.chkArztabrechnungJN.Name = "chkArztabrechnungJN";
            this.chkArztabrechnungJN.Size = new System.Drawing.Size(203, 20);
            this.chkArztabrechnungJN.TabIndex = 12;
            this.chkArztabrechnungJN.Text = "Arztabrechnung Erfassung";
            this.chkArztabrechnungJN.Visible = false;
            this.chkArztabrechnungJN.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // btnDeleteArzt
            // 
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDeleteArzt.Appearance = appearance1;
            this.btnDeleteArzt.AutoWorkLayout = false;
            this.btnDeleteArzt.IsStandardControl = false;
            this.btnDeleteArzt.Location = new System.Drawing.Point(302, 258);
            this.btnDeleteArzt.Name = "btnDeleteArzt";
            this.btnDeleteArzt.Size = new System.Drawing.Size(23, 24);
            this.btnDeleteArzt.TabIndex = 11;
            this.btnDeleteArzt.Click += new System.EventHandler(this.btnDeleteArzt_Click);
            // 
            // chkAnonym
            // 
            this.chkAnonym.Location = new System.Drawing.Point(90, 167);
            this.chkAnonym.Name = "chkAnonym";
            this.chkAnonym.Size = new System.Drawing.Size(137, 20);
            this.chkAnonym.TabIndex = 11;
            this.chkAnonym.Text = "Generischer Login";
            this.chkAnonym.CheckedChanged += new System.EventHandler(this.ChkAnonym_CheckedChanged);
            // 
            // cboAerzte
            // 
            this.cboAerzte.Location = new System.Drawing.Point(90, 258);
            this.cboAerzte.Name = "cboAerzte";
            this.cboAerzte.Size = new System.Drawing.Size(208, 24);
            this.cboAerzte.TabIndex = 3;
            this.cboAerzte.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblIstArzt
            // 
            this.lblIstArzt.AutoSize = true;
            this.lblIstArzt.Location = new System.Drawing.Point(6, 262);
            this.lblIstArzt.Name = "lblIstArzt";
            this.lblIstArzt.Size = new System.Drawing.Size(55, 17);
            this.lblIstArzt.TabIndex = 8;
            this.lblIstArzt.Text = "Ist Arzt?";
            // 
            // txtBenutzer
            // 
            this.txtBenutzer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBenutzer.Location = new System.Drawing.Point(90, 21);
            this.txtBenutzer.MaxLength = 25;
            this.txtBenutzer.Name = "txtBenutzer";
            this.txtBenutzer.Size = new System.Drawing.Size(235, 24);
            this.txtBenutzer.TabIndex = 1;
            this.txtBenutzer.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // chkAktiv
            // 
            this.chkAktiv.Location = new System.Drawing.Point(90, 141);
            this.chkAktiv.Name = "chkAktiv";
            this.chkAktiv.Size = new System.Drawing.Size(56, 20);
            this.chkAktiv.TabIndex = 9;
            this.chkAktiv.Text = "Aktiv";
            this.chkAktiv.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // btnPassword
            // 
            this.btnPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPassword.AutoWorkLayout = false;
            this.btnPassword.IsStandardControl = false;
            this.btnPassword.Location = new System.Drawing.Point(90, 193);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(120, 24);
            this.btnPassword.TabIndex = 10;
            this.btnPassword.Text = "&Passwort ändern";
            this.btnPassword.Click += new System.EventHandler(this.btnPassword_Click);
            // 
            // txtNachname
            // 
            this.txtNachname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNachname.Location = new System.Drawing.Point(90, 51);
            this.txtNachname.MaxLength = 25;
            this.txtNachname.Name = "txtNachname";
            this.txtNachname.Size = new System.Drawing.Size(235, 24);
            this.txtNachname.TabIndex = 5;
            this.txtNachname.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblBerufsstand
            // 
            this.lblBerufsstand.AutoSize = true;
            this.lblBerufsstand.Location = new System.Drawing.Point(6, 115);
            this.lblBerufsstand.Name = "lblBerufsstand";
            this.lblBerufsstand.Size = new System.Drawing.Size(59, 17);
            this.lblBerufsstand.TabIndex = 6;
            this.lblBerufsstand.Text = "Berufsst.";
            // 
            // txtVorname
            // 
            this.txtVorname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVorname.Location = new System.Drawing.Point(90, 81);
            this.txtVorname.MaxLength = 25;
            this.txtVorname.Name = "txtVorname";
            this.txtVorname.Size = new System.Drawing.Size(235, 24);
            this.txtVorname.TabIndex = 3;
            this.txtVorname.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblNachname
            // 
            this.lblNachname.AutoSize = true;
            this.lblNachname.Location = new System.Drawing.Point(6, 55);
            this.lblNachname.Name = "lblNachname";
            this.lblNachname.Size = new System.Drawing.Size(71, 17);
            this.lblNachname.TabIndex = 4;
            this.lblNachname.Text = "Nachname";
            // 
            // lblBenutzer
            // 
            this.lblBenutzer.AutoSize = true;
            this.lblBenutzer.Location = new System.Drawing.Point(6, 25);
            this.lblBenutzer.Name = "lblBenutzer";
            this.lblBenutzer.Size = new System.Drawing.Size(60, 17);
            this.lblBenutzer.TabIndex = 0;
            this.lblBenutzer.Text = "Benutzer";
            // 
            // lblVorname
            // 
            this.lblVorname.AutoSize = true;
            this.lblVorname.Location = new System.Drawing.Point(6, 85);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(61, 17);
            this.lblVorname.TabIndex = 2;
            this.lblVorname.Text = "Vorname";
            // 
            // chkPfleger
            // 
            this.chkPfleger.Location = new System.Drawing.Point(176, 141);
            this.chkPfleger.Name = "chkPfleger";
            this.chkPfleger.Size = new System.Drawing.Size(107, 20);
            this.chkPfleger.TabIndex = 8;
            this.chkPfleger.Text = "Pfleger";
            this.chkPfleger.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cbBerufsstand
            // 
            this.cbBerufsstand.AddEmptyEntry = false;
            this.cbBerufsstand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBerufsstand.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            this.cbBerufsstand.AutoOpenCBO = true;
            this.cbBerufsstand.BerufsstandGruppeJNA = 0;
            this.cbBerufsstand.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbBerufsstand.ExactMatch = false;
            this.cbBerufsstand.Group = "BER";
            this.cbBerufsstand.ID_PEP = -1;
            this.cbBerufsstand.Location = new System.Drawing.Point(90, 111);
            this.cbBerufsstand.Name = "cbBerufsstand";
            this.cbBerufsstand.PflichtJN = false;
            this.cbBerufsstand.ShowAddButton = true;
            this.cbBerufsstand.Size = new System.Drawing.Size(235, 24);
            this.cbBerufsstand.sys = false;
            this.cbBerufsstand.TabIndex = 7;
            this.cbBerufsstand.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // grpAdresse
            // 
            this.grpAdresse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAdresse.BackColor = System.Drawing.Color.Transparent;
            this.grpAdresse.Controls.Add(this.ucAdresse1);
            this.grpAdresse.Location = new System.Drawing.Point(16, 366);
            this.grpAdresse.Name = "grpAdresse";
            this.grpAdresse.Size = new System.Drawing.Size(906, 143);
            this.grpAdresse.TabIndex = 1;
            this.grpAdresse.TabStop = false;
            this.grpAdresse.Text = "Adresse";
            // 
            // ucAdresse1
            // 
            this.ucAdresse1.AutoScroll = true;
            this.ucAdresse1.BackColor = System.Drawing.Color.Transparent;
            this.ucAdresse1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAdresse1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucAdresse1.Location = new System.Drawing.Point(3, 19);
            this.ucAdresse1.Margin = new System.Windows.Forms.Padding(5);
            this.ucAdresse1.Name = "ucAdresse1";
            this.ucAdresse1.Size = new System.Drawing.Size(900, 121);
            this.ucAdresse1.TabIndex = 0;
            this.ucAdresse1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // grpKontakt
            // 
            this.grpKontakt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpKontakt.BackColor = System.Drawing.Color.Transparent;
            this.grpKontakt.Controls.Add(this.ucKontakt1);
            this.grpKontakt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpKontakt.Location = new System.Drawing.Point(353, 8);
            this.grpKontakt.Name = "grpKontakt";
            this.grpKontakt.Size = new System.Drawing.Size(569, 352);
            this.grpKontakt.TabIndex = 2;
            this.grpKontakt.TabStop = false;
            this.grpKontakt.Text = "Kontakt";
            // 
            // ucKontakt1
            // 
            this.ucKontakt1.BackColor = System.Drawing.Color.Transparent;
            this.ucKontakt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKontakt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucKontakt1.Location = new System.Drawing.Point(3, 19);
            this.ucKontakt1.Margin = new System.Windows.Forms.Padding(5);
            this.ucKontakt1.Name = "ucKontakt1";
            this.ucKontakt1.Size = new System.Drawing.Size(563, 330);
            this.ucKontakt1.TabIndex = 0;
            this.ucKontakt1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ucBenutzerGruppe1);
            this.ultraTabPageControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(925, 544);
            // 
            // ucBenutzerGruppe1
            // 
            this.ucBenutzerGruppe1.BackColor = System.Drawing.Color.Transparent;
            benutzer1.AktivJN = true;
            benutzer1.ArztabrechnungJN = false;
            benutzer1.BenutzerName = "";
            benutzer1.ELGA_AuthorSpeciality = "";
            benutzer1.ELGAActive = false;
            benutzer1.ELGAAutoLogin = false;
            benutzer1.ELGAAutostartSession = false;
            benutzer1.ELGAPatID = "";
            benutzer1.ELGAPwd = "";
            benutzer1.ELGAPwdLastChange = new System.DateTime(2021, 2, 28, 15, 38, 34, 573);
            benutzer1.ELGAUser = "";
            benutzer1.ELGAValidTrough = new System.DateTime(2019, 6, 19, 13, 53, 19, 11);
            benutzer1.ID = new System.Guid("4233ec14-b25f-4f7d-8d0b-e8408001d780");
            benutzer1.IDAdresse = new System.Guid("00000000-0000-0000-0000-000000000000");
            benutzer1.IDArzt = null;
            benutzer1.IDBerufsstand = new System.Guid("00000000-0000-0000-0000-000000000000");
            benutzer1.IDKontakt = new System.Guid("00000000-0000-0000-0000-000000000000");
            benutzer1.IsGeneric = false;
            benutzer1.Nachname = "";
            benutzer1.Passwort = "26BAD4DACB4B2C9FBB36C70A41C1B39F";
            benutzer1.PflegerJN = false;
            benutzer1.Vorname = "";
            this.ucBenutzerGruppe1.Benutzer = benutzer1;
            this.ucBenutzerGruppe1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBenutzerGruppe1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucBenutzerGruppe1.Location = new System.Drawing.Point(0, 0);
            this.ucBenutzerGruppe1.Margin = new System.Windows.Forms.Padding(5);
            this.ucBenutzerGruppe1.Name = "ucBenutzerGruppe1";
            this.ucBenutzerGruppe1.Size = new System.Drawing.Size(925, 544);
            this.ucBenutzerGruppe1.TabIndex = 0;
            this.ucBenutzerGruppe1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraTabPageControl6
            // 
            this.ultraTabPageControl6.Controls.Add(this.ucRechtBenutzer1);
            this.ultraTabPageControl6.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl6.Name = "ultraTabPageControl6";
            this.ultraTabPageControl6.Size = new System.Drawing.Size(925, 544);
            // 
            // ucRechtBenutzer1
            // 
            this.ucRechtBenutzer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucRechtBenutzer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucRechtBenutzer1.Location = new System.Drawing.Point(4, 4);
            this.ucRechtBenutzer1.Margin = new System.Windows.Forms.Padding(4);
            this.ucRechtBenutzer1.Name = "ucRechtBenutzer1";
            this.ucRechtBenutzer1.ReadOnly = false;
            this.ucRechtBenutzer1.Size = new System.Drawing.Size(917, 536);
            this.ucRechtBenutzer1.TabIndex = 0;
            this.ucRechtBenutzer1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraTabPageControl5
            // 
            this.ultraTabPageControl5.Controls.Add(this.ucBenutzerEinrichtung1);
            this.ultraTabPageControl5.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl5.Name = "ultraTabPageControl5";
            this.ultraTabPageControl5.Size = new System.Drawing.Size(925, 544);
            // 
            // ucBenutzerEinrichtung1
            // 
            this.ucBenutzerEinrichtung1.BackColor = System.Drawing.Color.Transparent;
            this.ucBenutzerEinrichtung1.Benutzer = null;
            this.ucBenutzerEinrichtung1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBenutzerEinrichtung1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucBenutzerEinrichtung1.Location = new System.Drawing.Point(0, 0);
            this.ucBenutzerEinrichtung1.Margin = new System.Windows.Forms.Padding(5);
            this.ucBenutzerEinrichtung1.Name = "ucBenutzerEinrichtung1";
            this.ucBenutzerEinrichtung1.Size = new System.Drawing.Size(925, 544);
            this.ucBenutzerEinrichtung1.TabIndex = 0;
            this.ucBenutzerEinrichtung1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.ucBenutzerAbteilung1);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(925, 544);
            // 
            // ucBenutzerAbteilung1
            // 
            benutzer2.AktivJN = true;
            benutzer2.ArztabrechnungJN = false;
            benutzer2.BenutzerName = "";
            benutzer2.ELGA_AuthorSpeciality = "";
            benutzer2.ELGAActive = false;
            benutzer2.ELGAAutoLogin = false;
            benutzer2.ELGAAutostartSession = false;
            benutzer2.ELGAPatID = "";
            benutzer2.ELGAPwd = "";
            benutzer2.ELGAPwdLastChange = new System.DateTime(2021, 2, 28, 15, 38, 34, 575);
            benutzer2.ELGAUser = "";
            benutzer2.ELGAValidTrough = new System.DateTime(2019, 6, 19, 13, 53, 19, 13);
            benutzer2.ID = new System.Guid("85a9705d-1a08-4443-9937-440904d18222");
            benutzer2.IDAdresse = new System.Guid("00000000-0000-0000-0000-000000000000");
            benutzer2.IDArzt = null;
            benutzer2.IDBerufsstand = new System.Guid("00000000-0000-0000-0000-000000000000");
            benutzer2.IDKontakt = new System.Guid("00000000-0000-0000-0000-000000000000");
            benutzer2.IsGeneric = false;
            benutzer2.Nachname = "";
            benutzer2.Passwort = "C91604E594B34198A9388D417C123B12";
            benutzer2.PflegerJN = false;
            benutzer2.Vorname = "";
            this.ucBenutzerAbteilung1.Benutzer = benutzer2;
            this.ucBenutzerAbteilung1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBenutzerAbteilung1.Location = new System.Drawing.Point(0, 0);
            this.ucBenutzerAbteilung1.Margin = new System.Windows.Forms.Padding(5);
            this.ucBenutzerAbteilung1.Name = "ucBenutzerAbteilung1";
            this.ucBenutzerAbteilung1.Size = new System.Drawing.Size(925, 544);
            this.ucBenutzerAbteilung1.TabIndex = 0;
            this.ucBenutzerAbteilung1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.groupBoxSMTPAngaben);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(2, 24);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(925, 544);
            // 
            // groupBoxSMTPAngaben
            // 
            this.groupBoxSMTPAngaben.Controls.Add(this.uMaskSMTPPort);
            this.groupBoxSMTPAngaben.Controls.Add(this.lblPort);
            this.groupBoxSMTPAngaben.Controls.Add(this.txtSMTPAbsenderAdresse);
            this.groupBoxSMTPAngaben.Controls.Add(this.txtSMTPPwd);
            this.groupBoxSMTPAngaben.Controls.Add(this.lblUser);
            this.groupBoxSMTPAngaben.Controls.Add(this.lblServer);
            this.groupBoxSMTPAngaben.Controls.Add(this.txtSMTPSrv);
            this.groupBoxSMTPAngaben.Controls.Add(this.lblPasswort);
            this.groupBoxSMTPAngaben.Controls.Add(this.uChkStandardAuthentifizierung);
            this.groupBoxSMTPAngaben.Location = new System.Drawing.Point(26, 15);
            this.groupBoxSMTPAngaben.Name = "groupBoxSMTPAngaben";
            this.groupBoxSMTPAngaben.Size = new System.Drawing.Size(344, 177);
            this.groupBoxSMTPAngaben.TabIndex = 0;
            this.groupBoxSMTPAngaben.TabStop = false;
            this.groupBoxSMTPAngaben.Text = "SMTP Angeben für E-Mail Versand";
            // 
            // uMaskSMTPPort
            // 
            this.uMaskSMTPPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uMaskSMTPPort.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.uMaskSMTPPort.Location = new System.Drawing.Point(115, 54);
            this.uMaskSMTPPort.Name = "uMaskSMTPPort";
            this.uMaskSMTPPort.NonAutoSizeHeight = 20;
            this.uMaskSMTPPort.Size = new System.Drawing.Size(74, 23);
            this.uMaskSMTPPort.TabIndex = 1;
            this.uMaskSMTPPort.MaskChanged += new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit.MaskChangedEventHandler(this.uMaskSMTPPort_MaskChanged);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(16, 51);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(30, 17);
            this.lblPort.TabIndex = 10;
            this.lblPort.Text = "Port";
            // 
            // txtSMTPAbsenderAdresse
            // 
            this.txtSMTPAbsenderAdresse.Location = new System.Drawing.Point(115, 83);
            this.txtSMTPAbsenderAdresse.MaxLength = 25;
            this.txtSMTPAbsenderAdresse.Name = "txtSMTPAbsenderAdresse";
            this.txtSMTPAbsenderAdresse.Size = new System.Drawing.Size(214, 24);
            this.txtSMTPAbsenderAdresse.TabIndex = 2;
            this.txtSMTPAbsenderAdresse.ValueChanged += new System.EventHandler(this.txtSMTPAbsenderAdresse_ValueChanged);
            // 
            // txtSMTPPwd
            // 
            this.txtSMTPPwd.Location = new System.Drawing.Point(115, 113);
            this.txtSMTPPwd.MaxLength = 25;
            this.txtSMTPPwd.Name = "txtSMTPPwd";
            this.txtSMTPPwd.PasswordChar = '*';
            this.txtSMTPPwd.Size = new System.Drawing.Size(214, 24);
            this.txtSMTPPwd.TabIndex = 3;
            this.txtSMTPPwd.ValueChanged += new System.EventHandler(this.txtSMTPPwd_ValueChanged);
            this.txtSMTPPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSMTPPwd_KeyDown);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(16, 86);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(34, 17);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "User";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(16, 27);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(45, 17);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Server";
            // 
            // txtSMTPSrv
            // 
            this.txtSMTPSrv.Location = new System.Drawing.Point(115, 24);
            this.txtSMTPSrv.MaxLength = 25;
            this.txtSMTPSrv.Name = "txtSMTPSrv";
            this.txtSMTPSrv.Size = new System.Drawing.Size(214, 24);
            this.txtSMTPSrv.TabIndex = 0;
            this.txtSMTPSrv.ValueChanged += new System.EventHandler(this.txtSMTPSrv_ValueChanged);
            // 
            // lblPasswort
            // 
            this.lblPasswort.AutoSize = true;
            this.lblPasswort.Location = new System.Drawing.Point(16, 116);
            this.lblPasswort.Name = "lblPasswort";
            this.lblPasswort.Size = new System.Drawing.Size(61, 17);
            this.lblPasswort.TabIndex = 2;
            this.lblPasswort.Text = "Passwort";
            // 
            // uChkStandardAuthentifizierung
            // 
            this.uChkStandardAuthentifizierung.Location = new System.Drawing.Point(115, 144);
            this.uChkStandardAuthentifizierung.Name = "uChkStandardAuthentifizierung";
            this.uChkStandardAuthentifizierung.Size = new System.Drawing.Size(187, 20);
            this.uChkStandardAuthentifizierung.TabIndex = 4;
            this.uChkStandardAuthentifizierung.Text = "Standard-Authentifizierung";
            this.uChkStandardAuthentifizierung.CheckedChanged += new System.EventHandler(this.uChkStandardAuthentifizierung_CheckedChanged);
            // 
            // ultraTabPageControl7
            // 
            this.ultraTabPageControl7.Controls.Add(this.panelELGA);
            this.ultraTabPageControl7.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl7.Name = "ultraTabPageControl7";
            this.ultraTabPageControl7.Size = new System.Drawing.Size(925, 544);
            // 
            // panelELGA
            // 
            this.panelELGA.BackColor = System.Drawing.Color.White;
            this.panelELGA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelELGA.Location = new System.Drawing.Point(0, 0);
            this.panelELGA.Name = "panelELGA";
            this.panelELGA.Size = new System.Drawing.Size(925, 544);
            this.panelELGA.TabIndex = 0;
            // 
            // ultraTabControl1
            // 
            appearance2.FontData.SizeInPoints = 8.25F;
            this.ultraTabControl1.Appearance = appearance2;
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl3);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl4);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl5);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl6);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl7);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(929, 570);
            this.ultraTabControl1.TabIndex = 4;
            ultraTab1.Key = "Stammdaten";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Stammdaten";
            ultraTab2.Key = "Rechte";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "Rechte";
            ultraTab6.Key = "RechteBenutzer";
            ultraTab6.TabPage = this.ultraTabPageControl6;
            ultraTab6.Text = "Rechte Benutzer";
            ultraTab5.Key = "Einrichtungen";
            ultraTab5.TabPage = this.ultraTabPageControl5;
            ultraTab5.Text = "Einrichtungen";
            ultraTab3.Key = "Abteilungen";
            ultraTab3.TabPage = this.ultraTabPageControl3;
            ultraTab3.Text = "Abteilungen";
            ultraTab4.Key = "SMTP";
            ultraTab4.TabPage = this.ultraTabPageControl4;
            ultraTab4.Text = "SMTP Einstellungen";
            ultraTab7.Key = "ELGA";
            ultraTab7.TabPage = this.ultraTabPageControl7;
            ultraTab7.Text = "ELGA";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2,
            ultraTab6,
            ultraTab5,
            ultraTab3,
            ultraTab4,
            ultraTab7});
            this.ultraTabControl1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraTabControl1.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.ultraTabControl1_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(925, 544);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucBenutzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.ultraTabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucBenutzer";
            this.Size = new System.Drawing.Size(929, 570);
            this.Load += new System.EventHandler(this.ucBenutzer_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.grpBenutzer.ResumeLayout(false);
            this.grpBenutzer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkELGAActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboELGA_AuthorSpeciality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkArztabrechnungJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAnonym)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAerzte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBenutzer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNachname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPfleger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBerufsstand)).EndInit();
            this.grpAdresse.ResumeLayout(false);
            this.grpKontakt.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl6.ResumeLayout(false);
            this.ultraTabPageControl5.ResumeLayout(false);
            this.ultraTabPageControl3.ResumeLayout(false);
            this.ultraTabPageControl4.ResumeLayout(false);
            this.groupBoxSMTPAngaben.ResumeLayout(false);
            this.groupBoxSMTPAngaben.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMTPAbsenderAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMTPPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMTPSrv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uChkStandardAuthentifizierung)).EndInit();
            this.ultraTabPageControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        public void initcontrol()
        {
            if (!this.IsInitialized)
            {
                this.ultraTabControl1.Tabs["ELGA"].Text = DB.PMDSBusiness.getResQS2("ELGA");

                if (ENV.lic_ELGA)
                {
                    this.contELGAUser1 = new contELGAUser();
                    this.contELGAUser1.Dock = DockStyle.Fill;
                    this.contELGAUser1.mainWindow = this;
                    this.contELGAUser1.initControl();
                    this.contELGAUser1.contELGASettings1.mainWindowBenutzer = this;
                    this.contELGAUser1.contELGARights1.mainWindowBenutzer = this;
                    this.panelELGA.Controls.Add(this.contELGAUser1);
                    this.ultraTabControl1.Tabs["ELGA"].Visible = true;

                    this.BenutzerdatenELGAVerwalten = PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.BenutzerdatenELGAVerwalten);
                }
                else
                {
                    this.ultraTabControl1.Tabs["ELGA"].Visible = false;
                }

                this.IsInitialized = true;
            }
        }

        public void deactivateTabs()
        {
            this.ultraTabControl1.Tabs["Stammdaten"].Visible = false;
            this.ultraTabControl1.Tabs["Rechte"].Visible = false;
            this.ultraTabControl1.Tabs["Einrichtungen"].Visible = false;
            this.ultraTabControl1.Tabs["SMTP"].Visible = false;

            this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["Abteilungen"];
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Benutzer Benutzer
        {
            get
            {
                return _benutzer;
            }
            set
            {
                this.initcontrol();

                if (value == null)
                    throw new ArgumentNullException("Benutzer");

                _valueChangeEnabled = false;
                _benutzer = value;
                UpdateGUI();
                _valueChangeEnabled = true;
            }
        }


        public void UpdateGUI()
        {
            ucAdresse1.Adresse = Benutzer.Adresse;
            ucKontakt1.Kontakt = Benutzer.Kontakt;
            ucBenutzerGruppe1.Benutzer = Benutzer;
            this.ucBenutzerEinrichtung1.Benutzer = Benutzer;
            ucBenutzerAbteilung1.Benutzer = Benutzer;

            txtVorname.Text = Benutzer.Vorname;
            txtNachname.Text = Benutzer.Nachname;
            txtBenutzer.Text = Benutzer.BenutzerName;
            chkPfleger.Checked = Benutzer.PflegerJN;
            chkAktiv.Checked = Benutzer.AktivJN;
            cbBerufsstand.Value = Benutzer.IDBerufsstand;
            this.chkAnonym.Checked = Benutzer.IsGeneric;
            this.chkArztabrechnungJN.Checked = Benutzer.ArztabrechnungJN;
            if (Benutzer.IDArzt == null)
                this.cboAerzte.Value = null;
            else
                this.cboAerzte.Value = (Guid)Benutzer.IDArzt;

            this.cboELGA_AuthorSpeciality.Text = Benutzer.ELGA_AuthorSpeciality;

            this.ucRechtBenutzer1.initControl();
            this.ucRechtBenutzer1.IDBenutzer = this.Benutzer.ID;
            this.ucRechtBenutzer1.loadData();

            this.chkELGAActive.Checked = this.Benutzer.ELGAActive;

            if (ENV.lic_ELGA)
            {
                this.setUIELGA(this.Benutzer.ELGAActive && !this.Benutzer.IsGeneric, true);
                if (IsInitialized2)
                {
                    this.contELGAUser1.loadData(this.Benutzer.ID, false, this.BenutzerdatenELGAVerwalten);
                }
            }
        }

        public void setUIELGA(bool bOn, bool clearUI)
        {
            this.ultraTabControl1.Tabs["ELGA"].Visible = bOn;
            if (clearUI)
            {
                this.contELGAUser1.clearUI();
            }
            //if (bOn)
            //{

            //}
            //else
            //{

            //}
        }

        public void clearUI()
        {
            //ucAdresse1.Adresse = Benutzer.Adresse;
            //ucKontakt1.Kontakt = Benutzer.Kontakt;
            //ucBenutzerGruppe1.Benutzer = Benutzer;
            //this.ucBenutzerEinrichtung1.Benutzer = Benutzer;
            //ucBenutzerAbteilung1.Benutzer = Benutzer;

            txtVorname.Text = "";
            txtNachname.Text ="";
            txtBenutzer.Text = "";
            chkPfleger.Checked = false;
            chkAktiv.Checked = false;
            cbBerufsstand.Value = null;
            this.chkAnonym.Checked = false;
            this.chkArztabrechnungJN.Checked = false;
            this.cboAerzte.Value = null;
            this.cboELGA_AuthorSpeciality.Text = "";
            this.cboELGA_AuthorSpeciality.Value = null;

            this.txtSMTPSrv.Text = "";
            this.uMaskSMTPPort.Value = 0;
            this.txtSMTPAbsenderAdresse.Text = "";
            this.txtSMTPPwd.Text = "";
            this.uChkStandardAuthentifizierung.Checked = false;

            this.ucBenutzerGruppe1.clearCheckBoxes();

            this.ucRechtBenutzer1.initControl();
            //this.ucRechtBenutzer1.IDBenutzer = System.Guid.NewGuid();
            this.ucRechtBenutzer1.clearCheckBoxes ();

            if (ENV.lic_ELGA)
            {
                this.contELGAUser1.clearUI();
            }
        }


        public void UpdateDATA()
        {
            ucAdresse1.UpdateDATA();
            ucKontakt1.UpdateDATA();
            ucBenutzerGruppe1.UpdateDATA();
            this.ucBenutzerEinrichtung1.saveData();
            ucBenutzerAbteilung1.saveData();

            Benutzer.Vorname = txtVorname.Text;
            Benutzer.Nachname = txtNachname.Text;
            Benutzer.BenutzerName = txtBenutzer.Text;
            Benutzer.PflegerJN = chkPfleger.Checked;
            Benutzer.AktivJN = chkAktiv.Checked;
            Benutzer.IsGeneric = this.chkAnonym.Checked;
            Benutzer.ArztabrechnungJN = this.chkArztabrechnungJN.Checked;
            Benutzer.ELGA_AuthorSpeciality = this.cboELGA_AuthorSpeciality.Text.Trim();

            if (cbBerufsstand.Value == null)
                Benutzer.IDBerufsstand = Guid.Empty;
            else
                Benutzer.IDBerufsstand = (Guid)cbBerufsstand.Value;

            if (this.cboAerzte.Value == null)
                Benutzer.IDArzt = null;
            else
                Benutzer.IDArzt = (Guid)this.cboAerzte.Value;

            this.Benutzer.ELGAActive = this.chkELGAActive.Checked;
        }

        public void writeSMTPData(System.Guid IDBenutzer)
        {
            using (PMDS.DB.DBBenutzer ben = new PMDS.DB.DBBenutzer())
            {
                ben.updateSMTPAngaben(IDBenutzer, this.txtSMTPSrv.Text, (int)this.uMaskSMTPPort.Value, this.txtSMTPAbsenderAdresse.Text, this.txtSMTPPwd.Text, this.uChkStandardAuthentifizierung.Checked);
            }
        }

        public void readSMTPData(System.Guid IDBenutzer)
        {
            using (PMDS.DB.DBBenutzer ben = new PMDS.DB.DBBenutzer())
            {
                DataTable dt = ben.readSMTPAngaben(IDBenutzer);
                this.txtSMTPSrv.Text = (string)dt.Rows[0]["smtpSrv"];
                this.uMaskSMTPPort.Value = (int)dt.Rows[0]["smtpPort"];
                this.txtSMTPAbsenderAdresse.Text = (string)dt.Rows[0]["smtpAbsender"];
                this.txtSMTPPwd.Text = (string)dt.Rows[0]["smtpPwd"];
                this.uChkStandardAuthentifizierung.Checked = (bool)dt.Rows[0]["smtpAuthentStandard"];
            }
        }

        public bool New()
        {
            using (frmEditPassword frm = new frmEditPassword(false, false))
            {
                frm.Text = "Neue Benutzerdaten erfassen";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Benutzer Informationen setzen
                    Benutzer obj = new Benutzer();
                    obj.BenutzerName = frm.User;
                    obj.Passwort = frm.Password;
                    Benutzer = obj;

                    this.txtSMTPSrv.Text = "";
                    this.uMaskSMTPPort.Value = 0;
                    this.txtSMTPAbsenderAdresse.Text = "";
                    this.txtSMTPPwd.Text = "";
                    this.uChkStandardAuthentifizierung.Checked = false;

                    if (this.mainWindow != null)
                    {
                        //this.mainWindow.cbBenutzer.DataSource = this.mainWindow._verwaltung._details.All();
                        //Infragistics.Win.ValueListItem valList = this.mainWindow.cbBenutzer.Items.Add(obj.ID, obj.BenutzerName);
                        //this.mainWindow.cbBenutzer.SelectedItem = valList;

                        this.mainWindow.btnSpeichern2.Enabled = true;
                        this.mainWindow.btnUndo2.Enabled = true;
                        this.mainWindow.cbBenutzer.Enabled = false;
                        this.mainWindow.btnAdd.Enabled = false;
                        this.mainWindow._verwaltung.IsEntryDirty = true;
                    }
                    return true;
                }
            }

            return false;
        }

        public void Read(object id)
        {
            try
            {
                if (id.GetType() == typeof(Guid))
                {
                    Benutzer obj = new Benutzer((Guid)id);
                    Benutzer = obj;
                    this.readSMTPData(Benutzer.ID);
                }

            }
            catch(Exception ex)
            {
                throw new Exception("ucBenutzer.Read: " + ex.ToString());
            }
        }

        public void Read()
        {
            Benutzer.Read();
            //Benutzer = Benutzer;
        }

        public void Write()
        {
            Benutzer.Write();
        }

        public void Delete()
        {
            Benutzer.Delete();
            Benutzer = new Benutzer();
        }

        public void OnValueChanged(object sender, EventArgs args)
        {
            if (_valueChangeEnabled && (ValueChanged != null))
            {
                if (this.mainWindow != null)
                {
                    this.mainWindow.btnSpeichern2.Enabled = true;
                    this.mainWindow.btnUndo2.Enabled = true;
                    this.mainWindow.cbBenutzer.Enabled = false;
                    this.mainWindow.btnAdd.Enabled = false;
                    this.mainWindow._verwaltung.IsEntryDirty = true;
                }
                ValueChanged(sender, args);
            }
        }

        protected void RequiredFields()
        {
            GuiUtil.ValidateRequired(txtBenutzer);
            GuiUtil.ValidateRequired(txtNachname);
            GuiUtil.ValidateRequired(cbBerufsstand);
        }

        public bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            txtBenutzer.Text = txtBenutzer.Text.Trim();

            GuiUtil.ValidateField(txtBenutzer, (txtBenutzer.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            if (txtBenutzer.Text.Length > 0)
            {
                object dbID = Benutzer.UserID(txtBenutzer.Text);
                bool bIDOK = (Guid.Equals(dbID, null) || Guid.Equals(dbID, Benutzer.ID));

                GuiUtil.ValidateField(txtBenutzer, bIDOK,
                    ENV.String("GUI.E_USER_EXIST"), ref bError, bInfo, errorProvider1);
            }

            GuiUtil.ValidateField(txtNachname, (txtNachname.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            //GuiUtil.ValidateField(cbBerufsstand, (cbBerufsstand.Value != null),
            //    ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            string MsgTxt = "";
            bool cbBerufsgruppeOK = PMDSBusinessUI.checkCboBox(this.cbBerufsstand, QS2.Desktop.ControlManagment.ControlManagment.getRes("Berufsst."), true, ref MsgTxt);
            bool cbELGAAutSpOK =  PMDSBusinessUI.checkCboBox(this.cboELGA_AuthorSpeciality, QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA Author speciality"), true, ref MsgTxt);
      /*      bool cbLandOK = PMDSBusinessUI.checkCboBox(this.ucAdresse1.cboLand, QS2.Desktop.ControlManagment.ControlManagment.getRes("Land"), true, ref MsgTxt)*/;
            if (!cbBerufsgruppeOK || !cbELGAAutSpOK)
            {
                bError = true;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(MsgTxt, QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern"), MessageBoxButtons.OK);
            }

            if (ENV.lic_ELGA)
            {
                if (this.Benutzer.ELGAActive)
                {
                    if (!this.contELGAUser1.validateData())
                    {
                        bError = true;
                    }
                }
            }

            return !bError;
        }

        #region IUCBase Members

        DataTable IUCBase.All()
        {
            return Benutzer.AllEntries();
        }

        IBusinessBase IUCBase.Object
        {
            get { return Benutzer; }
            set { Benutzer = (Benutzer)value; }
        }

        #endregion


        private void btnPassword_Click(object sender, System.EventArgs e)
        {
            using (frmEditPassword frm = new frmEditPassword(false, false, Benutzer))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Benutzer.Passwort = frm.Password;
                    OnValueChanged(sender, e);
                }
            }
        }

        private void txtSMTPSrv_ValueChanged(object sender, EventArgs e)
        {
            if (_valueChangeEnabled && (ValueChanged != null))
                ValueChanged(sender, e);
        }

        private void uMaskSMTPPort_MaskChanged(object sender, Infragistics.Win.UltraWinMaskedEdit.MaskChangedEventArgs e)
        {
            if (_valueChangeEnabled && (ValueChanged != null))
                ValueChanged(sender, e);
        }

        private void txtSMTPAbsenderAdresse_ValueChanged(object sender, EventArgs e)
        {
            if (_valueChangeEnabled && (ValueChanged != null))
                ValueChanged(sender, e);
        }

        private void txtSMTPPwd_ValueChanged(object sender, EventArgs e)
        {
            if (_valueChangeEnabled && (ValueChanged != null))
                ValueChanged(sender, e);
        }

        private void uChkStandardAuthentifizierung_CheckedChanged(object sender, EventArgs e)
        {
            if (_valueChangeEnabled && (ValueChanged != null))
                ValueChanged(sender, e);
        }

        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;


            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnDeleteArzt_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.cboAerzte.Value = null;
                object o = new object();
                EventArgs evArg = new EventArgs();
                this.OnValueChanged(o, evArg);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ChkELGAActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.chkELGAActive.Focused)
                {
                    object o = new object();
                    EventArgs evArg = new EventArgs();
                    this.OnValueChanged(o, evArg);

                    if (ENV.lic_ELGA)
                    {
                        this.setUIELGA(this.chkELGAActive.Checked && !this.chkAnonym.Checked, false);
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void ChkAnonym_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.chkAnonym.Focused)
                {
                    object o = new object();
                    EventArgs evArg = new EventArgs();
                    this.OnValueChanged(o, evArg);

                    if (ENV.lic_ELGA)
                    {
                        this.setUIELGA(this.chkELGAActive.Checked && !this.chkAnonym.Checked, false);
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void txtSMTPPwd_KeyDown(object sender, KeyEventArgs e)
        {
            PMDS.Global.generic.TogglePassword(sender);
        }
    }
}
