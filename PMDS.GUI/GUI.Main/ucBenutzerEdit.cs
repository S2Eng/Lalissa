//----------------------------------------------------------------------------
/// <summary>
///	ucBenutzerEdit.cs
/// Erstellt am:	22.9.2004
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
using PMDS.GUI.Engines;
using PMDS.Print;
using PMDS.Global.db.Patient;
using PMDS.Global.db.Global;
using System.Collections.Generic;
using PMDS.DB;
using System.Linq;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Control zum Bearbeiten der Benutzer-Daten.
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucBenutzerEdit : QS2.Desktop.ControlManagment.BaseControl, IClose
	{
		public EngineVerwaltung _verwaltung;
        public ucButton btnAdd;
        public QS2.Desktop.ControlManagment.BaseComboEditor cbBenutzer;
        private QS2.Desktop.ControlManagment.BaseLabel lblBenutzer;
        public ucBenutzer ucBenutzer2;
        private dsGUIDListe dsGUIDListe1;
		private System.ComponentModel.IContainer components;
        private QS2.Desktop.ControlManagment.BasePanel panelUsers;
        public QS2.Desktop.ControlManagment.BaseButton btnSpeichern2;
        public QS2.Desktop.ControlManagment.BaseButton btnUndo2;
        public QS2.Desktop.ControlManagment.BaseButton btnDel3;
        public bool _OnlyAbteilungBereiche = false;
        public QS2.Desktop.ControlManagment.BaseButton btnCheckUserCanSign;
        public bool IsVisibleInitialized = false;







		public ucBenutzerEdit()
		{
			InitializeComponent();
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBenutzerEdit));
            this.cbBenutzer = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.lblBenutzer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelUsers = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnSpeichern2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnUndo2 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDel3 = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnCheckUserCanSign = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.dsGUIDListe1 = new PMDS.Global.db.Global.dsGUIDListe();
            ((System.ComponentModel.ISupportInitialize)(this.cbBenutzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGUIDListe1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbBenutzer
            // 
            this.cbBenutzer.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cbBenutzer.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.cbBenutzer.Location = new System.Drawing.Point(88, 5);
            this.cbBenutzer.Name = "cbBenutzer";
            this.cbBenutzer.Size = new System.Drawing.Size(351, 24);
            this.cbBenutzer.TabIndex = 1;
            // 
            // lblBenutzer
            // 
            this.lblBenutzer.AutoSize = true;
            this.lblBenutzer.Location = new System.Drawing.Point(16, 8);
            this.lblBenutzer.Name = "lblBenutzer";
            this.lblBenutzer.Size = new System.Drawing.Size(64, 17);
            this.lblBenutzer.TabIndex = 0;
            this.lblBenutzer.Text = "Benutzer:";
            // 
            // panelUsers
            // 
            this.panelUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUsers.BackColor = System.Drawing.Color.LightGray;
            this.panelUsers.Location = new System.Drawing.Point(8, 35);
            this.panelUsers.Name = "panelUsers";
            this.panelUsers.Size = new System.Drawing.Size(864, 485);
            this.panelUsers.TabIndex = 12;
            // 
            // btnSpeichern2
            // 
            this.btnSpeichern2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnSpeichern2.Appearance = appearance1;
            this.btnSpeichern2.AutoWorkLayout = false;
            this.btnSpeichern2.Enabled = false;
            this.btnSpeichern2.IsStandardControl = false;
            this.btnSpeichern2.Location = new System.Drawing.Point(776, 526);
            this.btnSpeichern2.Name = "btnSpeichern2";
            this.btnSpeichern2.Size = new System.Drawing.Size(96, 32);
            this.btnSpeichern2.TabIndex = 102;
            this.btnSpeichern2.Text = "Speichern";
            this.btnSpeichern2.Click += new System.EventHandler(this.btnSpeichern2_Click);
            // 
            // btnUndo2
            // 
            this.btnUndo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnUndo2.Appearance = appearance2;
            this.btnUndo2.AutoWorkLayout = false;
            this.btnUndo2.Enabled = false;
            this.btnUndo2.IsStandardControl = false;
            this.btnUndo2.Location = new System.Drawing.Point(656, 526);
            this.btnUndo2.Name = "btnUndo2";
            this.btnUndo2.Size = new System.Drawing.Size(114, 32);
            this.btnUndo2.TabIndex = 103;
            this.btnUndo2.Text = "Rückgängig";
            this.btnUndo2.Click += new System.EventHandler(this.btnUndo2_Click);
            // 
            // btnDel3
            // 
            this.btnDel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnDel3.Appearance = appearance3;
            this.btnDel3.AutoWorkLayout = false;
            this.btnDel3.IsStandardControl = false;
            this.btnDel3.Location = new System.Drawing.Point(112, 526);
            this.btnDel3.Name = "btnDel3";
            this.btnDel3.Size = new System.Drawing.Size(96, 32);
            this.btnDel3.TabIndex = 104;
            this.btnDel3.Text = "Entfernen";
            this.btnDel3.Click += new System.EventHandler(this.btnDel3_Click);
            // 
            // btnCheckUserCanSign
            // 
            this.btnCheckUserCanSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.btnCheckUserCanSign.Appearance = appearance4;
            this.btnCheckUserCanSign.AutoWorkLayout = false;
            this.btnCheckUserCanSign.IsStandardControl = false;
            this.btnCheckUserCanSign.Location = new System.Drawing.Point(214, 526);
            this.btnCheckUserCanSign.Name = "btnCheckUserCanSign";
            this.btnCheckUserCanSign.Size = new System.Drawing.Size(140, 32);
            this.btnCheckUserCanSign.TabIndex = 105;
            this.btnCheckUserCanSign.Text = "Darf abzeichnen ...";
            this.btnCheckUserCanSign.Click += new System.EventHandler(this.BtnCheckUserCanSign_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance5;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.ImageSize = new System.Drawing.Size(12, 12);
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(8, 526);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 32);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Hinzufügen";
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dsGUIDListe1
            // 
            this.dsGUIDListe1.DataSetName = "dsGUIDListe";
            this.dsGUIDListe1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsGUIDListe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucBenutzerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnCheckUserCanSign);
            this.Controls.Add(this.panelUsers);
            this.Controls.Add(this.lblBenutzer);
            this.Controls.Add(this.cbBenutzer);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSpeichern2);
            this.Controls.Add(this.btnUndo2);
            this.Controls.Add(this.btnDel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucBenutzerEdit";
            this.Size = new System.Drawing.Size(882, 566);
            this.Load += new System.EventHandler(this.ucBenutzerEdit_Load);
            this.VisibleChanged += new System.EventHandler(this.ucBenutzerEdit_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.cbBenutzer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGUIDListe1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		private void ucBenutzerEdit_Load(object sender, System.EventArgs e)
		{
			try
			{
                this.btnSpeichern2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnUndo2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Rückgängig, 32, 32);
                this.btnDel3.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);

                this.cbBenutzer.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;

                this.panelUsers.Controls.Clear();
                this.ucBenutzer2 = new ucBenutzer();
                this.ucBenutzer2._OnlyAbteilungBereiche = this._OnlyAbteilungBereiche;
                this.panelUsers.Controls.Add(this.ucBenutzer2);
                this.ucBenutzer2.Dock = DockStyle.Fill;
                this.ucBenutzer2.mainWindow = this;

                _verwaltung = new EngineVerwaltung(cbBenutzer, ucBenutzer2, btnAdd, null, null, null );

                foreach (Infragistics.Win.ValueListItem valList in this.cbBenutzer.Items)
                {
                    Benutzer ben2 = new Benutzer((Guid)valList.DataValue);

                    if (valList.DataValue.Equals(ENV.USERID))
                    {
                        Benutzer ben = new Benutzer(ENV.USERID);
                        this.cbBenutzer.SelectedItem = valList;
                        this.ucBenutzer2.Benutzer = ben;
                    }

                    if (ben2.AktivJN)
                    {
                        valList.Appearance.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        valList.Appearance.ForeColor = Color.DarkRed;
                    }
                }

                this.SetEditOnOff();
                if (this._OnlyAbteilungBereiche)
                {
                    this.ucBenutzer2.deactivateTabs();
                    this.btnAdd.Visible = false;
                    this.btnDel3.Visible = false;
                }

                this.btnDel3.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);
			}
			catch(Exception ex)
			{
				ENV.HandleException(ex);
			}
		}



		//----------------------------------------------------------------------------
		/// <summary>
		/// Während der Änderung kein Drucken zulassen
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnSave_EnabledChanged(object sender, System.EventArgs e)
		{

		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Beendigung möglich
		/// </summary>
		//----------------------------------------------------------------------------
		public bool CanClose
		{
			get	{	return _verwaltung.CanClose;	}
		}

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        public void SetEditOnOff()
        {
            bool bManageusers = true;   // ENV.HasRight(UserRights.ManageUserRights);

            this.btnAdd.Visible = bManageusers;
            this.btnDel3.Visible = bManageusers;
            this.btnSpeichern2.Visible = bManageusers;
        }

        private void btnDel2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Benutzer wirklich löschen?", "Benutzer löschen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PMDSBusiness1.DeleteUser(this.ucBenutzer2.Benutzer.ID);
                    //this.ucBenutzer2.re();
                    //Benutzer = new Benutzer();
                }
                    
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {

        }

        private void btnSpeichern2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!this.ucBenutzer2.ValidateFields())
                    return;

                this.ucBenutzer2.UpdateDATA();
                this.ucBenutzer2.Write();
                this.ucBenutzer2.ucRechtBenutzer1.IDBenutzer = this.ucBenutzer2.Benutzer.ID;
                this.ucBenutzer2.ucRechtBenutzer1.saveData();
                PMDS.Global.ENV.evBenutzerSMTPDatenSpeichern((System.Guid)this.ucBenutzer2.Benutzer.ID);

                this.cbBenutzer.DataSource = this._verwaltung._details.All();
                foreach (Infragistics.Win.ValueListItem valList in this.cbBenutzer.Items)
                {
                    Benutzer ben2 = new Benutzer((Guid)valList.DataValue);
                    if (ben2.AktivJN)
                    {
                        valList.Appearance.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        valList.Appearance.ForeColor = Color.DarkRed;
                    }
                }

                //Infragistics.Win.ValueListItem valList = this.mainWindow.cbBenutzer.Items.Add(obj.ID, obj.BenutzerName);
                this.cbBenutzer.Value = this.ucBenutzer2.Benutzer.ID;
                this.cbBenutzer.DisplayMember = "TEXT";
                this.cbBenutzer.ValueMember = "ID";

                this.btnSpeichern2.Enabled = false;
                this.cbBenutzer.Enabled = true;
                this.btnUndo2.Enabled = false;
                this.btnAdd.Enabled = true;
                this._verwaltung.IsEntryDirty = false;

                this.ucBenutzer2.ucBenutzerAbteilung1.Benutzer = this.ucBenutzer2.Benutzer;

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnUndo2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.ucBenutzer2.Read();
                this.btnSpeichern2.Enabled = false;
                this.btnUndo2.Enabled = false;
                this.cbBenutzer.Enabled = true;
                this.btnAdd.Enabled = true;
                this._verwaltung.IsEntryDirty = false;

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnDel3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
               
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_DELETE", this.ucBenutzer2.Benutzer.BenutzerName),
                                                                    ENV.String("VERWALTUNG.DIALOGTITLE_DELETE"),
                                                                    MessageBoxButtons.YesNo,
                                                                    MessageBoxIcon.Question, true) == DialogResult.Yes)
                {
                    this.ucBenutzer2.Delete();
                    this.ucBenutzer2.clearUI();
                    this.cbBenutzer.DataSource = this._verwaltung._details.All();
                    this.cbBenutzer.DisplayMember = "TEXT";
                    this.cbBenutzer.ValueMember = "ID";
                    this.cbBenutzer.SelectedItem = null;

                    this.btnSpeichern2.Enabled = false;
                    this.btnUndo2.Enabled = false;
                    this.cbBenutzer.Enabled = true;
                    this.btnAdd.Enabled = true;

                    this._verwaltung.IsEntryDirty = false;

                    foreach (Infragistics.Win.ValueListItem valList in this.cbBenutzer.Items)
                    {
                        Benutzer ben2 = new Benutzer((Guid)valList.DataValue);
                        if (ben2.AktivJN)
                        {
                            valList.Appearance.ForeColor = Color.DarkGreen;
                        }
                        else
                        {
                            valList.Appearance.ForeColor = Color.DarkRed;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ucBenutzerEdit_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.Visible && !this.IsVisibleInitialized)
                {
                    this.cbBenutzer.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;
                    this.cbBenutzer.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
                    this.cbBenutzer.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;

                    this.IsVisibleInitialized = true;
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnCheckUserCanSign_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ucBenutzer2 != null)
                {
                    System.Collections.Generic.List<Guid> lstBerufsgruppenUserCanSign = new List<Guid>();
                    PMDSBusiness b = new PMDSBusiness();
                    PMDS.db.Entities.Benutzer ben = new db.Entities.Benutzer();
                    ben.IDBerufsstand = ucBenutzer2.Benutzer.IDBerufsstand;
                    ben.ID = ucBenutzer2.Benutzer.ID;
                    b.initUserCanSign(ben);
                    lstBerufsgruppenUserCanSign = PMDSBusiness.lstBerufsgruppenUserCanSign; //.Contains(ucBenutzer2.Benutzer.IDBerufsstand);
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                    {
                        string sBerufsgruppen = QS2.Desktop.ControlManagment.ControlManagment.getRes("Berechtigung zum Abzeichnen für folgende Berufsgruppen:") + " \n\r\n\r";
                        System.Collections.Generic.List<PMDS.db.Entities.AuswahlListe> lstBerufsgruppen = new List<PMDS.db.Entities.AuswahlListe>();

                        if (lstBerufsgruppenUserCanSign.Count() > 0)
                        {
                            foreach (Guid idBerufsstand in lstBerufsgruppenUserCanSign)
                            {
                                PMDS.db.Entities.AuswahlListe rAuswahliste = new db.Entities.AuswahlListe();
                                rAuswahliste = b.GetAuswahllisteByID(idBerufsstand, db);
                                lstBerufsgruppen.Add(rAuswahliste);
                                sBerufsgruppen += (rAuswahliste.Bezeichnung + "\n\r");
                            }
                        }
                        else
                        {
                            sBerufsgruppen += (QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine!") + "\n\r");
                        }
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sBerufsgruppen, "Info", MessageBoxButtons.OK);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucBenutzerEdit.BtnCheckUserCanSign_Click: " + ex.ToString());
            }
        }
    }

}
