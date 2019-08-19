using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Data.PflegePlan;
using Infragistics.Win.Misc;
using Infragistics.Win;
using VirtualKeyboard;

namespace PMDS.GUI
{
    public partial class ucQMButton : QS2.Desktop.ControlManagment.BaseControl
    {
        public new event QMButtonClickDelegate          Click;
        public new event QMButtonDoubleClickDelegate    DoubleClick;

        public ucQM modalWIndow;

        public QMEintrag _QMEintrag;
        private int  intAnzButtons = 0;



        public ucQMButton()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Konstruktor
        /// </summary>
        //----------------------------------------------------------------------------
        public ucQMButton(QMEintrag qmeintrag)
        {
            _QMEintrag = qmeintrag;
            InitializeComponent();
            RefreshControl();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Das Control aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        public  void RefreshControl()
        {
            lblMain.Text = _QMEintrag.Firsttext;
            bool bUntertaegig = _QMEintrag.COUNT > 1;
            RefreshButtons();
            RefreshColors();

        }


        public Color REDCOLOR
        {
            get
            {
                return Color.FromArgb(255, 192, 192);
            }
        }

        public Color YELLOWCOLOR
        {
            get
            {
                return Color.FromArgb(255, 255, 192);
            }
        }

        public Color GREEENCOLOR
        {
            get
            {
                return Color.FromArgb(192, 255, 192);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Die Farben aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshColors()
        {
            if (intAnzButtons > 0)
            {
                this.BackColor = System.Drawing.Color.WhiteSmoke;
                lblMain.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            }

            if (_QMEintrag.COUNT == 1)
            {
                dsPflegePlan.PflegePlanRow r = _QMEintrag._pprows[0].r;

                if (r.OhneZeitBezug)
                {
                    lblMain.Appearance.BackColor = YELLOWCOLOR;
                }
                else
                {
                    if (_QMEintrag._pprows[0].rIntervention.vonDatum < DateTime.Now)
                        lblMain.Appearance.BackColor = REDCOLOR;
                    else
                        lblMain.Appearance.BackColor = Color.WhiteSmoke;
                    if (PMDS.DB.DBPflegeEintrag.IsToDaySigned(_QMEintrag._pprows[0].r.ID))
                        lblMain.Appearance.BackColor = GREEENCOLOR;
                }
                lblZeitbereich.Appearance.BackColor = lblMain.Appearance.BackColor;
            }
            else
            {
                foreach (UltraButton b in pnlButtons.Controls)
                {
                    QMEintrag.cPflegepläneProButton PflegepläneProButton = (QMEintrag.cPflegepläneProButton)b.Tag;
                    if (PflegepläneProButton.rIntervention.vonDatum < DateTime.Now)
                        b.Appearance.BackColor = REDCOLOR;
                    else
                        b.Appearance.BackColor = Color.WhiteSmoke;

                    if (PMDS.DB.DBPflegeEintrag.IsToDaySigned(PflegepläneProButton.r.ID))
                        b.Appearance.BackColor = GREEENCOLOR;
                }
            }


           // lblMain.BackColor = System.Drawing.Color.WhiteSmoke ;
            //this.panelUnten.BackColor = System.Drawing.Color.Red;
            //this.lblMain.BackColor = System.Drawing.Color.Red;
            //this.BackColor = System.Drawing.Color.Red;
           this.BackColor = lblMain.Appearance.BackColor;


        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Die Untertägigen Buttons ggf. erzeugen
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshButtons()
        {
            lblZeitbereich.Text = "";
            lblZeitbereich.Visible = false;
            lblZeitbereich.Visible = _QMEintrag.COUNT == 1;
            //pnlButtons.Controls.Clear();

            foreach (UltraButton contButt in pnlButtons.Controls)
            {
                contButt.Visible = false;
            }
            
            panelUnten.Visible = true;
            pnlButtons.Visible = true;

            if (_QMEintrag.COUNT == 1)
            {
                dsPflegePlan.PflegePlanRow r    = _QMEintrag._pprows[0].r;
                pnlButtons.Visible              = false;
                if (!r.IsIDZeitbereichNull())
                    lblZeitbereich.Text = Zeitbereich.GetText(r.IDZeitbereich);
                else
                    lblZeitbereich.Text = r.StartDatum.ToShortTimeString();

                if (r.OhneZeitBezug)
                    lblZeitbereich.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("\r\nzuletzt: ") + PMDS.BusinessLogic.PflegePlan.GetLastRMTimeText(r.IDAufenthalt, r.IDEintrag);
                
                return;
            }
            int iNewLeft = 2;
            int iNewTop = 2;
            int anzPerLine = 0;
            intAnzButtons = 0;
            int lastIndex = 0;
            int maxIndex = pnlButtons.Controls.Count;


            foreach (QMEintrag.cPflegepläneProButton PflegepläneProButton in _QMEintrag._pprows)            // Für jeden Zeitpunkt einen Button 50x50 generieren
            {
                if (_QMEintrag._pprows.Count > 4)
                {
                    
                }
                else
                {
                    
                }
                intAnzButtons += 1;
                if (lastIndex <= maxIndex - 1)
                {
                    anzPerLine += 1;
                    
                    UltraButton b = (UltraButton)pnlButtons.Controls[lastIndex];
                    //UltraButton b = new UltraButton();
                    b.Visible = true;
                    
                   // b.Appearance.BackColor = Color.WhiteSmoke;
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    b.Tag = PflegepläneProButton;

                    if (!PflegepläneProButton.r.IsIDZeitbereichNull())
                    {
                        b.Text = Zeitbereich.GetText(PflegepläneProButton.r.IDZeitbereich);
                        b.Font = new System.Drawing.Font("Arial", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                    else
                    {
                        b.Text = QM.GetNextPflegeEintragTime(PflegepläneProButton.r, false).ToShortTimeString();
                    }

                    if (anzPerLine == 5)
                    {
                        iNewTop = b.Top + b.Height + 2;
                        anzPerLine = 0;
                        iNewLeft = 2;
                        b.Appearance.BackColor = System.Drawing.Color.Red;
                    }
                    // pnlButtons.Controls.Add(b);
                    iNewLeft = b.Left + b.Width + 2;
                    lastIndex += 1;
                }
                else
                {
                    anzPerLine += 1;
                    UltraButton b = new UltraButton();
                    b.Width = 40;
                    b.Height = 40;

                    b.ButtonStyle = UIElementButtonStyle.Flat;
                    b.UseOsThemes = DefaultableBoolean.False;
                    b.Appearance.BackColor = Color.WhiteSmoke;
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    b.Tag = PflegepläneProButton;
                    b.Click += new EventHandler(b_Click);


                    if (!PflegepläneProButton.r.IsIDZeitbereichNull())
                    {
                        b.Text = Zeitbereich.GetText(PflegepläneProButton.r.IDZeitbereich);
                        b.Font = new System.Drawing.Font("Arial", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                    else
                    {
                        b.Text = QM.GetNextPflegeEintragTime(PflegepläneProButton.r, false).ToShortTimeString();
                    }
                    b.Top = iNewTop;
                    b.Left = iNewLeft;


                    if (anzPerLine == 5)
                    {
                        iNewTop = b.Top + b.Height + 2;
                        anzPerLine = 0;
                        iNewLeft = 2;
                        b.Top = iNewTop;
                        b.Left = iNewLeft;
                        b.Appearance.BackColor = System.Drawing.Color.Red;
                    }

                    pnlButtons.Controls.Add(b);

                    iNewLeft = b.Left + b.Width + 2;
                }

                
            }

            //int iLines          = _QMEintrag.COUNT / 4 + 1;
            ////pnlButtons.Width    = this.Width;                       // es gehen sich immer 3 aus
            ////pnlButtons.Height   = iLines * 40 + iLines * 5 + 3;
            //pnlButtons.Dock     = DockStyle.Bottom;
            //pnlButtons.Visible = true;

        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Klick auf untertägig Button
        /// </summary>
        //----------------------------------------------------------------------------
        void b_Click(object sender, EventArgs e)
        {
            UltraButton b = (UltraButton)sender;
            QMEintrag.cPflegepläneProButton PflegepläneProButton = (QMEintrag.cPflegepläneProButton)b.Tag;
            ProcessClick(PflegepläneProButton);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Clickhandler
        /// </summary>
        //----------------------------------------------------------------------------
        private void ProcessClick(QMEintrag.cPflegepläneProButton PflegepläneProButton)
        {
            this.modalWIndow.lastMassClicked = this;
            ucVKey.PlayKlick();
            if (Click != null)
                Click(PflegepläneProButton, _QMEintrag);

        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	DoubleClickhandler
        /// </summary>
        //----------------------------------------------------------------------------
        private void ProcessDoubleClick(dsPflegePlan.PflegePlanRow r)
        {
            ucVKey.PlayKlick();
            if (DoubleClick != null)
                DoubleClick(r, _QMEintrag);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Labelklick nur dann wenn nicht untertägig
        /// </summary>
        //----------------------------------------------------------------------------
        private void lblMain_Click(object sender, EventArgs e)
        {
            if (_QMEintrag.COUNT == 1)
                ProcessClick(_QMEintrag._pprows[0]);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	LabelDoppelklick nur dann wenn nicht untertägig
        /// </summary>
        //----------------------------------------------------------------------------
        private void lblMain_DoubleClick(object sender, EventArgs e)
        {
            if (_QMEintrag.COUNT == 1)
                ProcessDoubleClick(_QMEintrag._pprows[0].r);
        }

        private void panelUnten_DoubleClick(object sender, EventArgs e)
        {
            if (_QMEintrag.COUNT == 1)
                ProcessDoubleClick(_QMEintrag._pprows[0].r);
        }

        private void panelUnten_Click(object sender, EventArgs e)
        {
            if (_QMEintrag.COUNT == 1)
                ProcessClick(_QMEintrag._pprows[0]);



        }

        private void lblZeitbereich_Click(object sender, EventArgs e)
        {
            if (_QMEintrag.COUNT == 1)
                ProcessClick(_QMEintrag._pprows[0]);
        }

        private void lblZeitbereich_DoubleClick(object sender, EventArgs e)
        {
            if (_QMEintrag.COUNT == 1)
                ProcessDoubleClick(_QMEintrag._pprows[0].r);
        }



        
    }

    public delegate void QMButtonClickDelegate(QMEintrag.cPflegepläneProButton PflegepläneProButton, QMEintrag QMe);
    public delegate void QMButtonDoubleClickDelegate(dsPflegePlan.PflegePlanRow pprow, QMEintrag QMe);
}
