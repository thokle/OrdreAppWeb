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
      lblTilBlad.Text = "Prisforesp�rgsel til " & bladNavn
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

      SqlComm.CommandText = "SELECT tblWEBeMails.PersonNavn, tblWEBeMails.eMail FROM tblWEBForesp�rgselLinjer INNER JOIN tblWEBeMails ON tblWEBForesp�rgselLinjer.BesvaretAf = tblWEBeMails.PersonID WHERE (tblWEBForesp�rgselLinjer.Foresp�rgselID = " & spurgtID & ") AND (tblWEBForesp�rgselLinjer.BladID = " & bladID & ")"
      dr = SqlComm.ExecuteReader
      If dr.Read Then
        besvaretAf = dr.GetString(0)
      End If
      dr.Close()
      If besvaretAf <> "" Then 'v�s bladets svar
        lbl�ndring.Visible = True
        lbl�ndring.Text = "Vores svar"
        lblBladmmpris.Visible = True
        lblBladmmRabat.Visible = True
        lblBladfarvetill�g.Visible = True
        lblBladfarverabat.Visible = True
        txtBladMmPris.Visible = True
        txtBladMmRabat.Visible = True
        txtBladFarvetill�g.Visible = True
        txtBladFarveRabat.Visible = True
        lblBladBem�rkning.Visible = True
        lblBladBem�rkning.Text = "Bem�rkning til svar"
        txtBladBem�rkning.Visible = True
        '      lblPlaceringUB.Style("Top") = 528
        '     PlaceringTable.Style("Top") = 548
        '        lblVigtigt.Style("Top") = 656
        '        lblVigtigt2.Style("Top") = 656
        '       lblMVH.Style("Top") = 712
        btnGodkend.Text = "Godkend �ndringer"
        btn�ndringer.Text = "Fortryd �ndringer"
        btnGodkend.Visible = False
        'btn�ndringer.Visible = False
        SqlComm.CommandText = "SELECT PlaceringUB, BladMmPris, BladMmRabat, BladFarveTill�g, BladFarveRabat, BladBem�rkning FROM tblWEBForesp�rgselLinjer WHERE (Foresp�rgselID = " & spurgtID & ") AND (BladID = " & bladID & ")"
        dr = SqlComm.ExecuteReader()
        dr.Read()
        placeringUB = dr.GetByte(0)
        txtBladMmPris.Text = Format(dr.GetDecimal(1), "###,##0.00")
        txtBladMmRabat.Text = dr.GetDouble(2).ToString()
        indFarve = dr.GetDecimal(3)
        If indFarve < 20 Then
          txtBladFarvetill�g.Text = Format(indFarve, "###,##0.00")
        Else
          txtBladFarvetill�g.Text = Format(indFarve, "#.###")
        End If
        txtBladFarveRabat.Text = dr.GetDouble(4).ToString()
        txtBladBem�rkning.Text = dr.GetString(5)
        dr.Close()
        Select Case placeringUB
          Case 1
            chk357.Checked = True
          Case 2
            chkHsFm.Checked = True
          Case 3
            chkH�jSide.Checked = True
          Case 4
            chkNej.Checked = True
        End Select
        If besvaretAf <> personNavn Then
          lblBesvaretAf.Text = "Der kan kun �ndres af " & besvaretAf
          chk357.Enabled = False
          chkHsFm.Enabled = False
          chkH�jSide.Enabled = False
          chkNej.Enabled = False
          txtBladMmPris.Enabled = False
          txtBladMmRabat.Enabled = False
          txtBladFarvetill�g.Enabled = False
          txtBladFarveRabat.Enabled = False
          txtBladBem�rkning.Enabled = False
          btn�ndringer.Text = "Luk siden"
        Else
          lblBesvaretAf.Text = "Udfyldt af " & personNavn
          btnGodkend.Visible = True
          'btn�ndringer.Visible = True
          '�bnGodkend()
        End If
      Else 'der er ikke svaret f�r
        lblBesvaretAf.Text = "Udfyldes af " & personNavn
        lbl�ndring.Visible = False
        lblBladmmpris.Visible = False
        lblBladmmRabat.Visible = False
        lblBladfarvetill�g.Visible = False
        lblBladfarverabat.Visible = False
        txtBladMmPris.Visible = False
        txtBladMmRabat.Visible = False
        txtBladFarvetill�g.Visible = False
        txtBladFarveRabat.Visible = False
        lblBladBem�rkning.Visible = False
        txtBladBem�rkning.Visible = False
        '    lblMarker.Style("Top") = 420
        '    lblPlaceringUB.Style("Top") = 348
        '    PlaceringTable.Style("Top") = 368
        '    lblVigtigt.Style("Top") = 476
        '    lblVigtigt2.Style("Top") = 476
        '    lblMVH.Style("Top") = 532
        btnGodkend.Visible = True
      End If
      'Hent medieplanhoved
      SqlComm.CommandText = "SELECT NavisionContact.Name, Salesperson.Name AS Navn, tblWEBForesp�rgsel.Format, tblWEBForesp�rgsel.AntalFarver, tblPlacering.Betegnelse, tblWEBForesp�rgsel.Mediebureau, tblWEBForesp�rgsel.AntalIndrykninger, tblWEBForesp�rgsel.Bem�rkning, tblWEBForesp�rgsel.PlaceringUB FROM tblWEBForesp�rgsel INNER JOIN NavisionContact ON tblWEBForesp�rgsel.Annonc�rNo_ = NavisionContact.No_ INNER JOIN tblPlacering ON tblWEBForesp�rgsel.PlaceringID = tblPlacering.PlaceringID INNER JOIN Salesperson ON tblWEBForesp�rgsel.KonsulentCode = Salesperson.Code WHERE (tblWEBForesp�rgsel.Foresp�rgselID = " & spurgtID & ")"
      dr = SqlComm.ExecuteReader
      dr.Read()
      visAnnonc�r.Text = dr.GetString(0)
      lblMVH.Text = "Med venlig hilsen<br>" & dr.GetString(1)
      visFormat.Text = dr.GetString(2)
      visFarver.Text = dr.GetByte(3)
      visPlacering.Text = dr.GetString(4)
      visMediebureau.Text = dr.GetString(5)
      visAntalIndrykn.Text = dr.GetByte(6)
      visBem�rkning.Text = dr.GetString(7)
      VisPlaceringUB = dr.GetBoolean(8)
      dr.Close()
      If Not VisPlaceringUB Then
        PlaceringTable.Visible = False
        lblMarker.Visible = False
        lblPlaceringUB.Visible = False
      End If
      'Hent prisforeslag
      SqlComm.CommandText = "SELECT DLUMmPris, DLUMmRabat, DLUFarveTill�g, DLUFarveRabat FROM tblWEBForesp�rgselLinjer WHERE (Foresp�rgselID = " & spurgtID & ") AND (BladID = " & bladID & ")"
      dr = SqlComm.ExecuteReader
      dr.Read()
      txtDLUMmpris.Text = Format(dr.GetDecimal(0), "###,##0.00")
      txtDLUMmRabat.Text = dr.GetDouble(1).ToString()
      indFarve = dr.GetDecimal(2)
      If indFarve < 20 Then
        txtDLUFarvetill�g.Text = Format(indFarve, "###,##0.00")
      Else
        txtDLUFarvetill�g.Text = Format(indFarve, "#.###")
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
      If btn�ndringer.Text <> "�ndringer til forslag" Then
        '  lblPlaceringUB.Style("Top") = 528
        '  PlaceringTable.Style("Top") = 548
        '  lblVigtigt.Style("Top") = 656
        '  lblVigtigt2.Style("Top") = 656
        '  lblMVH.Style("Top") = 712
        '  lblMarker.Style("Top") = 600
        lbl�ndring.Visible = True
        lblBladmmpris.Visible = True
        lblBladmmRabat.Visible = True
        lblBladfarvetill�g.Visible = True
        lblBladfarverabat.Visible = True
        txtBladMmPris.Visible = True
        txtBladMmRabat.Visible = True
        txtBladFarvetill�g.Visible = True
        txtBladFarveRabat.Visible = True
        lblBladBem�rkning.Visible = True
        txtBladBem�rkning.Visible = True
      Else
        '    lblPlaceringUB.Style("Top") = 348
        '    PlaceringTable.Style("Top") = 368
        '    lblVigtigt.Style("Top") = 476
        '    lblVigtigt2.Style("Top") = 476
        '    lblMVH.Style("Top") = 532
        '    lblMarker.Style("Top") = 420
        lbl�ndring.Visible = False
        lblBladmmpris.Visible = False
        lblBladmmRabat.Visible = False
        lblBladfarvetill�g.Visible = False
        lblBladfarverabat.Visible = False
        txtBladMmPris.Visible = False
        txtBladMmRabat.Visible = False
        txtBladFarvetill�g.Visible = False
        txtBladFarveRabat.Visible = False
        lblBladBem�rkning.Visible = False
        txtBladBem�rkning.Visible = False
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
  '    chkH�jSide.Checked = False
  '    chkNej.Checked = False
  '    PlaceringUB = 1
  '  End If
  '  �bnGodkend()
  'End Sub

  'Private Sub chkHsFm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHsFm.CheckedChanged
  '  If chkHsFm.Checked = True Then
  '    chk357.Checked = False
  '    chkH�jSide.Checked = False
  '    chkNej.Checked = False
  '    PlaceringUB = 2
  '  End If
  '  �bnGodkend()
  'End Sub

  'Private Sub chkH�jSide_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkH�jSide.CheckedChanged
  '  If chkH�jSide.Checked = True Then
  '    chk357.Checked = False
  '    chkHsFm.Checked = False
  '    chkNej.Checked = False
  '    PlaceringUB = 3
  '  End If
  '  �bnGodkend()
  'End Sub

  'Private Sub chkNej_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNej.CheckedChanged
  '  If chkNej.Checked = True Then
  '    chk357.Checked = False
  '    chkHsFm.Checked = False
  '    chkH�jSide.Checked = False
  '    PlaceringUB = 4
  '  End If
  '  �bnGodkend()
  'End Sub

  'Private Sub �bnGodkend()
  '  If VisPlaceringUB Then
  '    If (chk357.Checked Or chkHsFm.Checked Or chkH�jSide.Checked Or chkNej.Checked) = True Then
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

  Private Sub btn�ndringer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn�ndringer.Click
    If btn�ndringer.Text = "�ndringer til forslag" Then
      lbl�ndring.Visible = True
      lblBladmmpris.Visible = True
      lblBladmmRabat.Visible = True
      lblBladfarvetill�g.Visible = True
      lblBladfarverabat.Visible = True
      txtBladMmPris.Visible = True
      txtBladMmRabat.Visible = True
      txtBladFarvetill�g.Visible = True
      txtBladFarveRabat.Visible = True
      lblBladBem�rkning.Visible = True
      txtBladBem�rkning.Visible = True
      '  lblPlaceringUB.Style("Top") = 528
      '  PlaceringTable.Style("Top") = 548
      '  lblVigtigt.Style("Top") = 656
      '  lblVigtigt2.Style("Top") = 656
      '  lblMVH.Style("Top") = 712
      '  lblMarker.Style("Top") = 600
      btnGodkend.Text = "Godkend �ndringer"
      btn�ndringer.Text = "Fortryd �ndringer"
      txtBladMmPris.Text = txtDLUMmpris.Text
      txtBladMmRabat.Text = txtDLUMmRabat.Text
      txtBladFarvetill�g.Text = txtDLUFarvetill�g.Text
      txtBladFarveRabat.Text = txtDLUFarveRabat.Text
    Else
      If btn�ndringer.Text <> "Luk siden" Then
        lbl�ndring.Visible = False
        lblBladmmpris.Visible = False
        lblBladmmRabat.Visible = False
        lblBladfarvetill�g.Visible = False
        lblBladfarverabat.Visible = False
        txtBladMmPris.Visible = False
        txtBladMmRabat.Visible = False
        txtBladFarvetill�g.Visible = False
        txtBladFarveRabat.Visible = False
        lblBladBem�rkning.Visible = False
        txtBladBem�rkning.Visible = False
        '   lblPlaceringUB.Style("Top") = 348
        '   PlaceringTable.Style("Top") = 368
        '   lblVigtigt.Style("Top") = 476
        '   lblVigtigt2.Style("Top") = 476
        '   lblMVH.Style("Top") = 532
        '   lblMarker.Style("Top") = 420
        btnGodkend.Text = "Godkend forslag"
        btn�ndringer.Text = "�ndringer til forslag"
      Else
        Response.Redirect("LukBrowseren.htm")
      End If
    End If
    '�bnGodkend()
    btnGodkend.Visible = True
  End Sub

  Private Sub btnGodkend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGodkend.Click
    If btnGodkend.Text = "Godkend forslag" Then
      'opdater med DLU v�rdier
      txtBladMmPris.Text = txtDLUMmpris.Text
      txtBladMmRabat.Text = txtDLUMmRabat.Text
      txtBladFarvetill�g.Text = txtDLUFarvetill�g.Text
      txtBladFarveRabat.Text = txtDLUFarveRabat.Text
    End If
    Try
      SqlComm.CommandText = "UPDATE tblWEBForesp�rgselLinjer SET BesvaretAf = " & personID & ", PlaceringUB = " & placeringUB & ", BladMmPris = " & SqlConv(txtBladMmPris.Text) & ", BladMmRabat = " & SqlConv(txtBladMmRabat.Text) & ", BladFarveTill�g = " & SqlConv(txtBladFarvetill�g.Text) & ", BladFarveRabat = " & SqlConv(txtBladFarveRabat.Text) & ", BladBem�rkning = '" & Replace(txtBladBem�rkning.Text, "'", "''") & "' WHERE (Foresp�rgselID = " & spurgtID & ") AND (BladID = " & bladID & ")"
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
