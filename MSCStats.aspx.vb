Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WebForms


Partial Class MSCStats
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not IsPostBack Then
                Dim Count1000 As Integer = 0
                Dim Sum1000 As Double = 0
                GetData(1000, 1000000, Count1000, Sum1000)
                Dim Count100 As Integer = 0
                Dim Sum100 As Double = 0
                GetData(100, 1000, Count100, Sum100)
                Dim Count10 As Integer = 0
                Dim Sum10 As Double = 0
                GetData(10, 100, Count10, Sum10)
                Dim Count1 As Integer = 0
                Dim Sum1 As Double = 0
                GetData(0, 10, Count1, Sum1)
                Dim TCount As Integer = Count1000 + Count100 + Count10 + Count1
                Dim x As String() = New String(4) {}
                x(0) = "Over 1000 MSC " + Count1000.ToString + " (" + FormatPercent(Count1000 / TCount) + ")"
                x(1) = "Up to 1000 MSC " + Count100.ToString + " (" + FormatPercent(Count100 / TCount) + ")"
                x(2) = "Up to 100 MSC " + Count10.ToString + " (" + FormatPercent(Count10 / TCount) + ")"
                x(3) = "Up to 10 MSC " + Count1.ToString + " (" + FormatPercent(Count1 / TCount) + ")"
                Dim y As Integer() = New Integer(4) {}
                y(0) = Count1000
                y(1) = Count100
                y(2) = Count10
                y(3) = Count1
                Chart1.Series(0).Points.DataBindXY(x, y)
                Chart1.Series(0)("PieLabelStyle") = "Disabled"

                Dim TSum As Integer = Sum1000 + Sum100 + Sum10 + Sum1
                Dim x2 As String() = New String(4) {}
                x2(0) = "Over 1000 MSC " + FormatNumber(Sum1000, 0) + " (" + FormatPercent(Sum1000 / TSum) + ")"
                x2(1) = "Up to 1000 MSC " + FormatNumber(Sum100, 0) + " (" + FormatPercent(Sum100 / TSum) + ")"
                x2(2) = "Up to 100 MSC " + FormatNumber(Sum10, 0) + " (" + FormatPercent(Sum10 / TSum) + ")"
                x2(3) = "Up to 10 MSC " + FormatNumber(Sum1, 0) + " (" + FormatPercent(Sum1 / TSum) + ")"
                Dim y2 As Integer() = New Integer(4) {}
                y2(0) = Sum1000
                y2(1) = Sum100
                y2(2) = Sum10
                y2(3) = Sum1
                Chart2.Series(0).Points.DataBindXY(x2, y2)
                Chart2.Series(0)("PieLabelStyle") = "Disabled"

            End If
        End If
    End Sub

    Sub GetData(ByVal MSCFrom As Integer, ByVal MSCTo As Integer, ByRef CountAddress As Integer, ByRef SumMSC As Double)
        SumMSC = 0
        CountAddress = 0
        Dim DS As DataSet = (New AWS.DB.ConnectDB).SQLdataset( _
        " SELECT Count(Address) as TAddress,SUM(MSC) as TotalMSC" + _
        " FROM z_Address WHERE MSC>0 and MSC>=" + MSCFrom.ToString + " and MSC<" + MSCTo.ToString)
        If DS.Tables(0).DefaultView.Count > 0 Then
            CountAddress = DS.Tables(0).Rows(0).Item("TAddress")
            SumMSC = DS.Tables(0).Rows(0).Item("TotalMSC")
        End If
    End Sub

End Class
