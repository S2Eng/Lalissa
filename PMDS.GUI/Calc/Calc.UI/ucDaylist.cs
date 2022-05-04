using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.UI.Sitemap;
using PMDS.Global.db.Patient;



namespace PMDS.Calc.UI
{
    public partial class ucDaylist : QS2.Desktop.ControlManagment.BaseControl
    {

        public PMDS.Calc.Logic.daylist _daylist;
        public PMDS.UI.Sitemap.UIFct sitemap;
        public bool isLoaded = false;



        public ucDaylist()
        {
            InitializeComponent();
        }

        public void  initControl()
        {
            if (this.isLoaded) return;

            this.sitemap = new UIFct();
            this._daylist = new PMDS.Calc.Logic.daylist();
             
            this.ucbill1.initControl(QS2.Desktop.Txteditor.etyp.calc);
            this.InitTimeContextMenu();
           
            this.isLoaded = true;
            PMDS.Global.ENV.evklinikChanged += new PMDS.Global.klinikChanged(this.klinikChanged);

            this.resizeControl();
        }
        public void klinikChanged( dsKlinik.KlinikRow rSelectedKlinik, bool allKliniken)
        {
            this.ucbill1.editor.clearForm();
        }

        private void InitTimeContextMenu()
        {
            this.sitemap.initTimeContextMenu();
            foreach (MenuItem item in this.sitemap.timemenu.MenuItems)
            {
                item.Click += new EventHandler(Timeitem_Click);
             }
        }

        private void Timeitem_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            PMDS.Global.timehelper h = (PMDS.Global.timehelper)item.Tag;
            this.dtMonat.DateTime = h._from;
            //this.loadDaylist();
        }

        public  void loadDaylist()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.dtMonat.Value == null)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Abrechnungsmonat ausgewählt!", "Abrechnen");
                    return;
                }

                this._daylist.run(this.dtMonat.DateTime, this.ucbill1.editor.textControl1, ENV.IDKlinik);
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

        private void ucDaylist_Load(object sender, EventArgs e)
        {

        }

        private void btnTimes_MouseUp(object sender, MouseEventArgs e)
        {
            this.sitemap.timemenu.Show(this, new Point(  btnTimes.Left, btnTimes.Top + btnTimes.Height));
        }

        private void btnErstellen_Click(object sender, EventArgs e)
        {
            this.loadDaylist();

        }

        private void ucDaylist_Resize(object sender, EventArgs e)
        {
            this.resizeControl();
        }
        private void resizeControl()
        {
           if (this.isLoaded ) this.ucbill1.ResizeControl(this.panelDaylist.Width, this.panelDaylist.Height);
        }

    }
}
