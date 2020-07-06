<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="true" CodeFile="GenerateBMSSCT.aspx.cs" Inherits="DataEntry_GenerateBMSSCT"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" style="margin-top: -50px;">
        <div class="row" style="background: #72abb5; color: White; height: 50px;">
            <div class="col-100">
                <asp:Label ID="LblBMS" runat="server" Text="Generate BMS SCT" meta:resourcekey="LblBMSResource1"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-25">
                <asp:Label ID="lblBoard" runat="server" Text="BMS:" meta:resourcekey="lblBoardResource1"></asp:Label>
            </div>
            <div class="col-75">
                <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged"
                    meta:resourcekey="ddlBoardResource1">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RFVDdlBoard" runat="server" ControlToValidate="DdlBoard"
                    InitialValue="-- Select --" ErrorMessage="Please Select BMS." ValidationGroup="PnlBMS"
                    meta:resourcekey="RFVDdlBoardResource1">*</asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-25">
                <asp:Label ID="LblSubject" runat="server" Text="Subject:" meta:resourcekey="LblSubjectResource1"></asp:Label>
            </div>
            <div class="col-75">
                <asp:DropDownList ID="ddlSubject" runat="server" Enabled="False" SkinID="DdlWidth150"
                    OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" AutoPostBack="True"
                    meta:resourcekey="ddlSubjectResource1">
                    <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RFVDdlSubject" runat="server" ControlToValidate="DdlSubject"
                    InitialValue="-- Select --" ErrorMessage="Please Select Subject." ValidationGroup="PnlBMS"
                    meta:resourcekey="RFVDdlSubjectResource1">*</asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-25">
                <asp:Label ID="LblChapter" runat="server" Text="Chapter:" meta:resourcekey="LblChapterResource1"></asp:Label>
            </div>
            <div class="col-50">
                <asp:DropDownList ID="ddlChapter" runat="server" Enabled="False" SkinID="DdlWidth150"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged"
                    meta:resourcekey="ddlChapterResource1">
                    <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RFVDdlChapter" runat="server" ControlToValidate="DdlChapter"
                    InitialValue="-- Select --" ErrorMessage="Please Select Chapter." ValidationGroup="PnlBMS"
                    meta:resourcekey="RFVDdlChapterResource1">*</asp:RequiredFieldValidator>
            </div>
            <div id="DivChapterAdd" class="col-25" visible="false" runat="server">
                <asp:TextBox ID="TxtChapterIndex" runat="server" Width="50px" meta:resourcekey="TxtChapterIndexResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqdTxtChapterIndex" runat="server" ControlToValidate="TxtChapterIndex"
                    ErrorMessage="Please Enter Chapter Index." ValidationGroup="ChapterAdd" meta:resourcekey="rqdTxtChapterIndexResource1">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revchapterindex" runat="server" ControlToValidate="TxtChapterIndex"
                    ErrorMessage="Please Enter Number Only" ValidationGroup="ChapterAdd" ValidationExpression="[\d]{1,5}">*</asp:RegularExpressionValidator>
                <asp:TextBox ID="TxtChapterName" runat="server" Width="120px" meta:resourcekey="TxtChapterNameResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqdTxtChapterName" runat="server" ControlToValidate="TxtChapterName"
                    ErrorMessage="Please Enter Chapter Name." ValidationGroup="ChapterAdd" meta:resourcekey="rqdTxtChapterNameResource1">*</asp:RequiredFieldValidator>
                <asp:Button runat="server" ID="BtnChapterAdd" Text="Add" CssClass="gobutton" OnClick="BtnChapterAdd_Click"
                    ValidationGroup="ChapterAdd" meta:resourcekey="BtnChapterAddResource1" />
                <asp:ValidationSummary ID="vsChapterAdd" runat="server" ValidationGroup="ChapterAdd"
                    ShowMessageBox="True" ShowSummary="False" meta:resourcekey="vsChapterAddResource1" />
            </div>
        </div>
        <div class="row">
            <div class="col-25">
                <asp:Label ID="LblTopic" runat="server" Text="Topic:" meta:resourcekey="LblTopicResource1"></asp:Label>
            </div>
            <div class="col-50">
                <asp:DropDownList ID="ddlTopic" runat="server" Enabled="False" SkinID="DdlWidth150"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlTopic_SelectedIndexChanged" meta:resourcekey="ddlTopicResource1">
                    <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource3"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RFVDdlTopic" runat="server" ControlToValidate="DdlTopic"
                    InitialValue="-- Select --" ErrorMessage="Please Select Topic." ValidationGroup="PnlBMS"
                    meta:resourcekey="RFVDdlTopicResource1">*</asp:RequiredFieldValidator>
            </div>
            <div id="DivTopicAdd" runat="server" visible="false" class="col-25">
                <asp:TextBox ID="TxtToipcIndex" runat="server" Width="50px" meta:resourcekey="TxtToipcIndexResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVTxtToipcIndex" runat="server" ControlToValidate="TxtToipcIndex"
                    ErrorMessage="Please Enter Topic Index." ValidationGroup="TopicAdd" meta:resourcekey="RFVTxtToipcIndexResource1">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revTopicindex" runat="server" ControlToValidate="TxtToipcIndex"
                    ErrorMessage="Please Enter Number Only" ValidationGroup="TopicAdd" ValidationExpression="[\d]{1,5}">*</asp:RegularExpressionValidator>
                <asp:TextBox ID="TxtTopicName" runat="server" Width="120px" meta:resourcekey="TxtTopicNameResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqdTxtTopicName" runat="server" ControlToValidate="TxtTopicName"
                    ErrorMessage="Please Enter Topic Name." ValidationGroup="TopicAdd" meta:resourcekey="rqdTxtTopicNameResource1">*</asp:RequiredFieldValidator>
                <asp:Button runat="server" ID="BtnTopicAdd" Text="Add" CssClass="gobutton" OnClick="BtnTopicAdd_Click"
                    ValidationGroup="TopicAdd" meta:resourcekey="BtnTopicAddResource1" />
                <asp:ValidationSummary ID="vsTopicAdd" runat="server" ValidationGroup="TopicAdd"
                    ShowMessageBox="True" ShowSummary="False" meta:resourcekey="vsTopicAddResource1" />
            </div>
        </div>
        <div class="row">
            <div class="col-25">
            </div>
            <div class="col-75" style="float: left !important;">
                <asp:Button ID="BtnGenerate" Text="Generate" runat="server" CssClass="gobutton" ValidationGroup="PnlBMS"
                    OnClick="BtnGenerate_Click" meta:resourcekey="BtnGenerateResource1" />
                <asp:Button ID="btnReset" runat="server" CssClass="gobutton" Text="Reset" CausesValidation="False"
                    OnClick="btnReset_Click" meta:resourcekey="btnResetResource1" />
                <asp:ValidationSummary ID="VSPnlBMS" runat="server" ValidationGroup="PnlBMS" ShowMessageBox="True"
                    ShowSummary="False" meta:resourcekey="VSPnlBMSResource1" />
            </div>
        </div>
    </div>
    <table class="RoundTop InnerTableStyle TableControl" width="90%" cellpadding="0"
        cellspacing="0">
        <tr>
            <td>
                <table class="tblControl1">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="2" align="left">
                            <table>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                        </td>
                    </tr>
                </table>
                <!-- LoaderPart -->
                <asp:Button ID="btnLoader" runat="server" Style="display: none" />
                <asp:Button ID="btnCancel" runat="server" Style="display: none" />
                <cc1:ModalPopupExtender ID="ModalPopup" runat="server" PopupControlID="dvPopup" CancelControlID="btnCancel"
                    TargetControlID="btnLoader" BackgroundCssClass="modalBackground" Enabled="True">
                </cc1:ModalPopupExtender>
                <table id="dvPopup" runat="server" class="loadingtable" cellpadding="0" cellspacing="0">
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
                <!-- LoaderPart -->
                <script type="text/javascript">
                    var prm = Sys.WebForms.PageRequestManager.getInstance();
                    prm.add_beginRequest(BeginRequestHandler);
                    prm.add_endRequest(EndRequestHandler);
                    function BeginRequestHandler(sender, args) {
                        if ($("#<%= btnLoader.ClientID%>") != null) {
                            $("#<%= btnLoader.ClientID%>").click();
                        }
                    }

                    function EndRequestHandler(sender, args) {
                        if ($("#<%= btnCancel.ClientID%>") != null) {
                            $("#<%= btnCancel.ClientID%>").click();
                        }
                    }
                </script>
            </td>
        </tr>
    </table>
</asp:Content>
