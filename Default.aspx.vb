Imports System.IO
Imports System.Web


Partial Class _Default
    Inherits System.Web.UI.Page

    Private cmsPage As New cmsPages
    Private cmsCons As New cmsConnections

    Protected Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        Dim directoryFull As String = "/"

        Dim dir As String = HttpRuntime.AppDomainAppPath

        Dim di As New DirectoryInfo(dir)

        Dim fiArr As FileInfo() = di.GetFiles()

        Dim fri As FileInfo

        For Each fri In fiArr

            If fri.Name = "Site.NotSetup" Then
                Response.Redirect("Setup.aspx")
            End If

        Next

        If Not cmsCons.testContentDatabase Then
            Response.Redirect("Setup.aspx?actn=dbconnectfail")
        Else
            homeContent.Text = cmsPage.getHomePage()
        End If

    End Sub

End Class
