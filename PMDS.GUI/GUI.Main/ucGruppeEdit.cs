//----------------------------------------------------------------------------
/// <summary>
///	ucGruppeEdit.cs
/// Erstellt am:	14.10.2004
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
	/// Control zum Bearbeiten der Gruppen-Daten.
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucGruppeEdit : QS2.Desktop.ControlManagment.BaseControl, IClose
	{
		private EngineVerwaltung _verwaltung;

		private PMDS.GUI.ucButton btnUndo;
		private PMDS.GUI.ucButton btnDel;
		private PMDS.GUI.ucButton btnSave;
		private PMDS.GUI.ucButton btnAdd;
		private QS2.Desktop.ControlManagment.BaseLabel lblGruppe;
		private dsGUIDListe dsGUIDListe1;
		private QS2.Desktop.ControlManagment.BaseComboEditor cbGruppe;
		private PMDS.GUI.ucGruppe ucGruppe1;
		private System.ComponentModel.IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucGruppeEdit()
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucGruppeEdit));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            PMDS.BusinessLogic.Gruppe gruppe1 = new PMDS.BusinessLogic.Gruppe();
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.cbGruppe = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.dsGUIDListe1 = new dsGUIDListe();
            this.lblGruppe = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucGruppe1 = new PMDS.GUI.ucGruppe();
            ((System.ComponentModel.ISupportInitialize)(this.cbGruppe)).BeginInit();
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
            this.btnSave.Location = new System.Drawing.Point(384, 384);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 32);
            this.btnSave.TabIndex = 6;
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
            this.btnUndo.Location = new System.Drawing.Point(280, 384);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(96, 32);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.TabStop = false;
            this.btnUndo.Text = "Rückgängig";
            this.btnUndo.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnUndo.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance3;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(112, 384);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(96, 32);
            this.btnDel.TabIndex = 4;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "Entfernen";
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance4;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(8, 384);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 32);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Hinzufügen";
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // cbGruppe
            // 
            this.cbGruppe.Location = new System.Drawing.Point(88, 16);
            this.cbGruppe.Name = "cbGruppe";
            this.cbGruppe.Size = new System.Drawing.Size(160, 21);
            this.cbGruppe.TabIndex = 1;
            // 
            // dsGUIDListe1
            // 
            this.dsGUIDListe1.DataSetName = "dsGUIDListe";
            this.dsGUIDListe1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsGUIDListe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblGruppe
            // 
            this.lblGruppe.AutoSize = true;
            this.lblGruppe.Location = new System.Drawing.Point(16, 19);
            this.lblGruppe.Name = "lblGruppe";
            this.lblGruppe.Size = new System.Drawing.Size(45, 14);
            this.lblGruppe.TabIndex = 0;
            this.lblGruppe.Text = "Gruppe:";
            // 
            // ucGruppe1
            // 
            this.ucGruppe1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gruppe1.Bezeichnung = "";
            gruppe1.ID = new System.Guid("3599f91a-9f63-47dc-ace8-8fe865198646");
            this.ucGruppe1.Gruppe = gruppe1;
            this.ucGruppe1.Location = new System.Drawing.Point(0, 40);
            this.ucGruppe1.Name = "ucGruppe1";
            this.ucGruppe1.Size = new System.Drawing.Size(488, 344);
            this.ucGruppe1.TabIndex = 2;
            // 
            // ucGruppeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.ucGruppe1);
            this.Controls.Add(this.lblGruppe);
            this.Controls.Add(this.cbGruppe);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDel);
            this.Name = "ucGruppeEdit";
            this.Size = new System.Drawing.Size(488, 424);
            this.Load += new System.EventHandler(this.ucBenutzerEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbGruppe)).EndInit();
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
		private void ucBenutzerEdit_Load(object sender, System.EventArgs e)
		{
			try
			{
				_verwaltung = new EngineVerwaltung(cbGruppe, ucGruppe1, 
					btnAdd, btnDel, btnUndo, btnSave);
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

	}
}
