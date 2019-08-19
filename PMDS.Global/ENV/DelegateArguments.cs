//----------------------------------------------------------------------------------------------
//	DelegateArguments.cs
//  Sammlung von globalen Delegates und Arguments
//  Erstellt am:	15.10.2004
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using Infragistics.Win.UltraWinGrid;


namespace PMDS.Global
{
	
	public delegate void  					ASZMSelectedDelegate(ASZMSelectionArgs[] args, bool bAMDependet, bool bLokalisiert, string sLokalisierung, string sLokalisierungSeite);		// Alle markierten auf einmal übergeben

	public delegate void					ZuordnungUpdateDelegate(); 

	public delegate void					AddSelectedASZMToPDXDelegate(UltraGridRow[] rc);
	public delegate void					AddSelectedPDXToTOPDelegate(UltraGridRow[] rc);
    

    //Neu nach 06.06.2008 MDA
    public delegate void KlientenMehrfachAuswahlDelegate(bool mehrfachauswahl);
    //Neu nach 09.06.2008 MDA
    public delegate void PDXSelectedDelegate(PDxSelectionArgs[] pdxArgs);
    //Neu nach 03.09.2008 MDA
    public delegate void EnvPflegePlanKlientenAbteilungChangedDelegate();
    public delegate void ASZMtoPDxDelegate(Guid IDPdx, Guid IDEintrag, EintragGruppe gruppe, bool demStandardHinzufuegen, Guid[] IDAbteilungen);


    public delegate void refreshUI(object  val);

    public delegate void evPflegeplanÄndern(string typ );
    public delegate void evPlanungÄndern(string typ);

    //public class cDelRefresh
    //{   
    //    public static refreshUI _dRefresh;
    //    public delegate void refreshUI(object o);
        

    //    public static void regDelegate(refreshUI funct)
    //    { PMDS.Global.cDelRefresh._dRefresh = funct; }
    //    public static void useDelegate(object valueForRefresh)
    //    { PMDS.Global.cDelRefresh._dRefresh.Invoke( valueForRefresh); }
    //}

}


