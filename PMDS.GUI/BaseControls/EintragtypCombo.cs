//----------------------------------------------------------------------------
/// <summary>
///	PflegerCombo.cs
/// Erstellt am:	26.4.2005
/// Erstellt von:	RBU
/// </summary>
//----------------------------------------------------------------------------
using System;

using PMDS.Global;
using PMDS.Data.Global;
using PMDS.BusinessLogic;
using Infragistics.Win;

namespace PMDS.GUI.BaseControls
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// ComboBox für Leistungsgruppe-Auswahl
	/// </summary>
	//----------------------------------------------------------------------------
	public class EintragtypCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{
		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
        public EintragtypCombo()
		{
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert / setzt die ausgewählte Leistungsgruppe als integer
		/// </summary>
		//----------------------------------------------------------------------------
		public EintragFlag EintragTyp
		{
			get 
			{
				if(this.SelectedItem == null || this.Items.Count == 0)
					return EintragFlag.Einzelabzeichnung;
				else
					return (EintragFlag)this.SelectedItem.DataValue;
			}
			set 
			{
                int iv = (int)value;
				foreach(ValueListItem i in this.Items) 
				{
					if( ((int)i.DataValue) == iv) 
					{
						this.SelectedItem = i;
						break;
					}
				}
			}
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
				string[] sa = Enum.GetNames(typeof(EintragFlag));
				int i = 0;
				foreach (string s in sa)
				{
					this.Items.Add(i, s);
					i++;
				}
				
			}
			catch(Exception e)
			{
				ENV.HandleException(e);
			}
		}
	}

}
