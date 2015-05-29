<%@ Page Title="" Language="VB" MasterPageFile="~/admin/Admin.master" AutoEventWireup="false" CodeFile="categories.aspx.vb" Inherits="admin_categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" Runat="Server">

    Categories - Dashboard

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="siteContent" Runat="Server">

    <div class="row">
    <div class="col-sm-3 col-md-2 sidebar">
        <ul class="nav nav-sidebar">
            <li><a href="pages.aspx"><span class="glyphicon glyphicon-th-list"></span> Page Management</a></li>
            <li><a href="editPage.aspx"><span class="glyphicon glyphicon-edit"></span> Page Editor</a></li>
        </ul>
        <hr />
        <ul class="nav nav-sidebar">
            <li><a href="posts.aspx"><span class="glyphicon glyphicon-file"></span> Post Management</a></li>
            <li><a href="editPost.aspx?action=new"><span class="glyphicon glyphicon-plus"></span> New Post</a></li>
        </ul>
        <hr />
        <ul class="nav nav-sidebar">
            <li class="active"><a href="categories.aspx"><span class="glyphicon glyphicon-list-alt"></span> Categories</a></li>
            <li><a href="links.aspx"><span class="glyphicon glyphicon-link"></span> Links</a></li>
        </ul>
        <hr />
        <ul class="nav nav-sidebar">
            <li><a href="users.aspx"><span class="glyphicon glyphicon-user"></span> Users</a></li>
        </ul>
        <hr />
        <ul class="nav nav-sidebar">
            <li><a href="settings.aspx"><span class="glyphicon glyphicon-wrench"></span> Settings</a></li>
        </ul>

        <div class="sideBarFooter">
            <p><% Dim cmsSet As New cmsSettings
                    Response.Write(cmsSet.getPageTitle) %> | <span class="glyphicon glyphicon-copyright-mark"></span> 2015</p>
        </div>
    </div>

	<div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main animated slideInDown">

        <div class="row">
            <div class="col-lg-8">
                <h3>Category Management <asp:LinkButton CssClass="btn btn-primary disabled noCurves" runat="server" ID="addCatBtn">Add New</asp:LinkButton></h3>
                <hr />
            </div>
        </div>

        

    </div>
    </div>

</asp:Content>

