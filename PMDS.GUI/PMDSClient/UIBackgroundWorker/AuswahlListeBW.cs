using Infragistics.Win.UltraWinEditors;
using PMDS.Global.PMDSClient;
using PMDSClient.Sitemap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PMDS.GUI.PMDSClient.UIBackgroundWorker
{

    public class AuswahlListeBW
    {

        private WCFServicePMDS.BAL.AuswahlListeBAL.TypeSelList _TypeSelList = new WCFServicePMDS.BAL.AuswahlListeBAL.TypeSelList();
        private UltraComboEditor _cbo;

        public WCFServicePMDS.BAL.AuswahlListeBAL.TypeSelList TypeSelList
        {
            get => _TypeSelList;
            set => _TypeSelList = value;
        }
     
        public UltraComboEditor cbo
        {
            get => _cbo;
            set => _cbo = value;
        }








        public AuswahlListeBW(WCFServicePMDS.BAL.AuswahlListeBAL.TypeSelList TypeSelList, UltraComboEditor cbo)
        {
            this.TypeSelList = TypeSelList;
            this.cbo = cbo;
            this.loadAuswahlliste();
        }


        private void loadAuswahlliste()
        {
            this.TloadAuswahlliste(cbo);
            //Task t = genCDA3(CDAeTypeCDA, IDEinrichtungEmpfänger);
            //t.Start();
        }
        private async void TloadAuswahlliste(UltraComboEditor cbo)
        {
            System.Threading.Thread.Sleep(5000);
            await Task.Factory.StartNew(() =>
            {



                cbo.Invoke((Action)(() =>
                {
                    cbo.Value = null;
                }));
            });
        }

        private void getSelList(WCFServicePMDS.BAL.AuswahlListeBAL.TypeSelList TypeSelList)
        {
            if (TypeSelList.eTypeSelList == WCFServicePMDS.BAL.AuswahlListeBAL.eTypeSelList.AuswahlListe)
            {
                if (!string.IsNullOrEmpty(TypeSelList.IDGruppe) && String.Equals(TypeSelList.IDGruppe.Trim(), "", StringComparison.OrdinalIgnoreCase))
                {

                }
                else
                    throw new Exception("initControl: TypeSelList.IDGruppe not allowed!");
            }
            else if (TypeSelList.eTypeSelList == WCFServicePMDS.BAL.AuswahlListeBAL.eTypeSelList.Klinik)
            {

            }
            else
                throw new Exception("initControl: TypeSelList '" + TypeSelList.ToString() + "' not allowed!");
        }

    }

}
