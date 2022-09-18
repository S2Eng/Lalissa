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


    public partial class dropDownSelList : UserControl
    {

        public qs2.core.vb.sqlAdmin sqlAdmin1 = new qs2.core.vb.sqlAdmin();
        public string IDParticipant = "";





        public dropDownSelList()
        {
            InitializeComponent();
        }

        private void dropDownCountries_Load(object sender, EventArgs e)
        {

        }

        public void initControl(bool IDOwnIntValueMember, bool IDOwnStrValueMember )
        {
            try
            {
                this.sqlAdmin1.initControl();
                this.loadRes(IDOwnIntValueMember, IDOwnStrValueMember );
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void loadRes(bool IDOwnIntValueMember, bool IDOwnStrValueMember)
        {
            this.ultraDropDownSelLists.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName].Hidden = !IDOwnIntValueMember;
            this.ultraDropDownSelLists.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDOwnStrColumn.ColumnName].Hidden = !IDOwnStrValueMember;

            this.ultraDropDownSelLists.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Entry");
            this.ultraDropDownSelLists.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDOwnStrColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Key");
            this.ultraDropDownSelLists.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Key");
            this.ultraDropDownSelLists.DisplayLayout.Bands[0].Columns[this.dsAdmin1.tblSelListEntries.PrivateColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Private");
            this.ultraDropDownSelLists.DisplayLayout.Bands[0].Columns[qs2.core .generic.columnNameText].Header.Caption = qs2.core.language.sqlLanguage.getRes("Translation");

            if (IDOwnIntValueMember)
                this.ultraDropDownSelLists.ValueMember = this.dsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName;
            if (IDOwnStrValueMember)
                this.ultraDropDownSelLists.ValueMember = this.dsAdmin1.tblSelListEntries.IDOwnStrColumn.ColumnName;
        }


        public void loadData(string group, string IDApplication)
        {
            try
            {
                this.dsAdmin1.tblSelListEntries.Clear();
                qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                this.sqlAdmin1.getSelListEntrys(ref Parameters, group, this.IDParticipant, IDApplication.ToString(), ref this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypAuswahlList.group);
                this.ultraDropDownSelLists.Refresh();

                foreach (UltraGridRow rGridEntryObj in this.ultraDropDownSelLists.Rows)
                {
                    DataRowView v = (DataRowView)rGridEntryObj.ListObject;
                    qs2.core.vb.dsAdmin.tblSelListEntriesRow rEntryObj = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)v.Row;
                    string resFound = qs2.core.language.sqlLanguage.getRes(rEntryObj.IDRessource, this.IDParticipant, IDApplication.ToString());
                    if (resFound.Trim() == "")
                    {
                        rGridEntryObj.Cells[qs2.core.generic.columnNameText].Value = rEntryObj.IDRessource;
                    }
                    else
                    {
                        rGridEntryObj.Cells[qs2.core.generic.columnNameText].Value = resFound;
                    }
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void clearData()
        {
            try
            {
                this.dsAdmin1.tblSelListEntries.Clear();
                this.ultraDropDownSelLists.Refresh();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
    }
}
