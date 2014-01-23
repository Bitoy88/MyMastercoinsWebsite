Imports System
Imports System.IO
Imports System.Net
Imports System.Numerics
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Security.Cryptography
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim Ctr As Integer = 0
    Dim DecodeDataString As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.Params("AID") <> "" Then
                Address.Text = (New mymastercoins).GetAddress(Request.Params("AID"))
            End If
            If Request.Params("CurID") <> "" Then
                If Request.Params("CurID") = "1" Then
                    ddlCurrency.Text = "MSC"
                Else
                    ddlCurrency.Text = "TMSC"
                End If
            End If
            If Request.Params("XID") <> "" Then
                Address.Text = (New mymastercoins).GetTxID(Request.Params("XID"))
            End If
            If Request.Params("ADDR") <> "" Then
                Address.Text = Request.Params("ADDR")
            End If
            '            Application("LastProcessed") = (New mymastercoins).GetandProcessTx(Application("LastProcessed"))
            Application("LastCheckBTC") = (New Bitcoin).GetLastCheckBTC(Application("LastCheckBTC"), Application("BTCPrice"), Application("MSCPrice"))
            showdata()
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click, ddlCurrency.SelectedIndexChanged

        showdata()

    End Sub
    Sub showdata()
        lblMessage.Text = ""
        Address.Text = Trim(Address.Text)
        Select Case Address.Text.Length
            Case 33, 34
                Dim SQL As String = ""
                Dim DS2 As DataSet = (New Bitcoin).GetAddress(Trim(Address.Text))
                If DS2.Tables(0).DefaultView.Count > 0 Then
                    Dim CurrencyID As Integer = 1
                    Select Case ddlCurrency.Text
                        Case "MSC"
                            lblBalance.Text = DS2.Tables(0).Rows(0).Item("MSC")
                            CurrencyID = 1
                            lblUSD.Text = Format(CDbl(lblBalance.Text) * CDbl(Application("MSCPrice")) * CDbl(Application("BTCPrice")), "c")
                        Case "TMSC"
                            lblBalance.Text = DS2.Tables(0).Rows(0).Item("TMSC")
                            CurrencyID = 2
                            lblUSD.Text = ""
                    End Select
                    lblSmallBalance.Text = Right(lblBalance.Text, 6)
                    lblBalance.Text = lblBalance.Text.Substring(0, Len(lblBalance.Text) - 6)
                    Dim AddressID = DS2.Tables(0).Rows(0).Item("AddressID")
                    SQL = "SELECT TXID,z_Transactions.ExodusID,z_Transactions.dTrans as Date,z_Transactions.TransID AS TransNo, z_Transactions.AmountIn AS InAmount, z_Transactions.AmountOut AS OutAmount, z_Transactions.Description AS FromTo, TotalPrice" + _
                                " FROM z_Transactions LEFT OUTER JOIN z_Exodus ON z_Transactions.ExodusID = z_Exodus.ExodusID " & _
                                " where AddressID=" + AddressID.ToString + " and CurrencyID=" + CurrencyID.ToString + _
                                " order by z_Transactions.dtrans desc"
                    Dim DS As DataSet = (New AWS.DB.ConnectDB).SQLdataset(SQL)
                    If DS.Tables(0).DefaultView.Count > 0 Then
                        GVTrans.DataSource = DS.Tables(0).DefaultView
                        GVTrans.DataBind()
                        GVTrans.Visible = True
                        tabLedger.Visible = True
                    Else
                        tabLedger.Visible = True
                        GVTrans.Visible = False
                        lblMessage.Text = "No transactions found"
                    End If

                    SQL = "SELECT z_CurrencyforSale.*" + _
            " FROM z_CurrencyforSale " + _
            " WHERE  IsNewOffer=1 and z_CurrencyforSale.AddressID = " + AddressID.ToString + " And CurrencyID = " + CurrencyID.ToString + _
            " order by dtrans desc"
                    DS = (New AWS.DB.ConnectDB).SQLdataset(SQL)
                    If DS.Tables(0).DefaultView.Count > 0 Then
                        GVSell.DataSource = DS.Tables(0).DefaultView
                        GVSell.DataBind()
                        GVSell.Visible = True
                    Else
                        GVSell.Visible = False
                    End If


                    'Waiting for Payment
                    Dim CurrentBlockNo As Integer = (New Bitcoin).GetBlockCount()
                    SQL = "SELECT *" + _
    " FROM z_PurchasingCurrency " + _
    " WHERE   AddressID = " + AddressID.ToString + " And CurrencyID = " + CurrencyID.ToString + _
        " and MaxBlockNo>=" + CurrentBlockNo.ToString + _
    " order by dtrans desc"
                    DS = (New AWS.DB.ConnectDB).SQLdataset(SQL)
                    If DS.Tables(0).DefaultView.Count > 0 Then
                        GVPurchasing.DataSource = DS.Tables(0).DefaultView
                        GVPurchasing.DataBind()
                        GVPurchasing.Visible = True
                    Else
                        GVPurchasing.Visible = False
                    End If
                Else
                    lblMessage.Text = "No transactions found for " + Address.Text + "."
                    tabLedger.Visible = False
                End If
            Case 64
                Dim txhash As String = Trim(Address.Text)
                Dim SQL As String = "select * from z_Exodus where txid='" & txhash & "'"
                Dim DS As DataSet = (New AWS.DB.ConnectDB).SQLdataset(SQL)
                If DS.Tables(0).DefaultView.Count > 0 Then
                    Dim Remarks As String = IIf(IsDBNull(DS.Tables(0).Rows(0).Item("Remarks")), "", DS.Tables(0).Rows(0).Item("Remarks"))
                    Dim ExodusID As Integer = DS.Tables(0).Rows(0).Item("ExodusID")
                    Label21.Text = "Date:"
                    Label22.Text = DS.Tables(0).Rows(0).Item("dTrans")
                    SQL = "select * from z_Transactions where ExodusID=" + ExodusID.ToString + " and Description='Generated Coins'"
                    Dim DSGC As DataSet = (New AWS.DB.ConnectDB).SQLdataset(SQL)
                    If DSGC.Tables(0).DefaultView.Count > 0 Then
                        Dim Row1 = DSGC.Tables(0).Rows(0)
                        Dim CurrencyID2 As Integer = Row1("CurrencyID")
                        lblTitle.Text = "Generated Coins"
                        Label1.Text = "Recipient:"
                        Label2.Text = (New mymastercoins).GetAddress(Row1("AddressID"))
                        Label5.Text = "Amount Generated:"
                        Label6.Text = Row1("AmountIn").ToString + " " + (New Bitcoin).GetCurrency(CurrencyID2)

                    Else
                        SQL = "select * from z_Transactions where ExodusID=" + ExodusID.ToString + " and AmountOut>0"
                        Dim DS2 As DataSet = (New AWS.DB.ConnectDB).SQLdataset(SQL)
                        If DS2.Tables(0).DefaultView.Count > 0 Then
                            'Simple Send
                            Dim Row1 = DS2.Tables(0).Rows(0)
                            If Row1("TotalPrice") > 0 Then
                                lblTitle.Text = "Payment Confirmation"
                            Else
                                lblTitle.Text = "Simple Send"
                            End If
                            Dim CurrencyID2 As Integer = Row1("CurrencyID")

                            Dim AmounttoSend As String = Row1("AmountOut")

                            Label1.Text = "Sender:"
                            Label2.Text = (New mymastercoins).GetAddress(Row1("AddressID"))

                            Label5.Text = "Amount Sent:"
                            Label6.Text = AmounttoSend + " " + (New Bitcoin).GetCurrency(CurrencyID2)

                            Label9.Text = "Recipient:"
                            Label10.Text = Row1("Description")
                        Else
                            SQL = "select * from z_CurrencyforSale where ExodusID=" + ExodusID.ToString
                            DS2 = (New AWS.DB.ConnectDB).SQLdataset(SQL)
                            'Sell Master Coins for Bitcoins
                            If DS2.Tables(0).DefaultView.Count > 0 Then
                                Dim Row1 = DS2.Tables(0).Rows(0)
                                lblTitle.Text = "Sell Coins for Bitcoins"
                                Dim CurrencyID3 As Integer = Row1("CurrencyID")
                                Dim Currency As String = (New Bitcoin).GetCurrency(CurrencyID3)

                                Label1.Text = "Seller:"
                                Label2.Text = (New mymastercoins).GetAddress(Row1("AddressID"))

                                Label5.Text = "Amount for Sale:"
                                Label6.Text = Row1("AmountforSale").ToString + " " + Currency

                                Label9.Text = "BTC Desired:"
                                Label10.Text = Row1("BTCDesired").ToString

                                Label3.Text = "Time Limit:"
                                Label4.Text = Row1("TimeLimit").ToString

                                Label7.Text = "Min Trans Fee: "
                                Label8.Text = Row1("TransFee").ToString
                            Else
                                SQL = "select * from z_PurchasingCurrency where ExodusID=" + ExodusID.ToString
                                DS2 = (New AWS.DB.ConnectDB).SQLdataset(SQL)
                                'Sell Master Coins for Bitcoins
                                If DS2.Tables(0).DefaultView.Count > 0 Then
                                    Dim Row1 = DS2.Tables(0).Rows(0)
                                    'Accept Master Coins for Bitcoins
                                    lblTitle.Text = "Purchasing a Currency Offered for Sale"
                                    Dim Currency As String = (New Bitcoin).GetCurrency(Row1("CurrencyID"))

                                    Label1.Text = "Buyer:"
                                    Label2.Text = (New mymastercoins).GetAddress(Row1("AddressID"))

                                    Label5.Text = "Amount Purchasing:"
                                    Label6.Text = Row1("PurchasingAmount").ToString + " " + Currency
                                Else
                                    lblTitle.Text = "Invalid Transaction."
                                    Label1.Text = "Remarks:"
                                    Label2.Text = Remarks

                                End If
                            End If
                        End If
                    End If
                    tabTrans.Visible = True
                Else
                    lblTitle.Text = "Unknown Transaction ID."
                End If
            Case Else
                lblMessage.Text = "Please enter a valid Transaction ID or Address."
        End Select

    End Sub
End Class
