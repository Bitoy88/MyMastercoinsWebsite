<%@ Page Title="Chart Simple Send" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="CurrencyCharts.aspx.vb" Inherits="CurrencyCharts" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>
        Currency Chart</h2>


    <asp:Chart ID="Chart1" runat="server" 
        Width="691px">
        <Series>
            <asp:Series Name="Series1" ChartType="Line">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>


</asp:Content>
