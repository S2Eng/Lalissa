////----------------------------------------------------------------------------
///// <summary>
/////	DBTransaction.cs
///// Erstellt am:	16.11.2004
///// Erstellt von:	EHO
///// </summary>
////----------------------------------------------------------------------------
//using System;
//using RBU;

//namespace PMDS.Transaction
//{
//	//----------------------------------------------------------------------------
//	/// <summary>
//	/// Klasse zur Behandlung der Datenbank-Transaktion
//	/// </summary>
//	//----------------------------------------------------------------------------
//	public class DBTransaction : IDisposable
//	{
//		private bool _bOpenTransaction = false;

//		//----------------------------------------------------------------------------
//		/// <summary>
//		/// Konstruktor
//		/// </summary>
//		//----------------------------------------------------------------------------
//		public DBTransaction()
//		{
//			if (DataBase.CurrentTransaction() == null)
//			{
//				DataBase.BeginTransation();
//				_bOpenTransaction = true;
//			}
//		}

//		//----------------------------------------------------------------------------
//		/// <summary>
//		/// Transaktion festschreiben (Änderungen akzeptieren)
//		/// </summary>
//		//----------------------------------------------------------------------------
//		public void Commit()
//		{
//			if (_bOpenTransaction)
//				DataBase.CommitTransaction();

//			_bOpenTransaction = false;
//		}

//		//----------------------------------------------------------------------------
//		/// <summary>
//		/// Transaktion zurückfahren (Änderungen verwerfen)
//		/// </summary>
//		//----------------------------------------------------------------------------
//		public void Rollback()
//		{
//			if (_bOpenTransaction)
//				DataBase.RollbackTransaction();

//			_bOpenTransaction = false;
//		}
		
//		#region IDisposable Members

//		//----------------------------------------------------------------------------
//		/// <summary>
//		/// Dispose
//		/// </summary>
//		//----------------------------------------------------------------------------
//		public void Dispose()
//		{
//			// offene Transaktion zurückfahren
//			if (_bOpenTransaction)
//				Rollback();
//		}

//		#endregion
//	}
//}
