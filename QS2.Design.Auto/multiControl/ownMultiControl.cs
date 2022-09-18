using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using qs2.sitemap.ownControls;
using qs2.sitemap.ownControls.inherit_Infrag;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.FormattedLinkLabel;
using Infragistics.Win;
using Infragistics.Win.Misc;
using QS2.Resources;
using qs2.sitemap.workflowAssist;

namespace qs2.design.auto.multiControl
{


    [Designer(typeof(qs2.design.auto.multiControl.DesignerWizardCheck))]
    public partial class ownMultiControl : UserControl
    {
        public string _FldShort = "";
        public string[] _FldShorts;

        public qs2.core.Enums.eControlType _controlType;
        public qs2.sitemap.workflowAssist.form.contAutoUI parentAutoUI; //{ get; set;}
        public qs2.core.vb.dsAdmin.dbAutoUIRow rAutoUI { get; set; } = null;

        public UltraTextEditor Textfield { get; set; } = null;
        public UltraNumericEditor Numeric { get; set; } = null;
        public UltraComboEditor ComboBox { get; set; } = null;
        public UltraDropDownButton DropDown { get; set; }= null;
        public Infragistics.Win.Misc.UltraPopupControlContainer DropDownPopupControlContainer { get; set; } = null;
        public qs2.design.auto.multiControl.contOnwMultiControlGrid ControlForDropDown { get; set; } = null;
        public UltraDateTimeEditor Date { get; set; } = null;
        public UltraDateTimeEditor DateTime { get; set; } = null;
        public UltraDateTimeEditor Time { get; set; } = null;
        public InfragCheckBox ThreeStateCheckBox { get; set; } = null;
        public UltraPictureBox Picture { get; set; } = null;
        public UltraCheckEditor CheckBox { get; set; } = null;
        public UltraFormattedTextEditor TextfieldMulti { get; set; } = null;

        public System.Windows.Forms.Control _control;

        public ownMCCriteria ownMCCriteria1 = new ownMCCriteria();
        public ownMCDataBind ownMCDataBind1 = new ownMCDataBind();
        public ownMCEvents ownMCEvents1 = new ownMCEvents();
        public ownMCFormat ownMCFormat1 = new ownMCFormat();
        public ownMCValue ownMCValue1 = new ownMCValue();
        public ownMCInfo ownMCInfo1 = new ownMCInfo();
        public ownMCTxt ownMCTxt1 = new ownMCTxt();
        public ownMCUI ownMCUI1 = new ownMCUI();

        public bool isLoaded = false;
        public bool _isEnabled = false;

        public System.Guid key = System.Guid.NewGuid();

        private int _OwnLevelLeftWidth = 0;
        private int _OwnLevelRightWidth = 0;
        public bool _OwnLevelLeftVisible { get; set; } = false;
        private bool _OwnLevelTopVisible = false;
        public bool _OwnLevelRightVisible { get; set; } = false;
        private Infragistics.Win.HAlign _OwnLevelLeftOrientationHoriz;
        private Infragistics.Win.HAlign _OwnLevelRightOrientationHoriz;
        private Infragistics.Win.DefaultableBoolean _OwnLevelLeftFontDataBold = DefaultableBoolean.False;

        private int _OwnOrderLineNr = 1;
        private int _OwnOrderControlNr = 1;
        private int _OwnOrder = 1;

        private bool _OwnFieldForALLProducts = false;
        private string _OwnOnlyForProducts = "";
        private bool _OwnNotResetValue = false;
        private bool _OwnDoNotPrint = false;
        private bool _OwnInfoTop = false;
        
        //public qs2.core.vb.funct funct1 { get; set; } = new qs2.core.vb.funct();
        //public qs2.core.generic generic1 { get; set; } = new qs2.core.generic();


        //Queries
        public qs2.core.vb.dsAdmin.tblQueriesDefRow rQry;
        public qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListQry;


        public bool placeFix = false;
        public bool isSubQuery = false;
        public bool PropertyVisibleIsActive = false;

        public bool panelButtonsVisible = false;

        public bool visibleIsInProgress = false;
        public bool valueTaken = false;

        public System.Guid ID = System.Guid.Empty;
        public System.Guid IDGroup = System.Guid.Empty;
        public System.Guid IDGroupReport = System.Guid.Empty;

        public bool _txtIsLoaded = false;

        public enum eTypActionControl
        {
            selectAll = 0,
            CheckMinMaxxy = 1,
            clearErrorProvider = 2,
            showError = 3,
            setEditableAndFocus = 4,
            GetControlInfo = 5,
            ClearFocus = 6,
            SetFocus = 7,
            TabIndexOnOff = 8,
            place = 9,
            clearMC = 10,
            NoticeValueBeforeChangedFromUser = 11,
            clearError = 12
        }
        public bool doControlIsDone = false;
        public bool isParameterHeader = false;
        public System.Guid ParIDGuid = System.Guid.Empty;
        public bool TranslatedValueFound = false;

        public bool IsEvaluation = false;
        public static int fontsize = 10;

        public int countButtonsRigth = 1;
        public qs2.design.auto.multiControl.ownMultiControl ownMultiControlChild = null;
        public bool IsBetweenControlSecondValue = false;
        public bool IsInUseInparameterList = false;

        public bool TxtBoxForComboIsInitialized = false;
        public bool IsComboBoxWithTxtBox = false;
        
        public contListAssistentElem chapter = null;
        public bool chapterDone = false;
        public static int counterMCHasChapters = 0;
        public static int counterMCHasNoChapters = 0;

        public bool hasINCondition = false;
        public string INCondition = "";
        public qs2.core.Enums.eControlType controlTypeINCondition;
        public qs2.design.auto.workflowAssist.autoForm.ColorSchemas ColorSchemas1 = new qs2.design.auto.workflowAssist.autoForm.ColorSchemas();

        public object ValueBeforeChangedFromUser = null;

        public delegate void eMCValueChanged();
        public ownMultiControl.eMCValueChanged MCValueChanged;


        public ownMultiControl()
        {
            InitializeComponent();

        }

        public void doControl()
        {
            try
            {
                if (this.DesignMode)
                {
                    this.setControl(false);
                    this.ownMCCriteria1.getLicenseDesignTime(this);
                }

                this.ownMCTxt1.doText(this, false, this.DesignMode);
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiControl.doControl", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void setControl(bool LabelRightOn)
        {
            try
            {
                //this.SuspendLayout();

                if (!DesignMode)
                {
                    if (this.doControlIsDone)
                    {
                        return;
                    }
                }

                foreach (Control cont in msPanelControls3.ClientArea.Controls)
                {
                    cont.TabStop = false;
                    cont.Visible = false;
                }

                this.ownMCEvents1.ownControl1 = this;
                this.ownMCUI1.ownMultiControl1 = this;

                this.infragLabelLeft.Appearance.FontData.SizeInPoints = ownMultiControl.fontsize;
                this.infragLabelRight.Appearance.FontData.SizeInPoints = ownMultiControl.fontsize;
                
                if (this._controlType == core.Enums.eControlType.Integer ||
                    this._controlType == core.Enums.eControlType.IntegerNoDb ||
                    this._controlType == core.Enums.eControlType.Numeric ||
                    this._controlType == core.Enums.eControlType.NumericNoDb)
                {
                    if (this.Numeric == null)
                    {
                        this.Numeric = new UltraNumericEditor();
                        this.Numeric.AutoSize = false;
                        this.Numeric.Name = core.Enums.eControlType.Numeric.ToString();
                        this.Numeric.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.msPanelControls3.ClientArea.Controls.Add(this.Numeric);

                        Application.DoEvents();
                        this.Numeric.ValueChanged += new System.EventHandler(this.ownMCEvents1.ControlValueChanged);
                        this.Numeric.Enter += new System.EventHandler(this.ownMCEvents1.ControlEnter);
                        this.Numeric.Leave += new System.EventHandler(this.ownMCEvents1.ControlLeave);
                        this.Numeric.GotFocus += new System.EventHandler(this.ownMCEvents1.GotFocus);
                        this.Numeric.LostFocus += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.Numeric.MouseHover += new System.EventHandler(this.ownMCEvents1.MouseHover);
                        this.Numeric.MouseLeave += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.Numeric.TabStop = true;
                        this.Numeric.TabIndex = 0;
                        this.Numeric.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;        //Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
                        this.Numeric.Nullable = true;
                        this.Numeric.Appearance.FontData.SizeInPoints = ownMultiControl.fontsize;
                    }
                    this._control = this.Numeric;
                    this.Numeric.Visible = true;
                }
                else if (this._controlType == core.Enums.eControlType.ComboBox || this._controlType == core.Enums.eControlType.ComboBoxNoDb)
                {
                    if (this.ComboBox == null)
                    {
                        this.ComboBox = new UltraComboEditor();
                        this.ComboBox.AutoSize = false;
                        this.ComboBox.DropDownStyle = DropDownStyle.DropDown;
                        this.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
                        this.ComboBox.AutoSuggestFilterMode = AutoSuggestFilterMode.Contains;
                        this.ComboBox.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
                        this.ComboBox.ButtonStyle = UIElementButtonStyle.Flat;
                        this.ComboBox.UseFlatMode = DefaultableBoolean.True;
                        this.ComboBox.Name = core.Enums.eControlType.ComboBox.ToString();
                        this.ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.msPanelControls3.ClientArea.Controls.Add(this.ComboBox);

                        this.ComboBox.ValueChanged += new System.EventHandler(this.ownMCEvents1.ControlValueChanged);
                        this.ComboBox.KeyPress += new KeyPressEventHandler(this.ownMCEvents1.KeyPress);
                        this.ComboBox.KeyDown += new KeyEventHandler(this.ownMCEvents1.KeyDown);
                        this.ComboBox.Enter += new System.EventHandler(this.ownMCEvents1.ControlEnter);
                        this.ComboBox.Leave += new System.EventHandler(this.ownMCEvents1.ControlLeave);
                        this.ComboBox.GotFocus += new System.EventHandler(this.ownMCEvents1.GotFocus);
                        this.ComboBox.LostFocus += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.ComboBox.MouseHover += new System.EventHandler(this.ownMCEvents1.MouseHover);
                        this.ComboBox.MouseLeave += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.ComboBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ownMCEvents1.MouseDown);
                        this.ComboBox.TabStop = true;
                        this.ComboBox.TabIndex = 0;
                        this.ComboBox.HideSelection = false;
                        this.ComboBox.Appearance.FontData.SizeInPoints = ownMultiControl.fontsize;
                    }
                    this._control = this.ComboBox;
                    this.ComboBox.Visible = true;
                }

                else if (this._controlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox)
                {
                    if (this.ComboBox == null)
                    {
                        this.ComboBox = new UltraComboEditor();
                        this.ComboBox.AutoSize = false;
                        this.ComboBox.DropDownStyle = DropDownStyle.DropDown;
                        this.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
                        this.ComboBox.AutoSuggestFilterMode = AutoSuggestFilterMode.Contains;
                        this.ComboBox.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
                        this.ComboBox.ButtonStyle = UIElementButtonStyle.Flat;
                        this.ComboBox.UseFlatMode = DefaultableBoolean.True;
                        this.ComboBox.Name = core.Enums.eControlType.ComboBoxCheckThreeStateBox.ToString();
                        this.ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.msPanelControls3.ClientArea.Controls.Add(this.ComboBox);

                        this.ComboBox.ValueChanged += new System.EventHandler(this.ownMCEvents1.ControlValueChanged);
                        this.ComboBox.Enter += new System.EventHandler(this.ownMCEvents1.ControlEnter);
                        this.ComboBox.Leave += new System.EventHandler(this.ownMCEvents1.ControlLeave);
                        this.ComboBox.GotFocus += new System.EventHandler(this.ownMCEvents1.GotFocus);
                        this.ComboBox.LostFocus += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.ComboBox.MouseHover += new System.EventHandler(this.ownMCEvents1.MouseHover);
                        this.ComboBox.MouseLeave += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.ComboBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ownMCEvents1.MouseDown);
                        this.ComboBox.TabStop = true;
                        this.ComboBox.TabIndex = 0;
                        this.ComboBox.HideSelection = false;
                        this.ComboBox.Appearance.FontData.SizeInPoints = ownMultiControl.fontsize;
                    }
                    this._control = this.ComboBox;
                    this.ComboBox.Visible = true;
                }

                else if (this._controlType == core.Enums.eControlType.ComboBoxAsDropDown)
                {
                    if (this.DropDown == null || this.DropDown != null)
                    {
                        this.DropDown = new UltraDropDownButton();
                        this.DropDown.AutoSize = false;
                        this.DropDown.Name = core.Enums.eControlType.ComboBoxAsDropDown.ToString();
                        this.DropDown.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.DropDown.BackColorInternal = System.Drawing.SystemColors.Control;

                        this.DropDown.Enter += new System.EventHandler(this.ownMCEvents1.ControlEnter);
                        this.DropDown.Leave += new System.EventHandler(this.ownMCEvents1.ControlLeave);
                        this.DropDown.GotFocus += new System.EventHandler(this.ownMCEvents1.GotFocus);
                        this.DropDown.LostFocus += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.DropDown.MouseHover += new System.EventHandler(this.ownMCEvents1.MouseHover);
                        this.DropDown.MouseLeave += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.DropDown.TabStop = true;
                        this.DropDown.TabIndex = 0;
                        this.DropDown.Appearance.FontData.SizeInPoints = ownMultiControl.fontsize;
                        this.DropDown.Enabled = true;
                        this.DropDown.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                        this.DropDown.Location = new System.Drawing.Point(0, 0);
                        this.DropDown.PopupItemKey = "ucPicker1";
                        this.DropDown.Size = new System.Drawing.Size(179, 27);
                        this.DropDown.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
                        this.DropDown.Text = "";
                        this.DropDown.Appearance.ForeColor = System.Drawing.Color.Black;
                        this.DropDown.Appearance.ForeColorDisabled = System.Drawing.Color.Black;
                        this.DropDown.Appearance.BackColor = System.Drawing.Color.White;
                        this.DropDown.Appearance.BackColorDisabled = System.Drawing.Color.White;
                        this.DropDown.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                        this.DropDown.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                        this.msPanelControls3.ClientArea.Controls.Add(this.DropDown);

                        this.DropDownPopupControlContainer = new UltraPopupControlContainer(this.components);
                        this.DropDown.PopupItemProvider = this.DropDownPopupControlContainer;
                        this.DropDownPopupControlContainer.Opened += new System.EventHandler(this.ownMCEvents1.popupContainer_Opened);
                        this.DropDown.PopupItem = this.DropDownPopupControlContainer;

                        this.ControlForDropDown = new qs2.design.auto.multiControl.contOnwMultiControlGrid();
                        this.ControlForDropDown.panelGrid.Dock = DockStyle.Fill;
                        this.DropDown.Dock = DockStyle.Fill;
                        this.DropDownPopupControlContainer.PopupControl = this.ControlForDropDown.panelGrid;
                        this.ControlForDropDown._DropDown = this.DropDown;
                        this.ControlForDropDown.ownMC = this;
                        this.ControlForDropDown.initControl();
                    }
                    this._control = this.DropDown;
                    this.DropDown.Visible = true;
                }

                else if (this._controlType == core.Enums.eControlType.DateTime || this._controlType == core.Enums.eControlType.DateTimeNoDb)
                {
                    if (this.DateTime == null)
                    {
                        this.DateTime = new UltraDateTimeEditor();
                        this.DateTime.AutoSize = false;
                        this.DateTime.Name = core.Enums.eControlType.DateTime.ToString();
                        this.DateTime.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.msPanelControls3.ClientArea.Controls.Add(this.DateTime);

                        this.DateTime.ValueChanged += new System.EventHandler(this.ownMCEvents1.ControlValueChanged);
                        this.DateTime.Enter += new System.EventHandler(this.ownMCEvents1.ControlEnter);
                        this.DateTime.Leave += new System.EventHandler(this.ownMCEvents1.ControlLeaveDateTime);
                        this.DateTime.Leave += new System.EventHandler(this.ownMCEvents1.ControlLeave);
                        this.DateTime.GotFocus += new System.EventHandler(this.ownMCEvents1.GotFocus);
                        this.DateTime.LostFocus += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.DateTime.MouseHover += new System.EventHandler(this.ownMCEvents1.MouseHover);
                        this.DateTime.MouseLeave += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.DateTime.TabStop = true;
                        this.DateTime.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
                        this.DateTime.TabIndex = 0;
                        this.DateTime.Appearance.FontData.SizeInPoints = ownMultiControl.fontsize;
                    }
                    this._control = this.DateTime;
                    this.DateTime.Visible = true;
                }

                else if (this._controlType == core.Enums.eControlType.Date || this._controlType == core.Enums.eControlType.DateNoDb)
                {
                    if (this.Date == null)
                    {
                        this.Date = new UltraDateTimeEditor();
                        this.Date.Name = core.Enums.eControlType.Date.ToString();
                        this.Date.AutoSize = false;
                        this.Date.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.msPanelControls3.ClientArea.Controls.Add(this.Date);

                        this.Date.ValueChanged += new System.EventHandler(this.ownMCEvents1.ControlValueChanged);
                        this.Date.Enter += new System.EventHandler(this.ownMCEvents1.ControlEnter);
                        this.Date.Leave += new System.EventHandler(this.ownMCEvents1.ControlLeaveDateTime);
                        this.Date.Leave += new System.EventHandler(this.ownMCEvents1.ControlLeave);
                        this.Date.GotFocus += new System.EventHandler(this.ownMCEvents1.GotFocus);
                        this.Date.LostFocus += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.Date.MouseHover += new System.EventHandler(this.ownMCEvents1.MouseHover);
                        this.Date.MouseLeave += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.Date.TabStop = true;
                        this.Date.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
                        this.Date.TabIndex = 0;
                        this.Date.Appearance.FontData.SizeInPoints = ownMultiControl.fontsize;
                    }
                    this._control = this.Date;
                    this.Date.Visible = true;
                }

                else if (this._controlType == core.Enums.eControlType.Time || this._controlType == core.Enums.eControlType.TimeNoDb)
                {
                    if (this.Time == null)
                    {
                        this.Time = new UltraDateTimeEditor();
                        this.Time.AutoSize = false;
                        this.Time.Name = core.Enums.eControlType.Time.ToString();
                        this.Time.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.msPanelControls3.ClientArea.Controls.Add(this.Time);
                        this.Time.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
                        this.Time.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;

                        this.Time.ValueChanged += new System.EventHandler(this.ownMCEvents1.ControlValueChanged);
                        this.Time.Enter += new System.EventHandler(this.ownMCEvents1.ControlEnter);
                        this.Time.Leave += new System.EventHandler(this.ownMCEvents1.ControlLeaveDateTime);
                        this.Time.Leave += new System.EventHandler(this.ownMCEvents1.ControlLeave);
                        this.Time.GotFocus += new System.EventHandler(this.ownMCEvents1.GotFocus);
                        this.Time.LostFocus += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.Time.MouseHover += new System.EventHandler(this.ownMCEvents1.MouseHover);
                        this.Time.MouseLeave += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.Time.TabStop = true;
                        this.Time.TabIndex = 0;
                        this.Time.Appearance.FontData.SizeInPoints = ownMultiControl.fontsize;
                    }
                    this._control = this.Time;
                    this.Time.Visible = true;
                }

                else if (this._controlType == core.Enums.eControlType.Textfield || this._controlType == core.Enums.eControlType.TextfieldNoDb)
                {
                    if (this.Textfield == null)
                    {
                        this.Textfield = new UltraTextEditor();
                        this.Textfield.Name = core.Enums.eControlType.Textfield.ToString();
                        this.Textfield.AutoSize = false;
                        this.Textfield.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.msPanelControls3.ClientArea.Controls.Add(this.Textfield);

                        this.Textfield.ValueChanged += new System.EventHandler(this.ownMCEvents1.ControlValueChanged);
                        this.Textfield.Enter += new System.EventHandler(this.ownMCEvents1.ControlEnter);
                        this.Textfield.Leave += new System.EventHandler(this.ownMCEvents1.ControlLeave);
                        this.Textfield.GotFocus += new System.EventHandler(this.ownMCEvents1.GotFocus);
                        this.Textfield.MouseHover += new System.EventHandler(this.ownMCEvents1.MouseHover);
                        this.Textfield.MouseLeave += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.Textfield.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ownMCEvents1.KeyPress);
                        this.Textfield.TabStop = true;
                        this.Textfield.TabIndex = 0;
                        this.Textfield.Appearance.FontData.SizeInPoints = ownMultiControl.fontsize;
                    }
                    this._control = this.Textfield;
                    this.Textfield.Visible = true;
                }

                else if (this._controlType == core.Enums.eControlType.TextfieldMulti || this._controlType == core.Enums.eControlType.TextfieldMultiNoDb)
                {
                    if (this.TextfieldMulti == null)
                    {
                        this.TextfieldMulti = new UltraFormattedTextEditor();
                        this.TextfieldMulti.Name = core.Enums.eControlType.TextfieldMulti.ToString();
                        this.TextfieldMulti.AutoSize = false;
                        this.TextfieldMulti.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.msPanelControls3.ClientArea.Controls.Add(this.TextfieldMulti);

                        this.TextfieldMulti.ValueChanged += new System.EventHandler(this.ownMCEvents1.ControlValueChanged);
                        this.TextfieldMulti.Enter += new System.EventHandler(this.ownMCEvents1.ControlEnter);
                        this.TextfieldMulti.Leave += new System.EventHandler(this.ownMCEvents1.ControlLeave);
                        this.TextfieldMulti.GotFocus += new System.EventHandler(this.ownMCEvents1.GotFocus);
                        this.TextfieldMulti.LostFocus += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.TextfieldMulti.MouseHover += new System.EventHandler(this.ownMCEvents1.MouseHover);
                        this.TextfieldMulti.MouseLeave += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.TextfieldMulti.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ownMCEvents1.KeyPress);
                        this.TextfieldMulti.TabStop = true;
                        this.TextfieldMulti.TabIndex = 0;
                        this.TextfieldMulti.Appearance.FontData.SizeInPoints = ownMultiControl.fontsize;
                    }
                    this._control = this.TextfieldMulti;
                    this.TextfieldMulti.Visible = true;
                }

                else if (this._controlType == core.Enums.eControlType.CheckBox || this._controlType == core.Enums.eControlType.CheckBoxNoDb)
                {
                    if (this.CheckBox == null)
                    {
                        this.CheckBox = new UltraCheckEditor();
                        this.CheckBox.Name = core.Enums.eControlType.CheckBox.ToString();
                        this.CheckBox.AutoSize = false;                        
                        this.CheckBox.UseAppStyling = true; //os220609
                        this.CheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.msPanelControls3.ClientArea.Controls.Add(this.CheckBox);

                        this.CheckBox.BeforeCheckStateChanged += new Infragistics.Win.CheckEditor.BeforeCheckStateChangedHandler(this.ownMCEvents1.ControlBeforeCheckStateChanged);
                        this.CheckBox.AfterCheckStateChanged += new Infragistics.Win.CheckEditor.AfterCheckStateChangedHandler(this.ownMCEvents1.ControlValueChanged);
                        this.CheckBox.Enter += new System.EventHandler(this.ownMCEvents1.ControlEnter);
                        this.CheckBox.GotFocus += new System.EventHandler(this.ownMCEvents1.GotFocus);
                        this.CheckBox.LostFocus += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.CheckBox.MouseHover += new System.EventHandler(this.ownMCEvents1.MouseHover);
                        this.CheckBox.MouseLeave += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.CheckBox.TabStop = true;
                        this.CheckBox.TabIndex = 0;
                        this.CheckBox.Appearance.FontData.SizeInPoints = ownMultiControl.fontsize;
                    }
                    this._control = this.CheckBox;
                    this.CheckBox.Visible = true;
                }

                else if (this._controlType == core.Enums.eControlType.ThreeStateCheckBox || this._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                {
                    if (this.ThreeStateCheckBox == null)
                    {
                        this.ThreeStateCheckBox = new InfragCheckBox();
                        this.ThreeStateCheckBox.initControl();
                        this.ThreeStateCheckBox.Name = core.Enums.eControlType.ThreeStateCheckBox.ToString();
                        this.ThreeStateCheckBox.AutoSize = false;
                        this.ThreeStateCheckBox.UseAppStyling = true;   //os220609
                        this.ThreeStateCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ThreeStateCheckBox.ThreeState = true;
                        this.msPanelControls3.ClientArea.Controls.Add(this.ThreeStateCheckBox);
                        
                        this.ThreeStateCheckBox.BeforeCheckStateChanged += new Infragistics.Win.CheckEditor.BeforeCheckStateChangedHandler(this.ownMCEvents1.ControlBeforeCheckStateChanged);
                        this.ThreeStateCheckBox.evOnAfterCheckStateChanged += new qs2.sitemap.ownControls.inherit_Infrag.InfragCheckBox.dAfterCheckStateChanged(this.ownMCEvents1.ThreeStateCheckBoxAfterCheckStateChanged);
                        this.ThreeStateCheckBox.GotFocus += new System.EventHandler(this.ownMCEvents1.GotFocus);
                        this.ThreeStateCheckBox.LostFocus += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.ThreeStateCheckBox.MouseHover += new System.EventHandler(this.ownMCEvents1.MouseHover);
                        this.ThreeStateCheckBox.MouseLeave += new System.EventHandler(this.ownMCEvents1.LostFocus);
                        this.ThreeStateCheckBox.TabStop = true;
                        this.ThreeStateCheckBox.TabIndex = 0;
                        this.ThreeStateCheckBox.OwnTabIndex = 0;
                        this.ThreeStateCheckBox.Appearance.FontData.SizeInPoints = ownMultiControl.fontsize;
                    }
                    this._control = this.ThreeStateCheckBox;
                    this.ThreeStateCheckBox.Visible = true;
                }

                else if (this._controlType == core.Enums.eControlType.Label)
                {
                    this.msPanelControls3.Visible = false;
                    this.infragLabelLeft.Dock = DockStyle.Fill;
                    this.infragLabelLeft.Text = "";
                    this._OwnLevelLeftVisible = true;
                    this._OwnLevelRightVisible = false;
                    this._OwnLevelTopVisible = false;
                    this._control = this.infragLabelLeft;
                }

                else if (this._controlType == core.Enums.eControlType.Picture)
                {
                    if (this.Picture == null)
                    {
                        this.Picture = new UltraPictureBox();
                        this.Picture.Name = core.Enums.eControlType.Picture.ToString();
                        this.Picture.AutoSize = false;
                        this.Picture.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.msPanelControls3.ClientArea.Controls.Add(this.Picture);

                        this.Picture.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
                        this.Picture.ScaleImage = Infragistics.Win.ScaleImage.Always;
                        this.Picture.TabStop = true;
                        this.Picture.TabIndex = 0;
                    }
                    this.Picture.Image = null;
                    this._OwnLevelLeftVisible = false;
                    this._OwnLevelRightVisible = false;
                    this._OwnLevelTopVisible = false;
                    this.Picture.Visible = true;
                    this._control = this.Picture;
                }

                this.infragLabelLeft.MouseHover += new System.EventHandler(this.ownMCEvents1.MouseHover);
                this.infragLabelLeft.MouseLeave += new System.EventHandler(this.ownMCEvents1.LostFocus);

                this.infragLabelRight.MouseHover += new System.EventHandler(this.ownMCEvents1.MouseHover);
                this.infragLabelRight.MouseLeave += new System.EventHandler(this.ownMCEvents1.LostFocus);

                this.setLabels2(LabelRightOn, false, false);
                this.setLabelRightCheckBoxes();

                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
                {
                    this.ColorSchemas1.setAppearanceMC(this, null, null, this.OwnControlType);
                }                
                this.doControlIsDone = true;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiControl.setControl", "", false, true,
                                                                        this.ownMCCriteria1.Application,
                                                                        qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
            finally
            {
                //this.ResumeLayout();
            }
        }

        public void setControlTextBoxForCombo()
        {
            try
            {
                if (!this.IsEvaluation && !this.TxtBoxForComboIsInitialized)
                {
                    this.Textfield = new UltraTextEditor();
                    this.Textfield.Name = core.Enums.eControlType.Textfield.ToString();
                    this.Textfield.AutoSize = false;
                    this.Textfield.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.Textfield.TabStop = false;
                    this.Textfield.TabIndex = 0;
                    this.Textfield.Appearance.FontData.SizeInPoints = ownMultiControl.fontsize;
                    this.Textfield.Visible = false;
                    this.Textfield.ReadOnly = true;
                    this.Textfield.Enabled = false;
                    this.msPanelControls3.ClientArea.Controls.Add(this.Textfield);

                    this.IsComboBoxWithTxtBox = true;
                    this.TxtBoxForComboIsInitialized = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("setControlTextBoxForCombo: " + ex.ToString());
            }
        }

        public string getLabelText()
        {
            try
            {
                return (this.infragLabelLeft.Text.Trim() != "" ? this.infragLabelLeft.Text : (this.infragLabelRight.Text.Trim() != "" ? this.infragLabelRight.Text : this._FldShort));

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiControl.getLabelText", "", false, true,
                                                                        this.ownMCCriteria1.Application,
                                                                        qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return "";
            }
        }

        public void setLabels2(bool LabelRightOn, bool checkComboUserDefined, bool IsComboBoxRoles)
        {
            try
            {
                this.msPanelControls3.Visible = false;
                
                if (this._controlType == core.Enums.eControlType.ComboBox ||
                        this._controlType == core.Enums.eControlType.ComboBoxNoDb ||
                        this._controlType == core.Enums.eControlType.ComboBoxAsDropDown ||
                        this._controlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox ||
                        (this._controlType == core.Enums.eControlType.Textfield && this.hasINCondition))
                {
                    if (IsComboBoxRoles)
                    {
                        this.panelButtonsVisible = false;
                    }
                    else
                    {
                        if (!this.IsEvaluation && checkComboUserDefined)
                        {
                            if (this.ownMCCriteria1.rCriteria.UserDefined)
                            {
                                this.panelButtonsVisible = true;
                            }
                            else
                            {
                                this.panelButtonsVisible = false;
                            }
                        }
                        else
                        {
                            this.panelButtonsVisible = true;
                        }
                    }
                }
                else
                {
                    this.panelButtonsVisible = false;
                }

                if (this.DesignMode)
                {
                    this.panelButtonsVisible = false;
                }

                if (!this.placeFix)
                {
                    this.infragLabelLeft.Visible = this._OwnLevelLeftVisible;
                    this.infragLabelLeft.Width = this._OwnLevelLeftWidth;
                    this.infragLabelRight.Visible = this._OwnLevelRightVisible;
                    this.infragLabelRight.Width = this._OwnLevelRightWidth;
                    this.infragLabelLeft.Appearance.TextHAlign = this._OwnLevelLeftOrientationHoriz;
                    this.infragLabelRight.Appearance.TextHAlign = this._OwnLevelRightOrientationHoriz;
                    this.infragLabelLeft.Appearance.FontData.Bold = this._OwnLevelLeftFontDataBold;
                }

                if (this.countButtonsRigth == 1)
                {
                    //string xy = "";
                }
                else if (this.countButtonsRigth == 2)
                {
                    this.panelButtonsOnOff.Width = 45;
                }
                else if (this.countButtonsRigth == 3)
                {
                    this.panelButtonsOnOff.Width = 70;
                }
                else if (this.countButtonsRigth == 4)
                {
                    this.panelButtonsOnOff.Width = 95;
                }
                else
                {
                    throw new Exception("this.countButtonsRigth '" + this.countButtonsRigth.ToString() + "' not allowed!");
                }

                this.infragLabelLeft.Dock = DockStyle.None;
                this.infragLabelRight.Dock = DockStyle.None;
                this.msPanelControls3.Dock = DockStyle.None;
                this.panelButtonsOnOff.Dock = DockStyle.None;
                this.panelButtons.Dock = DockStyle.None;

                if (this.OwnLevelTopVisible)
                {
                    this.infragLabelLeft.Width = 0;
                    this._OwnLevelLeftWidth = 0;
                }
                else
                {
                    this.infragLabelLeft.Width = this._OwnLevelLeftWidth;
                }

                if (!this.OwnLevelLeftVisible)
                {
                    this.infragLabelLeft.Width = 0;
                    this._OwnLevelLeftWidth = 0;
                }

                this.panelButtons.Visible = panelButtonsVisible;
                this.infragLabelRight.Visible = LabelRightOn;

                if (LabelRightOn)
                {
                    this.infragLabelRight.Width = 25;
                }
                else
                {
                    this.infragLabelRight.Width = 0;
                }

                this.panelButtonsOnOff.Left = this.Width - this.panelButtonsOnOff.Width - this.infragLabelRight.Width;
                this.panelButtonsOnOff.Top = 0;
                this.panelButtonsOnOff.Height = this.Height;

                this.panelButtons.Left = 0;
                this.panelButtons.Top = 0;
                this.panelButtons.Width = this.panelButtonsOnOff.Width;
                this.panelButtons.Height = this.panelButtonsOnOff.Height;

                this.infragLabelLeft.Left = 0;
                this.infragLabelLeft.Top = 0;
                this.infragLabelLeft.Height = this.Height;
                this.infragLabelLeft.Appearance.TextHAlign = this._OwnLevelLeftOrientationHoriz;
                this.infragLabelLeft.Appearance.FontData.Bold = this._OwnLevelLeftFontDataBold;

                this.msPanelControls3.Left = this._OwnLevelLeftWidth;
                this.msPanelControls3.Top = 0;

                if (panelButtonsVisible)
                {
                    if (LabelRightOn)
                    {
                        this.msPanelControls3.Width = this.Width - this.infragLabelLeft.Width - this.infragLabelRight.Width - this.panelButtonsOnOff.Width;
                    }
                    else
                    {
                        this.msPanelControls3.Width = this.Width - this.infragLabelLeft.Width - this.panelButtons.Width;
                    }
                }
                else
                {
                    if (LabelRightOn)
                    {
                        this.msPanelControls3.Width = this.Width - this.infragLabelLeft.Width - this.infragLabelRight.Width;
                    }
                    else
                    {
                        this.msPanelControls3.Width = this.Width - this.infragLabelLeft.Width;
                    }
                }
                this.msPanelControls3.Height = this.Height;
                this.infragLabelRight.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                this.infragLabelRight.Left = this.Width - this.infragLabelRight.Width;
                this.infragLabelRight.Top = 0;
                this.infragLabelRight.Height = this.Height;
                this.infragLabelRight.Appearance.TextHAlign = this._OwnLevelRightOrientationHoriz;

                if (this._control != null)
                {
                    this._control.Dock = DockStyle.None;
                    this._control.Left = 0;
                    this._control.Top = 0;
                    this._control.Width = this.msPanelControls3.Width;
                    this._control.Height = this.msPanelControls3.Height;
                }
                qs2.core.generic.infoControl infoControl1 = new core.generic.infoControl ();
                this.doActionControl(eTypActionControl.place, ref infoControl1, false);

                if (this._controlType == core.Enums.eControlType.Label)
                {
                    this.infragLabelRight.Width = 0;
                    this.msPanelControls3.Width = 0;
                    this.infragLabelLeft.Width = this.Width;
                }

            }
            catch (Exception ex)
            {
                this.msPanelControls3.Visible = true;
                throw new Exception("ownMultiControl.setLabels; " + ex.ToString());
            }
            finally
            {
                this.msPanelControls3.Visible = true;
            }
        }

        private void setLabelRightCheckBoxes()
        {
            if (this._controlType == core.Enums.eControlType.CheckBox ||
                this._controlType == core.Enums.eControlType.CheckBoxNoDb)
            {
                this._OwnLevelRightVisible = false;
                this.CheckBox.Appearance.TextHAlign = this.infragLabelRight.Appearance.TextHAlign;
            }
            else if (this._controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                this._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
            {
                this._OwnLevelRightVisible = false;
                this.ThreeStateCheckBox.Appearance.TextHAlign = this.infragLabelRight.Appearance.TextHAlign;
            }
        }

        public string OwnFldShort
        {
            get
            {
                return this._FldShort;
            }
            set
            {
                this._FldShort = value;
                if (this.DesignMode)
                {
                    this.infragLabelLeft.Text = "[" + this._FldShort + "]";
                    this.infragLabelRight.Text = "[" + this._FldShort + "]";
                    this.doControl();
                }
            }
        }

        public string[] OwnFldShorts
        {
            get
            {
                return this._FldShorts;
            }
            set
            {
                this._FldShorts = value;
            }
        }

        public qs2.core.Enums.eControlType OwnControlType
        {
            get
            {
                return this._controlType;
            }
            set
            {
                this._controlType = value;
                if (this.DesignMode) this.doControl();
            }
        }

        public int OwnLevelLeftWidth
        {
            get
            {
                return this._OwnLevelLeftWidth;
            }
            set
            {
                this._OwnLevelLeftWidth = value;
                if (this.DesignMode) this.doControl();
            }
        }

        public int OwnLevelRightWidth
        {
            get
            {
                return this._OwnLevelRightWidth;
            }
            set
            {
                this._OwnLevelRightWidth = value;
                if (this.DesignMode)
                {
                    this.doControl();
                }
            }
        }

        public bool OwnLevelLeftVisible
        {
            get
            {
                return this._OwnLevelLeftVisible;
            }
            set
            {
                this._OwnLevelLeftVisible = value;
                if (this.DesignMode) this.doControl();
            }
        }

        public bool OwnLevelTopVisible
        {
            get
            {
                return this._OwnLevelTopVisible;
            }
            set
            {
                this._OwnLevelTopVisible = value;
                if (this.DesignMode) this.doControl();
            }
        }

        public bool OwnLevelRightVisible
        {
            get
            {
                return this._OwnLevelRightVisible;
            }
            set
            {
                this._OwnLevelRightVisible = value;
                if (!this._OwnLevelRightVisible)
                {
                    this.OwnLevelRightWidth = 0;
                }
                if (this.DesignMode) this.doControl();
            }
        }

        public Infragistics.Win.HAlign OwnLevelLeftOrientationHoriz
        {
            get
            {
                return this._OwnLevelLeftOrientationHoriz;
            }
            set
            {
                this._OwnLevelLeftOrientationHoriz = value;
                if (this.DesignMode) this.doControl();
            }
        }

        public string OwnDefaultValue
        {
            get
            {
                // not used!
                return "";
            }
            set
            {
                // not used!
            }
        }

        public int OwnOrderLineNr
        {
            get
            {
                return this._OwnOrderLineNr;
            }
            set
            {
                this._OwnOrderLineNr = value;
            }
        }

        public int OwnOrderControlNr
        {
            get
            {
                return this._OwnOrderControlNr;
            }
            set
            {
                this._OwnOrderControlNr = value;
            }
        }

        public int OwnOrder
        {
            get
            {
                return this._OwnOrder;
            }
            set
            {
                this._OwnOrder = value;
            }
        }

        public bool OwnNotResetValue
        {
            get
            {
                return this._OwnNotResetValue;
            }
            set
            {
                this._OwnNotResetValue = value;
            }
        }

        public bool OwnDoNotPrint
        {
            get
            {
                return this._OwnDoNotPrint;
            }
            set
            {
                this._OwnDoNotPrint = value;
            }
        }

        public Infragistics.Win.HAlign OwnLevelRightOrientationHoriz
        {
            get
            {
                return this._OwnLevelRightOrientationHoriz;
            }
            set
            {
                this._OwnLevelRightOrientationHoriz = value;
                if (this.DesignMode) this.doControl();
            }
        }

        public Infragistics.Win.DefaultableBoolean OwnLevelLeftFontDataBold
        {
            get
            {
                return this._OwnLevelLeftFontDataBold;
            }
            set
            {
                this._OwnLevelLeftFontDataBold = value;
                if (this.DesignMode) this.doControl();
            }
        }

        public bool OwnFieldForALLProducts
        {
            get
            {
                return this._OwnFieldForALLProducts;
            }
            set
            {
                this._OwnFieldForALLProducts = value;
            }
        }

        public string OwnOnlyForProducts
        {
            get
            {
                return this._OwnOnlyForProducts;
            }
            set
            {
                this._OwnOnlyForProducts = value;
            }
        }

        public bool OwnInfoTop
        {
            get
            {
                return this._OwnInfoTop;
            }
            set
            {
                this._OwnInfoTop = value;
            }
        }

        public bool IsInDesignerModus
        {
            get
            {
                return this.DesignMode;
            }
        }

        public object ownValue
        {
            get
            {
                return "";
            }
            set
            {

            }
        }

        public void doRelationsship(bool isLoaded, bool userChanged, int SubRelation, ownMCRelationship.eTypAssignments typeRunning, string ChapterParent,
                                    bool ProcGroupDeactivated)
        {
            try
            {
                if (this.ownMCCriteria1.rCriteria != null)          // && isLoaded
                {
                    qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 = this;
                    qs2.core.generic.retValue retValue1 = this.ownMCDataBind1.getValueFromRow(ownMultiControl1);
                    this.ownMCCriteria1.MCRelationship.doRelationship(ownMultiControl1._FldShort, ChapterParent.Trim(), ref retValue1, userChanged, SubRelation,
                                                                        this.ownMCCriteria1.Application,
                                                                        this.ownMCCriteria1.IDParticipant.ToString(),
                                                                        ref this.parentAutoUI.dataStay, ref parentAutoUI,
                                                                        ref typeRunning, ProcGroupDeactivated);
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiControl.doRelationsship", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void doActionControl(eTypActionControl typAction, ref qs2.core.generic.infoControl calculatedFormat1, bool OnOff)
        {
            try
            {
                Control ctl = null;
                if (this._controlType == core.Enums.eControlType.Integer ||
                    this._controlType == core.Enums.eControlType.IntegerNoDb ||
                    this._controlType == core.Enums.eControlType.Numeric ||
                    this._controlType == core.Enums.eControlType.NumericNoDb)
                {
                    if (typAction == eTypActionControl.selectAll)
                    {
                        this.Numeric.SelectAll();
                    }
                    else if (typAction == eTypActionControl.clearErrorProvider)
                    {
                        this.Numeric.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                    }
                    else if (typAction == eTypActionControl.clearMC)
                    {
                        this.ownMCValue1.clearValue(this, false, true);
                    }
                    else if (typAction == eTypActionControl.showError)
                    {
                        this.Numeric.UseAppStyling = false;
                        this.Numeric.Appearance.BackColor = qs2.core.Colors.BackColorFieldError;
                        this.Numeric.Appearance.BackColorDisabled = qs2.core.Colors.BackColorFieldError;
                        this.Numeric.Appearance.ForeColorDisabled = qs2.core.Colors.ForeColorFieldError;
                    }
                    else if (typAction == eTypActionControl.setEditableAndFocus)
                    {
                        this.setEditable(true, true);
                        this.Numeric.Focus();
                        this.Numeric.SelectAll();
                    }
                    else if (typAction == eTypActionControl.GetControlInfo)
                    {
                        calculatedFormat1 = (qs2.core.generic.infoControl)this.Numeric.Tag;
                    }
                    else if (typAction == eTypActionControl.ClearFocus)
                    {
                        this.ownMCTxt1.doFocus(this, false);
                    }
                    else if (typAction == eTypActionControl.SetFocus)
                    {

                    }
                    else if (typAction == eTypActionControl.place)
                    {
                        ctl = this.Numeric;
                    }
                    else if (typAction == eTypActionControl.NoticeValueBeforeChangedFromUser)
                    {
                        this.ValueBeforeChangedFromUser = this.Numeric.Value;
                    }
                }
                else if (this._controlType == core.Enums.eControlType.ComboBox ||
                        this._controlType == core.Enums.eControlType.ComboBoxNoDb)
                {
                    if (typAction == eTypActionControl.clearErrorProvider)
                    {
                        this.ComboBox.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                    }
                    else if (typAction == eTypActionControl.clearMC)
                    {
                        this.ownMCValue1.clearValue(this, false, true, true);
                    }
                    else if (typAction == eTypActionControl.showError)
                    {
                        this.ComboBox.UseAppStyling = false;
                        this.ComboBox.Appearance.BackColor = qs2.core.Colors.BackColorFieldError;
                        this.ComboBox.Appearance.BackColorDisabled = qs2.core.Colors.BackColorFieldError;
                        this.ComboBox.Appearance.ForeColorDisabled = qs2.core.Colors.ForeColorFieldError;
                    }
                    else if (typAction == eTypActionControl.setEditableAndFocus)
                    {
                        this.setEditable(true, true);
                        this.ComboBox.Focus();
                    }
                    else if (typAction == eTypActionControl.GetControlInfo)
                    {
                        calculatedFormat1 = (qs2.core.generic.infoControl)this.ComboBox.Tag;
                    }
                    else if (typAction == eTypActionControl.ClearFocus)
                    {
                        this.ownMCTxt1.doFocus(this, false);
                    }
                    else if (typAction == eTypActionControl.SetFocus)
                    {

                    }
                    else if (typAction == eTypActionControl.place)
                    {
                        ctl = this.ComboBox;
                    }
                    else if (typAction == eTypActionControl.NoticeValueBeforeChangedFromUser)
                    {
                        this.ValueBeforeChangedFromUser = this.ComboBox.Value;
                    }
                }
                else if (this._controlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox)
                {
                    if (typAction == eTypActionControl.clearErrorProvider)
                    {
                        this.ComboBox.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                    }
                    else if (typAction == eTypActionControl.clearMC)
                    {
                        this.ownMCValue1.clearValue(this, false, true);
                    }
                    else if (typAction == eTypActionControl.showError)
                    {
                        this.ComboBox.UseAppStyling = false;
                        this.ComboBox.Appearance.BackColor = qs2.core.Colors.BackColorFieldError;
                        this.ComboBox.Appearance.BackColorDisabled = qs2.core.Colors.BackColorFieldError;
                        this.ComboBox.Appearance.ForeColorDisabled = qs2.core.Colors.ForeColorFieldError;
                    }
                    else if (typAction == eTypActionControl.setEditableAndFocus)
                    {
                        this.setEditable(true, true);
                        this.ComboBox.Focus();
                    }
                    else if (typAction == eTypActionControl.GetControlInfo)
                    {
                        calculatedFormat1 = (qs2.core.generic.infoControl)this.ComboBox.Tag;
                    }
                    else if (typAction == eTypActionControl.ClearFocus)
                    {
                        this.ownMCTxt1.doFocus(this, false);
                    }
                    else if (typAction == eTypActionControl.SetFocus)
                    {

                    }
                    else if (typAction == eTypActionControl.place)
                    {
                        ctl = this.ComboBox;
                    }
                    else if (typAction == eTypActionControl.NoticeValueBeforeChangedFromUser)
                    {
                        this.ValueBeforeChangedFromUser = this.ComboBox.Value;
                    }
                }
                else if (this._controlType == core.Enums.eControlType.ComboBoxAsDropDown)
                {
                    if (typAction == eTypActionControl.clearErrorProvider)
                    {
                        this.DropDown.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                    }
                    else if (typAction == eTypActionControl.clearMC)
                    {
                        this.ownMCValue1.clearValue(this, false, true);
                    }
                    else if (typAction == eTypActionControl.showError)
                    {
                        this.DropDown.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                        this.DropDown.Appearance.BackColor = qs2.core.Colors.BackColorFieldError;
                        this.DropDown.Appearance.BackColorDisabled = qs2.core.Colors.BackColorFieldError;
                        this.DropDown.Appearance.ForeColorDisabled = qs2.core.Colors.ForeColorFieldError;
                    }
                    else if (typAction == eTypActionControl.setEditableAndFocus)
                    {
                        //this.setEditable(true, true);
                        this.DropDown.Focus();
                    }
                    else if (typAction == eTypActionControl.GetControlInfo)
                    {
                        //calculatedFormat1 = (qs2.core.generic.infoControl)this.DropDown.Tag;
                    }
                    else if (typAction == eTypActionControl.ClearFocus)
                    {
                    }
                    else if (typAction == eTypActionControl.SetFocus)
                    {

                    }
                    else if (typAction == eTypActionControl.place)
                    {
                        ctl = this.DropDown;
                    }
                    else if (typAction == eTypActionControl.NoticeValueBeforeChangedFromUser)
                    {
                        this.ValueBeforeChangedFromUser = this.ControlForDropDown.getValue();
                    }
                }
                else if (this._controlType == core.Enums.eControlType.DateTime ||
                        this._controlType == core.Enums.eControlType.DateTimeNoDb)
                {
                    if (typAction == eTypActionControl.selectAll)
                    {
                        this.DateTime.SelectAll();
                    }
                    else if (typAction == eTypActionControl.clearMC)
                    {
                        this.ownMCValue1.clearValue(this, false, true);
                    }
                    else if (typAction == eTypActionControl.clearErrorProvider)
                    {
                        this.DateTime.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                    }
                    else if (typAction == eTypActionControl.showError)
                    {
                        this.DateTime.UseAppStyling = false;
                        this.DateTime.Appearance.BackColor = qs2.core.Colors.BackColorFieldError;
                        this.DateTime.Appearance.BackColorDisabled = qs2.core.Colors.BackColorFieldError;
                        this.DateTime.Appearance.ForeColorDisabled = qs2.core.Colors.ForeColorFieldError;
                    }
                    else if (typAction == eTypActionControl.setEditableAndFocus)
                    {
                        this.setEditable(true, true);
                        this.DateTime.Focus();
                        this.DateTime.SelectAll();
                    }
                    else if (typAction == eTypActionControl.GetControlInfo)
                    {
                        calculatedFormat1 = (qs2.core.generic.infoControl)this.DateTime.Tag;
                    }
                    else if (typAction == eTypActionControl.ClearFocus)
                    {
                        this.ownMCTxt1.doFocus(this, false);
                    }
                    else if (typAction == eTypActionControl.SetFocus)
                    {

                    }
                    else if (typAction == eTypActionControl.place)
                    {
                        ctl = this.DateTime;
                    }
                    else if (typAction == eTypActionControl.NoticeValueBeforeChangedFromUser)
                    {
                        this.ValueBeforeChangedFromUser = this.DateTime.Value;
                    }
                }
                else if (this._controlType == core.Enums.eControlType.Date ||
                        this._controlType == core.Enums.eControlType.DateNoDb)
                {
                    if (typAction == eTypActionControl.selectAll)
                    {
                        this.Date.SelectAll();
                    }
                    else if (typAction == eTypActionControl.clearMC)
                    {
                        this.ownMCValue1.clearValue(this, false, true);
                    }
                    else if (typAction == eTypActionControl.clearErrorProvider)
                    {
                        this.Date.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                    }
                    else if (typAction == eTypActionControl.showError)
                    {
                        this.Date.UseAppStyling = false;
                        this.Date.Appearance.BackColor = qs2.core.Colors.BackColorFieldError;
                        this.Date.Appearance.BackColorDisabled = qs2.core.Colors.BackColorFieldError;
                        this.Date.Appearance.ForeColorDisabled = qs2.core.Colors.ForeColorFieldError;
                    }
                    else if (typAction == eTypActionControl.setEditableAndFocus)
                    {
                        this.setEditable(true, true);
                        this.Date.Focus();
                        this.Date.SelectAll();
                    }
                    else if (typAction == eTypActionControl.GetControlInfo)
                    {
                        calculatedFormat1 = (qs2.core.generic.infoControl)this.Date.Tag;
                    }
                    else if (typAction == eTypActionControl.ClearFocus)
                    {
                        this.ownMCTxt1.doFocus(this, false);
                    }
                    else if (typAction == eTypActionControl.SetFocus)
                    {

                    }
                    else if (typAction == eTypActionControl.place)
                    {
                        ctl = this.Date;
                    }
                    else if (typAction == eTypActionControl.NoticeValueBeforeChangedFromUser)
                    {
                        this.ValueBeforeChangedFromUser = this.Date.Value;
                    }
                }
                else if (this._controlType == core.Enums.eControlType.Time ||
                        this._controlType == core.Enums.eControlType.TimeNoDb)
                {
                    if (typAction == eTypActionControl.selectAll)
                    {
                        this.Time.SelectAll();
                    }
                    else if (typAction == eTypActionControl.clearMC)
                    {
                        this.ownMCValue1.clearValue(this, false, true);
                    }
                    else if (typAction == eTypActionControl.clearErrorProvider)
                    {
                        this.Time.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                    }
                    else if (typAction == eTypActionControl.showError)
                    {
                        this.Time.UseAppStyling = false;
                        this.Time.Appearance.BackColor = qs2.core.Colors.BackColorFieldError;
                        this.Time.Appearance.BackColorDisabled = qs2.core.Colors.BackColorFieldError;
                        this.Time.Appearance.ForeColorDisabled = qs2.core.Colors.ForeColorFieldError;
                    }
                    else if (typAction == eTypActionControl.setEditableAndFocus)
                    {
                        this.setEditable(true, true);
                        this.Time.Focus();
                        this.Time.SelectAll();
                    }
                    else if (typAction == eTypActionControl.GetControlInfo)
                    {
                        calculatedFormat1 = (qs2.core.generic.infoControl)this.Time.Tag;
                    }
                    else if (typAction == eTypActionControl.ClearFocus)
                    {
                        this.ownMCTxt1.doFocus(this, false);
                    }
                    else if (typAction == eTypActionControl.SetFocus)
                    {

                    }
                    else if (typAction == eTypActionControl.place)
                    {
                        ctl = this.Time;
                    }
                    else if (typAction == eTypActionControl.NoticeValueBeforeChangedFromUser)
                    {
                        this.ValueBeforeChangedFromUser = this.Time.Value;
                    }
                }
                else if (this._controlType == core.Enums.eControlType.Textfield ||
                        this._controlType == core.Enums.eControlType.TextfieldNoDb)
                {
                    if (typAction == eTypActionControl.selectAll)
                    {
                        this.Textfield.SelectAll();
                    }
                    else if (typAction == eTypActionControl.clearMC)
                    {
                        this.ownMCValue1.clearValue(this, false, true);
                    }
                    else if (typAction == eTypActionControl.clearErrorProvider)
                    {
                        this.Textfield.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                    }
                    else if (typAction == eTypActionControl.showError)
                    {
                        this.Textfield.UseAppStyling = false;
                        this.Textfield.Appearance.BackColor = qs2.core.Colors.BackColorFieldError;
                        this.Textfield.Appearance.ForeColor = qs2.core.Colors.ForeColorFieldError;
                        this.Textfield.Appearance.BackColorDisabled = qs2.core.Colors.BackColorFieldError;
                        this.Textfield.Appearance.ForeColorDisabled = qs2.core.Colors.ForeColorFieldError;
                    }
                    else if (typAction == eTypActionControl.clearError)
                    {
                        this.Textfield.UseAppStyling = false;
                        this.Textfield.Appearance.BackColor = qs2.core.Colors.BackColorFieldNoError;
                        this.Textfield.Appearance.ForeColor = qs2.core.Colors.ForeColorFieldNoError;
                        this.Textfield.Appearance.BackColorDisabled = qs2.core.Colors.BackColorFieldNoError;
                        this.Textfield.Appearance.ForeColorDisabled = qs2.core.Colors.ForeColorFieldNoError;
                    }
                    else if (typAction == eTypActionControl.setEditableAndFocus)
                    {
                        this.setEditable(true, true);
                        this.Textfield.Focus();
                        this.Textfield.SelectAll();
                    }
                    else if (typAction == eTypActionControl.GetControlInfo)
                    {
                        calculatedFormat1 = (qs2.core.generic.infoControl)this.Textfield.Tag;
                    }
                    else if (typAction == eTypActionControl.ClearFocus)
                    {
                        this.ownMCTxt1.doFocus(this, false);
                    }
                    else if (typAction == eTypActionControl.SetFocus)
                    {

                    }
                    else if (typAction == eTypActionControl.place)
                    {
                        ctl = this.Textfield;
                    }
                    else if (typAction == eTypActionControl.NoticeValueBeforeChangedFromUser)
                    {
                        this.ValueBeforeChangedFromUser = this.Textfield.Value;
                    }
                }
                else if (this._controlType == core.Enums.eControlType.TextfieldMulti ||
                        this._controlType == core.Enums.eControlType.TextfieldMultiNoDb)
                {
                    if (typAction == eTypActionControl.clearErrorProvider)
                    {
                        this.TextfieldMulti.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                    }
                    else if (typAction == eTypActionControl.clearMC)
                    {
                        this.ownMCValue1.clearValue(this, false, true);
                    }
                    else if (typAction == eTypActionControl.showError)
                    {
                        this.TextfieldMulti.UseAppStyling = false;
                        this.TextfieldMulti.Appearance.BackColor = qs2.core.Colors.BackColorFieldError;
                        this.TextfieldMulti.Appearance.BackColorDisabled = qs2.core.Colors.BackColorFieldError;
                        this.TextfieldMulti.Appearance.ForeColorDisabled = qs2.core.Colors.ForeColorFieldError;
                    }
                    else if (typAction == eTypActionControl.clearError)
                    {
                        this.TextfieldMulti.UseAppStyling = false;
                        this.TextfieldMulti.Appearance.BackColor = qs2.core.Colors.BackColorFieldNoError;
                        this.TextfieldMulti.Appearance.BackColorDisabled = qs2.core.Colors.BackColorFieldNoError;
                        this.TextfieldMulti.Appearance.ForeColorDisabled = qs2.core.Colors.BackColorFieldNoError;
                    }
                    else if (typAction == eTypActionControl.setEditableAndFocus)
                    {
                        this.setEditable(true, true);
                        this.TextfieldMulti.Focus();
                    }
                    else if (typAction == eTypActionControl.GetControlInfo)
                    {
                        calculatedFormat1 = (qs2.core.generic.infoControl)this.TextfieldMulti.Tag;
                    }
                    else if (typAction == eTypActionControl.ClearFocus)
                    {
                        this.ownMCTxt1.doFocus(this, false);
                    }
                    else if (typAction == eTypActionControl.SetFocus)
                    {

                    }
                    else if (typAction == eTypActionControl.place)
                    {
                        ctl = this.TextfieldMulti;
                    }
                    else if (typAction == eTypActionControl.NoticeValueBeforeChangedFromUser)
                    {
                        this.ValueBeforeChangedFromUser = this.TextfieldMulti.Value;
                    }
                }
                else if (this._controlType == core.Enums.eControlType.CheckBox ||
                        this._controlType == core.Enums.eControlType.CheckBoxNoDb)
                {
                    if (typAction == eTypActionControl.GetControlInfo)
                    {
                        calculatedFormat1 = (qs2.core.generic.infoControl)this.CheckBox.Tag;
                    }
                    else if (typAction == eTypActionControl.clearMC)
                    {
                        this.ownMCValue1.clearValue(this, false, true);
                    }
                    else if (typAction == eTypActionControl.ClearFocus)
                    {
                        this.ownMCTxt1.doFocus(this, false);
                    }
                    else if (typAction == eTypActionControl.SetFocus)
                    {

                    }
                    else if (typAction == eTypActionControl.place)
                    {
                        ctl = this.CheckBox;
                    }
                    else if (typAction == eTypActionControl.NoticeValueBeforeChangedFromUser)
                    {
                        this.ValueBeforeChangedFromUser = this.CheckBox.Checked;
                    }
                }
                else if (this._controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                        this._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                {
                    if (typAction == eTypActionControl.GetControlInfo)
                    {
                        calculatedFormat1 = (qs2.core.generic.infoControl)this.ThreeStateCheckBox.Tag;
                    }
                    else if (typAction == eTypActionControl.clearMC)
                    {
                        this.ownMCValue1.clearValue(this, false, true);
                    }
                    else if (typAction == eTypActionControl.ClearFocus)
                    {
                        this.ownMCTxt1.doFocus(this, false);
                    }
                    else if (typAction == eTypActionControl.SetFocus)
                    {

                    }
                    else if (typAction == eTypActionControl.place)
                    {
                        ctl = this.ThreeStateCheckBox;
                    }
                    else if (typAction == eTypActionControl.NoticeValueBeforeChangedFromUser)
                    {
                        this.ValueBeforeChangedFromUser = this.ThreeStateCheckBox.OwnCheckStateInt;
                    }
                }
                else if (this._controlType == core.Enums.eControlType.Label)
                {
                }
                else if (this._controlType == core.Enums.eControlType.Picture)
                {
                    if (typAction == eTypActionControl.place)
                    {
                        ctl = this.Picture;
                    }
                }

                if (typAction == eTypActionControl.place)
                {
                    if (ctl != null)
                    {
                        ctl.Top = 0;
                        ctl.Left = 0;
                        ctl.Dock = DockStyle.None;
                        ctl.Width = this.msPanelControls3.Width;
                        ctl.Height = this.msPanelControls3.Height;
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiControl.doActionControl", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public bool checkValueComboBox(bool WithMsgBox)
        {
            try
            {
                if (this._controlType == core.Enums.eControlType.ComboBox ||
                        this._controlType == core.Enums.eControlType.ComboBoxNoDb ||
                         this._controlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox)
                {
                    if (this.ComboBox.SelectedItem == null && this.ComboBox.Value == null)
                    {
                        if (!this.IsEvaluation)
                        {
                            if (this.ownMCCriteria1.ownMCCombo1.TypeComboBox == core.Enums.cVariablesValues.Roles)
                            {
                                return true;
                            }
                            else
                            {
                                if (WithMsgBox)
                                {
                                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("IncorrectValueEntered") + "!", MessageBoxButtons.OK, "");
                                }
                                this.ComboBox.Value = this.ValueBeforeChangedFromUser;
                                return false;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else if (this.ComboBox.SelectedItem == null && this.ComboBox.Value != null)
                    {
                        if (WithMsgBox)
                        {
                            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("IncorrectValueEntered") + "!", MessageBoxButtons.OK, "");
                        }
                        this.ComboBox.Value = this.ValueBeforeChangedFromUser;
                        return false;
                    }
                    else if (this.ComboBox.SelectedItem != null && this.ComboBox.Value != null)
                    {
                        return true;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiControl.checkValueComboBox", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return false;
            }
        }

        public void setEditable(bool editable, bool checkCriteria)
        {
            try
            {
                if (!this.IsEvaluation)
                {
                    this.getChapter();
                    if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(this.OwnFldShort, "StayComplete", false))
                    {
                        if (!qs2.core.vb.actUsr.checkRights(core.Enums.eRights.rightSetCompleted, false))
                        {
                            editable = false;
                        }
                        else
                        {
                            if (editable && this.parentAutoUI.rStayRead.StayComplete)
                            {
                                editable = true;
                            }
                        }
                    }
                    else
                    {
                        if (this.parentAutoUI != null && this.parentAutoUI.rStayRead.StayComplete)
                        {
                            if (editable)
                            {
                                editable = qs2.core.vb.actUsr.UserHasRigthSetCompleted;
                                if (this.chapter != null)
                                {
                                    if (this.chapter.cListAssistentElem.AlwaysEditable)
                                    {
                                        editable = true;
                                    }
                                }
                            }
                        }
                    }
                }
                this._isEnabled = editable;

                if (this._control != null)
                {
                    if (this._controlType != core.Enums.eControlType.CheckBox &&
                        this._controlType != core.Enums.eControlType.ThreeStateCheckBox &&
                        this._controlType != core.Enums.eControlType.Picture &&
                        this._controlType != core.Enums.eControlType.CheckBoxNoDb &&
                        this._controlType != core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                    {
                        this._control.Enabled = editable;

                        if (this._controlType == core.Enums.eControlType.Textfield || this._controlType == core.Enums.eControlType.TextfieldMulti)
                        {
                           //this.Controls[]
                        }

                        if (checkCriteria)
                        {
                            if (editable && this.ownMCCriteria1.rCriteria != null)
                            {
                                this._control.Enabled = this.ownMCCriteria1.rCriteria.Editable;
                                if (!this.ownMCCriteria1.rCriteria.Editable && this._control != null)
                                {
                                    this.TabStop = false;
                                }
                            }
                        }
                    }

                    if (!this.IsEvaluation && this.IsComboBoxWithTxtBox &&
                            (this._controlType == core.Enums.eControlType.ComboBox ||
                            this._controlType == core.Enums.eControlType.ComboBoxNoDb))
                    {
                        if (editable)
                        {
                            this.ComboBox.Visible = true;
                            this.Textfield.Visible = false;
                        }
                        else
                        {
                            this.ComboBox.Visible = false;
                            this.Textfield.Visible = true;
                        }
                    }

                    Control button = this.ownMCUI1.buttonInPanelxy;
                    if (button != null)
                    {
                        if (button.Name.ToString() == ownMCEvents.eTypButtonControl.addSelList.ToString())
                        {
                            if (!this.IsEvaluation)
                            {
                                this.panelButtonsOnOff.Visible = true;
                                button.Enabled = editable;
                            }
                            else
                            {
                                button.Visible = editable;
                            }
                        }
                    }

                    if (this.panelButtons.Controls.Count > 0)
                    {
                        if (editable)
                        {
                            if (this.IsEvaluation)
                            {
                                this.panelButtonsOnOff.Visible = true;
                            }
                        }
                        else
                        {
                            if (this.IsEvaluation)
                            {
                                this.panelButtonsOnOff.Visible = false;
                            }
                        }
                    }

                }

                if (this._controlType == core.Enums.eControlType.Picture)
                {
                    this.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiControl.setEditable", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void setToolStripMenü(ref System.Windows.Forms.ContextMenuStrip ContextMenuStrip1)
        {
            try
            {
                ContextMenuStrip1 = new ContextMenuStrip(this.components);
            }
            catch (Exception ex)
            {
                throw new Exception("getCompontens: " + ex.ToString());
            }
        }

        public void loadedDatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ownMCInfo1.showInfoCriterias(this, this.ownMCCriteria1.rCriteria.FldShort, this.ownMCCriteria1.Application, this.ownMCCriteria1.IDParticipant, this.OwnFieldForALLProducts);
            }
            catch (Exception ex)
            {
                this.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public void selListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ownMCInfo ownControlInfo2 = new ownMCInfo();

                bool addSelList = true;
                if (this.DesignMode)
                {
                    addSelList = false;
                }

                string IDGroupStrToCall = (this.ownMCCriteria1.rCriteria.AliasFldShort.Trim() == "" ? this.ownMCCriteria1.rCriteria.FldShort : this.ownMCCriteria1.rCriteria.AliasFldShort);
                ownControlInfo2.showInfoSelList(this, IDGroupStrToCall, this.ownMCCriteria1.Application, this.ownMCCriteria1.IDParticipant, addSelList, this, this.OwnFieldForALLProducts, true, false);
            }
            catch (Exception ex)
            {
                this.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public void infoFieldSQLServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ownMCInfo1.infoFieldDB(this, this._FldShort, this.ownMCCriteria1.Application, this.ownMCCriteria1.IDParticipant, this.OwnFieldForALLProducts);
            }
            catch (Exception ex)
            {
                this.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public void ressourcenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ownMCInfo1.showInfoRessourcen(this, this.ownMCCriteria1.rCriteria.FldShort, this.ownMCCriteria1.Application, this.ownMCCriteria1.IDParticipant, this.OwnFieldForALLProducts);
            }
            catch (Exception ex)
            {
                this.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public void fielShortsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ownMCInfo1.showInfoFldShorts(this, this._FldShorts, qs2.core.language.sqlLanguage.getRes("ListFielShorts"), this.ownMCCriteria1.Application, this.OwnFieldForALLProducts);
            }
            catch (Exception ex)
            {
                this.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void getExep(string ex, string title)
        {
            qs2.core.generic.getExep(ex.ToString(), title, "Field '" + this._FldShort + "'");
        }

        private void ownMultiControl_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode || this.visibleIsInProgress)
                {
                    return;
                }
                this.visibleIsInProgress = true;
                this.doVisible();
            }
            catch (Exception ex)
            {
                this.visibleIsInProgress = false;
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiControl.ownMultiControl_VisibleChanged", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                qs2.design.auto.multiControl.ownMCInfo.checkForProtocol(false);
            }
        }

        public bool doVisible()
        {
            try
            {
                if (!DesignMode && this.parentAutoUI != null)
                {
                    if (this.parentAutoUI.parentFormAutoUI.Visible && !this.isLoaded)
                    {
                        this.ownMCCriteria1._ControlIsFormatted = true;
                        if (!this.PropertyVisibleIsActive)
                        {
                            this.setVisible();
                        }

                        this.TabIndex = this.OwnOrderLineNr * 10 + this.OwnOrderControlNr;
                        this.isLoaded = true;
                    }
                }
                else if (!DesignMode && this.parentAutoUI == null)
                {
                    if (this.Visible)
                    {
                        this.setControl(false);
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.doVisible: " + "Field '" + this._FldShort + "'" + "\r\n" + ex.ToString());
            }
        }

        public bool checkIsVisible()
        {
            try
            {
                return this.getVisiblebyOrder();
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiControl.checkIsVisible", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return false;
            }
        }

        public void setVisible()
        {
            try
            {
                this.PropertyVisibleIsActive = false;
                this.Visible = this.getVisiblebyOrder();
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiControl.setVisible", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                this.PropertyVisibleIsActive = false;
            }
        }
        public bool getVisiblebyOrder()
        {
            bool bTmpVisibleSum = false;
            try
            {
                this.PropertyVisibleIsActive = true;

                if (!this.ownMCUI1.IsVisible_Criteriaxy)
                {
                    bTmpVisibleSum = false;
                }
                else
                {
                    bTmpVisibleSum = (this.ownMCUI1.IsVisible_Criteriaxy && this.ownMCUI1.IsVisible_LicenseKey && this.ownMCUI1.IsVisible_Roles && this.ownMCUI1.IsVisible_RelationsshipMCParent && this.ownMCUI1.IsVisible_RelationsshipGroups);
                }
                this.PropertyVisibleIsActive = false;

                return bTmpVisibleSum;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiControl.setVisible", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                this.PropertyVisibleIsActive = false;
                return bTmpVisibleSum;
            }
        }

        public void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ownMCEvents1.Info(this, e);
            }
            catch (Exception ex)
            {
                this.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void infoClassificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ownMCInfo1.infoClassification(this, this.ownMCCriteria1.Application);
            }
            catch (Exception ex)
            {
                this.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void unloadControl()
        {
            try
            {
                try
                {
                    if (this.Numeric != null)
                    {
                        this.Numeric.Dispose();
                        this.Numeric = null;
                    }

                    if (this.ComboBox != null)
                    {
                        this.ComboBox.DataSource = null;
                        this.ComboBox.DataMember = null;
                        this.ComboBox.DataBind();
                        Application.DoEvents();
                        this.ownMCCriteria1.ownMCCombo1 = null;

                        this.ComboBox.Dispose();
                        this.ComboBox = null;
                    }

                    if (this.DateTime != null)
                    {
                        this.DateTime.Dispose();
                        this.DateTime = null;
                    }

                    if (this.Date != null)
                    {
                        this.Date.Dispose();
                        this.Date = null;
                    }

                    if (this.Time != null)
                    {
                        this.Time.Dispose();
                        this.Time = null;
                    }

                    if (this.Textfield != null)
                    {
                        this.Textfield.Dispose();
                        this.Textfield = null;
                    }

                    if (this.TextfieldMulti != null)
                    {
                        this.TextfieldMulti.Dispose();
                        this.TextfieldMulti = null;
                    }

                    if (this.CheckBox != null)
                    {
                        this.CheckBox.Dispose();
                        this.CheckBox = null;
                    }

                    if (this.ThreeStateCheckBox != null)
                    {
                        this.ThreeStateCheckBox.Dispose();
                        this.ThreeStateCheckBox = null;
                    }

                    if (this.infragLabelLeft != null)
                    {
                        this.infragLabelLeft.Dispose();
                        this.infragLabelLeft = null;
                    }

                    if (this.Picture != null)
                    {
                        this.Picture.Image = null;
                        this.Picture.Dispose();
                        this.Picture = null;
                    }

                }
                catch (Exception ex2)
                {
                    string xy = ex2.ToString();
                    //throw new Exception(ex2.ToString());
                }

                if (this._control != null)
                {
                    if (this._control.DataBindings != null)
                    {
                        this._control.DataBindings.Clear();
                    }
                }

                if (this.ownMCDataBind1 != null)
                {
                    this.ownMCDataBind1.Binding1 = null;
                    this.ownMCDataBind1.RowGenericTables = null;
                }

                this.rSelListQry = null;
                this.rAutoUI = null;
                this.parentAutoUI = null;

                if (this.ownMCCriteria1 != null)
                {
                    this.ownMCCriteria1.rCriteria = null;
                    this.ownMCCriteria1.rColSys = null;
                }

                this.ownMCCriteria1 = null;
                this.ownMCDataBind1 = null;
                this.ownMCEvents1 = null;
                this.ownMCFormat1 = null;
                this.ownMCValue1 = null;
                this.ownMCInfo1 = null;
                this.ownMCTxt1 = null;
                this.ownMCUI1 = null;

                if (this._control != null)
                {
                    this._control.Dispose();
                    this._control = null;
                }

                if (this.infragLabelLeft != null)
                {
                    this.infragLabelLeft.Dispose();
                    this.infragLabelLeft = null;
                }
                if (this.infragLabelRight != null)
                {
                    this.infragLabelRight.Dispose();
                    this.infragLabelRight = null;
                }

            }
            catch (Exception ex)
            {
                string xy = ex.ToString();
            }
        }

        public void getChapter()
        {
            try
            {
                if (!this.chapterDone)
                {
                    if (this.rAutoUI != null)
                    {
                        if (this.rAutoUI.Chapter.Trim() != "")
                        {
                            this.chapter = this.parentAutoUI.contListChapters.getChapterForMC(this.rAutoUI.Chapter.Trim());
                            if (this.chapter != null)
                            {
                                //if (this.rAutoUI.Chapter.Trim().ToLower().Equals(("A").Trim().ToLower()))
                                //{
                                //    bool bStop = true;
                                //}
                                //if (this.chapter.cListAssistentElem.AlwaysEditable)
                                //{
                                //    bool bStop = true;
                                //}
                                ownMultiControl.counterMCHasChapters += 1;
                                //bool ChapterFound = true;
                            }
                            else
                            {
                                ownMultiControl.counterMCHasNoChapters += 1;
                                //bool NoChapter = true;
                            }
                        }
                        else
                        {
                            ownMultiControl.counterMCHasNoChapters += 1;
                            //bool NoChapter = true;
                        }
                    }
                    else
                    {
                        ownMultiControl.counterMCHasNoChapters += 1;
                        //bool NoChapter = true;
                    }

                    this.chapterDone = true;
                }
                else
                {
                    //bool bChapterDone = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ownMultiControl.getChapter: " + ex.ToString());
            }
        }

        private void ownMultiControl_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode)
                {
                    this.doControl();
                    if (this.OwnControlType == core.Enums.eControlType.TextfieldMulti)
                    {
                        this.TextfieldMulti.Height = this.Height;
                        System.Windows.Forms.Application.DoEvents();
                    }
                }

            }
            catch (Exception ex)
            {
                this.visibleIsInProgress = false;
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiControl.ownMultiControl_SizeChanged", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                qs2.design.auto.multiControl.ownMCInfo.checkForProtocol(false);
                //throw new Exception("ownMultiControl_VisibleChanged: " + "Field '" + this._FldShort + "'" + "\r\n" + ex.ToString());
            }
            finally
            {
                this.visibleIsInProgress = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void msPanelControls3_MouseEnterElement(object sender, UIElementEventArgs e)
        {
            try
            {
                if (!IsEvaluation && this.parentAutoUI != null && this.parentAutoUI.IsInitialized)
                {
                    if (!this.IsEvaluation)
                        this.ownMCEvents1.CheckMouseHoverLeaveContr(sender, e, true, this.OwnFldShort, this.ownMCCriteria1.Application, false);
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiControl.msPanelControls3_MouseEnterElement", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                qs2.design.auto.multiControl.ownMCInfo.checkForProtocol(false);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void msPanelControls3_MouseLeaveElement(object sender, UIElementEventArgs e)
        {
            try
            {
                if (!IsEvaluation && this.parentAutoUI != null && this.parentAutoUI.IsInitialized)
                {
                    if (!this.IsEvaluation)
                        this.ownMCEvents1.CheckMouseHoverLeaveContr(sender, e, false, this.OwnFldShort, this.ownMCCriteria1.Application, false);
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMultiControl.msPanelControls3_MouseLeaveElement", "", false, true,
                                                                this.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                qs2.design.auto.multiControl.ownMCInfo.checkForProtocol(false);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

    }

}
