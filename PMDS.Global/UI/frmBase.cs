//----------------------------------------------------------------------------
/// <summary>
///	frmBase.cs
/// Erstellt am:	26.7.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using PMDS.Global;
using RBU;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;



namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Form Basisklasse für Allgemeine Operationen
	/// </summary>
	//----------------------------------------------------------------------------
	public class frmBase : QS2.Desktop.ControlManagment.baseForm  
	{
		private System.ComponentModel.Container components;

		public frmBase()
		{
            InitializeComponent();
		}    

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

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "frmBase";
            this.Text = "frmBase";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.ResumeLayout(false);

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// OnLoad - Farben anpassen
		/// </summary>
		//----------------------------------------------------------------------------
		protected override void OnLoad(EventArgs e)
		{
			UpdateColors();
			base.OnLoad (e);
		}
        

		//----------------------------------------------------------------------------
		/// <summary>
		/// Farben anpassen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateColors()
		{
            //Color fBack = GetColor();
            //Color cBack	= Color.FromArgb(Math.Max(fBack.R-50, 0), Math.Max(fBack.G-50, 0), Math.Max(fBack.B-50, 0));
            //Color cFront= Color.White;

            //this.BackColor = fBack;
            //PatchInfo(cBack, cFront);
			PatchCtrl(this );
            this.BackColor = System.Drawing.Color.WhiteSmoke;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// spezielle Elemente patchen
		/// </summary>
		//----------------------------------------------------------------------------
		private void PatchCtrl(Control ctrl )
		{
            foreach (Control item in ctrl.Controls)
            {
                if (item.Tag != null)
                    if (item.Tag.ToString() == "Dontpatch")
                        continue;

                if (item is UltraGrid)
                {
                    UltraGrid g = (UltraGrid)item;

                    g.UseOsThemes = Infragistics.Win.DefaultableBoolean.True ;
                    g.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White ;
                    //g.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                    //g.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White ;
                    //if (g.DisplayLayout.CaptionAppearance.BackColor.IsEmpty)
                    //    g.DisplayLayout.CaptionAppearance.BackColor = c;
                    //g.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.White;
                    //g.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.red ;
                    //g.DisplayLayout.ScrollBarLook.Appearance.BackColor = c;
                }
                PatchCtrl(item );
            }
		}

        private void frmBase_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }
    }
}
