//----------------------------------------------------------------------------
/// <summary>
///	MassnahmenSerienCombo2.cs
/// Erstellt am:	31.05.2007
/// Erstellt von:	MDA
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Windows.Forms;

using Infragistics.Win.UltraWinEditors;

using PMDS.Global;
using PMDS.Data.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Patient;
using PMDS.Global.db.Patient;

namespace PMDS.GUI.BaseControls
{
    public partial class MassnahmenSerienCombo2 : Infragistics.Win.UltraWinEditors.UltraComboEditor
    {
        private Massnahmenserien _manager;
        private dsMassnahmenserien.MassnahmenserienDataTable _dt;

        //----------------------------------------------------------------------------
        /// <summary>
        /// Konstruktor
        /// </summary>
        //----------------------------------------------------------------------------
        public MassnahmenSerienCombo2()
        {
            if (ENV.AppRunning)
            {
                Value = null;
                InitializeComponent();
                _manager = new Massnahmenserien();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// AuswahlListe neu aufbauen
        /// </summary>
        //----------------------------------------------------------------------------
        public override void RefreshList()
        {
            RefreshList(Guid.Empty);
        }

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
                _manager.Read();
                _dt = _manager.Serien;

                foreach (dsMassnahmenserien.MassnahmenserienRow r in _dt)
                    this.Items.Add(r.ID, r.Bezeichnung);
                if (IDToSet != Guid.Empty)
                    ID = IDToSet;
            }
            catch (Exception e)
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
            set { _DisplayText = value; }
            get { return _DisplayText; }
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
            if (e.Button.Key == "Add")
            {
                frmMassnahmenserien frm = new frmMassnahmenserien();
                if (frm.ShowDialog() == DialogResult.OK)
                    RefreshList(ID);
                //frmPicker picker = new frmPicker(_dt, "Bezeichnung", "ID");
                //picker.Text = DISPLAY_TEXT;
                //if (picker.ShowDialog() == DialogResult.OK)
                //    ID = (Guid)picker.Value;
            }
        }
    }
}
