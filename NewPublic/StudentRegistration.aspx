<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentRegistration.aspx.cs" Inherits="NewPublic_StudentRegistration" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <%-- <link href="../App_Themes/bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../App_Themes/bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    <script src="../assets/js/core/jquery.min.js" type="text/javascript"></script>
    <link href="..c/App_Themes/Responsive/ss/font-awesome.min.css" rel="stylesheet" />
    <link href="../App_Themes/login.css" rel="stylesheet" />--%>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.12.0/jquery-ui.min.js"></script>

    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>

    <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>



    <link href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" rel="Stylesheet"></link>
    <style>
        body {
            /*background-color: #f6f6ef;*/
        }

        input[type=text], select {
            width: 75%;
            padding: 10px 20px;
            margin: 0px 0;
            display: inline-block;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .bg-color {
            /*background-color:#088081;*/
            background-color: #f6f6ef;
        }

        .center {
            margin: auto;
            margin-top: 100px;
            margin-bottom: 10px;
            width: 80%;
            border: 0px solid #1796a5;
            padding: 5px;
            height: 100vh;
        }

        .RadioButtonWidth label {
            margin-right: 30px;
        }

        .bg-reg {
            background-color: #4c7f7f !important;
        }
    </style>

    <style>
        /*** media queries */
        @media (min-width: 1281px) {
            .regcontainer {
                min-height: 200px;
            }

            .cdbody {
                padding-top: 0.5em !important;
            }

            .logo {
                width: 18%;
                padding-top: 10px;
            }

            .hdet {
                float: left;
                color: #C2822B;
                font-weight: 600;
            }

            .hhome {
                float: right;
            }

            .center {
                margin-top: 5px !important;
            }

            .dropdown {
                height: 3em !important;
                margin-top: 1.6em;
                width: 280px;
            }

            .regheader {
                font-size: 30px;
                font-weight: 550;
            }
        }

        /* 
  ##Device = Laptops, Desktops
  ##Screen = B/w 1025px to 1280px
*/

        @media (min-width: 1025px) and (max-width: 1280px) {
            .regcontainer {
                height: 300px;
            }

            .pageheader {
                height: 221px;
            }

            .cdbody {
                padding-top: 6em !important;
            }

            .logo {
                width: 400px;
                /*padding-top:20px;*/
            }

            .hdet {
                float: left;
                color: #C2822B;
                font-weight: 600;
            }

            .hhome {
                float: right;
                font-weight: 600;
            }

            .center {
                height: 100vh;
                width: 80%;
                margin-top: 10px;
                height: 100vh !important;
            }

            .dropdown {
                height: 3em !important;
                margin-top: 2em;
                /*width:280px*/
            }
        }


        /* 
  ##Device = Tablets, Ipads (portrait)
  ##Screen = B/w 768px to 1024px
*/

        @media (min-width: 768px) and (max-width: 1024px) {

            .cdbody {
                padding-top: 1em !important;
            }

            .logo {
                width: 25%;
                padding-top: 10px;
            }

            .hdet {
                float: left;
                font-size: 20px;
                font-weight: 600;
                color: #C2822B;
            }

            .regheader {
                font-weight: 600;
            }

            .hhome {
                float: right;
                font-size: 18px;
                font-weight: 600;
            }

            .dropdown {
                height: 3em !important;
                margin-top: 2em;
                /*width:280px*/
            }

            .center {
                height: 100vh;
                width: 80%;
                margin-top: 10px;
                height: 100vh !important;
            }
        }

        /* 
  ##Device = Tablets, Ipads (landscape)
  ##Screen = B/w 768px to 1024px
*/

        @media (min-width: 768px) and (max-width: 1024px) and (orientation: landscape) {

            .bg-reg {
                width: 100%;
            }

            .logo {
                width: 60%;
            }
        }
        /* 
  ##Device = Low Resolution Tablets, Mobiles (Landscape)
  ##Screen = B/w 481px to 767px
*/

        @media (min-width: 481px) and (max-width: 767px) {
            .bg-reg {
                width: 100% !important;
                min-height: 100px !important;
            }

            .cdbody {
                padding-top: 1em !important;
            }

            .logo {
                width: 40% !important;
                padding-top: 20px !important;
            }

            .hdet {
                float: left;
                font-size: 15px;
                font-weight: 700;
                color: #C2822B;
            }

            .hhome {
                float: right;
                font-size: 15px;
                font-weight: 700;
            }

            .dropdown {
                height: 2.5em !important;
                margin-top: 0.5em;
                /*margin-bottom:0.1em;*/
                /*width:20em;*/
                width: 85%;
                margin-left: 30px;
            }

            input[type="text"] {
                width: 85% !important;
                margin-left: 30px;
                /*margin-bottom:10px !important;*/
            }

            .lname {
                margin-bottom: 10px !important;
                margin-top: -20px !important;
            }

            .center {
                margin: auto;
                margin-top: 10px;
                margin-bottom: 10px;
                width: 80%;
                border: 0px solid #1796a5;
                padding: 10px;
            }

            .updpnl {
                margin-top: 20px;
                margin-bottom: -10px;
            }

            .submitrow {
                margin: auto;
            }
        }

        /* 
  ##Device = Most of the Smartphones Mobiles (Portrait)
  ##Screen = B/w 320px to 479px
*/

        @media (min-width: 320px) and (max-width: 480px) {

            .bg-reg {
                width: 100% !important;
                min-height: 100px !important;
            }

            .cdbody {
                padding-top: 1em !important;
            }

            .logo {
                width: 100% !important;
                /*padding-top:20px !important;*/
            }

            .hdet {
                float: left;
                font-size: 15px;
                font-weight: 700;
                color: #C2822B;
            }

            .hhome {
                float: right;
                font-size: 15px;
                font-weight: 700;
            }

            .updpnl {
                margin-top: 20px;
                margin-bottom: -10px;
            }

            .dropdown {
                height: 2.5em !important;
                margin-top: 1em;
                margin-left: 10px;
                /*margin-bottom:0.1em;*/
                /*width:20em;*/
                width: 90%;
            }

            input[type="text"] {
                width: 90% !important;
                margin-left: 10px;
                /*margin-bottom:10px !important;*/
            }

            .lname {
                margin-bottom: 10px !important;
                margin-top: -20px !important;
            }

            .center {
                margin: 40px auto;
                /*margin-top:40px;
            margin-bottom:40px;*/
                margin-bottom: 10px;
                width: 80%;
                border: 0px solid #1796a5;
                padding: 10px;
            }

            .regheader {
                font-size: 20px;
                font-weight: bold;
            }

            .submitrow {
                margin: auto;
            }
        }
    </style>
    <script type="text/javascript">
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>

    <script type="text/javascript">
        $(function () {

        });
    </script>
    <script>
        $(document).ready(function () {
            $("#txtusername").keyup(function () {
                UserOrEmailAvailability();

            });
            $("#txtPincode").keyup(function () {
                var myLength = $("#txtPincode").val().length;

                if (myLength > 5) {
                    //Two times call just for bind City without postback or wait
                    CityStateByPincode(0);
                    var cun = 0;
                    while (cun < 3) {
                        CityStateByPincode(1);
                        cun = cun + 1;
                    }
                    //console.log(capitalize_Words($('#hdnState').val()));
                    //$("#ddlStateID option:contains(" + capitalize_Words($('#hdnState').val())+ ")").attr('selected', 'selected');
                    //__doPostBack($("[id*=ddlStateID]")[0].name, "");
                    //$("#ddlCity option:contains(" + capitalize_Words($('#hdnCity').val()) + ")").attr('selected', 'selected');
                }

            });

            //function ajaxCall() {
            //    $.getJSON('https://api.data.gov.in/resource/7eca2fa3-d6f5-444e-b3d6-faa441e35294?api-key=579b464db66ec23bdd000001cdd3946e44ce4aad7209ff7b23ac571b&format=json&offset=0&limit=10&filters[pincode]=' + $("#txtPincode")[0].value + '',
            //        function (data) {
            //            return 
            //                 data.records



            //        });
            //}

            //$('#txtPincode').autocomplete({
            //    source: ajaxCall
            //});
            //$('#txtPincode').autocomplete({
            //    source: function (request, response) {
            //        $.getJSON('https://api.data.gov.in/resource/7eca2fa3-d6f5-444e-b3d6-faa441e35294?api-key=579b464db66ec23bdd000001cdd3946e44ce4aad7209ff7b23ac571b&format=json&offset=0&limit=10&filters[pincode]=382610', function (data) {
            //            response($.map(data.records, function (i) {
            //                return {
            //                    label: i.subdistname,
            //                    value: i.subdistname
            //                };
            //            }));
            //        });
            //    },
            //    minLength: 6,
            //   position: { my : "right top", at: "right bottom" },
            // //   appendTo: '#mypin',
            //    delay: 100
            //});


        });
    </script>



    <script type="text/javascript">

        function capitalize_Words(str) {
            return str.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); });
        }
        function CityStateByPincode(i) { //This function call on text change.             

            var GEOCODING = 'https://api.data.gov.in/resource/7eca2fa3-d6f5-444e-b3d6-faa441e35294?api-key=579b464db66ec23bdd000001cdd3946e44ce4aad7209ff7b23ac571b&format=json&offset=0&limit=10&filters[pincode]=' + $("#txtPincode")[0].value + '';

            $.getJSON(GEOCODING).done(function (location) {
                // console.log(location.records.length);
                //$('#country').html(location.records[0].);
                if (location.records.length > 0) {
                    //console.log(location.records[0]._statename);
                    //console.log(location.records[0].districtname);
                    //console.log(location.records[0].subdistname);
                    //console.log(location.records[0].villagename);
                    if (i == 0) {
                        var statnam = capitalize_Words(location.records[0]._statename);
                        var sel = document.getElementById('ddlStateID');
                        var opts = sel.options;
                        for (var opt, j = 0; opt = opts[j]; j++) {
                            //console.log(opt.text);
                            //console.log(statnam);   
                            if (opt.text == statnam) {
                                //sel.selectedIndex = j;
                                sel.options[j].selected = true;
                                break;
                            }
                        }
                        var citynam1 = capitalize_Words(location.records[0].subdistname);
                        document.getElementById('__EVENTARGUMENT').value = citynam1;
                        __doPostBack($("[id*=ddlStateID]")[0].name, "");
                    }

                    var citynam = capitalize_Words(location.records[0].subdistname);
                 //   document.getElementById('__EVENTARGUMENT').value = citynam;
                    //document.getElementById('btnCityf').click();  

                    //__doPostBack($("[id*=ddlCity]")[0].name, "");

                    var sel1 = document.getElementById('ddlCity');
                    var opts1 = sel1.options;
                    for (var opt1, j1 = 0; opt1 = opts1[j1]; j1++) {
                        //console.log(opt.text);
                        //console.log(citynam);
                        if (opt1.text == citynam) {
                            //sel1.selectedIndex = j1;
                            sel1.options[j1].selected = true;
                            break;
                        }
                    }

                    //$("#ddlCity option:contains(" + capitalize_Words(location.records[0].subdistname) + ")").attr('selected', 'selected');
                    //$("#ddlStateID").find("1").attr("selected", "selected");

                    // 
                    //$('#latitude').html(position.coords.latitude);
                    //$('#longitude').html(position.coords.longitude);
                }
            })



        }

        function UserOrEmailAvailability() { //This function call on text change.             
            $("#loaderIcon").show();
            $.ajax({
                type: "POST",
                url: "StudentRegistration.aspx/CheckEmail", // this for calling the web method function in cs code.  
                data: '{useroremail: "' + $("#txtusername")[0].value + '" }',// user name or email value  
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response);
                }
            });


        }

        // function OnSuccess  
        function OnSuccess(response) {
            var msg = $("#lblStatus")[0];
            switch (response.d) {
                case "true":
                    msg.style.display = "block";
                    msg.style.color = "red";
                    msg.innerHTML = "User Name already exists.";
                    $("#btnsubmit").prop("disabled", true);
                    break;
                case "false":
                    msg.style.display = "block";
                    msg.style.color = "green";
                    msg.innerHTML = "User Name Available";
                    $("#btnsubmit").prop("disabled", false);
                    break;
            }
            $("#loaderIcon").hide();
        }

    </script>
 <%--   <script>
        function __doPostBack(eventTarget, eventArgument) {
            document.Form1.__EVENTTARGET.value = eventTarget;
            document.Form1.__EVENTARGUMENT.value = eventArgument;
            document.Form1.submit();
        }
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
        </asp:ScriptManager>

        <ul id="log"></ul>
        <div class="center">
            <%--Registration py-5 mt-100">--%>
            <div class="row">
                <div class="alert alert-info" runat="server" visible="false" id="dvsuccessmessage">
                    <strong>
                        <asp:Label ID="Labelsuc" Text="Success!" runat="server" meta:resourcekey="Labelsucess"></asp:Label></strong>
                    <%-- <asp:Label ID="Label2" Text="" runat="server" meta:resourcekey="Labelsucess"></asp:Label>--%>

                    <%-- <strong>Success! </strong>You are registered successfully Login Id and Password sent to your registered mobile.--%>
                    <br />
                    <u><a href="UserLogin.aspx" meta:resourcekey="alinkbtologin">Login</a></u>
                </div>
                <%-- style="background: #F0F0F0;">--%>
            </div>
            <div class="row">
                <div class="col-md-12 bg-color text-center">
                    <div class="pageheader">
                        <%-- <div class="card-body">--%>
                        <%-- <img src="img/logo.png" class="logo" style="width: 30%"--/>--%>
                        <img src="../App_Themes/Home/Homepagenewimages/NewLogo.png" class="logo" />

                        <%-- <h2 class="py-3 regheader"><asp:Label ID="Label17" Text="Registration" runat="server" meta:resourcekey="LabelReg"></asp:Label>
                                
                                 </h2>--%>

                        <%--</div>--%>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 py-2 border">
                    <%-- <h4 class="pb-1">Please fill your details</h4>--%>
                    <h4 class="hdet" <%--style="float:left;"--%>>
                        <asp:Label ID="Label1" Text="Please fill your details" runat="server" meta:resourcekey="Labelhdng1"></asp:Label></h4>
                    <h4 class="hhome" <%--style="float:right"--%>><a href="../SwayamDemoHomepage.aspx" style="border-bottom: 1px solid blue;" meta:resourcekey="alinkbtohome">
                        <asp:Label ID="Label3" Text="Home" runat="server" meta:resourcekey="Labelhome"></asp:Label></a></h4>
                    <h4 style="clear: both"></h4>
                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <asp:Label ID="lblname" runat="server" Visible="False" meta:resourcekey="lblnameResource1"></asp:Label><br />
                            <asp:TextBox ID="txtFirstName" runat="server" placeholder="First name" CssClass="form-control" meta:resourcekey="txtFirstNameResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqFieldFirstName" runat="server" ErrorMessage="Enter First Name."
                                ValidationGroup="a" ControlToValidate="txtFirstName" placeholder="First name" meta:resourcekey="ReqFieldFirstNameResource1" Text="*"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label ID="lbllastname" runat="server" Visible="False" meta:resourcekey="lbllastnameResource1"></asp:Label><br />
                            <asp:TextBox ID="txtLastName" runat="server" placeholder="Last name" CssClass="form-control " meta:resourcekey="txtLastNameResource1"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label ID="lblschoolname" runat="server" Visible="False" meta:resourcekey="lblschoolnameResource1"></asp:Label><br />
                            <asp:TextBox ID="txtSchoolname" runat="server" placeholder="School Name" CssClass="form-control " meta:resourcekey="txtSchoolnameResource1"></asp:TextBox>

                        </div>
                    </div>
                    <div class="form-row updpnl">
                        <div class="form-group col-md-4">
                            <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged" CssClass="form-control dropdown" meta:resourcekey="ddlBoardResource1">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="ReqFieldBoard" runat="server" InitialValue="0"
                                ErrorMessage="Select Board." ValidationGroup="a" ControlToValidate="ddlBoard" meta:resourcekey="ReqFieldBoardResource1" Text="*"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-4">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>

                                    <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" Enabled="False" CssClass="form-control dropdown"
                                        OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged" meta:resourcekey="ddlMediumResource1">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ReqFieldMedium" runat="server" InitialValue="0"
                                        ErrorMessage="Select Medium of Education." ValidationGroup="a" ControlToValidate="ddlMedium" meta:resourcekey="ReqFieldMediumResource1" Text="*"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlBoard" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div class="form-group col-md-4">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>


                                    <asp:DropDownList ID="ddlStandard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged"
                                        Enabled="False" CssClass="form-control dropdown" meta:resourcekey="ddlStandardResource1">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ReqFieldStandard" runat="server" InitialValue="0"
                                        ErrorMessage="Select Standard." ValidationGroup="a" ControlToValidate="ddlStandard" meta:resourcekey="ReqFieldStandardResource1" Text="*"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlMedium" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <asp:Label ID="lblPincode" runat="server" Visible="False" meta:resourcekey="lblPincodeResource1"></asp:Label><br />
                            <asp:TextBox ID="txtPincode" runat="server" placeholder="pin code" MaxLength="6" CssClass="form-control " meta:resourcekey="txtPincodeResource1"></asp:TextBox>
                            <asp:HiddenField ID="hdnCity" runat="server" />
                            <asp:HiddenField ID="hdnState" runat="server" />
                        </div>
                        <div class="form-group col-md-4">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control dropdown" meta:resourcekey="ddlCityResource1">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RQFddlCityValidator2" runat="server" ErrorMessage="Please select city"
                                        ValidationGroup="a" ControlToValidate="ddlCity" meta:resourcekey="RQFddlCityResource1">*</asp:RequiredFieldValidator>
                                    <div style="display: none">
                                        <asp:Button ID="btnCity" OnClick="btnCity_Click" runat="server" />
                                    </div>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlStateID" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="btnCity" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div class="form-group col-md-4">


                            <asp:DropDownList ID="ddlStateID" runat="server" CssClass="form-control dropdown" AutoPostBack="true" meta:resourcekey="ddlStateIDResource1" OnSelectedIndexChanged="ddlStateID_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="ReqFieldStateID" runat="server" ErrorMessage="Please select State"
                                ValidationGroup="a" ControlToValidate="ddlStateID" meta:resourcekey="ReqFieldStateIDResource1">*</asp:RequiredFieldValidator>


                        </div>

                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <asp:Label ID="lblemail" runat="server" Visible="False" meta:resourcekey="lblemailResource1"></asp:Label><br />
                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email ID" CssClass="form-control" meta:resourcekey="txtEmailResource1"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="ReqFieldEmailID" runat="server" ErrorMessage="Enter EmailID."
                                ValidationGroup="a" ControlToValidate="txtEmail" meta:resourcekey="ReqFieldEmailIDResource1" Text="*"></asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ID="revEmailID" runat="server" ErrorMessage="Enter valid EmailID."
                                ToolTip="Enter valid EmailID." Text="." ValidationGroup="a" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ControlToValidate="txtEmail" meta:resourcekey="revEmailIDResource1"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label ID="lblmob" runat="server" Visible="False" meta:resourcekey="lblmobResource1"></asp:Label><br />
                            <asp:TextBox ID="txtContactNo" runat="server" MaxLength="10" placeholder="Contact Number" CssClass="form-control" meta:resourcekey="txtContactNoResource1" OnTextChanged="txtContactNo_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqFieldContactNo" runat="server" ErrorMessage="Enter Contact Number."
                                ControlToValidate="txtContactNo" ValidationGroup="a" meta:resourcekey="ReqFieldContactNoResource1" Text="*"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-4">
                            <asp:Label ID="LblOTP" runat="server" Visible="False" meta:resourcekey="lblotpResource1"></asp:Label><br />
                            <asp:Button ID="Btnresendotp" runat="server" CssClass="btn btn-dark submitrow" Visible="false" Text="Resend OTP" OnClick="btnrResendotp_Click" />
                            <asp:TextBox ID="TxtOTP" Visible="false" runat="server" MaxLength="06" placeholder="OTP" CssClass="form-control" meta:resourcekey="txtotpResource1" OnTextChanged="TxtOTP_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter OTP ."
                                ControlToValidate="TxtOTP" ValidationGroup="a" meta:resourcekey="ReqFieldContactNoResource1" Text="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <asp:Label ID="lblUsername" runat="server" Visible="False" meta:resourcekey="lblUsernameResource1"></asp:Label><br />
                            <%-- <asp:Button ID="btnUsername" runat="server" CssClass="btn btn-dark submitrow" visible="false" Text="User name" OnClick="btnusername_Click" />--%>
                            <asp:TextBox ID="txtusername" runat="server" MaxLength="30" placeholder="Username" CssClass="form-control" meta:resourcekey="txtUsernameResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqFieldUsername" runat="server" ErrorMessage="Enter Username."
                                ControlToValidate="txtusername" ValidationGroup="a" meta:resourcekey="ReqFieldUsernameResource1" Text="*"></asp:RequiredFieldValidator>
                            <img src="../App_Themes/Home/assets/loader.gif" id="loaderIcon" style="display: none" />
                            <asp:Label ID="lblStatus" runat="server" meta:resourcekey="lblStatusResource1"></asp:Label>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="col-md-6 form-group">

                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" meta:resourcekey="ValidationSummary1Resource1" ShowSummary="false" ShowMessageBox="True" ValidationGroup="a" DisplayMode="List" />


                        </div>
                    </div>
                    <div class="form-row" style="margin: auto;">
                        <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-danger submitrow" Enabled="false"
                            Text="Sign Up" OnClick="btnSubmit_Click" UseSubmitBehavior="False" data-dismiss="modal" ValidationGroup="a" meta:resourcekey="btnsubmitResource1" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script>
        $(document).ready(function () {
            //When an input with name="YourRadioButtonName" is changed
            $('input[name="rblrole"]').change(function () {
                if ($(this).val() == "Teacher") {
                    $(".subjectlist").css("display", "block");
                }
                else {
                    $(".subjectlist").css("display", "none");
                }
            }
            );
        });
        $("#txtContactNo").keyup(function (e) {
            //    debugger;
            if (this.value.length == this.maxLength) {
                var pattern = /^[6-9]{1}[0-9]{9}$/;
                var mobile = this.value;
                if (pattern.test(mobile)) {
                    //alert("here");
                    //$(this).next('.inputs').focus();
                    $("#TxtOTP").css('display', 'block');
                    $("#TxtOTP").focus();
                    __doPostBack($(this).attr("txtContactNo"), e);
                }
                else {
                    alert("invalid mobile number");
                    return false;
                }

            }
        });
        $("#TxtOTP").keyup(function (e) {
            //   debugger;
            if (this.value.length == this.maxLength) {
                var pattern = /^[0-9]+$/;
                var mobile = this.value;
                if (pattern.test(mobile)) {
                    //   alert("here1");
                    //$(this).next('.inputs').focus();
                    $("#btnsubmit").css('display', 'block');
                    $("#TxtOTP").focus();
                    __doPostBack($(this).attr("TxtOTP"), e);
                }
                else {
                    alert("invalid OTP");
                    return false;
                }

            }
        });
    </script>
</body>
</html>
