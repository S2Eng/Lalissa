using System;

using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.BusinessLogic;
using System.ComponentModel;
using PMDS.Global.db.Patient;
using PMDS.DB;
using System.Linq;



namespace PMDS.GUI.BaseControls
{

	public class BereichsCombo : Infragistics.Win.UltraWinEditors.UltraComboEditor
	{
		private bool _bENVAbteilung = true;
        private Guid _IDABteilung = Guid.Empty;

        public PMDSBusiness b = new PMDSBusiness();





        public BereichsCombo()
		{
		}

		[Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ENVAbteilung
		{
			get	{	return _bENVAbteilung;	}
			set	
			{	
				_bENVAbteilung = value;
				RefreshList(false);
			}
		}

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDABTEILUNG
        {
            set
            {
                _IDABteilung = value;
                RefreshList(true);
            }
            get
            {
                return _IDABteilung;
            }
        }

		public void RefreshList(bool InsertEmtyOne)
		{
			this.Items.Clear();

            if (InsertEmtyOne)
                this.Items.Add(Guid.Empty, "Bitte Bereich wählen");

			try
			{
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.BereichBenutzer> tBereichBenutzer = this.b.getBereichBenutzer(ENV.USERID, db);
                    
                    dsBereich.BereichDataTable t;
                    if (IDABTEILUNG != Guid.Empty)
                    {
                        t = KlinikBereiche.ByAbteilung(IDABTEILUNG);
                    }
                    else
                    {
                        if (ENVAbteilung)
                            t = KlinikBereiche.ByAbteilung(ENV.ABTEILUNG);
                        else
                        {
                            t = Klinik.Default().Bereiche.Bereiche;
                        }
                    }
                    foreach (dsBereich.BereichRow r in t.Rows)
                    {
                        var tBereichRight = (from bb in tBereichBenutzer
                                               where bb.IDBereich == r.ID
                                               select new
                                               {
                                                   IDBereich = bb.IDBereich
                                               });
                        if (tBereichRight.Count() > 0)
                        {
                            this.Items.Add(r.ID, r.Bezeichnung);
                        }
                    }
                }

            }
			catch(Exception e)
			{
				ENV.HandleException(e);
			}
		}

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDBereich
        {
            get
            {
                if (Items.Count == 0)
                    return Guid.Empty;
                return (Guid)SelectedItem.DataValue;
            }
        }

        public override void RefreshList()
        {
            RefreshList(false);
        }
	}

}
