Imports Microsoft.VisualBasic
Imports System.Security.Cryptography
Imports System.Data.SqlClient
Imports System.Text
Imports System.Drawing
Imports System.Web.Configuration
Imports System.Web.UI.Page
Imports System.Data

Public Class cmsConnections

    ' Only use this when testing internally. This connects to a local MSSQL Server
    Private localCon As String = "Data Source=.\MSSQL;Initial Catalog=JCMS_DBF;Integrated Security=True;"

    ' This connects to an online database, requires an SQL user to be created.
    Private SQLUsername As String = "JCMSCon"
    Private SQLPassword As String = "Annie"
    Private SQLDataSource As String = "50.140.19.136"
    Private SQLDatabase As String = "IWMS_TEST"

    Private onlineCon As String = "Data Source=" + SQLDataSource + ";Initial Catalog=" + SQLDatabase + ";Integrated Security=False;User ID=" + SQLUsername + ";Password=" + SQLPassword + ";"

    Public contentSystemCS As String = onlineCon

    Public Function testContentDatabase() As Boolean
        Try
            Using sqlCon As New SqlConnection(contentSystemCS)
                sqlCon.Open()
                Return (sqlCon.State = ConnectionState.Open)
            End Using
        Catch e1 As SqlException
            Return False
        Catch e2 As Exception
            Return False
        End Try
    End Function

End Class
