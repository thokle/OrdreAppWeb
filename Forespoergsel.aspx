<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Forespoergsel.aspx.vb" Inherits="OrdreApp.Forespoergsel"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
    <TITLE>Forespørgsel</TITLE>
    <META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
    <META content="Visual Basic 7.0" name="CODE_LANGUAGE">
    <META content="JavaScript" name="vs_defaultClientScript">
    <META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <LINK href="OrdreStyles.css" type="text/css" rel="stylesheet">
  </HEAD>
  <BODY ms_positioning="GridLayout">
    <FORM id="ForeForm" method="post" runat="server">
      <H1>
        <ASP:TEXTBOX id="txtDLUMmpris" style="Z-INDEX: 102; LEFT: 301px; POSITION: absolute; TOP: 100px" runat="server" width="56px" height="20px" readonly="True"></ASP:TEXTBOX>
        <ASP:BUTTON id="btnOpdater" style="Z-INDEX: 116; LEFT: 461px; POSITION: absolute; TOP: 262px" runat="server" width="71px" height="23px" text="Opdater" visible="False"></ASP:BUTTON>
        <ASP:BUTTON id="btnFortryd" style="Z-INDEX: 115; LEFT: 333px; POSITION: absolute; TOP: 262px" runat="server" width="71px" height="23px" text="Fortryd" visible="False"></ASP:BUTTON>
        <ASP:TEXTBOX id="txtBladMmPris" style="Z-INDEX: 112; LEFT: 301px; POSITION: absolute; TOP: 140px" runat="server" width="56px" height="20px" visible="False"></ASP:TEXTBOX>
        <ASP:TEXTBOX id="txtBladMmRabat" style="Z-INDEX: 105; LEFT: 368px; POSITION: absolute; TOP: 140px" runat="server" width="56px" height="20px" visible="False"></ASP:TEXTBOX>
        <ASP:TEXTBOX id="txtBladFarvetillæg" style="Z-INDEX: 107; LEFT: 444px; POSITION: absolute; TOP: 140px" runat="server" width="56px" height="20px" visible="False"></ASP:TEXTBOX>
        <ASP:TEXTBOX id="txtBladFarveRabat" style="Z-INDEX: 108; LEFT: 521px; POSITION: absolute; TOP: 140px" runat="server" width="56px" height="20px" visible="False"></ASP:TEXTBOX>
        <ASP:BUTTON id="btnÆndringer" style="Z-INDEX: 111; LEFT: 590px; POSITION: absolute; TOP: 139px" runat="server" width="71px" height="23px" text="Ændringer"></ASP:BUTTON>
        <ASP:TEXTBOX id="txtDLUMmRabat" style="Z-INDEX: 104; LEFT: 368px; POSITION: absolute; TOP: 100px" runat="server" width="56px" height="20px" readonly="True"></ASP:TEXTBOX>
        <ASP:TEXTBOX id="txtDLUFarveRabat" style="Z-INDEX: 109; LEFT: 521px; POSITION: absolute; TOP: 100px" runat="server" width="56px" height="20px" readonly="True"></ASP:TEXTBOX>
        <ASP:TEXTBOX id="txtDLUFarvetillæg" style="Z-INDEX: 106; LEFT: 444px; POSITION: absolute; TOP: 100px" runat="server" width="56px" height="20px" readonly="True"></ASP:TEXTBOX>Prisforespørgsel 
        til
        <%#BladNavn%>
        .</H1>
      <ASP:LABEL id="lblInfo" style="Z-INDEX: 101; LEFT: 14px; POSITION: absolute; TOP: 55px" runat="server" width="256px" height="67px" borderstyle="Solid" borderwidth="1px">Label</ASP:LABEL>
      <DIV style="DISPLAY: inline; Z-INDEX: 103; LEFT: 302px; WIDTH: 278px; POSITION: absolute; TOP: 55px; HEIGHT: 33px" ms_positioning="FlowLayout">
        DLU's forslag :<BR>
        <BR>
        <B>Kr./Mm.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Rabat&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Farvetillæg&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Rabat</B>
      </DIV>
      <ASP:BUTTON id="btnGodkend" style="Z-INDEX: 110; LEFT: 590px; POSITION: absolute; TOP: 99px" runat="server" width="71px" height="23px" text="Godkend"></ASP:BUTTON>
      <ASP:LABEL id="lblBemærkning" style="Z-INDEX: 113; LEFT: 303px; POSITION: absolute; TOP: 172px" runat="server" width="65px" height="19px" visible="False">Bemærkning</ASP:LABEL>
      <ASP:TEXTBOX id="txtBemærkning" style="Z-INDEX: 114; LEFT: 300px; POSITION: absolute; TOP: 188px" runat="server" width="277px" height="63px" visible="False" textmode="MultiLine"></ASP:TEXTBOX>
      <ASP:LABEL id="lblBesvaretAf" style="Z-INDEX: 117; LEFT: 18px; POSITION: absolute; TOP: 306px" runat="server" width="650px" height="34px"></ASP:LABEL>
    </FORM>
  </BODY>
</HTML>
