using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global.db.Global;
using Infragistics.Win.UltraWinTree;
using PMDS.GUI.VB;


namespace PMDS.GUI.BaseControls
{


    public partial class ucBenutzerCheckList : QS2.Desktop.ControlManagment.BaseControl
    {
        public event EventHandler CheckedChanged;
        public bool IsInitialized = false;

        public contSelectPatientenBenutzer contSelectPatientenBenutzer1 = null;






        public ucBenutzerCheckList()
        {
            InitializeComponent();
        }

        private void ucBenutzerCheckList_Load(object sender, EventArgs e)
        {

        }





        public void initControl()
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this.contSelectPatientenBenutzer1 = new contSelectPatientenBenutzer();
                    this.contSelectPatientenBenutzer1.Dock = DockStyle.Fill;
                    this.Controls.Add(this.contSelectPatientenBenutzer1); 

                    bool isTxtTemplate = false;
                    this.contSelectPatientenBenutzer1.LabelPickerAlternate = QS2.Desktop.ControlManagment.ControlManagment.getRes("Empfänger");
                    this.contSelectPatientenBenutzer1.SendEventPatientUsersWhenSelectChanged = true;
                    this.contSelectPatientenBenutzer1.noExceptionIfUserNotFound = true;
                    this.contSelectPatientenBenutzer1.initControl(VB.contSelectPatientenBenutzer.eTypeUI.Users, false, isTxtTemplate, null);
                    this.contSelectPatientenBenutzer1.treeBenutzerPatientsSelected.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.Details;
                    this.contSelectPatientenBenutzer1.treeBenutzerPatientsSelected.ViewSettingsDetails.ColumnAutoSizeMode = Infragistics.Win.UltraWinListView.ColumnAutoSizeMode.AllItemsAndHeader;
                    this.contSelectPatientenBenutzer1.bShowAlleWhen0Selected = false;
                    this.contSelectPatientenBenutzer1.loadDataAbtBereiche();
                    this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);
                    this.contSelectPatientenBenutzer1._TypePatientenUserPickerChanged = eTypePatientenUserPickerChanged.none;
                    ENV.delPatientenUersPickerValueChanged += new dPatientenUersPickerValueChanged(this.PatientenUersPickerValueChanged);

                    this.contSelectPatientenBenutzer1.btnSelectSave.Visible = false;
                    this.contSelectPatientenBenutzer1.lblSelected.Visible = false;
                    
                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucBenutzerCheckList.initControl: " + ex.ToString());
            }

        }

        public void PatientenUersPickerValueChanged(Nullable<Guid> IDKlinik, Nullable<Guid> IDAbteilung, Nullable<Guid> IDBereich, System.Collections.Generic.List<Guid> lstSelectedUsersPatients, UltraTreeNode treeNodeKlinik,
                                                    eTypePatientenUserPickerChanged TypePatientenUserPickerChanged)
        {
            try
            {
                if (TypePatientenUserPickerChanged == this.contSelectPatientenBenutzer1._TypePatientenUserPickerChanged)
                {
                    if (CheckedChanged != null)
                        CheckedChanged(this, EventArgs.Empty);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucBenutzerCheckList.PatientenUersPickerValueChanged: " + ex.ToString());
            }
        }

        public List<Guid> SELECTED
        {
            get
            {
                List<Guid> al2 = new List<Guid>();
                if (ENV.AppRunning)
                {
                    this.initControl();
                    al2 = this.contSelectPatientenBenutzer1.getList();
                }
            
                return al2;
            }
            set
            {
                if (ENV.AppRunning)
                {
                    this.initControl();

                    bool IDFoundInTree2 = false;
                    Nullable<Guid> GuidNull = null;
                    this.contSelectPatientenBenutzer1.loadBenutzerPatients(ref GuidNull, ref GuidNull, ref GuidNull, false, true, ref IDFoundInTree2, true);

                    this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);

                    string lstIDUsers = "";
                    foreach (Guid IDUser in value)
                    {
                        lstIDUsers += IDUser.ToString() + ";";
                    }
                    this.contSelectPatientenBenutzer1.loadDataColl(ref lstIDUsers);
                    this.contSelectPatientenBenutzer1.setLabelCount2();
                    this.contSelectPatientenBenutzer1.setIconToSelectedObjects(null, true, false);
                }
            }
        }
        
    }

}

