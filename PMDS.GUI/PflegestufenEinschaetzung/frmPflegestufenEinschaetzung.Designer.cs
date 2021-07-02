
namespace PMDS.GUI.PflegestufenEinschaetzung
{
    partial class frmPflegestufenEinschaetzung
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.dtpVon = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblVon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpBis = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.baseLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblKlientName = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblKlient = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnOK2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnCancel2 = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtpVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBis)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpVon
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            this.dtpVon.Appearance = appearance1;
            this.dtpVon.BackColor = System.Drawing.Color.White;
            this.dtpVon.DateTime = new System.DateTime(2021, 6, 30, 0, 0, 0, 0);
            this.dtpVon.FormatString = "";
            this.dtpVon.Location = new System.Drawing.Point(162, 54);
            this.dtpVon.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVon.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpVon.Name = "dtpVon";
            this.dtpVon.ownFormat = "";
            this.dtpVon.ownMaskInput = "";
            this.dtpVon.Size = new System.Drawing.Size(117, 21);
            this.dtpVon.TabIndex = 1;
            this.dtpVon.Value = new System.DateTime(2021, 6, 30, 0, 0, 0, 0);
            // 
            // lblVon
            // 
            this.lblVon.AutoSize = true;
            this.lblVon.Location = new System.Drawing.Point(13, 58);
            this.lblVon.Margin = new System.Windows.Forms.Padding(4);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(141, 14);
            this.lblVon.TabIndex = 15;
            this.lblVon.Text = "Beobachtungszeitraum von";
            // 
            // dtpBis
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            this.dtpBis.Appearance = appearance2;
            this.dtpBis.BackColor = System.Drawing.Color.White;
            this.dtpBis.DateTime = new System.DateTime(2021, 6, 30, 0, 0, 0, 0);
            this.dtpBis.FormatString = "";
            this.dtpBis.Location = new System.Drawing.Point(322, 54);
            this.dtpBis.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBis.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpBis.Name = "dtpBis";
            this.dtpBis.ownFormat = "";
            this.dtpBis.ownMaskInput = "";
            this.dtpBis.Size = new System.Drawing.Size(117, 21);
            this.dtpBis.TabIndex = 16;
            this.dtpBis.Value = new System.DateTime(2021, 6, 30, 0, 0, 0, 0);
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Location = new System.Drawing.Point(292, 58);
            this.baseLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(19, 14);
            this.baseLabel1.TabIndex = 17;
            this.baseLabel1.Text = "bis";
            // 
            // lblKlientName
            // 
            this.lblKlientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKlientName.Location = new System.Drawing.Point(162, 22);
            this.lblKlientName.Margin = new System.Windows.Forms.Padding(4);
            this.lblKlientName.Name = "lblKlientName";
            this.lblKlientName.Size = new System.Drawing.Size(277, 24);
            this.lblKlientName.TabIndex = 18;
            // 
            // lblKlient
            // 
            this.lblKlient.AutoSize = true;
            this.lblKlient.Location = new System.Drawing.Point(13, 22);
            this.lblKlient.Margin = new System.Windows.Forms.Padding(4);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(33, 14);
            this.lblKlient.TabIndex = 19;
            this.lblKlient.Text = "Klient";
            // 
            // btnOK2
            // 
            this.btnOK2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK2.AutoWorkLayout = false;
            this.btnOK2.IsStandardControl = false;
            this.btnOK2.Location = new System.Drawing.Point(322, 90);
            this.btnOK2.Name = "btnOK2";
            this.btnOK2.Size = new System.Drawing.Size(119, 32);
            this.btnOK2.TabIndex = 20;
            this.btnOK2.Text = "Starten";
            this.btnOK2.Click += new System.EventHandler(this.btnOK2_Click);
            // 
            // btnCancel2
            // 
            this.btnCancel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel2.AutoWorkLayout = false;
            this.btnCancel2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel2.IsStandardControl = false;
            this.btnCancel2.Location = new System.Drawing.Point(197, 90);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(119, 32);
            this.btnCancel2.TabIndex = 21;
            this.btnCancel2.Text = "Abbrechen";
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // frmPflegestufenEinschaetzung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 134);
            this.Controls.Add(this.btnCancel2);
            this.Controls.Add(this.btnOK2);
            this.Controls.Add(this.lblKlient);
            this.Controls.Add(this.lblKlientName);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.dtpBis);
            this.Controls.Add(this.lblVon);
            this.Controls.Add(this.dtpVon);
            this.Name = "frmPflegestufenEinschaetzung";
            this.Text = "Pflegestufen-Einschätzung";
            ((System.ComponentModel.ISupportInitialize)(this.dtpVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpVon;
        protected QS2.Desktop.ControlManagment.BaseLabel lblVon;
        protected QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpBis;
        protected QS2.Desktop.ControlManagment.BaseLabel baseLabel1;
        protected QS2.Desktop.ControlManagment.BaseLabel lblKlientName;
        protected QS2.Desktop.ControlManagment.BaseLabel lblKlient;
        private QS2.Desktop.ControlManagment.BaseButton btnOK2;
        private QS2.Desktop.ControlManagment.BaseButton btnCancel2;
    }
}