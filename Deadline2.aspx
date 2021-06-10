<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Deadline2.aspx.vb" Inherits="OrdreApp.Deadline2"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Deadline for julen 2010.</TITLE>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="OrdreStyles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY ms_positioning="GridLayout">
		<FORM id="DeadlineForm" method="post" runat="server">
			<H1><%#BladNavn%></H1>
			<DIV style="Z-INDEX: 100; LEFT: 6px; WIDTH: 654px; POSITION: absolute; TOP: 68px; HEIGHT: 18px" ms_positioning="FlowLayout">&nbsp;&nbsp; Deadline for annoncer&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
				Deadline for materiale</DIV>
			<DIV style="Z-INDEX: 102; LEFT: 80px; WIDTH: 25px; POSITION: absolute; TOP: 88px; HEIGHT: 14px" 
              ms_positioning="FlowLayout">dag</DIV>
			<DIV style="Z-INDEX: 103; LEFT: 170px; WIDTH: 25px; POSITION: absolute; TOP: 88px; HEIGHT: 11px" ms_positioning="FlowLayout">kl.</DIV>
			<DIV style="Z-INDEX: 104; LEFT: 270px; WIDTH: 25px; POSITION: absolute; TOP: 88px; HEIGHT: 11px" ms_positioning="FlowLayout">dag</DIV>
			<DIV style="Z-INDEX: 105; LEFT: 360px; WIDTH: 25px; POSITION: absolute; TOP: 88px; HEIGHT: 11px" ms_positioning="FlowLayout">kl.</DIV>
			<DIV style="Z-INDEX: 104; LEFT: 10px; WIDTH: 25px; POSITION: absolute; TOP: 112px; HEIGHT: 11px" ms_positioning="FlowLayout">tekst</DIV>
			<DIV style="Z-INDEX: 104; LEFT: 10px; WIDTH: 25px; POSITION: absolute; TOP: 140px; HEIGHT: 11px" ms_positioning="FlowLayout">rubrik</DIV>
			 
			<ASP:DROPDOWNLIST id="lstOrdreUge1" 
              style="Z-INDEX: 108; LEFT: 60px; POSITION: absolute; TOP: 112px; width: 70px;" 
              runat="server" height="18px"></ASP:DROPDOWNLIST>
              <ASP:DROPDOWNLIST id="lstOrdreTidUge1" style="Z-INDEX: 109; LEFT: 150px; POSITION: absolute; TOP: 112px" runat="server" width="60px" height="18px"></ASP:DROPDOWNLIST>
            <ASP:DROPDOWNLIST id="lstMaterialeUge1" 
              style="Z-INDEX: 110; LEFT: 250px; POSITION: absolute; TOP: 112px; width: 70px;" 
              runat="server" height="18px"></ASP:DROPDOWNLIST>
              <ASP:DROPDOWNLIST id="lstMaterialeTidUge1" style="Z-INDEX: 111; LEFT: 340px; POSITION: absolute; TOP: 112px" runat="server" width="60px" height="18px"></ASP:DROPDOWNLIST>

            <ASP:BUTTON id="btnOpdater" 
              style="Z-INDEX: 154; LEFT: 190px; POSITION: absolute; TOP: 177px" 
              runat="server" text="Opdater" width="76px" height="24px"></ASP:BUTTON>
           
			<ASP:DROPDOWNLIST id="lstOrdreUge2" 
              style="Z-INDEX: 108; LEFT: 60px; POSITION: absolute; TOP: 140px; width: 70px;" 
              runat="server" height="18px"></ASP:DROPDOWNLIST>
            <ASP:DROPDOWNLIST id="lstOrdreTidUge2" 
              style="Z-INDEX: 109; LEFT: 150px; POSITION: absolute; TOP: 140px" 
              runat="server" width="60px" height="18px"></ASP:DROPDOWNLIST>
            <ASP:DROPDOWNLIST id="lstMaterialeUge2" 
              style="Z-INDEX: 110; LEFT: 250px; POSITION: absolute; TOP: 140px; width: 70px;" 
              runat="server" height="18px"></ASP:DROPDOWNLIST>
            <ASP:DROPDOWNLIST id="lstMaterialeTidUge2" 
              style="Z-INDEX: 111; LEFT: 340px; POSITION: absolute; TOP: 140px" 
              runat="server" width="60px" height="18px"></ASP:DROPDOWNLIST>

        </FORM>
	</BODY>
</HTML>
