<%@ Page Title="About Us" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="CompareAddressTrans.aspx.vb" Inherits="CompareAddressTrans" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
        &nbsp;<asp:TextBox ID="txtTxID" runat="server" 
        Text="" Font-Size="Large"    Width="400px" 
        ToolTip="Enter a Transaction ID or Bitcoin Address"  ></asp:TextBox> 
        <asp:Button ID="btnCheckME0" runat="server" Text="Compare" 
            Width="260px" />
    <p>
        &nbsp;<p>
        <asp:Label ID="lblData" runat="server"></asp:Label>
    
</asp:Content>