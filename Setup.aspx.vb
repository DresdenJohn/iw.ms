Imports System.IO
Imports System.Data.SqlClient
Imports System.Data
Imports System.Xml
Imports System.Xml.Linq

Partial Class Setup
    Inherits System.Web.UI.Page

    Dim cmsCons As New cmsConnections
    Dim cmsCook As New cmsCookies
    Dim cmsFunc As New cmsFunctions
    Dim cmsSet As New cmsSettings
    Dim cmsUser As New cmsUsers
    Dim cmsPage As New cmsPages

    Public Sub firstTimeSetup()

        createTables()

        fillTables()

        deleteSetupMarker()

        Response.Redirect("default.aspx")

    End Sub

    Public Function checkInputs() As Boolean

        Dim result As Boolean = False

        Dim usernameReg As String = "^[a-zA-Z0-9_-]{3,16}$"
        Dim emailReg As String = "^([a-zA-Z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$"
        Dim passwordReg As String = "^[a-zA-Z0-9_-]{6,18}$"

        If Regex.IsMatch(username.Text, usernameReg) And Regex.IsMatch(password.Text, passwordReg) And Regex.IsMatch(email.Text, emailReg) Then
            results.Text = "<div class='alert alert-success animated fadeInDown' role='alert'>You're All Set! Setting up now...</div>"
            Return True

        Else
            results.Text = "<div class='alert alert-danger animated fadeInDown' role='alert'>Please Check Your Responses and Try Again</div>"
            Return False
        End If

    End Function

    Public Sub fillTables()

        Dim settingTemplateStart As String = "INSERT INTO [dbo].[TBL_SETTINGS]([s_SettingName],[s_Value],[s_UserAuth])VALUES("

        Dim siteNameInsert As String = settingTemplateStart + "'WebsiteName','" + HttpContext.Current.Server.HtmlEncode(siteName.Text) + "','S')"
        Dim activeTheme As String = settingTemplateStart + "'ActiveTheme', 'main','S')"
        Dim siteDescription As String = settingTemplateStart + "'SiteDescription', '" + HttpContext.Current.Server.HtmlEncode(siteDesc.Text) + "','S')"

        Dim accountCreate As String = "INSERT INTO [dbo].[TBL_USERS]([u_Name],[u_Password],[u_Email],[u_DateCreated],[u_Access])VALUES('" + username.Text + "','" + cmsFunc.getEncryptedPassword(password.Text) + "','" + email.Text + "',GETDATE(),'S')"

        Dim defaultPage As String = "INSERT INTO TBL_PAGES([pg_Name],[pg_Content],[pg_VisibilityLevel],[pg_LastUpdated],[pg_LastUpdatedBy])VALUES('default','" + cmsFunc.getPageTemplate() + " ','A',GETDATE(),0)"

        Dim links As String = "INSERT INTO TBL_LINKS([l_Name],[l_URL],[l_Position],[l_VisibilityLevel],[l_Order])VALUES('Home','./default.aspx','topNavBar','A',0)"

        Dim categories As String = "INSERT INTO [dbo].[TBL_CATEGORIES]([c_Name])VALUES('Blog')"

        Try
            Using connection As New SqlConnection(cmsCons.contentSystemCS)

                Dim massCommand As String = siteNameInsert + vbNewLine + activeTheme + vbNewLine + siteDescription + vbNewLine + accountCreate + vbNewLine + defaultPage + vbNewLine + links + vbNewLine + categories

                Dim command As New SqlCommand(massCommand, connection)

                connection.Open()

                command.ExecuteNonQuery()

                connection.Close()

            End Using
        Catch ex As SqlException

        End Try
        
    End Sub

    Public Sub createTables()

        Dim linksTable As String = "CREATE TABLE TBL_LINKS([l_ID] [int] IDENTITY(0,1) NOT NULL,	[l_Name] [nvarchar](50) NULL,[l_URL] [nvarchar](250) NULL,	[l_Category] [nvarchar](50) NULL,[l_Position] [nvarchar](50) NULL,[l_Target] [nvarchar](50) NULL,[l_VisibilityLevel] [nchar](10) NULL,[l_Order] [int] NULL)"

        Dim usersTable As String = "CREATE TABLE TBL_USERS(	[u_ID] [int] IDENTITY(0,1) NOT NULL,[u_Name] [nvarchar](50) NULL,[u_Password] [nvarchar](100) NULL,[u_Email] [nvarchar](50) NULL,	[u_Avatar] [nvarchar](250) NULL,[u_DateCreated] [datetime] NULL,[u_Access] [char](1) NULL,[u_Referred] [int] NULL)"

        Dim postsTable As String = "CREATE TABLE TBL_POSTS([p_ID] [int] IDENTITY(0,1) NOT NULL,[p_CreatedBy] [int] NULL,[p_DateCreated] [datetime] NULL,[p_HeaderImage] [nvarchar](250) NULL,[p_Title] [nvarchar](50) NULL,[p_Content] [text] NULL,[p_Tags] [text] NULL,[p_Category] [nvarchar](50) NULL,[p_VisibilityLevel] [char](1) NULL)"

        Dim pagesTable As String = "CREATE TABLE TBL_PAGES([pg_ID] [int] IDENTITY(0,1) NOT NULL,[pg_Name] [nvarchar](50) NULL,[pg_Content] [text] NULL,[pg_VisibilityLevel] [nchar](10) NULL,[pg_LastUpdated] [datetime] NULL,[pg_LastUpdatedBy] [int] NULL)"

        Dim settingsTable As String = "CREATE TABLE TBL_SETTINGS([s_SettingName] [nvarchar](50) NOT NULL,[s_Value] [text] NULL,[s_UserAuth] [nchar](10) NOT NULL)"

        Dim categoriesTable As String = "CREATE TABLE [dbo].[TBL_CATEGORIES]([c_ID] [int] IDENTITY(0,1) NOT NULL,[c_Name] [nvarchar](50) NULL)"

        Dim queryString As String = linksTable + usersTable + postsTable + pagesTable + settingsTable + categoriesTable

        Try
            Using connection As New SqlConnection(cmsCons.contentSystemCS)

                Dim command As New SqlCommand(queryString, connection)

                connection.Open()

                command.ExecuteNonQuery()

                connection.Close()

            End Using
        Catch ex As SqlException

        End Try

    End Sub

    Public Function checkIfSetup() As Boolean
        Dim setup As Boolean = True

        Dim dir As String = HttpRuntime.AppDomainAppPath

        Dim di As New DirectoryInfo(dir)

        Dim fiArr As FileInfo() = di.GetFiles()

        Dim fri As FileInfo

        Dim counter As Integer = 0

        For Each fri In fiArr

            If fri.Name = "Site.NotSetup" Then
                Return False
            End If

        Next

        Return setup
    End Function

    Public Sub deleteSetupMarker()

        Dim dir As String = HttpRuntime.AppDomainAppPath

        Dim di As New DirectoryInfo(dir)

        Dim fiArr As FileInfo() = di.GetFiles()

        Dim fri As FileInfo

        Dim counter As Integer = 0

        For Each fri In fiArr

            If fri.Name = "Site.NotSetup" Then
                File.Delete(dir + "Site.NotSetup")
            End If

        Next

    End Sub

    Protected Sub testDatabase_Click(sender As Object, e As EventArgs) Handles testDatabase.Click

        If cmsCons.testContentDatabase() Then

            databaseResult.Text = "<div class='label label-success animated tada' role='alert'>Connection Found!</div>"

        Else
            databaseResult.Text = "<div class='label label-danger animated shake' role='alert'>Connection Failed!</div>"
        End If

    End Sub

    Protected Sub runSetup_Click(sender As Object, e As EventArgs) Handles runSetup.Click
        If checkInputs() Then
            If Not cmsCons.testContentDatabase Then
                databaseResult.Text = "<div class='label label-danger animated shake' role='alert'>Check connection!</div>"
            Else
                firstTimeSetup()
            End If
        End If
    End Sub

    Protected Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        If checkIfSetup() Then

        End If

        Dim refreshAction As String = Request.QueryString("actn")

        Select Case (refreshAction)
            Case "dbconnectfail"
                setupContain.Visible = False
                dbError.Visible = True
        End Select

    End Sub

    Public Sub patchCategories()

        Dim queryString As String = "IF object_id('TBL_CATEGORIES', 'U') is null CREATE TABLE [dbo].[TBL_CATEGORIES]([c_ID] [int] IDENTITY(0,1) NOT NULL,[c_Name] [nvarchar](50) NULL) INSERT INTO [dbo].[TBL_CATEGORIES]([c_Name])VALUES('Blog')"

        Using connection As New SqlConnection(cmsCons.contentSystemCS)

            Dim command As New SqlCommand(queryString, connection)

            connection.Open()

            command.ExecuteNonQuery()

            connection.Close()

        End Using

    End Sub

End Class
