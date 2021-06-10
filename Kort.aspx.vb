Imports System.Data.SqlClient

Partial Class Kort
  Inherits System.Web.UI.Page
  Protected WithEvents SqlComm As System.Data.SqlClient.SqlCommand
  Dim dr As SqlDataReader
  Dim medieplanNr As Integer
  Dim version As Integer
  Protected WithEvents SqlConn As System.Data.SqlClient.SqlConnection
  Dim sqlTxt As String

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.SqlComm = New System.Data.SqlClient.SqlCommand()
    Me.SqlConn = New System.Data.SqlClient.SqlConnection()
    '
    'SqlConn
    '
        Me.SqlConn.ConnectionString = "data source=AGETOR;initial catalog=dimpSQL;password=hydeliFyt12;persist s" & _
    "ecurity info=True;user id=sa;workstation id=DDDIMP;packet size=4096"

  End Sub

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: This method call is required by the Web Form Designer
    'Do not modify it using the code editor.
    InitializeComponent()
  End Sub

#End Region

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If Not IsPostBack Then
      medieplanNr = CInt(Request.QueryString("MedieplanNr"))
      version = CInt(Request.QueryString("Version"))

      'sqlTxt = "SELECT dbo.tblMedieplanLinjer.UgeavisID, dbo.tblBladDækning.PostNr, dbo.tblPostNr.PostBy, "
      'sqlTxt = sqlTxt + "dbo.tblBladDækning.DækningsGrad FROM dbo.tblBladDækning INNER JOIN dbo.tblPostNr ON dbo.tblBladDækning.PostNr "
      'sqlTxt = sqlTxt + "= dbo.tblPostNr.PostNr INNER JOIN dbo.tblMedieplanLinjer ON dbo.tblBladDækning.UgeavisID = "
      'sqlTxt = sqlTxt + "dbo.tblMedieplanLinjer.UgeavisID "
      'sqlTxt = sqlTxt + "WHERE (dbo.tblMedieplanLinjer.MedieplanNr = " + medieplanNr.ToString + ") AND "
      'sqlTxt = sqlTxt + "(dbo.tblMedieplanLinjer.Version = " + version.ToString + ")"
      'SqlComm.CommandText = sqlTxt
      '     SqlConn2.Open()
      SqlConn.Open()
      dr = SqlComm.ExecuteReader
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
