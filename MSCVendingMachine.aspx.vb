
Imports System.Data
Imports System.Numerics
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Partial Class VendingMachine
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub
    Sub vending()
        Dim BTCReceivingAddress As String = "17UbSDAXDzmxRXCgn2w43EaaHzHK3Ncx87"
        Dim PostURL As String = "http://blockexplorer.com/q/mytransactions/" + BTCReceivingAddress
        Dim json As String = (New Bitcoin).getjson(PostURL)
        Dim obj As New JObject
        obj = JsonConvert.DeserializeObject(json)
        Dim results As List(Of JToken) = obj.Children().ToList
        Dim Ctr As Integer = 0
        For Each item As JProperty In results
            item.CreateReader()
            Dim obj2 As New JObject
            obj2 = JsonConvert.DeserializeObject(item.Value.ToString)
            Dim txid As String = obj2.Item("hash")
            Dim beIn As String = obj2.Item("in").ToString
            Dim beOut As String = obj2.Item("out").ToString

            Dim BuyerAddress As String = (New mymastercoins).GetReference(beIn)

            Dim OutArray As New JArray
            OutArray = JsonConvert.DeserializeObject(beOut)
            For Each subitem In OutArray
                Dim Hash160 As String = (New mymastercoins).GetStringBetween(subitem("scriptPubKey"), "OP_HASH160", "OP_EQUAL")
                Dim Address As String = (New Bitcoin).Hash160toAddress(Trim(Hash160))
                If Address = BTCReceivingAddress Then
                    Dim Value As String = subitem("value")
                    Dim MSC As Double = Value * 0.25
                    Exit For
                End If
            Next
        Next

    End Sub

    Sub sendmsc(ByVal BCID As String, ByVal BCPassword As String, ByVal SenderBTCAddress As String, ByVal RecipientAddress As String, ByVal Amount As Double)
        Dim CoinType As Integer = 2  'Test MSC  1=MSC
        Dim SendType As Integer = 0 'SimpleSend

        'Get Sequence Number of BTC Address to Sent to
        Dim recipientBytes As Byte() = (New Bitcoin).Decode(RecipientAddress)
        Dim recipientSequenceNum As Integer = recipientBytes(1)
        Dim dataSequenceNum As Integer = recipientSequenceNum - 1
        If dataSequenceNum < 0 Then
            dataSequenceNum = dataSequenceNum + 256
        End If

        Dim Amount100 As BigInteger = Val(Amount) * 100000000
        Dim dataString As String = 0.ToString("x2") + _
            dataSequenceNum.ToString("x2") + _
            SendType.ToString("x8") + _
            CoinType.ToString("x8") + _
            Amount100.ToString("x16") _
            + 0.ToString("x6")

        Dim Bytes As Byte() = Bitcoin.StringtoByte(dataString)
        Dim dataResult As String = Space(21)
        Dim Bytes2 As Byte() = Bitcoin.StringtoByte(dataResult)
        For Index As Integer = 0 To dataString.Length - 1 Step 2
            Dim Index2 As Integer = CInt(Index / 2)
            Bytes2(Index2) = Bitcoin.chartohex(Chr(Bytes(Index))) * 16 + Bitcoin.chartohex(Chr(Bytes(Index + 1)))
        Next
        '        Dim recipients As String = "{""1EXoDusjGwvnjZUyKkxZ4UHEf77z6A5S4P"":6000," + _
        '    """" + RecipientAddress + """:6000," + _
        '    """" + dataAddress + """:6000}"
        '       BCID = Trim(BCID)
        '      BCPassword = Trim(BCPassword)
        '     recipients = System.Uri.EscapeDataString(recipients)
        '        Dim PostURL As String = "https://blockchain.info/merchant/" + BCID + "/sendmany?password=" + BCPassword + "&recipients=" + recipients + "&from=" + SenderBTCAddress
        '       PostURL = "https://blockchain.info/merchant/" + BCID + "/balance?password=" + BCPassword
        '      Dim Reply As String = (New Bitcoin).getjson(PostURL)
        '     Message("Order sent " + Reply)
    End Sub

    Protected Sub test()
        Dim BCID As String = "15b2ae0a-1977-49a5-81d7-cb9ba419b45e"
        Dim BCPassword As String = "passed88"
        Dim SenderAddress As String = "1Apg72BuD9i4rscpoemDqURJ1VfyhyBaoe"
        Dim RecipientAddress As String = "1Fq37GNfyxSvnmye3QdxH6GpPAQ3enarfs"
    End Sub
End Class
