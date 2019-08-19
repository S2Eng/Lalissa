using PMDS.Global.db.Patient;

namespace PMDS.GUI
{
    partial class ucQM
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
            this.pnlBereichsAuswahl = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlBereich = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlUser = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlAbteilung = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucBigKlientenSelector1 = new PMDS.GUI.BaseControls.ucBigKlientenSelector();
            this.ucBigBenutzerAuswahl1 = new PMDS.GUI.BaseControls.ucBigBenutzerAuswahl();
            this.ucBigAbteilungsAuswahl1 = new PMDS.GUI.BaseControls.ucBigAbteilungsAuswahl();
            this.pnlBottom = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnFreierBericht = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnBedarfsM = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnUngeplM = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraFlowLayoutManager2 = new Infragistics.Win.Misc.UltraFlowLayoutManager(this.components);
            this.pnlButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.dsPatientStation1 = new dsPatientStation();
            this.panel1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucBigRMMain1 = new PMDS.GUI.ucBigRMMain();
            this.pnlBereichsAuswahl.SuspendLayout();
            this.pnlAbteilung.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFlowLayoutManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientStation1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBereichsAuswahl
            // 
            this.pnlBereichsAuswahl.Controls.Add(this.pnlBereich);
            this.pnlBereichsAuswahl.Controls.Add(this.pnlUser);
            this.pnlBereichsAuswahl.Controls.Add(this.pnlAbteilung);
            this.pnlBereichsAuswahl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBereichsAuswahl.Location = new System.Drawing.Point(0, 0);
            this.pnlBereichsAuswahl.Name = "pnlBereichsAuswahl";
            this.pnlBereichsAuswahl.Size = new System.Drawing.Size(951, 112);
            this.pnlBereichsAuswahl.TabIndex = 2;
            // 
            // pnlBereich
            // 
            this.pnlBereich.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBereich.Location = new System.Drawing.Point(680, 0);
            this.pnlBereich.Name = "pnlBereich";
            this.pnlBereich.Size = new System.Drawing.Size(144, 112);
            this.pnlBereich.TabIndex = 2;
            // 
            // pnlUser
            // 
            this.pnlUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlUser.Location = new System.Drawing.Point(824, 0);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(127, 112);
            this.pnlUser.TabIndex = 1;
            // 
            // pnlAbteilung
            // 
            this.pnlAbteilung.Controls.Add(this.ucBigKlientenSelector1);
            this.pnlAbteilung.Controls.Add(this.ucBigBenutzerAuswahl1);
            this.pnlAbteilung.Controls.Add(this.ucBigAbteilungsAuswahl1);
            this.pnlAbteilung.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAbteilung.Location = new System.Drawing.Point(0, 0);
            this.pnlAbteilung.Name = "pnlAbteilung";
            this.pnlAbteilung.Size = new System.Drawing.Size(680, 112);
            this.pnlAbteilung.TabIndex = 0;
            // 
            // ucBigKlientenSelector1
            // 
            this.ucBigKlientenSelector1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucBigKlientenSelector1.Location = new System.Drawing.Point(437, 4);
            this.ucBigKlientenSelector1.Name = "ucBigKlientenSelector1";
            this.ucBigKlientenSelector1.Size = new System.Drawing.Size(211, 94);
            this.ucBigKlientenSelector1.TabIndex = 0;
            this.ucBigKlientenSelector1.Visible = false;
            this.ucBigKlientenSelector1.SelectionChanged += new System.EventHandler(this.ucBigKlientenSelector1_SelectionChanged);
            this.ucBigKlientenSelector1.Load += new System.EventHandler(this.ucBigKlientenSelector1_Load);
            // 
            // ucBigBenutzerAuswahl1
            // 
            this.ucBigBenutzerAuswahl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucBigBenutzerAuswahl1.Location = new System.Drawing.Point(3, 4);
            this.ucBigBenutzerAuswahl1.Name = "ucBigBenutzerAuswahl1";
            this.ucBigBenutzerAuswahl1.Size = new System.Drawing.Size(211, 94);
            this.ucBigBenutzerAuswahl1.TabIndex = 0;
            this.ucBigBenutzerAuswahl1.SelectionChanged += new System.EventHandler(this.ucBigBenutzerAuswahl1_SelectionChanged);
            this.ucBigBenutzerAuswahl1.Load += new System.EventHandler(this.ucBigBenutzerAuswahl1_Load);
            // 
            // ucBigAbteilungsAuswahl1
            // 
            this.ucBigAbteilungsAuswahl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucBigAbteilungsAuswahl1.Location = new System.Drawing.Point(220, 4);
            this.ucBigAbteilungsAuswahl1.Name = "ucBigAbteilungsAuswahl1";
            this.ucBigAbteilungsAuswahl1.Size = new System.Drawing.Size(211, 94);
            this.ucBigAbteilungsAuswahl1.TabIndex = 0;
            this.ucBigAbteilungsAuswahl1.Visible = false;
            this.ucBigAbteilungsAuswahl1.SelectionChanged += new System.EventHandler(this.ucBigAbteilungsAuswahl1_SelectionChanged);
            this.ucBigAbteilungsAuswahl1.Load += new System.EventHandler(this.ucBigAbteilungsAuswahl1_Load);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnFreierBericht);
            this.pnlBottom.Controls.Add(this.btnBedarfsM);
            this.pnlBottom.Controls.Add(this.btnUngeplM);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 570);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(951, 105);
            this.pnlBottom.TabIndex = 4;
            this.pnlBottom.Visible = false;
            // 
            // btnFreierBericht
            // 
            this.btnFreierBericht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFreierBericht.AutoWorkLayout = false;
            this.btnFreierBericht.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnFreierBericht.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreierBericht.ImageSize = new System.Drawing.Size(60, 60);
            this.btnFreierBericht.IsStandardControl = false;
            this.btnFreierBericht.Location = new System.Drawing.Point(220, 6);
            this.btnFreierBericht.Name = "btnFreierBericht";
            this.btnFreierBericht.Size = new System.Drawing.Size(211, 94);
            this.btnFreierBericht.TabIndex = 13;
            this.btnFreierBericht.Text = "Dekurs";
            this.btnFreierBericht.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnFreierBericht.Click += new System.EventHandler(this.btnFreierBericht_Click);
            // 
            // btnBedarfsM
            // 
            this.btnBedarfsM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBedarfsM.AutoWorkLayout = false;
            this.btnBedarfsM.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnBedarfsM.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBedarfsM.ImageSize = new System.Drawing.Size(60, 60);
            this.btnBedarfsM.IsStandardControl = false;
            this.btnBedarfsM.Location = new System.Drawing.Point(437, 6);
            this.btnBedarfsM.Name = "btnBedarfsM";
            this.btnBedarfsM.Size = new System.Drawing.Size(211, 94);
            this.btnBedarfsM.TabIndex = 12;
            this.btnBedarfsM.Text = "Einzelverordnung";
            this.btnBedarfsM.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnBedarfsM.Click += new System.EventHandler(this.btnBedarfsM_Click);
            // 
            // btnUngeplM
            // 
            this.btnUngeplM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUngeplM.AutoWorkLayout = false;
            this.btnUngeplM.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnUngeplM.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUngeplM.ImageSize = new System.Drawing.Size(60, 60);
            this.btnUngeplM.IsStandardControl = false;
            this.btnUngeplM.Location = new System.Drawing.Point(3, 6);
            this.btnUngeplM.Name = "btnUngeplM";
            this.btnUngeplM.Size = new System.Drawing.Size(211, 94);
            this.btnUngeplM.TabIndex = 11;
            this.btnUngeplM.Text = "Ungeplante Maßnahme";
            this.btnUngeplM.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnUngeplM.Click += new System.EventHandler(this.btnUngeplM_Click);
            // 
            // ultraFlowLayoutManager2
            // 
            this.ultraFlowLayoutManager2.ContainerControl = this.pnlButtons;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(951, 458);
            this.pnlButtons.TabIndex = 5;
            // 
            // dsPatientStation1
            // 
            this.dsPatientStation1.DataSetName = "dsPatientStation";
            this.dsPatientStation1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsPatientStation1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucBigRMMain1);
            this.panel1.Controls.Add(this.pnlButtons);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 458);
            this.panel1.TabIndex = 6;
            // 
            // ucBigRMMain1
            // 
            this.ucBigRMMain1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucBigRMMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBigRMMain1.Location = new System.Drawing.Point(0, 0);
            this.ucBigRMMain1.Name = "ucBigRMMain1";
            this.ucBigRMMain1.Size = new System.Drawing.Size(951, 458);
            this.ucBigRMMain1.TabIndex = 6;
            this.ucBigRMMain1.Visible = false;
            // 
            // ucQM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlBereichsAuswahl);
            this.Name = "ucQM";
            this.Size = new System.Drawing.Size(951, 675);
            this.Load += new System.EventHandler(this.ucQM_Load);
            this.VisibleChanged += new System.EventHandler(this.ucQM_VisibleChanged);
            this.Move += new System.EventHandler(this.ucQM_Resize);
            this.Resize += new System.EventHandler(this.ucQM_Resize);
            this.pnlBereichsAuswahl.ResumeLayout(false);
            this.pnlAbteilung.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFlowLayoutManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientStation1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel pnlBereichsAuswahl;
        private dsPatientStation dsPatientStation1;
        private QS2.Desktop.ControlManagment.BasePanel pnlUser;
        private QS2.Desktop.ControlManagment.BasePanel pnlAbteilung;
        private QS2.Desktop.ControlManagment.BasePanel pnlBereich;
        private PMDS.GUI.BaseControls.ucBigAbteilungsAuswahl ucBigAbteilungsAuswahl1;
        private QS2.Desktop.ControlManagment.BasePanel pnlBottom;
        private Infragistics.Win.Misc.UltraFlowLayoutManager ultraFlowLayoutManager2;
        private QS2.Desktop.ControlManagment.BasePanel pnlButtons;
        private PMDS.GUI.BaseControls.ucBigKlientenSelector ucBigKlientenSelector1;
        private PMDS.GUI.BaseControls.ucBigBenutzerAuswahl ucBigBenutzerAuswahl1;
        private QS2.Desktop.ControlManagment.BaseButton btnFreierBericht;
        private QS2.Desktop.ControlManagment.BaseButton btnBedarfsM;
        private QS2.Desktop.ControlManagment.BaseButton btnUngeplM;
        private QS2.Desktop.ControlManagment.BasePanel panel1;
        private ucBigRMMain ucBigRMMain1;
    }
}
