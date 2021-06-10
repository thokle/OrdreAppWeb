Imports System.Data.SqlClient

Partial Class Forsendelser
  Inherits System.Web.UI.Page
  Protected WithEvents SqlConn As System.Data.SqlClient.SqlConnection
  Protected WithEvents SqlComm As System.Data.SqlClient.SqlCommand
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
      'Dim CheckSum As Integer
      'Dim counter As Integer
      BladID = CInt(Request.QueryString("BladID"))
      SqlComm.CommandText = "SELECT Navn FROM tblBlade WHERE (BladId = " & BladID & ")"
      SqlConn.Open()
      dr = SqlComm.ExecuteReader
      dr.Read()
      BladNavn = dr("Navn").ToString
      dr.Close()
      'For counter = 1 To Len(BladNavn)
      '    CheckSum = (CheckSum + (Asc(Mid(BladNavn, counter, 1)))) Mod 255
      'Next
      'If CheckSum <> Request.QueryString("Chk") Then
      '    Server.Transfer("CheckSumError.htm")
      'End If
      SqlComm.CommandText = "SELECT ForsendelsesNavn, ForsendelsesEmail FROM tblBlade WHERE (BladId = " & BladID & ")"
      dr = SqlComm.ExecuteReader
      If dr.Read Then
        txtNavn.Text = dr.GetString(0)
        txtEmail.Text = dr.GetString(1)
      End If
      dr.Close()
      SqlConn.Close()
      ViewState("BladNavn") = BladNavn
      ViewState("BladID") = BladID
      Me.DataBind()
    Else
      BladNavn = CStr(ViewState("BladNavn"))
      BladID = CInt(ViewState("BladID"))
    End If
  End Sub

  Private Sub btnOpdater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpdater.Click
    SqlComm.CommandText = "UPDATE tblBlade SET ForsendelsesNavn='" & txtNavn.Text & "', ForsendelsesEmail='" & txtEmail.Text & "' WHERE (BladID=" & BladID & ")"
    SqlConn.Open()
    SqlComm.ExecuteNonQuery()
    SqlConn.Close()
    Response.Redirect("Afslut.htm")
  End Sub
End Class
