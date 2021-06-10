Imports System.Data.SqlClient
Imports System.Convert

Partial Class MmPriser2
  Inherits System.Web.UI.Page
  Protected WithEvents SqlConn As System.Data.SqlClient.SqlConnection
  Protected WithEvents SqlComm As System.Data.SqlClient.SqlCommand
  Protected BladID As Integer
  Protected BladNavn As String

  Dim mmType As Int16
  Dim pris As String
  Dim dr As SqlDataReader
  Dim query(2) As String

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
      query = Split(Request.QueryString("Query"), "*")
      BladID = CInt(query(0))
      SqlComm.CommandText = "SELECT Navn FROM tblBlade WHERE (BladId = " & BladID & ")"
      SqlConn.Open()
      dr = SqlComm.ExecuteReader
      dr.Read()
      BladNavn = dr("Navn").ToString
      dr.Close()
      For counter = 1 To Len(BladNavn)
        CheckSum = (CheckSum + (Asc(Mid(BladNavn, counter, 1)))) Mod 255
      Next
      If CheckSum <> CInt(query(1)) Then
        Server.Transfer("CheckSumError.htm")
      End If
      If CInt(query(2)) > 0 Then
        SqlComm.CommandText = "UPDATE tblFarvetillægMinMaxWebApp SET Godkendt=1  WHERE (BladID=" & BladID & ")"
        SqlComm.ExecuteNonQuery()
        SqlConn.Close()
        Response.Redirect("Afslut.htm")
      End If
      SqlComm.CommandText = "SELECT mmType, Pris FROM tblMmPrisWebApp WHERE (BladId = " & BladID & ")"
      dr = SqlComm.ExecuteReader
      While dr.Read
        mmType = dr.GetByte(0)
        pris = Format(dr.GetDecimal(1), "###0.00")
        Select Case mmType
          Case 9
            txtTekstside.Text = pris
          Case 10
            txtStillinger.Text = pris
        End Select
      End While
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

  Private Sub btnGodkend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGodkend.Click
    Try
      SqlConn.Open()
      SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtTekstside.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND mmType=9)"
      SqlComm.ExecuteNonQuery()
      SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtStillinger.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND mmType=10)"
      SqlComm.ExecuteNonQuery()
      SqlComm.CommandText = "UPDATE tblFarvetillægMinMaxWebApp SET Godkendt=1  WHERE (BladID=" & BladID & ")"
      SqlComm.ExecuteNonQuery()
    Catch ex As Exception
      Response.Redirect("FejlKonverter.htm")
    Finally
      SqlConn.Close()
    End Try
    Response.Redirect("Afslut.htm")
  End Sub
End Class
