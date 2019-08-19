Imports System.Windows.Forms



Public Class HandleMessage

    Public Shared lMessages As New System.Collections.Generic.List(Of Messages)
    Public Class Messages
        Public frmNachricht As frmNachricht3 = Nothing
        Public ID As System.Guid = Nothing

        Public MessageIsInitialized As Boolean = False

        Public delonSearchObject As searchObject
        Public Delegate Function searchObject(ByRef tClipboard As dsClipboard.clipboardDataTable) As Boolean

        Public delegatesInitialized As Boolean = False
        Public delOnMessage As dMessage
        Public Delegate Function dMessage() As frmNachricht3
    End Class






    Public Function getNextWindow() As Messages
        Try
            Dim bClosedFound As Boolean = False
            For Each Window As Messages In HandleMessage.lMessages
                If Not Window.frmNachricht.isOpend Then
                    Return Window
                End If
            Next

            Return Me.addNewWindowToList()

        Catch ex As Exception
            Throw New Exception("getNextWindow: " + ex.ToString())
        End Try
    End Function
    Public Function addNewWindowToList() As Messages
        Try
            Dim NewWindow As New Messages()
            NewWindow.frmNachricht = New frmNachricht3()
            NewWindow.frmNachricht.InSharedMemory = True
            NewWindow.ID = System.Guid.NewGuid()
            NewWindow.MessageIsInitialized = True
            NewWindow.frmNachricht.Messages = NewWindow

            Dim dMessage As New Messages.dMessage(AddressOf HandleMessage.getMessage)
            NewWindow.delOnMessage = dMessage
            NewWindow.delegatesInitialized = True

            HandleMessage.lMessages.Add(NewWindow)
            Return NewWindow

        Catch ex As Exception
            Throw New Exception("addNewWindowToList: " + ex.ToString())
        End Try
    End Function
    Public Shared Function getMessage() As frmNachricht3
        Try
            Dim HandleMessage1 As New HandleMessage()
            Dim NextWindow As Messages = HandleMessage1.getNextWindow()
            'message.loadForm()
            'message.clear()
            Return NextWindow.frmNachricht

        Catch ex As Exception
            Throw New Exception("HandleMessage.openMessage: " + ex.ToString())
        End Try
    End Function

End Class
