Imports System.Data.SqlClient
Imports System.Convert

Partial Class MmPriser
  Inherits System.Web.UI.Page
  Protected WithEvents SqlConn As System.Data.SqlClient.SqlConnection
  Protected WithEvents SqlComm As System.Data.SqlClient.SqlCommand
  Protected BladID As Integer
  Protected BladNavn As String

  Dim Placering As Int16
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
    Me.SqlConn.ConnectionString = "data source=DLU02;initial catalog=DiMPdotNet;password=lp4DLU;persist security info=True;user id=LocalPlanner;workstation id=DDDIMP;packet size=4096"
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
      SqlComm.CommandText = "SELECT Navn FROM tblBladStamdata WHERE (BladID = " & BladID & ")"
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
      'If CInt(query(2)) > 0 Then
      '  SqlComm.CommandText = "UPDATE tblFarvetillægMinMaxWebApp SET Godkendt=1  WHERE (BladID=" & BladID & ")"
      '  SqlComm.ExecuteNonQuery()
      '  SqlConn.Close()
      '  Response.Redirect("Afslut.htm")
      'End If
      SqlComm.CommandText = "SELECT Placering, Pris FROM tblMmPrisWebApp WHERE (BladID = " & BladID & ")"
      dr = SqlComm.ExecuteReader
      While dr.Read
        Placering = dr.GetByte(0)
        pris = Format(dr.GetDecimal(1), "###0.00")
        Select Case Placering
          Case 1
            txtTekstside.Text = pris
          Case 2
            txtSide3.Text = pris
          Case 3
            txtSide5.Text = pris
          Case 4
            txtSide7.Text = pris
          Case 5
            txtHøjreSide.Text = pris
          Case 16
            txtBolig.Text = pris
          Case 12
            txtMotorside.Text = pris
          Case 13
            txtForlystelser.Text = pris
          Case 15
            txtStillinger.Text = pris
          Case 14
            txtOfficielle.Text = pris
          Case 17
            txtUddannelse.Text = pris
          Case 11
            txtRubrik.Text = pris
        End Select
      End While
      dr.Close()
      SqlComm.CommandText = "SELECT farvePris, farveMin, farveMax, farve4Pris, farve4Min, farve4Max, PrisBemærkning FROM tblFarveTillægWebApp WHERE (BladID = " & BladID & ")"
      dr = SqlComm.ExecuteReader
      If dr.Read() Then
        If Not dr.IsDBNull(0) Then
          If dr.GetDecimal(0) > 0 Then
            txtFarvetillæg.Text = Format(dr.GetDecimal(0), "###0.00")
          Else
            txtFarvetillæg.Text = ""
          End If
        End If
        If Not dr.IsDBNull(1) Then txtFarveMin.Text = dr.GetInt16(1)
        If Not dr.IsDBNull(2) Then txtFarveMax.Text = dr.GetInt16(2)
        If Not dr.IsDBNull(3) Then
          If dr.GetDecimal(3) > 0 Then
            txt4Farvetillæg.Text = Format(dr.GetDecimal(3), "###0.00")
          Else
            txt4Farvetillæg.Text = ""
          End If
        End If
        If Not dr.IsDBNull(4) Then txt4FarveMin.Text = dr.GetInt16(4)
        If Not dr.IsDBNull(5) Then txt4FarveMax.Text = dr.GetInt16(5)
        If Not dr.IsDBNull(6) Then txtBem.Text = dr.GetString(6)
      End If
      dr.Close()
      SqlConn.Close()
      checkLabels()
      ViewState("BladNavn") = BladNavn
      ViewState("BladID") = BladID
      Me.DataBind()
    Else
      BladNavn = CStr(ViewState("BladNavn"))
      BladID = CInt(ViewState("BladID"))
    End If
  End Sub

  Private Sub txtFarvetillæg_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFarvetillæg.TextChanged
    checkLabels()
  End Sub

  Private Sub txt4Farvetillæg_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt4Farvetillæg.TextChanged
    checkLabels()
  End Sub

  Private Sub checkLabels()
    If txt4Farvetillæg.Text.Length > 0 Then
      If CDbl(txt4Farvetillæg.Text) < 20 Then
        txt4FarveMin.Visible = True
        txt4FarveMax.Visible = True
      Else
        txt4FarveMin.Visible = False
        txt4FarveMax.Visible = False
      End If
    Else
      txt4FarveMin.Visible = False
      txt4FarveMax.Visible = False
    End If
    If txtFarvetillæg.Text.Length > 0 Then
      If CDbl(txtFarvetillæg.Text) < 20 Then
        txtFarveMin.Visible = True
        txtFarveMax.Visible = True
      Else
        txtFarveMin.Visible = False
        txtFarveMax.Visible = False
      End If
    Else
      txtFarveMin.Visible = False
      txtFarveMax.Visible = False
    End If
    If txtFarveMin.Visible OrElse txt4FarveMin.Visible Then
      lblMin.Visible = True
    Else
      lblMin.Visible = False
    End If
    If txtFarveMax.Visible OrElse txt4FarveMax.Visible Then
      lblMax.Visible = True
    Else
      lblMax.Visible = False
    End If
  End Sub

  Private Sub btnGodkend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGodkend.Click
    Dim sql As String

    Try
      SqlConn.Open()
      SqlComm.CommandText = "DELETE FROM tblMmPrisWebApp WHERE (BladID = " & BladID & ")"
      SqlComm.ExecuteNonQuery()
      If txtTekstside.Text.Length > 0 Then
        SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" & BladID & ",1," & txtTekstside.Text.Replace(",", ".") & ")"
        '  SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtTekstside.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=1)"
        SqlComm.ExecuteNonQuery()
      End If
      If txtSide3.Text.Length > 0 Then
        SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" & BladID & ",2," & txtSide3.Text.Replace(",", ".") & ")"
        'SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtSide3.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=2)"
        SqlComm.ExecuteNonQuery()
      End If
      If txtSide5.Text.Length > 0 Then
        SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" & BladID & ",3," & txtSide5.Text.Replace(",", ".") & ")"
        'SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtSide5.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=3)"
        SqlComm.ExecuteNonQuery()
      End If
      If txtSide7.Text.Length > 0 Then
        SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" & BladID & ",4," & txtSide7.Text.Replace(",", ".") & ")"
        'SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtSide7.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=4)"
        SqlComm.ExecuteNonQuery()
      End If
      If txtHøjreSide.Text.Length > 0 Then
        SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" & BladID & ",5," & txtHøjreSide.Text.Replace(",", ".") & ")"
        'SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtHøjreSide.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=5)"
        SqlComm.ExecuteNonQuery()
      End If
      If txtBolig.Text.Length > 0 Then
        SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" & BladID & ",16," & txtBolig.Text.Replace(",", ".") & ")"
        'SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtBolig.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=16)"
        SqlComm.ExecuteNonQuery()
      End If
      If txtMotorside.Text.Length > 0 Then
        SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" & BladID & ",12," & txtMotorside.Text.Replace(",", ".") & ")"
        'SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtMotorside.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=12)"
        SqlComm.ExecuteNonQuery()
      End If
      If txtForlystelser.Text.Length > 0 Then
        SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" & BladID & ",13," & txtForlystelser.Text.Replace(",", ".") & ")"
        'SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtForlystelser.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=13)"
        SqlComm.ExecuteNonQuery()
      End If
      If txtStillinger.Text.Length > 0 Then
        SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" & BladID & ",15," & txtStillinger.Text.Replace(",", ".") & ")"
        'SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtStillinger.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=15)"
        SqlComm.ExecuteNonQuery()
      End If
      If txtOfficielle.Text.Length > 0 Then
        SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" & BladID & ",14," & txtOfficielle.Text.Replace(",", ".") & ")"
        'SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtOfficielle.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=14)"
        SqlComm.ExecuteNonQuery()
      End If
      If txtUddannelse.Text.Length > 0 Then
        SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" & BladID & ",17," & txtUddannelse.Text.Replace(",", ".") & ")"
        'SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtUddannelse.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=17)"
        SqlComm.ExecuteNonQuery()
      End If
      If txtRubrik.Text.Length > 0 Then
        SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" & BladID & ",11," & txtRubrik.Text.Replace(",", ".") & ")"
        'SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtRubrik.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=11)"
        SqlComm.ExecuteNonQuery()
      End If

      SqlComm.CommandText = "DELETE FROM tblFarveTillægWebApp WHERE (BladID = " & BladID & ")"
      SqlComm.ExecuteNonQuery()
      If txtFarvetillæg.Text.Length = 0 Then txtFarvetillæg.Text = "0"
      If txt4Farvetillæg.Text.Length = 0 Then txt4Farvetillæg.Text = "0"

      sql = "INSERT INTO tblFarveTillægWebApp (BladID, farvePris, farveMin, farveMax, farve4Pris, farve4Min, farve4Max, Godkendt, PrisBemærkning) VALUES ("
      sql += BladID & "," & txtFarvetillæg.Text.Replace(",", ".") & "," & txtFarveMin.Text & "," & txtFarveMax.Text & "," & txt4Farvetillæg.Text.Replace(",", ".") & "," & txt4FarveMin.Text & "," & txt4FarveMax.Text & ",1,'" & Replace(txtBem.Text, "'", "''") & "')"
      SqlComm.CommandText = sql
      SqlComm.ExecuteNonQuery()
    Catch ex As Exception
      Response.Redirect("FejlKonverter.htm")
    Finally
      SqlConn.Close()
    End Try
    Response.Redirect("Afslut.htm")
  End Sub
End Class
