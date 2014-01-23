Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WebForms


Partial Class CurrencyCharts
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim CurrencyID As String = 1
            If Request.Params("CurrencyID") <> "" Then
                CurrencyID = Request.Params("CurrencyID")
            End If
            Dim DS As DataSet = (New AWS.DB.ConnectDB).SQLdataset("SELECT CONVERT (date, dTrans) AS DTrans, SUM(TotalBTC) AS TBTC FROM z_PurchasingCurrency WHERE (Ispaid = 1) AND (CurrencyID = " + CurrencyID.ToString + ") GROUP BY CONVERT (date, dTrans)")
            Chart1.DataSource = DS.Tables(0)
            Chart1.Series("Series1").XValueMember = "DTrans"
            Chart1.Series("Series1").YValueMembers = "TBTC"
            Chart1.DataBind()
        End If
    End Sub



End Class
