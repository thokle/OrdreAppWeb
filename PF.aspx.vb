Imports System.Data.SqlClient

Partial Class PF
  Inherits System.Web.UI.Page
  Protected WithEvents SqlComm As System.Data.SqlClient.SqlCommand
  Protected WithEvents SqlConn As System.Data.SqlClient.SqlConnection
  Protected WithEvents lblVigtigt As System.Web.UI.WebControls.Label
  Protected WithEvents lblVigtigt2 As System.Web.UI.WebControls.Label
  Protected bladID As Integer
  Protected bladNavn As String
  Protected dr As SqlDataReader
  Protected eMail As String
  Protected eMailID As Integer
  Protected personNavn As String
  Protected besvaretAf As String
  Protected personID As Integer
  Protected queryChk As Integer
  Protected spurgtID As Integer
  Protected placeringUB As Integer
  Protected indFarve As Double
  Protected query(3) As String
  Protected VisPlaceringUB As Boolean

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
      Dim checkSum As Integer
      Dim counter As Integer
      If Request.QueryString.Count > 1 Then
        BladID = CInt(Request.QueryString("BladID"))
        spurgtID = CInt(Request.QueryString("ID"))
        QueryChk = CInt(Request.QueryString("Chk"))
        PersonID = CInt(Request.QueryString("PID"))
      Else
        query = Split(Request.QueryString("Query"), "*")
        BladID = CInt(query(0))
        QueryChk = CInt(query(1))
        spurgtID = CInt(query(2))
        PersonID = CInt(query(3))
      End If
      If PersonID = 0 Then
        Server.Transfer("NoeMail.htm")
      End If
      SqlComm.CommandText = "SELECT Navn FROM tblBladStamdata WHERE (BladID = " & bladID & ")"
      SqlConn.Open()
      dr = SqlComm.ExecuteReader
      dr.Read()
      BladNavn = dr("Navn").ToString
      dr.Close()
      checkSum = 0
      For counter = 1 To Len(BladNavn)
        CheckSum = (CheckSum + (Asc(Mid(BladNavn, counter, 1)))) Mod 255
      Next
      If checkSum <> queryChk Then
        Server.Transfer("CheckSumError.htm")
      End If
      lblTilBlad.Text = "Prisforespørgsel til " & bladNavn
      SqlComm.CommandText = "SELECT PersonNavn, eMail FROM tblWEBeMails WHERE (PersonID=" & personID & ")"
      dr = SqlComm.ExecuteReader
      If dr.Read Then
        personNavn = dr.GetString(0)
        eMail = dr.GetString(1)
      End If
      If personNavn = "" Then
        'Response.Redirect("IndtastNavn.aspx" & Request.Url.Query)
        Server.Transfer("IndtastNavn.aspx" & Request.Url.Query)
      End If
      dr.Close()

      SqlComm.CommandText = "SELECT tblWEBeMails.PersonNavn, tblWEBeMails.eMail FROM tblWEBForespørgselLinjer INNER JOIN tblWEBeMails ON tblWEBForespørgselLinjer.BesvaretAf = tblWEBeMails.PersonID WHERE (tblWEBForespørgselLinjer.ForespørgselID = " & spurgtID & ") AND (tblWEBForespørgselLinjer.BladID = " & bladID & ")"
      dr = SqlComm.ExecuteReader
      If dr.Read Then
        besvaretAf = dr.GetString(0)
      End If
      dr.Close()
      If besvaretAf <> "" Then 'vís bladets svar
        lblÆndring.Visible = True
        lblÆndring.Text = "Vores svar"
        lblBladmmpris.Visible = True
        lblBladmmRabat.Visible = True
        lblBladfarvetillæg.Visible = True
        lblBladfarverabat.Visible = True
        txtBladMmPris.Visible = True
        txtBladMmRabat.Visible = True
        txtBladFarvetillæg.Visible = True
        txtBladFarveRabat.Visible = True
        lblBladBemærkning.Visible = True
        lblBladBemærkning.Text = "Bemærkning til svar"
        txtBladBemærkning.Visible = True
        '      lblPlaceringUB.Style("Top") = 528
        '     PlaceringTable.Style("Top") = 548
        '        lblVigtigt.Style("Top") = 656
        '        lblVigtigt2.Style("Top") = 656
        '       lblMVH.Style("Top") = 712
        btnGodkend.Text = "Godkend ændringer"
        btnÆndringer.Text = "Fortryd ændringer"
        btnGodkend.Visible = False
        'btnÆndringer.Visible = False
        SqlComm.CommandText = "SELECT PlaceringUB, BladMmPris, BladMmRabat, BladFarveTillæg, BladFarveRabat, BladBemærkning FROM tblWEBForespørgselLinjer WHERE (ForespørgselID = " & spurgtID & ") AND (BladID = " & bladID & ")"
        dr = SqlComm.ExecuteReader()
        dr.Read()
        placeringUB = dr.GetByte(0)
        txtBladMmPris.Text = Format(dr.GetDecimal(1), "###,##0.00")
        txtBladMmRabat.Text = dr.GetDouble(2).ToString()
        indFarve = dr.GetDecimal(3)
        If indFarve < 20 Then
          txtBladFarvetillæg.Text = Format(indFarve, "###,##0.00")
        Else
          txtBladFarvetillæg.Text = Format(indFarve, "#.###")
        End If
        txtBladFarveRabat.Text = dr.GetDouble(4).ToString()
        txtBladBemærkning.Text = dr.GetString(5)
        dr.Close()
        Select Case placeringUB
          Case 1
            chk357.Checked = True
          Case 2
            chkHsFm.Checked = True
          Case 3
            chkHøjSide.Checked = True
          Case 4
            chkNej.Checked = True
        End Select
        If besvaretAf <> personNavn Then
          lblBesvaretAf.Text = "Der kan kun ændres af " & besvaretAf
          chk357.Enabled = False
          chkHsFm.Enabled = False
          chkHøjSide.Enabled = False
          chkNej.Enabled = False
          txtBladMmPris.Enabled = False
          txtBladMmRabat.Enabled = False
          txtBladFarvetillæg.Enabled = False
          txtBladFarveRabat.Enabled = False
          txtBladBemærkning.Enabled = False
          btnÆndringer.Text = "Luk siden"
        Else
          lblBesvaretAf.Text = "Udfyldt af " & personNavn
          btnGodkend.Visible = True
          'btnÆndringer.Visible = True
          'ÅbnGodkend()
        End If
      Else 'der er ikke svaret før
        lblBesvaretAf.Text = "Udfyldes af " & personNavn
        lblÆndring.Visible = False
        lblBladmmpris.Visible = False
        lblBladmmRabat.Visible = False
        lblBladfarvetillæg.Visible = False
        lblBladfarverabat.Visible = False
        txtBladMmPris.Visible = False
        txtBladMmRabat.Visible = False
        txtBladFarvetillæg.Visible = False
        txtBladFarveRabat.Visible = False
        lblBladBemærkning.Visible = False
        txtBladBemærkning.Visible = False
        '    lblMarker.Style("Top") = 420
        '    lblPlaceringUB.Style("Top") = 348
        '    PlaceringTable.Style("Top") = 368
        '    lblVigtigt.Style("Top") = 476
        '    lblVigtigt2.Style("Top") = 476
        '    lblMVH.Style("Top") = 532
        btnGodkend.Visible = True
      End If
      'Hent medieplanhoved
      SqlComm.CommandText = "SELECT NavisionContact.Name, Salesperson.Name AS Navn, tblWEBForespørgsel.Format, tblWEBForespørgsel.AntalFarver, tblPlacering.Betegnelse, tblWEBForespørgsel.Mediebureau, tblWEBForespørgsel.AntalIndrykninger, tblWEBForespørgsel.Bemærkning, tblWEBForespørgsel.PlaceringUB FROM tblWEBForespørgsel INNER JOIN NavisionContact ON tblWEBForespørgsel.AnnoncørNo_ = NavisionContact.No_ INNER JOIN tblPlacering ON tblWEBForespørgsel.PlaceringID = tblPlacering.PlaceringID INNER JOIN Salesperson ON tblWEBForespørgsel.KonsulentCode = Salesperson.Code WHERE (tblWEBForespørgsel.ForespørgselID = " & spurgtID & ")"
      dr = SqlComm.ExecuteReader
      dr.Read()
      visAnnoncør.Text = dr.GetString(0)
      lblMVH.Text = "Med venlig hilsen<br>" & dr.GetString(1)
      visFormat.Text = dr.GetString(2)
      visFarver.Text = dr.GetByte(3)
      visPlacering.Text = dr.GetString(4)
      visMediebureau.Text = dr.GetString(5)
      visAntalIndrykn.Text = dr.GetByte(6)
      visBemærkning.Text = dr.GetString(7)
      VisPlaceringUB = dr.GetBoolean(8)
      dr.Close()
      If Not VisPlaceringUB Then
        PlaceringTable.Visible = False
        lblMarker.Visible = False
        lblPlaceringUB.Visible = False
      End If
      'Hent prisforeslag
      SqlComm.CommandText = "SELECT DLUMmPris, DLUMmRabat, DLUFarveTillæg, DLUFarveRabat FROM tblWEBForespørgselLinjer WHERE (ForespørgselID = " & spurgtID & ") AND (BladID = " & bladID & ")"
      dr = SqlComm.ExecuteReader
      dr.Read()
      txtDLUMmpris.Text = Format(dr.GetDecimal(0), "###,##0.00")
      txtDLUMmRabat.Text = dr.GetDouble(1).ToString()
      indFarve = dr.GetDecimal(2)
      If indFarve < 20 Then
        txtDLUFarvetillæg.Text = Format(indFarve, "###,##0.00")
      Else
        txtDLUFarvetillæg.Text = Format(indFarve, "#.###")
      End If
      txtDLUFarveRabat.Text = dr.GetDouble(3).ToString()
      SqlConn.Close()
      ViewState("BladNavn") = bladNavn
      ViewState("BladID") = bladID
      ViewState("PersonNavn") = personNavn
      ViewState("BesvaretAf") = besvaretAf
      ViewState("PersonID") = personID
      ViewState("spurgtID") = spurgtID
      ViewState("PlaceringUB") = placeringUB
      viewstate("VisPlaceringUB") = VisPlaceringUB
    Else
      bladNavn = CStr(ViewState("BladNavn"))
      bladID = CInt(ViewState("BladID"))
      personNavn = CStr(ViewState("PersonNavn"))
      besvaretAf = CStr(ViewState("BesvaretAf"))
      personID = CInt(ViewState("PersonID"))
      spurgtID = CInt(ViewState("spurgtID"))
      placeringUB = CInt(Viewstate("PlaceringUB"))
      VisPlaceringUB = CBool(Viewstate("VisPlaceringUB"))
      If btnÆndringer.Text <> "Ændringer til forslag" Then
        '  lblPlaceringUB.Style("Top") = 528
        '  PlaceringTable.Style("Top") = 548
        '  lblVigtigt.Style("Top") = 656
        '  lblVigtigt2.Style("Top") = 656
        '  lblMVH.Style("Top") = 712
        '  lblMarker.Style("Top") = 600
        lblÆndring.Visible = True
        lblBladmmpris.Visible = True
        lblBladmmRabat.Visible = True
        lblBladfarvetillæg.Visible = True
        lblBladfarverabat.Visible = True
        txtBladMmPris.Visible = True
        txtBladMmRabat.Visible = True
        txtBladFarvetillæg.Visible = True
        txtBladFarveRabat.Visible = True
        lblBladBemærkning.Visible = True
        txtBladBemærkning.Visible = True
      Else
        '    lblPlaceringUB.Style("Top") = 348
        '    PlaceringTable.Style("Top") = 368
        '    lblVigtigt.Style("Top") = 476
        '    lblVigtigt2.Style("Top") = 476
        '    lblMVH.Style("Top") = 532
        '    lblMarker.Style("Top") = 420
        lblÆndring.Visible = False
        lblBladmmpris.Visible = False
        lblBladmmRabat.Visible = False
        lblBladfarvetillæg.Visible = False
        lblBladfarverabat.Visible = False
        txtBladMmPris.Visible = False
        txtBladMmRabat.Visible = False
        txtBladFarvetillæg.Visible = False
        txtBladFarveRabat.Visible = False
        lblBladBemærkning.Visible = False
        txtBladBemærkning.Visible = False
      End If
      If Not VisPlaceringUB Then
        PlaceringTable.Visible = False
        lblMarker.Visible = False
        lblPlaceringUB.Visible = False
      End If
    End If
  End Sub

  'Private Sub chk357_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk357.CheckedChanged
  '  If chk357.Checked = True Then
  '    chkHsFm.Checked = False
  '    chkHøjSide.Checked = False
  '    chkNej.Checked = False
  '    PlaceringUB = 1
  '  End If
  '  ÅbnGodkend()
  'End Sub

  'Private Sub chkHsFm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHsFm.CheckedChanged
  '  If chkHsFm.Checked = True Then
  '    chk357.Checked = False
  '    chkHøjSide.Checked = False
  '    chkNej.Checked = False
  '    PlaceringUB = 2
  '  End If
  '  ÅbnGodkend()
  'End Sub

  'Private Sub chkHøjSide_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHøjSide.CheckedChanged
  '  If chkHøjSide.Checked = True Then
  '    chk357.Checked = False
  '    chkHsFm.Checked = False
  '    chkNej.Checked = False
  '    PlaceringUB = 3
  '  End If
  '  ÅbnGodkend()
  'End Sub

  'Private Sub chkNej_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNej.CheckedChanged
  '  If chkNej.Checked = True Then
  '    chk357.Checked = False
  '    chkHsFm.Checked = False
  '    chkHøjSide.Checked = False
  '    PlaceringUB = 4
  '  End If
  '  ÅbnGodkend()
  'End Sub

  'Private Sub ÅbnGodkend()
  '  If VisPlaceringUB Then
  '    If (chk357.Checked Or chkHsFm.Checked Or chkHøjSide.Checked Or chkNej.Checked) = True Then
  '      btnGodkend.Enabled = True
  '    Else
  '      btnGodkend.Enabled = False
  '      placeringUB = 0
  '    End If
  '  Else
  '    btnGodkend.Enabled = True
  '    placeringUB = 0
  '  End If
  '  viewstate("PlaceringUB") = placeringUB
  'End Sub

  Private Sub btnÆndringer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnÆndringer.Click
    If btnÆndringer.Text = "Ændringer til forslag" Then
      lblÆndring.Visible = True
      lblBladmmpris.Visible = True
      lblBladmmRabat.Visible = True
      lblBladfarvetillæg.Visible = True
      lblBladfarverabat.Visible = True
      txtBladMmPris.Visible = True
      txtBladMmRabat.Visible = True
      txtBladFarvetillæg.Visible = True
      txtBladFarveRabat.Visible = True
      lblBladBemærkning.Visible = True
      txtBladBemærkning.Visible = True
      '  lblPlaceringUB.Style("Top") = 528
      '  PlaceringTable.Style("Top") = 548
      '  lblVigtigt.Style("Top") = 656
      '  lblVigtigt2.Style("Top") = 656
      '  lblMVH.Style("Top") = 712
      '  lblMarker.Style("Top") = 600
      btnGodkend.Text = "Godkend ændringer"
      btnÆndringer.Text = "Fortryd ændringer"
      txtBladMmPris.Text = txtDLUMmpris.Text
      txtBladMmRabat.Text = txtDLUMmRabat.Text
      txtBladFarvetillæg.Text = txtDLUFarvetillæg.Text
      txtBladFarveRabat.Text = txtDLUFarveRabat.Text
    Else
      If btnÆndringer.Text <> "Luk siden" Then
        lblÆndring.Visible = False
        lblBladmmpris.Visible = False
        lblBladmmRabat.Visible = False
        lblBladfarvetillæg.Visible = False
        lblBladfarverabat.Visible = False
        txtBladMmPris.Visible = False
        txtBladMmRabat.Visible = False
        txtBladFarvetillæg.Visible = False
        txtBladFarveRabat.Visible = False
        lblBladBemærkning.Visible = False
        txtBladBemærkning.Visible = False
        '   lblPlaceringUB.Style("Top") = 348
        '   PlaceringTable.Style("Top") = 368
        '   lblVigtigt.Style("Top") = 476
        '   lblVigtigt2.Style("Top") = 476
        '   lblMVH.Style("Top") = 532
        '   lblMarker.Style("Top") = 420
        btnGodkend.Text = "Godkend forslag"
        btnÆndringer.Text = "Ændringer til forslag"
      Else
        Response.Redirect("LukBrowseren.htm")
      End If
    End If
    'ÅbnGodkend()
    btnGodkend.Visible = True
  End Sub

  Private Sub btnGodkend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGodkend.Click
    If btnGodkend.Text = "Godkend forslag" Then
      'opdater med DLU værdier
      txtBladMmPris.Text = txtDLUMmpris.Text
      txtBladMmRabat.Text = txtDLUMmRabat.Text
      txtBladFarvetillæg.Text = txtDLUFarvetillæg.Text
      txtBladFarveRabat.Text = txtDLUFarveRabat.Text
    End If
    Try
      SqlComm.CommandText = "UPDATE tblWEBForespørgselLinjer SET BesvaretAf = " & personID & ", PlaceringUB = " & placeringUB & ", BladMmPris = " & SqlConv(txtBladMmPris.Text) & ", BladMmRabat = " & SqlConv(txtBladMmRabat.Text) & ", BladFarveTillæg = " & SqlConv(txtBladFarvetillæg.Text) & ", BladFarveRabat = " & SqlConv(txtBladFarveRabat.Text) & ", BladBemærkning = '" & Replace(txtBladBemærkning.Text, "'", "''") & "' WHERE (ForespørgselID = " & spurgtID & ") AND (BladID = " & bladID & ")"
      SqlConn.Open()
      SqlComm.ExecuteNonQuery()
    Catch
      Response.Redirect("FejlOpdater.htm")
    Finally
      SqlConn.Close()
    End Try
    Server.Transfer("SendTilKollega.aspx" & Request.Url.Query)
  End Sub

  Private Function SqlConv(ByVal Tal As String) As String
    Return Replace(Tal, ",", ".")
  End Function
End Class
