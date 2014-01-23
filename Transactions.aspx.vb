Imports System.Data
Partial Class Transactions
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Application("LastProcessed") = (New mymastercoins).GetandProcessTx(Application("LastProcessed"))
        lblMessage.Text = "Processed " & Application("LastProcessed")

        Dim SQL As String = "SELECT top 100 * from z_Exodus where Isprocessed=1 order by dtrans desc,blocknumber,ExodusID "
        Dim DS As DataSet = (New AWS.DB.ConnectDB).SQLdataset(SQL)
        If DS.Tables(0).DefaultView.Count > 0 Then

            GVTrans.DataSource = DS.Tables(0).DefaultView
            GVTrans.DataBind()
            GVTrans.Visible = True
        End If

    End Sub
End Class
