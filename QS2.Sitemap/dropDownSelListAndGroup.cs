using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;





namespace qs2.sitemap
{


    public partial class dropDownSelListAndGroup : UserControl
    {

        public qs2.core.vb.sqlAdmin sqlAdmin1 = new qs2.core.vb.sqlAdmin();
        public string IDParticipant = "";
        public bool showColType = false;
        


        public dropDownSelListAndGroup()
        {
            InitializeComponent();
        }

        private void dropDownCountries_Load(object sender, EventArgs e)
        {

        }

        public void initControl(bool IDValueMember, bool IDOwnIntValueMember, bool IDOwnStrValueMember,
                                bool TranslateColAsDisplayMember, bool minimalColumnsVisible, bool IDRessValueMember)
        {
            try
            {
                this.sqlAdmin1.initControl();
                this.loadRes(IDValueMember, IDOwnIntValueMember, IDOwnStrValueMember, TranslateColAsDisplayMember, minimalColumnsVisible, IDRessValueMember);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void loadRes(bool IDValueMember, bool IDOwnIntValueMember, bool IDOwnStrValueMember,
                                bool TranslateColAsDisplayMember, bool minimalColumnsVisible, bool IDRessValueMember)
        {

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }

            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Hidden = false;
            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup .s_IDOwnIntColumn.ColumnName].Hidden = !IDOwnIntValueMember;
            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_IDOwnStrColumn.ColumnName].Hidden = !IDOwnStrValueMember;
            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_IDColumn.ColumnName].Hidden = !IDValueMember;

            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_IDRessourceColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Entry");
            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_IDOwnStrColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Key");
            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_IDOwnIntColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Key");
            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_IDColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Key");
            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[ qs2.core.generic.columnNameText].Header.Caption = qs2.core.language.sqlLanguage.getRes("Translation");

            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.g_IDApplicationColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Application");
            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.g_IDParticipantColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Participant");
            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.g_IDGroupStrColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Group");
            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_TypeStrColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Typ");

            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.g_VersionNrFromColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("VersionFrom");
            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.g_VersionNrToColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("VersionTo");

            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_TypeStrColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Typ");

            if (IDValueMember)
            {
                this.ultraDropDownSelListsWithGroup.ValueMember = this.dsAdmin1.vListEntriesWithGroup.s_IDColumn.ColumnName;  
            }
            if (IDOwnIntValueMember)
            {
                this.ultraDropDownSelListsWithGroup.ValueMember = this.dsAdmin1.vListEntriesWithGroup.s_IDOwnIntColumn.ColumnName;  
            }
            if (IDOwnStrValueMember)
            {
                this.ultraDropDownSelListsWithGroup.ValueMember = this.dsAdmin1.vListEntriesWithGroup.s_IDOwnStrColumn.ColumnName; 
            }
            if (IDRessValueMember)
            {
                this.ultraDropDownSelListsWithGroup.ValueMember = this.dsAdmin1.vListEntriesWithGroup.s_IDRessourceColumn.ColumnName; 
            }

            if (TranslateColAsDisplayMember)
            {
                this.ultraDropDownSelListsWithGroup.DisplayMember = qs2.core.generic.columnNameText;
            }
                

            if (minimalColumnsVisible)
            {
                this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_IDOwnStrColumn.ColumnName].Hidden = true;
                this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_IDColumn.ColumnName].Hidden = true;
                this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.g_IDApplicationColumn.ColumnName].Hidden = true;
                this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.g_IDParticipantColumn.ColumnName].Hidden = true;
                this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.g_IDGroupStrColumn.ColumnName].Hidden = true;
                this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_IDRessourceColumn.ColumnName].Hidden = true;
                this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_IDOwnIntColumn.ColumnName].Hidden = false;
                this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[qs2.core.generic.columnNameText].Header.Caption = qs2.core.language.sqlLanguage.getRes("Selection");
                this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_CreatedColumn.ColumnName].Hidden = true;
                this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_CreatedUserColumn.ColumnName].Hidden = true;
                this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_TypeStrColumn.ColumnName].Hidden = true;
                this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.g_TypeEnumColumn.ColumnName].Hidden = true;
                this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_PrivateColumn.ColumnName].Hidden = true;

                this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_IDOwnIntColumn.ColumnName].Width = 60;
                this.ultraDropDownSelListsWithGroup.Width = 500;
            }

            this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].Columns[this.dsAdmin1.vListEntriesWithGroup.s_TypeStrColumn.ColumnName].Hidden = !this.showColType;

        }
        public void setWidthDropDown(int width)
        {
            this.ultraDropDownSelListsWithGroup.Width = width;
        }

        public void loadData(string  group, string Application, Boolean clear)
        {
            try
            {
                if (clear) this.dsAdmin1.vListEntriesWithGroup.Clear();
                this.sqlAdmin1.getSelListEntrysRelGroup(group, "", Application, ref this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypAuswahlList.group);
                this.ultraDropDownSelListsWithGroup.Refresh();

                foreach ( UltraGridRow  rGridEntryObj in this.ultraDropDownSelListsWithGroup.Rows)
                {
                    DataRowView v = (DataRowView)rGridEntryObj.ListObject;
                    qs2.core.vb.dsAdmin.vListEntriesWithGroupRow rEntryObj = (qs2.core.vb.dsAdmin.vListEntriesWithGroupRow)v.Row;
                    string resFound = qs2.core.language.sqlLanguage.getRes(rEntryObj.s_IDRessource , this.IDParticipant, rEntryObj.g_IDApplication);
                    if (resFound.Trim() == "")
                    {
                        rGridEntryObj.Cells[qs2.core.generic.columnNameText].Value = rEntryObj.g_IDRessource;
                    }
                    else
                    {
                        rGridEntryObj.Cells[qs2.core.generic.columnNameText].Value = resFound;
                    }  
                }

                this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].SortedColumns.Clear();
                this.ultraDropDownSelListsWithGroup.DisplayLayout.Bands[0].SortedColumns.Add(this.dsAdmin1.vListEntriesWithGroup.s_sortColumn.ColumnName, false);

                this.ultraDropDownSelListsWithGroup.Refresh();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }

        }
    }
}
