Imports System.Data.SqlClient

Partial Class Deadline
  Inherits System.Web.UI.Page
  Protected WithEvents SqlConn As System.Data.SqlClient.SqlConnection
  Protected WithEvents SqlComm As System.Data.SqlClient.SqlCommand
  Protected BladID As Integer
  Protected BladNavn As String
  Dim dr As SqlDataReader
  Protected QueryChk As Integer

  Dim query(1) As String

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
      Dim i As Integer

      If Request.QueryString.Count > 1 Then
        BladID = CInt(Request.QueryString("BladID"))
        QueryChk = CInt(Request.QueryString("Chk"))
      Else
        query = Split(Request.QueryString("Query"), "*")
        BladID = CInt(query(0))
        QueryChk = CInt(query(1))
      End If

      SqlComm.CommandText = "SELECT Navn FROM tblBladStamdata WHERE (BladId = " & BladID & ")"
      SqlConn.Open()
      dr = SqlComm.ExecuteReader
      dr.Read()
      BladNavn = dr("Navn").ToString
      dr.Close()
      CheckSum = 0
      For counter = 1 To Len(BladNavn)
        CheckSum = (CheckSum + (Asc(Mid(BladNavn, counter, 1)))) Mod 255
      Next
      'If CheckSum <> QueryChk AndAlso QueryChk <> 9999 Then
      '  Server.Transfer("CheckSumError.htm")
      'End If
      ViewState("BladNavn") = BladNavn
      ViewState("BladID") = BladID
      lstUge1.Items.Add(" ")
      lstUdgivelseUge1.Items.Add(" ")
      lstOrdreUge1.Items.Add(" ")
      lstMaterialeUge1.Items.Add(" ")
      lstUge2.Items.Add(" ")
      lstUdgivelseUge2.Items.Add(" ")
      lstOrdreUge2.Items.Add(" ")
      lstMaterialeUge2.Items.Add(" ")
      lstUge3.Items.Add(" ")
      lstUdgivelseUge3.Items.Add(" ")
      lstOrdreUge3.Items.Add(" ")
      lstMaterialeUge3.Items.Add(" ")
      lstUge4.Items.Add(" ")
      lstUdgivelseUge4.Items.Add(" ")
      lstOrdreUge4.Items.Add(" ")
      lstMaterialeUge4.Items.Add(" ")
      lstUge5.Items.Add(" ")
      lstUdgivelseUge5.Items.Add(" ")
      lstOrdreUge5.Items.Add(" ")
      lstMaterialeUge5.Items.Add(" ")
      lstUge6.Items.Add(" ")
      lstUdgivelseUge6.Items.Add(" ")
      lstOrdreUge6.Items.Add(" ")
      lstMaterialeUge6.Items.Add(" ")
      lstUge7.Items.Add(" ")
      lstUdgivelseUge7.Items.Add(" ")
      lstOrdreUge7.Items.Add(" ")
      lstMaterialeUge7.Items.Add(" ")
      lstUge8.Items.Add(" ")
      lstUdgivelseUge8.Items.Add(" ")
      lstOrdreUge8.Items.Add(" ")
      lstMaterialeUge8.Items.Add(" ")
      For i = 1 To 31
        lstUdgivelseUge1.Items.Add(i.ToString())
        lstOrdreUge1.Items.Add(i.ToString())
        lstMaterialeUge1.Items.Add(i.ToString())
        lstUdgivelseUge2.Items.Add(i.ToString())
        lstOrdreUge2.Items.Add(i.ToString())
        lstMaterialeUge2.Items.Add(i.ToString())
        lstUdgivelseUge3.Items.Add(i.ToString())
        lstOrdreUge3.Items.Add(i.ToString())
        lstMaterialeUge3.Items.Add(i.ToString())
        lstUdgivelseUge4.Items.Add(i.ToString())
        lstOrdreUge4.Items.Add(i.ToString())
        lstMaterialeUge4.Items.Add(i.ToString())
        lstUdgivelseUge5.Items.Add(i.ToString())
        lstOrdreUge5.Items.Add(i.ToString())
        lstMaterialeUge5.Items.Add(i.ToString())
        lstUdgivelseUge6.Items.Add(i.ToString())
        lstOrdreUge6.Items.Add(i.ToString())
        lstMaterialeUge6.Items.Add(i.ToString())
        lstUdgivelseUge7.Items.Add(i.ToString())
        lstOrdreUge7.Items.Add(i.ToString())
        lstMaterialeUge7.Items.Add(i.ToString())
        lstUdgivelseUge8.Items.Add(i.ToString())
        lstOrdreUge8.Items.Add(i.ToString())
        lstMaterialeUge8.Items.Add(i.ToString())
      Next
      lstOrdreTidUge1.Items.Add(" ")
      lstMaterialeTidUge1.Items.Add(" ")
      lstOrdreTidUge2.Items.Add(" ")
      lstMaterialeTidUge2.Items.Add(" ")
      lstOrdreTidUge3.Items.Add(" ")
      lstMaterialeTidUge3.Items.Add(" ")
      lstOrdreTidUge4.Items.Add(" ")
      lstMaterialeTidUge4.Items.Add(" ")
      lstOrdreTidUge5.Items.Add(" ")
      lstMaterialeTidUge5.Items.Add(" ")
      lstOrdreTidUge6.Items.Add(" ")
      lstMaterialeTidUge6.Items.Add(" ")
      lstOrdreTidUge7.Items.Add(" ")
      lstMaterialeTidUge7.Items.Add(" ")
      lstOrdreTidUge8.Items.Add(" ")
      lstMaterialeTidUge8.Items.Add(" ")
      For i = 9 To 16
        lstOrdreTidUge1.Items.Add(i.ToString() + ":00")
        lstOrdreTidUge1.Items.Add(i.ToString() + ":30")
        lstMaterialeTidUge1.Items.Add(i.ToString() + ":00")
        lstMaterialeTidUge1.Items.Add(i.ToString() + ":30")
        lstOrdreTidUge2.Items.Add(i.ToString() + ":00")
        lstOrdreTidUge2.Items.Add(i.ToString() + ":30")
        lstMaterialeTidUge2.Items.Add(i.ToString() + ":00")
        lstMaterialeTidUge2.Items.Add(i.ToString() + ":30")
        lstOrdreTidUge3.Items.Add(i.ToString() + ":00")
        lstOrdreTidUge3.Items.Add(i.ToString() + ":30")
        lstMaterialeTidUge3.Items.Add(i.ToString() + ":00")
        lstMaterialeTidUge3.Items.Add(i.ToString() + ":30")
        lstOrdreTidUge4.Items.Add(i.ToString() + ":00")
        lstOrdreTidUge4.Items.Add(i.ToString() + ":30")
        lstMaterialeTidUge4.Items.Add(i.ToString() + ":00")
        lstMaterialeTidUge4.Items.Add(i.ToString() + ":30")
        lstOrdreTidUge5.Items.Add(i.ToString() + ":00")
        lstOrdreTidUge5.Items.Add(i.ToString() + ":30")
        lstMaterialeTidUge5.Items.Add(i.ToString() + ":00")
        lstMaterialeTidUge5.Items.Add(i.ToString() + ":30")
        lstOrdreTidUge6.Items.Add(i.ToString() + ":00")
        lstOrdreTidUge6.Items.Add(i.ToString() + ":30")
        lstMaterialeTidUge6.Items.Add(i.ToString() + ":00")
        lstMaterialeTidUge6.Items.Add(i.ToString() + ":30")
        lstOrdreTidUge7.Items.Add(i.ToString() + ":00")
        lstOrdreTidUge7.Items.Add(i.ToString() + ":30")
        lstMaterialeTidUge7.Items.Add(i.ToString() + ":00")
        lstMaterialeTidUge7.Items.Add(i.ToString() + ":30")
        lstOrdreTidUge8.Items.Add(i.ToString() + ":00")
        lstOrdreTidUge8.Items.Add(i.ToString() + ":30")
        lstMaterialeTidUge8.Items.Add(i.ToString() + ":00")
        lstMaterialeTidUge8.Items.Add(i.ToString() + ":30")
      Next
      For i = 1 To 53
        lstUge1.Items.Add(i.ToString())
        lstUge2.Items.Add(i.ToString())
        lstUge3.Items.Add(i.ToString())
        lstUge4.Items.Add(i.ToString())
        lstUge5.Items.Add(i.ToString())
        lstUge6.Items.Add(i.ToString())
        lstUge7.Items.Add(i.ToString())
        lstUge8.Items.Add(i.ToString())
      Next
      SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " & BladID & ") AND (Linje = 1)"
      dr = SqlComm.ExecuteReader()
      While dr.Read()
        lstUdgivelseUge1.SelectedIndex = dr(1)
        lstOrdreUge1.SelectedIndex = dr(2)
        lstOrdreTidUge1.SelectedIndex = lstOrdreTidUge1.Items.IndexOf(lstOrdreTidUge1.Items.FindByText(dr(3)))
        lstMaterialeUge1.SelectedIndex = dr(4)
        lstMaterialeTidUge1.SelectedIndex = lstMaterialeTidUge1.Items.IndexOf(lstMaterialeTidUge1.Items.FindByText(dr(5)))
        lstUge1.SelectedIndex = lstUge1.Items.IndexOf(lstUge1.Items.FindByText(dr(6)))
        chkKommerIkke1.Checked = dr(0)
        chkKommerIkke1_CheckedChanged(New Object(), New System.EventArgs())
      End While
      dr.Close()

      SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " & BladID & ") AND (Linje = 2)"
      dr = SqlComm.ExecuteReader()
      While dr.Read()
        lstUdgivelseUge2.SelectedIndex = dr(1)
        lstOrdreUge2.SelectedIndex = dr(2)
        lstOrdreTidUge2.SelectedIndex = lstOrdreTidUge2.Items.IndexOf(lstOrdreTidUge2.Items.FindByText(dr(3)))
        lstMaterialeUge2.SelectedIndex = dr(4)
        lstMaterialeTidUge2.SelectedIndex = lstMaterialeTidUge2.Items.IndexOf(lstMaterialeTidUge2.Items.FindByText(dr(5)))
        lstUge2.SelectedIndex = lstUge2.Items.IndexOf(lstUge2.Items.FindByText(dr(6)))
        chkKommerIkke2.Checked = dr(0)
        chkKommerIkke2_CheckedChanged(New Object(), New System.EventArgs())
      End While
      dr.Close()

      SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " & BladID & ") AND (Linje = 3)"
      dr = SqlComm.ExecuteReader()
      While dr.Read()
        lstUdgivelseUge3.SelectedIndex = dr(1)
        lstOrdreUge3.SelectedIndex = dr(2)
        lstOrdreTidUge3.SelectedIndex = lstOrdreTidUge3.Items.IndexOf(lstOrdreTidUge3.Items.FindByText(dr(3)))
        lstMaterialeUge3.SelectedIndex = dr(4)
        lstMaterialeTidUge3.SelectedIndex = lstMaterialeTidUge3.Items.IndexOf(lstMaterialeTidUge3.Items.FindByText(dr(5)))
        lstUge3.SelectedIndex = lstUge3.Items.IndexOf(lstUge3.Items.FindByText(dr(6)))
        chkKommerIkke3.Checked = dr(0)
        chkKommerIkke3_CheckedChanged(New Object(), New System.EventArgs())
      End While
      dr.Close()

      SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " & BladID & ") AND (Linje = 4)"
      dr = SqlComm.ExecuteReader()
      While dr.Read()
        lstUdgivelseUge4.SelectedIndex = dr(1)
        lstOrdreUge4.SelectedIndex = dr(2)
        lstOrdreTidUge4.SelectedIndex = lstOrdreTidUge4.Items.IndexOf(lstOrdreTidUge4.Items.FindByText(dr(3)))
        lstMaterialeUge4.SelectedIndex = dr(4)
        lstMaterialeTidUge4.SelectedIndex = lstMaterialeTidUge4.Items.IndexOf(lstMaterialeTidUge4.Items.FindByText(dr(5)))
        lstUge4.SelectedIndex = lstUge4.Items.IndexOf(lstUge4.Items.FindByText(dr(6)))
        chkKommerIkke4.Checked = dr(0)
        chkKommerIkke4_CheckedChanged(New Object(), New System.EventArgs())
      End While
      dr.Close()

      SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " & BladID & ") AND (Linje = 5)"
      dr = SqlComm.ExecuteReader()
      While dr.Read()
        lstUdgivelseUge5.SelectedIndex = dr(1)
        lstOrdreUge5.SelectedIndex = dr(2)
        lstOrdreTidUge5.SelectedIndex = lstOrdreTidUge5.Items.IndexOf(lstOrdreTidUge5.Items.FindByText(dr(3)))
        lstMaterialeUge5.SelectedIndex = dr(4)
        lstMaterialeTidUge5.SelectedIndex = lstMaterialeTidUge5.Items.IndexOf(lstMaterialeTidUge5.Items.FindByText(dr(5)))
        lstUge5.SelectedIndex = lstUge5.Items.IndexOf(lstUge5.Items.FindByText(dr(6)))
        chkKommerIkke5.Checked = dr(0)
        chkKommerIkke5_CheckedChanged(New Object(), New System.EventArgs())
      End While
      dr.Close()

      SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " & BladID & ") AND (Linje = 6)"
      dr = SqlComm.ExecuteReader()
      While dr.Read()
        lstUdgivelseUge6.SelectedIndex = dr(1)
        lstOrdreUge6.SelectedIndex = dr(2)
        lstOrdreTidUge6.SelectedIndex = lstOrdreTidUge6.Items.IndexOf(lstOrdreTidUge6.Items.FindByText(dr(3)))
        lstMaterialeUge6.SelectedIndex = dr(4)
        lstMaterialeTidUge6.SelectedIndex = lstMaterialeTidUge6.Items.IndexOf(lstMaterialeTidUge6.Items.FindByText(dr(5)))
        lstUge6.SelectedIndex = lstUge6.Items.IndexOf(lstUge6.Items.FindByText(dr(6)))
        chkKommerIkke6.Checked = dr(0)
        chkKommerIkke6_CheckedChanged(New Object(), New System.EventArgs())
      End While
      dr.Close()

      SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " & BladID & ") AND (Linje = 7)"
      dr = SqlComm.ExecuteReader()
      While dr.Read()
        lstUdgivelseUge7.SelectedIndex = dr(1)
        lstOrdreUge7.SelectedIndex = dr(2)
        lstOrdreTidUge7.SelectedIndex = lstOrdreTidUge7.Items.IndexOf(lstOrdreTidUge7.Items.FindByText(dr(3)))
        lstMaterialeUge7.SelectedIndex = dr(4)
        lstMaterialeTidUge7.SelectedIndex = lstMaterialeTidUge7.Items.IndexOf(lstMaterialeTidUge7.Items.FindByText(dr(5)))
        lstUge7.SelectedIndex = lstUge7.Items.IndexOf(lstUge7.Items.FindByText(dr(6)))
        chkKommerIkke7.Checked = dr(0)
        chkKommerIkke7_CheckedChanged(New Object(), New System.EventArgs())
      End While
      dr.Close()

      SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " & BladID & ") AND (Linje = 8)"
      dr = SqlComm.ExecuteReader()
      While dr.Read()
        lstUdgivelseUge8.SelectedIndex = dr(1)
        lstOrdreUge8.SelectedIndex = dr(2)
        lstOrdreTidUge8.SelectedIndex = lstOrdreTidUge8.Items.IndexOf(lstOrdreTidUge8.Items.FindByText(dr(3)))
        lstMaterialeUge8.SelectedIndex = dr(4)
        lstMaterialeTidUge8.SelectedIndex = lstMaterialeTidUge8.Items.IndexOf(lstMaterialeTidUge8.Items.FindByText(dr(5)))
        lstUge8.SelectedIndex = lstUge8.Items.IndexOf(lstUge8.Items.FindByText(dr(6)))
        chkKommerIkke8.Checked = dr(0)
        chkKommerIkke8_CheckedChanged(New Object(), New System.EventArgs())
      End While
      dr.Close()

      SqlConn.Close()
      Me.DataBind()
    Else
      BladNavn = CStr(ViewState("BladNavn"))
      BladID = CInt(ViewState("BladID"))
    End If
  End Sub

  Private Sub btnOpdater_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOpdater.Click
    Try
      SqlComm.CommandText = "DELETE FROM tblWEBUdgivelse WHERE (BladID=" & BladID & ")"
      SqlConn.Open()
      SqlComm.ExecuteNonQuery()
      If lstUge1.SelectedIndex > 0 Then
        SqlComm.CommandText = "INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" & BladID.ToString() + ", 1,'" & lstUge1.SelectedItem.ToString() & "'," + lstUdgivelseUge1.SelectedIndex.ToString() + "," + lstOrdreUge1.SelectedIndex.ToString() + ",'" + lstOrdreTidUge1.SelectedItem.ToString() + "'," + lstMaterialeUge1.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge1.SelectedItem.ToString() + "'," + IIf(chkKommerIkke1.Checked, "1", "0") + ")"
        SqlComm.ExecuteNonQuery()
      End If
      If lstUge2.SelectedIndex > 0 Then
        SqlComm.CommandText = "INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" & BladID.ToString() + ", 2,'" & lstUge2.SelectedItem.ToString() & "'," + lstUdgivelseUge2.SelectedIndex.ToString() + "," + lstOrdreUge2.SelectedIndex.ToString() + ",'" + lstOrdreTidUge2.SelectedItem.ToString() + "'," + lstMaterialeUge2.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge2.SelectedItem.ToString() + "'," + IIf(chkKommerIkke2.Checked, "1", "0") + ")"
        SqlComm.ExecuteNonQuery()
      End If
      If lstUge3.SelectedIndex > 0 Then
        SqlComm.CommandText = "INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" & BladID.ToString() + ", 3,'" & lstUge3.SelectedItem.ToString() & "'," + lstUdgivelseUge3.SelectedIndex.ToString() + "," + lstOrdreUge3.SelectedIndex.ToString() + ",'" + lstOrdreTidUge3.SelectedItem.ToString() + "'," + lstMaterialeUge3.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge3.SelectedItem.ToString() + "'," + IIf(chkKommerIkke3.Checked, "1", "0") + ")"
        SqlComm.ExecuteNonQuery()
      End If
      If lstUge4.SelectedIndex > 0 Then
        SqlComm.CommandText = "INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" & BladID.ToString() + ", 4,'" & lstUge4.SelectedItem.ToString() & "'," + lstUdgivelseUge4.SelectedIndex.ToString() + "," + lstOrdreUge4.SelectedIndex.ToString() + ",'" + lstOrdreTidUge4.SelectedItem.ToString() + "'," + lstMaterialeUge4.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge4.SelectedItem.ToString() + "'," + IIf(chkKommerIkke4.Checked, "1", "0") + ")"
        SqlComm.ExecuteNonQuery()
      End If
      If lstUge5.SelectedIndex > 0 Then
        SqlComm.CommandText = "INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" & BladID.ToString() + ", 5,'" & lstUge5.SelectedItem.ToString() & "'," + lstUdgivelseUge5.SelectedIndex.ToString() + "," + lstOrdreUge5.SelectedIndex.ToString() + ",'" + lstOrdreTidUge5.SelectedItem.ToString() + "'," + lstMaterialeUge5.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge5.SelectedItem.ToString() + "'," + IIf(chkKommerIkke5.Checked, "1", "0") + ")"
        SqlComm.ExecuteNonQuery()
      End If
      If lstUge6.SelectedIndex > 0 Then
        SqlComm.CommandText = "INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" & BladID.ToString() + ", 6,'" & lstUge6.SelectedItem.ToString() & "'," + lstUdgivelseUge6.SelectedIndex.ToString() + "," + lstOrdreUge6.SelectedIndex.ToString() + ",'" + lstOrdreTidUge6.SelectedItem.ToString() + "'," + lstMaterialeUge6.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge6.SelectedItem.ToString() + "'," + IIf(chkKommerIkke6.Checked, "1", "0") + ")"
        SqlComm.ExecuteNonQuery()
      End If
      If lstUge7.SelectedIndex > 0 Then
        SqlComm.CommandText = "INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" & BladID.ToString() + ", 7,'" & lstUge7.SelectedItem.ToString() & "'," + lstUdgivelseUge7.SelectedIndex.ToString() + "," + lstOrdreUge7.SelectedIndex.ToString() + ",'" + lstOrdreTidUge7.SelectedItem.ToString() + "'," + lstMaterialeUge7.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge7.SelectedItem.ToString() + "'," + IIf(chkKommerIkke7.Checked, "1", "0") + ")"
        SqlComm.ExecuteNonQuery()
      End If
      If lstUge8.SelectedIndex > 0 Then
        SqlComm.CommandText = "INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" & BladID.ToString() + ", 8,'" & lstUge8.SelectedItem.ToString() & "'," + lstUdgivelseUge8.SelectedIndex.ToString() + "," + lstOrdreUge8.SelectedIndex.ToString() + ",'" + lstOrdreTidUge8.SelectedItem.ToString() + "'," + lstMaterialeUge8.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge8.SelectedItem.ToString() + "'," + IIf(chkKommerIkke8.Checked, "1", "0") + ")"
        SqlComm.ExecuteNonQuery()
      End If
    Catch
      Response.Redirect("FejlOpdater.htm")
    Finally
      SqlConn.Close()
      SqlConn.Dispose()
    End Try
    Response.Redirect("Afslut.htm")
  End Sub

  Private Sub chkKommerIkke1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkKommerIkke1.CheckedChanged
    If chkKommerIkke1.Checked = True Then
      lstUdgivelseUge1.SelectedIndex = 0
      lstUdgivelseUge1.Enabled = False
      lstOrdreUge1.SelectedIndex = 0
      lstOrdreUge1.Enabled = False
      lstOrdreTidUge1.SelectedIndex = 0
      lstOrdreTidUge1.Enabled = False
      lstMaterialeUge1.SelectedIndex = 0
      lstMaterialeUge1.Enabled = False
      lstMaterialeTidUge1.SelectedIndex = 0
      lstMaterialeTidUge1.Enabled = False
    Else
      lstUdgivelseUge1.Enabled = True
      lstOrdreUge1.Enabled = True
      lstOrdreTidUge1.Enabled = True
      lstMaterialeUge1.Enabled = True
      lstMaterialeTidUge1.Enabled = True
    End If
  End Sub

  Private Sub chkKommerIkke2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkKommerIkke2.CheckedChanged
    If chkKommerIkke2.Checked = True Then
      lstUdgivelseUge2.SelectedIndex = 0
      lstUdgivelseUge2.Enabled = False
      lstOrdreUge2.SelectedIndex = 0
      lstOrdreUge2.Enabled = False
      lstOrdreTidUge2.SelectedIndex = 0
      lstOrdreTidUge2.Enabled = False
      lstMaterialeUge2.SelectedIndex = 0
      lstMaterialeUge2.Enabled = False
      lstMaterialeTidUge2.SelectedIndex = 0
      lstMaterialeTidUge2.Enabled = False
    Else
      lstUdgivelseUge2.Enabled = True
      lstOrdreUge2.Enabled = True
      lstOrdreTidUge2.Enabled = True
      lstMaterialeUge2.Enabled = True
      lstMaterialeTidUge2.Enabled = True
    End If
  End Sub

  Private Sub chkKommerIkke3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkKommerIkke3.CheckedChanged
    If chkKommerIkke3.Checked = True Then
      lstUdgivelseUge3.SelectedIndex = 0
      lstUdgivelseUge3.Enabled = False
      lstOrdreUge3.SelectedIndex = 0
      lstOrdreUge3.Enabled = False
      lstOrdreTidUge3.SelectedIndex = 0
      lstOrdreTidUge3.Enabled = False
      lstMaterialeUge3.SelectedIndex = 0
      lstMaterialeUge3.Enabled = False
      lstMaterialeTidUge3.SelectedIndex = 0
      lstMaterialeTidUge3.Enabled = False
    Else
      lstUdgivelseUge3.Enabled = True
      lstOrdreUge3.Enabled = True
      lstOrdreTidUge3.Enabled = True
      lstMaterialeUge3.Enabled = True
      lstMaterialeTidUge3.Enabled = True
    End If
  End Sub

  Private Sub chkKommerIkke4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkKommerIkke4.CheckedChanged
    If chkKommerIkke4.Checked = True Then
      lstUdgivelseUge4.SelectedIndex = 0
      lstUdgivelseUge4.Enabled = False
      lstOrdreUge4.SelectedIndex = 0
      lstOrdreUge4.Enabled = False
      lstOrdreTidUge4.SelectedIndex = 0
      lstOrdreTidUge4.Enabled = False
      lstMaterialeUge4.SelectedIndex = 0
      lstMaterialeUge4.Enabled = False
      lstMaterialeTidUge4.SelectedIndex = 0
      lstMaterialeTidUge4.Enabled = False
    Else
      lstUdgivelseUge4.Enabled = True
      lstOrdreUge4.Enabled = True
      lstOrdreTidUge4.Enabled = True
      lstMaterialeUge4.Enabled = True
      lstMaterialeTidUge4.Enabled = True
    End If
  End Sub

  Private Sub chkKommerIkke5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKommerIkke5.CheckedChanged
    If chkKommerIkke5.Checked = True Then
      lstUdgivelseUge5.SelectedIndex = 0
      lstUdgivelseUge5.Enabled = False
      lstOrdreUge5.SelectedIndex = 0
      lstOrdreUge5.Enabled = False
      lstOrdreTidUge5.SelectedIndex = 0
      lstOrdreTidUge5.Enabled = False
      lstMaterialeUge5.SelectedIndex = 0
      lstMaterialeUge5.Enabled = False
      lstMaterialeTidUge5.SelectedIndex = 0
      lstMaterialeTidUge5.Enabled = False
    Else
      lstUdgivelseUge5.Enabled = True
      lstOrdreUge5.Enabled = True
      lstOrdreTidUge5.Enabled = True
      lstMaterialeUge5.Enabled = True
      lstMaterialeTidUge5.Enabled = True
    End If
  End Sub

  Private Sub chkKommerIkke6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKommerIkke6.CheckedChanged
    If chkKommerIkke6.Checked = True Then
      lstUdgivelseUge6.SelectedIndex = 0
      lstUdgivelseUge6.Enabled = False
      lstOrdreUge6.SelectedIndex = 0
      lstOrdreUge6.Enabled = False
      lstOrdreTidUge6.SelectedIndex = 0
      lstOrdreTidUge6.Enabled = False
      lstMaterialeUge6.SelectedIndex = 0
      lstMaterialeUge6.Enabled = False
      lstMaterialeTidUge6.SelectedIndex = 0
      lstMaterialeTidUge6.Enabled = False
    Else
      lstUdgivelseUge6.Enabled = True
      lstOrdreUge6.Enabled = True
      lstOrdreTidUge6.Enabled = True
      lstMaterialeUge6.Enabled = True
      lstMaterialeTidUge6.Enabled = True
    End If
  End Sub

  Private Sub chkKommerIkke7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKommerIkke7.CheckedChanged
    If chkKommerIkke7.Checked = True Then
      lstUdgivelseUge7.SelectedIndex = 0
      lstUdgivelseUge7.Enabled = False
      lstOrdreUge7.SelectedIndex = 0
      lstOrdreUge7.Enabled = False
      lstOrdreTidUge7.SelectedIndex = 0
      lstOrdreTidUge7.Enabled = False
      lstMaterialeUge7.SelectedIndex = 0
      lstMaterialeUge7.Enabled = False
      lstMaterialeTidUge7.SelectedIndex = 0
      lstMaterialeTidUge7.Enabled = False
    Else
      lstUdgivelseUge7.Enabled = True
      lstOrdreUge7.Enabled = True
      lstOrdreTidUge7.Enabled = True
      lstMaterialeUge7.Enabled = True
      lstMaterialeTidUge7.Enabled = True
    End If
  End Sub

  Private Sub chkKommerIkke8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKommerIkke8.CheckedChanged
    If chkKommerIkke8.Checked = True Then
      lstUdgivelseUge8.SelectedIndex = 0
      lstUdgivelseUge8.Enabled = False
      lstOrdreUge8.SelectedIndex = 0
      lstOrdreUge8.Enabled = False
      lstOrdreTidUge8.SelectedIndex = 0
      lstOrdreTidUge8.Enabled = False
      lstMaterialeUge8.SelectedIndex = 0
      lstMaterialeUge8.Enabled = False
      lstMaterialeTidUge8.SelectedIndex = 0
      lstMaterialeTidUge8.Enabled = False
    Else
      lstUdgivelseUge8.Enabled = True
      lstOrdreUge8.Enabled = True
      lstOrdreTidUge8.Enabled = True
      lstMaterialeUge8.Enabled = True
      lstMaterialeTidUge8.Enabled = True
    End If
  End Sub
End Class
