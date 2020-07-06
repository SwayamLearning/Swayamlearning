<%@ Page Title="" Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="contact.aspx.cs" Inherits="NewPublic_contact" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        @font-face {
    font-family: 'Avenir Next LT Pro';
    src: url('App_Themes/Home/Fonts/AvenirNextLTPro-It.woff2') format('woff2'),
        url('App_Themes/Home/Fonts/AvenirNextLTPro-It.woff') format('woff');
    font-weight: normal;
    font-style: italic;
}

@font-face {
    font-family: 'Avenir Next LT Pro';
    src: url('App_Themes/Home/Fonts/AvenirNextLTPro-Regular.woff2') format('woff2'),
        url('App_Themes/Home/Fonts/AvenirNextLTPro-Regular.woff') format('woff');
    font-weight: normal;
    font-style: normal;
}

@font-face {
    font-family: 'Avenir Next LT Pro';
    src: url('App_Themes/Home/Fonts/AvenirNextLTPro-Bold.woff2') format('woff2'),
        url('App_Themes/Home/Fonts/AvenirNextLTPro-Bold.woff') format('woff');
    font-weight: bold;
    font-style: normal;
}
       .contact-section .form-control {
           font-family: 'Avenir Next LT Pro';
            border: 1px solid #2fbfbc;
            border-top: none;
            border-left: none;
            border-right: none;
            box-shadow: none;
            background-color: #f8f8f8;
        }
.contact-section
{
    font-family: 'Avenir Next LT Pro';
    padding-bottom:10px;
    margin-top:80px;
    max-width:100%;
    background-color:white;
    margin-left:auto;
    margin-right:auto;
    padding-left:50px;
    padding-right:50px
}
h2 {
  /*font-family: 'Raleway', sans-serif;*/
    font-family: 'Avenir Next LT Pro';
  font-weight: 900;
  color: #101f1d;
  font-size: 35px;
  letter-spacing: 1.25px;
  margin-top: 0;
}
.contact-fields {
  padding: 40px 0 0;
}
.phone {
  padding-top: 50px;
}
.email a
{
    /*color:#34aec6 !important;*/
    color:#10697b !important
}
.phone,
.email,
.working-hours,
.location {
  margin-bottom:30px;
   
  font-size: 20px;
  color:#10697b;
}
.phone a,
.email a,
.location a {
  color: /*#fd4f00*/#2fbfbc;
  font-size:20px;
}
.contact-h2 {
  color: #fd4f00;
  padding-top:20px;
}
.contact-fields .form-group {
  margin-bottom: 35px;
}
.contact-info {
  /*margin-top: -20px;
  padding-left:100px;*/
}
.contact-fields .form-group input,
.contact-fields .form-group textarea {
  font-size: 16px;
}
.location a.btn.btn-accent {
  padding: 12px 26px 10px;
  margin-top: 30px;
  font-size: 16px;
}
.location a.btn.btn-accent img {
  margin-right: 20px;
}
.location hr {
  margin-bottom: 10px;
}
.btncontact {
  font-size: 15px;
  padding: 22px 46px 18px;
  line-height: 1;
  text-transform: uppercase;
  border: none;
  border-radius: 0;
  position: relative;
  letter-spacing: 0.3px;
}
.btncontact.btn-accent {
    background:#34aec6;
  /*background: #2fbfbc;*/
  color: white;
   font-family: 'Avenir Next LT Pro';
   font-weight:bold;
}
.btn.btn-accent:hover {
  background: #269694;
}
.ct-newsletter-section .container {
  width: 100%;
  max-width: 1360px;
}
.ct-section-head,
.ct-section-header {
  /*font-family: 'Raleway', sans-serif;*/
    font-family: 'Avenir Next LT Pro';
  font-weight: 900;
  color: #101f1d;
  font-size: 35px;
  text-transform: uppercase;
  padding-top: 45px;
  letter-spacing: 1.25px;
  margin-bottom: 5px;
}
.ct-section-header {
  text-align: center;
}
.ct-newsletter-inline {
  display: table;
  width: 100%;
  color: white;
  margin: 69px 0 138px;
  text-align: center;
}
.ct-newsletter-inline__facebook {
  background-color: #3b5997;
}
.ct-newsletter-inline__facebook, .ct-newsletter-inline__twitter {
  width: 16%;
}
a {
  -webkit-transition: all 250ms cubic-bezier(0.55, 0, 0.1, 1);
  transition: all 250ms cubic-bezier(0.55, 0, 0.1, 1);
}
.ct-newsletter-inline__facebook i, .ct-newsletter-inline__twitter i {
  font-size: 109px;
  padding-top: 25px;
}
.ct-newsletter-inline__facebook span, 
.ct-newsletter-inline__twitter span {
  /*font-family: 'Raleway', sans-serif;*/
    font-family: 'Avenir Next LT Pro';
  font-size: 13px;
  text-transform: uppercase;
  font-weight: 600;
  letter-spacing: 4px;
  display: block;
  padding-top: 15px;
}
.ct-newsletter-inline__twitter {
  background-color: #2fc2ee;
}
.ct-newsletter-inline__facebook, 
.ct-newsletter-inline__twitter {
  width: 16%;
  padding-top: 25px;
}
.ct-newsletter-inline__form {
  background-color: #fd4f00;
  padding: 24px;
}
.ct-newsletter-inline__form .ct-newsletter {
  text-align: left;
  width: 100%;
  max-width: 668px;
  margin: 0px auto;
}
.ct-newsletter-inline__form .form-inline {
  display: table;
  width: 100%;
  height: 65px;
}
.ct-newsletter-inline__form .form-inline input {
  width: 50%;
  width: calc(100% - 137px);
  padding: 0 40px;
  font-size: 16px;
  letter-spacing: 0.3px;
  color: #111f1d;
  text-transform: uppercase;
}
.ct-newsletter-inline__form .form-inline input, 
.ct-newsletter-inline__form .form-inline .btn {
  display: table-cell;
  vertical-align: middle;
  height: 65px;
  border: none;
  margin: 0;
}
.ct-newsletter-inline__form .form-inline .btn {
  width: 137px;
  font-family: 'Oswald', sans-serif;
  font-size: 25px;
  padding-left: 0;
  padding-right: 3px;
  text-align: center;
}
.ct-newsletter-inline__form .form-inline input, .ct-newsletter-inline__form .form-inline .btn {
  display: table-cell;
  vertical-align: middle;
  height: 65px;
  border: none;
  margin: 0;
}
input[type="text"]
{
    height:40px !important;
}
.location h2
{
      font-size:20px;
}
.location p
{
    line-height:30px;
}
.email h2 
{
    font-size:20px;
}

.btn.btn-dark {
  background: #111f1d;
  color: white;
}
/*.btncontact {
  font-size: 15px;
  padding: 22px 46px 18px;
  line-height: 1;
  text-transform: uppercase;
  border: none;
  border-radius: 0;
  position: relative;
  letter-spacing: 0.3px;
}*/
       
form input
{
    max-width:525px !important;
}
 form .txtarea
 {
     max-width:100% !important;
 }
 .radio {
    padding: 0px;
}

 input[type="radio"] {
    margin: 8px 11px 13px 13px;
}

.radio > label {
    float: left;
    margin-right: 5px;
    padding: 0px 5px 0px 10px;
}
.containerwidth
{
    max-width:100% !important;
}
    </style>
     <%-- <link href="App_Themes/Home/css/Homepagemediaquery.css" rel="stylesheet" />--%>
    <script type="text/javascript">
        function SubmitQuery() {
            debugger;
            var cultureInfo = '<%= System.Globalization.CultureInfo.CurrentCulture.Name %>';
           // alert(cultureInfo);
            var name = document.getElementById('<%= TxtUserName.ClientID %>').value;
             var email = document.getElementById('<%= TxtUserMail.ClientID %>').value;
            var phone = document.getElementById('<%= txtcontact.ClientID %>').value;
             var comment = document.getElementById('<%= TxtMessage.ClientID %>').value;
            if (name == null || name.trim() == "") {
                if (cultureInfo == 'en-US') {
                    alert('Please enter Name.');
                }
                if (cultureInfo == 'gu-IN')
                {
                    alert("નામ દાખલ કરો");
                }
                if (cultureInfo == 'hi-IN')
                {
                    alert("कृपया नाम दर्ज करें");
                }
                document.getElementById('<%= TxtUserName.ClientID %>').focus();
                return false; // cancel submission
            }
                    
         
            if (email == null || email.trim() == "") {
                if (cultureInfo == 'en-US') {
                    alert('Please enter Email.');
                }
                if (cultureInfo == 'gu-IN') {
                    alert("ઇમેઇલ દાખલ કરો");
                }
                if (cultureInfo == 'hi-IN') {
                    alert("कृपया ईमेल दर्ज करें");
                }
              
                document.getElementById('<%= TxtUserMail.ClientID %>').focus();
                return false; // cancel submission
            }

            //var pattern = /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/;
              var pattern=/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})$/;
                    var isemail = pattern.test(email);
                     if (!isemail) {
                        
                         if (cultureInfo == 'en-US') {
                             alert('Please enter valid Email.');
                         }
                         if (cultureInfo == 'gu-IN') {
                             alert("માન્ય ઇમેઇલ દાખલ કરો");
                         }
                         if (cultureInfo == 'hi-IN') {
                             alert("कृपया वैध ईमेल दर्ज़ करें");
                         }
                         document.getElementById('<%= TxtUserMail.ClientID %>').focus();
                         return false;
                      } 

         
            if (phone == null || phone.trim() == "") {
               
                if (cultureInfo == 'en-US') {
                    alert('Please enter valid Phone no.');
                }
                if (cultureInfo == 'gu-IN') {
                    alert("મોબાઇલ નંબર દાખલ કરો");
                }
                if (cultureInfo == 'hi-IN') {
                    alert("कृपया मान्य मोबाइल दर्ज करें");
                }
                document.getElementById('<%= txtcontact.ClientID %>').focus();
                return false; // cancel submission
            }
            
            var pattern = /^\d{8,12}$/;
            var isphone = pattern.test(phone);
            if (!isphone) {
                if (cultureInfo == 'en-US') {
                    alert('Please enter valid phone Number');
                }
                if (cultureInfo == 'gu-IN') {
                    alert("માન્ય મોબાઇલ નંબર દાખલ કરો");
                }
                if (cultureInfo == 'hi-IN') {
                    alert("कृपया मान्य मोबाइल दर्ज करें");
                }
              
               
                document.getElementById('<%= txtcontact.ClientID %>').focus();
                return false;
            }
           
            if (comment == null || comment.trim() == "") {
                if (cultureInfo == 'en-US') {
                    alert('Please enter Message');
                }
                if (cultureInfo == 'gu-IN') {
                    alert("પ્રશ્ન દાખલ કરો");
                }
                if (cultureInfo == 'hi-IN') {
                    alert("कृपया संदेश दर्ज करें");
                }

            
                document.getElementById('<%= TxtMessage.ClientID %>').focus();
                return false; // cancel submission
            }
             
            return true;
        }

       
        function preventBack() { 
            window.history.forward();  
        } 
          
        setTimeout("preventBack()", 0); 
          
        window.onunload = function () { null }; 
     
    </script>
  
   <%-- <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container containerwidth">
        <div class="contact-section">
            <h2 class="ct-section-head" runat="server" id="hcontact">CONTACT US</h2>
            <div class="row contact-fields">

                <div class="col-md-6 col-lg-4 left-form">
                      <div class="form-group">
                          <label ID="lblusername" runat="server" class="sr-only" for="TxtUserName"  meta:resourcekey="Labelusername">Name *</label>
                          <input    autofocus="false" class="required form-control" id="TxtUserName" name="TxtUserName" placeholder="Name&nbsp;*" type="text" required="required"   runat="server"/>
                       <%-- <asp:Label ID="lblusername" runat="server" Text="Name" meta:resourcekey="Labelusername" CssClass="sr-only" />

                        <asp:TextBox ID="TxtUserName" runat="server" CssClass="form-control" placeholder="Enter Name" meta:resourcekey="Txtusername"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ucreqdUsername" runat="server" ControlToValidate="TxtUserName"
                            ErrorMessage="Please Enter Name." ValidationGroup="uccontact" Display="None" meta:resourcekey="RequiredFieldName"></asp:RequiredFieldValidator>--%>

                    </div>
                </div>
                 <div class="col-md-6 col-lg-4 left-form">
                     <div class="form-group">
                          <label ID="lblschool" runat="server" class="sr-only" for="TxtSchool"  meta:resourcekey="LabelSchoolname">School  </label>
                          <input    autofocus="false" class="required form-control" id="TxtSchool" name="TxtSchool" placeholder="School&nbsp;*" type="text" required="required"   runat="server"/>
                       <%-- <asp:Label ID="lblusername" runat="server" Text="Name" meta:resourcekey="Labelusername" CssClass="sr-only" />

                        <asp:TextBox ID="TxtUserName" runat="server" CssClass="form-control" placeholder="Enter Name" meta:resourcekey="Txtusername"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ucreqdUsername" runat="server" ControlToValidate="TxtUserName"
                            ErrorMessage="Please Enter Name." ValidationGroup="uccontact" Display="None" meta:resourcekey="RequiredFieldName"></asp:RequiredFieldValidator>--%>

                    </div>
                </div>
                 <div class="col-md-12  col-lg-4 left-form">

                      <asp:RadioButtonList ID="rblrole" RepeatDirection="Horizontal" runat="server" CssClass="radio"  >
    <asp:ListItem Text="Student"  selected="True" Value="1" />
    <asp:ListItem Text="Teacher"  Value="2" />
    <asp:ListItem Text="School" Value="3" />
    
</asp:RadioButtonList>
                    <%-- <div class="form-check form-check-inline">
                         <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio1" value="1" checked/>
                         <label class="form-check-label" for="inlineRadio1">Student</label>
                     </div>
                    <div class="form-check form-check-inline">
                       <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio2" value="2"/>
                      <label class="form-check-label" for="inlineRadio2">Teacher</label>
                    </div>
                    <div class="form-check form-check-inline">
                      <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio3" value="3" >
                      <label class="form-check-label" for="inlineRadio3">School  </label>
                    </div>--%>
                      
                </div>
                </div>
                <div class="row contact-fields">

                <div class="col-md-6">
                       <div class="form-group">
                         <label class="sr-only" for="TxtUserMail" ID="lblEmail" runat="server" meta:resourcekey="LabelEmail" >Email *</label>
                         <input class="required form-control h5-email" ID="TxtUserMail" runat="server" name="contactEmail" placeholder="Email&nbsp;*" type="text"  required="required" meta:resourcekey="TxtUserEmail"/>
                        <%--<asp:Label ID="lblEmail" runat="server" Text="Email" meta:resourcekey="LabelEmail" CssClass="sr-only" />--%>
                      <%--  <asp:TextBox ID="TxtUserMail" runat="server" CssClass="form-control  h5-email" placeholder="Enter Email" meta:resourcekey="TxtUserEmail"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ucreqEmail" runat="server" ControlToValidate="TxtUserMail"
                            ErrorMessage="Please Enter Email." ValidationGroup="uccontact" Display="None" meta:resourcekey="RequiredfieldEmail"></asp:RequiredFieldValidator>--%>

                    </div>
                </div>
                 <div class="col-md-6">
                      <div class="form-group">
                          <label runat="server" ID="lblcontact" class="sr-only" for="txtcontact" meta:resourcekey="LabelContact">Phone *</label>
                           <input runat="server" ID="txtcontact" class="required form-control h5-phone"  name="contactPhone" placeholder="Enter Mobile Number&nbsp;*" type="text" required="required" meta:resourcekey="TxtUserContact"/>
                       <%-- <asp:Label ID="lblcontact" runat="server" Text="Mobile Number" meta:resourcekey="LabelContact" CssClass="sr-only" />--%>
                       <%-- <asp:TextBox ID="txtcontact" runat="server" CssClass="form-control h5-phone" placeholder="Enter Mobile Number" meta:resourcekey="TxtUserEmail"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ucreqContact" runat="server" ControlToValidate="txtcontact"
                            ErrorMessage="Please Enter Contact." ValidationGroup="uccontact" Display="None" meta:resourcekey="RequiredfieldContact"></asp:RequiredFieldValidator>--%>

                    </div>
                </div>
                    
                </div>
                 <div class="row contact-fields">

                     <div class="col-md-12 left-form">
                           <div class="form-group">
                           <label ID="lblMessage" runat="server" class="sr-only"  meta:resourcekey="LabelMessage" for="TxtMessage">Type your message here</label>
                           <textarea runat="server" ID="TxtMessage" class="required form-control txtarea"   name="comment" placeholder="Type your message here&nbsp;*" rows="5" cols="60" required="required"/> 
                     <%--   <asp:Label ID="lblMessage" runat="server" Text="Email" meta:resourcekey="LabelMessage" CssClass="sr-only" />--%>
                      <%--  <asp:TextBox ID="TxtMessage" runat="server" TextMode="MultiLine" Height="100" CssClass="form-control" placeholder="Type your Message here"></asp:TextBox>--%>
                       <%-- <asp:RequiredFieldValidator ID="UcreqMessage" runat="server" ControlToValidate="TxtMessage"
                            ErrorMessage="Please Enter Message." ValidationGroup="uccontact" Display="None" meta:resourcekey="RequiredfieldMessage"></asp:RequiredFieldValidator>--%>

                    </div>
                     </div>
                     </div>
            <div class="row contact-fields">
                <div class="col-md-6 left-form">

                    <input id="btnsubmitquery" runat="server" type="button" onclick="if (SubmitQuery() == false) return (false);" onserverclick="btnsubmitquery_Click" class="btncontact btn-accent" value="Send Message" UseSubmitBehavior="false" />

                   
                    </div>
                <div class="col-md-6   contact-info">
                    <%-- <div class="phone">
        <h2>Call</h2>
        <a href="tel:+5555555555">555.555.5555</a>
      </div>--%>
                    <div class="email">
                        <h2 id="Emailtext" runat="server">Email</h2>
                        <a href="mailto:support@swayamlearning.org">support@swayamlearning.org</a>
                    </div>
                   
                </div>

            </div>
                
                
                  

                  

                    <%--   <asp:Button ID="btnsubmitquery" Text="Send Message" Cssclass="btn btn-accent" runat="server"  OnClick="btnsubmitquery_Click" />--%>
                 <%--   <div class="form-group">
                        <asp:ValidationSummary ID="uccontactsummary" runat="server" ValidationGroup="uccontact"
                            CssClass="form-control" meta:resourcekey="ValidationSummary" />
                    </div>--%>

                </div>
                
            </div>
        
</asp:Content>
