
Partial Class admin_settings
    Inherits System.Web.UI.Page

    Dim cmsFunc As New cmsFunctions
    Dim cmsSet As New cmsSettings
    Dim cmsPage As New cmsPages
    Dim cmsPost As New cmsPosts
    Dim cmsCons As New cmsConnections

    Protected Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        If Not Page.IsPostBack Then
            websiteName.Text = cmsSet.getPageTitle()

            siteDescription.Text = cmsSet.getSiteDesc()
        End If

    End Sub

    Protected Sub saveWebsiteName_Click(sender As Object, e As EventArgs) Handles saveWebsiteName.Click

        If cmsSet.setPageTitle(websiteName.Text) > 0 Then

            siteNameUpdate.Text = "Saved!"
            siteNameUpdate.CssClass = "label label-success animated tada"

        End If

    End Sub

    Protected Sub siteDescSave_Click(sender As Object, e As EventArgs) Handles siteDescSave.Click

        If cmsSet.setSiteDesc(siteDescription.Text) > 0 Then

            siteDescUpdate.Text = "Saved!"
            siteDescUpdate.CssClass = "label label-success animated tada"

        End If

    End Sub
End Class
