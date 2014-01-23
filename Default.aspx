<%@ Page Title="MyMastercoins" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <asp:TextBox ID="Address" runat="server" 
        Text="" Font-Size="Large"    Width="400px" 
        ToolTip="Enter a Transaction ID or Bitcoin Address"  ></asp:TextBox> 
<asp:Button ID="Button1" runat="server"  Text="Find"></asp:Button>
    <br />
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Text=""></asp:Label>
        <br/>
    <asp:Table ID="tabLedger" runat="server" Height="58px" Width="600px" 
        Visible="False"  >
    <asp:TableRow >
    <asp:TableCell >
        <asp:DropDownList ID="ddlCurrency" AutoPostBack="true"   runat="server" Font-Bold="True" 
            Font-Size="Large">
            <asp:ListItem>MSC</asp:ListItem>
            <asp:ListItem>TMSC</asp:ListItem>
        </asp:DropDownList>&nbsp;&nbsp;
        <asp:Label ID="lblBalance" runat="server" Font-Bold="True" Font-Size="Large" 
        Text=""></asp:Label>
        <asp:Label ID="lblSmallBalance" runat="server" Font-Bold="True" Font-Size="small" 
        Text=""></asp:Label>
    </asp:TableCell>
    <asp:TableCell HorizontalAlign="Right"   >
        <asp:Label ID="lblUSD" runat="server" Font-Bold="True" Font-Size="Large" 
        Text=""></asp:Label>
    </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow >
    <asp:TableCell  ColumnSpan="2"  >
        <asp:GridView ID="GVTrans" runat="server" AutoGenerateColumns="False"  
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" ForeColor="Black" GridLines="Horizontal"  >
            <Columns>
                <asp:BoundField HeaderText="Date" ItemStyle-Width="80" DataField="Date"/>
                <asp:BoundField HeaderText="In"  ItemStyle-HorizontalAlign="Right" 
                    DataField="InAmount" DataFormatString="{0:##,###,###.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="From/To" DataField="FromTo" />

                <asp:BoundField HeaderText="Out"  ItemStyle-HorizontalAlign="Right" 
                    DataField="OutAmount" DataFormatString="{0:##,###,###.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField HeaderText="Total BTC"  ItemStyle-HorizontalAlign="Right" 
                    DataField="TotalPrice" DataFormatString="{0:##,###,###.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>

                <asp:TemplateField HeaderText="Tx ID"  >
    <ItemTemplate>
   <asp:HyperLink ID="HyperLink1" runat="server"  Text=<%# (Eval("ExodusID"))%> NavigateUrl=<%# ("default.aspx?XID=" + Eval("ExodusID").tostring  )  %>  ></asp:HyperLink>     
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

    </asp:TableCell>



    </asp:TableRow>
    </asp:Table>

    <br/><br/>
        <asp:GridView ID="GVSell" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" ForeColor="Black" GridLines="Horizontal"  >
            <Columns>
                <asp:BoundField HeaderText="Date" ItemStyle-Width="80"   DataField="dTrans"/>
                <asp:BoundField HeaderText="Amount For Sale"  ItemStyle-HorizontalAlign="Right" 
                    DataField="AmountforSale" DataFormatString="{0:##,###,###.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Sold"  >
    <ItemTemplate>
       <%# CDbl(Eval("AmountforSale") - Eval("Available")).ToString()%>     
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>

                <asp:BoundField HeaderText="Remaining"  ItemStyle-HorizontalAlign="Right" 
                    DataField="Available" DataFormatString="{0:##,###,###.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField HeaderText="BTC Desired"  ItemStyle-HorizontalAlign="Right" 
                    DataField="BTCDesired" DataFormatString="{0:##,###,###.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField  HeaderText="Time Limit"  DataField="TimeLimit" DataFormatString="{0:##,###,###.########}" >
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Transfer Fee"  DataField="TransFee"  DataFormatString="{0:##,###,###.########}" >
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Tx ID"  >
    <ItemTemplate>
   <asp:HyperLink ID="HyperLink1" runat="server"  Text=<%# (Eval("ExodusID"))%> NavigateUrl=<%# ("default.aspx?XID=" + Eval("ExodusID").tostring  )  %>  ></asp:HyperLink>     
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
<br/>
<br/>

        <asp:GridView ID="GVPurchasing" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" ForeColor="Black" GridLines="Horizontal"  >
            <Columns>
                <asp:BoundField HeaderText="Date" ItemStyle-Width="80" DataField="dTrans"/>
                <asp:BoundField HeaderText="Amount to Purchase"  ItemStyle-HorizontalAlign="Right" 
                    DataField="PurchasingAmount" DataFormatString="{0:##,###,###.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Purchased"  ItemStyle-HorizontalAlign="Right" 
                    DataField="PurchasedAmount" DataFormatString="{0:##,###,###.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Seller ID"  DataField="SellerID"/>
                <asp:BoundField HeaderText="Unit Price"  ItemStyle-HorizontalAlign="Right" 
                    DataField="UnitPrice" DataFormatString="{0:#######.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Total BTC"  ItemStyle-HorizontalAlign="Right" 
                    DataField="TotalBTC" DataFormatString="{0:########.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField HeaderText="Transfer Fee"  ItemStyle-HorizontalAlign="Right" 
                    DataField="TransFee" DataFormatString="{0:########.########}" >
    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="CFS ID"  DataField="CurrencyforSaleID"/>
                <asp:TemplateField HeaderText=""  >
    <ItemTemplate>
        <%# IIf(Eval("Ispaid"), "Yes", "Not Yet Paid ")%>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tx ID"  >
    <ItemTemplate>
   <asp:HyperLink ID="HyperLink1" runat="server"  Text=<%# (Eval("ExodusID"))%> NavigateUrl=<%# ("default.aspx?XID=" + Eval("ExodusID").tostring  )  %>  ></asp:HyperLink>     
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

    <asp:Table ID="tabTrans" runat="server" Height="58px" 
        Visible="False"  >
    <asp:TableHeaderRow >
            <asp:TableHeaderCell ColumnSpan="5"  ><asp:Label  runat="server" ID="lblTitle"  /></asp:TableHeaderCell></asp:TableHeaderRow><asp:TableRow >
        <asp:TableCell ><asp:Label  runat="server" ID="Label21"  ></asp:Label></asp:TableCell><asp:TableCell ><asp:Label  runat="server" ID="Label22"  ></asp:Label> </asp:TableCell><asp:TableCell Width="20px"  >&nbsp;&nbsp;&nbsp;</asp:TableCell><asp:TableCell ><asp:Label  runat="server" ID="Label15"  ></asp:Label></asp:TableCell><asp:TableCell ><asp:Label  runat="server" ID="Label16"  ></asp:Label> </asp:TableCell></asp:TableRow><asp:TableRow >
        <asp:TableCell ><asp:Label  runat="server" ID="Label1"  ></asp:Label></asp:TableCell><asp:TableCell ><asp:Label  runat="server" ID="Label2"  ></asp:Label> </asp:TableCell><asp:TableCell Width="20px"  >&nbsp;&nbsp;&nbsp;</asp:TableCell><asp:TableCell ><asp:Label  runat="server" ID="Label3"  ></asp:Label></asp:TableCell><asp:TableCell ><asp:Label  runat="server" ID="Label4"  ></asp:Label> </asp:TableCell></asp:TableRow><asp:TableRow >
        <asp:TableCell ><asp:Label  runat="server" ID="Label5"  ></asp:Label></asp:TableCell><asp:TableCell ><asp:Label  runat="server" ID="Label6"  ></asp:Label> </asp:TableCell><asp:TableCell Width="20px"  >&nbsp;&nbsp;&nbsp;</asp:TableCell><asp:TableCell ><asp:Label  runat="server" ID="Label7"  ></asp:Label></asp:TableCell><asp:TableCell ><asp:Label  runat="server" ID="Label8"  ></asp:Label> </asp:TableCell></asp:TableRow><asp:TableRow >
        <asp:TableCell ><asp:Label  runat="server" ID="Label9"  ></asp:Label></asp:TableCell><asp:TableCell ><asp:Label  runat="server" ID="Label10"  ></asp:Label> </asp:TableCell><asp:TableCell Width="20px"  >&nbsp;&nbsp;&nbsp;</asp:TableCell><asp:TableCell ><asp:Label  runat="server" ID="Label11"  ></asp:Label></asp:TableCell><asp:TableCell ><asp:Label  runat="server" ID="Label12"  ></asp:Label> </asp:TableCell></asp:TableRow></asp:Table><br />
</asp:Content>
