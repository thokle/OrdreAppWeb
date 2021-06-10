<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BemForm.aspx.vb" Inherits="OrdreApp.BemForm"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
    <TITLE>Bemærkning til DLU fra
      <%#BladNavn%>
      i Uge
      <%#Uge%>
    </TITLE>
    <META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
    <META content="Visual Basic 7.0" name="CODE_LANGUAGE">
    <META content="JavaScript" name="vs_defaultClientScript">
    <META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <LINK href="OrdreStyles.css" type="text/css" rel="stylesheet">
  </HEAD>
  <BODY ms_positioning="GridLayout">
    <FORM id="BemForm" method="post" runat="server">
      <H1>Bemærkning til DLU fra
        <%#BladNavn%>
        i Uge
        <%#Uge%>
        .</H1>
      <ASP:TEXTBOX id="txtBem" style="Z-INDEX: 101; LEFT: 20px; POSITION: absolute; TOP: 113px" runat="server" height="108px" width="940px" textmode="MultiLine"></ASP:TEXTBOX>
      <ASP:BUTTON id="btnOpdater" style="Z-INDEX: 102; LEFT: 420px; POSITION: absolute; TOP: 241px" runat="server" height="23px" width="140px" text="Opdater"></ASP:BUTTON>
      <DIV style="DISPLAY: inline; Z-INDEX: 103; LEFT: 22px; WIDTH: 896px; POSITION: absolute; TOP: 92px; HEIGHT: 28px" ms_positioning="FlowLayout">
        <P>Click i vinduet herunder, for at skrive din bemærkning. Når du trykker på 
          opdater, kommer du automatisk tilbage til Annoncekontrol.</P>
      </DIV>
    </FORM>
  </BODY>
</HTML>
