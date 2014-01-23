<%@ Page Title="MyMastercoins Buying and Selling" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Orders.aspx.vb" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Selling  <asp:Label ID="lblCurrency" runat="server" Font-Bold="True"  
        Text=""></asp:Label>

    </h2>

        <asp:GridView ID="GVSell" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" ForeColor="Black" GridLines="Horizontal"  >
            <Columns>
                <asp:BoundField HeaderText="CFS ID"  DataField="CurrencyforSaleID"/>
                <asp:BoundField HeaderText="Date" ItemStyle-Width="80"  DataField="dTrans"/>

                <asp:TemplateField HeaderText="Available"  >
    <ItemTemplate  >
        <%# Math.Round((Eval("Available")), 8)%>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Pending"  >
    <ItemTemplate  >
        <%# Math.Round(GetPending(Eval("CurrencyforSaleID")), 8)%>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Unit Price"  >
    <ItemTemplate  >
        <%# Math.Round((Eval("BTCDesired") / Eval("AmountforSale")), 8)%>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="Total BTC"  ItemStyle-HorizontalAlign="Right" 
                    DataField="BTCDesired" DataFormatString="{0:########.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Time Limit"  DataField="TimeLimit" >
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Seller ID"  >
    <ItemTemplate>
   <asp:HyperLink runat="server"  Text=<%# ((new mymastercoins).GetShortAddress(Eval("AddressID")))%> NavigateUrl=<%# ("default.aspx?AID=" + Eval("AddressID").tostring + "&CURID=" + Eval("CurrencyID").tostring )  %>  ></asp:HyperLink>     
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tx ID"  >
    <ItemTemplate>
   <asp:HyperLink ID="HyperLink1" runat="server"  Text=<%# ((new mymastercoins).GetShortTXID(Eval("ExodusID")))%> NavigateUrl=<%# ("default.aspx?XID=" + Eval("ExodusID").tostring  )  %>  ></asp:HyperLink>     
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
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

    <h2>
        Buying  <asp:Label ID="lblCurrency2" runat="server" Font-Bold="True"  
        Text=""></asp:Label>

    </h2>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
        RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="1">Waiting for Payment</asp:ListItem>
        <asp:ListItem Value="2">Payment Confirmed</asp:ListItem>
        <asp:ListItem Value="3">Expired</asp:ListItem>
    </asp:RadioButtonList>
        <asp:GridView ID="GVPurchasing" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" ForeColor="Black" GridLines="Horizontal"  >
            <Columns>
                <asp:BoundField HeaderText="Date" ItemStyle-Width="80" DataField="dTrans"/>
                <asp:BoundField HeaderText="Amount to Purchase" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Right" 
                    DataField="PurchasingAmount" DataFormatString="{0:########.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Purchased"  ItemStyle-HorizontalAlign="Right" 
                    DataField="PurchasedAmount" DataFormatString="{0:########.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Unit Price"  ItemStyle-HorizontalAlign="Right" 
                    DataField="UnitPrice" DataFormatString="{0:#######.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Total BTC"  ItemStyle-HorizontalAlign="Right" 
                    DataField="TotalBTC" DataFormatString="{0:########.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField HeaderText="Transfer Fee" ItemStyle-Width="40" ItemStyle-HorizontalAlign="Right" 
                    DataField="TransFee" DataFormatString="{0:########.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Tx ID"   >
    <ItemTemplate>
   <asp:HyperLink ID="HyperLink1" runat="server"  Text=<%# ((new mymastercoins).GetShortTXID(Eval("ExodusID")))%> NavigateUrl=<%# ("default.aspx?XID=" + Eval("ExodusID").tostring  )  %>  ></asp:HyperLink>     
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>


                <asp:BoundField HeaderText="CFS ID"  DataField="CurrencyforSaleID"/>
                <asp:TemplateField HeaderText="Buyer ID"  >
    <ItemTemplate>
   <asp:HyperLink ID="HyperLink1" runat="server"  Text=<%# ((new mymastercoins).GetShortAddress(Eval("AddressID"))) %> NavigateUrl=<%# ("default.aspx?AID=" + Eval("AddressID").tostring + "&CURID=" + Eval("CurrencyID").tostring )  %>  ></asp:HyperLink>     
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Seller ID"  >
    <ItemTemplate>
   <asp:HyperLink ID="HyperLink1" runat="server"  Text=<%# ((new mymastercoins).GetShortAddress(Eval("SellerID"))) %> NavigateUrl=<%# ("default.aspx?AID=" + Eval("SellerID").tostring + "&CURID=" + Eval("CurrencyID").tostring )  %>  ></asp:HyperLink>     
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>

                <asp:BoundField HeaderText="Max Block Time"  ItemStyle-Width="30" DataField="MaxBlockNo"/>
                <asp:TemplateField HeaderText=""  >
    <ItemTemplate>
        <%# IIf(Eval("Ispaid"), "<font color=GREEN>Payment Confirmed</FONT>", IIf(Eval("MaxBlockNo") >= Eval("CurrentBlockNo"), "<small>Waiting for Payment</small>", "<small>Time Expired</small>"))%>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField  HeaderText="Paid BTC"  ItemStyle-Width="30" DataField="Paid" DataFormatString="{0:########.########}" />
                <asp:TemplateField  HeaderText="Unpaid" >
    <ItemTemplate>
        <%# FormatNumber(Eval("TotalBTC") - Eval("Paid"))%>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>

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
<br/><br/>
    Current Block No. <asp:Label ID="lblCurrentBlockNo" runat="server" Font-Bold="True"  
        Text=""></asp:Label>


</asp:Content>