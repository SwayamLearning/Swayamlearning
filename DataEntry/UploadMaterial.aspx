<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="UploadMaterial.aspx.cs" Inherits="DataEntry_UploadMaterial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="margin-top: -50px;">
    <div class="row" style="background: #72abb5; color: White; height: 50px;">
        <div class="col-100">
            <asp:Label ID="LblBMS" runat="server" Text="Upload Content" meta:resourcekey="LblBMSResource1"></asp:Label>
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
        <div class="col-75">
            <asp:DropDownList ID="ddlChapter" runat="server" Enabled="False" SkinID="DdlWidth150"
                AutoPostBack="True" OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged"
                meta:resourcekey="ddlChapterResource1">
                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource2"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RFVDdlChapter" runat="server" ControlToValidate="DdlChapter"
                InitialValue="-- Select --" ErrorMessage="Please Select Chapter." ValidationGroup="PnlBMS"
                meta:resourcekey="RFVDdlChapterResource1">*</asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-25">
            <asp:Label ID="LblTopic" runat="server" Text="Topic:" meta:resourcekey="LblTopicResource1"></asp:Label>
        </div>
        <div class="col-75">
            <asp:DropDownList ID="ddlTopic" runat="server" Enabled="False" SkinID="DdlWidth150"
                meta:resourcekey="ddlTopicResource1">
                <asp:ListItem Text="-- Select --" meta:resourcekey="ListItemResource3"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RFVDdlTopic" runat="server" ControlToValidate="DdlTopic"
                InitialValue="-- Select --" ErrorMessage="Please Select Topic." ValidationGroup="PnlBMS"
                meta:resourcekey="RFVDdlTopicResource1">*</asp:RequiredFieldValidator>
        </div>

    </div>
      
    <div class="row">
        <div class="col-25">
            <asp:Label ID="Label1" runat="server" Text="Content type" meta:resourcekey="lblBoardResource1"></asp:Label>
        </div>
        <div class="col-75">
            <asp:DropDownList ID="ddlContent" runat="server" AutoPostBack="True" meta:resourcekey="ddlContenttype1">
                <asp:ListItem Value="0" Text="Please Select"></asp:ListItem>
                <asp:ListItem Value="1" Text="Video-1"></asp:ListItem>
                <asp:ListItem Value="2" Text="Video-2"></asp:ListItem>
                <asp:ListItem Value="3" Text="Video-3"></asp:ListItem>
                <asp:ListItem Value="4" Text="WorkSheet Level 1"></asp:ListItem>
                <asp:ListItem Value="5" Text="WorkSheet Level 2"></asp:ListItem>
                <asp:ListItem Value="6" Text="WorkSheet Level 3"></asp:ListItem>
                <asp:ListItem Value="7" Text="LessonPlan"></asp:ListItem>
                <asp:ListItem Value="8" Text="TextBook"></asp:ListItem>
                <asp:ListItem Value="9" Text="Supplementary material"></asp:ListItem>

            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlContent"
                InitialValue="-- Select --" ErrorMessage="Please Select Contenttype." ValidationGroup="PnlBMS"
                meta:resourcekey="RFVDdlContentResource1">*</asp:RequiredFieldValidator>
        </div>
    </div>
            <div class="row">
        <div class="col-25">
            <asp:Label ID="Label3" runat="server" Text="Package type" meta:resourcekey="lblBoardResource1"></asp:Label>
        </div>
        <div class="col-75">
            <asp:DropDownList ID="ddlpackage" runat="server" AutoPostBack="True" meta:resourcekey="ddlContenttype1">
                <asp:ListItem Value="0" Text="Demo package"></asp:ListItem>
                <asp:ListItem Value="1" Text="Free package"></asp:ListItem>
                <asp:ListItem Value="2" Text="Paid package"></asp:ListItem>
                 

            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlpackage"
                InitialValue="-- Select --" ErrorMessage="Please Select Contenttype." ValidationGroup="PnlBMS"
                meta:resourcekey="RFVDdlContentResource1">*</asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
       
        <div class="col-25">
            <asp:Label ID="Label2" runat="server" Text="File Upload" meta:resourcekey="lblBoardResource1"></asp:Label>
        </div>
        <div class="col-25">
              <asp:FileUpload ID="FileUpload1"   runat="server" />
        </div>
       
         <div class="col-15">
             <asp:RadioButtonList ID="rblhost" RepeatDirection="Horizontal" runat="server" CssClass="radio"  >
    <asp:ListItem Text="Vimeo"  selected="True" Value="1" />
    <asp:ListItem Text="Local"  Value="2" />
   
    
</asp:RadioButtonList>

             
        </div>
         <div class="col-25">
              <asp:TextBox ID="txtvimeourl" runat="server" Visible="false" placeholder="vimeourl"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-25">
             <asp:Button ID="Button1" CssClass="btn btn-outline-secondary" runat="server" Text="Upload" OnClick="btnUpload_Click" />
        </div>
        <div class="col-25">
             <asp:Button ID="Button2" CssClass="btn btn-outline-secondary" runat="server" Text="Upload URL" OnClick="btnUploadurl_Click" />
        </div>
    </div>
    <div class="row">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
        </div>
   <script>
       $(document).ready(function () {
           debugger;
            var radioChecked;
            radioChecked = $("#<%=rblhost.ClientID%> input:checked").val();
            if (radioChecked == "1") {
                  $('#<%= txtvimeourl.ClientID%>').show();
            } else {
                 $('#<%= txtvimeourl.ClientID%>').hide();
            }
            $('#<%=rblhost.ClientID%>').change(function () {
                radioChecked = $("input[type='radio']:checked").val()
                if (radioChecked == "1") {
                    $('#<%= txtvimeourl.ClientID%>').show();
                } else {
                    $('#<%= txtvimeourl.ClientID%>').hide();
                }
            });
        });
   </script>         
   
                 
</asp:Content>

