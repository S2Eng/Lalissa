using System;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text;
using System.IO;

using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win;

using PMDS.BusinessLogic;
using PMDS.Global;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Tools für Ultragrid
	/// </summary>
	//----------------------------------------------------------------------------
	public class UltraExplorerBarTools
	{
		public UltraExplorerBarTools()
		{
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Zeigen oder Verstecken eines Items (wenn kein Item mehr sichtbar, dann auch
		/// die Gruppe ausblenden
		/// </summary>
		//----------------------------------------------------------------------------
		public static void SetVisible(UltraExplorerBar bar, string group, string item, bool bVisible)
		{
			UltraExplorerBarGroup g =  bar.Groups[group];
			SetVisible(g.Items[item], bVisible);
		}

		public static void SetVisible(UltraExplorerBarItem item, bool bVisible)
		{
			item.Visible = bVisible;

			// ist irgend wer sichtbar
			bool bGroupVisible = false;
			foreach(UltraExplorerBarItem barItem in item.Group.Items)
			{
				if (barItem.Visible)
				{
					bGroupVisible = true;
					break;
				}
			}
			item.Group.Visible = bGroupVisible;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Enablen/disablen aller Elemente un der Explorerbar
		/// </summary>
		//----------------------------------------------------------------------------
		public static void EnableAllItems(UltraExplorerBar bar,  bool bEnable)
		{
			foreach(UltraExplorerBarGroup g in bar.Groups)
			{
				
				foreach(UltraExplorerBarItem item in g.Items)
					item.Settings.Enabled = bEnable ? DefaultableBoolean.True : DefaultableBoolean.False;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		///Bold aller Elemente setzen
		/// </summary>
		//----------------------------------------------------------------------------
		public static void AllItemsBold(UltraExplorerBar bar,  bool bbold)
		{
			foreach(UltraExplorerBarGroup g in bar.Groups)
			{
				
				foreach(UltraExplorerBarItem item in g.Items)
					item.Settings.AppearancesSmall.Appearance.FontData.Bold = bbold ? DefaultableBoolean.True : DefaultableBoolean.False;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		///Bold eines Item setzen
		/// </summary>
		//----------------------------------------------------------------------------
		public static void SetItemBold(UltraExplorerBarItem item, bool bbold)
		{
			item.Settings.AppearancesSmall.Appearance.FontData.Bold = bbold ? DefaultableBoolean.True : DefaultableBoolean.False;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		///	Visible test
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool IsVisible(UltraExplorerBar bar, string group, string item)
		{
			UltraExplorerBarGroup g =  bar.Groups[group];
			return g.Items[item].Visible;
		}
	}
}
