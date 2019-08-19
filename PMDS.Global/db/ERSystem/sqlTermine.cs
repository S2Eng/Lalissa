using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;




namespace PMDS.Global.db.ERSystem
{




    public partial class sqlTermine : Component
    {
        public sqlTermine()
        {
            InitializeComponent();
        }

        public sqlTermine(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }



    }
}
