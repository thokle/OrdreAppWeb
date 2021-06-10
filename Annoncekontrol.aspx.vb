Imports System.Data.SqlClient
Imports System.Globalization

Partial Class Annoncekontrol
  Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.SqlConn = New System.Data.SqlClient.SqlConnection()
    Me.SqlComm = New System.Data.SqlClient.SqlCommand()
    Me.da = New System.Data.SqlClient.SqlDataAdapter()
    Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
    Me.Dst = New OrdreApp.dst()
    CType(Me.Dst, System.ComponentModel.ISupportInitialize).BeginInit()
    '
    'SqlConn
    '
    Me.SqlConn.ConnectionString = "data source=DLU02;initial catalog=DiMPdotNet;password=lp4DLU;persist security info=True;user id=LocalPlanner;workstation id=DDDIMP;packet size=4096"
    '
    'SqlComm
    '
    Me.SqlComm.Connection = Me.SqlConn
    '
    'da
    '
    Me.da.SelectCommand = Me.SqlSelectCommand1
        Me.da.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblMedieplanLinjer", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("OrdreNr", "OrdreNr"), New System.Data.Common.DataColumnMapping("SlutVist", "SlutVist"), New System.Data.Common.DataColumnMapping("Annoncør", "Annoncør"), New System.Data.Common.DataColumnMapping("Betegnelse", "Betegnelse"), New System.Data.Common.DataColumnMapping("Format", "Format"), New System.Data.Common.DataColumnMapping("AntalFarver", "AntalFarver"), New System.Data.Common.DataColumnMapping("FejlID", "FejlID"), New System.Data.Common.DataColumnMapping("EnOrdre", "EnOrdre"), New System.Data.Common.DataColumnMapping("Kulør", "Kulør"), New System.Data.Common.DataColumnMapping("AnnoncørID", "AnnoncørID"), New System.Data.Common.DataColumnMapping("mmType", "mmType"), New System.Data.Common.DataColumnMapping("BladID", "BladID"), New System.Data.Common.DataColumnMapping("DPKulørID", "DPKulørID"), New System.Data.Common.DataColumnMapping("Version", "Version"), New System.Data.Common.DataColumnMapping("MedieplanNr", "MedieplanNr"), New System.Data.Common.DataColumnMapping("EXPR2", "EXPR2"), New System.Data.Common.DataColumnMapping("SidePlacering", "SidePlacering")})})
    '
    'SqlSelectCommand1
    '
    Me.SqlSelectCommand1.CommandText = "SELECT tblMedieplan.MedieplanNr AS OrdreNr, CASE WHEN tblAnnoncekontrol.ErKontrolleret IS NULL THEN 0 ELSE tblAnnoncekontrol.ErKontrolleret END AS SlutVist, NavisionContact.Name AS Annoncør, tblPlacering.Betegnelse, LTRIM(STR(tblMedieplan.Format1)) + 'x' + LTRIM(STR(tblMedieplan.Format2)) AS Format, tblMedieplan.AntalFarver, CASE WHEN tblAnnoncekontrol.Fejlkode IS NULL THEN 0 ELSE tblAnnoncekontrol.Fejlkode END AS FejlID, tblMedieplan.Fakturering AS EnOrdre, tblDPKulør.Kulør, NavisionContact.No_ AS AnnoncørID, tblPlacering.PlaceringID AS mmType, tblMedieplanLinjer.UgeavisID AS BladID, tblDPKulør.DPKulørID, tblMedieplan.Version, tblMedieplanLinjer.MedieplanNr, tblMedieplanLinjer.Version AS EXPR2, tblAnnoncekontrol.SidePlacering FROM tblMedieplanLinjer INNER JOIN tblDPKulør INNER JOIN NavisionContact INNER JOIN tblPlacering INNER JOIN tblMedieplan ON tblPlacering.PlaceringID = tblMedieplan.PlaceringID ON NavisionContact.No_ = tblMedieplan.AnnoncørNo_ ON tblDPKulør.DPKulørID = tblMedieplan.DPKulørID INNER JOIN tblMedieplanNr ON tblMedieplan.MedieplanNr = tblMedieplanNr.MedieplanNr AND tblMedieplan.Version = tblMedieplanNr.AktivVersion ON tblMedieplanLinjer.MedieplanNr = tblMedieplan.MedieplanNr AND tblMedieplanLinjer.Version = tblMedieplan.Version LEFT OUTER JOIN tblAnnoncekontrol ON tblMedieplanLinjer.MedieplanNr = tblAnnoncekontrol.MedieplanNr AND tblMedieplanLinjer.UgeavisID = tblAnnoncekontrol.UgeavisID WHERE (tblMedieplan.Status = 3 OR tblMedieplan.Status = 5 OR tblMedieplan.Status = 6 OR tblMedieplan.Status = 99) AND (tblMedieplan.IndrykningsUge = @Uge) AND (tblMedieplanLinjer.UgeavisID = @BladID) AND (tblMedieplan.IndrykningsÅr = @År) ORDER BY OrdreNr"

    Me.SqlSelectCommand1.Connection = Me.SqlConnection1
    Me.SqlSelectCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Uge", System.Data.SqlDbType.TinyInt, 1, "IndrykningsUge"))
    Me.SqlSelectCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BladID", System.Data.SqlDbType.Int, 4, "BladID"))
    Me.SqlSelectCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@År", System.Data.SqlDbType.Int, 4, "IndrykningsÅr"))
    '
    'SqlConnection1
    '
    Me.SqlConnection1.ConnectionString = "data source=DLU02;initial catalog=DiMPdotNet;password=lp4DLU;persist security info=True;user id=LocalPlanner;workstation id=DDDIMP;packet size=4096"
    '
    'Dst
    '
    Me.Dst.DataSetName = "dst"
    Me.Dst.Locale = New System.Globalization.CultureInfo("da-DK")
    Me.Dst.Namespace = "http://www.tempuri.org/dst.xsd"
    CType(Me.Dst, System.ComponentModel.ISupportInitialize).EndInit()

  End Sub

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: This method call is required by the Web Form Designer
    'Do not modify it using the code editor.
    InitializeComponent()
  End Sub

#End Region
  Protected BladNavn As String
  Protected WithEvents SqlConn As System.Data.SqlClient.SqlConnection
  Protected WithEvents SqlComm As System.Data.SqlClient.SqlCommand
  Protected Uge As Integer
  Protected BladID As Integer
  Protected År As Integer
  Protected QueryChk As Integer
  Protected FejlTekst(9) As String
  Dim query(2) As String

  Dim dr As SqlDataReader

  Protected WithEvents da As System.Data.SqlClient.SqlDataAdapter

  Protected WithEvents BemLink As System.Web.UI.WebControls.HyperLink
  Protected WithEvents Dst As OrdreApp.dst
  Protected eMail As String = ""
  Protected WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
  Protected WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
  Protected kontrolleretAfDLU As Integer = 0
  Protected FejlIAnnonce As Integer = 0

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    FejlTekst(0) = "Ingen valgt"
    FejlTekst(1) = "Bestilt efter deadline"
    FejlTekst(2) = "Ordre ikke modtaget"
    FejlTekst(3) = "Glemt annonce"
    FejlTekst(4) = "DLU har fremsendt forkert materiale"
    FejlTekst(5) = "Vi har indrykket forkert materiale"
    FejlTekst(6) = "Forkert farve"
    FejlTekst(7) = "Forkert placering"
    FejlTekst(8) = "Forkert annonce format"
    FejlTekst(9) = "Glemt farve"
    If Not IsPostBack Then
      Dim CheckSum As Integer
      Dim counter As Integer
      Dim DenneUge As Integer

      query = Split(Request.QueryString("Query"), "*")
      BladID = CInt(query(0))
      Uge = CInt(query(1))
      eMail = CStr(query(2))
      QueryChk = CInt(query(3))
      SqlComm.CommandText = "SELECT Navn FROM tblBladStamdata WHERE (BladID = " & BladID & ")"
      SqlConn.Open()
      dr = SqlComm.ExecuteReader
      dr.Read()
      BladNavn = dr("Navn").ToString
      If QueryChk = 999 Then
        kontrolleretAfDLU = 1
      Else
        For counter = 1 To Len(BladNavn)
          CheckSum = (CheckSum + (Uge + Asc(Mid(BladNavn, counter, 1)))) Mod 255
        Next
        If CheckSum <> QueryChk Then
          Server.Transfer("CheckSumError.htm?" & CheckSum.ToString())
        End If
      End If
      dr.Close()
      SqlConn.Close()
      Dim myCI As New CultureInfo("da-DK")
      Dim myCal As Calendar = myCI.Calendar
      Dim myCWR As CalendarWeekRule = myCI.DateTimeFormat.CalendarWeekRule
      Dim myFirstDOW As DayOfWeek = myCI.DateTimeFormat.FirstDayOfWeek
      DenneUge = CInt(myCal.GetWeekOfYear(DateTime.Now, myCWR, myFirstDOW))
            'If DenneUge < Uge Then
            '  År = Date.Now.Year - 1
            'Else
            År = Date.Now.Year
            'End If
      ViewState("BladNavn") = BladNavn
      ViewState("Uge") = Uge
      ViewState("År") = År
      ViewState("BladID") = BladID
      ViewState("Email") = eMail
      ViewState("DLU") = kontrolleretAfDLU
      ViewState("QueryChk") = QueryChk
      ViewState("FejlIAnnonce") = FejlIAnnonce
      ShowOrdrer()
    Else
      BladNavn = CStr(ViewState("BladNavn"))
      Uge = CInt(ViewState("Uge"))
      År = CInt(ViewState("År"))
      BladID = CInt(ViewState("BladID"))
      eMail = CStr(ViewState("Email"))
      kontrolleretAfDLU = CInt(ViewState("DLU"))
      QueryChk = CInt(ViewState("QueryChk"))
      FejlIAnnonce = CInt(ViewState("FejlIAnnonce"))
    End If
  End Sub

  Private Sub ShowOrdrer()
    da.SelectCommand.Parameters("@BladID").Value = BladID
    da.SelectCommand.Parameters("@Uge").Value = Uge
    da.SelectCommand.Parameters("@År").Value = År
    da.Fill(Dst)
    Me.DataBind()
  End Sub

  Private Sub grdOrdrer_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdOrdrer.ItemCommand
    Dim OrdreID As Integer = CInt(e.Item.Cells(8).Text)
    Dim ErrorID As Integer = 0
    Dim ManglerKontrol As Integer
    Dim AntalFejl As Integer
    Dim EnOrdre As Integer
    Dim Status As Integer
    Dim SidePlacering As Integer

    If e.CommandName = "Send" Then
      Try
        If grdOrdrer.EditItemIndex > -1 Then
                    SidePlacering = CType(e.Item.Cells(6).Controls(1), TextBox).Text
          ErrorID = CType(e.Item.Cells(7).Controls(1), DropDownList).SelectedItem.Value
          EnOrdre = CInt(e.Item.Cells(9).Text)
        End If
      Catch ex As Exception
        Response.Redirect("FejlKonverter.htm")
      End Try
      If FejlIAnnonce = 1 Then
        If ErrorID = 0 Then
          Response.Redirect("GlemtAtAngiveFejl.htm")
        End If
      ElseIf FejlIAnnonce = 2 Then
        If SidePlacering = 0 Then
          Response.Redirect("GlemtAtAngiveSidePlacering.htm")
        End If
      Else
        Response.Redirect("FejlOpdater.htm")
      End If

      Try
        SqlConn.Open()
        SqlComm.CommandText = "DELETE FROM tblAnnoncekontrol WHERE (MedieplanNr = " & OrdreID & ") AND (UgeavisID = " & BladID & ")"
        SqlComm.ExecuteNonQuery()
        SqlComm.CommandText = "INSERT INTO tblAnnoncekontrol (MedieplanNr, UgeavisID, ErKontrolleret, " & _
                              "KontrolTidspunkt, KontrollørEmail, KontrolleretAfDLU, Fejlkode, SidePlacering) " & _
                              "VALUES (" & OrdreID & "," & BladID & ", 1, " & _
                              "GETDATE(),'" & eMail & "'," & kontrolleretAfDLU & "," & ErrorID & "," & SidePlacering & ")"
        SqlComm.ExecuteNonQuery()
        SqlComm.CommandText = "SELECT DISTINCT COUNT(tblMedieplanLinjer.UgeavisID) AS ManglerKontrol FROM " & _
                              "tblMedieplanNr INNER JOIN tblMedieplanLinjer ON tblMedieplanNr.MedieplanNr = tblMedieplanLinjer.MedieplanNr " & _
                              "AND tblMedieplanNr.AktivVersion = tblMedieplanLinjer.Version LEFT OUTER JOIN " & _
                              "tblAnnoncekontrol ON tblMedieplanLinjer.MedieplanNr = tblAnnoncekontrol.MedieplanNr AND " & _
                              "tblMedieplanLinjer.UgeavisID = tblAnnoncekontrol.UgeavisID WHERE " & _
                              "(tblMedieplanNr.MedieplanNr = " & OrdreID & ") AND " & _
                              "(tblAnnoncekontrol.ErKontrolleret IS NULL OR tblAnnoncekontrol.ErKontrolleret = 0)"

        ManglerKontrol = SqlComm.ExecuteScalar()
        If ManglerKontrol = 0 Then
          SqlComm.CommandText = "SELECT COUNT(MedieplanNr) AS AntalFejl FROM tblAnnoncekontrol " & _
                                "WHERE(Fejlkode > 0) And (MedieplanNr = " & OrdreID & ")"
          AntalFejl = SqlComm.ExecuteScalar()
          If AntalFejl = 0 Then
            SqlComm.CommandText = "SELECT tblMedieplan.Fakturering FROM tblMedieplan INNER JOIN tblMedieplanNr ON " & _
                                  "tblMedieplan.MedieplanNr = tblMedieplanNr.MedieplanNr AND tblMedieplan.Version = tblMedieplanNr.AktivVersion " & _
                                  "WHERE(tblMedieplanNr.MedieplanNr = " & OrdreID & ")"
            EnOrdre = SqlComm.ExecuteScalar
            If EnOrdre = 1 Then
              Status = 6
            Else
              Status = 99
            End If
          Else
            Status = 5
          End If
          SqlComm.CommandText = "UPDATE tblMedieplan SET Status = " & Status & " FROM tblMedieplan INNER JOIN " & _
          "tblMedieplanNr ON tblMedieplan.MedieplanNr = tblMedieplanNr.MedieplanNr AND tblMedieplan.Version = " & _
          "tblMedieplanNr.AktivVersion WHERE (tblMedieplan.MedieplanNr = " & OrdreID & ")"
          SqlComm.ExecuteNonQuery()
          SqlComm.CommandText = "UPDATE tblMedieplanNr SET Status = " & Status & " WHERE(MedieplanNr = " & OrdreID & ")"
          SqlComm.ExecuteNonQuery()
        End If
      Catch ex As Exception
        SqlConn.Close()
        Response.Redirect("FejlOpdater.htm")
      Finally
        SqlConn.Close()
      End Try
      If ErrorID = 7 Then
        Response.Redirect("ForkertPlacering.aspx" & Request.Url.Query & "*" & OrdreID.ToString)
      End If
      grdOrdrer.EditItemIndex = -1
      ViewState("FejlIAnnonce") = 0
      ShowOrdrer()
    Else
      If e.CommandName = "Ok" Then
        Try
          SqlConn.Open()
          SqlComm.CommandText = "UPDATE tblAnnoncekontrol SET ErKontrolleret = 0  WHERE (MedieplanNr = " & OrdreID & ") AND (UgeavisID = " & BladID & ")"
          SqlComm.ExecuteNonQuery()
        Catch ex As Exception
          SqlConn.Close()
          Response.Redirect("FejlEditer.htm")
        Finally
          SqlConn.Close()
        End Try
      ElseIf e.CommandName = "Ja" Then
        FejlIAnnonce = 2
      ElseIf e.CommandName = "Nej" Then
        FejlIAnnonce = 1
      Else
        FejlIAnnonce = 0
      End If
      grdOrdrer.EditItemIndex = e.Item.ItemIndex
      ViewState("FejlIAnnonce") = FejlIAnnonce
      ShowOrdrer()
    End If
  End Sub

End Class
