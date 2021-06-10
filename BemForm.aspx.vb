Imports System.Data.SqlClient

Partial Class BemForm
  Inherits System.Web.UI.Page
  Protected WithEvents SqlConn As System.Data.SqlClient.SqlConnection
  Protected WithEvents SqlComm As System.Data.SqlClient.SqlCommand
  Protected Uge As Integer
  Protected BladID As Integer
  Protected BladNavn As String

  Dim dr As SqlDataReader
#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.SqlConn = New System.Data.SqlClient.SqlConnection()
    Me.SqlComm = New System.Data.SqlClient.SqlCommand()
    '
    'SqlConn
    '
    Me.SqlConn.ConnectionString = "data source=DLU02;initial catalog=dimpSQL;password=lp4DLU;persist security info=True;user id=LocalPlanner;workstation id=DDDIMP;packet size=4096"
    '
    'SqlComm
    '
    Me.SqlComm.Connection = Me.SqlConn

  End Sub

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: This method call is required by the Web Form Designer
    'Do not modify it using the code editor.
    InitializeComponent()
  End Sub

#End Region

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If Not IsPostBack Then
      Dim CheckSum As Integer
      Dim counter As Integer
      BladID = CInt(Request.QueryString("BladID"))
      Uge = CInt(Request.QueryString("Uge"))
      SqlComm.CommandText = "SELECT Navn FROM tblBlade WHERE (BladId = " & BladID & ")"
      SqlConn.Open()
      dr = SqlComm.ExecuteReader
      dr.Read()
      BladNavn = dr("Navn").ToString
      dr.Close()
      For counter = 1 To Len(BladNavn)
        CheckSum = (CheckSum + (Uge + Asc(Mid(BladNavn, counter, 1)))) Mod 255
      Next
      If CheckSum <> Request.QueryString("Chk") Then
        Server.Transfer("CheckSumError.htm")
      End If
      SqlComm.CommandText = "SELECT Bemærkning FROM tblUgeBemærkninger WHERE (BladId = " & BladID & ") AND (Uge = " & Uge & ")"
      dr = SqlComm.ExecuteReader
      If dr.Read Then txtBem.Text = dr.GetString(0)
      dr.Close()
      SqlConn.Close()

      ViewState("BladNavn") = BladNavn
      ViewState("Uge") = Uge
      ViewState("BladID") = BladID
      Me.DataBind()
    Else
      BladNavn = CStr(ViewState("BladNavn"))
      Uge = CInt(ViewState("Uge"))
      BladID = CInt(ViewState("BladID"))
    End If
  End Sub

  Private Sub txtBem_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBem.TextChanged
    SqlComm.CommandText = "DELETE FROM tblUgeBemærkninger WHERE (BladID=" & BladID & ") AND (Uge=" & Uge & ")"
    SqlConn.Open()
    SqlComm.ExecuteNonQuery()
    SqlComm.CommandText = "INSERT INTO tblUgeBemærkninger (BladID, Uge, Bemærkning) VALUES (" & BladID & "," & Uge & ",'" & Replace(txtBem.Text, "'", "''") & "')"
    SqlComm.ExecuteNonQuery()
    SqlConn.Close()
  End Sub

  Private Sub btnOpdater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpdater.Click
    Response.Redirect("OrdreCheckForm.aspx?BladID=" & BladID & "&Uge=" & Uge & "&Chk=" & Request.QueryString("Chk"))
  End Sub
End Class
