Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class cmsPages

    Private cmsCon As New cmsConnections
    Private cmsFunc As New cmsFunctions
    Private cmsSet As New cmsSettings
    Private cmsUser As New cmsUsers

    Public Function getHomePage() As String

        Dim homeContent As String = ""

        Dim queryString As String = "SELECT * FROM TBL_PAGES WHERE pg_ID = 0"

        Try
            Using connection As New SqlConnection(cmsCon.contentSystemCS)

                Dim command As New SqlCommand(queryString, connection)

                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader

                reader.Read()

                homeContent = HttpContext.Current.Server.HtmlDecode(reader("pg_Content"))

                reader.Close()

                connection.Close()

            End Using
        Catch ex As SqlException
            HttpContext.Current.Response.Redirect("Setup.aspx?actn=dbconnectfail")
        End Try

        Return homeContent


    End Function

    Public Function getTitle(ByVal pg_ID As String) As String
        Dim pageTitle As String = ""

        Dim queryString As String = "SELECT * FROM TBL_PAGES WHERE pg_ID = '" + pg_ID + "'"

        Try
            Using connection As New SqlConnection(cmsCon.contentSystemCS)

                Dim command As New SqlCommand(queryString, connection)

                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader

                reader.Read()

                pageTitle = reader("pg_Name").ToString

                reader.Close()

                connection.Close()

            End Using
        Catch ex As SqlException

        End Try

        Return pageTitle
    End Function

    Public Function getPage(ByVal pg_ID As String, ByVal decode As Boolean) As String

        Dim pageContent As String = ""

        Dim queryString As String = "SELECT * FROM TBL_PAGES WHERE pg_ID = '" + pg_ID + "'"

        Try
            Using connection As New SqlConnection(cmsCon.contentSystemCS)

                Dim command As New SqlCommand(queryString, connection)

                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader

                reader.Read()

                If decode Then
                    pageContent = HttpContext.Current.Server.HtmlDecode(reader("pg_Content").ToString)
                Else
                    pageContent = reader("pg_Content").ToString
                End If

                reader.Close()

                connection.Close()

            End Using
        Catch ex As SqlException

        End Try

        Return pageContent

    End Function

    Public Function setPage(ByVal pg_ID As String, ByVal content As String, ByVal title As String, ByVal pageVis As String) As Integer
        Dim result As Integer = 0

        Dim queryString As String = "UPDATE TBL_PAGES SET pg_Name = '" + title + "', pg_Content = '" + content + "', pg_VisibilityLevel = '" + pageVis + "', pg_LastUpdated = GETDATE() WHERE pg_ID='" + pg_ID + "'"

        Try
            Using connection As New SqlConnection(cmsCon.contentSystemCS)

                Dim command As New SqlCommand(queryString, connection)

                connection.Open()

                result = command.ExecuteNonQuery

                connection.Close()

            End Using
        Catch ex As Exception

        End Try

        Return result
    End Function

    Public Function deletePage(ByVal pg_ID As String) As String
        Dim result As String = ""

        Dim queryString As String = "DELETE FROM TBL_PAGES WHERE pg_ID = '" + pg_ID + "'"

        Using connection As New SqlConnection(cmsCon.contentSystemCS)

            Dim command As New SqlCommand(queryString, connection)

            connection.Open()

            command.ExecuteNonQuery()

            connection.Close()

        End Using

        Return result
    End Function

    Public Function addPage(ByVal content As String, ByVal title As String) As String
        Dim result As String = ""

        Randomize()
        ' Generate random value between 1 and 6. 
        Dim value As Integer = CInt(Int((24 * Rnd()) + 1))

        Dim newpagetext As String = "New Page " + value.ToString

        Dim queryString As String = "INSERT INTO TBL_PAGES([pg_VisibilityLevel],[pg_Name],[pg_Content],[pg_LastUpdated])VALUES('A','" + newpagetext + "','',GETDATE())SELECT pg_ID FROM TBL_PAGES WHERE pg_Name = '" + newpagetext + "'"

        Using connection As New SqlConnection(cmsCon.contentSystemCS)

            Dim command As New SqlCommand(queryString, connection)

            connection.Open()

            Dim reader As SqlDataReader = command.ExecuteReader

            reader.Read()

            result = reader(0)

            reader.Close()

            'Dim links As String = "INSERT INTO TBL_LINKS([l_Name],[l_URL],[l_Position],[l_VisibilityLevel],[l_Order])VALUES('" + newpagetext + "','./page.aspx?id=" + result + "','topNavBar','A',0)"

            'Dim secCommand As New SqlCommand(links, connection)

            'secCommand.ExecuteNonQuery()

            connection.Close()

        End Using

        Return result
    End Function

    Public Function getPageList() As String

        Dim pageList As String = ""

        Dim queryString As String = "SELECT * FROM TBL_PAGES"

        Try
            Using connection As New SqlConnection(cmsCon.contentSystemCS)

                Dim command As New SqlCommand(queryString, connection)

                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader

                pageList += "<table class='table table-striped table-hover table-bordered'><thead><tr>"
                pageList += "<th>Title</th>"
                pageList += "<th>Visibility</th>"
                pageList += "<th>Last Edited</th>"
                pageList += "<th>Actions</th>"
                pageList += "</thead><tbody>"

                While reader.Read()

                    Dim titleCap As String = StrConv(reader(1), VbStrConv.ProperCase)

                    Dim visibilityLevel As String = (reader(5))
                    Dim visDisplay As String = "Visible to All"

                    If visibilityLevel.Contains("A") Then
                        visDisplay = "Visible to All"
                    ElseIf visibilityLevel.Contains("S") Then
                        visDisplay = "Visible to Admins"
                    Else
                        visDisplay = "Hidden (Draft)"
                    End If

                    'Dim username As String = cmsUser.getUsernameByID(reader(4))
                    '" by " + StrConv(username, vbProperCase) 

                    pageList += "<tr>"
                    pageList += "<td><a href='../page.aspx?id=" + reader(0).ToString + "' target='_blank'>" + titleCap + "</a></td>"
                    pageList += "<td>" + visDisplay + "</td>"
                    pageList += "<td>" + reader("pg_LastUpdated").ToString + "</td>"
                    pageList += "<td><a href='./editPage.aspx?id=" + reader(0).ToString + "' class='btn btn-primary btn-sm'>Edit</a> <a href='./editPage.aspx?id=" + reader(0).ToString + "&action=delete' class='btn btn-danger btn-sm'>Delete</a></td></tr>"

                End While

                reader.Close()

                pageList += "</tbody></table>"

            End Using
        Catch ex As SqlException

        End Try

        Return pageList

    End Function

End Class
