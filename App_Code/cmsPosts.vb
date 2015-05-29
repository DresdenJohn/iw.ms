Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class cmsPosts

    Private cmsCon As New cmsConnections
    Private cmsNav As New cmsNavigation
    Private cmsSet As New cmsSettings

    Public Function getPostMeta(ByVal postID As Integer) As String()


        Dim postResult As String = ""

        Dim post As String() = {}

        Dim queryString As String = "SELECT * FROM TBL_POSTS WHERE postID = '" + postID.ToString + "'"

        Try
            Using connection As New SqlConnection(cmsCon.contentSystemCS)

                Dim command As New SqlCommand(queryString, connection)

                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader

                reader.Read()

                ReDim post(7)

                post = {reader("p_CreatedBy"), reader("p_HeaderImage"), reader("p_Title"), reader("p_Content"), reader("p_Tags"), reader("p_Category"), reader("p_VisibilityLevel")}

                connection.Close()

            End Using
        Catch ex As SqlException

        End Try

        Return post

    End Function

    Public Function grabPosts(ByVal postType As String, ByVal amount As Integer) As Integer()

        Dim postIDs(amount) As Integer

        Dim queryString As String = "SELECT * FROM TBL_POSTS WHERE p_Category = '" + postType + "' ORDER BY p_DateCreated DESC"

        Try
            Using connection As New SqlConnection(cmsCon.contentSystemCS)

                Dim command As New SqlCommand(queryString, connection)

                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader

                For count As Integer = 1 To amount Step 1
                    reader.Read()



                Next

                connection.Close()

            End Using
        Catch ex As Exception

        End Try

        Return postIDs


    End Function



End Class
