<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MmPriser.aspx.vb" Inherits="OrdreApp.MmPriser"%>
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
				priser</H3>
			<BR>
			<ASP:TEXTBOX id="txtTekstside" style="Z-INDEX: 112; LEFT: 88px; POSITION: absolute; TOP: 70px" runat="server" width="80px" height="22px"></ASP:TEXTBOX><ASP:TEXTBOX id="txtSide3" style="Z-INDEX: 105; LEFT: 88px; POSITION: absolute; TOP: 100px" tabIndex="1" runat="server" width="80px" height="22px"></ASP:TEXTBOX><ASP:TEXTBOX id="txtSide5" style="Z-INDEX: 107; LEFT: 88px; POSITION: absolute; TOP: 130px" tabIndex="2" runat="server" width="80px" height="22px"></ASP:TEXTBOX><ASP:TEXTBOX id="txtSide7" style="Z-INDEX: 108; LEFT: 88px; POSITION: absolute; TOP: 160px" tabIndex="3" runat="server" width="80px" height="22px"></ASP:TEXTBOX><ASP:TEXTBOX id="txtHøjreSide" style="Z-INDEX: 138; LEFT: 88px; POSITION: absolute; TOP: 190px" tabIndex="4" runat="server" width="80px" height="22px"></ASP:TEXTBOX><ASP:TEXTBOX id="txtBolig" style="Z-INDEX: 111; LEFT: 88px; POSITION: absolute; TOP: 220px" tabIndex="5" runat="server" width="80px" height="22px"></ASP:TEXTBOX><ASP:TEXTBOX id="txtMotorside" style="Z-INDEX: 113; LEFT: 88px; POSITION: absolute; TOP: 250px" tabIndex="6" runat="server" width="80px" height="22px"></ASP:TEXTBOX><ASP:TEXTBOX id="txtForlystelser" style="Z-INDEX: 102; LEFT: 88px; POSITION: absolute; TOP: 280px" tabIndex="7" runat="server" width="80px" height="22px"></ASP:TEXTBOX><ASP:TEXTBOX id="txtStillinger" style="Z-INDEX: 128; LEFT: 280px; POSITION: absolute; TOP: 70px" tabIndex="8" runat="server" width="80px" height="22px"></ASP:TEXTBOX><ASP:TEXTBOX id="txtOfficielle" style="Z-INDEX: 104; LEFT: 280px; POSITION: absolute; TOP: 100px" tabIndex="9" runat="server" width="80px" height="22px"></ASP:TEXTBOX><ASP:TEXTBOX id="txtUddannelse" style="Z-INDEX: 106; LEFT: 280px; POSITION: absolute; TOP: 130px" tabIndex="10" runat="server" width="80px" height="22px"></ASP:TEXTBOX><ASP:TEXTBOX id="txtRubrik" style="Z-INDEX: 110; LEFT: 280px; POSITION: absolute; TOP: 160px" tabIndex="11" runat="server" width="80px" height="22px"></ASP:TEXTBOX><ASP:TEXTBOX id="txtFarvetillæg" style="Z-INDEX: 114; LEFT: 280px; POSITION: absolute; TOP: 250px" tabIndex="13" runat="server" width="80px" height="22px" autopostback="True"></ASP:TEXTBOX><ASP:TEXTBOX id="txt4Farvetillæg" style="Z-INDEX: 103; LEFT: 280px; POSITION: absolute; TOP: 280px" tabIndex="16" runat="server" width="80px" height="22px" autopostback="True"></ASP:TEXTBOX>
			<DIV style="DISPLAY: inline; Z-INDEX: 115; LEFT: 12px; WIDTH: 72px; POSITION: absolute; TOP: 70px; HEIGHT: 22px" ms_positioning="FlowLayout">Tekstside</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 127; LEFT: 12px; WIDTH: 72px; POSITION: absolute; TOP: 100px; HEIGHT: 22px" ms_positioning="FlowLayout">Side 
				3</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 124; LEFT: 12px; WIDTH: 72px; POSITION: absolute; TOP: 130px; HEIGHT: 22px" ms_positioning="FlowLayout">Side 
				5</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 122; LEFT: 12px; WIDTH: 72px; POSITION: absolute; TOP: 160px; HEIGHT: 22px" ms_positioning="FlowLayout">Side 
				7</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 121; LEFT: 12px; WIDTH: 72px; POSITION: absolute; TOP: 190px; HEIGHT: 22px" ms_positioning="FlowLayout">Højre 
				Side</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 120; LEFT: 12px; WIDTH: 72px; POSITION: absolute; TOP: 220px; HEIGHT: 22px" ms_positioning="FlowLayout">Bolig</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 119; LEFT: 12px; WIDTH: 72px; POSITION: absolute; TOP: 250px; HEIGHT: 22px" ms_positioning="FlowLayout">Motorside</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 100; LEFT: 12px; WIDTH: 72px; POSITION: absolute; TOP: 280px; HEIGHT: 22px" ms_positioning="FlowLayout">Forlystelser</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 117; LEFT: 194px; WIDTH: 84px; POSITION: absolute; TOP: 70px; HEIGHT: 22px" ms_positioning="FlowLayout">Stillinger</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 126; LEFT: 194px; WIDTH: 84px; POSITION: absolute; TOP: 100px; HEIGHT: 22px" ms_positioning="FlowLayout">Officielle</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 125; LEFT: 194px; WIDTH: 84px; POSITION: absolute; TOP: 130px; HEIGHT: 22px" ms_positioning="FlowLayout">Uddannelse</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 123; LEFT: 194px; WIDTH: 84px; POSITION: absolute; TOP: 160px; HEIGHT: 22px" ms_positioning="FlowLayout">Rubrik</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 118; LEFT: 194px; WIDTH: 84px; POSITION: absolute; TOP: 250px; HEIGHT: 22px" ms_positioning="FlowLayout">Farve 
				tillæg</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 101; LEFT: 194px; WIDTH: 84px; POSITION: absolute; TOP: 280px; HEIGHT: 22px" ms_positioning="FlowLayout">4-farve 
				tillæg</DIV>
			<ASP:TEXTBOX id="txtFarveMin" style="Z-INDEX: 129; LEFT: 370px; POSITION: absolute; TOP: 250px" tabIndex="14" runat="server" width="80px" height="22px" visible="False">0</ASP:TEXTBOX><ASP:TEXTBOX id="txtFarveMax" style="Z-INDEX: 130; LEFT: 458px; POSITION: absolute; TOP: 250px" tabIndex="15" runat="server" width="80px" height="22px" visible="False">0</ASP:TEXTBOX><ASP:TEXTBOX id="txt4FarveMin" style="Z-INDEX: 131; LEFT: 370px; POSITION: absolute; TOP: 280px" tabIndex="17" runat="server" width="80px" height="22px" visible="False">0</ASP:TEXTBOX><ASP:TEXTBOX id="txt4FarveMax" style="Z-INDEX: 132; LEFT: 458px; POSITION: absolute; TOP: 280px" tabIndex="18" runat="server" width="80px" height="22px" visible="False">0</ASP:TEXTBOX><ASP:LABEL id="lblMin" style="Z-INDEX: 133; LEFT: 390px; POSITION: absolute; TOP: 233px" runat="server" width="65px" height="14px" visible="False">Min. Kr.</ASP:LABEL><ASP:LABEL id="lblMax" style="Z-INDEX: 134; LEFT: 470px; POSITION: absolute; TOP: 233px" runat="server" width="65px" height="14px" visible="False">Max. Kr.</ASP:LABEL><ASP:TEXTBOX id="txtBem" style="Z-INDEX: 135; LEFT: 400px; POSITION: absolute; TOP: 94px" tabIndex="19" runat="server" width="284px" height="71px" textmode="MultiLine"></ASP:TEXTBOX>
			<DIV style="DISPLAY: inline; Z-INDEX: 136; LEFT: 401px; WIDTH: 236px; POSITION: absolute; TOP: 70px; HEIGHT: 22px" ms_positioning="FlowLayout">Bemærkninger</DIV>
			<ASP:BUTTON id="btnGodkend" style="Z-INDEX: 137; LEFT: 567px; POSITION: absolute; TOP: 301px" runat="server" width="116px" height="27px" text="Godkend" tabIndex="20"></ASP:BUTTON></FORM>
	</BODY>
</HTML>
