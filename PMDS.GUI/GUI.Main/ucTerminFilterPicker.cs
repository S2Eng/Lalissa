using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win;

using PMDS.Global;
using PMDS.GUI;
using PMDS.BusinessLogic;
using PMDS.Global.db.Pflegeplan;



namespace PMDS.GUI
{



	public class ucTerminFilterPicker : QS2.Desktop.ControlManagment.BaseControl
	{

        public ucTermineEx mainWindowxy;

        public bool IsInitialized = false;

        public PMDS.Global.db.ERSystem.UISitemaps UISitemaps1 = new Global.db.ERSystem.UISitemaps();






		private Infragistics.Win.Misc.UltraPopupControlContainer popupContainer;
        public QS2.Desktop.ControlManagment.BasePanel pAll;
        public Infragistics.Win.Misc.UltraDropDownButton btn;
        //private PMDS.GUI.BaseControls.PflegerCombo cbBezug;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkBezugJN;
		private QS2.Desktop.ControlManagment.BaseCheckBox chkMa�nahme;
		private QS2.Desktop.ControlManagment.BaseButton btnClose;
		private PMDS.GUI.ucPicker ucPicker1;
		private Infragistics.Win.Misc.UltraPopupControlContainer popupContainer2;
		private QS2.Desktop.ControlManagment.BasePanel pMassnahme;
        public QS2.Desktop.ControlManagment.BaseButton btnClose3;
        private Infragistics.Win.Misc.UltraDropDownButton btnEintragMa�nahme;
		private dsEintrag dsEintrag1;
        private System.Windows.Forms.ListBox lbMa�nahme;
        private QS2.Desktop.ControlManagment.BaseComboEditor cbAbzeichnen;
        private QS2.Desktop.ControlManagment.BaseButton btnDelMa�nahme;
        private QS2.Desktop.ControlManagment.BasePanel panelButtonsUnten;
        public QS2.Desktop.ControlManagment.BasePanel panelAktualisieren;
        public QS2.Desktop.ControlManagment.BasePanel panelClose;
        public QS2.Desktop.ControlManagment.BaseButton btnClose2;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkBerufsgruppeJN;
        public BaseControls.AuswahlGruppeComboMulti cboBerufsstandMulti;
        public BaseControls.AuswahlGruppeComboMulti cboWichtigF�rMulti;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkWichtigF�rJN;
        private Panel panelCombos;
        private Panel panelMa�nahme;
        public BaseControls.AuswahlGruppeComboMulti cboZusatzwerteMulti;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkZusatzwerteJN;
        public BaseControls.AuswahlGruppeComboMulti cboPlanungsEintr�geMulti;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkPlanungsEintr�geJN;
        public BaseControls.AuswahlGruppeComboMulti cboZeitbezugJNAMulti;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkZeitbezugJN;
        protected QS2.Desktop.ControlManagment.BaseLabel labAbzeichnen;
        public QS2.Desktop.ControlManagment.BaseComboEditor cboShowCC;
        private QS2.Desktop.ControlManagment.BaseLableWin lblCCAnzeigen;
        public BaseControls.AuswahlGruppeComboMulti cboHerkunftPlanungseintrag;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkHerkunftPlanungseintrag;
		private System.ComponentModel.IContainer components;

        




		public ucTerminFilterPicker()
		{
			InitializeComponent();

			pAll.DataBindings.Add("BackColor", this, "BackColor");
			pMassnahme.DataBindings.Add("BackColor", this, "BackColor");

            cbAbzeichnen.Value = -1;
	
	    }
        private void ucTerminFilterPicker_Load(object sender, EventArgs e)
        {
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

		#region Vom Komponenten-Designer generierter Code
		/// <summary> 
		/// Erforderliche Methode f�r die Designerunterst�tzung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor ge�ndert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTerminFilterPicker));
            this.btn = new Infragistics.Win.Misc.UltraDropDownButton();
            this.popupContainer = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.pAll = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelCombos = new System.Windows.Forms.Panel();
            this.cboZeitbezugJNAMulti = new PMDS.GUI.BaseControls.AuswahlGruppeComboMulti();
            this.cboHerkunftPlanungseintrag = new PMDS.GUI.BaseControls.AuswahlGruppeComboMulti();
            this.chkZeitbezugJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cboShowCC = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.chkHerkunftPlanungseintrag = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblCCAnzeigen = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.cbAbzeichnen = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.labAbzeichnen = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboZusatzwerteMulti = new PMDS.GUI.BaseControls.AuswahlGruppeComboMulti();
            this.chkZusatzwerteJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cboBerufsstandMulti = new PMDS.GUI.BaseControls.AuswahlGruppeComboMulti();
            this.cboPlanungsEintr�geMulti = new PMDS.GUI.BaseControls.AuswahlGruppeComboMulti();
            this.chkPlanungsEintr�geJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cboWichtigF�rMulti = new PMDS.GUI.BaseControls.AuswahlGruppeComboMulti();
            this.chkWichtigF�rJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.chkBerufsgruppeJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panelMa�nahme = new System.Windows.Forms.Panel();
            this.btnDelMa�nahme = new QS2.Desktop.ControlManagment.BaseButton();
            this.chkMa�nahme = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.btnEintragMa�nahme = new Infragistics.Win.Misc.UltraDropDownButton();
            this.popupContainer2 = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.pMassnahme = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnClose3 = new QS2.Desktop.ControlManagment.BaseButton();
            this.ucPicker1 = new PMDS.GUI.ucPicker();
            this.dsEintrag1 = new PMDS.Global.db.Pflegeplan.dsEintrag();
            this.lbMa�nahme = new System.Windows.Forms.ListBox();
            this.panelButtonsUnten = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelClose = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnClose2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelAktualisieren = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            this.chkBezugJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.pAll.SuspendLayout();
            this.panelCombos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkZeitbezugJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboShowCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHerkunftPlanungseintrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAbzeichnen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZusatzwerteJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPlanungsEintr�geJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWichtigF�rJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBerufsgruppeJN)).BeginInit();
            this.panelMa�nahme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMa�nahme)).BeginInit();
            this.pMassnahme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsEintrag1)).BeginInit();
            this.panelButtonsUnten.SuspendLayout();
            this.panelClose.SuspendLayout();
            this.panelAktualisieren.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkBezugJN)).BeginInit();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Left";
            this.btn.Appearance = appearance1;
            this.btn.BackColorInternal = System.Drawing.SystemColors.Control;
            this.btn.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaToolbarButton;
            this.btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn.Location = new System.Drawing.Point(0, 0);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(606, 24);
            this.btn.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.btn.TabIndex = 0;
            this.btn.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btn.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // popupContainer
            // 
            this.popupContainer.PopupControl = this.pAll;
            // 
            // pAll
            // 
            this.pAll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pAll.Controls.Add(this.panelCombos);
            this.pAll.Controls.Add(this.panelMa�nahme);
            this.pAll.Controls.Add(this.panelButtonsUnten);
            this.pAll.Location = new System.Drawing.Point(0, 24);
            this.pAll.Name = "pAll";
            this.pAll.Size = new System.Drawing.Size(603, 525);
            this.pAll.TabIndex = 1;
            this.pAll.Visible = false;
            // 
            // panelCombos
            // 
            this.panelCombos.BackColor = System.Drawing.Color.Transparent;
            this.panelCombos.Controls.Add(this.cboZeitbezugJNAMulti);
            this.panelCombos.Controls.Add(this.cboHerkunftPlanungseintrag);
            this.panelCombos.Controls.Add(this.chkZeitbezugJN);
            this.panelCombos.Controls.Add(this.cboShowCC);
            this.panelCombos.Controls.Add(this.chkHerkunftPlanungseintrag);
            this.panelCombos.Controls.Add(this.lblCCAnzeigen);
            this.panelCombos.Controls.Add(this.cbAbzeichnen);
            this.panelCombos.Controls.Add(this.labAbzeichnen);
            this.panelCombos.Controls.Add(this.cboZusatzwerteMulti);
            this.panelCombos.Controls.Add(this.chkZusatzwerteJN);
            this.panelCombos.Controls.Add(this.cboBerufsstandMulti);
            this.panelCombos.Controls.Add(this.cboPlanungsEintr�geMulti);
            this.panelCombos.Controls.Add(this.chkPlanungsEintr�geJN);
            this.panelCombos.Controls.Add(this.cboWichtigF�rMulti);
            this.panelCombos.Controls.Add(this.chkWichtigF�rJN);
            this.panelCombos.Controls.Add(this.chkBerufsgruppeJN);
            this.panelCombos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCombos.Location = new System.Drawing.Point(0, 147);
            this.panelCombos.Name = "panelCombos";
            this.panelCombos.Size = new System.Drawing.Size(603, 339);
            this.panelCombos.TabIndex = 1;
            // 
            // cboZeitbezugJNAMulti
            // 
            this.cboZeitbezugJNAMulti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboZeitbezugJNAMulti.BackColor = System.Drawing.Color.Transparent;
            this.cboZeitbezugJNAMulti.Enabled = false;
            this.cboZeitbezugJNAMulti.Location = new System.Drawing.Point(193, 230);
            this.cboZeitbezugJNAMulti.Name = "cboZeitbezugJNAMulti";
            this.cboZeitbezugJNAMulti.Size = new System.Drawing.Size(403, 23);
            this.cboZeitbezugJNAMulti.TabIndex = 13;
            this.cboZeitbezugJNAMulti.TypeMulti = PMDS.GUI.BaseControls.AuswahlGruppeComboMulti.eTypeMulti.ZeitbezugJNA;
            // 
            // cboHerkunftPlanungseintrag
            // 
            this.cboHerkunftPlanungseintrag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboHerkunftPlanungseintrag.BackColor = System.Drawing.Color.Transparent;
            this.cboHerkunftPlanungseintrag.Enabled = false;
            this.cboHerkunftPlanungseintrag.Location = new System.Drawing.Point(193, 306);
            this.cboHerkunftPlanungseintrag.Name = "cboHerkunftPlanungseintrag";
            this.cboHerkunftPlanungseintrag.Size = new System.Drawing.Size(403, 23);
            this.cboHerkunftPlanungseintrag.TabIndex = 25;
            this.cboHerkunftPlanungseintrag.TypeMulti = PMDS.GUI.BaseControls.AuswahlGruppeComboMulti.eTypeMulti.ZeitbezugJNA;
            // 
            // chkZeitbezugJN
            // 
            this.chkZeitbezugJN.Location = new System.Drawing.Point(8, 232);
            this.chkZeitbezugJN.Name = "chkZeitbezugJN";
            this.chkZeitbezugJN.Size = new System.Drawing.Size(179, 18);
            this.chkZeitbezugJN.TabIndex = 12;
            this.chkZeitbezugJN.Text = "Zeitbezug";
            this.chkZeitbezugJN.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkZeitbezugJN.CheckedChanged += new System.EventHandler(this.chkInterventionstyp_CheckedChanged);
            // 
            // cboShowCC
            // 
            this.cboShowCC.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = -1;
            valueListItem1.DisplayText = "Alle";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "Nur CC";
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "Kein CC";
            this.cboShowCC.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.cboShowCC.Location = new System.Drawing.Point(193, 269);
            this.cboShowCC.Name = "cboShowCC";
            this.cboShowCC.Size = new System.Drawing.Size(403, 21);
            this.cboShowCC.TabIndex = 14;
            this.cboShowCC.ValueChanged += new System.EventHandler(this.cboShowCC_ValueChanged);
            // 
            // chkHerkunftPlanungseintrag
            // 
            this.chkHerkunftPlanungseintrag.Location = new System.Drawing.Point(8, 306);
            this.chkHerkunftPlanungseintrag.Name = "chkHerkunftPlanungseintrag";
            this.chkHerkunftPlanungseintrag.Size = new System.Drawing.Size(177, 18);
            this.chkHerkunftPlanungseintrag.TabIndex = 24;
            this.chkHerkunftPlanungseintrag.Text = "Herkunft Planungseintrag";
            this.chkHerkunftPlanungseintrag.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkHerkunftPlanungseintrag.CheckedChanged += new System.EventHandler(this.chkHerkunftPlanungseintrag_CheckedChanged);
            // 
            // lblCCAnzeigen
            // 
            this.lblCCAnzeigen.Location = new System.Drawing.Point(8, 270);
            this.lblCCAnzeigen.Name = "lblCCAnzeigen";
            this.lblCCAnzeigen.Size = new System.Drawing.Size(178, 18);
            this.lblCCAnzeigen.TabIndex = 23;
            this.lblCCAnzeigen.Text = "CC anzeigen";
            // 
            // cbAbzeichnen
            // 
            this.cbAbzeichnen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAbzeichnen.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem4.DataValue = -1;
            valueListItem4.DisplayText = "Alle";
            valueListItem5.DataValue = 1;
            valueListItem5.DisplayText = "Alle Eintr�ge die gegenzuzeichnen sind";
            valueListItem6.DataValue = 0;
            valueListItem6.DisplayText = "Alle Eintr�ge die nicht gegenzuzeichnen sind";
            this.cbAbzeichnen.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5,
            valueListItem6});
            this.cbAbzeichnen.Location = new System.Drawing.Point(193, 45);
            this.cbAbzeichnen.Name = "cbAbzeichnen";
            this.cbAbzeichnen.Size = new System.Drawing.Size(403, 21);
            this.cbAbzeichnen.TabIndex = 3;
            this.cbAbzeichnen.ValueChanged += new System.EventHandler(this.cbAbzeichnen_ValueChanged);
            // 
            // labAbzeichnen
            // 
            this.labAbzeichnen.AutoSize = true;
            this.labAbzeichnen.Location = new System.Drawing.Point(8, 45);
            this.labAbzeichnen.Name = "labAbzeichnen";
            this.labAbzeichnen.Size = new System.Drawing.Size(90, 14);
            this.labAbzeichnen.TabIndex = 22;
            this.labAbzeichnen.Text = "Gegenzeichnung";
            // 
            // cboZusatzwerteMulti
            // 
            this.cboZusatzwerteMulti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboZusatzwerteMulti.BackColor = System.Drawing.Color.Transparent;
            this.cboZusatzwerteMulti.Enabled = false;
            this.cboZusatzwerteMulti.Location = new System.Drawing.Point(193, 194);
            this.cboZusatzwerteMulti.Name = "cboZusatzwerteMulti";
            this.cboZusatzwerteMulti.Size = new System.Drawing.Size(403, 23);
            this.cboZusatzwerteMulti.TabIndex = 11;
            this.cboZusatzwerteMulti.TypeMulti = PMDS.GUI.BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Zusatzwerte;
            // 
            // chkZusatzwerteJN
            // 
            this.chkZusatzwerteJN.Location = new System.Drawing.Point(8, 195);
            this.chkZusatzwerteJN.Name = "chkZusatzwerteJN";
            this.chkZusatzwerteJN.Size = new System.Drawing.Size(179, 20);
            this.chkZusatzwerteJN.TabIndex = 10;
            this.chkZusatzwerteJN.Text = "Zusatzwerte";
            this.chkZusatzwerteJN.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkZusatzwerteJN.CheckedChanged += new System.EventHandler(this.chkZusatzwerte_CheckedChanged);
            // 
            // cboBerufsstandMulti
            // 
            this.cboBerufsstandMulti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBerufsstandMulti.BackColor = System.Drawing.Color.Transparent;
            this.cboBerufsstandMulti.Enabled = false;
            this.cboBerufsstandMulti.Location = new System.Drawing.Point(193, 116);
            this.cboBerufsstandMulti.Name = "cboBerufsstandMulti";
            this.cboBerufsstandMulti.Size = new System.Drawing.Size(403, 23);
            this.cboBerufsstandMulti.TabIndex = 7;
            this.cboBerufsstandMulti.TypeMulti = PMDS.GUI.BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Berufsgruppe;
            // 
            // cboPlanungsEintr�geMulti
            // 
            this.cboPlanungsEintr�geMulti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPlanungsEintr�geMulti.BackColor = System.Drawing.Color.Transparent;
            this.cboPlanungsEintr�geMulti.Enabled = false;
            this.cboPlanungsEintr�geMulti.Location = new System.Drawing.Point(193, 77);
            this.cboPlanungsEintr�geMulti.Name = "cboPlanungsEintr�geMulti";
            this.cboPlanungsEintr�geMulti.Size = new System.Drawing.Size(403, 23);
            this.cboPlanungsEintr�geMulti.TabIndex = 5;
            this.cboPlanungsEintr�geMulti.TypeMulti = PMDS.GUI.BaseControls.AuswahlGruppeComboMulti.eTypeMulti.TypePlanungseintrag;
            // 
            // chkPlanungsEintr�geJN
            // 
            this.chkPlanungsEintr�geJN.Location = new System.Drawing.Point(8, 77);
            this.chkPlanungsEintr�geJN.Name = "chkPlanungsEintr�geJN";
            this.chkPlanungsEintr�geJN.Size = new System.Drawing.Size(180, 20);
            this.chkPlanungsEintr�geJN.TabIndex = 4;
            this.chkPlanungsEintr�geJN.Text = "Planungstypen";
            this.chkPlanungsEintr�geJN.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkPlanungsEintr�geJN.CheckedChanged += new System.EventHandler(this.chkEintragstypMulti_CheckedChanged);
            // 
            // cboWichtigF�rMulti
            // 
            this.cboWichtigF�rMulti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboWichtigF�rMulti.BackColor = System.Drawing.Color.Transparent;
            this.cboWichtigF�rMulti.Enabled = false;
            this.cboWichtigF�rMulti.Location = new System.Drawing.Point(193, 155);
            this.cboWichtigF�rMulti.Name = "cboWichtigF�rMulti";
            this.cboWichtigF�rMulti.Size = new System.Drawing.Size(403, 23);
            this.cboWichtigF�rMulti.TabIndex = 9;
            this.cboWichtigF�rMulti.TypeMulti = PMDS.GUI.BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Berufsgruppe;
            // 
            // chkWichtigF�rJN
            // 
            this.chkWichtigF�rJN.Location = new System.Drawing.Point(8, 156);
            this.chkWichtigF�rJN.Name = "chkWichtigF�rJN";
            this.chkWichtigF�rJN.Size = new System.Drawing.Size(180, 20);
            this.chkWichtigF�rJN.TabIndex = 8;
            this.chkWichtigF�rJN.Text = "Wichtig f�r Berufsgruppe";
            this.chkWichtigF�rJN.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkWichtigF�rJN.CheckedChanged += new System.EventHandler(this.chkWichtigF�rJN_CheckedChanged);
            // 
            // chkBerufsgruppeJN
            // 
            this.chkBerufsgruppeJN.Location = new System.Drawing.Point(8, 116);
            this.chkBerufsgruppeJN.Name = "chkBerufsgruppeJN";
            this.chkBerufsgruppeJN.Size = new System.Drawing.Size(182, 20);
            this.chkBerufsgruppeJN.TabIndex = 6;
            this.chkBerufsgruppeJN.Text = "Geplant f�r Berufsgruppe";
            this.chkBerufsgruppeJN.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkBerufsgruppeJN.CheckedChanged += new System.EventHandler(this.chkBerufsgruppeJN_CheckedChanged);
            // 
            // panelMa�nahme
            // 
            this.panelMa�nahme.BackColor = System.Drawing.Color.Transparent;
            this.panelMa�nahme.Controls.Add(this.btnDelMa�nahme);
            this.panelMa�nahme.Controls.Add(this.chkMa�nahme);
            this.panelMa�nahme.Controls.Add(this.btnEintragMa�nahme);
            this.panelMa�nahme.Controls.Add(this.lbMa�nahme);
            this.panelMa�nahme.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMa�nahme.Location = new System.Drawing.Point(0, 0);
            this.panelMa�nahme.Name = "panelMa�nahme";
            this.panelMa�nahme.Size = new System.Drawing.Size(603, 147);
            this.panelMa�nahme.TabIndex = 0;
            // 
            // btnDelMa�nahme
            // 
            this.btnDelMa�nahme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelMa�nahme.AutoWorkLayout = false;
            this.btnDelMa�nahme.IsStandardControl = false;
            this.btnDelMa�nahme.Location = new System.Drawing.Point(530, 5);
            this.btnDelMa�nahme.Name = "btnDelMa�nahme";
            this.btnDelMa�nahme.Size = new System.Drawing.Size(66, 19);
            this.btnDelMa�nahme.TabIndex = 2;
            this.btnDelMa�nahme.Text = "entfernen";
            this.btnDelMa�nahme.Click += new System.EventHandler(this.btnDelM_Click);
            // 
            // chkMa�nahme
            // 
            this.chkMa�nahme.Location = new System.Drawing.Point(8, 5);
            this.chkMa�nahme.Name = "chkMa�nahme";
            this.chkMa�nahme.Size = new System.Drawing.Size(254, 17);
            this.chkMa�nahme.TabIndex = 1;
            this.chkMa�nahme.Text = "Nur die gew�hlte(n) Ma�nahme(n) anzeigen";
            this.chkMa�nahme.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkMa�nahme.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // btnEintragMa�nahme
            // 
            this.btnEintragMa�nahme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.TextHAlignAsString = "Left";
            this.btnEintragMa�nahme.Appearance = appearance2;
            this.btnEintragMa�nahme.BackColorInternal = System.Drawing.SystemColors.Control;
            this.btnEintragMa�nahme.Enabled = false;
            this.btnEintragMa�nahme.Location = new System.Drawing.Point(8, 120);
            this.btnEintragMa�nahme.Name = "btnEintragMa�nahme";
            this.btnEintragMa�nahme.PopupItemKey = "ucPicker1";
            this.btnEintragMa�nahme.PopupItemProvider = this.popupContainer2;
            this.btnEintragMa�nahme.Size = new System.Drawing.Size(588, 21);
            this.btnEintragMa�nahme.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.btnEintragMa�nahme.TabIndex = 4;
            this.btnEintragMa�nahme.Text = "Ma�nahmen einf�gen";
            this.btnEintragMa�nahme.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnEintragMa�nahme.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // popupContainer2
            // 
            this.popupContainer2.PopupControl = this.pMassnahme;
            this.popupContainer2.Opened += new System.EventHandler(this.popupContainer2_Opened);
            // 
            // pMassnahme
            // 
            this.pMassnahme.BackColor = System.Drawing.Color.Gainsboro;
            this.pMassnahme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pMassnahme.Controls.Add(this.btnClose3);
            this.pMassnahme.Controls.Add(this.ucPicker1);
            this.pMassnahme.Location = new System.Drawing.Point(0, 548);
            this.pMassnahme.Name = "pMassnahme";
            this.pMassnahme.Size = new System.Drawing.Size(603, 237);
            this.pMassnahme.TabIndex = 2;
            this.pMassnahme.Visible = false;
            // 
            // btnClose3
            // 
            this.btnClose3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose3.AutoWorkLayout = false;
            this.btnClose3.IsStandardControl = false;
            this.btnClose3.Location = new System.Drawing.Point(529, 207);
            this.btnClose3.Name = "btnClose3";
            this.btnClose3.Size = new System.Drawing.Size(65, 24);
            this.btnClose3.TabIndex = 100;
            this.btnClose3.Text = "Schlie�en";
            this.btnClose3.Click += new System.EventHandler(this.btnClose3_Click);
            // 
            // ucPicker1
            // 
            this.ucPicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPicker1.BackColor = System.Drawing.Color.Transparent;
            this.ucPicker1.DataSource = this.dsEintrag1.Eintrag;
            this.ucPicker1.DisplayMember = "Text";
            this.ucPicker1.Location = new System.Drawing.Point(0, 42);
            this.ucPicker1.Name = "ucPicker1";
            this.ucPicker1.Size = new System.Drawing.Size(601, 168);
            this.ucPicker1.TabIndex = 0;
            this.ucPicker1.Value = null;
            this.ucPicker1.ValueMember = "ID";
            this.ucPicker1.SelectionChanged += new System.EventHandler(this.ucPicker1_SelectionChanged);
            this.ucPicker1.Selected += new PMDS.GUI.ucPicker.PickerSelectedDelegate(this.ucPicker1_Selected);
            // 
            // dsEintrag1
            // 
            this.dsEintrag1.DataSetName = "dsEintrag";
            this.dsEintrag1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsEintrag1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbMa�nahme
            // 
            this.lbMa�nahme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMa�nahme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMa�nahme.Location = new System.Drawing.Point(8, 24);
            this.lbMa�nahme.Name = "lbMa�nahme";
            this.lbMa�nahme.Size = new System.Drawing.Size(588, 93);
            this.lbMa�nahme.TabIndex = 3;
            this.lbMa�nahme.SelectedIndexChanged += new System.EventHandler(this.lbM_SelectedIndexChanged);
            // 
            // panelButtonsUnten
            // 
            this.panelButtonsUnten.Controls.Add(this.panelClose);
            this.panelButtonsUnten.Controls.Add(this.panelAktualisieren);
            this.panelButtonsUnten.Location = new System.Drawing.Point(67, 488);
            this.panelButtonsUnten.Name = "panelButtonsUnten";
            this.panelButtonsUnten.Size = new System.Drawing.Size(420, 30);
            this.panelButtonsUnten.TabIndex = 100;
            // 
            // panelClose
            // 
            this.panelClose.Controls.Add(this.btnClose2);
            this.panelClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelClose.Location = new System.Drawing.Point(200, 0);
            this.panelClose.Name = "panelClose";
            this.panelClose.Size = new System.Drawing.Size(120, 30);
            this.panelClose.TabIndex = 0;
            // 
            // btnClose2
            // 
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnClose2.Appearance = appearance3;
            this.btnClose2.AutoWorkLayout = false;
            this.btnClose2.IsStandardControl = false;
            this.btnClose2.Location = new System.Drawing.Point(45, 2);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(70, 25);
            this.btnClose2.TabIndex = 0;
            this.btnClose2.Text = "Schlie�en";
            this.btnClose2.Click += new System.EventHandler(this.btnClose2_Click);
            // 
            // panelAktualisieren
            // 
            this.panelAktualisieren.Controls.Add(this.btnClose);
            this.panelAktualisieren.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelAktualisieren.Location = new System.Drawing.Point(320, 0);
            this.panelAktualisieren.Name = "panelAktualisieren";
            this.panelAktualisieren.Size = new System.Drawing.Size(100, 30);
            this.panelAktualisieren.TabIndex = 1;
            this.panelAktualisieren.Visible = false;
            // 
            // btnClose
            // 
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnClose.Appearance = appearance4;
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.IsStandardControl = false;
            this.btnClose.Location = new System.Drawing.Point(0, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Aktualisieren";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkBezugJN
            // 
            this.chkBezugJN.Location = new System.Drawing.Point(0, 0);
            this.chkBezugJN.Name = "chkBezugJN";
            this.chkBezugJN.Size = new System.Drawing.Size(120, 20);
            this.chkBezugJN.TabIndex = 0;
            // 
            // ucTerminFilterPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.pAll);
            this.Controls.Add(this.pMassnahme);
            this.Controls.Add(this.btn);
            this.Name = "ucTerminFilterPicker";
            this.Size = new System.Drawing.Size(606, 730);
            this.Load += new System.EventHandler(this.ucTerminFilterPicker_Load);
            this.pAll.ResumeLayout(false);
            this.panelCombos.ResumeLayout(false);
            this.panelCombos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkZeitbezugJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboShowCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHerkunftPlanungseintrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAbzeichnen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZusatzwerteJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPlanungsEintr�geJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWichtigF�rJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBerufsgruppeJN)).EndInit();
            this.panelMa�nahme.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkMa�nahme)).EndInit();
            this.pMassnahme.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsEintrag1)).EndInit();
            this.panelButtonsUnten.ResumeLayout(false);
            this.panelClose.ResumeLayout(false);
            this.panelAktualisieren.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkBezugJN)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion






        public void initControl(bool IsQuickfilter, eUITypeTermine UITypeTermine, bool isTerminpicker)
        {
            try
            {
                this.BackColor = System.Drawing.Color.Gainsboro;
                this.ShowCC = -1;
                this.Abzeichnen = -1;

                if (!this.IsInitialized)
                {
                    if (isTerminpicker)
                        this.btn.PopupItem = this.popupContainer;

                    this.initCombos();
                    this.cboBerufsstandMulti.initControl(BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Berufsgruppe, UITypeTermine, IsQuickfilter, -1, -100000, false);
                    this.cboWichtigF�rMulti.initControl(BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Berufsgruppe, UITypeTermine, IsQuickfilter, -1, -100000, false);
                    this.cboPlanungsEintr�geMulti.initControl(BaseControls.AuswahlGruppeComboMulti.eTypeMulti.TypePlanungseintrag, UITypeTermine, IsQuickfilter, -1, -100000, false);
                    this.cboZusatzwerteMulti.initControl(BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Zusatzwerte, UITypeTermine, IsQuickfilter, -1, -100000, false);
                    this.cboZeitbezugJNAMulti.initControl(BaseControls.AuswahlGruppeComboMulti.eTypeMulti.ZeitbezugJNA, UITypeTermine, IsQuickfilter, -1, -100000, false);
                    this.cboHerkunftPlanungseintrag.initControl(BaseControls.AuswahlGruppeComboMulti.eTypeMulti.HerkunftPlanungseintrag, UITypeTermine, IsQuickfilter, -1, -100000, false);

                    if (this.mainWindowxy == null)
                    {
                        this.cbAbzeichnen.Visible = true;
                        this.cboBerufsstandMulti.Visible = true;
                    }
                    else
                    {
                        if (this.mainWindowxy.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Interventionen)
                        {
                            this.labAbzeichnen.Visible = false;
                            this.cbAbzeichnen.Visible = false;
                            this.cboBerufsstandMulti.Visible = true;
                            this.chkWichtigF�rJN.Visible = false;
                            this.cboWichtigF�rMulti.Visible = false;
                            this.cboPlanungsEintr�geMulti.Visible = true;
                            this.chkZusatzwerteJN.Visible = false;
                            this.cboZusatzwerteMulti.Visible = false;
                            this.chkZeitbezugJN.Visible = true;
                            this.cboZeitbezugJNAMulti.Visible = true;
                            this.lblCCAnzeigen.Visible = false;
                            this.cboShowCC.Visible = false;
                            this.chkHerkunftPlanungseintrag.Visible = false;
                            this.cboHerkunftPlanungseintrag.Visible = false;
                        }
                        else if (this.mainWindowxy.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.�bergabe)
                        {
                            this.labAbzeichnen.Visible = true;
                            this.cbAbzeichnen.Visible = true;
                            this.cboBerufsstandMulti.Visible = true;
                            this.cboPlanungsEintr�geMulti.Visible = true;
                            this.chkZusatzwerteJN.Visible = true;
                            this.cboZusatzwerteMulti.Visible = true;
                            this.chkZeitbezugJN.Visible = false;
                            this.cboZeitbezugJNAMulti.Visible = false;
                            this.lblCCAnzeigen.Visible = true;
                            this.cboShowCC.Visible = true;
                            this.chkHerkunftPlanungseintrag.Visible = true;
                            this.cboHerkunftPlanungseintrag.Visible = true;
                        }
                        else if (this.mainWindowxy.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Dekurs)
                        {
                            this.labAbzeichnen.Visible = true;
                            this.cbAbzeichnen.Visible = true;
                            this.cboBerufsstandMulti.Visible = true;
                            this.panelMa�nahme.Visible = false;
                            this.chkPlanungsEintr�geJN.Visible = false;
                            this.cboPlanungsEintr�geMulti.Visible = false;
                            this.chkZusatzwerteJN.Visible = false;
                            this.cboZusatzwerteMulti.Visible = false;
                            this.chkZeitbezugJN.Visible = false;
                            this.cboZeitbezugJNAMulti.Visible = false;
                            this.lblCCAnzeigen.Visible = true;
                            this.cboShowCC.Visible = true;
                            this.chkHerkunftPlanungseintrag.Visible = true;
                            this.cboHerkunftPlanungseintrag.Visible = true;
                        } 
                    }

                    this.RefreshGUI();
                    this.IsInitialized = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucTerminFilterPicker.initControl: " + ex.ToString());
            }
        }
        public void initCombos()
        {
            if (this.mainWindowxy == null)
            {
            }
            else
            {
                if (this.mainWindowxy.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Interventionen)
                {
                    this.cboWichtigF�rMulti.Visible = false;
                    this.cboWichtigF�rMulti.Visible = false;
                }
                else if (this.mainWindowxy.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.�bergabe)
                {
                }
                else if (this.mainWindowxy.ucSiteMapTermine1._UITypeTermine == eUITypeTermine.Dekurs)
                {
                }
            }
        }

        //public void ShowBezugsPflegePersonxy(bool bShow)
        //{
        //    //this.chkBezugJN.Visible = bShow;
        //    //this.cbBezug.Visible = bShow;
        //}

		public void RefreshGUI()
		{
			//object o = cbBezug.Value;
            //this.cbBezug.RefreshList();
            //this.cbBezug.Value = o;

            this.ucPicker1.DataSource = new PDx().KATALOGE['M'].EINTRAEGE;
            this.UpdateText();
		}

		public int Abzeichnen
		{
			get
			{
                if (!DesignMode)
                {
                    if (this.cbAbzeichnen.Value == null)
                    {
                        throw new NotSupportedException("ucTerminFilterPicker.AbzeichnenJN: this.cbAbzeichnenJN.Value == null");
                    }
                }

                return (int)this.cbAbzeichnen.Value;
			}
			set 
			{
				cbAbzeichnen.Value = value;
			}
		}
        public int ShowCC
        {
            get
            {
                if (!DesignMode)
                {
                    if (this.cboShowCC.Value == null)
                    {
                        throw new NotSupportedException("ucTerminFilterPicker.ShowCC: this.cboShowCC.Value == null");
                    }
                    else
                    {

                    }
                }
                else
                {
                    
                }
                if (IsInitialized)
                {
                    return (int)this.cboShowCC.Value;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                cboShowCC.Value = value;
            }
        }
        public bool ShowBerufsstand
        {
            get
            {
                return this.chkBerufsgruppeJN.Checked;
            }
            set
            {
                this.chkBerufsgruppeJN.Checked = value;
            }
        }
        public bool ShowZusatzwerte
        {
            get
            {
                return this.chkZusatzwerteJN.Checked;
            }
            set
            {
                this.chkZusatzwerteJN.Checked = value;
            }
        }
        public bool ShowZeitbezugJN
        {
            get
            {
                return this.chkZeitbezugJN.Checked;
            }
            set
            {
                this.chkZeitbezugJN.Checked = value;
            }
        }
        public bool ShowHerkunftPlanungsEintrag
        {
            get
            {
                return this.chkHerkunftPlanungseintrag.Checked;
            }
            set
            {
                this.chkHerkunftPlanungseintrag.Checked = value;
            }
        }
        public bool ShowPlanungsEintr�geJN
        {
            get
            {
                return this.chkPlanungsEintr�geJN.Checked;
            }
            set
            {
                this.chkPlanungsEintr�geJN.Checked = value;
            }
        }
        public bool ShowBezug
        {
            get
            {
                return this.chkBezugJN.Checked;
            }
            set
            {
                this.chkBezugJN.Checked = value;
            }
        }


        public System.Collections.Generic.List<Guid> setBerufsstandErstelltFromString(string slstGuid)
        {
            try
            {
                System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                this.ShowBerufsstand = false;
                this.cboBerufsstandMulti.clearSelectedNodes();
                if (slstGuid.Trim() != "")
                {
                    this.UISitemaps1.getListGuidFromString(slstGuid, ref lstGuid);
                    if (lstGuid.Count > 0)
                    {
                        this.Berufsstand = lstGuid;
                        this.ShowBerufsstand = true;
                    }
                }

                return lstGuid;
            }
            catch (Exception ex)
            {
                throw new Exception("setBerufsstandErstelltFromString: " + ex.ToString());
            }
        }
        public System.Collections.Generic.List<Guid> setWichtigF�rFromString(string slstGuid)
        {
            try
            {
                System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                this.WichtigF�rJN = false;
                this.cboWichtigF�rMulti.clearSelectedNodes();
                if (slstGuid.Trim() != "")
                {
                    this.UISitemaps1.getListGuidFromString(slstGuid, ref lstGuid);
                    if (lstGuid.Count > 0)
                    {
                        this.WichtigF�r = lstGuid;
                        this.WichtigF�rJN = true;
                    }
                }

                return lstGuid;
            }
            catch (Exception ex)
            {
                throw new Exception("setWichtigF�rFromString: " + ex.ToString());
            }
        }
        public System.Collections.Generic.List<string> setZusatzwerteFromString(string slstString)
        {
            try
            {
                System.Collections.Generic.List<string> lstString = new System.Collections.Generic.List<string>();
                this.ShowZusatzwerte = false;
                this.cboZusatzwerteMulti.clearSelectedNodes();
                if (slstString.Trim() != "")
                {
                    this.UISitemaps1.getListStringFromString(slstString, ref lstString);
                    if (lstString.Count > 0)
                    {
                        this.Zusatzwerte = lstString;
                        this.ShowZusatzwerte = true;
                    }
                }

                return lstString;
            }
            catch (Exception ex)
            {
                throw new Exception("setZusatzwerteErstelltFromString: " + ex.ToString());
            }
        }
        public System.Collections.Generic.List<int> setZeitbezugJNAFromInt(string slstString)
        {
            try
            {
                System.Collections.Generic.List<int> lstInt= new System.Collections.Generic.List<int>();
                this.ShowZeitbezugJN = false;
                this.cboZeitbezugJNAMulti.clearSelectedNodes();
                if (slstString.Trim() != "")
                {
                    this.UISitemaps1.getListIntFromString(slstString, ref lstInt);
                    if (lstInt.Count > 0)
                    {
                        this.ZeitbezugJNA = lstInt;
                        this.ShowZeitbezugJN = true;
                    }
                }

                return lstInt;
            }
            catch (Exception ex)
            {
                throw new Exception("setZeitbezugJNAFromString: " + ex.ToString());
            }
        }
        public System.Collections.Generic.List<int> setHerkunftPlanungsEintragFromInt(string slstString)
        {
            try
            {
                System.Collections.Generic.List<int> lstInt = new System.Collections.Generic.List<int>();
                this.ShowHerkunftPlanungsEintrag = false;
                this.cboHerkunftPlanungseintrag.clearSelectedNodes();
                if (slstString.Trim() != "")
                {
                    this.UISitemaps1.getListIntFromString(slstString, ref lstInt);
                    if (lstInt.Count > 0)
                    {
                        this.HerkunftPlanungsEintrag = lstInt;
                        this.ShowHerkunftPlanungsEintrag = true;
                    }
                }

                return lstInt;
            }
            catch (Exception ex)
            {
                throw new Exception("setHerkunftPlanungsEintragJNAFromInt: " + ex.ToString());
            }
        }
        public System.Collections.Generic.List<int> setPlanungsEintr�geFromString(string slstInt)
        {
            try
            {
                System.Collections.Generic.List<int> lstInt = new System.Collections.Generic.List<int>();
                this.ShowPlanungsEintr�geJN  = false;
                this.cboPlanungsEintr�geMulti.clearSelectedNodes();
                if (slstInt.Trim() != "")
                {
                    this.UISitemaps1.getListIntFromString(slstInt, ref lstInt);
                    if (lstInt.Count > 0)
                    {
                        this.PlanungsEintr�ge = lstInt;
                        this.ShowPlanungsEintr�geJN = true;
                    }
                }

                return lstInt;
            }
            catch (Exception ex)
            {
                throw new Exception("setPlanungsEintr�geFromString: " + ex.ToString());
            }
        }


        public System.Collections.Generic.List<Guid> Berufsstand
        {
            get
            {
                System.Collections.Generic.List<Guid> lstBerufsstand = new System.Collections.Generic.List<Guid>();
                System.Collections.Generic.List<int> lstIntSelected = new System.Collections.Generic.List<int>();
                System.Collections.Generic.List<string> lstStringSelected = new System.Collections.Generic.List<string>();
                this.cboBerufsstandMulti.getSelected(ref lstBerufsstand, ref lstIntSelected, ref lstStringSelected);
                return lstBerufsstand;
            }
            set
            {
                this.cboBerufsstandMulti.setSelected(value, null, null);
            }
        }
        public System.Collections.Generic.List<string> Zusatzwerte
        {
            get
            {
                System.Collections.Generic.List<string> lstZusatzwerte = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<Guid> lstGuid= new System.Collections.Generic.List<Guid>();
                System.Collections.Generic.List<int> lstIntSelected = new System.Collections.Generic.List<int>();
                this.cboZusatzwerteMulti.getSelected(ref lstGuid, ref lstIntSelected, ref lstZusatzwerte);
                return lstZusatzwerte;
            }
            set
            {
                this.cboZusatzwerteMulti.setSelected(null, null, value);
            }
        }
        public System.Collections.Generic.List<int> ZeitbezugJNA
        {
            get
            {
                System.Collections.Generic.List<string> lstStrSelected = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                System.Collections.Generic.List<int> lstZeitbezug = new System.Collections.Generic.List<int>();
                this.cboZeitbezugJNAMulti.getSelected(ref lstGuid, ref lstZeitbezug, ref lstStrSelected);
                return lstZeitbezug;
            }
            set
            {
                this.cboZeitbezugJNAMulti.setSelected(null, value, null);
            }
        }
        public System.Collections.Generic.List<int> HerkunftPlanungsEintrag
        {
            get
            {
                System.Collections.Generic.List<string> lstStrSelected = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                System.Collections.Generic.List<int> lstHerkunftPlanungsEintrag = new System.Collections.Generic.List<int>();
                this.cboHerkunftPlanungseintrag.getSelected(ref lstGuid, ref lstHerkunftPlanungsEintrag, ref lstStrSelected);
                return lstHerkunftPlanungsEintrag;
            }
            set
            {
                this.cboHerkunftPlanungseintrag.setSelected(null, value, null);
            }
        }
        public System.Collections.Generic.List<int> PlanungsEintr�ge
        {
            get
            {
                System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                System.Collections.Generic.List<int> lstPlanungsEintr�ge = new System.Collections.Generic.List<int>();
                System.Collections.Generic.List<string> lstStringSelected = new System.Collections.Generic.List<string>();
                this.cboPlanungsEintr�geMulti.getSelected(ref lstGuid, ref lstPlanungsEintr�ge, ref lstStringSelected);
                return lstPlanungsEintr�ge;
            }
            set
            {
                this.cboPlanungsEintr�geMulti.setSelected(null, value, null);
            }
        }

        public bool WichtigF�rJN
        {
            get
            {
                return this.chkWichtigF�rJN.Checked;
            }
            set
            {
                this.chkWichtigF�rJN.Checked = value;
            }
        }
        public System.Collections.Generic.List<Guid> WichtigF�r
        {
            get
            {
                System.Collections.Generic.List<Guid> lstWichtigF�r = new System.Collections.Generic.List<Guid>();
                System.Collections.Generic.List<int> lstIntSelected = new System.Collections.Generic.List<int>();
                System.Collections.Generic.List<string> lstStringSelected = new System.Collections.Generic.List<string>();
                this.cboWichtigF�rMulti.getSelected(ref lstWichtigF�r, ref lstIntSelected, ref lstStringSelected);
                return lstWichtigF�r;
            }
            set
            {
                this.cboWichtigF�rMulti.setSelected(value, null, null);
            }
        }

		public Guid[] MASSNAHMEN 
		{
			get 
			{
				ArrayList al = new ArrayList();
				if(chkMa�nahme.Checked)					// Wenn haken gesetzt dann Liste generieren sonst leeres Array liefern
				{
					foreach(ucPicker.PickerSelectedArgs a in lbMa�nahme.Items)
						al.Add(a._IDEintrag);
				}
				return (Guid[])al.ToArray(typeof(Guid));
			}
			set
			{
				lbMa�nahme.Items.Clear();
				foreach(Guid g in value)
                    this.lbMa�nahme.Items.Add(new ucPicker.PickerSelectedArgs(g, PMDS.DB.DBUtil.GetEintrag(g).Text));
			}
		}

		public Guid IDMassnahme
		{
			get
			{
				if (!chkMa�nahme.Checked || (ucPicker1.Value == null))
					return Guid.Empty;

				return (Guid)ucPicker1.Value;
			}

			set
			{
                this.chkMa�nahme.Checked = (value != Guid.Empty);
                if (this.chkMa�nahme.Checked)
                    this.ucPicker1.Value = value;
			}
		}

		//public Guid IDBezug
		//{
		//	get
		//	{
  //              if (!this.chkBezugJN.Checked || (cbBezug.Value == null))
		//			return Guid.Empty;

		//		return (Guid)cbBezug.Value;
		//	}
		//	set
		//	{
		//		chkBezugJN.Checked = (value != Guid.Empty);
		//		if (chkBezugJN.Checked)
		//			cbBezug.Value = value;
		//	}
		//}

		private void UpdateText()
		{
			string text = "";

            if (this.chkMa�nahme.Checked) text = AddText(text, ENV.String("GUI.FILTER_EINTRAG"));
            if (this.chkBezugJN.Checked) text = AddText(text, ENV.String("GUI.FILTER_BEZUG"));
            if (this.chkBerufsgruppeJN.Checked) text = AddText(text, "Berufsstand");
            if (this.chkWichtigF�rJN.Checked) text = AddText(text, "Wichtig f�r");
            if (this.chkPlanungsEintr�geJN.Checked) text = AddText(text, "Planungseintr�ge");
            if (this.chkZeitbezugJN.Checked) text = AddText(text, "Zeitbezug");
            if (this.chkZusatzwerteJN.Checked) text = AddText(text, "Zusatzwerte");
            if (this.chkHerkunftPlanungseintrag.Checked) text = AddText(text, "Herkunft Planungseintrag");
            if (((int)this.ShowCC) != -1)
            {
                text = AddText(text, "CC");
            }
            if (((int)this.Abzeichnen) != -1)
            {
                text = AddText(text, "Abzeichnen");
            }
			if (text == "")			text = ENV.String("GUI.FILTER_NONE");

            this.btn.Text = text;
		}

		public void ClearFields() 
		{
            this.lbMa�nahme.Text = "";

            this.cbAbzeichnen.Value = -1;
            this.chkMa�nahme.Checked = false;

            //this.chkBezugJN.Checked = false;
            //this.cbBezug.SelectedItem = null;

            this.chkBerufsgruppeJN.Checked = false;
            this.cboBerufsstandMulti.clearSelectedNodes();

            this.chkZusatzwerteJN.Checked = false;
            this.cboZusatzwerteMulti.clearSelectedNodes();

            this.chkPlanungsEintr�geJN.Checked = false;
            this.cboPlanungsEintr�geMulti.clearSelectedNodes();

            this.chkZeitbezugJN.Checked = false;
            this.cboZeitbezugJNAMulti.clearSelectedNodes();

            this.chkHerkunftPlanungseintrag.Checked = false;
            this.cboHerkunftPlanungseintrag.clearSelectedNodes();

            this.ShowCC = -1;
		}

		private string AddText(string txt1, string txt2)
		{
			if (txt1.Length != 0)
				txt1 += " , ";

			txt1 += txt2;
			return txt1;
		}
        public void historieOnOff(bool bOn)
        {
            if (bOn)
            {
                this.btn.Appearance.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                this.btn.Appearance.ForeColor = System.Drawing.Color.Black;
            }
        }

		private void chk_CheckedChanged(object sender, System.EventArgs e)
		{
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                btnEintragMa�nahme.Enabled = chkMa�nahme.Checked;
                //cbBezug.Enabled = chkBezugJN.Checked;
                ShowHideDelButton();
                UpdateText();

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
		private void ShowHideDelButton() 
		{
			btnDelMa�nahme.Enabled		= chkMa�nahme.Checked && (lbMa�nahme.Items.Count > 0);
		}

		private void cb_ValueChanged(object sender, System.EventArgs e)
		{
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                UpdateText();

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

		private void btnClose_Click(object sender, System.EventArgs e)
		{
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                btn.Focus();
                Application.DoEvents();
                if (this.mainWindowxy != null)
                {
                    bool LayoutFound = false;
                    //this.mainWindowxy.MainWindow.quickFilterButtons1.QButtonClicked = null;
                    this.mainWindowxy.MainWindow.quickFilterButtons1.ManuellFilterClicked = true;
                    this.mainWindowxy.MainWindow.getTermine(this.mainWindowxy.MainWindow.UITypeTermine, ref LayoutFound, true);
                } 

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
		private void ucPicker1_SelectionChanged(object sender, System.EventArgs e)
		{
		}

		private void popupContainer2_Opened(object sender, System.EventArgs e)
		{
			ucPicker1.Focus();
		}

		private void ucPicker1_Selected(PMDS.GUI.ucPicker.PickerSelectedArgs args)
		{
			 lbMa�nahme.Items.Add(args);
		}

		private void lbM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowHideDelButton();

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
        private void btnDelM_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (lbMa�nahme.SelectedIndex < 0)
                    return;
                this.lbMa�nahme.Items.RemoveAt(lbMa�nahme.SelectedIndex);


                if (lbMa�nahme.Items.Count > 0)
                    this.lbMa�nahme.SelectedIndex = 0;

                this.ShowHideDelButton();

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
        private void btnClose2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.btn.Focus();

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
        private void chkBerufsgruppeJN_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.cboBerufsstandMulti.Enabled = this.chkBerufsgruppeJN.Checked;
                this.UpdateText();

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
        private void btnClose3_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.btnEintragMa�nahme.Focus();

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

        private void chkWichtigF�rJN_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.cboWichtigF�rMulti.Enabled = this.chkWichtigF�rJN.Checked;
                this.UpdateText();

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

        private void chkEintragstypMulti_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.cboPlanungsEintr�geMulti.Enabled = this.chkPlanungsEintr�geJN.Checked;
                this.UpdateText();

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

        private void chkZusatzwerte_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.cboZusatzwerteMulti.Enabled = this.chkZusatzwerteJN.Checked;
                this.UpdateText();

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

        private void chkInterventionstyp_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.cboZeitbezugJNAMulti.Enabled = this.chkZeitbezugJN.Checked;
                this.UpdateText();

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

        private void cbAbzeichnen_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.cbAbzeichnen.Focused)
                {
                    this.UpdateText();
                }

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

        private void cboShowCC_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.cboShowCC.Focused)
                {
                    this.UpdateText();
                }

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

        private void chkHerkunftPlanungseintrag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.cboHerkunftPlanungseintrag.Enabled = this.chkHerkunftPlanungseintrag.Checked;
                this.UpdateText();

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
