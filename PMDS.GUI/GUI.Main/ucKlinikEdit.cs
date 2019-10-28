using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.GUI.Engines;
using PMDS.Global.db.Patient;
using PMDS.GUI.ELGA;
using static PMDSClient.Sitemap.WCFServiceClient;
using PMDS.Global.db.ERSystem;

namespace PMDS.GUI
{


	public class ucKlinikEdit : QS2.Desktop.ControlManagment.BaseControl, IClose
	{
		private EngineVerwaltung _verwaltung;
        
		private PMDS.GUI.ucButton btnUndo;
		private PMDS.GUI.ucKlinik ucKlinik1;
		private System.ComponentModel.IContainer components;
        private PMDS.GUI.ucButton btnAdd;
        private QS2.Desktop.ControlManagment.BaseLabel lblAuswahlEinrichtung;
        private ucButton btnDel;
        public QS2.Desktop.ControlManagment.BaseButton btnSave2;
        public QS2.Desktop.ControlManagment.BaseButton btnELGASearchGDA;
        private QS2.Desktop.ControlManagment.BaseComboEditor cbKlinik;




		public ucKlinikEdit()
		{
			InitializeComponent();
		}




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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKlinikEdit));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.cbKlinik = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.ucKlinik1 = new PMDS.GUI.ucKlinik();
            this.lblAuswahlEinrichtung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.btnSave2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnELGASearchGDA = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbKlinik)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUndo.Appearance = appearance1;
            this.btnUndo.AutoWorkLayout = false;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUndo.DoOnClick = true;
            this.btnUndo.IsStandardControl = true;
            this.btnUndo.Location = new System.Drawing.Point(684, 565);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(96, 32);
            this.btnUndo.TabIndex = 3;
            this.btnUndo.TabStop = false;
            this.btnUndo.Text = "Rückgängig";
            this.btnUndo.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnUndo.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // cbKlinik
            // 
            this.cbKlinik.Location = new System.Drawing.Point(119, 9);
            this.cbKlinik.Name = "cbKlinik";
            this.cbKlinik.Size = new System.Drawing.Size(256, 21);
            this.cbKlinik.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance2;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(8, 565);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 32);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Hinzufügen";
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ucKlinik1
            // 
            this.ucKlinik1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucKlinik1.Location = new System.Drawing.Point(8, 40);
            this.ucKlinik1.Name = "ucKlinik1";
            this.ucKlinik1.Size = new System.Drawing.Size(868, 521);
            this.ucKlinik1.TabIndex = 1;
            // 
            // lblAuswahlEinrichtung
            // 
            this.lblAuswahlEinrichtung.Location = new System.Drawing.Point(10, 12);
            this.lblAuswahlEinrichtung.Name = "lblAuswahlEinrichtung";
            this.lblAuswahlEinrichtung.Size = new System.Drawing.Size(114, 15);
            this.lblAuswahlEinrichtung.TabIndex = 114;
            this.lblAuswahlEinrichtung.Text = "Auswahl Einrichtung";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance3;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(104, 565);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(96, 32);
            this.btnDel.TabIndex = 115;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "Entfernen";
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave2
            // 
            this.btnSave2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave2.Appearance = appearance4;
            this.btnSave2.AutoWorkLayout = false;
            this.btnSave2.Enabled = false;
            this.btnSave2.IsStandardControl = false;
            this.btnSave2.Location = new System.Drawing.Point(780, 565);
            this.btnSave2.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(96, 32);
            this.btnSave2.TabIndex = 1002;
            this.btnSave2.Tag = "";
            this.btnSave2.Text = "Speichern";
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // btnELGASearchGDA
            // 
            this.btnELGASearchGDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnELGASearchGDA.Appearance = appearance5;
            this.btnELGASearchGDA.AutoWorkLayout = false;
            this.btnELGASearchGDA.IsStandardControl = false;
            this.btnELGASearchGDA.Location = new System.Drawing.Point(200, 565);
            this.btnELGASearchGDA.Margin = new System.Windows.Forms.Padding(4);
            this.btnELGASearchGDA.Name = "btnELGASearchGDA";
            this.btnELGASearchGDA.Size = new System.Drawing.Size(98, 32);
            this.btnELGASearchGDA.TabIndex = 1003;
            this.btnELGASearchGDA.Tag = "";
            this.btnELGASearchGDA.Text = "Suche ELGA";
            this.btnELGASearchGDA.Click += new System.EventHandler(this.btnELGASearchGDA_Click);
            // 
            // ucKlinikEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnELGASearchGDA);
            this.Controls.Add(this.cbKlinik);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.lblAuswahlEinrichtung);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.ucKlinik1);
            this.Controls.Add(this.btnSave2);
            this.Name = "ucKlinikEdit";
            this.Size = new System.Drawing.Size(884, 597);
            this.Load += new System.EventHandler(this.ucKlinikEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbKlinik)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		private void ucKlinikEdit_Load(object sender, System.EventArgs e)
		{
			try
			{
				_verwaltung = new EngineVerwaltung(cbKlinik, ucKlinik1, 
					btnAdd, null, btnUndo, null);

                this.ucKlinik1.mainWindow = this;

                this.btnELGASearchGDA.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);

                ELGABusiness bELGA = new ELGABusiness();
                if (bELGA.ELGAIsActive(ENV.CurrentIDPatient, ENV.IDAUFENTHALT, true))
                {
                    this.btnELGASearchGDA.Visible = true;
                }

                // wenn ucKlinik zugänglich dann Add Button verstecken
                //if (ucKlinik1.Enabled)
                //    btnAdd.Visible = false;
            }
            catch (Exception ex)
			{
				ENV.HandleException(ex);
			}
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
            this.btnDel.Enabled = false;
		}

		public bool CanClose
		{
			get	{	return _verwaltung.CanClose;	}
		}


        private void btnUndo_Click(object sender, EventArgs e)
        {
            this.btnSave2.Enabled = false;
            this.btnDel.Enabled = true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Klinik wirklich löschen?", "Klink löschen",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
                    dsKlinik.KlinikRow rKlinik = DBKlinik1.loadKlinik((System.Guid)this.cbKlinik.Value, true);
                    DBKlinik1.deletKlinik(rKlinik);
                    _verwaltung = new EngineVerwaltung(cbKlinik, ucKlinik1, btnAdd, null, btnUndo, null);
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!this.ucKlinik1.ValidateFields())
                    return;

                this.ucKlinik1.UpdateDATA();
                this.ucKlinik1.Write();
                this.ucKlinik1.WriteER();
                Klinik obj = new Klinik((Guid)this.ucKlinik1.Klinik.ID);
                this.ucKlinik1.Klinik = obj;
                
                PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
                dsKlinik.KlinikRow rKlinik = DBKlinik1.loadKlinik((System.Guid)this.cbKlinik.Value, true);
                _verwaltung = new EngineVerwaltung(cbKlinik, ucKlinik1, btnAdd, null, btnUndo, null);
                this.cbKlinik.Value = this.ucKlinik1.Klinik.ID;

                this.btnSave2.Enabled = false;
                this.cbKlinik.Enabled = true;
                this.btnAdd.Enabled = true;
                this.btnDel.Enabled = true;
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnELGASearchGDA_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                cSearchGdaFlds FieldsSearch = new cSearchGdaFlds()
                {
                    NachnameFirma = this.ucKlinik1.txtKlinik.Text.Trim(),
                    Vorname = "",
                    Ort = this.ucKlinik1.ucAdresse1.txtOrt.Text.Trim(),
                    PLZ = this.ucKlinik1.ucAdresse1.txtPLZ.Text.Trim(),
                    Strasse = this.ucKlinik1.ucAdresse1.txtStrasse.Text.Trim(),
                    StrasseNr = ""
                };

                frmELGASearchGDA frmELGASearchGDA1 = new frmELGASearchGDA();
                frmELGASearchGDA1.initControl(null, null, FieldsSearch, contELGASearchGDA.eTypeUI.Kliniken);
                frmELGASearchGDA1.ShowDialog();
                if (!frmELGASearchGDA1.contELGASearchGDA1.abort)
                {
                    this.ucKlinik1.txtKlinik.Text = frmELGASearchGDA1.contELGASearchGDA1._rSelRow.NachnameFirma.Trim();
                    this.ucKlinik1.ucAdresse1.txtOrt.Text = frmELGASearchGDA1.contELGASearchGDA1._rSelRow.Ort.Trim();
                    this.ucKlinik1.ucAdresse1.txtPLZ.Text = frmELGASearchGDA1.contELGASearchGDA1._rSelRow.PLZ.Trim();
                    this.ucKlinik1.ucAdresse1.txtStrasse.Text = frmELGASearchGDA1.contELGASearchGDA1._rSelRow.Strasse.Trim() + " " + frmELGASearchGDA1.contELGASearchGDA1._rSelRow.StrasseNr.Trim();
                    this.ucKlinik1.txtELGAGdaOid.Text = frmELGASearchGDA1.contELGASearchGDA1._rSelRow.IDElga.Trim();
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
