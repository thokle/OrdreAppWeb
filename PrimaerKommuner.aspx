<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PrimaerKommuner.aspx.vb" Inherits="OrdreApp.PrimKommune" EnableSessionState="False" buffer="True"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Primære kommuner for
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
			<H1>Primære kommuner for
				<%#BladNavn%>
				.</H1>
			<asp:datagrid id=grdPrim style="Z-INDEX: 101; LEFT: 33px; POSITION: absolute; TOP: 136px" runat="server" DataMember="tblPrimaerKommuner" DataKeyField="BladId" DataSource="<%# Dst %>" AutoGenerateColumns="False" Width="337px" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical" Height="81px">
				<SELECTEDITEMSTYLE font-bold="True" forecolor="White" backcolor="#008A8C"></SELECTEDITEMSTYLE>
				<ALTERNATINGITEMSTYLE backcolor="Gainsboro"></ALTERNATINGITEMSTYLE>
				<ITEMSTYLE forecolor="Black" backcolor="#EEEEEE"></ITEMSTYLE>
				<HEADERSTYLE font-bold="True" forecolor="White" backcolor="#000084"></HEADERSTYLE>
				<FOOTERSTYLE forecolor="Black" backcolor="#CCCCCC"></FOOTERSTYLE>
				<COLUMNS>
					<ASP:BOUNDCOLUMN datafield="Kommune" sortexpression="Kommune" headertext="Kommune"></ASP:BOUNDCOLUMN>
					<ASP:BUTTONCOLUMN text="Slet" buttontype="PushButton" commandname="Delete"></ASP:BUTTONCOLUMN>
				</COLUMNS>
				<PAGERSTYLE horizontalalign="Center" forecolor="Black" backcolor="#999999" mode="NumericPages"></PAGERSTYLE>
			</asp:datagrid>
			<DIV style="DISPLAY: inline; Z-INDEX: 102; LEFT: 36px; WIDTH: 184px; POSITION: absolute; TOP: 98px; HEIGHT: 22px" ms_positioning="FlowLayout">
				Primære&nbsp;kommuner&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</DIV>
			<ASP:TEXTBOX id="txtPrimKom" style="Z-INDEX: 103; LEFT: 426px; POSITION: absolute; TOP: 185px" runat="server" width="212px" height="25px" maxlength="30"></ASP:TEXTBOX><ASP:BUTTON id="btnAddPostNr" style="Z-INDEX: 104; LEFT: 423px; POSITION: absolute; TOP: 234px" runat="server" width="105px" height="22px" text="Tilføj Kommune"></ASP:BUTTON>
			<ASP:REQUIREDFIELDVALIDATOR id="RequiredFieldValidator1" style="Z-INDEX: 106; LEFT: 413px; POSITION: absolute; TOP: 294px" runat="server" height="23px" width="207px" errormessage="Der skal indtastes en kommune." controltovalidate="txtPrimKom"></ASP:REQUIREDFIELDVALIDATOR>
		</FORM>
	</BODY>
</HTML>
