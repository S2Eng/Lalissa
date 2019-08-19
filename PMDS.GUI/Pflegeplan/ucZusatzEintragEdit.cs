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


	public class ucZusatzEintragEdit : QS2.Desktop.ControlManagment.BaseControl, IClose
	{
		private EngineVerwaltung _verwaltung;

		private PMDS.GUI.ucButton btnAdd;
		private PMDS.GUI.ucButton btnUndo;
		private PMDS.GUI.ucButton btnDel;
		private QS2.Desktop.ControlManagment.BaseLabel lblEintrag;
		private QS2.Desktop.ControlManagment.BaseComboEditor cbZusatzEintrag;
		private PMDS.GUI.ucZusatzEintrag ucZusatzEintrag1;
        private dsIDListe dsIDListe1;
        public Infragistics.Win.Misc.UltraButton btnSave2;
        private System.ComponentModel.IContainer components;



		public ucZusatzEintragEdit()
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucZusatzEintragEdit));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            PMDS.BusinessLogic.ZusatzEintrag zusatzEintrag2 = new PMDS.BusinessLogic.ZusatzEintrag();
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.lblEintrag = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbZusatzEintrag = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.dsIDListe1 = new PMDS.Global.db.Global.dsIDListe();
            this.ucZusatzEintrag1 = new PMDS.GUI.ucZusatzEintrag();
            this.btnSave2 = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbZusatzEintrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsIDListe1)).BeginInit();
            this.SuspendLayout();
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
            this.btnAdd.Location = new System.Drawing.Point(8, 563);
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
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUndo.Appearance = appearance1;
            this.btnUndo.AutoWorkLayout = false;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUndo.DoOnClick = true;
            this.btnUndo.IsStandardControl = true;
            this.btnUndo.Location = new System.Drawing.Point(408, 563);
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
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance2;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(105, 563);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(96, 32);
            this.btnDel.TabIndex = 4;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "Entfernen";
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            // 
            // lblEintrag
            // 
            this.lblEintrag.AutoSize = true;
            this.lblEintrag.Location = new System.Drawing.Point(16, 11);
            this.lblEintrag.Name = "lblEintrag";
            this.lblEintrag.Size = new System.Drawing.Size(43, 14);
            this.lblEintrag.TabIndex = 0;
            this.lblEintrag.Text = "Eintrag:";
            // 
            // cbZusatzEintrag
            // 
            this.cbZusatzEintrag.Location = new System.Drawing.Point(88, 8);
            this.cbZusatzEintrag.Name = "cbZusatzEintrag";
            this.cbZusatzEintrag.Size = new System.Drawing.Size(502, 21);
            this.cbZusatzEintrag.TabIndex = 1;
            // 
            // dsIDListe1
            // 
            this.dsIDListe1.DataSetName = "dsIDListe";
            this.dsIDListe1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsIDListe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucZusatzEintrag1
            // 
            this.ucZusatzEintrag1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucZusatzEintrag1.Location = new System.Drawing.Point(0, 40);
            this.ucZusatzEintrag1.Name = "ucZusatzEintrag1";
            this.ucZusatzEintrag1.Size = new System.Drawing.Size(609, 519);
            this.ucZusatzEintrag1.TabIndex = 2;
            zusatzEintrag2.Bezeichnung = "";
            zusatzEintrag2.ELGA_Code = "";
            zusatzEintrag2.ELGA_CodeSystem = "";
            zusatzEintrag2.ELGA_Version = "";
            zusatzEintrag2.ELGA_DisplayName = "";
            zusatzEintrag2.ELGA_ID = -1;
            zusatzEintrag2.ELGA_Unit = "";
            zusatzEintrag2.FeldNr = 0;
            zusatzEintrag2.ID = "";
            zusatzEintrag2.MaxValue = 0D;
            zusatzEintrag2.MinValue = 0D;
            zusatzEintrag2.Typ = 0;
            this.ucZusatzEintrag1.ZusatzEintrag = zusatzEintrag2;
            // 
            // btnSave2
            // 
            this.btnSave2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave2.Location = new System.Drawing.Point(505, 563);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(96, 32);
            this.btnSave2.TabIndex = 7;
            this.btnSave2.Text = "Speichern";
            this.btnSave2.Click += new System.EventHandler(this.BtnSave2_Click);
            // 
            // ucZusatzEintragEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.ucZusatzEintrag1);
            this.Controls.Add(this.lblEintrag);
            this.Controls.Add(this.cbZusatzEintrag);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnSave2);
            this.Controls.Add(this.btnUndo);
            this.Name = "ucZusatzEintragEdit";
            this.Size = new System.Drawing.Size(609, 599);
            this.Load += new System.EventHandler(this.ucZusatzEintragEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbZusatzEintrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsIDListe1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		private void ucZusatzEintragEdit_Load(object sender, System.EventArgs e)
		{
			try
			{
                this.ucZusatzEintrag1.mainWindow = this;
                this.btnSave2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);

                _verwaltung = new EngineVerwaltung(cbZusatzEintrag, ucZusatzEintrag1, 
					btnAdd, btnDel, btnUndo, null);
			}
			catch(Exception ex)
			{
				ENV.HandleException(ex);
			}
		}

        public bool CanClose
		{
			get	{	return _verwaltung.CanClose;	}
		}

        private void BtnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!ucZusatzEintrag1.ValidateFields())
                    return;

                DialogResult res = DialogResult.Yes;
                if (this.ucZusatzEintrag1._ELGAFieldChanged)
                {
                    res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden ELGA-Felder geändert. Dies kann Auswirkungen auf die Datenübergabe an ELGA haben!" + "\r\n" +
                                                                "Wollen Sie die Daten trotzdem speichern?", "Speichern", MessageBoxButtons.YesNo);
                    if (res == DialogResult.No)
                    {
                        return;
                    }
                }

                ucZusatzEintrag1.UpdateDATA();
                ucZusatzEintrag1.Write();
                this.btnSave2.Enabled = false;
                this.btnUndo.Enabled = false;

                //this.ucZusatzEintrag1.ZusatzEintrag = this.ucZusatzEintrag1.ZusatzEintrag;
                _verwaltung.LoadWith(ucZusatzEintrag1.ZusatzEintrag.ID);
                _verwaltung.SetCurrent();
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

    }

}
