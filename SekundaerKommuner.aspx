<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SekundaerKommuner.aspx.vb" Inherits="OrdreApp.SekuKommune" EnableSessionState="False" buffer="True"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sekundære kommuner for
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
			<h1>Sekundære kommuner for
				<%#BladNavn%>
				.</h1>
			<asp:datagrid id=grdPrim style="Z-INDEX: 101; LEFT: 33px; POSITION: absolute; TOP: 136px" runat="server" DataMember="tblSekundaerKommuner" DataKeyField="BladId" DataSource="<%# Dst %>" AutoGenerateColumns="False" Width="337px" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical" Height="81px">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
				<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
				<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="Kommune" SortExpression="Kommune" HeaderText="Kommune"></asp:BoundColumn>
					<asp:ButtonColumn Text="Slet" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
			<DIV style="DISPLAY: inline; Z-INDEX: 102; LEFT: 36px; WIDTH: 320px; POSITION: absolute; TOP: 98px; HEIGHT: 22px" ms_positioning="FlowLayout">
				Sekundære&nbsp;kommuner</DIV>
			<asp:textbox id="txtSekuKom" style="Z-INDEX: 103; LEFT: 426px; POSITION: absolute; TOP: 185px" runat="server" Width="212px" Height="25px" MaxLength="30"></asp:textbox><asp:button id="btnAddPostNr" style="Z-INDEX: 104; LEFT: 423px; POSITION: absolute; TOP: 234px" runat="server" Width="105px" Height="22px" Text="Tilføj Kommune"></asp:button>
			<asp:HyperLink id="SekLink" style="Z-INDEX: 106; LEFT: 590px; POSITION: absolute; TOP: 112px" runat="server" Width="130px" Height="13px" CssClass="HelpLink">Gå Til Primære kommuner</asp:HyperLink>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" style="Z-INDEX: 108; LEFT: 413px; POSITION: absolute; TOP: 294px" runat="server" Height="23px" Width="207px" ErrorMessage="Der skal indtastes en kommune." ControlToValidate="txtSekuKom"></asp:RequiredFieldValidator></form>
	</body>
</HTML>
