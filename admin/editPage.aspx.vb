Imports System.IO

Partial Class admin_editPage
    Inherits System.Web.UI.Page

    Public cmsPage As New cmsPages
    Public cmsFunc As New cmsFunctions

    Protected Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        If Not Page.IsPostBack Then

            Dim pageid As String = Request.QueryString("id")

            If pageid Is Nothing Then
                pageid = "0"
            End If

            Dim action As String = Request.QueryString("action")

            Select Case (action)
                Case "delete"
                    delPageLit.Text = "<script>$(window).load(function () {$('#deletePageModal').modal('show');});</script>"
                Case "new"
                    pageStatus.Text = "<div class='alert alert-success alert-dismissible fade in noCurves' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><span class='glyphicon glyphicon-ok' aria-hidden='true'></span> Page has been created! You can visit your new page <a href='../page.aspx?id=" + pageid.ToString + "'>here</a>.</div>"
            End Select

            Dim currentPage As String = cmsPage.getPage(pageid, True)

            Dim titleCap As String = StrConv(Server.HtmlDecode(cmsPage.getTitle(pageid)), vbProperCase)

            pageTitle.Text = titleCap

            pageTitleLink.Text = "<a href='../page.aspx?id=" + pageid + "' target='_blank'>" + titleCap + "</a>"

            If titleCap.ToLower.Equals("home") Then
                pageTitle.Attributes.Add("disabled", "")
                visibilityChoice.Attributes.Add("disabled", "")
                pageDropdown.Attributes.Add("disabled", "")
                pageTitle.Text = "Homepage Title Cannot Be Changed"
                deletePageBtn.Attributes.Add("disabled", "")
                deletePageBtn.Text = "Can't Delete Home Page"
            End If

            CKEditor1.Text = currentPage

            liveView.Text = currentPage

            liveViewStyles.Text = cmsFunc.loadLiveViewStyles()

        End If

    End Sub

    Protected Sub previewPage_Click(sender As Object, e As EventArgs) Handles previewPage.Click

        Dim currenText As String = CKEditor1.Text

        liveView.Text = currenText

    End Sub

    Protected Sub savePage_Click(sender As Object, e As EventArgs) Handles savePage.Click

        Dim currenText As String = pageTitle.Text

        If currenText.Equals("Homepage Title Cannot Be Changed") Then
            currenText = "Home"
        End If

        Dim pageContent As String = HttpContext.Current.Server.HtmlEncode(CKEditor1.Text)

        Dim pageNum As String = ""

        If Request.QueryString("id") Is Nothing Then
            pageNum = "0"
        Else
            pageNum = Request.QueryString("id")
        End If

        Dim resultCounter As Integer = cmsPage.setPage(pageNum, pageContent, Server.HtmlEncode(currenText), visibilityChoice.SelectedValue)

        If resultCounter > 0 Then

            pageStatus.Text = "<div class='alert alert-success alert-dismissible fade in noCurves' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><span class='glyphicon glyphicon-ok' aria-hidden='true'></span> Page has been saved!</div>"

            liveView.Text = CKEditor1.Text

        Else
            pageStatus.Text = "<div class='alert alert-danger alert-dismissible fade in noCurves' style='margin:0' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><span class='glyphicon glyphicon-remove' aria-hidden='true'></span> Page has not been saved!</div><br/>"

            liveView.Text = CKEditor1.Text
        End If


    End Sub

    Protected Sub deletePageBtn_Click(sender As Object, e As EventArgs) Handles deletePageBtn.Click
        Dim pageNum As String = ""

        If Request.QueryString("id") Is Nothing Then
            pageNum = "0"
        Else
            pageNum = Request.QueryString("id")
        End If

        cmsPage.deletePage(pageNum)

        Response.Redirect("pages.aspx?action=deleted")

    End Sub

    Protected Sub switchToCode_Click(sender As Object, e As EventArgs) Handles switchToCode.Click

        updatePanel1.Visible = False
        updatePanel3.Visible = True
        switchToCode.Attributes.Add("disabled", "")
        switchToLive.Attributes.Remove("disabled")

    End Sub

    Protected Sub switchToLive_Click(sender As Object, e As EventArgs) Handles switchToLive.Click

        liveView.Text = CKEditor1.Text

        updatePanel1.Visible = True
        updatePanel3.Visible = False
        switchToLive.Attributes.Add("disabled", "")
        switchToCode.Attributes.Remove("disabled")

    End Sub
End Class
