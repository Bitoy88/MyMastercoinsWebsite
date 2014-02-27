Imports System
Imports System.Configuration
Imports System.Data
Imports System.XML
Imports System.Web
Imports System.Data.SqlClient

Namespace AWS.DB

    Public Class ConnectDB

        Function ConnectDB2() As SqlConnection
            Dim ConnectString As String = ""
            Dim myConn As New SqlConnection(ConnectString)
            Return myConn
        End Function
        Public Sub SQLExecute2(ByVal SQL As String)
            Dim myConn = ConnectDB2()
            Dim myCom = New SqlCommand(SQL, myConn)
            myConn.Open()
            myCom.ExecuteNonQuery()
            myConn.Close()
        End Sub
        Public Function SQLdataset2(ByVal SQL As String) As DataSet
            ' Create Instance of Connection and Command Object
            Dim myConn = ConnectDB2()

            Dim myCom As New SqlCommand(SQL, myConn)
            myConn.Open()
            '        context.Response.Write(SQL)
            Dim objAdapter1 As New SqlDataAdapter
            objAdapter1.SelectCommand = myCom
            Dim objDataset1 As New DataSet
            objAdapter1.Fill(objDataset1, "Data")
            myConn.Close()
            Return objDataset1
        End Function

        Function ConnectDB() As SqlConnection
            Dim ConnectString As String = "data source=.\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\aspnetdb.mdf;User Instance=true"
            'Dim ConnectString As String = "Data Source=tcp:s09.winhost.com;Initial Catalog=DB_66808_mymsc;User ID=DB_66808_mymsc_user;Password=pass1088;Integrated Security=False;"
            Dim myConn As New SqlConnection(ConnectString)
            Return myConn
        End Function

        Public Function SQLdataset(ByVal SQL As String) As DataSet
            ' Create Instance of Connection and Command Object
            Dim myConn = ConnectDB()

            Dim myCom As New SqlCommand(SQL, myConn)
            myConn.Open()
            '        context.Response.Write(SQL)
            Dim objAdapter1 As New SqlDataAdapter
            objAdapter1.SelectCommand = myCom
            Dim objDataset1 As New DataSet
            objAdapter1.Fill(objDataset1, "Data")
            myConn.Close()
            Return objDataset1
        End Function

        Function ymd(ByVal DateToConvert As DateTime) As String
            Dim DateTimeFormat As String = System.Configuration.ConfigurationManager.AppSettings("DateTimeFormat")
            If DateTimeFormat = "" Then
                DateTimeFormat = "yyyy/MM/dd hh:mm:ss tt"
            End If
            Return DateToConvert.ToString(DateTimeFormat)
            'Return DateToConvert.ToString
        End Function

        Public Sub SQLExecute(ByVal SQL As String)
            Dim myConn = ConnectDB()
            Dim myCom = New SqlCommand(SQL, myConn)
            myConn.Open()
            myCom.ExecuteNonQuery()
            myConn.Close()
        End Sub
        Public Function HTMLEncode(ByVal Value As String) As String
            Return Replace(Value, "'", "''")
        End Function
    End Class
End Namespace
