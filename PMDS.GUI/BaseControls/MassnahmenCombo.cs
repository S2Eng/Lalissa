using System;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using PMDS.Global;using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.BusinessLogic;
using PMDS.Global.db.Pflegeplan;



namespace PMDS.GUI.BaseControls
{


	public class MassnahmenCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{
		private dsEintrag.EintragDataTable _massnahmen = null;
      

        
        
		public MassnahmenCombo()
		{
			if (ENV.AppRunning)
			{
				InitializeComponent();
				RefreshList();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MassnahmenCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// MassnahmenCombo
			// 
            this.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
			appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
			editorButton1.Appearance = appearance1;
			editorButton1.Key = "search";
			this.ButtonsRight.Add(editorButton1);
			this.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.MassnahmenCombo_EditorButtonClick);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion





		public override void RefreshList()
		{
			this.Items.Clear();
			try
			{
                if (!PMDS.GUI.frmPatientRueckmeldungLine.IsSchnellrückmeldung)
                {
                    _massnahmen = new PDx().KATALOGE['M'].EINTRAEGE;
                    foreach (dsEintrag.EintragRow kr in _massnahmen)
                        this.Items.Add(kr.ID, kr.Text);
                }

            }
			catch(Exception e)
			{
				ENV.HandleException(e);
			}
		}

        public void RefreshListMedikationOnly()
        {
            this.Items.Clear();
            try
            {
                if (!PMDS.GUI.frmPatientRueckmeldungLine.IsSchnellrückmeldung)
                {
                    _massnahmen = new PDx().KATALOGE['M'].EINTRAEGE;
                    foreach (dsEintrag.EintragRow kr in _massnahmen)
                        if (kr.BedarfsMedikationJN)
                            this.Items.Add(kr.ID, kr.Text);
                }

            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }

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
			if (e.Button.Key == "search")
			{
				frmPicker picker = new frmPicker(_massnahmen, "Text", "ID", -1, false);
				picker.Text = ENV.String("GUI.SEARCH_MASSNAHME");
				if (picker.ShowDialog() == DialogResult.OK)
				{
					ID = (Guid)picker.Value;
					for(int i = 0; i< this.Items.Count; i++)
					{
						if(this.Items[i].DataValue.Equals(this.ID))
							this.SelectedItem = this.Items[i];
					}
				}
			}
		}

	}
}
