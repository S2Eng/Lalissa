using System;
using Infragistics.Win.UltraWinEditors;


namespace qs2.sitemap.ownControls.inherit_Infrag
{
    public class InfragCheckBox : UltraCheckEditor
    {
        public event dAfterCheckStateChanged evOnAfterCheckStateChanged;
        public delegate void dAfterCheckStateChanged(object sender, EventArgs e);
        
        public int OwnCheckStateInt
        {
            get
            {
                if (this.CheckState == System.Windows.Forms.CheckState.Unchecked)
                    return 0;
                else if (this.CheckState == System.Windows.Forms.CheckState.Checked)
                    return 1;
                else
                    return -1;
            }
            set
            {
                switch (value)
                {
                    case 0:
                        this.CheckState = System.Windows.Forms.CheckState.Unchecked;
                        break;
                    case 1:
                        this.CheckState = System.Windows.Forms.CheckState.Checked;
                        break;
                    default:
                        this.CheckState = System.Windows.Forms.CheckState.Indeterminate;
                        break;
                }
            }
        }

        public int OwnTabIndex
        {
            set => base.TabIndex = value;
        }

        public void ControlAfterCheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Focused)
                {
                    switch (this.CheckState)
                    {
                        case System.Windows.Forms.CheckState.Unchecked:
                            this.OwnCheckStateInt = 0;
                            break;
                        case System.Windows.Forms.CheckState.Checked:
                            this.OwnCheckStateInt = 1;
                            break;
                        default:
                            this.OwnCheckStateInt = -1;
                            break;
                    }
                    this.evOnAfterCheckStateChanged?.Invoke(sender, e);
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void Enter(object sender, EventArgs e)
        {
            try
            {
                this.Focus();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public  void initControl()
        {
            this.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.ControlAfterCheckStateChanged);
            base.Enter += new System.EventHandler(this.Enter);
        }
    }
}
