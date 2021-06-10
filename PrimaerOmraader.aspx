<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PrimaerOmraader.aspx.vb" Inherits="OrdreApp.PrimPost" EnableSessionState="False" buffer="True"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
    <TITLE>Primære dækningsområder for
      <%#BladNavn%>
      .</TITLE>
    <META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
    <META content="Visual Basic 7.0" name="CODE_LANGUAGE">
    <META content="JavaScript" name="vs_defaultClientScript">
    <META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <LINK href="OrdreStyles.css" type="text/css" rel="stylesheet">
  </HEAD>
  <BODY ms_positioning="GridLayout">
    <FORM id="OrdreForm" method="post" runat="server">
      <H1>Primære dækningsområder for
        <%#BladNavn%>.</H1>
        <asp:datagrid id=grdPrim style="Z-INDEX: 101; LEFT: 33px; POSITION: absolute; TOP: 136px" runat="server" DataMember="tblDækning" DataKeyField="BladId" DataSource="<%# Dst %>" AutoGenerateColumns="False" Width="337px" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical" Height="81px" ToolTip="Liste over de dækningsområder der er registreret af DLU.">
        <SELECTEDITEMSTYLE font-bold="True" forecolor="White" backcolor="#008A8C"></SELECTEDITEMSTYLE>
        <ALTERNATINGITEMSTYLE backcolor="Gainsboro"></ALTERNATINGITEMSTYLE>
        <ITEMSTYLE forecolor="Black" backcolor="#EEEEEE"></ITEMSTYLE>
        <HEADERSTYLE font-bold="True" forecolor="White" backcolor="#000084"></HEADERSTYLE>
        <FOOTERSTYLE forecolor="Black" backcolor="#CCCCCC"></FOOTERSTYLE>
        <PAGERSTYLE horizontalalign="Center" forecolor="Black" backcolor="#999999" mode="NumericPages"></PAGERSTYLE>
        <Columns>
          <asp:boundcolumn DataField="PostNr" HeaderText="Post Nr" SortExpression="PostNr">
            <HeaderStyle Width="100px" />
          </asp:boundcolumn>
          <asp:boundcolumn DataField="Byen" HeaderText="Post By" SortExpression="Byen">
            <HeaderStyle Width="300px" />
          </asp:boundcolumn>
          <asp:buttoncolumn ButtonType="PushButton" CommandName="Delete" Text="Slet">
          </asp:buttoncolumn>
        </Columns>
      </ASP:DATAGRID>
      <DIV style="DISPLAY: inline; Z-INDEX: 102; LEFT: 36px; WIDTH: 320px; POSITION: absolute; TOP: 98px; HEIGHT: 22px" ms_positioning="FlowLayout">
        Primære&nbsp;dækningsområder</DIV>
      <ASP:TEXTBOX id="txtPostPrim" style="Z-INDEX: 103; LEFT: 436px; POSITION: absolute; TOP: 185px" runat="server" width="58px" height="25px" maxlength="4" ToolTip="Indtast et postnr. du vil tilføje til listen."></ASP:TEXTBOX>
      <ASP:BUTTON id="btnAddPostNr" style="Z-INDEX: 104; LEFT: 423px; POSITION: absolute; TOP: 234px" runat="server" width="92px" height="22px" text="Tilføj PostNr" ToolTip="Indtast et postnr. i feltet, for at åbne for knappen."></ASP:BUTTON>
      <DIV style="DISPLAY: inline; Z-INDEX: 105; LEFT: 403px; WIDTH: 137px; POSITION: absolute; TOP: 144px; HEIGHT: 19px" ms_positioning="FlowLayout">Indtast 
        nyt post nr.</DIV>
      <ASP:HYPERLINK id="SekLink" style="Z-INDEX: 106; LEFT: 592px; POSITION: absolute; TOP: 177px" runat="server" width="130px" height="13px" cssclass="HelpLink" Visible="False" Enabled="False">Gå Til Sekundær områder</ASP:HYPERLINK>
      <ASP:RANGEVALIDATOR id="RangeValidator1" style="Z-INDEX: 107; LEFT: 411px; POSITION: absolute; TOP: 269px" runat="server" height="17px" width="263px" errormessage="Post nr. skal være mellem 1000 og 9999" controltovalidate="txtPostPrim" maximumvalue="9999" minimumvalue="1000" type="Integer"></ASP:RANGEVALIDATOR>
      <ASP:REQUIREDFIELDVALIDATOR id="RequiredFieldValidator1" style="Z-INDEX: 108; LEFT: 413px; POSITION: absolute; TOP: 294px" runat="server" height="23px" width="207px" errormessage="Der skal indtastes et post nr." controltovalidate="txtPostPrim"></ASP:REQUIREDFIELDVALIDATOR></FORM>
  </BODY>
</HTML>
