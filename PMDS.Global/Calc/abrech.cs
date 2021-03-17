using System;
using System.Windows.Forms;
using System.ComponentModel;




namespace PMDS.Global
{
    
	public static class abrech
	{

        public static DateTime GueltigBis = new DateTime(2099, 12, 31, 23, 59, 59);
        
		public static string[] GetleistungsgruppeNames()
		{
			return Enum.GetNames(typeof(Leistungsgruppe));
		}
    }
    
	public enum Leistungsgruppe
	{
        [Description("Wohnkomponente Grundleistung")]               //-IntVers=NoTranslation
        WohnkomponenteGrundleistung = 0,
        [Description("Pflegekomponente Grundleistung")]             
        PflegekomponenteGrundleistung = 1,
        [Description("Periodische Leistungen")]                      
        PeriodischeLeistungen = 2
	}
    public enum AbrechnungsGruppe
    {
        Grundleistung = 0,
        PeriodischeLeistung = 2,
        Sonderleistung = 3
    }
	public enum Kostentraegerart
	{
		Grundkosten = 0,
        Transferleistung = 3,
        Periodischeleistung =4,
        GrundkostenPeriodischeleistung = 5,
        Sonderleistung = 6,
        GrundkostenSonderleistung = 7,
        PeriodischeLeistungSonderleistung = 8,
        Alles = 9
	}
    



}
