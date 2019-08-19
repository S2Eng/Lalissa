using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.BusinessLogic;




namespace PMDS.GUI
{

    public partial class ucAnamneseModellgruppeBase : QS2.Desktop.ControlManagment.BaseControl, IAnamneseModellgruppe
    {
        public event EventHandler ValueChanged;
        private bool _readOnly = false;
        private dsPDXByPflegeModell.PDXPflegeModellDataTable _pdxTable;
        private DataRow _AnamneseRow;
        private PDXAnamnese _PDXAnamnese;
        protected List<DataBindingHelper> ListDataBindingHelper = new List<DataBindingHelper>();
        private ucAnamnesePDX _ucPDX;







        public ucAnamneseModellgruppeBase()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ucAnamnesePDX setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ucAnamnesePDX PDXControl
        {
            get { return _ucPDX; }
            set { _ucPDX = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ReadOnly setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                SetReadOnly();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// PDXPflegeModellDataTable setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsPDXByPflegeModell.PDXPflegeModellDataTable PDXTable
        {
            get { return _pdxTable; }
            set
            {
                _pdxTable = value;

                if (PDXControl != null)
                    PDXControl.PDXByPflegeModell = value;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// AnamneseRow setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataRow AnamneseRow
        {
            get { return _AnamneseRow; }
            set
            {
                _AnamneseRow = value;
                BindData();

                if (PDXControl != null && _AnamneseRow != null)
                    PDXControl.IDAnamnese = new Guid(_AnamneseRow["ID"].ToString());
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// PDXAnamnese setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PDXAnamnese PDXAnamnese
        {
            get { return _PDXAnamnese; }
            set
            {
                _PDXAnamnese = value;
                if (PDXControl != null)
                    PDXControl.PDXAnamnese = value;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Falls ein DataRow angegeben und nicht null, DataBindings alle Controls im ListDataBindingHelper setzen, sonst
        /// Werte alle diese Controls initialisieren.
        /// </summary>
        //----------------------------------------------------------------------------
        public virtual void BindData()
        {
            try
            {
                System.Reflection.PropertyInfo info = null;

                //DataBindings dauert zu Lang
                //foreach (DataBindingHelper bHelper in ListDataBindingHelper)
                //{
                //    bHelper.Control.DataBindings.Clear();
                //    //Wert des Controls initialisieren
                //    info = bHelper.Control.GetType().GetProperty(bHelper.PropertyName);
                //    if (info != null)
                //        info.SetValue(bHelper.Control, null, null);

                //    if (AnamneseRow != null)
                //    {
                //        Binding b = new Binding(bHelper.PropertyName, AnamneseRow, bHelper.DataMember, true);
                //        bHelper.Control.DataBindings.Add(b);
                //    }
                //}

                foreach (DataBindingHelper bHelper in ListDataBindingHelper)
                {
                    errorProvider1.SetError(bHelper.Control, "");//ErrorProvider initialisieren Neu nach 10.05.2007 MDA
                    bHelper.Control.DataBindings.Clear();
                    //Wert des Controls initialisieren
                    info = bHelper.Control.GetType().GetProperty(bHelper.PropertyName);
                    if (info != null)
                        info.SetValue(bHelper.Control, null, null);

                    if (AnamneseRow != null)
                    {
                        if (info != null)
                        {
                            try
                            {

                                if (AnamneseRow[bHelper.DataMember] != System.DBNull.Value)
                                    info.SetValue(bHelper.Control, AnamneseRow[bHelper.DataMember], null);
                            }
                            catch (Exception ex)
                            {
                                string xy = "";

                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Beendet beim Überschreiben den aktuellen Bearbeitungsvorgang aller Controls im ListDataBindingHelper
        /// </summary>
        //----------------------------------------------------------------------------
        public virtual void EndCurrentEdits()
        {
            try
            {
                if (PDXControl != null)
                    PDXControl.UpdateDATA();

                if (AnamneseRow != null)
                {
                    //foreach (DataBindingHelper bHelper in ListDataBindingHelper)
                    //{
                    //    bHelper.Control.BindingContext[AnamneseRow].EndCurrentEdit();
                    //}
                    System.Reflection.PropertyInfo info = null;
                    object val;
                    foreach (DataBindingHelper bHelper in ListDataBindingHelper)
                    {
                        info = bHelper.Control.GetType().GetProperty(bHelper.PropertyName);
                        if (info != null)
                        {
                            val = info.GetValue(bHelper.Control, null);
                            if (val == null)
                            {
                                AnamneseRow[bHelper.DataMember] = System.DBNull.Value;
                                //this.EndCurrentEditsDetails(AnamneseRow, bHelper.DataMember);
                            }
                            else if (val == System.DBNull.Value)
                            {
                                this.EndCurrentEditsDetails(AnamneseRow, bHelper.DataMember);
                            }
                            else
                            {
                                AnamneseRow[bHelper.DataMember] = val;
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }

        public void EndCurrentEditsDetails(DataRow r, string DataMember)
        {
            try
            {
                if (r[DataMember].GetType() == typeof(System.Int32) ||
                        r[DataMember].GetType() == typeof(System.Decimal) ||
                        r[DataMember].GetType() == typeof(float))
                {
                    r[DataMember] = 0;
                }
                else if (r[DataMember].GetType() == typeof(System.String))
                {
                    r[DataMember] = "";
                }
                else if (r[DataMember].GetType() == typeof(System.DateTime))
                {
                    r[DataMember] = System.DBNull.Value;
                }
                else if (r[DataMember].GetType() == typeof(System.Boolean))
                {
                    r[DataMember] = false;
                }
                else if (r[DataMember].GetType() == typeof(System.DBNull))
                {
                    r[DataMember] = System.DBNull.Value;
                }
                else
                {
                    throw new Exception("ucAnamneseModellgruppeBase.EndCurrentEdits: AnamneseRow[" + DataMember.Trim() + "].GetType() '" + AnamneseRow[DataMember].GetType().Name + "' not allowed!");
                }

            }
            catch (Exception e)
            {
                throw new Exception("ucAnamneseModellgruppeBase.EndCurrentEditsDetails: " + e.ToString());
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// prüft ob alle Eingaben richtig sind.
        /// </summary>
        //----------------------------------------------------------------------------
        public virtual bool ValidateFields()
        {
            //Neu nach 10.05.2007
            bool bError = false;
            bool bInfo = true;

            //All Datumsfelder dürfen nicht in der zunkunft liegen.
            foreach (DataBindingHelper dbHelper in ListDataBindingHelper)
            {
                if (dbHelper.Control is UltraDateTimeEditor)
                {
                    GuiUtil.ValidateField(dbHelper.Control, (((UltraDateTimeEditor)dbHelper.Control).DateTime <= DateTime.Now),
                        QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum darf nicht in der Zukunft liegen."), ref bError, bInfo, errorProvider1);
                }

            }

            return !bError;
        }



        //----------------------------------------------------------------------------
        /// <summary>
        /// ReadOnly oder Enabled alle Controls im ListDataBindingHelper setzen 
        /// </summary>
        //----------------------------------------------------------------------------
        private void SetReadOnly()
        {
            if (PDXControl != null)
                PDXControl.ReadOnly = ReadOnly;

            System.Reflection.PropertyInfo info = null;

            foreach (DataBindingHelper dbHelper in ListDataBindingHelper)
            {
                info = dbHelper.Control.GetType().GetProperty("ReadOnly");

                if (info != null)
                    info.SetValue(dbHelper.Control, ReadOnly, null);
                else
                    dbHelper.Control.Enabled = !ReadOnly;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten-Änderung signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        public void OnValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(sender, e);
        }
    }
}
