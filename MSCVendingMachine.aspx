<%@ Page Title="About Us" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="MSCVendingMachine.aspx.vb" Inherits="VendingMachine" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        MyMastercoins Vending Machine</h2>
        
        Easiest way to buy MSC.   Simply send Bitcoins to <br/>
        <h2>
        <asp:Label ID="lblBTCAddress" runat="server"></asp:Label>
        </h2>
        1 MSC = <asp:Label ID="lblMSCPrice" runat="server"></asp:Label> MSC

</asp:Content>