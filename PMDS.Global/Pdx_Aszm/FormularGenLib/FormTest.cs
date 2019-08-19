using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Xml;
using System.Text;
using System.IO;



namespace FormularGen
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormTest : System.Windows.Forms.Form
	{


		private FormularGen.ucFormular ucFormular1;
		private System.Windows.Forms.Button btnNewPage;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.CheckBox cbEnabled;
		private System.Windows.Forms.Button btnPrint;

		private System.Windows.Forms.Label label1;
		private FormularGen.ucFormularTreeView tvmain;
		private System.Windows.Forms.Button btnDeletePage;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rbPortrait;
		private System.Windows.Forms.RadioButton rbLandscape;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rbA3;
		private System.Windows.Forms.RadioButton rbA4;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.OpenFileDialog dlgOpen;
		private System.Windows.Forms.SaveFileDialog dlgSave;
		private System.Windows.Forms.RadioButton rbA5;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnLoadData;
		private System.Windows.Forms.Button btnSaveData;
		private System.Windows.Forms.SaveFileDialog dlgSaveData;
		private System.Windows.Forms.OpenFileDialog dlgOpenData;
		private System.Windows.Forms.CheckBox cbTab;
		private System.Windows.Forms.CheckBox cbAllowAddPictures;
		private System.Windows.Forms.CheckBox cbReadOnly;
		private System.Windows.Forms.ComboBox cbPageMode;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormTest()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			ucFormular1.FORMULAR = new Formular();
			ucFormular1.ContentChanged +=new EventHandler(ucFormular1_ContentChanged);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            this.btnNewPage = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeletePage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbA5 = new System.Windows.Forms.RadioButton();
            this.rbA3 = new System.Windows.Forms.RadioButton();
            this.rbA4 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbLandscape = new System.Windows.Forms.RadioButton();
            this.rbPortrait = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.dlgSaveData = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpenData = new System.Windows.Forms.OpenFileDialog();
            this.cbTab = new System.Windows.Forms.CheckBox();
            this.cbAllowAddPictures = new System.Windows.Forms.CheckBox();
            this.cbReadOnly = new System.Windows.Forms.CheckBox();
            this.cbPageMode = new System.Windows.Forms.ComboBox();
            this.tvmain = new FormularGen.ucFormularTreeView();
            this.ucFormular1 = new FormularGen.ucFormular();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewPage
            // 
            this.btnNewPage.Location = new System.Drawing.Point(8, 32);
            this.btnNewPage.Name = "btnNewPage";
            this.btnNewPage.Size = new System.Drawing.Size(75, 23);
            this.btnNewPage.TabIndex = 1;
            this.btnNewPage.Text = "Neue Seite";
            this.btnNewPage.Click += new System.EventHandler(this.btnNewPage_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "1000",
            "500",
            "400",
            "300",
            "200",
            "100",
            "75",
            "50",
            "25",
            "10"});
            this.comboBox1.Location = new System.Drawing.Point(592, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(72, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cbEnabled
            // 
            this.cbEnabled.Location = new System.Drawing.Point(408, 8);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(64, 24);
            this.cbEnabled.TabIndex = 4;
            this.cbEnabled.Text = "enabled";
            this.cbEnabled.CheckedChanged += new System.EventHandler(this.cbEnabled_CheckedChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(472, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "drucken";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(552, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Zoom";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDeletePage
            // 
            this.btnDeletePage.Location = new System.Drawing.Point(8, 80);
            this.btnDeletePage.Name = "btnDeletePage";
            this.btnDeletePage.Size = new System.Drawing.Size(176, 23);
            this.btnDeletePage.TabIndex = 8;
            this.btnDeletePage.Text = "Seite löschen";
            this.btnDeletePage.Click += new System.EventHandler(this.btnDeletePage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnNewPage);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 72);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbA5);
            this.groupBox3.Controls.Add(this.rbA3);
            this.groupBox3.Controls.Add(this.rbA4);
            this.groupBox3.Location = new System.Drawing.Point(232, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(128, 48);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // rbA5
            // 
            this.rbA5.Location = new System.Drawing.Point(64, 8);
            this.rbA5.Name = "rbA5";
            this.rbA5.Size = new System.Drawing.Size(40, 16);
            this.rbA5.TabIndex = 2;
            this.rbA5.Text = "A5";
            // 
            // rbA3
            // 
            this.rbA3.Location = new System.Drawing.Point(8, 24);
            this.rbA3.Name = "rbA3";
            this.rbA3.Size = new System.Drawing.Size(40, 16);
            this.rbA3.TabIndex = 1;
            this.rbA3.Text = "A3";
            // 
            // rbA4
            // 
            this.rbA4.Checked = true;
            this.rbA4.Location = new System.Drawing.Point(8, 8);
            this.rbA4.Name = "rbA4";
            this.rbA4.Size = new System.Drawing.Size(48, 16);
            this.rbA4.TabIndex = 0;
            this.rbA4.TabStop = true;
            this.rbA4.Text = "A4";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbLandscape);
            this.groupBox2.Controls.Add(this.rbPortrait);
            this.groupBox2.Location = new System.Drawing.Point(88, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 48);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // rbLandscape
            // 
            this.rbLandscape.Location = new System.Drawing.Point(8, 24);
            this.rbLandscape.Name = "rbLandscape";
            this.rbLandscape.Size = new System.Drawing.Size(104, 16);
            this.rbLandscape.TabIndex = 1;
            this.rbLandscape.Text = "Querformat";
            // 
            // rbPortrait
            // 
            this.rbPortrait.Checked = true;
            this.rbPortrait.Location = new System.Drawing.Point(8, 8);
            this.rbPortrait.Name = "rbPortrait";
            this.rbPortrait.Size = new System.Drawing.Size(104, 16);
            this.rbPortrait.TabIndex = 0;
            this.rbPortrait.TabStop = true;
            this.rbPortrait.Text = "Hochformat";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(408, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "speichern";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(488, 32);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "laden";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(568, 32);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 12;
            this.btnNew.Text = "neu";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.CheckFileExists = false;
            this.dlgOpen.Filter = "Formulardateien|*.S2frm";
            this.dlgOpen.RestoreDirectory = true;
            // 
            // dlgSave
            // 
            this.dlgSave.Filter = "Formulardateien|*.S2frm";
            this.dlgSave.RestoreDirectory = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLoadData);
            this.groupBox4.Controls.Add(this.btnSaveData);
            this.groupBox4.Location = new System.Drawing.Point(704, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(256, 56);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Daten";
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(128, 16);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 13;
            this.btnLoadData.Text = "laden";
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnSaveData
            // 
            this.btnSaveData.Location = new System.Drawing.Point(48, 16);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(75, 23);
            this.btnSaveData.TabIndex = 12;
            this.btnSaveData.Text = "speichern";
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // dlgSaveData
            // 
            this.dlgSaveData.Filter = "Formulardatendateien|*.S2frmdata";
            this.dlgSaveData.RestoreDirectory = true;
            // 
            // dlgOpenData
            // 
            this.dlgOpenData.CheckFileExists = false;
            this.dlgOpenData.Filter = "Formulardatendateien (*.S2frmdata)|*.S2frmdata";
            this.dlgOpenData.RestoreDirectory = true;
            // 
            // cbTab
            // 
            this.cbTab.Checked = true;
            this.cbTab.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTab.Location = new System.Drawing.Point(408, 56);
            this.cbTab.Name = "cbTab";
            this.cbTab.Size = new System.Drawing.Size(160, 16);
            this.cbTab.TabIndex = 14;
            this.cbTab.Text = "Als Karteireiter anzeigen";
            this.cbTab.CheckedChanged += new System.EventHandler(this.cbTab_CheckedChanged);
            // 
            // cbAllowAddPictures
            // 
            this.cbAllowAddPictures.Location = new System.Drawing.Point(192, 80);
            this.cbAllowAddPictures.Name = "cbAllowAddPictures";
            this.cbAllowAddPictures.Size = new System.Drawing.Size(216, 16);
            this.cbAllowAddPictures.TabIndex = 15;
            this.cbAllowAddPictures.Text = "Bilddokumentation aktivieren";
            this.cbAllowAddPictures.CheckedChanged += new System.EventHandler(this.cbAllowAddPictures_CheckedChanged);
            // 
            // cbReadOnly
            // 
            this.cbReadOnly.Location = new System.Drawing.Point(576, 56);
            this.cbReadOnly.Name = "cbReadOnly";
            this.cbReadOnly.Size = new System.Drawing.Size(104, 16);
            this.cbReadOnly.TabIndex = 16;
            this.cbReadOnly.Text = "Readonly";
            this.cbReadOnly.CheckedChanged += new System.EventHandler(this.cbReadOnly_CheckedChanged);
            // 
            // cbPageMode
            // 
            this.cbPageMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPageMode.Items.AddRange(new object[] {
            "Design,",
            "Editable,",
            "Readonly"});
            this.cbPageMode.Location = new System.Drawing.Point(696, 64);
            this.cbPageMode.Name = "cbPageMode";
            this.cbPageMode.Size = new System.Drawing.Size(176, 21);
            this.cbPageMode.TabIndex = 17;
            this.cbPageMode.SelectedIndexChanged += new System.EventHandler(this.cbPageMode_SelectedIndexChanged);
            // 
            // tvmain
            // 
            this.tvmain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tvmain.FORMULAR = null;
            this.tvmain.Location = new System.Drawing.Point(8, 104);
            this.tvmain.Name = "tvmain";
            this.tvmain.Size = new System.Drawing.Size(176, 600);
            this.tvmain.TabIndex = 7;
            // 
            // ucFormular1
            // 
            this.ucFormular1.ADDPICTURESALLOWED = false;
            this.ucFormular1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucFormular1.BackColor = System.Drawing.Color.Transparent;
            this.ucFormular1.FORMULAR = null;
            this.ucFormular1.FORMULARSTYLE = FormularGen.FormularStyle.Tab;
            this.ucFormular1.Location = new System.Drawing.Point(192, 112);
            this.ucFormular1.Name = "ucFormular1";
            this.ucFormular1.PAGEMODE = FormularGen.PageMode.Design;
            this.ucFormular1.ReadOnly = false;
            this.ucFormular1.SELECTBOX = false;
            this.ucFormular1.Size = new System.Drawing.Size(768, 592);
            this.ucFormular1.TabIndex = 0;
            this.ucFormular1.ZOOM = 100;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(968, 718);
            this.Controls.Add(this.cbPageMode);
            this.Controls.Add(this.cbReadOnly);
            this.Controls.Add(this.cbAllowAddPictures);
            this.Controls.Add(this.cbTab);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDeletePage);
            this.Controls.Add(this.tvmain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cbEnabled);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ucFormular1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulargenerator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>


		private void btnNewPage_Click(object sender, System.EventArgs e)
		{
			Page.PageFormat pf = rbA4.Checked ? Page.PageFormat.A4 : rbA5.Checked ? Page.PageFormat.A5 : Page.PageFormat.A3;
			Page.PageOrientation po = rbPortrait.Checked ? Page.PageOrientation.Portrait : Page.PageOrientation.Landscape;
			ucFormular1.NewPage(pf, po);
			TogglePagemode();
		}

		private void TogglePagemode()
		{
			if(cbEnabled.Checked)
				ucFormular1.PAGEMODE = PageMode.Editable;
			else
				ucFormular1.PAGEMODE = PageMode.Design;
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int i = Convert.ToInt32(comboBox1.Text);
			if (i>0)
				ucFormular1.ZOOM = i;
		}


		private void cbEnabled_CheckedChanged(object sender, System.EventArgs e)
		{
			TogglePagemode();
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			ucFormular1.PrintFormular();
		}


		public void NewFormular() 
		{
			Formular f = new Formular();
			ucFormular1.FORMULAR = f;
			TogglePagemode();
			ucFormular1.Refresh();
			tvmain.FORMULAR = f;
		}

		private void RefreshHeader(string sFile) 
		{
			this.Text = sFile;
		}


		public bool LoadFormular() 
		{
			dlgOpen.InitialDirectory = ".\\";
			DialogResult res =  dlgOpen.ShowDialog();
			
			if(res != DialogResult.OK)
				return false;

			string sFile = dlgOpen.FileName;
			string sFileOnly = Path.GetFileNameWithoutExtension(sFile);

			Formular f = new Formular();
			f.LoadFormular(sFile);
			ucFormular1.FORMULAR = f;
			TogglePagemode();
			ucFormular1.Refresh();
			RefreshHeader(sFileOnly);
			cbAllowAddPictures.Checked = ucFormular1.ADDPICTURESALLOWED;

//			Formular f1 = new Formular();
//			string s = f.SaveFormularToString("JAJA");
//			f1.LoadFromularFromString(s);
			return true;
		}

		public bool SaveFormular() 
		{
			string sOldDir = Environment.CurrentDirectory;
			try 
			{
				dlgSave.InitialDirectory = ".\\";
				DialogResult res =  dlgSave.ShowDialog();
			
				if(res != DialogResult.OK)
					return false;

				string sFile = dlgSave.FileName;
				string sFileOnly = Path.GetFileNameWithoutExtension(sFile);
			
				XmlTextWriter w = new XmlTextWriter(sFile, Encoding.UTF8);
				w.Formatting = Formatting.Indented;
				ucFormular1.FORMULAR.SaveFormular(w, sFileOnly + ".S2frm");
				w.Close();
				RefreshHeader(ucFormular1.FORMULAR.FORMULARNAME);
				//Process p = Process.Start("notepad.exe", sFile);
				return true;
			}
			finally
			{
				Environment.CurrentDirectory = sOldDir;
			}
		}

		public bool SaveFormularData() 
		{
			if(ucFormular1.FORMULAR.FORMULARNAME == "")
			{
				MessageBox.Show("Formular hat nich keine Namen \r\nBitte speichern Sie das Formular zuerst");
				return false;
			}

			dlgSaveData.InitialDirectory = ".\\";
			DialogResult res =  dlgSaveData.ShowDialog();
			
			if(res != DialogResult.OK)
				return false;

			string sFile = dlgSaveData.FileName;
			string sFileOnly = Path.GetFileNameWithoutExtension(sFile);
			
			XmlTextWriter w = new XmlTextWriter(sFile, Encoding.UTF8);
			w.Formatting = Formatting.Indented;
			ucFormular1.FORMULAR.SaveFormularData(w, Guid.NewGuid(), "Reini", "Kein Klient", System.DateTime.Now.ToString());

			w.Close();
			//Process p = Process.Start("notepad.exe", sFile);
			return true;
		}


		public bool LoadFormularData() 
		{
			if(ucFormular1.FORMULAR.FORMULARNAME == "")
			{
				MessageBox.Show("Formular ist nicht geladen\r\nBitte laden Sie das Formular zuerst");
				return false;
			}

			try 
			{
				dlgOpenData.InitialDirectory = ".\\";
				DialogResult res =  dlgOpenData.ShowDialog();
			
				if(res != DialogResult.OK)
					return false;

				string sFile = dlgOpenData.FileName;
				string sFileOnly = Path.GetFileNameWithoutExtension(sFile);

				Formular f = ucFormular1.FORMULAR;
				f.LoadFormularData(sFile);
				ucFormular1.Refresh();
				ucFormular1.RefreshLabels();
				return true;
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
		}

		private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		
		}

		private void ucFormular1_ContentChanged(object sender, EventArgs e)
		{
			tvmain.FORMULAR = ucFormular1.FORMULAR;
			ucFormular1.RefreshLabels();
		}

		private void btnDeletePage_Click(object sender, System.EventArgs e)
		{
			ucFormular1.RemovePage(tvmain.SELECTEDPAGE);
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			SaveFormular();
		}

		private void btnLoad_Click(object sender, System.EventArgs e)
		{
			LoadFormular();
		}

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			NewFormular();
		}

		private void btnSaveData_Click(object sender, System.EventArgs e)
		{
			SaveFormularData();
		}

		private void btnLoadData_Click(object sender, System.EventArgs e)
		{
			LoadFormularData();
		}

		private void cbTab_CheckedChanged(object sender, System.EventArgs e)
		{
			ucFormular1.FORMULARSTYLE = cbTab.Checked ? FormularStyle.Tab : FormularStyle.Endless;
		}

		private void cbAllowAddPictures_CheckedChanged(object sender, System.EventArgs e)
		{
			ucFormular1.ADDPICTURESALLOWED = cbAllowAddPictures.Checked;
		}

		private void cbReadOnly_CheckedChanged(object sender, System.EventArgs e)
		{
			ucFormular1.ReadOnly = cbReadOnly.Checked;
		}

		private void cbPageMode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cbPageMode.SelectedIndex > -1)
				ucFormular1.PAGEMODE = (PageMode)cbPageMode.SelectedIndex;
		}
	}
}
