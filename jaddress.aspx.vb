Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WebForms


Partial Class About
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Application("LastProcessed") = (New mymastercoins).GetandProcessTx(Application("LastProcessed"), 1)
            Dim CurrencyID As Integer = 1
            If Request.Params("CurrencyID") <> "" Then
                CurrencyID = Request.Params("CurrencyID")
            End If
            If Request.Params("Currency_ID") <> "" Then
                CurrencyID = Request.Params("Currency_ID")
            End If
            Dim SQL2 As String = "SELECT * from z_Address Order by Address"
            Dim DS2 As DataSet = (New AWS.DB.ConnectDB).SQLdataset(SQL2)
            If DS2.Tables(0).DefaultView.Count > 0 Then
                Response.Write("[")
                For i = 0 To DS2.Tables(0).DefaultView.Count - 1
                    Dim Row1 = DS2.Tables(0).Rows(i)
                    Dim Address As String = Row1.Item("Address")
                    Dim Balance As Double = 0
                    Dim CurrencyCode As String = (New Bitcoin).GetCurrency(CurrencyID)
                    Balance = Math.Round(Row1.Item(CurrencyCode) - (New mymastercoins).GetCurrencyForSale(Row1.Item("AddressID"), CurrencyID), 8)
                    Response.Write("{""address"": """ + Trim(Address) + """, ""balance"": """ + Balance.ToString + """}")
                    If i = DS2.Tables(0).DefaultView.Count - 1 Then
                        Response.Write("")
                    Else
                        Response.Write(",")
                    End If
                Next
                Response.Write("]")
            End If
            Response.End()
        End If
    End Sub
End Class
