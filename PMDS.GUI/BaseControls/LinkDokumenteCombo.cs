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
using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// ComboBox für Leistungsgruppe-Auswahl
	/// </summary>
	//----------------------------------------------------------------------------
	public class LinkDokumenteCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{
		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
        public LinkDokumenteCombo()
		{
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert / setzt die ausgewählte Leistungsgruppe als integer
		/// </summary>
		//----------------------------------------------------------------------------
		public Guid IDLinkDokument
		{
			get 
			{
				if(this.Items.Count == 0 || SelectedItem == null)
					return Guid.Empty;
				else
					return (Guid)this.SelectedItem.DataValue;
			}
			set 
			{
				foreach(ValueListItem i in this.Items) 
				{
					if( ((Guid)i.DataValue) == value) 
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
                LinkDokumente l = new LinkDokumente();
                Items.Add(Guid.Empty, "     ");                                  // für keine Zuordnung
                foreach (dsGUIDListe.IDListeRow r in l.ALL_IDLISTE.Rows)
                    Items.Add(r.ID, r.TEXT);
			}
			catch(Exception e)
			{
				ENV.HandleException(e);
			}
		}
	}

}
