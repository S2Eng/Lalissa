using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;

namespace PMDS.GUI
{
    public partial class ucPDxSearchPicker : QS2.Desktop.ControlManagment.BaseControl
    {
        public delegate void PDxSearchDelegate(PDXSuchArt suchArt, SearchCondition condition, SearchIN searchIN);
        public event PDxSearchDelegate PDxSearch;
        private string _AbteilungTxt;
        //Neu nach 15.09.2008 MDa
        private PflegePlanModus _PflegePlanModus = PflegePlanModus.Normal;
        
        public ucPDxSearchPicker()
        {
            InitializeComponent();
            _AbteilungTxt = opAuswahl.Items[0].DisplayText;
            if (DesignMode || !ENV.AppRunning) return;
            EnvPflegePlan.EnvPflegePlanKlientenAbteilungChanged += new EnvPflegePlanKlientenAbteilungChangedDelegate(EnvPflegePlan_EnvPflegePlanKlientenAbteilungChanged);
        }

        void EnvPflegePlan_EnvPflegePlanKlientenAbteilungChanged()
        {
            SetAbteilungText();
        }

        //Neu nach 12.09.2008 MDA
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PflegePlanModus PFLEGEPLANMODUS
        {
            get { return _PflegePlanModus; }
            set
            {
                _PflegePlanModus = value;
                btnPfDef.Text = _PflegePlanModus == PflegePlanModus.Normal ? QS2.Desktop.ControlManagment.ControlManagment.getRes("&Pflegediagnosen hinzufügen") : QS2.Desktop.ControlManagment.ControlManagment.getRes("&Wunden hinzufügen");
            }
        }

        private void SetAbteilungText()
        {
            Abteilung abteilung = new Abteilung();
            string abteilungText = abteilung.GetAbteilungstext(EnvPflegePlan.CurrentKlientenAbteilung);
            opAuswahl.BeginUpdate();
            opAuswahl.Items[0].DisplayText = string.Format(_AbteilungTxt, abteilungText);
            opAuswahl.EndUpdate();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnPfDef.CloseUp();

            PDXSuchArt suchArt = (PDXSuchArt)Enum.Parse(typeof(PDXSuchArt), opAuswahl.Value.ToString());
            SearchCondition condition = (SearchCondition)Enum.Parse(typeof(SearchCondition), opVerknuepfung.Value.ToString());
            SearchIN searchIN = (SearchIN)Enum.Parse(typeof(SearchIN), opSucheIN.Value.ToString());

            if (PDxSearch != null)
                PDxSearch(suchArt, condition, searchIN);
        }
    }
}
