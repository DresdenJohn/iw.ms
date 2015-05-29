<%@ Page Title="" Language="VB" MasterPageFile="~/admin/Admin.master" AutoEventWireup="false" CodeFile="pages.aspx.vb" Inherits="admin_pages" %>

<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">

    Pages - Dashboard

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="siteContent" Runat="Server">

    <div class="row">
    <div class="col-sm-3 col-md-2 sidebar">
        <ul class="nav nav-sidebar">
            <li class="active"><a href="pages.aspx"><span class="glyphicon glyphicon-th-list"></span> Page Management</a></li>
            <li><a href="editPage.aspx"><span class="glyphicon glyphicon-edit"></span> Page Editor</a></li>
        </ul>
        <hr />
        <ul class="nav nav-sidebar">
            <li><a href="posts.aspx"><span class="glyphicon glyphicon-file"></span> Post Management</a></li>
            <li><a href="editPost.aspx?action=new"><span class="glyphicon glyphicon-plus"></span> New Post</a></li>
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
            <li><a href="settings.aspx"><span class="glyphicon glyphicon-wrench"></span> Settings</a></li>
        </ul>

        <div class="sideBarFooter">
            <p><% Dim cmsSet As New cmsSettings
                    Response.Write(cmsSet.getPageTitle) %> | <span class="glyphicon glyphicon-copyright-mark"></span> 2015</p>
        </div>
    </div>

	<div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main animated slideInDown">

    <h3 class="sub-header">Page Management <asp:LinkButton runat="server" ID="addPageButton" cssclass="btn btn-sm btn-primary">Add New Page</asp:LinkButton></h3>
    
    <div class="table-responsive table-hover">
        <asp:Literal ID="statusLit" runat="server"></asp:Literal>
        <asp:Literal ID="pageList" runat="server"></asp:Literal>
    </div>
    </div>
    </div>


</asp:Content>

