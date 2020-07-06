<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="true" CodeFile="RegistrationReport.aspx.cs" Inherits="Report_RegistrationReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" style="margin-top: -50px;">
        <div class="row" style="background: #72abb5; color: White; height: 50px;">
            <div class="col-100">
                <asp:Label ID="LblTitle" runat="server" Text="Date Wise Registration Report"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-100">
                <asp:UpdatePanel runat="server" ID="UpRegistration" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="row" style="margin-left: 5px;">
                            <div class="col-25" style="padding-top: 10px;">
                                Registration Start Date:
                            </div>
                            <div class="col-25">
                                <asp:TextBox ID="TxtStartDate" runat="server" Width="70%"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalExtStartDate" runat="server" TargetControlID="TxtStartDate"
                                    PopupButtonID="ibtnStartDate" Enabled="True" Format="dd MMM, yyyy">
                                </cc1:CalendarExtender>
                            </div>
                            <div class="col-25" style="padding-top: 10px;">
                                Registration End Date:
                            </div>
                            <div class="col-25">
                                <asp:TextBox ID="TxtEndDate" runat="server" Width="70%"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalExtEndDate" runat="server" TargetControlID="TxtEndDate"
                                    PopupButtonID="ibtnEndDate" Enabled="True" Format="dd MMM, yyyy">
                                </cc1:CalendarExtender>
                                <asp:Button ID="btnSubmit" runat="server" Text="Go" OnClick="btnSubmit_Click" ValidationGroup="VgAdmission" />
                            </div>
                        </div>
                        <div class="row" style="margin-left: 5px;">
                        </div>
                        <div class="row" style="margin-left: 5px;">
                            <div class="col-100 scrollgridx">
                                <asp:GridView ID="gvRegistration" runat="server" AutoGenerateColumns="False" OnRowCommand="gvRegistration_RowCommand"
                                    AllowPaging="true" OnSorting="gvRegistration_Sorting" OnPageIndexChanging="gvRegistration_PageIndexChanging"
                                    PageSize="10" OnRowCreated="gvRegistration_RowCreated" OnRowDataBound="gvRegistration_RowDataBound"
                                    CssClass="table table-striped table-bordered table-hover">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Student Name" SortExpression="StudentName">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("StudentName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contact Number" SortExpression="ContactNo">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("ContactNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EmailID" SortExpression="EmailID">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("EmailID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Registration Date" SortExpression="CreatedOn">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# string.Format("{0:dd MMM, yyyy}", Eval("CreatedOn")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Package Name" SortExpression="PackageName">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="ShowPackage" runat="server" CommandName="ShowPackage" CommandArgument='<%#Eval("PackageID") %>'><%# Eval("PackageName") %></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Activate On" SortExpression="ActivateOn">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# string.Format("{0:dd MMM, yyyy}", Eval("ActivateOn")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="From Date" SortExpression="FromDate">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# string.Format("{0:dd MMM, yyyy}", Eval("FromDate")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Valid Till" SortExpression="ValidTill">
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" Text='<%# string.Format("{0:dd MMM, yyyy}", Eval("ValidTill")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerTemplate>
                                        <%--<div class="row">
                                        <div class="col-5">--%>
                                        <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                            ImageUrl="~/App_Themes/Responsive/web/first.png" ID="ibtnFirst" ToolTip="Move First Page"
                                            meta:resourcekey="btnFirstResource1"  Width="30px"/>
                                        <%--</div>
                                        <div class="col-5">--%>
                                        <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                            ImageUrl="~/App_Themes/Responsive/web/previous.png" ID="ibtnPrevious" ToolTip="Move Previous Page"
                                            meta:resourcekey="btnPreviousResource1" Width="30px" />
                                        <%--</div>
                                        <div class="col-20">--%>
                                        <div style="display: inline; padding-top: -5px !important;">
                                            <asp:Label ID="LblPage" runat="server" Text="Page" ForeColor="Black" meta:resourcekey="LblPageResource1"></asp:Label>
                                            <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged"
                                                Width="100px" runat="server" AutoPostBack="True" SkinID="DdlWidth50" meta:resourcekey="ddlPageSelectorResource1">
                                            </asp:DropDownList>
                                        </div>
                                        <%--</div>
                                        <div class="col-5">--%>
                                        <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                            ImageUrl="~/App_Themes/Responsive/web/NEXT.png" ID="ibtnNext" ToolTip="Move Next Page"
                                            meta:resourcekey="btnNextResource1"  Width="30px"/>
                                        <%--</div>
                                        <div class="col-5">--%>
                                        <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                            ImageUrl="~/App_Themes/Responsive/web/last.png" ID="ibtnLast" ToolTip="Move Last Page"
                                            meta:resourcekey="btnLastResource1" Width="30px"/>
                                        <%--</div>
                                    </div>--%>
                                    </PagerTemplate>
                                    <EmptyDataTemplate>
                                        No Registration Found
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                        <%--<div style="width: 90%; margin: auto; margin-top: 30px;">
                            <div class="activitydivside1" style="margin-top: 15px; margin-bottom: 15px;">
                                <div class="ActivityContent">
                                </div>
                            </div>
                        </div>--%>
                        <!--Show Package-->
                        <asp:Button ID="BtnShowPackagePopup" runat="server" Text="Show" Style="display: none" />
                        <asp:Button ID="BtnCancelPackagePopup" runat="server" Text="Close" Style="display: none" />
                        <cc1:ModalPopupExtender ID="MdlPackageSleep" runat="server" PopupControlID="PnlPackageSleep"
                            TargetControlID="BtnShowPackagePopup" BackgroundCssClass="modalBackground" CancelControlID="BtnCancelPackagePopup">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="PnlPackageSleep" runat="server" Style="display: none;">
                            <div class="activitydivfull">
                                <div class="ActivityHeader">
                                    <asp:Label ID="lblactionTitle" runat="server" Text="Package Detail"></asp:Label>
                                    <div style="float: right; padding: 0px 5px 0px 0px;">
                                        <img onclick="javascript:return ClosePackagePopup();" alt="Close" src="../App_Themes/Images/close.png"
                                            height="20px" width="20px" style="cursor: pointer;" />
                                    </div>
                                </div>
                                <div class="ActivityContent">
                                    <div style="margin-top: 15px; overflow: auto;">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top: 10px;">
                                                    <asp:GridView ID="gvpackage" runat="server" Style="margin-top: 2px; margin-bottom: 15px;"
                                                        EmptyDataText="No Mail Record Found" AutoGenerateColumns="false" Width="200%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Package Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("PackageName") %>' /></ItemTemplate>
                                                                <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Package Type">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("PackageType") %>' /></ItemTemplate>
                                                                <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="BMS">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("BMS") %>' /></ItemTemplate>
                                                                <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Subject">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("Subject") %>' /></ItemTemplate>
                                                                <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Price">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label12" runat="server" Text='<%#Eval("Price") %>' /></ItemTemplate>
                                                                <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Number Of Days">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label13" runat="server" Text='<%#Eval("NoOfMonth") %>' /></ItemTemplate>
                                                                <ItemStyle CssClass="GridViewRows" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <!--Send Package-->
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvRegistration" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- LoaderPart start-->
    <asp:Button ID="btnLoader" runat="server" Style="display: none" />
    <asp:Button ID="btnCancel" runat="server" Style="display: none" />
    <cc1:ModalPopupExtender ID="ModalPopup" runat="server" PopupControlID="dvPopup" CancelControlID="btnCancel"
        TargetControlID="btnLoader" BackgroundCssClass="modalBackground" Enabled="True">
    </cc1:ModalPopupExtender>
    <table id="dvPopup" runat="server" class="loadingtable" cellpadding="0" cellspacing="0"
        style="display: none;">
        <tr>
            <td>
                <img src="../App_Themes/Responsive/web/Loader.gif" alt="Loading Please wait.." />
            </td>
        </tr>
        <tr>
            <td class="loadingtabletd">
                <span>Loading Please Wait..</span>
            </td>
        </tr>
    </table>
    <!-- LoaderPart end-->
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            ShowLoader();
        }
        function EndRequestHandler(sender, args) {
            HideLoader();
        }
        function ShowLoader() {
            if ($("#<%= btnLoader.ClientID%>") != null) {
                $("#<%= btnLoader.ClientID%>").click();
            }
        }
        function HideLoader() {
            if ($("#<%= btnCancel.ClientID%>") != null) {
                $("#<%= btnCancel.ClientID%>").click();
            }
        }
        function ClosePackagePopup() {
            if ($("#<%= BtnCancelPackagePopup.ClientID%>") != null) {
                $("#<%= BtnCancelPackagePopup.ClientID%>").click();
            }
            return false;
        }     
    </script>
</asp:Content>
