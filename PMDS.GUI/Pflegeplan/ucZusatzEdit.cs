//----------------------------------------------------------------------------
/// <summary>
///	ucZusatzEdit.cs
/// Erstellt am:	01.10.2004
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
using PMDS.Data.Global;
using PMDS.GUI.Engines;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zum Bearbeiten der ZusatzGruppen.
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucZusatzEdit : QS2.Desktop.ControlManagment.BaseControl, IClose
	{
		private EngineVerwaltung _verwaltung;

		private PMDS.GUI.ucButton btnUndo;
		private PMDS.GUI.ucButton btnSave;
		private QS2.Desktop.ControlManagment.BaseComboEditor cbGruppe;
		private System.ComponentModel.IContainer components;
		private dsIDListe dsIDListe1;
		private QS2.Desktop.ControlManagment.BaseLabel lblzusatzGruppe;
		private QS2.Desktop.ControlManagment.BaseButton btnEntry;
		private PMDS.GUI.ucZusatz ucZusatz1;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucZusatzEdit()
		{
			InitializeComponent();

            btnEntry.Visible = ENV.HasRight(UserRights.Stammdatenverwaltung);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucZusatzEdit));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            PMDS.BusinessLogic.ZusatzGruppe zusatzGruppe1 = new PMDS.BusinessLogic.ZusatzGruppe();
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.cbGruppe = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.dsIDListe1 = new PMDS.Global.db.Global.dsIDListe();
            this.lblzusatzGruppe = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucZusatz1 = new PMDS.GUI.ucZusatz();
            this.btnEntry = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbGruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsIDListe1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUndo.Appearance = appearance1;
            this.btnUndo.AutoWorkLayout = false;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUndo.DoOnClick = true;
            this.btnUndo.IsStandardControl = true;
            this.btnUndo.Location = new System.Drawing.Point(376, 224);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(96, 32);
            this.btnUndo.TabIndex = 14;
            this.btnUndo.TabStop = false;
            this.btnUndo.Text = "Rückgängig";
            this.btnUndo.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnUndo.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance2;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DoOnClick = true;
            this.btnSave.IsStandardControl = true;
            this.btnSave.Location = new System.Drawing.Point(472, 224);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 32);
            this.btnSave.TabIndex = 15;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // cbGruppe
            // 
            this.cbGruppe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGruppe.Location = new System.Drawing.Point(96, 8);
            this.cbGruppe.Name = "cbGruppe";
            this.cbGruppe.Size = new System.Drawing.Size(408, 21);
            this.cbGruppe.TabIndex = 16;
            // 
            // dsIDListe1
            // 
            this.dsIDListe1.DataSetName = "dsIDListe";
            this.dsIDListe1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsIDListe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblzusatzGruppe
            // 
            this.lblzusatzGruppe.AutoSize = true;
            this.lblzusatzGruppe.Location = new System.Drawing.Point(8, 11);
            this.lblzusatzGruppe.Name = "lblzusatzGruppe";
            this.lblzusatzGruppe.Size = new System.Drawing.Size(79, 14);
            this.lblzusatzGruppe.TabIndex = 18;
            this.lblzusatzGruppe.Text = "ZusatzGruppe:";
            // 
            // ucZusatz1
            // 
            this.ucZusatz1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucZusatz1.Location = new System.Drawing.Point(0, 0);
            this.ucZusatz1.Name = "ucZusatz1";
            this.ucZusatz1.Size = new System.Drawing.Size(576, 224);
            this.ucZusatz1.TabIndex = 19;
            this.ucZusatz1.ZusatzGruppe = zusatzGruppe1;
            // 
            // btnEntry
            // 
            this.btnEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEntry.AutoWorkLayout = false;
            this.btnEntry.IsStandardControl = false;
            this.btnEntry.Location = new System.Drawing.Point(8, 224);
            this.btnEntry.Name = "btnEntry";
            this.btnEntry.Size = new System.Drawing.Size(96, 32);
            this.btnEntry.TabIndex = 20;
            this.btnEntry.Text = "Einträge";
            this.btnEntry.Click += new System.EventHandler(this.btnEntry_Click);
            // 
            // ucZusatzEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnEntry);
            this.Controls.Add(this.lblzusatzGruppe);
            this.Controls.Add(this.cbGruppe);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ucZusatz1);
            this.Name = "ucZusatzEdit";
            this.Size = new System.Drawing.Size(576, 256);
            this.Load += new System.EventHandler(this.ucZusatzEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbGruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsIDListe1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Engine einhängen
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucZusatzEdit_Load(object sender, System.EventArgs e)
		{
			try
			{
				_verwaltung = new EngineVerwaltung(cbGruppe, ucZusatz1, 
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
		/// Eintragsverwaltung anstossen
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnEntry_Click(object sender, System.EventArgs e)
		{
			frmZusatzEintrag frm = new frmZusatzEintrag();
			frm.ShowDialog();

			ucZusatz1.InitCombo();
			_verwaltung.RefreshSelector();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Verwaltung nur zuläassig wenn keine Änderung
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnSave_EnabledChanged(object sender, EventArgs e)
		{
			btnEntry.Enabled = !btnSave.Enabled;
		}
	}
}
