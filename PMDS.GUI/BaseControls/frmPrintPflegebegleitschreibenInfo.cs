//----------------------------------------------------------------------------
/// <summary>
///	frmPrintPflegebriefInfo.cs
/// Erstellt am:	26.6.2007
/// Erstellt von:	RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using PMDS.GUI;
using PMDS.Global;
using PMDS.BusinessLogic;
using System.Text;
using Infragistics.Win.UltraWinEditors;
using PMDS.GUI.BaseControls;
using System.Reflection;
using PMDS.Global.db.ERSystem;
using PMDSClient.Sitemap;
using System.Linq;
using PMDS.GUI.VB;

namespace PMDS.DynReportsForms
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Form für Druck-Vorschau.
	/// </summary>
	//----------------------------------------------------------------------------
	public class frmPrintPflegebegleitschreibenInfo : DynReportsForm
	{
        public bool SavePBSToArchive { set; get; } = false;
        private bool ReceiverELGA { get; set; } = false;
		private bool _canClose = false;
		private QS2.Desktop.ControlManagment.BaseLabel lblAnEinrichtung;
        public EinrichtungsCombo cbETo;
        private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpWichtigeInformationen;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtBemerkung;
        private TableLayoutPanel tableLayoutPanelMain;
        private QS2.Desktop.ControlManagment.BasePanel panel21;
        private QS2.Desktop.ControlManagment.BasePanel panelAusscheidung;
        private QS2.Desktop.ControlManagment.BasePanel panel18;
        private QS2.Desktop.ControlManagment.BasePanel panelErnährung;
        private QS2.Desktop.ControlManagment.BasePanel panel15;
        private QS2.Desktop.ControlManagment.BasePanel panelAnAuskleiden;
        private QS2.Desktop.ControlManagment.BasePanel panel12;
        private QS2.Desktop.ControlManagment.BasePanel panel9;
        private QS2.Desktop.ControlManagment.BasePanel panelMobilisation;
        private QS2.Desktop.ControlManagment.BasePanel panel6;
        private QS2.Desktop.ControlManagment.BasePanel panelVerständigung;
        private QS2.Desktop.ControlManagment.BasePanel panel3;
        private QS2.Desktop.ControlManagment.BasePanel panelOrientierung;
        private QS2.Desktop.ControlManagment.BasePanel panel1;
        private QS2.Desktop.ControlManagment.BaseCheckBox g2;
        private QS2.Desktop.ControlManagment.BaseLabel lblVerständigung;
        private QS2.Desktop.ControlManagment.BasePanel panel22;
        private QS2.Desktop.ControlManagment.BaseCheckBox g7;
        private QS2.Desktop.ControlManagment.BaseLabel lblAusscheidung;
        private QS2.Desktop.ControlManagment.BasePanel panel16;
        private QS2.Desktop.ControlManagment.BaseCheckBox g62;
        private QS2.Desktop.ControlManagment.BaseCheckBox g61;
        private QS2.Desktop.ControlManagment.BaseLabel lblErnährung;
        private QS2.Desktop.ControlManagment.BasePanel panel13;
        private QS2.Desktop.ControlManagment.BaseCheckBox g5;
        private QS2.Desktop.ControlManagment.BaseLabel lblAnAuskleiden;
        private QS2.Desktop.ControlManagment.BasePanel panel10;
        private QS2.Desktop.ControlManagment.BaseCheckBox g42;
        private QS2.Desktop.ControlManagment.BaseCheckBox g41;
        private QS2.Desktop.ControlManagment.BaseLabel lblKörperpflege;
        private QS2.Desktop.ControlManagment.BasePanel panel7;
        private QS2.Desktop.ControlManagment.BaseCheckBox g3;
        private QS2.Desktop.ControlManagment.BaseLabel lblMobilisation;
        private QS2.Desktop.ControlManagment.BasePanel panel4;
        private QS2.Desktop.ControlManagment.BaseCheckBox g1;
        private QS2.Desktop.ControlManagment.BaseLabel lblOrientierung;
        private QS2.Desktop.ControlManagment.BaseCheckBox v15;
        private QS2.Desktop.ControlManagment.BaseCheckBox v14;
        private QS2.Desktop.ControlManagment.BaseCheckBox v13;
        private QS2.Desktop.ControlManagment.BaseCheckBox v12;
        private QS2.Desktop.ControlManagment.BaseCheckBox v11;
        private QS2.Desktop.ControlManagment.BasePanel panelKörperpflege;
        private QS2.Desktop.ControlManagment.BaseCheckBox v42;
        private QS2.Desktop.ControlManagment.BaseCheckBox v41;
        private QS2.Desktop.ControlManagment.BaseCheckBox v35;
        private QS2.Desktop.ControlManagment.BaseCheckBox v34;
        private QS2.Desktop.ControlManagment.BaseCheckBox v32;
        private QS2.Desktop.ControlManagment.BaseCheckBox v31;
        private QS2.Desktop.ControlManagment.BaseCheckBox v25;
        private QS2.Desktop.ControlManagment.BaseCheckBox v24;
        private QS2.Desktop.ControlManagment.BaseCheckBox v22;
        private QS2.Desktop.ControlManagment.BaseCheckBox v21;
        private QS2.Desktop.ControlManagment.BaseCheckBox v75;
        private QS2.Desktop.ControlManagment.BaseCheckBox v74;
        private QS2.Desktop.ControlManagment.BaseCheckBox v77;
        private QS2.Desktop.ControlManagment.BaseCheckBox v76;
        private QS2.Desktop.ControlManagment.BaseCheckBox v73;
        private QS2.Desktop.ControlManagment.BaseCheckBox v72;
        private QS2.Desktop.ControlManagment.BaseCheckBox v71;
        private QS2.Desktop.ControlManagment.BaseCheckBox v66;
        private QS2.Desktop.ControlManagment.BaseCheckBox v63;
        private QS2.Desktop.ControlManagment.BaseCheckBox v62;
        private QS2.Desktop.ControlManagment.BaseCheckBox v61;
        private QS2.Desktop.ControlManagment.BaseCheckBox v52;
        private QS2.Desktop.ControlManagment.BaseCheckBox v51;
        private QS2.Desktop.ControlManagment.BaseCheckBox v45;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private QS2.Desktop.ControlManagment.BaseTextEditor k1;
        private QS2.Desktop.ControlManagment.BaseTextEditor k7;
        private QS2.Desktop.ControlManagment.BaseTextEditor k6;
        private QS2.Desktop.ControlManagment.BaseTextEditor k5;
        private QS2.Desktop.ControlManagment.BaseTextEditor k4;
        private QS2.Desktop.ControlManagment.BaseTextEditor k3;
        private QS2.Desktop.ControlManagment.BaseTextEditor k2;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpHilfsmittel;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtSonstiges;
        private QS2.Desktop.ControlManagment.BaseLabel lblSonstiges;
        private QS2.Desktop.ControlManagment.BaseTextEditorWin vDMTyp;
        private QS2.Desktop.ControlManagment.BaseTextEditorWin vDiaeten;
        private QS2.Desktop.ControlManagment.BaseTextEditor vHilfsm;
        private QS2.Desktop.ControlManagment.BaseTextEditor k71;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpAusdruck;
        private QS2.Desktop.ControlManagment.BaseCheckBox vPP;
        private QS2.Desktop.ControlManagment.BaseCheckBox vMedDat;
        private QS2.Desktop.ControlManagment.BaseCheckBox vMedika;
        private QS2.Desktop.ControlManagment.BaseCheckBox vTermine;
        private QS2.Desktop.ControlManagment.BaseCheckBox vabgesetzeMed;
        private QS2.Desktop.ControlManagment.BaseTextEditor vEinrichtungsID;
        private QS2.Desktop.ControlManagment.BaseCheckBox vHoer;
        private QS2.Desktop.ControlManagment.BaseCheckBox vSeh;
        private QS2.Desktop.ControlManagment.BaseCheckBox vUK;
        private QS2.Desktop.ControlManagment.BaseCheckBox vOK;
        private QS2.Desktop.ControlManagment.BaseLabel lblMitgegebeneHilfsmittel;
        private System.ComponentModel.IContainer components;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkInsArchiv;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Form zum Bearbeiten der Report Pflegebrief-Daten.
		/// </summary>
		//----------------------------------------------------------------------------
        public frmPrintPflegebegleitschreibenInfo()
		{
			InitializeComponent();
			RequiredFields();
            InitValues(System.IO.Path.Combine(PMDS.Global.ENV.pathConfig,  "frmPrintPflegebegleitschreibenInfo.config"));

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                this.cbETo.NotKrankenkasse = true;
                this.cbETo.RefreshList();
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert alle Felder mit Wert: g = Gruppe, k=Kommentar, v=Value
        /// Reichenfolge oben nach unten nach rechts Gruppenweise
        /// </summary>
        //----------------------------------------------------------------------------
        public NameValueCollection VALUES
        {
            get
            {
                NameValueCollection nv = new NameValueCollection();

                List<Control> list = new List<Control>();
                GetAllControls(this, ref list);

                foreach (Control c in list)
                {
                    if (c is UltraCheckEditor)
                    {
                        UltraCheckEditor e = (UltraCheckEditor)c;
                        nv.Add(e.Name, e.Checked ? "J" : "N");
                    }

                    if (c is UltraTextEditor)
                    {
                        UltraTextEditor e = (UltraTextEditor)c;
                        nv.Add(e.Name, e.Text.Trim());
                    }
                }
                return nv;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Rekursive Funktion zum ermitteln sämtlicher Controls in den Controls
        /// </summary>
        //----------------------------------------------------------------------------
        private void GetAllControls(Control root, ref List<Control> list)
        {
            foreach (Control c in root.Controls)
            {
                list.Add(c);
                GetAllControls(c, ref list);
            }
        }

        public List<PMDS.Print.CR.BerichtParameter>  GetBERICHTPARAMETER()
        {
            return base.BERICHTPARAMETER;
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dispose
		/// </summary>
		//----------------------------------------------------------------------------
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintPflegebegleitschreibenInfo));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.cbETo = new PMDS.GUI.BaseControls.EinrichtungsCombo();
            this.lblAnEinrichtung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpWichtigeInformationen = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.txtBemerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel22 = new QS2.Desktop.ControlManagment.BasePanel();
            this.g7 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblAusscheidung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panel16 = new QS2.Desktop.ControlManagment.BasePanel();
            this.vDiaeten = new QS2.Desktop.ControlManagment.BaseTextEditorWin();
            this.g62 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.g61 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblErnährung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panel13 = new QS2.Desktop.ControlManagment.BasePanel();
            this.g5 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblAnAuskleiden = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panel10 = new QS2.Desktop.ControlManagment.BasePanel();
            this.g42 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.g41 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblKörperpflege = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panel7 = new QS2.Desktop.ControlManagment.BasePanel();
            this.g3 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblMobilisation = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panel4 = new QS2.Desktop.ControlManagment.BasePanel();
            this.vEinrichtungsID = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.g1 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblOrientierung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panel1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.g2 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblVerständigung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panel21 = new QS2.Desktop.ControlManagment.BasePanel();
            this.k71 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.k7 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.panelAusscheidung = new QS2.Desktop.ControlManagment.BasePanel();
            this.v75 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v74 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v77 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v76 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v73 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v72 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v71 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panel18 = new QS2.Desktop.ControlManagment.BasePanel();
            this.k6 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.panelErnährung = new QS2.Desktop.ControlManagment.BasePanel();
            this.vDMTyp = new QS2.Desktop.ControlManagment.BaseTextEditorWin();
            this.v66 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v63 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v62 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v61 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panel15 = new QS2.Desktop.ControlManagment.BasePanel();
            this.k5 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.panelAnAuskleiden = new QS2.Desktop.ControlManagment.BasePanel();
            this.v52 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v51 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panel12 = new QS2.Desktop.ControlManagment.BasePanel();
            this.k4 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.panelKörperpflege = new QS2.Desktop.ControlManagment.BasePanel();
            this.v45 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v42 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v41 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panel9 = new QS2.Desktop.ControlManagment.BasePanel();
            this.k3 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.panelMobilisation = new QS2.Desktop.ControlManagment.BasePanel();
            this.v35 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v34 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v32 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v31 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panel6 = new QS2.Desktop.ControlManagment.BasePanel();
            this.k2 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.panelVerständigung = new QS2.Desktop.ControlManagment.BasePanel();
            this.v25 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v24 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v22 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v21 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panel3 = new QS2.Desktop.ControlManagment.BasePanel();
            this.k1 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelOrientierung = new QS2.Desktop.ControlManagment.BasePanel();
            this.v15 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v14 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v13 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v12 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v11 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.grpHilfsmittel = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.vHoer = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.vSeh = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.vUK = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.vOK = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblMitgegebeneHilfsmittel = new QS2.Desktop.ControlManagment.BaseLabel();
            this.vHilfsm = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtSonstiges = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblSonstiges = new QS2.Desktop.ControlManagment.BaseLabel();
            this.vMedDat = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.grpAusdruck = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.vabgesetzeMed = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.vTermine = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.vMedika = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.vPP = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.chkInsArchiv = new QS2.Desktop.ControlManagment.BaseCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cbETo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grpWichtigeInformationen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBemerkung)).BeginInit();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panel22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g7)).BeginInit();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g61)).BeginInit();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g5)).BeginInit();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g41)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vEinrichtungsID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g2)).BeginInit();
            this.panel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.k7)).BeginInit();
            this.panelAusscheidung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v71)).BeginInit();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k6)).BeginInit();
            this.panelErnährung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v61)).BeginInit();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k5)).BeginInit();
            this.panelAnAuskleiden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v51)).BeginInit();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k4)).BeginInit();
            this.panelKörperpflege.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v41)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k3)).BeginInit();
            this.panelMobilisation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v31)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k2)).BeginInit();
            this.panelVerständigung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v21)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k1)).BeginInit();
            this.panelOrientierung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v11)).BeginInit();
            this.grpHilfsmittel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vHoer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vSeh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vUK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vHilfsm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSonstiges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vMedDat)).BeginInit();
            this.grpAusdruck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vabgesetzeMed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vTermine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vMedika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInsArchiv)).BeginInit();
            this.SuspendLayout();
            // 
            // cbETo
            // 
            this.cbETo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbETo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbETo.Location = new System.Drawing.Point(96, 8);
            this.cbETo.Name = "cbETo";
            this.cbETo.NotKrankenkasse = true;
            this.cbETo.Size = new System.Drawing.Size(744, 21);
            this.cbETo.TabIndex = 0;
            this.cbETo.ValueChanged += new System.EventHandler(this.cbETo_ValueChanged);
            // 
            // lblAnEinrichtung
            // 
            this.lblAnEinrichtung.AutoSize = true;
            this.lblAnEinrichtung.Location = new System.Drawing.Point(8, 11);
            this.lblAnEinrichtung.Name = "lblAnEinrichtung";
            this.lblAnEinrichtung.Size = new System.Drawing.Size(81, 14);
            this.lblAnEinrichtung.TabIndex = 0;
            this.lblAnEinrichtung.Text = "An Einrichtung:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(703, 736);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(792, 736);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 2;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // grpWichtigeInformationen
            // 
            this.grpWichtigeInformationen.Controls.Add(this.txtBemerkung);
            this.grpWichtigeInformationen.Location = new System.Drawing.Point(24, 651);
            this.grpWichtigeInformationen.Name = "grpWichtigeInformationen";
            this.grpWichtigeInformationen.Size = new System.Drawing.Size(475, 118);
            this.grpWichtigeInformationen.TabIndex = 0;
            this.grpWichtigeInformationen.TabStop = false;
            this.grpWichtigeInformationen.Text = "Wichtige Informationen";
            // 
            // txtBemerkung
            // 
            this.txtBemerkung.AcceptsReturn = true;
            this.txtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBemerkung.Location = new System.Drawing.Point(3, 19);
            this.txtBemerkung.Multiline = true;
            this.txtBemerkung.Name = "txtBemerkung";
            this.txtBemerkung.Size = new System.Drawing.Size(466, 91);
            this.txtBemerkung.TabIndex = 0;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.46343F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.41608F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.1205F));
            this.tableLayoutPanelMain.Controls.Add(this.panel22, 0, 6);
            this.tableLayoutPanelMain.Controls.Add(this.panel16, 0, 5);
            this.tableLayoutPanelMain.Controls.Add(this.panel13, 0, 4);
            this.tableLayoutPanelMain.Controls.Add(this.panel10, 0, 3);
            this.tableLayoutPanelMain.Controls.Add(this.panel7, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.panel21, 2, 6);
            this.tableLayoutPanelMain.Controls.Add(this.panelAusscheidung, 1, 6);
            this.tableLayoutPanelMain.Controls.Add(this.panel18, 2, 5);
            this.tableLayoutPanelMain.Controls.Add(this.panelErnährung, 1, 5);
            this.tableLayoutPanelMain.Controls.Add(this.panel15, 2, 4);
            this.tableLayoutPanelMain.Controls.Add(this.panelAnAuskleiden, 1, 4);
            this.tableLayoutPanelMain.Controls.Add(this.panel12, 2, 3);
            this.tableLayoutPanelMain.Controls.Add(this.panelKörperpflege, 1, 3);
            this.tableLayoutPanelMain.Controls.Add(this.panel9, 2, 2);
            this.tableLayoutPanelMain.Controls.Add(this.panelMobilisation, 1, 2);
            this.tableLayoutPanelMain.Controls.Add(this.panel6, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.panelVerständigung, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelOrientierung, 1, 0);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(24, 35);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 7;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.81861F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.93387F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.13267F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.51824F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.33147F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.91583F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.3493F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(817, 490);
            this.tableLayoutPanelMain.TabIndex = 7;
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.Color.LightGray;
            this.panel22.Controls.Add(this.g7);
            this.panel22.Controls.Add(this.lblAusscheidung);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel22.Location = new System.Drawing.Point(1, 374);
            this.panel22.Margin = new System.Windows.Forms.Padding(0);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(231, 115);
            this.panel22.TabIndex = 18;
            // 
            // g7
            // 
            this.g7.Checked = true;
            this.g7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.g7.Location = new System.Drawing.Point(38, 23);
            this.g7.Name = "g7";
            this.g7.Size = new System.Drawing.Size(120, 20);
            this.g7.TabIndex = 0;
            this.g7.Text = "selbständig";
            // 
            // lblAusscheidung
            // 
            this.lblAusscheidung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAusscheidung.Location = new System.Drawing.Point(18, 4);
            this.lblAusscheidung.Name = "lblAusscheidung";
            this.lblAusscheidung.Size = new System.Drawing.Size(123, 23);
            this.lblAusscheidung.TabIndex = 0;
            this.lblAusscheidung.Text = "Ausscheidung";
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.LightGray;
            this.panel16.Controls.Add(this.vDiaeten);
            this.panel16.Controls.Add(this.g62);
            this.panel16.Controls.Add(this.g61);
            this.panel16.Controls.Add(this.lblErnährung);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(1, 306);
            this.panel16.Margin = new System.Windows.Forms.Padding(0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(231, 67);
            this.panel16.TabIndex = 15;
            // 
            // vDiaeten
            // 
            this.vDiaeten.BackColor = System.Drawing.SystemColors.Control;
            this.vDiaeten.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vDiaeten.Location = new System.Drawing.Point(93, 4);
            this.vDiaeten.Multiline = true;
            this.vDiaeten.Name = "vDiaeten";
            this.vDiaeten.Size = new System.Drawing.Size(122, 15);
            this.vDiaeten.TabIndex = 9;
            this.vDiaeten.Text = "Diäten";
            this.vDiaeten.Visible = false;
            // 
            // g62
            // 
            this.g62.Location = new System.Drawing.Point(38, 40);
            this.g62.Name = "g62";
            this.g62.Size = new System.Drawing.Size(120, 20);
            this.g62.TabIndex = 1;
            this.g62.Text = "Normalkost";
            this.g62.CheckedChanged += new System.EventHandler(this.g62_CheckedChanged);
            // 
            // g61
            // 
            this.g61.Checked = true;
            this.g61.CheckState = System.Windows.Forms.CheckState.Checked;
            this.g61.Location = new System.Drawing.Point(38, 23);
            this.g61.Name = "g61";
            this.g61.Size = new System.Drawing.Size(120, 20);
            this.g61.TabIndex = 0;
            this.g61.Text = "selbständig";
            // 
            // lblErnährung
            // 
            this.lblErnährung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErnährung.Location = new System.Drawing.Point(18, 4);
            this.lblErnährung.Name = "lblErnährung";
            this.lblErnährung.Size = new System.Drawing.Size(123, 23);
            this.lblErnährung.TabIndex = 0;
            this.lblErnährung.Text = "Ernährung";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.LightGray;
            this.panel13.Controls.Add(this.g5);
            this.panel13.Controls.Add(this.lblAnAuskleiden);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(1, 251);
            this.panel13.Margin = new System.Windows.Forms.Padding(0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(231, 54);
            this.panel13.TabIndex = 12;
            // 
            // g5
            // 
            this.g5.Location = new System.Drawing.Point(38, 23);
            this.g5.Name = "g5";
            this.g5.Size = new System.Drawing.Size(120, 20);
            this.g5.TabIndex = 0;
            this.g5.Text = "selbständig";
            // 
            // lblAnAuskleiden
            // 
            this.lblAnAuskleiden.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnAuskleiden.Location = new System.Drawing.Point(18, 4);
            this.lblAnAuskleiden.Name = "lblAnAuskleiden";
            this.lblAnAuskleiden.Size = new System.Drawing.Size(123, 23);
            this.lblAnAuskleiden.TabIndex = 0;
            this.lblAnAuskleiden.Text = "An-/Auskleiden";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.LightGray;
            this.panel10.Controls.Add(this.g42);
            this.panel10.Controls.Add(this.g41);
            this.panel10.Controls.Add(this.lblKörperpflege);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(1, 185);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(231, 65);
            this.panel10.TabIndex = 9;
            // 
            // g42
            // 
            this.g42.Location = new System.Drawing.Point(38, 40);
            this.g42.Name = "g42";
            this.g42.Size = new System.Drawing.Size(120, 20);
            this.g42.TabIndex = 1;
            this.g42.Text = "keine Hautschäden";
            // 
            // g41
            // 
            this.g41.Checked = true;
            this.g41.CheckState = System.Windows.Forms.CheckState.Checked;
            this.g41.Location = new System.Drawing.Point(38, 23);
            this.g41.Name = "g41";
            this.g41.Size = new System.Drawing.Size(120, 20);
            this.g41.TabIndex = 0;
            this.g41.Text = "selbständig";
            // 
            // lblKörperpflege
            // 
            this.lblKörperpflege.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKörperpflege.Location = new System.Drawing.Point(18, 4);
            this.lblKörperpflege.Name = "lblKörperpflege";
            this.lblKörperpflege.Size = new System.Drawing.Size(123, 23);
            this.lblKörperpflege.TabIndex = 0;
            this.lblKörperpflege.Text = "Körperpflege";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.LightGray;
            this.panel7.Controls.Add(this.g3);
            this.panel7.Controls.Add(this.lblMobilisation);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(1, 131);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(231, 53);
            this.panel7.TabIndex = 6;
            // 
            // g3
            // 
            this.g3.Checked = true;
            this.g3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.g3.Location = new System.Drawing.Point(38, 23);
            this.g3.Name = "g3";
            this.g3.Size = new System.Drawing.Size(120, 20);
            this.g3.TabIndex = 0;
            this.g3.Text = "selbständig";
            // 
            // lblMobilisation
            // 
            this.lblMobilisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobilisation.Location = new System.Drawing.Point(18, 4);
            this.lblMobilisation.Name = "lblMobilisation";
            this.lblMobilisation.Size = new System.Drawing.Size(123, 23);
            this.lblMobilisation.TabIndex = 0;
            this.lblMobilisation.Text = "Mobilisation";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Controls.Add(this.vEinrichtungsID);
            this.panel4.Controls.Add(this.g1);
            this.panel4.Controls.Add(this.lblOrientierung);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(231, 76);
            this.panel4.TabIndex = 0;
            // 
            // vEinrichtungsID
            // 
            this.vEinrichtungsID.Location = new System.Drawing.Point(58, 45);
            this.vEinrichtungsID.Name = "vEinrichtungsID";
            this.vEinrichtungsID.Size = new System.Drawing.Size(100, 21);
            this.vEinrichtungsID.TabIndex = 1;
            this.vEinrichtungsID.Text = "00000000-0000-0000-0000-000000000000";
            this.vEinrichtungsID.Visible = false;
            // 
            // g1
            // 
            this.g1.Checked = true;
            this.g1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.g1.Location = new System.Drawing.Point(38, 23);
            this.g1.Name = "g1";
            this.g1.Size = new System.Drawing.Size(120, 20);
            this.g1.TabIndex = 0;
            this.g1.Text = "orientiert";
            this.g1.AfterCheckStateChanged += new Infragistics.Win.ToggleEditorBase.AfterCheckStateChangedHandler(this.g1_AfterCheckStateChanged);
            // 
            // lblOrientierung
            // 
            this.lblOrientierung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrientierung.Location = new System.Drawing.Point(18, 4);
            this.lblOrientierung.Name = "lblOrientierung";
            this.lblOrientierung.Size = new System.Drawing.Size(123, 23);
            this.lblOrientierung.TabIndex = 0;
            this.lblOrientierung.Text = "Orientierung";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.g2);
            this.panel1.Controls.Add(this.lblVerständigung);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 78);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 52);
            this.panel1.TabIndex = 3;
            // 
            // g2
            // 
            this.g2.Checked = true;
            this.g2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.g2.Location = new System.Drawing.Point(38, 23);
            this.g2.Name = "g2";
            this.g2.Size = new System.Drawing.Size(120, 20);
            this.g2.TabIndex = 0;
            this.g2.Text = "nicht beeinträchtigt";
            this.g2.AfterCheckStateChanged += new Infragistics.Win.ToggleEditorBase.AfterCheckStateChangedHandler(this.g2_AfterCheckStateChanged);
            // 
            // lblVerständigung
            // 
            this.lblVerständigung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerständigung.Location = new System.Drawing.Point(18, 4);
            this.lblVerständigung.Name = "lblVerständigung";
            this.lblVerständigung.Size = new System.Drawing.Size(123, 23);
            this.lblVerständigung.TabIndex = 0;
            this.lblVerständigung.Text = "Verständigung";
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.k71);
            this.panel21.Controls.Add(this.k7);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel21.Location = new System.Drawing.Point(578, 374);
            this.panel21.Margin = new System.Windows.Forms.Padding(0);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(238, 115);
            this.panel21.TabIndex = 20;
            // 
            // k71
            // 
            this.k71.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k71.Location = new System.Drawing.Point(0, 54);
            this.k71.Multiline = true;
            this.k71.Name = "k71";
            this.k71.Size = new System.Drawing.Size(238, 61);
            this.k71.TabIndex = 1;
            // 
            // k7
            // 
            this.k7.Dock = System.Windows.Forms.DockStyle.Top;
            this.k7.Location = new System.Drawing.Point(0, 0);
            this.k7.Multiline = true;
            this.k7.Name = "k7";
            this.k7.Size = new System.Drawing.Size(238, 54);
            this.k7.TabIndex = 0;
            // 
            // panelAusscheidung
            // 
            this.panelAusscheidung.Controls.Add(this.v75);
            this.panelAusscheidung.Controls.Add(this.v74);
            this.panelAusscheidung.Controls.Add(this.v77);
            this.panelAusscheidung.Controls.Add(this.v76);
            this.panelAusscheidung.Controls.Add(this.v73);
            this.panelAusscheidung.Controls.Add(this.v72);
            this.panelAusscheidung.Controls.Add(this.v71);
            this.panelAusscheidung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAusscheidung.Location = new System.Drawing.Point(233, 374);
            this.panelAusscheidung.Margin = new System.Windows.Forms.Padding(0);
            this.panelAusscheidung.Name = "panelAusscheidung";
            this.panelAusscheidung.Size = new System.Drawing.Size(344, 115);
            this.panelAusscheidung.TabIndex = 19;
            // 
            // v75
            // 
            this.v75.Location = new System.Drawing.Point(3, 87);
            this.v75.Name = "v75";
            this.v75.Size = new System.Drawing.Size(162, 20);
            this.v75.TabIndex = 4;
            this.v75.Text = "Harninkontinenz nur Nachts";
            // 
            // v74
            // 
            this.v74.Location = new System.Drawing.Point(3, 66);
            this.v74.Name = "v74";
            this.v74.Size = new System.Drawing.Size(120, 20);
            this.v74.TabIndex = 3;
            this.v74.Text = "Harninkontinenz";
            // 
            // v77
            // 
            this.v77.Location = new System.Drawing.Point(159, 41);
            this.v77.Name = "v77";
            this.v77.Size = new System.Drawing.Size(120, 40);
            this.v77.TabIndex = 6;
            this.v77.Text = "Stuhlinkontinenz";
            // 
            // v76
            // 
            this.v76.Location = new System.Drawing.Point(159, 3);
            this.v76.Name = "v76";
            this.v76.Size = new System.Drawing.Size(152, 37);
            this.v76.TabIndex = 5;
            this.v76.Text = "Katheter/Sonden/Stomata";
            // 
            // v73
            // 
            this.v73.Location = new System.Drawing.Point(3, 46);
            this.v73.Name = "v73";
            this.v73.Size = new System.Drawing.Size(120, 20);
            this.v73.TabIndex = 2;
            this.v73.Text = "Toilettentraining";
            // 
            // v72
            // 
            this.v72.Location = new System.Drawing.Point(3, 25);
            this.v72.Name = "v72";
            this.v72.Size = new System.Drawing.Size(120, 20);
            this.v72.TabIndex = 1;
            this.v72.Text = "regelm. Leibstuhl";
            // 
            // v71
            // 
            this.v71.Location = new System.Drawing.Point(3, 4);
            this.v71.Name = "v71";
            this.v71.Size = new System.Drawing.Size(120, 20);
            this.v71.TabIndex = 0;
            this.v71.Text = "Begl. zum WC";
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.k6);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel18.Location = new System.Drawing.Point(578, 306);
            this.panel18.Margin = new System.Windows.Forms.Padding(0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(238, 67);
            this.panel18.TabIndex = 17;
            // 
            // k6
            // 
            this.k6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k6.Location = new System.Drawing.Point(0, 0);
            this.k6.Margin = new System.Windows.Forms.Padding(0);
            this.k6.Multiline = true;
            this.k6.Name = "k6";
            this.k6.Size = new System.Drawing.Size(238, 67);
            this.k6.TabIndex = 0;
            // 
            // panelErnährung
            // 
            this.panelErnährung.Controls.Add(this.vDMTyp);
            this.panelErnährung.Controls.Add(this.v66);
            this.panelErnährung.Controls.Add(this.v63);
            this.panelErnährung.Controls.Add(this.v62);
            this.panelErnährung.Controls.Add(this.v61);
            this.panelErnährung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelErnährung.Location = new System.Drawing.Point(233, 306);
            this.panelErnährung.Margin = new System.Windows.Forms.Padding(0);
            this.panelErnährung.Name = "panelErnährung";
            this.panelErnährung.Size = new System.Drawing.Size(344, 67);
            this.panelErnährung.TabIndex = 16;
            // 
            // vDMTyp
            // 
            this.vDMTyp.BackColor = System.Drawing.SystemColors.Control;
            this.vDMTyp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vDMTyp.Location = new System.Drawing.Point(67, 31);
            this.vDMTyp.Name = "vDMTyp";
            this.vDMTyp.Size = new System.Drawing.Size(80, 13);
            this.vDMTyp.TabIndex = 8;
            this.vDMTyp.Text = "Diabetestyp";
            // 
            // v66
            // 
            this.v66.Location = new System.Drawing.Point(159, 28);
            this.v66.Name = "v66";
            this.v66.Size = new System.Drawing.Size(151, 20);
            this.v66.TabIndex = 5;
            this.v66.Text = "Flüssigkeitskontrolle";
            // 
            // v63
            // 
            this.v63.Location = new System.Drawing.Point(3, 4);
            this.v63.Name = "v63";
            this.v63.Size = new System.Drawing.Size(120, 20);
            this.v63.TabIndex = 2;
            this.v63.Text = "benötigt Hilfe";
            // 
            // v62
            // 
            this.v62.Location = new System.Drawing.Point(3, 28);
            this.v62.Name = "v62";
            this.v62.Size = new System.Drawing.Size(120, 20);
            this.v62.TabIndex = 1;
            this.v62.Text = "Diabetes";
            this.v62.CheckedValueChanged += new System.EventHandler(this.v62_CheckedValueChanged);
            // 
            // v61
            // 
            this.v61.Location = new System.Drawing.Point(159, 3);
            this.v61.Name = "v61";
            this.v61.Size = new System.Drawing.Size(120, 20);
            this.v61.TabIndex = 0;
            this.v61.Text = "Diät";
            this.v61.CheckedChanged += new System.EventHandler(this.v61_CheckedChanged);
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.k5);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(578, 251);
            this.panel15.Margin = new System.Windows.Forms.Padding(0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(238, 54);
            this.panel15.TabIndex = 14;
            // 
            // k5
            // 
            this.k5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k5.Location = new System.Drawing.Point(0, 0);
            this.k5.Multiline = true;
            this.k5.Name = "k5";
            this.k5.Size = new System.Drawing.Size(238, 54);
            this.k5.TabIndex = 0;
            // 
            // panelAnAuskleiden
            // 
            this.panelAnAuskleiden.Controls.Add(this.v52);
            this.panelAnAuskleiden.Controls.Add(this.v51);
            this.panelAnAuskleiden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnAuskleiden.Location = new System.Drawing.Point(233, 251);
            this.panelAnAuskleiden.Margin = new System.Windows.Forms.Padding(0);
            this.panelAnAuskleiden.Name = "panelAnAuskleiden";
            this.panelAnAuskleiden.Size = new System.Drawing.Size(344, 54);
            this.panelAnAuskleiden.TabIndex = 13;
            // 
            // v52
            // 
            this.v52.Location = new System.Drawing.Point(3, 23);
            this.v52.Name = "v52";
            this.v52.Size = new System.Drawing.Size(206, 20);
            this.v52.TabIndex = 1;
            this.v52.Text = "vollständig übernehmen";
            // 
            // v51
            // 
            this.v51.Location = new System.Drawing.Point(3, 4);
            this.v51.Name = "v51";
            this.v51.Size = new System.Drawing.Size(120, 20);
            this.v51.TabIndex = 0;
            this.v51.Text = "benötigt Hilfe";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.k4);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(578, 185);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(238, 65);
            this.panel12.TabIndex = 11;
            // 
            // k4
            // 
            this.k4.AcceptsReturn = true;
            this.k4.AlwaysInEditMode = true;
            this.k4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k4.Location = new System.Drawing.Point(0, 0);
            this.k4.Multiline = true;
            this.k4.Name = "k4";
            this.k4.Size = new System.Drawing.Size(238, 65);
            this.k4.TabIndex = 0;
            // 
            // panelKörperpflege
            // 
            this.panelKörperpflege.Controls.Add(this.v45);
            this.panelKörperpflege.Controls.Add(this.v42);
            this.panelKörperpflege.Controls.Add(this.v41);
            this.panelKörperpflege.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKörperpflege.Location = new System.Drawing.Point(233, 185);
            this.panelKörperpflege.Margin = new System.Windows.Forms.Padding(0);
            this.panelKörperpflege.Name = "panelKörperpflege";
            this.panelKörperpflege.Size = new System.Drawing.Size(344, 65);
            this.panelKörperpflege.TabIndex = 10;
            // 
            // v45
            // 
            this.v45.Location = new System.Drawing.Point(159, 2);
            this.v45.Name = "v45";
            this.v45.Size = new System.Drawing.Size(120, 23);
            this.v45.TabIndex = 4;
            this.v45.Text = "Hautschäden";
            this.v45.CheckedChanged += new System.EventHandler(this.v45_CheckedChanged);
            // 
            // v42
            // 
            this.v42.Location = new System.Drawing.Point(3, 25);
            this.v42.Name = "v42";
            this.v42.Size = new System.Drawing.Size(120, 20);
            this.v42.TabIndex = 1;
            this.v42.Text = "Ganzwäsche";
            // 
            // v41
            // 
            this.v41.Location = new System.Drawing.Point(3, 4);
            this.v41.Name = "v41";
            this.v41.Size = new System.Drawing.Size(120, 20);
            this.v41.TabIndex = 0;
            this.v41.Text = "benötigt Hilfe";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.k3);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(578, 131);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(238, 53);
            this.panel9.TabIndex = 8;
            // 
            // k3
            // 
            this.k3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k3.Location = new System.Drawing.Point(0, 0);
            this.k3.Multiline = true;
            this.k3.Name = "k3";
            this.k3.Size = new System.Drawing.Size(238, 53);
            this.k3.TabIndex = 0;
            // 
            // panelMobilisation
            // 
            this.panelMobilisation.Controls.Add(this.v35);
            this.panelMobilisation.Controls.Add(this.v34);
            this.panelMobilisation.Controls.Add(this.v32);
            this.panelMobilisation.Controls.Add(this.v31);
            this.panelMobilisation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMobilisation.Location = new System.Drawing.Point(233, 131);
            this.panelMobilisation.Margin = new System.Windows.Forms.Padding(0);
            this.panelMobilisation.Name = "panelMobilisation";
            this.panelMobilisation.Size = new System.Drawing.Size(344, 53);
            this.panelMobilisation.TabIndex = 7;
            // 
            // v35
            // 
            this.v35.Location = new System.Drawing.Point(159, 24);
            this.v35.Name = "v35";
            this.v35.Size = new System.Drawing.Size(120, 20);
            this.v35.TabIndex = 4;
            this.v35.Text = "Lähmungen wo?";
            // 
            // v34
            // 
            this.v34.Location = new System.Drawing.Point(159, 3);
            this.v34.Name = "v34";
            this.v34.Size = new System.Drawing.Size(120, 20);
            this.v34.TabIndex = 3;
            this.v34.Text = "Kontrakturen wo?";
            this.v34.CheckedChanged += new System.EventHandler(this.v34_CheckedChanged);
            // 
            // v32
            // 
            this.v32.Location = new System.Drawing.Point(3, 25);
            this.v32.Name = "v32";
            this.v32.Size = new System.Drawing.Size(120, 20);
            this.v32.TabIndex = 1;
            this.v32.Text = "bettlägrig";
            // 
            // v31
            // 
            this.v31.Location = new System.Drawing.Point(3, 4);
            this.v31.Name = "v31";
            this.v31.Size = new System.Drawing.Size(120, 20);
            this.v31.TabIndex = 0;
            this.v31.Text = "benötigt Hilfe";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.k2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(578, 78);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(238, 52);
            this.panel6.TabIndex = 5;
            // 
            // k2
            // 
            this.k2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k2.Location = new System.Drawing.Point(0, 0);
            this.k2.Multiline = true;
            this.k2.Name = "k2";
            this.k2.Size = new System.Drawing.Size(238, 52);
            this.k2.TabIndex = 0;
            // 
            // panelVerständigung
            // 
            this.panelVerständigung.Controls.Add(this.v25);
            this.panelVerständigung.Controls.Add(this.v24);
            this.panelVerständigung.Controls.Add(this.v22);
            this.panelVerständigung.Controls.Add(this.v21);
            this.panelVerständigung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVerständigung.Location = new System.Drawing.Point(233, 78);
            this.panelVerständigung.Margin = new System.Windows.Forms.Padding(0);
            this.panelVerständigung.Name = "panelVerständigung";
            this.panelVerständigung.Size = new System.Drawing.Size(344, 52);
            this.panelVerständigung.TabIndex = 4;
            // 
            // v25
            // 
            this.v25.Location = new System.Drawing.Point(159, 24);
            this.v25.Name = "v25";
            this.v25.Size = new System.Drawing.Size(141, 20);
            this.v25.TabIndex = 4;
            this.v25.Text = "geringes Sehvermögen";
            // 
            // v24
            // 
            this.v24.Location = new System.Drawing.Point(159, 3);
            this.v24.Name = "v24";
            this.v24.Size = new System.Drawing.Size(120, 20);
            this.v24.TabIndex = 3;
            this.v24.Text = "Aphasie";
            this.v24.CheckedChanged += new System.EventHandler(this.v21_CheckedChanged);
            // 
            // v22
            // 
            this.v22.Location = new System.Drawing.Point(3, 25);
            this.v22.Name = "v22";
            this.v22.Size = new System.Drawing.Size(120, 20);
            this.v22.TabIndex = 1;
            this.v22.Text = "taub";
            this.v22.CheckedChanged += new System.EventHandler(this.v21_CheckedChanged);
            // 
            // v21
            // 
            this.v21.Location = new System.Drawing.Point(3, 4);
            this.v21.Name = "v21";
            this.v21.Size = new System.Drawing.Size(120, 20);
            this.v21.TabIndex = 0;
            this.v21.Text = "schwerhörig";
            this.v21.CheckedChanged += new System.EventHandler(this.v21_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.k1);
            this.panel3.Controls.Add(this.ultraLabel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(578, 1);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(238, 76);
            this.panel3.TabIndex = 2;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // k1
            // 
            this.k1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k1.Location = new System.Drawing.Point(0, 22);
            this.k1.Multiline = true;
            this.k1.Name = "k1";
            this.k1.Size = new System.Drawing.Size(238, 54);
            this.k1.TabIndex = 0;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(238, 22);
            this.ultraLabel1.TabIndex = 1;
            this.ultraLabel1.Text = "Kommentar";
            // 
            // panelOrientierung
            // 
            this.panelOrientierung.Controls.Add(this.v15);
            this.panelOrientierung.Controls.Add(this.v14);
            this.panelOrientierung.Controls.Add(this.v13);
            this.panelOrientierung.Controls.Add(this.v12);
            this.panelOrientierung.Controls.Add(this.v11);
            this.panelOrientierung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOrientierung.Location = new System.Drawing.Point(233, 1);
            this.panelOrientierung.Margin = new System.Windows.Forms.Padding(0);
            this.panelOrientierung.Name = "panelOrientierung";
            this.panelOrientierung.Size = new System.Drawing.Size(344, 76);
            this.panelOrientierung.TabIndex = 1;
            // 
            // v15
            // 
            this.v15.Location = new System.Drawing.Point(159, 24);
            this.v15.Name = "v15";
            this.v15.Size = new System.Drawing.Size(120, 20);
            this.v15.TabIndex = 3;
            this.v15.Text = "z. Pers. desor.";
            this.v15.CheckStateChanged += new System.EventHandler(this.v11_CheckStateChanged);
            // 
            // v14
            // 
            this.v14.Location = new System.Drawing.Point(159, 3);
            this.v14.Name = "v14";
            this.v14.Size = new System.Drawing.Size(120, 20);
            this.v14.TabIndex = 1;
            this.v14.Text = "situativ desor.";
            this.v14.CheckStateChanged += new System.EventHandler(this.v11_CheckStateChanged);
            // 
            // v13
            // 
            this.v13.Location = new System.Drawing.Point(3, 46);
            this.v13.Name = "v13";
            this.v13.Size = new System.Drawing.Size(120, 20);
            this.v13.TabIndex = 4;
            this.v13.Text = "Seitenteile";
            // 
            // v12
            // 
            this.v12.Location = new System.Drawing.Point(3, 25);
            this.v12.Name = "v12";
            this.v12.Size = new System.Drawing.Size(120, 20);
            this.v12.TabIndex = 2;
            this.v12.Text = "zeitl. desor.";
            this.v12.CheckStateChanged += new System.EventHandler(this.v11_CheckStateChanged);
            // 
            // v11
            // 
            this.v11.Location = new System.Drawing.Point(3, 4);
            this.v11.Name = "v11";
            this.v11.Size = new System.Drawing.Size(120, 20);
            this.v11.TabIndex = 0;
            this.v11.Text = "örtlich desor.";
            this.v11.CheckStateChanged += new System.EventHandler(this.v11_CheckStateChanged);
            // 
            // grpHilfsmittel
            // 
            this.grpHilfsmittel.Controls.Add(this.vHoer);
            this.grpHilfsmittel.Controls.Add(this.vSeh);
            this.grpHilfsmittel.Controls.Add(this.vUK);
            this.grpHilfsmittel.Controls.Add(this.vOK);
            this.grpHilfsmittel.Controls.Add(this.lblMitgegebeneHilfsmittel);
            this.grpHilfsmittel.Controls.Add(this.vHilfsm);
            this.grpHilfsmittel.Location = new System.Drawing.Point(24, 531);
            this.grpHilfsmittel.Name = "grpHilfsmittel";
            this.grpHilfsmittel.Size = new System.Drawing.Size(376, 114);
            this.grpHilfsmittel.TabIndex = 1;
            this.grpHilfsmittel.TabStop = false;
            this.grpHilfsmittel.Text = "Hilfsmittel";
            // 
            // vHoer
            // 
            this.vHoer.Location = new System.Drawing.Point(278, 80);
            this.vHoer.Name = "vHoer";
            this.vHoer.Size = new System.Drawing.Size(92, 20);
            this.vHoer.TabIndex = 18;
            this.vHoer.Text = "Hörgerät";
            // 
            // vSeh
            // 
            this.vSeh.Location = new System.Drawing.Point(190, 80);
            this.vSeh.Name = "vSeh";
            this.vSeh.Size = new System.Drawing.Size(81, 20);
            this.vSeh.TabIndex = 17;
            this.vSeh.Text = "Sehbehelf";
            // 
            // vUK
            // 
            this.vUK.Location = new System.Drawing.Point(96, 80);
            this.vUK.Name = "vUK";
            this.vUK.Size = new System.Drawing.Size(120, 20);
            this.vUK.TabIndex = 16;
            this.vUK.Text = "UK Prothese";
            // 
            // vOK
            // 
            this.vOK.Location = new System.Drawing.Point(4, 80);
            this.vOK.Name = "vOK";
            this.vOK.Size = new System.Drawing.Size(120, 20);
            this.vOK.TabIndex = 15;
            this.vOK.Text = "OK Prothese";
            // 
            // lblMitgegebeneHilfsmittel
            // 
            this.lblMitgegebeneHilfsmittel.AutoSize = true;
            this.lblMitgegebeneHilfsmittel.Location = new System.Drawing.Point(2, 63);
            this.lblMitgegebeneHilfsmittel.Name = "lblMitgegebeneHilfsmittel";
            this.lblMitgegebeneHilfsmittel.Size = new System.Drawing.Size(119, 14);
            this.lblMitgegebeneHilfsmittel.TabIndex = 8;
            this.lblMitgegebeneHilfsmittel.Text = "mitgegebene Hilfsmitel";
            // 
            // vHilfsm
            // 
            this.vHilfsm.AcceptsReturn = true;
            this.vHilfsm.AcceptsTab = true;
            this.vHilfsm.AlwaysInEditMode = true;
            this.vHilfsm.Location = new System.Drawing.Point(3, 16);
            this.vHilfsm.Margin = new System.Windows.Forms.Padding(0);
            this.vHilfsm.Multiline = true;
            this.vHilfsm.Name = "vHilfsm";
            this.vHilfsm.Size = new System.Drawing.Size(367, 44);
            this.vHilfsm.TabIndex = 1;
            this.vHilfsm.ValueChanged += new System.EventHandler(this.vHilfsm_ValueChanged);
            // 
            // txtSonstiges
            // 
            this.txtSonstiges.AcceptsReturn = true;
            this.txtSonstiges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSonstiges.Location = new System.Drawing.Point(645, 614);
            this.txtSonstiges.Multiline = true;
            this.txtSonstiges.Name = "txtSonstiges";
            this.txtSonstiges.Size = new System.Drawing.Size(169, 85);
            this.txtSonstiges.TabIndex = 7;
            this.txtSonstiges.Visible = false;
            // 
            // lblSonstiges
            // 
            this.lblSonstiges.AutoSize = true;
            this.lblSonstiges.Location = new System.Drawing.Point(587, 614);
            this.lblSonstiges.Name = "lblSonstiges";
            this.lblSonstiges.Size = new System.Drawing.Size(52, 14);
            this.lblSonstiges.TabIndex = 6;
            this.lblSonstiges.Text = "sonstiges";
            this.lblSonstiges.Visible = false;
            // 
            // vMedDat
            // 
            this.vMedDat.Checked = true;
            this.vMedDat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vMedDat.Location = new System.Drawing.Point(6, 19);
            this.vMedDat.Name = "vMedDat";
            this.vMedDat.Size = new System.Drawing.Size(120, 20);
            this.vMedDat.TabIndex = 10;
            this.vMedDat.Text = "Medizinische Daten";
            // 
            // grpAusdruck
            // 
            this.grpAusdruck.Controls.Add(this.vabgesetzeMed);
            this.grpAusdruck.Controls.Add(this.vTermine);
            this.grpAusdruck.Controls.Add(this.vMedika);
            this.grpAusdruck.Controls.Add(this.vPP);
            this.grpAusdruck.Controls.Add(this.vMedDat);
            this.grpAusdruck.Location = new System.Drawing.Point(409, 531);
            this.grpAusdruck.Name = "grpAusdruck";
            this.grpAusdruck.Size = new System.Drawing.Size(354, 66);
            this.grpAusdruck.TabIndex = 2;
            this.grpAusdruck.TabStop = false;
            this.grpAusdruck.Text = "AUSDRUCK";
            // 
            // vabgesetzeMed
            // 
            this.vabgesetzeMed.Location = new System.Drawing.Point(128, 40);
            this.vabgesetzeMed.Name = "vabgesetzeMed";
            this.vabgesetzeMed.Size = new System.Drawing.Size(153, 20);
            this.vabgesetzeMed.TabIndex = 14;
            this.vabgesetzeMed.Text = "Abgesetzte Medikation";
            // 
            // vTermine
            // 
            this.vTermine.Checked = true;
            this.vTermine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vTermine.Location = new System.Drawing.Point(266, 19);
            this.vTermine.Name = "vTermine";
            this.vTermine.Size = new System.Drawing.Size(86, 20);
            this.vTermine.TabIndex = 13;
            this.vTermine.Text = "Termine";
            // 
            // vMedika
            // 
            this.vMedika.Checked = true;
            this.vMedika.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vMedika.Location = new System.Drawing.Point(128, 19);
            this.vMedika.Name = "vMedika";
            this.vMedika.Size = new System.Drawing.Size(153, 20);
            this.vMedika.TabIndex = 12;
            this.vMedika.Text = "Aktuelle Medikation";
            // 
            // vPP
            // 
            this.vPP.Checked = true;
            this.vPP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vPP.Location = new System.Drawing.Point(6, 40);
            this.vPP.Name = "vPP";
            this.vPP.Size = new System.Drawing.Size(120, 20);
            this.vPP.TabIndex = 11;
            this.vPP.Text = "Pflegeplanung";
            // 
            // chkInsArchiv
            // 
            this.chkInsArchiv.Location = new System.Drawing.Point(537, 742);
            this.chkInsArchiv.Name = "chkInsArchiv";
            this.chkInsArchiv.Size = new System.Drawing.Size(153, 20);
            this.chkInsArchiv.TabIndex = 15;
            this.chkInsArchiv.Text = "Ins Archiv ablegen";
            this.chkInsArchiv.CheckedChanged += new System.EventHandler(this.chkInsArchiv_CheckedChanged);
            // 
            // frmPrintPflegebegleitschreibenInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(860, 776);
            this.Controls.Add(this.chkInsArchiv);
            this.Controls.Add(this.grpAusdruck);
            this.Controls.Add(this.lblSonstiges);
            this.Controls.Add(this.txtSonstiges);
            this.Controls.Add(this.grpWichtigeInformationen);
            this.Controls.Add(this.grpHilfsmittel);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbETo);
            this.Controls.Add(this.lblAnEinrichtung);
            this.KeyPreview = true;
            this.Name = "frmPrintPflegebegleitschreibenInfo";
            this.Text = "Pflegebegleitschreiben Informationen ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.FrmPrintPflegebegleitschreibenInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbETo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grpWichtigeInformationen.ResumeLayout(false);
            this.grpWichtigeInformationen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBemerkung)).EndInit();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g7)).EndInit();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g61)).EndInit();
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g5)).EndInit();
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g41)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g3)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vEinrichtungsID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g2)).EndInit();
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.k7)).EndInit();
            this.panelAusscheidung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v71)).EndInit();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k6)).EndInit();
            this.panelErnährung.ResumeLayout(false);
            this.panelErnährung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v61)).EndInit();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k5)).EndInit();
            this.panelAnAuskleiden.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v51)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k4)).EndInit();
            this.panelKörperpflege.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v41)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k3)).EndInit();
            this.panelMobilisation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v31)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k2)).EndInit();
            this.panelVerständigung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v21)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k1)).EndInit();
            this.panelOrientierung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v11)).EndInit();
            this.grpHilfsmittel.ResumeLayout(false);
            this.grpHilfsmittel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vHoer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vSeh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vUK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vHilfsm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSonstiges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vMedDat)).EndInit();
            this.grpAusdruck.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vabgesetzeMed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vTermine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vMedika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInsArchiv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion




		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !_canClose;
		}

		protected void RequiredFields()
		{
            GuiUtil.ValidateRequired(cbETo);
		}

		private bool ValidateFields()
		{
            bool bError = false;
            //bool bInfo = true;
            //GuiUtil.ValidateField(cbETo, (cbETo.Value != null),
            //ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            if (this.cbETo.Value == null)
            {
                this.errorProvider1.SetError(this.cbETo, "Error");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("An Einrichtung: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                return false;
            }

            return true;		
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (!ValidateFields())
				return;

            _canClose = true;
		}

        public bool GetReceiverHasELGAOID()
        {
            return ReceiverELGA;
        }

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			_canClose = true;
		}

		public Guid Einrichtung
		{
			get	{	return (Guid)cbETo.Value;	}
		}

		public string Bemerkung
		{
			get	{	return txtBemerkung.Text;	}
		}

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void v82_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void v62_CheckedValueChanged(object sender, EventArgs e)
        {
            if (v62.Checked == true) vDMTyp.Visible = true;
            else vDMTyp.Visible = false;
       }

        private void vHilfsm_ValueChanged(object sender, EventArgs e)
        {
            //string hm = (string)vHilfsm.Text;
            //hm.Replace("@", "\r\n"); hm = hm.Replace("@", "\r\n");
            //vHilfsm.Text = hm;
        }

        private void g1_AfterCheckStateChanged(object sender, EventArgs e)
        {
            if(g1.Checked == true)
            {   v11.Checked= false;v12.Checked=false;v14.Checked=false;v15.Checked=false;}
        }

        private void v11_CheckStateChanged(object sender, EventArgs e)
        {
            if (v11.Checked==true || v12.Checked==true || v14.Checked==true || v15.Checked==true)
                { g1.Checked= false;}
        }

        private void g2_AfterCheckStateChanged(object sender, EventArgs e)
        {
            if (g2.Checked == true)
            { v21.Checked = false; v22.Checked = false; v24.Checked = false; /*v25.Checked = false;*/ }
        }

        private void v21_CheckedChanged(object sender, EventArgs e)
        {
            if (v21.Checked == true || v22.Checked == true || v24.Checked == true /*|| v25.Checked == true*/)
            { g2.Checked = false; }
        }

        private void g62_CheckedChanged(object sender, EventArgs e)
        {
            if (g62.Checked == true) { v61.Checked = false; }
            
        }

        private void v61_CheckedChanged(object sender, EventArgs e)
        {
           if (v61.Checked == true) { g62.Checked = false; }
        }

        private void v45_CheckedChanged(object sender, EventArgs e)
        {
            if (v45.Checked == true) { g42.Checked = false; }
        }

        private void cbETo_ValueChanged(object sender, EventArgs e)
        {
            Guid gui = (Guid)(cbETo.Value);
            vEinrichtungsID.Text = gui.ToString("B");
            
            bool bShowCheckInsArchiv = false;
            using (compSql comp = new compSql())
            {
                bShowCheckInsArchiv = comp.GetOrdnerBiografie("Pflegebegleitschreiben") != null && !ENV.SavePflegebegleitschreibenToArchiv;
            }

            if (bShowCheckInsArchiv)
            {
                chkInsArchiv.Visible = true;
                chkInsArchiv.Checked = false;
                SavePBSToArchive = false;
            }
            else
            {
                chkInsArchiv.Visible = false;
                chkInsArchiv.Checked = true;
                SavePBSToArchive = true;
            }
        }

        private void v34_CheckedChanged(object sender, EventArgs e)
        {

        }    

        private bool validateCboEinrichtung()
        {
            if (this.cbETo.Value == null)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Einrichtung: Auswahl erforderlich!", "PMDS", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void FrmPrintPflegebegleitschreibenInfo_Load(object sender, EventArgs e)
        {
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
        }

        private void chkInsArchiv_CheckedChanged(object sender, EventArgs e)
        {
            SavePBSToArchive = chkInsArchiv.Checked;
        }
    }


}
