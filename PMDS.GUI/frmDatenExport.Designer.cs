
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.chkXMLExport = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.chkPDFExport = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.btnArchivErstellen = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblTarget = new QS2.Desktop.ControlManagment.BaseLabel();
            this.optDatenexportTyp = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.lblKlient = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkPDFA = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.RTFLog = new PMDS.GUI.ucRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chkXMLExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPDFExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDatenexportTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPDFA)).BeginInit();
            this.SuspendLayout();
            // 
            // chkXMLExport
            // 
            appearance1.FontData.SizeInPoints = 10F;
            this.chkXMLExport.Appearance = appearance1;
            this.chkXMLExport.Checked = true;
            this.chkXMLExport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXMLExport.Enabled = false;
            this.chkXMLExport.Location = new System.Drawing.Point(491, 68);
            this.chkXMLExport.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkXMLExport.Name = "chkXMLExport";
            this.chkXMLExport.Size = new System.Drawing.Size(161, 27);
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
            this.chkPDFExport.Location = new System.Drawing.Point(491, 31);
            this.chkPDFExport.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkPDFExport.Name = "chkPDFExport";
            this.chkPDFExport.Size = new System.Drawing.Size(161, 27);
            this.chkPDFExport.TabIndex = 160;
            this.chkPDFExport.Text = "PDF-Export";
            this.chkPDFExport.CheckedChanged += new System.EventHandler(this.chkPDFExport_CheckedChanged);
            // 
            // btnArchivErstellen
            // 
            this.btnArchivErstellen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.FontData.SizeInPoints = 10F;
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnArchivErstellen.Appearance = appearance3;
            this.btnArchivErstellen.AutoWorkLayout = false;
            this.btnArchivErstellen.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnArchivErstellen.IsStandardControl = false;
            this.btnArchivErstellen.Location = new System.Drawing.Point(940, 23);
            this.btnArchivErstellen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnArchivErstellen.Name = "btnArchivErstellen";
            this.btnArchivErstellen.Size = new System.Drawing.Size(193, 42);
            this.btnArchivErstellen.TabIndex = 158;
            this.btnArchivErstellen.Text = "Archiv erstellen";
            this.btnArchivErstellen.Click += new System.EventHandler(this.btnArchivErstellen_Click);
            // 
            // lblTarget
            // 
            this.lblTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.lblTarget.Appearance = appearance4;
            this.lblTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarget.Location = new System.Drawing.Point(15, 123);
            this.lblTarget.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(1118, 57);
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
            this.optDatenexportTyp.ItemSpacingHorizontal = 10;
            this.optDatenexportTyp.ItemSpacingVertical = 5;
            this.optDatenexportTyp.Location = new System.Drawing.Point(16, 33);
            this.optDatenexportTyp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.optDatenexportTyp.Name = "optDatenexportTyp";
            this.optDatenexportTyp.Size = new System.Drawing.Size(464, 82);
            this.optDatenexportTyp.TabIndex = 3;
            this.optDatenexportTyp.ValueChanged += new System.EventHandler(this.optDatenexportTyp_ValueChanged);
            // 
            // lblKlient
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            this.lblKlient.Appearance = appearance7;
            this.lblKlient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKlient.Location = new System.Drawing.Point(662, 73);
            this.lblKlient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(272, 43);
            this.lblKlient.TabIndex = 162;
            // 
            // chkPDFA
            // 
            appearance8.FontData.SizeInPoints = 10F;
            this.chkPDFA.Appearance = appearance8;
            this.chkPDFA.Checked = true;
            this.chkPDFA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPDFA.Location = new System.Drawing.Point(636, 31);
            this.chkPDFA.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkPDFA.Name = "chkPDFA";
            this.chkPDFA.Size = new System.Drawing.Size(242, 27);
            this.chkPDFA.TabIndex = 163;
            this.chkPDFA.Text = "Ein PDF/A-Dokument erstellen";
            // 
            // RTFLog
            // 
            this.RTFLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTFLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RTFLog.HiglightColor = PMDS.GUI.RtfColor.White;
            this.RTFLog.Location = new System.Drawing.Point(16, 187);
            this.RTFLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTFLog.Name = "RTFLog";
            this.RTFLog.Size = new System.Drawing.Size(1154, 342);
            this.RTFLog.TabIndex = 159;
            this.RTFLog.Text = "";
            this.RTFLog.TextColor = PMDS.GUI.RtfColor.Black;
            this.RTFLog.TextChanged += new System.EventHandler(this.RTFLog_TextChanged);
            // 
            // frmDatenExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 554);
            this.Controls.Add(this.chkPDFA);
            this.Controls.Add(this.lblKlient);
            this.Controls.Add(this.chkXMLExport);
            this.Controls.Add(this.chkPDFExport);
            this.Controls.Add(this.RTFLog);
            this.Controls.Add(this.btnArchivErstellen);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.optDatenexportTyp);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1083, 593);
            this.Name = "frmDatenExport";
            this.Text = "frmDatenExport";
            ((System.ComponentModel.ISupportInitialize)(this.chkXMLExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPDFExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optDatenexportTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPDFA)).EndInit();
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
        public QS2.Desktop.ControlManagment.BaseCheckBox chkPDFA;
    }
}