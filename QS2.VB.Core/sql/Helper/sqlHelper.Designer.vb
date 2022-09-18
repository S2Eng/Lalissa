Partial Class sqlHelper
    Inherits System.ComponentModel.Component

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Erforderlich für die Unterstützung des Windows.Forms-Klassenkompositions-Designers
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'Dieser Aufruf ist für den Komponenten-Designer erforderlich.
        InitializeComponent()

    End Sub

    'Die Komponente überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Komponenten-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Komponenten-Designer erforderlich.
    'Das Bearbeiten ist mit dem Komponenten-Designer möglich.
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sqlHelper))
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlConn = New System.Data.SqlClient.SqlConnection()
        Me.daSelListObjDoubledSelLists = New System.Data.SqlClient.SqlDataAdapter()
        Me.daSelListObjDoubledFldShorts = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand1 = New System.Data.SqlClient.SqlCommand()
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = resources.GetString("SqlSelectCommand1.CommandText")
        Me.SqlSelectCommand1.Connection = Me.SqlConn
        '
        'SqlConn
        '
        Me.SqlConn.ConnectionString = "Data Source=stysrv02v\sql2008r2;Initial Catalog=QS2_DEV;Integrated Security=True"
        Me.SqlConn.FireInfoMessageEventOnUserErrors = False
        '
        'daSelListObjDoubledSelLists
        '
        Me.daSelListObjDoubledSelLists.SelectCommand = Me.SqlSelectCommand1
        Me.daSelListObjDoubledSelLists.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblSelListEntriesObj", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDSelListEntry", "IDSelListEntry"), New System.Data.Common.DataColumnMapping("IDSelListEntrySublist", "IDSelListEntrySublist"), New System.Data.Common.DataColumnMapping("typIDGroup", "typIDGroup"), New System.Data.Common.DataColumnMapping("IDObject", "IDObject"), New System.Data.Common.DataColumnMapping("IDStay", "IDStay"), New System.Data.Common.DataColumnMapping("FldShort", "FldShort"), New System.Data.Common.DataColumnMapping("IDParticipant", "IDParticipant")})})
        '
        'daSelListObjDoubledFldShorts
        '
        Me.daSelListObjDoubledFldShorts.SelectCommand = Me.SqlCommand1
        Me.daSelListObjDoubledFldShorts.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblSelListEntriesObj", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDSelListEntry", "IDSelListEntry"), New System.Data.Common.DataColumnMapping("FldShort", "FldShort"), New System.Data.Common.DataColumnMapping("IDApplication", "IDApplication"), New System.Data.Common.DataColumnMapping("typIDGroup", "typIDGroup"), New System.Data.Common.DataColumnMapping("IDObject", "IDObject"), New System.Data.Common.DataColumnMapping("IDStay", "IDStay"), New System.Data.Common.DataColumnMapping("IDSelListEntrySublist", "IDSelListEntrySublist"), New System.Data.Common.DataColumnMapping("IDParticipant", "IDParticipant")})})
        '
        'SqlCommand1
        '
        Me.SqlCommand1.CommandText = resources.GetString("SqlCommand1.CommandText")
        Me.SqlCommand1.Connection = Me.SqlConn

    End Sub

    Friend WithEvents SqlSelectCommand1 As SqlClient.SqlCommand
    Friend WithEvents daSelListObjDoubledSelLists As SqlClient.SqlDataAdapter
    Friend WithEvents SqlConn As SqlClient.SqlConnection
    Friend WithEvents daSelListObjDoubledFldShorts As SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand1 As SqlClient.SqlCommand
End Class
