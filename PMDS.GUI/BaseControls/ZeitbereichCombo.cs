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
    public class ZeitbereichCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
    {
        public ZeitbereichCombo()
        {
        }

        
        //----------------------------------------------------------------------------
        /// <summary>
        /// AuswahlListe neu aufbauen
        /// </summary>
        //----------------------------------------------------------------------------
        public void RefreshList(bool InsertEmtyOne)
        {
            RefreshList(InsertEmtyOne, false);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// AuswahlListe neu aufbauen
        /// </summary>
        //----------------------------------------------------------------------------
        public void RefreshList(bool InsertEmtyOne, bool emtyText)
        {
            this.Items.Clear();

            if (InsertEmtyOne)
            {
                string txt = emtyText ? " " : QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Zeitbereich wählen");
                this.Items.Add(Guid.Empty, txt);
            }
            try
            {
                Zeitbereich z = new Zeitbereich();
                dsZeitbereich.ZeitbereichDataTable dt = z.Read();

                foreach (dsZeitbereich.ZeitbereichRow r in dt)
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

        //----------------------------------------------------------------------------
        /// <summary>
        /// Setzt oder liefert den ausgewählten Zeitbereich
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDZeitbereich
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
                    if (i.DataValue != DBNull.Value && ((Guid)i.DataValue) == value)
                    {
                        this.SelectedItem = i;
                        break;
                    }
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert den von Wert des gewählten zeitbereiches
        /// </summary>
        //----------------------------------------------------------------------------
        public DateTime VON_SELECTED
        {
            get
            {
                if (Items.Count == 0 || SelectedItem== null || SelectedItem.Tag == null)
                    return new DateTime(1900, 0, 0, 0, 0, 0);

                dsZeitbereich.ZeitbereichRow r = (dsZeitbereich.ZeitbereichRow)SelectedItem.Tag;
                return r.von;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert den bis Wert des gewählten zeitbereiches
        /// </summary>
        //----------------------------------------------------------------------------
        public DateTime BIS_SELECTED
        {
            get
            {
                if (Items.Count == 0 || SelectedItem == null || SelectedItem.Tag == null)
                    return new DateTime(1900, 0, 0, 0, 0, 0);

                dsZeitbereich.ZeitbereichRow r = (dsZeitbereich.ZeitbereichRow)SelectedItem.Tag;
                return r.bis;
            }
        }

        public override void RefreshList()
        {
            RefreshList(false);
        }
    }
}
