namespace PMDS.GUI
{
    partial class ucPDxSearchPicker
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
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.btnPfDef = new Infragistics.Win.Misc.UltraDropDownButton();
            this.ultraPopupControlContainer1 = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.pnlPrintStammDatenBlatt = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraGroupBox2 = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.opSucheIN = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.ultraGroupBox1 = new QS2.Desktop.ControlManagment.BaseGroupBox();
            this.opVerknuepfung = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.opAuswahl = new QS2.Desktop.ControlManagment.BaseOptionSet();
            this.btnOk = new PMDS.GUI.ucButton(this.components);
            this.pnlPrintStammDatenBlatt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opSucheIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opVerknuepfung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opAuswahl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPfDef
            // 
            this.btnPfDef.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button;
            this.btnPfDef.Location = new System.Drawing.Point(3, 3);
            this.btnPfDef.Name = "btnPfDef";
            this.btnPfDef.PopupItemKey = "pnlPrintStammDatenBlatt";
            this.btnPfDef.PopupItemProvider = this.ultraPopupControlContainer1;
            this.btnPfDef.RightAlignPopup = Infragistics.Win.DefaultableBoolean.False;
            this.btnPfDef.Size = new System.Drawing.Size(189, 21);
            this.btnPfDef.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.btnPfDef.TabIndex = 90;
            this.btnPfDef.Text = "&Pflegedefinitionen hinzufügen";
            this.btnPfDef.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnPfDef.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraPopupControlContainer1
            // 
            this.ultraPopupControlContainer1.PopupControl = this.pnlPrintStammDatenBlatt;
            // 
            // pnlPrintStammDatenBlatt
            // 
            this.pnlPrintStammDatenBlatt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPrintStammDatenBlatt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrintStammDatenBlatt.Controls.Add(this.ultraGroupBox2);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.ultraGroupBox1);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.opAuswahl);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.btnOk);
            this.pnlPrintStammDatenBlatt.Location = new System.Drawing.Point(3, 24);
            this.pnlPrintStammDatenBlatt.Name = "pnlPrintStammDatenBlatt";
            this.pnlPrintStammDatenBlatt.Size = new System.Drawing.Size(284, 170);
            this.pnlPrintStammDatenBlatt.TabIndex = 91;
            this.pnlPrintStammDatenBlatt.Visible = false;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.opSucheIN);
            this.ultraGroupBox2.Location = new System.Drawing.Point(130, 76);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(145, 54);
            this.ultraGroupBox2.TabIndex = 89;
            this.ultraGroupBox2.Text = "Wo wollen Sie suchen";
            this.ultraGroupBox2.Visible = false;
            // 
            // opSucheIN
            // 
            this.opSucheIN.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.opSucheIN.CheckedIndex = 0;
            valueListItem9.DataValue = 0;
            valueListItem9.DisplayText = "Pflegediagnosen";
            valueListItem10.DataValue = 1;
            valueListItem10.DisplayText = "Zugeordnete ASZM";
            this.opSucheIN.Items.Add(valueListItem9);
            this.opSucheIN.Items.Add(valueListItem10);
            this.opSucheIN.ItemSpacingVertical = 2;
            this.opSucheIN.Location = new System.Drawing.Point(6, 17);
            this.opSucheIN.Name = "opSucheIN";
            this.opSucheIN.Size = new System.Drawing.Size(122, 32);
            this.opSucheIN.TabIndex = 88;
            this.opSucheIN.Text = "Pflegediagnosen";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.opVerknuepfung);
            this.ultraGroupBox1.Location = new System.Drawing.Point(35, 76);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(89, 54);
            this.ultraGroupBox1.TabIndex = 88;
            this.ultraGroupBox1.Text = "Verknüpfung";
            this.ultraGroupBox1.Visible = false;
            // 
            // opVerknuepfung
            // 
            this.opVerknuepfung.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.opVerknuepfung.CheckedIndex = 0;
            valueListItem11.DataValue = 0;
            valueListItem11.DisplayText = "Und";
            valueListItem12.DataValue = 1;
            valueListItem12.DisplayText = "Oder";
            this.opVerknuepfung.Items.Add(valueListItem11);
            this.opVerknuepfung.Items.Add(valueListItem12);
            this.opVerknuepfung.ItemSpacingVertical = 2;
            this.opVerknuepfung.Location = new System.Drawing.Point(6, 17);
            this.opVerknuepfung.Name = "opVerknuepfung";
            this.opVerknuepfung.Size = new System.Drawing.Size(58, 32);
            this.opVerknuepfung.TabIndex = 88;
            this.opVerknuepfung.Text = "Und";
            // 
            // opAuswahl
            // 
            this.opAuswahl.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.opAuswahl.CheckedIndex = 0;
            valueListItem13.DataValue = 0;
            valueListItem13.DisplayText = "Favoriten für {0}";
            valueListItem14.DataValue = 1;
            valueListItem14.DisplayText = "Allgemeine Favoriten";
            valueListItem15.DataValue = 2;
            valueListItem15.DisplayText = "Pflegeanamnesen";
            valueListItem16.DataValue = 3;
            valueListItem16.DisplayText = "Suchen";
            this.opAuswahl.Items.Add(valueListItem13);
            this.opAuswahl.Items.Add(valueListItem14);
            this.opAuswahl.Items.Add(valueListItem15);
            this.opAuswahl.Items.Add(valueListItem16);
            this.opAuswahl.ItemSpacingVertical = 2;
            this.opAuswahl.Location = new System.Drawing.Point(12, 12);
            this.opAuswahl.Name = "opAuswahl";
            this.opAuswahl.Size = new System.Drawing.Size(257, 66);
            this.opAuswahl.TabIndex = 87;
            this.opAuswahl.Text = "Favoriten für {0}";
            // 
            // btnOk
            // 
            appearance2.Image = 4;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnOk.Appearance = appearance2;
            this.btnOk.Location = new System.Drawing.Point(226, 136);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(49, 29);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ucPDxSearchPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPrintStammDatenBlatt);
            this.Controls.Add(this.btnPfDef);
            this.Name = "ucPDxSearchPicker";
            this.Size = new System.Drawing.Size(290, 199);
            this.pnlPrintStammDatenBlatt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.opSucheIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.opVerknuepfung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opAuswahl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraDropDownButton btnPfDef;
        private QS2.Desktop.ControlManagment.BasePanel pnlPrintStammDatenBlatt;
        private ucButton btnOk;
        private QS2.Desktop.ControlManagment.BaseOptionSet opAuswahl;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBox2;
        private QS2.Desktop.ControlManagment.BaseOptionSet opSucheIN;
        private QS2.Desktop.ControlManagment.BaseGroupBox ultraGroupBox1;
        private QS2.Desktop.ControlManagment.BaseOptionSet opVerknuepfung;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainer1;
    }
}
