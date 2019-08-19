//----------------------------------------------------------------------------
/// <summary>
///	ucEinrichtungEdit.cs
/// Erstellt am:	22.9.2004
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
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Control zum Bearbeiten der Einrichtungs-Daten.
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucEinrichtungEdit : QS2.Desktop.ControlManagment.BaseControl, IClose
	{
		private EngineVerwaltung _verwaltung;

		private PMDS.GUI.ucEinrichtung ucEinrichtung1;
		private PMDS.GUI.ucButton btnAdd;
		private PMDS.GUI.ucButton btnUndo;
		private PMDS.GUI.ucButton btnSave;
		private PMDS.GUI.ucButton btnDel;
		private QS2.Desktop.ControlManagment.BaseLabel lblEinrichtung;
		private QS2.Desktop.ControlManagment.BaseComboEditor cbEinrichtung;
		private dsGUIDListe dsGUIDListe1;
		private System.ComponentModel.IContainer components;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucEinrichtungEdit()
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
            PMDS.BusinessLogic.Einrichtung einrichtung1 = new PMDS.BusinessLogic.Einrichtung();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEinrichtungEdit));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.ucEinrichtung1 = new PMDS.GUI.ucEinrichtung();
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.lblEinrichtung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbEinrichtung = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.dsGUIDListe1 = new PMDS.Global.db.Global.dsGUIDListe();
            ((System.ComponentModel.ISupportInitialize)(this.cbEinrichtung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGUIDListe1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucEinrichtung1
            // 
            this.ucEinrichtung1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            einrichtung1.Bezeichnung = "";
            einrichtung1.ELGA_OID = "";
            einrichtung1.ELGAAbgeglichen = false;
            //einrichtung1.ID = new System.Guid("65a68034-f43d-44d4-9c82-5125a22788b7");
            //einrichtung1.IDAdresse = new System.Guid("d61b88bc-92c2-4188-a1a5-c04438b5d91a");
            //einrichtung1.IDKontakt = new System.Guid("da8d747c-7ef1-4894-bb88-b60fa3b10450");
            einrichtung1.IstKrankenkasse = false;
            //this.ucEinrichtung1.Einrichtung = einrichtung1;
            this.ucEinrichtung1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucEinrichtung1.Location = new System.Drawing.Point(0, 40);
            this.ucEinrichtung1.Name = "ucEinrichtung1";
            this.ucEinrichtung1.Size = new System.Drawing.Size(908, 355);
            this.ucEinrichtung1.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance1;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(8, 401);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 32);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Hinzufügen";
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUndo.Appearance = appearance2;
            this.btnUndo.AutoWorkLayout = false;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUndo.DoOnClick = true;
            this.btnUndo.IsStandardControl = true;
            this.btnUndo.Location = new System.Drawing.Point(696, 401);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(106, 32);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.TabStop = false;
            this.btnUndo.Text = "Rückgängig";
            this.btnUndo.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnUndo.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance3;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DoOnClick = true;
            this.btnSave.IsStandardControl = true;
            this.btnSave.Location = new System.Drawing.Point(807, 401);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 32);
            this.btnSave.TabIndex = 6;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance4;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(112, 401);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(96, 32);
            this.btnDel.TabIndex = 4;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "Entfernen";
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Visible = false;
            // 
            // lblEinrichtung
            // 
            this.lblEinrichtung.AutoSize = true;
            this.lblEinrichtung.Location = new System.Drawing.Point(16, 11);
            this.lblEinrichtung.Name = "lblEinrichtung";
            this.lblEinrichtung.Size = new System.Drawing.Size(78, 17);
            this.lblEinrichtung.TabIndex = 0;
            this.lblEinrichtung.Text = "Einrichtung:";
            // 
            // cbEinrichtung
            // 
            this.cbEinrichtung.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cbEinrichtung.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cbEinrichtung.Location = new System.Drawing.Point(100, 8);
            this.cbEinrichtung.Name = "cbEinrichtung";
            this.cbEinrichtung.Size = new System.Drawing.Size(445, 24);
            this.cbEinrichtung.TabIndex = 1;
            this.cbEinrichtung.ValueChanged += new System.EventHandler(this.CbEinrichtung_ValueChanged);
            // 
            // dsGUIDListe1
            // 
            this.dsGUIDListe1.DataSetName = "dsGUIDListe";
            this.dsGUIDListe1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsGUIDListe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucEinrichtungEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Controls.Add(this.cbEinrichtung);
            this.Controls.Add(this.lblEinrichtung);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.ucEinrichtung1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name = "ucEinrichtungEdit";
            this.Size = new System.Drawing.Size(911, 441);
            this.Load += new System.EventHandler(this.ucEinrichtungEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbEinrichtung)).EndInit();
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
		private void ucEinrichtungEdit_Load(object sender, System.EventArgs e)
		{
			try
			{
				_verwaltung = new EngineVerwaltung(cbEinrichtung, ucEinrichtung1, 
					btnAdd,  this.btnDel, btnUndo, btnSave);
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

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void CbEinrichtung_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
