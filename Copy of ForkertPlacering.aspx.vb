Imports System.Data.SqlClient

Public Class ForkertPlacering
  Inherits System.Web.UI.Page

  Protected WithEvents sqlConn As System.Data.SqlClient.SqlConnection
  Protected WithEvents sqlComm As System.Data.SqlClient.SqlCommand
  Protected WithEvents btnOpdater As System.Web.UI.WebControls.Button
  Protected ordreID As Integer
  Protected bladID As Integer
  Protected uge As Integer
  Protected bladNavn As String
  Protected dr As SqlDataReader
  Protected queryChk As Integer
  Protected WithEvents txtSide As System.Web.UI.WebControls.TextBox
  Protected WithEvents Label1 As System.Web.UI.WebControls.Label
  Protected WithEvents Label2 As System.Web.UI.WebControls.Label
  Protected WithEvents txtPris As System.Web.UI.WebControls.TextBox
  Protected WithEvents txtPersonNavn As System.Web.UI.WebControls.TextBox
  Protected WithEvents validerTxtPersonNavnUdfýldt As System.Web.UI.WebControls.RequiredFieldValidator
  Protected query(3) As String
#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.sqlConn = New System.Data.SqlClient.SqlConnection()
    Me.sqlComm = New System.Data.SqlClient.SqlCommand()
    '
    'sqlConn
    '
        Me.sqlConn.ConnectionString = "data source=AGETOR;initial catalog=dimpSQL;password=hydeliFyt12;persist s" & _
    "ecurity info=True;user id=sa;workstation id=DDDIMP;packet size=4096"
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
      Dim counter As Integer
      Dim CheckSum As Integer

      query = Split(Request.QueryString("Query"), "*")
      bladID = CInt(query(0))
      uge = CInt(query(1))
      queryChk = CInt(query(2))
      ordreID = CInt(query(3))

      sqlComm.CommandText = "SELECT Navn FROM tblBlade WHERE (BladId = " & bladID & ")"
      sqlConn.Open()
      dr = sqlComm.ExecuteReader

      dr.Read()
      bladNavn = dr("Navn").ToString
      dr.Close()
      For counter = 1 To Len(bladNavn)
        CheckSum = (CheckSum + (Asc(Mid(bladNavn, counter, 1)))) Mod 255
      Next
      If CheckSum <> queryChk AndAlso queryChk <> 999 Then
        Server.Transfer("CheckSumError.htm")
      End If
      sqlConn.Close()
      ViewState("BladNavn") = bladNavn
      ViewState("BladID") = bladID
      viewstate("Uge") = uge
      viewstate("queryChk") = queryChk
      viewstate("OrdreID") = ordreID
      Me.DataBind()
    Else
      bladNavn = CStr(ViewState("BladNavn"))
      ordreID = CInt(Viewstate("OrdreID"))
      bladID = CInt(ViewState("BladID"))
      uge = CInt(ViewState("Uge"))
      queryChk = CInt(viewstate("queryChk"))
    End If

  End Sub

  Private Sub btnOpdater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpdater.Click
    If Page.IsValid Then
      Response.Redirect("Annoncekontrol.aspx?Query=" & bladID & "*" & uge & "*" & queryChk)
      '   Server.Transfer("PF.aspx" & Request.Url.Query)
    End If
  End Sub
End Class
