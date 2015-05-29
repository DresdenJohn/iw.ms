
Partial Class admin_pages
    Inherits System.Web.UI.Page

    Dim cmsPage As New cmsPages

    Protected Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        pageList.Text = cmsPage.getPageList()

        Dim pageAction As String = Request.QueryString("action")

        Select Case pageAction
            Case "deleted"
                statusLit.Text = "<div class='alert alert-info alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong>Done!</strong> Page has been deleted. Page list has been updated.</div>"
        End Select

    End Sub

    Protected Sub addPageButton_Click(sender As Object, e As EventArgs) Handles addPageButton.Click

        Dim pageNum As String = cmsPage.addPage("", "")

        Response.Redirect("editPage.aspx?id=" + pageNum + "&action=new")

    End Sub
End Class
