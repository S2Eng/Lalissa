using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;



namespace PMDS.Calc.UI.Admin
{


    public partial class ucDepotgeldKlient : QS2.Desktop.ControlManagment.BaseControl, ISave, IPatient, IRefresh
    {
        public event EventHandler ValueChanged;
        private Guid _IDPatient = Guid.Empty;
        private bool _DataChenged = false;
        private PMDS.GUI.ucDepotgeldkonto ucTaschengeld1;
        public frmDepotgeldKlient mainForm;

        


        public ucDepotgeldKlient()
        {
            InitializeComponent();
        }
        public void  initControl()
        {
            this.ucTaschengeld1 = new PMDS.GUI.ucDepotgeldkonto();
            this.ucTaschengeld1.initControl();
            this.panelDepotgeld.Controls.Add(this.ucTaschengeld1);
            this.ucTaschengeld1.ValueChanged += new System.EventHandler(this.uc_ValueChanged);
            this.ucTaschengeld1.Dock = DockStyle.Fill;
            
            this.btnSchlieﬂen.Appearance.Image = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);
        }


        public bool Save()
        {
            try
            {
                if(!IsChanged)
                    return true;

                if (!ValidateFields())
                    return false;

                ucTaschengeld1.Write();
                _DataChenged = false;

                this.showHideButtons(false);

                return true;
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
        }
        public void Undo()
        {
            RefreshControl();
        }
        public bool IsChanged 
        { 
            get 
            {
                return _DataChenged; 
            } 
        }
        public bool ValidateFields()
        {
            return ucTaschengeld1.ValidateFields();
        }
        public void RefreshControl()
        {
            _DataChenged = false;
            KlientDetails klient =  new KlientDetails(_IDPatient, Aufenthalt.LastByPatient(_IDPatient));
            ucTaschengeld1.IDKlient  = klient.ID ;
            ucTaschengeld1.loadData();

            this.showHideButtons(false);
        }
        public void showHideButtons(bool on)
        {
            if (this.mainForm != null)
            {
                this.btnSave.Enabled = on;
                this.btnUndo.Enabled = on;
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
        {
            get { return _IDPatient; }
            set
            {
                _IDPatient = value;
                RefreshControl();
            }
        }

        private void uc_ValueChanged(object sender, EventArgs e)
        {
            _DataChenged = true;
            if (ValueChanged != null)
            {
                ValueChanged(this, e);
            }

            this.showHideButtons(true);
        }

        private void btnSchlieﬂen_Click(object sender, EventArgs e)
        {
            this.mainForm.Close();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            this.RefreshControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }


    }
}
