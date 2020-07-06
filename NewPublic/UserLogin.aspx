<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="NewPublic_UserLogin" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
     
     <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
      
    <link href="../App_Themes/bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../App_Themes/bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    <script src="../assets/js/core/jquery.min.js" type="text/javascript"></script>
    <link href="../App_Themes/Responsive/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../App_Themes/login.css" rel="stylesheet" />
   
   <style>
       .modal {
  position: fixed !important;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width:600px !important;
  margin-top:20px;
}
        @media (min-width: 481px) and (max-width: 767px)
        {    .modal {
           position: fixed !important;
           top: 50%;
           left: 50%;
           transform: translate(-50%, -50%);
           width: 300px;
           margin-top: 20px;
       }

        }
@media (min-width: 320px) and (max-width: 480px)
{
       .modal {
           position: fixed !important;
           top: 50%;
           left: 50%;
           transform: translate(-50%, -50%);
           width: 80%;
           margin-top: 20px;
       }
       .form-control, .login-btn {
        min-height: 28px;
        border-radius: 1px;
        width:100%;
    }
       #forgot-password
       {
           width:300px !important;
       }
}

   </style>
     <script type="text/javascript"> 
        function preventBack() { 
            window.history.forward();  
        } 
          
        setTimeout("preventBack()", 0); 
          
        window.onunload = function () { null }; 
    </script> 
</head>

    <body>
       
         <div class="container">
             <div class="row">
                  
               
                  <div class="Absolute-center">
                    <div class="col-xs-4 col-xs-offset-4 col-sm-4 col-sm-offset-4">

                       
                         <form runat="server" id="loginform">
                              <h2 style="float:right;margin-top:10px;font-size:15px; font-weight:500;"><a href="../SwayamDemoHomePage.aspx" style="border-bottom: 1px solid blue;"><asp:Label ID="Label7" Text="Home" runat="server" meta:resourcekey="Labelhome"></asp:Label></a></h2>
                              <h2 class="text-center"><img src="../App_Themes/Home/Homepagenewimages/Logonew.png" width="200" /></h2>   
                                <%--<h2 style="float:left;">Login</h2>
                                <h2 style="float:right"><img src="img/logo2.png" width="100" /></h2>
                              <h2 style="clear:both"></h2>--%>

                                <div class="form-group">

                                     <asp:Label ID="Label2" runat="server" text="Email" meta:resourcekey="LabelEmail"></asp:Label>
                                      <asp:TextBox ID="uctxtUserName" runat="server" CssClass="form-control" placeholder="Mobile Number" meta:resourcekey="Txtusername"  ></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="ucrqdUserName" runat="server" ControlToValidate="uctxtUserName"
                                     ErrorMessage="Please Enter Email." ValidationGroup="ucLogin" Display="None" meta:resourcekey="RequiredFieldEmail" ></asp:RequiredFieldValidator>
                                     
                                </div>
                                <div class="form-group">

                                    <asp:Label ID="Label1" runat="server" text="Password" meta:resourcekey="LabelPassword"></asp:Label>
                                    <asp:TextBox ID="uctxtUserPassword" runat="server" TextMode="Password" placeholder="Password" CssClass="form-control" meta:resourcekey="uctxtUserPasswordResource1"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="ucrqdPassword" runat="server" ControlToValidate="uctxtUserPassword" meta:resourcekey="RequiredFieldPassword"
                                        ErrorMessage="Please Enter Password." ValidationGroup="ucLogin" Display="None"></asp:RequiredFieldValidator>


                                </div>
                                <div class="form-group">
                               
                                     <asp:Button ID="ucbtnGo" runat="server" ClientIDMode="Static" Text="Log in" ValidationGroup="ucLogin"
                                            OnClick="btnGo_Click"  CssClass="btn login-btn btn-block" meta:resourcekey="Btnlogin" />
                                
                                 </div > 

                                <div class="clearfix">

                                     <label class="pull-left checkbox-inline" style="padding-top:3px!important;"><asp:CheckBox ID="ucchkRememberMe" runat="server" meta:resourcekey="ucchkRememberMeResource1" /></label>
                                     <%--    <a href="" class="pull-right" id="FP" data-toggle="modal" data_targer="#forgot-password">Forgot Password?</a>--%>
                                     
                                        <button class="btn-link pull-right" id="button1"  runat="server" type="button" data-target="#forgot-password" data-toggle="modal" meta:resourcekey="ucforgotPassword">Forgot Password?</button>

                                </div>
                                 <div class="form-group">

                                    <p>
                                        <asp:ValidationSummary ID="ucvsumTeacherLogin" runat="server" ValidationGroup="ucLogin"
                                            CssClass="Summary" meta:resourcekey="ValidationSummary" />
                                     <p>
                                        <asp:Label ID="ucinvalididpassword" runat="server" ForeColor="Red" meta:resourcekey="LabelinvalidPassword"></asp:Label>
                                    </p>
                                 </div>

                                 <%--<div class="or-seperator"><i>or</i></div>
                                  <div class="form-group">
                                     

                                <asp:Button ID="ucbtnfblogin" runat="server" ClientIDMode="Static" Text="Log in with facebook" ValidationGroup="ucLogin"
                                    OnClick="btnGo_Click" CssClass="btn login-btn btn-block" >
                                    
                                     </asp:Button>--%>
                              
                         </div > 


                              <div class="modal" tabindex="-1" role="dialog" id="forgot-password" aria-labelledby="Forgotpasswordlabel" aria-hidden="true">

                                        <div class="modal-dialog" role="document" <%--style="width:400px;margin:20px;--%>" >

                                            <div class="modal-content" >

                                                <div class="modal-header">
                                                     <button type="button" class="close" aria-label="Close" onclick="CloseModal();"><span aria-hidden="true">&times;</span></button>
                                                    <h4 class="modal-title" id="Forgotpasswordlabel"><span class="glyphicon glyphicon-lock"> 
                                                        <asp:Label ID="Label4" Text="Recover Password!" runat="server" meta:resourcekey="Recoverpassword"></asp:Label></h4>
                                                </div>
                                                <div class="modal-body">
                    

                                                        <div class="form-group">
                                                          
                                                                <asp:Label ID="Label3" runat="server" text="Email" meta:resourcekey="Labelforgotemail"></asp:Label>
                                                               
                                  
                                                                <asp:TextBox ID="uctxtEmail" runat="server" CssClass="form-control input-lg"  meta:resourcekey="txtforgotemail" placeholder="Enter Mobile Number"></asp:TextBox>

                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uctxtEmail"
                                                                    ErrorMessage="Please Enter Mobile Number." ValidationGroup="ucforgot" Display="None" meta:resourcekey="Requiredfieldforgotemail"></asp:RequiredFieldValidator>
                                                            </div>
                                                       
                                                          <asp:Button ID="btnforgot" runat="server" ClientIDMode="Static" Text="Submit" ValidationGroup="ucforgot"
                                                                    OnClick="btnforgot_Click" CssClass="btn  btn-block login-btn" UseSubmitBehavior="False"  meta:resourcekey="btnforgot"/>
                                                      </div>
                                                      
                                                         
                                                            
                                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ucforgot"
                                                                    CssClass="Summary" meta:resourcekey="validationforgot" />
                         
                                                             
                                                        
                    
                                              
                                                <div class="modal-footer">
                                                                     <p><asp:Label ID="Label5" Text="Remember Password?" runat="server" meta:resourcekey="Rememberpassword"></asp:Label><a id="loginModal1" href="UserLogin.aspx">
                                                                         <asp:Label ID="Label6" Text="Login Here!" runat="server" meta:resourcekey="LoginLink"></asp:Label>
                                                                         </a></p>
                                                </div>
                                            </div>

                                        </div>
        
                                    </div>
                      </form>   

                        
                            
                     </div>
                 </div>
                


             </div>
          

    
          


        <script>
            
            function Validemail() {
                
                    var email = document.getElementById("<%=uctxtUserName.ClientID%>");
                    var filter = /^([a-zA-Z0-9_.-])+@(([a-zA-Z0-9-])+.)+([a-zA-Z0-9]{2,4})+$/;
                    if (!filter.test(email.value)) {
                        alert('Please provide a valid email address');
                        email.focus;
                        return false;
                    }
                    return true;
            }
            function CloseModal()
            {
               

                $("#forgot-password").hide();
                $("#loginform").show();
            }
        </script>

        <script>

           
            $(document).ready(function () {
                $("#button1").click(function () {
                   
                    $("#forgot-password").show();
                    //$("#loginform").hide();
                });
            });
        </script>
     
</body>

 
</html>
