using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{
    public partial class ucZeitbereich : QS2.Desktop.ControlManagment.BaseControl
    {
        private Zeitbereich _z = new Zeitbereich();
        public ucZeitbereich()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Init: lesen aller zeitbereiche
        /// </summary>
        //----------------------------------------------------------------------------
        public void Init()
        {
            
            dgMain.DataMember = "";
            dgMain.DataSource =  _z.Read();              // Alle verfügbaren Zeitbereiche lesen
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Ab in die DB
        /// </summary>
        //----------------------------------------------------------------------------
        public void Write()
        {
            _z.Write((dsZeitbereich.ZeitbereichDataTable)dgMain.DataSource);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Eine neue Zeile wird hinzugefügt
        /// </summary>
        //----------------------------------------------------------------------------
        private void dgMain_InitializeTemplateAddRow(object sender, Infragistics.Win.UltraWinGrid.InitializeTemplateAddRowEventArgs e)
        {
            e.TemplateAddRow.Cells["ID"].Value = Guid.NewGuid();
            DateTime dt = new DateTime(1900, 1, 1, 0, 0, 0);
            e.TemplateAddRow.Cells["von"].Value = dt;
            e.TemplateAddRow.Cells["bis"].Value = dt;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Englische Box ausblenden
        /// </summary>
        //----------------------------------------------------------------------------
        private void dgMain_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }
    }
}
