using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;




namespace qs2.sitemap.workflowAssist
{


    public partial class license : Component
    {

        private string _IDParticipant;
        private qs2.core.license.doLicense.eApp _IDApplication;
        




        public license()
        {
            InitializeComponent();
        }

        public license(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public string OwnParticipant
        {
            get
            {
                return this._IDParticipant;
            }
            set
            {
                this._IDParticipant = value;
            }
        }

        public qs2.core.license.doLicense.eApp OwnApplication
        {
            get
            {
                return this._IDApplication;
            }
            set
            {
                this._IDApplication = value;
            }
        }


    }
}
