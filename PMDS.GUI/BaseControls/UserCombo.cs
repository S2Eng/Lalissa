//----------------------------------------------------------------------------
/// <summary>
///	AbteilungsCombo.cs
/// Erstellt am:	14.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;

using PMDS.Global;using PMDS.Data.Global;
using PMDS.BusinessLogic;
using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// ComboBox f�r Abteilungs-Auswahl
	/// </summary>
	//----------------------------------------------------------------------------
	public class UserCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{

		private			bool								_bInit = true;
		private static	dsGUIDListe.IDListeDataTable		_GuidListe;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public UserCombo()
		{
            if(!DesignMode && ENV.AppRunning)
			    RefreshList();
			_bInit = false;
		}

		public static void ReloadUser() 
		{

		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// AuswahlListe neu aufbauen
		/// </summary>
		//----------------------------------------------------------------------------
		public override void RefreshList()
		{
			this.Items.Clear();

			try
			{
				if(!_bInit)						// Wenn die Funnktion von au��n angesto�en wird dann die Eintr�ge neu lesen
					_GuidListe = null;

				if(_GuidListe == null)
					_GuidListe = Benutzer.All();

				foreach(dsGUIDListe.IDListeRow r in _GuidListe)
					this.Items.Add(r.ID, r.TEXT);
			}
			catch(Exception e)
			{
				ENV.HandleException(e);
			}
		}
	}

}
