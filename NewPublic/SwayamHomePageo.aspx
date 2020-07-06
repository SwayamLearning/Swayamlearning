<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/SwayamMaster.master"
    AutoEventWireup="true" CodeFile="SwayamHomePage.aspx.cs" Inherits="NewPublic_SwayamHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%-- <section class="courses hidden-xs hidden-sm" style="min-height: 0px;">
        
            <div id="advertise" style="width:100%;background-color:#f1f1f1;min-height:70px;">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12" style="text-align:center;margin-top:20px;">
                            <h3 style="margin-top:0px;font-weight:bold;color:#066EE2;font-family: 'Lato', sans-serif;">Anytime Anywhere Interactive classes <a class="btns btn-1">Explore Now</a></h3>
                        </div>
                    </div>
                </div>
            </div>
        
</section>--%>
    <section class="GSEB hidden-xs" id="gsebg">
        <div class="row">
            <div class="col-xs-4 coursesection">
                <p >GSEB - Gujarati</p>
            </div>
            <div class="col-xs-8 standard">
                <ul>
                    <li class="col-xs-2"  style="padding-top:15px !important;"><a style="cursor:pointer !important" href="../Dashboard/StudentDashboard.aspx?Class=1">Class1</a></li>
                    <li class="col-xs-2"  style="padding-top:15px !important;"><a style="cursor:pointer !important" href="../Dashboard/StudentDashboard.aspx?Class=2">Class2</a></li>
                    <li class="col-xs-2"  style="padding-top:15px !important;"><a style="cursor:pointer !important" href="../Dashboard/StudentDashboard.aspx?Class=3">Class3</a></li>
                    <li class="col-xs-2"  style="padding-top:15px !important;"><a style="cursor:pointer !important" href="../Dashboard/StudentDashboard.aspx?Class=4">Class4</a></li>
                    <li class="col-xs-2"  style="padding-top:15px !important;"><a style="cursor:pointer !important" href="../Dashboard/StudentDashboard.aspx?Class=5">Class5</a></li>
                </ul>
                <ul>
                    
                    <li class="col-xs-2"  style="padding-top:15px !important;"><a style="cursor:pointer !important" href="../Dashboard/StudentDashboard.aspx?Class=6">Class6</a></li>
                    <li class="col-xs-2"  style="padding-top:15px !important;"><a style="cursor:pointer !important" href="../Dashboard/StudentDashboard.aspx?Class=7">Class7</a></li>
                    <li class="col-xs-2"  style="padding-top:15px !important;"><a style="cursor:pointer !important" href="../Dashboard/StudentDashboard.aspx?Class=8">Class8</a></li>
                    <li class="col-xs-2"  style="padding-top:15px !important;"><a style="cursor:pointer !important" href="../DemoPages/Game.html">Games</a></li>
                     <li class="col-xs-2"  style="padding-top:15px !important;"><a style="cursor:pointer !important" href="#">Stories</a></li>

                </ul>
                
            </div>
        </div>
        <hr />
    </section>
   <%-- <section class="NCERT-Hindi hidden-xs" id="ncerth">
        <div class="row">
            <div class="col-xs-4 coursesection">
                <p>NCERT - Hindi</p>
            </div>
            <div class="col-xs-8 standard">

                <ul>
                    <li class="col-xs-3"><a href="#">Class1</a></li>
                    <li class="col-xs-3"><a href="#">Class2</a></li>
                    <li class="col-xs-3"><a href="#">Class3</a></li>
                    <li class="col-xs-3"><a href="#">Class4</a></li>

                </ul>
                <ul>
                    <li class="col-xs-3"><a href="#">Class5</a></li>
                    <li class="col-xs-3"><a href="#">Class6</a></li>
                    <li class="col-xs-3"><a href="#">Class7</a></li>
                    <li class="col-xs-3"><a href="#">Class8</a></li>

                </ul>
                <ul>
                    <li class="col-xs-3"><a href="#">Class9</a></li>
                    <li class="col-xs-3"><a href="#">Class10</a></li>
                    <li class="col-xs-3"><a href="#">Class11</a></li>
                    <li class="col-xs-3"><a href="#">Class12</a></li>

                </ul>

            </div>
        </div>
        <hr/>
    </section>
    <section class="NCERT-English hidden-xs" id="ncerte">

        <div class="row">
            <div class="col-xs-4 coursesection">
                <p>NCERT - English</p>
            </div>
            <div class="col-xs-8 standard">

                <ul>
                    <li class="col-xs-3"><a href="#">Class1</a></li>
                    <li class="col-xs-3"><a href="#">Class2</a></li>
                    <li class="col-xs-3"><a href="#">Class3</a></li>
                    <li class="col-xs-3"><a href="#">Class4</a></li>

                </ul>
                <ul>
                    <li class="col-xs-3"><a href="#">Class5</a></li>
                    <li class="col-xs-3"><a href="#">Class6</a></li>
                    <li class="col-xs-3"><a href="#">Class7</a></li>
                    <li class="col-xs-3"><a href="#">Class8</a></li>

                </ul>
                <ul>
                    <li class="col-xs-3"><a href="#">Class9</a></li>
                    <li class="col-xs-3"><a href="#">Class10</a></li>
                    <li class="col-xs-3"><a href="#">Class11</a></li>
                    <li class="col-xs-3"><a href="#">Class12</a></li>

                </ul>

            </div>
        </div>
        <hr />
    </section>--%>
    <section id="Panelformobile" class="hidden-sm hidden-md hidden-lg" style="margin-top: 10px;">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-heading clickable">
                            <h3 class="panel-title" style="text-align:center;">
                               GSEB - Gujarati
                            </h3>
                            <span class="pull-right "><i class="glyphicon glyphicon-minus"></i></span>
                        </div>
                        <div class="panel-body">
                            <ul style="list-style:none; padding-left:10px;">
                                <li class="col-xs-3"><a href="#">Class5</a></li>
                                <li class="col-xs-3"><a href="#">Class6</a></li>
                                <li class="col-xs-3"><a href="#">Class7</a></li>
                                <li class="col-xs-3"><a href="#">Class8</a></li>
                            </ul>
                           
                            <ul style="list-style:none;padding-left:10px;">

                                <li class="col-xs-3"><a href="#">Class9</a></li>
                                <li class="col-xs-3"><a href="#">Class10</a></li>


                            </ul>
</div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-default" >
                        <div class="panel-heading clickable">
                            <h3 class="panel-title" style="text-align:center;">
                               NCERT - Hindi
                            </h3>
                            <span class="pull-right "><i class="glyphicon glyphicon-minus"></i></span>
                        </div>
                        <div class="panel-body">
                            <ul style="list-style:none; padding-left:10px;">
                                <li class="col-xs-3"><a href="#">Class1</a></li>
                                <li class="col-xs-3"><a href="#">Class2</a></li>
                                <li class="col-xs-3"><a href="#">Class3</a></li>
                                <li class="col-xs-3"><a href="#">Class4</a></li>

                            </ul>
                            <ul style="list-style:none; padding-left:10px;">
                                <li class="col-xs-3"><a href="#">Class5</a></li>
                                <li class="col-xs-3"><a href="#">Class6</a></li>
                                <li class="col-xs-3"><a href="#">Class7</a></li>
                                <li class="col-xs-3"><a href="#">Class8</a></li>

                            </ul>
                            <ul style="list-style:none; padding-left:10px;">
                                <li class="col-xs-3"><a href="#">Class9</a></li>
                                <li class="col-xs-3"><a href="#">Class10</a></li>
                                <li class="col-xs-3"><a href="#">Class11</a></li>
                                <li class="col-xs-3"><a href="#">Class12</a></li>

                            </ul>                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-default" >
                        <div class="panel-heading clickable">
                            <h3 class="panel-title" style="text-align:center;">
                                NCERT - English
                            </h3>
                            <span class="pull-right "><i class="glyphicon glyphicon-minus"></i></span>
                        </div>
                        <div class="panel-body">
                            <ul style="list-style:none; padding-left:10px;">
                                <li class="col-xs-3" style="color:black;"><a href="#">Class1</a></li>
                                <li class="col-xs-3"><a href="#">Class2</a></li>
                                <li class="col-xs-3"><a href="#">Class3</a></li>
                                <li class="col-xs-3"><a href="#">Class4</a></li>

                            </ul>
                            <ul style="list-style:none; padding-left:10px;">
                                <li class="col-xs-3"><a href="#">Class5</a></li>
                                <li class="col-xs-3"><a href="#">Class6</a></li>
                                <li class="col-xs-3"><a href="#">Class7</a></li>
                                <li class="col-xs-3"><a href="#">Class8</a></li>

                            </ul>
                            <ul style="list-style:none; padding-left:10px;">
                                <li class="col-xs-3"><a href="#">Class9</a></li>
                                <li class="col-xs-3"><a href="#">Class10</a></li>
                                <li class="col-xs-3"><a href="#">Class11</a></li>
                                <li class="col-xs-3"><a href="#">Class12</a></li>

                            </ul>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </section>
    
</asp:Content>
