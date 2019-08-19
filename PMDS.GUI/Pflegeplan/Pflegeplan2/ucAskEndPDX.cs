using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;

namespace PMDS.GUI
{
    public partial class ucAskEndPDX : QS2.Desktop.ControlManagment.BaseControl
    {
        private ASZMLokalisiert[] _raszm;
        public ucAskEndPDX()
        {
            InitializeComponent();
            dtpEnd.DateTime = DateTime.Now.Date;
            RequiredFields();	
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Endedatum anzeigen oder nicht anzeigen
        /// </summary>
        //----------------------------------------------------------------------------
        public bool HiedeEndDate
        {
            get { return !pnlEndDatum.Visible; }
            set 
            { 
                pnlEndDatum.Visible = !value;
                if (!value)
                    Height = panel1.Height;
                else
                    Height = pnlEndDatum.Height + panel1.Height;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ASZMLokalisiert Array setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ASZMLokalisiert[] RASZM
        {
            get { return _raszm; }
            set 
            {
                _raszm = value;
                ProcessInfo();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Das Ende Datum
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime END_DATE
        {
            get { return dtpEnd.DateTime;}
            set{dtpEnd.DateTime = value;}
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Der Ende Grund
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string REASON
        {
            get{return tbReason.Text.Trim();}
            set{tbReason.Text = value;}
        }

        private void ProcessInfo()
        {

            lbInfo.Items.Add("---------------------------------------------------------------------");
            lbInfo.Items.Add(ENV.String("END_ASZMINFO"));
            lbInfo.Items.Add("---------------------------------------------------------------------");
            foreach (ASZMLokalisiert l in _raszm)
                if (l._bCanPPFinished)
                    lbInfo.Items.Add(l._Gruppe + " - " + l._Text + " (" + l._PDXText + " " + l._Lokalisierung + " " + l._LokalisierungSeite + ")");

            lbInfo.Items.Add("");
            lbInfo.Items.Add("");
            lbInfo.Items.Add("---------------------------------------------------------------------");
            lbInfo.Items.Add(ENV.String("END_NOT_ASZMINFO"));
            lbInfo.Items.Add("---------------------------------------------------------------------");
            foreach (ASZMLokalisiert l in _raszm)
                if (!l._bCanPPFinished)
                    lbInfo.Items.Add(l._Gruppe + " - " + l._Text + " (" + l._PDXText + " " + l._Lokalisierung + " " + l._LokalisierungSeite + ")");
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Benötigte Felder setzen
        /// </summary>
        //----------------------------------------------------------------------------
        protected void RequiredFields()
        {
            GuiUtil.ValidateRequired(dtpEnd);
            GuiUtil.ValidateRequired(tbReason);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Felder validieren
        /// </summary>
        //----------------------------------------------------------------------------
        public bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            // txtSexus
            GuiUtil.ValidateField(tbReason, (tbReason.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            // dtpGebDatum
            GuiUtil.ValidateField(dtpEnd, (dtpEnd.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            return !bError;
        }
    }
}
