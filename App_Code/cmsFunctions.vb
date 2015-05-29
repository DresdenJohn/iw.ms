Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Xml
Imports System.Xml.Linq

Public Class cmsFunctions

    Private cmsCons As New cmsConnections
    Private cmsSet As New cmsSettings

    Public Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        Dim sBuilder As New StringBuilder()

        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        Return sBuilder.ToString()

    End Function

    Public Function getEncryptedPassword(ByVal passwordText As String) As String

        Dim passwordSource As String = "L16vobDwmk" + passwordText

        Using md5Hash As MD5 = MD5.Create()
            Return GetMd5Hash(md5Hash, passwordSource)
        End Using

    End Function

    Public Function getThemeName() As String

        Dim themeName As String = "main"

        Return themeName

    End Function

    Public Function loadStyles() As String

        Dim themeResult As String = ""

        Dim queryString As String = "SELECT * FROM TBL_SETTINGS WHERE s_SettingName = 'ActiveTheme'"

        Try
            Using connection As New SqlConnection(cmsCons.contentSystemCS)

                Dim command As New SqlCommand(queryString, connection)

                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader

                reader.Read()

                Dim styleName As String = reader("s_Value")

                Dim directoryFull As String = "/theme/" + styleName + "/css/"

                Dim dir As String = HttpRuntime.AppDomainAppPath + "theme\" + styleName + "\css\"

                Dim di As New DirectoryInfo(dir)

                Dim fiArr As FileInfo() = di.GetFiles()

                Dim fri As FileInfo

                For Each fri In fiArr

                    themeResult += "<link href='." + directoryFull + fri.Name + "' rel='stylesheet' />" + vbNewLine

                Next

                If cmsSet.isDebugging Then

                    themeResult += dir
                    themeResult += di.ToString

                End If

                reader.Close()
                connection.Close()

            End Using
        Catch ex As SqlException
            Return ex.Message
        End Try

        Return themeResult

    End Function

    Public Function loadLiveViewStyles() As String

        Dim themeResult As String = ""

        Dim queryString As String = "SELECT * FROM TBL_SETTINGS WHERE s_SettingName = 'ActiveTheme'"

        Try
            Using connection As New SqlConnection(cmsCons.contentSystemCS)

                Dim command As New SqlCommand(queryString, connection)

                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader

                reader.Read()

                Dim styleName As String = reader("s_Value")

                Dim directoryFull As String = "../theme/" + styleName + "/css/"

                Dim dir As String = HttpRuntime.AppDomainAppPath + ".\theme\" + styleName + "\css\"

                Dim di As New DirectoryInfo(dir)

                Dim fiArr As FileInfo() = di.GetFiles()

                Dim fri As FileInfo

                For Each fri In fiArr

                    themeResult += "<link href='" + directoryFull + fri.Name + "' rel='stylesheet' />" + vbNewLine

                Next

                If cmsSet.isDebugging Then

                    themeResult += dir
                    themeResult += di.ToString

                End If

                reader.Close()
                connection.Close()

            End Using
        Catch ex As SqlException
            Return ex.Message
        End Try

        Return themeResult

    End Function

    Public Function loadScripts() As String

        Dim scriptResult As String = ""

        Dim queryString As String = "SELECT * FROM TBL_SETTINGS WHERE s_SettingName = 'ActiveTheme'"

        Try
            Using connection As New SqlConnection(cmsCons.contentSystemCS)

                Dim command As New SqlCommand(queryString, connection)

                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader

                reader.Read()

                Dim styleName As String = reader("s_Value")

                Dim directoryFull As String = "/theme/" + styleName + "/js/"

                Dim dir As String = HttpRuntime.AppDomainAppPath + "theme\" + styleName + "\js\"

                Dim di As New DirectoryInfo(dir)

                Dim fiArr As FileInfo() = di.GetFiles()

                Dim fri As FileInfo

                For Each fri In fiArr

                    scriptResult += "<script src='." + directoryFull + fri.Name + "'></script>" + vbNewLine

                Next

                If cmsSet.isDebugging Then

                    scriptResult += dir
                    scriptResult += di.ToString

                End If

                reader.Close()
                connection.Close()

            End Using
        Catch ex As SqlException

        End Try

        Return scriptResult

    End Function

    Public Function getPageTemplate() As String

        Dim page As String = <![CDATA[&lt;div class=&quot;splash&quot;&gt;

&lt;div class=&quot;container&quot;&gt;
		&lt;div class=&quot;row&quot;&gt;
          &lt;div class=&quot;col-md-offset-1 col-md-10 col-md-offset-1&quot;&gt;
            &lt;div class=&quot;jumbotron animated fadeIn&quot;&gt;
              &lt;h3&gt;Hello world!&lt;/h3&gt;
                &lt;hr /&gt;
              &lt;p&gt;This is the starting template for your iw.ms site! You can access the login panel with your email and password used for &lt;a href=&quot;/admin/&quot;&gt;here&lt;/a&gt; and edit this homepage and banner. Please note that iw.ms isn&#39;t fully finished yet and may have bugs. Full documentation coming soon!&lt;/p&gt;
            &lt;/div&gt;
          &lt;/div&gt;
      	&lt;/div&gt;
	&lt;/div&gt; &lt;!-- /container --&gt;

&lt;/div&gt;

&lt;div class=&quot;container&quot;&gt;

	&lt;div class=&quot;row&quot;&gt;

		&lt;div class=&quot;col-md-7 col-md-offset-1 blog-main&quot;&gt;

			&lt;div class=&quot;blog-post&quot;&gt;
				&lt;h2 class=&quot;blog-post-title&quot;&gt;Sample blog post&lt;/h2&gt;
				&lt;p class=&quot;blog-post-meta&quot;&gt;January 1, 2014 by &lt;a href=&quot;#&quot;&gt;Mark&lt;/a&gt;&lt;/p&gt;

				&lt;p&gt;This blog post shows a few different types of content that&#39;s supported and styled with Bootstrap. Basic typography, images, and code are all supported.&lt;/p&gt;
				&lt;hr&gt;
				&lt;p&gt;Cum sociis natoque penatibus et magnis &lt;a href=&quot;#&quot;&gt;dis parturient montes&lt;/a&gt;, nascetur ridiculus mus. Aenean eu leo quam. Pellentesque ornare sem lacinia quam venenatis vestibulum. Sed posuere consectetur est at lobortis. Cras mattis consectetur purus sit amet fermentum.&lt;/p&gt;
				&lt;blockquote&gt;
				  &lt;p&gt;Curabitur blandit tempus porttitor. &lt;strong&gt;Nullam quis risus eget urna mollis&lt;/strong&gt; ornare vel eu leo. Nullam id dolor id nibh ultricies vehicula ut id elit.&lt;/p&gt;
				&lt;/blockquote&gt;
				&lt;p&gt;Etiam porta &lt;em&gt;sem malesuada magna&lt;/em&gt; mollis euismod. Cras mattis consectetur purus sit amet fermentum. Aenean lacinia bibendum nulla sed consectetur.&lt;/p&gt;
				&lt;h2&gt;Heading&lt;/h2&gt;
				&lt;p&gt;Vivamus sagittis lacus vel augue laoreet rutrum faucibus dolor auctor. Duis mollis, est non commodo luctus, nisi erat porttitor ligula, eget lacinia odio sem nec elit. Morbi leo risus, porta ac consectetur ac, vestibulum at eros.&lt;/p&gt;
				&lt;h3&gt;Sub-heading&lt;/h3&gt;
				&lt;p&gt;Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.&lt;/p&gt;
				&lt;pre&gt;&lt;code&gt;Example code block&lt;/code&gt;&lt;/pre&gt;
				&lt;p&gt;Aenean lacinia bibendum nulla sed consectetur. Etiam porta sem malesuada magna mollis euismod. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa.&lt;/p&gt;
				&lt;h3&gt;Sub-heading&lt;/h3&gt;
				&lt;p&gt;Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean lacinia bibendum nulla sed consectetur. Etiam porta sem malesuada magna mollis euismod. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus.&lt;/p&gt;
				&lt;ul&gt;
				  &lt;li&gt;Praesent commodo cursus magna, vel scelerisque nisl consectetur et.&lt;/li&gt;
				  &lt;li&gt;Donec id elit non mi porta gravida at eget metus.&lt;/li&gt;
				  &lt;li&gt;Nulla vitae elit libero, a pharetra augue.&lt;/li&gt;
				&lt;/ul&gt;
				&lt;p&gt;Donec ullamcorper nulla non metus auctor fringilla. Nulla vitae elit libero, a pharetra augue.&lt;/p&gt;
				&lt;ol&gt;
				  &lt;li&gt;Vestibulum id ligula porta felis euismod semper.&lt;/li&gt;
				  &lt;li&gt;Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.&lt;/li&gt;
				  &lt;li&gt;Maecenas sed diam eget risus varius blandit sit amet non magna.&lt;/li&gt;
				&lt;/ol&gt;
				&lt;p&gt;Cras mattis consectetur purus sit amet fermentum. Sed posuere consectetur est at lobortis.&lt;/p&gt;
			  &lt;/div&gt;&lt;!-- /.blog-post --&gt;

		&lt;/div&gt;&lt;!-- /.blog-main --&gt;

		&lt;div class=&quot;col-md-3 blog-sidebar&quot;&gt;

			&lt;div class=&quot;sidebar-module sidebar-module-inset&quot;&gt;
				&lt;h4&gt;Meta&lt;/h4&gt;
				&lt;p&gt;&lt;a href=&quot;/admin/&quot;&gt;Admin Login&lt;/a&gt;&lt;/p&gt;
			&lt;/div&gt;
			&lt;div class=&quot;sidebar-module sidebar-module-inset&quot;&gt;
				&lt;h4&gt;Social&lt;/h4&gt;
				&lt;p&gt;&lt;a href=&quot;#&quot;&gt;RSS Feed&lt;/a&gt;&lt;/p&gt;
				&lt;p&gt;&lt;a href=&quot;#&quot;&gt;Twitter&lt;/a&gt;&lt;/p&gt;
				&lt;p&gt;&lt;a href=&quot;#&quot;&gt;Facebook&lt;/a&gt;&lt;/p&gt;
			&lt;/div&gt;

		&lt;/div&gt;&lt;!-- /.blog-sidebar --&gt;

	&lt;/div&gt;&lt;!-- /.row --&gt;
&lt;/div&gt;]]>.Value

        Return page

    End Function

End Class
