using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Global;



namespace PMDS.GUI
{



    public class ucPflegeEintragEx : PMDS.GUI.ucPflegeEintrag
    {
        protected QS2.Desktop.ControlManagment.BaseLabel lblGeplant;
        protected QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpZeitpunktPlan;
        private ucDateSelect ucDateSelect1;
        private System.ComponentModel.IContainer components = null;

        //----------------------------------------------------------------------------
        /// <summary>
        /// Default Konstruktor
        /// </summary>
        //----------------------------------------------------------------------------
        public ucPflegeEintragEx()
        {
            // Initialisierung erfolgt via InitSubComponent
            //InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Dispose
        /// </summary>
        //----------------------------------------------------------------------------
        public void ProcessMOhneZeitbezug()
        {
            dtpZeitpunkt.DateTime = DateTime.Now;
            lblGeplant.Visible = false;
            dtpZeitpunktPlan.Visible = false;
            _OhneZeitbezug = true;
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Dispose
        /// </summary>
        //----------------------------------------------------------------------------
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

        #region Vom Designer generierter Code
        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.lblGeplant = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpZeitpunktPlan = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.ucDateSelect1 = new PMDS.GUI.ucDateSelect();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImportant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMassnahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpZeitpunkt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBedarfsMedikament)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlsDekursKopieren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGegenzeichnen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeschreibungLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpZeitpunktPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // ucZusatzWert1
            // 
            this.ucZusatzWert1.Location = new System.Drawing.Point(440, 211);
            this.ucZusatzWert1.Margin = new System.Windows.Forms.Padding(4);
            this.ucZusatzWert1.Size = new System.Drawing.Size(353, 390);
            this.ucZusatzWert1.TabIndex = 11;
            // 
            // lblWichtigFür
            // 
            this.lblWichtigFür.Location = new System.Drawing.Point(11, 68);
            // 
            // cbImportant
            // 
            this.cbImportant.BackColor = System.Drawing.SystemColors.Control;
            this.cbImportant.Location = new System.Drawing.Point(120, 64);
            this.cbImportant.Size = new System.Drawing.Size(78, 24);
            this.cbImportant.TabIndex = 5;
            // 
            // lblAnmerkung
            // 
            this.lblAnmerkung.Location = new System.Drawing.Point(10, 186);
            // 
            // cbMassnahme
            // 
            this.cbMassnahme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.BackColor = System.Drawing.Color.LightYellow;
            this.cbMassnahme.Appearance = appearance1;
            this.cbMassnahme.BackColor = System.Drawing.SystemColors.Control;
            this.cbMassnahme.Location = new System.Drawing.Point(214, 122);
            this.cbMassnahme.Size = new System.Drawing.Size(581, 24);
            this.cbMassnahme.TabIndex = 8;
            // 
            // lblZeitpunktDerDurchführung
            // 
            this.lblZeitpunktDerDurchführung.Location = new System.Drawing.Point(11, 39);
            // 
            // labMassnahme
            // 
            this.labMassnahme.Location = new System.Drawing.Point(11, 126);
            // 
            // chkDone
            // 
            this.chkDone.Location = new System.Drawing.Point(440, 39);
            this.chkDone.Size = new System.Drawing.Size(128, 19);
            this.chkDone.TabIndex = 3;
            this.chkDone.CheckedChanged += new System.EventHandler(this.chkDone_CheckedChanged);
            // 
            // dtpZeitpunkt
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            this.dtpZeitpunkt.Appearance = appearance2;
            this.dtpZeitpunkt.Location = new System.Drawing.Point(213, 36);
            this.dtpZeitpunkt.TabIndex = 1;
            this.dtpZeitpunkt.ValueChanged += new System.EventHandler(this.dtpZeitpunkt_ValueChanged);
            // 
            // lblDauer
            // 
            this.lblDauer.Location = new System.Drawing.Point(655, 39);
            // 
            // txtIstDauer
            // 
            appearance3.BackColor = System.Drawing.Color.MistyRose;
            this.txtIstDauer.Appearance = appearance3;
            this.txtIstDauer.ContextMenuStrip = null;
            this.txtIstDauer.Location = new System.Drawing.Point(704, 37);
            // 
            // cbBedarfsMedikament
            // 
            this.cbBedarfsMedikament.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.cbBedarfsMedikament.BackColor = System.Drawing.SystemColors.Control;
            this.cbBedarfsMedikament.Location = new System.Drawing.Point(213, 92);
            this.cbBedarfsMedikament.Size = new System.Drawing.Size(581, 24);
            this.cbBedarfsMedikament.TabIndex = 7;
            // 
            // lblMedikation
            // 
            this.lblMedikation.Location = new System.Drawing.Point(11, 97);
            // 
            // lblMin
            // 
            this.lblMin.Location = new System.Drawing.Point(765, 39);
            // 
            // auswahlGruppeComboMulti1
            // 
            this.auswahlGruppeComboMulti1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.auswahlGruppeComboMulti1.Location = new System.Drawing.Point(213, 62);
            this.auswahlGruppeComboMulti1.Size = new System.Drawing.Size(581, 27);
            this.auswahlGruppeComboMulti1.TabIndex = 6;
            // 
            // chkAlsDekursKopieren
            // 
            this.chkAlsDekursKopieren.Location = new System.Drawing.Point(213, 150);
            this.chkAlsDekursKopieren.TabIndex = 9;
            // 
            // panelTxtControl
            // 
            this.panelTxtControl.Location = new System.Drawing.Point(226, 497);
            this.panelTxtControl.Size = new System.Drawing.Size(185, 110);
            // 
            // lblZusatzwerte
            // 
            this.lblZusatzwerte.Location = new System.Drawing.Point(440, 186);
            // 
            // chkGegenzeichnen
            // 
            this.chkGegenzeichnen.Location = new System.Drawing.Point(440, 150);
            // 
            // panelBeschreibungTXTEditor
            // 
            this.panelBeschreibungTXTEditor.Location = new System.Drawing.Point(9, 211);
            this.panelBeschreibungTXTEditor.Size = new System.Drawing.Size(422, 391);
            // 
            // txtBeschreibungLine
            // 
            this.txtBeschreibungLine.Size = new System.Drawing.Size(36, 24);
            // 
            // lblGeplant
            // 
            this.lblGeplant.AutoSize = true;
            this.lblGeplant.Location = new System.Drawing.Point(11, 11);
            this.lblGeplant.Margin = new System.Windows.Forms.Padding(4);
            this.lblGeplant.Name = "lblGeplant";
            this.lblGeplant.Size = new System.Drawing.Size(126, 17);
            this.lblGeplant.TabIndex = 30;
            this.lblGeplant.Text = "Geplanter Zeitpunkt";
            // 
            // dtpZeitpunktPlan
            // 
            this.dtpZeitpunktPlan.Enabled = false;
            this.dtpZeitpunktPlan.FormatString = "";
            this.dtpZeitpunktPlan.Location = new System.Drawing.Point(213, 7);
            this.dtpZeitpunktPlan.Margin = new System.Windows.Forms.Padding(4);
            this.dtpZeitpunktPlan.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpZeitpunktPlan.Name = "dtpZeitpunktPlan";
            this.dtpZeitpunktPlan.ownFormat = "";
            this.dtpZeitpunktPlan.ownMaskInput = "";
            this.dtpZeitpunktPlan.Size = new System.Drawing.Size(171, 24);
            this.dtpZeitpunktPlan.TabIndex = 0;
            // 
            // ucDateSelect1
            // 
            this.ucDateSelect1.Location = new System.Drawing.Point(388, 34);
            this.ucDateSelect1.Margin = new System.Windows.Forms.Padding(4);
            this.ucDateSelect1.Name = "ucDateSelect1";
            this.ucDateSelect1.Size = new System.Drawing.Size(51, 27);
            this.ucDateSelect1.TabIndex = 2;
            this.ucDateSelect1.delRefresh += new PMDS.Global.refreshUI(this.ucDateSelect1_delRefresh);
            this.ucDateSelect1.Load += new System.EventHandler(this.ucDateSelect1_Load);
            // 
            // ucPflegeEintragEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Controls.Add(this.lblGeplant);
            this.Controls.Add(this.dtpZeitpunktPlan);
            this.Controls.Add(this.ucDateSelect1);
            this.Name = "ucPflegeEintragEx";
            this.Size = new System.Drawing.Size(799, 609);
            this.Load += new System.EventHandler(this.ucPflegeEintragEx_Load);
            this.Controls.SetChildIndex(this.txtBeschreibungLine, 0);
            this.Controls.SetChildIndex(this.chkGegenzeichnen, 0);
            this.Controls.SetChildIndex(this.lblZusatzwerte, 0);
            this.Controls.SetChildIndex(this.chkAlsDekursKopieren, 0);
            this.Controls.SetChildIndex(this.auswahlGruppeComboMulti1, 0);
            this.Controls.SetChildIndex(this.ucDateSelect1, 0);
            this.Controls.SetChildIndex(this.chkDone, 0);
            this.Controls.SetChildIndex(this.lblMin, 0);
            this.Controls.SetChildIndex(this.lblMedikation, 0);
            this.Controls.SetChildIndex(this.dtpZeitpunktPlan, 0);
            this.Controls.SetChildIndex(this.cbBedarfsMedikament, 0);
            this.Controls.SetChildIndex(this.lblGeplant, 0);
            this.Controls.SetChildIndex(this.txtIstDauer, 0);
            this.Controls.SetChildIndex(this.lblDauer, 0);
            this.Controls.SetChildIndex(this.dtpZeitpunkt, 0);
            this.Controls.SetChildIndex(this.labMassnahme, 0);
            this.Controls.SetChildIndex(this.lblZeitpunktDerDurchführung, 0);
            this.Controls.SetChildIndex(this.cbMassnahme, 0);
            this.Controls.SetChildIndex(this.lblAnmerkung, 0);
            this.Controls.SetChildIndex(this.cbImportant, 0);
            this.Controls.SetChildIndex(this.lblWichtigFür, 0);
            this.Controls.SetChildIndex(this.ucZusatzWert1, 0);
            this.Controls.SetChildIndex(this.panelTxtControl, 0);
            this.Controls.SetChildIndex(this.panelBeschreibungTXTEditor, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImportant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMassnahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpZeitpunkt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBedarfsMedikament)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlsDekursKopieren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGegenzeichnen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeschreibungLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpZeitpunktPlan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        //----------------------------------------------------------------------------
        /// <summary>
        /// vererbten Controls die Möglichkeit geben sich zu initialisieren
        /// </summary>
        //----------------------------------------------------------------------------
        protected override void InitSubComponent()
        {
            if (!ENV.AppRunning)
                return;
            base.InitSubComponent();
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Änderung der Uhrzeit zulassen
        /// </summary>
        //----------------------------------------------------------------------------
        public bool EnableEditTime
        {
            get { return dtpZeitpunkt.MaskInput != "dd.mm.yyyy"; }
            set { dtpZeitpunkt.MaskInput = "dd.mm.yyyy" + (value ? " hh:mm" : ""); }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten nach GUI übertragen
        /// </summary>
        //----------------------------------------------------------------------------
        public override void UpdateGUI()
        {
            base.UpdateGUI();
            dtpZeitpunktPlan.Value = Eintrag.Zeitpunkt;
        }

        private void ucPflegeEintragEx_Load(object sender, EventArgs e)
        {

        }

        private void chkDone_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ucDateSelect1_delRefresh(object val)
        {
            this.dtpZeitpunkt.DateTime = (DateTime)val;
        }

        private void ucDateSelect1_Load(object sender, EventArgs e)
        {

        }

        public void PrepareForEdit3()
        {
            this.ucDateSelect1.Enabled = true;
            base.PrepareForEdit2();
        }

        private void dtpZeitpunkt_ValueChanged(object sender, EventArgs e)
        {

            if (ENV.ToleranzIntervall < 0)      //Zeitpunkt vor dem Toleranzintervall einfärben
            {
                if (dtpZeitpunkt.DateTime.AddHours(Math.Abs(ENV.ToleranzIntervall)) < DateTime.Now)
                {
                    dtpZeitpunkt.Appearance.ForeColor = Color.Red;
                    dtpZeitpunkt.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                }
                else
                {
                    dtpZeitpunkt.Appearance.ResetForeColor();
                    dtpZeitpunkt.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                }
            }

            if (ENV.ToleranzIntervall > 0)      //Zeitpunkt wurde ggf. auf jetzt gesetzt, wenn Toleranzintervall überschritten wurde
            {
                if (Eintrag.Zeitpunkt.AddHours(Math.Abs(ENV.ToleranzIntervall)) < DateTime.Now)
                {
                    dtpZeitpunkt.Appearance.ForeColor = Color.Blue;
                    dtpZeitpunkt.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                }
                else
                {
                    dtpZeitpunkt.Appearance.ResetForeColor();
                    dtpZeitpunkt.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                }
            }

        }

    }
}

