//----------------------------------------------------------------------------
/// <summary>
///	frmInfo.cs
/// Erstellt am:	22.3.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace PMDS
{


	public class frmInfo : QS2.Desktop.ControlManagment.baseForm 
    {

        public bool closeIfVisible = !PMDS.Global.ENV.COMMANDLINE_bshowSplash;




		public frmInfo()
		{
			InitializeComponent();
		}
        
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfo));
            this.SuspendLayout();
            // 
            // frmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(685, 244);
            this.ControlBox = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInfo";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmInfo_Load);
            this.VisibleChanged += new System.EventHandler(this.frmInfo_VisibleChanged);
            this.ResumeLayout(false);

		}
		#endregion

		public void Start()
		{
            try
            {
                Show();
            }
            catch (Exception ex)
            {
                //do nothing
            }

        }

	    public void Stop()
		{
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                //do nothing
            }

        }

	    private void frmInfo_Load(object sender, System.EventArgs e)
		{
		}

        private void frmInfo_VisibleChanged(object sender, EventArgs e)
        {
            if (closeIfVisible)
            {
                try
                {
                    if (this != null)
                        this.Close();
                }
                catch (Exception ex)
                {
                    //do nothing
                }
            }
        }

    }
}
