using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Infragistics.Win;



namespace PMDS.Calc.UI.Admin
{

	public partial class EnumOptionSet : Infragistics.Win.UltraWinEditors.UltraOptionSet
	{
		private System.Type _type = null;

		public EnumOptionSet()
		{
			InitializeComponent();
		}

		public EnumOptionSet(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		public void SetEnumType(Type enumType)
		{
			if (! enumType.IsEnum)
				throw new Exception ("EnumOptionSet muss mit einem Enum-Typ versehen werden. Verwendeter Typ: " + enumType.ToString());

			_type = enumType;
			RefreshList();
		}

		public int Option
		{
			get 
			{
				if(this.Items.Count == 0)
				{
					return -1;
				}
				else
				{
					if (this.CheckedItem != null && this.CheckedItem.DataValue.GetType().Equals(typeof(int)))
					{
						return (int)this.CheckedItem.DataValue;
					}
					else
					{
						return -1;
					}
				}
			}
			set 
			{
				foreach(ValueListItem i in this.Items) 
				{
					if( ((int)i.DataValue) == value) 
					{
						this.CheckedItem = i;
						break;
					}
				}
			}
		}

		public void RefreshList()
		{
			if (_type == null) return;
			this.Items.Clear();
			try
			{
				string[] sa = Enum.GetNames(_type);
				int i = 0;
				foreach (string s in sa)
				{
                    string txt = "";
                    if (i == (int)PMDS.Global.Leistungsgruppe.PeriodischeLeistungen )
                    {
                        txt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Periodische Leistungen");
                    }
                    else if (i == (int)PMDS.Global.Leistungsgruppe.PflegekomponenteGrundleistung )
                    {
                        txt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegekomponente Grundleistung");
                    }
                    else if (i == (int)PMDS.Global.Leistungsgruppe.WohnkomponenteGrundleistung  )
                    {
                        txt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Wohnkomponente Grundleistung");
                    }
                    ValueListItem itm = this.Items.Add(i, txt);
                    itm.Tag = s;
					i++;
				}
				
			}
			catch(Exception e)
			{
				PMDS.Global.ENV.HandleException(e);
			}
		}

	}
}
