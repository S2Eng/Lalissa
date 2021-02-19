using System;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using PMDS.GUI;
using PMDS.Global;
using PMDS.BusinessLogic;
using Infragistics.Win.UltraWinEditors;
//lthArztabrechnung  neues Form integrieren in PMDS.Int


namespace PMDS.DynReportsForms
{

	public class frmPrintArztbrief : PMDS.GUI.BaseControls.DynReportsForm
    {
		private bool _canClose = false;
		private QS2.Desktop.ControlManagment.BaseLabel lblAnEinrichtung;
        public GUI.BaseControls.EinrichtungsCombo cbETo;
        private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private QS2.Desktop.ControlManagment.BaseGroupBoxWin grpAnmerkungen;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtAnmerkungen;
        private QS2.Desktop.ControlManagment.BaseLabel txtFree;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtText;
        private System.ComponentModel.IContainer components;



        public frmPrintArztbrief()
		{
            try
            {
                InitializeComponent();
                if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
                {
                    this.cbETo.NotKrankenkasse = true;
                    this.cbETo.RefreshList();
                    QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                    ControlManagment1.autoTranslateForm(this);
                }

                RequiredFields();
            }
            catch (Exception ex)
            {
                throw new Exception("frmPrintArztbrief: " + ex.ToString());
            }
		}






        public NameValueCollection VALUES
        {
            get
            {
                try
                {
                    NameValueCollection nv = new NameValueCollection();

                    List<Control> list = new List<Control>();
                    GetAllControls(this, ref list);

                    foreach (Control c in list)
                    {
                        if (c is UltraCheckEditor)
                        {
                            UltraCheckEditor e = (UltraCheckEditor)c;
                            nv.Add(e.Name, e.Checked ? "J" : "N");
                        }

                        if (c is UltraTextEditor)
                        {
                            UltraTextEditor e = (UltraTextEditor)c;
                            nv.Add(e.Name, e.Text.Trim());
                        }
                    }
                    return nv;
                }
                catch (Exception ex)
                {
                    throw new Exception("frmPrintArztbrief.VALUES: " + ex.ToString());
                }
            }
        }

        private void GetAllControls(Control root, ref List<Control> list)
        {
            try
            {
                foreach (Control c in root.Controls)
                {
                    list.Add(c);
                    GetAllControls(c, ref list);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmPrintArztbrief.GetAllControls: " + ex.ToString());
            }
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintArztbrief));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.lblAnEinrichtung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpAnmerkungen = new QS2.Desktop.ControlManagment.BaseGroupBoxWin();
            this.txtAnmerkungen = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.cbETo = new PMDS.GUI.BaseControls.EinrichtungsCombo();
            this.txtText = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtFree = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grpAnmerkungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnmerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbETo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtText)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAnEinrichtung
            // 
            this.lblAnEinrichtung.AutoSize = true;
            this.lblAnEinrichtung.Location = new System.Drawing.Point(11, 14);
            this.lblAnEinrichtung.Margin = new System.Windows.Forms.Padding(4);
            this.lblAnEinrichtung.Name = "lblAnEinrichtung";
            this.lblAnEinrichtung.Size = new System.Drawing.Size(98, 17);
            this.lblAnEinrichtung.TabIndex = 0;
            this.lblAnEinrichtung.Text = "An Einrichtung:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // grpAnmerkungen
            // 
            this.grpAnmerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAnmerkungen.Controls.Add(this.txtAnmerkungen);
            this.grpAnmerkungen.Location = new System.Drawing.Point(11, 76);
            this.grpAnmerkungen.Margin = new System.Windows.Forms.Padding(4);
            this.grpAnmerkungen.Name = "grpAnmerkungen";
            this.grpAnmerkungen.Padding = new System.Windows.Forms.Padding(4);
            this.grpAnmerkungen.Size = new System.Drawing.Size(796, 385);
            this.grpAnmerkungen.TabIndex = 2;
            this.grpAnmerkungen.TabStop = false;
            this.grpAnmerkungen.Text = "Anmerkungen";
            // 
            // txtAnmerkungen
            // 
            this.txtAnmerkungen.AcceptsReturn = true;
            this.txtAnmerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnmerkungen.Location = new System.Drawing.Point(11, 22);
            this.txtAnmerkungen.Margin = new System.Windows.Forms.Padding(4);
            this.txtAnmerkungen.Multiline = true;
            this.txtAnmerkungen.Name = "txtAnmerkungen";
            this.txtAnmerkungen.Size = new System.Drawing.Size(775, 352);
            this.txtAnmerkungen.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance1;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(622, 465);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 39);
            this.btnCancel.TabIndex = 100;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(740, 465);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(64, 39);
            this.btnOK.TabIndex = 101;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbETo
            // 
            this.cbETo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbETo.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cbETo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbETo.Location = new System.Drawing.Point(128, 10);
            this.cbETo.Margin = new System.Windows.Forms.Padding(4);
            this.cbETo.Name = "cbETo";
            this.cbETo.NotKrankenkasse = true;
            this.cbETo.Size = new System.Drawing.Size(668, 24);
            this.cbETo.TabIndex = 0;
            // 
            // txtText
            // 
            this.txtText.AcceptsReturn = true;
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Location = new System.Drawing.Point(128, 43);
            this.txtText.Margin = new System.Windows.Forms.Padding(4);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(668, 26);
            this.txtText.TabIndex = 1;
            // 
            // txtFree
            // 
            this.txtFree.AutoSize = true;
            this.txtFree.Location = new System.Drawing.Point(11, 48);
            this.txtFree.Margin = new System.Windows.Forms.Padding(4);
            this.txtFree.Name = "txtFree";
            this.txtFree.Size = new System.Drawing.Size(62, 17);
            this.txtFree.TabIndex = 4;
            this.txtFree.Text = "Abteilung";
            // 
            // frmPrintArztbrief
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(815, 506);
            this.ControlBox = false;
            this.Controls.Add(this.txtFree);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.grpAnmerkungen);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbETo);
            this.Controls.Add(this.lblAnEinrichtung);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "frmPrintArztbrief";
            this.ShowInTaskbar = false;
            this.Text = "Arztbrief drucken ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmPrintPflegebegleitschreibenInfo_Load);
            this.VisibleChanged += new System.EventHandler(this.frmPrintArztbrief_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grpAnmerkungen.ResumeLayout(false);
            this.grpAnmerkungen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnmerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbETo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            try
            {
                e.Cancel = !_canClose;

            }
            catch (Exception ex)
            {
                throw new Exception("frmPrintArztbrief.frm_Closing: " + ex.ToString());
            }
		}

		protected void RequiredFields()
		{
            try
            {
                GuiUtil.ValidateRequired(cbETo);

            }
            catch (Exception ex)
            {
                throw new Exception("frmPrintArztbrief.RequiredFields: " + ex.ToString());
            }
		}

        public List<PMDS.Print.CR.BerichtParameter> GetBERICHTPARAMETER()
        {
            return base.BERICHTPARAMETER;
        }

        private bool ValidateFields()
		{
            try
            {
                bool bError = false;
                bool bInfo = true;

                //GuiUtil.ValidateField(cbETo, (cbETo.Value != null),
                //    ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

                return !bError;

            }
            catch (Exception ex)
            {
                throw new Exception("frmPrintArztbrief.ValidateFields: " + ex.ToString());
            }
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!ValidateFields())
                    return;

                _canClose = true;

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

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _canClose = true;
                
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

		public Guid Einrichtung
		{
			get	{	return (Guid)cbETo.Value;	}
		}

		public string Bemerkung
		{
			get	{	return txtAnmerkungen.Text;	}
		}

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void v82_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void frmPrintPflegebegleitschreibenInfo_Load(object sender, EventArgs e)
        {
            try
            {
              
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void frmPrintArztbrief_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)       //lthIntIntegrieren
                this.cbETo.checkButtons();
        }
    }

}
