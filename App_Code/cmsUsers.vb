Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class cmsUsers

    Private cmsCons As New cmsConnections
    Private cmsSettings As New cmsSettings
    Private cmsFunc As New cmsFunctions

    Public Function checkAccount(ByVal email As String, ByVal password As String) As Boolean

        Dim isValid As Boolean = False
        Dim dbEmail As String = ""
        Dim dbPassword As String = ""

        Dim queryString As String =
            "SELECT * FROM TBL_USERS WHERE u_Email = '" + email + "'"

        Using connection As New SqlConnection(cmsCons.contentSystemCS)
            Dim command As New SqlCommand(queryString, connection)

            Try
                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader

                While reader.Read()
                    dbEmail = reader("u_Email")
                    dbPassword = reader("u_Password")
                End While

                If password.Equals(dbPassword) Then
                    isValid = True
                End If

                reader.Close()

                connection.Close()
            Catch ex As SqlException

            End Try

        End Using

        Return isValid
    End Function

    Public Function getUsernameByID(ByVal id As String) As String
        Dim user As String = ""

        Dim queryString As String = "SELECT * FROM TBL_USERS WHERE u_ID = " + id

        Using connection As New SqlConnection(cmsCons.contentSystemCS)
            Dim command As New SqlCommand(queryString, connection)

            connection.Open()

            Dim reader As SqlDataReader = command.ExecuteReader

            reader.Read()

            user = reader(1)

            reader.Close()

            connection.Close()

        End Using

        Return user
    End Function

    Public Function getUsernameByEmail(ByVal email As String) As String
        Dim queryString As String = "SELECT * FROM TBL_USERS WHERE u_Email = '" + email + "'"

        Dim username As String = ""

        Using connection As New SqlConnection(cmsCons.contentSystemCS)
            Dim command As New SqlCommand(queryString, connection)

            Try
                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader

                While reader.Read()
                    username = reader("u_Name")
                End While

                reader.Close()

                connection.Close()

            Catch ex As SqlException

            End Try

        End Using

        Return StrConv(username, vbProperCase)

    End Function

    Public Function getAuthLevel(cmCookie As HttpCookie) As String

        If cmCookie Is Nothing Then
            Return "U"
        End If

        Dim queryString As String = "SELECT * FROM TBL_USERS WHERE u_Email = '" + cmCookie.Values("cm_email").ToString + "'"

        Dim authLevel As String = ""

        Using connection As New SqlConnection(cmsCons.contentSystemCS)
            Dim command As New SqlCommand(queryString, connection)

            Try
                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader

                While reader.Read()
                    authLevel = reader("u_Access")
                End While

                reader.Close()

                connection.Close()

            Catch ex As SqlException

            End Try
        End Using

        Return authLevel

    End Function

End Class
