using System;

using PMDS.Global;using PMDS.Data.Global;
using PMDS.BusinessLogic;
using System.Drawing;

using Infragistics.Win.UltraWinEditors;
using System.ComponentModel;
using Infragistics.Win;
using PMDS.Global.db.Global;
using System.Collections.Generic;
using System.Linq;

namespace PMDS.GUI.BaseControls
{

	public class AuswahlGruppeCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{
		private EditorButton _addBtn = new EditorButton("");
		private string _group = "";
        private bool    _addEmptyEnry;
        private bool _ignoreUnterdruecken = true;     //Column Unterdruecken aus Auswahlliste igonorieren: standardmäßig alle anzeigen
        private bool _selectdistinct;

        private int _BerufsstandGruppeJNA = -1;

        public bool VisibleIsInitialized = false;
        public int _SupressLevelHierarchie = -100000;

        public bool _sys = false;
        public bool _ExactMatch = false;
        public bool _PflichtJN = false;
        public bool _autoOpenCBO = false;

        public bool IsInitialized = false;
        public AuswahlGruppe _grp = null;






        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // AuswahlGruppeCombo
            // 
            this.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            this.ValueChanged += new System.EventHandler(this.AuswahlGruppeCombo_ValueChanged);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        public AuswahlGruppeCombo()
		{
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
            {
                //if (Group == "FAM")
                //{
                //    bool bStop2 = true;
                //}

                //if (Settings.AppRunning && Group.Trim() != "")
                //{
                //    this.initControl();
                //}

                //if (Settings.HasRight(UserRights.AuswahllistenVerwalten) && Settings.AppRunning)
                //{
                //    //    if (sys)
                //    //    {
                //    //        _addBtn.Text = "+";
                //    //        _addBtn.Click += new EditorButtonEventHandler(addBtn_Click);
                //    //        this.ButtonsRight.Add(_addBtn);
                //    //    }
                //    //    else
                //    //    {
                //    //        bool bStop = true;
                //    //    }

                //    //    //Neu nach 03.07.2007 MDA
                //    Settings.AuswahlGruppeListChanged += new AuswahlGruppeListChangedDelegate(ENV_AuswahlGruppeListChanged);
                //}
            }
		}

        public void initControl()
        {
            //if (Group == "WAT")
            //{
            //    bool bStop2 = true;
            //}

            if (!this.IsInitialized && System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
            {
                _grp = new AuswahlGruppe(Group);
                dsAuswahlGruppe.AuswahlListeGruppeRow rGroup = _grp._db.getGroup(this.Group);
                this.sys = rGroup.sys;
                this.ExactMatch = rGroup.ExactMatch;
                this.PflichtJN = rGroup.PflichtJN;

                if (this.AutoOpenCBO)
                {
                    this.DropDownStyle = DropDownStyle.DropDown;
                    this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    this.AutoSuggestFilterMode = AutoSuggestFilterMode.Contains;
                }

                if (!this.sys)
                {
                    if (ENV.HasRight(UserRights.AuswahllistenVerwalten) && ENV.AppRunning)
                    {
                        _addBtn.Text = "+";
                        _addBtn.Click += new EditorButtonEventHandler(addBtn_Click);
                        this.ButtonsRight.Add(_addBtn);
                        ENV.AuswahlGruppeListChanged += new AuswahlGruppeListChangedDelegate(ENV_AuswahlGruppeListChanged);
                    }
                   
                    //if (this.ButtonsRight.Count > 0)
                    //{
                    //    this.ButtonsRight[0].Visible = false;
                    //}
                }
                else
                {
                    bool bStop = true;
                }

                if (this.ExactMatch)
                {

                }

                this.IsInitialized = true;
            }
        }

        public override void RefreshList()
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                return;

            this.initControl();
            this.Items.Clear();
            try
            {
                if (_addEmptyEnry)
                    this.Items.Add(Guid.Empty, " ");

                if (ENV.StartupTyp != "auswpep")
                {

                    List<string> lItems = new List<string>();   //üfr distinct

                    dsAuswahlGruppe.AuswahlListeDataTable t = _grp.AuswahlListe;
                    foreach (dsAuswahlGruppe.AuswahlListeRow r in new AuswahlGruppe(Group).AuswahlListe)
                    {
                        if (r.IDAuswahlListeGruppe.Trim().Equals("BER", StringComparison.CurrentCultureIgnoreCase))         //Berufsgruppen - Sonderbehandlung
                        {
                            if (r.Hierarche >= this._SupressLevelHierarchie && 
                                ((!r.IstGruppe && this._BerufsstandGruppeJNA == 0) || (r.IstGruppe && this._BerufsstandGruppeJNA == 1) || this._BerufsstandGruppeJNA == -1)
                               )
                            {
                                this.Items.Add(r.ID, r.Bezeichnung);
                            }
                        }
                        else
                        {
                            if (this._ignoreUnterdruecken)
                            {
                                this.Items.Add(r.ID, r.Bezeichnung);
                                lItems.Add(r.Bezeichnung);
                            }
                            else if (!r.Unterdruecken)          //unterdrückte nicht anzeigen
                            {
                                if (_selectdistinct && !lItems.Where(a => a == r.Bezeichnung).Any())        //nur eindeutige Rows
                                {
                                    this.Items.Add(r.ID, r.Bezeichnung);
                                    lItems.Add(r.Bezeichnung);
                                }
                                else if (!_selectdistinct) 
                                {
                                    this.Items.Add(r.ID, r.Bezeichnung);
                                }
                            }
                        }
                    }
                }
                else
                {
                    using (System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter())
                    {
                        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                        cmd.Connection = DBPep.ConnPep;
                        cmd.CommandText = Group;
                        da.SelectCommand = cmd;
                        using (System.Data.DataTable dt = new System.Data.DataTable())
                        {
                            da.Fill(dt);
                            foreach (System.Data.DataRow r in dt.Rows)
                            {
                                this.Items.Add(r[0].ToString(), r[1].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }

        void ENV_AuswahlGruppeListChanged(string Grop)
        {
            if (Grop == _group)
            {
                object oldValue = Value;
                RefreshList();
                Value = oldValue;
            }
        }

        public bool sys
        {
            get { return _sys; }
            set { _sys = value; }
        }
        public bool ExactMatch
        {
            get { return _ExactMatch; }
            set { _ExactMatch = value; }
        }
        public bool PflichtJN
        {
            get { return _PflichtJN; }
            set { _PflichtJN = value; }
        }
        public bool AutoOpenCBO
        {
            get { return _autoOpenCBO; }
            set { _autoOpenCBO = value; }
        }
        
        public bool ShowAddButton
		{
			get { return _addBtn.Visible;  }
			set { _addBtn.Visible = value; }
		}

        public bool AddEmptyEntry
        {
            get { return _addEmptyEnry; }
            set { _addEmptyEnry = value; }
        }

		public new bool ReadOnly
		{
			get
            {
                return base.ReadOnly;
            }
			set	
			{	
				_addBtn.Visible = !value;	
				base.ReadOnly = value;
			}
		}

		public string Group
		{
			get	{	return _group;	}
			set
            {
                try
                {
                    _group = value;
                    if (String.IsNullOrWhiteSpace(value))
                        return;

                    RefreshList();
                }
                catch(Exception ex)
                {
                    throw new Exception("Group: " + ex.ToString());
                }
			}
		}

        public bool IgnoreUnterdruecken
        {
            get { return _ignoreUnterdruecken; }
            set
            {
                try
                {
                    _ignoreUnterdruecken = value;
                    if (!DesignMode)
                       RefreshList();
                }
                catch (Exception ex)
                {
                    throw new Exception("IgnoreUnterdruecken: " + ex.ToString());
                }
            }
        }

        public bool SelectDistinct
        {
            get { return _selectdistinct; }
            set
            {
                try
                {
                    _selectdistinct = value;
                    if (!DesignMode)
                        RefreshList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Selectdistinct: " + ex.ToString());
                }
            }
        }

        public int BerufsstandGruppeJNA
        {
            get
            {
                return this._BerufsstandGruppeJNA;
            }
            set
            {
                this._BerufsstandGruppeJNA = value;
            }
        }

		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid ID
		{
			get	
			{
				if (Value == null)
					return Guid.Empty;
				else
					return (Guid)Value;
			}
			set	
			{
				if (value == Guid.Empty)
					Value = null;
				else
					Value = value;
			}
		}
        public int ID_PEP
        {
            get
            {
                if (Value == null  || Value.Equals(Guid.Empty))
                    return -1;
                else
                    return  System.Convert.ToInt32 (Value);
            }
            set
            {
                if (value == -1)
                    Value = null;
                else
                    Value = value;
            }
        }
        public string TEXT
        {
            set
            {
                foreach (ValueListItem item in this.Items)
                {
                    if (item.DisplayText == value)
                    {
                        this.SelectedItem = item;
                        break;
                    }
                }
            }
        }

		private void addBtn_Click(object sender, EditorButtonEventArgs e)
		{
			object oldValue = Value;

			frmAuswahl frm = new frmAuswahl(Group);
			frm.ShowDialog();
			RefreshList();
            ENV.SignalAuswahlGruppeListChanged(Group);

			Value = oldValue;
		}

        private void AuswahlGruppeCombo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible && !this.VisibleIsInitialized)
                {
                    //this.DropDownStyle = DropDownStyle.DropDown;
                    //this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //this.AutoSuggestFilterMode = AutoSuggestFilterMode.Contains;

                    if (this.sys)
                    {
                    }
                    if (this.ExactMatch)
                    {
                    }

                    this.VisibleIsInitialized = true;
                }

            }
            catch (Exception ex)
            {

                PMDS.Global.ENV.HandleException(ex);
            }
        }

    }

}
