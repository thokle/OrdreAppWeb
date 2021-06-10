<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SekundaerOmraader.aspx.vb" Inherits="OrdreApp.SekundaerPost" EnableSessionState="False" buffer="True"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sekundære dækningsområder for
			<%#BladNavn%>
			.</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="OrdreStyles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="OrdreForm" method="post" runat="server">
			<h1>
				<asp:HyperLink id="PrimLink" style="Z-INDEX: 106; LEFT: 592px; POSITION: absolute; TOP: 176px" runat="server" Height="13px" Width="130px" CssClass="HelpLink">Gå Til Primær områder</asp:HyperLink>
				<asp:RequiredFieldValidator id="RequiredFieldValidator1" style="Z-INDEX: 108; LEFT: 408px; POSITION: absolute; TOP: 295px" runat="server" Width="207px" Height="23px" ControlToValidate="txtPostPrim" ErrorMessage="Der skal indtastes et post nr."></asp:RequiredFieldValidator>
				<asp:RangeValidator id="RangeValidator1" style="Z-INDEX: 107; LEFT: 407px; POSITION: absolute; TOP: 270px" runat="server" Width="263px" Height="17px" Type="Integer" MinimumValue="1000" MaximumValue="9999" ControlToValidate="txtPostPrim" ErrorMessage="Post nr. skal være mellem 1000 og 9999"></asp:RangeValidator>Sekundære 
				dækningsområder for
				<%#BladNavn%>
				.</h1>
			<asp:datagrid id=grdPrim style="Z-INDEX: 101; LEFT: 33px; POSITION: absolute; TOP: 136px" runat="server" DataMember="tblDækningAnden" DataKeyField="BladId" DataSource="<%# Dst %>" AutoGenerateColumns="False" Width="337px" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical" Height="87px">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
				<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
				<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="PostNr" SortExpression="PostNr" HeaderText="Post Nr">
						<HeaderStyle Width="100px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Byen" SortExpression="Byen" HeaderText="Post By">
						<HeaderStyle Width="300px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:ButtonColumn Text="Slet" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
			<DIV style="DISPLAY: inline; Z-INDEX: 102; LEFT: 36px; WIDTH: 344px; POSITION: absolute; TOP: 98px; HEIGHT: 28px" ms_positioning="FlowLayout">Sekundære&nbsp;dækningsområder 
				(Dækning&nbsp;under 80%)</DIV>
			<asp:textbox id="txtPostPrim" style="Z-INDEX: 103; LEFT: 436px; POSITION: absolute; TOP: 185px" runat="server" Width="58px" Height="25px" MaxLength="4"></asp:textbox><asp:button id="btnAddPostNr" style="Z-INDEX: 104; LEFT: 423px; POSITION: absolute; TOP: 234px" runat="server" Width="92px" Height="22px" Text="Tilføj PostNr"></asp:button>
			<DIV style="DISPLAY: inline; Z-INDEX: 105; LEFT: 403px; WIDTH: 137px; POSITION: absolute; TOP: 144px; HEIGHT: 19px" ms_positioning="FlowLayout">Indtast 
				nyt post nr.</DIV>
		</form>
	</body>
</HTML>
