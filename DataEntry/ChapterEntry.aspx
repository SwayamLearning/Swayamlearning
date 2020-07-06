<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="true" CodeFile="ChapterEntry.aspx.cs" Inherits="DataEntry_ChapterEntry"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/Jquery1.9.1.js" type="text/javascript"></script>
    <style type="text/css">
        .col-70
        {
            float: left;
            width: 45%;
            margin-top: 6px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" style="margin-top: -50px;">
        <div class="row" style="background: #72abb5; color: White; height: 50px;">
            <div class="col-100">
                <asp:Label ID="LblBMS" runat="server" Text="Upload Chapter Topic Content" meta:resourcekey="LblBMSResource1"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-100">
                <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-25">
                                <asp:Label ID="lblBoard" runat="server" Text="Board:" meta:resourcekey="lblBoardResource1"></asp:Label>
                            </div>
                            <div class="col-70">
                                <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" SkinID="DdlWidth150"
                                    OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged" meta:resourcekey="ddlBoardResource1">
                                </asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="RFVDdlBoard" runat="server" ControlToValidate="DdlBoard"
                                InitialValue="-- Select --" ErrorMessage="Please Select Board." ValidationGroup="PnlBMS"
                                meta:resourcekey="RFVDdlBoardResource1">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="row">
                            <div class="col-25">
                                <asp:Label ID="LblMedium" runat="server" Text="Medium:" meta:resourcekey="LblMediumResource1"></asp:Label>
                            </div>
                            <div class="col-70">
                                <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" SkinID="DdlWidth150"
                                    OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged" Enabled="False" meta:resourcekey="ddlMediumResource1">
                                </asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="RFVDdlMedium" runat="server" ControlToValidate="DdlMedium"
                                InitialValue="-- Select --" ErrorMessage="Please Select Medium." ValidationGroup="PnlBMS"
                                meta:resourcekey="RFVDdlMediumResource1">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="row">
                            <div class="col-25">
                                <asp:Label ID="LblStandard" runat="server" Text="Standard:" meta:resourcekey="LblStandardResource1"></asp:Label>
                            </div>
                            <div class="col-70">
                                <asp:DropDownList ID="ddlStandard" runat="server" AutoPostBack="True" 
                                    OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged" Enabled="False" meta:resourcekey="ddlStandardResource1">
                                </asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="RFVDdlStandard" runat="server" ControlToValidate="DdlStandard"
                                InitialValue="-- Select --" ErrorMessage="Please Select Standard." ValidationGroup="PnlBMS"
                                meta:resourcekey="RFVDdlStandardResource1">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="row">
                            <div class="col-25">
                                <asp:Label ID="LblSubject" runat="server" Text="Subject:" meta:resourcekey="LblSubjectResource1"></asp:Label>
                            </div>
                            <div class="col-70">
                                <asp:DropDownList ID="ddlSubject" runat="server" Enabled="False" SkinID="DdlWidth150"
                                    OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" AutoPostBack="True"
                                    meta:resourcekey="ddlSubjectResource1">
                                    <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="RFVDdlSubject" runat="server" ControlToValidate="DdlSubject"
                                InitialValue="-- Select --" ErrorMessage="Please Select Subject." ValidationGroup="PnlBMS"
                                meta:resourcekey="RFVDdlSubjectResource1">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="row">
                            <div class="col-25">
                                <asp:Label ID="LblChapter" runat="server" Text="Chapter:" meta:resourcekey="LblChapterResource1"></asp:Label>
                            </div>
                            <div class="col-70">
                                <asp:DropDownList ID="ddlChapter" runat="server" Enabled="False" AutoPostBack="True"
                                    SkinID="DdlWidth150" OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged"
                                    meta:resourcekey="ddlChapterResource1">
                                    <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="RFVDdlChapter" runat="server" ControlToValidate="DdlChapter"
                                InitialValue="-- Select --" ErrorMessage="Please Select Chapter." ValidationGroup="PnlBMS"
                                meta:resourcekey="RFVDdlChapterResource1">*</asp:RequiredFieldValidator>
                            <div id="DivChapterAdd" runat="server" visible="false">
                                <asp:TextBox ID="TxtChapterIndex" runat="server" Width="50px" meta:resourcekey="TxtChapterIndexResource1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqdTxtChapterIndex" runat="server" ControlToValidate="TxtChapterIndex"
                                    ErrorMessage="Please Enter Chapter Index." ValidationGroup="ChapterAdd" meta:resourcekey="rqdTxtChapterIndexResource1">*</asp:RequiredFieldValidator>
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
                            <div class="col-70">
                                <asp:DropDownList ID="ddlTopic" runat="server" Enabled="False" AutoPostBack="True"
                                    SkinID="DdlWidth150" OnSelectedIndexChanged="ddlTopic_SelectedIndexChanged" meta:resourcekey="ddlTopicResource1">
                                    <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="RFVDdlTopic" runat="server" ControlToValidate="DdlTopic"
                                InitialValue="-- Select --" ErrorMessage="Please Select Topic." ValidationGroup="PnlBMS"
                                meta:resourcekey="RFVDdlTopicResource1">*</asp:RequiredFieldValidator>
                            <div id="DivTopicAdd" runat="server" visible="false">
                                <asp:TextBox ID="TxtToipcIndex" runat="server" Width="50px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFVTxtToipcIndex" runat="server" ControlToValidate="TxtToipcIndex"
                                    ErrorMessage="Please Enter Topic Index." ValidationGroup="TopicAdd">*</asp:RequiredFieldValidator>
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
                                <asp:Label ID="Label1" runat="server" Text="Type:" meta:resourcekey="Label1Resource1"></asp:Label>
                            </div>
                            <div class="col-70">
                                <asp:DropDownList ID="ddlType" runat="server" Enabled="False" AutoPostBack="True"
                                    SkinID="DdlWidth150" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" meta:resourcekey="ddlTypeResource1">
                                    <asp:ListItem Text="-- Select --" Selected="True" Value="0" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="RFVDdlType" runat="server" ControlToValidate="DdlType"
                                InitialValue="-- Select --" ErrorMessage="Please Select Type." ValidationGroup="PnlBMS"
                                meta:resourcekey="RFVDdlTypeResource1">*</asp:RequiredFieldValidator>
                            <div id="FileTypeDiv" runat="server" visible="false">
                                <asp:TextBox ID="TxtFileType" runat="server" Width="170px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFVTxtFileType" runat="server" ControlToValidate="TxtFileType"
                                    ErrorMessage="Please Enter File Type." ValidationGroup="FileTypeAdd">*</asp:RequiredFieldValidator>
                                <asp:Button runat="server" ID="btnFileTypeAdd" Text="Add" CssClass="gobutton" ValidationGroup="FileTypeAdd"
                                    OnClick="btnFileTypeAdd_Click" />
                                <asp:ValidationSummary ID="VSFileType" runat="server" ValidationGroup="FileTypeAdd"
                                    ShowMessageBox="True" ShowSummary="False" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-25">
                                <asp:Label ID="Label2" runat="server" Text="Upload File:" meta:resourcekey="Label2Resource1"></asp:Label>
                            </div>
                            <div class="col-70">
                                <asp:FileUpload ID="fuChapters" runat="server" Enabled="False" meta:resourcekey="fuChaptersResource1" />
                            </div>
                            <asp:RequiredFieldValidator ID="RFVfuChapters" runat="server" ControlToValidate="fuChapters"
                                ErrorMessage="Please Select File." ValidationGroup="PnlBMS" meta:resourcekey="RFVfuChaptersResource1">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="row">
                            <div class="col-25">
                            </div>
                            <div class="col-70">
                                <asp:Button ID="BtnUpload" Text="Upload File" runat="server" CssClass="gobutton"
                                    ValidationGroup="PnlBMS" OnClick="BtnUpload_Click" meta:resourcekey="BtnUploadResource1" />
                                &nbsp;
                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="gobutton" CausesValidation="False"
                                    OnClick="btnReset_Click" meta:resourcekey="btnResetResource1" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-25">
                            </div>
                            <div class="col-70">
                                <asp:ValidationSummary ID="VSPnlBMS" runat="server" ValidationGroup="PnlBMS" ShowMessageBox="True"
                                    ShowSummary="False" meta:resourcekey="VSPnlBMSResource1" />
                            </div>
                        </div>
                        
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlBoard" />
                        <asp:AsyncPostBackTrigger ControlID="ddlMedium" />
                        <asp:AsyncPostBackTrigger ControlID="ddlStandard" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSubject" />
                        <asp:AsyncPostBackTrigger ControlID="ddlChapter" />
                        <asp:AsyncPostBackTrigger ControlID="ddlTopic" />
                        <asp:AsyncPostBackTrigger ControlID="ddlType" />
                        <asp:PostBackTrigger ControlID="BtnUpload" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
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
</asp:Content>
