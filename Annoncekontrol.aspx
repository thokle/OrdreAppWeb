<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Annoncekontrol.aspx.vb" Inherits="OrdreApp.Annoncekontrol" EnableSessionState="False" buffer="True"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
    <head>
        <title>Annoncekontrol for
            <%#BladNavn%>i Uge
            <%#Uge%>
        </title>
        <meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR" />
        <meta content="Visual Basic 7.0" name="CODE_LANGUAGE" />
        <meta content="JavaScript" name="vs_defaultClientScript" />
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
        <link href="OrdreStyles.css" type="text/css" rel="stylesheet" />
        <style type="text/css">
          .style1
          {
            z-index: 101;
            left: 20px;
            position: absolute;
            top: 107px;
            width: 935px;
            height: 68px;
          }
        </style>
    </head>
    <body ms_positioning="GridLayout">
        <form id="OrdreForm" method="post" runat="server">
            <h1>Annoncekontrol for     <%#BladNavn%>i Uge <%#Uge%>.</h1>
            <asp:datagrid id="grdOrdrer" 
              runat="server" DataMember="tblMedieplanLinjer" DataKeyField="OrdreNr" 
              DataSource="<%# Dst %>" AutoGenerateColumns="False" BorderColor="#999999" 
              BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="0" 
              GridLines="Vertical" CssClass="style1" Width="935px">
                <AlternatingItemStyle Font-Size="14px" BackColor="Gainsboro"></AlternatingItemStyle>
                <Columns>
                  <asp:BoundColumn DataField="Annoncør" HeaderText="Annoncør" ReadOnly="True">
                    <HeaderStyle Width="210px" />
                  </asp:BoundColumn>
                  <asp:BoundColumn DataField="Format" HeaderText="Format" ReadOnly="True">
                    <HeaderStyle Width="50px" />
                  </asp:BoundColumn>
                  <asp:TemplateColumn HeaderText="Farver">
                    <ItemTemplate>
                      <asp:Label ID="lblFarver" runat="server" 
                        Text='<%# DataBinder.Eval(Container, "DataItem.AntalFarver") & " " & iif(DataBinder.Eval(Container,"DataItem.AntalFarver")=1,DataBinder.Eval(Container,"DataItem.Kulør"),"") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="70px" />
                  </asp:TemplateColumn>
                  <asp:BoundColumn DataField="Betegnelse" HeaderText="Placering" ReadOnly="True">
                    <HeaderStyle Width="90px" />
                  </asp:BoundColumn>
                  <asp:TemplateColumn HeaderText="Ordre Nr.">
                    <ItemTemplate>
                      <asp:Label ID="Label4" runat="server" 
                        Text='<%# DataBinder.Eval(Container, "DataItem.OrdreNr") %>' 
                        Visible='<%# DataBinder.Eval (Container,"DataItem.EnOrdre") %>'>
                            </asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="75px" />
                  </asp:TemplateColumn>
                  <asp:TemplateColumn HeaderText="Ok">
                    <EditItemTemplate>
                      <asp:Button ID="btnSend" runat="server" commandname="Send" font-bold="True" 
                        height="23px" text="Send" tooltip="Click for at opdatere Ordren" 
                        width="40px" BorderWidth="1px" />
                    </EditItemTemplate>
                    <ItemTemplate>
                      <asp:Button ID="btnJa" runat="server" CommandName='<%# iif (DataBinder.Eval (Container,"DataItem.SlutVist")=0,"Ja","Ok") %>' 
                        Enabled='<%# iif (DataBinder.Eval (Container,"DataItem.SlutVist")=0,"True","False") %>' 
                        Font-Bold="True" Height="23px" 
                        Text='<%# iif (DataBinder.Eval (Container,"DataItem.SlutVist")=0,"Ja","Ok") %>' 
                        ToolTip='<%# iif (DataBinder.Eval (Container,"DataItem.SlutVist")=0,"Click hvis ordren er OK","Ordren er sendt") %>' 
                        Width="53px" BorderWidth="1px" />
                      <asp:Button ID="btnNej" runat="server" commandname="Nej" font-bold="True" 
                        height="23px" text="Nej" tooltip="Click hvis der var fejl i Ordren" 
                        width="37px" BorderWidth="1px" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="95px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="False" 
                      Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                      Font-Underline="False" />
                  </asp:TemplateColumn>
                  <asp:TemplateColumn HeaderText="Side">
                    <EditItemTemplate>
                      <asp:TextBox ID="txtSide" runat="server" Height="19px" 
                        Text='<%# DataBinder.Eval(Container, "DataItem.SidePlacering") %>' 
                        Width="35px" BorderWidth="1px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblSide" runat="server" Height="25px" 
                        Text='<%# DataBinder.Eval(Container, "DataItem.SidePlacering") %>' Width="35px"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="40px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:TemplateColumn>
                  <asp:TemplateColumn HeaderText="Fejl">
                    <EditItemTemplate>
                      <asp:DropDownList ID="DropDownList2" runat="server"   SelectedIndex='<%# DataBinder.Eval (Container, "DataItem.FejlID") %>' 
                        Width="175px" Height ="25px" Visible='<%# iif (FejlIAnnonce=1,"true","false") %>'>
                        <asp:ListItem value="0" Selected="True">Ingen valgt</asp:ListItem>
                        <asp:ListItem value="1">Bestilt efter deadline</asp:ListItem>
                        <asp:ListItem value="2">Ordre ikke modtaget</asp:ListItem>
                        <asp:ListItem value="3">Glemt annonce</asp:ListItem>
                        <asp:ListItem value="4">DLU har fremsendt forkert materiale</asp:ListItem>
                        <asp:ListItem value="5">Vi har indrykket forkert materiale</asp:ListItem>
                        <asp:ListItem value="6">Forkert farve</asp:ListItem>
                        <asp:ListItem value="7">Forkert placering</asp:ListItem>
                        <asp:ListItem value="8">Forkert annoce format</asp:ListItem>
                        <asp:ListItem value="9">Glemt farve</asp:ListItem>
                      </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                      <asp:Label ID="lblFejl" runat="server" 
                        Text='<%# FejlTekst (DataBinder.Eval (Container, "DataItem.FejlID")) %>' 
                        Width="170px"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="150px" />
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                      Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                      VerticalAlign="Middle" />
                  </asp:TemplateColumn>
                  <asp:BoundColumn DataField="OrdreNr" ReadOnly="True" Visible="False">
                  </asp:BoundColumn>
                  <asp:BoundColumn DataField="EnOrdre" ReadOnly="True" Visible="False">
                  </asp:BoundColumn>
                </Columns>
                <EditItemStyle Font-Size="14px" />
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" Font-Size="14px" 
                  ForeColor="White" />
                <ItemStyle Font-Size="14px" ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
                <PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
                <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" Font-Size="14px" 
                  ForeColor="White" />
            </asp:datagrid><ASP:HYPERLINK id="HyperLink" style="Z-INDEX: 102; LEFT: 777px; POSITION: absolute; TOP: 77px" runat="server" cssclass="HelpLink" height="14px" width="182px" navigateurl="Help.htm">Hjælp til Annonce kontrol</ASP:HYPERLINK>
        </form>
    </body>
</html>
