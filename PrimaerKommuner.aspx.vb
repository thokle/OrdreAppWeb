Imports System.Data.SqlClient

Partial Class PrimKommune
  Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.SqlConn = New System.Data.SqlClient.SqlConnection()
    Me.SqlComm = New System.Data.SqlClient.SqlCommand()
    Me.da = New System.Data.SqlClient.SqlDataAdapter()
    Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.Dst = New OrdreApp.dst()
    CType(Me.Dst, System.ComponentModel.ISupportInitialize).BeginInit()
    '
    'SqlConn
    '
        Me.SqlConn.ConnectionString = "data source=AGETOR;initial catalog=dimpSQL;password=hydeliFyt12;persist s" & _
    "ecurity info=True;user id=sa;workstation id=DDDIMP;packet size=4096"
    '
    'SqlComm
    '
    Me.SqlComm.Connection = Me.SqlConn
    '
    'da
    '
    Me.da.InsertCommand = Me.SqlInsertCommand1
    Me.da.SelectCommand = Me.SqlSelectCommand1
    Me.da.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblPrimaerKommuner", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("BladId", "BladId"), New System.Data.Common.DataColumnMapping("Kommune", "Kommune")})})
    '
    'SqlInsertCommand1
    '
    Me.SqlInsertCommand1.CommandText = "INSERT INTO tblPrimaerKommuner(BladId, Kommune) VALUES (@BladId, @Kommune); SELEC" & _
    "T BladId, Kommune FROM tblPrimaerKommuner"
    Me.SqlInsertCommand1.Connection = Me.SqlConn
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BladId", System.Data.SqlDbType.Int, 4, "BladId"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Kommune", System.Data.SqlDbType.NVarChar, 60, "Kommune"))
    '
    'SqlSelectCommand1
    '
    Me.SqlSelectCommand1.CommandText = "SELECT BladId, Kommune FROM tblPrimaerKommuner WHERE (BladId = @BladID)"
    Me.SqlSelectCommand1.Connection = Me.SqlConn
    Me.SqlSelectCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BladID", System.Data.SqlDbType.Int, 4, "BladId"))
    '
    'Dst
    '
    Me.Dst.DataSetName = "dst"
    Me.Dst.Locale = New System.Globalization.CultureInfo("da-DK")
    Me.Dst.Namespace = "http://www.tempuri.org/dst.xsd"
    CType(Me.Dst, System.ComponentModel.ISupportInitialize).EndInit()

  End Sub

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: This method call is required by the Web Form Designer
    'Do not modify it using the code editor.
    InitializeComponent()
  End Sub

#End Region
  Protected BladNavn As String
  Protected WithEvents SqlConn As System.Data.SqlClient.SqlConnection
  Protected WithEvents SqlComm As System.Data.SqlClient.SqlCommand
  Protected BladID As Integer
  Dim dr As SqlDataReader

  Protected WithEvents da As System.Data.SqlClient.SqlDataAdapter

  Protected WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
  Protected WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
  Protected WithEvents Dst As OrdreApp.dst

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If Not IsPostBack Then
      Dim counter As Integer
      Dim checkSum As Integer
      BladID = CInt(Request.QueryString("BladID"))
      SqlComm.CommandText = "SELECT Navn FROM tblBlade WHERE (BladId = " & BladID & ")"
      SqlConn.Open()
      dr = SqlComm.ExecuteReader
      dr.Read()
      BladNavn = dr("Navn").ToString
      dr.Close()
      SqlConn.Close()
      For counter = 1 To Len(BladNavn)
        checkSum = (checkSum + (Asc(Mid(BladNavn, counter, 1)))) Mod 255
      Next
      'If checkSum <> Request.QueryString("Chk") Then
      '    Server.Transfer("CheckSumError.htm")
      'End If
      ViewState("BladNavn") = BladNavn
      ViewState("BladID") = BladID
      ShowOrdrer()
    Else
      BladNavn = CStr(ViewState("BladNavn"))
      BladID = CInt(ViewState("BladID"))
    End If
  End Sub

  Private Sub ShowOrdrer()
    da.SelectCommand.Parameters("@BladID").Value = BladID
    da.Fill(Dst)
    Me.DataBind()
  End Sub

  Private Sub grdPrim_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPrim.DeleteCommand
    Try
      SqlComm.CommandText = "DELETE FROM tblPrimaerKommuner WHERE (BladID=" & BladID & ") AND (Kommune='" & CStr(e.Item.Cells(0).Text) & "')"
      SqlConn.Open()
      SqlComm.ExecuteNonQuery()
      ShowOrdrer()
    Catch ex As Exception
      SqlConn.Close()
      Server.Transfer("FejlOpdater.htm")
    Finally
      SqlConn.Close()
    End Try
  End Sub

  Private Sub btnAddPostNr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPostNr.Click
    Try
      SqlComm.CommandText = "INSERT INTO tblPrimaerKommuner (BladID, Kommune) VALUES (" & BladID & ",'" & CStr(txtPrimKom.Text) & "')"
      SqlConn.Open()
      SqlComm.ExecuteNonQuery()
      ShowOrdrer()
    Catch ex As Exception
      SqlConn.Close()
      Server.Transfer("FejlOpdater.htm")
    Finally
      SqlConn.Close()
    End Try
  End Sub

End Class
