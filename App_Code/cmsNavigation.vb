Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class cmsNavigation

    Private cmsCon As New cmsConnections

    Public Function getTopNavList(Optional ByVal activePage As String = "") As String
        Dim result As String = ""

        Dim queryString As String = "SELECT * FROM TBL_LINKS WHERE l_Position = 'topNavBar' ORDER BY l_Order ASC"

        Dim pgqueryString As String = "SELECT * FROM TBL_PAGES WHERE pg_VisibilityLevel = 'A' ORDER BY pg_ID ASC"

        Try
            Using connection As New SqlConnection(cmsCon.contentSystemCS)

                Dim pgCommand As New SqlCommand(pgqueryString, connection)

                Dim command As New SqlCommand(queryString, connection)

                connection.Open()

                Dim pgReader As SqlDataReader = pgCommand.ExecuteReader

                While pgReader.Read()

                    result += "<li><a href='./page.aspx?id=" & pgReader("pg_ID").ToString & "'>" & StrConv(pgReader("pg_Name"), vbProperCase) & "</a>" & "</li>" & vbNewLine

                End While

                pgReader.Close()

                Dim reader As SqlDataReader = command.ExecuteReader

                While reader.Read()

                    '<li class="active"><a href="#">Home</a></li>
                    '<li><a href="#">About</a></li>
                    '<li><a href="#">Contact</a></li>

                    result += "<li"


                    result += "><a href='" & reader("l_URL").ToString & "'>" & reader("l_Name").ToString & "</a>" & "</li>" & vbNewLine

                End While

                reader.Close()

                connection.Close()

            End Using
        Catch ex As Exception

        End Try

        Return result
    End Function


End Class
