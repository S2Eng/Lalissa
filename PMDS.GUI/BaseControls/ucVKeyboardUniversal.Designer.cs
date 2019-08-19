namespace PMDS.GUI.BaseControls
{
    partial class ucVKeyboardUniversal
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
            this.btnToogle = new QS2.Desktop.ControlManagment.BaseButton();
            this.ucVKeyboardAlpha1 = new PMDS.GUI.BaseControls.ucVKeyboardAlpha();
            this.ucVKeyboard1 = new VirtualKeyboard.ucVKeyboard();
            this.SuspendLayout();
            // 
            // btnToogle
            // 
            this.btnToogle.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnToogle.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToogle.Location = new System.Drawing.Point(3, 2);
            this.btnToogle.Name = "btnToogle";
            this.btnToogle.Size = new System.Drawing.Size(82, 49);
            this.btnToogle.TabIndex = 2;
            this.btnToogle.Text = "A->Z";
            this.btnToogle.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnToogle.Click += new System.EventHandler(this.btnToogle_Click);
            // 
            // ucVKeyboardAlpha1
            // 
            this.ucVKeyboardAlpha1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucVKeyboardAlpha1.KeyFont = new System.Drawing.Font("Arial", 12F);
            this.ucVKeyboardAlpha1.Location = new System.Drawing.Point(105, 125);
            this.ucVKeyboardAlpha1.Name = "ucVKeyboardAlpha1";
            this.ucVKeyboardAlpha1.Size = new System.Drawing.Size(924, 281);
            this.ucVKeyboardAlpha1.TabIndex = 1;
            // 
            // ucVKeyboard1
            // 
            this.ucVKeyboard1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucVKeyboard1.KeyFont = new System.Drawing.Font("Arial", 12F);
            this.ucVKeyboard1.Location = new System.Drawing.Point(0, 0);
            this.ucVKeyboard1.Name = "ucVKeyboard1";
            this.ucVKeyboard1.Size = new System.Drawing.Size(921, 277);
            this.ucVKeyboard1.TabIndex = 0;
            // 
            // ucVKeyboardUniversal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btnToogle);
            this.Controls.Add(this.ucVKeyboardAlpha1);
            this.Controls.Add(this.ucVKeyboard1);
            this.Name = "ucVKeyboardUniversal";
            this.Size = new System.Drawing.Size(922, 358);
            this.EnabledChanged += new System.EventHandler(this.ucVKeyboardUniversal_EnabledChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private VirtualKeyboard.ucVKeyboard ucVKeyboard1;
        private ucVKeyboardAlpha ucVKeyboardAlpha1;
        private QS2.Desktop.ControlManagment.BaseButton btnToogle;
    }
}
