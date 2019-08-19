//----------------------------------------------------------------------------
/// <summary>
///	Interfaces.cs
/// Erstellt am:	22.9.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.Data.PflegePlan;
using PMDS.Print.CR;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.Global
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Schnittstelle für Datenbankoperation
	/// </summary>
	//----------------------------------------------------------------------------
	public interface IDBBase
	{
		DataTable All();

		void New();
		void Read();
		void Write();

		object ID { get; set; }
		DataTable ITEM	{ get; }
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Interface für PMDSGUI Objekte
	/// </summary>
	//----------------------------------------------------------------------------
	public interface IPMDSGUIObject
	{
		string AREA						{	get;}		// Bereichsangabe
		Control CONTROL					{	get;}		// darzustellendes Control
		IPMDSMenuFramework FRAMEWORK	{	get;set;}	// Framework referenz

		void AttachFramework();
		void DetachFramework();
		bool Save();
		void Undo();
		void ProcessKeyEvent(KeyEventArgs e);			// KeyEvent Behandlung

//		void ExternSiteMapEventHandler(SiteEvents e);
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Headerinformationen
	/// </summary>
	//----------------------------------------------------------------------------
	public interface IPMDSHeader
	{
		// Info Bereiche
		string LEFTINFO		{	set;	}
		string MIDDLEINFO	{	set;	}
		string RIGHTINFO	{	set;	}
        void ShowOnlyHeader(bool bShow);
        void ShowControlAndHeader(bool bShow);
        void action(bool bOnOff);
        void ShowGesamtarchiv(bool bOnOff);
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Menüverarbeitung / Explorerverarbeitung
	/// </summary>
	//----------------------------------------------------------------------------
	public interface IPMDSMenuFramework 
	{
		// other
		IPMDSHeader HEADER	{	get;	}
		void AddObject(IPMDSGUIObject o);
		void BringOnTop(IPMDSGUIObject o);
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Schnittstelle für Datenbankoperation mit Unterelementen
	/// </summary>
	//----------------------------------------------------------------------------
	public interface IDBBaseEntries : IDBBase
	{
		DataRow		NewEntry();
		DataTable	SUBITEMS { get; }
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Schnittstelle für Business-Objekte
	/// </summary>
	//----------------------------------------------------------------------------
	public interface IBusinessBase
	{
		DataTable AllEntries();

		void New();
		void Read(object id);
		void Read();
		void Write();
		void Delete();

		DataRow ROW { get; }
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Schnittstelle für WizardPage
	/// </summary>
	//----------------------------------------------------------------------------
	public interface IWizardPage
	{
		void UpdateGUI();
		void UpdateDATA();
		bool ValidateFields();
    }

	//----------------------------------------------------------------------------
	/// <summary>
	/// Schnittstelle für UserControl-Objekte
	/// </summary>
	//----------------------------------------------------------------------------
	public interface IUCBase
	{
		event EventHandler ValueChanged;

		DataTable	All();
		IBusinessBase Object	{	get; set; }

		bool New();
		void Read(object id);
		void Read();
		void Write();
		void Delete();

		void UpdateDATA();
		bool ValidateFields();
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Schnittstelle für ZusatzWerte
	/// </summary>
	//----------------------------------------------------------------------------
	public interface IZusatz
	{
		object ZusatzWertForAbteilung(Guid idAbteilung);
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Schnittstelle für Marker
	/// </summary>
	//----------------------------------------------------------------------------
	public interface IMarker
	{
		CheckedListBox	Control	{	get;	}
		DataTable		DATA	{	get;	}
		DataRow			Find(DataRow r);
		void			NewItem(DataRow r);
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Schnittstelle um Objekt zu beenden
	/// </summary>
	//----------------------------------------------------------------------------
	public interface IClose
	{
		bool CanClose	{	get;	}
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Schnittstelle um Objekt ReadOnly zu setzten
	/// </summary>
	//----------------------------------------------------------------------------
	public interface IReadOnly
	{
		bool ReadOnly	{	get;set;	}
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Schnittstelle für externe Pflegeplan aktivitäten
	/// </summary>
	//----------------------------------------------------------------------------
	public interface IPflegePlanAction
	{
		void Write(Guid IDUser, bool bUseTransaction,  bool bWriteHistory);
		void EndPDx(PDxLokalisiert[] rpdx, ASZMLokalisiert[] raszm, string sReason, DateTime dtEnd);
		Guid InsertPPEntry(ASZMSelectionArgs args, Guid IDUser);
		void Refresh();
		dsPflegePlanPDx.PflegePlanPDxDataTable PFLEGEPLANPDX { get;}
		dsPflegePlan.PflegePlanDataTable PFLEGEPLAN_EINTRAEGE {get;}
		void EndPflegePlanID(Guid IDPflegeplan, string sReason, DateTime dtEnd);				// Beendet einen übergebenen Eintrag soferne noch nicht beendet die Änderungen werden erst nach einem Write geschrieben
		
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Schnittstelle für Info-Text zu setzten (beim Main-Fenster)
	/// </summary>
	//----------------------------------------------------------------------------
	public interface IInfoText
	{
		event EventHandler InfoChanged;

		string Info	{ get;	}
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Schnittstelle für Konfiguration
	/// </summary>
	//----------------------------------------------------------------------------
	public interface IConfig
	{
		void EditConfig();
		void LoadConfig();
		void SaveConfig();
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Für anstoßen der Aktualisierung
	/// </summary>
	//----------------------------------------------------------------------------
	public interface ITerminRefresh
	{
		void TerminRefresh();
	}

    public interface IBerichtParameterGUI
    {
        object VALUE { get; }                               // liefert den aktuellen Wert
        BerichtParameter BERICHTPARAMETER { get; set;}      // die zugehörigen Berichtparameter struktur
        string VALUE_TEXT { get;}                           // liefert den Text zum Wert zb: zur BenutzerID den Benutzernamen
        event EventHandler ValueChanged;                    // Wird ausgelöst wenn der Wert GUI mäßig verändert wurde
        void AnotherValueChanged(BerichtParameter p);       // Kann aufgerufen werden wenn sich irgendwo anders sich ein wert ändert damit Abhängigkeiten abgebildet werden
    }

    public interface ISave
    {
        bool Save();
        void Undo();
        bool IsChanged { get;}
        bool ValidateFields();
    }

    public interface IAufenthalt
    {
        Guid IDAufenthalt { get;set;}
    }

    public interface IPatient
    {
        Guid IDPatient { get;set;}
    }

    //Neu nach 30.01.2008
    public interface IRefresh
    {
        void RefreshControl();
    }

    //Neu nach 09.06.2008 MDA
    public interface ITreeview
    {
        ASZMSelectionArgs ARG { get;set;}
        PDxSelectionArgs PDX_SARG { get;set;}
        bool IsPDx { get;}
        PDxSelectionArgs CurrentPDX { get;}
    }
}
