using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.Abrechnung.Global;
using PMDS.BusinessLogic.Abrechnung;
using Infragistics.Win.UltraWinTree;




namespace PMDS.Calc.UI.Admin
{

    
	public class ucLeistungskatalogAuswahl : ucDragPickerBase
	{
        
        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLeistungskatalogAuswahl));
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            ((System.ComponentModel.ISupportInitialize)(this.tvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // tvMain
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(224)))), ((int)(((byte)(187)))));
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(224)))), ((int)(((byte)(187)))));
            appearance1.ForeColor = System.Drawing.Color.Black;
            _override1.ActiveNodeAppearance = appearance1;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(224)))), ((int)(((byte)(187)))));
            appearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(224)))), ((int)(((byte)(187)))));
            appearance2.ForeColor = System.Drawing.Color.Black;
            _override1.SelectedNodeAppearance = appearance2;
            this.tvMain.Override = _override1;
            this.tvMain.UseAppStyling = false;
            this.tvMain.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // btnPush
            // 
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            this.btnPush.Appearance = appearance3;
            this.btnPush.Location = new System.Drawing.Point(185, 36);
            this.btnPush.Size = new System.Drawing.Size(30, 26);
            // 
            // btnPull
            // 
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            this.btnPull.Appearance = appearance4;
            this.btnPull.Location = new System.Drawing.Point(185, 63);
            this.btnPull.Size = new System.Drawing.Size(30, 26);
            this.btnPull.Visible = false;
            // 
            // ucLeistungskatalogAuswahl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "ucLeistungskatalogAuswahl";
            ((System.ComponentModel.ISupportInitialize)(this.tvMain)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        
        public ucLeistungskatalogAuswahl()
		{
			InitializeComponent();
		}
        public override void RefreshControl()
		{
			LeistungsKatalog k = new LeistungsKatalog();
			dsLeistungskatalog ds;
            tvMain.Nodes.Clear();

			int i = 0;
            foreach (string s in abrech.GetleistungsgruppeNames())
			{
				UltraTreeNode n = tvMain.Nodes.Add("Root" + i.ToString(), s);
				n.Tag = Guid.Empty;
                n.Override.NodeAppearance.ForeColor = Color.RoyalBlue;
                //n.Override.NodeAppearance.BackColor = Color.White;
				ds = k.Read(i);
				foreach(dsLeistungskatalog.LeistungskatalogRow r in ds.Leistungskatalog)
				{
                    if (r.IsIDKlinikNull())
                    {
                        UltraTreeNode nl = n.Nodes.Add(r.ID.ToString(), r.Bezeichnung);
                        nl.Tag = r.ID;
                    }
                    else
                    {
                        if (ENV.IDKlinik.Equals(r.IDKlinik))
                        {
                            UltraTreeNode nl = n.Nodes.Add(r.ID.ToString(), r.Bezeichnung);
                            nl.Tag = r.ID;
                        }
                    }
				}

				i++;
			}

			tvMain.ExpandAll();
            //tvMain.SelectedNodes.Clear();
            //tvMain.ActiveNode = null;
        }
        
	}
}
