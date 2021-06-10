<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PrimaerDaekning.aspx.vb" Inherits="OrdreApp.PrimærDækning" EnableSessionState="False" buffer="True"%>
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
        <%#BladNavn%>
        .</H1>
      <asp:datagrid id=grdPrim style="Z-INDEX: 101; LEFT: 33px; POSITION: absolute; TOP: 136px" runat="server" DataMember="tblWEBPrimærDækning" DataKeyField="BladId" DataSource="<%# Dst %>" AutoGenerateColumns="False" Width="292px" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical" Height="81px">
        <SELECTEDITEMSTYLE font-bold="True" forecolor="White" backcolor="#008A8C"></SELECTEDITEMSTYLE>
        <ALTERNATINGITEMSTYLE backcolor="Gainsboro"></ALTERNATINGITEMSTYLE>
        <ITEMSTYLE forecolor="Black" backcolor="#EEEEEE"></ITEMSTYLE>
        <HEADERSTYLE font-bold="True" forecolor="White" backcolor="#000084"></HEADERSTYLE>
        <FOOTERSTYLE forecolor="Black" backcolor="#CCCCCC"></FOOTERSTYLE>
        <COLUMNS>
          <ASP:BOUNDCOLUMN datafield="postNrOgBy" sortexpression="postNrOgBy" readonly="True" headertext="Post Nr og By"></ASP:BOUNDCOLUMN>
          <ASP:BUTTONCOLUMN text="Slet" buttontype="PushButton" headertext="Slet" commandname="Delete"></ASP:BUTTONCOLUMN>
        </COLUMNS>
        <PAGERSTYLE horizontalalign="Center" forecolor="Black" backcolor="#999999" mode="NumericPages"></PAGERSTYLE>
      </ASP:DATAGRID></FORM>
  </BODY>
</HTML>
