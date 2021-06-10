<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Forsendelser.aspx.vb" Inherits="OrdreApp.Forsendelser"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Kontaktperson til forsendelser fra DLU.</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="OrdreStyles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="BemForm" method="post" runat="server">
			<h1><%#BladNavn%>
				<asp:textbox id="txtEmail" style="Z-INDEX: 103; LEFT: 373px; POSITION: absolute; TOP: 144px" tabIndex="2" runat="server" Height="25px" Width="303px"></asp:textbox><br>
				Indtast kontaktperson til forsendelser fra DLU.</h1>
			<asp:textbox id="txtNavn" style="Z-INDEX: 101; LEFT: 19px; POSITION: absolute; TOP: 145px" tabIndex="1" runat="server" Height="25px" Width="303px"></asp:textbox><asp:button id="btnOpdater" style="Z-INDEX: 102; LEFT: 276px; POSITION: absolute; TOP: 192px" tabIndex="3" runat="server" Height="23px" Width="140px" Text="Opdater"></asp:button>
			<P>Click i felterne herunder og indtast navn og email. Når du er færdig, tryk på 
				"Opdater" og luk siden.</P>
			<DIV style="DISPLAY: inline; Z-INDEX: 104; LEFT: 376px; WIDTH: 114px; POSITION: absolute; TOP: 124px; HEIGHT: 20px" ms_positioning="FlowLayout">
				<P>E-mail adresse</P>
			</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 105; LEFT: 21px; WIDTH: 155px; POSITION: absolute; TOP: 124px; HEIGHT: 20px" ms_positioning="FlowLayout">Kontaktperson</DIV>
		</form>
	</body>
</HTML>
