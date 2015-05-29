<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Setup.aspx.vb" Inherits="Setup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>iw.ms setup</title>

    <link href="./css/bootstrap.min.css" rel="stylesheet" />
    <link href="./css/animate.css" rel="stylesheet" />

    <link href="css/Setup.css" rel="stylesheet" />

    <link rel="icon" type="image/png" href="./theme/main/img/favicon.png"/>

    <link href='http://fonts.googleapis.com/css?family=Droid+Sans' rel='stylesheet' type='text/css' />

    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Label ID="dbError" runat="server" Visible="false">
            <div class="container">
                <div class="alert alert-danger fade in" role="alert">
                    <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Sorry! It seems my site isn't up right now. Check back in a little bit! (Error 503)
                </div>
            </div>
        </asp:Label>
        <asp:Label ID="setupContain" runat="server">
            <div class="container animated fadeInDown">
            <div class="header">
                <h3 class="text-muted text-center">iw.ms first-time setup</h3>
            </div>

            <hr />

            <h3>Welcome</h3>
            <p>It looks like this is your first time running iw.ms so I'll do my best to get you started right away.</p>

            <hr />

            <h3>Step One:</h3>
            <p>If you haven't already please go to:</p>
            <pre><code>Site Root &gt; App_Code &gt; cmsConnections.vb</code></pre> 

            <p>Ensure the following credentials are in place in order to connect to the dabatase.</p>
            <pre><code>Private SQLUsername As String = "iwms_user"
Private SQLPassword As String = "makeOneUp"
Private SQLDataSource As String = "127.0.0.1"
Private SQLDatabase As String = "iwms_dbf"</code></pre>
            
            <p>Once you fill out the rest of the form you can test the database connection (Not required but reccomended)</p>

            <hr />

            <h3>Step Two:</h3>
            <p>Fill out the following information to setup your site (These can be changed later)</p>

            <asp:UpdatePanel ID="updatePanel2" runat="server">
                <Triggers><asp:AsyncPostBackTrigger ControlID="runSetup" EventName="Click" /></Triggers>
                <ContentTemplate>
                    <asp:Literal ID="pageConent" runat="server"></asp:Literal>
                    <div class="row">
                        <div class="col-lg-10">
                            <div class="input-group">
                              <span style="border-bottom-left-radius:0px;" class="input-group-addon" id="basic-addon1" >Site Name</span>
                                <asp:TextBox ID="siteName" CssClass="form-control topText" runat="server" required="" ValidationGroup="setup"></asp:TextBox>
                            </div>
                            <div class="input-group">
                              <span style="border-top-left-radius:0;" class="input-group-addon" id="basic-addon2">Site Description</span>
                                <asp:TextBox ID="siteDesc" CssClass="form-control botText" runat="server" required="" ValidationGroup="setup"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-2">

                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            
            <hr />
            <h3>Step Three:</h3>
            <p>Create a new account with admin access.</p>

            <p>Credential Requirements:</p>
            <pre><code>Email must be valid
Username cannot have any symbols or spaces
Password can have any letter or number, no spaces or symbols</code></pre>

            <asp:UpdatePanel ID="updatePanel3" runat="server" UpdateMode="Conditional">
                <Triggers><asp:AsyncPostBackTrigger ControlID="runSetup" EventName="Click" /></Triggers>
                <ContentTemplate>
                    <asp:Literal ID="loginResult" runat="server"></asp:Literal>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="input-group">
                              <span style="border-bottom-left-radius:0px;" class="input-group-addon" id="basic-addon6">Username</span>
                                <asp:TextBox ID="username" CssClass="form-control topText" runat="server" required="" ValidationGroup="setup"></asp:TextBox>
                            </div>
                            <div class="input-group">
                              <span style="border-bottom-left-radius:0px;border-top-left-radius:0px;" class="input-group-addon" id="basic-addon3">E-mail</span>
                                <asp:TextBox ID="email" AutoCompleteType="Email" type="email" CssClass="form-control topText" runat="server" required="" ValidationGroup="setup"></asp:TextBox>
                            </div>
                            <div class="input-group">
                              <span style="border-top-left-radius:0px;" class="input-group-addon" id="basic-addon4">Password</span>
                                <asp:TextBox ID="password" TextMode="Password" CssClass="form-control botText" runat="server" required="" ValidationGroup="setup"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            
            <hr />

            <div class="row">

                <div class="col-lg-offset-1 col-lg-10 col-lg-offset-1">
                    <asp:UpdatePanel ID="resultsUpdate" runat="server">
                        <ContentTemplate>
                            <asp:Literal ID="results" runat="server"></asp:Literal>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="row">
                        <div class="col-lg-7">
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="testDatabase" EventName="Click"/>
                                </Triggers>
                                <ContentTemplate>

                                    <asp:Button ValidationGroup="dbCheck" CssClass="btn btn-primary btn-sm" ID="testDatabase" runat="server" Type="button" Text="Test Database Connection" CausesValidation="false" />
                        
                                    <asp:Literal ID="databaseResult" runat="server">
                                        <div class="label label-default" role="alert">Waiting for Test</div>
                                    </asp:Literal>

                    
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-lg-5">
                            <asp:Button ValidationGroup="setup" ID="runSetup" runat="server" CssClass="btn btn-sm btn-primary btn-block" text="Save &amp; Setup"/>
                        </div>
                    </div>
                </div>
            </div>
            <hr />
            <footer class="footer">
                <p class="text-right">&copy; iw.ms | 2015</p>
            </footer>

        </div> <!-- /container -->
        </asp:Label>
        


        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
        <script src="./js/bootstrap.min.js"></script>
        <script src="./js/holder.js"></script>

    </form>
</body>
</html>
