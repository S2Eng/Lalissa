Imports System.Windows.Forms



Public Class IExplorer

    Public gen As New General

    Public WebSiteIsReady As Boolean = False

    Public _LastUsrID As String = ""
    Public _LastPwdID As String = ""






    Private Sub WebBrowser_Loaded(sender As Object, e As Windows.RoutedEventArgs)
        Try

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub

    Private Sub Grid_Loaded(sender As Object, e As Windows.RoutedEventArgs)
        Try
            'Me.IExplorer1.Navigate("http://www.ebay.com")

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub
    Public Sub ShowHtmlTxtxy(sHtml As String)
        Try
            Dim uri As New Uri(sHtml)
            Dim source As System.IO.Stream = System.Windows.Application.GetContentStream(uri).Stream()
            Me.IExplorer1.NavigateToStream(source)

        Catch ex As Exception
            Throw New Exception("IExplorer.ShowHtmlTxt: " + ex.ToString())
        End Try
    End Sub
    Public Sub NavigateToUrl(Url As String)
        Try
            Me.WebSiteIsReady = False
            Me.IExplorer1.Navigate(Url)

        Catch ex As Exception
            Throw New Exception("IExplorer.NavigateToUrl: " + ex.ToString())
        End Try
    End Sub
    Public Sub NavigateToStr(TxtHtml As String)
        Try

            Dim TxtHtmlCorrected As String = General.ReplaceMetaContentInHTML(TxtHtml)
            Me.IExplorer1.NavigateToString(TxtHtml)
            'Dim doc As mshtml.HTMLDocument = Me.IExplorer1.Document
            'doc.Encoding = "utf-8"
            'Me.IExplorer1.Refresh()

        Catch ex As Exception
            Throw New Exception("IExplorer.NavigateToStr: " + ex.ToString())
        End Try
    End Sub
    Public Sub ClearBrowser()
        Try
            'Me.IExplorer1.NavigateToString("")

        Catch ex As Exception
            Throw New Exception("IExplorer.ClearBrowser: " + ex.ToString())
        End Try
    End Sub

    Public Function getWebsiteAsTxt() As String
        Try
            Dim doc As mshtml.HTMLDocument = Me.IExplorer1.Document
            Dim sWebsiteHTML As String = doc.body.innerHTML
            Dim sWebsiteHTML2 As String = doc.body.innerText
            Dim sWebsiteHTML3 As String = doc.body.outerText

            'Dim oPageText As Object()
            'doc.write(oPageText)

            If Not sWebsiteHTML Is Nothing Then
                Return sWebsiteHTML.ToString()
            Else
                Return ""
            End If

        Catch ex As Exception
            Throw New Exception("IExplorer.getWebsiteAsTxt: " + ex.ToString())
        End Try
    End Function
    Private Sub IExplorer1_IsVisibleChanged(sender As Object, e As Windows.DependencyPropertyChangedEventArgs) Handles IExplorer1.IsVisibleChanged
        Try

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub
    Private Sub IExplorer1_LoadCompleted(sender As Object, e As Windows.Navigation.NavigationEventArgs) Handles IExplorer1.LoadCompleted
        Try
            Dim doc As mshtml.HTMLDocument = Me.IExplorer1.Document
            Dim ElementCollection As mshtml.IHTMLElementCollection = doc.getElementsByName("Login_SUBUSERID")
            Dim elemUserID As mshtml.IHTMLElement = ElementCollection(0)
            If Not elemUserID Is Nothing Then
                System.Threading.Thread.CurrentThread.Sleep(500)
                Me.WebSiteIsReady = True
            End If

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub
    Public Sub WebSiteLoaded()
        Try
            Do While Not Me.WebSiteIsReady
                Application.DoEvents()
            Loop

        Catch ex As Exception
            Throw New Exception("IExplorer.WebSiteLoaded: " + ex.ToString())
        End Try
    End Sub

    Public Sub doLogIn(UserID As String, Pwd As String, ReloadiOffice As Boolean)
        Try
            'If ReloadiOffice Then
            '    Me.NavigateToUrl(Settings.urlIOffice.Trim())
            'End If
            Me.WebSiteLoaded()

            Dim doc As mshtml.HTMLDocument = Me.IExplorer1.Document

            Dim ElementCollection1 As mshtml.IHTMLElementCollection = doc.getElementsByName("Login_USERID")
            Dim elemUserID As mshtml.IHTMLElement = ElementCollection1(0)
            If Not elemUserID Is Nothing Then
                If UserID.Trim() <> "" Then
                    elemUserID.innerText = UserID.Trim()
                End If
                If Me._LastUsrID.Trim() <> "" Then
                    elemUserID.innerText = Me._LastUsrID.Trim()
                End If
            End If

            Dim ElementCollection2 As mshtml.IHTMLElementCollection = doc.getElementsByName("Login_USERPW")
            Dim elemPwd As mshtml.IHTMLElement = ElementCollection2(0)
            If Not elemPwd Is Nothing Then
                If Pwd.Trim() <> "" Then
                    elemPwd.setAttribute("value", Pwd.Trim())
                End If
            End If

            'If UserID.Trim() <> "" Then
            '    Dim ElementCollection3 As mshtml.IHTMLElementCollection = doc.getElementsByName("BT_Anmelden")
            '    Dim elemBLogIn As mshtml.IHTMLElement = ElementCollection3(0)
            '    'elemBLogIn.click()
            '    doc.getElementsByName("BT_Anmelden").InvokeMember("click")
            'End If

            'Me.IExplorer1.Refresh()

            Me._LastUsrID = UserID.Trim()

        Catch ex As Exception
            Throw New Exception("IExplorer.doLogIn: " + ex.ToString())
        End Try
    End Sub

End Class
