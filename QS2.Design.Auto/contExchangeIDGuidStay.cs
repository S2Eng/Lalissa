using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace qs2.ui
{
    public partial class contExchangeIDGuidStay : UserControl
    {
        private bool ExchangeModeExport { get; set; } = true;
        private string IDStayGuid { get; set; } = "";
        private string RecordInfo { get; set; } = "";
        private SaveFileDialog FileDialogSave { get; set; } = new SaveFileDialog();
        private OpenFileDialog FileDialogOpen { get; set; } = new OpenFileDialog();
        private string FileDialogFilter { get; set; } = "Text|*.txt";      
        private int ID { get; set; } = -1;
        private string IDParticipant { get; set; } = "";
        private string IDApplication { get; set; } = "";




        public contExchangeIDGuidStay()
        {
            InitializeComponent();
        }

        public bool Init(bool ExchangeModeExportIn, string RecordInfoIn, qs2.core.vb.dsObjects.tblStayRow rIn)
        {
            if (rIn == null) throw new ArgumentNullException(nameof(rIn));

            ExchangeModeExport = ExchangeModeExportIn;
            RecordInfo = RecordInfoIn;
            IDStayGuid = rIn.IDGuid.ToString();
            ID = rIn.ID;
            IDParticipant = rIn.IDParticipant;
            IDApplication = rIn.IDApplication;

            pnlImport.Visible = !ExchangeModeExport;

            lblRecordInfo.Text = RecordInfo;
            lblIDStayGuid.Text = qs2.core.generic.TranslateEx("KeyValue");
            txtIDStayGuid.Text = ExchangeModeExportIn ? IDStayGuid.ToString() : "";
            btnAction.Text = qs2.core.generic.TranslateEx(ExchangeModeExportIn ? "Export" : "Import");
            rbClipboard.Text = qs2.core.generic.TranslateEx(ExchangeModeExportIn ? "ToClipboard" : "FromClipboard");
            rbAsChild.Text = qs2.core.generic.TranslateEx("AsChild");
            rbAsParent.Text = qs2.core.generic.TranslateEx("AsParent");
            rbFile.Text = qs2.core.generic.TranslateEx(ExchangeModeExportIn ? "ToFile" : "FromFile");
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Guid.TryParse(txtIDStayGuid.Text, out _))
                {
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NotAGuid"), System.Windows.Forms.MessageBoxButtons.OK, "");
                }

                if (rbAsParent.Checked)
                {
                    using (qs2.core.BAL.ImpExpStayKey qb = new qs2.core.BAL.ImpExpStayKey())
                    {
                        qb.Init(IDApplication, IDParticipant);
                        if (qb.SetValue(ID, "IDPredecessor", txtIDStayGuid.Text) == 1)
                            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("Done"), System.Windows.Forms.MessageBoxButtons.OK, "");
                        else
                            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NotOk"), System.Windows.Forms.MessageBoxButtons.OK, "");
                    }
                }
                else
                {
                    using (qs2.core.BAL.ImpExpStayKey qb = new core.BAL.ImpExpStayKey())
                    {
                        qb.Init(IDApplication, IDParticipant);
                        var RetValue = (string)qb.GetValue(ID, "IDSucessors");
                        
                        if (RetValue != null && RetValue.GetType() == typeof(System.String))
                        {
                            string[] ArrChilds = RetValue.Split(new char[';'], StringSplitOptions.RemoveEmptyEntries);
                            if (!ArrChilds.Contains("txtIDStayGuid.Text" + ";"))
                            {
                                qb.SetValue(ID, "IDSucessors", RetValue + txtIDStayGuid.Text + ";");
                                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("Done"), System.Windows.Forms.MessageBoxButtons.OK, "");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                switch (ExchangeModeExport)
                {
                    case true:      //Export
                        if (!Guid.TryParse(txtIDStayGuid.Text, out _))
                        {
                            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NotAGuid"), System.Windows.Forms.MessageBoxButtons.OK, "");
                        }

                        if (rbClipboard.Checked)        //to Clipboard
                        {
                            System.Windows.Forms.Clipboard.SetText(txtIDStayGuid.Text);
                            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("Done"), System.Windows.Forms.MessageBoxButtons.OK, "");
                        }
                        else                           //to File
                        {
                            FileDialogSave.Title = qs2.core.generic.TranslateEx("SaveIDStayGuidToFile");
                            FileDialogSave.Filter = FileDialogFilter;
                            FileDialogSave.ShowDialog();
                            if (!string.IsNullOrWhiteSpace(FileDialogSave.FileName))
                            {
                                System.IO.File.WriteAllText(FileDialogSave.FileName, txtIDStayGuid.Text);
                                if (System.IO.File.Exists(FileDialogSave.FileName))
                                {
                                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("Done"), System.Windows.Forms.MessageBoxButtons.OK, "");
                                }
                                else
                                {
                                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NotOk"), System.Windows.Forms.MessageBoxButtons.OK, "");
                                }
                            }
                        }
                        break;

                    case false:                         //Import
                        if (rbClipboard.Checked)        //from Clipboard
                        {
                            if (Guid.TryParse(System.Windows.Forms.Clipboard.GetText(), out _))
                                txtIDStayGuid.Text = System.Windows.Forms.Clipboard.GetText();
                            else
                                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NotAGuid"), System.Windows.Forms.MessageBoxButtons.OK, "");
                        }
                        else                            //from File
                        {
                            FileDialogOpen.Title = qs2.core.generic.TranslateEx("GetIDStayGuidFromFile");
                            FileDialogSave.Filter = FileDialogFilter;
                            FileDialogOpen.ShowDialog();
                            if (!string.IsNullOrWhiteSpace(FileDialogOpen.FileName) && System.IO.File.Exists(FileDialogOpen.FileName))
                            {
                                txtIDStayGuid.Text = System.IO.File.ReadAllText(FileDialogOpen.FileName).Trim();
                            }
                            else
                            {
                                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NotOk"), System.Windows.Forms.MessageBoxButtons.OK, "");
                            }
                        }
                        break;

                    default:
                        qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NotImplemented"), System.Windows.Forms.MessageBoxButtons.OK, "");
                        break;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
            }
        }
    }
}
