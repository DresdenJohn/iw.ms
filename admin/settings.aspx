<%@ Page Title="" Language="VB" MasterPageFile="~/admin/Admin.master" AutoEventWireup="false" CodeFile="settings.aspx.vb" Inherits="admin_settings" %>

<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">

    Settings - Dashboard

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="siteContent" Runat="Server">

    <div class="row">
    <div class="col-sm-3 col-md-2 sidebar">
        <ul class="nav nav-sidebar">
            <li><a href="pages.aspx"><span class="glyphicon glyphicon-th-list"></span> Page Management</a></li>
            <li><a href="editPage.aspx"><span class="glyphicon glyphicon-edit"></span> Page Editor</a></li>
        </ul>
        <hr />
        <ul class="nav nav-sidebar">
            <li><a href="posts.aspx"><span class="glyphicon glyphicon-file"></span> Post Management</a></li>
            <li><a href="editPost.aspx"><span class="glyphicon glyphicon-plus"></span> New Post</a></li>
        </ul>
        <hr />
        <ul class="nav nav-sidebar">
            <li><a href="categories.aspx"><span class="glyphicon glyphicon-list-alt"></span> Categories</a></li>
            <li><a href="links.aspx"><span class="glyphicon glyphicon-link"></span> Links</a></li>
        </ul>
        <hr />
        <ul class="nav nav-sidebar">
            <li><a href="users.aspx"><span class="glyphicon glyphicon-user"></span> Users</a></li>
        </ul>
        <hr />
        <ul class="nav nav-sidebar">
            <li class="active"><a href="settings.aspx"><span class="glyphicon glyphicon-wrench"></span> Settings</a></li>
        </ul>

        <div class="sideBarFooter">
            <p><% Dim cmsSet As New cmsSettings
                    Response.Write(cmsSet.getPageTitle) %> | <span class="glyphicon glyphicon-copyright-mark"></span> 2015</p>
        </div>
    </div>

	<div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main animated slideInDown">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="row">
            <div class="col-lg-10">
                <div class="row">
            <div class="col-md-6">
                <h3><% Response.Write(cmsSet.getPageTitle + " Global Settings")  %></h3>
                <hr />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="panel panel-primary noCurves">
                            <div class="panel-heading noCurves">
                                <h4 class="panel-title">Website Name <asp:label ID="siteNameUpdate" runat="server" CssClass="label label-default noCurves">Unchanged</asp:label></h4> 
                            </div>
                            <div class="panel-body noCurves">
                                <div class="input-group">
                                    <asp:textbox runat="server" ID="websiteName" type="text" CssClass="form-control noCurves" placeholder="My Awesome Site" onkeypress="settingChange('siteContent_siteNameUpdate')"></asp:textbox>
                                    <span class="input-group-btn">
                                        <asp:button ID="saveWebsiteName" runat="server" CssClass="btn btn-default" text="Save"/>
                                    </span>
                                </div><!-- /input-group -->
                            </div>
                        </div>

                        
                    </ContentTemplate>

                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">

                    <ContentTemplate>

                        <div class="panel panel-primary noCurves">
                            <div class="panel-heading noCurves">
                                <h4 class="panel-title">Website Description <asp:label ID="siteDescUpdate" runat="server" CssClass="label label-default noCurves">Unchanged</asp:label></h4> 
                            </div>
                            <div class="panel-body noCurves">
                                <div class="input-group">
                                    <asp:textbox runat="server" ID="siteDescription" type="text" CssClass="form-control noCurves" placeholder="My Site is Awesome" onkeypress="settingChange('siteContent_siteDescUpdate')"></asp:textbox>
                                    <span class="input-group-btn">
                                        <asp:button ID="siteDescSave" runat="server" CssClass="btn btn-default" text="Save"/>
                                    </span>
                                </div><!-- /input-group -->
                            </div>
                        </div>
                        
                    </ContentTemplate>

                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">

                    <ContentTemplate>

                        <div class="panel panel-primary noCurves">
                            <div class="panel-heading noCurves">
                                <h4 class="panel-title">Homepage Content Type <asp:label ID="contentTypeUpdate" runat="server" CssClass="label label-danger noCurves">Currently Disabled</asp:label></h4>
                            </div>
                            <div class="panel-body noCurves">
                                <div class="input-group">
                                  <span class="input-group-addon noCurves">
                                      <!-- onchange="settingChange('siteContent_contentTypeUpdate')"  -->
                                    <asp:RadioButton GroupName="contentType" disabled="" runat="server" ID="posts" Text=" Posts" />
                                  </span>
                                    <asp:DropDownList onchange="settingChange('siteContent_contentTypeUpdate')" ID="postsDropdown" CssClass="form-control noCurves" disabled=""  runat="server"><asp:ListItem>Blog</asp:ListItem></asp:DropDownList>
                                
                                </div>
                                <div class="input-group">
                                  <span class="input-group-addon noCurves">
                                    <asp:RadioButton GroupName="contentType" disabled="" runat="server" ID="static" Checked="true" Text=" Static Page" />
                                  </span>
                                <asp:DropDownList onchange="settingChange('siteContent_contentTypeUpdate')" ID="pageDropdown" CssClass="form-control noCurves" disabled="" runat="server"><asp:ListItem>Default</asp:ListItem></asp:DropDownList>
                                    
                                </div>
                                <asp:Button CssClass="btn btn-block btn-default noCurves disabled" ID="saveContentType" runat="server" Text="Save Content Type" />
                            </div>
                        </div>
                    </ContentTemplate>

                </asp:UpdatePanel>

            </div>
            <div class="col-md-6">
                <h3>Settings Quick Tips</h3>
                <hr />
                <div class="panel panel-info noCurves">
                  <div class="panel-heading noCurves">
                    <h3 class="panel-title">Website Name</h3>
                  </div>
                  <div class="panel-body">
                    <p>Pretty straightforward. This will show your website's name across all pages, admin dashboard, and really anywhere that identifies your site as your own.</p>
                  </div>
                </div>
                <div class="panel panel-info noCurves">
                  <div class="panel-heading noCurves">
                    <h3 class="panel-title">Website Description</h3>
                  </div>
                  <div class="panel-body">
                    <p>Be creative with this! This will provide viewers of your site a little background as to what's in store for them. It will also show as meta-data for search engines.</p>
                  </div>
                </div>
                <div class="panel panel-info noCurves">
                  <div class="panel-heading noCurves">
                    <h3 class="panel-title">Homepage Content Type</h3>
                  </div>
                  <div class="panel-body">
                    <p>This decides what shows on your site's front page. It can be a choice between a static page (From your existing <a href="pages.aspx">pages</a>). Or you can choose to show a series of posts of a select <a href="#">category</a>. Choose which type you'd want, and then input the corresponding answer to that type (Post Category, or Static Page Choice)</p>
                  </div>
                </div>
            </div>
        </div>
            </div>
        </div>
    </div>
    </div>

</asp:Content>

