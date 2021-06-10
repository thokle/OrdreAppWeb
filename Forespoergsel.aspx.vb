Imports System.Data.SqlClient

Partial Class Forespoergsel
  Inherits System.Web.UI.Page
  Protected BladID As Integer
  Protected WithEvents SqlConn As System.Data.SqlClient.SqlConnection
  Protected WithEvents SqlComm As System.Data.SqlClient.SqlCommand
  Protected BladNavn As String
  Dim dr As SqlDataReader
  Protected eMail As String
  Protected PersonNavn As String
  Protected BesvaretAf As String
  Protected PersonID As Integer
  Protected FirstTime As Boolean
  Protected QueryChk As Integer
  Protected spurgtID As Integer
  Dim query(3) As String

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.SqlConn = New System.Data.SqlClient.SqlConnection()
    Me.SqlComm = New System.Data.SqlClient.SqlCommand()
    '
    'SqlConn
    '
        Me.SqlConn.ConnectionString = "data source=AGETOR;initial catalog=dimpSQL;password=hydeliFyt12;persist s" & _
    "ecurity info=True;user id=sa;workstation id=DDDIMP;packet size=4096"
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
      If Request.QueryString.Count > 1 Then
        BladID = CInt(Request.QueryString("BladID"))
        spurgtID = CInt(Request.QueryString("ID"))
        QueryChk = CInt(Request.QueryString("Chk"))
        eMail = CStr(Request.QueryString("eMail"))
      Else
        query = Split(Request.QueryString("Query"), "*")
        BladID = CInt(query(0))
        QueryChk = CInt(query(1))
        spurgtID = CInt(query(2))
        eMail = CStr(query(3))
      End If
      If eMail = "" Then
        Server.Transfer("NoeMail.htm")
      End If
      SqlComm.CommandText = "SELECT Navn FROM tblBlade WHERE (BladId = " & BladID & ")"
      SqlConn.Open()
      dr = SqlComm.ExecuteReader
      dr.Read()
      BladNavn = dr("Navn").ToString
      dr.Close()
      For counter = 1 To Len(BladNavn)
        CheckSum = (CheckSum + (Asc(Mid(BladNavn, counter, 1)))) Mod 255
      Next
      If CheckSum <> QueryChk Then
        Server.Transfer("CheckSumError.htm")
      End If
      SqlComm.CommandText = "SELECT PersonNavn, PersonID FROM tblWEBeMails WHERE (eMail='" & eMail & "')"
      dr = SqlComm.ExecuteReader
      If dr.Read Then
        PersonNavn = dr.GetString(0)
        PersonID = dr.GetInt32(1)
      End If
      'If PersonNavn = "" Then
      '  Server.Transfer("IndtastNavn.aspx" & Request.Url.Query)
      'End If
      dr.Close()

      SqlComm.CommandText = "SELECT tblWEBeMails.PersonNavn FROM tblWEBForesp�rgselLinjer INNER JOIN tblWEBeMails ON tblWEBForesp�rgselLinjer.BesvaretAf = tblWEBeMails.PersonID WHERE (tblWEBForesp�rgselLinjer.Foresp�rgselID = " & spurgtID & ") AND (tblWEBForesp�rgselLinjer.BladID = " & BladID & ")"
      dr = SqlComm.ExecuteReader
      If dr.Read Then
        BesvaretAf = dr.GetString(0)
      End If
      dr.Close()
      If BesvaretAf <> "" Then 'v�s bladets svar
        txtBladMmPris.Visible = True
        txtBladMmRabat.Visible = True
        txtBladFarvetill�g.Visible = True
        txtBladFarveRabat.Visible = True
        lblBem�rkning.Visible = True
        txtBem�rkning.Visible = True
        btnFortryd.Visible = False
        btnOpdater.Visible = True
        btnGodkend.Visible = False
        btn�ndringer.Visible = False
        SqlComm.CommandText = "SELECT BladMmPris, BladMmRabat, BladFarveTill�g, BladFarveRabat, BladBem�rkning FROM tblWEBForesp�rgselLinjer WHERE (Foresp�rgselID = " & spurgtID & ") AND (BladID = " & BladID & ")"
        dr = SqlComm.ExecuteReader()
        dr.Read()
        txtBladMmPris.Text = Format(dr.GetDecimal(0), "###,##0.00")
        txtBladMmRabat.Text = dr.GetDouble(1).ToString()
        txtBladFarvetill�g.Text = Format(dr.GetDecimal(2), "0000")
        txtBladFarveRabat.Text = dr.GetDouble(3).ToString()
        txtBem�rkning.Text = dr.GetString(4)
        dr.Close()
        If BesvaretAf <> PersonNavn Then
          btnOpdater.Visible = False
          lblBesvaretAf.Text = "<h2>Der kan kun �ndres af " & BesvaretAf & "</h2>"
        Else
          lblBesvaretAf.Text = "<h3>Udfyldt af " & PersonNavn & "</h3>"
        End If
        FirstTime = False
      Else 'der er ikke svaret f�r
        lblBesvaretAf.Text = "<h2>Udfyldes af " & PersonNavn & "</h2>"
        FirstTime = True
      End If
      'Hent medieplanhoved
      SqlComm.CommandText = "SELECT tblAnnonc�rer.Annonc�r, tblBrugere.Navn, tblWEBForesp�rgsel.Format, tblWEBForesp�rgsel.AntalFarver, tblMmTyper.Betegnelse, tblWEBForesp�rgsel.Bem�rkning FROM tblWEBForesp�rgsel INNER JOIN tblAnnonc�rer ON tblWEBForesp�rgsel.Annonc�rID = tblAnnonc�rer.Annonc�rID INNER JOIN tblBrugere ON tblWEBForesp�rgsel.KonsulentID = tblBrugere.BrugerID INNER JOIN tblMmTyper ON tblWEBForesp�rgsel.Placering = tblMmTyper.mmType WHERE(tblWEBForesp�rgsel.Foresp�rgselID = " & spurgtID & ")"
      dr = SqlComm.ExecuteReader
      dr.Read()
      lblInfo.Text = "<b>Kunde : </b>" & dr.GetString(0) & "<BR><b>Konsulent : </b>" & dr.GetString(1) & "<br><b>Format : </b>" & dr.GetString(2) & "<br><b>Farver : </b>" & dr.GetByte(3) & "<br><b>Placering : </b>" & dr.GetString(4) & "<br><b>Bem�rkning : </b>" & dr.GetString(5)
      dr.Close()
      'Hent prisforeslag
      SqlComm.CommandText = "SELECT DLUMmPris, DLUMmRabat, DLUFarveTill�g, DLUFarveRabat FROM tblWEBForesp�rgselLinjer WHERE (Foresp�rgselID = " & spurgtID & ") AND (BladID = " & BladID & ")"
      dr = SqlComm.ExecuteReader
      dr.Read()
      txtDLUMmpris.Text = Format(dr.GetDecimal(0), "###,##0.00")
      txtDLUMmRabat.Text = dr.GetDouble(1).ToString()
      txtDLUFarvetill�g.Text = Format(dr.GetDecimal(2), "0000")
      txtDLUFarveRabat.Text = dr.GetDouble(3).ToString()

      SqlConn.Close()
      ViewState("BladNavn") = BladNavn
      ViewState("BladID") = BladID
      ViewState("PersonNavn") = PersonNavn
      ViewState("BesvaretAf") = BesvaretAf
      ViewState("PersonID") = PersonID
      ViewState("spurgtID") = spurgtID
      ViewState("FirstTime") = FirstTime
      Me.DataBind()
    Else
      BladNavn = CStr(ViewState("BladNavn"))
      BladID = CInt(ViewState("BladID"))
      PersonNavn = CStr(ViewState("PersonNavn"))
      BesvaretAf = CStr(ViewState("BesvaretAf"))
      PersonID = CInt(ViewState("PersonID"))
      spurgtID = CInt(ViewState("spurgtID"))
      FirstTime = CBool(ViewState("FirstTime"))
    End If
  End Sub

  Private Sub btn�ndringer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn�ndringer.Click
    txtBladMmPris.Visible = True
    txtBladMmRabat.Visible = True
    txtBladFarvetill�g.Visible = True
    txtBladFarveRabat.Visible = True
    lblBem�rkning.Visible = True
    txtBem�rkning.Visible = True
    btnFortryd.Visible = True
    btnOpdater.Visible = True
    btnGodkend.Visible = False
    btn�ndringer.Visible = False
  End Sub

  Private Sub btnFortryd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFortryd.Click
    txtBladMmPris.Visible = False
    txtBladMmRabat.Visible = False
    txtBladFarvetill�g.Visible = False
    txtBladFarveRabat.Visible = False
    lblBem�rkning.Visible = False
    txtBem�rkning.Visible = False
    btnFortryd.Visible = False
    btnOpdater.Visible = False
    btnGodkend.Visible = True
    btn�ndringer.Visible = True
  End Sub

  Private Sub btnGodkend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGodkend.Click
    txtBladMmPris.Text = txtDLUMmpris.Text
    txtBladMmRabat.Text = txtDLUMmRabat.Text
    txtBladFarvetill�g.Text = txtDLUFarvetill�g.Text
    txtBladFarveRabat.Text = txtDLUFarveRabat.Text
    OpdaterData()
  End Sub

  Private Function SqlConv(ByVal Tal As String) As String
    Return Replace(Tal, ",", ".")
  End Function

  Private Sub btnOpdater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpdater.Click
    OpdaterData()
  End Sub

  Private Sub OpdaterData()
    Try
      SqlComm.CommandText = "UPDATE tblWEBForesp�rgselLinjer SET BesvaretAf = " & PersonID & ", BladMmPris = " & SqlConv(txtBladMmPris.Text) & ", BladMmRabat = " & SqlConv(txtBladMmRabat.Text) & ", BladFarveTill�g = " & SqlConv(txtBladFarvetill�g.Text) & ", BladFarveRabat = " & SqlConv(txtBladFarveRabat.Text) & ", BladBem�rkning = '" & txtBem�rkning.Text & "' WHERE (Foresp�rgselID = " & spurgtID & ") AND (BladID = " & BladID & ")"
      SqlConn.Open()
      SqlComm.ExecuteNonQuery()
      If FirstTime Then
        SqlComm.CommandText = "UPDATE tblWEBForesp�rgsel SET AntalSvar = AntalSvar + 1 WHERE (Foresp�rgselID = " & spurgtID & ")"
        SqlComm.ExecuteNonQuery()
      End If
    Catch
      Response.Redirect("FejlOpdater.htm")
    Finally
      SqlConn.Close()
    End Try
    Response.Redirect("Afslut.htm")
  End Sub
End Class
