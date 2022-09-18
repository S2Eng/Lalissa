using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qs2.design.auto.multiControl
{

    public partial class frmMCHelp : Form
    {
        private string App { get; set; }
        private string FldShort { get; set; }
        private string HelpText { get; set; }
        private static Size MaxClientSize { get; } = new Size(900, 700);
        private static Size MinClientSize { get; } = new Size(400, 15);
        private const float MaxFontSize = 11;
        private const float MinFontSize = 8;
        private const int TxtPadding = 10;
        private static string NoHelp { get; } = qs2.core.language.sqlLanguage.getRes("NoHelpAvailableForField");




        public frmMCHelp()
        {
            InitializeComponent();
        }

        public void initControl(string FldShortIn, string AppIn)
        {
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.ePicture.ico_Ressourcen, 32, 32);

            App = AppIn;
            FldShort = FldShortIn;
            txtHelp.Text = "";
            HelpText = GetHelpText();
        }

        public string  GetHelpText()
        {
            using (QS2.db.Entities.ERModellQS2Entities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
            {
                qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;

                string fldtrans = qs2.core.language.sqlLanguage.getRes(FldShort.Trim(), core.Enums.eResourceType.Label,
                                    qs2.core.license.doLicense.rParticipant.IDParticipant,
                                    qs2.core.license.doLicense.rApplication.IDApplication, ref rLangFoundReturn,
                                    true, true, core.language.sqlLanguage.eLanguage.NoText,
                                    false).Trim();
                string fldtmp = (string.IsNullOrEmpty(fldtrans) ? FldShort : fldtrans);
                this.Text = qs2.core.language.sqlLanguage.getRes("HelpForField") + " " + fldtmp;

                var rRes = (from r in qs2.core.language.sqlLanguage.dsLanguageAll.Ressourcen
                            where r.IDRes == FldShort && r.IDApplication == App && r.Type == "Help" && r.IDLanguageUser == "ALL" && r.IDParticipant == "ALL"
                            select new{ r.IDRes, r.German, r.English}).FirstOrDefault();

                if (rRes != null)
                {
                    return !String.IsNullOrWhiteSpace(rRes.German) ? rRes.German : NoHelp;
                }
                else
                    return NoHelp;
            }
        }

        private void frmMCHelp_Paint(object sender, PaintEventArgs e)
        {
            for (float fSize = MaxFontSize; fSize >= MinFontSize; fSize--)
            {
                Font Arial = new Font("Arial", fSize);
                Size textSize = TextRenderer.MeasureText(HelpText, Arial);
                Size ActClientSize = new Size(textSize.Width, textSize.Height);
                TextFormatFlags TxtFlags = TextFormatFlags.Left |  TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;

                if (ActClientSize.Width <= MaxClientSize.Width && ActClientSize.Height <= MaxClientSize.Height)
                {
                    TextRenderer.DrawText(e.Graphics, HelpText, Arial, new Rectangle(new Point(TxtPadding, TxtPadding), textSize), Color.Black, TxtFlags);
                    this.ClientSize = new Size(Math.Max(textSize.Width, MinClientSize.Width) + 2 * TxtPadding, Math.Max(textSize.Height, MinClientSize.Height) + 2 * TxtPadding);
                    txtHelp.Visible = false;
                    return;
                }
            }
            txtHelp.Text = HelpText;
        }

        private void frmMCHelp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}


