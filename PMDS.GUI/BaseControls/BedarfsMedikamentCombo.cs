using System;
using PMDS.Global;using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.BusinessLogic;
using Infragistics.Win;
using Infragistics.Win.UltraWinToolTip;
using System.Drawing;
using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{


	public class BedarfsMedikamentCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
  




        public BedarfsMedikamentCombo()
		{
            if (!ENV.AppRunning)
                return;

            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(null);
            this.ultraToolTipManager1.ContainingControl = this;
            ultraToolTipManager1.AutoPopDelay = 60000;
            ultraToolTipManager1.InitialDelay = 0;
            this.TextChanged += new System.EventHandler(this.BedarfsMedikamentCombo_TextChanged);
            this.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			RefreshList();

		}

	    public void RefreshList(Guid IDAufenthalt)
		{
			this.Items.Clear(); 
			try
			{
                if (!PMDS.GUI.frmPatientRueckmeldungLine.IsSchnellrückmeldung)
                {
                    dsGUIDListe.IDListeDataTable dt = Rezept.GetBedarfsMedikamente(IDAufenthalt, DateTime.Now);
                    this.Items.Add(Guid.Empty, " ");
                    foreach (dsGUIDListe.IDListeRow r in dt.Rows)
                    {
                        string[] sa = r.TEXT.Split(new string[] { "||" }, StringSplitOptions.None);
                        ValueListItem item = this.Items.Add(r.ID, sa[0].Replace("\r\n", " - "));        //os 130315: CrLf durch - ersetzen für Anzeige in Combobox
                        item.Tag = sa[1];                                                               //für Tooltip
                    }
                }

            }
			catch(Exception e)
			{
				ENV.HandleException(e);
			}
		}

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // BedarfsMedikamentCombo
            // 
            this.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void BedarfsMedikamentCombo_TextChanged(object sender, EventArgs e)
        {
            UltraToolTipInfo i = new UltraToolTipInfo();
            i.ToolTipText = "";

            try
            {
                if (SelectedItem == null || (Guid)SelectedItem.DataValue == Guid.Empty)
                    return;

                string sText = SelectedItem.Tag.ToString().Trim();
                if (sText.Length == 0)
                    return;

                i.ToolTipText = sText;
            }
            finally
            {
                ultraToolTipManager1.SetUltraToolTip(this, i);

                if (i.ToolTipText.Length > 0)
                    ultraToolTipManager1.ShowToolTip(this, PointToScreen(new Point(0,0)));
            }
        }

	}

}
