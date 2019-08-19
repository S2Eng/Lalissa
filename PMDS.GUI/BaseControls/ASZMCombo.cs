using System;
using System.ComponentModel;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Global.db.Pflegeplan;


namespace PMDS.GUI.BaseControls
{
    

	public class ASZMCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{
		private dsEintrag.EintragDataTable _massnahmen = null;
        public int EntferntJN = -1;
        public bool AlwaysRefresh = false;
        public bool AlleEinträge = false;
        public Infragistics.Win.DropDownStyle dropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;





        public ASZMCombo()
		{
			if (ENV.AppRunning)
			{
				InitializeComponent();

                this.ButtonsRight["List"].Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);
                this.ButtonsRight["List"].Visible = false;
			}
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("search");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ASZMCombo));
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton("List");
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ASZMCombo
            // 
            this.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            editorButton1.Appearance = appearance1;
            editorButton1.Key = "search";
            editorButton2.Key = "List";
            this.ButtonsRight.Add(editorButton1);
            this.ButtonsRight.Add(editorButton2);
            this.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.MassnahmenCombo_EditorButtonClick);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

		}
        #endregion


        public void setUI(bool showButtonList)
        {
            try
            {
                this.ButtonsRight["List"].Visible = showButtonList;

            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }
        public override void RefreshList()
		{
			this.Items.Clear();
			try
			{
                PDx pdxTmp = new PDx();
                pdxTmp.KATALOGE[_group.ToString()[0]].AlleEinträge = this.AlleEinträge;
                _massnahmen = pdxTmp.KATALOGE[_group.ToString()[0]].EINTRAEGE;
                foreach (dsEintrag.EintragRow kr in _massnahmen)
                {
                    if (kr.EntferntJN)
                    {
                        bool IsEntfernt = true;
                    }

                    bool AddItem = false;
                    if (this.EntferntJN == -1)
                    {
                        AddItem = true;
                    }
                    else
                    {
                        if (this.EntferntJN == 0 && !kr.EntferntJN)
                        {
                            AddItem = true;
                        }
                        else if (this.EntferntJN == 1 && kr.EntferntJN)
                        {
                            AddItem = true;
                        }
                    }

                    if (AddItem)
                    {
                        string Warnhinweis = "";
                        if (kr.Warnhinweis != null && kr.Warnhinweis.Trim() != "")
                        {
                            Warnhinweis = " (" + kr.Warnhinweis.Trim() + ")";
                        }
                        this.Items.Add(kr.ID, kr.Text + Warnhinweis);
                    }
                }

                this.DropDownStyle = dropDownStyle;

            }
			catch(Exception e)
			{
				ENV.HandleException(e);
			}
		}

		public void RefreshList(Guid IDToSet)
		{
			this.Items.Clear();

			try
			{
				RefreshList();
				if(IDToSet != Guid.Empty)
					ID = IDToSet;
			}
			catch(Exception e)
			{
				ENV.HandleException(e);
			}
		}

		public EintragGruppe GROUP 
		{
			set 
			{
				if(value != _group || this.AlwaysRefresh) 
				{
					_group = value;
					RefreshList();
                    this.AlwaysRefresh = false;
                }
			}
			get {return _group;}
		}
		private EintragGruppe _group = EintragGruppe.M;

		public string DISPLAY_TEXT 
		{
			set {_DisplayText = value;}
			get {return _DisplayText;}
		}
		private string _DisplayText = "***Text not set***";

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

		private void MassnahmenCombo_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
		{
            try
            {
                if (e.Button.Key == "search")
                {
                    frmPicker picker = new frmPicker(_massnahmen, "Text", "ID", -1, false, true);
                    picker.Text = DISPLAY_TEXT;
                    if (picker.ShowDialog() == DialogResult.OK)
                    {
                        ID = (Guid)picker.Value;

                        for (int i = 0; i < this.Items.Count; i++)
                        {
                            if (this.Items[i].DataValue.Equals(this.ID))
                                this.SelectedItem = this.Items[i];
                        }

                    }
                }
                else if (e.Button.Key == "List")
                {
                    frmEintraegeQuickEdit frmASZMQuickEdit1 = new frmEintraegeQuickEdit();
                    frmASZMQuickEdit1.initControl(this.GROUP.ToString(), this.EntferntJN, this.Text.Trim());
                    frmASZMQuickEdit1.ShowDialog(this);
                    if (!frmASZMQuickEdit1.contASZMQuickEdit1.abort)
                    {
                        this.RefreshList();
                    }

                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

	}

}

