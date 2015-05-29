
Partial Class admin_login
    Inherits System.Web.UI.Page

    Public cmsFunc As New cmsFunctions
    Public cmsSettings As New cmsSettings
    Public cmsCookie As New cmsCookies
    Public cmsUser As New cmsUsers


    
    Protected Sub LoginButton_Click(sender As Object, e As EventArgs)

        Dim password As String = cmsFunc.getEncryptedPassword(Login1.Password)
        Dim email As String = Login1.UserName

        If cmsUser.checkAccount(email, password) Then

            Dim cmCookie As New HttpCookie("cm_auth_tick")

            cmCookie.Values("cm_email") = email
            cmCookie.Values("cm_password") = password
            cmCookie.Values("cm_username") = cmsUser.getUsernameByEmail(email)

            If Login1.RememberMeSet Then
                cmCookie.Expires = DateTime.Now.AddDays(14)
            Else
                cmCookie.Expires = DateTime.Now.AddDays(1)
            End If

            Response.Cookies.Add(cmCookie)

            Response.Redirect("default.aspx")
        Else
            Response.Redirect("login.aspx?action=loginfail")
        End If

    End Sub

    Protected Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        Dim refreshAction As String = Request.QueryString("action")

        Select Case (refreshAction)
            Case "logout"
                cmsCookie.doLogout()
            Case "loggedOut"
                logout.Visible = True
            Case "loginfail"
                loginFail.Visible = True
            Case "login"
                loginRequired.Visible = True
        End Select

    End Sub

    Protected Sub linkHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("~")
    End Sub
End Class
