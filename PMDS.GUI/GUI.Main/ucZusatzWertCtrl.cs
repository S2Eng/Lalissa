//----------------------------------------------------------------------------
/// <summary>
///	ucZusatzWertCtrl.cs
/// Erstellt am:	07.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.Data.Global;
using PMDS.BusinessLogic;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinMaskedEdit;
using PMDS.DB;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// UserControl zum Bearbeiten von eines ZusatzWertees.
	/// </summary>
	//----------------------------------------------------------------------------
	public class ucZusatzWertCtrl : QS2.Desktop.ControlManagment.BaseControl, IReadOnly
	{
        public ZWCBase	_ctrl;
        public QS2.Desktop.ControlManagment.BaseLabel labelInfo;

        public event EventHandler ValueChanged;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtValue;
		private QS2.Desktop.ControlManagment.BaseComboEditor cbValue;
        private dsINTListe dsINTListe1;
		private QS2.Desktop.ControlManagment.BaseTextEditor txtBigValue;
		private QS2.Desktop.ControlManagment.BaseComboEditor cbListValue;
		private QS2.Desktop.ControlManagment.BaseMaskEdit maskValue;
		private PMDS.GUI.ucZusatzWertImage ucZusatzWertImage1;
        private QS2.Desktop.ControlManagment.BaseMaskEdit maskFValue;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private IContainer components;

        public Guid IDAufenthalt = System.Guid.Empty;
        public ZusatzWertPara ZusatzWertPara1 = null;

        public frmPflegeEintragSmall mainWindowEditEintragÜbergabe = null;





        //----------------------------------------------------------------------------
        /// <summary>
        /// Konstruktor
        /// </summary>
        //----------------------------------------------------------------------------
        public ucZusatzWertCtrl(ZusatzWertPara def)
		{
			InitializeComponent();
			GenerateControl(def);
		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert den Text des Labels
        /// </summary>
        //----------------------------------------------------------------------------
        public string GetLabelText()
        {
            return labelInfo.Text;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert den Text des Wertes
        /// </summary>
        //----------------------------------------------------------------------------
        public string GetValueText()
        {
            return _ctrl.GetControlText();
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dispose
		/// </summary>
		//----------------------------------------------------------------------------
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.labelInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtValue = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.cbValue = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.dsINTListe1 = new dsINTListe();
            this.txtBigValue = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.cbListValue = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.maskValue = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.maskFValue = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.ucZusatzWertImage1 = new PMDS.GUI.ucZusatzWertImage();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsINTListe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBigValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbListValue)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.Location = new System.Drawing.Point(16, 3);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(136, 14);
            this.labelInfo.TabIndex = 99;
            this.labelInfo.Text = "<Bezeichnung>";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Enabled = false;
            this.txtValue.Location = new System.Drawing.Point(152, 0);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(336, 21);
            this.txtValue.TabIndex = 0;
            this.txtValue.Text = "nur Text";
            this.txtValue.Visible = false;
            this.txtValue.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cbValue
            // 
            this.cbValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbValue.Enabled = false;
            this.cbValue.Location = new System.Drawing.Point(152, 120);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(336, 21);
            this.cbValue.TabIndex = 2;
            this.cbValue.Text = "Text mit Auswahlliste";
            this.cbValue.Visible = false;
            this.cbValue.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // dsINTListe1
            // 
            this.dsINTListe1.DataSetName = "dsINTListe";
            this.dsINTListe1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsINTListe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtBigValue
            // 
            this.txtBigValue.AcceptsReturn = true;
            this.txtBigValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBigValue.Enabled = false;
            this.txtBigValue.Location = new System.Drawing.Point(152, 24);
            this.txtBigValue.Multiline = true;
            this.txtBigValue.Name = "txtBigValue";
            this.txtBigValue.Size = new System.Drawing.Size(336, 88);
            this.txtBigValue.TabIndex = 1;
            this.txtBigValue.Text = "mehrzeiliger Text";
            this.txtBigValue.Visible = false;
            this.txtBigValue.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // cbListValue
            // 
            this.cbListValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbListValue.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbListValue.Enabled = false;
            this.cbListValue.Location = new System.Drawing.Point(152, 144);
            this.cbListValue.Name = "cbListValue";
            this.cbListValue.Size = new System.Drawing.Size(336, 21);
            this.cbListValue.TabIndex = 3;
            this.cbListValue.Visible = false;
            this.cbListValue.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // maskValue
            // 
            this.maskValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maskValue.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.maskValue.Enabled = false;
            this.maskValue.Location = new System.Drawing.Point(152, 168);
            this.maskValue.Name = "maskValue";
            this.maskValue.NonAutoSizeHeight = 20;
            this.maskValue.Size = new System.Drawing.Size(336, 20);
            this.maskValue.TabIndex = 4;
            this.maskValue.Visible = false;
            this.maskValue.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // maskFValue
            // 
            this.maskFValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maskFValue.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.maskFValue.Enabled = false;
            this.maskFValue.Location = new System.Drawing.Point(152, 192);
            this.maskFValue.Name = "maskFValue";
            this.maskFValue.NonAutoSizeHeight = 20;
            this.maskFValue.Size = new System.Drawing.Size(336, 20);
            this.maskFValue.TabIndex = 100;
            this.maskFValue.Text = ".";
            this.maskFValue.Visible = false;
            this.maskFValue.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ucZusatzWertImage1
            // 
            this.ucZusatzWertImage1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucZusatzWertImage1.Image = null;
            this.ucZusatzWertImage1.ImageName = "";
            this.ucZusatzWertImage1.Location = new System.Drawing.Point(152, 224);
            this.ucZusatzWertImage1.Name = "ucZusatzWertImage1";
            this.ucZusatzWertImage1.ReadOnly = false;
            this.ucZusatzWertImage1.Size = new System.Drawing.Size(336, 88);
            this.ucZusatzWertImage1.TabIndex = 5;
            this.ucZusatzWertImage1.Visible = false;
            this.ucZusatzWertImage1.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // ucZusatzWertCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.maskFValue);
            this.Controls.Add(this.ucZusatzWertImage1);
            this.Controls.Add(this.maskValue);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.txtBigValue);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.cbListValue);
            this.Controls.Add(this.cbValue);
            this.Name = "ucZusatzWertCtrl";
            this.Size = new System.Drawing.Size(504, 352);
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsINTListe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBigValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbListValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// AuswahlListe worhanden
		/// </summary>
		//----------------------------------------------------------------------------
		private bool HasSelectList(ZusatzWertPara def)
		{
			if (def.Liste == null)
				return false;

			return (def.Liste.Rows.Count != 0);	
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Control initialisieren
		/// </summary>
		//----------------------------------------------------------------------------
		private void GenerateControl(ZusatzWertPara def)
		{
			_ctrl = null;
			labelInfo.Text	= def.Bezeichnung;
            this.ZusatzWertPara1 = def;

            switch (def.Type)

			{
				case ZusatzEintragTyp.LABEL:
					_ctrl = new ZWCLabel(labelInfo, def);
					this.TabStop = false;
					break;

				case ZusatzEintragTyp.TEXT:
					if (HasSelectList(def))
						_ctrl = new ZWCTextList(cbValue, def);
					else
						_ctrl = new ZWCText(txtValue, def);
					break;

				case ZusatzEintragTyp.INT:
					if (HasSelectList(def))
						_ctrl = new ZWCINTList(cbListValue, def);
					else
						_ctrl = new ZWCINT(maskValue, def);
					break;

				case ZusatzEintragTyp.BIG_TEXT:
					_ctrl = new ZWCBigText(txtBigValue, def);
					break;

				case ZusatzEintragTyp.IMAGE:
					_ctrl = new ZWCIMAGE(ucZusatzWertImage1, def);
					break;
			
				case ZusatzEintragTyp.FLOAT:
					_ctrl = new ZWCFLOAT(maskFValue, def);
					break;

				default:
					throw new NotSupportedException(def.Type.ToString());
			}

			// Positionieren
			_ctrl.Ctrl.Visible  = true;
			_ctrl.Ctrl.Enabled  = true;
            
			if (def.Type == ZusatzEintragTyp.LABEL)
			{
				_ctrl.Ctrl.Location = new Point(_ctrl.Ctrl.Location.X - 10, _ctrl.Ctrl.Location.Y);
				ClientSize = new Size(ClientSize.Width, txtValue.ClientSize.Height+2);
			}
			else
			{
				_ctrl.Ctrl.Location = txtValue.Location;
				ClientSize = new Size(ClientSize.Width, _ctrl.Ctrl.ClientSize.Height+2);
			}
		}

		public void UpdateGUI()
		{
			_ctrl.UpdateGUI();
		}

		public void UpdateDATA()
		{
			_ctrl.UpdateDATA();
		}

		protected void OnValueChanged(object sender, EventArgs args)
		{
			if (ValueChanged != null)
				ValueChanged(sender, args);

            if (this.mainWindowEditEintragÜbergabe != null)
            {
                this.mainWindowEditEintragÜbergabe.HasChanged = true;
            }
		}

		public dsZusatzWert.ZusatzWertRow Value
		{
			get	{	return _ctrl.Value;	}
			set	
			{	
				if (value == null)
					throw new ArgumentNullException("Value");

				_ctrl.Value = value;
				UpdateGUI();

                if (ENV.ShowPPToolTip)
                {
                    this.doToolTipsHeute(this.IDAufenthalt);
                }
			}
		}

        public void doToolTipsHeute(Guid IDAufenthalt)
        {
            try
            {
                if (IDAufenthalt != System.Guid.Empty)
                {
                    PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        DateTime dNow = DateTime.Now;
                        ZusatzWertVerlauf ZusatzWertVerlauf1 = new ZusatzWertVerlauf();
                        
                        PMDS.db.Entities.ZusatzGruppeEintrag  rZusatzGruppeEintrag = b.getZusatzGruppeEintrag(this.Value.IDZusatzGruppeEintrag, db);
                        dsZusatzVerlauf.ZusatzWertDataTable tZusatzwerteHeute = ZusatzWertVerlauf1.ReadVerlauf(IDAufenthalt, rZusatzGruppeEintrag.IDZusatzEintrag, dNow.AddDays(-1), dNow);
                        dsZusatzVerlauf.ZusatzWertRow[] arrZusatzWert = (dsZusatzVerlauf.ZusatzWertRow[])tZusatzwerteHeute.Select("", "Zeitpunkt asc");
                        string sTxtToolTip = "";
                        string sTitleToolTip = "";
                        foreach (dsZusatzVerlauf.ZusatzWertRow rZusatzWert in arrZusatzWert)
                        {
                            sTxtToolTip +=  rZusatzWert.Zeitpunkt.ToString("dd.MM.yyyy HH:mm:ss") + ": " + rZusatzWert.Wert.ToString() + "\r\n";
                            sTitleToolTip = QS2.Desktop.ControlManagment.ControlManagment.getRes("Werte der letzten 24 Stunden:");
                        }
                        Infragistics.Win.UltraWinToolTip.UltraToolTipInfo info = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                        info.ToolTipText = sTxtToolTip.Trim();
                        info.ToolTipTitle = sTitleToolTip.Trim();
                        ultraToolTipManager1.SetUltraToolTip(this, info);
                        ultraToolTipManager1.SetUltraToolTip(this.labelInfo, info);
                    }
                }
                else
                {
                    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo info = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                    string sTxtToolTip = "";
                    string sTitleToolTip = QS2.Desktop.ControlManagment.ControlManagment.getRes("Werte der letzten 24 Stunden konnten nicht gelesen werden.");
                    info.ToolTipText = sTxtToolTip.Trim();
                    info.ToolTipTitle = sTitleToolTip.Trim(); 
                    ultraToolTipManager1.SetUltraToolTip(this, info);
                    ultraToolTipManager1.SetUltraToolTip(this.labelInfo, info);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("doToolTipsHeute: " + ex.ToString());
            }
        }

		public void ValidateFields(ErrorProvider errorProvider1, ref bool bError)
		{
			_ctrl.ValidateFields(errorProvider1, ref bError);
		}

		#region IReadOnly Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// ReadOnly
		/// </summary>
		//----------------------------------------------------------------------------
		public bool ReadOnly
		{
			get	{	return _ctrl.ReadOnly;	}
			set	{	_ctrl.ReadOnly = value;	}
		}

		#endregion
	}

	public class ZWCBase : IReadOnly
	{
		private Control							_ctrl;
		private ZusatzWertPara					_def;
		private dsZusatzWert.ZusatzWertRow		_value;




		public ZWCBase(Control ctrl, ZusatzWertPara def)
		{
			_def = def;
			_ctrl= ctrl;
		}

        public string GetControlText()
        {
            return _ctrl.Text;
        }


		public Control Ctrl
		{
			get	{	return _ctrl;	}
		}


		public virtual ZusatzWertPara Para
		{
			get	{	return _def;	}
		}

		public virtual dsZusatzWert.ZusatzWertRow Value
		{
			get	{	return _value;	}
			set	{	_value = value;	}
		}

		public virtual void UpdateGUI()
		{
		}

		public virtual void UpdateDATA()
		{
		}
        
		public virtual void ValidateFields(ErrorProvider errorProvider1, ref bool bError)
		{
		}

		#region IReadOnly Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// ReadOnly
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual bool ReadOnly
		{
			get	{	return false;	}
			set	{					}
		}

		#endregion
	}

	//----------------------------------------------------------------------------

	public class ZWCTextList : ZWCBase, IReadOnly
	{
		private UltraComboEditor _ctrl;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ZWCTextList(UltraComboEditor ctrl, ZusatzWertPara def) : base(ctrl, def)
		{
			_ctrl = ctrl;

			// Werte setzten
			foreach(dsINTListe.INTListeRow r in def.Liste)
				ctrl.Items.Add(r.TEXT, r.TEXT);

			if (!def.IsOptional)
				GuiUtil.ValidateRequired(ctrl);
		}


		public override void UpdateGUI()
		{
			_ctrl.Text = Value.Wert;
		}


		public override void UpdateDATA()
		{
			Value.Wert = _ctrl.Text;
		}


		public override void ValidateFields(ErrorProvider errorProvider1, ref bool bError)
		{
			bool bInfo = true;

			_ctrl.Text = _ctrl.Text.Trim();
			if (!Para.IsOptional)
			{
				GuiUtil.ValidateField(_ctrl, (_ctrl.Text.Length > 0),
					ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
			}
		}

		#region IReadOnly Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// ReadOnly
		/// </summary>
		//----------------------------------------------------------------------------
		public override bool ReadOnly
		{
			get	{	return _ctrl.ReadOnly;	}
			set	{	_ctrl.ReadOnly = value;	}
		}

		#endregion
	}

	public class ZWCText : ZWCBase, IReadOnly
	{
		private QS2.Desktop.ControlManagment.BaseTextEditor _ctrl;



		public ZWCText(QS2.Desktop.ControlManagment.BaseTextEditor ctrl, ZusatzWertPara def) : base(ctrl, def)
		{
			_ctrl = ctrl;
			if (!def.IsOptional)
				GuiUtil.ValidateRequired(ctrl);
		}


		public override void UpdateGUI()
		{
			_ctrl.Text = Value.Wert;
		}


		public override void UpdateDATA()
		{
			Value.Wert = _ctrl.Text;
		}

		public override void ValidateFields(ErrorProvider errorProvider1, ref bool bError)
		{
			bool bInfo = true;

			_ctrl.Text = _ctrl.Text.Trim();
			if (!Para.IsOptional)
			{
				GuiUtil.ValidateField(_ctrl, (_ctrl.Text.Length > 0),
					ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
			}
		}

		#region IReadOnly Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// ReadOnly
		/// </summary>
		//----------------------------------------------------------------------------
		public override bool ReadOnly
		{
			get	{	return _ctrl.ReadOnly;	}
			set	{	_ctrl.ReadOnly = value;	}
		}

		#endregion
	}

	//----------------------------------------------------------------------------

	public class ZWCBigText : ZWCBase, IReadOnly
	{
		private QS2.Desktop.ControlManagment.BaseTextEditor _ctrl;



		public ZWCBigText(QS2.Desktop.ControlManagment.BaseTextEditor ctrl, ZusatzWertPara def) : base(ctrl, def)
		{
			_ctrl = ctrl;
			if (!def.IsOptional)
				GuiUtil.ValidateRequired(ctrl);
		}

		public override void UpdateGUI()
		{
			_ctrl.Text = Value.Wert;
		}

		public override void UpdateDATA()
		{
			Value.Wert = _ctrl.Text;
		}


		public override void ValidateFields(ErrorProvider errorProvider1, ref bool bError)
		{
			bool bInfo = true;

			_ctrl.Text = _ctrl.Text.Trim();
			if (!Para.IsOptional)
			{
				GuiUtil.ValidateField(_ctrl, (_ctrl.Text.Length > 0),
					ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
			}
		}

		#region IReadOnly Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// ReadOnly
		/// </summary>
		//----------------------------------------------------------------------------
		public override bool ReadOnly
		{
			get	{	return _ctrl.ReadOnly;	}
			set	{	_ctrl.ReadOnly = value;	}
		}

		#endregion
	}


	public class ZWCINTList : ZWCBase, IReadOnly
	{
		private UltraComboEditor _ctrl;



		public ZWCINTList(UltraComboEditor ctrl, ZusatzWertPara def) : base(ctrl, def)
		{
			_ctrl = ctrl;

			// Werte setzten
			foreach(dsINTListe.INTListeRow r in def.Liste)
				ctrl.Items.Add(r.ID, r.TEXT);

			if (!def.IsOptional)
				GuiUtil.ValidateRequired(ctrl);
		}


		public override void UpdateGUI()
		{
			_ctrl.Value = Value.ZahlenWert;
		}


		public override void UpdateDATA()
		{
			if (_ctrl.Value != null)
				Value.ZahlenWert = Convert.ToInt32(_ctrl.Value);
		}


		public override void ValidateFields(ErrorProvider errorProvider1, ref bool bError)
		{
			bool bInfo = true;

			_ctrl.Text = _ctrl.Text.Trim();

			if (!Para.IsOptional)
			{
				GuiUtil.ValidateField(_ctrl, (_ctrl.Text.Length > 0),
					ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
			}
		}

		#region IReadOnly Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// ReadOnly
		/// </summary>
		//----------------------------------------------------------------------------
		public override bool ReadOnly
		{
			get	{	return _ctrl.ReadOnly;	}
			set	{	_ctrl.ReadOnly = value;	}
		}

		#endregion
	}

	public class ZWCINT : ZWCBase, IReadOnly
	{
		private UltraMaskedEdit _ctrl;



		public ZWCINT(UltraMaskedEdit ctrl, ZusatzWertPara def) : base(ctrl, def)
		{
			_ctrl = ctrl;
			if (!def.IsOptional)
				GuiUtil.ValidateRequired(ctrl);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten nach GUI übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public override void UpdateGUI()
		{
			if (Value.ZahlenWert == -1)
				_ctrl.Value = null;
			else
				_ctrl.Value = Value.ZahlenWert;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public override void UpdateDATA()
		{
			if (_ctrl.Value == DBNull.Value)
				Value.ZahlenWert = -1;
			else
				Value.ZahlenWert = (int)_ctrl.Value;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Felder validieren
		/// </summary>
		//----------------------------------------------------------------------------
		public override void ValidateFields(ErrorProvider errorProvider1, ref bool bError)
		{
			bool bInfo = true;

			_ctrl.Text = _ctrl.Text.Trim();

			if (!Para.IsOptional)
			{
				GuiUtil.ValidateField(_ctrl, _ctrl.Value != DBNull.Value,
					ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
			}
		}

		#region IReadOnly Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// ReadOnly
		/// </summary>
		//----------------------------------------------------------------------------
		public override bool ReadOnly
		{
			get	{	return _ctrl.ReadOnly;	}
			set	{	_ctrl.ReadOnly = value;	}
		}

		#endregion
	}

	//----------------------------------------------------------------------------

	public class ZWCLabel : ZWCBase
	{
		private UltraLabel _ctrl;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ZWCLabel(UltraLabel ctrl, ZusatzWertPara def) : base(ctrl, def)
		{
			_ctrl = ctrl;
			ctrl.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True;
		}
	}

	//----------------------------------------------------------------------------

	public class ZWCIMAGE : ZWCBase, IReadOnly
	{
		private ucZusatzWertImage _ctrl;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ZWCIMAGE(ucZusatzWertImage ctrl, ZusatzWertPara def) : base(ctrl, def)
		{
			_ctrl = ctrl;
			if (!def.IsOptional)
				GuiUtil.ValidateRequired(ctrl);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten nach GUI übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public override void UpdateGUI()
		{
			_ctrl.ImageName = Value.Wert;

			if (!Value.IsRawFormatNull() && Value.RawFormat.Length != 0)
				_ctrl.Image	= BUtil.ImageFromArray(Value.RawFormat, false);
			else
				_ctrl.Image = null;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public override void UpdateDATA()
		{
			Value.Wert = _ctrl.ImageName;

			if (_ctrl.Image == null)
				Value.SetRawFormatNull();
			else
				Value.RawFormat = BUtil.ImageToArray(_ctrl.Image);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Felder validieren
		/// </summary>
		//----------------------------------------------------------------------------
		public override void ValidateFields(ErrorProvider errorProvider1, ref bool bError)
		{
			bool bInfo = true;

			if (!Para.IsOptional)
			{
				GuiUtil.ValidateField(_ctrl, (_ctrl.ImageName.Length > 0),
					ENV.String("GUI.E_NO_IMAGE"), ref bError, bInfo, errorProvider1);
			}
		}

		#region IReadOnly Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// ReadOnly
		/// </summary>
		//----------------------------------------------------------------------------
		public override bool ReadOnly
		{
			get	{	return _ctrl.ReadOnly;	}
			set	{	_ctrl.ReadOnly = value;	}
		}

		#endregion
	}

	//----------------------------------------------------------------------------

	public class ZWCFLOAT : ZWCBase, IReadOnly
	{
		private UltraMaskedEdit _ctrl;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ZWCFLOAT(UltraMaskedEdit ctrl, ZusatzWertPara def) : base(ctrl, def)
		{
			_ctrl = ctrl;
			if (!def.IsOptional)
				GuiUtil.ValidateRequired(ctrl);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Daten nach GUI übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public override void UpdateGUI()
		{
			if (Value.ZahlenWertFloat == -1.0)
				_ctrl.Value = DBNull.Value;
			else
				_ctrl.Value = Value.ZahlenWertFloat;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// GUI nach Daten übertragen
		/// </summary>
		//----------------------------------------------------------------------------
		public override void UpdateDATA()
		{
			if (_ctrl.Value == DBNull.Value)
				Value.ZahlenWertFloat = -1.0;
			else
				Value.ZahlenWertFloat = (double)_ctrl.Value;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Felder validieren
		/// </summary>
		//----------------------------------------------------------------------------
		public override void ValidateFields(ErrorProvider errorProvider1, ref bool bError)
		{
			bool bInfo = true;

			_ctrl.Text = _ctrl.Text.Trim();

			if (!Para.IsOptional)
			{
				GuiUtil.ValidateField(_ctrl, _ctrl.Value != DBNull.Value,
					ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
			}

			if (_ctrl.Value != DBNull.Value)
			{
				double val = (double)_ctrl.Value;
				GuiUtil.ValidateField(_ctrl, ((val >= Para.MinValue) && (val <= Para.MaxValue)),
					ENV.String("GUI.E_FLOAT_OUTOFRANGE", Para.MinValue, Para.MaxValue), ref bError, bInfo, errorProvider1);
			}
		}

		#region IReadOnly Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// ReadOnly
		/// </summary>
		//----------------------------------------------------------------------------
		public override bool ReadOnly
		{
			get	{	return _ctrl.ReadOnly;	}
			set	{	_ctrl.ReadOnly = value;	}
		}

		#endregion
	}

}
