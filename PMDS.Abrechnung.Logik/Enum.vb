
Public Enum eKonto
    Zahlungen = 1
    Kundenforderungen = 2
    USt = 3
    Erlöse = 4
    Eröffnungsbilanz = 10
End Enum
Public Enum eKontoseite
    soll = 0
    haben = 1
    beide = 2
End Enum
Public Enum eZahlEA
    Auszahlung = 0
    Einzahlung = 1
End Enum



Public Enum eBillTyp
    Alle = 100
    Rechnung = 1
    Beilage = 2
    Sammelrechnung = 3
    Zahlungsbestätigung = 4
    Depotgeld = 5
    FreieRechnung = 6
    KeineRechnung = -1
End Enum
Public Enum eBillStatus
    offen = 0
    freigegeben = 1
    storniert = -10
End Enum
Public Enum eTypRechNr
    Standard = 0
    lfdNr = 1
    Monatlich = 2       '<20121123>
End Enum


Public Enum eCalcRun
    freeBill = 0
    manBill = 1
    month = 2
    all = 100
End Enum
Public Enum eCalcTyp
    abrechnung = 0
    vorauszahlung = 1
End Enum

Public Enum eZahlart
    Bar = 0
    Erlagschein = 1
    Überweisung = 2
    Bankeinzug = 3
    FSW = 4
End Enum


Public Enum eModify
    rechNr = 0
    field = 1
    negativ = 2
    stornoRech = 3
    rechDatum = 4

    openBillRechStor = 20
    openBillRechStorStorno = 21

    nichts = 100
End Enum

Public Enum eTypProt
    LZ = 0
    AbzüglAndererKost = 2
    SumLeistNetto = 3
    MWStSatz = 4
    SumLeistBrutto = 5
    Gesamtkosten = 6
    Rechnungssumme = 7
    GSGB = 8

    AbzüglSumAccontoZahl = 10
    RundAusgleich = 11
    Zahlungsbetrag = 12
    Abwesenheit = 13
    Rollungxy = 14

    GesamtsumNetto = 15
    selbstbehalt = 16

    VorauszahlNetto = 30
    VorauszahlBrutto = 31

    sumGSBG = 33
    GesamtkostenRechnungsbetrag = 34
    sumSelbstbehalt = 35

    Name = 32
    MwStBetrag = 37

    Leerzeile = 1000
End Enum

Public Enum eTypeModifyBill
    StornoRechnung = 0
    StornoSR = 1
End Enum

Public Class anwAbw
    Public anw As Integer = 0
    Public abw As Integer = 0
End Class


