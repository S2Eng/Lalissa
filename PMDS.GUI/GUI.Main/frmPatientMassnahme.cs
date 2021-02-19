//----------------------------------------------------------------------------
/// <summary>
///	frmPatientMassnahme.cs
/// Erstellt am:	16.11.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using PMDS.BusinessLogic;
using PMDS.Global;
using System.Linq;

namespace PMDS.GUI
{


	public class frmPatientMassnahme : QS2.Desktop.ControlManagment.baseForm
    {
        private QS2.Desktop.ControlManagment.BaseLabel labInfo;
        public ucPflegeEintrag ucPflegeEintrag1;
        private QS2.Desktop.ControlManagment.BaseButton btnOK2;
        private QS2.Desktop.ControlManagment.BaseButton btnCancel2;
		private System.ComponentModel.IContainer components;
        public bool abort = true;
        public QS2.Desktop.ControlManagment.BaseButton btnKlientenMehrfachauswahl;
        private QS2.Desktop.ControlManagment.BaseButton btnSonderterminErstellen2;
        public System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteSelected = new System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes>();






        public frmPatientMassnahme(Patient pat, bool bMedikation , Nullable<Guid> IDEintragFromQuickbutton)
		{
			InitializeComponent();

            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            if (!ENV.AppRunning)
                return;

            if(bMedikation)
            {
                labInfo.Text = string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung erfassen für {0}"), pat.FullInfo);
               
                //Wichtig für Arzt standardmäßig auswählen 
                ucPflegeEintrag1._IsMedikation = bMedikation;
            }
            else 
                labInfo.Text = string.Format(labInfo.Text, pat.FullInfo);
			ucPflegeEintrag1.Eintrag    = pat.NewMassnahme();
            ucPflegeEintrag1.Medikation = bMedikation;
            ucPflegeEintrag1.IDEintragFromQuickbutton = IDEintragFromQuickbutton;
              
            this.btnOK2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
            this.btnCancel2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abbrechen, 32, 32);
		}


		public frmPatientMassnahme()
		{
			InitializeComponent();

            this.btnOK2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
            this.btnCancel2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abbrechen, 32, 32);


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
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnOK2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnCancel2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.ucPflegeEintrag1 = new PMDS.GUI.ucPflegeEintrag();
            this.btnKlientenMehrfachauswahl = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnSonderterminErstellen2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.SuspendLayout();
            // 
            // labInfo
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.labInfo.Appearance = appearance1;
            this.labInfo.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(0, 0);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(1134, 48);
            this.labInfo.TabIndex = 0;
            this.labInfo.Text = "Ungeplante Maßnahme für {0}";
            // 
            // btnOK2
            // 
            this.btnOK2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK2.Appearance = appearance2;
            this.btnOK2.AutoWorkLayout = false;
            this.btnOK2.IsStandardControl = false;
            this.btnOK2.Location = new System.Drawing.Point(1075, 623);
            this.btnOK2.Name = "btnOK2";
            this.btnOK2.Size = new System.Drawing.Size(48, 34);
            this.btnOK2.TabIndex = 15;
            this.btnOK2.Click += new System.EventHandler(this.btnOK2_Click);
            // 
            // btnCancel2
            // 
            this.btnCancel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel2.AutoWorkLayout = false;
            this.btnCancel2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel2.IsStandardControl = false;
            this.btnCancel2.Location = new System.Drawing.Point(986, 623);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(88, 34);
            this.btnCancel2.TabIndex = 14;
            this.btnCancel2.Text = "Abbrechen";
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // ucPflegeEintrag1
            // 
            this.ucPflegeEintrag1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPflegeEintrag1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucPflegeEintrag1.Location = new System.Drawing.Point(0, 48);
            this.ucPflegeEintrag1.Margin = new System.Windows.Forms.Padding(4);
            this.ucPflegeEintrag1.Medikation = false;
            this.ucPflegeEintrag1.Name = "ucPflegeEintrag1";
            this.ucPflegeEintrag1.ReadOnly = false;
            this.ucPflegeEintrag1.RM_OPTIONAL = false;
            this.ucPflegeEintrag1.Size = new System.Drawing.Size(1128, 569);
            this.ucPflegeEintrag1.TabIndex = 1;
            // 
            // btnKlientenMehrfachauswahl
            // 
            this.btnKlientenMehrfachauswahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnKlientenMehrfachauswahl.Appearance = appearance3;
            this.btnKlientenMehrfachauswahl.AutoWorkLayout = false;
            this.btnKlientenMehrfachauswahl.IsStandardControl = false;
            this.btnKlientenMehrfachauswahl.Location = new System.Drawing.Point(113, 623);
            this.btnKlientenMehrfachauswahl.Name = "btnKlientenMehrfachauswahl";
            this.btnKlientenMehrfachauswahl.Size = new System.Drawing.Size(127, 34);
            this.btnKlientenMehrfachauswahl.TabIndex = 16;
            this.btnKlientenMehrfachauswahl.Text = "Klienten Mehrfachauswahl";
            this.btnKlientenMehrfachauswahl.UseAppStyling = false;
            this.btnKlientenMehrfachauswahl.Click += new System.EventHandler(this.btnKlientenMehrfachauswahl_Click);
            // 
            // btnSonderterminErstellen2
            // 
            this.btnSonderterminErstellen2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSonderterminErstellen2.Appearance = appearance4;
            this.btnSonderterminErstellen2.AutoWorkLayout = false;
            this.btnSonderterminErstellen2.IsStandardControl = false;
            this.btnSonderterminErstellen2.Location = new System.Drawing.Point(5, 624);
            this.btnSonderterminErstellen2.Name = "btnSonderterminErstellen2";
            this.btnSonderterminErstellen2.Size = new System.Drawing.Size(108, 33);
            this.btnSonderterminErstellen2.TabIndex = 109;
            this.btnSonderterminErstellen2.Text = "Termin erstellen";
            this.btnSonderterminErstellen2.Click += new System.EventHandler(this.btnSonderterminErstellen2_Click);
            // 
            // frmPatientMassnahme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel2;
            this.ClientSize = new System.Drawing.Size(1134, 661);
            this.Controls.Add(this.btnSonderterminErstellen2);
            this.Controls.Add(this.btnKlientenMehrfachauswahl);
            this.Controls.Add(this.btnOK2);
            this.Controls.Add(this.btnCancel2);
            this.Controls.Add(this.ucPflegeEintrag1);
            this.Controls.Add(this.labInfo);
            this.MinimumSize = new System.Drawing.Size(1150, 700);
            this.Name = "frmPatientMassnahme";
            this.Text = "Ungeplante Maßnahme ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmPatientMassnahme_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		}


        private void frmPatientMassnahme_Load(object sender, EventArgs e)
        {
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.Close();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnOK2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!PMDS.Global.db.ERSystem.PMDSBusinessUI.checkTxtRegex(this.ucPflegeEintrag1.contTXTFieldBeschreibung.TXTControlField.Text, true))
                {
                    return;
                }

                if (!ucPflegeEintrag1.ValidateFields())
                    return;

                ucPflegeEintrag1.UpdateDATA();
                ucPflegeEintrag1.Write();

                Guid IDGruppe = System.Guid.NewGuid();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    IQueryable<PMDS.db.Entities.PflegeEintrag> lstPEorig = db.PflegeEintrag.Where(pe => pe.ID == this.ucPflegeEintrag1.Eintrag.ID);
                    PMDS.db.Entities.PflegeEintrag rPEeOriginal = lstPEorig.First();
                    rPEeOriginal.IDGruppe = IDGruppe;
                    db.SaveChanges();
                }

                System.Collections.Generic.List<Guid> lstPEToCopy = new System.Collections.Generic.List<Guid>();
                this.ucPflegeEintrag1.auswahlGruppeComboMulti1.AddCC2(this.ucPflegeEintrag1.Eintrag.ID, this.ucPflegeEintrag1.IsNew,
                                                                        this.ucPflegeEintrag1.chkAlsDekursKopieren.Checked, ucPflegeEintrag1.Eintrag.AbzeichnenJN, ucPflegeEintrag1.Eintrag.IDWichtig,
                                                                        ref lstPEToCopy, false, ref IDGruppe);

                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                if (this.lstPatienteSelected.Count > 0)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                    {
                        PMDSBusiness1.CopyAndAddPE(this.ucPflegeEintrag1.Eintrag.ID, ref this.lstPatienteSelected, db, ref IDGruppe);
                    }
                }
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    foreach (Guid IDPE in lstPEToCopy)
                    {
                        PMDSBusiness1.CopyAndAddPE(IDPE, ref this.lstPatienteSelected, db, ref IDGruppe);
                    }
                }

                //using (PMDS.db.Entities.ERModellPMDSEntities dbZW = PMDS.DB.PMDSBusiness.getDBContext())
                //{
                //    PMDSBusiness1.copyUpdateZusatzwertePEIDGruppe(this.ucPflegeEintrag1.Eintrag.ID, dbZW);
                //}

                this.abort = false;
                this.Close();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        public void openMehrfachselektionPatients()
        {
            try
            {
                PMDS.GUI.GUI.Main.frmPatientenmehrfachauswahl frmPatientenmehrfachauswahl1 = new GUI.Main.frmPatientenmehrfachauswahl();
                frmPatientenmehrfachauswahl1.lstPatienteSelected = this.lstPatienteSelected;
                frmPatientenmehrfachauswahl1.initControl();
                frmPatientenmehrfachauswahl1.ShowDialog(this);
                if (!frmPatientenmehrfachauswahl1.abort)
                {
                    this.lstPatienteSelected = frmPatientenmehrfachauswahl1.lstPatienteSelected;
                    this.btnKlientenMehrfachauswahl.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Klienten Mehrfachauswahl") + " (" + this.lstPatienteSelected.Count.ToString() + ")";
                    if (this.lstPatienteSelected.Count > 0)
                    {
                        this.btnKlientenMehrfachauswahl.Appearance.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.btnKlientenMehrfachauswahl.Appearance.ForeColor = Color.Black;
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void btnKlientenMehrfachauswahl_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.openMehrfachselektionPatients();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnSonderterminErstellen2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.SonderterminErstellen();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void SonderterminErstellen()
        {
            try
            {
                ucSiteMapTermine ucSiteMap = null;
                GuiAction.InsertTermin(ucPflegeEintrag1.Eintrag.IDAufenthalt, false, (Form)GuiWorkflow.mainWindow, ucSiteMap, ucPflegeEintrag1.Eintrag.ID, null);

            }
            catch (Exception ex)
            {
                throw new Exception("SonderterminErstellen: " + ex.ToString());
            }
        }

    }
}
