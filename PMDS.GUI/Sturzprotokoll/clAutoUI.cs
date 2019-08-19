using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Infragistics.Win;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{


    public class clAutoUI
    {
        public DB.Global.DBAutoUI dbAutoUI1 = null;
        public dsVerwaltung dsVerwaltungUpdate = null;
        public DB.Global.DBSturz dbSturzUpdate = null;
        public dsVerwaltung.tblSturzprotokollRow rSturzLoaded = null;


        public System.Guid IDSP = System.Guid.Empty;
        public System.Guid IDPatient = System.Guid.Empty;
        public bool IsNew = false;
        public bool IsLoaded = false;


        public static int TopStart = 10;
        public static int LeftSpace = 20;
        public static int SpaceBeetweenLabelAndControl = 6;
        public static int spaceBeetweenControls = 0;
        public static int ElementSpaceHeigth = 10;
        public static int RigthSpace = 20;

        public class cTagElement
        {
            public dsVerwaltung.tblUIDefinitionsRow rUIElementFound = null;
            public bool IsLabel = false;

        }

        public QS2.Desktop.ControlManagment.BasePanel _PanelToLoad = null;








        public bool init(string DbTable, ref QS2.Desktop.ControlManagment.BasePanel PanelToLoadTmp)
        {
            try
            {
                this.dsVerwaltungUpdate = new dsVerwaltung();
                this.dbAutoUI1 = new DB.Global.DBAutoUI();
                PanelToLoadTmp.Controls.Clear();
                this._PanelToLoad = PanelToLoadTmp;

                PMDS.DB.Global.DBAutoUI DBAutoUI1 = new DB.Global.DBAutoUI();
                DBAutoUI1.getAutoUI(this.dsVerwaltungUpdate, DbTable);

                Control PrevContAdded = null;
                int NextTop = clAutoUI.TopStart;
                foreach (dsVerwaltung.tblUIDefinitionsRow rUIElementFound in this.dsVerwaltungUpdate.tblUIDefinitions)
                {
                    Control ContToAdd = null;

                    if (!rUIElementFound.UIType.Trim().Equals("Header", StringComparison.CurrentCultureIgnoreCase))
                    {
                        this.addElement(rUIElementFound, DbTable, ref  this._PanelToLoad, ref NextTop, ref ContToAdd, ref PrevContAdded, "Label");
                        PrevContAdded = ContToAdd;
                    }

                    if (!rUIElementFound.UIType.Trim().Equals("Label", StringComparison.CurrentCultureIgnoreCase))
                    {
                        this.addElement(rUIElementFound, DbTable, ref  this._PanelToLoad, ref NextTop, ref ContToAdd, ref PrevContAdded, rUIElementFound.UIType.Trim());
                        PrevContAdded = ContToAdd; 
                    }
                }
               
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clAutoUI.run: " + ex.ToString());
            }
        }
        public bool addElement(dsVerwaltung.tblUIDefinitionsRow rUIElementFound, string DbTable, ref QS2.Desktop.ControlManagment.BasePanel PanelToLoad,
                                ref int NextTop, ref Control ContToAdd, ref Control PrevContAdded, string UIType)
        {
            try
            {
                bool IsLabel = false;
                if (UIType.Trim().Equals("Boolean", StringComparison.CurrentCultureIgnoreCase))
                {
                    Infragistics.Win.UltraWinEditors.UltraCheckEditor newCheckBox = new QS2.Desktop.ControlManagment.BaseCheckBox();
                    ContToAdd = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)newCheckBox;
                    newCheckBox.Width = PanelToLoad.Width - clAutoUI.LeftSpace - clAutoUI.RigthSpace;
                    newCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                    
                }
                else if (UIType.Trim().Equals("Text", StringComparison.CurrentCultureIgnoreCase))
                {
                    Infragistics.Win.UltraWinEditors.UltraTextEditor newText = new QS2.Desktop.ControlManagment.BaseTextEditor();
                    ContToAdd = (Infragistics.Win.UltraWinEditors.UltraTextEditor)newText;
                    newText.Multiline = true;
                    newText.MaxLength = 5000000;

                    if (rUIElementFound.ElementHeigth > 5)
                    {
                        ContToAdd.Height = rUIElementFound.ElementHeigth;
                    }
                    else
                    {
                        ContToAdd.Height = 80;
                    }
                    if (rUIElementFound.ElementWidth > 5)
                    {
                        newText.Width = rUIElementFound.ElementWidth;
                    }
                    else
                    {
                        newText.Width = PanelToLoad.Width - clAutoUI.LeftSpace - clAutoUI.RigthSpace;
                        newText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                    }
                }
                else if (UIType.Trim().Equals("Header", StringComparison.CurrentCultureIgnoreCase))
                {
                    IsLabel = true;
                    Infragistics.Win.Misc.UltraLabel newHeader = new QS2.Desktop.ControlManagment.BaseLabel();
                    ContToAdd = (Infragistics.Win.Misc.UltraLabel)newHeader;
                    newHeader.Text = rUIElementFound.LabelTxt.Trim();
                    newHeader.Appearance.FontData.SizeInPoints = 12;
                    newHeader.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                    newHeader.Appearance.FontData.Bold = DefaultableBoolean.False;
                    if (rUIElementFound.ElementHeigth > 5)
                    {
                        newHeader.AutoSize = true;
                        //newHeader.Width = PanelToLoad.Width - clAutoUI.LeftSpace - clAutoUI.RigthSpace;
                        //newHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        //ContToAdd.Height = rUIElementFound.ElementHeigth;
                    }
                    else
                    {
                        newHeader.AutoSize = true;
                        //ContToAdd.Height = 150;
                    }
                }
                else if (UIType.Trim().Equals("Date", StringComparison.CurrentCultureIgnoreCase) ||
                        UIType.Trim().Equals("DateTime", StringComparison.CurrentCultureIgnoreCase))
                {
                    Infragistics.Win.UltraWinEditors.UltraDateTimeEditor newDate = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
                    ContToAdd = (Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)newDate;
                    newDate.Width = 120;
                    if (UIType.Trim().Equals("Date", StringComparison.CurrentCultureIgnoreCase))
                    {
                        newDate.MaskInput = "{date}";
                        newDate.FormatString = "d";
                    }
                    else if (UIType.Trim().Equals("DateTime", StringComparison.CurrentCultureIgnoreCase))
                    {
                        newDate.MaskInput = "{date} {time}";
                        newDate.FormatString = "g";
                    }
                }
                else if (UIType.Trim().Equals("Label", StringComparison.CurrentCultureIgnoreCase))
                {
                    IsLabel = true;
                    Infragistics.Win.Misc.UltraLabel newLabel = new QS2.Desktop.ControlManagment.BaseLabel();
                    ContToAdd = (Infragistics.Win.Misc.UltraLabel)newLabel;
                    newLabel.UseAppStyling = false;
                    //newLabel.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                    //newLabel.Appearance.BackColor = System.Drawing.Color.Yellow;
                    if (rUIElementFound.ElementHeigth > 5)
                    {
                        newLabel.AutoSize = true;
                        //newLabel.AutoSize = false;
                        //newLabel.Width = PanelToLoad.Width - clAutoUI.LeftSpace - clAutoUI.RigthSpace;
                        //newLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        //ContToAdd.Height = rUIElementFound.ElementHeigth;
                    }
                    else
                    {
                        newLabel.AutoSize = true;
                        //newLabel.Width = PanelToLoad.Width - clAutoUI.LeftSpace - clAutoUI.RigthSpace;
                        //newLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        //ContToAdd.Height = 12;
                    }
                    //newLabel.Text = rUIElementFound.LabelTxt.Trim();
                }
                else if (UIType.Trim().Equals("Double", StringComparison.CurrentCultureIgnoreCase))
                {
                    Infragistics.Win.UltraWinEditors.UltraNumericEditor newNumeric= new QS2.Desktop.ControlManagment.BaseNumericEditor();
                    ContToAdd = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)newNumeric;
                    newNumeric.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
                    newNumeric.MaskInput = "{LOC}nnn,nnn,nnn,nnn.nnnn";
                    newNumeric.FormatString = "###,###,###,##0.0000";
                    newNumeric.MinValue = -992299999;
                    newNumeric.MaxValue = 992299999;
                    newNumeric.Width = 120;
                }
                else if (UIType.Trim().Equals("Integer", StringComparison.CurrentCultureIgnoreCase))
                {
                    Infragistics.Win.UltraWinEditors.UltraNumericEditor newNumeric = new QS2.Desktop.ControlManagment.BaseNumericEditor();
                    ContToAdd = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)newNumeric;
                    newNumeric.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Integer;
                    newNumeric.MaskInput = "{LOC}nnn,nnn,nnn,nnn";
                    newNumeric.FormatString = "###,###,###,##0";
                    newNumeric.MinValue = -992299999;
                    newNumeric.MaxValue = 992299999;
                    newNumeric.Width = 120;
                }
                else if (UIType.Trim().Equals("Space", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (rUIElementFound.ElementHeigth > 5)
                    {
                        NextTop += rUIElementFound.ElementHeigth;
                    }
                    else
                    {
                        NextTop += clAutoUI.ElementSpaceHeigth;
                    }
                }
                else
                {
                    throw new Exception("clAutoUI.addElement: Error UIType '" + rUIElementFound.UIType.Trim() + "' not supported!");
                }

                int SpaceMinus = 0;
                if (IsLabel)
                {
                    NextTop += clAutoUI.SpaceBeetweenLabelAndControl;
                }
                else
                {
                    SpaceMinus = -3;
                }

                cTagElement cTg = new cTagElement();
                cTg.rUIElementFound = rUIElementFound;
                cTg.IsLabel = IsLabel;

                ContToAdd.Tag = (cTagElement)cTg;
                ContToAdd.Top = NextTop;
                ContToAdd.Left += clAutoUI.LeftSpace;

                PanelToLoad.Controls.Add(ContToAdd);
                if (IsLabel)
                {
                    NextTop += ContToAdd.Height + clAutoUI.spaceBeetweenControls + -5;
                }
                else
                {
                    NextTop += ContToAdd.Height + clAutoUI.spaceBeetweenControls - SpaceMinus;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clAutoUI.addElement: " + ex.ToString());
            }
        }
        
        public bool loadData(string DbTable)
        {
            try
            {
                this.dbSturzUpdate = new DB.Global.DBSturz();
                this.dsVerwaltungUpdate.tblSturzprotokoll.Rows.Clear();
                this.rSturzLoaded = null;
                PMDS.BusinessLogic.Patient pat = new BusinessLogic.Patient(IDPatient);

                this.dbSturzUpdate.getSturzByID(this.dsVerwaltungUpdate, System.Guid.NewGuid());
                this.dbSturzUpdate.getSturzByID(this.dsVerwaltungUpdate, this.IDSP);
                if (this.dsVerwaltungUpdate.tblSturzprotokoll.Rows.Count == 1)
                {
                    this.dbSturzUpdate.getSturzByID(this.dsVerwaltungUpdate, this.IDSP);
                    this.rSturzLoaded = (dsVerwaltung.tblSturzprotokollRow)this.dsVerwaltungUpdate.tblSturzprotokoll.Rows[0];
                    this.IsNew = false;
                }
                else if (this.dsVerwaltungUpdate.tblSturzprotokoll.Rows.Count == 0)
                {
                    this.rSturzLoaded = this.dbSturzUpdate.getNewSturz(this.dsVerwaltungUpdate);
                    this.rSturzLoaded.IDStandardprozedur = this.IDSP;
                    this.rSturzLoaded.IDPatient = this.IDPatient;
                    this.IsNew = true;
                }  

                Control PrevContAdded = null;
                foreach (Control ControlFound in this._PanelToLoad .Controls)
                {
                    this.loadDataElement(DbTable, ControlFound, ref pat);
                    PrevContAdded = ControlFound;
                }

                this.IsLoaded = true;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clAutoUI.loadData: " + ex.ToString());
            }
        }
        public bool loadDataElement(string DbTable, Control ControlFound, ref PMDS.BusinessLogic.Patient pat)
        {
            try
            {
                cTagElement cTg = (cTagElement)ControlFound.Tag;

                if (cTg.IsLabel)
                {
                    Infragistics.Win.Misc.UltraLabel newLabel = (Infragistics.Win.Misc.UltraLabel)ControlFound;
                    newLabel.Text = cTg.rUIElementFound.LabelTxt.Trim();
                }
                else
                {
                    if (cTg.rUIElementFound.UIType.Trim().Equals("Boolean", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Infragistics.Win.UltraWinEditors.UltraCheckEditor newCheckBox = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)ControlFound;
                        object obj = (object)this.rSturzLoaded[cTg.rUIElementFound.DbColumn.Trim()];
                        if (this.checkNull(obj))
                        {
                            newCheckBox.Checked = false;
                        }
                        else
                        {
                            bool vBool = System.Convert.ToBoolean(obj);
                            newCheckBox.Checked = vBool;
                        }
                    }
                    else if (cTg.rUIElementFound.UIType.Trim().Equals("Text", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Infragistics.Win.UltraWinEditors.UltraTextEditor newText = (Infragistics.Win.UltraWinEditors.UltraTextEditor)ControlFound;
                        object obj = (object)this.rSturzLoaded[cTg.rUIElementFound.DbColumn.Trim()];
                        if (this.checkNull(obj))
                        {
                            newText.Text = "";
                        }
                        else
                        {
                            string vText = System.Convert.ToString(obj);
                            newText.Text = vText;
                        }
                        if (this.IsNew)
                        {
                            if (cTg.rUIElementFound.LabelTxt.Trim().Equals("Name des Bewohners", StringComparison.CurrentCultureIgnoreCase))
                            {
                                   newText.Text = pat.NameVollstaendig;
                            }
                            else if (cTg.rUIElementFound.LabelTxt.Trim().Equals("Wohnbereich", StringComparison.CurrentCultureIgnoreCase))
                            {

                            }
                        }
                    }
                    else if (cTg.rUIElementFound.UIType.Trim().Equals("Header", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Infragistics.Win.Misc.UltraLabel newHeader = (Infragistics.Win.Misc.UltraLabel)ControlFound;
                        newHeader.Text = cTg.rUIElementFound.LabelTxt.Trim();
                    }
                    else if (cTg.rUIElementFound.UIType.Trim().Equals("Date", StringComparison.CurrentCultureIgnoreCase) ||
                             cTg.rUIElementFound.UIType.Trim().Equals("DateTime", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Infragistics.Win.UltraWinEditors.UltraDateTimeEditor newDate = (Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)ControlFound;
                        object obj = (object)this.rSturzLoaded[cTg.rUIElementFound.DbColumn.Trim()];
                        if (this.checkNull(obj))
                        {
                            newDate.Value = null;
                        }
                        else
                        {
                            DateTime vDatTime = System.Convert.ToDateTime(obj);
                            newDate.DateTime = vDatTime;
                        }
                        if (this.IsNew)
                        {
                            if (cTg.rUIElementFound.LabelTxt.Trim().Equals("Geburtsdatum", StringComparison.CurrentCultureIgnoreCase))
                            {
                                if (pat.Geburtsdatum != System.DBNull.Value)
                                {
                                    try
                                    {
                                        newDate.DateTime = (DateTime)pat.Geburtsdatum; 
                                    }
                                    catch
                                    {
                                        string xy = "";
                                    }
                                }
                            }
                        }
                    }
                    else if (cTg.rUIElementFound.UIType.Trim().Equals("Label", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Infragistics.Win.Misc.UltraLabel newLabel = (Infragistics.Win.Misc.UltraLabel)ControlFound;
                        newLabel.Text = cTg.rUIElementFound.LabelTxt.Trim();
                    }
                    else if (cTg.rUIElementFound.UIType.Trim().Equals("Double", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Infragistics.Win.UltraWinEditors.UltraNumericEditor newNumeric = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)ControlFound;
                        object obj = (object)this.rSturzLoaded[cTg.rUIElementFound.DbColumn.Trim()];
                        if (this.checkNull(obj))
                        {
                            newNumeric.Value = 0;
                        }
                        else
                        {
                            double vDouble = System.Convert.ToDouble(obj);
                            newNumeric.Value = vDouble;
                        }
                    }
                    else if (cTg.rUIElementFound.UIType.Trim().Equals("Integer", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Infragistics.Win.UltraWinEditors.UltraNumericEditor newInteger = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)ControlFound;
                        object obj = (object)this.rSturzLoaded[cTg.rUIElementFound.DbColumn.Trim()];
                        if (this.checkNull(obj))
                        {
                            newInteger.Value = 0;
                        }
                        else
                        {
                            int vInt = System.Convert.ToInt32(obj);
                            newInteger.Value = vInt;
                        }
                    }
                    else if (cTg.rUIElementFound.UIType.Trim().Equals("Space", StringComparison.CurrentCultureIgnoreCase))
                    {

                    }
                    else
                    {
                        throw new Exception("clAutoUI.loadDataElement: Error UIType '" + cTg.rUIElementFound.UIType.Trim() + "' not supported!");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clAutoUI.loadDataElement: " + ex.ToString());
            }
        }

        public bool GetData()
        {
            try
            {
                if (this.dsVerwaltungUpdate.tblSturzprotokoll.Rows.Count == 1)
                {
                    Control PrevContAdded = null;
                    foreach (Control ControlFound in this._PanelToLoad.Controls)
                    {
                        this.saveDataElement(ref  this._PanelToLoad, ControlFound);
                        PrevContAdded = ControlFound;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clAutoUI.SaveData: " + ex.ToString());
            }
        }
        public bool saveDataElement(ref QS2.Desktop.ControlManagment.BasePanel PanelToLoad, Control ControlFound)
        {
            try
            {
                cTagElement cTg = (cTagElement)ControlFound.Tag;

                if (cTg.IsLabel)
                {
                    Infragistics.Win.Misc.UltraLabel newLabel = (Infragistics.Win.Misc.UltraLabel)ControlFound;
                }
                else
                {
                    if (cTg.rUIElementFound.UIType.Trim().Equals("Boolean", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Infragistics.Win.UltraWinEditors.UltraCheckEditor newCheckBox = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)ControlFound;
                        this.rSturzLoaded[cTg.rUIElementFound.DbColumn.Trim()] = newCheckBox.Checked;
                    }
                    else if (cTg.rUIElementFound.UIType.Trim().Equals("Text", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Infragistics.Win.UltraWinEditors.UltraTextEditor newText = (Infragistics.Win.UltraWinEditors.UltraTextEditor)ControlFound;
                        this.rSturzLoaded[cTg.rUIElementFound.DbColumn.Trim()] = newText.Text.Trim();
                    }
                    else if (cTg.rUIElementFound.UIType.Trim().Equals("Header", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Infragistics.Win.Misc.UltraLabel newHeader = (Infragistics.Win.Misc.UltraLabel)ControlFound;
                    }
                    else if (cTg.rUIElementFound.UIType.Trim().Equals("Date", StringComparison.CurrentCultureIgnoreCase) ||
                             cTg.rUIElementFound.UIType.Trim().Equals("DateTime", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Infragistics.Win.UltraWinEditors.UltraDateTimeEditor newDate = (Infragistics.Win.UltraWinEditors.UltraDateTimeEditor)ControlFound;
                        object obj = (object)newDate.Value;
                        if (this.checkNull(obj))
                        {
                            this.rSturzLoaded[cTg.rUIElementFound.DbColumn.Trim()] = System.DBNull.Value;
                        }
                        else
                        {
                            DateTime vDatTime = newDate.DateTime;
                            this.rSturzLoaded[cTg.rUIElementFound.DbColumn.Trim()] = vDatTime;
                        }
                    }
                    else if (cTg.rUIElementFound.UIType.Trim().Equals("Label", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Infragistics.Win.Misc.UltraLabel newLabel = (Infragistics.Win.Misc.UltraLabel)ControlFound;
                    }
                    else if (cTg.rUIElementFound.UIType.Trim().Equals("Double", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Infragistics.Win.UltraWinEditors.UltraNumericEditor newNumeric = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)ControlFound;
                        object obj = (object)newNumeric.Value;
                        if (this.checkNull(obj))
                        {
                            this.rSturzLoaded[cTg.rUIElementFound.DbColumn.Trim()] = 0;
                        }
                        else
                        {
                            double vDouble = System.Convert.ToDouble(newNumeric.Value);
                            this.rSturzLoaded[cTg.rUIElementFound.DbColumn.Trim()] = vDouble;
                        }
                    }
                    else if (cTg.rUIElementFound.UIType.Trim().Equals("Integer", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Infragistics.Win.UltraWinEditors.UltraNumericEditor newInteger = (Infragistics.Win.UltraWinEditors.UltraNumericEditor)ControlFound;
                        object obj = (object)newInteger.Value;
                        if (this.checkNull(obj))
                        {
                            this.rSturzLoaded[cTg.rUIElementFound.DbColumn.Trim()] = 0;
                        }
                        else
                        {
                            int vInt = System.Convert.ToInt32(newInteger.Value);
                            this.rSturzLoaded[cTg.rUIElementFound.DbColumn.Trim()] = vInt;
                        }
                    }
                    else if (cTg.rUIElementFound.UIType.Trim().Equals("Space", StringComparison.CurrentCultureIgnoreCase))
                    {
                        string str = "";
                    }
                    else
                    {
                        throw new Exception("clAutoUI.saveDataElement: Error UIType '" + cTg.rUIElementFound.UIType.Trim() + "' not supported!");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clAutoUI.saveDataElement: " + ex.ToString());
            }
        }
        public bool UpdateData()
        {
            try
            {
                if (this.IsLoaded)
                {
                    this.dbSturzUpdate.daSturzByID.Update(this.dsVerwaltungUpdate.tblSturzprotokoll);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("clAutoUI.UpdateData: " + ex.ToString());
            }
        }

        public bool checkNull(object valToCheck)
        {
            if (valToCheck == null)
            {
                return true;
            }
            else
            {
                if (valToCheck == System.DBNull.Value)
                {
                    return true;
                }
                else
                {
                    if (valToCheck.GetType().Name.Trim().Equals("Date", StringComparison.CurrentCultureIgnoreCase) ||
                        valToCheck.GetType().Name.Trim().Equals("DateTime", StringComparison.CurrentCultureIgnoreCase))
                    {
                        if ((DateTime)valToCheck == DateTime.MinValue)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

    }

}
