//----------------------------------------------------------------------------
/// <summary>
///	ucVersetzung.cs
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
using PMDS.Global.db.Patient;
using PMDS.DB;
using System.Linq;

namespace PMDS.GUI
{


	public class ucVersetzung : QS2.Desktop.ControlManagment.BaseControl
	{
		private Aufenthalt _aufenthalt;
        public dsKlinik.KlinikRow rKlinik = null;
        public PMDSBusiness b = new PMDSBusiness();



        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseLabel lblVerlegungNach;
        public QS2.Desktop.ControlManagment.BaseTextEditor txtBemerkung;
		private QS2.Desktop.ControlManagment.BaseLabel lblBemerkung;
        private QS2.Desktop.ControlManagment.BaseLabel lblVerlegungsdatum;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpVersetzung;
        public BaseControls.AbteilungsCombo cbAbteilung;
        private QS2.Desktop.ControlManagment.BaseLabel lblBereich;
        public BaseControls.BereichsCombo cboBereich;
        private IContainer components;









		public ucVersetzung()
		{
			InitializeComponent();
			Aufenthalt = new Aufenthalt();
			RequiredFields();
		}



        public void loadBereich()
        {
            try
            {
                if (this.cbAbteilung.Value != null)
                {
                    this.loadBereich((Guid)this.cbAbteilung.Value);
                }
                else
                {
                    this.loadBereich(null);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("frmVersetzung.loadBereich: " + ex.ToString());
            }
        }
        public void loadBereich(Nullable<Guid> IDAbteilung)
        {
            try
            {
                this.cboBereich.Items.Clear();
                if (IDAbteilung != null)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.Bereich> tBereiche = this.b.loadBereichForAbteilung((Guid)IDAbteilung, db);
                        System.Linq.IQueryable<PMDS.db.Entities.BereichBenutzer> tBereichBenutzer = this.b.getBereichBenutzer(ENV.USERID, db);

                        foreach (PMDS.db.Entities.Bereich rBereich in tBereiche)
                        {
                            var tBereichRight = (from bb in tBereichBenutzer
                                                 where bb.IDBereich == rBereich.ID
                                                 select new
                                                 {
                                                     IDBereich = bb.IDBereich
                                                 });

                            if (tBereichRight.Count() > 0)
                            {
                                Infragistics.Win.ValueListItem iotm = this.cboBereich.Items.Add(rBereich.ID, rBereich.Bezeichnung.Trim());
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmVersetzung.initControl: " + ex.ToString());
            }
        }


        private void ucVersetzung_Load(object sender, System.EventArgs e)
		{
		}

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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblVerlegungNach = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtBemerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblBemerkung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblVerlegungsdatum = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpVersetzung = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblBereich = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboBereich = new PMDS.GUI.BaseControls.BereichsCombo();
            this.cbAbteilung = new PMDS.GUI.BaseControls.AbteilungsCombo();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpVersetzung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAbteilung)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblVerlegungNach
            // 
            this.lblVerlegungNach.AutoSize = true;
            this.lblVerlegungNach.Location = new System.Drawing.Point(8, 36);
            this.lblVerlegungNach.Name = "lblVerlegungNach";
            this.lblVerlegungNach.Size = new System.Drawing.Size(83, 14);
            this.lblVerlegungNach.TabIndex = 2;
            this.lblVerlegungNach.Text = "Verlegung nach";
            // 
            // txtBemerkung
            // 
            this.txtBemerkung.AcceptsReturn = true;
            this.txtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBemerkung.Location = new System.Drawing.Point(112, 87);
            this.txtBemerkung.Multiline = true;
            this.txtBemerkung.Name = "txtBemerkung";
            this.txtBemerkung.Size = new System.Drawing.Size(392, 192);
            this.txtBemerkung.TabIndex = 5;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.AutoSize = true;
            this.lblBemerkung.Location = new System.Drawing.Point(8, 90);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(62, 14);
            this.lblBemerkung.TabIndex = 4;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // lblVerlegungsdatum
            // 
            this.lblVerlegungsdatum.AutoSize = true;
            this.lblVerlegungsdatum.Location = new System.Drawing.Point(8, 11);
            this.lblVerlegungsdatum.Name = "lblVerlegungsdatum";
            this.lblVerlegungsdatum.Size = new System.Drawing.Size(93, 14);
            this.lblVerlegungsdatum.TabIndex = 0;
            this.lblVerlegungsdatum.Text = "Verlegungsdatum";
            // 
            // dtpVersetzung
            // 
            this.dtpVersetzung.FormatString = "";
            this.dtpVersetzung.Location = new System.Drawing.Point(112, 8);
            this.dtpVersetzung.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpVersetzung.Name = "dtpVersetzung";
            this.dtpVersetzung.Size = new System.Drawing.Size(128, 21);
            this.dtpVersetzung.TabIndex = 1;
            // 
            // lblBereich
            // 
            this.lblBereich.AutoSize = true;
            this.lblBereich.Location = new System.Drawing.Point(8, 60);
            this.lblBereich.Name = "lblBereich";
            this.lblBereich.Size = new System.Drawing.Size(43, 14);
            this.lblBereich.TabIndex = 6;
            this.lblBereich.Text = "Bereich";
            // 
            // cboBereich
            // 
            this.cboBereich.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboBereich.Location = new System.Drawing.Point(112, 59);
            this.cboBereich.Name = "cboBereich";
            this.cboBereich.Size = new System.Drawing.Size(205, 21);
            this.cboBereich.TabIndex = 7;
            // 
            // cbAbteilung
            // 
            this.cbAbteilung.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbAbteilung.ENVAbteilung = false;
            this.cbAbteilung.Location = new System.Drawing.Point(112, 33);
            this.cbAbteilung.Name = "cbAbteilung";
            this.cbAbteilung.rKlinik = null;
            this.cbAbteilung.Size = new System.Drawing.Size(205, 21);
            this.cbAbteilung.TabIndex = 3;
            this.cbAbteilung.ValueChanged += new System.EventHandler(this.cbAbteilung_ValueChanged);
            // 
            // ucVersetzung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.cboBereich);
            this.Controls.Add(this.lblBereich);
            this.Controls.Add(this.cbAbteilung);
            this.Controls.Add(this.lblVerlegungNach);
            this.Controls.Add(this.txtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblVerlegungsdatum);
            this.Controls.Add(this.dtpVersetzung);
            this.Name = "ucVersetzung";
            this.Size = new System.Drawing.Size(512, 287);
            this.Load += new System.EventHandler(this.ucVersetzung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpVersetzung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAbteilung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion



		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        public Guid IDAbteilungNach
        {
            get
            {
                return (Guid)cbAbteilung.Value;
            }
        }

		public void UpdateGUI()
		{
            this.cbAbteilung.rKlinik = this.rKlinik;
            this.cbAbteilung.RefreshList();
			dtpVersetzung.Value	= Aufenthalt.Verlauf.Datum;
			cbAbteilung.Value	= Aufenthalt.Verlauf.IDAbteilung_Nach;
			txtBemerkung.Text	= Aufenthalt.Verlauf.Bemerkung;

            this.loadBereich((Nullable<Guid>)cbAbteilung.Value);
        }

		public void UpdateDATA()
		{
			Aufenthalt.Verlauf.Datum			= (DateTime)dtpVersetzung.Value;
			Aufenthalt.Verlauf.IDAbteilung_Nach	= (Guid)cbAbteilung.Value;
            Aufenthalt.Verlauf.IDBereich = (Guid)cboBereich.Value;
            Aufenthalt.Verlauf.Bemerkung		= txtBemerkung.Text;

            //Alle Bezugspersonen löschen
            DataTable table = Aufenthalt.Verlauf.BenutzerBezug;
            if (table != null)
            {
                // get checkMarkers
                foreach (DataRow r in table.Rows)
                {
                    r.Delete();
                }
            }            
		}

		protected void RequiredFields()
		{
			GuiUtil.ValidateRequired(dtpVersetzung);
			GuiUtil.ValidateRequired(cbAbteilung);
		}

		public bool ValidateFields()
		{
			bool bError = false;
			bool bInfo = true;

			// dtpVersetzung
			GuiUtil.ValidateField(dtpVersetzung, (dtpVersetzung.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

			// cbAbteilung
			GuiUtil.ValidateField(cbAbteilung, (cbAbteilung.Text.Length > 0),
				ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            // cboBereich
            GuiUtil.ValidateField(cboBereich, (cboBereich.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            return !bError;
		}

        private void cbAbteilung_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbAbteilung.Focused)
                {
                    this.loadBereich();
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

    }
}
