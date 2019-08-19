using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{
    public partial class ucZeitbereichSerien : QS2.Desktop.ControlManagment.BaseControl
    {
        private ZeitbereichSerien _z;

        public ucZeitbereichSerien()
        {
            InitializeComponent();
        }

        private void dgMain_InitializeTemplateAddRow(object sender, Infragistics.Win.UltraWinGrid.InitializeTemplateAddRowEventArgs e)
        {
            e.TemplateAddRow.Cells["ID"].Value = Guid.NewGuid();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Init: lesen aller ZeitbereichSerien
        /// </summary>
        //----------------------------------------------------------------------------
        public void Init()
        {
            if (_z == null)
                _z = new ZeitbereichSerien();
            dgMain.DataMember = "";
            dgMain.DataSource = _z.Read();              // Alle verfügbaren Zeitbereiche lesen
            
            // Valuelists laden
            UltraGridTools.AddZeitbereichValueList(dgMain, "IDZeitbereich0");
            UltraGridTools.AddZeitbereichValueList(dgMain, "IDZeitbereich1");
            UltraGridTools.AddZeitbereichValueList(dgMain, "IDZeitbereich2");
            UltraGridTools.AddZeitbereichValueList(dgMain, "IDZeitbereich3");
            UltraGridTools.AddZeitbereichValueList(dgMain, "IDZeitbereich4");
            UltraGridTools.AddZeitbereichValueList(dgMain, "IDZeitbereich5");
            UltraGridTools.AddZeitbereichValueList(dgMain, "IDZeitbereich6");
            UltraGridTools.AddZeitbereichValueList(dgMain, "IDZeitbereich7");

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Ab in die DB
        /// </summary>
        //----------------------------------------------------------------------------
        public void Write()
        {
            dsZeitbereichSerien.ZeitbereichSerienDataTable dt = (dsZeitbereichSerien.ZeitbereichSerienDataTable)dgMain.DataSource;
            
            foreach (dsZeitbereichSerien.ZeitbereichSerienRow r in dt)              // Alle Guid.empty (wegen Combo) in nul umwandeln
            {
                if (!r.IsIDZeitbereich0Null() && r.IDZeitbereich0 == Guid.Empty) r.SetIDZeitbereich0Null();
                if (!r.IsIDZeitbereich1Null() && r.IDZeitbereich1 == Guid.Empty) r.SetIDZeitbereich1Null();
                if (!r.IsIDZeitbereich2Null() && r.IDZeitbereich2 == Guid.Empty) r.SetIDZeitbereich2Null();
                if (!r.IsIDZeitbereich3Null() && r.IDZeitbereich3 == Guid.Empty) r.SetIDZeitbereich3Null();
                if (!r.IsIDZeitbereich4Null() && r.IDZeitbereich4 == Guid.Empty) r.SetIDZeitbereich4Null();
                if (!r.IsIDZeitbereich5Null() && r.IDZeitbereich5 == Guid.Empty) r.SetIDZeitbereich5Null();
                if (!r.IsIDZeitbereich6Null() && r.IDZeitbereich6 == Guid.Empty) r.SetIDZeitbereich6Null();
                if (!r.IsIDZeitbereich7Null() && r.IDZeitbereich7 == Guid.Empty) r.SetIDZeitbereich7Null();
            }
            _z.Write(dt);
        }

    }
}
