//----------------------------------------------------------------------------------------------
//  Erstellt am:	21.05.2007
//  Erstellt von:	MDA
//----------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;



namespace PMDS.GUI
{



    public partial class frmPDX2 : frmBase
    {
        public event ZuordnungUpdateDelegate ZuordnungChanged;
        private Guid _IDPdx;
        private String _PdxName;
        private bool _addASZMToPdx;

        public frmPDX2()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

        }

        public Guid IDPDX
        {
            get
            {
                return _IDPdx;
            }
            set
            {
                _IDPdx = value;
                ucPdx21.IDPDX = IDPDX;
            }
        }

        public String PDXNAME
        {
            get
            {
                return _PdxName;
            }
            set
            {
                _PdxName = value;
                ucPdx21.PDXNAME = PDXNAME;
            }
        }

        public bool ADDASZMTOPDX
        {
            get
            {
                return _addASZMToPdx;
            }
            set
            {
                _addASZMToPdx = value;
                ucPdx21.ADDASZMTOPDX = true;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Dialog schließen überwachen
        /// </summary>
        //----------------------------------------------------------------------------
        private void frmPDX2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ucPdx21.CONTENT_CHANGED)
            {
                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"),
                                                                                            ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"),
                                                                                            MessageBoxButtons.YesNoCancel,
                                                                                            MessageBoxIcon.Question, true);      

                if (res == DialogResult.Yes)
                {
                    ucPdx21.Save();

                    if (ZuordnungChanged != null)
                        ZuordnungChanged();

                    return;
                }

                if (res == DialogResult.No)
                    return;

                e.Cancel = true;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// leitet neue Zuordnung an ucASZMSearchSelector weiter --> dg neu befüllt
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucPdx21_ZuordnungChanged()
        {
            if (ZuordnungChanged != null)
                ZuordnungChanged();
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
            base.OnKeyDown(e);
        }

        private void frmPDX2_Load(object sender, EventArgs e)
        {
            ultraGridBagLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
        }
    }
}