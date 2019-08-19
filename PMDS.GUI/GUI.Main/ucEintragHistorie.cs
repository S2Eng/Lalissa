//----------------------------------------------------------------------------
/// <summary>
///	ucEintragHistorie.cs
/// Erstellt am:	21.12.2005
/// Erstellt von:	RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Anzeige der Historie zu einem Eintrag eines Pflegeplanes
	/// Es werden die Zusatzwerte als Spalten angezeigt
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucEintragHistorie : QS2.Desktop.ControlManagment.BaseControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucEintragHistorie()
		{
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
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
			// 
			// ucEintragHistorie
			// 
			this.Name = "ucEintragHistorie";
			this.Size = new System.Drawing.Size(648, 216);

		}
		#endregion
	}
}
