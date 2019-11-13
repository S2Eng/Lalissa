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
using PMDS.GUI.ELGA;
using static PMDSClient.Sitemap.WCFServiceClient;
using PMDS.Global.db.ERSystem;

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
        public QS2.Desktop.ControlManagment.BaseButton btnELGASearchGDA;
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.ucEinrichtung1 = new PMDS.GUI.ucEinrichtung();
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.lblEinrichtung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbEinrichtung = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.dsGUIDListe1 = new PMDS.Global.db.Global.dsGUIDListe();
            this.btnELGASearchGDA = new QS2.Desktop.ControlManagment.BaseButton();
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
            //einrichtung1.ID = new System.Guid("eda9ce21-41b4-4d21-8427-ea907c3713e4");
            //einrichtung1.IDAdresse = new System.Guid("87c3f865-69f0-4d18-ac84-dd7881de953a");
            //einrichtung1.IDKontakt = new System.Guid("ef2feb11-fcad-42e3-9588-e6e89ec7d9c4");
            einrichtung1.IstKrankenkasse = false;
            this.ucEinrichtung1.Einrichtung = einrichtung1;
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
            // btnELGASearchGDA
            // 
            this.btnELGASearchGDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnELGASearchGDA.Appearance = appearance5;
            this.btnELGASearchGDA.AutoWorkLayout = false;
            this.btnELGASearchGDA.IsStandardControl = false;
            this.btnELGASearchGDA.Location = new System.Drawing.Point(217, 401);
            this.btnELGASearchGDA.Margin = new System.Windows.Forms.Padding(4);
            this.btnELGASearchGDA.Name = "btnELGASearchGDA";
            this.btnELGASearchGDA.Size = new System.Drawing.Size(111, 32);
            this.btnELGASearchGDA.TabIndex = 150;
            this.btnELGASearchGDA.Tag = "";
            this.btnELGASearchGDA.Text = "Suche ELGA";
            this.btnELGASearchGDA.Click += new System.EventHandler(this.btnELGASearchGDA_Click);
            // 
            // ucEinrichtungEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Controls.Add(this.btnELGASearchGDA);
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

                this.btnELGASearchGDA.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);

                this.btnELGASearchGDA.Visible = true;
                //ELGABusiness bELGA = new ELGABusiness();
                //if (bELGA.ELGAIsActive(ENV.CurrentIDPatient, ENV.IDAUFENTHALT, true))
                //{
                //    this.btnELGASearchGDA.Visible = true;
                //}
               
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

        private void btnELGASearchGDA_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                cSearchGdaFlds FieldsSearch = new cSearchGdaFlds()
                {
                    NachnameFirma = this.ucEinrichtung1.txtEinrichtung.Text.Trim(),
                    Vorname = "",
                    Ort = this.ucEinrichtung1.txtOrt.Text.Trim(),
                    PLZ = this.ucEinrichtung1.txtPLZ.Text.Trim(),
                    Strasse = this.ucEinrichtung1.txtStrasse.Text.Trim(),
                    StrasseNr = ""
                };

                frmELGASearchGDA frmELGASearchGDA1 = new frmELGASearchGDA();
                frmELGASearchGDA1.initControl(null, null, FieldsSearch, contELGASearchGDA.eTypeUI.ExtEinrichtungen);
                frmELGASearchGDA1.ShowDialog();
                if (!frmELGASearchGDA1.contELGASearchGDA1.abort)
                {
                    this.ucEinrichtung1.txtEinrichtung.Text = frmELGASearchGDA1.contELGASearchGDA1._rSelRow.NachnameFirma.Trim();
                    this.ucEinrichtung1.txtOrt.Text = frmELGASearchGDA1.contELGASearchGDA1._rSelRow.Ort.Trim();
                    this.ucEinrichtung1.txtPLZ.Text = frmELGASearchGDA1.contELGASearchGDA1._rSelRow.PLZ.Trim();
                    this.ucEinrichtung1.txtStrasse.Text = frmELGASearchGDA1.contELGASearchGDA1._rSelRow.Strasse.Trim() + " " + frmELGASearchGDA1.contELGASearchGDA1._rSelRow.StrasseNr.Trim();
                    this.ucEinrichtung1.txtELGAGdaOid.Text = frmELGASearchGDA1.contELGASearchGDA1._rSelRow.IDElga.Trim();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

    }
}
