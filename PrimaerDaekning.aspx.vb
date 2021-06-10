Imports System.Data.SqlClient

Partial Class PrimærDækning
  Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.SqlConn = New System.Data.SqlClient.SqlConnection()
    Me.SqlComm = New System.Data.SqlClient.SqlCommand()
    Me.da = New System.Data.SqlClient.SqlDataAdapter()
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
    Me.da.SelectCommand = Me.SqlSelectCommand1
    Me.da.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblWEBPrimærDækning", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("BladId", "BladId"), New System.Data.Common.DataColumnMapping("postNrOgBy", "postNrOgBy"), New System.Data.Common.DataColumnMapping("Primær", "Primær"), New System.Data.Common.DataColumnMapping("PKey", "PKey")})})
    '
    'SqlSelectCommand1
    '
    Me.SqlSelectCommand1.CommandText = "SELECT BladId, postNrOgBy, Primær, PKey FROM tblWEBPrimærDækning WHERE (BladId = " & _
    "@BladID)"
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
  Protected WithEvents Dst As OrdreApp.dst
  Protected QueryChk As Integer
  Dim query(1) As String

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If Not IsPostBack Then
      Dim counter As Integer
      Dim checkSum As Integer

      query = Split(Request.QueryString("Query"), "*")
      BladID = CInt(query(0))
      QueryChk = CInt(query(1))

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
      '      if not querychk = 999 then
      '        If checkSum <> QueryChk Then
      '          Server.Transfer("CheckSumError.htm")
      '        End If
      '      end if
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
      SqlComm.CommandText = "DELETE FROM tblWEBPrimærDækning WHERE (BladID=" & BladID & ") AND (postNrOgBy='" & CStr(e.Item.Cells(0).Text) & "')"
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
