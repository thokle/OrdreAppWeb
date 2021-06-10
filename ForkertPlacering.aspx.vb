Imports System.Data.SqlClient

Partial Class ForkertPlacering2
  Inherits System.Web.UI.Page

  Protected WithEvents sqlConn As System.Data.SqlClient.SqlConnection
  Protected WithEvents sqlComm As System.Data.SqlClient.SqlCommand
  Protected ordreID As Integer
  Protected bladID As Integer
  Protected uge As Integer
  Protected bladNavn As String
  Protected eMail As String
  Protected dr As SqlDataReader
  Protected queryChk As Integer
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
      Dim counter As Integer
      Dim CheckSum As Integer

      query = Split(Request.QueryString("Query"), "*")
      bladID = CInt(query(0))
      uge = CInt(query(1))
      eMail = CStr(query(2))
      queryChk = CInt(query(3))
      ordreID = CInt(query(4))

      sqlComm.CommandText = "SELECT Navn FROM tblBladStamdata WHERE (BladID = " & bladID & ")"
      sqlConn.Open()
      dr = sqlComm.ExecuteReader

      dr.Read()
      bladNavn = dr("Navn").ToString
      dr.Close()
      For counter = 1 To Len(bladNavn)
        CheckSum = (CheckSum + (uge + Asc(Mid(bladNavn, counter, 1)))) Mod 255
      Next
      If CheckSum <> queryChk AndAlso queryChk <> 999 Then
        Server.Transfer("CheckSumError.htm")
      End If
      sqlConn.Close()
      ViewState("BladNavn") = bladNavn
      ViewState("BladID") = bladID
      viewstate("Uge") = uge
      viewstate("Email") = eMail
      viewstate("queryChk") = queryChk
      viewstate("OrdreID") = ordreID
      Me.DataBind()
    Else
      bladNavn = CStr(ViewState("BladNavn"))
      ordreID = CInt(Viewstate("OrdreID"))
      bladID = CInt(ViewState("BladID"))
      uge = CInt(ViewState("Uge"))
      eMail = CStr(viewstate("Email"))
      queryChk = CInt(viewstate("queryChk"))
    End If

  End Sub

  Private Sub btnOpdater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpdater.Click
    Try
      sqlComm.CommandText = "UPDATE tblAnnoncekontrol SET IndrykketPåSide = '" & txtSide.Text & _
      "', FaktureresTil = '" & txtPris.Text & "'  WHERE (MedieplanNr = " & ordreID & ") AND (UgeavisID = " & bladID & ")"
      sqlConn.Open()
      sqlComm.ExecuteNonQuery()
    Catch ex As Exception
      Response.Redirect("FejlKonverter.htm")
    End Try

    Response.Redirect("Annoncekontrol.aspx?Query=" & bladID & "*" & uge & "*" & eMail & "*" & queryChk)

  End Sub
End Class
