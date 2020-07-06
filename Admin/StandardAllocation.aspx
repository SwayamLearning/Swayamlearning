<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="true" CodeFile="StandardAllocation.aspx.cs" Inherits="Admin_StandardAllocation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
    <style type="text/css">
        /* Style inputs, select elements and textareas */
        input[type=text], select, textarea
        {
            width: 100%;
            padding: 12px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            resize: vertical;
        }
        
        /* Style the label to display next to the inputs */
        label
        {
            padding: 12px 12px 12px 0;
            display: inline-block;
        }
        
        /* Style the submit button */
        input[type=submit]
        {
            background-color: #4CAF50;
            color: white;
            padding: 12px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer; /*float: right;*/
        }
        
        /* Style the container */
        .container
        {
            border-radius: 5px;
            background-color: #f2f2f2;
            padding: 20px;
        }
        
        /* Floating column for labels: 25% width */
        .col-25
        {
            float: left;
            width: 25%;
            margin-top: 6px;
        }
        
        /* Floating column for inputs: 75% width */
        .col-75
        {
            float: left;
            width: 75%;
            margin-top: 6px;
        }
        
        /* Clear floats after the columns */
        .row:after
        {
            content: "";
            display: table;
            clear: both;
        }
        
        /* Responsive layout - when the screen is less than 600px wide, make the two columns stack on top of each other instead of next to each other */
        @media screen and (max-width: 600px)
        {
            .col-25, .col-75, input[type=submit]
            {
                width: 100%;
                margin-top: 0;
            }
        }
    </style>
    <style type="text/css">
    /*    .table table tbody tr td a, .table table tbody tr td span
        {
            position: relative;
            float: left;
            padding: 6px 12px;
            margin-left: -1px;
            line-height: 1.42857143;
            color: #337ab7;
            text-decoration: none;
            background-color: #fff;
            border: 1px solid #ddd;
            width:100%;
        }
        
        .table table > tbody > tr > td > span
        {
            z-index: 3;
            color: #fff;
            cursor: default;
            background-color: #337ab7;
            border-color: #337ab7;
        }
        
        .table table > tbody > tr > td:first-child > a, .table table > tbody > tr > td:first-child > span
        {
            margin-left: 0;
            border-top-left-radius: 4px;
            border-bottom-left-radius: 4px;
        }
        
        .table table > tbody > tr > td:last-child > a, .table table > tbody > tr > td:last-child > span
        {
            border-top-right-radius: 4px;
            border-bottom-right-radius: 4px;
        }
        
        .table table > tbody > tr > td > a:hover, .table table > tbody > tr > td > span:hover, .table table > tbody > tr > td > a:focus, .table table > tbody > tr > td > span:focus
        {
            z-index: 2;
            color: #23527c;
            background-color: #eee;
            border-color: #ddd;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 


    <div class="container" style="margin-top: -50px;">
        <div class="row" style="background: #72abb5; color: White; height: 50px;">
            <div class="col-100">
                <h2>
                    <asp:Label ID="LblPageTitle" runat="server" Text="School Details" meta:resourcekey="LblPageTitleResource1"></asp:Label></h2>
            </div>
        </div>
        <div class="row">
            <div class="col-25">
                <label for="fname">
                    School Name:</label>
            </div>
            <div class="col-75">
                <div>
                    <asp:Literal ID="LtSchoolID" runat="server" Visible="False" meta:resourceKey="LtSchoolIDResource1"></asp:Literal>
                    <asp:DropDownList ID="ddlSchool" runat="server" Width="100%" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged">
                        <asp:ListItem Text="-- Select --"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-25">
                <label for="lname">
                    Allocated:</label>
            </div>
            <div class="col-75">
                <asp:RadioButtonList ID="rlstAllocated" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                    <asp:ListItem Value="0" Text="No"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="row">
            <div class="col-25">
            </div>
            <div class="col-75" style="float: left !important;">
                <asp:Button ID="BtnGo" runat="server" Text="Go" ValidationGroup="VGSearch" meta:resourceKey="BtnGoResource1"
                    OnClick="BtnGo_Click" />
                <asp:Button ID="BtnReset" runat="server" Text="Reset" OnClick="BtnReset_Click" />
                <asp:ValidationSummary ID="VsSearch" ValidationGroup="VGSearch" ShowMessageBox="True"
                    ShowSummary="False" runat="server" meta:resourceKey="VsSearchResource1" />
            </div>
        </div>
        <div class="row" id="dvbtnactive">
            <div class="col-25">
                <asp:ImageButton ID="ImgBtnActivate" runat="server" ImageUrl="~/App_Themes/Responsive/web/activeuser.png"
                    OnClick="ImgBtnActivate_Click" OnClientClick="javascript:return selectmessage();" />
            </div>
        </div>
        <div class="row">
            <div class="col-100">
                <div id="PnlActivateDeactivate" runat="server" visible="false" meta:resourcekey="PnlActivateDeactivateResource1">
                    <div class="subheaduserdetail" id="LblFlActDect" runat="server" cssclass="SubTitle"
                        meta:resourcekey="LblFlActDectResource1">
                        Allocate/Deallocate User
                    </div>
                    <div class="ActivityContent" style="margin-right: 5px;">
                        <div>
                            <asp:Label ID="LblActiveAction" runat="server" Text="Action:" CssClass="textlabel"
                                meta:resourceKey="LblActiveActionResource1"></asp:Label>
                            <asp:RadioButton ID="RdbAllocated" runat="server" Text="Allocate" GroupName="ActDeact"
                                Checked="True" meta:resourceKey="RdbActiveResource1" />
                            <asp:RadioButton ID="RdbDeallocated" runat="server" Text="Deallocate" GroupName="ActDeact"
                                meta:resourceKey="RdbDeactiveResource1" />
                        </div>
                        <div class="gobotton">
                            <asp:Button ID="BtnActDeactSub" runat="server" Text="Submit" CssClass="gobutton"
                                OnClick="BtnActDeactSub_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-100">
                Standard List
              
                    <asp:CheckBoxList ID="ChkUserList" runat="server" CssClass="chkChoice">
                    </asp:CheckBoxList>
                    <asp:GridView ID="GvStandard" runat="server" DataKeyNames="Standard,Allocated,BMSID"
                        CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GvUserList_PageIndexChanging"
                        OnRowCreated="grvEmpStdSubAllocationDetails_RowCreated" AutoGenerateColumns="False"
                        PageSize="10" AllowPaging="true" Style="margin-top: 0px">
                        <Columns>
                            <asp:BoundField DataField="UserID" HeaderText="UserID" Visible="False" meta:resourcekey="BoundFieldResource1" />
                            <asp:TemplateField HeaderText="Select" meta:resourcekey="TemplateFieldResource1"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkSelectHeader" runat="server" onclick="javascript:SelectAllCheckboxes(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkUserID" runat="server" meta:resourcekey="ChkUserIDResource1" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Standard" HeaderText="Standard" />
                            <asp:BoundField DataField="Allocated" HeaderText="Allocated" />
                            <asp:BoundField DataField="BMSID" HeaderText="BMSID" Visible="false" />
                        </Columns>
                        <PagerTemplate>
                            <asp:ImageButton Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                ImageUrl="~/App_Themes/Responsive/web/first.png" ID="ibtnFirst" ToolTip="Move First Page"
                                meta:resourcekey="btnFirstResource1" CssClass="playbtn" Height="30px" />
                            <asp:ImageButton Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                ImageUrl="~/App_Themes/Responsive/web/previous.png" ID="ibtnPrevious" ToolTip="Move Previous Page"
                                meta:resourcekey="btnPreviousResource1" CssClass="playbtn" Height="30px" />
                            <asp:Label ID="LblPage" runat="server" Text="Page" ForeColor="Black" meta:resourcekey="LblPageResource1"></asp:Label>
                            <asp:DropDownList ID="ddlPageSelector" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged" Width="90px"
                                runat="server" AutoPostBack="True" SkinID="DdlWidth50" meta:resourcekey="ddlPageSelectorResource1">
                            </asp:DropDownList>
                            <asp:ImageButton Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                ImageUrl="~/App_Themes/Responsive/web/NEXT.png" ID="ibtnNext" ToolTip="Move Next Page"
                                meta:resourcekey="btnNextResource1" CssClass="playbtn" Height="30px" />
                            <asp:ImageButton Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                ImageUrl="~/App_Themes/Responsive/web/last.png" ID="ibtnLast" ToolTip="Move Last Page"
                                meta:resourcekey="btnLastResource1" CssClass="playbtn" Height="30px"/>
                        </PagerTemplate>
                    </asp:GridView>
               
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="up1" runat="server" class="tblDashboard">
        <ContentTemplate>
            <div class="sidepanel">
                <div class="activitydivside">
                    <div class="ActivityHeader">
                    </div>
                    <div>
                        <p>
                            </li>
                        </p>
                        <ul class="standarbtn">
                            <li class="standarbar">
                                <%--  <asp:ImageButton ID="ImgBtnActivate" runat="server" ImageUrl="~/App_Themes/Responsive/web/activeuser.png"
                                    OnClick="ImgBtnActivate_Click" OnClientClick="javascript:return selectmessage();" />--%>
                            </li>
                        </ul>
                    </div>
                    <div id="PnlSearch" runat="server" meta:resourcekey="PnlSearchResource1" visible="false">
                        <%-- <div class="subheaduserdetail" id="LblFLSearch" runat="server" meta:resourcekey="LblFLSearchResource1">
                            Search</div>
                        <div class="ActivityContent">
                             <div>
                                <asp:Label ID="LblSchoolName" runat="server" Text="School Name:" CssClass="textlabel"
                                    meta:resourceKey="LblSchoolNameResource1"></asp:Label></div>--%>
                        <%--<div>
                                <asp:Literal ID="LtSchoolID" runat="server" Visible="False" meta:resourceKey="LtSchoolIDResource1"></asp:Literal>
                                <asp:DropDownList ID="ddlSchool" runat="server" Width="100%" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlSchool_SelectedIndexChanged">
                                    <asp:ListItem Text="-- Select --"></asp:ListItem>
                                </asp:DropDownList>
                            </div>--%>
                        <%-- <div>
                                <asp:Label ID="lblAllocated" runat="server" Text="Allocated:" CssClass="textlabel"
                                    meta:resourceKey="lblActiveResource1"></asp:Label>
                                <asp:RadioButtonList ID="rlstAllocated" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>--%>
                        <%-- <div class="gobotton">
                                <asp:Button ID="BtnGo" runat="server" Text="Go" CssClass="gobutton" ValidationGroup="VGSearch"
                                    meta:resourceKey="BtnGoResource1" OnClick="BtnGo_Click" />
                                <asp:Button ID="BtnReset" runat="server" Text="Reset" CssClass="gobutton" OnClick="BtnReset_Click" />
                                <asp:ValidationSummary ID="VsSearch" ValidationGroup="VGSearch" ShowMessageBox="True"
                                    ShowSummary="False" runat="server" meta:resourceKey="VsSearchResource1" />
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function selectmessage() {
            var TargetBaseControl = document.getElementById('<%= GvStandard.ClientID %>');
            var AllTick = false;
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox')
                    if (Inputs[n].checked == true) {
                        AllTick = true;
                        break;
                    }
            if (AllTick == false) {
                alert("Please select atleast one record.");
                return false;
            }
            else {
                return true;
            }
        }
    </script>
</asp:Content>
