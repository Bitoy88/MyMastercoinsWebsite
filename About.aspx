<%@ Page Title="Chart Simple Send" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="About.aspx.vb" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Simple Send MSC Volume</h2>
    <asp:Chart ID="Chart1" runat="server"  
    Width="692px">
        <Series>
            <asp:Series Name="Series1" XValueMember="Expr2" YValueMembers="Expr1">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>


</asp:Content>
