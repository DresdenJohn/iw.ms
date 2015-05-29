
Partial Class page
    Inherits System.Web.UI.Page

    Private cmsPage As New cmsPages

    Protected Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        Dim pgID As String = Request.QueryString("id")

        If Not pgID.Equals(Nothing) Then
            pageContent.Text = cmsPage.getPage(pgID, True)
        End If

    End Sub

End Class
