Partial Class compSql
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(compSql))
        Me.daLayoutGrid = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand2 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand3 = New System.Data.SqlClient.SqlCommand()
        Me.SqlCommand4 = New System.Data.SqlClient.SqlCommand()
        Me.daLayout = New System.Data.SqlClient.SqlDataAdapter()
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand()
        '
        'daLayoutGrid
        '
        Me.daLayoutGrid.DeleteCommand = Me.SqlCommand1
        Me.daLayoutGrid.InsertCommand = Me.SqlCommand2
        Me.daLayoutGrid.SelectCommand = Me.SqlCommand3
        Me.daLayoutGrid.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "LayoutGrids", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDGuid", "IDGuid"), New System.Data.Common.DataColumnMapping("GridName", "GridName"), New System.Data.Common.DataColumnMapping("Band", "Band"), New System.Data.Common.DataColumnMapping("ColumnName", "ColumnName"), New System.Data.Common.DataColumnMapping("ColumnWith", "ColumnWith"), New System.Data.Common.DataColumnMapping("Visible", "Visible"), New System.Data.Common.DataColumnMapping("OrderBy", "OrderBy"), New System.Data.Common.DataColumnMapping("Desc", "Desc"), New System.Data.Common.DataColumnMapping("GroupBy", "GroupBy"), New System.Data.Common.DataColumnMapping("Sort", "Sort"), New System.Data.Common.DataColumnMapping("IDLayout", "IDLayout"), New System.Data.Common.DataColumnMapping("GridAutoNewline", "GridAutoNewline"), New System.Data.Common.DataColumnMapping("TypeCol", "TypeCol"), New System.Data.Common.DataColumnMapping("AutoSizeHeigthColumn", "AutoSizeHeigthColumn"), New System.Data.Common.DataColumnMapping("ColMinHeigth", "ColMinHeigth"), New System.Data.Common.DataColumnMapping("ColMaxHeigth", "ColMaxHeigth"), New System.Data.Common.DataColumnMapping("ColumnCaption", "ColumnCaption"), New System.Data.Common.DataColumnMapping("TypeUI", "TypeUI")})})
        Me.daLayoutGrid.UpdateCommand = Me.SqlCommand4
        '
        'SqlCommand1
        '
        Me.SqlCommand1.CommandText = "DELETE FROM [qs2].[LayoutGrids] WHERE (([IDGuid] = @Original_IDGuid))"
        Me.SqlCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlCommand2
        '
        Me.SqlCommand2.CommandText = resources.GetString("SqlCommand2.CommandText")
        Me.SqlCommand2.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@GridName", System.Data.SqlDbType.VarChar, 0, "GridName"), New System.Data.SqlClient.SqlParameter("@Band", System.Data.SqlDbType.Int, 0, "Band"), New System.Data.SqlClient.SqlParameter("@ColumnName", System.Data.SqlDbType.VarChar, 0, "ColumnName"), New System.Data.SqlClient.SqlParameter("@ColumnWith", System.Data.SqlDbType.Int, 0, "ColumnWith"), New System.Data.SqlClient.SqlParameter("@Visible", System.Data.SqlDbType.Bit, 0, "Visible"), New System.Data.SqlClient.SqlParameter("@OrderBy", System.Data.SqlDbType.Bit, 0, "OrderBy"), New System.Data.SqlClient.SqlParameter("@Desc", System.Data.SqlDbType.Bit, 0, "Desc"), New System.Data.SqlClient.SqlParameter("@GroupBy", System.Data.SqlDbType.Bit, 0, "GroupBy"), New System.Data.SqlClient.SqlParameter("@Sort", System.Data.SqlDbType.Int, 0, "Sort"), New System.Data.SqlClient.SqlParameter("@IDLayout", System.Data.SqlDbType.UniqueIdentifier, 0, "IDLayout"), New System.Data.SqlClient.SqlParameter("@GridAutoNewline", System.Data.SqlDbType.Bit, 0, "GridAutoNewline"), New System.Data.SqlClient.SqlParameter("@TypeCol", System.Data.SqlDbType.NVarChar, 0, "TypeCol"), New System.Data.SqlClient.SqlParameter("@AutoSizeHeigthColumn", System.Data.SqlDbType.Bit, 0, "AutoSizeHeigthColumn"), New System.Data.SqlClient.SqlParameter("@ColMinHeigth", System.Data.SqlDbType.Int, 0, "ColMinHeigth"), New System.Data.SqlClient.SqlParameter("@ColMaxHeigth", System.Data.SqlDbType.Int, 0, "ColMaxHeigth"), New System.Data.SqlClient.SqlParameter("@ColumnCaption", System.Data.SqlDbType.NVarChar, 0, "ColumnCaption"), New System.Data.SqlClient.SqlParameter("@TypeUI", System.Data.SqlDbType.Int, 0, "TypeUI")})
        '
        'SqlCommand3
        '
        Me.SqlCommand3.CommandText = resources.GetString("SqlCommand3.CommandText")
        '
        'SqlCommand4
        '
        Me.SqlCommand4.CommandText = resources.GetString("SqlCommand4.CommandText")
        Me.SqlCommand4.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@GridName", System.Data.SqlDbType.VarChar, 0, "GridName"), New System.Data.SqlClient.SqlParameter("@Band", System.Data.SqlDbType.Int, 0, "Band"), New System.Data.SqlClient.SqlParameter("@ColumnName", System.Data.SqlDbType.VarChar, 0, "ColumnName"), New System.Data.SqlClient.SqlParameter("@ColumnWith", System.Data.SqlDbType.Int, 0, "ColumnWith"), New System.Data.SqlClient.SqlParameter("@Visible", System.Data.SqlDbType.Bit, 0, "Visible"), New System.Data.SqlClient.SqlParameter("@OrderBy", System.Data.SqlDbType.Bit, 0, "OrderBy"), New System.Data.SqlClient.SqlParameter("@Desc", System.Data.SqlDbType.Bit, 0, "Desc"), New System.Data.SqlClient.SqlParameter("@GroupBy", System.Data.SqlDbType.Bit, 0, "GroupBy"), New System.Data.SqlClient.SqlParameter("@Sort", System.Data.SqlDbType.Int, 0, "Sort"), New System.Data.SqlClient.SqlParameter("@IDLayout", System.Data.SqlDbType.UniqueIdentifier, 0, "IDLayout"), New System.Data.SqlClient.SqlParameter("@GridAutoNewline", System.Data.SqlDbType.Bit, 0, "GridAutoNewline"), New System.Data.SqlClient.SqlParameter("@TypeCol", System.Data.SqlDbType.NVarChar, 0, "TypeCol"), New System.Data.SqlClient.SqlParameter("@AutoSizeHeigthColumn", System.Data.SqlDbType.Bit, 0, "AutoSizeHeigthColumn"), New System.Data.SqlClient.SqlParameter("@ColMinHeigth", System.Data.SqlDbType.Int, 0, "ColMinHeigth"), New System.Data.SqlClient.SqlParameter("@ColMaxHeigth", System.Data.SqlDbType.Int, 0, "ColMaxHeigth"), New System.Data.SqlClient.SqlParameter("@ColumnCaption", System.Data.SqlDbType.NVarChar, 0, "ColumnCaption"), New System.Data.SqlClient.SqlParameter("@TypeUI", System.Data.SqlDbType.Int, 0, "TypeUI"), New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daLayout
        '
        Me.daLayout.DeleteCommand = Me.SqlDeleteCommand1
        Me.daLayout.InsertCommand = Me.SqlInsertCommand1
        Me.daLayout.SelectCommand = Me.SqlSelectCommand1
        Me.daLayout.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Layout", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDGuid", "IDGuid"), New System.Data.Common.DataColumnMapping("LayoutName", "LayoutName"), New System.Data.Common.DataColumnMapping("AllUsers", "AllUsers"), New System.Data.Common.DataColumnMapping("CreateFrom", "CreateFrom"), New System.Data.Common.DataColumnMapping("CreateAt", "CreateAt"), New System.Data.Common.DataColumnMapping("Key", "Key"), New System.Data.Common.DataColumnMapping("GridRowMinHeigth", "GridRowMinHeigth"), New System.Data.Common.DataColumnMapping("GridRowMaxHeigth", "GridRowMaxHeigth"), New System.Data.Common.DataColumnMapping("AutoFitStyleGrid", "AutoFitStyleGrid"), New System.Data.Common.DataColumnMapping("GridAutoNewline", "GridAutoNewline"), New System.Data.Common.DataColumnMapping("ShowAlwaysGroupBy", "ShowAlwaysGroupBy"), New System.Data.Common.DataColumnMapping("CaptionVisible", "CaptionVisible"), New System.Data.Common.DataColumnMapping("AutoSizeWidthColumns", "AutoSizeWidthColumns")})})
        Me.daLayout.UpdateCommand = Me.SqlUpdateCommand1
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = "DELETE FROM [qs2].[Layout] WHERE (([IDGuid] = @Original_IDGuid))"
        Me.SqlDeleteCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = resources.GetString("SqlInsertCommand1.CommandText")
        Me.SqlInsertCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@LayoutName", System.Data.SqlDbType.VarChar, 0, "LayoutName"), New System.Data.SqlClient.SqlParameter("@AllUsers", System.Data.SqlDbType.Bit, 0, "AllUsers"), New System.Data.SqlClient.SqlParameter("@CreateFrom", System.Data.SqlDbType.VarChar, 0, "CreateFrom"), New System.Data.SqlClient.SqlParameter("@CreateAt", System.Data.SqlDbType.DateTime, 0, "CreateAt"), New System.Data.SqlClient.SqlParameter("@Key", System.Data.SqlDbType.NVarChar, 0, "Key"), New System.Data.SqlClient.SqlParameter("@GridRowMinHeigth", System.Data.SqlDbType.Int, 0, "GridRowMinHeigth"), New System.Data.SqlClient.SqlParameter("@GridRowMaxHeigth", System.Data.SqlDbType.Int, 0, "GridRowMaxHeigth"), New System.Data.SqlClient.SqlParameter("@AutoFitStyleGrid", System.Data.SqlDbType.NVarChar, 0, "AutoFitStyleGrid"), New System.Data.SqlClient.SqlParameter("@GridAutoNewline", System.Data.SqlDbType.Bit, 0, "GridAutoNewline"), New System.Data.SqlClient.SqlParameter("@ShowAlwaysGroupBy", System.Data.SqlDbType.Bit, 0, "ShowAlwaysGroupBy"), New System.Data.SqlClient.SqlParameter("@CaptionVisible", System.Data.SqlDbType.Bit, 0, "CaptionVisible"), New System.Data.SqlClient.SqlParameter("@AutoSizeWidthColumns", System.Data.SqlDbType.Bit, 0, "AutoSizeWidthColumns")})
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = resources.GetString("SqlSelectCommand1.CommandText")
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = resources.GetString("SqlUpdateCommand1.CommandText")
        Me.SqlUpdateCommand1.Parameters.AddRange(New System.Data.SqlClient.SqlParameter() {New System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"), New System.Data.SqlClient.SqlParameter("@LayoutName", System.Data.SqlDbType.VarChar, 0, "LayoutName"), New System.Data.SqlClient.SqlParameter("@AllUsers", System.Data.SqlDbType.Bit, 0, "AllUsers"), New System.Data.SqlClient.SqlParameter("@CreateFrom", System.Data.SqlDbType.VarChar, 0, "CreateFrom"), New System.Data.SqlClient.SqlParameter("@CreateAt", System.Data.SqlDbType.DateTime, 0, "CreateAt"), New System.Data.SqlClient.SqlParameter("@Key", System.Data.SqlDbType.NVarChar, 0, "Key"), New System.Data.SqlClient.SqlParameter("@GridRowMinHeigth", System.Data.SqlDbType.Int, 0, "GridRowMinHeigth"), New System.Data.SqlClient.SqlParameter("@GridRowMaxHeigth", System.Data.SqlDbType.Int, 0, "GridRowMaxHeigth"), New System.Data.SqlClient.SqlParameter("@AutoFitStyleGrid", System.Data.SqlDbType.NVarChar, 0, "AutoFitStyleGrid"), New System.Data.SqlClient.SqlParameter("@GridAutoNewline", System.Data.SqlDbType.Bit, 0, "GridAutoNewline"), New System.Data.SqlClient.SqlParameter("@ShowAlwaysGroupBy", System.Data.SqlDbType.Bit, 0, "ShowAlwaysGroupBy"), New System.Data.SqlClient.SqlParameter("@CaptionVisible", System.Data.SqlDbType.Bit, 0, "CaptionVisible"), New System.Data.SqlClient.SqlParameter("@AutoSizeWidthColumns", System.Data.SqlDbType.Bit, 0, "AutoSizeWidthColumns"), New System.Data.SqlClient.SqlParameter("@Original_IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDGuid", System.Data.DataRowVersion.Original, Nothing)})

    End Sub

    Public WithEvents daLayoutGrid As SqlClient.SqlDataAdapter
    Friend WithEvents SqlCommand1 As SqlClient.SqlCommand
    Friend WithEvents SqlCommand2 As SqlClient.SqlCommand
    Friend WithEvents SqlCommand3 As SqlClient.SqlCommand
    Friend WithEvents SqlCommand4 As SqlClient.SqlCommand
    Public WithEvents daLayout As SqlClient.SqlDataAdapter
    Friend WithEvents SqlDeleteCommand1 As SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand1 As SqlClient.SqlCommand
    Friend WithEvents SqlSelectCommand1 As SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As SqlClient.SqlCommand
End Class
