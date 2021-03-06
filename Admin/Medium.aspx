﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="true" CodeFile="Medium.aspx.cs" Inherits="Admin_Medium" Culture="auto"
    meta:resourcekey="PageResource2" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
    <script type="text/javascript">        $(document).ready(function () {
            $("#<%= ibtnSearch.ClientID%>").click(function () {
                if ($("#<%= pnlSearch.ClientID%>").is(':visible')) {
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlActDeact.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                else {
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlActDeact.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                return false;
            });

            $("#<%= ibtnAdd.ClientID%>").click(function () {
                if ($("#<%= pnlAdd.ClientID%>").is(':visible')) {
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlActDeact.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                else {
                    $("#<%= pnlAdd.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlActDeact.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                return false;
            });
            $("#<%= ibtnActiveDeactive.ClientID%>").click(function () {
                if ($("#<%= pnlAdd.ClientID%>").is(':visible')) {
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlActDeact.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                else {
                    $("#<%= pnlActDeact.ClientID%>").removeClass("InVisible").addClass("Visible");
                    $("#<%= pnlAdd.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlSearch.ClientID%>").removeClass("Visible").addClass("InVisible");
                    $("#<%= pnlEdit.ClientID%>").removeClass("Visible").addClass("InVisible");
                }
                return false;
            });
        });   
    </script>
    <script type="text/javascript">
        var TotalChkBx;
        var Counter;

        Counter = 0;


        function SelectAll(CheckBox) {

            var TargetBaseControl = document.getElementById('<%= this.grvSYS_Mediumdetail.ClientID %>');

            var TargetChildControl = "chkselect";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox')
                    Inputs[n].checked = CheckBox.checked;
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function ChildClick(CheckBox) {

            TotalChkBx = parseInt('<%= this.grvSYS_Mediumdetail.Rows.Count %>');

            var HeaderCheckBox = document.getElementById('ctl00_ContentPlaceHolder1_grvSYS_Mediumdetail_ctl01_chkHeaderchkSelect');
            if (CheckBox.checked && Counter < TotalChkBx)
                Counter++;
            else if (Counter > 0)
                Counter--;
            if (Counter < TotalChkBx)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBx)
                HeaderCheckBox.checked = true;
        }         
    
    </script>
     <style type="text/css">
        
        .InVisible
        {
            visibility: hidden;
            display: none;
        }
        .Visible
        {
            visibility: visible;
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" style="margin-top: -50px;">
        <div class="row" style="background: #72abb5; color: White; height: 50px;">
            <div class="col-100">
                <asp:Label ID="lblTitle" runat="server" Text="Medium" meta:resourcekey="lblTitleResource1"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-100">
                <asp:ImageButton ID="ibtnRefresh" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarRefresh.png"
                    OnClick="ibtnRefresh_Click" ToolTip="Refresh" meta:resourcekey="ibtnRefreshResource1" />
                <asp:ImageButton ID="ibtnAdd" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarAdd.png"
                    ToolTip="Add Medium" meta:resourcekey="ibtnAddResource1" />
                <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarEdit.png"
                    OnClick="ibtnEdit_Click" ToolTip="Edit" meta:resourcekey="ibtnEditResource1" />
                <asp:ImageButton ID="ibtnActiveDeactive" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarActiveDeactive.png"
                    ToolTip="Active/Deactive Medium" meta:resourcekey="ibtnActiveDeactiveResource1" />
                <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App_Themes/Images/ButtonBarView.png"
                    ToolTip="Search" meta:resourcekey="ibtnSearchResource1" />
            </div>
        </div>
        <div class="row">
            <div class="col-100">
                <asp:Panel ID="pnlSearch" runat="server" CssClass="Visible" meta:resourcekey="pnlSearchResource1">
                    <fieldset id="fsSearchInfo" runat="server" style="margin: 5px">
                        <legend>
                            <asp:Label ID="lblSearchTitle" runat="server" Text="Search" CssClass="SubTitle" meta:resourcekey="lblSearchTitleResource1"></asp:Label>
                        </legend>
                        <table class="tblControl1">
                            <tr>
                                <td>
                                    <asp:Label ID="lblMediumSearch" runat="server" Text="Medium:" meta:resourcekey="lblMediumSearchResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMediumSearch" runat="server" meta:resourcekey="txtMediumSearchResource1"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblCodeSearch" runat="server" Text="Code:" meta:resourcekey="lblCodeSearchResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCodeSearch" runat="server" meta:resourcekey="txtCodeSearchResource1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDescriptionSearch" runat="server" Text="Description:" meta:resourcekey="lblDescriptionSearchResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescriptionSearch" runat="server" meta:resourcekey="txtDescriptionSearchResource1"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblActive" runat="server" Text="Active:" meta:resourceKey="lblActiveResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rlstActive" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1" Text="Yes" meta:resourceKey="lblActiveListItemResource1"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="No" meta:resourceKey="lblActiveListItemResource2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3" align="center">
                                    <asp:Button ID="btnSearch" ValidationGroup="aSearch" CssClass="gobutton" runat="server"
                                        Text="Go" AlternateText="Search" OnClick="BtnSearch_Click" meta:resourcekey="btnSearchResource2" />
                                    <asp:Button ID="btnSearchReset" runat="server" Text="Reset" meta:resourcekey="btnCancelResource1"
                                        OnClick="btnSearchReset_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
            </div>
        </div>
        <div class="row">
            <div class="col-100">
                <asp:Panel ID="pnlAdd" runat="server" CssClass="InVisible" meta:resourcekey="pnlAddResource1">
                    <fieldset id="fsAdd" runat="server" style="margin: 5px">
                        <legend>
                            <asp:Label ID="lblAddTitle" runat="server" Text="Add" CssClass="SubTitle" meta:resourcekey="lblAddTitleResource1"></asp:Label>
                        </legend>
                        <table class="tblControl1">
                            <tr>
                                <td>
                                    <asp:Label ID="lblMedium" runat="server" Text="Medium:" meta:resourcekey="lblMediumResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMedium" runat="server" meta:resourcekey="txtMediumResource1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqFieldMedium" runat="server" ErrorMessage="Please Insert Medium"
                                        ValidationGroup="a" ControlToValidate="txtMedium" meta:resourcekey="ReqFieldMediumResource1">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblCode" runat="server" Text="Code:" meta:resourcekey="lblCodeResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCode" runat="server" meta:resourcekey="txtCodeResource1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqFieldCode" runat="server" ErrorMessage="Please Insert Code"
                                        ValidationGroup="a" ControlToValidate="txtCode" meta:resourcekey="ReqFieldCodeResource1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDescription" runat="server" Text="Description:" meta:resourcekey="lblDescriptionResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescription" runat="server" meta:resourcekey="txtDescriptionResource1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqFieldDescription" runat="server" ErrorMessage="Please Insert Description"
                                        ValidationGroup="a" ControlToValidate="txtDescription" meta:resourcekey="ReqFieldDescriptionResource1">*</asp:RequiredFieldValidator>
                                </td>
                                <td colspan="2" style="text-align: left">
                                    <asp:Button ID="btnSave" ValidationGroup="a" runat="server" Text="Save" AlternateText="Save"
                                        CssClass="gobutton" OnClick="BtnSave_Click" meta:resourcekey="btnSaveResource1" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Reset" CssClass="gobutton" OnClick="BtnCancel_Click"
                                        meta:resourcekey="btnCancelResource1" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:ValidationSummary ID="ValSumSYS_Medium" runat="server" ValidationGroup="a" meta:resourcekey="ValSumSYS_MediumResource1" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
            </div>
        </div>
        <div class="row">
            <div class="col-100">
                <asp:Panel ID="pnlEdit" runat="server" CssClass="InVisible" meta:resourcekey="pnlEditResource1">
                    <fieldset id="fsEmpStdSubEdit" runat="server" style="margin: 5px">
                        <legend>
                            <asp:Label ID="lblEditTitle" runat="server" Text="Edit" CssClass="SubTitle" meta:resourcekey="lblEditTitleResource1"></asp:Label>
                        </legend>
                        <table class="tblControl1">
                            <tr>
                                <td>
                                    <asp:Label ID="lblMediumEdit" runat="server" Text="Medium:" meta:resourcekey="lblMediumEditResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMediumEdit" runat="server" meta:resourcekey="txtMediumEditResource1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqFieldMediumEdit" runat="server" ErrorMessage="Please Insert Medium"
                                        ValidationGroup="aEdit" ControlToValidate="txtMediumEdit" meta:resourcekey="ReqFieldMediumEditResource1">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblCodeEdit" runat="server" Text="Code:" meta:resourcekey="lblCodeEditResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCodeEdit" runat="server" meta:resourcekey="txtCodeEditResource1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqFieldCodeEdit" runat="server" ErrorMessage="Please Insert Code"
                                        ValidationGroup="aEdit" ControlToValidate="txtCodeEdit" meta:resourcekey="ReqFieldCodeEditResource1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDescriptionEdit" runat="server" Text="Description:" meta:resourcekey="lblDescriptionEditResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescriptionEdit" runat="server" meta:resourcekey="txtDescriptionEditResource1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqFieldDescriptionEdit" runat="server" ErrorMessage="Please Insert Description"
                                        ValidationGroup="aEdit" ControlToValidate="txtDescriptionEdit" meta:resourcekey="ReqFieldDescriptionEditResource1">*</asp:RequiredFieldValidator>
                                </td>
                                <td colspan="2" style="text-align: left;">
                                    <asp:Button ID="btnUpdate" ValidationGroup="aEdit" runat="server" Text="Update" AlternateText="Save"
                                        CssClass="gobutton" OnClick="BtnUpdate_Click" meta:resourcekey="btnUpdateResource1" />
                                    <asp:Button ID="btnCancelEdit" runat="server" CssClass="gobutton" Text="Cancel" OnClick="BtnCancelEdit_Click"
                                        meta:resourcekey="btnCancelEditResource1" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:ValidationSummary ID="ValSumSYS_MediumEdit" runat="server" ValidationGroup="aEdit"
                                        meta:resourcekey="ValSumSYS_MediumEditResource1" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
            </div>
        </div>
        <div class="row">
            <div class="col-100">
                <asp:Panel ID="pnlActDeact" runat="server" CssClass="InVisible" meta:resourcekey="pnlActDeactResource1">
                    <fieldset id="fsActDeact" runat="server" style="margin: 5px">
                        <legend>
                            <asp:Label ID="lblActDeactTitle" runat="server" Text="Active/Deactive " meta:resourcekey="lblActDeactTitleResource1"></asp:Label>
                        </legend>
                        <table cellspacing="1" style="margin: 5px" class="tblControl1">
                            <tr>
                                <td>
                                    <asp:Label ID="lblPnlActDeactTitle" runat="server" Text="Please Select Action:" meta:resourcekey="lblPnlActDeactTitleResource1"></asp:Label>
                                    <asp:RadioButton ID="rbActive" runat="server" Text=" Active" GroupName="ActDeact"
                                        Checked="True" meta:resourcekey="rbActiveResource1" />
                                    <asp:RadioButton ID="rbDeactive" runat="server" Text=" Deactive" GroupName="ActDeact"
                                        meta:resourcekey="rbDeactiveResource1" />
                                </td>
                                <td>
                                    <asp:Button ID="btnActDeactSub" runat="server" Text="Submit" CssClass="gobutton"
                                        OnClick="BtnActDeactSub_Click" meta:resourcekey="btnActDeactSubResource1" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
            </div>
        </div>
        <div class="row">
            <div class="col-100">
                <asp:UpdatePanel ID="upDetails" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grvSYS_Mediumdetail" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover"
                            CellPadding="4" DataKeyNames="MediumID,Medium,Code,Description,IsActive,CreatedOn,CreatedByName,ModifiedOn,ModifiedByName"
                            OnPageIndexChanging="grvSYS_Mediumdetail_PageIndexChanging" OnSorting="grvSYS_Mediumdetail_Sorting"
                            OnRowCreated="grvSYS_Mediumdetail_RowCreated" meta:resourcekey="grvSYS_MediumdetailResource1">
                            <Columns>
                                <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                                    <HeaderTemplate>
                                        <table>
                                            <tr>
                                                <td align="center">
                                                    <asp:CheckBox ID="chkHeaderchkSelect" runat="server" onclick="javascript:SelectAll(this);"
                                                        meta:resourcekey="chkHeaderchkSelectResource1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td align="center">
                                                    <asp:CheckBox ID="chkSelect" runat="server" onclick="javascript:ChildClick(this);"
                                                        meta:resourcekey="chkSelectResource1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sr. No" meta:resourcekey="TemplateFieldResource2">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %></ItemTemplate>
                                    <ItemStyle Width="5px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Medium" SortExpression="Medium" HeaderText="Medium" meta:resourcekey="BoundFieldResource1">
                                    <ItemStyle Width="10px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Code" SortExpression="Code" HeaderText="Code" meta:resourcekey="BoundFieldResource2">
                                    <ItemStyle Width="5px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Description" SortExpression="Description" HeaderText="Description"
                                    meta:resourcekey="BoundFieldResource3" />
                                <asp:BoundField DataField="CreatedOn" SortExpression="CreatedOn" HeaderText="CreatedOn"
                                    DataFormatString="{0: dd-MMM-yyyy hh:mm tt}" meta:resourcekey="BoundFieldResource5">
                                    <ItemStyle Width="25px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CreatedByName" SortExpression="CreatedByName" HeaderText="CreatedBy"
                                    meta:resourcekey="BoundFieldResource6">
                                    <ItemStyle Width="20px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ModifiedOn" SortExpression="ModifiedOn" HeaderText="ModifiedOn"
                                    DataFormatString="{0: dd-MMM-yyyy hh:mm tt}" meta:resourcekey="BoundFieldResource7">
                                    <ItemStyle Width="25px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ModifiedByName" SortExpression="ModifiedByName" HeaderText="ModifiedBy"
                                    meta:resourcekey="BoundFieldResource8">
                                    <ItemStyle Width="20px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Active" SortExpression="Active" HeaderText="Active" meta:resourcekey="BoundFieldResource4">
                                    <ItemStyle Width="3px" />
                                </asp:BoundField>
                            </Columns>
                            <PagerTemplate>
                                <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                    ImageUrl="~/App_Themes/Images/first.png" ID="ibtnFirst" ToolTip="Move First Page"
                                    meta:resourcekey="ibtnFirstResource1" />
                                <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                    ImageUrl="~/App_Themes/Images/previous.png" ID="ibtnPrevious" ToolTip="Move Previous Page"
                                    meta:resourcekey="ibtnPreviousResource1" />
                                <asp:Label ID="lblPage" runat="server" Text="Page" meta:resourcekey="lblPageResource1"></asp:Label>
                                <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged"
                                    runat="server" AutoPostBack="True" SkinID="DdlWidth50" meta:resourcekey="ddlPageSelectorResource1">
                                </asp:DropDownList>
                                <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                    ImageUrl="~/App_Themes/Images/NEXT.png" ID="ibtnNext" ToolTip="Move Next Page"
                                    meta:resourcekey="ibtnNextResource1" />
                                <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                    ImageUrl="~/App_Themes/Images/last.png" ID="ibtnLast" ToolTip="Move Last Page"
                                    meta:resourcekey="ibtnLastResource1" />
                            </PagerTemplate>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
  
</asp:Content>
