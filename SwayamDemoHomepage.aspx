<%@ Page Title="" Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="SwayamDemoHomepage.aspx.cs" Inherits="SwayamDemoHomepage"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .fit-image{
                background-color: white;
    /*object-position: center;
    object-fit: cover;*/
    width: 100%;
    max-height:100%;
    /*height: 100%;*/
/*width: 100%;
object-fit: cover;*/
 
}
        #All
        {
            margin-top:50px !important;
            overflow:hidden;
            padding-bottom:0px;
          
        }
        .bordertop
        {
            margin-top:10px;
            padding:20px 20px;
            border-top:1px solid silver;
        }
        /*.fixed-btn {
            position: fixed;
            top: 200px;
            left: 102px;
            height: 100px;
            z-index: 999;
        }
        .btnfixed{
            width:141px;
            height:150px;
            padding:10px;
            /*border-radius:20px;
            background-color:#ffd69a; 
            color:#17476E;
            font-size:20px;
            font-weight:bold;
            font-family: 'Avenir Next LT Pro' !important;
            background-image:url('App_Themes/Home/Homepagenewimages/demo%20button.png');

        }*/
    </style>
       <link href="App_Themes/Home/css/Popupstylesheet.css" rel="stylesheet" />
    <%--<link href="App_Themes/Home/css/banner1.css" rel="stylesheet" />--%>
    <script>
        

         
        window.onload = function() {
         
              var cultureInfo = '<%= System.Globalization.CultureInfo.CurrentCulture.Name %>';
           // alert(cultureInfo);
            var desktopbanner = document.getElementById('DesktopBanner1');
            var mobilebanner = document.getElementById('MobileBanner1')
            if (cultureInfo == 'en-US') {
                desktopbanner.style.backgroundImage = "url(App_Themes/Home/Homepagenewimages/Banner1_English_Desktop.jpg)";
                mobilebanner.style.backgroundImage = "url(App_Themes/Home/Homepagenewimages/Banner1_English_Mobile.jpg)";
            }
            if (cultureInfo == 'gu-IN')
            {
                desktopbanner.style.backgroundImage = "url(App_Themes/Home/Homepagenewimages/Banner1_Gujarati_Desktop.jpg)";
                mobilebanner.style.backgroundImage = "url(App_Themes/Home/Homepagenewimages/Banner1_Gujarati_Mobile.jpg)";
            }
            if (cultureInfo == 'hi-IN') {
                desktopbanner.style.backgroundImage = "url(App_Themes/Home/Homepagenewimages/Banner1_Hindi_Desktop.jpg)";
                mobilebanner.style.backgroundImage = "url(App_Themes/Home/Homepagenewimages/Banner1_Hindi_Mobile.jpg)";
            }
             
        };
        
            
         
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="container">
    <div id="All">
         
      <section id="DesktopBanner1" class="d-none d-md-block">
             
                <div class="fixed-btn">
                <a href="https://www.youtube.com/channel/UCHGi2kA_8BqeGg_Uf1cjrQQ" class="btnfixed" id="link1">
                     <img src="App_Themes/Home/Homepagenewimages/demo button.png" id="demo" style="border:0" />
             </a>
                
            </div>
        <div class="container-fluid" style="position:relative">

             <div class="overlay"></div>
            <div class="inner">
        
                <p class="lead">
            <a class="btn  btn-lg btnlead shadow-none " href="NewPublic/StudentRegistration.aspx" role="button"> </a>
        </p>
                <p class="teacher">
                     <a class="btn btn-lg shadow-none btnteacher" href="contact.aspx" role="button"> </a>

                </p>
                <p class="dschool">
                     <a class="btn  btn-lg  shadow-none btnschool" href="contact.aspx" role="button"> </a>

                </p>
           <%-- <div class="row">
                <div class="col-12 d1">--%>
                     
                    <%-- <div class="img-overlay">
                     
                         <button class="btn btn-md btn-success">Button</button>
                 </div>--%>
               <%-- </div>
                   
            </div>
           --%>
          
        </div>
         </div>
    </section> 
      <section id="MobileBanner1" class="d-block d-md-none">
           <div class="fixed-btn">
                <a href="https://drive.google.com/drive/folders/18kRCi8Ba2s9hnGQ-EdgHGPAOy3fjZPqX?usp=sharing" class="btnfixed" id="link1">
                     <img src="App_Themes/Home/Homepagenewimages/demo button.png" id="demo1" style="border:0" />
             </a>
                
            </div>
        <div class="container-fluid">
            <%--<div class="row">
                <div class="col-12">
                    <img src="App_Themes/Home/Homepagenewimages/Banner1_English_Mobile.jpg" class="fit-image" width="500" runat="server" id="imgmobile1" />
                </div>
                 
            </div>--%>
             <div class="overlay"></div>
            <div class="inner">
        
                <p class="mlead">
            <a class="btn  btn-lg shadow-none mbtnlead " href="NewPublic/StudentRegistration.aspx" role="button"></a>
        </p>
                <p class="mteacher">
                     <a class="btn  btn-lg shadow-none mbtnteacher" href="contact.aspx" role="button"></a>

                </p>
                <p class="mschool">
                     <a class="btn  btn-lg shadow-none mbtnschool" href="contact.aspx" role="button"></a>

                </p>
           <%-- <div class="row">
                <div class="col-12 d1">--%>
                     
                    <%-- <div class="img-overlay">
                     
                         <button class="btn btn-md btn-success">Button</button>
                 </div>--%>
               <%-- </div>
                   
            </div>
           --%>
          
        </div>
        </div>
    </section> 
      <section id="Banner2" class="bordertop">
         <div class="container-fluid">
             <div class="row studentrow">
                 <div class="col-md-6 col-12 " <%--style="background-color:yellow;"--%>>
                     <img src="App_Themes/Home/Homepageimages/Banner2/1.png" class="img-fluid fit-image banner2img img1"/>
                 </div>
                  <div class="col-md-6 col-12 student" <%--style="background-color:blue;"--%>>
                      <h1 class="righth1 banner2h1"> <asp:Label ID="lblbanner21" Text="PERSONALIZED LEARNING FOR STUDENTS" runat="server" meta:resourcekey="labelbanner2h1"/> 
                          </h1>
                     <%-- <h1 class="righth1">FOR STUDENTS </h1>--%>
                           <ul class="d-none d-md-block">
                                <li>
                                  
                                     <asp:Label ID="Lblbanner22" Text="e-Books" runat="server" meta:resourcekey="labelbanner2li1"/>
                                   <%--  e-Books --%>
                                     <img src="App_Themes/Home/Homepageimages/Banner2/Icon%201.png" width="30" />
                                </li>
                                <li>
                                    <asp:Label ID="Lblbanner23" Text="Curriculum Videos" runat="server" meta:resourcekey="labelbanner2li2"/>
                                    <%-- Curriculum Videos --%>
                                     <img src="App_Themes/Home/Homepageimages/Banner2/Icon%202.png" width="30" />
                                    
                                </li>
                                <li>
                                    <asp:Label ID="Lblbanner24" Text="Self Evaluation Tests" runat="server" meta:resourcekey="labelbanner2li3"/>
                                    <%-- Self Evaluation Tests --%>
                                     <img src="App_Themes/Home/Homepageimages/Banner2/Icon%203.png" width="30" />
                                   
                                </li>
                                <li>
                                     <asp:Label ID="Lblbanner25" Text="e-Tutorials " runat="server" meta:resourcekey="labelbanner2li4"/>
                                     <%--e-Tutorials --%>
                                     <img src="App_Themes/Home/Homepageimages/Banner2/Icon%204.png" width="30" />
                                   
                                </li>
                                <li>
                                     <asp:Label ID="Lblbanner26" Text="Edutainment Videos" runat="server" meta:resourcekey="labelbanner2li5"/>
                                     
                                     <img src="App_Themes/Home/Homepageimages/Banner2/Icon%205.png" width="30" />
                                    
                                </li>
                            </ul>
                              <ul class="d-block d-md-none">
                                <li>
                                     <img src="App_Themes/Home/Homepageimages/Banner2/Icon%201.png" width="30" />
                                  <%--   <asp:Label id="lblbook" runat="server" Text="e-Books"></asp:Label>--%>
                                      <asp:Literal ID="lblbook" runat="server" meta:resourcekey="lablbook" Text="e-Books"></asp:Literal>
                                    
                                    
                                </li>
                                <li>
                                     <img src="App_Themes/Home/Homepageimages/Banner2/Icon%202.png" width="30" />
                                    
                                      <asp:Literal ID="lblcurr" runat="server" meta:resourcekey="lablcurr" Text="Curriculum Videos "></asp:Literal>
                                    
                                    
                                    
                                </li>
                                <li>
                                      <img src="App_Themes/Home/Homepageimages/Banner2/Icon%203.png" width="30" />
                                    
                                        <asp:Literal ID="lblself" runat="server" meta:resourcekey="lablself" Text="Self Evaluation Tests"></asp:Literal>
                                    
                                   
                                </li>
                                <li>
                                     <img src="App_Themes/Home/Homepageimages/Banner2/Icon%204.png" width="30" />
                                       
                                       <asp:Literal ID="lbletut" runat="server" meta:resourcekey="labletut" Text="e-Tutorials "></asp:Literal>
                                                                 
                                   
                                </li>
                                <li>
                                     <img src="App_Themes/Home/Homepageimages/Banner2/Icon%205.png" width="30" />
                                    
                                       <asp:Literal ID="lbledutain" runat="server" meta:resourcekey="labledutain" Text="Edutainment Videos"></asp:Literal>
                                    
                                    
                                    
                                </li>
                            </ul>
                       <div class="btnwrapper">
                     <asp:Button CssClass="btn  btn-class btn-class-right" runat="server" Text="Register for Free" OnClientClick="return redirectSignUp('student')" meta:resourcekey="btnregstu" />
                        </div>
                    
                 </div>
             </div>
         </div>
     </section>
      <section id="Banner3" class="bordertop">
             <div class="container-fluid">
                 <div class="row studentrow">
                       <div class="col-md-6  teacher order-sm-2 order-2 order-md-1"<%-- style="background-color:lightblue;"--%>>
                          <h1 class="righth1 teacherh1"><asp:Label ID="Label1" Text="TEACHING TOOLS FOR TEACHERS" runat="server" meta:resourcekey="labelbanner3h1"/>
                              </h1>
                           <ul>
                                <li>
                                     <img src="App_Themes/Home/Homepageimages/Banner3/Icon%201.png" width="30" />
                                      <asp:Literal ID="ltrvideo" runat="server" meta:resourcekey="labelvideo" Text=" Video Lessons"></asp:Literal>
                                    
                                    
                                </li>
                                <li>
                                      <img src="App_Themes/Home/Homepageimages/Banner3/Icon%202.png" width="30" />
                                     <asp:Literal ID="ltrchap" runat="server" meta:resourcekey="labelchap" Text="Chapter-wise tests"></asp:Literal>
                                    
                                   
                                    
                                </li>
                                <li>
                                      
                                     <img src="App_Themes/Home/Homepageimages/Banner3/Icon%203.png" width="30" />
                                        <asp:Literal ID="ltrlquest" runat="server"  meta:resourcekey="labelqpap" Text="Question Papers"></asp:Literal>
                                    
                                </li>
                                <li>
                                     
                                     <img src="App_Themes/Home/Homepageimages/Banner3/Icon%204.png" width="30" />
                                     <asp:Literal ID="ltrletut" runat="server"  meta:resourcekey="labeletut" Text="e-Tutorials"></asp:Literal>
                                    
                                </li>
                                
                            </ul>
                            <div class="btnwrapper">
                              <asp:Button CssClass="btn  btn-class btn-class-left" runat="server" Text="Get in touch" OnClientClick="return redirecttocontact()" meta:resourcekey="btnget"/>
                                </div>
                     </div>
                     <div class="col-md-6 float-right order-1 order-sm-1 order-md-2" <%--style="background-color:burlywood;"--%> >
                         <img src="App_Themes/Home/Homepageimages/Banner3/2.png" class="img-fluid fit-image banner2img img2" />
                    
                     </div>
                
                 </div>
             </div>
         </section>
      <section id="Banner4" class="bordertop">
             <div class="container-fluid">
                 <div class="row studentrow">
                     <div class="col-md-6 float-right" <%--style="background-color:greenyellow;"--%>>
                         <img src="App_Themes/Home/Homepageimages/Banner4/2.png" class="img-fluid fit-image banner2img img3" />
                     </div>
                      <div class="col-md-6 school" <%--style="background-color:limegreen;"--%>>
                          <h1 class="righth1 banner4h1"><asp:Label ID="Label2" Text="ALL-IN-ONE SCHOOL MANAGEMENT WITH E-PATHSHALA" runat="server" meta:resourcekey="labelbanner4h1"/></h1>
                          
                           <ul class="d-none d-md-block">
                                <li>
                                    <asp:Literal ID="Literalbn41" runat="server" meta:resourcekey="litbn41" Text="Online collaboration with students &amp; teachers"></asp:Literal>
                                   <%--  Online collaboration with students & teachers--%>
                                     <img src="App_Themes/Home/Homepageimages/Banner4/Icon%201.png" width="30" />
                                </li>
                                <li>
                                     <asp:Literal ID="Literalbn42" runat="server"  meta:resourcekey="litbn42" Text="Simplified learning Videos "></asp:Literal>
                                  <%--   Simplified learning Videos --%>
                                     <img src="App_Themes/Home/Homepageimages/Banner4/Icon%202.png" width="30" />
                                    
                                </li>
                                <li>
                                     <asp:Literal ID="Literalbn43" runat="server"  meta:resourcekey="litbn43" Text=" Tutorials &amp; tests"></asp:Literal>
                                   <%--  Tutorials & tests--%>
                                     <img src="App_Themes/Home/Homepageimages/Banner4/Icon%203.png" width="30" />
                                   
                                </li>
                                <li>
                                     <asp:Literal ID="Literalbn44" runat="server"  meta:resourcekey="litbn44" Text="Progress Reports"></asp:Literal>
                               <%--     Progress Reports--%>
                                     <img src="App_Themes/Home/Homepageimages/Banner4/Icon%204.png" width="30" />
                                   
                                </li>
                                  <asp:Button CssClass="btn btn-class btn-class-right" runat="server" Text="Request for a demo" OnClientClick="return redirecttocontact()" meta:resourcekey="btndemo1"/>
                            </ul>
                           <ul class="d-block d-md-none">
                                <li>
                                    
                                    
                                     <img src="App_Themes/Home/Homepageimages/Banner4/Icon%201.png" width="30" />
                                        <asp:Literal ID="ltrschool1" runat="server"  meta:resourcekey="litbn45" Text="Online collaboration with students &amp; teachers"></asp:Literal>
                                </li>
                                <li>
                                     
                                     <img src="App_Themes/Home/Homepageimages/Banner4/Icon%202.png" width="30" />
                                    <asp:literal ID="ltrschool2" runat="server" meta:resourcekey="litbn46">Simplified learning Videos </asp:literal>
                                    
                                </li>
                                <li>
                                    
                                     <img src="App_Themes/Home/Homepageimages/Banner4/Icon%203.png" width="30" />
                                       <asp:Literal ID="ltrschool3" runat="server" meta:resourcekey="litbn47" Text=" Tutorials &amp; tests"></asp:Literal>
                                </li>
                                <li>
                                    
                                     <img src="App_Themes/Home/Homepageimages/Banner4/Icon%204.png" width="30" />
                                     <asp:Literal ID="ltrschool4" runat="server" meta:resourcekey="litbn48" Text="Progress Reports"></asp:Literal>
                                   
                                </li>
                                  
                                <div class="btnwrapper">
                                  <asp:Button CssClass="btn btn-class btn-class-right" runat="server" Text="Request for a demo" OnClientClick="return redirecttocontact()" meta:resourcekey="btndemo2" />
                              </div>
                                 </ul>
                     </div>
                 </div>
             </div>
         </section>
    </div>
    </div>

    <%-- <div id="openModal" class="modalDialog">
        <div>
            <div class="container">
                <div class="row">
                    <div class="col-12 nopadding">
                        <a href="#close" title="Close" class="close">X</a>
                        <img src="App_Themes/Home/Homepagenewimages/Popupimage.jpg" class="img-fluid imgreg" />

                    </div>
                </div>
            </div>


        </div>
    </div>--%>

</asp:Content>

