using System;
namespace PMDS.Global
{
	public class PDXGruppeEintragDef
	{
		private Guid      			_IDPDX;
		private Guid      			_IDPDXGruppe;
		private String    			_Klartext;
		private String    			_Definition;

		public PDXGruppeEintragDef()
		{
		}
		public Guid IDPDX
		{
			get
			{
				return _IDPDX;
			}
			set
			{
				_IDPDX = value;
			}
		}
		public Guid IDPDXGruppe
		{
			get
			{
				return _IDPDXGruppe;
			}
			set
			{
				_IDPDXGruppe = value;
			}
		}
		public String Klartext
		{
			get
			{
				return _Klartext;
			}
			set
			{
				_Klartext = value;
			}
		}
		public String Definition
		{
			get
			{
				return _Definition;
			}
			set
			{
				_Definition = value;
			}
		}
	}
}
