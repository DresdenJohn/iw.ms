Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Imports System.IO

Public Class cmsSettings

    Public isDebugging As Boolean = False
    Private webCons As New cmsConnections

    Public Function getLogoLocation() As String

        Dim logoLocation As String = "<img src='./styles/required/assets/logo.png'/>"

        Dim queryString As String = "SELECT * FROM TBL_SETTINGS WHERE s_SettingName = 'HomepageLogo'"

        Try
            Using connection As New SqlConnection(webCons.contentSystemCS)

                Dim command As New SqlCommand(queryString, connection)

                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader

                reader.Read()

                logoLocation = "<img src='" & reader("s_Value").ToString & "'/>"

                reader.Close()
                connection.Close()

            End Using
        Catch ex As SqlException

        End Try
        
        Return logoLocation

    End Function

    Public Function getPageTitle() As String

        Dim pageTitle As String = "iwms site"

        Dim queryString As String = "SELECT * FROM TBL_SETTINGS WHERE s_SettingName = 'WebsiteName'"

        Try
            Using connection As New SqlConnection(webCons.contentSystemCS)

                Dim command As New SqlCommand(queryString, connection)

                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader

                reader.Read()

                pageTitle = HttpContext.Current.Server.HtmlDecode(reader("s_Value").ToString)

                reader.Close()
                connection.Close()
            End Using
        Catch ex As Exception

        End Try

        Return pageTitle

    End Function

    Public Function setPageTitle(ByVal newName As String) As Integer
        Dim result As Integer = 0

        Dim queryString As String = "UPDATE TBL_SETTINGS SET [s_Value] = '" + HttpContext.Current.Server.HtmlEncode(newName) + "' WHERE [s_SettingName] = 'WebsiteName'"

        Using connection As New SqlConnection(webCons.contentSystemCS)

            Dim command As New SqlCommand(queryString, connection)

            connection.Open()

            result = command.ExecuteNonQuery()

            connection.Close()

        End Using

        Return result
    End Function

    Public Function getSiteDesc() As String
        Dim siteDesc As String = ""

        Dim queryString As String = "SELECT * FROM TBL_SETTINGS WHERE s_SettingName = 'SiteDescription'"

        Try
            Using connection As New SqlConnection(webCons.contentSystemCS)

                Dim command As New SqlCommand(queryString, connection)

                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader

                reader.Read()

                siteDesc = HttpContext.Current.Server.HtmlDecode(reader("s_Value").ToString)

                reader.Close()
                connection.Close()
            End Using
        Catch ex As Exception

        End Try

        Return siteDesc
    End Function

    Public Function setSiteDesc(ByVal desc As String) As Integer
        Dim result As Integer = 0

        Dim queryString As String = "UPDATE [dbo].[TBL_SETTINGS] SET [s_Value] = '" + HttpContext.Current.Server.HtmlEncode(desc) + "' WHERE s_SettingName = 'SiteDescription'"

        Using connection As New SqlConnection(webCons.contentSystemCS)
            Try
                Dim command As New SqlCommand(queryString, connection)

                connection.Open()

                result = command.ExecuteNonQuery()

                connection.Close()

            Catch ex As Exception

            End Try

        End Using

        Return result
    End Function

End Class
