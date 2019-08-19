//----------------------------------------------------------------------------------------------
//	ucPlacePicker.cs
//  Auswahl Klinik - Abteilung - Bereich
//  Erstellt am:	9.11.2004
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using Infragistics.Win.UltraWinTree;
using PMDS.Global.db.Patient;


namespace PMDS.GUI
{

	public class ucPlacePicker : QS2.Desktop.ControlManagment.BaseControl
	{
		private Infragistics.Win.UltraWinTree.UltraTree tvMain;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public ucPlacePicker()
		{
			InitializeComponent();
			if(DesignMode)
				return;

			RefreshControl();
		}

		private void RefreshControl() 
		{
            PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
            dsKlinik.KlinikRow rKlinikActuell = DBKlinik1.loadKlinik(PMDS.Global.ENV.IDKlinik, true);

            UltraTreeNode n = tvMain.Nodes.Add(rKlinikActuell.ID.ToString(), rKlinikActuell.Bezeichnung);				// Main root
            n.Tag = rKlinikActuell.ID;
			
			// Die einzelnen Abteilungen hinzufügen
            //dsGUIDListe.IDListeDataTable dt = (dsGUIDListe.IDListeDataTable)k.Abteilungen.AllEntries();     //xyhlxyxy

            dsAbteilung dsAbteilung1 = new dsAbteilung();
            PMDS.DB.DBAbteilung DBAbteilung1 = new PMDS.DB.DBAbteilung();
            DBAbteilung1.getAbteilungenByKlinik(rKlinikActuell.ID, dsAbteilung1);
            foreach (dsAbteilung.AbteilungRow rAbt in dsAbteilung1.Abteilung)
            {
                UltraTreeNode na = n.Nodes.Add(rAbt.ID.ToString(), rAbt.Bezeichnung .Trim () );
                na.Tag = rAbt.ID;

                dsBereich.BereichDataTable bt = KlinikBereiche.ByAbteilung(rAbt.ID);
                foreach (dsBereich.BereichRow rb in bt)
                {
                    UltraTreeNode nb = na.Nodes.Add(rb.ID.ToString(), rb.Bezeichnung);
                    nb.Tag = rb.ID;
                }

            }
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
            this.tvMain = new Infragistics.Win.UltraWinTree.UltraTree();
            ((System.ComponentModel.ISupportInitialize)(this.tvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // tvMain
            // 
            this.tvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMain.Location = new System.Drawing.Point(0, 0);
            this.tvMain.Name = "tvMain";
            this.tvMain.Size = new System.Drawing.Size(312, 304);
            this.tvMain.TabIndex = 0;
            // 
            // ucPlacePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tvMain);
            this.Name = "ucPlacePicker";
            this.Size = new System.Drawing.Size(312, 304);
            ((System.ComponentModel.ISupportInitialize)(this.tvMain)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	}
}
