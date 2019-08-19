using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;



namespace PMDS.Global.db.ERSystem
{

    public partial class sqlMedDaten : Component
    {
        public string daSelxy= "";
        public bool isInitialized = false;
        
        public enum eSelTypexy
        {
            IDxy = 0,
        }





        public sqlMedDaten()
        {
            InitializeComponent();
        }

        public sqlMedDaten(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }



        public void initControl()
        {
            try
            {
                if (!this.isInitialized)
                {
                    //this.daSelxy = this.daxy.SelectCommand.CommandText;

                    this.isInitialized = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("sqlMedDaten.initControl: " + ex.ToString());
            }
        }


    }
}
