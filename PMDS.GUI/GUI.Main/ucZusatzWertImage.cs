//----------------------------------------------------------------------------
/// <summary>
///	ucZusatzWertImage.cs
/// Erstellt am:	2.2.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text;

using PMDS.Global;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zu, Handling eines Image-Zusatzwertes
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucZusatzWertImage : QS2.Desktop.ControlManagment.BaseControl, IReadOnly
	{
		public event EventHandler ValueChanged;

		private string _name = "";
		private QS2.Desktop.ControlManagment.BaseButton btnPicSave;
		private QS2.Desktop.ControlManagment.BaseButton btnPicLoad;
		private Infragistics.Win.UltraWinEditors.UltraPictureBox picBox;
		private QS2.Desktop.ControlManagment.BaseButton btnPicClear;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucZusatzWertImage()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dispose
		/// </summary>
		//----------------------------------------------------------------------------
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
            this.btnPicSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnPicLoad = new QS2.Desktop.ControlManagment.BaseButton();
            this.picBox = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.btnPicClear = new QS2.Desktop.ControlManagment.BaseButton();
            this.SuspendLayout();
            // 
            // btnPicSave
            // 
            this.btnPicSave.Location = new System.Drawing.Point(120, 56);
            this.btnPicSave.Name = "btnPicSave";
            this.btnPicSave.Size = new System.Drawing.Size(128, 24);
            this.btnPicSave.TabIndex = 3;
            this.btnPicSave.Text = "Bild speichern nach ...";
            this.btnPicSave.Click += new System.EventHandler(this.btnPicSave_Click);
            // 
            // btnPicLoad
            // 
            this.btnPicLoad.Location = new System.Drawing.Point(120, 32);
            this.btnPicLoad.Name = "btnPicLoad";
            this.btnPicLoad.Size = new System.Drawing.Size(128, 24);
            this.btnPicLoad.TabIndex = 2;
            this.btnPicLoad.Text = "Bild laden von ...";
            this.btnPicLoad.Click += new System.EventHandler(this.btnPicLoad_Click);
            // 
            // picBox
            // 
            this.picBox.BorderShadowColor = System.Drawing.Color.Empty;
            this.picBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.picBox.Location = new System.Drawing.Point(0, 0);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(112, 88);
            this.picBox.TabIndex = 0;
            // 
            // btnPicClear
            // 
            this.btnPicClear.Location = new System.Drawing.Point(120, 8);
            this.btnPicClear.Name = "btnPicClear";
            this.btnPicClear.Size = new System.Drawing.Size(128, 24);
            this.btnPicClear.TabIndex = 1;
            this.btnPicClear.Text = "Bild entfernen";
            this.btnPicClear.Click += new System.EventHandler(this.btnPicClear_Click);
            // 
            // ucZusatzWertImage
            // 
            this.Controls.Add(this.btnPicClear);
            this.Controls.Add(this.btnPicSave);
            this.Controls.Add(this.btnPicLoad);
            this.Controls.Add(this.picBox);
            this.Name = "ucZusatzWertImage";
            this.Size = new System.Drawing.Size(256, 88);
            this.ResumeLayout(false);

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Name setzen/auslesen
		/// </summary>
		//----------------------------------------------------------------------------
		public string ImageName
		{
			get	
			{	
				return _name;
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Name");

				_name = value;
			}
		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// Image setzen/auslesen
		/// </summary>
		//----------------------------------------------------------------------------
		public Image Image
		{
			get	
			{	
				return (Image)picBox.Image;
			}

			set	
			{	
				if (value != null)
					picBox.Image = value;
				else
					picBox.Image = picBox.DefaultImage;

				OnValueChanged(null);
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Bild laden
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnPicLoad_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = Filter();
			dlg.FileName = ImageName;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Image = Image.FromFile(dlg.FileName);
				ImageName = dlg.FileName;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Bild speichern
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnPicSave_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = Filter();
			dlg.FileName = ImageName;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Image.Save(dlg.FileName);
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Bild löschen
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnPicClear_Click(object sender, System.EventArgs e)
		{
			ImageName = "";
			Image = null;
		}

		#region IReadOnly Members

		public bool ReadOnly
		{
			get
			{
				// TODO:  Add ucZusatzWertImage.ReadOnly getter implementation
				return false;
			}
			set
			{
				// TODO:  Add ucZusatzWertImage.ReadOnly setter implementation
			}
		}

		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Open/Save Dialog Filter
		/// </summary>
		//----------------------------------------------------------------------------
		private string Filter()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("All files (*.*)|*.*");
			sb.Append("|JPEG (*.jp*)|*.jp*");
			sb.Append("|BMP (*.bmp)|*.bmp");
			sb.Append("|GIF (*.gif)|*.gif");

			return sb.ToString();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten-Änderungs signalisieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected void OnValueChanged(EventArgs args)
		{
			if (ValueChanged != null)
				ValueChanged(this, args);
		}
	}
}
