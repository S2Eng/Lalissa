using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Abrechnung.Global;
using PMDS.Calc.UI.Admin;
using PMDS.Global;





namespace PMDS.Calc.UI.Admin
{
    public partial class ucKlientenakt : QS2.Desktop.ControlManagment.BaseControl, ISave, IPatient, IRefresh
    {
        public event EventHandler ValueChanged;
        private Guid _IDPatient = Guid.Empty;
        private bool _DataChenged = false;
        //public PMDS.GUI.ucKlientStammdaten ucKlientStammdaten1;


        


        public ucKlientenakt()
        {
            InitializeComponent();

        }

        public void  initControl()
        {
            //this.ucKlientStammdaten1 = new PMDS.GUI.ucKlientStammdaten();
            //this.ucKlientStammdaten1.Dock = DockStyle.Fill;
            //this.panelKlient.Controls.Add(this.ucKlientStammdaten1);
            this.ucKlientStammdaten1.ValueChanged += new System.EventHandler(this.ucKlient1_ValueChanged);
            this.ucKlientStammdaten1.initControl(false, false, true);
        }

        public bool Save()
        {
            try
            {
                if (!ValidateFields())
                    return false;

                ucKlientStammdaten1.UpdateDATA();
                ucKlientStammdaten1.Write();

                _DataChenged = false;
                return true;
            }
            catch (Exception e)
            {
                PMDS.Global.ENV.HandleException(e);
                return false;
            }
        }

        public void Undo()
        {
            RefreshControl();
        }

        public bool IsChanged { get { return _DataChenged; } }

        
        public bool ValidateFields()
        {
            if (_IDPatient == Guid.Empty)
                return true;

            return ucKlientStammdaten1.ValidateFields();
        }

        public void RefreshControl()
        {
            UpdateActions();

            if (_IDPatient == Guid.Empty)
            {
                ucKlientStammdaten1.Klient = new KlientDetails();
            }
            else
            {
                Guid currentAufenthalt = ucKlientStammdaten1.Klient.Aufenthalt != null ? ucKlientStammdaten1.Klient.Aufenthalt.ID : Guid.Empty;
                ucKlientStammdaten1.Klient = new KlientDetails(_IDPatient, currentAufenthalt);
            }
            _DataChenged = false;

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
        {
            get { return _IDPatient; }
            set
            {
                _IDPatient = value;
                _DataChenged = false;
                UpdateActions();
                KlientDetails klient =  new KlientDetails(_IDPatient, Aufenthalt.LastByPatient(_IDPatient));
                ucKlientStammdaten1.Klient = klient;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// erlaubte Aktionen ein/ausblenden
        /// </summary>
        //----------------------------------------------------------------------------
        private void UpdateActions()
        {
            ////nach User Rechte Tab Stammdaten anzeigen oder ausblenden
            //ucKlient2.StammdatenVisible = ENV.HasRight(UserRights.KlientenAktStammdatenAnzeigen);

            ////Stammdaten ReadOnly setzen
            //ucKlient2.StammdatenReadOnly = !ENV.HasRight(UserRights.KlientenAktStammdatenAendern);

            //Sonstige Visible
            //ucKlient2.SonstigeVisible = ENV.HasRight(UserRights.KlientenAktSonstigeAnzeigen);

            //Sonstige ReadOnly
            //ucKlient2.SonstigeReadOnly = !ENV.HasRight(UserRights.KlientenAktSonstigeAendern);
    

            //if (!ucKlient2.StammdatenVisible && !ucKlient2.SonstigeVisible)
            //{
            //    panelKeinRecht.Visible = true;
            //}
        }

        private void ucKlient1_ValueChanged(object sender, EventArgs e)
        {
            _DataChenged = true;

            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        private void ucKlientenakt_Load(object sender, EventArgs e)
        {
            
        }
        public  void resizeUI(int w, int h)
        {
            this.Width = w;
            this.Height = h;

        }
    }
}
