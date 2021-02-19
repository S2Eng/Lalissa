using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global;
using Infragistics.Win;
using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{
    public partial class ZeitbereichSerienCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
    {
        public ZeitbereichSerienCombo()
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

        //----------------------------------------------------------------------------
        /// <summary>
        /// AuswahlListe neu aufbauen
        /// </summary>
        //----------------------------------------------------------------------------
        public void RefreshList(bool InsertEmtyOne)
        {
            this.Items.Clear();

            if (InsertEmtyOne)
                this.Items.Add(Guid.Empty, QS2.Desktop.ControlManagment.ControlManagment.getRes("Benutzer definiert"));

            try
            {
                ZeitbereichSerien z = new ZeitbereichSerien();
                dsZeitbereichSerien.ZeitbereichSerienDataTable dt = z.Read();

                foreach (dsZeitbereichSerien.ZeitbereichSerienRow r in dt)
                {
                    ValueListItem item = this.Items.Add(r.ID, r.Bezeichnung);
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
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || !ENV.AppRunning)
                return;
            RefreshList(false);
        }
    }
}
