//----------------------------------------------------------------------------
/// <summary>
///	ucBenutzerGruppeEdit.cs
/// Erstellt am:	15.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.GUI.Engines;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Control zum Bearbeiten der BenutzerGruppen-Daten.
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucBenutzerGruppeEdit : QS2.Desktop.ControlManagment.BaseControl, IClose
	{
		private EngineVerwaltung _verwaltung;

		private PMDS.GUI.ucButton btnUndo;
		private PMDS.GUI.ucButton btnSave;
		private QS2.Desktop.ControlManagment.BaseLabel lblBenutzer;
		private dsGUIDListe dsGUIDListe1;
		private QS2.Desktop.ControlManagment.BaseComboEditor cbBenutzer;
		private PMDS.GUI.ucBenutzerGruppe ucBenutzerGruppe1;
		private QS2.Desktop.ControlManagment.BaseButton btnGroup;
		private System.ComponentModel.IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucBenutzerGruppeEdit()
		{
			InitializeComponent();

            btnGroup.Visible = true;        // ENV.HasRight(UserRights.ManageGroupRights);
			btnSave.EnabledChanged += new EventHandler(btnSave_EnabledChanged);
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBenutzerGruppeEdit));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            PMDS.BusinessLogic.Benutzer benutzer1 = new PMDS.BusinessLogic.Benutzer();
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.cbBenutzer = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.dsGUIDListe1 = new dsGUIDListe();
            this.lblBenutzer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucBenutzerGruppe1 = new PMDS.GUI.ucBenutzerGruppe();
            this.btnGroup = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbBenutzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGUIDListe1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance1;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DoOnClick = true;
            this.btnSave.IsStandardControl = true;
            this.btnSave.Location = new System.Drawing.Point(776, 466);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 32);
            this.btnSave.TabIndex = 4;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUndo.Appearance = appearance2;
            this.btnUndo.AutoWorkLayout = false;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUndo.DoOnClick = true;
            this.btnUndo.IsStandardControl = true;
            this.btnUndo.Location = new System.Drawing.Point(646, 466);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(122, 32);
            this.btnUndo.TabIndex = 3;
            this.btnUndo.TabStop = false;
            this.btnUndo.Text = "Rückgängig";
            this.btnUndo.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnUndo.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // cbBenutzer
            // 
            this.cbBenutzer.Location = new System.Drawing.Point(88, 16);
            this.cbBenutzer.Name = "cbBenutzer";
            this.cbBenutzer.Size = new System.Drawing.Size(160, 24);
            this.cbBenutzer.TabIndex = 1;
            // 
            // dsGUIDListe1
            // 
            this.dsGUIDListe1.DataSetName = "dsGUIDListe";
            this.dsGUIDListe1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsGUIDListe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblBenutzer
            // 
            this.lblBenutzer.AutoSize = true;
            this.lblBenutzer.Location = new System.Drawing.Point(16, 19);
            this.lblBenutzer.Name = "lblBenutzer";
            this.lblBenutzer.Size = new System.Drawing.Size(64, 17);
            this.lblBenutzer.TabIndex = 0;
            this.lblBenutzer.Text = "Benutzer:";
            // 
            // ucBenutzerGruppe1
            // 
            this.ucBenutzerGruppe1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBenutzerGruppe1.AutoSize = true;
            this.ucBenutzerGruppe1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            benutzer1.AktivJN = true;
            benutzer1.ArztabrechnungJN = false;
            benutzer1.BenutzerName = "";
            benutzer1.ID = new System.Guid("bbae731f-c0fe-4450-8b62-9c19c2cab3af");
            benutzer1.IDAdresse = new System.Guid("00000000-0000-0000-0000-000000000000");
            benutzer1.IDArzt = null;
            benutzer1.IDBerufsstand = new System.Guid("00000000-0000-0000-0000-000000000000");
            benutzer1.IDKontakt = new System.Guid("00000000-0000-0000-0000-000000000000");
            benutzer1.IsGeneric = false;
            benutzer1.Nachname = "";
            benutzer1.Passwort = "B3F3B38B253462A13F44755C9B65AABF";
            benutzer1.PflegerJN = false;
            benutzer1.Vorname = "";
            this.ucBenutzerGruppe1.Benutzer = benutzer1;
            this.ucBenutzerGruppe1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucBenutzerGruppe1.Location = new System.Drawing.Point(0, 48);
            this.ucBenutzerGruppe1.Margin = new System.Windows.Forms.Padding(5);
            this.ucBenutzerGruppe1.Name = "ucBenutzerGruppe1";
            this.ucBenutzerGruppe1.Size = new System.Drawing.Size(877, 412);
            this.ucBenutzerGruppe1.TabIndex = 2;
            // 
            // btnGroup
            // 
            this.btnGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGroup.AutoWorkLayout = false;
            this.btnGroup.IsStandardControl = false;
            this.btnGroup.Location = new System.Drawing.Point(8, 466);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(96, 32);
            this.btnGroup.TabIndex = 19;
            this.btnGroup.Text = "Gruppen";
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // ucBenutzerGruppeEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btnGroup);
            this.Controls.Add(this.ucBenutzerGruppe1);
            this.Controls.Add(this.lblBenutzer);
            this.Controls.Add(this.cbBenutzer);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name = "ucBenutzerGruppeEdit";
            this.Size = new System.Drawing.Size(880, 506);
            this.Load += new System.EventHandler(this.ucBenutzerGruppeEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbBenutzer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGUIDListe1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Engine einhängen
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucBenutzerGruppeEdit_Load(object sender, System.EventArgs e)
		{
			try
			{
				_verwaltung = new EngineVerwaltung(cbBenutzer, ucBenutzerGruppe1, 
					null, null, btnUndo, btnSave);
			}
			catch(Exception ex)
			{
				ENV.HandleException(ex);
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Beendigung möglich
		/// </summary>
		//----------------------------------------------------------------------------
		public bool CanClose
		{
			get	{	return _verwaltung.CanClose;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Gruppenverwaltung anstossen
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnGroup_Click(object sender, System.EventArgs e)
		{
			frmGruppe frm = new frmGruppe();
			frm.ShowDialog();
			ucBenutzerGruppe1.InitGruppen();
			_verwaltung.RefreshSelector();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Gruppenverwaltung nur zuläassig wenn keine Änderung
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnSave_EnabledChanged(object sender, EventArgs e)
		{
			btnGroup.Enabled = !btnSave.Enabled;
		}
	}
}
