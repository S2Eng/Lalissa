//----------------------------------------------------------------------------
/// <summary>
///	DBBase.cs
/// Erstellt am:	01.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data.OleDb;
using System.Data;

using RBU;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Global;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Basisklasse für Datenbank-Operationen
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBBase : System.ComponentModel.Component, IDBBase
	{
		private bool _bSingleEntry = true;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBBase()
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
		/// Beim Selekt muss genau ein Datensatz geliefert werden
		/// </summary>
		//----------------------------------------------------------------------------
		protected virtual bool IsSingleEntry
		{
			get	{	return _bSingleEntry;	}
			set	{	_bSingleEntry = value;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung aller Einträge.
		/// </summary>
		//----------------------------------------------------------------------------
		protected virtual OleDbDataAdapter daAll
		{
			get	
			{	
				throw new NotSupportedException("daAll");
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected virtual OleDbDataAdapter daFilterEntry
		{
			get	
			{	
				throw new NotSupportedException("daFilterEntry-2");
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// ID setzten
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual object ID
		{
			get	{	try
					{
						return daFilterEntry.SelectCommand.Parameters[0].Value;		
					}
					catch
					{}
					return 0;
			}
			set	{	daFilterEntry.SelectCommand.Parameters[0].Value = value;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Alle Einträge ermitteln.
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual DataTable All()
		{
			DataTable dt = (DataTable)new dsIDListe.IDListeDataTable();

			if (daFilterEntry.SelectCommand.Parameters[0].OleDbType == OleDbType.Guid)
				dt = (DataTable)new dsGUIDListe.IDListeDataTable();

			DataBase.Fill(daAll, dt);
			return dt;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen Eintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual void New()
        {
            throw new NotImplementedException("IDBBase.New");
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Einträge neu lesen
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual void Read()
		{
			((IDBBase)this).ITEM.Clear();

			if (IsSingleEntry)
				DBUtil.OneRowByID(this, ((IDBBase)this).ITEM, daFilterEntry);
			else
				DataBase.Fill(daFilterEntry, ((IDBBase)this).ITEM);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Abgleich der Daten mit Datenbank.
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual void Write()
		{
			DataBase.Update(daFilterEntry, ((IDBBase)this).ITEM);
		}

		#region IDBBase Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		DataTable IDBBase.ITEM
		{
			get	
			{	
				throw new NotSupportedException("IDBBase.ITEM");
			}
		}

		#endregion
	}
}
