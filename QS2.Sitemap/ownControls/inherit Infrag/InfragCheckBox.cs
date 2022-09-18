using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.FormattedLinkLabel;
using Infragistics.Win;
using Infragistics.Win.Misc;




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
                if (value == 0)
                    this.CheckState = System.Windows.Forms.CheckState.Unchecked;
                else  if (value == 1)
                    this.CheckState = System.Windows.Forms.CheckState.Checked;
                else
                    this.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            }
        }
        public int OwnTabIndex
        {
            get
            {
                return base.TabIndex;
            }
            set
            {
                base.TabIndex = value;
            }
        }

        public void ControlAfterCheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Focused)
                {
                    if (this.CheckState == System.Windows.Forms.CheckState.Unchecked)
                        this.OwnCheckStateInt = 0;
                    else if (this.CheckState == System.Windows.Forms.CheckState.Checked)
                        this.OwnCheckStateInt = 1;
                    else
                    {
                        this.OwnCheckStateInt = -1; 
                    }

                    if (this.evOnAfterCheckStateChanged != null)
                        this.evOnAfterCheckStateChanged.Invoke(sender, e);
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
        public void Leave(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
        public  void initControl()
        {
            this.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.ControlAfterCheckStateChanged);
            base.Enter += new System.EventHandler(this.Enter);
            base.Leave += new System.EventHandler(this.Leave);
        }

    }
}
