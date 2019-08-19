using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using Infragistics.Win;
using System.Text;
using PMDS.Global.db.Global;


namespace PMDS.GUI
{


    public class frmManageQuickFilter : QS2.Desktop.ControlManagment.baseForm 
    {

        private QuickFilterManager _manager = new QuickFilterManager();
        public PMDS.Global.db.ERSystem.UISitemaps UISitemaps1 = new Global.db.ERSystem.UISitemaps();


        private dsQuickFilter.QuickFilterDataTable _dt = null;
        private PMDS.GUI.ucTerminFilterPicker ucTerminFilterPicker1;
        private System.Windows.Forms.NumericUpDown nupVorher;
        private System.Windows.Forms.NumericUpDown nupNachher;
        private System.Windows.Forms.CheckBox checkBox1;
        private QS2.Desktop.ControlManagment.BaseLableWin lblVorher;
        private QS2.Desktop.ControlManagment.BaseLableWin lblNachher;
        private PMDS.GUI.BaseControls.QuickFilterCombo cbFilter;
        private QS2.Desktop.ControlManagment.BaseLableWin label1;
        private QS2.Desktop.ControlManagment.BasePanel panel1;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbToolTip;
        private QS2.Desktop.ControlManagment.BaseLableWin label2;
        private QS2.Desktop.ControlManagment.BaseLableWin label3;
        private PMDS.GUI.AbteilungsAuswahlCombo cbAbteilung;
        private QS2.Desktop.ControlManagment.BaseGroupBoxWin groupBox1;
        private CheckBox cbIntervention;
        private CheckBox cbÜbergabe;
        private ucButton btnDeletexyxyxyxyxyxyx;
        private ucButton btnAdd;
        private ucButton btnUmbenennen;
        private QS2.Desktop.ControlManagment.BaseLableWin label4;
        private QS2.Desktop.ControlManagment.BaseMaskEdit tbReihenfolge;
        private qs2.core.vb.cboLayout cboLayout1;
        private QS2.Desktop.ControlManagment.BaseLableWin lblKeyQuickFilter;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtKeyQuickFilter;
        private ucButton btnSave;
        private ucButton btnClose;
        private CheckBox chkBereichIntervention;
        private CheckBox chkBereichÜbergabe;
        private CheckBox chkBereichDekurs;
        private CheckBox chkBenutzenInDekursJN;
        private QS2.Desktop.ControlManagment.BaseLableWin baseLableWin3;
        private QS2.Desktop.ControlManagment.BaseLableWin baseLableWin2;
        private QS2.Desktop.ControlManagment.BaseLableWin baseLableWin1;
        private ErrorProvider errorProvider1;
        private CheckBox chkIsStandard;
        private QS2.Desktop.ControlManagment.BaseButton btnCopyAndPaste;
        public BaseControls.AuswahlGruppeComboMulti cboBerufsstand;
        private QS2.Desktop.ControlManagment.BaseLableWin baseLableWin4;
        private IContainer components;

        public bool IsInitialized = false;







        public frmManageQuickFilter()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageQuickFilter));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn106 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn107 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn108 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn103 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn104 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn105 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn100 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn101 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn102 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn97 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn98 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn99 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand5 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn94 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn95 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn96 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand6 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn91 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn92 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn93 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand7 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn88 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn89 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn90 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand8 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn85 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn86 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn87 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand9 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn82 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn83 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn84 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand10 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn79 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn80 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn81 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand11 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn76 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn77 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn78 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand12 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn73 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn74 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn75 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand13 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn70 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn71 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn72 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand14 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn67 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn68 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn69 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand15 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn64 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn65 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn66 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand16 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn61 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn62 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn63 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand17 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn58 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn59 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn60 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand18 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn55 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn56 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn57 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand19 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn52 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn53 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn54 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand20 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn51 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand21 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand22 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand23 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand24 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand25 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand26 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand27 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand28 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand29 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand30 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand31 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand32 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand33 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand34 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand35 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand36 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Abteilung", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKlinik");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.lblVorher = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblNachher = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.nupVorher = new System.Windows.Forms.NumericUpDown();
            this.nupNachher = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.panel1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.cboBerufsstand = new PMDS.GUI.BaseControls.AuswahlGruppeComboMulti();
            this.baseLableWin4 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.chkIsStandard = new System.Windows.Forms.CheckBox();
            this.tbReihenfolge = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.txtKeyQuickFilter = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.tbToolTip = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblKeyQuickFilter = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.cboLayout1 = new qs2.core.vb.cboLayout();
            this.label4 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.groupBox1 = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.baseLableWin3 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.baseLableWin2 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.baseLableWin1 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.chkBereichDekurs = new System.Windows.Forms.CheckBox();
            this.chkBenutzenInDekursJN = new System.Windows.Forms.CheckBox();
            this.chkBereichÜbergabe = new System.Windows.Forms.CheckBox();
            this.chkBereichIntervention = new System.Windows.Forms.CheckBox();
            this.cbIntervention = new System.Windows.Forms.CheckBox();
            this.cbÜbergabe = new System.Windows.Forms.CheckBox();
            this.label2 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.ucTerminFilterPicker1 = new PMDS.GUI.ucTerminFilterPicker();
            this.label3 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCopyAndPaste = new QS2.Desktop.ControlManagment.BaseButton();
            this.cbAbteilung = new PMDS.GUI.AbteilungsAuswahlCombo();
            this.cbFilter = new PMDS.GUI.BaseControls.QuickFilterCombo();
            this.btnClose = new PMDS.GUI.ucButton(this.components);
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.btnDeletexyxyxyxyxyxyx = new PMDS.GUI.ucButton(this.components);
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnUmbenennen = new PMDS.GUI.ucButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nupVorher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupNachher)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyQuickFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbToolTip)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVorher
            // 
            this.lblVorher.Enabled = false;
            this.lblVorher.Location = new System.Drawing.Point(8, 32);
            this.lblVorher.Name = "lblVorher";
            this.lblVorher.Size = new System.Drawing.Size(100, 16);
            this.lblVorher.TabIndex = 4;
            this.lblVorher.Text = "Tage vor Heute";
            // 
            // lblNachher
            // 
            this.lblNachher.Enabled = false;
            this.lblNachher.Location = new System.Drawing.Point(8, 55);
            this.lblNachher.Name = "lblNachher";
            this.lblNachher.Size = new System.Drawing.Size(100, 16);
            this.lblNachher.TabIndex = 5;
            this.lblNachher.Text = "Tage nach Heute";
            // 
            // nupVorher
            // 
            this.nupVorher.Enabled = false;
            this.nupVorher.Location = new System.Drawing.Point(108, 32);
            this.nupVorher.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nupVorher.Name = "nupVorher";
            this.nupVorher.Size = new System.Drawing.Size(72, 20);
            this.nupVorher.TabIndex = 1;
            // 
            // nupNachher
            // 
            this.nupNachher.Enabled = false;
            this.nupNachher.Location = new System.Drawing.Point(108, 55);
            this.nupNachher.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nupNachher.Name = "nupNachher";
            this.nupNachher.Size = new System.Drawing.Size(72, 20);
            this.nupNachher.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(8, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 24);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Zeitraum aktivieren";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Quickfilter";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cboBerufsstand);
            this.panel1.Controls.Add(this.baseLableWin4);
            this.panel1.Controls.Add(this.chkIsStandard);
            this.panel1.Controls.Add(this.tbReihenfolge);
            this.panel1.Controls.Add(this.nupVorher);
            this.panel1.Controls.Add(this.nupNachher);
            this.panel1.Controls.Add(this.txtKeyQuickFilter);
            this.panel1.Controls.Add(this.tbToolTip);
            this.panel1.Controls.Add(this.lblKeyQuickFilter);
            this.panel1.Controls.Add(this.cboLayout1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ucTerminFilterPicker1);
            this.panel1.Controls.Add(this.lblVorher);
            this.panel1.Controls.Add(this.lblNachher);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Location = new System.Drawing.Point(14, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 531);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            // 
            // cboBerufsstand
            // 
            this.cboBerufsstand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBerufsstand.BackColor = System.Drawing.Color.Transparent;
            this.cboBerufsstand.Location = new System.Drawing.Point(74, 134);
            this.cboBerufsstand.Name = "cboBerufsstand";
            this.cboBerufsstand.Size = new System.Drawing.Size(447, 23);
            this.cboBerufsstand.TabIndex = 19;
            this.cboBerufsstand.TypeMulti = PMDS.GUI.BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Berufsgruppe;
            // 
            // baseLableWin4
            // 
            this.baseLableWin4.Location = new System.Drawing.Point(8, 137);
            this.baseLableWin4.Name = "baseLableWin4";
            this.baseLableWin4.Size = new System.Drawing.Size(100, 16);
            this.baseLableWin4.TabIndex = 20;
            this.baseLableWin4.Text = "Berufsstand";
            // 
            // chkIsStandard
            // 
            this.chkIsStandard.Location = new System.Drawing.Point(9, 108);
            this.chkIsStandard.Name = "chkIsStandard";
            this.chkIsStandard.Size = new System.Drawing.Size(125, 15);
            this.chkIsStandard.TabIndex = 18;
            this.chkIsStandard.Text = "Standard";
            // 
            // tbReihenfolge
            // 
            this.tbReihenfolge.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.tbReihenfolge.Location = new System.Drawing.Point(451, 108);
            this.tbReihenfolge.Name = "tbReihenfolge";
            this.tbReihenfolge.NonAutoSizeHeight = 20;
            this.tbReihenfolge.Size = new System.Drawing.Size(70, 20);
            this.tbReihenfolge.TabIndex = 4;
            // 
            // txtKeyQuickFilter
            // 
            this.txtKeyQuickFilter.Location = new System.Drawing.Point(101, 305);
            this.txtKeyQuickFilter.Name = "txtKeyQuickFilter";
            this.txtKeyQuickFilter.Size = new System.Drawing.Size(375, 21);
            this.txtKeyQuickFilter.TabIndex = 6;
            // 
            // tbToolTip
            // 
            this.tbToolTip.Location = new System.Drawing.Point(8, 177);
            this.tbToolTip.MaxLength = 255;
            this.tbToolTip.Multiline = true;
            this.tbToolTip.Name = "tbToolTip";
            this.tbToolTip.Size = new System.Drawing.Size(516, 121);
            this.tbToolTip.TabIndex = 5;
            // 
            // lblKeyQuickFilter
            // 
            this.lblKeyQuickFilter.Location = new System.Drawing.Point(8, 307);
            this.lblKeyQuickFilter.Name = "lblKeyQuickFilter";
            this.lblKeyQuickFilter.Size = new System.Drawing.Size(100, 16);
            this.lblKeyQuickFilter.TabIndex = 17;
            this.lblKeyQuickFilter.Text = "Key Quick-Filter";
            // 
            // cboLayout1
            // 
            this.cboLayout1.BackColor = System.Drawing.Color.Transparent;
            this.cboLayout1.Location = new System.Drawing.Point(8, 326);
            this.cboLayout1.Name = "cboLayout1";
            this.cboLayout1.Size = new System.Drawing.Size(523, 27);
            this.cboLayout1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(349, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Position von links";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.baseLableWin3);
            this.groupBox1.Controls.Add(this.baseLableWin2);
            this.groupBox1.Controls.Add(this.baseLableWin1);
            this.groupBox1.Controls.Add(this.chkBereichDekurs);
            this.groupBox1.Controls.Add(this.chkBenutzenInDekursJN);
            this.groupBox1.Controls.Add(this.chkBereichÜbergabe);
            this.groupBox1.Controls.Add(this.chkBereichIntervention);
            this.groupBox1.Controls.Add(this.cbIntervention);
            this.groupBox1.Controls.Add(this.cbÜbergabe);
            this.groupBox1.Location = new System.Drawing.Point(263, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 80);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "sichtbar in";
            // 
            // baseLableWin3
            // 
            this.baseLableWin3.Location = new System.Drawing.Point(145, 58);
            this.baseLableWin3.Name = "baseLableWin3";
            this.baseLableWin3.Size = new System.Drawing.Size(22, 16);
            this.baseLableWin3.TabIndex = 20;
            this.baseLableWin3.Text = "-->";
            // 
            // baseLableWin2
            // 
            this.baseLableWin2.Location = new System.Drawing.Point(145, 39);
            this.baseLableWin2.Name = "baseLableWin2";
            this.baseLableWin2.Size = new System.Drawing.Size(22, 16);
            this.baseLableWin2.TabIndex = 19;
            this.baseLableWin2.Text = "-->";
            // 
            // baseLableWin1
            // 
            this.baseLableWin1.Location = new System.Drawing.Point(145, 20);
            this.baseLableWin1.Name = "baseLableWin1";
            this.baseLableWin1.Size = new System.Drawing.Size(22, 16);
            this.baseLableWin1.TabIndex = 18;
            this.baseLableWin1.Text = "-->";
            // 
            // chkBereichDekurs
            // 
            this.chkBereichDekurs.Location = new System.Drawing.Point(183, 57);
            this.chkBereichDekurs.Name = "chkBereichDekurs";
            this.chkBereichDekurs.Size = new System.Drawing.Size(72, 17);
            this.chkBereichDekurs.TabIndex = 5;
            this.chkBereichDekurs.Text = "Bereich";
            // 
            // chkBenutzenInDekursJN
            // 
            this.chkBenutzenInDekursJN.Location = new System.Drawing.Point(18, 57);
            this.chkBenutzenInDekursJN.Name = "chkBenutzenInDekursJN";
            this.chkBenutzenInDekursJN.Size = new System.Drawing.Size(125, 17);
            this.chkBenutzenInDekursJN.TabIndex = 4;
            this.chkBenutzenInDekursJN.Text = "Dekurs Einzel";
            // 
            // chkBereichÜbergabe
            // 
            this.chkBereichÜbergabe.Location = new System.Drawing.Point(183, 37);
            this.chkBereichÜbergabe.Name = "chkBereichÜbergabe";
            this.chkBereichÜbergabe.Size = new System.Drawing.Size(72, 17);
            this.chkBereichÜbergabe.TabIndex = 3;
            this.chkBereichÜbergabe.Text = "Bereich";
            // 
            // chkBereichIntervention
            // 
            this.chkBereichIntervention.Location = new System.Drawing.Point(183, 19);
            this.chkBereichIntervention.Name = "chkBereichIntervention";
            this.chkBereichIntervention.Size = new System.Drawing.Size(72, 15);
            this.chkBereichIntervention.TabIndex = 1;
            this.chkBereichIntervention.Text = "Bereich";
            // 
            // cbIntervention
            // 
            this.cbIntervention.Location = new System.Drawing.Point(18, 19);
            this.cbIntervention.Name = "cbIntervention";
            this.cbIntervention.Size = new System.Drawing.Size(125, 15);
            this.cbIntervention.TabIndex = 0;
            this.cbIntervention.Text = "Intervention Einzel";
            // 
            // cbÜbergabe
            // 
            this.cbÜbergabe.Location = new System.Drawing.Point(18, 37);
            this.cbÜbergabe.Name = "cbÜbergabe";
            this.cbÜbergabe.Size = new System.Drawing.Size(125, 17);
            this.cbÜbergabe.TabIndex = 2;
            this.cbÜbergabe.Text = "Übergabe Einzel";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tooltip";
            // 
            // ucTerminFilterPicker1
            // 
            this.ucTerminFilterPicker1.Abzeichnen = -1;
            this.ucTerminFilterPicker1.BackColor = System.Drawing.Color.Gainsboro;
            this.ucTerminFilterPicker1.Berufsstand = ((System.Collections.Generic.List<System.Guid>)(resources.GetObject("ucTerminFilterPicker1.Berufsstand")));
            this.ucTerminFilterPicker1.HerkunftPlanungsEintrag = ((System.Collections.Generic.List<int>)(resources.GetObject("ucTerminFilterPicker1.HerkunftPlanungsEintrag")));
            this.ucTerminFilterPicker1.IDBezug = System.Guid.Empty;
            this.ucTerminFilterPicker1.IDMassnahme = System.Guid.Empty;
            this.ucTerminFilterPicker1.Location = new System.Drawing.Point(8, 364);
            this.ucTerminFilterPicker1.MASSNAHMEN = new System.Guid[0];
            this.ucTerminFilterPicker1.Name = "ucTerminFilterPicker1";
            this.ucTerminFilterPicker1.PlanungsEinträge = ((System.Collections.Generic.List<int>)(resources.GetObject("ucTerminFilterPicker1.PlanungsEinträge")));
            this.ucTerminFilterPicker1.ShowBerufsstand = false;
            this.ucTerminFilterPicker1.ShowBezug = false;
            this.ucTerminFilterPicker1.ShowCC = -1;
            this.ucTerminFilterPicker1.ShowHerkunftPlanungsEintrag = false;
            this.ucTerminFilterPicker1.ShowPlanungsEinträgeJN = false;
            this.ucTerminFilterPicker1.ShowZeitbezugJN = false;
            this.ucTerminFilterPicker1.ShowZusatzwerte = false;
            this.ucTerminFilterPicker1.Size = new System.Drawing.Size(516, 104);
            this.ucTerminFilterPicker1.TabIndex = 8;
            this.ucTerminFilterPicker1.WichtigFür = ((System.Collections.Generic.List<System.Guid>)(resources.GetObject("ucTerminFilterPicker1.WichtigFür")));
            this.ucTerminFilterPicker1.WichtigFürJN = false;
            this.ucTerminFilterPicker1.ZeitbezugJNA = ((System.Collections.Generic.List<int>)(resources.GetObject("ucTerminFilterPicker1.ZeitbezugJNA")));
            this.ucTerminFilterPicker1.Zusatzwerte = ((System.Collections.Generic.List<string>)(resources.GetObject("ucTerminFilterPicker1.Zusatzwerte")));
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Abteilung";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnCopyAndPaste
            // 
            this.btnCopyAndPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCopyAndPaste.Appearance = appearance1;
            this.btnCopyAndPaste.AutoWorkLayout = false;
            this.btnCopyAndPaste.IsStandardControl = false;
            this.btnCopyAndPaste.Location = new System.Drawing.Point(528, 62);
            this.btnCopyAndPaste.Name = "btnCopyAndPaste";
            this.btnCopyAndPaste.Size = new System.Drawing.Size(23, 21);
            this.btnCopyAndPaste.TabIndex = 106;
            this.btnCopyAndPaste.Click += new System.EventHandler(this.btnCopyAndPaste_Click_1);
            // 
            // cbAbteilung
            // 
            this.cbAbteilung.AutoSize = false;
            ultraGridBand1.ColHeadersVisible = false;
            ultraGridColumn106.Header.VisiblePosition = 0;
            ultraGridColumn107.Header.VisiblePosition = 1;
            ultraGridColumn107.Hidden = true;
            ultraGridColumn108.Header.VisiblePosition = 2;
            ultraGridColumn108.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn106,
            ultraGridColumn107,
            ultraGridColumn108});
            ultraGridBand1.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand1.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand2.ColHeadersVisible = false;
            ultraGridColumn103.Header.VisiblePosition = 0;
            ultraGridColumn104.Header.VisiblePosition = 1;
            ultraGridColumn104.Hidden = true;
            ultraGridColumn105.Header.VisiblePosition = 2;
            ultraGridColumn105.Hidden = true;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn103,
            ultraGridColumn104,
            ultraGridColumn105});
            ultraGridBand2.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand2.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand2.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand3.ColHeadersVisible = false;
            ultraGridColumn100.Header.VisiblePosition = 0;
            ultraGridColumn101.Header.VisiblePosition = 1;
            ultraGridColumn101.Hidden = true;
            ultraGridColumn102.Header.VisiblePosition = 2;
            ultraGridColumn102.Hidden = true;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn100,
            ultraGridColumn101,
            ultraGridColumn102});
            ultraGridBand3.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand3.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand3.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand4.ColHeadersVisible = false;
            ultraGridColumn97.Header.VisiblePosition = 0;
            ultraGridColumn98.Header.VisiblePosition = 1;
            ultraGridColumn98.Hidden = true;
            ultraGridColumn99.Header.VisiblePosition = 2;
            ultraGridColumn99.Hidden = true;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn97,
            ultraGridColumn98,
            ultraGridColumn99});
            ultraGridBand4.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand4.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand4.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand5.ColHeadersVisible = false;
            ultraGridColumn94.Header.VisiblePosition = 0;
            ultraGridColumn95.Header.VisiblePosition = 1;
            ultraGridColumn95.Hidden = true;
            ultraGridColumn96.Header.VisiblePosition = 2;
            ultraGridColumn96.Hidden = true;
            ultraGridBand5.Columns.AddRange(new object[] {
            ultraGridColumn94,
            ultraGridColumn95,
            ultraGridColumn96});
            ultraGridBand5.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand5.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand5.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand6.ColHeadersVisible = false;
            ultraGridColumn91.Header.VisiblePosition = 0;
            ultraGridColumn92.Header.VisiblePosition = 1;
            ultraGridColumn92.Hidden = true;
            ultraGridColumn93.Header.VisiblePosition = 2;
            ultraGridColumn93.Hidden = true;
            ultraGridBand6.Columns.AddRange(new object[] {
            ultraGridColumn91,
            ultraGridColumn92,
            ultraGridColumn93});
            ultraGridBand6.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand6.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand6.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand7.ColHeadersVisible = false;
            ultraGridColumn88.Header.VisiblePosition = 0;
            ultraGridColumn89.Header.VisiblePosition = 1;
            ultraGridColumn89.Hidden = true;
            ultraGridColumn90.Header.VisiblePosition = 2;
            ultraGridColumn90.Hidden = true;
            ultraGridBand7.Columns.AddRange(new object[] {
            ultraGridColumn88,
            ultraGridColumn89,
            ultraGridColumn90});
            ultraGridBand7.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand7.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand7.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand8.ColHeadersVisible = false;
            ultraGridColumn85.Header.VisiblePosition = 0;
            ultraGridColumn86.Header.VisiblePosition = 1;
            ultraGridColumn86.Hidden = true;
            ultraGridColumn87.Header.VisiblePosition = 2;
            ultraGridColumn87.Hidden = true;
            ultraGridBand8.Columns.AddRange(new object[] {
            ultraGridColumn85,
            ultraGridColumn86,
            ultraGridColumn87});
            ultraGridBand8.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand8.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand8.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand9.ColHeadersVisible = false;
            ultraGridColumn82.Header.VisiblePosition = 0;
            ultraGridColumn83.Header.VisiblePosition = 1;
            ultraGridColumn83.Hidden = true;
            ultraGridColumn84.Header.VisiblePosition = 2;
            ultraGridColumn84.Hidden = true;
            ultraGridBand9.Columns.AddRange(new object[] {
            ultraGridColumn82,
            ultraGridColumn83,
            ultraGridColumn84});
            ultraGridBand9.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand9.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand9.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand10.ColHeadersVisible = false;
            ultraGridColumn79.Header.VisiblePosition = 0;
            ultraGridColumn80.Header.VisiblePosition = 1;
            ultraGridColumn80.Hidden = true;
            ultraGridColumn81.Header.VisiblePosition = 2;
            ultraGridColumn81.Hidden = true;
            ultraGridBand10.Columns.AddRange(new object[] {
            ultraGridColumn79,
            ultraGridColumn80,
            ultraGridColumn81});
            ultraGridBand10.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand10.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand10.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand11.ColHeadersVisible = false;
            ultraGridColumn76.Header.VisiblePosition = 0;
            ultraGridColumn77.Header.VisiblePosition = 1;
            ultraGridColumn77.Hidden = true;
            ultraGridColumn78.Header.VisiblePosition = 2;
            ultraGridColumn78.Hidden = true;
            ultraGridBand11.Columns.AddRange(new object[] {
            ultraGridColumn76,
            ultraGridColumn77,
            ultraGridColumn78});
            ultraGridBand11.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand11.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand11.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand12.ColHeadersVisible = false;
            ultraGridColumn73.Header.VisiblePosition = 0;
            ultraGridColumn74.Header.VisiblePosition = 1;
            ultraGridColumn74.Hidden = true;
            ultraGridColumn75.Header.VisiblePosition = 2;
            ultraGridColumn75.Hidden = true;
            ultraGridBand12.Columns.AddRange(new object[] {
            ultraGridColumn73,
            ultraGridColumn74,
            ultraGridColumn75});
            ultraGridBand12.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand12.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand12.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand13.ColHeadersVisible = false;
            ultraGridColumn70.Header.VisiblePosition = 0;
            ultraGridColumn71.Header.VisiblePosition = 1;
            ultraGridColumn71.Hidden = true;
            ultraGridColumn72.Header.VisiblePosition = 2;
            ultraGridColumn72.Hidden = true;
            ultraGridBand13.Columns.AddRange(new object[] {
            ultraGridColumn70,
            ultraGridColumn71,
            ultraGridColumn72});
            ultraGridBand13.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand13.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand13.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand14.ColHeadersVisible = false;
            ultraGridColumn67.Header.VisiblePosition = 0;
            ultraGridColumn68.Header.VisiblePosition = 1;
            ultraGridColumn68.Hidden = true;
            ultraGridColumn69.Header.VisiblePosition = 2;
            ultraGridColumn69.Hidden = true;
            ultraGridBand14.Columns.AddRange(new object[] {
            ultraGridColumn67,
            ultraGridColumn68,
            ultraGridColumn69});
            ultraGridBand14.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand14.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand14.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand15.ColHeadersVisible = false;
            ultraGridColumn64.Header.VisiblePosition = 0;
            ultraGridColumn65.Header.VisiblePosition = 1;
            ultraGridColumn65.Hidden = true;
            ultraGridColumn66.Header.VisiblePosition = 2;
            ultraGridColumn66.Hidden = true;
            ultraGridBand15.Columns.AddRange(new object[] {
            ultraGridColumn64,
            ultraGridColumn65,
            ultraGridColumn66});
            ultraGridBand15.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand15.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand15.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand16.ColHeadersVisible = false;
            ultraGridColumn61.Header.VisiblePosition = 0;
            ultraGridColumn62.Header.VisiblePosition = 1;
            ultraGridColumn62.Hidden = true;
            ultraGridColumn63.Header.VisiblePosition = 2;
            ultraGridColumn63.Hidden = true;
            ultraGridBand16.Columns.AddRange(new object[] {
            ultraGridColumn61,
            ultraGridColumn62,
            ultraGridColumn63});
            ultraGridBand16.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand16.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand16.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand17.ColHeadersVisible = false;
            ultraGridColumn58.Header.VisiblePosition = 0;
            ultraGridColumn59.Header.VisiblePosition = 1;
            ultraGridColumn59.Hidden = true;
            ultraGridColumn60.Header.VisiblePosition = 2;
            ultraGridColumn60.Hidden = true;
            ultraGridBand17.Columns.AddRange(new object[] {
            ultraGridColumn58,
            ultraGridColumn59,
            ultraGridColumn60});
            ultraGridBand17.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand17.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand17.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand18.ColHeadersVisible = false;
            ultraGridColumn55.Header.VisiblePosition = 0;
            ultraGridColumn56.Header.VisiblePosition = 1;
            ultraGridColumn56.Hidden = true;
            ultraGridColumn57.Header.VisiblePosition = 2;
            ultraGridColumn57.Hidden = true;
            ultraGridBand18.Columns.AddRange(new object[] {
            ultraGridColumn55,
            ultraGridColumn56,
            ultraGridColumn57});
            ultraGridBand18.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand18.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand18.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand19.ColHeadersVisible = false;
            ultraGridColumn52.Header.VisiblePosition = 0;
            ultraGridColumn53.Header.VisiblePosition = 1;
            ultraGridColumn53.Hidden = true;
            ultraGridColumn54.Header.VisiblePosition = 2;
            ultraGridColumn54.Hidden = true;
            ultraGridBand19.Columns.AddRange(new object[] {
            ultraGridColumn52,
            ultraGridColumn53,
            ultraGridColumn54});
            ultraGridBand19.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand19.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand19.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand20.ColHeadersVisible = false;
            ultraGridColumn49.Header.VisiblePosition = 0;
            ultraGridColumn50.Header.VisiblePosition = 1;
            ultraGridColumn50.Hidden = true;
            ultraGridColumn51.Header.VisiblePosition = 2;
            ultraGridColumn51.Hidden = true;
            ultraGridBand20.Columns.AddRange(new object[] {
            ultraGridColumn49,
            ultraGridColumn50,
            ultraGridColumn51});
            ultraGridBand20.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand20.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand20.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand21.ColHeadersVisible = false;
            ultraGridColumn46.Header.VisiblePosition = 0;
            ultraGridColumn47.Header.VisiblePosition = 1;
            ultraGridColumn47.Hidden = true;
            ultraGridColumn48.Header.VisiblePosition = 2;
            ultraGridColumn48.Hidden = true;
            ultraGridBand21.Columns.AddRange(new object[] {
            ultraGridColumn46,
            ultraGridColumn47,
            ultraGridColumn48});
            ultraGridBand21.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand21.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand21.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand22.ColHeadersVisible = false;
            ultraGridColumn43.Header.VisiblePosition = 0;
            ultraGridColumn44.Header.VisiblePosition = 1;
            ultraGridColumn44.Hidden = true;
            ultraGridColumn45.Header.VisiblePosition = 2;
            ultraGridColumn45.Hidden = true;
            ultraGridBand22.Columns.AddRange(new object[] {
            ultraGridColumn43,
            ultraGridColumn44,
            ultraGridColumn45});
            ultraGridBand22.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand22.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand22.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand23.ColHeadersVisible = false;
            ultraGridColumn40.Header.VisiblePosition = 0;
            ultraGridColumn41.Header.VisiblePosition = 1;
            ultraGridColumn41.Hidden = true;
            ultraGridColumn42.Header.VisiblePosition = 2;
            ultraGridColumn42.Hidden = true;
            ultraGridBand23.Columns.AddRange(new object[] {
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42});
            ultraGridBand23.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand23.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand23.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand24.ColHeadersVisible = false;
            ultraGridColumn37.Header.VisiblePosition = 0;
            ultraGridColumn38.Header.VisiblePosition = 1;
            ultraGridColumn38.Hidden = true;
            ultraGridColumn39.Header.VisiblePosition = 2;
            ultraGridColumn39.Hidden = true;
            ultraGridBand24.Columns.AddRange(new object[] {
            ultraGridColumn37,
            ultraGridColumn38,
            ultraGridColumn39});
            ultraGridBand24.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand24.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand24.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand25.ColHeadersVisible = false;
            ultraGridColumn34.Header.VisiblePosition = 0;
            ultraGridColumn34.Width = 317;
            ultraGridColumn35.Header.VisiblePosition = 1;
            ultraGridColumn35.Hidden = true;
            ultraGridColumn36.Header.VisiblePosition = 2;
            ultraGridColumn36.Hidden = true;
            ultraGridBand25.Columns.AddRange(new object[] {
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36});
            ultraGridBand25.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand25.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand25.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand26.ColHeadersVisible = false;
            ultraGridColumn31.Header.VisiblePosition = 0;
            ultraGridColumn32.Header.VisiblePosition = 1;
            ultraGridColumn32.Hidden = true;
            ultraGridColumn33.Header.VisiblePosition = 2;
            ultraGridColumn33.Hidden = true;
            ultraGridBand26.Columns.AddRange(new object[] {
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33});
            ultraGridBand26.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand26.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand26.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand27.ColHeadersVisible = false;
            ultraGridColumn28.Header.VisiblePosition = 0;
            ultraGridColumn29.Header.VisiblePosition = 1;
            ultraGridColumn29.Hidden = true;
            ultraGridColumn30.Header.VisiblePosition = 2;
            ultraGridColumn30.Hidden = true;
            ultraGridBand27.Columns.AddRange(new object[] {
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30});
            ultraGridBand27.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand27.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand27.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand28.ColHeadersVisible = false;
            ultraGridColumn25.Header.VisiblePosition = 0;
            ultraGridColumn26.Header.VisiblePosition = 1;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn27.Header.VisiblePosition = 2;
            ultraGridColumn27.Hidden = true;
            ultraGridBand28.Columns.AddRange(new object[] {
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27});
            ultraGridBand28.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand28.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand28.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand29.ColHeadersVisible = false;
            ultraGridColumn22.Header.VisiblePosition = 0;
            ultraGridColumn23.Header.VisiblePosition = 1;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.Header.VisiblePosition = 2;
            ultraGridColumn24.Hidden = true;
            ultraGridBand29.Columns.AddRange(new object[] {
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24});
            ultraGridBand29.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand29.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand29.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand30.ColHeadersVisible = false;
            ultraGridColumn19.Header.VisiblePosition = 0;
            ultraGridColumn20.Header.VisiblePosition = 1;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.Header.VisiblePosition = 2;
            ultraGridColumn21.Hidden = true;
            ultraGridBand30.Columns.AddRange(new object[] {
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21});
            ultraGridBand30.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand30.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand30.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand31.ColHeadersVisible = false;
            ultraGridColumn16.Header.VisiblePosition = 0;
            ultraGridColumn17.Header.VisiblePosition = 1;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.Header.VisiblePosition = 2;
            ultraGridColumn18.Hidden = true;
            ultraGridBand31.Columns.AddRange(new object[] {
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18});
            ultraGridBand31.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand31.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand31.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand32.ColHeadersVisible = false;
            ultraGridColumn13.Header.VisiblePosition = 0;
            ultraGridColumn14.Header.VisiblePosition = 1;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.Header.VisiblePosition = 2;
            ultraGridColumn15.Hidden = true;
            ultraGridBand32.Columns.AddRange(new object[] {
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15});
            ultraGridBand32.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand32.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand32.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand33.ColHeadersVisible = false;
            ultraGridColumn10.Header.VisiblePosition = 0;
            ultraGridColumn11.Header.VisiblePosition = 1;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.VisiblePosition = 2;
            ultraGridColumn12.Hidden = true;
            ultraGridBand33.Columns.AddRange(new object[] {
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12});
            ultraGridBand33.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand33.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand33.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand34.ColHeadersVisible = false;
            ultraGridColumn7.Header.VisiblePosition = 0;
            ultraGridColumn8.Header.VisiblePosition = 1;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.Header.VisiblePosition = 2;
            ultraGridColumn9.Hidden = true;
            ultraGridBand34.Columns.AddRange(new object[] {
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
            ultraGridBand34.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand34.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand34.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand35.ColHeadersVisible = false;
            ultraGridColumn4.Header.VisiblePosition = 0;
            ultraGridColumn5.Header.VisiblePosition = 1;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.VisiblePosition = 2;
            ultraGridColumn6.Hidden = true;
            ultraGridBand35.Columns.AddRange(new object[] {
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            ultraGridBand35.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand35.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand35.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            ultraGridBand36.ColHeadersVisible = false;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridBand36.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3});
            ultraGridBand36.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand36.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            ultraGridBand36.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand5);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand6);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand7);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand8);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand9);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand10);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand11);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand12);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand13);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand14);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand15);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand16);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand17);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand18);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand19);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand20);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand21);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand22);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand23);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand24);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand25);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand26);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand27);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand28);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand29);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand30);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand31);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand32);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand33);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand34);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand35);
            this.cbAbteilung.DisplayLayout.BandsSerializer.Add(ultraGridBand36);
            this.cbAbteilung.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cbAbteilung.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.cbAbteilung.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            this.cbAbteilung.DisplayMember = "Bezeichnung";
            this.cbAbteilung.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cbAbteilung.Location = new System.Drawing.Point(14, 21);
            this.cbAbteilung.Name = "cbAbteilung";
            this.cbAbteilung.Size = new System.Drawing.Size(317, 23);
            this.cbAbteilung.TabIndex = 0;
            this.cbAbteilung.ValueMember = "ID";
            this.cbAbteilung.ValueChanged += new System.EventHandler(this.cbAbteilung_ValueChanged);
            // 
            // cbFilter
            // 
            this.cbFilter.DISPLAY_TEXT = "";
            this.cbFilter.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbFilter.Enabled = false;
            this.cbFilter.ID = System.Guid.Empty;
            this.cbFilter.Location = new System.Drawing.Point(14, 62);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(512, 21);
            this.cbFilter.TabIndex = 1;
            this.cbFilter.ValueChanged += new System.EventHandler(this.cbFilter_ValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnClose.Appearance = appearance2;
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.DoOnClick = true;
            this.btnClose.IsStandardControl = true;
            this.btnClose.Location = new System.Drawing.Point(518, 628);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 32);
            this.btnClose.TabIndex = 104;
            this.btnClose.TabStop = false;
            this.btnClose.TYPE = PMDS.GUI.ucButton.ButtonType.beenden;
            this.btnClose.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance3;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DoOnClick = true;
            this.btnSave.IsStandardControl = true;
            this.btnSave.Location = new System.Drawing.Point(332, 628);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.TabIndex = 103;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnDeletexyxyxyxyxyxyx
            // 
            this.btnDeletexyxyxyxyxyxyx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDeletexyxyxyxyxyxyx.Appearance = appearance4;
            this.btnDeletexyxyxyxyxyxyx.AutoWorkLayout = false;
            this.btnDeletexyxyxyxyxyxyx.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDeletexyxyxyxyxyxyx.DoOnClick = true;
            this.btnDeletexyxyxyxyxyxyx.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDeletexyxyxyxyxyxyx.IsStandardControl = true;
            this.btnDeletexyxyxyxyxyxyx.Location = new System.Drawing.Point(106, 628);
            this.btnDeletexyxyxyxyxyxyx.Name = "btnDeletexyxyxyxyxyxyx";
            this.btnDeletexyxyxyxyxyxyx.Size = new System.Drawing.Size(91, 32);
            this.btnDeletexyxyxyxyxyxyx.TabIndex = 101;
            this.btnDeletexyxyxyxyxyxyx.TabStop = false;
            this.btnDeletexyxyxyxyxyxyx.Text = "Entfernen";
            this.btnDeletexyxyxyxyxyxyx.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDeletexyxyxyxyxyxyx.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDeletexyxyxyxyxyxyx.Click += new System.EventHandler(this.ucButton2_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance5;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(14, 628);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 32);
            this.btnAdd.TabIndex = 100;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Hinzufügen";
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.ucButton1_Click);
            // 
            // btnUmbenennen
            // 
            this.btnUmbenennen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUmbenennen.Appearance = appearance6;
            this.btnUmbenennen.AutoWorkLayout = false;
            this.btnUmbenennen.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUmbenennen.DoOnClick = true;
            this.btnUmbenennen.IsStandardControl = true;
            this.btnUmbenennen.Location = new System.Drawing.Point(231, 628);
            this.btnUmbenennen.Name = "btnUmbenennen";
            this.btnUmbenennen.Size = new System.Drawing.Size(100, 32);
            this.btnUmbenennen.TabIndex = 102;
            this.btnUmbenennen.TabStop = false;
            this.btnUmbenennen.Text = "Editieren";
            this.btnUmbenennen.TYPE = PMDS.GUI.ucButton.ButtonType.edit;
            this.btnUmbenennen.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUmbenennen.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmManageQuickFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(566, 666);
            this.Controls.Add(this.btnCopyAndPaste);
            this.Controls.Add(this.cbAbteilung);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDeletexyxyxyxyxyxyx);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUmbenennen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(582, 705);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(582, 705);
            this.Name = "frmManageQuickFilter";
            this.Text = "Quickfilter Verwaltung";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmManageQuickFilter_Closing);
            this.Load += new System.EventHandler(this.frmManageQuickFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupVorher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupNachher)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKeyQuickFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbToolTip)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void frmManageQuickFilter_Load(object sender, System.EventArgs e)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);
                _dt = _manager.Read(System.Guid.NewGuid());

                ucTerminFilterPicker1.initControl(true, eUITypeTermine.None);
                ucTerminFilterPicker1.panelAktualisieren.Visible = false;
                ucTerminFilterPicker1.panelClose.Visible = true;
                ShowHideMenu();

                this.cboLayout1.initControl(true, true, PMDS.Global.ENV.adminSecure );
                this.cboLayout1.LoadData();

                this.btnCopyAndPaste.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Kopieren, 32, 32);

            }
            catch(Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        public void ClearErrorProvider()
        {
            this.errorProvider1.SetError(this.txtKeyQuickFilter, "");

        }
        public bool ValidateData() 
        {
            this.ClearErrorProvider();

            if (this.txtKeyQuickFilter.Text.Trim() == "")
            {
                this.errorProvider1.SetError(this.txtKeyQuickFilter, "Eingabe erforderlich");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Key Quick-Filter: Eingabe erforderlich!", "Eingabe erforderlich", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
        private void ProcessQuickFiltSave() 
        {
            if(_dt == null)
                return;

            if (!this.ValidateData())
            {
                return;
            }

            FieldsToRow(ROW);
            _manager.Write(_dt);
        }

        private void ProcessVerlassen()
        {
            //ProcessQuickfilterSave();
            this.Close();
        }

        private PMDS.Global.db.Global.dsQuickFilter.QuickFilterRow ROW 
        {
            get 
            {
                return _dt[0];
            }
        }

        private void ProcessAdd() 
        {
            RBU.SingleTextEditForm frm = new RBU.SingleTextEditForm();
            frm.Text	= ENV.String("DIALOGTITLE_NEWQUICKFILTER");
            DialogResult res =  frm.ShowDialog();
            if(res != DialogResult.OK || frm.TEXT.Length < 1)
                return;

            Guid ID = _manager.AddNew(frm.TEXT, cbAbteilung.ABTEILUNG);
            _dt = _manager.Read(ID);
            RowToFields(ROW);
            RefreshList(ID);
        }

        private void RowToFields(dsQuickFilter.QuickFilterRow r)
        {
            if (!this.IsInitialized)
            {
                this.cboBerufsstand.initControl(BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Berufsgruppe, eUITypeTermine.None, false, 0, -100000, false);
                this.IsInitialized = true;
            }

            checkBox1.Checked = r.ZeitraumJN;
            nupNachher.Value = r.Tagenachher;
            nupVorher.Value = r.Tagevorher;
            if(r.MassnahmeJN)
                ucTerminFilterPicker1.IDMassnahme = r.IDEintrag;
            else
                ucTerminFilterPicker1.IDMassnahme = Guid.Empty;

            if(r.BezugspersonJN)
                ucTerminFilterPicker1.IDBezug = r.IDBenutzer;
            else
                ucTerminFilterPicker1.IDBezug = Guid.Empty;

            tbToolTip.Text = r.Tooltip.Trim();

            qs2.core.vb.dsLayout dsLayout1 = new qs2.core.vb.dsLayout();
            qs2.core.vb.compLayout compLayout1 = new qs2.core.vb.compLayout();
            compLayout1.initControl();
            System.Guid IDGuidTmpEmnpty = System.Guid.Empty;
            compLayout1.getLayout(ref dsLayout1, "", qs2.core.vb.compLayout.eSelLayoutGrid.Key, IDGuidTmpEmnpty, r.KeyLayout.Trim());
            if (dsLayout1.Layout.Rows.Count == 1)
            {
                qs2.core.vb.dsLayout.LayoutRow rLayout = (qs2.core.vb.dsLayout.LayoutRow)dsLayout1.Layout.Rows[0];
                this.cboLayout1.cboLay.Value = rLayout.IDGuid;
            }
            else if (dsLayout1.Layout.Rows.Count == 0)
            {
                this.cboLayout1.cboLay.Value = null;
            }
            else
            {
                throw new Exception("RowToFields: dsLayout1.Layout.Rows.Count > 1 for KeyLayout '" +  r.KeyLayout.Trim() +  "'");
            }
            this.txtKeyQuickFilter.Text = r.KeyQuickFilter;

            //this.cboLayout1.cboLay.Value 
            
            ucTerminFilterPicker1.MASSNAHMEN		= QuickFilterManager.GuidArrayFromString(r.Massnahmen);

            cbÜbergabe.Checked                   = r.BenutzenInEvaluierungJN;
            cbIntervention.Checked                  = r.BenutzenInInterventionJN;
            tbReihenfolge.Value                     = r.Reihenfolge;
            this.chkIsStandard.Checked = r.IsStandard;

            this.chkBereichIntervention.Checked = r.BereichIntervention;
            this.chkBereichÜbergabe.Checked = r.BereichÜbergabe;

            this.chkBenutzenInDekursJN.Checked = r.BenutzenInDekursJN;
            this.chkBereichDekurs.Checked = r.BereichDekurs;
            this.ucTerminFilterPicker1.ShowCC = r.ShowCC;

            this.cboBerufsstand.clearSelectedNodes();
            this.setBerufsstandErstelltFromString(r.LstBSQuickfilter.Trim());
            if (r.LstBSQuickfilter.Trim() != "")
            {
                System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                this.UISitemaps1.getListGuidFromString(r.LstBSQuickfilter.Trim(), ref lstGuid);
                if (lstGuid.Count > 0)
                {
                    this.Berufsstand = lstGuid;
                }
            }

            this.ucTerminFilterPicker1.setBerufsstandErstelltFromString(r.LstErstelltVonBerufgruppe.Trim());
            this.ucTerminFilterPicker1.setWichtigFürFromString(r.LstWichtigFürBerufsgruppe.Trim());

            this.ucTerminFilterPicker1.ShowBerufsstand = false;
            this.ucTerminFilterPicker1.cboBerufsstandMulti.clearSelectedNodes(); 
            if (r.LstErstelltVonBerufgruppe.Trim() != "")
            {
                System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                this.UISitemaps1.getListGuidFromString(r.LstErstelltVonBerufgruppe.Trim(), ref lstGuid);
                if (lstGuid.Count > 0)
                {
                    this.ucTerminFilterPicker1.Berufsstand = lstGuid;
                    this.ucTerminFilterPicker1.ShowBerufsstand = true;
                }
            }
            
            this.ucTerminFilterPicker1.WichtigFürJN = false;
            this.ucTerminFilterPicker1.cboWichtigFürMulti.clearSelectedNodes();
            if (r.LstWichtigFürBerufsgruppe.Trim() != "")
            {
                System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                this.UISitemaps1.getListGuidFromString(r.LstWichtigFürBerufsgruppe.Trim(), ref lstGuid);
                if (lstGuid.Count > 0)
                {
                    this.ucTerminFilterPicker1.WichtigFür = lstGuid;
                    this.ucTerminFilterPicker1.WichtigFürJN = true;
                }
            }

            this.ucTerminFilterPicker1.setZusatzwerteFromString(r.LstZusatzwerte.Trim());
            this.ucTerminFilterPicker1.ShowZusatzwerte = false;
            this.ucTerminFilterPicker1.cboZusatzwerteMulti.clearSelectedNodes();
            if (r.LstZusatzwerte.Trim() != "")
            {
                System.Collections.Generic.List<string> lstString = new System.Collections.Generic.List<string>();
                this.UISitemaps1.getListStringFromString(r.LstZusatzwerte.Trim(), ref lstString);
                if (lstString.Count > 0)
                {
                    this.ucTerminFilterPicker1.Zusatzwerte = lstString;
                    this.ucTerminFilterPicker1.ShowZusatzwerte = true;
                }
            }

            this.ucTerminFilterPicker1.setPlanungsEinträgeFromString(r.LstInterventionsTyp.Trim());
            this.ucTerminFilterPicker1.ShowPlanungsEinträgeJN = false;
            this.ucTerminFilterPicker1.cboPlanungsEinträgeMulti.clearSelectedNodes();
            if (r.LstInterventionsTyp.Trim() != "")
            {
                System.Collections.Generic.List<int> lstInt = new System.Collections.Generic.List<int>();
                this.UISitemaps1.getListIntFromString(r.LstInterventionsTyp.Trim(), ref lstInt);
                if (lstInt.Count > 0)
                {
                    this.ucTerminFilterPicker1.PlanungsEinträge = lstInt;
                    this.ucTerminFilterPicker1.ShowPlanungsEinträgeJN = true;
                }
            }

            this.ucTerminFilterPicker1.setZeitbezugJNAFromInt(r.LstZeitbezug.Trim());
            this.ucTerminFilterPicker1.ShowZeitbezugJN = false;
            this.ucTerminFilterPicker1.cboZeitbezugJNAMulti.clearSelectedNodes();
            if (r.LstZeitbezug.Trim() != "")
            {
                System.Collections.Generic.List<int> lstInt = new System.Collections.Generic.List<int>();
                this.UISitemaps1.getListIntFromString(r.LstZeitbezug.Trim(), ref lstInt);
                if (lstInt.Count > 0)
                {
                    this.ucTerminFilterPicker1.ZeitbezugJNA = lstInt;
                    this.ucTerminFilterPicker1.ShowZeitbezugJN = true;
                }
            }    

            this.ucTerminFilterPicker1.setHerkunftPlanungsEintragFromInt(r.LstHerkunftPlanungsEintrag.Trim());
            this.ucTerminFilterPicker1.ShowHerkunftPlanungsEintrag = false;
            this.ucTerminFilterPicker1.cboHerkunftPlanungseintrag.clearSelectedNodes();
            if (r.LstHerkunftPlanungsEintrag.Trim() != "")
            {
                System.Collections.Generic.List<int> lstInt = new System.Collections.Generic.List<int>();
                this.UISitemaps1.getListIntFromString(r.LstHerkunftPlanungsEintrag.Trim(), ref lstInt);
                if (lstInt.Count > 0)
                {
                    this.ucTerminFilterPicker1.HerkunftPlanungsEintrag = lstInt;
                    this.ucTerminFilterPicker1.ShowHerkunftPlanungsEintrag = true;
                }
            }

            this.ucTerminFilterPicker1.Abzeichnen = r.AbzeichnenJN;

        }
        public System.Collections.Generic.List<Guid> setBerufsstandErstelltFromString(string slstGuid)
        {
            try
            {
                System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                this.cboBerufsstand.clearSelectedNodes();
                if (slstGuid.Trim() != "")
                {
                    this.UISitemaps1.getListGuidFromString(slstGuid, ref lstGuid);
                    if (lstGuid.Count > 0)
                    {
                        this.Berufsstand = lstGuid;
                    }
                }

                return lstGuid;
            }
            catch (Exception ex)
            {
                throw new Exception("setBerufsstandErstelltFromString: " + ex.ToString());
            }
        }

        public System.Collections.Generic.List<Guid> Berufsstand
        {
            get
            {
                System.Collections.Generic.List<Guid> lstBerufsstand = new System.Collections.Generic.List<Guid>();
                System.Collections.Generic.List<int> lstIntSelected = new System.Collections.Generic.List<int>();
                System.Collections.Generic.List<string> lstStringSelected = new System.Collections.Generic.List<string>();
                this.cboBerufsstand.getSelected(ref lstBerufsstand, ref lstIntSelected, ref lstStringSelected);
                return lstBerufsstand;
            }
            set
            {
                this.cboBerufsstand.setSelected(value, null, null);
            }
        }

        private void FieldsToRow(PMDS.Global.db.Global.dsQuickFilter.QuickFilterRow r)
        {
            r.ZeitraumJN				= checkBox1.Checked;
            r.Tagenachher				= (int)nupNachher.Value;
            r.Tagevorher				= (int)nupVorher.Value;

            r.MassnahmeJN				= ucTerminFilterPicker1.IDMassnahme == Guid.Empty ? false : true;
            if(r.MassnahmeJN)
                r.IDEintrag = ucTerminFilterPicker1.IDMassnahme;
            else
                r.SetIDEintragNull();
            
            r.BezugspersonJN			= ucTerminFilterPicker1.IDBezug  == Guid.Empty ? false : true;
            if(r.BezugspersonJN)
                r.IDBenutzer = ucTerminFilterPicker1.IDBezug;
            else
                r.SetIDBenutzerNull();
            
            r.Tooltip		= tbToolTip.Text.Trim();

            qs2.core.vb.dsLayout.LayoutRow rLayoutSelected = this.cboLayout1.getSelectedRow(false);
            if (rLayoutSelected != null)
            {
                r.KeyLayout = rLayoutSelected.Key.Trim();
            }
            else
            {
                r.KeyLayout = ""; 
            }
            r.KeyQuickFilter = this.txtKeyQuickFilter.Text.Trim();

            StringBuilder sb = new StringBuilder();
            int iCount = 0;
            foreach(Guid g in ucTerminFilterPicker1.MASSNAHMEN)
            {
                if(iCount > 0)
                    sb.Append(",");
                sb.Append(g.ToString());
                iCount++;
            }
            r.Massnahmen = sb.ToString();

            r.BenutzenInInterventionJN  = cbIntervention.Checked;
            r.BenutzenInEvaluierungJN   = cbÜbergabe.Checked;
            r.Reihenfolge               = (int)tbReihenfolge.Value;

            r.BereichIntervention = this.chkBereichIntervention.Checked;
            r.BereichÜbergabe = this.chkBereichÜbergabe.Checked;

            r.BenutzenInDekursJN = this.chkBenutzenInDekursJN.Checked;
            r.BereichDekurs = this.chkBereichDekurs.Checked;
            r.ShowCC = this.ucTerminFilterPicker1.ShowCC;
            r.IsStandard = this.chkIsStandard.Checked;

            r.LstBSQuickfilter = "";
            foreach (Guid ID in this.Berufsstand)
            {
                r.LstBSQuickfilter += ID.ToString() + ";";
            }

            if (this.ucTerminFilterPicker1.ShowBerufsstand)
            {
                r.LstErstelltVonBerufgruppe = "";
                foreach (Guid ID in this.ucTerminFilterPicker1.Berufsstand)
                {
                    r.LstErstelltVonBerufgruppe += ID.ToString() + ";"; 
                }
                //System.Collections.Generic.List<string> lstMedTypeForPatient = qs2.core.generic.readStrVariables(rNewMedDaten.Beschreibung.Trim());
                //foreach (string MedDatenType in lstMedTypeForPatient)
                //{
                //    if (rMedDat.MedizinischerTyp.ToString().Trim().Equals(MedDatenType.Trim()))
                //    {
                //        MedTypeExists = true;
                //    }
                //}
            }
            else
            {
                r.LstErstelltVonBerufgruppe = "";
            }
            if (this.ucTerminFilterPicker1.WichtigFürJN)
            {
                r.LstWichtigFürBerufsgruppe = "";
                foreach (Guid ID in this.ucTerminFilterPicker1.WichtigFür)
                {
                    r.LstWichtigFürBerufsgruppe += ID.ToString() + ";";
                }
            }
            else
            {
                r.LstWichtigFürBerufsgruppe = "";
            }
            if (this.ucTerminFilterPicker1.ShowZusatzwerte)
            {
                r.LstZusatzwerte = "";
                foreach (string ID in this.ucTerminFilterPicker1.Zusatzwerte)
                {
                    r.LstZusatzwerte += ID.ToString() + ";";
                }
            }
            else
            {
                r.LstZusatzwerte = "";
            }
            if (this.ucTerminFilterPicker1.ShowPlanungsEinträgeJN)
            {
                r.LstInterventionsTyp = "";
                foreach (int ID in this.ucTerminFilterPicker1.PlanungsEinträge)
                {
                    r.LstInterventionsTyp += ID.ToString() + ";";
                }
            }
            else
            {
                r.LstInterventionsTyp = "";
            }

            if (this.ucTerminFilterPicker1.ShowZeitbezugJN)
            {
                r.LstZeitbezug = "";
                foreach (int ID in this.ucTerminFilterPicker1.ZeitbezugJNA)
                {
                    r.LstZeitbezug += ID.ToString() + ";";
                }
            }
            else
            {
                r.LstZeitbezug = "";
            }

            if (this.ucTerminFilterPicker1.ShowHerkunftPlanungsEintrag)
            {
                r.LstHerkunftPlanungsEintrag = "";
                foreach (int ID in this.ucTerminFilterPicker1.HerkunftPlanungsEintrag)
                {
                    r.LstHerkunftPlanungsEintrag += ID.ToString() + ";";
                }
            }
            else
            {
                r.LstHerkunftPlanungsEintrag = "";
            }

            r.AbzeichnenJN = this.ucTerminFilterPicker1.Abzeichnen;
        }

        private void RefreshList()
        {
            RefreshList(Guid.Empty);
            
        }

        private void RefreshList(Guid id) 
        {
            if(id == Guid.Empty)
                cbFilter.RefreshList(cbAbteilung.ABTEILUNG);
            else
                cbFilter.RefreshList(id, cbAbteilung.ABTEILUNG);

            ShowHidePanel();
            ShowHideMenu();
        }

        private void ShowHidePanel() 
        {
            if(cbFilter.Value == null) 
            {
                panel1.Visible = false;
            }
            else 
            {
                if(cbFilter.Value != null)
                    panel1.Visible = true;	
            }
        }

        private void ProcessDel() 
        {
            if(_dt == null)
                return;
            ROW.Delete();
            _manager.Write(_dt);
            _dt = null;
            RefreshList();	
            
        }

        private void ProcessRename() 
        {
            if(_dt == null)
                return;

            RBU.SingleTextEditForm frm = new RBU.SingleTextEditForm();
            frm.TEXT = ROW.Bezeichnung;
            DialogResult res =  frm.ShowDialog();
            if(res != DialogResult.OK)
                return;

            ROW.Bezeichnung = frm.TEXT;
            _manager.Write(_dt);
            RefreshList(ROW.ID);
        }

        private void ShowHideMenu()
        {
            bool  bEnable = _dt == null ? false  : true;
            this.btnAdd.Enabled = bEnable;
            this.btnDeletexyxyxyxyxyxyx.Enabled = bEnable;
            this.btnCopyAndPaste.Enabled = bEnable;
            this.btnUmbenennen .Enabled = bEnable;
            this.btnSave.Enabled = bEnable;

            if (cbAbteilung.Value == null)
            {
                this.btnAdd.Enabled = false;
                this.btnDeletexyxyxyxyxyxyx.Enabled = false;
                this.btnCopyAndPaste.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnUmbenennen.Enabled = false;
                this.btnSave.Enabled = false;
            }

            else
                if (cbFilter.Value == null)
                {
                    this.btnAdd.Enabled = true;
                    this.btnDeletexyxyxyxyxyxyx.Enabled = false;
                    this.btnCopyAndPaste.Enabled = false;
                    this.btnSave.Enabled = false;
                    this.btnUmbenennen.Enabled = false;
                    this.btnSave.Enabled = false;
                }
                else
                {
                    this.btnAdd.Enabled = true;
                    this.btnDeletexyxyxyxyxyxyx.Enabled = true;
                    this.btnCopyAndPaste.Enabled = true;
                    this.btnSave.Enabled = true;
                    this.btnUmbenennen.Enabled = true;
                    this.btnSave.Enabled = true;
                }

            //if(cbAbteilung.Value == null)
            //    ultraExplorerBar1.Groups[1].Items[0].Settings.Enabled = DefaultableBoolean.False;
            //else
            //    ultraExplorerBar1.Groups[1].Items[0].Settings.Enabled = DefaultableBoolean.True;
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                lblNachher.Enabled = checkBox1.Checked;
                lblVorher.Enabled = checkBox1.Checked;
                nupNachher.Enabled = checkBox1.Checked;
                nupVorher.Enabled = checkBox1.Checked;
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

        private void ClearFields()
        {
            ucTerminFilterPicker1.ClearFields();
            this.cboBerufsstand.clearSelectedNodes();

            nupNachher.Value	= 0;
            nupVorher.Value		= 0;
            checkBox1.Checked	= false;
        }

        private void cbFilter_ValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.cboLayout1.LoadData();
                //ProcessQuickfilterSave();
                ClearFields();
                if (cbFilter.Value != null)
                {
                    _dt = _manager.Read((Guid)cbFilter.Value);
                    RowToFields(ROW);
                }
                ShowHidePanel();
                ShowHideMenu();
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

        private void frmManageQuickFilter_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //ProcessQuickfilterSave();
                this.DialogResult = DialogResult.OK;
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

        private void cbAbteilung_ValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                cbFilter.Enabled = true;
                //ProcessQuickfilterSave();
                RefreshList();			// Combo Filter neu aufbauen
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

        private void ucButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //ProcessQuickfilterSave();
                ProcessAdd();
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

        private void ucButton2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie das Layout wirklich löschen?", "Löschen", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    ProcessDel(); 
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ProcessRename();
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

        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

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

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ProcessQuickFiltSave();
                ENV.SignalQuickfilterChanged(null);
                //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Layout wurde gespeichert!", "Speichern");
  
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Close();

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

        private void btnCopyAndPaste_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Quickfilter wirklich kopieren?", "Quickfilter kopieren", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                    Guid IDQuickfilterNew = System.Guid.Empty;

                    PMDSBusiness1.CopyQuickfilter(this.ROW.ID, ref IDQuickfilterNew);
                    this.RefreshList(IDQuickfilterNew);
                }

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

    }
}
