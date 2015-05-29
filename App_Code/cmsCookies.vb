Imports Microsoft.VisualBasic

Public Class cmsCookies

    Private cmsCons As New cmsConnections
    Private cmsSet As New cmsSettings
    Private cmsFunc As New cmsFunctions
    Private cmsUser As New cmsUsers

    Dim cm_username As String = ""
    Dim cm_email As String = ""
    Dim cm_password As String = ""

    ' Cookie Management

    Public Function checkLogin(ByVal cm_cookie As HttpCookie) As Boolean

        If Not cm_cookie Is Nothing Then

            Dim cmCookie As HttpCookie = HttpContext.Current.Request.Cookies("cm_auth_tick")

            cm_username = HttpContext.Current.Server.HtmlEncode(cmCookie.Values("cm_username"))
            cm_email = HttpContext.Current.Server.HtmlEncode(cmCookie.Values("cm_email"))
            cm_password = HttpContext.Current.Server.HtmlEncode(cmCookie.Values("cm_password"))

            Dim emailRegCheck As New Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
            Dim passwordRegCheck As New Regex("[a-zA-Z0-9]*")

            If emailRegCheck.IsMatch(cm_email) And passwordRegCheck.IsMatch(cm_password) Then
                Return False
            Else : Return False
            End If

        Else
            Return False
        End If

    End Function

    Public Sub refreshCookie()

        If Not HttpContext.Current.Request.Cookies("cm_auth_tick") Is Nothing Then

            Dim cmCookie As HttpCookie = HttpContext.Current.Request.Cookies("cm_auth_tick")

            cm_username = HttpContext.Current.Server.HtmlEncode(cmCookie.Values("cm_username"))
            cm_email = HttpContext.Current.Server.HtmlEncode(cmCookie.Values("cm_email"))
            cm_password = HttpContext.Current.Server.HtmlEncode(cmCookie.Values("cm_password"))

        End If

    End Sub

    Public Sub doLogout()
        Dim cmCookie As New HttpCookie("cm_auth_tick")

        cmCookie.Expires = DateTime.Now.AddDays(-1)

        cmCookie.Values("cm_username") = ""
        cmCookie.Values("cm_password") = ""
        cmCookie.Values("cm_email") = ""

        HttpContext.Current.Response.Cookies.Add(cmCookie)

        HttpContext.Current.Response.Redirect("./login.aspx?action=loggedOut")
    End Sub

    Public Function doLogin(ByVal email As String, ByVal password As String) As Boolean

        Dim emailRegCheck As New Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
        Dim passwordRegCheck As New Regex("[a-zA-Z0-9]*")

        Return True

    End Function

End Class
