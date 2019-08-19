using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;

namespace PMDS.GUI
{
    public partial class ucAskEndASZM : QS2.Desktop.ControlManagment.BaseControl
    {
        private ASZMLokalisiert[] _raszm;
        private PDxLokalisiert[] _rpdx;
        public ucAskEndASZM()
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
        /// PDxLokalisiert Array setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PDxLokalisiert[] RPDX
        {
            get { return _rpdx; }
            set
            {
                _rpdx = value;
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
            get { return dtpEnd.DateTime; }
            set { dtpEnd.DateTime = value; }
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
            get { return tbReason.Text.Trim(); }
            set { tbReason.Text = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die ausgewählten ASZM
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ASZMLokalisiert[] SELECTED_ASZM
        {
            get
            {
                ArrayList al = new ArrayList();
                foreach (ASZMLokalisiert l in lbInfo.CheckedItems)
                {
                    l._bCanPPFinished = true;
                    al.Add(l);
                }

                return (ASZMLokalisiert[])al.ToArray(typeof(ASZMLokalisiert));
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Vorbereiten der Anzeige
        /// </summary>
        //----------------------------------------------------------------------------
        private void ProcessInfo()
        {
            if (_raszm == null || _rpdx == null) return;

            foreach (ASZMLokalisiert l in _raszm)
            {
                int iNew = lbInfo.Items.Add(l);
                if (l._IDPDx != Guid.Empty)
                {
                    foreach (PDxLokalisiert pl in _rpdx)
                        if (l._IDPDx == pl._IDPDx)
                            lbInfo.SetItemChecked(iNew, true);
                }
                else
                {
                    lbInfo.SetItemChecked(iNew, true);				// nicht zugeordnete immer markieren
                }
            }
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


            // Auswahl in der Listbox ?
            GuiUtil.ValidateField(lbInfo, (lbInfo.CheckedItems.Count > 0),
                ENV.String("GUI.E_NO_SELECTION"), ref bError, bInfo, errorProvider1);


            return !bError;
        }
    }
}
