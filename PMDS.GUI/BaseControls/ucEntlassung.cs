//----------------------------------------------------------------------------
/// <summary>
///	ucEntlassung.cs
/// Erstellt am:	13.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;



namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zur Bearbeitung einer Entlassung
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucEntlassung : QS2.Desktop.ControlManagment.BaseControl, IReadOnly
	{
		private Aufenthalt _aufenthalt;

		private System.Windows.Forms.ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseLabel lblNachgenendeBehandlung;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtBemerkung;
		private QS2.Desktop.ControlManagment.BaseLabel lblBemerkung;
        private QS2.Desktop.ControlManagment.BaseLabel lblEntlassungsdatum;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpDatum;
        public BaseControls.EinrichtungsCombo cbEinrichtung;
        public QS2.Desktop.ControlManagment.BaseCheckBox chkVerstorben;
        private QS2.Desktop.ControlManagment.BaseLabel lblTodeszeitpunkt;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor uceTodeszeitpunkt;
        private IContainer components;






		//----------------------------------------------------------------------------
		/// <summary>
		/// Default Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucEntlassung()
		{
			InitializeComponent();
			Aufenthalt = new Aufenthalt();
			RequiredFields();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Initialisierung der GUI
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucVersetzung_Load(object sender, System.EventArgs e)
		{
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dispose
		/// </summary>
		//----------------------------------------------------------------------------
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton3 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton4 = new Infragistics.Win.UltraWinEditors.EditorButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblNachgenendeBehandlung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtBemerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblBemerkung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblEntlassungsdatum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpDatum = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.chkVerstorben = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblTodeszeitpunkt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.uceTodeszeitpunkt = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.cbEinrichtung = new PMDS.GUI.BaseControls.EinrichtungsCombo();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVerstorben)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceTodeszeitpunkt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEinrichtung)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblNachgenendeBehandlung
            // 
            this.lblNachgenendeBehandlung.AutoSize = true;
            this.lblNachgenendeBehandlung.Location = new System.Drawing.Point(249, 35);
            this.lblNachgenendeBehandlung.Name = "lblNachgenendeBehandlung";
            this.lblNachgenendeBehandlung.Size = new System.Drawing.Size(101, 14);
            this.lblNachgenendeBehandlung.TabIndex = 2;
            this.lblNachgenendeBehandlung.Text = "Nachgehende Beh.";
            // 
            // txtBemerkung
            // 
            this.txtBemerkung.AcceptsReturn = true;
            this.txtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BackColor2 = System.Drawing.Color.White;
            appearance4.BackColorDisabled = System.Drawing.Color.White;
            appearance4.BackColorDisabled2 = System.Drawing.Color.White;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtBemerkung.Appearance = appearance4;
            this.txtBemerkung.BackColor = System.Drawing.Color.White;
            this.txtBemerkung.Location = new System.Drawing.Point(112, 56);
            this.txtBemerkung.Multiline = true;
            this.txtBemerkung.Name = "txtBemerkung";
            this.txtBemerkung.Size = new System.Drawing.Size(526, 232);
            this.txtBemerkung.TabIndex = 10;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.AutoSize = true;
            this.lblBemerkung.Location = new System.Drawing.Point(8, 59);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(62, 14);
            this.lblBemerkung.TabIndex = 4;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // lblEntlassungsdatum
            // 
            this.lblEntlassungsdatum.AutoSize = true;
            this.lblEntlassungsdatum.Location = new System.Drawing.Point(8, 11);
            this.lblEntlassungsdatum.Name = "lblEntlassungsdatum";
            this.lblEntlassungsdatum.Size = new System.Drawing.Size(97, 14);
            this.lblEntlassungsdatum.TabIndex = 0;
            this.lblEntlassungsdatum.Text = "Entlassungsdatum";
            // 
            // dtpDatum
            // 
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BackColor2 = System.Drawing.Color.White;
            appearance5.BackColorDisabled = System.Drawing.Color.White;
            appearance5.BackColorDisabled2 = System.Drawing.Color.White;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.dtpDatum.Appearance = appearance5;
            this.dtpDatum.BackColor = System.Drawing.Color.White;
            this.dtpDatum.FormatString = "";
            this.dtpDatum.Location = new System.Drawing.Point(112, 8);
            this.dtpDatum.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.ownFormat = "";
            this.dtpDatum.ownMaskInput = "";
            this.dtpDatum.ReadOnly = true;
            this.dtpDatum.Size = new System.Drawing.Size(125, 21);
            this.dtpDatum.TabIndex = 1;
            // 
            // chkVerstorben
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.chkVerstorben.Appearance = appearance3;
            this.chkVerstorben.BackColor = System.Drawing.Color.Transparent;
            this.chkVerstorben.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkVerstorben.Location = new System.Drawing.Point(113, 32);
            this.chkVerstorben.Name = "chkVerstorben";
            this.chkVerstorben.Size = new System.Drawing.Size(114, 20);
            this.chkVerstorben.TabIndex = 2;
            this.chkVerstorben.Text = "Verstorben";
            this.chkVerstorben.CheckedChanged += new System.EventHandler(this.chkVerstorben_CheckedChanged);
            // 
            // lblTodeszeitpunkt
            // 
            this.lblTodeszeitpunkt.AutoSize = true;
            this.lblTodeszeitpunkt.Location = new System.Drawing.Point(249, 35);
            this.lblTodeszeitpunkt.Name = "lblTodeszeitpunkt";
            this.lblTodeszeitpunkt.Size = new System.Drawing.Size(81, 14);
            this.lblTodeszeitpunkt.TabIndex = 11;
            this.lblTodeszeitpunkt.Text = "Todeszeitpunkt";
            // 
            // uceTodeszeitpunkt
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.White;
            appearance1.BackColorDisabled = System.Drawing.Color.White;
            appearance1.BackColorDisabled2 = System.Drawing.Color.White;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            this.uceTodeszeitpunkt.Appearance = appearance1;
            this.uceTodeszeitpunkt.BackColor = System.Drawing.Color.White;
            this.uceTodeszeitpunkt.FormatString = "";
            this.uceTodeszeitpunkt.Location = new System.Drawing.Point(333, 32);
            this.uceTodeszeitpunkt.MaskInput = "dd.mm.yyyy hh:mm";
            this.uceTodeszeitpunkt.Name = "uceTodeszeitpunkt";
            this.uceTodeszeitpunkt.ownFormat = "";
            this.uceTodeszeitpunkt.ownMaskInput = "";
            this.uceTodeszeitpunkt.Size = new System.Drawing.Size(128, 21);
            this.uceTodeszeitpunkt.TabIndex = 4;
            // 
            // cbEinrichtung
            // 
            this.cbEinrichtung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColor2 = System.Drawing.Color.White;
            appearance2.BackColorDisabled = System.Drawing.Color.White;
            appearance2.BackColorDisabled2 = System.Drawing.Color.White;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.cbEinrichtung.Appearance = appearance2;
            this.cbEinrichtung.BackColor = System.Drawing.Color.White;
            editorButton1.Text = "+";
            editorButton1.Visible = false;
            editorButton2.Text = "+";
            editorButton2.Visible = false;
            editorButton3.Text = "+";
            editorButton3.Visible = false;
            editorButton4.Text = "+";
            editorButton4.Visible = false;
            this.cbEinrichtung.ButtonsRight.Add(editorButton1);
            this.cbEinrichtung.ButtonsRight.Add(editorButton2);
            this.cbEinrichtung.ButtonsRight.Add(editorButton3);
            this.cbEinrichtung.ButtonsRight.Add(editorButton4);
            this.cbEinrichtung.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbEinrichtung.Location = new System.Drawing.Point(349, 32);
            this.cbEinrichtung.Name = "cbEinrichtung";
            this.cbEinrichtung.NotKrankenkasse = true;
            this.cbEinrichtung.ReadOnly = true;
            this.cbEinrichtung.Size = new System.Drawing.Size(287, 21);
            this.cbEinrichtung.TabIndex = 3;
            // 
            // ucEntlassung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.uceTodeszeitpunkt);
            this.Controls.Add(this.cbEinrichtung);
            this.Controls.Add(this.chkVerstorben);
            this.Controls.Add(this.txtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblEntlassungsdatum);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.lblTodeszeitpunkt);
            this.Controls.Add(this.lblNachgenendeBehandlung);
            this.Name = "ucEntlassung";
            this.Size = new System.Drawing.Size(646, 296);
            this.Load += new System.EventHandler(this.ucVersetzung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVerstorben)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceTodeszeitpunkt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEinrichtung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Aufenthalt setzen/auslesen
		/// </summary>
		//----------------------------------------------------------------------------
		public Aufenthalt Aufenthalt
		{
			get	
			{	
				return _aufenthalt;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Aufenthalt");

				_aufenthalt = value;
				UpdateGUI();
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten nach GUI �bertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateGUI()
		{
			dtpDatum.Value		= Aufenthalt.Entlassungszeitpunkt;
			txtBemerkung.Text	= Aufenthalt.Entlassungsbemerkung;
			cbEinrichtung.Value	= Aufenthalt.IDEinrichtung_Entlassung;
            this.setUI();

            //dtpDatum.ReadOnly = true;
            //txtBemerkung.ReadOnly = true;
            //cbEinrichtung.ReadOnly = true;

            //dtpDatum.Appearance.BackColor = System.Drawing.Color.White;
            //txtBemerkung.Appearance.BackColor = System.Drawing.Color.White;
            //cbEinrichtung.Appearance.BackColor = System.Drawing.Color.White;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten �bertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdateDATA()
		{
			Aufenthalt.Entlassungszeitpunkt		= (DateTime)dtpDatum.Value;
			Aufenthalt.Entlassungsbemerkung		= txtBemerkung.Text;
            if (cbEinrichtung.Value != null)
            {
                Aufenthalt.IDEinrichtung_Entlassung = (Guid)cbEinrichtung.Value;
            }
            else
            {
                Aufenthalt.IDEinrichtung_Entlassung = System.Guid.Empty;
            }

            Aufenthalt.Verlauf.Datum			= (DateTime)dtpDatum.Value;
			Aufenthalt.Verlauf.Bemerkung		= txtBemerkung.Text;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Ben�tigte Felder setzen
		/// </summary>
		//----------------------------------------------------------------------------
		protected void RequiredFields()
		{
			GuiUtil.ValidateRequired(dtpDatum);
			GuiUtil.ValidateRequired(cbEinrichtung);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Felder validieren
		/// </summary>
		//----------------------------------------------------------------------------
		public bool ValidateFields()
		{
			bool bError = false;
			bool bInfo = true;

			// dtpDatum
			GuiUtil.ValidateField(dtpDatum, (dtpDatum.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            if (this.chkVerstorben.Checked)
            {
                if (this.uceTodeszeitpunkt.Value == null)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Todeszeitpunkt: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }
                if (this.uceTodeszeitpunkt.Value != null)
                {
                    if (this.uceTodeszeitpunkt.DateTime > DateTime.Now)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Todeszeitpunkt darf nicht in der zukunft liegen!", "", MessageBoxButtons.OK);
                        return false;
                    }
                }
            }
            else
            {
                // cbEinrichtung
                GuiUtil.ValidateField(cbEinrichtung, (cbEinrichtung.Text.Length > 0),
                    ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
            }

            return !bError;
		}

		#region IReadOnly Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// ReadOnly
		/// </summary>
		//----------------------------------------------------------------------------
		public bool ReadOnly
		{
			get
			{
				return dtpDatum.ReadOnly;
			}
			set
			{
				dtpDatum.ReadOnly = value;
				cbEinrichtung.ReadOnly = value;
				txtBemerkung.ReadOnly = value;
			}
		}

        #endregion

        private void chkVerstorben_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkVerstorben.Focused)
                {
                    this.setUI();
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
        public void setUI()
        {
            try
            {
                if (this.chkVerstorben.Checked)
                {
                    this.lblTodeszeitpunkt.Visible = true;
                    this.uceTodeszeitpunkt.Visible = true;

                    this.lblNachgenendeBehandlung.Visible = false;
                    this.cbEinrichtung.Visible = false;
                }
                else
                {
                    this.lblTodeszeitpunkt.Visible = false;
                    this.uceTodeszeitpunkt.Visible = false;

                    this.lblNachgenendeBehandlung.Visible = true;
                    this.cbEinrichtung.Visible = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucEntlassung.setUI: " + ex.ToString());
            }
        }

    }
}
