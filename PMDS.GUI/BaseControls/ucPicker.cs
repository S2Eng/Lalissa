//----------------------------------------------------------------------------
/// <summary>
///	ucPicker.cs
/// Erstellt am:	6.7.2005
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
	/// UserControl für Auswahl mittels Suche
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucPicker : QS2.Desktop.ControlManagment.BaseControl
	{
		public class PickerSelectedArgs
		{
			public Guid		_IDEintrag = Guid.Empty;
			public string	_Text = "";

			public PickerSelectedArgs(Guid IDEintrag, string sText) 
			{
				_IDEintrag	= IDEintrag;
				_Text		= sText;
			}

			public override string ToString()
			{
				return _Text;
			}

		}
		public delegate void PickerSelectedDelegate(PickerSelectedArgs args);

        private bool _readOnly = false;
        public ListBox lbSearch;
        private System.Data.DataView dv;
        private QS2.Desktop.ControlManagment.BaseTextEditorWin txtSearch;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel uGridBagLayoutPanelList;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private QS2.Desktop.ControlManagment.BasePanel panel1;
		private System.ComponentModel.IContainer components = null;

		public event EventHandler SelectionChanged;
		public event PickerSelectedDelegate Selected;

        public bool isEintragPicker = false;





		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucPicker()
		{
			InitializeComponent();
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
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
            this.lbSearch = new System.Windows.Forms.ListBox();
            this.dv = new System.Data.DataView();
            this.txtSearch = new QS2.Desktop.ControlManagment.BaseTextEditorWin();
            this.uGridBagLayoutPanelList = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panel1 = new QS2.Desktop.ControlManagment.BasePanel();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGridBagLayoutPanelList)).BeginInit();
            this.uGridBagLayoutPanelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSearch
            // 
            this.lbSearch.BackColor = System.Drawing.Color.White;
            this.lbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSearch.DataSource = this.dv;
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            this.uGridBagLayoutPanelList.SetGridBagConstraint(this.lbSearch, gridBagConstraint1);
            this.lbSearch.HorizontalExtent = 5000;
            this.lbSearch.HorizontalScrollbar = true;
            this.lbSearch.IntegralHeight = false;
            this.lbSearch.Location = new System.Drawing.Point(5, 5);
            this.lbSearch.Name = "lbSearch";
            this.uGridBagLayoutPanelList.SetPreferredSize(this.lbSearch, new System.Drawing.Size(323, 100));
            this.lbSearch.Size = new System.Drawing.Size(478, 396);
            this.lbSearch.TabIndex = 1;
            this.lbSearch.SelectedValueChanged += new System.EventHandler(this.OnSelectionChanged);
            this.lbSearch.DoubleClick += new System.EventHandler(this.lbSearch_DoubleClick);
            // 
            // dv
            // 
            this.dv.AllowDelete = false;
            this.dv.AllowEdit = false;
            this.dv.AllowNew = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint2.Insets.Left = 5;
            gridBagConstraint2.Insets.Right = 5;
            gridBagConstraint2.Insets.Top = 5;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.txtSearch, gridBagConstraint2);
            this.txtSearch.Location = new System.Drawing.Point(5, 5);
            this.txtSearch.Name = "txtSearch";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.txtSearch, new System.Drawing.Size(362, 20));
            this.txtSearch.Size = new System.Drawing.Size(478, 20);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // uGridBagLayoutPanelList
            // 
            this.uGridBagLayoutPanelList.Controls.Add(this.lbSearch);
            this.uGridBagLayoutPanelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGridBagLayoutPanelList.ExpandToFitHeight = true;
            this.uGridBagLayoutPanelList.ExpandToFitWidth = true;
            this.uGridBagLayoutPanelList.Location = new System.Drawing.Point(0, 0);
            this.uGridBagLayoutPanelList.Name = "uGridBagLayoutPanelList";
            this.uGridBagLayoutPanelList.Size = new System.Drawing.Size(488, 406);
            this.uGridBagLayoutPanelList.TabIndex = 4;
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.txtSearch);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(488, 26);
            this.ultraGridBagLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uGridBagLayoutPanelList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 406);
            this.panel1.TabIndex = 6;
            // 
            // ucPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.Name = "ucPicker";
            this.Size = new System.Drawing.Size(488, 432);
            this.Load += new System.EventHandler(this.ucPicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGridBagLayoutPanelList)).EndInit();
            this.uGridBagLayoutPanelList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            this.ultraGridBagLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten filtern
		/// </summary>
		//----------------------------------------------------------------------------
		private void FilterItems(string filter)
		{
			string f = "";
			if (filter != "")
				f = string.Format("{0} like '%{1}%'", DisplayMember, GuiUtil.LikeFilter(filter));

			try { dv.RowFilter = f; } 
			catch { dv.RowFilter = "1 = 0"; }

			// damit übergeordnetes Element 
			// eine eventuelle Anzahländerung mitbekommt
			OnSelectionChanged(null, EventArgs.Empty);
		}

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                txtSearch.ReadOnly = _readOnly;
                lbSearch.Enabled = !_readOnly;
            }
        }

        /// <summary>
        /// Nach Eingabe von DataSource, kann der Filter eingesetzt werden.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Filter
        {
            get { return txtSearch.Text.Trim(); }
            set { txtSearch.Text = value; }
        }
		//----------------------------------------------------------------------------
		/// <summary>
		/// DataSource
		/// </summary>
		//----------------------------------------------------------------------------
		public DataTable DataSource
		{
			get	{	return dv.Table;	}
			set	
            {
                if (this.isEintragPicker && value != null)
                {
                    PMDS.Global.db.Pflegeplan.dsEintrag.EintragDataTable dtCopy = (PMDS.Global.db.Pflegeplan.dsEintrag.EintragDataTable)value.Copy();
                    dtCopy.Columns.Add("TextWarnhinweis", typeof(string));
                    foreach (PMDS.Global.db.Pflegeplan.dsEintrag.EintragRow r in dtCopy.Rows)
                    {
                        r["TextWarnhinweis"] = r.Text.Trim() + " (" + r.Warnhinweis.Trim() + ")";
                    }
                    this.lbSearch.DisplayMember = "TextWarnhinweis";

                    dv.Table = dtCopy;
                    txtSearch.Text = "";
                }
                else
                {
                    dv.Table = value;
                    txtSearch.Text = "";
                }
            }
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DisplayMember
		/// </summary>
		//----------------------------------------------------------------------------
		public string DisplayMember
		{
			get	{	return lbSearch.DisplayMember;	}
			set	{	lbSearch.DisplayMember = value;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// ValueMember
		/// </summary>
		//----------------------------------------------------------------------------
		public string ValueMember
		{
			get	{	return lbSearch.ValueMember;	}
			set	{	lbSearch.ValueMember = value;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Value
		/// </summary>
		//----------------------------------------------------------------------------
		public object Value
		{
			get	{	return lbSearch.SelectedValue;	}
			set
			{
				if (value == null)
				{
					if (Count > 0)
						lbSearch.SelectedIndex = 0;
				}
				else
					lbSearch.SelectedValue = value;

				OnSelectionChanged(null, EventArgs.Empty);
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Text
		/// </summary>
		//----------------------------------------------------------------------------
		public override string Text
		{
			get	{	return lbSearch.Text;	}
			set	{	/* NOT REQUIRED */		}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Count
		/// </summary>
		//----------------------------------------------------------------------------
		public int Count
		{
			get	{	return dv.Count;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten-Änderungs signalisieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected void OnSelectionChanged(object sender, EventArgs args)
		{
			if (SelectionChanged != null)
				SelectionChanged(this, args);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Elementauswahl signalisieren
		/// </summary>
		//----------------------------------------------------------------------------
		protected void OnSelected(PickerSelectedArgs args)
		{
			if (Selected != null)
				Selected(args);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Datenauswahl selektieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void lbSearch_DoubleClick(object sender, System.EventArgs e)
		{
			// Daten vorhanden ?
			if (Value == null)
				return;

			PickerSelectedArgs args = new PickerSelectedArgs((Guid)Value, Text);
			OnSelected(args);
		}

        private void ucPicker_Load(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterItems(txtSearch.Text);
        }



	}
}
