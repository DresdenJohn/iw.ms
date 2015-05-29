<%@ Page Title="" Language="VB" MasterPageFile="~/admin/Admin.master" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="dash_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">

    Overview - Dashboard

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="siteContent" Runat="Server">

    <div class="row">
        <div class="col-md-2 sidebar">
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
                       Response.Write(cmsSet.getPageTitle)%> | <span class="glyphicon glyphicon-copyright-mark"></span> 2015</p>
            </div>
        </div>

	    <div class="col-md-offset-2 col-md-10 main animated slideInDown">

            <div class="row">
                <div class="col-lg-10">
                    <h3>Welcome to the Admin Dashboard!</h3>
                    <p>Pardon the dust here, <b>iw.ms</b> still isn't completed so as of right now you may only have access to certain features. I will be constantly updating the backend and adding more features. So expect changes often! The site itself is stable so don't worry about losing your site. Let me know if you're having any issues!</p>
                    <hr />
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default noCurves">
                                <div class="panel panel-heading noCurves">
                                    <h4 class="panel-title"><span class="glyphicon glyphicon-console"></span> Dashboard Status <span class="label label-info">Estimated 40% Completed</span></h4>
                                </div>
                                <div class="panel panel-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <ul>
                                                <li>Page Management - <span class="label label-success">98% Completed</span>
                                                    <ul>
                                                        <li><span class="label label-success">Completed</span>
                                                            <ul>
                                                                <li>Design/Layout</li>
                                                                <li>VB Backend</li>
                                                                <li>Page Creation/Deletion</li>
                                                                <li>Page Editing/Saving</li>
                                                                <li>Page Name (Setting)</li>
                                                                <li>Page Visibility (Setting)</li>
                                                            </ul>
                                                        </li>
                                                        <li><span class="label label-danger">Unfinished</span>
                                                            <ul>
                                                                <li>Page Type (Setting)</li>
                                                            </ul>
                                                        </li>
                                                    </ul>
                                                </li>
                                        
                                            </ul>
                                        </div>
                                        <div class="col-lg-6">
                                            <ul>
                                                <li>Settings - <span class="label label-success">98% Completed</span>
                                                    <ul>
                                                        <li><span class="label label-success">Completed</span>
                                                            <ul>
                                                                <li>Design/Layout</li>
                                                                <li>VB Backend</li>
                                                                <li>Loading/Editing Current Settings</li>
                                                                <li>Saving Current Settings</li>
                                                            </ul>
                                                        </li>
                                                        <li><span class="label label-danger">Unfinished</span>
                                                            <ul>
                                                                <li>Homepage Content Type (Setting)</li>
                                                            </ul>
                                                        </li>
                                                    </ul>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <ul>
                                                <li>Post Management - <span class="label label-warning">10% Completed</span>
                                                    <ul>
                                                        <li><span class="label label-success">Completed</span>
                                                            <ul>
                                                                <li>VB Backend</li>
                                                            </ul>
                                                        </li>
                                                        <li><span class="label label-danger">Unfinished</span>
                                                            <ul>
                                                                <li>Design/Layout</li>
                                                                <li>Post Creation/Deletion</li>
                                                                <li>Post Editing/Saving</li>
                                                            </ul>
                                                        </li>
                                                    </ul>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="col-lg-6">
                                            <ul>
                                                <li>Links - <span class="label label-danger">0% Completed</span>
                                                    <ul>
                                                        <li><span class="label label-success">Completed</span>
                                                            <ul>
                                                                <li>Nothing yet!</li>
                                                            </ul>
                                                        </li>
                                                        <li><span class="label label-danger">Unfinished</span>
                                                            <ul>
                                                                <li>Design/Layout</li>
                                                                <li>Creation/Deletion</li>
                                                                <li>Editing/Saving</li>
                                                                <li>VB Backend</li>
                                                            </ul>
                                                        </li>
                                                    </ul>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <ul>
                                                <li>Users - <span class="label label-danger">0% Completed</span>
                                                    <ul>
                                                        <li><span class="label label-success">Completed</span>
                                                            <ul>
                                                                <li>Nothing yet!</li>
                                                            </ul>
                                                        </li>
                                                        <li><span class="label label-danger">Unfinished</span>
                                                            <ul>
                                                                <li>Design/Layout</li>
                                                                <li>Creation/Deletion</li>
                                                                <li>Editing/Saving</li>
                                                                <li>VB Backend</li>
                                                            </ul>
                                                        </li>
                                                    </ul>
                                                </li>
                                        
                                            </ul>
                                        </div>
                                        <div class="col-lg-6">
                                            <ul>
                                                <li>Categories - <span class="label label-danger">0% Completed</span>
                                                    <ul>
                                                        <li><span class="label label-success">Completed</span>
                                                            <ul>
                                                                <li>Nothing yet!</li>
                                                            </ul>
                                                        </li>
                                                        <li><span class="label label-danger">Unfinished</span>
                                                            <ul>
                                                                <li>Design/Layout</li>
                                                                <li>Creation/Deletion</li>
                                                                <li>Editing/Saving</li>
                                                                <li>VB Backend</li>
                                                            </ul>
                                                        </li>
                                                    </ul>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

