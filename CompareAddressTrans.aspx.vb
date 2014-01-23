
Imports System.Data
Imports System.Numerics
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Partial Class CompareAddressTrans
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
        End If
    End Sub

    Protected Sub btnCheckME0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheckME0.Click
        Dim PostURL As String = "http://mastercoin-explorer.com/mastercoin_verify/transactions/" + Trim(txtTxID.Text) + "?currency_id=2"
        Dim obj As New JObject
        Dim json As String = (New Bitcoin).getjson(PostURL)
        obj = JsonConvert.DeserializeObject(json)
        Dim i As Integer
        Dim Array1 As JArray = JsonConvert.DeserializeObject(obj.Item("transactions").ToString)
        For i = 0 To Array1.Count - 1
            Dim tx_hash As String = Trim(Array1.Item(i).Item("tx_hash").ToString)
            Dim Isvalid As String = Trim(Array1.Item(i).Item("valid").ToString) = "True"
            If Isvalid Then
                Dim SQL As String = "Select * from z_Exodus where IsValid=1 and TXID='" + tx_hash + "'"
                Dim DS As DataSet = (New AWS.DB.ConnectDB).SQLdataset(SQL)
                If DS.Tables(0).DefaultView.Count = 0 Then
                    showdata("Invalid or missing " + tx_hash)
                End If
            End If
        Next
        showdata("Done")
    End Sub
    Sub showdata(ByVal s As String)
        lblData.Text = s + "<br/>" + lblData.Text
    End Sub
End Class
