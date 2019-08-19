//----------------------------------------------------------------------------------------------
//	frmMain.cs
//  Default Buttons
//  Erstellt am:	13.9.2004
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using Infragistics.Win.Misc;
using Infragistics.Win;



namespace PMDS.GUI
{
 


    public class ucButton : QS2.Desktop.ControlManagment.BaseButton 
	{

		private ucButton.ButtonType		_type;
        private PMDS.Global.UIGlobal.ButtonPlacement _typePlacement;
        public bool isBigButton = true;
		private System.ComponentModel.IContainer components;

        private PMDS.Global.UIGlobal cUI = new PMDS.Global.UIGlobal();
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public Infragistics.Win.UltraWinToolTip.UltraToolTipManager toolTip1;

        public QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();

        public bool _DoOnClick = true;








		public ucButton(System.ComponentModel.IContainer container)
		{
			InitializeComponent();
			Init1();
		}

		public ucButton()
		{
			InitializeComponent();
			Init1();
		}

		private void Init1() 
		{
			TYPE = ucButton.ButtonType.Save;
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public enum ButtonType
		{
			Save,
			Undo,
			Add,
			Sub,
			OK,
			Cancel,
			Print,
			Search, 
			Ignore,
            saveBenutzerverwaltung,
            edit,
            beenden,
            none
		}

        public PMDS.Global.UIGlobal.ButtonPlacement TYPEPlacement
        {
            get
            {
                return _typePlacement;
            }
            set
            {
                this._typePlacement = value;
                cUI.setButtonStyleStandard(this, this._typePlacement);
            }
        }
        public bool DoOnClick
        {
            get
            {
                return this._DoOnClick;
            }
            set
            {
                this._DoOnClick = value;
            }
        }

		public ucButton.ButtonType TYPE
		{
			get 
			{
				return _type;
			}
			set
			{
				_type = value;
                //Appearance.Image = (int)value;
                
                //if (this.Text.Trim() == "")
                //{
                //    Appearance.ImageHAlign = HAlign.Center;
                //    this.TabStop = false;
                //    isBigButton = false;
                //}
                //else
                //{
                if (_type != ButtonType.none)
                {
                    Appearance.ImageVAlign = VAlign.Middle;

                    this.Text = "";
                    this.SetToolTip("");
                    if (this.Width > 85)
                    {
                        Appearance.ImageHAlign = HAlign.Right;
                        isBigButton = true;
                    }
                    else
                    {
                        Appearance.ImageHAlign = HAlign.Center;
                        this.TabStop = false;
                        isBigButton = false;
                        this.Text = "";
                    }
                }

                //}

                //Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.None , "", Infragistics.Win.DefaultableBoolean.Default);
                //this.ultraToolTipManager1.AutoPopDelay = 0;
                this.Cursor = System.Windows.Forms.Cursors.Default;

                if (_type == ButtonType.Add || _type == ButtonType.Sub)
                {
                    //System.Drawing.Size sizKleinIco = new System.Drawing.Size(12, 12);
                    //this.ImageSize = sizKleinIco;
                }

                if (!isBigButton)
                {
                    if (_type == ButtonType.Add || _type == ButtonType.Sub)
                    {
                        cUI.setButtonStyleStandard(this, this._typePlacement );
                    }
                }
                if (_typePlacement == PMDS.Global.UIGlobal.ButtonPlacement.grid)
                {
                    cUI.setButtonStyleStandard(this, this._typePlacement);
                    System.Drawing.Size sizKleinIco = new System.Drawing.Size(12, 12);
                    this.ImageSize = sizKleinIco;
                    this.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);
                }

                if (_type == ButtonType.Add )
                {
                    if (!isBigButton)
                    {
                        this.SetToolTip(QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinzufügen")); 
                    }
                    else
                    {
                        this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinzufügen");
                    }
                    this.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                }
                else if (_type == ButtonType.Cancel )
                {
                    if (!isBigButton)
                    {
                        this.SetToolTip(QS2.Desktop.ControlManagment.ControlManagment.getRes("Abbrechen")); 
                    }
                    else
                    {
                        this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Abbrechen");
                    }
                    this.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abbrechen, 32, 32);
                }
                else if (_type == ButtonType.Ignore )
                {
                    if (!isBigButton)
                    {
                        this.SetToolTip(QS2.Desktop.ControlManagment.ControlManagment.getRes("Ignorieren")); 
                    }
                    else
                    {
                        this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ignorieren");
                    }
                    this.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abbrechen, 32, 32);
                }
                else if (_type == ButtonType.OK )
                {
                    if (!isBigButton)
                    {
                        this.SetToolTip(QS2.Desktop.ControlManagment.ControlManagment.getRes("OK")); 
                    }
                    else
                    {
                        this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("OK");
                    }
                    this.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abgezeichnet, 32, 32);
                }
                else if (_type == ButtonType.Print )
                {
                    if (!isBigButton)
                    {
                        this.SetToolTip(QS2.Desktop.ControlManagment.ControlManagment.getRes("Drucken")); 
                    }
                    else
                    {
                        this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Drucken");
                    }
                    this.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, 32, 32);
                }
                else if (_type == ButtonType.Save || _type == ButtonType.saveBenutzerverwaltung)
                {
                    if (!isBigButton)
                    {
                        this.SetToolTip(QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern")); 
                    }
                    else
                    {
                        this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern");
                    }
                    this.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                }
                else if (_type == ButtonType.Search )
                {
                    if (!isBigButton)
                    {
                        this.SetToolTip(QS2.Desktop.ControlManagment.ControlManagment.getRes("Suchen")); 
                    }
                    else
                    {
                        this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Suchen");
                    }
                    this.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                }
                else if (_type == ButtonType.edit )
                {
                    if (!isBigButton)
                    {
                        this.SetToolTip(QS2.Desktop.ControlManagment.ControlManagment.getRes("Editieren")); 
                    }
                    else
                    {
                        this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Editieren");
                    }
                    this.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Bearbeiten, 32, 32);
                }
                else if (_type == ButtonType.Sub )
                {
                    if (!isBigButton)
                    {
                        this.SetToolTip(QS2.Desktop.ControlManagment.ControlManagment.getRes("Entfernen")); 
                    }
                    else
                    {
                        this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Entfernen");
                    }
                    this.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);
                }
                else if (_type == ButtonType.Undo )
                {
                    if (!isBigButton)
                    {
                        this.SetToolTip(QS2.Desktop.ControlManagment.ControlManagment.getRes("Rückgängig"));
                    }
                    else
                    {
                        this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Rückgängig");
                    }
                    this.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Rückgängig, 32, 32);
                }
                else if (_type == ButtonType.beenden )
                {
                    if (!isBigButton)
                    {
                        this.SetToolTip(QS2.Desktop.ControlManagment.ControlManagment.getRes("Beenden")); 
                    }
                    else
                    {
                        this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Beenden");
                    }
                    this.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);
                }
                else if (_type == ButtonType.none)
                {
                    if (!isBigButton)
                    {
                    }
                    else
                    {
                        //this.Text = "";
                    }
                    this.Appearance.Image = null;
                }
                if (qs2.core.ENV.SystemIsInitialized)
                {
                    //if (isBigButton)
                    //{
          
                    //}
                    //else
                    //{
                    //    this.Text = "";
                    //}
                }
                else
                {
                    //this.Text = "";
                }
			}
		}

        public void SetToolTip(string ToolTipText)
        {
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
            ToolTipInfo.ToolTipTitle = "";
            ToolTipInfo.ToolTipText = ToolTipText;
            toolTip1.SetUltraToolTip(this, ToolTipInfo);
        }


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTip1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolTip1
            // 
            this.toolTip1.ContainingControl = this;
            this.toolTip1.InitialDelay = 0;
            // 
            // ucButton
            // 
            this.IsStandardControl = true;
            this.VisibleChanged += new System.EventHandler(this.ucButton_VisibleChanged);
            this.ResumeLayout(false);

		}
		#endregion

		protected override void OnClick(EventArgs e)
		{
            //if (this._DoOnClick)
            //{
                if (Enabled)
                    base.OnClick(e);
            //}
		}

        private void ucButton_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                this.get_setStandardControl(_type.ToString(), false );
            }
            catch (Exception ex)
            {
                throw new Exception("ucButton_VisibleChanged: " + ex.ToString());
            }
        }

	}
}
