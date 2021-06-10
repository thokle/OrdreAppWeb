<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PF.aspx.vb" Inherits="OrdreApp.PF"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Prisforespørgsel fra DLU.</TITLE>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="OrdreStyles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY ms_positioning="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<ASP:LABEL id="visAntalIndrykn" style="Z-INDEX: 121; LEFT: 140px; POSITION: absolute; TOP: 120px" runat="server" width="648px" height="20px">Antal indrykn.</ASP:LABEL>
			<ASP:LABEL id="lblPlacering" style="Z-INDEX: 118; LEFT: 40px; POSITION: absolute; TOP: 192px" runat="server" width="88px" height="20px" enableviewstate="False">Placering</ASP:LABEL>
			<ASP:LABEL id="visFarver" style="Z-INDEX: 117; LEFT: 140px; POSITION: absolute; TOP: 168px" runat="server" width="648px" height="20px">Farver</ASP:LABEL>
			<ASP:LABEL id="lblFormat" style="Z-INDEX: 114; LEFT: 40px; POSITION: absolute; TOP: 144px" runat="server" width="88px" height="20px" enableviewstate="False">Format</ASP:LABEL>
			<ASP:LABEL id="visMediebureau" style="Z-INDEX: 113; LEFT: 140px; POSITION: absolute; TOP: 96px" runat="server" width="648px" height="20px">Mediebureau</ASP:LABEL>
			<ASP:LABEL id="visAnnoncør" style="Z-INDEX: 111; LEFT: 140px; POSITION: absolute; TOP: 72px" runat="server" width="648px" height="20px">Annonør</ASP:LABEL>
			<ASP:LABEL id="lblMVH" 
              style="Z-INDEX: 143; LEFT: 40px; POSITION: absolute; TOP: 597px" runat="server" 
              width="256px" height="20px">Med venlig hilsen<BR>Annette Niebuhr</ASP:LABEL>
			<ASP:LABEL id="lblAntalIndrykn" style="Z-INDEX: 120; LEFT: 40px; POSITION: absolute; TOP: 120px" runat="server" width="88px" height="20px" enableviewstate="False">Antal indrykn.</ASP:LABEL>
			<ASP:LABEL id="visPlacering" style="Z-INDEX: 119; LEFT: 140px; POSITION: absolute; TOP: 192px" runat="server" width="648px" height="20px">Placering</ASP:LABEL>
			<ASP:TEXTBOX id="txtBladBemærkning" style="Z-INDEX: 140; LEFT: 137px; POSITION: absolute; TOP: 475px" runat="server" width="648px" height="80px" textmode="MultiLine" visible="False"></ASP:TEXTBOX>
			<ASP:LABEL id="lblFarver" style="Z-INDEX: 116; LEFT: 40px; POSITION: absolute; TOP: 168px" runat="server" width="88px" height="20px" enableviewstate="False">Farver</ASP:LABEL>
			<ASP:LABEL id="visFormat" style="Z-INDEX: 115; LEFT: 140px; POSITION: absolute; TOP: 144px" runat="server" width="648px" height="20px">Format</ASP:LABEL>
			<ASP:LABEL id="lblMediebureau" style="Z-INDEX: 112; LEFT: 40px; POSITION: absolute; TOP: 96px" runat="server" width="88px" height="20px" enableviewstate="False">Mediebureau</ASP:LABEL>
			<ASP:TEXTBOX id="txtDLUMmRabat" style="Z-INDEX: 102; LEFT: 352px; POSITION: absolute; TOP: 308px" runat="server" width="70px" height="20px" readonly="True"></ASP:TEXTBOX>
			<ASP:TEXTBOX id="txtDLUFarvetillæg" style="Z-INDEX: 104; LEFT: 436px; POSITION: absolute; TOP: 308px" runat="server" width="70px" height="20px" readonly="True"></ASP:TEXTBOX>
			<ASP:TEXTBOX id="txtDLUFarveRabat" style="Z-INDEX: 107; LEFT: 516px; POSITION: absolute; TOP: 308px" runat="server" width="70px" height="20px" readonly="True"></ASP:TEXTBOX>
			<ASP:TEXTBOX id="txtBladMmPris" style="Z-INDEX: 108; LEFT: 272px; POSITION: absolute; TOP: 368px" runat="server" width="70px" height="20px" visible="False"></ASP:TEXTBOX>
			<ASP:TEXTBOX id="txtBladMmRabat" style="Z-INDEX: 103; LEFT: 352px; POSITION: absolute; TOP: 368px" runat="server" width="70px" height="20px" visible="False"></ASP:TEXTBOX>
			<ASP:TEXTBOX id="txtBladFarvetillæg" style="Z-INDEX: 105; LEFT: 436px; POSITION: absolute; TOP: 368px" runat="server" width="70px" height="20px" visible="False"></ASP:TEXTBOX>
			<ASP:TEXTBOX id="txtBladFarveRabat" style="Z-INDEX: 106; LEFT: 516px; POSITION: absolute; TOP: 368px" runat="server" width="70px" height="20px" visible="False"></ASP:TEXTBOX>
			<ASP:LABEL id="lblTilBlad" style="Z-INDEX: 100; LEFT: 20px; POSITION: absolute; TOP: 16px" runat="server" width="832px" height="20px" font-bold="True">Label</ASP:LABEL>
			<ASP:LABEL id="lblBesvaretAf" style="Z-INDEX: 101; LEFT: 20px; POSITION: absolute; TOP: 40px" runat="server" width="832px" height="20px" font-bold="True">Label</ASP:LABEL>
			<ASP:TEXTBOX id="txtDLUMmpris" style="Z-INDEX: 109; LEFT: 272px; POSITION: absolute; TOP: 308px" runat="server" width="70px" height="20px" readonly="True"></ASP:TEXTBOX>
			<ASP:LABEL id="lblAnnoncør" style="Z-INDEX: 110; LEFT: 40px; POSITION: absolute; TOP: 72px" runat="server" width="88px" height="20px" enableviewstate="False">Annoncør</ASP:LABEL>
			<ASP:TEXTBOX id="visBemærkning" style="Z-INDEX: 122; LEFT: 140px; POSITION: absolute; TOP: 216px" runat="server" width="648px" height="60px" readonly="True" textmode="MultiLine"></ASP:TEXTBOX>
			<ASP:LABEL id="lblBemærkning" style="Z-INDEX: 126; LEFT: 40px; POSITION: absolute; TOP: 220px" runat="server" width="88px" height="20px" enableviewstate="False">Bemærkning</ASP:LABEL>
			<ASP:LABEL id="lblDLUForslag" style="Z-INDEX: 124; LEFT: 40px; POSITION: absolute; TOP: 288px" runat="server" width="104px" height="20px" enableviewstate="False" font-bold="True">DLU's forslag</ASP:LABEL>
			<ASP:LABEL id="lblDLUmmPris" style="Z-INDEX: 127; LEFT: 272px; POSITION: absolute; TOP: 288px" runat="server" width="70px" height="20px" enableviewstate="False" font-bold="True">kr./mm</ASP:LABEL>
			<ASP:LABEL id="lblDLUmmRabat" style="Z-INDEX: 129; LEFT: 352px; POSITION: absolute; TOP: 288px" runat="server" width="70px" height="20px" enableviewstate="False" font-bold="True">rabat</ASP:LABEL>
			<ASP:LABEL id="lblDLUFarvetillæg" style="Z-INDEX: 130; LEFT: 432px; POSITION: absolute; TOP: 288px" runat="server" width="70px" height="20px" enableviewstate="False" font-bold="True">farvetillæg</ASP:LABEL>
			<ASP:LABEL id="lblDLUfarverabat" style="Z-INDEX: 131; LEFT: 516px; POSITION: absolute; TOP: 288px" runat="server" width="70px" height="20px" enableviewstate="False" font-bold="True">rabat</ASP:LABEL>
			<ASP:BUTTON id="btnGodkend" 
              style="Z-INDEX: 132; LEFT: 644px; POSITION: absolute; TOP: 308px" 
              runat="server" width="144px" height="24px" text="Godkend forslag"></ASP:BUTTON>
			<ASP:BUTTON id="btnÆndringer" style="Z-INDEX: 133; LEFT: 644px; POSITION: absolute; TOP: 344px" runat="server" width="144px" height="24px" text="Ændringer til forslag"></ASP:BUTTON>
			<ASP:LABEL id="lblPlaceringUB" 
              style="Z-INDEX: 134; LEFT: 376px; POSITION: absolute; TOP: 677px" 
              runat="server" width="204px" height="20px" enableviewstate="False" 
              font-bold="True">Kan der ydes placering u/b</ASP:LABEL>
			<TABLE id="PlaceringTable" 
              style="FONT-SIZE: 12px; Z-INDEX: 135; LEFT: 244px; WIDTH: 348px; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 697px; HEIGHT: 52px; TEXT-ALIGN: center" 
              cellspacing="1" cellpadding="1" width="348" border="1" runat="server">
				<TR>
					<TD style="WIDTH: 78px">side 3,5,7</TD>
					<TD style="WIDTH: 109px">Høj. side f. midt</TD>
					<TD style="WIDTH: 71px">Høj. side</TD>
					<TD>nej</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 78px"><ASP:CHECKBOX id="chk357" runat="server" text=" " autopostback="True"></ASP:CHECKBOX></TD>
					<TD style="WIDTH: 109px"><ASP:CHECKBOX id="chkHsFm" runat="server" text=" " autopostback="True"></ASP:CHECKBOX></TD>
					<TD style="WIDTH: 71px"><ASP:CHECKBOX id="chkHøjSide" runat="server" text=" " autopostback="True"></ASP:CHECKBOX></TD>
					<TD><ASP:CHECKBOX id="chkNej" runat="server" text=" " autopostback="True"></ASP:CHECKBOX></TD>
				</TR>
			</TABLE>
			<ASP:LABEL id="lblÆndring" style="Z-INDEX: 123; LEFT: 40px; POSITION: absolute; TOP: 348px" runat="server" width="104px" height="20px" enableviewstate="False" font-bold="True" visible="False">Ændring</ASP:LABEL>
			<ASP:LABEL id="lblBladmmpris" style="Z-INDEX: 128; LEFT: 272px; POSITION: absolute; TOP: 348px" runat="server" width="70px" height="20px" enableviewstate="False" font-bold="True" visible="False">kr./mm</ASP:LABEL>
			<ASP:LABEL id="lblBladmmRabat" style="Z-INDEX: 136; LEFT: 352px; POSITION: absolute; TOP: 348px" runat="server" width="70px" height="20px" enableviewstate="False" font-bold="True" visible="False">rabat</ASP:LABEL>
			<ASP:LABEL id="lblBladfarvetillæg" style="Z-INDEX: 137; LEFT: 432px; POSITION: absolute; TOP: 348px" runat="server" width="70px" height="20px" enableviewstate="False" font-bold="True" visible="False">farvetillæg</ASP:LABEL>
			<ASP:LABEL id="lblBladfarverabat" style="Z-INDEX: 138; LEFT: 516px; POSITION: absolute; TOP: 348px" runat="server" width="70px" height="20px" enableviewstate="False" font-bold="True" visible="False">rabat</ASP:LABEL>
			<ASP:LABEL id="lblBladBemærkning" 
              style="Z-INDEX: 139; LEFT: 40px; POSITION: absolute; TOP: 455px; width: 288px;" 
              runat="server" height="20px" enableviewstate="False" visible="False" 
              font-bold="True">Bemærkning til ændring (max. 250 tegn)</ASP:LABEL>
			<ASP:LABEL id="lblMarker" style="Z-INDEX: 144; LEFT: 250px; POSITION: absolute; TOP: 646px" runat="server" height="16px" width="168px" font-size="XX-Small">Markér ét felt</ASP:LABEL></FORM>
	</BODY>
</HTML>
