//----------------------------------------------------------------------------
/// <summary>
///	MassnahmenCombo.cs
/// Erstellt am:	15.11.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Windows.Forms;

using Infragistics.Win.UltraWinEditors;

using PMDS.Global;using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.BusinessLogic;



namespace PMDS.GUI.BaseControls
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// ComboBox für Massnahmen-Auswahl
	/// </summary>
	//----------------------------------------------------------------------------
	public class MedikamentCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{
        private PMDS.Global.db.Patient.dsMedikament.MedikamentSmallDataTable _medikament = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public MedikamentCombo()
		{
			if (ENV.AppRunning)
			{
				InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedikamentCombo));
            this.dsMedikament1 = new PMDS.Global.db.Patient.dsMedikament();
            ((System.ComponentModel.ISupportInitialize)(this.dsMedikament1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dsMedikament1
            // 
            this.dsMedikament1.DataSetName = "dsMedikament";
            this.dsMedikament1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsMedikament1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MedikamentCombo
            // 
            this.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            editorButton1.Appearance = appearance1;
            editorButton1.Key = "search";
            this.ButtonsRight.Add(editorButton1);
            this.DataMember = "MedikamentSmall";
            this.DataSource = this.dsMedikament1;
            this.DisplayMember = "Bezeichnung";
            this.ValueMember = "ID";
            this.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.MassnahmenCombo_EditorButtonClick);
            ((System.ComponentModel.ISupportInitialize)(this.dsMedikament1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		//----------------------------------------------------------------------------
		/// <summary>
		/// AuswahlListe neu aufbauen
		/// </summary>
		//----------------------------------------------------------------------------
		public override void RefreshList()
		{
			RefreshList(Guid.Empty);
		}

        private Global.db.Patient.dsMedikament dsMedikament1;

		//----------------------------------------------------------------------------
		/// <summary>
		/// AuswahlListe neu aufbauen und auf eine bestimmte ID setzen
		/// </summary>
		//----------------------------------------------------------------------------
		public void RefreshList(Guid IDToSet)
		{
			this.Items.Clear();

			try
			{
                PMDS.DB.DBMedikament m = new PMDS.DB.DBMedikament();
                m.LoadAllMedikamente(false);
                this.dsMedikament1 = PMDS.DB.DBMedikament._dsMedikament;
                this.Refresh();

				if(IDToSet != Guid.Empty)
					ID = IDToSet;
			}
			catch(Exception e)
			{
				ENV.HandleException(e);
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// ResourceString für Anzeigetext
		/// </summary>
		//----------------------------------------------------------------------------
		public string DISPLAY_TEXT 
		{
			set {_DisplayText = value;}
			get {return _DisplayText;}
		}
		private string _DisplayText = "";

		//----------------------------------------------------------------------------
		/// <summary>
		/// ID ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
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

		//----------------------------------------------------------------------------
		/// <summary>
		/// search Fenster öffnen
		/// </summary>
		//----------------------------------------------------------------------------
		private void MassnahmenCombo_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
		{
			if (e.Button.Key == "search")
			{
				frmPicker picker = new frmPicker(_medikament, "Bezeichnung", "ID", -1, false);
				picker.Text = DISPLAY_TEXT;
				if (picker.ShowDialog() == DialogResult.OK)
					ID = (Guid)picker.Value;
			}
		}
	}
}
