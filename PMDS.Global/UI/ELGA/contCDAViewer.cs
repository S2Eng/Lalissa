using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMDS.Global;
using System.IO;

namespace PMDS.GUI.ELGA
{

    public partial class contCDAViewer : UserControl
    {
        private string _Xml = "";
        private string _typeFile = "";
        public frmCDAViewer mainWindow = null;


        public contCDAViewer()
        {
            InitializeComponent();
        }

        public void initControl(string Xml, string typeFile)
        {
            try
            {
                this._Xml = Xml;
                this._typeFile = typeFile;

            }
            catch (Exception ex)
            {
                throw new Exception("contCDAViewer.initControl: " + ex.ToString());
            }
        }
        public void loadFile()
        {
            try
            {
                string pTmp = System.IO.Path.Combine(ENV.path_Temp, "CDA");
                string fStyle = System.IO.Path.Combine(pTmp, "ELGA_Stylesheet_v1.0.xsl");
                if (!System.IO.Directory.Exists(pTmp))
                {
                    Directory.CreateDirectory(pTmp);
                }
                if (!System.IO.File.Exists(fStyle))
                {
                    System.IO.File.Copy(@ENV.pathConfig + "\\ELGA_Stylesheet_v1.0.xsl", fStyle);
                }

                string fileXml = Path.Combine(pTmp, _typeFile + "_" + System.Guid.NewGuid().ToString() + ".xml");
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@fileXml, false))
                {
                    file.Write(_Xml);
                }

                this.webBrowser1.Navigate(@fileXml);
            }
            catch (Exception ex)
            {
                throw new Exception("contCDAViewer.loadFile: " + ex.ToString());
            }
        }

        private void ContCDAViewer_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    this.loadFile();
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

    }

}
