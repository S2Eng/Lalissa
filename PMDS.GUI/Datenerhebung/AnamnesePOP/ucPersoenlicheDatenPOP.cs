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
    public partial class ucPersoenlicheDatenPOP : ucAnamneseModellgruppeBase
    {
        private KlientDetails _klient;
        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness(); 






        public ucPersoenlicheDatenPOP()
        {
            InitializeComponent();
            AddControlsToDataBindings();
        }

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
                                                    new DataBindingHelper(tbBMI, "Value", "BMI"),
                                                    new DataBindingHelper(tbDurchgefuehrMit, "Text", "DurchgefuehrtMit"),
                                                    new DataBindingHelper(ZahnersatzOKJN, "Checked", "ZahnersatzOKJN"),
                                                    new DataBindingHelper(ZahnersatzUKJN, "Checked", "ZahnersatzUKJN"),
                                                    new DataBindingHelper(SehhilfeBrilleJN, "Checked", "SehhilfeBrilleJN"),
                                                    new DataBindingHelper(SehhilfeKontaktlinsenJN, "Checked", "SehhilfeKontaktlinsenJN"),
                                                    new DataBindingHelper(HoergeraetRechtsJN, "Checked", "HoergeraetRechtsJN"),
                                                    new DataBindingHelper(HoergeraetLinksJN, "Checked", "HoergeraetLinksJN"),
                                                    new DataBindingHelper(opDepositenJN, "Value", "DepositenJN"),
                                                    new DataBindingHelper(tbSonstigeHilfen, "Text", "SonstigeHilfen"),
                                                    new DataBindingHelper(tbAllergie, "Text", "Allergie"),
                                                    new DataBindingHelper(tbReligioeseBeduerfnisse, "Text", "ReligioeseBeduerfnisse"),
                                                    new DataBindingHelper(tbMobileKrankenpflege, "Text", "MobileKrankenpflege"),
                                                    new DataBindingHelper(tbSozialeDienste, "Text", "SozialeDienste"),
                                                    new DataBindingHelper(tbVerstaendigungAn, "Text", "VerstaendigungAn"),
                                                    new DataBindingHelper(tbSonstiges, "Text", "Sonstiges")
                                                    });

            BindData();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KlientDetails Klient
        {
            get { return _klient; }
            set {_klient = value;}
        }

        private double CalculateBMI(double HeightCm, double WeightKg)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    PMDS.db .Entities.Patient rPatient = this.b.getPatient(this.Klient.ID, db);
                    if (HeightCm != 0)
                    {
                        double BMI = Math.Round((WeightKg * (double)(100 - rPatient.Amputation_Prozent) / 100) / System.Math.Pow((HeightCm / 100), 2), 1);
                        return BMI;
                    }
                    else
                    {
                        return 0;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("CalculateBMI: " + ex.ToString());
            }
        }





        private void btnDatenUebernehmen_Click(object sender, EventArgs e)
        {
            if(Klient != null)
            {
                tbGroesse.Text = Klient.Groesse != 0 ? Klient.Groesse.ToString() : "";
                tbGewicht.Text = Klient.Aufenthalt.Gewicht != 0 ? Klient.Aufenthalt.Gewicht.ToString() : "";
                tbBMI.Text = this.CalculateBMI(Klient.Groesse, Klient.Aufenthalt.Gewicht).ToString("#0.#");

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

        private void ucPersoenlicheDatenPOP_Load(object sender, EventArgs e)
        {

        }

        private void tbGewicht_KeyUp(object sender, KeyEventArgs e)
        {
            tbBMI.Text = CalculateBMI(System.Convert.ToDouble(tbGroesse.Text != "" ? tbGroesse.Text : "0"), System.Convert.ToDouble(tbGewicht.Text != "" ? tbGewicht.Text : "0")).ToString("#0.#");
        }

        private void tbGroesse_KeyUp(object sender, KeyEventArgs e)
        {
            tbBMI.Text = CalculateBMI(System.Convert.ToDouble(tbGroesse.Text != "" ? tbGroesse.Text : "0"), System.Convert.ToDouble(tbGewicht.Text != "" ? tbGewicht.Text : "0")).ToString("#0.#");
        }
    }
}
