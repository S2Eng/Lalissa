using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Win;
using System.Drawing;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;




namespace qs2.sitemap
{

    
    public class ui
    {

        public void aktivateButtonxyxyxy(List<cButt> buttons, int aktiv, bool BackgroundTransparentInaktiv)
        {
            foreach (cButt itm in buttons)
            {
                if (itm.nr == aktiv)
                    itm.on = true;
                else
                    itm.on = false;
            }
            this.setUIButtonsxyxyxy(buttons, BackgroundTransparentInaktiv);
        }
        public void setUIButtonsxyxyxy(List<cButt> buttons, bool BackgroundTransparentInaktiv)
        {
            //foreach (cButt itm in buttons)
            //{
            //    if (itm.on)
            //        qs2.core.ui.setAktiv(itm.butt, -1, false);
            //    else
            //        qs2.core.ui.setInaktiv(itm.butt, -1, BackgroundTransparentInaktiv);
            //}
        }


        public class cButt
        {
            //public UltraButton butt;
            public bool on = false;
            public int nr = -1;
            public int  selListEntryID;
            public string selListEntryIDOwnStr;
            public qs2.core.Enums.eTypList TypList;
        }

        public static void loadGridCriterias(UltraGridBand band, qs2.core.vb.dsAdmin ds)
        {
            band.Columns[ds.tblCriteria.FldShortColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("FldShort");
            band.Columns[ds.tblCriteria.IDApplicationColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Application");
            band.Columns[ds.tblCriteria.ControlTypeColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("TypeControl");
            band.Columns[ds.tblCriteria.SQLValueListSelectColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("SQLValueListSelect");
            band.Columns[ds.tblCriteria.SourceTableColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Table");
            band.Columns[ds.tblCriteria.ControlPatternColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("FormatString");
            band.Columns[ds.tblCriteria.MaskInputColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("MaskInput");
            band.Columns[ds.tblCriteria.ControlMinValColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("ControlMinVal");
            band.Columns[ds.tblCriteria.ControlMaxValColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("ControlMaxVal");
            band.Columns[ds.tblCriteria.UsedColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Used");
            band.Columns[ds.tblCriteria.ValidateColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Validate");
            band.Columns[ds.tblCriteria.EditableColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Editable");
            band.Columns[ds.tblCriteria.UseInQueriesColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("UseInQueries");
            band.Columns[ds.tblCriteria.LicenseKeyColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("LicenseKey");
            band.Columns[ds.tblCriteria.DescriptionColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Description");
            band.Columns[ds.tblCriteria.ShowAtColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("ShowAt");
            band.Columns[ds.tblCriteria.AliasFldShortColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("AliasFldShort");
            band.Columns[ds.tblCriteria.UserDefinedColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("UserDefined");
            band.Columns[ds.tblCriteria.preferedColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Prefered");
            band.Columns[ds.tblCriteria.ClassificationColumn .ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Classification");
            band.Columns[ds.tblCriteria.ControlMinLengthColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("ControlMinLength");
            band.Columns[ds.tblCriteria.ControlMaxLengthColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("ControlMaxLength");

            band.Columns[ds.tblCriteria.DefaultValuesColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("DefaultValues");
            band.Columns[ds.tblCriteria.DefaultValuesCustomerColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("DefaultValuesCustomer");
            band.Columns[ds.tblCriteria.UsedCustomerColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("UsedCustomer");

            band.Columns[qs2.core.generic.columnNameText].Header.Caption = qs2.core.language.sqlLanguage.getRes("Translation");
            //band.Columns[qs2.core.generic.columnNameText].Hidden = true;
        }

        public static void translateCriterias(RowsCollection rows, 
                                                string IDParticipant, core.Enums.eResourceType enumTypResSearch,
                                                bool alwaysTranslate, bool resetNewTranlsation, string columnNewTranslation, bool CheckLabelForQuery)
        {
            try
            {
                foreach (UltraGridRow rGridCrit in rows)
                {
                    System.Data.DataRowView v = (System.Data.DataRowView)rGridCrit.ListObject;
                    qs2.core.vb.dsAdmin.tblCriteriaRow rCrit = (qs2.core.vb.dsAdmin.tblCriteriaRow)v.Row;

                    qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                    string resFoundLevel = qs2.core.language.sqlLanguage.getRes(rCrit.FldShort, enumTypResSearch, IDParticipant, rCrit.IDApplication, ref  rLangFoundReturn, true, true,
                                                                                    core.language.sqlLanguage.eLanguage.NoText, CheckLabelForQuery);
                    if (resFoundLevel.Trim() == "")
                    {
                        if (alwaysTranslate)
                        {
                            rGridCrit.Cells[qs2.core.generic.columnNameText].Value = rCrit.FldShort;        //rCrit.FldShort;
                        }
                        else
                        {
                            rGridCrit.Cells[qs2.core.generic.columnNameText].Value = "";        //rCrit.FldShort;
                        }
                     }
                    else
                        rGridCrit.Cells[qs2.core.generic.columnNameText].Value = resFoundLevel;

                    if (resetNewTranlsation)
                    {
                        rGridCrit.Cells[columnNewTranslation].Value = "";   
                    }

                    //string resFoundLevelRight = qs2.core.language.sqlLanguage.getRes(rCrit.FldShort, core.Enums.eResourceType.LabelRight, qs2.core.license.doLicense.rParticipant.IDParticipant, rCrit.IDApplication);
                    //if (resFoundLevelRight.Trim() == "")
                    //{
                    //    if (this.chkLeaveNotFoundedTextEmpty.Checked)
                    //        rGridCrit.Cells[qs2.core.generic.columnNameText].ToolTipText  = "";
                    //    else
                    //        rGridCrit.Cells[qs2.core.generic.columnNameText].ToolTipText = rCrit.FldShort;
                    //}
                    //else
                    //    rGridCrit.Cells[qs2.core.generic.columnNameText].ToolTipText = resFoundLevelRight;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ui.translateCriterias:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
    }
}
 
