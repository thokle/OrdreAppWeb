<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MmPriser2.aspx.vb" Inherits="OrdreApp.MmPriser2"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
    <TITLE>Mm. priser for
      <%#BladNavn%>
      .</TITLE>
    <META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
    <META content="Visual Basic 7.0" name="CODE_LANGUAGE">
    <META content="JavaScript" name="vs_defaultClientScript">
    <META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <LINK href="OrdreStyles.css" type="text/css" rel="stylesheet">
  </HEAD>
  <BODY ms_positioning="GridLayout">
    <FORM id="BemForm" method="post" runat="server">
      <H3><%#BladNavn%>
        priser 2008</H3>
      <BR>
      <ASP:TEXTBOX id="txtTekstside" style="Z-INDEX: 112; LEFT: 88px; POSITION: absolute; TOP: 70px" runat="server" width="80px" height="22px"></ASP:TEXTBOX><ASP:TEXTBOX id="txtStillinger" style="Z-INDEX: 126; LEFT: 280px; POSITION: absolute; TOP: 70px" tabindex="7" runat="server" width="80px" height="22px"></ASP:TEXTBOX>
      <DIV style="DISPLAY: inline; Z-INDEX: 115; LEFT: 12px; WIDTH: 72px; POSITION: absolute; TOP: 70px; HEIGHT: 22px" ms_positioning="FlowLayout">Bolig 
        side</DIV>
      <DIV style="DISPLAY: inline; Z-INDEX: 116; LEFT: 194px; WIDTH: 84px; POSITION: absolute; TOP: 70px; HEIGHT: 22px" ms_positioning="FlowLayout">Særskilte 
        Stillinger</DIV>
      <ASP:BUTTON id="btnGodkend" style="Z-INDEX: 135; LEFT: 128px; POSITION: absolute; TOP: 120px" runat="server" width="116px" height="27px" text="Opdater"></ASP:BUTTON></FORM>
  </BODY>
</HTML>
