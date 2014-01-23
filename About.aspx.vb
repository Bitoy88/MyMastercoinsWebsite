Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WebForms


Partial Class About
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not IsPostBack Then
                '                Application("LastProcessed") = (New mymastercoins).GetandProcessTx(Application("LastProcessed"))
                Dim CurrencyID As String = 1
                If Request.Params("CurrencyID") <> "" Then
                    CurrencyID = Request.Params("CurrencyID")
                End If
                Dim dFrom As String = "2013/09/01"
                If Request.Params("From") <> "" Then
                    If IsDate(Request.Params("From")) Then
                        dFrom = Request.Params("From")
                    End If
                End If
                If Request.Params("Days") <> "" Then
                    If IsNumeric(Request.Params("Days")) Then
                        dFrom = DateAdd(DateInterval.Day, -CInt(Request.Params("Days")), Now())
                    End If
                Else
                    dFrom = DateAdd(DateInterval.Day, -12, Now())
                End If
                Dim SQL2 As String = ""
                If DateDiff(DateInterval.Hour, CDate(dFrom), Now()) <= 24 Then
                    SQL2 = " { fn CONCAT(STR(DATEPART(hh, dTrans), 2), ':00') } "
                Else
                    SQL2 = "CONVERT(date, dTrans)"
                End If
                Dim DS As DataSet = (New AWS.DB.ConnectDB).SQLdataset("SELECT " + SQL2 + " AS Expr2, SUM(AmountOut) AS Expr1" + _
                " FROM z_Transactions " + _
                " WHERE     (AmountOut > 0 and CurrencyID=1) " + _
                " AND  dTrans>='" + dFrom + "'" + _
                " GROUP BY " + SQL2 + " " + _
                " ORDER BY Expr2")
                Chart1.DataSource = DS.Tables(0)
                Chart1.Series("Series1").XValueMember = "Expr2"
                Chart1.Series("Series1").YValueMembers = "Expr1"
                Chart1.DataBind()
            End If
        End If
    End Sub



End Class
