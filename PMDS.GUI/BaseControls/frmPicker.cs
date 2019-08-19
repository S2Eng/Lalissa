//----------------------------------------------------------------------------
/// <summary>
///	frmPicker.cs
/// Erstellt am:	6.7.2005
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
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Form für Datensuche.
	/// </summary>
	//----------------------------------------------------------------------------
	public class frmPicker :  System.Windows.Forms.Form 
	{
		private bool _bCanclose = false;
		private PMDS.GUI.ucPicker ucPicker1;
		private PMDS.GUI.ucButton btnCancel;
		private PMDS.GUI.ucButton btnOK;
		private QS2.Desktop.ControlManagment.BaseLabel txtAnzahl;
		private System.ComponentModel.IContainer components = null;

        public int _TypeActivePdxShow = -1;
        public DataTable _SourceOrig = new DataTable();
        public string _displayMember = "";
        public string _valueMember = "";








        public frmPicker(DataTable source, string displayMember, string valueMember, int TypeActivePdxShow, bool IsPdxVerwaltung, bool IsEintragTable = false)
		{
            InitializeComponent();

            if (IsPdxVerwaltung)
            {
                this._TypeActivePdxShow = TypeActivePdxShow;
                this._SourceOrig = source;
                this._displayMember = displayMember;
                this._valueMember = valueMember;

                this.LoadTree();
            }
            else
            {
                if (IsEintragTable && source != null)
                {
                    ucPicker1.isEintragPicker = true;
                    ucPicker1.DataSource = source;
                    ucPicker1.DisplayMember = "TextWarnhinweis";
                    ucPicker1.ValueMember = valueMember;
                }
                else
                {
                    ucPicker1.DataSource = source;
                    ucPicker1.DisplayMember = displayMember;
                    ucPicker1.ValueMember = valueMember;
                }
            }
		}

        public void LoadTree()
        {
            try
            {
                System.Collections.Generic.List<dsPDx.PDXRow> lstToDelete = new System.Collections.Generic.List<dsPDx.PDXRow>();
                DataTable sourceAct = new DataTable();
                sourceAct = this._SourceOrig.Copy();
                
                foreach (dsPDx.PDXRow r in (dsPDx.PDXDataTable)sourceAct)
                {
                    if (this._TypeActivePdxShow == 0)
                    {
                        if (!r.EntferntJN)
                        {
                            bool doNowShow = true;
                            lstToDelete.Add(r);
                        }
                    }
                    else if (this._TypeActivePdxShow == 1)
                    {
                        if (r.EntferntJN)
                        {
                            bool doNowShow = true;
                            lstToDelete.Add(r);
                        }
                    }
                    else if(this._TypeActivePdxShow == -1)
                    {
                        bool bShowAll = true;
                    }
                    else
                    {
                        throw new Exception("LoadTree: this._TypeActivePdxShow  '" + this._TypeActivePdxShow.ToString()+ "' not allowed!");
                    }
                }
                foreach (dsPDx.PDXRow rPdxToDelete in lstToDelete)
                {
                    rPdxToDelete.Delete();
                    //rPdxToDelete.Table.DataSet.AcceptChanges();
                }
                sourceAct.AcceptChanges();

                ucPicker1.DataSource = sourceAct;
                ucPicker1.DisplayMember = this._displayMember;
                ucPicker1.ValueMember = this._valueMember;

            }
            catch (Exception ex)
            {
                throw new Exception("LoadTree: " + ex.ToString());
            }
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPicker));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.ucPicker1 = new PMDS.GUI.ucPicker();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.txtAnzahl = new QS2.Desktop.ControlManagment.BaseLabel();
            this.SuspendLayout();
            // 
            // ucPicker1
            // 
            this.ucPicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPicker1.BackColor = System.Drawing.Color.Transparent;
            this.ucPicker1.DataSource = null;
            this.ucPicker1.DisplayMember = "";
            this.ucPicker1.Location = new System.Drawing.Point(8, 9);
            this.ucPicker1.Name = "ucPicker1";
            this.ucPicker1.Size = new System.Drawing.Size(881, 551);
            this.ucPicker1.TabIndex = 0;
            this.ucPicker1.Value = null;
            this.ucPicker1.ValueMember = "";
            this.ucPicker1.SelectionChanged += new System.EventHandler(this.ucPicker1_SelectionChanged);
            this.ucPicker1.Selected += new PMDS.GUI.ucPicker.PickerSelectedDelegate(this.ucPicker1_Selected);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance3;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(745, 566);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance1;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(841, 566);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtAnzahl
            // 
            this.txtAnzahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAnzahl.Location = new System.Drawing.Point(8, 566);
            this.txtAnzahl.Name = "txtAnzahl";
            this.txtAnzahl.Size = new System.Drawing.Size(224, 23);
            this.txtAnzahl.TabIndex = 1;
            // 
            // frmPicker
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(897, 604);
            this.Controls.Add(this.txtAnzahl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ucPicker1);
            this.MinimumSize = new System.Drawing.Size(360, 352);
            this.Name = "frmPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Suchen nach ...";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Closing);
            this.Load += new System.EventHandler(this.frmPicker_Load);
            this.ResumeLayout(false);

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Selektionsänderung behandeln
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucPicker1_SelectionChanged(object sender, System.EventArgs e)
		{
			txtAnzahl.Text = ENV.String("GUI.SEARCH_INFO", ucPicker1.Count);

			btnOK.Enabled = ((ucPicker1.Count != 0) && (ucPicker1.Value != null));
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog akzeptieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			_bCanclose = true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog abbrechen
		/// </summary>
		//----------------------------------------------------------------------------
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			_bCanclose = true;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dialog schließen überwachen
		/// </summary>
		//----------------------------------------------------------------------------
		private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = !_bCanclose;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Value
		/// </summary>
		//----------------------------------------------------------------------------
		public object Value
		{
			get	{	return ucPicker1.Value;	}
		}

        public bool ReadOnly
        {
            get { return ucPicker1.ReadOnly; }
            set { ucPicker1.ReadOnly = value; }
        }

        /// <summary>
        /// Nach Eingabe von DataSource, kann der Filter eingesetzt werden.
        /// </summary>
        public string Filter
        {
            get { return ucPicker1.Filter; }
            set { ucPicker1.Filter = value; }
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Auswahl übernehmen
		/// </summary>
		//----------------------------------------------------------------------------
		private void ucPicker1_Selected(ucPicker.PickerSelectedArgs e)
		{
			btnOK_Click(this, null);

			DialogResult = btnOK.DialogResult;
			this.Close();
		}

        private void frmPicker_Load(object sender, EventArgs e)
        {
            QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
            ControlManagment1.autoTranslateForm(this);
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
        }

    }
}
