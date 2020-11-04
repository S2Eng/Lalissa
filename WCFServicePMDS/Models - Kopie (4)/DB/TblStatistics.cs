using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblStatistics
    {
        public int Id { get; set; }
        public int Nr { get; set; }
        public int RecordId { get; set; }
        public DateTime SurgDt { get; set; }
        public double Vlad { get; set; }
        public double LogPredMort { get; set; }
        public double ConfidenceIntervall1 { get; set; }
        public double Low1 { get; set; }
        public double High1 { get; set; }
        public double ConfidenceIntervall2 { get; set; }
        public double Low2 { get; set; }
        public double High2 { get; set; }
        public double ConfidenceIntervall3 { get; set; }
        public double Low3 { get; set; }
        public double High3 { get; set; }
        public double ConfidenceIntervall4 { get; set; }
        public double Low4 { get; set; }
        public double High4 { get; set; }
        public int SurgId { get; set; }
        public string SurgName { get; set; }
        public int CusumcumDeads { get; set; }
        public double CusumavgObsMort { get; set; }
        public double CusumworseningAlarm { get; set; }
        public double CusumworseningAlert { get; set; }
        public double CusumimprovementAlert { get; set; }
        public double CusumimprovementAlarm { get; set; }
    }
}