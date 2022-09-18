
namespace qs2.ui.ManageDeathStatus
{
    partial class contManageDeathStatusExcel
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.btnStart = new qs2.sitemap.ownControls.inherit_Infrag.InfragButton();
            this.lblLastName = new Infragistics.Win.Misc.UltraLabel();
            this.cboLastName = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblFirstName = new Infragistics.Win.Misc.UltraLabel();
            this.cboFirstName = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblDayDOB = new Infragistics.Win.Misc.UltraLabel();
            this.lblMonthDOB = new Infragistics.Win.Misc.UltraLabel();
            this.lblYearDOB = new Infragistics.Win.Misc.UltraLabel();
            this.lblDOB = new Infragistics.Win.Misc.UltraLabel();
            this.cboDayDOB = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboMonthDOB = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboYearDOB = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblGender = new Infragistics.Win.Misc.UltraLabel();
            this.cboGender = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboICD9 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblICD9 = new Infragistics.Win.Misc.UltraLabel();
            this.cboYearDOD = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboMonthDOD = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cboDayDOD = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblDOD = new Infragistics.Win.Misc.UltraLabel();
            this.lblYearDOD = new Infragistics.Win.Misc.UltraLabel();
            this.lblMonthDOD = new Infragistics.Win.Misc.UltraLabel();
            this.lblDayDOD = new Infragistics.Win.Misc.UltraLabel();
            this.pnlAssignment = new Infragistics.Win.Misc.UltraPanel();
            this.lblExcel = new Infragistics.Win.Misc.UltraLabel();
            this.lblDatabase = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.lblAdvice = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cboLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDayDOB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMonthDOB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYearDOB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboICD9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYearDOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMonthDOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDayDOD)).BeginInit();
            this.pnlAssignment.ClientArea.SuspendLayout();
            this.pnlAssignment.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnStart.Appearance = appearance1;
            this.btnStart.Location = new System.Drawing.Point(177, 364);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.OwnAutoTextYN = true;
            this.btnStart.OwnPicture = null;
            this.btnStart.OwnPictureTxt = "";
            this.btnStart.OwnSizeMode = qs2.core.Enums.eSize.big;
            this.btnStart.OwnTooltipText = "";
            this.btnStart.OwnTooltipTitle = null;
            this.btnStart.Size = new System.Drawing.Size(179, 41);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(7, 39);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(4);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(133, 24);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "LastName";
            // 
            // cboLastName
            // 
            this.cboLastName.Location = new System.Drawing.Point(177, 35);
            this.cboLastName.Margin = new System.Windows.Forms.Padding(4);
            this.cboLastName.Name = "cboLastName";
            this.cboLastName.Size = new System.Drawing.Size(179, 24);
            this.cboLastName.TabIndex = 3;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(7, 71);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(133, 24);
            this.lblFirstName.TabIndex = 4;
            this.lblFirstName.Text = "FirstName";
            // 
            // cboFirstName
            // 
            this.cboFirstName.Location = new System.Drawing.Point(177, 67);
            this.cboFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.cboFirstName.Name = "cboFirstName";
            this.cboFirstName.Size = new System.Drawing.Size(179, 24);
            this.cboFirstName.TabIndex = 5;
            // 
            // lblDayDOB
            // 
            this.lblDayDOB.Location = new System.Drawing.Point(102, 103);
            this.lblDayDOB.Margin = new System.Windows.Forms.Padding(4);
            this.lblDayDOB.Name = "lblDayDOB";
            this.lblDayDOB.Size = new System.Drawing.Size(53, 24);
            this.lblDayDOB.TabIndex = 6;
            this.lblDayDOB.Text = "Day";
            // 
            // lblMonthDOB
            // 
            this.lblMonthDOB.Location = new System.Drawing.Point(102, 135);
            this.lblMonthDOB.Margin = new System.Windows.Forms.Padding(4);
            this.lblMonthDOB.Name = "lblMonthDOB";
            this.lblMonthDOB.Size = new System.Drawing.Size(53, 24);
            this.lblMonthDOB.TabIndex = 7;
            this.lblMonthDOB.Text = "Month";
            // 
            // lblYearDOB
            // 
            this.lblYearDOB.Location = new System.Drawing.Point(102, 167);
            this.lblYearDOB.Margin = new System.Windows.Forms.Padding(4);
            this.lblYearDOB.Name = "lblYearDOB";
            this.lblYearDOB.Size = new System.Drawing.Size(53, 24);
            this.lblYearDOB.TabIndex = 8;
            this.lblYearDOB.Text = "Year";
            // 
            // lblDOB
            // 
            this.lblDOB.Location = new System.Drawing.Point(7, 103);
            this.lblDOB.Margin = new System.Windows.Forms.Padding(4);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(65, 23);
            this.lblDOB.TabIndex = 9;
            this.lblDOB.Text = "Birthday";
            // 
            // cboDayDOB
            // 
            this.cboDayDOB.Location = new System.Drawing.Point(177, 99);
            this.cboDayDOB.Margin = new System.Windows.Forms.Padding(4);
            this.cboDayDOB.Name = "cboDayDOB";
            this.cboDayDOB.Size = new System.Drawing.Size(179, 24);
            this.cboDayDOB.TabIndex = 10;
            // 
            // cboMonthDOB
            // 
            this.cboMonthDOB.Location = new System.Drawing.Point(177, 131);
            this.cboMonthDOB.Margin = new System.Windows.Forms.Padding(4);
            this.cboMonthDOB.Name = "cboMonthDOB";
            this.cboMonthDOB.Size = new System.Drawing.Size(179, 24);
            this.cboMonthDOB.TabIndex = 11;
            // 
            // cboYearDOB
            // 
            this.cboYearDOB.Location = new System.Drawing.Point(177, 163);
            this.cboYearDOB.Margin = new System.Windows.Forms.Padding(4);
            this.cboYearDOB.Name = "cboYearDOB";
            this.cboYearDOB.Size = new System.Drawing.Size(179, 24);
            this.cboYearDOB.TabIndex = 12;
            // 
            // lblGender
            // 
            this.lblGender.Location = new System.Drawing.Point(7, 199);
            this.lblGender.Margin = new System.Windows.Forms.Padding(4);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(133, 24);
            this.lblGender.TabIndex = 13;
            this.lblGender.Text = "Gender";
            // 
            // cboGender
            // 
            this.cboGender.Location = new System.Drawing.Point(177, 195);
            this.cboGender.Margin = new System.Windows.Forms.Padding(4);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(179, 24);
            this.cboGender.TabIndex = 14;
            // 
            // cboICD9
            // 
            this.cboICD9.Location = new System.Drawing.Point(177, 323);
            this.cboICD9.Margin = new System.Windows.Forms.Padding(4);
            this.cboICD9.Name = "cboICD9";
            this.cboICD9.Size = new System.Drawing.Size(179, 24);
            this.cboICD9.TabIndex = 23;
            // 
            // lblICD9
            // 
            this.lblICD9.Location = new System.Drawing.Point(7, 327);
            this.lblICD9.Margin = new System.Windows.Forms.Padding(4);
            this.lblICD9.Name = "lblICD9";
            this.lblICD9.Size = new System.Drawing.Size(133, 24);
            this.lblICD9.TabIndex = 22;
            this.lblICD9.Text = "ICD Code";
            // 
            // cboYearDOD
            // 
            this.cboYearDOD.Location = new System.Drawing.Point(177, 291);
            this.cboYearDOD.Margin = new System.Windows.Forms.Padding(4);
            this.cboYearDOD.Name = "cboYearDOD";
            this.cboYearDOD.Size = new System.Drawing.Size(179, 24);
            this.cboYearDOD.TabIndex = 21;
            // 
            // cboMonthDOD
            // 
            this.cboMonthDOD.Location = new System.Drawing.Point(177, 259);
            this.cboMonthDOD.Margin = new System.Windows.Forms.Padding(4);
            this.cboMonthDOD.Name = "cboMonthDOD";
            this.cboMonthDOD.Size = new System.Drawing.Size(179, 24);
            this.cboMonthDOD.TabIndex = 20;
            // 
            // cboDayDOD
            // 
            this.cboDayDOD.Location = new System.Drawing.Point(177, 227);
            this.cboDayDOD.Margin = new System.Windows.Forms.Padding(4);
            this.cboDayDOD.Name = "cboDayDOD";
            this.cboDayDOD.Size = new System.Drawing.Size(179, 24);
            this.cboDayDOD.TabIndex = 19;
            // 
            // lblDOD
            // 
            this.lblDOD.Location = new System.Drawing.Point(7, 231);
            this.lblDOD.Margin = new System.Windows.Forms.Padding(4);
            this.lblDOD.Name = "lblDOD";
            this.lblDOD.Size = new System.Drawing.Size(87, 23);
            this.lblDOD.TabIndex = 18;
            this.lblDOD.Text = "Date of Death";
            // 
            // lblYearDOD
            // 
            this.lblYearDOD.Location = new System.Drawing.Point(102, 295);
            this.lblYearDOD.Margin = new System.Windows.Forms.Padding(4);
            this.lblYearDOD.Name = "lblYearDOD";
            this.lblYearDOD.Size = new System.Drawing.Size(53, 24);
            this.lblYearDOD.TabIndex = 17;
            this.lblYearDOD.Text = "Year";
            // 
            // lblMonthDOD
            // 
            this.lblMonthDOD.Location = new System.Drawing.Point(102, 263);
            this.lblMonthDOD.Margin = new System.Windows.Forms.Padding(4);
            this.lblMonthDOD.Name = "lblMonthDOD";
            this.lblMonthDOD.Size = new System.Drawing.Size(53, 24);
            this.lblMonthDOD.TabIndex = 16;
            this.lblMonthDOD.Text = "Month";
            // 
            // lblDayDOD
            // 
            this.lblDayDOD.Location = new System.Drawing.Point(102, 231);
            this.lblDayDOD.Margin = new System.Windows.Forms.Padding(4);
            this.lblDayDOD.Name = "lblDayDOD";
            this.lblDayDOD.Size = new System.Drawing.Size(53, 24);
            this.lblDayDOD.TabIndex = 15;
            this.lblDayDOD.Text = "Day";
            // 
            // pnlAssignment
            // 
            // 
            // pnlAssignment.ClientArea
            // 
            this.pnlAssignment.ClientArea.Controls.Add(this.ultraLabel10);
            this.pnlAssignment.ClientArea.Controls.Add(this.ultraLabel9);
            this.pnlAssignment.ClientArea.Controls.Add(this.ultraLabel8);
            this.pnlAssignment.ClientArea.Controls.Add(this.ultraLabel7);
            this.pnlAssignment.ClientArea.Controls.Add(this.ultraLabel6);
            this.pnlAssignment.ClientArea.Controls.Add(this.ultraLabel5);
            this.pnlAssignment.ClientArea.Controls.Add(this.ultraLabel4);
            this.pnlAssignment.ClientArea.Controls.Add(this.ultraLabel3);
            this.pnlAssignment.ClientArea.Controls.Add(this.ultraLabel2);
            this.pnlAssignment.ClientArea.Controls.Add(this.ultraLabel1);
            this.pnlAssignment.ClientArea.Controls.Add(this.lblExcel);
            this.pnlAssignment.ClientArea.Controls.Add(this.lblDatabase);
            this.pnlAssignment.ClientArea.Controls.Add(this.lblLastName);
            this.pnlAssignment.ClientArea.Controls.Add(this.cboICD9);
            this.pnlAssignment.ClientArea.Controls.Add(this.btnStart);
            this.pnlAssignment.ClientArea.Controls.Add(this.cboLastName);
            this.pnlAssignment.ClientArea.Controls.Add(this.lblICD9);
            this.pnlAssignment.ClientArea.Controls.Add(this.lblFirstName);
            this.pnlAssignment.ClientArea.Controls.Add(this.cboYearDOD);
            this.pnlAssignment.ClientArea.Controls.Add(this.cboFirstName);
            this.pnlAssignment.ClientArea.Controls.Add(this.cboMonthDOD);
            this.pnlAssignment.ClientArea.Controls.Add(this.lblDayDOB);
            this.pnlAssignment.ClientArea.Controls.Add(this.cboDayDOD);
            this.pnlAssignment.ClientArea.Controls.Add(this.lblMonthDOB);
            this.pnlAssignment.ClientArea.Controls.Add(this.lblDOD);
            this.pnlAssignment.ClientArea.Controls.Add(this.lblYearDOB);
            this.pnlAssignment.ClientArea.Controls.Add(this.lblYearDOD);
            this.pnlAssignment.ClientArea.Controls.Add(this.lblDOB);
            this.pnlAssignment.ClientArea.Controls.Add(this.lblMonthDOD);
            this.pnlAssignment.ClientArea.Controls.Add(this.cboDayDOB);
            this.pnlAssignment.ClientArea.Controls.Add(this.lblDayDOD);
            this.pnlAssignment.ClientArea.Controls.Add(this.cboMonthDOB);
            this.pnlAssignment.ClientArea.Controls.Add(this.cboGender);
            this.pnlAssignment.ClientArea.Controls.Add(this.cboYearDOB);
            this.pnlAssignment.ClientArea.Controls.Add(this.lblGender);
            this.pnlAssignment.Enabled = false;
            this.pnlAssignment.Location = new System.Drawing.Point(14, 13);
            this.pnlAssignment.Name = "pnlAssignment";
            this.pnlAssignment.Size = new System.Drawing.Size(372, 421);
            this.pnlAssignment.TabIndex = 24;
            // 
            // lblExcel
            // 
            this.lblExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExcel.Location = new System.Drawing.Point(177, 3);
            this.lblExcel.Margin = new System.Windows.Forms.Padding(4);
            this.lblExcel.Name = "lblExcel";
            this.lblExcel.Size = new System.Drawing.Size(176, 24);
            this.lblExcel.TabIndex = 25;
            this.lblExcel.Text = "Excel-File";
            // 
            // lblDatabase
            // 
            this.lblDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabase.Location = new System.Drawing.Point(7, 4);
            this.lblDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(146, 24);
            this.lblDatabase.TabIndex = 24;
            this.lblDatabase.Text = "Database";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(148, 39);
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(21, 24);
            this.ultraLabel1.TabIndex = 26;
            this.ultraLabel1.Text = "...";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(148, 71);
            this.ultraLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(21, 24);
            this.ultraLabel2.TabIndex = 27;
            this.ultraLabel2.Text = "...";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(148, 103);
            this.ultraLabel3.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(21, 24);
            this.ultraLabel3.TabIndex = 28;
            this.ultraLabel3.Text = "...";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(148, 135);
            this.ultraLabel4.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(21, 24);
            this.ultraLabel4.TabIndex = 29;
            this.ultraLabel4.Text = "...";
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(148, 167);
            this.ultraLabel5.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(21, 24);
            this.ultraLabel5.TabIndex = 30;
            this.ultraLabel5.Text = "...";
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(148, 199);
            this.ultraLabel6.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(21, 24);
            this.ultraLabel6.TabIndex = 31;
            this.ultraLabel6.Text = "...";
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.Location = new System.Drawing.Point(148, 231);
            this.ultraLabel7.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(21, 24);
            this.ultraLabel7.TabIndex = 32;
            this.ultraLabel7.Text = "...";
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.Location = new System.Drawing.Point(148, 263);
            this.ultraLabel8.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(21, 24);
            this.ultraLabel8.TabIndex = 33;
            this.ultraLabel8.Text = "...";
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.Location = new System.Drawing.Point(148, 295);
            this.ultraLabel9.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(21, 24);
            this.ultraLabel9.TabIndex = 34;
            this.ultraLabel9.Text = "...";
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.Location = new System.Drawing.Point(148, 327);
            this.ultraLabel10.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(21, 24);
            this.ultraLabel10.TabIndex = 35;
            this.ultraLabel10.Text = "...";
            // 
            // lblAdvice
            // 
            this.lblAdvice.Location = new System.Drawing.Point(14, 441);
            this.lblAdvice.Margin = new System.Windows.Forms.Padding(4);
            this.lblAdvice.Name = "lblAdvice";
            this.lblAdvice.Size = new System.Drawing.Size(372, 68);
            this.lblAdvice.TabIndex = 25;
            this.lblAdvice.Text = "LastName";
            // 
            // contManageDeathStatusExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAdvice);
            this.Controls.Add(this.pnlAssignment);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "contManageDeathStatusExcel";
            this.Size = new System.Drawing.Size(408, 513);
            this.Load += new System.EventHandler(this.contManageDeathStatusExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDayDOB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMonthDOB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYearDOB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboICD9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYearDOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMonthDOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDayDOD)).EndInit();
            this.pnlAssignment.ClientArea.ResumeLayout(false);
            this.pnlAssignment.ClientArea.PerformLayout();
            this.pnlAssignment.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sitemap.ownControls.inherit_Infrag.InfragButton btnStart;
        private Infragistics.Win.Misc.UltraLabel lblLastName;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboLastName;
        private Infragistics.Win.Misc.UltraLabel lblFirstName;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboFirstName;
        private Infragistics.Win.Misc.UltraLabel lblDayDOB;
        private Infragistics.Win.Misc.UltraLabel lblMonthDOB;
        private Infragistics.Win.Misc.UltraLabel lblYearDOB;
        private Infragistics.Win.Misc.UltraLabel lblDOB;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboDayDOB;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboMonthDOB;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboYearDOB;
        private Infragistics.Win.Misc.UltraLabel lblGender;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboGender;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboICD9;
        private Infragistics.Win.Misc.UltraLabel lblICD9;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboYearDOD;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboMonthDOD;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboDayDOD;
        private Infragistics.Win.Misc.UltraLabel lblDOD;
        private Infragistics.Win.Misc.UltraLabel lblYearDOD;
        private Infragistics.Win.Misc.UltraLabel lblMonthDOD;
        private Infragistics.Win.Misc.UltraLabel lblDayDOD;
        private Infragistics.Win.Misc.UltraPanel pnlAssignment;
        private Infragistics.Win.Misc.UltraLabel lblExcel;
        private Infragistics.Win.Misc.UltraLabel lblDatabase;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel lblAdvice;
    }
}
