using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Patient;
using PMDS.Klient;
using PMDS.GUI.Klient;

namespace PMDS.GUI
{
    public partial class ucPersoenlicheDaten : ucAnamneseModellgruppeBase
    {
        private KlientDetails _klient;
        public ucPersoenlicheDaten()
        {
            InitializeComponent();
            AddControlsToDataBindings();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ReadOnly setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                base.ReadOnly = value;
                btnDatenUebernehmen.Enabled = !value;
            }
        }

        private void AddControlsToDataBindings()
        {
            ListDataBindingHelper.Clear();
            ListDataBindingHelper.AddRange(new DataBindingHelper[]{new DataBindingHelper(tbGewicht, "Value", "Gewicht"), 
                                                    new DataBindingHelper(tbGroesse, "Value", "Groesse"),
                                                    new DataBindingHelper(cmbRelegion, "Text", "Konfision"),
                                                    new DataBindingHelper(tbDurchgefuehrMit, "Text", "DurchgefuehrtMit"),
                                                    new DataBindingHelper(ZahnersatzOKJN, "Checked", "ZahnersatzOKJN"),
                                                    new DataBindingHelper(ZahnersatzUKJN, "Checked", "ZahnersatzUKJN"),
                                                    new DataBindingHelper(SehhilfeBrilleJN, "Checked", "SehhilfeBrilleJN"),
                                                    new DataBindingHelper(SehhilfeKontaktlinsenJN, "Checked", "SehhilfeKontaktlinsenJN"),
                                                    new DataBindingHelper(HoergeraetRechtsJN, "Checked", "HoergeraetRechtsJN"),
                                                    new DataBindingHelper(HoergeraetLinksJN, "Checked", "HoergeraetLinksJN"),
                                                    new DataBindingHelper(opDepositenJN, "Value", "DepositenJN"),
                                                    new DataBindingHelper(tbAllergie, "Text", "Allergie"),
                                                    new DataBindingHelper(tbMobileKrankenpflege, "Text", "MobileKrankenpflage"),
                                                    new DataBindingHelper(tbSozialeDienste, "Text", "SozialeDienste"),
                                                    new DataBindingHelper(tbVerstaendigungAn, "Text", "VerstaendigungAn"),
                                                    new DataBindingHelper(tbSonstiges, "Text", "Sonstiges")
                                                    });

            BindData();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// KlientDetails setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KlientDetails Klient
        {
            get { return _klient; }
            set {_klient = value;}
        }
        
        private void btnDatenUebernehmen_Click(object sender, EventArgs e)
        {
            if(Klient != null)
            {
                tbGroesse.Text = Klient.Groesse != 0 ? Klient.Groesse.ToString() : "";
                tbGewicht.Text = Klient.Aufenthalt.Gewicht != 0 ? Klient.Aufenthalt.Gewicht.ToString() : "";
                cmbRelegion.Text = Klient.Konfision;

                StringBuilder sb = new StringBuilder();

                foreach (dsMedizinischeDaten.MedizinischeDatenRow r in Klient.MEDIZINISCHE_DATEN.ALLERGIEN.MedizinischeDaten)
                {
                    if (sb.ToString() != "") sb.Append(", ");
                    sb.Append(r.Beschreibung);
                }

                tbAllergie.Text = sb.ToString();

                sb = new StringBuilder();

                foreach (dsKontaktpersonen.KontaktpersonRow r in Klient.GetkontalPersonen(false).Kontaktperson)
                {
                    if (sb.ToString() != "") sb.Append(", ");
                    sb.Append(r.Name);
                }

                tbVerstaendigungAn.Text = sb.ToString();
            }
        }

        private void control_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(sender, e);
        }
    }
}
