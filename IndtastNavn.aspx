<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IndtastNavn.aspx.vb" Inherits="OrdreApp.IndtastNavn"%>
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
		<FORM id="IndNavnForm" method="post" runat="server">
			<H4>Indtast dit fulde navn:</H4>
			<ASP:TEXTBOX id="txtPersonNavn" style="Z-INDEX: 101; LEFT: 11px; POSITION: absolute; TOP: 147px" runat="server" maxlength="100" width="439px"></ASP:TEXTBOX>
			<DIV style="DISPLAY: inline; Z-INDEX: 102; LEFT: 16px; WIDTH: 435px; COLOR: black; POSITION: absolute; TOP: 103px; HEIGHT: 25px" align="center" ms_positioning="FlowLayout">
				<H2><%#eMail%></H2>
			</DIV>
			<ASP:BUTTON id="btnOpdater" style="Z-INDEX: 103; LEFT: 183px; POSITION: absolute; TOP: 189px" runat="server" width="92px" height="28px" text="Opdater"></ASP:BUTTON><ASP:REQUIREDFIELDVALIDATOR id="validerTxtPersonNavnUdfýldt" style="Z-INDEX: 104; LEFT: 471px; POSITION: absolute; TOP: 151px" runat="server" controltovalidate="txtPersonNavn" errormessage="Du skal udfylde navnet."></ASP:REQUIREDFIELDVALIDATOR></FORM>
	</BODY>
</HTML>
