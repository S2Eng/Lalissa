using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global;
using System.IO;
using System.Diagnostics;
using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{
    //----------------------------------------------------------------------------
    /// <summary>
    /// Verwaltung der Medizinischen typen
    /// </summary>
    //----------------------------------------------------------------------------
    public partial class frmEditLinkDokumente : QS2.Desktop.ControlManagment.baseForm 
    {
        private LinkDokumente _doc = new LinkDokumente();
        private dsLinkDokumente.LinkDokumenteDataTable _dt;

        public frmEditLinkDokumente()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Load
        /// </summary>
        //----------------------------------------------------------------------------
        private void frmEditLinkDokumente_Load(object sender, EventArgs e)
        {
            _dt = _doc.ALL;
            FillDatagrid();

            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Datengrid aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void FillDatagrid()
        {
            bindingSource1.DataSource = _dt;
            bindingSource1.DataMember = "";
            
        }

        private void bindingSource1_AddingNew(object sender, AddingNewEventArgs e)
        {
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Speichern
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnOK_Click(object sender, EventArgs e)
        {
            _doc.Update(_dt);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Neuen Satz hinzufügen
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dsLinkDokumente.LinkDokumenteRow r = _doc.NewRow(_dt);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die aktuelle sekektierte Row
        /// </summary>
        //----------------------------------------------------------------------------
        private dsLinkDokumente.LinkDokumenteRow CURRENT
        {
            get
            {
                if (dataGridView1.CurrentRow == null)
                    return null;
                DataRowView v = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                dsLinkDokumente.LinkDokumenteRow r = (dsLinkDokumente.LinkDokumenteRow)v.Row;
                return r;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Zeile löschen
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null) 
            {
                DataRowView v = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                dsLinkDokumente.LinkDokumenteRow r = (dsLinkDokumente.LinkDokumenteRow)v.Row;
                r.Delete();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Icon festlegen
        /// </summary>
        //----------------------------------------------------------------------------
        private void iconHochladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            DialogResult res = openFileDialog1.ShowDialog();
            if (res != DialogResult.OK)
                return;

            string sFile = openFileDialog1.FileName;
            if (!File.Exists(sFile))
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datei "  + sFile +" existiert nicht");
                return;
            }

            CURRENT.Dokument = File.ReadAllBytes(sFile);
            CURRENT.LinkName = Path.GetFileName(openFileDialog1.FileName);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Icon löschen
        /// </summary>
        //----------------------------------------------------------------------------
        private void iconLöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            CURRENT.SetDokumentNull();
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Anzeigen eines Dokumentes
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (CURRENT == null)
                return;
            if (CURRENT.LinkName.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                ProcessHyperlink();
            else
                PMDS.GUI.GuiUtil.ShowDocumentFromByteStream(CURRENT.Dokument, Path.GetExtension(CURRENT.LinkName).ToLower());

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Hyperlink im Standardbrowser aufmachen
        /// </summary>
        //----------------------------------------------------------------------------
        private void ProcessHyperlink()
        {
            try
            {
                Process.Start(CURRENT.LinkName);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Dokument speichern
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CURRENT == null || CURRENT.LinkName.StartsWith("http", StringComparison.OrdinalIgnoreCase) || CURRENT.IsDokumentNull())
                return;

            try
            {
                saveFileDialog1.DefaultExt = Path.GetExtension(CURRENT.LinkName).ToLower();
                saveFileDialog1.FileName = CURRENT.LinkName;
                DialogResult res = saveFileDialog1.ShowDialog();
                if (res != DialogResult.OK)
                    return;

                File.WriteAllBytes(saveFileDialog1.FileName, CURRENT.Dokument);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

    }
}