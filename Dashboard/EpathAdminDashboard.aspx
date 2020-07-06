<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="true" CodeFile="EpathAdminDashboard.aspx.cs" Inherits="Admin_EpathAdminDashboard" %>

<%@ Register Src="~/UserControl/TeacherNotes.ascx" TagName="TeacherNotes" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" style="margin-top: -50px;">
        <div style="display: none; float: left; width: 40%; padding-left: 5%;">
            <asp:UpdatePanel ID="upEadmin" runat="server">
                <ContentTemplate>
                    <table class="TableControl" width="100%">
                        <tr>
                            <td>
                                <uc2:TeacherNotes ID="ucNotes" runat="server" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="row" style="background: #72abb5; color: White; height: 50px;">
            <div class="col-100">
                <asp:Label ID="lbltext" runat="server" ForeColor="Red" Text="No.of.Visitors:" />
                 <asp:Label ID="lblCount" runat="server" ForeColor="Red" Text="No.of.Visitors:" />
            </div>
        </div>
        <div class="row" style="background: #72abb5; color: White; height: 50px;">
            <div class="col-100">
                Recent Updates
            </div>
        </div>
        <div class="row">
            <div class="col-100">
                <div class="user-profile" >
                    <asp:GridView ID="gvRegistration" runat="server" AutoGenerateColumns="False" PageSize="5"
                        CssClass="table table-striped table-bordered table-hover">
                        <Columns>
                            <asp:TemplateField HeaderText="Student Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblSchool" runat="server" Text='<%# Eval("StudentName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblBMSSCT" runat="server" Text='<%# Eval("ContactNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EmailID">
                                <ItemTemplate>
                                    <asp:Label ID="lblNote" runat="server" Text='<%# Eval("EmailID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Registration Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedOn" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy}", Eval("CreatedOn")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            No Registration Found
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="eduresource">
                    <asp:GridView ID="grdviewedu" runat="server"  AutoGenerateColumns="False" PageSize="5" CssClass="table table-striped table-bordered table-hover">
                        <Columns>
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:Label ID="lblSchool" runat="server" Text='<%# Eval("EduResourceID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BMSSCT">
                                <ItemTemplate>
                                    <asp:Label ID="lblBMSSCT" runat="server" Text='<%# Eval("BMS_SCT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Resource">
                                <ItemTemplate>
                                    <asp:Label ID="lblNote" runat="server" Text='<%# Eval("Resource") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="URL">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedOn" runat="server" Text='<%# Eval("ResourceURL") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            No Registration Found
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-100">
                <asp:LinkButton ID="lnkViewAllAdmission" runat="server" Text="View More..." OnClick="lnkViewAllAdmission_Click"
                    ForeColor="Blue"></asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
