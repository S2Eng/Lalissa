using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using PMDS.Global.db.Patient;



namespace PMDS.GUI
{


	public class frmAbteilungsWahl : QS2.Desktop.ControlManagment.baseForm  
	{

        public bool abort = true;
        private QS2.Desktop.ControlManagment.BaseComboEditor cboEinrichtung;
        private QS2.Desktop.ControlManagment.BaseLabel lblEinrichtung;
        private QS2.Desktop.ControlManagment.BaseComboEditor cboAbteilung;
        private QS2.Desktop.ControlManagment.BaseLabel lblAbteilung;
        private QS2.Desktop.ControlManagment.BaseButton btnOK;
        private QS2.Desktop.ControlManagment.BaseButton btnAbort;
		private System.ComponentModel.IContainer components;
        


		public frmAbteilungsWahl()
		{
			InitializeComponent();
		}

        private void frmAbteilungsWahl_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!DesignMode)
                {
                    QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                    ControlManagment1.autoTranslateForm(this);
                }

                this.loadEinrichtungen();
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
        private void frmAbteilungsWahl_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbteilungsWahl));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.cboEinrichtung = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.lblEinrichtung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboAbteilung = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.lblAbteilung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboEinrichtung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAbteilung)).BeginInit();
            this.SuspendLayout();
            // 
            // cboEinrichtung
            // 
            this.cboEinrichtung.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboEinrichtung.Location = new System.Drawing.Point(84, 14);
            this.cboEinrichtung.Name = "cboEinrichtung";
            this.cboEinrichtung.Size = new System.Drawing.Size(220, 21);
            this.cboEinrichtung.TabIndex = 0;
            this.cboEinrichtung.ValueChanged += new System.EventHandler(this.cboEinrichtung_ValueChanged);
            // 
            // lblEinrichtung
            // 
            this.lblEinrichtung.AutoSize = true;
            this.lblEinrichtung.Location = new System.Drawing.Point(17, 17);
            this.lblEinrichtung.Name = "lblEinrichtung";
            this.lblEinrichtung.Size = new System.Drawing.Size(61, 14);
            this.lblEinrichtung.TabIndex = 169;
            this.lblEinrichtung.Text = "Einrichtung";
            // 
            // cboAbteilung
            // 
            this.cboAbteilung.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboAbteilung.Location = new System.Drawing.Point(84, 37);
            this.cboAbteilung.Name = "cboAbteilung";
            this.cboAbteilung.Size = new System.Drawing.Size(220, 21);
            this.cboAbteilung.TabIndex = 1;
            // 
            // lblAbteilung
            // 
            this.lblAbteilung.AutoSize = true;
            this.lblAbteilung.Location = new System.Drawing.Point(17, 40);
            this.lblAbteilung.Name = "lblAbteilung";
            this.lblAbteilung.Size = new System.Drawing.Size(52, 14);
            this.lblAbteilung.TabIndex = 171;
            this.lblAbteilung.Text = "Abteilung";
            // 
            // btnOK
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance1;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.IsStandardControl = false;
            this.btnOK.Location = new System.Drawing.Point(84, 69);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(92, 26);
            this.btnOK.TabIndex = 172;
            this.btnOK.Text = "Auswählen";
            this.btnOK.Click += new System.EventHandler(this.btnOK2_Click);
            // 
            // btnAbort
            // 
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance2;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(178, 69);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(73, 26);
            this.btnAbort.TabIndex = 173;
            this.btnAbort.Text = "Abrechnen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // frmAbteilungsWahl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(321, 102);
            this.ControlBox = false;
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboAbteilung);
            this.Controls.Add(this.lblAbteilung);
            this.Controls.Add(this.cboEinrichtung);
            this.Controls.Add(this.lblEinrichtung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAbteilungsWahl";
            this.ShowInTaskbar = false;
            this.Text = "Auswahl Abteilung";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmAbteilungsWahl_Closing);
            this.Load += new System.EventHandler(this.frmAbteilungsWahl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboEinrichtung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAbteilung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public void loadEinrichtungen()
        {
            try
            {
                this.cboEinrichtung.Items.Clear();
                this.cboAbteilung.Items.Clear();

                dsKlinik dsKlinik1 = new dsKlinik();
                PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
                DBKlinik1.loadAllKliniken(dsKlinik1.Klinik);
                foreach ( dsKlinik.KlinikRow rKlinik in dsKlinik1.Klinik)
                {
                    ValueListItem itmKlinik = this.cboEinrichtung.Items.Add(rKlinik.ID, rKlinik.Bezeichnung.Trim());
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        public void loadAbteilung(System.Guid IDKlinik)
        {
            try
            {
                this.cboAbteilung.Items.Clear();

                dsAbteilung dsAbteilung1 = new dsAbteilung();
                PMDS.DB.DBAbteilung DBAbteilung1 = new PMDS.DB.DBAbteilung();
                DBAbteilung1.getAbteilungenByKlinik(IDKlinik, dsAbteilung1);
                foreach (dsAbteilung.AbteilungRow rAbt in dsAbteilung1.Abteilung)
                {
                    ValueListItem itmAbt = this.cboAbteilung.Items.Add(rAbt.ID, rAbt.Bezeichnung.Trim());
                 }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
		public Guid IDABTEILUNG 
		{
			get 
			{
                return (System.Guid)this.cboAbteilung.SelectedItem.DataValue;
			}
		}

        private void cboEinrichtung_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cboEinrichtung.Focused)
                {
                    if (this.cboEinrichtung.SelectedItem != null)
                    {
                        this.loadAbteilung((System.Guid)this.cboEinrichtung.SelectedItem.DataValue);
                    }
                }
            }
            catch (Exception ex)
            {
               PMDS.Global.ENV.HandleException(ex);
            }
        }

        public bool checkSelection()
        {
            if (this.cboEinrichtung.Value == null)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Einrichtung: Auswahl erforderlich!");
                this.cboEinrichtung.Focus();
                return false;
            }
            if (this.cboAbteilung.Value == null)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abteilung: Auswahl erforderlich!");
                this.cboAbteilung.Focus();
                return false;
            }
            return true;
        }

        private void btnOK2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.checkSelection())
                {
                    this.abort = false;
                    this.Close();
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

        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Close();

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
