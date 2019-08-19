using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Klient;
using PMDS.GUI.Klient;

namespace PMDS.GUI
{
    public partial class ucKontaktPersonen : QS2.Desktop.ControlManagment.BaseControl, IWizardPage, IReadOnly
    {
        private KlientDetails _klient;
        private bool _externerDienstleister = true;
        public event EventHandler ValueChanged;
        //Neu nach 27.04.2007 MDA
        private bool _readOnly = false;
        
        public ucKontaktPersonen()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Klient setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KlientDetails Klient
        {
            get
            {
                if (_klient == null)
                    _klient = new KlientDetails();
                return _klient;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Klient");

                _klient = value;
                UpdateGUI();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Klient setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        public bool ExternerDienstleister
        {
            get
            {
                return _externerDienstleister;
            }
            set
            {
                _externerDienstleister = value;
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle Kontaktperson Datenzeile ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsKontaktpersonen.KontaktpersonRow CurrentKontaktpersonRow
        {
            get
            {
                return (dsKontaktpersonen.KontaktpersonRow)UltraGridTools.CurrentSelectedRow(gridKontaktpersonen);
            }
        }

        //Neu nach 27.04.2007
        //----------------------------------------------------------------------------
        /// <summary>
        /// ReadOnly setzen / auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                SetReadOnly();
            }
        }

        /// <summary>
        /// lädt die Daten aus einem Businessobject und aktualisiert die GUI.
        /// </summary>
        public void UpdateGUI()
        {
            //----------------------------------------------------
            //              Kontakte
            //----------------------------------------------------
            gridKontaktpersonen.DataSource = Klient.GetkontalPersonen(ExternerDienstleister);
        }

        /// <summary>
        /// Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        /// </summary>
        public void UpdateDATA()
        {
            
        }

        /// <summary>
        /// prüft ob alle Eingaben richtig sind.
        /// </summary>
        public bool ValidateFields()
        {
            return true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle Rows ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        private dsKontaktpersonen.KontaktpersonRow[] CurrentSelectedRows()
        {
            dsKontaktpersonen.KontaktpersonRow[] list = null;
            List<DataRowView> listDataRowView = new List<DataRowView>();

            foreach (UltraGridRow r in gridKontaktpersonen.Rows)
            {
                if (r.Selected && r.ListObject != null)
                {
                    listDataRowView.Add((DataRowView)r.ListObject);
                }
            }

            if (listDataRowView.Count > 0)
            {
                list = new dsKontaktpersonen.KontaktpersonRow[listDataRowView.Count];
                int i = 0;
                foreach (DataRowView v in listDataRowView)
                {
                    list[i] = (dsKontaktpersonen.KontaktpersonRow)v.Row;
                    i++;
                }

            }

            return list;
        }

        private void UpdateKontaktperson(object sender, EventArgs e)
        {
            if (CurrentKontaktpersonRow != null)
            {
                bool change = KlientGuiAction.UpdateKontaktperson(CurrentKontaktpersonRow, Klient, ExternerDienstleister);
                if (change)
                    ValueChanged(sender, e);
            }
        }

        //Neu nach 26.04.2007 MDA
        private void SetReadOnly()
        {
            btnAddKP.Enabled = !ReadOnly;
            btnDelKP.Enabled = !ReadOnly;
            btnUpdateKP.Enabled = !ReadOnly;
        }


        private void btnAddKP_Click(object sender, EventArgs e)
        {
            bool change = KlientGuiAction.UpdateKontaktperson(null, Klient, ExternerDienstleister);
            if (change)
            {
                ValueChanged(sender, e);
            }
        }

        private void btnDelKP_Click(object sender, EventArgs e)
        {
            if (KlientGuiAction.DeleteKontakte(gridKontaktpersonen, _klient, ExternerDienstleister) && ValueChanged != null)
                ValueChanged(sender, e);
        }

        private void btnUpdateKP_Click(object sender, EventArgs e)
        {
            UpdateKontaktperson(sender, e);
        }

        private void gridKontaktpersonen_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            //if (PMDS.Global.historie.HistorieOn  ) return;
            //Neu nach 27.04.2007: Wenn ReadOnly Event sperren
            if (!ReadOnly)
                UpdateKontaktperson(sender, e);
        }

        private void gridKontaktpersonen_KeyDown(object sender, KeyEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.D && !ReadOnly && ENV.adminSecure) //Neu nach 27.04.2007: Wenn ReadOnly Event sperren
            {
                if (KlientGuiAction.DeleteKontakte(gridKontaktpersonen, _klient, ExternerDienstleister) && ValueChanged != null)
                    ValueChanged(sender, e);
            }
        }

        private void ucKontaktPersonen_Load(object sender, EventArgs e)
        {

        }
    }
}
