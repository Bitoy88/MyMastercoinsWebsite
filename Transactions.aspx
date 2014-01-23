<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Transactions.aspx.vb" Inherits="Transactions" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Text=""></asp:Label>
        <br/>

            <asp:GridView ID="GVTrans" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" ForeColor="Black" GridLines="Horizontal"  >
            <Columns>
                <asp:TemplateField HeaderText="Tx ID"  >
    <ItemTemplate>
   <asp:HyperLink ID="HyperLink1" runat="server"  Text=<%# (Eval("ExodusID"))%> NavigateUrl=<%# ("default.aspx?XID=" + Eval("ExodusID").tostring  )  %>  ></asp:HyperLink>     
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="Date"  ItemStyle-HorizontalAlign="Right" 
                    DataField="dTrans" >
<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Tx ID" DataField="TxID"  />
                <asp:BoundField HeaderText="Block No." DataField="BlockNumber"  />
                <asp:TemplateField HeaderText=""  >
    <ItemTemplate>
        <%# IIf(Eval("Isvalid"), "<font color=GREEN>Valid</FONT>", "<small>invalid</small>")%>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="Remarks" DataField="Remarks"  />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>

    </div>
</asp:Content> 
