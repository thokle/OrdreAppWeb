<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Oplag.aspx.vb" Inherits="OrdreApp.OplagClass" EnableSessionState="False" buffer="True"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
    <TITLE>Oplag for
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
      <H1>Oplag for
        <%#BladNavn%>
        .</H1>
      <asp:datagrid id=grdPrim runat="server" Height="176px" GridLines="Vertical" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#999999" Width="504px" AutoGenerateColumns="False" DataSource="<%# dst %>" DataKeyField="BladID" DataMember="tblOplagWEB" FORECOLOR="Maroon" FONT-SIZE="Small" FONT-NAMES="Arial" HORIZONTALALIGN="Center" STYLE="Z-INDEX: 100; LEFT: 20px; POSITION: absolute; TOP: 116px">
        <SELECTEDITEMSTYLE font-bold="True" wrap="False" horizontalalign="Center" forecolor="White" verticalalign="Middle" backcolor="#008A8C"></SELECTEDITEMSTYLE>
        <EDITITEMSTYLE wrap="False" horizontalalign="Center" forecolor="White" verticalalign="Middle" backcolor="DarkCyan"></EDITITEMSTYLE>
        <ALTERNATINGITEMSTYLE wrap="False" horizontalalign="Center" verticalalign="Middle" backcolor="Gainsboro"></ALTERNATINGITEMSTYLE>
        <ITEMSTYLE wrap="False" horizontalalign="Center" forecolor="Black" verticalalign="Middle" backcolor="#EEEEEE"></ITEMSTYLE>
        <HEADERSTYLE font-bold="True" wrap="False" horizontalalign="Center" forecolor="White" verticalalign="Middle" backcolor="#000084"></HEADERSTYLE>
        <FOOTERSTYLE wrap="False" horizontalalign="Center" forecolor="Black" verticalalign="Middle" backcolor="#CCCCCC"></FOOTERSTYLE>
        <COLUMNS>
          <ASP:BOUNDCOLUMN datafield="PostNr" readonly="True" headertext="Post Nr.">
            <HEADERSTYLE wrap="False" width="15%"></HEADERSTYLE>
            <ITEMSTYLE wrap="False"></ITEMSTYLE>
            <FOOTERSTYLE wrap="False"></FOOTERSTYLE>
          </ASP:BOUNDCOLUMN>
          <ASP:TEMPLATECOLUMN headertext="Oplag">
            <HEADERSTYLE wrap="False" width="25%"></HEADERSTYLE>
            <ITEMSTYLE wrap="False"></ITEMSTYLE>
            <ITEMTEMPLATE>
              <asp:Label id="lblOplag" runat="server" Width="90%" Height="22px" Text='<%# DataBinder.Eval(Container, "DataItem.Oplag") %>'>
              </ASP:LABEL>
            </ITEMTEMPLATE>
            <FOOTERSTYLE wrap="False"></FOOTERSTYLE>
            <EDITITEMTEMPLATE>
              <asp:TextBox id="txtOplag" runat="server" Width="90%" Height="22px" Text='<%# DataBinder.Eval(Container, "DataItem.Oplag") %>' Wrap="False">
              </ASP:TEXTBOX>
            </EDITITEMTEMPLATE>
          </ASP:TEMPLATECOLUMN>
          <ASP:EDITCOMMANDCOLUMN buttontype="PushButton" updatetext="Opdater" headertext="Edit&#233;r oplag" canceltext="Afbryd" edittext="Ret Oplag">
            <HEADERSTYLE wrap="False" width="35%"></HEADERSTYLE>
            <ITEMSTYLE wrap="False"></ITEMSTYLE>
            <FOOTERSTYLE wrap="False"></FOOTERSTYLE>
          </ASP:EDITCOMMANDCOLUMN>
          <ASP:BUTTONCOLUMN buttontype="PushButton" datatextfield="PostNr" headertext="Slet Post Nr." commandname="Delete" datatextformatstring="Slet {0}">
            <HEADERSTYLE wrap="False" width="25%"></HEADERSTYLE>
            <ITEMSTYLE wrap="False"></ITEMSTYLE>
            <FOOTERSTYLE wrap="False"></FOOTERSTYLE>
          </ASP:BUTTONCOLUMN>
        </COLUMNS>
        <PAGERSTYLE verticalalign="Middle" horizontalalign="Center" wrap="False"></PAGERSTYLE>
      </ASP:DATAGRID>
      <DIV ms_positioning="FlowLayout" style="Z-INDEX: 101; LEFT: 544px; WIDTH: 137px; POSITION: absolute; TOP: 120px; HEIGHT: 20px">
        Indtast nyt post nr.
      </DIV>
      <ASP:TEXTBOX id="txtPostNr" runat="server" maxlength="4" height="25px" width="72px" style="Z-INDEX: 102; LEFT: 572px; POSITION: absolute; TOP: 152px"></ASP:TEXTBOX><ASP:BUTTON id="btnAddPostNr" runat="server" height="22px" width="92px" text="Tilføj PostNr" style="Z-INDEX: 103; LEFT: 560px; POSITION: absolute; TOP: 192px"></ASP:BUTTON>
      <ASP:RANGEVALIDATOR id="RangeValidator1" runat="server" height="16px" width="263px" type="Integer" minimumvalue="1000" maximumvalue="9999" controltovalidate="txtPostNr" errormessage="Post nr. skal være mellem 1000 og 9999" style="Z-INDEX: 104; LEFT: 536px; POSITION: absolute; TOP: 228px"></ASP:RANGEVALIDATOR>
      <ASP:BUTTON id="btnGodkend" style="Z-INDEX: 105; LEFT: 560px; POSITION: absolute; TOP: 264px" runat="server" width="92px" height="22px" text="Godkend"></ASP:BUTTON>
    </FORM>
  </BODY>
</HTML>
