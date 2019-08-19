using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Infragistics.Win.UltraWinEditors;
using PMDS.Global;

namespace PMDS.GUI
{
    public partial class dtCombo : UltraComboEditor
    {
        public dtCombo()
        {
            InitializeComponent();
        }

        public dtCombo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            if (DesignMode || !ENV.AppRunning)
                return;
            MaxDropDownItems = 24;
            RefreshList();

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
                DateTime dtStart = DateTime.Now;
                DateTime dt = dtStart;
                this.Items.Clear();
                
                while ((dt.Year == dtStart.Year) ||
                        (dt.Year == dtStart.Year - 1 && (dt.Month >= 1 && dt.Month <= 12))
                      )
                {
                    this.Items.Add(dt, dt.Date.ToString("MM.yyyy"));
                    dt = dt.AddMonths(-1);
                }

            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }
        //protected override void OnAfterExitEditMode(object sender, EventArgs args)
        //{
        //    if (Text.Trim().Length > 0 && Text.Trim().Length < 7)
        //        Text = "";
        //    base.OnAfterExitEditMode(sender, args);
        //}

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            int x = 0;
            if ((e.KeyChar != '\b' && e.KeyChar != '\r' && e.KeyChar != '.' && !int.TryParse(e.KeyChar.ToString(), out x)))
            {
                e.Handled = true;
                return;
            }
            else if (SelectionLength == 0 && Text.Trim().Length == 7 && e.KeyChar != '\b' && e.KeyChar != '\r')
            {
                e.Handled = true;
                return;
            }
            else
            {
                if (e.KeyChar == '.' && Text.Trim().Length == 1)
                {
                    if (Text.Trim() == "0")
                    {
                        e.Handled = true;
                        return;
                    }
                    
                    Text = "0" + Text.Trim() + ".";
                    this.SelectionStart = Text.Length;
                    e.Handled = true;
                    
                }
                else if (Text.Length == 1 && int.TryParse(e.KeyChar.ToString(), out x))
                {
                    if (Text != "0" && x > 2)
                    {
                        e.Handled = true;
                        return;
                    }
                    else if (Text == "0" && x == 0)
                    {
                        e.Handled = true;
                        return;
                    }
                    else
                    {
                        Text = Text.Trim() + x.ToString() + ".";
                        SelectionStart = Text.Length;
                        e.Handled = true;
                    }
                }
                else if(Text.Length > 0 && int.TryParse(e.KeyChar.ToString(), out x))
                {
                    if(SelectionStart == 0 && x > 1)
                    {
                        e.Handled = true;
                        return;
                    }
                    if(SelectionStart == 1 && (x == 0 || x > 2))
                    {
                        e.Handled = true;
                        return;
                    }
                    else if (SelectionStart == 2 && e.KeyChar != '.')
                    {
                        if (Text.Length <= SelectionStart)
                        {
                            Text = Text.Trim() + "." + x.ToString();
                            SelectionStart = Text.Length;
                            e.Handled = true;
                        }
                        else
                        {
                            Text = Text.Insert(2, ".");
                            Text = Text.Insert(3, x.ToString());
                            SelectionStart = 4;
                            e.Handled = true;
                        }
                    }
                }
            }
        }
        
    }
}
