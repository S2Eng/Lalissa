//----------------------------------------------------------------------------
/// <summary>
///	DBException.cs
/// Erstellt am:	15.9.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbank-Exception für PMDS spezifische Fehler
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBException : Exception
	{
		public DBException(string message) : base(message)
		{
		}
	}
}
