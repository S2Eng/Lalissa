using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.BusinessLogic;


namespace PMDS.Global
{
    public interface IAnamneseObject
    {
        PDXAnamnese PDXAnamnese { get; set;}
        Guid IDPatient { get; set;}
        DataRow New();
        void Read();
        void Write();
        void Refresh();
        void UpdateDATA(Guid IDAnamnese, DateTime ErstelltAm, Guid IDBenutzer);
        DataTable AnamneseDataTable { get;}
        DataTable PDXByPflegeModell { get;}
        DataTable Pflegemodelle { get;}
        DataTable PDXAnamneseDataTable { get;}
        DataRow GetAnamneseRow(Guid id);
        Guid GetIDBenutzer(Guid IDAnamnese);
    }

    public interface IAnamnese
    {
 	    PflegeModelle Modell {get; set;}
	    Guid IDPatient {get; set;}
	    String EntyText {get; set;}
	    bool ISTOSAVE { get;}
        bool ReadOnly { get;set;}
	    void UpdateGUI();
        void UpdateDATA();
	    bool ValidateFields();
	}

    public interface IAnamneseModellgruppe
    {
        bool ReadOnly { get;set;}
	    void BindData();
        void EndCurrentEdits();
	    bool ValidateFields();
	    dsPDXByPflegeModell.PDXPflegeModellDataTable PDXTable {get; set ;}
        DataRow AnamneseRow { get; set;}
	    PDXAnamnese PDXAnamnese {get; set;}
    }


}
