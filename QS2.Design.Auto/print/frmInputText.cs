using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace qs2.design.auto.print
{


    public partial class frmInputText : Form
    {

        public bool abort = true;

        


        public frmInputText()
        {
            InitializeComponent();
        }

        private void frmInputText_Load(object sender, EventArgs e)
        {

        }


        public void initControl()
        {
            try
            {
                //this.AcceptButton = this.btnOk;
                this.CancelButton = this.btnAbort;

                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.ePicture.ico_lock, 32, 32);
                this.Text = qs2.core.language.sqlLanguage.getRes("InputText");

                this.btnOk.Text = qs2.core.language.sqlLanguage.getRes("OK");

            }
            catch (Exception ex)
            {
                throw new Exception("frmInputText:initControl: " + ex.ToString());
            }
        }

        public void loadData(string txtValueMin, qs2.core.Enums.eControlType controlTypeINCondition)
        {
            try
            {
                this.txtText.Text = "";
                if (txtValueMin.Trim().StartsWith("("))
                {
                    txtValueMin = txtValueMin.Trim().Substring(1, txtValueMin.Trim().Length - 1);
                }
                if (txtValueMin.Trim().EndsWith(")"))
                {
                    txtValueMin = txtValueMin.Trim().Substring(0, txtValueMin.Trim().Length - 1);
                }

                string[] sVars = txtValueMin.Trim().Split(',');
                if (sVars.Length > 0)
                {
                    for (int i = 0; i < sVars.Length; i++)
                    {
                        string sVar = sVars[i];
                        if (sVar.Trim() != "")
                        {
                            if (sVar.Trim().StartsWith(("'")))
                            {
                                sVar = sVar.Trim().Substring(1, sVar.Trim().Length - 1);
                            }
                            if (sVar.Trim().EndsWith(("'")))
                            {
                                sVar = sVar.Trim().Substring(0, sVar.Trim().Length - 1);
                            }

                            this.txtText.Text += sVar.Trim() + "\r\n";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmInputText:loadData: " + ex.ToString());
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = false;
                this.Close();

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = true;
                this.Close();

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmInputText_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    this.txtText.SelectionStart = 0;
                    this.txtText.SelectionLength = 0;
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
    }

}
