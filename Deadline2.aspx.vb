Imports System.Data.SqlClient

Partial Class Deadline2
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
      lstOrdreUge1.Items.Add(" ")
      lstMaterialeUge1.Items.Add(" ")
      lstOrdreUge1.Items.Add("Mandag")
      lstMaterialeUge1.Items.Add("Mandag")
      lstOrdreUge1.Items.Add("Tirsdag")
      lstMaterialeUge1.Items.Add("Tirsdag")
      lstOrdreUge1.Items.Add("Onsdag")
      lstMaterialeUge1.Items.Add("Onsdag")
      lstOrdreUge1.Items.Add("Torsdag")
      lstMaterialeUge1.Items.Add("Torsdag")
      lstOrdreUge1.Items.Add("Fredag")
      lstMaterialeUge1.Items.Add("Fredag")
      lstOrdreUge1.Items.Add("Lørdag")
      lstMaterialeUge1.Items.Add("Lørdag")
      lstOrdreUge1.Items.Add("Søndag")
      lstMaterialeUge1.Items.Add("Søndag")
      lstOrdreTidUge1.Items.Add(" ")
      lstMaterialeTidUge1.Items.Add(" ")
      lstOrdreUge2.Items.Add(" ")
      lstMaterialeUge2.Items.Add(" ")
      lstOrdreUge2.Items.Add("Mandag")
      lstMaterialeUge2.Items.Add("Mandag")
      lstOrdreUge2.Items.Add("Tirsdag")
      lstMaterialeUge2.Items.Add("Tirsdag")
      lstOrdreUge2.Items.Add("Onsdag")
      lstMaterialeUge2.Items.Add("Onsdag")
      lstOrdreUge2.Items.Add("Torsdag")
      lstMaterialeUge2.Items.Add("Torsdag")
      lstOrdreUge2.Items.Add("Fredag")
      lstMaterialeUge2.Items.Add("Fredag")
      lstOrdreUge2.Items.Add("Lørdag")
      lstMaterialeUge2.Items.Add("Lørdag")
      lstOrdreUge2.Items.Add("Søndag")
      lstMaterialeUge2.Items.Add("Søndag")
      lstOrdreTidUge2.Items.Add(" ")
      lstMaterialeTidUge2.Items.Add(" ")
      For i = 9 To 16
        lstOrdreTidUge1.Items.Add(i.ToString() + ":00")
        lstOrdreTidUge1.Items.Add(i.ToString() + ":30")
        lstMaterialeTidUge1.Items.Add(i.ToString() + ":00")
        lstMaterialeTidUge1.Items.Add(i.ToString() + ":30")
        lstOrdreTidUge2.Items.Add(i.ToString() + ":00")
        lstOrdreTidUge2.Items.Add(i.ToString() + ":30")
        lstMaterialeTidUge2.Items.Add(i.ToString() + ":00")
        lstMaterialeTidUge2.Items.Add(i.ToString() + ":30")
      Next
      SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " & BladID & ") AND (Linje = 1)"
      dr = SqlComm.ExecuteReader()
      While dr.Read()
        lstOrdreUge1.SelectedIndex = dr(2)
        lstOrdreTidUge1.SelectedIndex = lstOrdreTidUge1.Items.IndexOf(lstOrdreTidUge1.Items.FindByText(dr(3)))
        lstMaterialeUge1.SelectedIndex = dr(4)
        lstMaterialeTidUge1.SelectedIndex = lstMaterialeTidUge1.Items.IndexOf(lstMaterialeTidUge1.Items.FindByText(dr(5)))
      End While
      dr.Close()
      SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " & BladID & ") AND (Linje = 2)"
      dr = SqlComm.ExecuteReader()
      While dr.Read()
        lstOrdreUge2.SelectedIndex = dr(2)
        lstOrdreTidUge2.SelectedIndex = lstOrdreTidUge2.Items.IndexOf(lstOrdreTidUge2.Items.FindByText(dr(3)))
        lstMaterialeUge2.SelectedIndex = dr(4)
        lstMaterialeTidUge2.SelectedIndex = lstMaterialeTidUge2.Items.IndexOf(lstMaterialeTidUge2.Items.FindByText(dr(5)))
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
      If lstOrdreUge1.SelectedIndex > 0 Then
        SqlComm.CommandText = "INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" & BladID.ToString() + ", 1,'0', 0," + lstOrdreUge1.SelectedIndex.ToString() + ",'" + lstOrdreTidUge1.SelectedItem.ToString() + "'," + lstMaterialeUge1.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge1.SelectedItem.ToString() + "', 0)"
        SqlComm.ExecuteNonQuery()
      End If
      If lstOrdreUge2.SelectedIndex > 0 Then
        SqlComm.CommandText = "INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" & BladID.ToString() + ", 2,'0', 0," + lstOrdreUge2.SelectedIndex.ToString() + ",'" + lstOrdreTidUge2.SelectedItem.ToString() + "'," + lstMaterialeUge2.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge2.SelectedItem.ToString() + "', 0)"
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
End Class
