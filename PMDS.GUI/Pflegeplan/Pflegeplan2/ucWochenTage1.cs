//----------------------------------------------------------------------------
/// <summary>
///	ucWochenTage.cs - Wochentagsselektor
/// Erstellt am:	1425.10.2004
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
	public class ucWochenTage1 : QS2.Desktop.ControlManagment.BaseControl
	{
		private int					_wochentage = 0;
        public event EventHandler ASZMValueChanged;
        private bool _valueChangeEnabled = true;

		private QS2.Desktop.ControlManagment.BaseCheckBox cbMo;
		private QS2.Desktop.ControlManagment.BaseCheckBox cbDi;
		private QS2.Desktop.ControlManagment.BaseCheckBox cbMi;
		private QS2.Desktop.ControlManagment.BaseCheckBox cbDo;
		private QS2.Desktop.ControlManagment.BaseCheckBox cbFr;
		private QS2.Desktop.ControlManagment.BaseCheckBox cbSa;
		private QS2.Desktop.ControlManagment.BaseCheckBox cbSo;
		
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucWochenTage1()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Aktualisieren der Checkboxen
		/// </summary>
		//----------------------------------------------------------------------------
		private void RefreshCheckboxes()
		{
			cbMo.Checked	= (_wochentage & 1) == 0 ? false : true;
			cbDi.Checked	= (_wochentage & 2) == 0 ? false : true;
			cbMi.Checked	= (_wochentage & 4) == 0 ? false : true;
			cbDo.Checked	= (_wochentage & 8) == 0 ? false : true;
			cbFr.Checked	= (_wochentage & 16) == 0 ? false : true;
			cbSa.Checked	= (_wochentage & 32) == 0 ? false : true;
			cbSo.Checked	= (_wochentage & 64) == 0 ? false : true;
		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// Bitcodierte Wochentage - Bit 0 = Montag
		/// </summary>
		//----------------------------------------------------------------------------
		[Description("Bitcodierter Wert für die Wochentage Bit 0 = Montag")]
		public int WOCHENTAGE 
		{
			get 
			{
				_wochentage = 0;
				if(cbMo.Checked) _wochentage+=1;
				if(cbDi.Checked) _wochentage+=2;
				if(cbMi.Checked) _wochentage+=4;
				if(cbDo.Checked) _wochentage+=8;
				if(cbFr.Checked) _wochentage+=16;
				if(cbSa.Checked) _wochentage+=32;
				if(cbSo.Checked) _wochentage+=64;
				return _wochentage;
			}
			set 
			{
				_wochentage = value;
                _valueChangeEnabled = false;
				RefreshCheckboxes();
                _valueChangeEnabled = true;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Eigene ToString Funktion
		/// </summary>
		//----------------------------------------------------------------------------
		public override string ToString()
		{
			string sRet = "";           //-IntVers=NoTranslation
            if (cbMo.Checked)
				sRet += "Mo ";
			if(cbDi.Checked)
				sRet += "Di ";
			if(cbMi.Checked)
				sRet += "Mi ";
			if(cbDo.Checked)
				sRet += "Do ";
			if(cbFr.Checked)
				sRet += "Fr ";
			if(cbSa.Checked)
				sRet += "Sa ";
			if(cbSo.Checked)
				sRet += "So ";
			if(sRet.Length == 0)
				sRet = "*****";
			return sRet;
		}

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            if (_valueChangeEnabled && ASZMValueChanged != null)
                ASZMValueChanged(sender, e);
        }

		//----------------------------------------------------------------------------
		/// <summary>
		///Dispose
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
        public void setControlsAktivDisable(bool bOn)
        {
            PMDS.GUI.BaseControls.historie.OnOffControls(this, bOn);
        }

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.cbMo = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbDi = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbMi = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbDo = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbFr = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbSa = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbSo = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.SuspendLayout();
            // 
            // cbMo
            // 
            this.cbMo.Location = new System.Drawing.Point(0, 0);
            this.cbMo.Name = "cbMo";
            this.cbMo.Size = new System.Drawing.Size(40, 20);
            this.cbMo.TabIndex = 0;
            this.cbMo.Text = "Mo";
            this.cbMo.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbDi
            // 
            this.cbDi.Location = new System.Drawing.Point(40, 0);
            this.cbDi.Name = "cbDi";
            this.cbDi.Size = new System.Drawing.Size(40, 20);
            this.cbDi.TabIndex = 1;
            this.cbDi.Text = "Di";
            this.cbDi.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbMi
            // 
            this.cbMi.Location = new System.Drawing.Point(80, 0);
            this.cbMi.Name = "cbMi";
            this.cbMi.Size = new System.Drawing.Size(40, 20);
            this.cbMi.TabIndex = 2;
            this.cbMi.Text = "Mi";
            this.cbMi.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbDo
            // 
            this.cbDo.Location = new System.Drawing.Point(120, 0);
            this.cbDo.Name = "cbDo";
            this.cbDo.Size = new System.Drawing.Size(40, 20);
            this.cbDo.TabIndex = 3;
            this.cbDo.Text = "Do";
            this.cbDo.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbFr
            // 
            this.cbFr.Location = new System.Drawing.Point(160, 0);
            this.cbFr.Name = "cbFr";
            this.cbFr.Size = new System.Drawing.Size(40, 20);
            this.cbFr.TabIndex = 4;
            this.cbFr.Text = "Fr";
            this.cbFr.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbSa
            // 
            this.cbSa.Location = new System.Drawing.Point(200, 0);
            this.cbSa.Name = "cbSa";
            this.cbSa.Size = new System.Drawing.Size(40, 20);
            this.cbSa.TabIndex = 5;
            this.cbSa.Text = "Sa";
            this.cbSa.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cbSo
            // 
            this.cbSo.Location = new System.Drawing.Point(240, 0);
            this.cbSo.Name = "cbSo";
            this.cbSo.Size = new System.Drawing.Size(40, 20);
            this.cbSo.TabIndex = 6;
            this.cbSo.Text = "So";
            this.cbSo.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // ucWochenTage1
            // 
            this.Controls.Add(this.cbSo);
            this.Controls.Add(this.cbSa);
            this.Controls.Add(this.cbFr);
            this.Controls.Add(this.cbDo);
            this.Controls.Add(this.cbMi);
            this.Controls.Add(this.cbDi);
            this.Controls.Add(this.cbMo);
            this.Name = "ucWochenTage1";
            this.Size = new System.Drawing.Size(280, 18);
            this.ResumeLayout(false);

		}
		#endregion
	}
}
