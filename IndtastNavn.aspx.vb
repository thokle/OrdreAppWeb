Imports System.Data.SqlClient

Partial Class IndtastNavn
  Inherits System.Web.UI.Page

  Protected WithEvents sqlConn As System.Data.SqlClient.SqlConnection
  Protected WithEvents sqlComm As System.Data.SqlClient.SqlCommand

  Protected personNavn As String
  Protected bladID As Integer
  Protected bladNavn As String
  Protected dr As SqlDataReader
  Protected eMail As String
  Protected PersonID As Integer
  Protected queryChk As Integer
  Protected spurgtID As Integer
  Protected query(3) As String
#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.sqlConn = New System.Data.SqlClient.SqlConnection()
    Me.sqlComm = New System.Data.SqlClient.SqlCommand()
    '
    'sqlConn
    '
    Me.SqlConn.ConnectionString = "data source=DLU02;initial catalog=DiMPdotNet;password=lp4DLU;persist security info=True;user id=LocalPlanner;workstation id=DDDIMP;packet size=4096"
    '
    'sqlComm
    '
    Me.sqlComm.Connection = Me.sqlConn

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
      If Request.QueryString.Count > 1 Then
        BladID = CInt(Request.QueryString("BladID"))
        spurgtID = CInt(Request.QueryString("ID"))
        QueryChk = CInt(Request.QueryString("Chk"))
        PersonID = CStr(Request.QueryString("eMail"))
      Else
        query = Split(Request.QueryString("Query"), "*")
        bladID = CInt(query(0))
        QueryChk = CInt(query(1))
        spurgtID = CInt(query(2))
        PersonID = CStr(query(3))
      End If
      If PersonID = 0 Then
        Server.Transfer("NoeMail.htm")
      End If
      sqlComm.CommandText = "SELECT Navn FROM tblBladStamdata WHERE (BladID = " & bladID & ")"
      sqlConn.Open()
      dr = sqlComm.ExecuteReader

      dr.Read()
      bladNavn = dr("Navn").ToString
      dr.Close()
      For counter = 1 To Len(bladNavn)
        CheckSum = (CheckSum + (Asc(Mid(bladNavn, counter, 1)))) Mod 255
      Next
      If CheckSum <> queryChk Then
        Server.Transfer("CheckSumError.htm")
      End If
      sqlComm.CommandText = "SELECT PersonNavn, eMail FROM tblWEBeMails WHERE (PersonID=" & PersonID & ")"
      dr = sqlComm.ExecuteReader
      If dr.Read Then
        personNavn = dr.GetString(0)
        eMail = dr.GetString(1)
      End If


      sqlConn.Close()
      ViewState("BladNavn") = bladNavn
      ViewState("BladID") = bladID
      viewstate("PersonID") = PersonID
      ViewState("eMail") = eMail
      Me.DataBind()
    Else
      'BladNavn = CStr(ViewState("BladNavn"))
      PersonID = CInt(Viewstate("PersonID"))
      bladID = CInt(ViewState("BladID"))
      eMail = CStr(ViewState("eMail"))
    End If

  End Sub

  Private Sub btnOpdater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpdater.Click
    If Page.IsValid Then
      sqlComm.CommandText = "UPDATE tblWEBeMails SET PersonNavn = '" & txtPersonNavn.Text & "' WHERE PersonID = " & personID
      SqlConn.Open()
      SqlComm.ExecuteNonQuery()
      SqlConn.Close()
      Server.Transfer("PF.aspx" & Request.Url.Query)
    End If
  End Sub
End Class
