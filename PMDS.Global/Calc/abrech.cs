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
        Wohnkomponente_Grundleistung = 0,
        [Description("Pflegekomponente Grundleistung")]             
        Pflegekomponente_Grundleistung = 1,
        [Description("Periodische Leistungen")]                      
        Periodische_Leistungen = 2
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
        Grundkosten_Periodischeleistung = 5,
        Sonderleistung = 6,
        Grundkosten_Sonderleistung = 7,
        PeriodischeLeistung_Sonderleistung = 8,
        Alles = 9
	}
    
}
