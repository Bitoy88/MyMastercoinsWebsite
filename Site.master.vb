
Partial Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            '            Application("LastProcessed") = (New mymastercoins).GetandProcessTx(Application("LastProcessed"))
            Application("LastCheckBTC") = (New Bitcoin).GetLastCheckBTC(Application("LastCheckBTC"), Application("BTCPrice"), Application("MSCPrice"))
        End If
    End Sub

End Class

