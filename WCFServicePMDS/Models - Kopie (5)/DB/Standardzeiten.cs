﻿using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Standardzeiten
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime Zeitpunkt { get; set; }
    }
}