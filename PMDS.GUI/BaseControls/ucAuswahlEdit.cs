//----------------------------------------------------------------------------
/// <summary>
///	ucAuswahlEdit.cs
/// Erstellt am:	16.9.2004
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
	/// Control zum Bearbeiten der AuswahlGruppen.
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucAuswahlEdit : QS2.Desktop.ControlManagment.BaseControl, IClose
	{
		private EngineVerwaltung _verwaltung;

		private QS2.Desktop.ControlManagment.BaseComboEditor cbGruppe;
		private System.ComponentModel.IContainer components;
		private QS2.Desktop.ControlManagment.BaseLabel lblGruppe;
		private PMDS.GUI.ucAuswahl ucAuswahl1;
        public ucButton btnUndo;
        public ucButton btnSave;
        private dsGUIDListe dsGUIDListe1;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucAuswahlEdit()
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
            PMDS.BusinessLogic.AuswahlGruppe auswahlGruppe1 = new PMDS.BusinessLogic.AuswahlGruppe();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAuswahlEdit));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.cbGruppe = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.dsGUIDListe1 = new PMDS.Global.db.Global.dsGUIDListe();
            this.lblGruppe = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucAuswahl1 = new PMDS.GUI.ucAuswahl();
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cbGruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGUIDListe1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbGruppe
            // 
            this.cbGruppe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGruppe.Location = new System.Drawing.Point(72, 8);
            this.cbGruppe.Name = "cbGruppe";
            this.cbGruppe.Size = new System.Drawing.Size(492, 21);
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
            this.lblGruppe.Location = new System.Drawing.Point(16, 11);
            this.lblGruppe.Name = "lblGruppe";
            this.lblGruppe.Size = new System.Drawing.Size(45, 14);
            this.lblGruppe.TabIndex = 0;
            this.lblGruppe.Text = "Gruppe:";
            // 
            // ucAuswahl1
            // 
            this.ucAuswahl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            auswahlGruppe1.Bezeichnung = "";
            auswahlGruppe1.ID = "";
            this.ucAuswahl1.AuswahlGruppe = auswahlGruppe1;
            this.ucAuswahl1.Location = new System.Drawing.Point(8, 8);
            this.ucAuswahl1.Name = "ucAuswahl1";
            this.ucAuswahl1.Size = new System.Drawing.Size(684, 443);
            this.ucAuswahl1.TabIndex = 2;
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
            this.btnUndo.Location = new System.Drawing.Point(492, 459);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(96, 32);
            this.btnUndo.TabIndex = 3;
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
            this.btnSave.Location = new System.Drawing.Point(596, 459);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 32);
            this.btnSave.TabIndex = 4;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // ucAuswahlEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblGruppe);
            this.Controls.Add(this.cbGruppe);
            this.Controls.Add(this.ucAuswahl1);
            this.Name = "ucAuswahlEdit";
            this.Size = new System.Drawing.Size(700, 491);
            this.Load += new System.EventHandler(this.ucAuswahl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbGruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGUIDListe1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Die AuswahlGruppen-Liste befüllen.
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucAuswahl_Load(object sender, System.EventArgs e)
		{
			try
			{
				string oldGroup = Group;

                this.ucAuswahl1.mainWindow = this;
				_verwaltung = new EngineVerwaltung(cbGruppe, ucAuswahl1, 
					null, null, btnUndo, btnSave);

				if ((oldGroup != null) && (oldGroup != ""))
					Group = oldGroup;
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
		/// aktuelle Gruppe
		/// </summary>
		//----------------------------------------------------------------------------
		public string Group
		{
			get	{	return (string)cbGruppe.Value;	}
			set	{	cbGruppe.Value = value;	}
		}

    }
}
