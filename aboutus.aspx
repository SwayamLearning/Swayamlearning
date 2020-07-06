<%@ Page Title="" Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true"    CodeFile="aboutus.aspx.cs" Inherits="NewPublic_aboutus" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     
    <style>
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
        body {
     font-family: 'Avenir Next LT Pro';font-size: 14px;
}

        /**for 1200px and above*/
     
    </style>
    <link href="App_Themes/Home/css/aboutus.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid">
        <div class="col-md-12 col-md-offset-2 col-12">
            <div class="jumbotron">
                <h1><asp:Label ID="lblhd1" runat="server" meta:resourcekey="reslblhd1">“Education is an ornament in prosperity and a refuge in adversity”.</asp:Label></h1>
                <p><asp:Label ID="lblhd1p" runat="server" meta:resourcekey="reslblhd1p"> - Aristotle</asp:Label></p>
               <%-- <h3>A platfom with simplified personalised learning videos supporting GSEB,CBSE syllabus in Hindi,Gujarati and English.</h3>
                <p>Curriculum videos,e-books,tests,edutainment videos</p>
                <p><a href="#" class="btn btn-primary btn-lg" role="button">Register for Free</a></p>--%>
            </div>
        </div>
    </div>
    <div class="aboutsection " runat="server">
        <div class="row abouttop1">
               <div class="col-md-8    col-12  d-sm-none d-lg-block about1 ">

                <p class="ml-auto paraclass">
                    <asp:Localize ID="para1" runat="server" meta:resourcekey="litpara1" Text="

               
                   
                   
                    The journey of seeking knowledge has the power to enhance and enlighten any walk of
life. Every child should be given the opportunity to tread on this path and open the
doors to the world of education and learning, irrespective of any barriers. The need of
the hour is to make learning an unstoppable movement and make it reach to the
remotest corners of the country. Swayam Learning is an initiative, our small step ahead,
in this movement.
                
                    "></asp:Localize>
                </p>

            </div>

            <div class="col-md-4   about1img d-sm-none d-lg-block " >
                <img src="App_Themes/Home/Homepagenewimages/Element%201.png" class="img-fluid w-100" />
            </div>

        </div>

        <div class="row abouttop2" >
            <div class="col-md-4 col-sm-3  col-12 d-sm-none d-lg-block">
                <img src="App_Themes/Home/Homepagenewimages/Element%202.png" class="img-fluid"/>
            </div>
            <div class="col-md-8 col-sm-10  col-12 about2 d-sm-none d-lg-block">
                <p class="ml-auto paraclass">
                     <asp:Localize ID="para2" runat="server" meta:resourcekey="litpara2" Text="
                    Swayam Learning is a digital knowledge ecosystem designed for students, teachers and
schools to make learning accessible, easy and convenient. A platform with simplified
personalised learning videos supporting GSEB, CBSE &amp;amp; NCERT syllabus in Hindi,
Gujarati and English languages, Swayam Learning gives users the chance to learn in
their comfortable pace. With curriculum videos, e-Books, e-Tests, audio lectures, e-
Tutorials, edutainment videos, virtual labs, teaching tools, Swayam Learning offers 360
degree learning, teaching and school-management solutions in a user-friendly
environment. 
                          "></asp:Localize>
                </p>
            </div>

        </div>

        <div class="aboutsectionsm d-none  d-sm-block d-md-block d-lg-none">
             <div class="row">
                 <div class="col-md-8 col-sm-8 about111">
                     <p class="ml-auto paraclass">
                         <asp:Localize ID="Localize1" runat="server" meta:resourcekey="litpara11" Text="

               
                   
                   
                    The journey of seeking knowledge has the power to enhance and enlighten any walk of
life. Every child should be given the opportunity to tread on this path and open the
doors to the world of education and learning, irrespective of any barriers.The need of
the 
                
                    "></asp:Localize>
                     </p>
                 </div>
                 <div class="col-md-4 col-sm-4">
                       <img src="App_Themes/Home/Homepagenewimages/Element%201.png" class="img-fluid w-100" />
                 </div>
             </div>
        
             <div class="row">
            <div class="col-md-12 col-sm-12 about121">
                  <p class="ml-auto paraclass">
                    <asp:Localize ID="Localize2" runat="server" meta:resourcekey="litpara12" Text="

               
                   
       hour is to make learning an unstoppable movement and make it reach to the
remotest corners of the country. Swayam Learning is an initiative, our small step ahead,
in this movement.
                
                    "></asp:Localize>
                </p>
            </div>
        </div>

            <div class="row">
                <div class="col-md-4 col-sm-4">
                <img src="App_Themes/Home/Homepagenewimages/Element%202.png" class="img-fluid"/>
            </div>
            <div class="col-md-8 col-sm-8 about211">
                <p class="ml-auto paraclass">
                     <asp:Localize ID="Localize3" runat="server" meta:resourcekey="litpara21" Text="
                    Swayam Learning is a digital knowledge ecosystem designed for students, teachers and
schools to make learning accessible, easy and convenient. A platform with simplified
personalised learning videos supporting GSEB, CBSE &amp;amp; NCERT syllabus in Hindi,

                          "></asp:Localize>
                </p>
            </div>
            </div>
            <div class="row">
                  <div class="col-md-12 col-sm-12 about212">
                   <p class="ml-auto paraclass">
                     <asp:Localize ID="Localize4" runat="server" meta:resourcekey="litpara22" Text="
                    Gujarati and English languages, Swayam Learning gives users the chance to learn in
their comfortable pace. With curriculum videos, e-Books, e-Tests, audio lectures, e-
Tutorials, edutainment videos, virtual labs, teaching tools, Swayam Learning offers 360
degree learning, teaching and school-management solutions in a user-friendly
environment. 
                          "></asp:Localize>
                </p>
                      </div>
            </div>
            </div>
        <div class="row about-bottom2">
            <div class="col-12">
                <p class="ml-auto paraclass">
                      <asp:Localize ID="para3" runat="server" meta:resourcekey="litpara3" Text="
                   Ensuring the principle of ‘Learning on the go, anywhere, anytime’, Swayam Learning is
an attempt to enrich the system of education with a perfect blend of knowledge, fun and
technology. This will set up a new normal of education being uncomplicated, interactive
and engaging, suiting the local requirements and matching the global standards.
                          "></asp:Localize>
                </p>
            </div>
        </div>
        <div class="row about-bottom3">
            <div class="col-12">
                 <h1 class="text-center"><asp:Label ID="lblbotmhd1" runat="server" meta:resourcekey="reslblbothd1">LET EDUCATION BE FOR ONE AND ALL</asp:Label></h1>
                 <h2 class="text-center"><asp:Label ID="lblbotmhd2" runat="server" meta:resourcekey="reslblbothd2">Welcome to Swayam Learning.</asp:Label> </h2>
            </div>
        </div>
    </div>  
</asp:Content>
 