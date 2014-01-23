Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WebForms


Partial Class About
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim CurrencyID As Integer = 1
            If Request.Params("Currency_ID") <> "" Then
                CurrencyID = Request.Params("Currency_ID")
            End If
            Dim Address As String = ""
            If Request.Params("Address") <> "" Then
                Address = Request.Params("Address")
            End If
            Address = Trim((New AWS.DB.ConnectDB).HTMLEncode(Address))
            Dim AddressID As Integer = (New mymastercoins).GetAddressID(Address)
            If AddressID <> 0 Then
                Dim SQL2 As String = "SELECT TxID,z_Transactions.ExodusID,TotalPrice from z_Transactions,z_Exodus where z_Transactions.ExodusID=z_Exodus.ExodusID and z_Transactions.AddressID=" & AddressID & " and CurrencyID=" & CurrencyID & " Order by z_Transactions.dTrans "
                Dim DS2 As DataSet = (New AWS.DB.ConnectDB).SQLdataset(SQL2)
                If DS2.Tables(0).DefaultView.Count > 0 Then
                    Response.Write("{""address"":""" & Address & """, ""transactions"": [")
                    For i = 0 To DS2.Tables(0).DefaultView.Count - 1
                        Dim Row1 = DS2.Tables(0).Rows(i)
                        Response.Write("{""tx_hash"": """ & Trim(Row1.Item("TxID")) & """, ""valid"": ""true"",")
                        Dim Accepted As String = "nil"
                        Dim Purchased As String = "nil"
                        If Row1.Item("TotalPrice") > 0 Then
                            getamounts(Row1.Item("ExodusID"), Accepted, Purchased)
                        End If
                        Response.Write("accepted_amount: " + Accepted + ",bought_amount: " + Purchased + "}")
                        If i = DS2.Tables(0).DefaultView.Count - 1 Then
                            Response.Write("")
                        Else
                            Response.Write(",")
                        End If
                    Next
                    Response.Write("]}")
                End If
            End If
            Response.End()
        End If
    End Sub

    Sub getamounts(ByVal ExodusID As Integer, ByRef AcceptedAmount As String, ByVal BoughtAmount As String)
        Dim Sql = "select * from z_PurchasingCurrency where ExodusID=" + ExodusID.ToString
        Dim DS2 As DataSet = (New AWS.DB.ConnectDB).SQLdataset(Sql)
        If DS2.Tables(0).DefaultView.Count > 0 Then
            Dim Row1 = DS2.Tables(0).Rows(0)
            AcceptedAmount = Row1("PurchasedAmount").ToString
            BoughtAmount = Row1("PaidAmount").ToString
        End If

    End Sub

End Class
