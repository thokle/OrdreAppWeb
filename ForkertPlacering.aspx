<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ForkertPlacering.aspx.vb" Inherits="OrdreApp.ForkertPlacering2"%>
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
		<FORM id="IndPlaceringForm" method="post" runat="server">
			<H4>Forkert placering:</H4>
			<ASP:BUTTON id="btnOpdater" style="Z-INDEX: 101; LEFT: 68px; POSITION: absolute; TOP: 148px" runat="server" width="92px" height="28px" text="Opdater"></ASP:BUTTON>
			<ASP:TEXTBOX id="txtSide" style="Z-INDEX: 102; LEFT: 128px; POSITION: absolute; TOP: 72px" runat="server" width="84px"></ASP:TEXTBOX>
			<ASP:LABEL id="Label1" style="Z-INDEX: 103; LEFT: 12px; POSITION: absolute; TOP: 76px" runat="server" width="112px">Indrykket på side</ASP:LABEL>
			<ASP:LABEL id="Label2" style="Z-INDEX: 104; LEFT: 12px; POSITION: absolute; TOP: 112px" runat="server" width="136px">Faktureres til mm. kr.</ASP:LABEL>
			<ASP:TEXTBOX id="txtPris" style="Z-INDEX: 105; LEFT: 156px; POSITION: absolute; TOP: 108px" runat="server" width="56px"></ASP:TEXTBOX></FORM>
	</BODY>
</HTML>
