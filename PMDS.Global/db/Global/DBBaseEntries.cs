//----------------------------------------------------------------------------
/// <summary>
///	DBBaseEntries.cs
/// Erstellt am:	01.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data.OleDb;
using System.Data;

using RBU;
using PMDS.Global;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Basisklasse für Datenbank-Operationen mit Subeinträgen
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBBaseEntries : DBBase, IDBBaseEntries
	{
		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		private System.ComponentModel.Container components = null;

		protected DBBaseEntries()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dispose
		/// </summary>
		//----------------------------------------------------------------------------
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung der Sub-Einträge.
		/// </summary>
		//----------------------------------------------------------------------------
		protected virtual OleDbDataAdapter daSubEntries
		{
			get	
			{	
				throw new NotSupportedException ("daSubEntries");
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// ID setzten
		/// </summary>
		//----------------------------------------------------------------------------
		public override object ID
		{
			get	{	return base.ID;		}
			set	
			{	
				base.ID = value;
				daSubEntries.SelectCommand.Parameters[0].Value = value;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Einträge neu lesen
		/// </summary>
		//----------------------------------------------------------------------------
		public override void Read()
		{
			base.Read();
			((IDBBaseEntries)this).SUBITEMS.Clear();
			DataBase.Fill(daSubEntries, ((IDBBaseEntries)this).SUBITEMS);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Abgleich der Daten mit Datenbank.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void Write()
		{
			base.Write();
			DataBase.Update(daSubEntries, ((IDBBaseEntries)this).SUBITEMS);
		}

		#region IDBBaseEntries Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		DataRow IDBBaseEntries.NewEntry()
		{
			throw new NotImplementedException("IDBBaseEntries.NewEntry");
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		DataTable IDBBaseEntries.SUBITEMS
		{
			get	
			{	
				throw new NotSupportedException("IDBBaseEntries.SUBITEMS");
			}
		}

		#endregion
	}
}
