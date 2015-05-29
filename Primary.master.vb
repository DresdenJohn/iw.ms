
Partial Class Primary
    Inherits System.Web.UI.MasterPage

    Public cmsSet As New cmsSettings
    Public cmsNav As New cmsNavigation
    Public cmsFunc As New cmsFunctions

    Public cm_username As String
    Public cm_password As String
    Public cm_email As String

    Protected Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        themeCss.Text = cmsFunc.loadStyles()
        themejs.Text = cmsFunc.loadScripts()
        pageTitle.Text = cmsSet.getPageTitle()

    End Sub
 
End Class

