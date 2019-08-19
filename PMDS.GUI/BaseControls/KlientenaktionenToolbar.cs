using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PMDS.GUI.BaseControls
{
    public partial class KlientenaktionenToolbar : Component
    {
        public KlientenaktionenToolbar()
        {
            InitializeComponent();
        }

        public KlientenaktionenToolbar(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
