
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.optDatenexportTyp = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.lblTarget = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnArchivErstellen = new QS2.Desktop.ControlManagment.BaseButton();
            this.RTFLog = new PMDS.GUI.ucRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.optDatenexportTyp)).BeginInit();
            this.SuspendLayout();
            // 
            // optDatenexportTyp
            // 
            this.optDatenexportTyp.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance1.FontData.SizeInPoints = 10F;
            this.optDatenexportTyp.ItemAppearance = appearance1;
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
            this.optDatenexportTyp.Location = new System.Drawing.Point(12, 22);
            this.optDatenexportTyp.Name = "optDatenexportTyp";
            this.optDatenexportTyp.Size = new System.Drawing.Size(366, 55);
            this.optDatenexportTyp.TabIndex = 3;
            this.optDatenexportTyp.ValueChanged += new System.EventHandler(this.optDatenexportTyp_ValueChanged);
            // 
            // lblTarget
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.lblTarget.Appearance = appearance2;
            this.lblTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarget.Location = new System.Drawing.Point(12, 83);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(776, 52);
            this.lblTarget.TabIndex = 157;
            this.lblTarget.Text = "Ausgabeverzeichnis";
            // 
            // btnArchivErstellen
            // 
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnArchivErstellen.Appearance = appearance3;
            this.btnArchivErstellen.AutoWorkLayout = false;
            this.btnArchivErstellen.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnArchivErstellen.IsStandardControl = false;
            this.btnArchivErstellen.Location = new System.Drawing.Point(644, 22);
            this.btnArchivErstellen.Name = "btnArchivErstellen";
            this.btnArchivErstellen.Size = new System.Drawing.Size(144, 25);
            this.btnArchivErstellen.TabIndex = 158;
            this.btnArchivErstellen.Text = "Archiv erstellen";
            this.btnArchivErstellen.Click += new System.EventHandler(this.btnArchivErstellen_Click);
            // 
            // RTFLog
            // 
            this.RTFLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RTFLog.HiglightColor = PMDS.GUI.RtfColor.White;
            this.RTFLog.Location = new System.Drawing.Point(12, 152);
            this.RTFLog.Name = "RTFLog";
            this.RTFLog.Size = new System.Drawing.Size(775, 279);
            this.RTFLog.TabIndex = 159;
            this.RTFLog.Text = "";
            this.RTFLog.TextColor = PMDS.GUI.RtfColor.Black;
            // 
            // frmDatenExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RTFLog);
            this.Controls.Add(this.btnArchivErstellen);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.optDatenexportTyp);
            this.Name = "frmDatenExport";
            this.Text = "frmDatenExport";
            ((System.ComponentModel.ISupportInitialize)(this.optDatenexportTyp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseOptionSet optDatenexportTyp;
        private QS2.Desktop.ControlManagment.BaseLabel lblTarget;
        private QS2.Desktop.ControlManagment.BaseButton btnArchivErstellen;
        private ucRichTextBox RTFLog;
    }
}