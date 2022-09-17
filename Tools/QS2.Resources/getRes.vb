Imports System.Drawing



Public Class getRes

    Public Enum Allgemein

        ico_Abbrechen = 100
        ico_Abgezeichnet = 101
        ico_Bearbeiten = 102
        ico_Beenden = 103
        ico_ChooseAll = 104
        ico_ChooseNone = 105
        ico_Drucken = 106
        ico_Loeschen = 107
        ico_Minus = 108
        ico_NeuesDokument = 109
        ico_Oeffnen = 110
        ico_OK = 111
        ico_Plus = 112
        ico_Speichern = 113
        ico_Ueberfaellig = 114
        ico_Vorwaerts = 115
        ico_Zurueck = 116

        ico_Aktualisieren = 117
        ico_Rückgängig = 118
        ico_Suche = 119
        ico_Vergrößern = 120
        ico_Verkleinern = 121
        ico_Vorschau = 122
        ico_Table = 123

        ico_about = 124
        ico_antworten = 125
        ico_earth = 126
        ico_folder = 127
        ico_heftklammer = 128
        ico_historie = 129
        ico_persons = 130
        ico_scannen = 131
        ico_send = 132
        ico_trash = 133

    End Enum
    Public Enum Allgemein2
        ico_Transparent = 200
        ico_Excel = 203
        ico_Editor = 204
        ico_Info = 205
        ico_Wichtig = 206
        ico_PDF = 209
        ico_Message = 210
        ico_Dokumentenarchiv = 211
        ico_Pflaster = 212
        ico_OffeneMeldungen = 213
        ico_Rechte = 214
        ico_Help = 216
        ico_Clock = 217
        ico_Ausschneiden = 219
        ico_Kopieren = 220
        ico_Ordner = 221
        ico_Weiterleiten = 222
        ico_Winword = 223
        ico_Outlook = 224
        ico_AlleTermine = 225
        ico_Archiv = 226
        ico_Kliententermine = 227
        ico_MeineTermine = 228
        ico_yellow = 229
        ico_green = 230
        ico_red = 231
    End Enum

    Public Enum Launcher
        ico_Abrechnung = 300
        ico_Bewerber = 301
        ico_Datenuebernahme = 302
        ico_Onlineformulare = 303
        ico_PEPS = 304
        ico_PMDS = 305
        ico_Stammdaten = 306
        ico_Touchdoku = 307
        ico_QS2 = 308
    End Enum

    Public Enum PMDS_Abrechnung
        ico_Abrechnung = 400
        ico_Abrechnungsberichte = 401
        ico_Abrechnungsstammdaten = 402
        ico_Buchhaltung = 403
        ico_Depotgeld = 404
        ico_Kostenstraeger = 405
        ico_Leistungskatalog = 406
        ico_Rechnung = 407
        ico_Sammelabrechnung = 408
        ico_Sonderleistungen = 409

        ico_Tagsatzliste = 410
    End Enum

    Public Enum PMDS_Intervention
        ico_Einzelverordnung = 500
        ico_FreierBericht = 501
        ico_Massnahmen = 502
        ico_Sondertermine = 503
    End Enum

    Public Enum PMDS_Klientenakt
        ico_ArchivTerminemail = 600
        ico_Berichte = 601
        ico_Datenerhebung = 602
        ico_Datenerhebung_2 = 603
        ico_Evaluierung = 604
        ico_Evaluierung_2 = 605
        ico_Interventionen = 606
        ico_Interventionen_2 = 607
        ico_Klientenliste = 608
        ico_MitverantworticherBereich = 609
        ico_Patient = 610
        ico_Planung = 611
        ico_Planung_2 = 612
        ico_Uebergabe = 613
        ico_Uebergabe_2 = 614
        ico_Wunddoku = 615
        ico_Ausrufezeichen = 616
    End Enum

    Public Enum PMDS_Klientenliste
        ico_Aufnahme = 700
        ico_Bereichsuebersicht = 701
        ico_Klientenakt = 702
        ico_Klientenakt_2 = 703
    End Enum

    Public Enum PMDS_MedizinischeTypen
        ico_Allergien = 800
        ico_Antikaguliert = 801
        ico_Diabetes = 802
        ico_Impfungen = 803
        ico_Implantate = 804
        ico_Infektion = 805
        ico_Katheder = 806
        ico_Kostform = 807
        ico_MedizinischeDauerdiagnosen = 808
        ico_MedizinischeDiagnosen = 809
        ico_Nuechtern = 810
        ico_Sonstiges = 811
        ico_Suchtmittel = 812
        ico_Befunde = 813
        ico_UnverträglichkeitenRZ = 814
        ico_InfektionRZ = 815
    End Enum

    Public Enum PMDS_TouchDoku
        ico_Bereichsansicht = 900
        ico_Pfleger = 901
    End Enum


    'QS2
    Public Enum ePicture
        none = -999

        ico_marked = 1000
        ico_lock = 1001

        ico_up = 1002
        ico_down = 1003

        ico_User = 1006
        ico_modifyQuery = 1007
        ico_adjustments = 1008
        ico_selLists = 1009
        ico_license = 1010
        ico_doLicense = 1012
        ico_log = 1013
        ico_sys = 1014
        ico_Ressourcen = 1015
        ico_Criterias = 1016

        ICO_weis = 1017

        ico_service = 1019
        ico_Queries = 1020
        ico_ManageQueries = 1021
        ico_Reports = 1022

        logoProducer = 1025

        reportDefault = 1026
        queryDefault = 1027

        ico_forward = 1029
        ico_PatientSearch = 1030

        QS2_10cm_RGB = 1031

    End Enum

    Public Enum ePicTyp
        bmp = 20000
        jpg = 20001
        gif = 20002
        ico = 20003
        png = 20004
        img = 20005
    End Enum
    Public Enum PMDS2
        ico_Interventionen2 = 1100
        ico_Medikamente_01 = 1101
        ico_Medizinische_Daten = 1102
        ico_Verknüpfen_03 = 1103
        ico_Verordnungen_03 = 1104
        ico_Wunden = 1105
        ico_Wunden_02 = 1106
    End Enum

    Public Shared namespaceToLoad = "QS2.Resources."






    Public Shared Function getIcon(ByVal icon As [Enum], ByVal width As Integer, ByVal height As Integer) As Icon

        Try
            Dim resourceName As String = getRes.namespaceToLoad + icon.ToString() + ".ico"
            Dim thisExe As System.Reflection.Assembly
            thisExe = System.Reflection.Assembly.GetExecutingAssembly()

            Dim strm As System.IO.Stream
            strm = thisExe.GetManifestResourceStream(resourceName)
            Dim ico As System.Drawing.Icon
            ico = New System.Drawing.Icon(strm, New Size(width, height))
            Return ico

        Catch ex As Exception
            Throw New Exception("getRes.getIcon: Icon '" + icon.ToString() + "' could not load!'" + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Shared Function getImage(ByVal icon As [Enum], ByVal width As Integer, ByVal height As Integer) As Bitmap

        Try
            Return getIcon(icon, width, height).ToBitmap()

        Catch ex As Exception
            Throw New Exception("getRes.getImage: Icon '" + icon.ToString() + "' could not load!'" + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Shared Function getImage(ByVal icon As [Enum]) As Image
        Try
            If icon.ToString().Trim().ToLower().Equals((ePicture.none.ToString().ToLower())) Then
                Return Nothing
            End If

            Dim resourceName As String = getRes.namespaceToLoad + icon.ToString() + ".ico"
            Dim thisExe As System.Reflection.Assembly
            thisExe = System.Reflection.Assembly.GetExecutingAssembly()

            Dim strm As System.IO.Stream
            strm = thisExe.GetManifestResourceStream(resourceName)
            Dim img As System.Drawing.Image
            img = System.Drawing.Image.FromStream(strm)
            Return img

        Catch ex As Exception
            Throw New Exception("getRes.getImage: Icon '" + icon.ToString() + "' could not load!'" + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Shared Function getImage(ByVal icon As [Enum], PicTyp As ePicTyp) As Image
        Try
            If icon.ToString().Trim().ToLower().Equals((ePicture.none.ToString().ToLower())) Then
                Return Nothing
            End If

            Dim resourceName As String = getRes.namespaceToLoad + icon.ToString() + "." + PicTyp.ToString()
            Dim thisExe As System.Reflection.Assembly
            thisExe = System.Reflection.Assembly.GetExecutingAssembly()

            Dim strm As System.IO.Stream
            strm = thisExe.GetManifestResourceStream(resourceName)
            Dim img As System.Drawing.Image
            img = System.Drawing.Image.FromStream(strm)
            Return img

        Catch ex As Exception
            Throw New Exception("getRes.getImage: Icon '" + icon.ToString() + "' could not load!'" + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Shared Function ImgToIco(ByVal SourceImage As Image) As Icon
        Try
            Dim TempBitmap As New Bitmap(SourceImage)
            Return Icon.FromHandle(TempBitmap.GetHicon())

        Catch ex As Exception
            Throw New Exception("getRes.ImgToIco: Icon '" + SourceImage.ToString() + "' could not load!'" + vbNewLine + ex.ToString())
        End Try
    End Function



    Public Shared Function getIconFromTxt(ByVal icon As String, ByVal width As Integer, ByVal height As Integer) As Icon
        Try
            Dim resourceName As String = getRes.namespaceToLoad + icon.Trim() + ".ico"
            Dim thisExe As System.Reflection.Assembly
            thisExe = System.Reflection.Assembly.GetExecutingAssembly()

            Dim strm As System.IO.Stream
            strm = thisExe.GetManifestResourceStream(resourceName)
            Dim ico As System.Drawing.Icon
            ico = New System.Drawing.Icon(strm, New Size(width, height))
            Return ico

        Catch ex As Exception
            Throw New Exception("getRes.ImgToIco: Icon '" + icon.ToString() + "' could not load!'" + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Shared Function getImageFromTxt(ByVal icon As String, ByVal width As Integer, ByVal height As Integer) As Bitmap

        Try
            Return getIconFromTxt(icon, width, height).ToBitmap()

        Catch ex As Exception
            Throw New Exception("getRes.getImageFromTxt: Icon '" + icon.ToString() + "' could not load!'" + vbNewLine + ex.ToString())
        End Try
    End Function


    Public Shared Function getImage(EnumAsText As String, IconWidth As Integer, IconHeigth As Integer) As Image
        Try
            Dim Found As Boolean = False
            Dim EnumValFound As Integer = -999

            If IconWidth < 0 Then
                IconWidth = 32
            End If
            If IconHeigth < 0 Then
                IconHeigth = 32
            End If


            Dim eAllgemein As New QS2.Resources.getRes.Allgemein
            Dim imgFound As Image = getRes.SearchImageInEnumFromText(EnumAsText.Trim(), eAllgemein, Found, IconWidth, IconHeigth)
            If Not imgFound Is Nothing Then
                Return imgFound
            End If

            Dim eAllgemein2 As New QS2.Resources.getRes.Allgemein2
            imgFound = getRes.SearchImageInEnumFromText(EnumAsText.Trim(), eAllgemein2, Found, IconWidth, IconHeigth)
            If Not imgFound Is Nothing Then
                Return imgFound
            End If

            Dim eLauncher As New QS2.Resources.getRes.Launcher
            imgFound = getRes.SearchImageInEnumFromText(EnumAsText.Trim(), eLauncher, Found, IconWidth, IconHeigth)
            If Not imgFound Is Nothing Then
                Return imgFound
            End If

            Dim ePMDS_Abrechnung As New QS2.Resources.getRes.PMDS_Abrechnung
            imgFound = getRes.SearchImageInEnumFromText(EnumAsText.Trim(), ePMDS_Abrechnung, Found, IconWidth, IconHeigth)
            If Not imgFound Is Nothing Then
                Return imgFound
            End If

            Dim ePMDS_Intervention As New QS2.Resources.getRes.PMDS_Intervention
            imgFound = getRes.SearchImageInEnumFromText(EnumAsText.Trim(), ePMDS_Intervention, Found, IconWidth, IconHeigth)
            If Not imgFound Is Nothing Then
                Return imgFound
            End If

            Dim ePMDS_Klientenakt As New QS2.Resources.getRes.PMDS_Klientenakt
            imgFound = getRes.SearchImageInEnumFromText(EnumAsText.Trim(), ePMDS_Klientenakt, Found, IconWidth, IconHeigth)
            If Not imgFound Is Nothing Then
                Return imgFound
            End If

            Dim ePMDS_Klientenliste As New QS2.Resources.getRes.PMDS_Klientenliste
            imgFound = getRes.SearchImageInEnumFromText(EnumAsText.Trim(), ePMDS_Klientenliste, Found, IconWidth, IconHeigth)
            If Not imgFound Is Nothing Then
                Return imgFound
            End If

            Dim ePMDS_MedizinischeTypen As New QS2.Resources.getRes.PMDS_MedizinischeTypen
            imgFound = getRes.SearchImageInEnumFromText(EnumAsText.Trim(), ePMDS_MedizinischeTypen, Found, IconWidth, IconHeigth)
            If Not imgFound Is Nothing Then
                Return imgFound
            End If

            Dim ePMDS_TouchDoku As New QS2.Resources.getRes.PMDS_TouchDoku
            imgFound = getRes.SearchImageInEnumFromText(EnumAsText.Trim(), ePMDS_TouchDoku, Found, IconWidth, IconHeigth)
            If Not imgFound Is Nothing Then
                Return imgFound
            End If

            Dim ePMDS_IconsQS2 As New QS2.Resources.getRes.ePicture
            imgFound = getRes.SearchImageInEnumFromText(EnumAsText.Trim(), ePMDS_TouchDoku, Found, IconWidth, IconHeigth)
            If Not imgFound Is Nothing Then
                Return imgFound
            End If

            Dim ePMDS2 As New QS2.Resources.getRes.PMDS2
            imgFound = getRes.SearchImageInEnumFromText(EnumAsText.Trim(), ePMDS2, Found, IconWidth, IconHeigth)
            If Not imgFound Is Nothing Then
                Return imgFound
            End If

        Catch ex As Exception
            Throw New Exception("getRes.getImage: " + ex.ToString())
        End Try
    End Function
    Private Shared Function SearchImageInEnumFromText(ByRef EnumAsText As String, ByRef EnumToSearch As [Enum], ByRef Found As Boolean, _
                                            ByRef IconWidth As Integer, ByRef IconHeigth As Integer) As Image
        Try
            Dim EnumValFound As Integer = -999
            getRes.SearchEnumFromText(EnumAsText.Trim(), EnumToSearch.GetType(), Found, EnumValFound)
            If Found Then
                Return getRes.getImageFromTxt(EnumAsText, IconWidth, IconHeigth)
            End If

        Catch ex As Exception
            Throw New Exception("getRes.SearchEnumFromText: " + ex.ToString())
        End Try
    End Function
    Public Shared Function SearchEnumFromText(ByRef EnumAsText As String, EnumTypeToSearch As Type, _
                                       ByRef Found As Boolean, ByRef EnumValFound As Integer) As Boolean
        Try
            For Each val As Integer In [Enum].GetValues(EnumTypeToSearch)
                Dim strEnum As String = [Enum].GetName(EnumTypeToSearch, val)
                If strEnum.Trim().ToLower().Equals(EnumAsText.Trim().ToLower()) Then
                    Found = True
                    EnumValFound = val
                    Return True
                End If
            Next
            Return Nothing

        Catch ex As Exception
            Throw New Exception("getRes.SearchEnumFromText: " + ex.ToString())
        End Try
    End Function


End Class

