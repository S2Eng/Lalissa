using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinListView;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Patient;
using PMDS.Data.PflegePlan;


namespace PMDS.GUI
{

    

    public partial class ucAnamnesePDX : ucAnamnesePDXBase
    {
        //Neu nach 10.05.2007
        private PDxSelectionArgs _arg;
        private int _CurrentItemIndex = -1;
        
        public ucAnamnesePDX()
        {
            InitializeComponent();
        }

        public override bool ReadOnly
        {
            get{return base.ReadOnly;}
            set
            {
                base.ReadOnly = value;
                SetReadOnly();
            }
        }

        private void SetReadOnly()
        {
            if(ReadOnly)
                tbResourcen.Enabled = false;

            btnPDXPlanen.Enabled = !ReadOnly;
        }

        public override void UpdateGUI()
        {
            base.UpdateGUI();

            if (_arg == null)
                return;
            InitPDxInfos();

            if (_CurrentItemIndex != -1)
            {
                lvPDX.Items[_CurrentItemIndex].Activate();
                lvPDX.SelectedItems.Add(lvPDX.Items[_CurrentItemIndex]);
            }
        }

        //Neu nach 10.05.2007
        //----------------------------------------------------------------------------
        /// <summary>
        /// Pflegedefinition Informationen anzeigen
        /// </summary>
        //----------------------------------------------------------------------------
        private void InitPDxInfos()
        {
            if (_arg == null)
                return;

            _valueChangeEnabled = false;
            lblInfo.Text = string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Resourcen zu {0}."), _arg.Klartext);    
            
            tbResourcen.Text = _arg.Resourceklient.Trim();

            lblBeschreibung.Text = _arg.Text;
            
            UpdateSize();
            
            btnPDXPlanen.Text = string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("PD \"{0}\" jetzt planen"), _arg.Code);

            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
            ultraToolTipInfo1.ToolTipText = string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("PD \"{0}\" jetzt planen"), _arg.Klartext);
            ultraToolTipManager1.SetUltraToolTip(btnPDXPlanen, ultraToolTipInfo1);
            
            ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
            ultraToolTipInfo1.ToolTipText = lblInfo.Text;
            ultraToolTipManager1.SetUltraToolTip(lblInfo, ultraToolTipInfo1);

            _valueChangeEnabled = true;
        }

        //Neu nach 10.05.2007
        //----------------------------------------------------------------------------
        /// <summary>
        /// Grösse von Labels abhängig von der Text ändern
        /// </summary>
        //----------------------------------------------------------------------------
        private void UpdateSize()
        {
            Graphics g = lblBeschreibung.CreateGraphics();
            float h = g.MeasureString(lblBeschreibung.Text, lblBeschreibung.Font, lblBeschreibung.Width).Height;
            lblBeschreibung.Height = Convert.ToInt32(h);
        }

        //Neu nach 10.05.2007
        private void SetResourcenReadOnly(UltraListViewItem item)
        {
            if (ReadOnly)
                return;

            tbResourcen.Enabled =  item.CheckState == CheckState.Checked ? true : false;
            btnPDXPlanen.Enabled = tbResourcen.Enabled; 
        }

        private void tbResourcen_Leave(object sender, EventArgs e)
        {
            if (_arg == null)
                return;

            if (tbResourcen.Text.Trim() != _arg.Resourceklient.Trim())
                _arg.Resourceklient = tbResourcen.Text.Trim();
        }

        private void btnPDXPlanen_Click(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            UpdateSize();
        }

        private void ucAnamnesePDX_Load(object sender, EventArgs e)
        {
            lblBeschreibung.Text = "";
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten-Änderung signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        public void Control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }

        protected override void lvPDX_ItemCheckStateChanged(object sender, Infragistics.Win.UltraWinListView.ItemCheckStateChangedEventArgs e)
        {
            base.lvPDX_ItemCheckStateChanged(sender, e);
            SetResourcenReadOnly(e.Item);
        }

        private void lvPDX_ItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            if (e.SelectedItems.First != null)
            {
                e.SelectedItems.First.Activate();
                _CurrentItemIndex = e.SelectedItems.First.Index;
                _arg = (PDxSelectionArgs)e.SelectedItems.First.Tag;
                InitPDxInfos();
                SetResourcenReadOnly(e.SelectedItems.First);
            }
        }
    }
}
