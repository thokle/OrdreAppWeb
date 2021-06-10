<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MainMenu.aspx.vb" Inherits="OrdreApp.MainMenu"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Kontaktperson til forsendelser fra DLU.</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="OrdreStyles.css" type="text/css" rel="stylesheet">
		<base target="main">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="BemForm" method="post" runat="server">
			<asp:hyperlink id="linkPris" style="Z-INDEX: 101; LEFT: 10px; POSITION: absolute; TOP: 14px" runat="server" Width="93px" Height="14px">Priser</asp:hyperlink>
			<asp:hyperlink id="linkPrimaer" style="Z-INDEX: 102; LEFT: 114px; POSITION: absolute; TOP: 14px" runat="server" Width="125px" Height="14px">Dækningsområder</asp:hyperlink>
			<asp:HyperLink id="linkKommuner" style="Z-INDEX: 103; LEFT: 267px; POSITION: absolute; TOP: 14px" runat="server" Width="96px" Height="14px">Kommuner</asp:HyperLink>
		</form>
	</body>
</HTML>
