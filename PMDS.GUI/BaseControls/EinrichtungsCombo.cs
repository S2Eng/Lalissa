using System;
using System.Windows.Forms;
using PMDS.Global;using PMDS.Data.Global;
using PMDS.BusinessLogic;
using Infragistics.Win.UltraWinEditors;
using PMDS.Global.db.Global;


namespace PMDS.GUI.BaseControls
{

	public class EinrichtungsCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{
		private EditorButton _addBtn2 = new EditorButton("");
        public bool IsInitialized { get; set; }
        public bool NotKrankenkasse { get; set; }
        public bool PSBOnly { get; set; }
        public bool DischLotcnOnly { get; set; }
        public EinrichtungsCombo()
		{
            //lthIntIntegrieren
            // Recht notwendig
            RefreshList();
		}

        public void checkButtons()
        {
            //lthIntIntegrieren
            if (!this.IsInitialized)
            {
                this.ButtonsRight.Clear();
                if (ENV.HasRight(UserRights.Stammdatenverwaltung))
                {
                    _addBtn2.Text = "+";
                    _addBtn2.Click += new EditorButtonEventHandler(addBtn_Click);
                    this.ButtonsRight.Add(_addBtn2);
                    this.IsInitialized = true;
                }
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// ReadOnly überschreiben
        /// </summary>
        //----------------------------------------------------------------------------
        public new bool ReadOnly
		{
			get	{	return base.ReadOnly;				}
			set	
			{
                // Edit Button entfernen
                _addBtn2.Visible = !value;	
				base.ReadOnly = value;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// AuswahlListe neu aufbauen
		/// </summary>
		//----------------------------------------------------------------------------
		public override void RefreshList()
		{
			this.Items.Clear();
			try
			{
                if (ENV.AppRunning)
                {
                    dsGUIDListe.IDListeDataTable t = Einrichtung.All(NotKrankenkasse, PSBOnly, DischLotcnOnly);
                    foreach (dsGUIDListe.IDListeRow r in t)
                        this.Items.Add(r.ID, r.TEXT);
                }

			}
			catch(Exception e)
			{
				ENV.HandleException(e);
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neue Einrichtung erfassen
		/// </summary>
		//----------------------------------------------------------------------------
		private void addBtn_Click(object sender, EditorButtonEventArgs e)
		{
			object oldValue = Value;

            frmEinrichtung frm = new frmEinrichtung();
            frm.initControl();
            frm.ShowDialog();
//            new frmEinrichtung().ShowDialog();


			RefreshList();

			Value = oldValue;
		}

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // EinrichtungsCombo
            // 
            this.VisibleChanged += new System.EventHandler(this.EinrichtungsCombo_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void EinrichtungsCombo_VisibleChanged(object sender, EventArgs e)
        {

        }
    }

}
