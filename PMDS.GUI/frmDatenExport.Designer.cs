
namespace PMDS.GUI
{
    partial class frmDatenExport
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
            this.txtEditor?.Dispose();
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.chkXMLExport = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.chkPDFExport = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.btnArchivErstellen = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblTarget = new QS2.Desktop.ControlManagment.BaseLabel();
            this.optDatenexportTyp = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.RTFLog = new PMDS.GUI.ucRichTextBox();
            this.lblKlient = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chkXMLExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPDFExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDatenexportTyp)).BeginInit();
            this.SuspendLayout();
            // 
            // chkXMLExport
            // 
            appearance1.FontData.SizeInPoints = 10F;
            this.chkXMLExport.Appearance = appearance1;
            this.chkXMLExport.Checked = true;
            this.chkXMLExport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXMLExport.Enabled = false;
            this.chkXMLExport.Location = new System.Drawing.Point(456, 55);
            this.chkXMLExport.Margin = new System.Windows.Forms.Padding(4);
            this.chkXMLExport.Name = "chkXMLExport";
            this.chkXMLExport.Size = new System.Drawing.Size(121, 22);
            this.chkXMLExport.TabIndex = 161;
            this.chkXMLExport.Text = "XML-Export";
            // 
            // chkPDFExport
            // 
            appearance2.FontData.SizeInPoints = 10F;
            this.chkPDFExport.Appearance = appearance2;
            this.chkPDFExport.Checked = true;
            this.chkPDFExport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPDFExport.Enabled = false;
            this.chkPDFExport.Location = new System.Drawing.Point(456, 25);
            this.chkPDFExport.Margin = new System.Windows.Forms.Padding(4);
            this.chkPDFExport.Name = "chkPDFExport";
            this.chkPDFExport.Size = new System.Drawing.Size(121, 22);
            this.chkPDFExport.TabIndex = 160;
            this.chkPDFExport.Text = "PDF-Export";
            // 
            // btnArchivErstellen
            // 
            this.btnArchivErstellen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.FontData.SizeInPoints = 10F;
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnArchivErstellen.Appearance = appearance3;
            this.btnArchivErstellen.AutoWorkLayout = false;
            this.btnArchivErstellen.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnArchivErstellen.IsStandardControl = false;
            this.btnArchivErstellen.Location = new System.Drawing.Point(584, 19);
            this.btnArchivErstellen.Name = "btnArchivErstellen";
            this.btnArchivErstellen.Size = new System.Drawing.Size(175, 34);
            this.btnArchivErstellen.TabIndex = 158;
            this.btnArchivErstellen.Text = "Archiv erstellen";
            this.btnArchivErstellen.Click += new System.EventHandler(this.btnArchivErstellen_Click);
            // 
            // lblTarget
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.lblTarget.Appearance = appearance4;
            this.lblTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarget.Location = new System.Drawing.Point(11, 100);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(776, 46);
            this.lblTarget.TabIndex = 157;
            this.lblTarget.Text = "Ausgabeverzeichnis";
            // 
            // optDatenexportTyp
            // 
            appearance5.FontData.SizeInPoints = 12F;
            this.optDatenexportTyp.Appearance = appearance5;
            this.optDatenexportTyp.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance6.FontData.SizeInPoints = 10F;
            this.optDatenexportTyp.ItemAppearance = appearance6;
            valueListItem1.DataValue = true;
            valueListItem1.DisplayText = "nur Klienten mit aktuellem Aufenthalt";
            valueListItem1.Tag = "aktuell";
            valueListItem2.DataValue = false;
            valueListItem2.DisplayText = "nur Klienten mit mindestens einem beendeten Aufenthalt";
            valueListItem2.Tag = "entlassen";
            valueListItem3.DataValue = "ValueListItem2";
            valueListItem3.DisplayText = "alle Klienten";
            valueListItem3.Tag = "alle";
            this.optDatenexportTyp.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.optDatenexportTyp.Location = new System.Drawing.Point(12, 27);
            this.optDatenexportTyp.Name = "optDatenexportTyp";
            this.optDatenexportTyp.Size = new System.Drawing.Size(437, 53);
            this.optDatenexportTyp.TabIndex = 3;
            this.optDatenexportTyp.ValueChanged += new System.EventHandler(this.optDatenexportTyp_ValueChanged);
            // 
            // RTFLog
            // 
            this.RTFLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTFLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RTFLog.HiglightColor = PMDS.GUI.RtfColor.White;
            this.RTFLog.Location = new System.Drawing.Point(12, 152);
            this.RTFLog.Name = "RTFLog";
            this.RTFLog.Size = new System.Drawing.Size(775, 279);
            this.RTFLog.TabIndex = 159;
            this.RTFLog.Text = "";
            this.RTFLog.TextColor = PMDS.GUI.RtfColor.Black;
            this.RTFLog.TextChanged += new System.EventHandler(this.RTFLog_TextChanged);
            // 
            // lblKlient
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            this.lblKlient.Appearance = appearance7;
            this.lblKlient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKlient.Location = new System.Drawing.Point(584, 59);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(204, 35);
            this.lblKlient.TabIndex = 162;
            // 
            // frmDatenExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblKlient);
            this.Controls.Add(this.chkXMLExport);
            this.Controls.Add(this.chkPDFExport);
            this.Controls.Add(this.RTFLog);
            this.Controls.Add(this.btnArchivErstellen);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.optDatenexportTyp);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "frmDatenExport";
            this.Text = "frmDatenExport";
            ((System.ComponentModel.ISupportInitialize)(this.chkXMLExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPDFExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDatenexportTyp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseOptionSet optDatenexportTyp;
        private QS2.Desktop.ControlManagment.BaseLabel lblTarget;
        private QS2.Desktop.ControlManagment.BaseButton btnArchivErstellen;
        private ucRichTextBox RTFLog;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkPDFExport;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkXMLExport;
        private QS2.Desktop.ControlManagment.BaseLabel lblKlient;
    }
}