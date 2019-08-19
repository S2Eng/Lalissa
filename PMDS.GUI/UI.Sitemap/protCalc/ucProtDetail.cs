using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace PMDS.GUI
{


    public partial class ucProtDetail : QS2.Desktop.ControlManagment.BaseControl
    {

        public PMDS.Global .ucProtokoll  modalWindow;
        public  PMDS.Global .clTagInfoLog  _tg;


        public ucProtDetail()
        {
            InitializeComponent();
        }
        
        private void frmInfoProt_Load(object sender, EventArgs e)
        {
          
            
        }
        
        public void setData(string titel, string prot, PMDS.Global .clTagInfoLog tg )
        {
            if (titel != "") this.Text = titel;
            this.txtProtokoll2.Text    = prot;
            this._tg = tg;
        }
        public void setWithHeight( int w , int h )
        {
            this.Width = w;
            this.Height = Height;
        }
        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.modalWindow.panelAll.Visible  = true;
        }

        private void UFormLinkZurücksetzen_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(this.txtProtokoll2.Text, true);
        }

        private void abrechungsprotokollTabellenansicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                PMDS.Global.frmProtDS frmDS = new PMDS.Global.frmProtDS();

                System.IO .StringReader    xmlStringReader =  new System.IO .StringReader (this._tg.tabLog );
                System.Xml .XmlTextReader  xmlReader = new System.Xml .XmlTextReader(xmlStringReader);
                frmDS._db  .ReadXml(xmlReader  );
                xmlReader.Close();
                frmDS.addLogDS (false  );
                frmDS.Show();
            }
            catch (Exception ex)
            {
               PMDS.Global .ENV .HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void txtProtokoll2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true  ;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.modalWindow.mainWindow.Close();
        }

        private void zusätzlicheRechnungsfelderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                PMDS.Global.frmProtDS frmDS = new PMDS.Global.frmProtDS();

                System.IO.StringReader xmlStringReader = new System.IO.StringReader(this._tg.tabLogFields);
                System.Xml.XmlTextReader xmlReader = new System.Xml.XmlTextReader(xmlStringReader);
                frmDS._db.ReadXml(xmlReader);
                xmlReader.Close();
                frmDS.addLogDS(false);
                frmDS.Show();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }



    }
}
