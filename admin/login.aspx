<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="admin_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Dashboard Login</title>

    <link href="~/css/bootstrap.min.css" rel="stylesheet" />
    <link href="./css/dashboard.css" rel="stylesheet" />
    <link href="./css/login.css" rel="stylesheet" />
    <link href="~/css/animate.css" rel="stylesheet" />
    

    <link rel="icon" type="image/png" href="../theme/main/img/favicon.png"/>

    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>
<body>
    <form id="form1" runat="server">
        
        <div class="container animated fadeInDown">
            <div class="form-signin">
                <h3 style="text-align:center;"><%Response.Write(cmsSettings.getPageTitle) %></h3>
                <br />
                <asp:Literal ID="loginFail" runat="server" Visible="false">
                    <div class="alert alert-danger alert-dismissible fade in" role="alert">
                      <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                      <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Incorrect Login Info
                    </div>

                </asp:Literal>
                <asp:Literal ID="loginRequired" runat="server" Visible="false">
                    <div class="alert alert-warning alert-dismissible fade in" role="alert">
                      <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                      <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Please Login First
                    </div>

                </asp:Literal>
                <asp:Literal ID="logout" runat="server" Visible="false">
                    <div class="alert alert-info alert-dismissible fade in" role="alert">
                      <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                      <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> You have logged out
                    </div>

                </asp:Literal>
                <asp:Login ID="Login1" runat="server" CssClass="fullWidth" FailureText="Invalid Login; Try Again">
                    <LayoutTemplate>
                        <asp:Label ID="UserNameLabel" CssClass="sr-only" runat="server" AssociatedControlID="UserName">Email Address</asp:Label>
                        <asp:TextBox CssClass="form-control" type="email" AutoCompleteType="Email" placeholder="Email" ID="UserName" runat="server" required="" autofocus=""></asp:TextBox>

                        <asp:Label ID="PasswordLabel" CssClass="sr-only" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                        <asp:TextBox CssClass="form-control" ID="Password" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                        <div class="checkbox">
                            <label>
                                <asp:CheckBox ID="RememberMe" runat="server"/> Remember Me
                            </label>
                        </div>

                        <asp:Literal ID="FailureText" runat="server" EnableViewState="false"></asp:Literal>
                        <asp:Button ID="LoginButton" CssClass="btn btn-md btn-primary btn-block" runat="server" CommandName="Login" Text="Sign In" ValidationGroup="Login1" OnClick="LoginButton_Click"/>
                        <a class="btn btn-md btn-primary btn-block" href="../default.aspx">Back to Home</a>
                    </LayoutTemplate>
                </asp:Login>
            </div> 
        </div>
        

        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
        <script src="../js/bootstrap.min.js"></script>
        <script src="../js/holder.js"></script>

    </form>
</body>
</html>
