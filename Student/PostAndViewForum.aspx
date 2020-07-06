<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/materialMaster.master" AutoEventWireup="true"
    CodeFile="PostAndViewForum.aspx.cs" Inherits="Student_PostAndViewForum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .pblock {
            width: 100%;
            list-style-type: none;
            margin: 0 auto;
            padding: 5px;
            margin-bottom: 10px;
            border: 1px solid #cccccc;
            border-radius: 5px;
        }

            .pblock .pdetail {
                padding: 5px 5px 15px 5px;
            }

            .pblock .rdetail {
                -moz-border-radius: 5px;
                border-radius: 5px;
                webkit-border-radius: 5px;
                border: 1px solid #c3ccdf;
                padding-left: 20px;
                background-color: #FFF;
                margin-left: 20px;
                width: 760px;
                padding: 10px 0px 15px 10px;
                margin-bottom: 10px;
                display: block;
            }

        .bydetail {
            border: 1px solid #cccccc;
            border-radius: 5px;
            background-color: #dddddd;
            display: inline-block;
            padding: 4px;
            margin-left: 10px;
        }
    </style>
    <%--gridview button css--%>
    <style>
        .UsersGridViewButton {
            border: thin solid #B6E427;
            font-family: 'Arial Unicode MS';
            background-color: green;
            color: #FFFFFF;
            font-style: normal;
            text-align: center;
            padding-right: 10px;
            padding-left: 10px;
        }
    </style>
    <style>
        .col-md-12 {
            padding-left: 100px;
        }

        tr, td {
            width: 900px;
        }
    </style>
    <script type="text/javascript">
        //GridView Comment
        function showReply(n) {
            $("#divReply" + n).show();
            return false;
        }
        function closeReply(n) {
            $("#divReply" + n).hide();
            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 80%; margin: auto;">
        <%-- <div class="activitydivside1">
            <div class="ActivityHeader">
                <asp:Label runat="server" Text="Post Forum"></asp:Label>
                <div>
                    <asp:ValidationSummary ID="Vlsgpost" ValidationGroup="Vgpost" runat="server" Font-Bold="False"
                        ShowMessageBox="True" ShowSummary="False" />
                </div>
            </div>
            <div class="ActivityContent" style="text-align: center;">
                <textarea id="TxtForum" runat="server" rows="5" cols="100" style="min-width: 400px;
                    max-width: 400px; padding: 5px;"></textarea>
                <asp:RequiredFieldValidator ID="RqdForum" runat="server" ControlToValidate="TxtForum"
                    ErrorMessage="Please enter post text." ValidationGroup="Vgpost">*</asp:RequiredFieldValidator>
                <div style="display: inline-block; vertical-align: bottom;">
                    <asp:Button ID="btnpost" Text="Post" runat="server" OnClick="btnpost_Click" ValidationGroup="Vgpost" />
                </div>
            </div>
        </div>--%>
        <div class="activitydivside1" style="margin-top: 15px;">
            <div class="ActivityHeader">
                <asp:Label runat="server" Text="View Forum"></asp:Label>
            </div>
            <div class="ActivityContent" style="background-color: #e7ebf2 !important;">
                <asp:GridView ID="GvPost" AutoGenerateColumns="false" runat="server" ShowHeader="false"
                    BackColor="#e7ebf2">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="pblock">
                                    <div class="pdetail">
                                        <p>
                                            <asp:Label ID="Label3" Text='<%# Eval("Forum") %>' runat="server" />
                                            <span class="bydetail">Post On
                                                <asp:Label ID="Label1" Text='<%# Eval("PostedOn") %>' runat="server" />
                                                By
                                                <asp:Label ID="Label2" Text='<%# Eval("PostedBy") %>' runat="server" />
                                            </span>
                                        </p>
                                        <div style="display: inline-block; float: right;">
                                        </div>
                                    </div>
                                    <div class="rdetail">
                                        <asp:Label ID="Label4" Text='<%# Eval("Forum") %>' runat="server" />
                                        <span class="bydetail">Reply On
                                            <asp:Label ID="Label5" Text='<%# Eval("PostedOn") %>' runat="server" />
                                            By
                                            <asp:Label ID="Label6" Text='<%# Eval("PostedBy") %>' runat="server" />
                                        </span>
                                        <div style="display: block; float: right;">
                                            <asp:Button Text="My Reply" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="GridView1" BorderStyle="None" CssClass="table-responsive" Width="100%" GridLines="None" runat="server" AutoGenerateColumns="False" ShowHeader="False">
                    <Columns>

                        <asp:BoundField DataField="ForumID" Visible="false" HeaderText="PostedBy" />

                        <asp:TemplateField HeaderText="ParentMessage">
                            <ItemTemplate>
                                <div class="container">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <table>
                                                <tr>
                                                    <td style="width: 55px; vertical-align: top; padding-top: 10px">
                                                        <%--  <asp:Label ID="lblParentDate" runat="server" Text='<%#Bind("Forum") %>'></asp:Label>--%>
                                                        <br />
                                                        <asp:Image ID="ImageParent" runat="server" Style="width: 25px; height: 25px;" ImageUrl="~/Images/student-512.png" />
                                                        <asp:Label ID="Label4" Font-Bold="true" ForeColor="#0F697A" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>

                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CommentMessage") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lb1COmmenId" runat="server" Visible="false" Text='<%#Eval("ForumID") %>'></asp:Label>

                                                        <a class="link" id='lnkReplyParent<%#Eval("ForumID") %>' href="javascript:void(0)" onclick="showReply(<%#Eval("ForumID") %>);return false;">Reply</a>&nbsp;
                                        <a class="link" id="lnkCancle" href="javascript:void(0)" onclick="closeReply(<%#Eval("ForumID") %>);return false;">Cancle</a>
                                                        <div id='divReply<%#Eval("ForumID") %>' style="display: none; margin-top: 5px;">
                                                            <asp:TextBox ID="textCommentReplyParent" CssClass="input-group" runat="server" Width="90%" TextMode="MultiLine"></asp:TextBox>
                                                            <br />
                                                            <asp:Button ID="btnReplyParent" runat="server" Text="Reply" CssClass="UsersGridViewButton" OnClick="btnReplyParent_Click" />
                                                        </div>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td style="padding-left: 100px; border-bottom: 1px solid #4cff00;">
                                                        <br />

                                                        <asp:GridView ID="GridView2" BorderStyle="None" GridLines="None" runat="server" AutoGenerateColumns="False" DataSource='<%# Bind("Empl") %>' ShowHeader="False">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="UserName">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblChildDate" runat="server" Text='<%#Bind("CommentDate") %>'></asp:Label>
                                                                        <br />
                                                                        <asp:Image ID="ImageParent" runat="server" Style="width: 25px; height: 25px;" ImageUrl="~/Images/student-512.png" />
                                                                        <asp:Label ID="Label2" runat="server" Font-Bold="true" ForeColor="#C2822B" Text='<%#Bind("UserName") %>'></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("commentMessage") %>'></asp:Label>
                                                                        <hr />

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>

                                                        <br />





                                                    </td>
                                                </tr>
                                            </table>
                                        </div>

                                    </div>
                                </div>






                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllReplyDetails" TypeName="ParentCommentIDAcess"></asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>
