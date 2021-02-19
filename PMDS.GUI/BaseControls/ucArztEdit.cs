using Infragistics.Win.UltraWinGrid;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Global.db.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;


namespace PMDS.GUI
{
    public partial class ucArztEdit : QS2.Desktop.ControlManagment.BaseControl
    {
        private Aerzte _Aerzte;
        private Guid _IDPatient = Guid.Empty;
        private bool _ShowAuswahlColumn = false;
        private bool _CanModify = true;
        private Guid[] _listPatientAerzte;
        
        public ucArztEdit()
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime && ENV.AppRunning)
            {
                _Aerzte = new Aerzte();
                _Aerzte.Read();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Spalte Auswahl anzeigen Ja \ Nein
        /// </summary>
        //----------------------------------------------------------------------------
        public bool ShowAuswahlColumn
        {
            get { return _ShowAuswahlColumn; }
            set
            {
                _ShowAuswahlColumn = value;
                ShowOrHideAuswahlColumn();
            }
        }

        public bool CanModify
        {
            get { return _CanModify; }
            set
            {
                _CanModify = value;
                ShowHideModifyButtons();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// IDPatient lesen / setzen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
        {
            get { return _IDPatient;}
            set
            {
                _IDPatient = value;
                _Aerzte.ReadByPatient(_IDPatient);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Klasse Aerzte lesen / setzen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Aerzte CLASS_AERZTE
        {
            get { return _Aerzte; }
            set {_Aerzte = value;}
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle Arzt Datenzeile ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsAerzte.AerzteRow CurrentArztRow
        {
            get
            {
                return (dsAerzte.AerzteRow)UltraGridTools.CurrentSelectedRow(gridAerzte);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ID alle Ausgewählte Ärzte zurückgeben
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid[] Aerzte
        {
            get {return GetAusgewehlteAerzte();}
            set { _listPatientAerzte = value; }
        }

        private Guid[] GetAusgewehlteAerzte()
        {
            List<Guid> list = new List<Guid>();

            foreach (UltraGridRow r in gridAerzte.Rows)
            {
                if (Convert.ToBoolean(r.Cells["Auswahl"].Value) == true)
                    list.Add((Guid)r.Cells["ID"].Value);
            }

            return list.ToArray();
        }

        private void SetAusgewehlteAerzte()
        {
            foreach (UltraGridRow r in gridAerzte.Rows)
            {
                r.Cells["Auswahl"].Value = false;

                foreach (Guid id in _listPatientAerzte)
                {
                    if ((Guid)r.Cells["ID"].Value == id)
                    {
                        r.Cells["Auswahl"].Value = true;
                        break;
                    }
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle Rows ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        private dsAerzte.AerzteRow[] CurrentSelectedRows()
        {
            dsAerzte.AerzteRow[] list = null;
            List<DataRowView> listDataRowView = new List<DataRowView>();

            foreach (UltraGridRow r in gridAerzte.Rows)
            {
                if (r.Selected && r.ListObject != null)
                {
                    listDataRowView.Add((DataRowView)r.ListObject);
                }
            }

            if (listDataRowView.Count > 0)
            {
                list = new dsAerzte.AerzteRow[listDataRowView.Count];
                int i = 0;
                foreach (DataRowView v in listDataRowView)
                {
                    list[i] = (dsAerzte.AerzteRow)v.Row;
                    i++;
                }

            }

            return list;
        }

        public void Write()
        {
            _Aerzte.Write();
        }

        private void ShowOrHideAuswahlColumn()
        {
            gridAerzte.BeginUpdate();
            gridAerzte.DisplayLayout.Bands[0].Columns["Auswahl"].Hidden = !ShowAuswahlColumn;
            gridAerzte.EndUpdate();
        }


        private void ShowHideModifyButtons()
        {
            btnAdd.Visible = _CanModify;
            btnUpdate.Visible = _CanModify;
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Suchen Verarbeiten
        /// </summary>
        //----------------------------------------------------------------------------
        private void ProcessSearch()
        {
            gridAerzte.BeginUpdate();
            gridAerzte.Rows.ColumnFilters.ClearAllFilters();

            if (tbNachname.TextLength == 0 && cbFachrichtung.TextLength == 0)
            {
                gridAerzte.EndUpdate();
                return;
            }

            if (tbNachname.TextLength != 0)
                gridAerzte.Rows.ColumnFilters["Nachname"].FilterConditions.Add(FilterComparisionOperator.StartsWith, tbNachname.Text.Trim());

            if(cbFachrichtung.TextLength != 0)
                gridAerzte.Rows.ColumnFilters["Fachrichtung"].FilterConditions.Add(FilterComparisionOperator.Equals, cbFachrichtung.Text.Trim());
            gridAerzte.EndUpdate();
        }

        private bool AddArzt()
        {
            frmArzt frm = new frmArzt();
            frm.AerzteRow = _Aerzte.New();
            frm.Arzt = _Aerzte.GetArzt(frm.AerzteRow.ID);
            DialogResult res = frm.ShowDialog();

            if (res != DialogResult.OK)
            {
                frm.AerzteRow.Delete();
                return false;
            }

            if (IDPatient != Guid.Empty)
            {
                _Aerzte.NewPatientAerzte(frm.Arzt.ID);
            }
            return true;
        }

        private bool UpdateArzt()
        {
            if (CurrentArztRow == null)
                return false;

            frmArzt frm = new frmArzt();
            frm.AerzteRow = CurrentArztRow;
            frm.Arzt = _Aerzte.GetArzt(CurrentArztRow.ID);
            DialogResult res = frm.ShowDialog();

            if (res != DialogResult.OK)
                return false;
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddArzt();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateArzt();
        }

        private void ucArztEdit_Load(object sender, EventArgs e)
        {

            this.btnUpdate.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime && ENV.AppRunning)
            {
                gridAerzte.DataSource = _Aerzte.AERZTE;

                if (_listPatientAerzte != null)
                    SetAusgewehlteAerzte();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ProcessSearch();
        }

        private void gridAerzte_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
