using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Global;
using PMDS.DB;

using System.Linq;
using Infragistics.Win.UltraWinGrid;
using S2Extensions;

namespace PMDS.GUI
{

	public class ucAuswahl : QS2.Desktop.ControlManagment.BaseControl, IUCBase
	{
		private AuswahlGruppe _auswahlGruppe;
		private bool _valueChangeEnabled = true;
		public event EventHandler ValueChanged;

		private QS2.Desktop.ControlManagment.BaseButton btnUp;
		private  dsAuswahlGruppe dsAuswahlGruppe1;
		private PMDS.GUI.ucButton btnDel;
		private System.Data.DataView viewAuswahl;
		private QS2.Desktop.ControlManagment.BaseGrid dgAuswahl;
		private PMDS.GUI.ucButton btnAdd;
		private QS2.Desktop.ControlManagment.BaseButton btnDown;
		private System.ComponentModel.IContainer components;
        private Panel panelDetailBottom;
        private Infragistics.Win.Misc.UltraGroupBox grpDetails;
        private Infragistics.Win.Misc.UltraLabel lblBerufsgruppen;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkGegenzeichnenJN;
        internal Infragistics.Win.Misc.UltraPopupControlContainer UPopupContBerufsgruppen;
        public Klient.cboAuswahllisteMulti cboBerufsgruppen;
        public ucAuswahlEdit mainWindow = null;

        public UIGlobal UIGlobal1 = new UIGlobal();

        public Infragistics.Win.UltraWinGrid.UltraGridRow last_gridRow = null;
        public dsAuswahlGruppe.AuswahlListeRow last_rSelRow = null;








        public ucAuswahl()
		{
			InitializeComponent();
			New();
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("AuswahlListe", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDAuswahlListeGruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Reihenfolge");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IstGruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GehörtzuGruppe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Hierarche");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Beschreibung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Unterdruecken");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ELGA_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ELGA_Code");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ELGA_CodeSystem");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ELGA_DisplayName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ELGA_Version");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAuswahl));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.btnUp = new QS2.Desktop.ControlManagment.BaseButton();
            this.dgAuswahl = new QS2.Desktop.ControlManagment.BaseGrid();
            this.btnDown = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelDetailBottom = new System.Windows.Forms.Panel();
            this.grpDetails = new Infragistics.Win.Misc.UltraGroupBox();
            this.cboBerufsgruppen = new PMDS.GUI.Klient.cboAuswahllisteMulti();
            this.chkGegenzeichnenJN = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lblBerufsgruppen = new Infragistics.Win.Misc.UltraLabel();
            this.btnAdd = new PMDS.GUI.ucButton(this.components);
            this.btnDel = new PMDS.GUI.ucButton(this.components);
            this.UPopupContBerufsgruppen = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.viewAuswahl = new System.Data.DataView();
            this.dsAuswahlGruppe1 = new PMDS.Global.db.Global.dsAuswahlGruppe();
            ((System.ComponentModel.ISupportInitialize)(this.dgAuswahl)).BeginInit();
            this.panelDetailBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpDetails)).BeginInit();
            this.grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkGegenzeichnenJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewAuswahl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAuswahlGruppe1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.AutoWorkLayout = false;
            this.btnUp.IsStandardControl = false;
            this.btnUp.Location = new System.Drawing.Point(686, 0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(32, 24);
            this.btnUp.TabIndex = 18;
            this.btnUp.Text = "<";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // dgAuswahl
            // 
            this.dgAuswahl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAuswahl.AutoWork = true;
            this.dgAuswahl.DataSource = this.viewAuswahl;
            this.dgAuswahl.DisplayLayout.AddNewBox.Prompt = "Add ...";
            ultraGridBand1.AddButtonCaption = "AuswahlListeGruppe";
            ultraGridColumn7.Header.VisiblePosition = 0;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn7.RowLayoutColumnInfo.OriginX = 0;
            ultraGridColumn7.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(43, 0);
            ultraGridColumn7.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn7.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn8.Header.Caption = "Gruppe";
            ultraGridColumn8.Header.VisiblePosition = 1;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn8.RowLayoutColumnInfo.OriginX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(51, 0);
            ultraGridColumn8.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn8.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn17.Header.VisiblePosition = 3;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn17.RowLayoutColumnInfo.OriginX = 6;
            ultraGridColumn17.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn17.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(42, 0);
            ultraGridColumn17.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn17.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn18.Header.VisiblePosition = 2;
            ultraGridColumn18.MaxLength = 255;
            ultraGridColumn18.RowLayoutColumnInfo.OriginX = 4;
            ultraGridColumn18.RowLayoutColumnInfo.OriginY = 0;
            ultraGridColumn18.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(273, 0);
            ultraGridColumn18.RowLayoutColumnInfo.SpanX = 2;
            ultraGridColumn18.RowLayoutColumnInfo.SpanY = 2;
            ultraGridColumn19.Header.Caption = "Ist Gruppe";
            ultraGridColumn19.Header.VisiblePosition = 4;
            ultraGridColumn20.Header.Caption = "Gehört zu Gruppe";
            ultraGridColumn20.Header.VisiblePosition = 5;
            ultraGridColumn20.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(233, 0);
            ultraGridColumn21.Header.VisiblePosition = 6;
            ultraGridColumn22.Header.VisiblePosition = 7;
            ultraGridColumn22.RowLayoutColumnInfo.PreferredCellSize = new System.Drawing.Size(186, 0);
            ultraGridColumn23.Header.VisiblePosition = 8;
            ultraGridColumn24.Header.VisiblePosition = 9;
            ultraGridColumn25.Header.VisiblePosition = 10;
            ultraGridColumn26.Header.VisiblePosition = 11;
            ultraGridColumn27.Header.VisiblePosition = 12;
            ultraGridColumn28.Header.VisiblePosition = 13;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28});
            ultraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.ColumnLayout;
            this.dgAuswahl.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgAuswahl.DisplayLayout.GroupByBox.Prompt = "Drag a column header here to group by that column.";
            this.dgAuswahl.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgAuswahl.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.dgAuswahl.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            this.dgAuswahl.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.dgAuswahl.DisplayLayout.Override.NullText = "";
            this.dgAuswahl.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.dgAuswahl.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.dgAuswahl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgAuswahl.Location = new System.Drawing.Point(0, 32);
            this.dgAuswahl.Name = "dgAuswahl";
            this.dgAuswahl.Size = new System.Drawing.Size(806, 510);
            this.dgAuswahl.TabIndex = 22;
            this.dgAuswahl.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dgAuswahl_CellChange);
            this.dgAuswahl.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.dgAuswahl_BeforeCellActivate);
            this.dgAuswahl.Click += new System.EventHandler(this.dgAuswahl_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.AutoWorkLayout = false;
            this.btnDown.IsStandardControl = false;
            this.btnDown.Location = new System.Drawing.Point(718, 0);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(32, 24);
            this.btnDown.TabIndex = 19;
            this.btnDown.Text = ">";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // panelDetailBottom
            // 
            this.panelDetailBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelDetailBottom.Controls.Add(this.grpDetails);
            this.panelDetailBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDetailBottom.Location = new System.Drawing.Point(0, 542);
            this.panelDetailBottom.Name = "panelDetailBottom";
            this.panelDetailBottom.Size = new System.Drawing.Size(806, 58);
            this.panelDetailBottom.TabIndex = 23;
            // 
            // grpDetails
            // 
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.Controls.Add(this.cboBerufsgruppen);
            this.grpDetails.Controls.Add(this.chkGegenzeichnenJN);
            this.grpDetails.Controls.Add(this.lblBerufsgruppen);
            this.grpDetails.Location = new System.Drawing.Point(5, 1);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(794, 52);
            this.grpDetails.TabIndex = 26;
            this.grpDetails.Text = "Details";
            // 
            // cboBerufsgruppen
            // 
            this.cboBerufsgruppen.Location = new System.Drawing.Point(90, 15);
            this.cboBerufsgruppen.Margin = new System.Windows.Forms.Padding(4);
            this.cboBerufsgruppen.Name = "cboBerufsgruppen";
            this.cboBerufsgruppen.Size = new System.Drawing.Size(347, 31);
            this.cboBerufsgruppen.TabIndex = 99;
            this.cboBerufsgruppen.AfterCheck += new System.EventHandler(this.OnValueChangedComboBerufsstand);
            // 
            // chkGegenzeichnenJN
            // 
            this.chkGegenzeichnenJN.Location = new System.Drawing.Point(456, 19);
            this.chkGegenzeichnenJN.Name = "chkGegenzeichnenJN";
            this.chkGegenzeichnenJN.Size = new System.Drawing.Size(146, 23);
            this.chkGegenzeichnenJN.TabIndex = 26;
            this.chkGegenzeichnenJN.Text = "Gegenzeichnen J/N";
            this.chkGegenzeichnenJN.Visible = false;
            this.chkGegenzeichnenJN.CheckedChanged += new System.EventHandler(this.chkGegenzeichnenJN_CheckedChanged);
            // 
            // lblBerufsgruppen
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.lblBerufsgruppen.Appearance = appearance1;
            this.lblBerufsgruppen.Location = new System.Drawing.Point(10, 19);
            this.lblBerufsgruppen.Name = "lblBerufsgruppen";
            this.lblBerufsgruppen.Size = new System.Drawing.Size(101, 22);
            this.lblBerufsgruppen.TabIndex = 25;
            this.lblBerufsgruppen.Text = "Berufsgruppen";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAdd.Appearance = appearance2;
            this.btnAdd.AutoWorkLayout = false;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.DoOnClick = true;
            this.btnAdd.IsStandardControl = true;
            this.btnAdd.Location = new System.Drawing.Point(758, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.TabStop = false;
            this.btnAdd.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnAdd.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDel.Appearance = appearance3;
            this.btnDel.AutoWorkLayout = false;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.DoOnClick = true;
            this.btnDel.IsStandardControl = true;
            this.btnDel.Location = new System.Drawing.Point(782, 0);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 24);
            this.btnDel.TabIndex = 21;
            this.btnDel.TabStop = false;
            this.btnDel.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // viewAuswahl
            // 
            this.viewAuswahl.AllowNew = false;
            this.viewAuswahl.Table = this.dsAuswahlGruppe1.AuswahlListe;
            // 
            // dsAuswahlGruppe1
            // 
            this.dsAuswahlGruppe1.DataSetName = "dsAuswahlGruppe";
            this.dsAuswahlGruppe1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsAuswahlGruppe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ucAuswahl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.panelDetailBottom);
            this.Controls.Add(this.dgAuswahl);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDel);
            this.Name = "ucAuswahl";
            this.Size = new System.Drawing.Size(806, 600);
            this.Load += new System.EventHandler(this.ucAuswahl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAuswahl)).EndInit();
            this.panelDetailBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpDetails)).EndInit();
            this.grpDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkGegenzeichnenJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewAuswahl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAuswahlGruppe1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public AuswahlGruppe AuswahlGruppe
		{
			get	
			{	
				return _auswahlGruppe;	
			}

			set	
			{	
				if (value == null)
					throw new ArgumentNullException("AuswahlGruppe");

				_valueChangeEnabled = false;
				_auswahlGruppe = value;
				//string oldSort = viewAuswahl.Sort;
				viewAuswahl.Table = _auswahlGruppe.AuswahlListe;
				//viewAuswahl.Sort = oldSort;
				dgAuswahl.DataBind();
				_valueChangeEnabled = true;
				UpdateButtons();

                if (_auswahlGruppe.ID.Trim() != "")
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        var rAuswahlListeGruppe = (from ag in db.AuswahlListeGruppe
                                       where ag.ID == _auswahlGruppe.ID
                                                   select new
                                       {
                                            ID = ag.ID,
                                            Bezeichnung = ag.Bezeichnung,
                                            sys = ag.sys
                                        }).First();

                        bool sysTmp = false;
                        if (ENV.adminSecure)
                        {
                            sysTmp = false;
                        }
                        else
                        {
                            sysTmp = rAuswahlListeGruppe.sys;
                        }

                        this.btnAdd.Visible = !sysTmp;
                        this.btnDel.Visible = !sysTmp;
                        this.btnUp.Visible = !sysTmp;
                        this.btnDown.Visible = !sysTmp;
                        if (this.mainWindow != null)
                        {
                            this.mainWindow.btnSave.Visible = !sysTmp;
                        }
                    }
                }
            }
		}


		private void ucAuswahl_Load(object sender, System.EventArgs e)
		{
			try
			{
				BindingContext[viewAuswahl].PositionChanged += new EventHandler(ucAuswahl_PositionChanged);
            }
			catch(Exception ex)
			{
				ENV.HandleException(ex);
			}
		}

		public bool New()
		{
            this.clearDetail("");
            AuswahlGruppe = new AuswahlGruppe();
			return true;
		}

		public void Read(object id)
		{
            this.clearDetail((string)id);
            AuswahlGruppe obj = new AuswahlGruppe((string)id);
			AuswahlGruppe = obj;
		}

		public void Read()
		{
            AuswahlGruppe.Read();
            this.clearDetail(AuswahlGruppe.ID);
            AuswahlGruppe = AuswahlGruppe;
        }

		public void Write()
		{
			AuswahlGruppe.Write();
		}

		public void Delete()
		{
            AuswahlGruppe.Delete();
            this.clearDetail("");
            New();
		}

		protected void OnValueChanged(object sender, EventArgs args)
		{
            if (_valueChangeEnabled && (ValueChanged != null))
                ValueChanged(sender, args);
        }

        private void dgAuswahl_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
		{
			OnValueChanged(sender, EventArgs.Empty);
		}

		private void ucAuswahl_PositionChanged(object sender, EventArgs e)
		{
			UpdateButtons();		
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			AuswahlGruppe.AddEntry();
			OnValueChanged(sender, EventArgs.Empty);
			UpdateButtons();
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			UltraGridTools.DeleteCurrentSelectedRow(dgAuswahl, false);

			// Reihenfolge neu vergeben
			dsAuswahlGruppe.AuswahlListeRow r;
			for(int i=0;i<viewAuswahl.Count;i++)
			{
				r = RowAtIndex(i);
				if (r.Reihenfolge != (i+1))
					r.Reihenfolge = (i+1);
			}

			OnValueChanged(sender, EventArgs.Empty);
			UpdateButtons();
		}

		private dsAuswahlGruppe.AuswahlListeRow RowAtIndex(int idx)
		{
			return (dsAuswahlGruppe.AuswahlListeRow)viewAuswahl[idx].Row;
		}

		private void UpdateButtons()
		{
			int sel	= BindingContext[viewAuswahl].Position;
			int max	= viewAuswahl.Count;

			btnUp.Enabled	= (sel > 0);
			btnDown.Enabled = (sel < (max-1));
		}

		private void SwapRow(int i, int j)
		{
			dsAuswahlGruppe.AuswahlListeRow r1 = RowAtIndex(i);
			dsAuswahlGruppe.AuswahlListeRow r2 = RowAtIndex(j);

			int reihe = r1.Reihenfolge;
			r1.Reihenfolge = r2.Reihenfolge;
			r2.Reihenfolge = reihe;
		}

		private void btnUp_Click(object sender, System.EventArgs e)
		{
			int sel	= BindingContext[viewAuswahl].Position;
			int max	= viewAuswahl.Count;

			if (sel > 0)
			{
				SwapRow(sel, sel-1);
				BindingContext[viewAuswahl].Position = sel-1;
				dgAuswahl.DataBind();
				OnValueChanged(sender, EventArgs.Empty);
			}
		}

		private void btnDown_Click(object sender, System.EventArgs e)
		{
			int sel	= BindingContext[viewAuswahl].Position;
			int max	= viewAuswahl.Count;

			if (sel < (max-1))
			{
				SwapRow(sel, sel+1);
				BindingContext[viewAuswahl].Position = sel+1;
				dgAuswahl.DataBind();
				OnValueChanged(sender, EventArgs.Empty);
			}
		}

		public void UpdateDATA()
		{

		}

		public bool ValidateFields()
		{
			bool bError = false;

			// AuswahlListe - keine Leeren zeilen erlaubt
			foreach(dsAuswahlGruppe.AuswahlListeRow r in _auswahlGruppe.AuswahlListe)
			{
				if (r.RowState == DataRowState.Deleted)
					continue;

				GuiUtil.ValidateField(dgAuswahl, (r.Bezeichnung.Trim().Length > 0),
					ENV.String("GUI.E_NO_EMPTY_LINES"), ref bError, false, null);

				if (bError)
					break;
			}

			return !bError;
		}

		DataTable IUCBase.All()
		{
			return AuswahlGruppe.AllEntries();
		}

		IBusinessBase IUCBase.Object
		{
			get	{	return AuswahlGruppe;					}
			set	{	AuswahlGruppe = (AuswahlGruppe)value;	}
		}

        private void dgAuswahl_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void dgAuswahl_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.dgAuswahl))
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                    dsAuswahlGruppe.AuswahlListeRow rSelRow = this.getSelectedRow(false, ref gridRow);
                    if (rSelRow != null)
                    {
                        if (this.last_rSelRow != null)
                        {
                            //this.writeAuswahlisteDetails(this.last_rSelRow);
                        }

                        this.clearDetail(rSelRow.IDAuswahlListeGruppe);
                        if (rSelRow.IDAuswahlListeGruppe.Trim() != "" && rSelRow.IDAuswahlListeGruppe.Trim().ToLower().Equals(("DDF").Trim().ToLower()))
                        {
                            this.showAuswahlisteDetails(rSelRow);
                            this.last_rSelRow = rSelRow;
                            this.last_gridRow = gridRow;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


        public dsAuswahlGruppe.AuswahlListeRow getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.dgAuswahl.ActiveRow != null)
                {
                    if (this.dgAuswahl.ActiveRow.IsGroupByRow || this.dgAuswahl.ActiveRow.IsFilterRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.dgAuswahl.ActiveRow.ListObject;
                        dsAuswahlGruppe.AuswahlListeRow rSelRow = (dsAuswahlGruppe.AuswahlListeRow)v.Row;
                        gridRow = this.dgAuswahl.ActiveRow;
                        return rSelRow;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucAuswahl.getSelectedRow: " + ex.ToString());
            }
        }

        public void showAuswahlisteDetails(dsAuswahlGruppe.AuswahlListeRow rSelListAct)
        {
            try
            {
                this.chkGegenzeichnenJN.Checked = rSelListAct.IstGruppe;
                this.cboBerufsgruppen.setSelectedRowsID(rSelListAct.Beschreibung.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception("ucAuswahl.getAuswahlisteDetails: " + ex.ToString());
            }
        }

        public void clearDetail(string IDSelList)
        {
            try
            {
                this.last_gridRow = null;
                this.last_rSelRow = null;
                this.chkGegenzeichnenJN.Checked = false;
                this.cboBerufsgruppen.setAllSelectedOnOff(false);

                if (!string.IsNullOrWhiteSpace(IDSelList) && IDSelList.sEquals("DDF"))
                {
                    if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv" && !this.cboBerufsgruppen.isInitialized)
                    {
                        this.cboBerufsgruppen.initControl("BER");
                        this.cboBerufsgruppen.loadData();
                    }
                    this.panelDetailBottom.Visible = true;
                }
                else
                {
                    this.panelDetailBottom.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucAuswahl.clearDetail: " + ex.ToString());
            }
        }

        private void chkGegenzeichnenJN_CheckedChanged(object sender, EventArgs e)
        {
            try
            { 
                if (this.chkGegenzeichnenJN.Focused)
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                    dsAuswahlGruppe.AuswahlListeRow rSelRow = this.getSelectedRow(false, ref gridRow);
                    if (rSelRow != null)
                    {
                        rSelRow.IstGruppe = this.chkGegenzeichnenJN.Checked;
                    }

                    OnValueChanged(sender, EventArgs.Empty);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucAuswahl.clearDetail: " + ex.ToString());
            }
        }

        public void OnValueChangedComboBerufsstand(object sender, EventArgs args)
        {
            try
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                dsAuswahlGruppe.AuswahlListeRow rSelRow = this.getSelectedRow(false, ref gridRow);
                if (rSelRow != null)
                {
                    rSelRow.Beschreibung = this.cboBerufsgruppen.getSelectedRowsID();
                }

                OnValueChanged(sender, EventArgs.Empty);

            }
            catch (Exception ex)
            {
                throw new Exception("ucAuswahl.OnValueChangedComboBerufsstand: " + ex.ToString());
            }
        }

    }


}
