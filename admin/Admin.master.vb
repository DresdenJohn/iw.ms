
Partial Class dash_Admin
    Inherits System.Web.UI.MasterPage

    Public cmsUsers As New cmsUsers

    Protected Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        Dim cmCookie As HttpCookie = Request.Cookies("cm_auth_tick")

        If Not cmsUsers.getAuthLevel(cmCookie).Equals("S") Then

            Response.Redirect("login.aspx?action=login")

        End If

        Dim currentUser As String = cmsUsers.getUsernameByEmail(cmCookie.Values("cm_email"))

        usernameLabel.Text = StrConv(currentUser, vbProperCase)

    End Sub
End Class

