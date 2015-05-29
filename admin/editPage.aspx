<%@ Page Title="" Language="VB" MasterPageFile="~/admin/Admin.master" AutoEventWireup="false" CodeFile="editPage.aspx.vb" Inherits="admin_editPage" ValidateRequest="false" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" Runat="Server">

    Page Editor - Dashboard

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="siteContent" Runat="Server">

    <div class="row">

        <div class="col-md-2 sidebar">
            <ul class="nav nav-sidebar">
                <li><a href="pages.aspx"><span class="glyphicon glyphicon-th-list"></span> Page Management</a></li>
                <li class="active"><a href="#"><span class="glyphicon glyphicon-edit"></span> Page Editor</a></li>
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

	    <div class="col-sm-offset-2 col-md-10 main animated fadeIn">

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <h3>
                <a href="pages.aspx">Page Management</a> > 
                <a href="editPage.aspx">Page Editor</a> > 
                <asp:Literal runat="server" ID="pageTitleLink">
                </asp:Literal>
            </h3>
            <hr />
            <div class="row">
                <asp:UpdatePanel ID="pageStatusPanel" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="previewPage" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="savePage" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <div class="col-lg-12">
                            <asp:Label ID="pageStatus" runat="server"></asp:Label>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </div>
            <div class="row">
                <div class="col-md-offset-1 col-md-5">

                    <asp:UpdatePanel ID="updatePan3" runat="server">
                        <ContentTemplate>
                            <div class="panel panel-primary noCurves">
                                <div class="panel-heading noCurves">
                                    <h4 class="panel-title"><span class="glyphicon glyphicon-th-list"></span> Page Settings <asp:label ID="pageSettingsUpdate" runat="server" CssClass="label label-default noCurves">Unchanged</asp:label></h4> 
                                </div>
                                <div class="panel-body noCurves">
                                    <div class="input-group">
                                        <span class="input-group-addon noCurves" id="sizing-addon1"><b>Page Title</b></span>
                                        <asp:TextBox CssClass="form-control noCurves" runat="server" ID="pageTitle" required="" onkeypress="settingChange('siteContent_pageSettingsUpdate')"></asp:TextBox>
                                    </div>
                                    <br />
                                    <div class="input-group">
                                        <span class="input-group-addon noCurves" id="sizing-addon3"><b>Visibility</b></span>
                                        <asp:DropDownList onchange="settingChange('siteContent_pageSettingsUpdate')" ID="visibilityChoice" CssClass="form-control noCurves" runat="server">
                                            <asp:ListItem Value="A">Visible to All</asp:ListItem>
                                            <asp:ListItem Value="S">Visible to Admins</asp:ListItem>
                                            <asp:ListItem Value="D">Hidden (Draft)</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <br />
                                    <div class="input-group">
                                        <span class="input-group-addon noCurves" id="sizing-addon2"><b>Page Type</b></span>
                                        <asp:DropDownList onchange="settingChange('siteContent_pageSettingsUpdate')" ID="pageDropdown" disabled="" CssClass="form-control noCurves" runat="server">
                                            <asp:ListItem>Static Page</asp:ListItem>
                                            <asp:ListItem>Post Category: (Category Here)</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
                <div class="col-md-5">

                    <div class="panel panel-primary noCurves">
                        <div class="panel-heading noCurves">
                            <h4 class="panel-title"><span class="glyphicon glyphicon-th-list"></span> Page Edit Tools</h4>
                        </div>
                        <div class="panel-body">
                            <asp:UpdatePanel ID="updatePanel2" runat="server" UpdateMode="Conditional">
                
                                <ContentTemplate>
                                    <asp:LinkButton ID="previewPage" runat="server" CssClass="btn btn-md btn-primary btn-block editButtons"><span class="glyphicon glyphicon-eye-open"></span> Preview Live Page</asp:LinkButton>
                                    <asp:LinkButton ID="savePage" runat="server" CssClass="btn btn-md btn-primary btn-block editButtons"><span class="glyphicon glyphicon-save"></span> Save Page</asp:LinkButton>
               
                                </ContentTemplate>

                            </asp:UpdatePanel>

                            <hr />

                           <asp:LinkButton runat="server" ID="pageTips" data-toggle="modal" data-target="#pageTipsModal" OnClientClick="myfunction(); return false;" CssClass="btn btn-md btn-primary btn-block editButtons"><span class="glyphicon glyphicon-cog"></span> Page Settings Help</asp:LinkButton>
                            <asp:LinkButton runat="server" OnClientClick="myfunction(); return false;" data-toggle="modal" data-target="#editTipsModal" id="editTips" cssclass="btn btn-md btn-primary btn-block editButtons"><span class="glyphicon glyphicon-pencil"></span> Page Edit Tips</asp:LinkButton>
                            <hr />
                            <asp:LinkButton runat="server" ID="delPage" data-toggle="modal" data-target="#deletePageModal" OnClientClick="myfunction(); return false;" CssClass="btn btn-md btn-danger btn-block editButtons delButton"><span class="glyphicon glyphicon-trash"></span> Delete This Page</asp:LinkButton>

                        </div>
                    </div>

                </div>
            </div>
            <hr />

            <asp:UpdatePanel ID="switchPanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="row">
                        <div class="col-lg-offset-3 col-lg-3">
                            <asp:LinkButton runat="server" ID="switchToCode" CssClass="btn btn-block btn-primary"><span class="glyphicon glyphicon-console"></span> Code Edit View</asp:LinkButton>
                        </div>
                        <div class="col-lg-3">
                            <asp:LinkButton runat="server" ID="switchToLive" disabled="" CssClass="btn btn-block btn-primary"><span class="glyphicon glyphicon-edit"></span> Live View</asp:LinkButton>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

            <hr />

            <asp:UpdatePanel ID="pageViewPanel" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="switchToCode" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="switchToLive" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <asp:UpdatePanel ID="updatePanel1" runat="server" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="previewPage" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="savePage" EventName="Click" />
                        </Triggers>
                        <ContentTemplate>

                            <script src="ckeditor/ckeditor.js"></script>
                            <script src="ckeditor/adapters/jquery.js"></script>

                            <div class="panel panel-primary noCurves animated fadeIn">
                                <div class="panel-heading noCurves">
                                    <h4 class="panel-title">Site Live View</h4>
                                    <asp:Literal ID="liveViewStyles" runat="server"></asp:Literal>
                                </div>
                                <div class="panel-body" id="liveViewEditor" runat="server" style="padding:0;">
                                    <asp:Literal ID="liveView" runat="server"></asp:Literal>
                                </div>
                            
                                <%--<script>
                                    function loadEditor(id) {
                                        var instance = CKEDITOR.instances[id];
                                        if (instance) {
                                            CKEDITOR.remove(instance);
                                        }
                                        CKEDITOR.inline(id);
                                    }

                                    $(document).ready(function () {
                                        loadEditor('siteContent_liveViewEditor')
                                    });
                                </script>--%>
                                    
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                     <asp:UpdatePanel ID="updatePanel3" Visible="false" runat="server">
                        <ContentTemplate>
                            <div class="panel panel-primary noCurves animated fadeIn">
                                <div class="panel-heading noCurves">
                                    <h4 class="panel-title">Code Editor</h4>
                                </div>
                                <div class="panel-body" style="padding: 0;">
                                    <CKEditor:CKEditorControl ID="CKEditor1" BasePath="ckeditor" runat="server" Skin="flat" RemovePlugins="toolbar" StartupMode="Source" Height="400" ExtraPlugins="codemirror"></CKEditor:CKEditorControl>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>

    <div class="modal fade" id="pageTipsModal" tabindex="1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="modalTitle">Page Settings Help</h4>
            </div>
            <div class="modal-body">
                <p>Above you'll see the following settings: Page Title and Page Type. First one is simply the name of that specific page (About, Downloads, Info, etc).</p>
                <p>The second option defines if that page will be static or will act as a page that displays posts of a specific <a href="categories.aspx">category</a>. When selected as a post type, choose also what category of posts to pull from.</p>
            </div>
            <div class="modal-footer">
            <button type="button" class="btn btn-default noCurves" data-dismiss="modal">Close</button>
            </div>
        </div>
        </div>
    </div>
    <div class="modal fade" id="deletePageModal" tabindex="1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="delPageTitle">Delete Page Confirmation</h4>
            </div>
            <div class="modal-body">
                <p>Are you sure you want to delete this page? It will be gone forever!<br /><small>(That's a long time!)</small></p>
            </div>
            <div class="modal-footer">
            <button type="button" class="btn btn-default noCurves" data-dismiss="modal">Close</button>
            <asp:LinkButton ID="deletePageBtn" CssClass="btn btn-danger noCurves" runat="server">Delete Page</asp:LinkButton>
            </div>
        </div>
        </div>
    </div>
    <div class="modal fade" id="editTipsModal" tabindex="1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="myModalLabel">Page Editing Tips</h4>
            </div>
            <div class="modal-body">
            <p>The code editor below holds the middle content (excluding header and footer) in full source view. You can use the preview button on the right to update the live view on the bottom before saving the page.</p>
            <p>Note: When a page is chosen as a "post" type, then the editor below will serve as the <b>sidebar only</b>.</p>
            <p>The framework used is <a href="http://getbootstrap.com">Bootstrap</a>, a CSS and JavaScript framework that makes website making simple.</p>
            <p>Bootstrap Usage Tips and Tricks:</p>
            <ul>
                <li><a href="http://getbootstrap.com/getting-started/#examples">Starting Templates</a></li>
                <li><a href="http://getbootstrap.com/components/">Components</a></li>
                <li><a href="http://getbootstrap.com/css/">CSS</a></li>
                <li><a href="http://getbootstrap.com/javascript/">JavaScript</a></li>
            </ul>
            </div>
            <div class="modal-footer">
            <button type="button" class="btn btn-default noCurves" data-dismiss="modal">Close</button>
            </div>
        </div>
        </div>
    </div>

    <asp:Literal ID="delPageLit" runat="server"></asp:Literal>
            
</asp:Content>

