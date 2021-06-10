Imports System.Data.SqlClient

Partial Class OplagClass
  Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.SqlConn = New System.Data.SqlClient.SqlConnection()
    Me.SqlComm = New System.Data.SqlClient.SqlCommand()
    Me.da = New System.Data.SqlClient.SqlDataAdapter()
    Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.dst = New OrdreApp.dst()
    CType(Me.dst, System.ComponentModel.ISupportInitialize).BeginInit()
    '
    'SqlConn
    '
        Me.SqlConn.ConnectionString = "data source=AGETOR;initial catalog=dimpSQL;password=hydeliFyt12;persist s" & _
    "ecurity info=True;user id=sa;workstation id=DDDIMP;packet size=4096"
    '
    'SqlComm
    '
    Me.SqlComm.Connection = Me.SqlConn
    '
    'da
    '
    Me.da.SelectCommand = Me.SqlSelectCommand1
    Me.da.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblOplagWEB", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("PostNr", "PostNr"), New System.Data.Common.DataColumnMapping("Oplag", "Oplag"), New System.Data.Common.DataColumnMapping("BladID", "BladID")})})
    '
    'SqlSelectCommand1
    '
    Me.SqlSelectCommand1.CommandText = "SELECT PostNr, Oplag, BladID FROM tblOplagWEB WHERE (BladID = @BladID)"
    Me.SqlSelectCommand1.Connection = Me.SqlConn
    Me.SqlSelectCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BladID", System.Data.SqlDbType.Int, 4, "BladID"))
    '
    'dst
    '
    Me.dst.DataSetName = "dst"
    Me.dst.Locale = New System.Globalization.CultureInfo("da-DK")
    Me.dst.Namespace = "http://www.tempuri.org/dst.xsd"
    CType(Me.dst, System.ComponentModel.ISupportInitialize).EndInit()

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
  Protected BladID As Integer
  Dim dr As SqlDataReader


  Protected WithEvents da As System.Data.SqlClient.SqlDataAdapter
  Protected WithEvents dst As OrdreApp.dst
  Protected WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
  Protected queryChk As Integer

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If Not IsPostBack Then
      Dim counter As Integer
      Dim checkSum As Integer
      Dim query(1) As String
      query = Split(Request.QueryString("Query"), "*")
      BladID = CInt(query(0))
      QueryChk = CInt(query(1))
      SqlComm.CommandText = "SELECT Navn FROM tblBlade WHERE (BladId = " & BladID & ")"
      SqlConn.Open()
      dr = SqlComm.ExecuteReader
      dr.Read()
      BladNavn = dr("Navn").ToString
      dr.Close()
      SqlConn.Close()
      For counter = 1 To Len(BladNavn)
        checkSum = (checkSum + (Asc(Mid(BladNavn, counter, 1)))) Mod 255
      Next
      If checkSum <> queryChk Then
        Server.Transfer("CheckSumError.htm")
      End If
      ViewState("BladNavn") = BladNavn
      ViewState("BladID") = BladID
      ShowOrdrer()
    Else
      BladNavn = CStr(ViewState("BladNavn"))
      BladID = CInt(ViewState("BladID"))
    End If
  End Sub

  Private Sub ShowOrdrer()
    If grdPrim.EditItemIndex > -1 Then
      btnAddPostNr.Enabled = False
      btnGodkend.Enabled = False
      txtPostNr.Enabled = False
    Else
      btnAddPostNr.Enabled = True
      btnGodkend.Enabled = True
      txtPostNr.Enabled = True
    End If
    da.SelectCommand.Parameters("@BladID").Value = BladID
    da.Fill(dst)
    Me.DataBind()
  End Sub

  Private Sub grdPrim_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPrim.DeleteCommand
    Try
      SqlComm.CommandText = "DELETE FROM tblOplagWEB WHERE (BladID=" & BladID & ") AND (PostNr=" & CInt(e.Item.Cells(0).Text) & ")"
      SqlConn.Open()
      SqlComm.ExecuteNonQuery()
      ShowOrdrer()
    Catch ex As Exception
      SqlConn.Close()
      Server.Transfer("FejlOpdater.htm")
    Finally
      SqlConn.Close()
    End Try
  End Sub

  Private Sub btnAddPostNr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPostNr.Click
    Try
      SqlComm.CommandText = "INSERT INTO tblOplagWEB (BladID, PostNr, Oplag) VALUES ('" & BladID & "', '" & CInt(txtPostNr.Text) & "', '0')"
      SqlConn.Open()
      SqlComm.ExecuteNonQuery()
      ShowOrdrer()
    Catch ex As Exception
      SqlConn.Close()
      Server.Transfer("FejlOpdater.htm")
    Finally
      SqlConn.Close()
    End Try
  End Sub

  Private Sub grdPrim_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPrim.EditCommand
    grdPrim.EditItemIndex = e.Item.ItemIndex
    ShowOrdrer()
  End Sub

  Private Sub grdPrim_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPrim.CancelCommand
    grdPrim.EditItemIndex = -1
    ShowOrdrer()
  End Sub

  Private Sub grdPrim_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPrim.UpdateCommand
    Dim indOplag As Integer

    Try
      indOplag = CInt(CType(e.Item.Cells(1).Controls(1), TextBox).Text)
    Catch
      Response.Redirect("FejlKonverter.htm")
    End Try
    Try
      SqlComm.CommandText = "UPDATE tblOplagWEB SET Oplag = '" & indOplag & "' WHERE (BladID=" & BladID & ") AND (PostNr=" & CInt(e.Item.Cells(0).Text) & ")"
      SqlConn.Open()
      SqlComm.ExecuteNonQuery()
      ShowOrdrer()
    Catch ex As Exception
      SqlConn.Close()
      Server.Transfer("FejlOpdater.htm")
    Finally
      SqlConn.Close()
    End Try
    grdPrim.EditItemIndex = -1
    ShowOrdrer()
  End Sub

  Private Sub txtPostNr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPostNr.TextChanged
    If txtPostNr.Text <> "" Then
      btnAddPostNr.Enabled = True
    Else
      btnAddPostNr.Enabled = False
    End If
  End Sub

  Private Sub btnGodkend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGodkend.Click
    Try
      SqlComm.CommandText = "DELETE FROM tblOplagGodkendWEB WHERE (BladID=" & BladID & ")"
      SqlConn.Open()
      SqlComm.ExecuteNonQuery()
    Catch
      SqlConn.Close()
      Response.Redirect("FejlOpdater.htm?1")
    Finally
      SqlConn.Close()
    End Try
    Try
      SqlComm.CommandText = "INSERT INTO tblOplagGodkendWEB (BladID, Godkendt) VALUES ('" & BladID & "', '1')"
      SqlConn.Open()
      SqlComm.ExecuteNonQuery()
    Catch ex As Exception
      SqlConn.Close()
      Response.Redirect("FejlOpdater.htm")
    Finally
      SqlConn.Close()
    End Try
    Response.Redirect("Afslut.htm")
  End Sub
End Class
