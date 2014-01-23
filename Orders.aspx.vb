Imports System.Data

Partial Class About
    Inherits System.Web.UI.Page
    Dim CurrentBlockNo As Long = (New Bitcoin).GetBlockCount()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SQL As String

        Dim CurrencyID As Integer = Request.Params("CurrencyID")
        If CurrencyID = 0 Then
            CurrencyID = 1
        End If
        Dim Currency As String = (New Bitcoin).GetCurrency(CurrencyID)
        lblCurrency.Text = Currency
        lblCurrency2.Text = Currency

        SQL = "SELECT z_CurrencyforSale.*" + _
" FROM z_CurrencyforSale " + _
" WHERE  CurrencyID = " + CurrencyID.ToString + " and IsNewOffer=1 and Available>0 " + _
" order by dtrans desc"
        Dim DS As DataSet = (New AWS.DB.ConnectDB).SQLdataset(SQL)
        If DS.Tables(0).DefaultView.Count > 0 Then
            GVSell.DataSource = DS.Tables(0).DefaultView
            GVSell.DataBind()
            GVSell.Visible = True
        Else
            GVSell.Visible = False
        End If

        lblCurrentBlockNo.Text = CurrentBlockNo.ToString
        SQL = "SELECT *, " + CurrentBlockNo.ToString + " as CurrentBlockNo" + _
" FROM z_PurchasingCurrency " + _
" WHERE  CurrencyID = " + CurrencyID.ToString + _
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

    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Dim CurrentBlockNo As Integer = lblCurrentBlockNo.Text
        Dim SQL As String
        Dim DS As DataSet
        Dim CurrencyID As Integer = Request.Params("CurrencyID")
        If CurrencyID = 0 Then
            CurrencyID = 1
        End If
        Select Case RadioButtonList1.SelectedValue
            Case "1"
                'Waiting for payment
                SQL = "SELECT *, " + CurrentBlockNo.ToString + " as CurrentBlockNo" + _
        " FROM z_PurchasingCurrency " + _
        " WHERE  CurrencyID = " + CurrencyID.ToString + _
        " and MaxBlockNo>=" + CurrentBlockNo.ToString + _
        " order by dtrans desc"
                DS = (New AWS.DB.ConnectDB).SQLdataset(SQL)

            Case "2"
                SQL = "SELECT *, " + CurrentBlockNo.ToString + " as CurrentBlockNo" + _
        " FROM z_PurchasingCurrency " + _
        " WHERE  CurrencyID = " + CurrencyID.ToString + _
        " and IsPaid=1 " + _
        " order by dtrans desc"
                DS = (New AWS.DB.ConnectDB).SQLdataset(SQL)
            Case "3"
                SQL = "SELECT *, " + CurrentBlockNo.ToString + " as CurrentBlockNo" + _
        " FROM z_PurchasingCurrency " + _
        " WHERE  CurrencyID = " + CurrencyID.ToString + _
        " and IsPaid=0 and MaxBlockNo<" + CurrentBlockNo.ToString + _
        " order by dtrans desc"
                DS = (New AWS.DB.ConnectDB).SQLdataset(SQL)
        End Select
        If DS.Tables(0).DefaultView.Count > 0 Then
            GVPurchasing.DataSource = DS.Tables(0).DefaultView
            GVPurchasing.DataBind()
            GVPurchasing.Visible = True
        Else
            GVPurchasing.Visible = False
        End If

    End Sub
    Function GetPending(ByVal CurrencyforSaleID As Integer) As Double
        Return (New mymastercoins).GetCoinsPendingPayment(CurrencyforSaleID, CurrentBlockNo)
    End Function
End Class
