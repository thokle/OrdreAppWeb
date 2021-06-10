Imports System.Data.SqlClient

Partial Class DaekKort
  Inherits System.Web.UI.Page

  Protected WithEvents sqlConn As System.Data.SqlClient.SqlConnection
  Protected WithEvents sqlComm As System.Data.SqlClient.SqlCommand
  Protected WithEvents sqlConn2 As System.Data.SqlClient.SqlConnection

  Protected MedieplanNr As String
  Protected Version As String
  Protected sqlTxt As String
  Protected dr As SqlDataReader
#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.sqlConn = New System.Data.SqlClient.SqlConnection()
    Me.sqlComm = New System.Data.SqlClient.SqlCommand()
    Me.sqlConn2 = New System.Data.SqlClient.SqlConnection()
    'sqlConn
    '
        Me.sqlConn.ConnectionString = "data source=AGETOR;initial catalog=DIMPdotNet;password=hydeliFyt12;persist s" & _
    "ecurity info=True;user id=sa;workstation id=DDDIMP;packet size=4096"
    Me.sqlConn2.ConnectionString = "data source=DDDIMP;initial catalog=DiMPdotNet;password=hydeliFyt12;persist security info=True;user id=sa;workstation id=DDDIMP;packet size=4096"
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
      MedieplanNr = CStr(Request.QueryString("MedieplanNr"))
      Version = CStr(Request.QueryString("Version"))

      sqlTxt = "SELECT dbo.tblMedieplanLinjer.UgeavisID, dbo.tblBladDækning.PostNr, dbo.tblPostNr.PostBy, "
      sqlTxt = sqlTxt + "dbo.tblBladDækning.DækningsGrad FROM dbo.tblBladDækning INNER JOIN dbo.tblPostNr ON dbo.tblBladDækning.PostNr "
      sqlTxt = sqlTxt + "= dbo.tblPostNr.PostNr INNER JOIN dbo.tblMedieplanLinjer ON dbo.tblBladDækning.UgeavisID = "
      sqlTxt = sqlTxt + "dbo.tblMedieplanLinjer.UgeavisID "
      sqlTxt = sqlTxt + "WHERE (dbo.tblMedieplanLinjer.MedieplanNr = " + MedieplanNr + ") AND "
      sqlTxt = sqlTxt + "(dbo.tblMedieplanLinjer.Version = " + Version + ")"
      sqlComm.CommandText = sqlTxt
      sqlConn.Open()
      dr = sqlComm.ExecuteReader
      While dr.Read()
        Response.Write(dr("UgeavisID").ToString)
        Response.Write(dr("PostNr").ToString)
        Response.Write(dr("PostBy").ToString)
        Response.Write(dr("Dækningsgrad").ToString)
      End While
      dr.Close()
      Response.End()
    End If
  End Sub
End Class
