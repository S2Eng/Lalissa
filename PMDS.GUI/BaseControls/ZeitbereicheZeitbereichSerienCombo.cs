using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global;
using PMDS.Data.Patient;
using Infragistics.Win;
using PMDS.Global.db.Patient;
using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{
    public partial class ZeitbereicheZeitbereichSerienCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
    {
        public ZeitbereicheZeitbereichSerienCombo()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Setzt oder liefert den ausgewählten Zeitbereich
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid ID
        {
            get
            {
                if (Items.Count == 0)
                    return Guid.Empty;
                return (Guid)SelectedItem.DataValue;
            }
            set
            {
                foreach (ValueListItem i in this.Items)
                {
                    if (((Guid)i.DataValue) == value)
                    {
                        this.SelectedItem = i;
                        break;
                    }
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsZeitbereichSerie
        {
            get
            {
                if (ID == Guid.Empty)
                    return false;

                return (SelectedItem.Tag is dsZeitbereichSerien.ZeitbereichSerienRow) ? true : false;

            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// AuswahlListe neu aufbauen
        /// </summary>
        //----------------------------------------------------------------------------
        public void RefreshList(bool InsertEmtyOne)
        {
            this.Items.Clear();

            if (InsertEmtyOne)
                this.Items.Add(Guid.Empty, QS2.Desktop.ControlManagment.ControlManagment.getRes("Benutzerdefiniert"));
            
            try
            {
                Massnahmenserien massnahmenserien = new Massnahmenserien();
                massnahmenserien.Read();
                dsMassnahmenserien.MassnahmenserienDataTable massnahmenserienDT = massnahmenserien.Serien;
                ZeitbereichSerien z = new ZeitbereichSerien();
                dsZeitbereichSerien.ZeitbereichSerienDataTable dt = z.Read();
                ValueListItem item;

                foreach (dsMassnahmenserien.MassnahmenserienRow r in massnahmenserienDT)
                {
                    if (r.ID == Guid.Empty) continue;
                    item = this.Items.Add(r.ID, r.Bezeichnung);
                    item.Tag = r;
                }

                foreach (dsZeitbereichSerien.ZeitbereichSerienRow r in dt)
                {
                    item = this.Items.Add(r.ID, r.Bezeichnung);
                    item.Tag = r;
                }
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }

        public override void RefreshList()
        {
            if (DesignMode || !ENV.AppRunning)
                return;
            RefreshList(false);
        }
    }
}
