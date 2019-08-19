using System;
namespace PMDS.Global
{
	public class PDXGruppeDef
	{
		private Guid      			_ID;
		private Guid      			_IDAbteilung;
		private Int32     			_Reihenfolge;
		private String    			_Bezeichnung;
		private bool      			_Changed;

		public PDXGruppeDef()
		{
		}
		public Guid ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}
		public Guid IDAbteilung
		{
			get
			{
				return _IDAbteilung;
			}
			set
			{
				_IDAbteilung = value;
			}
		}
		public Int32 Reihenfolge
		{
			get
			{
				return _Reihenfolge;
			}
			set
			{
				_Reihenfolge = value;
			}
		}
		public String Bezeichnung
		{
			get
			{
				return _Bezeichnung;
			}
			set
			{
				_Bezeichnung = value;
			}
		}
		public bool Changed
		{
			get
			{
				return _Changed;
			}
			set
			{
				_Changed = value;
			}
		}
	}
}
