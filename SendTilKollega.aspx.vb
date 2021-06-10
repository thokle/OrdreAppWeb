Imports System.Data.SqlClient
Imports System.Diagnostics.Debug
Imports System.Web.Mail

Partial Class SendTilKollega
  Inherits System.Web.UI.Page
  Protected WithEvents SqlConn As System.Data.SqlClient.SqlConnection
  Protected WithEvents SqlComm As System.Data.SqlClient.SqlCommand

  Protected BladID As Integer
  Protected QueryChk As Integer
  Protected spurgtID As Integer
  Protected eMail As String
  Protected dr As SqlDataReader
  Protected BladNavn As String
  Protected EmailTilbud As String
  Protected query(3) As String
  Protected emails() As String
  Protected PersonID As Integer
  Protected PersonNavn As String

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
      Dim i As Integer
      Dim fundne As Integer

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

      SqlComm.CommandText = "SELECT Navn, PrisforespørgselEmails FROM tblBladStamdata WHERE (BladID = " & BladID & ")"
      SqlConn.Open()
      dr = SqlComm.ExecuteReader
      dr.Read()
      BladNavn = dr("Navn").ToString
      EmailTilbud = dr("PrisforespørgselEmails").ToString
      dr.Close()
      For counter = 1 To Len(BladNavn)
        CheckSum = (CheckSum + (Asc(Mid(BladNavn, counter, 1)))) Mod 255
      Next
      If CheckSum <> QueryChk Then
        Server.Transfer("CheckSumError.htm")
      End If

      SqlComm.CommandText = "SELECT PersonNavn, eMail FROM tblWEBeMails WHERE (PersonID=" & PersonID & ")"
      dr = SqlComm.ExecuteReader
      If dr.Read Then
        PersonNavn = dr.GetString(0)
        eMail = dr.GetString(1)
      End If
      If PersonNavn = "" Then
        Server.Transfer("IndtastNavn.aspx" & Request.Url.Query)
      End If
      dr.Close()

      'emails = Split(EmailTilbud, ";")
      'fundne = 0
      'For i = 0 To UBound(emails)
      '  If eMail <> emails(i) Then
      '    fundne = fundne + 1
      '    Select Case fundne
      '      Case 1
      '        txtEmail1.Text = emails(i)
      '        txtEmail1_TextChanged(New System.Object(), New System.EventArgs())
      '      Case 2
      '        txtEmail2.Text = emails(i)
      '        txtEmail2_TextChanged(New System.Object(), New System.EventArgs())
      '      Case 3
      '        txtEmail3.Text = emails(i)
      '        txtEmail3_TextChanged(New System.Object(), New System.EventArgs())
      '      Case 4
      '        txtEmail4.Text = emails(i)
      '        txtEmail4_TextChanged(New System.Object(), New System.EventArgs())
      '    End Select
      '  End If
      'Next i
      ViewState("BladNavn") = BladNavn
      ViewState("BladID") = BladID
      ViewState("PersonNavn") = PersonNavn
      ViewState("PersonID") = PersonID
      ViewState("spurgtID") = spurgtID
      ViewState("eMail") = eMail
    Else
      BladNavn = CStr(ViewState("BladNavn"))
      BladID = CInt(ViewState("BladID"))
      PersonNavn = CStr(ViewState("PersonNavn"))
      PersonID = CInt(ViewState("PersonID"))
      spurgtID = CInt(ViewState("spurgtID"))
      eMail = CStr(ViewState("eMail"))
    End If
  End Sub

  Private Sub btnAfslut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAfslut.Click
    Response.Redirect("LukBrowseren.htm")
  End Sub

  Private Sub txtEmail1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmail1.TextChanged
    regEx1.Validate()
    If txtEmail1.Text <> "" And regEx1.IsValid Then
      btnSend.Enabled = True
      txtEmail2.Enabled = True
    Else
      btnSend.Enabled = False
      txtEmail2.Enabled = False
    End If
  End Sub

  Private Sub txtEmail2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmail2.TextChanged
    regEx2.Validate()
    If txtEmail2.Text <> "" And regEx2.IsValid Then
      btnSend.Enabled = True
      txtEmail3.Enabled = True
    Else
      btnSend.Enabled = False
      txtEmail3.Enabled = False
    End If
  End Sub

  Private Sub txtEmail3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmail3.TextChanged
    regEx3.Validate()
    If txtEmail3.Text <> "" And regEx3.IsValid Then
      btnSend.Enabled = True
      txtEmail4.Enabled = True
    Else
      btnSend.Enabled = False
      txtEmail4.Enabled = False
    End If
  End Sub

  Private Sub txtEmail4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmail4.TextChanged
    regEx4.Validate()
    If txtEmail4.Text <> "" And regEx4.IsValid Then
      btnSend.Enabled = True
      txtEmail5.Enabled = True
    Else
      btnSend.Enabled = False
      txtEmail5.Enabled = False
    End If
  End Sub

  Private Sub txtEmail5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmail5.TextChanged
    regEx5.Validate()
    If txtEmail5.Text <> "" And regEx5.IsValid Then
      btnSend.Enabled = True
      txtEmail6.Enabled = True
    Else
      btnSend.Enabled = False
      txtEmail6.Enabled = False
    End If
  End Sub

  Private Sub txtEmail6_TextChanged(sender As Object, e As System.EventArgs) Handles txtEmail6.TextChanged
    regEx6.Validate()
    If txtEmail6.Text <> "" And regEx6.IsValid Then
      btnSend.Enabled = True
      txtEmail7.Enabled = True
    Else
      btnSend.Enabled = False
      txtEmail7.Enabled = False
    End If
  End Sub

  Private Sub txtEmail7_TextChanged(sender As Object, e As System.EventArgs) Handles txtEmail7.TextChanged
    regEx7.Validate()
    If txtEmail7.Text <> "" And regEx7.IsValid Then
      btnSend.Enabled = True
      txtEmail8.Enabled = True
    Else
      btnSend.Enabled = False
      txtEmail8.Enabled = False
    End If
  End Sub

  Private Sub txtEmail8_TextChanged(sender As Object, e As System.EventArgs) Handles txtEmail8.TextChanged
    regEx8.Validate()
    If txtEmail8.Text <> "" And regEx8.IsValid Then
      btnSend.Enabled = True
      txtEmail9.Enabled = True
    Else
      btnSend.Enabled = False
      txtEmail9.Enabled = False
    End If
  End Sub

  Private Sub txtEmail9_TextChanged(sender As Object, e As System.EventArgs) Handles txtEmail9.TextChanged
    regEx9.Validate()
    If txtEmail9.Text <> "" And regEx9.IsValid Then
      btnSend.Enabled = True
      txtEmail10.Enabled = True
    Else
      btnSend.Enabled = False
      txtEmail10.Enabled = False
    End If
  End Sub

  Private Sub txtEmail10_TextChanged(sender As Object, e As System.EventArgs) Handles txtEmail10.TextChanged
    regEx10.Validate()
    If txtEmail10.Text <> "" And regEx10.IsValid Then
      btnSend.Enabled = True
    Else
      btnSend.Enabled = False
    End If
  End Sub

  Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
    If Page.IsValid Then
      'Sendekode her
      Dim eMailMSG As New System.Net.Mail.SmtpClient
      Dim sendHTML As String
      Dim Annoncør, MVH, FormatString, Farver, Placering, Mediebureau, AntalIndrykn, Bemærkning As String
      Dim BesvaretAf As String = ""
      Dim BladMmPris, BladMmRabat, BladFarvetillæg, BladFarveRabat, BladBemærkning As String
      Dim indFarve As Double
      Dim PlaceringUB As Integer
      Dim i As Integer

      SqlComm.CommandText = "SELECT tblWEBeMails.PersonNavn, tblWEBeMails.eMail FROM tblWEBForespørgselLinjer INNER JOIN tblWEBeMails ON tblWEBForespørgselLinjer.BesvaretAf = tblWEBeMails.PersonID WHERE (tblWEBForespørgselLinjer.ForespørgselID = " & spurgtID & ") AND (tblWEBForespørgselLinjer.BladID = " & BladID & ")"
      SqlConn.Open()
      dr = SqlComm.ExecuteReader
      If dr.Read Then
        BesvaretAf = dr.GetString(0)
      End If
      dr.Close()
      'Hent medieplanhoved
      '     SqlComm.CommandText = "SELECT tblAnnoncører.Annoncør, tblBrugere.Navn, tblWEBForespørgsel.Format, tblWEBForespørgsel.AntalFarver, tblMmTyper.Betegnelse, tblWEBForespørgsel.Mediebureau, tblWEBForespørgsel.AntalIndrykninger, tblWEBForespørgsel.Bemærkning FROM tblWEBForespørgsel INNER JOIN tblAnnoncører ON tblWEBForespørgsel.AnnoncørID = tblAnnoncører.AnnoncørID INNER JOIN tblBrugere ON tblWEBForespørgsel.KonsulentID = tblBrugere.BrugerID INNER JOIN tblMmTyper ON tblWEBForespørgsel.Placering = tblMmTyper.mmType WHERE(tblWEBForespørgsel.ForespørgselID = " & spurgtID & ")"
      SqlComm.CommandText = "SELECT NavisionContact.Name, Salesperson.Name AS Navn, tblWEBForespørgsel.Format, tblWEBForespørgsel.AntalFarver, tblPlacering.Betegnelse, tblWEBForespørgsel.Mediebureau, tblWEBForespørgsel.AntalIndrykninger, tblWEBForespørgsel.Bemærkning FROM tblWEBForespørgsel INNER JOIN NavisionContact ON tblWEBForespørgsel.AnnoncørNo_ = NavisionContact.No_ INNER JOIN tblPlacering ON tblWEBForespørgsel.PlaceringID = tblPlacering.PlaceringID INNER JOIN Salesperson ON tblWEBForespørgsel.KonsulentCode = Salesperson.Code WHERE (tblWEBForespørgsel.ForespørgselID = " & spurgtID & ")"
      dr = SqlComm.ExecuteReader
      dr.Read()
      Annoncør = dr.GetString(0)
      MVH = "Med venlig hilsen<br>" & dr.GetString(1)
      FormatString = dr.GetString(2)
      Farver = dr.GetByte(3)
      Placering = dr.GetString(4)
      Mediebureau = dr.GetString(5)
      AntalIndrykn = dr.GetByte(6)
      Bemærkning = dr.GetString(7)
      dr.Close()

      'Hent prisforeslag
      SqlComm.CommandText = "SELECT PlaceringUB, BladMmPris, BladMmRabat, BladFarveTillæg, BladFarveRabat, BladBemærkning FROM tblWEBForespørgselLinjer WHERE (ForespørgselID = " & spurgtID & ") AND (BladID = " & BladID & ")"
      dr = SqlComm.ExecuteReader()
      dr.Read()
      PlaceringUB = dr.GetByte(0)
      BladMmPris = Format(dr.GetDecimal(1), "###,##0.00")
      BladMmRabat = dr.GetDouble(2).ToString()
      indFarve = dr.GetDecimal(3)
      If indFarve < 20 Then
        BladFarvetillæg = Format(indFarve, "###,##0.00")
      Else
        BladFarvetillæg = Format(indFarve, "#.###")
      End If
      BladFarveRabat = dr.GetDouble(4).ToString()
      BladBemærkning = dr.GetString(5)
      dr.Close()
      'sendHTML = "<HTML><HEAD><TITLE>Afgivet tilbud.</TITLE><META http-equiv=" + Chr(34) + "Content-Type" + Chr(34) + " content=" + Chr(34) + "text/html; charset=windows-1250" + Chr(34) + "></HEAD><BODY>"
      'sendHTML = sendHTML + "<B>Vi har afgivet følgende tilbud til DLU.<BR>"
      'sendHTML = "<B>Vi har afgivet følgende tilbud til DLU.<BR>"
      'sendHTML = sendHTML + "Tilbuddet er udfyldt af " + BesvaretAf + "</B><BR><BR>"
      sendHTML = "Vi har afgivet følgende tilbud til DLU." & vbCrLf
      sendHTML = sendHTML & "Tilbuddet er udfyldt af " & BesvaretAf & vbCrLf & vbCrLf
      sendHTML = sendHTML & "Annoncør: " & Annoncør & vbCrLf
      sendHTML = sendHTML & "Mediebureau: " & Mediebureau & vbCrLf
      sendHTML = sendHTML & "Format: " & FormatString & vbCrLf
      sendHTML = sendHTML & "Farver: " & Farver & vbCrLf
      sendHTML = sendHTML & "Placering: " & Placering & vbCrLf
      sendHTML = sendHTML & "Antal indrykninger: " & AntalIndrykn & vbCrLf
      sendHTML = sendHTML & vbCrLf
      sendHTML = sendHTML & "Bemærkninger: " & Bemærkning & vbCrLf & vbCrLf & BladBemærkning & vbCrLf & vbCrLf & vbCrLf
      sendHTML = sendHTML & "Tilbud:" & vbCrLf
      sendHTML = sendHTML & "kr./mm.: " & BladMmPris & vbCrLf
      sendHTML = sendHTML & "mm. rabat: " & BladMmRabat & vbCrLf
      sendHTML = sendHTML & "farvetillæg: " & BladFarvetillæg & vbCrLf
      sendHTML = sendHTML & "farve rabat: " & BladFarveRabat & vbCrLf
      'sendHTML = sendHTML + "<TABLE cellspacing=" + Chr(34) + "0" + Chr(34) + " cellpadding=" + Chr(34) + "0" + Chr(34) + " width=" + Chr(34) + "90%" + Chr(34) + " border=" + Chr(34) + "0" + Chr(34) + ">"
      'sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
      'sendHTML = sendHTML + "<TD width=" + Chr(34) + "15%" + Chr(34) + ">Annoncør</TD>"
      'sendHTML = sendHTML + "<TD width=" + Chr(34) + "85%" + Chr(34) + ">" + Annoncør + "</TD></TR>"
      'sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
      'sendHTML = sendHTML + "<TD>Mediebureau</TD><TD>" + Mediebureau + "</TD></TR>"
      'sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
      'sendHTML = sendHTML + "<TD>Format</TD><TD>" + FormatString + "</TD></TR>"
      'sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
      'sendHTML = sendHTML + "<TD>Farver</TD><TD>" + Farver + "</TD></TR>"
      'sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
      'sendHTML = sendHTML + "<TD>Placering</TD><TD>" + Placering + "</TD></TR>"
      'sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
      'sendHTML = sendHTML + "<TD>Antal indrykn.</TD><TD>" + AntalIndrykn + "</TD></TR>"
      'sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + "><TD><BR></TD><TD></TD></TR>"
      'sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
      'sendHTML = sendHTML + "<TD>Bemærkninger</TD><TD>" + Bemærkning + "<br><br>" + BladBemærkning + "</TD></TR>"
      'sendHTML = sendHTML + "</TABLE><BR><BR>"
      'sendHTML = sendHTML + "<TABLE cellpadding=" + Chr(34) + "0" + Chr(34) + " cellspacing=" + Chr(34) + "0" + Chr(34) + " border=" + Chr(34) + "0" + Chr(34) + " width=" + Chr(34) + "60%" + Chr(34) + ">"
      'sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
      'sendHTML = sendHTML + "<TD width=" + Chr(34) + "32%" + Chr(34) + "><B>Tilbud</B></TD>"
      'sendHTML = sendHTML + "<TD width=" + Chr(34) + "17%" + Chr(34) + "><B>kr./mm</B></TD>"
      'sendHTML = sendHTML + "<TD width=" + Chr(34) + "17%" + Chr(34) + "><B>rabat</B></TD>"
      'sendHTML = sendHTML + "<TD width=" + Chr(34) + "17%" + Chr(34) + "><B>farvetillæg</B></TD>"
      'sendHTML = sendHTML + "<TD width=" + Chr(34) + "17%" + Chr(34) + "><B>rabat</B></TD></TR>"
      'sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + "><TD></TD>"
      'sendHTML = sendHTML + "<TD>" + BladMmPris + "</TD>"
      'sendHTML = sendHTML + "<TD>" + BladMmRabat + "</TD>"
      'sendHTML = sendHTML + "<TD>" + BladFarvetillæg + "</TD>"
      'sendHTML = sendHTML + "<TD>" + BladFarveRabat + "</TD></TR></TABLE><BR>"
      '   sendHTML = sendHTML + "<B>Der ydes placering u/b</B>"
      'sendHTML = sendHTML + "<TABLE cellspacing=" + Chr(34) + "0" + Chr(34) + " cellpadding=" + Chr(34) + "0" + Chr(34) + " width=" + Chr(34) + "60%" + Chr(34) + " border=" + Chr(34) + "1" + Chr(34) + ">"
      'sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
      'sendHTML = sendHTML + "<TD width=" + Chr(34) + "32%" + Chr(34) + "></TD>"
      'sendHTML = sendHTML + "<TD width=" + Chr(34) + "17%" + Chr(34) + " align=" + Chr(34) + "middle" + Chr(34) + ">side 3,5,7</TD>"
      'sendHTML = sendHTML + "<TD width=" + Chr(34) + "17%" + Chr(34) + " align=" + Chr(34) + "middle" + Chr(34) + ">Høj. side f. midt</TD>"
      'sendHTML = sendHTML + "<TD width=" + Chr(34) + "17%" + Chr(34) + " align=" + Chr(34) + "middle" + Chr(34) + ">Høj. side</TD>"
      'sendHTML = sendHTML + "<TD width=" + Chr(34) + "17%" + Chr(34) + " align=" + Chr(34) + "middle" + Chr(34) + ">nej</TD></TR>"
      'sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + "><TD><br></TD>"
      'While i < PlaceringUB - 1
      '  sendHTML = sendHTML + "<TD align=" + Chr(34) + "middle" + Chr(34) + "><br></TD>"
      '  i = i + 1
      'End While
      'sendHTML = sendHTML + "<TD align=" + Chr(34) + "middle" + Chr(34) + ">X</TD>"
      'While i < 3
      '  sendHTML = sendHTML + "<TD align=" + Chr(34) + "middle" + Chr(34) + "><br></TD>"
      '  i = i + 1
      'End While
      'sendHTML = sendHTML + "</TR></TABLE><BR>"
      'sendHTML = sendHTML + "<BR>"
      'sendHTML = sendHTML + "<TABLE cellspacing=" + Chr(34) + "0" + Chr(34) + " cellpadding=" + Chr(34) + "0" + Chr(34) + " width=" + Chr(34) + "90%" + Chr(34) + " border=" + Chr(34) + "0" + Chr(34) + ">"
      'sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
      'sendHTML = sendHTML + "<TD width=" + Chr(34) + "21%" + Chr(34) + "><B>Vigtigt</B></TD>"
      'sendHTML = sendHTML + "<TD><B>Det er vigtigt, at vi overholder de afgivne priser, hvis vi kontaktes af "
      'sendHTML = sendHTML + "annoncøren eller mediebureauet, når/hvis de kontakter os direkte for at "
      'sendHTML = sendHTML + "forhandle prisen ned.</B></TD></TR></TABLE></BODY></HTML>"
      sendHTML = sendHTML & vbCrLf & vbCrLf
      sendHTML = sendHTML & "Vigtigt!!" & vbCrLf
      sendHTML = sendHTML & "Det er vigtigt, at vi overholder de afgivne priser, hvis vi kontaktes af " & vbCrLf
      sendHTML = sendHTML & "annoncøren eller mediebureauet, når/hvis de kontakter os direkte for at " & vbCrLf
      sendHTML = sendHTML & "forhandle prisen ned."

      'eMailMSG.Subject = "Vi har afgivet dette tilbud til " + Annoncør
      'eMailMSG.To.Add(txtEmail1.Text)
      'eMailMSG.Body = sendHTML
      'eMailMSG.BodyFormat = System.Net.Mail.
      'SmtpMail.SmtpServer = "192.168.100.44"

      eMailMSG.Host = "10.10.5.12"
      Try
        eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail1.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML)
      Catch
      End Try
      If txtEmail2.Text <> "" Then
        Try
          eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail2.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML)
        Catch
        End Try
      End If
      If txtEmail3.Text <> "" Then
        Try
          eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail3.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML)
        Catch
        End Try
      End If
      If txtEmail4.Text <> "" Then
        Try
          eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail4.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML)
        Catch
        End Try
      End If
      If txtEmail5.Text <> "" Then
        Try
          eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail5.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML)
        Catch
        End Try
      End If
      If txtEmail6.Text <> "" Then
        Try
          eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail6.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML)
        Catch
        End Try
      End If
      If txtEmail7.Text <> "" Then
        Try
          eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail7.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML)
        Catch
        End Try
      End If
      If txtEmail8.Text <> "" Then
        Try
          eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail8.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML)
        Catch
        End Try
      End If
      If txtEmail9.Text <> "" Then
        Try
          eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail9.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML)
        Catch
        End Try
      End If
      If txtEmail10.Text <> "" Then
        Try
          eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail10.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML)
        Catch
        End Try
      End If
      Response.Redirect("LukBrowseren.htm")
    End If
  End Sub


End Class
