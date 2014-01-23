<%@ Page Title="Chart Simple Send" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="MSCStats.aspx.vb" Inherits="MSCStats" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        MSC Statistics</h2>
    <asp:Chart ID="Chart1" runat="server"  
    Width="692px">
        <Series>
            <asp:Series Name="Series1" XValueMember="Expr2" YValueMembers="Expr1" 
                ChartType="Pie" Legend="Legend1">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <Area3DStyle Enable3D="True" />
            </asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1" Title="No. of Address">
            </asp:Legend>
        </Legends>
    </asp:Chart>


    <asp:Chart ID="Chart2" runat="server"  
    Width="692px">
        <Series>
            <asp:Series Name="Series1" XValueMember="Expr2" YValueMembers="Expr1" 
                ChartType="Pie">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <Area3DStyle Enable3D="True" />
            </asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1" Title="Total MSC">
            </asp:Legend>
        </Legends>
    </asp:Chart>


</asp:Content>
