using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
    public partial class ucStandardZeiten : QS2.Desktop.ControlManagment.BaseControl
    {
        private dsRezeptEintrag.RezeptEintragRow _RezeptEintrag;
        private Standardzeiten _Standardzeiten;
        private bool _bnuechtern = false;
        private bool _bkeepStandardzeiten = false; // bei neuem Rezepteintrag wegen änderung will ich UpdateGui() nicht
               
        public ucStandardZeiten()
        {
            InitializeComponent();
            RequiredFields();
            zp0.Visible = false;
            t0.Visible = false;
           
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsRezeptEintrag.RezeptEintragRow RezeptEintrag
        {
            get { return _RezeptEintrag; }
            set
            {
                _RezeptEintrag = value;
                if(!BkeepStandardzeiten)
                UpdateGUI();
            }
        }

        // bei neuem Rezepteintrag wegen änderung will ich UpdateGui() nicht
        public bool BkeepStandardzeiten
        {
            get { return _bkeepStandardzeiten; }
            set { _bkeepStandardzeiten = value; }
        }


       

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten nach GUI übertragen
        /// </summary>
        //----------------------------------------------------------------------------
        public void UpdateGUI()
        {
            if (RezeptEintrag == null)
                return;

            cbStandardzeitenJN.Checked = RezeptEintrag.StandardzeitenJN;

            if (!RezeptEintrag.IsZeitpunkt0Null())
            {
                t0.Value = RezeptEintrag.Zeitpunkt0;
                t0.Visible = true;
            }
            else
            {
                t0.Value = null;
                t0.Visible = false;
            }

            if (!RezeptEintrag.IsZeitpunkt1Null())
            {
                t1.Value = RezeptEintrag.Zeitpunkt1;
                pnlZeitpunkte.Visible = !cbStandardzeitenJN.Checked;
            }
            else
            {
                t1.Value = null;
                pnlZeitpunkte.Visible = cbStandardzeitenJN.Checked;
            }

            if (!RezeptEintrag.IsZeitpunkt2Null())
            {
                t2.Value = RezeptEintrag.Zeitpunkt2;
                pnlZeitpunkte.Visible = !cbStandardzeitenJN.Checked;
            }
            else
            {
                t2.Value = null;
                pnlZeitpunkte.Visible = cbStandardzeitenJN.Checked;
            }

            if (!RezeptEintrag.IsZeitpunkt3Null())
            {
                t3.Value = RezeptEintrag.Zeitpunkt3;
                pnlZeitpunkte.Visible = !cbStandardzeitenJN.Checked;
            }
            else
            {
                t3.Value = null;
                pnlZeitpunkte.Visible = cbStandardzeitenJN.Checked;
            }

            if (!RezeptEintrag.IsZeitpunkt4Null())
            {
                t4.Value = RezeptEintrag.Zeitpunkt4;
                pnlZeitpunkte.Visible = !cbStandardzeitenJN.Checked;
            }
            else
            {
                t4.Value = null;
                pnlZeitpunkte.Visible = cbStandardzeitenJN.Checked;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// GUI nach Daten übertragen
        /// </summary>
        //----------------------------------------------------------------------------
        public void UpdateDATA()
        {
            if (RezeptEintrag == null)
                return;

            RezeptEintrag.StandardzeitenJN = cbStandardzeitenJN.Checked;

            if (t0.Value != null)
                RezeptEintrag.Zeitpunkt0 = t0.DateTime;
            else
                RezeptEintrag.SetZeitpunkt0Null();

            if (t1.Value != null)
                RezeptEintrag.Zeitpunkt1 = t1.DateTime;
            else
                RezeptEintrag.SetZeitpunkt1Null();

            if (t2.Value != null)
                RezeptEintrag.Zeitpunkt2 = t2.DateTime;
            else
                RezeptEintrag.SetZeitpunkt2Null();

            if (t3.Value != null)
                RezeptEintrag.Zeitpunkt3 = t3.DateTime;
            else
                RezeptEintrag.SetZeitpunkt3Null();

            if (t4.Value != null)
                RezeptEintrag.Zeitpunkt4 = t4.DateTime;
            else
                RezeptEintrag.SetZeitpunkt4Null();

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Benötigte Felder setzen
        /// </summary>
        //----------------------------------------------------------------------------
        protected void RequiredFields()
        {
            GuiUtil.ValidateRequired(t0);
            GuiUtil.ValidateRequired(t1);
            GuiUtil.ValidateRequired(t2);
            GuiUtil.ValidateRequired(t3);
            GuiUtil.ValidateRequired(t4);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Backcolor bei Bedarfsmed auf weiß oder blau setzen
        /// </summary>
        //----------------------------------------------------------------------------
        public void setZeitenBackcolor(Color backcolor)
        {
            t0.Appearance.BackColor = backcolor;
            t1.Appearance.BackColor = backcolor;
            t2.Appearance.BackColor = backcolor;
            t3.Appearance.BackColor = backcolor;
            t4.Appearance.BackColor = backcolor;
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Felder validieren
        /// </summary>
        //----------------------------------------------------------------------------
        public bool ValidateFields( )
        {
            bool bError = false;
            bool bInfo = true;
            if(cbStandardzeitenJN.Checked)
                return !bError;

            // mindestens 1 t0 ... t4 muss einen Wert haben
            bool bZOK = false;

            if (t0.Text.Trim().Length > 0 || t1.Text.Trim().Length > 0 || t2.Text.Trim().Length > 0 ||
                t3.Text.Trim().Length > 0 || t4.Text.Trim().Length > 0
                
                
                
                )
                bZOK = true;

            if (!bZOK)
            {
                GuiUtil.ValidateField(t0, bZOK, ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                GuiUtil.ValidateField(t1, bZOK, ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                GuiUtil.ValidateField(t2, bZOK, ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                GuiUtil.ValidateField(t3, bZOK, ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                GuiUtil.ValidateField(t4, bZOK, ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
            }

            return !bError;
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Felder validieren
        /// </summary>
        //----------------------------------------------------------------------------
        public bool ValidateFields(int[] Dosierung)
        {
            bool bError = false;
            if (cbStandardzeitenJN.Checked)
                return !bError;

            // mindestens 1 t0 ... t4 muss einen Wert haben
            bool bZOK = true;

            if ((
                (t0.Text.Trim().Length == 0 && Dosierung[0] > 0)|| (t1.Text.Trim().Length == 0 && Dosierung[1] > 0)|| (t2.Text.Trim().Length == 0 && Dosierung[2] > 0)||
                (t3.Text.Trim().Length == 0 && Dosierung[3] > 0)|| (t4.Text.Trim().Length == 0 && Dosierung[4] > 0)||
                
                (t0.Text.Trim().Length > 0 && Dosierung[0] == 0)|| (t1.Text.Trim().Length > 0 && Dosierung[1] == 0)|| (t2.Text.Trim().Length > 0 && Dosierung[2] == 0)||
                (t3.Text.Trim().Length > 0 && Dosierung[3] == 0)|| (t4.Text.Trim().Length > 0 && Dosierung[4] == 0)
                ))
                bZOK = false;

            if (!bZOK)
            {
                /*GuiUtil.ValidateField(t0, bZOK, ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                GuiUtil.ValidateField(t1, bZOK, ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                GuiUtil.ValidateField(t2, bZOK, ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                GuiUtil.ValidateField(t3, bZOK, ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
                GuiUtil.ValidateField(t4, bZOK, ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);*/
                int summe=0;
                for (int i = 0; i < Dosierung.Length; i++)
                    summe = summe+ Dosierung[i];
                if(summe==0)    
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte geben Sie zu jedem erfaßten Zeitpunkt eine Dosierung bzw. zu jeder Dosierung einen Zeitpunkt an!"); 

                else
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte geben Sie zu jeder erfaßten Dosierung einen Zeitpunkt bzw. zu jedem erfaßten Zeitpunkt eine Dosierung an!");
                bError = true;

            }

            return !bError;
        }

        private void InitStandardZeiten()
        {
            foreach (dsStandardZeiten.StandardzeitenRow r in _Standardzeiten.STANDARDZEITEN.Standardzeiten)
            {
                foreach (Control c in Controls)
                {
                    if (c.Name.Contains("zp" + r.ID.ToString()))
                    {
                        //c.Text = r.Zeitpunkt.TimeOfDay.ToString();
                        c.Text = r.Bezeichnung;
                        break;
                    }
                }
            }
        }

        private void cbStandardzeitenJN_CheckedChanged(object sender, EventArgs e)
        {           
            pnlZeitpunkte.Visible = !cbStandardzeitenJN.Checked;
           



            if (cbStandardzeitenJN.Checked)
            {
                t0.Text = "";
                t1.Text = "";
                t2.Text = "";
                t3.Text = "";
                t4.Text = "";
            }
            errorProvider1.Clear();
        }
        
        private void ucStandardZeiten_Load(object sender, EventArgs e)
        {
            if (!DesignMode && ENV.AppRunning)
            {
                pnlZeitpunkte.Location = new Point(pnlZeitpunkte.Location.X, 0);
                _Standardzeiten = new Standardzeiten();
                _Standardzeiten.Read();
                InitStandardZeiten();
                pnlZeitpunkte.Visible = !cbStandardzeitenJN.Checked;
            }
        }
        
        // alle fünf Zeitfenster greifen hier an
        private void t0_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Standardzeiten Checkbox setzten
        /// </summary>
        //----------------------------------------------------------------------------
        public void setStandardZeitenCheckbox(bool bnuechtern)
        {
            cbStandardzeitenJN.Checked = true;
            _bnuechtern = bnuechtern;
            zp0.Visible = _bnuechtern; t0.Visible = _bnuechtern;
            zp1.Visible = !_bnuechtern;
            zp2.Visible = !_bnuechtern;
            zp3.Visible = !_bnuechtern;
            zp4.Visible = !_bnuechtern;
            pnlZeitpunkte.Visible = !cbStandardzeitenJN.Checked;
           
        

        }
               
    }
}
