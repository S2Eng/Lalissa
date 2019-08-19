//----------------------------------------------------------------------------
/// <summary>
///	frmPrintPflegebriefInfo.cs
/// Erstellt am:	9.2.2005
/// Erstellt von:	EHO
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
using System.Text;
using PMDS.GUI;
using PMDS.Global;
using PMDS.BusinessLogic;
using Infragistics.Win.UltraWinEditors;

namespace PMDS.Print
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Form für Druck-Vorschau.
	/// </summary>
	//----------------------------------------------------------------------------
	public class frmPrintPflegebegleitschreibenInfo : frmBase
	{
		private bool _canClose = false;
		private QS2.Desktop.ControlManagment.BaseLabel lblAnEinrichtung;
		private PMDS.GUI.BaseControls.EinrichtungsCombo cbETo;
		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpWichtigeInformationen;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtBemerkung;
        private TableLayoutPanel tableLayoutPanelCenter;
        private QS2.Desktop.ControlManagment.BasePanel panelRight4;
        private QS2.Desktop.ControlManagment.BasePanel panelCheckBoxes7;
        private QS2.Desktop.ControlManagment.BasePanel panelRight3;
        private QS2.Desktop.ControlManagment.BasePanel panelCheckBoxes6;
        private QS2.Desktop.ControlManagment.BasePanel panelRight2;
        private QS2.Desktop.ControlManagment.BasePanel panelCheckBoxes5;
        private QS2.Desktop.ControlManagment.BasePanel panelRight1;
        private QS2.Desktop.ControlManagment.BasePanel panelRight6;
        private QS2.Desktop.ControlManagment.BasePanel panelCheckBoxes3;
        private QS2.Desktop.ControlManagment.BasePanel panelRight5;
        private QS2.Desktop.ControlManagment.BasePanel panelCheckBoxes2;
        private QS2.Desktop.ControlManagment.BasePanel panelKommentar;
        private QS2.Desktop.ControlManagment.BasePanel panelCheckBoxes1;
        private QS2.Desktop.ControlManagment.BasePanel panelVerständigung;
        private QS2.Desktop.ControlManagment.BaseCheckBox g2;
        private QS2.Desktop.ControlManagment.BaseLabel lblVerständigung;
        private QS2.Desktop.ControlManagment.BasePanel panelAusscheidung;
        private QS2.Desktop.ControlManagment.BaseCheckBox g7;
        private QS2.Desktop.ControlManagment.BaseLabel lblAusscheidung;
        private QS2.Desktop.ControlManagment.BasePanel panelErklärung;
        private QS2.Desktop.ControlManagment.BaseCheckBox g62;
        private QS2.Desktop.ControlManagment.BaseCheckBox g61;
        private QS2.Desktop.ControlManagment.BaseLabel lblErnährung;
        private QS2.Desktop.ControlManagment.BasePanel panelAnAuskleiden;
        private QS2.Desktop.ControlManagment.BaseCheckBox g5;
        private QS2.Desktop.ControlManagment.BaseLabel lblAnAuskleiden;
        private QS2.Desktop.ControlManagment.BasePanel panelKörperpflege;
        private QS2.Desktop.ControlManagment.BaseCheckBox g42;
        private QS2.Desktop.ControlManagment.BaseCheckBox g41;
        private QS2.Desktop.ControlManagment.BaseLabel lblöKörperpflege;
        private QS2.Desktop.ControlManagment.BasePanel panelMobilisation;
        private QS2.Desktop.ControlManagment.BaseCheckBox g3;
        private QS2.Desktop.ControlManagment.BaseLabel lblMobilisation;
        private QS2.Desktop.ControlManagment.BasePanel panelOrientierung;
        private QS2.Desktop.ControlManagment.BaseCheckBox g1;
        private QS2.Desktop.ControlManagment.BaseLabel lblOrientierung;
        private QS2.Desktop.ControlManagment.BaseCheckBox v15;
        private QS2.Desktop.ControlManagment.BaseCheckBox v14;
        private QS2.Desktop.ControlManagment.BaseCheckBox v13;
        private QS2.Desktop.ControlManagment.BaseCheckBox v12;
        private QS2.Desktop.ControlManagment.BaseCheckBox v11;
        private QS2.Desktop.ControlManagment.BasePanel panelCheckBoxes4;
        private QS2.Desktop.ControlManagment.BaseCheckBox v44;
        private QS2.Desktop.ControlManagment.BaseCheckBox v43;
        private QS2.Desktop.ControlManagment.BaseCheckBox v42;
        private QS2.Desktop.ControlManagment.BaseCheckBox v41;
        private QS2.Desktop.ControlManagment.BaseCheckBox v36;
        private QS2.Desktop.ControlManagment.BaseCheckBox v35;
        private QS2.Desktop.ControlManagment.BaseCheckBox v34;
        private QS2.Desktop.ControlManagment.BaseCheckBox v33;
        private QS2.Desktop.ControlManagment.BaseCheckBox v32;
        private QS2.Desktop.ControlManagment.BaseCheckBox v31;
        private QS2.Desktop.ControlManagment.BaseCheckBox v26;
        private QS2.Desktop.ControlManagment.BaseCheckBox v25;
        private QS2.Desktop.ControlManagment.BaseCheckBox v24;
        private QS2.Desktop.ControlManagment.BaseCheckBox v23;
        private QS2.Desktop.ControlManagment.BaseCheckBox v22;
        private QS2.Desktop.ControlManagment.BaseCheckBox v21;
        private QS2.Desktop.ControlManagment.BaseCheckBox v75;
        private QS2.Desktop.ControlManagment.BaseCheckBox v74;
        private QS2.Desktop.ControlManagment.BaseCheckBox v78;
        private QS2.Desktop.ControlManagment.BaseCheckBox v77;
        private QS2.Desktop.ControlManagment.BaseCheckBox v76;
        private QS2.Desktop.ControlManagment.BaseCheckBox v73;
        private QS2.Desktop.ControlManagment.BaseCheckBox v72;
        private QS2.Desktop.ControlManagment.BaseCheckBox v71;
        private QS2.Desktop.ControlManagment.BaseCheckBox v66;
        private QS2.Desktop.ControlManagment.BaseCheckBox v65;
        private QS2.Desktop.ControlManagment.BaseCheckBox v64;
        private QS2.Desktop.ControlManagment.BaseCheckBox v63;
        private QS2.Desktop.ControlManagment.BaseCheckBox v62;
        private QS2.Desktop.ControlManagment.BaseCheckBox v61;
        private QS2.Desktop.ControlManagment.BaseCheckBox v52;
        private QS2.Desktop.ControlManagment.BaseCheckBox v51;
        private QS2.Desktop.ControlManagment.BaseCheckBox v45;
        private QS2.Desktop.ControlManagment.BaseLabel lblKommentar;
        private QS2.Desktop.ControlManagment.BaseTextEditor k1;
        private QS2.Desktop.ControlManagment.BaseTextEditor k7;
        private QS2.Desktop.ControlManagment.BaseTextEditor k6;
        private QS2.Desktop.ControlManagment.BaseTextEditor k5;
        private QS2.Desktop.ControlManagment.BaseTextEditor k4;
        private QS2.Desktop.ControlManagment.BaseTextEditor k3;
        private QS2.Desktop.ControlManagment.BaseTextEditor k2;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpPersönlicheSachen;
        private QS2.Desktop.ControlManagment.BaseCheckBox lblZahnprotUK;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtSonstiges;
        private QS2.Desktop.ControlManagment.BaseLabel lblSonstiges;
        private QS2.Desktop.ControlManagment.BaseCheckBox lblBrille;
        private QS2.Desktop.ControlManagment.BaseCheckBox lblInsulinPE;
        private QS2.Desktop.ControlManagment.BaseCheckBox lblHörgerät;
        private QS2.Desktop.ControlManagment.BaseCheckBox lblZahnprotOK;
		private System.ComponentModel.IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Form zum Bearbeiten der Report Pflegebrief-Daten.
		/// </summary>
		//----------------------------------------------------------------------------
        public frmPrintPflegebegleitschreibenInfo()
		{
			InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            RequiredFields();

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
            this.tableLayoutPanelCenter = new System.Windows.Forms.TableLayoutPanel();
            this.panelAusscheidung = new QS2.Desktop.ControlManagment.BasePanel();
            this.g7 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblAusscheidung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelErklärung = new QS2.Desktop.ControlManagment.BasePanel();
            this.g62 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.g61 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblErnährung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelAnAuskleiden = new QS2.Desktop.ControlManagment.BasePanel();
            this.g5 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblAnAuskleiden = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelKörperpflege = new QS2.Desktop.ControlManagment.BasePanel();
            this.g42 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.g41 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblöKörperpflege = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelMobilisation = new QS2.Desktop.ControlManagment.BasePanel();
            this.g3 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblMobilisation = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelOrientierung = new QS2.Desktop.ControlManagment.BasePanel();
            this.g1 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblOrientierung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelVerständigung = new QS2.Desktop.ControlManagment.BasePanel();
            this.g2 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblVerständigung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelRight4 = new QS2.Desktop.ControlManagment.BasePanel();
            this.k7 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.panelCheckBoxes7 = new QS2.Desktop.ControlManagment.BasePanel();
            this.v78 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v75 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v74 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v77 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v76 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v73 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v72 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v71 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panelRight3 = new QS2.Desktop.ControlManagment.BasePanel();
            this.k6 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.panelCheckBoxes6 = new QS2.Desktop.ControlManagment.BasePanel();
            this.v66 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v65 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v64 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v63 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v62 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v61 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panelRight2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.k5 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.panelCheckBoxes5 = new QS2.Desktop.ControlManagment.BasePanel();
            this.v52 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v51 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panelRight1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.k4 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.panelCheckBoxes4 = new QS2.Desktop.ControlManagment.BasePanel();
            this.v45 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v44 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v43 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v42 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v41 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panelRight6 = new QS2.Desktop.ControlManagment.BasePanel();
            this.k3 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.panelCheckBoxes3 = new QS2.Desktop.ControlManagment.BasePanel();
            this.v36 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v35 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v34 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v33 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v32 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v31 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panelRight5 = new QS2.Desktop.ControlManagment.BasePanel();
            this.k2 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.panelCheckBoxes2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.v26 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v25 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v24 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v23 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v22 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v21 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panelKommentar = new QS2.Desktop.ControlManagment.BasePanel();
            this.k1 = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblKommentar = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelCheckBoxes1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.v15 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v14 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v13 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v12 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.v11 = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.grpPersönlicheSachen = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.txtSonstiges = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblSonstiges = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblBrille = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblInsulinPE = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblHörgerät = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblZahnprotOK = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblZahnprotUK = new QS2.Desktop.ControlManagment.BaseCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cbETo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grpWichtigeInformationen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBemerkung)).BeginInit();
            this.tableLayoutPanelCenter.SuspendLayout();
            this.panelAusscheidung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g7)).BeginInit();
            this.panelErklärung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g61)).BeginInit();
            this.panelAnAuskleiden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g5)).BeginInit();
            this.panelKörperpflege.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g41)).BeginInit();
            this.panelMobilisation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g3)).BeginInit();
            this.panelOrientierung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g1)).BeginInit();
            this.panelVerständigung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g2)).BeginInit();
            this.panelRight4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k7)).BeginInit();
            this.panelCheckBoxes7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v78)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v76)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v71)).BeginInit();
            this.panelRight3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k6)).BeginInit();
            this.panelCheckBoxes6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v61)).BeginInit();
            this.panelRight2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k5)).BeginInit();
            this.panelCheckBoxes5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v51)).BeginInit();
            this.panelRight1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k4)).BeginInit();
            this.panelCheckBoxes4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v41)).BeginInit();
            this.panelRight6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k3)).BeginInit();
            this.panelCheckBoxes3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v31)).BeginInit();
            this.panelRight5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k2)).BeginInit();
            this.panelCheckBoxes2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v21)).BeginInit();
            this.panelKommentar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k1)).BeginInit();
            this.panelCheckBoxes1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v11)).BeginInit();
            this.grpPersönlicheSachen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSonstiges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBrille)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInsulinPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHörgerät)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahnprotOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahnprotUK)).BeginInit();
            this.SuspendLayout();
            // 
            // cbETo
            // 
            this.cbETo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbETo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbETo.Location = new System.Drawing.Point(96, 8);
            this.cbETo.Name = "cbETo";
            this.cbETo.Size = new System.Drawing.Size(640, 21);
            this.cbETo.TabIndex = 0;
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
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(598, 685);
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
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(694, 685);
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
            this.grpWichtigeInformationen.Location = new System.Drawing.Point(8, 597);
            this.grpWichtigeInformationen.Name = "grpWichtigeInformationen";
            this.grpWichtigeInformationen.Size = new System.Drawing.Size(736, 55);
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
            this.txtBemerkung.Location = new System.Drawing.Point(16, 24);
            this.txtBemerkung.Multiline = true;
            this.txtBemerkung.Name = "txtBemerkung";
            this.txtBemerkung.Size = new System.Drawing.Size(704, 23);
            this.txtBemerkung.TabIndex = 0;
            // 
            // tableLayoutPanelCenter
            // 
            this.tableLayoutPanelCenter.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelCenter.ColumnCount = 3;
            this.tableLayoutPanelCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.41226F));
            this.tableLayoutPanelCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.33983F));
            this.tableLayoutPanelCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.06815F));
            this.tableLayoutPanelCenter.Controls.Add(this.panelAusscheidung, 0, 6);
            this.tableLayoutPanelCenter.Controls.Add(this.panelErklärung, 0, 5);
            this.tableLayoutPanelCenter.Controls.Add(this.panelAnAuskleiden, 0, 4);
            this.tableLayoutPanelCenter.Controls.Add(this.panelKörperpflege, 0, 3);
            this.tableLayoutPanelCenter.Controls.Add(this.panelMobilisation, 0, 2);
            this.tableLayoutPanelCenter.Controls.Add(this.panelOrientierung, 0, 0);
            this.tableLayoutPanelCenter.Controls.Add(this.panelVerständigung, 0, 1);
            this.tableLayoutPanelCenter.Controls.Add(this.panelRight4, 2, 6);
            this.tableLayoutPanelCenter.Controls.Add(this.panelCheckBoxes7, 1, 6);
            this.tableLayoutPanelCenter.Controls.Add(this.panelRight3, 2, 5);
            this.tableLayoutPanelCenter.Controls.Add(this.panelCheckBoxes6, 1, 5);
            this.tableLayoutPanelCenter.Controls.Add(this.panelRight2, 2, 4);
            this.tableLayoutPanelCenter.Controls.Add(this.panelCheckBoxes5, 1, 4);
            this.tableLayoutPanelCenter.Controls.Add(this.panelRight1, 2, 3);
            this.tableLayoutPanelCenter.Controls.Add(this.panelCheckBoxes4, 1, 3);
            this.tableLayoutPanelCenter.Controls.Add(this.panelRight6, 2, 2);
            this.tableLayoutPanelCenter.Controls.Add(this.panelCheckBoxes3, 1, 2);
            this.tableLayoutPanelCenter.Controls.Add(this.panelRight5, 2, 1);
            this.tableLayoutPanelCenter.Controls.Add(this.panelCheckBoxes2, 1, 1);
            this.tableLayoutPanelCenter.Controls.Add(this.panelKommentar, 2, 0);
            this.tableLayoutPanelCenter.Controls.Add(this.panelCheckBoxes1, 1, 0);
            this.tableLayoutPanelCenter.Location = new System.Drawing.Point(24, 35);
            this.tableLayoutPanelCenter.Name = "tableLayoutPanelCenter";
            this.tableLayoutPanelCenter.RowCount = 7;
            this.tableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.36266F));
            this.tableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.719928F));
            this.tableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.64452F));
            this.tableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.18492F));
            this.tableLayoutPanelCenter.Size = new System.Drawing.Size(719, 558);
            this.tableLayoutPanelCenter.TabIndex = 7;
            // 
            // panelAusscheidung
            // 
            this.panelAusscheidung.BackColor = System.Drawing.Color.LightGray;
            this.panelAusscheidung.Controls.Add(this.g7);
            this.panelAusscheidung.Controls.Add(this.lblAusscheidung);
            this.panelAusscheidung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAusscheidung.Location = new System.Drawing.Point(1, 437);
            this.panelAusscheidung.Margin = new System.Windows.Forms.Padding(0);
            this.panelAusscheidung.Name = "panelAusscheidung";
            this.panelAusscheidung.Size = new System.Drawing.Size(203, 120);
            this.panelAusscheidung.TabIndex = 18;
            // 
            // g7
            // 
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
            // panelErklärung
            // 
            this.panelErklärung.BackColor = System.Drawing.Color.LightGray;
            this.panelErklärung.Controls.Add(this.g62);
            this.panelErklärung.Controls.Add(this.g61);
            this.panelErklärung.Controls.Add(this.lblErnährung);
            this.panelErklärung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelErklärung.Location = new System.Drawing.Point(1, 361);
            this.panelErklärung.Margin = new System.Windows.Forms.Padding(0);
            this.panelErklärung.Name = "panelErklärung";
            this.panelErklärung.Size = new System.Drawing.Size(203, 75);
            this.panelErklärung.TabIndex = 15;
            // 
            // g62
            // 
            this.g62.Location = new System.Drawing.Point(38, 40);
            this.g62.Name = "g62";
            this.g62.Size = new System.Drawing.Size(120, 20);
            this.g62.TabIndex = 1;
            this.g62.Text = "Normalkost";
            // 
            // g61
            // 
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
            // panelAnAuskleiden
            // 
            this.panelAnAuskleiden.BackColor = System.Drawing.Color.LightGray;
            this.panelAnAuskleiden.Controls.Add(this.g5);
            this.panelAnAuskleiden.Controls.Add(this.lblAnAuskleiden);
            this.panelAnAuskleiden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnAuskleiden.Location = new System.Drawing.Point(1, 318);
            this.panelAnAuskleiden.Margin = new System.Windows.Forms.Padding(0);
            this.panelAnAuskleiden.Name = "panelAnAuskleiden";
            this.panelAnAuskleiden.Size = new System.Drawing.Size(203, 42);
            this.panelAnAuskleiden.TabIndex = 12;
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
            // panelKörperpflege
            // 
            this.panelKörperpflege.BackColor = System.Drawing.Color.LightGray;
            this.panelKörperpflege.Controls.Add(this.g42);
            this.panelKörperpflege.Controls.Add(this.g41);
            this.panelKörperpflege.Controls.Add(this.lblöKörperpflege);
            this.panelKörperpflege.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKörperpflege.Location = new System.Drawing.Point(1, 238);
            this.panelKörperpflege.Margin = new System.Windows.Forms.Padding(0);
            this.panelKörperpflege.Name = "panelKörperpflege";
            this.panelKörperpflege.Size = new System.Drawing.Size(203, 79);
            this.panelKörperpflege.TabIndex = 9;
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
            this.g41.Location = new System.Drawing.Point(38, 23);
            this.g41.Name = "g41";
            this.g41.Size = new System.Drawing.Size(120, 20);
            this.g41.TabIndex = 0;
            this.g41.Text = "selbständig";
            // 
            // lblöKörperpflege
            // 
            this.lblöKörperpflege.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblöKörperpflege.Location = new System.Drawing.Point(18, 4);
            this.lblöKörperpflege.Name = "lblöKörperpflege";
            this.lblöKörperpflege.Size = new System.Drawing.Size(123, 23);
            this.lblöKörperpflege.TabIndex = 0;
            this.lblöKörperpflege.Text = "Körperpflege";
            // 
            // panelMobilisation
            // 
            this.panelMobilisation.BackColor = System.Drawing.Color.LightGray;
            this.panelMobilisation.Controls.Add(this.g3);
            this.panelMobilisation.Controls.Add(this.lblMobilisation);
            this.panelMobilisation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMobilisation.Location = new System.Drawing.Point(1, 159);
            this.panelMobilisation.Margin = new System.Windows.Forms.Padding(0);
            this.panelMobilisation.Name = "panelMobilisation";
            this.panelMobilisation.Size = new System.Drawing.Size(203, 78);
            this.panelMobilisation.TabIndex = 6;
            // 
            // g3
            // 
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
            // panelOrientierung
            // 
            this.panelOrientierung.BackColor = System.Drawing.Color.LightGray;
            this.panelOrientierung.Controls.Add(this.g1);
            this.panelOrientierung.Controls.Add(this.lblOrientierung);
            this.panelOrientierung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOrientierung.Location = new System.Drawing.Point(1, 1);
            this.panelOrientierung.Margin = new System.Windows.Forms.Padding(0);
            this.panelOrientierung.Name = "panelOrientierung";
            this.panelOrientierung.Size = new System.Drawing.Size(203, 78);
            this.panelOrientierung.TabIndex = 0;
            // 
            // g1
            // 
            this.g1.Location = new System.Drawing.Point(38, 23);
            this.g1.Name = "g1";
            this.g1.Size = new System.Drawing.Size(120, 20);
            this.g1.TabIndex = 0;
            this.g1.Text = "orientiert";
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
            // panelVerständigung
            // 
            this.panelVerständigung.BackColor = System.Drawing.Color.LightGray;
            this.panelVerständigung.Controls.Add(this.g2);
            this.panelVerständigung.Controls.Add(this.lblVerständigung);
            this.panelVerständigung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVerständigung.Location = new System.Drawing.Point(1, 80);
            this.panelVerständigung.Margin = new System.Windows.Forms.Padding(0);
            this.panelVerständigung.Name = "panelVerständigung";
            this.panelVerständigung.Size = new System.Drawing.Size(203, 78);
            this.panelVerständigung.TabIndex = 3;
            // 
            // g2
            // 
            this.g2.Location = new System.Drawing.Point(38, 23);
            this.g2.Name = "g2";
            this.g2.Size = new System.Drawing.Size(120, 20);
            this.g2.TabIndex = 0;
            this.g2.Text = "nicht beeinträchtigt";
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
            // panelRight4
            // 
            this.panelRight4.Controls.Add(this.k7);
            this.panelRight4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight4.Location = new System.Drawing.Point(509, 437);
            this.panelRight4.Margin = new System.Windows.Forms.Padding(0);
            this.panelRight4.Name = "panelRight4";
            this.panelRight4.Size = new System.Drawing.Size(209, 120);
            this.panelRight4.TabIndex = 20;
            // 
            // k7
            // 
            this.k7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k7.Location = new System.Drawing.Point(0, 0);
            this.k7.Multiline = true;
            this.k7.Name = "k7";
            this.k7.Size = new System.Drawing.Size(209, 120);
            this.k7.TabIndex = 0;
            // 
            // panelCheckBoxes7
            // 
            this.panelCheckBoxes7.Controls.Add(this.v78);
            this.panelCheckBoxes7.Controls.Add(this.v75);
            this.panelCheckBoxes7.Controls.Add(this.v74);
            this.panelCheckBoxes7.Controls.Add(this.v77);
            this.panelCheckBoxes7.Controls.Add(this.v76);
            this.panelCheckBoxes7.Controls.Add(this.v73);
            this.panelCheckBoxes7.Controls.Add(this.v72);
            this.panelCheckBoxes7.Controls.Add(this.v71);
            this.panelCheckBoxes7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCheckBoxes7.Location = new System.Drawing.Point(205, 437);
            this.panelCheckBoxes7.Margin = new System.Windows.Forms.Padding(0);
            this.panelCheckBoxes7.Name = "panelCheckBoxes7";
            this.panelCheckBoxes7.Size = new System.Drawing.Size(303, 120);
            this.panelCheckBoxes7.TabIndex = 19;
            // 
            // v78
            // 
            this.v78.Location = new System.Drawing.Point(159, 87);
            this.v78.Name = "v78";
            this.v78.Size = new System.Drawing.Size(141, 20);
            this.v78.TabIndex = 7;
            this.v78.Text = "Obstipationsprophylaxe";
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
            this.v77.Text = "Stuhlinkontinenz ? letzter Stuhlgang ?";
            // 
            // v76
            // 
            this.v76.Location = new System.Drawing.Point(159, 3);
            this.v76.Name = "v76";
            this.v76.Size = new System.Drawing.Size(141, 37);
            this.v76.TabIndex = 5;
            this.v76.Text = "Dauerkatheter ? letzter Wechsel ?";
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
            // panelRight3
            // 
            this.panelRight3.Controls.Add(this.k6);
            this.panelRight3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight3.Location = new System.Drawing.Point(509, 361);
            this.panelRight3.Margin = new System.Windows.Forms.Padding(0);
            this.panelRight3.Name = "panelRight3";
            this.panelRight3.Size = new System.Drawing.Size(209, 75);
            this.panelRight3.TabIndex = 17;
            // 
            // k6
            // 
            this.k6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k6.Location = new System.Drawing.Point(0, 0);
            this.k6.Multiline = true;
            this.k6.Name = "k6";
            this.k6.Size = new System.Drawing.Size(209, 75);
            this.k6.TabIndex = 0;
            // 
            // panelCheckBoxes6
            // 
            this.panelCheckBoxes6.Controls.Add(this.v66);
            this.panelCheckBoxes6.Controls.Add(this.v65);
            this.panelCheckBoxes6.Controls.Add(this.v64);
            this.panelCheckBoxes6.Controls.Add(this.v63);
            this.panelCheckBoxes6.Controls.Add(this.v62);
            this.panelCheckBoxes6.Controls.Add(this.v61);
            this.panelCheckBoxes6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCheckBoxes6.Location = new System.Drawing.Point(205, 361);
            this.panelCheckBoxes6.Margin = new System.Windows.Forms.Padding(0);
            this.panelCheckBoxes6.Name = "panelCheckBoxes6";
            this.panelCheckBoxes6.Size = new System.Drawing.Size(303, 75);
            this.panelCheckBoxes6.TabIndex = 16;
            // 
            // v66
            // 
            this.v66.Location = new System.Drawing.Point(159, 48);
            this.v66.Name = "v66";
            this.v66.Size = new System.Drawing.Size(120, 20);
            this.v66.TabIndex = 5;
            this.v66.Text = "Flüssigkeitszufuhr";
            // 
            // v65
            // 
            this.v65.Location = new System.Drawing.Point(159, 27);
            this.v65.Name = "v65";
            this.v65.Size = new System.Drawing.Size(120, 20);
            this.v65.TabIndex = 4;
            this.v65.Text = "Sonde";
            // 
            // v64
            // 
            this.v64.Location = new System.Drawing.Point(159, 6);
            this.v64.Name = "v64";
            this.v64.Size = new System.Drawing.Size(120, 20);
            this.v64.TabIndex = 3;
            this.v64.Text = "breiig";
            // 
            // v63
            // 
            this.v63.Location = new System.Drawing.Point(3, 49);
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
            // 
            // v61
            // 
            this.v61.Location = new System.Drawing.Point(3, 7);
            this.v61.Name = "v61";
            this.v61.Size = new System.Drawing.Size(120, 20);
            this.v61.TabIndex = 0;
            this.v61.Text = "Diät";
            // 
            // panelRight2
            // 
            this.panelRight2.Controls.Add(this.k5);
            this.panelRight2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight2.Location = new System.Drawing.Point(509, 318);
            this.panelRight2.Margin = new System.Windows.Forms.Padding(0);
            this.panelRight2.Name = "panelRight2";
            this.panelRight2.Size = new System.Drawing.Size(209, 42);
            this.panelRight2.TabIndex = 14;
            // 
            // k5
            // 
            this.k5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k5.Location = new System.Drawing.Point(0, 0);
            this.k5.Multiline = true;
            this.k5.Name = "k5";
            this.k5.Size = new System.Drawing.Size(209, 42);
            this.k5.TabIndex = 0;
            // 
            // panelCheckBoxes5
            // 
            this.panelCheckBoxes5.Controls.Add(this.v52);
            this.panelCheckBoxes5.Controls.Add(this.v51);
            this.panelCheckBoxes5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCheckBoxes5.Location = new System.Drawing.Point(205, 318);
            this.panelCheckBoxes5.Margin = new System.Windows.Forms.Padding(0);
            this.panelCheckBoxes5.Name = "panelCheckBoxes5";
            this.panelCheckBoxes5.Size = new System.Drawing.Size(303, 42);
            this.panelCheckBoxes5.TabIndex = 13;
            // 
            // v52
            // 
            this.v52.Location = new System.Drawing.Point(3, 21);
            this.v52.Name = "v52";
            this.v52.Size = new System.Drawing.Size(206, 20);
            this.v52.TabIndex = 1;
            this.v52.Text = "vollständig übernehmen";
            // 
            // v51
            // 
            this.v51.Location = new System.Drawing.Point(3, 0);
            this.v51.Name = "v51";
            this.v51.Size = new System.Drawing.Size(120, 20);
            this.v51.TabIndex = 0;
            this.v51.Text = "benötigt Hilfe";
            // 
            // panelRight1
            // 
            this.panelRight1.Controls.Add(this.k4);
            this.panelRight1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight1.Location = new System.Drawing.Point(509, 238);
            this.panelRight1.Margin = new System.Windows.Forms.Padding(0);
            this.panelRight1.Name = "panelRight1";
            this.panelRight1.Size = new System.Drawing.Size(209, 79);
            this.panelRight1.TabIndex = 11;
            // 
            // k4
            // 
            this.k4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k4.Location = new System.Drawing.Point(0, 0);
            this.k4.Multiline = true;
            this.k4.Name = "k4";
            this.k4.Size = new System.Drawing.Size(209, 79);
            this.k4.TabIndex = 0;
            // 
            // panelCheckBoxes4
            // 
            this.panelCheckBoxes4.Controls.Add(this.v45);
            this.panelCheckBoxes4.Controls.Add(this.v44);
            this.panelCheckBoxes4.Controls.Add(this.v43);
            this.panelCheckBoxes4.Controls.Add(this.v42);
            this.panelCheckBoxes4.Controls.Add(this.v41);
            this.panelCheckBoxes4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCheckBoxes4.Location = new System.Drawing.Point(205, 238);
            this.panelCheckBoxes4.Margin = new System.Windows.Forms.Padding(0);
            this.panelCheckBoxes4.Name = "panelCheckBoxes4";
            this.panelCheckBoxes4.Size = new System.Drawing.Size(303, 79);
            this.panelCheckBoxes4.TabIndex = 10;
            // 
            // v45
            // 
            this.v45.Location = new System.Drawing.Point(159, 25);
            this.v45.Name = "v45";
            this.v45.Size = new System.Drawing.Size(120, 35);
            this.v45.TabIndex = 4;
            this.v45.Text = "Hautschäden ? Größe? wo ?";
            // 
            // v44
            // 
            this.v44.Location = new System.Drawing.Point(159, 3);
            this.v44.Name = "v44";
            this.v44.Size = new System.Drawing.Size(120, 20);
            this.v44.TabIndex = 3;
            this.v44.Text = "Zahnprot. UK";
            // 
            // v43
            // 
            this.v43.Location = new System.Drawing.Point(3, 46);
            this.v43.Name = "v43";
            this.v43.Size = new System.Drawing.Size(120, 20);
            this.v43.TabIndex = 2;
            this.v43.Text = "Zahnprot. OK";
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
            // panelRight6
            // 
            this.panelRight6.Controls.Add(this.k3);
            this.panelRight6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight6.Location = new System.Drawing.Point(509, 159);
            this.panelRight6.Margin = new System.Windows.Forms.Padding(0);
            this.panelRight6.Name = "panelRight6";
            this.panelRight6.Size = new System.Drawing.Size(209, 78);
            this.panelRight6.TabIndex = 8;
            // 
            // k3
            // 
            this.k3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k3.Location = new System.Drawing.Point(0, 0);
            this.k3.Multiline = true;
            this.k3.Name = "k3";
            this.k3.Size = new System.Drawing.Size(209, 78);
            this.k3.TabIndex = 0;
            // 
            // panelCheckBoxes3
            // 
            this.panelCheckBoxes3.Controls.Add(this.v36);
            this.panelCheckBoxes3.Controls.Add(this.v35);
            this.panelCheckBoxes3.Controls.Add(this.v34);
            this.panelCheckBoxes3.Controls.Add(this.v33);
            this.panelCheckBoxes3.Controls.Add(this.v32);
            this.panelCheckBoxes3.Controls.Add(this.v31);
            this.panelCheckBoxes3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCheckBoxes3.Location = new System.Drawing.Point(205, 159);
            this.panelCheckBoxes3.Margin = new System.Windows.Forms.Padding(0);
            this.panelCheckBoxes3.Name = "panelCheckBoxes3";
            this.panelCheckBoxes3.Size = new System.Drawing.Size(303, 78);
            this.panelCheckBoxes3.TabIndex = 7;
            // 
            // v36
            // 
            this.v36.Location = new System.Drawing.Point(159, 45);
            this.v36.Name = "v36";
            this.v36.Size = new System.Drawing.Size(120, 20);
            this.v36.TabIndex = 5;
            this.v36.Text = "Gehhilfen";
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
            // 
            // v33
            // 
            this.v33.Location = new System.Drawing.Point(3, 46);
            this.v33.Name = "v33";
            this.v33.Size = new System.Drawing.Size(120, 20);
            this.v33.TabIndex = 2;
            this.v33.Text = "Rollstuhl";
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
            // panelRight5
            // 
            this.panelRight5.Controls.Add(this.k2);
            this.panelRight5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight5.Location = new System.Drawing.Point(509, 80);
            this.panelRight5.Margin = new System.Windows.Forms.Padding(0);
            this.panelRight5.Name = "panelRight5";
            this.panelRight5.Size = new System.Drawing.Size(209, 78);
            this.panelRight5.TabIndex = 5;
            // 
            // k2
            // 
            this.k2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k2.Location = new System.Drawing.Point(0, 0);
            this.k2.Multiline = true;
            this.k2.Name = "k2";
            this.k2.Size = new System.Drawing.Size(209, 78);
            this.k2.TabIndex = 0;
            // 
            // panelCheckBoxes2
            // 
            this.panelCheckBoxes2.Controls.Add(this.v26);
            this.panelCheckBoxes2.Controls.Add(this.v25);
            this.panelCheckBoxes2.Controls.Add(this.v24);
            this.panelCheckBoxes2.Controls.Add(this.v23);
            this.panelCheckBoxes2.Controls.Add(this.v22);
            this.panelCheckBoxes2.Controls.Add(this.v21);
            this.panelCheckBoxes2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCheckBoxes2.Location = new System.Drawing.Point(205, 80);
            this.panelCheckBoxes2.Margin = new System.Windows.Forms.Padding(0);
            this.panelCheckBoxes2.Name = "panelCheckBoxes2";
            this.panelCheckBoxes2.Size = new System.Drawing.Size(303, 78);
            this.panelCheckBoxes2.TabIndex = 4;
            // 
            // v26
            // 
            this.v26.Location = new System.Drawing.Point(159, 45);
            this.v26.Name = "v26";
            this.v26.Size = new System.Drawing.Size(120, 20);
            this.v26.TabIndex = 5;
            this.v26.Text = "Brille";
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
            // 
            // v23
            // 
            this.v23.Location = new System.Drawing.Point(3, 46);
            this.v23.Name = "v23";
            this.v23.Size = new System.Drawing.Size(120, 20);
            this.v23.TabIndex = 2;
            this.v23.Text = "Hörgerät";
            // 
            // v22
            // 
            this.v22.Location = new System.Drawing.Point(3, 25);
            this.v22.Name = "v22";
            this.v22.Size = new System.Drawing.Size(120, 20);
            this.v22.TabIndex = 1;
            this.v22.Text = "taub";
            // 
            // v21
            // 
            this.v21.Location = new System.Drawing.Point(3, 4);
            this.v21.Name = "v21";
            this.v21.Size = new System.Drawing.Size(120, 20);
            this.v21.TabIndex = 0;
            this.v21.Text = "schwerhörig";
            // 
            // panelKommentar
            // 
            this.panelKommentar.Controls.Add(this.k1);
            this.panelKommentar.Controls.Add(this.lblKommentar);
            this.panelKommentar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKommentar.Location = new System.Drawing.Point(509, 1);
            this.panelKommentar.Margin = new System.Windows.Forms.Padding(0);
            this.panelKommentar.Name = "panelKommentar";
            this.panelKommentar.Size = new System.Drawing.Size(209, 78);
            this.panelKommentar.TabIndex = 2;
            this.panelKommentar.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // k1
            // 
            this.k1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k1.Location = new System.Drawing.Point(0, 22);
            this.k1.Multiline = true;
            this.k1.Name = "k1";
            this.k1.Size = new System.Drawing.Size(209, 56);
            this.k1.TabIndex = 0;
            // 
            // lblKommentar
            // 
            this.lblKommentar.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKommentar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKommentar.Location = new System.Drawing.Point(0, 0);
            this.lblKommentar.Name = "lblKommentar";
            this.lblKommentar.Size = new System.Drawing.Size(209, 22);
            this.lblKommentar.TabIndex = 1;
            this.lblKommentar.Text = "Kommentar";
            // 
            // panelCheckBoxes1
            // 
            this.panelCheckBoxes1.Controls.Add(this.v15);
            this.panelCheckBoxes1.Controls.Add(this.v14);
            this.panelCheckBoxes1.Controls.Add(this.v13);
            this.panelCheckBoxes1.Controls.Add(this.v12);
            this.panelCheckBoxes1.Controls.Add(this.v11);
            this.panelCheckBoxes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCheckBoxes1.Location = new System.Drawing.Point(205, 1);
            this.panelCheckBoxes1.Margin = new System.Windows.Forms.Padding(0);
            this.panelCheckBoxes1.Name = "panelCheckBoxes1";
            this.panelCheckBoxes1.Size = new System.Drawing.Size(303, 78);
            this.panelCheckBoxes1.TabIndex = 1;
            // 
            // v15
            // 
            this.v15.Location = new System.Drawing.Point(159, 24);
            this.v15.Name = "v15";
            this.v15.Size = new System.Drawing.Size(120, 20);
            this.v15.TabIndex = 3;
            this.v15.Text = "z. Pers. desor.";
            // 
            // v14
            // 
            this.v14.Location = new System.Drawing.Point(159, 3);
            this.v14.Name = "v14";
            this.v14.Size = new System.Drawing.Size(120, 20);
            this.v14.TabIndex = 1;
            this.v14.Text = "situativ desor.";
            // 
            // v13
            // 
            this.v13.Location = new System.Drawing.Point(3, 46);
            this.v13.Name = "v13";
            this.v13.Size = new System.Drawing.Size(120, 20);
            this.v13.TabIndex = 4;
            this.v13.Text = "Bettgitter";
            // 
            // v12
            // 
            this.v12.Location = new System.Drawing.Point(3, 25);
            this.v12.Name = "v12";
            this.v12.Size = new System.Drawing.Size(120, 20);
            this.v12.TabIndex = 2;
            this.v12.Text = "zeitl. desor.";
            // 
            // v11
            // 
            this.v11.Location = new System.Drawing.Point(3, 4);
            this.v11.Name = "v11";
            this.v11.Size = new System.Drawing.Size(120, 20);
            this.v11.TabIndex = 0;
            this.v11.Text = "örtlich desor.";
            // 
            // grpPersönlicheSachen
            // 
            this.grpPersönlicheSachen.Controls.Add(this.txtSonstiges);
            this.grpPersönlicheSachen.Controls.Add(this.lblSonstiges);
            this.grpPersönlicheSachen.Controls.Add(this.lblBrille);
            this.grpPersönlicheSachen.Controls.Add(this.lblInsulinPE);
            this.grpPersönlicheSachen.Controls.Add(this.lblHörgerät);
            this.grpPersönlicheSachen.Controls.Add(this.lblZahnprotOK);
            this.grpPersönlicheSachen.Controls.Add(this.lblZahnprotUK);
            this.grpPersönlicheSachen.Location = new System.Drawing.Point(8, 651);
            this.grpPersönlicheSachen.Name = "grpPersönlicheSachen";
            this.grpPersönlicheSachen.Size = new System.Drawing.Size(578, 66);
            this.grpPersönlicheSachen.TabIndex = 1;
            this.grpPersönlicheSachen.TabStop = false;
            this.grpPersönlicheSachen.Text = "persönliche Sachen";
            // 
            // txtSonstiges
            // 
            this.txtSonstiges.AcceptsReturn = true;
            this.txtSonstiges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSonstiges.Location = new System.Drawing.Point(238, 37);
            this.txtSonstiges.Multiline = true;
            this.txtSonstiges.Name = "txtSonstiges";
            this.txtSonstiges.Size = new System.Drawing.Size(334, 23);
            this.txtSonstiges.TabIndex = 7;
            // 
            // lblSonstiges
            // 
            this.lblSonstiges.AutoSize = true;
            this.lblSonstiges.Location = new System.Drawing.Point(180, 43);
            this.lblSonstiges.Name = "lblSonstiges";
            this.lblSonstiges.Size = new System.Drawing.Size(52, 14);
            this.lblSonstiges.TabIndex = 6;
            this.lblSonstiges.Text = "sonstiges";
            // 
            // lblBrille
            // 
            this.lblBrille.Location = new System.Drawing.Point(180, 19);
            this.lblBrille.Name = "lblBrille";
            this.lblBrille.Size = new System.Drawing.Size(61, 20);
            this.lblBrille.TabIndex = 5;
            this.lblBrille.Text = "Brille";
            // 
            // lblInsulinPE
            // 
            this.lblInsulinPE.Location = new System.Drawing.Point(103, 40);
            this.lblInsulinPE.Name = "lblInsulinPE";
            this.lblInsulinPE.Size = new System.Drawing.Size(120, 20);
            this.lblInsulinPE.TabIndex = 4;
            this.lblInsulinPE.Text = "Insulin PE";
            // 
            // lblHörgerät
            // 
            this.lblHörgerät.Location = new System.Drawing.Point(103, 19);
            this.lblHörgerät.Name = "lblHörgerät";
            this.lblHörgerät.Size = new System.Drawing.Size(120, 20);
            this.lblHörgerät.TabIndex = 3;
            this.lblHörgerät.Text = "Hörgerät";
            // 
            // lblZahnprotOK
            // 
            this.lblZahnprotOK.Location = new System.Drawing.Point(6, 40);
            this.lblZahnprotOK.Name = "lblZahnprotOK";
            this.lblZahnprotOK.Size = new System.Drawing.Size(120, 20);
            this.lblZahnprotOK.TabIndex = 2;
            this.lblZahnprotOK.Text = "Zahnprot. OK";
            this.lblZahnprotOK.CheckedChanged += new System.EventHandler(this.v82_CheckedChanged);
            // 
            // lblZahnprotUK
            // 
            this.lblZahnprotUK.Location = new System.Drawing.Point(6, 19);
            this.lblZahnprotUK.Name = "lblZahnprotUK";
            this.lblZahnprotUK.Size = new System.Drawing.Size(120, 20);
            this.lblZahnprotUK.TabIndex = 1;
            this.lblZahnprotUK.Text = "Zahnprot. UK";
            // 
            // frmPrintPflegebegleitschreibenInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(750, 729);
            this.ControlBox = false;
            this.Controls.Add(this.grpWichtigeInformationen);
            this.Controls.Add(this.grpPersönlicheSachen);
            this.Controls.Add(this.tableLayoutPanelCenter);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbETo);
            this.Controls.Add(this.lblAnEinrichtung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrintPflegebegleitschreibenInfo";
            this.ShowInTaskbar = false;
            this.Text = "Pflegebegleitschreiben Informationen ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmPrintPflegebegleitschreibenInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbETo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grpWichtigeInformationen.ResumeLayout(false);
            this.grpWichtigeInformationen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBemerkung)).EndInit();
            this.tableLayoutPanelCenter.ResumeLayout(false);
            this.panelAusscheidung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g7)).EndInit();
            this.panelErklärung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g61)).EndInit();
            this.panelAnAuskleiden.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g5)).EndInit();
            this.panelKörperpflege.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g41)).EndInit();
            this.panelMobilisation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g3)).EndInit();
            this.panelOrientierung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g1)).EndInit();
            this.panelVerständigung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g2)).EndInit();
            this.panelRight4.ResumeLayout(false);
            this.panelRight4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k7)).EndInit();
            this.panelCheckBoxes7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v78)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v76)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v71)).EndInit();
            this.panelRight3.ResumeLayout(false);
            this.panelRight3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k6)).EndInit();
            this.panelCheckBoxes6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v61)).EndInit();
            this.panelRight2.ResumeLayout(false);
            this.panelRight2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k5)).EndInit();
            this.panelCheckBoxes5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v51)).EndInit();
            this.panelRight1.ResumeLayout(false);
            this.panelRight1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k4)).EndInit();
            this.panelCheckBoxes4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v41)).EndInit();
            this.panelRight6.ResumeLayout(false);
            this.panelRight6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k3)).EndInit();
            this.panelCheckBoxes3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v31)).EndInit();
            this.panelRight5.ResumeLayout(false);
            this.panelRight5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k2)).EndInit();
            this.panelCheckBoxes2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v21)).EndInit();
            this.panelKommentar.ResumeLayout(false);
            this.panelKommentar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k1)).EndInit();
            this.panelCheckBoxes1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v11)).EndInit();
            this.grpPersönlicheSachen.ResumeLayout(false);
            this.grpPersönlicheSachen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSonstiges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBrille)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInsulinPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHörgerät)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahnprotOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahnprotUK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog schließen überwachen
		/// </summary>
		//----------------------------------------------------------------------------
		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !_canClose;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Benötigte Felder setzen
		/// </summary>
		//----------------------------------------------------------------------------
		protected void RequiredFields()
		{
			GuiUtil.ValidateRequired(cbETo);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Felder validieren
		/// </summary>
		//----------------------------------------------------------------------------
		private bool ValidateFields()
		{
			bool bError = false;
			bool bInfo = true;

			// cbETo
			GuiUtil.ValidateField(cbETo, (cbETo.Value != null),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			return !bError;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog akzeptieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (!ValidateFields())
				return;

			_canClose = true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog abbrechen
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			_canClose = true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Einrichtung
		/// </summary>
		//----------------------------------------------------------------------------
		public Guid Einrichtung
		{
			get	{	return (Guid)cbETo.Value;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Bemerkung
		/// </summary>
		//----------------------------------------------------------------------------
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

        private void frmPrintPflegebegleitschreibenInfo_Load(object sender, EventArgs e)
        {

        }
	}
}
