<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/materialMaster.master" AutoEventWireup="true" CodeFile="StudentDashboardSwaAcademy.aspx.cs" Inherits="Dashboard_StudentDashboardSwaAcademy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../App_Themes/Green/masonry.pkgd.min.js" type="text/javascript"></script>
    <style type="text/css">
        .circle-text {
            color: #71AF32;
            margin-top: -5px;
            font-weight: bold;
        }

        .circle-info-half {
            color: #FFFFFF;
        }

        .tblDashboard tr td {
            vertical-align: top;
            text-align: left;
            padding: 3px;
        }

        .tblDashboard .Header {
            color: #096B6B;
            text-align: center;
            padding: 5px;
            margin: 25px;
        }

        .tblDashboard .LeftPart {
            padding-right: 15px;
        }

        .Width300 {
            min-width: 300px;
            max-width: 300px;
        }

        .Width700 {
            min-width: 700px;
            max-width: 700px;
        }

        .Width1000px {
            min-width: 1000px;
            max-width: 1000px;
            max-height: 700px;
        }

        .MarginBottom15px {
            margin-bottom: 15px;
        }

        .RBPadding {
            width: 100%; /*display: block;*/
            margin: auto;
        }

            .RBPadding input[type="radio"] {
                margin: 3px;
            }

        #lblChapter {
            float: left !important;
        }

        #lblTopic {
            float: left !important;
        }

        .chapterlist .Node a {
            pointer-events: none;
            cursor: default;
        }

        .mrtp10 {
            margin-top: 10px !important;
        }

        .mrtp15 {
            margin-top: 15px !important;
        }

        .loading {
            -moz-border-bottom-colors: none;
            -moz-border-left-colors: none;
            -moz-border-right-colors: none;
            -moz-border-top-colors: none;
            animation: 500ms linear 0s normal none infinite running nprogress-spinner;
            border-color: #71af32 #225244 #225244 #71af32;
            border-image: none;
            border-radius: 50%;
            border-style: solid;
            border-width: 6px;
            box-sizing: border-box;
            content: " ";
            height: 60px;
            width: 60px;
            display: inline-block;
        }

        @keyframes nprogress-spinner {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
        }

        .Covered {
            color: #71af32;
        }

        .UnCovered {
            color: #fff;
        }
    </style>
    <style type="text/css">
        .treeView {
            -moz-user-select: none;
            position: relative;
        }

            .treeView ul {
                margin: 0 0 0 -1.5em;
                padding: 0 0 0 1.5em;
            }

                .treeView ul ul {
                    background: rgba(0, 0, 0, 0) url("../App_Themes/Green/tree/list-item-contents.png") repeat-y scroll left center;
                }

            .treeView li.lastChild > ul {
                background-image: none;
            }

            .treeView li {
                /*background: rgba(0, 0, 0, 0) url("../App_Themes/Green/js/list-item-root.png") no-repeat scroll left top;*/
                cursor: pointer;
                list-style-image: url("../App_Themes/Green/tree/button.png");
                list-style-position: inside;
                margin: 0;
                padding: 5px;
            }

                .treeView li.collapsibleListOpen {
                    cursor: pointer;
                    list-style-image: url("../App_Themes/Green/tree/button-open.png");
                }

                .treeView li.collapsibleListClosed {
                    cursor: pointer;
                    list-style-image: url("../App_Themes/Green/tree/button-closed.png");
                }

                .treeView li li {
                    background-image: url("../App_Themes/Green/tree/list-item.png");
                    padding-left: 1.5em;
                    background-repeat: repeat-y;
                }

                .treeView li.lastChild {
                    background-image: url("../App_Themes/Green/tree/list-item-last.png");
                    background-repeat: no-repeat;
                }
        /*Progress bar start*/

        #container {
            text-align: center;
            margin: 0 5px 0;
        }

            #container a {
                font-weight: bold;
                color: #71af32;
            }

        .bar-main-container {
            margin: 10px 0px 0px 0px;
            width: 100%;
            display: inline-block;
            font-family: sans-serif;
            font-weight: normal;
            font-size: 0.8em;
            color: #71af32;
            border: 1px solid #2e8e6e;
        }

        .wrap {
        }

        .bar-percentage {
            float: left;
            background: #263434;
            padding: 10px 0px;
            width: 25%;
            white-space: nowrap;
            display: inline-block;
            font-weight: bold;
        }

        .bar-container {
            float: right;
            height: 10px;
            background: #225244;
            width: 73%;
            margin: 12px 0px;
            overflow: hidden;
            margin-right: 0.5%;
            margin-left: 0.5%;
            display: inline-block; /*-moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            -khtml-border-radius: 4px;
            border-radius: 4px;*/
        }

        .bar {
            float: left;
            background: #71af32;
            height: 100%;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=100)";
            filter: alpha(opacity=100);
            -moz-opacity: 1;
            -khtml-opacity: 1;
            opacity: 1; /*-moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            -khtml-border-radius: 4px;
            border-radius: 4px;*/
        }

        /* COLORS */
        .prback {
            background: rgba(0, 0, 0, 0) url("../App_Themes/Green/Images/green-bg.jpg") repeat scroll 0 0;
        }

        @media (max-width: 650px) {
            .bar-percentage {
                width: 100%;
            }

            .bar-container {
                width: 92%;
                margin-right: 10px;
            }
        }
        /*progress bar end*/
    </style>
    <style type="text/css">
        .form-control2 {
            background-color: #314B3C !important;
            border: 1px solid #273D2F !important;
            border-radius: 0px !important;
            box-shadow: 0 1px 1px rgba(0, 0, 0, 0.075) inset !important;
            color: #f9f9f9 !important;
            display: block !important;
            font-size: 14px !important;
            height: 60px !important;
            line-height: 1.42857 !important;
            padding: 6px 12px !important;
            transition: border-color 0.15s ease-in-out 0s, box-shadow 0.15s ease-in-out 0s !important;
            vertical-align: middle !important;
            width: 100% !important;
        }

        .input-sm2 {
            border-radius: 0 !important;
            font-size: 12px !important;
            height: 60px !important;
            line-height: 1.5 !important;
            padding: 5px 10px !important;
            width: 100% !important;
        }

        .form-control2:focus {
            border-color: #48a02b !important;
            outline: 0 !important;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075), 0 0 8px rgba(40, 225, 189, 0.6) !important;
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075), 0 0 8px rgba(40, 225, 189, 0.6) !important;
        }

        .form-inline .form-control2 {
            display: inline-block !important;
        }

        .GridViewItemForRes td {
            padding: 6px;
        }

        .hoversubscribe {
            background: rgba(0, 0, 0, 0) url("../App_Themes/Green/Images/watermarknone.png") repeat scroll 0 0 / 100% auto;
        }

            .hoversubscribe:hover {
                background: rgba(0, 0, 0, 0) url("../App_Themes/Green/Images/watermark.png") repeat scroll 0 0 / 100% auto;
            }

        .ActivityHeadingNormal {
            background-color: #263434;
            color: #71af32;
            font-size: 1em;
            padding: 10px;
            text-transform: uppercase;
        }
    </style>
    <style type="text/css">
        .Star {
            background-image: url(../Images/Star.gif);
            height: 17px;
            width: 17px;
        }

        .WaitingStar {
            background-image: url(../Images/WaitingStar.gif);
            height: 17px;
            width: 17px;
        }

        .FilledStar {
            background-image: url(../Images/FilledStar.gif);
            height: 17px;
            width: 17px;
        }
    </style>
    <style type="text/css">
        .rating {
            overflow: hidden;
            display: inline-block; /*font-size: 0; */
            position: relative;
        }

        .rating-input {
            float: right;
            width: 16px;
            height: 16px;
            padding: 0;
            margin: 0 0 0 -16px;
            opacity: 0;
        }

            .rating:hover .rating-star:hover, .rating:hover .rating-star:hover ~ .rating-star, .rating-input:checked ~ .rating-star {
                background-position: 0 0;
            }

        .rating-star, .rating:hover .rating-star {
            position: relative;
            float: right;
            display: block;
            width: 16px;
            height: 16px;
            background: url('../Images/star.png') 0 -16px;
        }

        textarea {
            resize: none !important;
        }
    </style>
    <link href="../App_Themes/GreenDashboard.css" rel="stylesheet" type="text/css" />


    <%--  <script src="../App_Themes/Green/CircularChart/js/jquery.circliful.min.js" type="text/javascript"></script>--%>
    <%--<script type="text/javascript" src="../App_Themes/Green/tree/CollapsibleLists.compressed.js"></script>--%>

    <%--Styles for Chapter List card--%>
    <style>
        h4 button {
            width: 100% !important;
            font-size: 125% !important;
        }

        #chapterCard .card {
            margin: 5px 0px !important;
        }

        #chapterCard .card-header {
            padding-bottom: 0px;
            cursor: pointer;
            padding-left: 50px;
        }

        /*To devide header and body part*/
        #chapterCard .card-body {
            border-top: 1px solid silver;
        }

        /*for Plus sign on right side of header*/
        #chapterCard .card-header:before {
            font-family: 'FontAwesome';
            content: "\f068";
            float: left;
            margin-left: -25px;
            color: silver;
        }
        /*for Minus sign on right side of header*/
        #chapterCard .card-header.collapsed:before {
            /* symbol for "collapsed" panels */
            content: "\f067";
        }

        .CoveredChapter {
            margin-top: -50px;
            color: green;
        }
    </style>

    <script src="../assets/js/core/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">


        function showChapters(show) {

            var chapters = document.getElementById("chapters");
            var noChapters = document.getElementById("noChapters");
            var subjectContainer = document.getElementById("subjectContainer");

            var subjectHeader = document.getElementById("subjectHeader");

            document.getElementById("txtSearch").value = "";

            chapters.removeAttribute("class");
            noChapters.removeAttribute("class");
            subjectContainer.removeAttribute("class");

            if (show == true) {
                chapters.setAttribute("class", "container-fluid");
                noChapters.setAttribute("class", "container-fluid d-none");
                subjectContainer.setAttribute("class", "container-fluid d-none");
                
            } else {
                subjectHeader.innerHTML = "";
                chapters.setAttribute("class", "container-fluid  d-none");
                noChapters.setAttribute("class", "container-fluid");
                subjectContainer.setAttribute("class", "container-fluid");
            }

        }

        function onSubjectClicked(subjectID, subject) {

            //var subjectList = document.getElementById("subjectList");
            //subjectList.setAttribute("class", "active");

            //window.location.href = "DisplayPage.aspx";
            //PageMethods.navigateToChapters('', onSubjectClicked_success);
            
            showLoader();
            var subjectHeader = document.getElementById("subjectHeader");
            subjectHeader.innerHTML = subject;
            PageMethods.SubjectSelection(subjectID, subject, onSubjectSelectionSuccess, onFailed);

           
        }

        function onSubjectSelectionSuccess(response, userContext, methodName) {
            ////alert(response);
            var chapterCard = document.getElementById("chapterCard");
            

             

            
            
            if (response == "") {
                showChapters(false);
            } else {
                showChapters(true);
            }
            chapterCard.innerHTML = response;
            // alert(response);
            hideLoader();
        }

        function onFailed(){
            hideLoader();
        }

        function onSubjectClicked_success(response, userContext, methodName) {
            if (response == "Navigate") {
                window.location.href = "Chapters.aspx";
            }
        }


        function ShowCurrentTime() {
            PageMethods.GetCurrentTime(document.getElementById("<%=txtUserName.ClientID%>").value, OnSuccess);
        }

        function OnSuccess(response, userContext, methodName) {
        }




        function ShowContent(fname, ext, res, id) {

           <%--if ($("#<%= btnShow.ClientID%>") != null) {
                $("#<%= btnShow.ClientID%>").click();
                document.getElementById('<%= LblDisplay.ClientID %>').innerHTML = document.getElementById('<%= hdnTopicName.ClientID %>').value;--%>

            var modalTitle = document.getElementById("modal-title");
            modalTitle.innerHTML = $('#' + "chapter" + id).text();

            var modalBody = document.getElementById("modal-body");
            if (ext == ".mp4") {
                modalTitle.innerHTML += " - (Animation)"
                modalBody.innerHTML = "<video style=\"margin:auto;\" id=\"myVideo\" width='65%' preload controls autoplay><source type='video/mp4' codecs='avc1.42E01E, mp4a.40.2' src='" + res + "' ></video>";
                var vid = document.getElementById("myVideo");
                //vid.onplaying = function () {
                //    alert("The video is now playing");
                //};
                //vid.onabort = function () {
                //    alert("The video ended");
                //}
                //vid.onpause = function () {
                //    alert("The video paused");
                //}
                vid.onended = function () {
                    $('#modal-body').html('');
                    jQuery("#myModal").modal("hide");

                    //Log the resource into database for student.
                    PageMethods.log_StudentWiseCoveredSyllabus(fname, id);

                    //document.querySelectorAll('[property]'); // All with attribute named "property"
                    
                    var btns = document.querySelectorAll('[data-bmssctID="' + id + '"]'); // All with "property" set to "value" exactly.
                    btns.forEach(function (element) {
                        try {
                            element.removeAttribute("disabled");
                        } catch (ex) { };

                    });
                }
                var elem = document.getElementById("myVideo");
                if (elem.requestFullscreen) {
                    elem.requestFullscreen();
                } else if (elem.mozRequestFullScreen) {
                    elem.mozRequestFullScreen();
                } else if (elem.webkitRequestFullscreen) {
                    elem.webkitRequestFullscreen();
                } else if (elem.msRequestFullscreen) {
                    elem.msRequestFullscreen();
                }
            } else if (ext == ".pdf") {
                modalTitle.innerHTML += " - (MCQ/Worksheet)"
                var pdfurl = window.location.href.replace("Dashboard/StudentDashboard.aspx", "") + res.replace("../", ""); modalBody.innerHTML = "<iframe id='myframe' width='100%' height='100%' src=\"http://docs.google.com/gview?url=" + pdfurl + "&embedded=true\" allowfullscreen='true'></iframe>";
            } else if (ext == ".Test") {
                modalTitle.innerHTML += " - (Quiz)"
                var testurl = res + "&BMSSCTID=" + id;
                modalBody.innerHTML = "<iframe id='myframe' width='100%' height='100%' src='" + testurl + "' allowfullscreen='true'></iframe>";
            } else {
                modalBody.innerHTML = "<iframe id='myframe' width='100%' height='100%' src='" + testurl + "' allowfullscreen='true'></iframe>";
            }
            PlayedContent(fname, res);
            //}
            return false;
        }

        //log played content
        function PlayedContent(fname, res) {
            showLoader();
            PageMethods.LogResourceAccess(fname, res, Success, Failure);
            function Success(result) {
                hideLoader();
            }
            function Failure(error) {
                hideLoader();
            }
        }

        $(document).ready(function () {
            $('#myModal').on('hidden.bs.modal', function () {
                $('#modal-body').html('');
            })
        });
    </script>
    <%-- <script src="../assets/MDB%20Free/js/modules/chart.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.js"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--Following code demonstrate to call  serverside methods from client side--%>
    <div style="visibility: hidden; display: none;">
        Your Name :
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <input id="btnGetTime" type="button" value="Show Current Time" onclick="ShowCurrentTime()" />
    </div>

    <%--Display Subject List Dynamically--%>
    <div id="subjectContainer" class="container-fluid">
        <div class="row">
            <style>
                .coverage {
                    background-color: #F3F3F3;
                    min-height: 5px;
                    max-height: 5px;
                    width: 100%;
                    position: relative;
                    clear: both;
                }

                    .coverage .covered {
                        position: absolute;
                        top: 0px;
                        left: 0px;
                        z-index: 500;
                        background-color: green !important;
                        min-height: 5px;
                        max-height: 5px;
                    }

                .checked {
                    color: silver;
                }

                .card-footer {
                    border-top: none !important;
                }
            </style>

            <% foreach (System.Data.DataRow dr in dtSubjects.Rows)
                {
                    var subject = dr["Subject"];
                    var subjectID = dr["SubjectID"];
                    var covered = dr["Covered"];
                    var notCovered = dr["NotCovered"];
                    var Colour = dr["Colour"];
            %>


            <div class="col-12 col-sm-6 col-md-4" style="cursor: pointer">
                <script type="text/javascript">
                    var subjectID = <%: subjectID %>;
                    //$.ajax({
                    //    type: "POST",
                    //    url: "StudentDashboard.aspx/GetPerformanceChartdata",
                    //    data: JSON.stringify({'subjectid': subjectID}),
                    //    contentType: "application/json; charset=utf-8",
                    //    dataType: "json",
                    //    success: OnSuccess_,
                    //    error: OnErrorCall_
                    //});

                    <%--function OnSuccess_(reponse) {
  
                        var aData = reponse.d;
                        var aLabels = aData[0];
                        var aDatasets1 = aData[1];
                        
                        var chartOptions = {
                            responsive: true,
                            title: {
                                display: true,
                                position: "top",
                                text: "Performance Graph",
                                fontSize: 18,
                                fontColor: "#111"
                            },
                            scales: {
                                yAxes: [{
                                    ticks: {
                                        max: 100,
                                        min: 0,
                                        stepSize: 20
                                    }
                                }]
                            },
                        };


                        var data = {
                            labels: aLabels,
                            datasets: [{
                                label: "Chapter test performance",
                                fill: false,
                                borderColor: "lightblue",
                                backgroundColor: "blue",
                                fill: false,
                                lineTension: 0,
                                radius: 5,

                                data: aDatasets1
                            }]
                        };


                        var ctx = $("#myChart-<%: subjectID %>").get(0).getContext('2d');
                        //alert(ctx);
                        ctx.canvas.height = 350;  // setting height of canvas
                        ctx.canvas.width = 500; // setting width of canvas
                        //var lineChart = new Chart(ctx).Line(data, { bezierCurve: false });
                        var myNewChart = new Chart(ctx, { type: "line", data: data, options: chartOptions });

                        //lineChart.render();

                        var ctx1 = $("#myExpandedChart-<%: subjectID %>").get(0).getContext('2d');
                        //alert(ctx);
                        ctx1.canvas.height = 250;  // setting height of canvas
                        ctx1.canvas.width = 500; // setting width of canvas
                        //var lineChart = new Chart(ctx).Line(data, { bezierCurve: false });
                        var myNewExpChart = new Chart(ctx1, { type: "line", data: data, options: chartOptions });

                    }
                    function OnErrorCall_(repo) {
                        alert("Woops something went wrong, pls try later !");
                    }--%>

                </script>
                <div class="card card-chart" style="cursor: default">
                    <div class="card-header text text-center" style="padding: 0px !important; min-height: 151px; max-height: 151px; cursor: default;">

                        <%--<div class="container h-151" style="background-color: white; color: black; border-top: 10px solid <%: Colour %>; border-bottom: 10px solid <%: Colour %>;">--%>
                        <div class="container h-151" style="background: linear-gradient(to right, <%: Colour %>); color: white;">
                            <div class="row align-items-center h-151" style="height: 151px;">

                                <div class="col-12 mx-auto">

                                    <h3>
                                        <strong>
                                            <%: subject %>
                                        </strong>
                                    </h3>

                                    <button type="button" class="btn btn-link" onclick="onSubjectClicked(<%: subjectID %>, '<%: subject %>' )">
                                        <i class="fa fa-youtube-play" aria-hidden="true" style="font-size: 4em;"></i>
                                    </button>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-body my-3">

                        <%--<h6 class="card-title text-center">--%>
                        <%--<button type="button" class="btn" style="background-color: #1B9CE5" onclick="onSubjectClicked(<%: subjectID %>, '<%: subject %>' )"><%: subject %></button>--%>
                        <%--</h6>--%>
                        <div class="coverage" style="clear: both;">
                            <div class="covered" style="width: <%: covered %>% !important"></div>
                        </div>
                        <div class="text text-left">
                            <%: covered %>% Complete.
                        </div>
                        <%-- <div class="text text-right" style="margin-top: -25px;">
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                        </div>--%>
                    </div>
                    <div class="card-footer">

                        <div class="stats" style="visibility: hidden; display: none;">
                            <i class="material-icons">access_time</i> updated 4 minutes ago
                 
                        </div>
                        <div class="text text-right" style="margin-top: -25px;">
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                        </div>

                        <%-- <canvas id="myChart-<%: subjectID %>" data-toggle="modal" data-target="#expandedChart-<%: subjectID %>"></canvas>
                        <i class="fa fa-search-plus pull-right" data-toggle="modal" data-target="#expandedChart-<%: subjectID %>" aria-hidden="true" style="position:absolute; right:25px; top:281px; cursor:pointer"></i>--%>
                    </div>
                </div>
            </div>

            <style>
                .chartModal {
                    width: 50%;
                    height: 75%;
                    left: 25%;
                    top: 8%;
                }
            </style>
            <!-- Chart Modal (Expanded)-->
            <div class="modal chartModal" id="expandedChart-<%: subjectID %>">
                <div class="modal-dialog ">
                    <div class="modal-content">

                        <!-- Modal Header -->
                        <div class="modal-header">
                            <h4 class="modal-title">

                                <strong>
                                    <%: subject %>
                                </strong>

                            </h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body" id="expandedChartBody">
                            <canvas id="myExpandedChart-<%: subjectID %>"></canvas>
                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer" style="visibility: hidden; display: none;">
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        </div>

                    </div>
                </div>
            </div>

            <%--Open modal popup on mouse hover--%>
            <%--<script type="text/javascript">
                $(document).ready(function() {
                    $( "#myChart-<%: subjectID %>" ).hover(function() {
                        $('#expandedChart-<%: subjectID %>').modal({
                            show: true
                        });
                    });
                });
            </script>--%>


            <% } //foreach %>
        </div>
    </div>






    <%--  <script>
        //line
         
        alert("chart");
        var label;
    
        
        var ctxL = document.getElementById("myChart").getContext('2d');


        var myLineChart = new Chart(ctxL, {
            type: 'line',
            data: {
                labels: ['ch1', 'ch2'],
                datasets: [
                    {
                        label: "My First dataset",
                        fillColor: "rgba(220,220,220,0.2)",
                        strokeColor: "rgba(220,220,220,1)",
                        pointColor: "rgba(220,220,220,1)",
                        pointStrokeColor: "#fff",
                        pointHighlightFill: "#fff",
                        pointHighlightStroke: "rgba(220,220,220,1)",
                        data: [10, 20]
                    }],
            },
            options: {
                responsive: true
            }


        });
         
         
    </script>--%>

    <script>

        //function getChartData() {

        //    alert("here");
        //    $.ajax({
        //        type: "POST",
        //        url: "StudentDashboard.aspx/GetPerformanceChartdata",
        //        data: '',
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: OnSuccess_,
        //        error: OnErrorCall_
        //    });

        //}

        $(document).ready(function () {




        });


    </script>
    <style>
        .card-header-background {
            background-color: #6C757D;
        }
    </style>
    <div class="row" style="visibility: hidden; display: none;">
        <div class="col-md-4">
            <div class="card card-chart">
                <%-- <div class="card-header card-header-success">--%>
                <div class="card-header card-header-background">
                    <div class="ct-chart" id="dailySalesChart"></div>
                </div>
                <div class="card-body">
                    <h4 class="card-title">Daily Sales</h4>
                    <p class="card-category">
                        <span class="text-success"><i class="fa fa-long-arrow-up"></i>55% </span>increase in today sales.
                    </p>
                </div>
                <div class="card-footer bg-danger">
                    <div class="stats">
                        <i class="material-icons">access_time</i> updated 4 minutes ago
                 
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card card-chart">
                <div class="card-header card-header-warning">
                    <div class="ct-chart" id="websiteViewsChart"></div>
                </div>
                <div class="card-body">
                    <h4 class="card-title">Email Subscriptions</h4>
                    <p class="card-category">Last Campaign Performance</p>
                </div>
                <div class="card-footer">
                    <div class="stats">
                        <i class="material-icons">access_time</i> campaign sent 2 days ago
                 
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card card-chart">
                <div class="card-header card-header-danger">
                    <div class="ct-chart" id="completedTasksChart"></div>
                </div>
                <div class="card-body">
                    <h4 class="card-title">Completed Tasks</h4>
                    <p class="card-category">Last Campaign Performance</p>
                </div>
                <div class="card-footer">
                    <div class="stats">
                        <i class="material-icons">access_time</i> campaign sent 2 days ago
                 
                    </div>
                </div>
            </div>
        </div>
    </div>


    <%--No content message if no content found--%>
    <div id="noChapters" class="container-fluid d-none">
        <div class="row">
            <div class="col-12">
                <h3 class="text-danger">Oops! No chapters available.
                </h3>
            </div>

        </div>
    </div>


    <%--Chapter list will be generated dynamically here--%>
    <div id="chapters" class="container-fluid d-none">

        <%--Search--%>
        <div class="row">
            <div class="col-8">
                <div class="input-group form-group">
                    <input id="txtSearch" type="text" class="form-control" placeholder="Search for the chapters" aria-label="Search for the chapters" aria-describedby="basic-addon2" />
                    <button id="btnSearch" type="button" class="btn btn-primary btn-just-icon" onclick="search();" style="margin-top: -4px;">
                        <span class="material-icons">search</span>
                    </button>
                    <script>
                        // Get the input field
                        var input = document.getElementById("txtSearch");

                        // Execute a function when the user releases a key on the keyboard
                        input.addEventListener("keyup", function (event) {
                            // Cancel the default action, if needed
                            event.preventDefault();
                            // Number 13 is the "Enter" key on the keyboard
                            if (event.keyCode === 13) {
                                // Trigger the button element with a click
                                document.getElementById("btnSearch").click();
                            }
                        });
                    </script>
                    <%--<input type="button" value="Search" />--%>
                </div>
            </div>
            <div class="col-4">
                <%--Back Button--%>
                <div class="row">
                    <div class="col-12 text text-right">
                        <button type="button" class="btn btn-link" onclick="showChapters(false);">
                            <h4 style="text-transform: none">Go to Dashboard
                            </h4>
                        </button>
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                function search() {

                    var strSearch = document.getElementById('txtSearch').value.toLowerCase();
                    var element = document.querySelectorAll('[data-isCard="true"]');
                    console.log(element);
                    //alert(element.length);

                    for (var i = 0; i < element.length - 1; i++) {
                        if (element[i].dataset.chapter.toLowerCase().includes(strSearch)) {
                            //alert('true');
                            element[i].removeAttribute("style");

                        } else {
                            //alert('false');
                            element[i].setAttribute("style", "visibility:hidden; display: none;");
                        }
                    }

                }
            </script>

        </div>

        <%--Chapter list will be generated dynamically here--%>
        <div class="row" id="chapterCard">
        </div>

    </div>
    <%--Check BuildContentHTMLDisable() method in server side code for free user--%>


    <!-- The Modal To Play / Display content (.mp4, .pdf and quiz) -->
    <style>
        .modal-dialog {
            width: 100% !important;
            min-width: 100% !important;
            height: 100%;
            margin: 0;
            padding: 0;
        }

        .modal-content {
            height: auto;
            min-height: 100%;
            border-radius: 0;
        }

        .modal-body {
            height: 100% !important;
            min-height: 350px !important;
        }

        iframe {
            border: none !important;
            height: 100% !important;
            position: absolute !important;
            height: 100% !important;
            top: 0px !important;
            left: 0px !important;
        }

        #myframe {
            position: absolute !important;
            height: 100% !important;
            top: 0px !important;
            left: 0px !important;
        }
    </style>
    <div class="modal" id="myModal">
        <div class="modal-dialog">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title" id="modal-title">Modal Heading</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div id="modal-body" class="modal-body text-center">
                    <div id="dvcontentPlayArea" class="text-center">
                    </div>
                </div>

                <!-- Modal footer -->
                <%--<div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>--%>
            </div>
        </div>
    </div>





    <%--<div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header collapsed" data-toggle="collapse" href="#collapseExample" role="button" aria-expanded="false" aria-controls="collapseExample">
                        <h5 class="text-primary align-baseline"><strong>Chapter Name </strong></h5>
                    </div>
                    <div class="card-body collapse" id="collapseExample">
                        <button class="btn btn-outline-primary">Video Presentation</button>
                        <button class="btn btn-outline-danger">MCQ</button>
                        <button class="btn btn-outline-warning">Worksheet</button>
                        <button class="btn btn-outline-success">Post test</button>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <%--Hidden--%>
    <div style="display: none; visibility: hidden;">
        <div class="row DBHeader">
            <%--Yor are here--%>
            <div class="col-sm-5 NoPadding">
                <div class="DashboardHeading">
                    You are here: <span style="color: White;">Dashboard</span>
                </div>
            </div>
            <%--date time--%>
            <div class="col-sm-3 NoPadding">
                <div class="DashboardHeading">
                    <img src="../App_Themes/Green/Images/icon-calendar.png" />
                    &nbsp;&nbsp;<i>Today:
                    <%=DateTime.Now.ToString("dd MMM yyyy / hh:mm tt")%></i>
                </div>
            </div>
            <%--search panel--%>
            <div class="col-sm-4 NoPadding">
                <table class="SearchTable" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <span class="glyphicon glyphicon-search" style="margin-right: 10px;"></span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtkeyword" CssClass="text Search" runat="server" title="Enter Keyoword of Topic Name to search."
                                placeholder="Search">
                            </asp:TextBox>
                            <asp:TextBox ID="tbAutoCompleteAll" runat="server" autocomplete="Off" Style="display: none;"></asp:TextBox>
                        </td>
                        <td>
                            <%-- <asp:RequiredFieldValidator ID="rfvkeyword" ValidationGroup="vgSearch" ControlToValidate="txtkeyword"
                            runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td>
                            <asp:Button Style="margin: 0px; max-height: 29px;" ID="btnsearcksubmit" runat="server"
                                Text="Go" title="search result based on Board, Medium, standard, Subject, Chapter and TopicName."
                                OnClientClick="javascript:return SearchChapter();" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row" id="dvprofilepercentage" runat="server">
            <%--Profile complate percentage area--%>
            <div class="col-md-12">
                <div id="container">
                    <div id="bar-2" class="bar-main-container prback">
                        <div class="wrap">
                            <div id="profilepercentage" runat="server" class="bar-percentage" data-percentage="62">
                            </div>
                            <div class="bar-container">
                                <div class="bar">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <%--subject list--%>
            <div class="col-xs-12 col-sm-4 col-md-3 col-xl-3">
                <div class="Activity mrtp10" style="min-width: 150px;">
                    <div class="ActivityHeading">
                        <asp:Label ID="Label1" runat="server" Text="Subject list"></asp:Label>
                    </div>
                    <div class="Content" id="dvSubjectlist">
                        <asp:RadioButtonList ID="rbSubjectList" runat="server" RepeatDirection="Vertical"
                            CssClass="RBPadding" RepeatColumns="1" CellSpacing="10" CellPadding="10" onchange="javascript:return subjectselection();"
                            meta:resourcekey="rbSubjectListResource1">
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="Activity mrtp15">
                    <div class="ActivityHeading">
                        <asp:Label ID="Label2" runat="server" Text="Syllabus Covered"></asp:Label>
                    </div>
                    <div class="Content">
                        <div id="dvcoveredgraph" style="text-align: center;">
                        </div>
                    </div>
                </div>
            </div>
            <%--Chapter Topic list--%>
            <div class="col-xs-12 col-sm-8 col-md-9 col-xl-9">
                <div class="row mrtp10" id="test">
                </div>
                <div class="Activity mrtp10" style="display: none;">
                    <div class="ActivityHeading">
                        <asp:Label ID="Label3" runat="server" Text="Chapter list"></asp:Label>
                    </div>
                    <div class="Content">
                        <div id="dvChapterTopicList">
                        </div>
                        <asp:HiddenField ID="hdnchapterid" runat="server" Value="" />
                        <asp:HiddenField ID="hdntopicid" runat="server" Value="" />
                        <asp:HiddenField ID="hdnTopicName" runat="server" Value="" />
                    </div>
                </div>
            </div>
            <%--Content List And Syllabus Covered graph--%>
            <div class="hidden-sm  hidden-md hidden-lg hidden-xs">
                <div class="Activity mrtp10">
                    <div class="ActivityHeading">
                        <asp:Label ID="Label4" runat="server" Text="Educational Resources"></asp:Label>
                    </div>
                    <div class="Content">
                        <div id="dvContentList" style="text-align: center;">
                        </div>
                        <asp:HiddenField ID="hdnbmssctid" runat="server" Value="" />
                        <asp:HiddenField ID="hdnstudentid" runat="server" Value="" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="Content">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="activitydiv activityright" id="fsExpiryNotification" runat="server" visible="true">
                    </div>
                </div>
                <div>
                </div>
            </div>
        </div>
        <div class="row" style="margin: 0px; padding: 0px; overflow: auto; display: none;">
            <div>
                <ul class="nav nav-tabs GridTab">
                    <li class="active"><a data-toggle="tab" href="#Current_Package">Current Packages</a></li>
                    <li><a data-toggle="tab" href="#Expired_Package">Expired Packages</a></li>
                </ul>
                <div class="tab-content">
                    <div id="Current_Package" class="tab-pane fade in active">
                        <div class="GridTitle" style="visibility: hidden; display: none;">
                            <asp:Label ID="lblLegendExpiryNotification" runat="server" Text="Current Packages"></asp:Label>
                        </div>
                        <div>
                            <asp:GridView ID="gvSubjectExpiryNotification" runat="server" AutoGenerateColumns="False"
                                meta:resourcekey="gvSubjectExpiryNotificationResource1">
                                <Columns>
                                    <asp:TemplateField HeaderText="Subject">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("Subject").ToString().Replace(",", ", " ) %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PackageType" HeaderText="Package Type" />
                                    <asp:BoundField DataField="FromDate" HeaderText="Activate On" DataFormatString="{0:dd-MMM-yyyy}" />
                                    <asp:BoundField DataField="ValidTill" HeaderText="Expired On" DataFormatString="{0:dd-MMM-yyyy}" />
                                </Columns>
                            </asp:GridView>
                            <span style="padding-left: 430px;">
                                <asp:LinkButton ID="lnkviewmore" runat="server" Text="View More...." Visible="False"
                                    OnClick="lnkviewmore_Click"></asp:LinkButton>
                            </span>
                            <asp:GridView ID="gvComboExpiryNotification" runat="server" Visible="False" AutoGenerateColumns="False"
                                meta:resourcekey="gvComboExpiryNotificationResource1">
                                <Columns>
                                    <asp:BoundField DataField="Standard" HeaderText="Standard" />
                                    <asp:BoundField DataField="Name" HeaderText="Package Type" />
                                    <asp:BoundField DataField="FromDate" HeaderText="Activate On" />
                                    <asp:BoundField DataField="ValidTill" HeaderText="Expired On" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div id="Expired_Package" class="tab-pane fade">
                        <div class="GridTitle" style="visibility: hidden; display: none;">
                            <asp:Label ID="lblexpiredpackage" runat="server" Text="Expired Packages"></asp:Label>
                        </div>
                        <asp:GridView ID="gvExpiredPackageList" runat="server" Visible="true" AutoGenerateColumns="False"
                            Style="width: 94%;" PageSize="2">
                            <Columns>
                                <asp:TemplateField HeaderText="Subject">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("Subject").ToString().Replace(",", ", " ) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PackageType" HeaderText="Package Type" />
                                <asp:BoundField DataField="FromDate" HeaderText="Activate On" DataFormatString="{0:dd-MMM-yyyy}" />
                                <asp:BoundField DataField="ValidTill" HeaderText="Expired On" DataFormatString="{0:dd-MMM-yyyy}" />
                            </Columns>
                        </asp:GridView>
                        <span style="padding-left: 430px;">
                            <asp:LinkButton ID="lnkviewmore1" runat="server" Text="View More...." Visible="False"
                                OnClick="lnkviewmore1_Click"></asp:LinkButton>
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <%--Content Play Area--%>
            <div class="col-sm-12">
                <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup" Style="display: none"
                    meta:resourcekey="btnShowResource1" />
                <asp:Button ID="btnClose" runat="server" Text="Close Modal Popup" Style="display: none"
                    meta:resourcekey="btnShowResource1" />
                <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Display" TargetControlID="btnShow"
                    BackgroundCssClass="modalBackground" CancelControlID="btnClose" DynamicServicePath=""
                    Enabled="True">
                </cc1:ModalPopupExtender>
                <div id="Display" runat="server" style="display: none;">
                    <div class="WoodenBorder" style="position: fixed; top: 0px; left: 0px; width: 100%; height: 100%; z-index: 100001;">
                        <div class="GreenBoard" style="height: 5%;">
                            <asp:Label ID="LblDisplay" runat="server" Text="Display Resource" meta:resourceKey="LblDisplay"
                                Style="display: inline-block;"></asp:Label>
                            <div style="position: fixed; top: 22px; right: 22px;">
                                <asp:ImageButton ID="ibtnClose" runat="server" Text="Close" CausesValidation="False"
                                    meta:resourceKey="btnCloseResource1" ImageUrl="~/App_Themes/Images/close.png"
                                    Height="20px" Width="20px" OnClientClick="javascript:return CloseContent();" />
                            </div>
                        </div>
                        <%--<div id="dvcontentPlayArea" style="height: 95%; background-image: url('../App_Themes/Green/Images/green-bg.jpg');">
                        &nbsp;
                    </div>--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <%--Finish Activity with feedback popup start--%>
            <asp:Button ID="btnfeedbackshow" runat="server" Text="Show Modal Popup" Style="display: none" />
            <asp:Button ID="btnfeedbackclose" runat="server" Text="Hide Modal Popup" Style="display: none" />
            <cc1:ModalPopupExtender ID="mdlfeedback" runat="server" PopupControlID="pnlfeedback"
                TargetControlID="btnfeedbackshow" BehaviorID="mdlfeedback" CancelControlID="btnfeedbackclose"
                BackgroundCssClass="modalBackground" DynamicServicePath="" Enabled="True">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlfeedback" runat="server" Style="display: none; border: none; width: 90%;"
                CssClass="Activity">
                <div class="hidden-xs col-sm-2 col-md-3 col-lg-4">
                    &nbsp;
                </div>
                <div class="col-xs-12 col-sm-8 col-md-6 col-lg-4 NoPadding" style="border: 1px solid #2e8e6e;">
                    <div class="ActivityHeading" style="margin-bottom: 0px;">
                        <asp:Label ID="lblHeader" runat="server" Text="Finish Activity"></asp:Label>
                    </div>
                    <div class="ActivityContent">
                        <div class="GreenBoard">
                            <div style="padding-top: 15px; display: none;">
                                <div>
                                    <cc1:Rating ID="topicrating" AutoPostBack="false" runat="server" StarCssClass="Star"
                                        WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star" FilledStarCssClass="FilledStar">
                                    </cc1:Rating>
                                </div>
                            </div>
                            <div style="padding-top: 15px;">
                                <div>
                                    <asp:TextBox ID="txtfeedback" CssClass="form-control2 input-sm2" TextMode="MultiLine"
                                        runat="server" placeholder="Enter feedback here"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="ActivityHeading" style="margin-bottom: 0px;">
                        <div class="text-center">
                            <asp:Button ID="btnfeedbacksubmit" runat="server" Text="Finish Activity" OnClientClick="javascript:return FinishActivity();"
                                Style="border: 2px solid #F77408; padding: 8px 15px; text-decoration: none; border-radius: 34px; display: table-cell; background: none; color: #F77408;" />
                            &nbsp;&nbsp;
                        <asp:Button ID="btnfeedbackcancel" runat="server" Text="Cancel" OnClientClick="javascript:return closefeedback();"
                            Style="border: 2px solid #F77408; padding: 8px 15px; text-decoration: none; border-radius: 34px; display: table-cell; background: none; color: #F77408;" />
                        </div>
                    </div>
                </div>
                <div class="hidden-xs col-sm-2 col-md-3 col-lg-4">
                    &nbsp;
                </div>
            </asp:Panel>
        </div>

    </div>

    <script type="text/javascript">
        //fire script when document is load
        $(document).ready(function () {
            $("input").attr("autocomplete", "off"); subjectselectionwithoutfocus(); $('html, body').animate({ scrollTop: $("#dvSubjectlist").offset().top - 250 }, 1000); showProfilecomplate();
            //setInterval(function ApplyJS() { $('.grid').masonry({ itemSelector: '.grid-item', percentPosition: true }); }, 1000);
        });


        //play content in model popup
        //function ShowContent(fname, ext, res, id) { if ($("#<%= btnShow.ClientID%>") != null) { $("#<%= btnShow.ClientID%>").click(); document.getElementById('<%= LblDisplay.ClientID %>').innerHTML = document.getElementById('<%= hdnTopicName.ClientID %>').value; if (ext == ".mp4") { $('#dvcontentPlayArea').html("<video width='100%' height='100%' style='max-height:100%' preload  controls autoplay><source type='video/mp4' codecs='avc1.42E01E, mp4a.40.2' src='" + res + "' ></video>"); } else if (ext == ".pdf") { var pdfurl = window.location.href.replace("Dashboard/StudentDashboard.aspx", "") + res.replace("../", ""); $('#dvcontentPlayArea').html("<iframe id='myframe' width='100%' height='100%' src=\"http://docs.google.com/gview?url=" + pdfurl + "&embedded=true\" allowfullscreen='true'></iframe>"); } else if (ext == ".Test") { var testurl = res + "&BMSSCTID=" + id; $('#dvcontentPlayArea').html("<iframe id='myframe' width='100%' height='100%' src='" + testurl + "' allowfullscreen='true'></iframe>"); } else { $('#dvcontentPlayArea').html("<iframe id='myframe' width='100%' height='100%' src='" + res + "' allowfullscreen='true'></iframe>"); } PlayedContent(fname, res); } return false; }


        //educational resource populate on chapter-topic selection changed
        function TopicSelection(bmssctid, subjectid, chapterid, topicid, topicname, iscover) { ManageOtherSubjectTopicSelectionFromSearchResult(subjectid); document.getElementById('<%= hdnTopicName.ClientID %>').value = topicname; $('#dvContentList').html(GetLoading()); $('html, body').animate({ scrollTop: $("#dvContentList").offset().top - 180 }, 1000); document.getElementById('<%= hdnchapterid.ClientID %>').value = chapterid; document.getElementById('<%= hdntopicid.ClientID %>').value = topicid; PageMethods.TopicSelection(subjectid, chapterid, topicid, topicname, iscover, Success, Failure); function Success(result) { $('#dvContentList').html(result); if (result.toString() == null || result.toString() == '') { window.location.href = "../OtherPages/Landing.aspx"; } if ($('#' + bmssctid + '').hasClass('Covered')) { $('#btnsubmitfeedback').css('display', 'none'); } } function Failure(error) { alert("OOPS! There is some problem, please try again."); location.reload(); } }

        //profile percentage bar
        function showProfilecomplate() { var progress = $('.bar-percentage'); var percentage = Math.ceil($('.bar-percentage').attr('data-percentage')); $({ countNum: 0 }).animate({ countNum: percentage }, { duration: 2000, easing: 'linear', step: function () { var pct = ''; if (percentage == 0) { pct = Math.floor(this.countNum) + '%'; } else { pct = Math.floor(this.countNum + 1) + '%'; } progress.html('<a href=\"../Student/MyAccount.aspx\">' + pct + ' PROFILE COMPLETED</a>') && progress.siblings().children().css('width', pct); } }); }
        //update syllabus covered graph
        function UpdateCoveredSyllabus(subjectid, subjectname) { $('#dvcoveredgraph').html(GetLoading()); PageMethods.UpdateCoveredSyllabus(subjectid, Success, Failure); function Success(result) { $('#dvcoveredgraph').html("<div id=\"myStat\" clientidmode=\"Static\" data-dimension=\"170\" data-info=\"" + subjectname + "\" data-width=\"12\" data-fontsize=\"16\" data-percent=\"" + result[0].Value + "\" data-text=\"" + result[1].Value + "\" data-fgcolor=\"#71af32\" data-bgcolor=\"#225244\" data-fill=\"transparent\" style=\"margin: auto;\"></div>"); $('#myStat').circliful(); } function Failure(error) { } }
        //close content popup
        function CloseContent() { if ($("#<%= btnClose.ClientID%>") != null) { $("#<%= btnClose.ClientID%>").click(); $('#dvcontentPlayArea').html(''); } return false; }
        //collapse all node os tree
        function CollapseAll(obj) { if (obj.className != ' collapsibleListOpen' && obj.className != 'collapsibleListOpen') { $('.collapsibleListOpen').each(function () { $(this).removeClass('collapsibleListOpen').addClass(' collapsibleListClosed'); $(this).find('ul').attr('style', 'display:none'); }) } }
        //show feedback popup while finish activities
        function showfeedback(bmssctid, studentid) { document.getElementById('<%= txtfeedback.ClientID %>').value = ''; document.getElementById('<%= hdnbmssctid.ClientID %>').value = bmssctid; document.getElementById('<%= hdnstudentid.ClientID %>').value = studentid; if ($find("mdlfeedback") != null) { $find("mdlfeedback").show(); } return false; }
        //close feedback popup
        function closefeedback() { document.getElementById('<%= txtfeedback.ClientID %>').value = ''; document.getElementById('<%= hdnbmssctid.ClientID %>').value = ''; document.getElementById('<%= hdnstudentid.ClientID %>').value = ''; if ($find("mdlfeedback") != null) { $find("mdlfeedback").hide(); } return false; }
        //select subject automatically when other chpter topic select from search result
        function ManageOtherSubjectTopicSelectionFromSearchResult(subjectid) { if (subjectid != '#') { $("#<%=rbSubjectList.ClientID %> input[type='radio'][value='" + subjectid + "']").prop("checked", true); UpdateCoveredSyllabus(GetSelectedSubjectID(), GetSelectedSubjectName()); } }
        //get id of selected subject
        function GetSelectedSubjectID() { return $('#<%=rbSubjectList.ClientID %> input[type=radio]:checked').val(); }
        //get name of selected subject
        function GetSelectedSubjectName() { var idVal = $('#<%=rbSubjectList.ClientID %> input[type=radio]:checked').attr("id"); return ($("label[for='" + idVal + "']").text()); }
        //get html of loading
        function GetLoading() { return '<div style="text-align:center;"><div class="loading"></div></div>'; }
        //play content
        function PlayContent(fname, ext, res, id) { ShowContent(fname, ext, res, id); }
        ////log played content
        //function PlayedContent(fname, res) { PageMethods.LogResourceAccess(fname, res, Success, Failure); function Success(result) { } function Failure(error) { } }
        function RefreshPage() { location.reload(); return false; }

        //chpter-topic list populate on subject selection with focus
        function subjectselection() {
            $('#test').html(GetLoading());
            //$('#test').html('');
            $('html, body').animate({ scrollTop: $("#test").offset().top - 180 }, 1000);
            PageMethods.SubjectSelection(GetSelectedSubjectID(), GetSelectedSubjectName(), Success, Failure);
            function Success(result) {
                $('#test').html(result);
                SetTopicFirstForDemo();
                if (result == '') {
                    alert('OOPS! There is some problem, please try again.'); location.reload();
                } else {
                    //CollapsibleLists.applyTo(document.getElementById('ChapterTopicList'));
                }
            }
            function Failure(error) {
                alert("OOPS! There is some problem, please try again."); location.reload();
            }
            UpdateCoveredSyllabus(GetSelectedSubjectID(), GetSelectedSubjectName());
        }

        //get search result of chapter-topic 
        function SearchChapter() {
            var searchkeyword = $("#<%= txtkeyword.ClientID %>").val();
            $('#test').html(GetLoading());
            $('html, body').animate({ scrollTop: $("#test").offset().top - 180 }, 1000);
            PageMethods.SubjectSelectionSearch(searchkeyword, Success, Failure);
            function Success(result) {
                $('#test').html(result);
                SetTopicFirstForDemo();
            }
            function Failure(error) {
                alert("OOPS! There is some problem, please try again."); location.reload();
            } return false;
        }

        //chpter-topic list populate on subject selection without focuc
        function subjectselectionwithoutfocus() {
            $('#test').html(GetLoading());
            PageMethods.SubjectSelection(GetSelectedSubjectID(), GetSelectedSubjectName(), Success, Failure);
            function Success(result) {
                $('#test').html(result);
                SetTopicFirstForDemo();
            }
            function Failure(error) {
                alert("OOPS! There is some problem, please try again.");
                location.reload();
            }
            UpdateCoveredSyllabus(GetSelectedSubjectID(), GetSelectedSubjectName());
        }
        //finish activity chapter-topic wise
        function FinishActivity() {
            debugger;
            var bmssctid = document.getElementById('<%= hdnbmssctid.ClientID %>').value;
            var studentid = document.getElementById('<%= hdnstudentid.ClientID %>').value;
            var ActivityFeedback = document.getElementById('<%= txtfeedback.ClientID %>').value;
            $('html, body').animate({ scrollTop: $("#dvcoveredgraph").offset().top - 180 }, 1000);
            //var ratingcount = $('#ctl00_ContentPlaceHolder1_topicrating a .FilledStar').length;
            //PageMethods.SaveStudentFinishActivity(bmssctid, studentid, ActivityFeedback, ratingcount, Success, Failure);
            PageMethods.SaveStudentFinishActivity(bmssctid, studentid, ActivityFeedback, Success, Failure);
            function Success(result) {
                if (result == "Covered successfully" || result == "Already covered") {
                    $('#btnsubmitfeedback').css('display', 'none'); closefeedback();
                    UpdateCoveredSyllabus(GetSelectedSubjectID(), GetSelectedSubjectName());
                    $('#' + bmssctid + '').removeClass("UnCovered").addClass("Covered");
                } else {
                    closefeedback(); alert('OOPS! There is some problem in finish activity, please try again.'); location.reload();
                }
            } function Failure(error) { alert("OOPS! There is some problem, please try again."); location.reload(); } return false;
        }

        function RedirectToBuy() {
            window.location = "BuyPackage.aspx";
        }
        function ApplyJS() { $('.grid').masonry({ itemSelector: '.grid-item', percentPosition: true }); }
        function SetTopicFirstForDemo() {
            if (checkdemo()) {
                var divgriditem = document.getElementsByClassName("grid-item");
                var i;
                for (i = 0; i < divgriditem.length; i++) {
                    var heading = divgriditem[i].getElementsByClassName('hoversubscribe');
                    if (heading.length == 0) {
                        $(".grid").prepend(divgriditem[i]);
                        divgriditem[i].remove();
                    }
                }
            }
        }
        function checkdemo() {
            var divgriditem = document.getElementsByClassName("grid-item");
            var i;
            for (i = 0; i < divgriditem.length; i++) {
                var heading = divgriditem[i].getElementsByClassName('hoversubscribe');
                if (heading.length > 0) {
                    return true;
                }
            }
            return false;
        }
    </script>
    <script type="text/javascript">


        $(document).on('click', '.rating-input', function () {
            debugger;


            if (($(this).attr("id")).indexOf("rating-input-1-1") == 0) {

                if ($(this).next().css('background-position') == "0px 0px") {

                    var strid1 = $(this).attr("id");
                    ResetStar(strid1);
                    $(this).next().css('background-position', '0px -16px');

                    var str1 = replaceAt(strid1, 15, "0");
                    StoreRating(str1);
                    return;
                }
                else {
                    $(this).next().css('background-position', '0px 0px');

                }

            }
            else {

                var strid = $(this).attr("id");
                ResetStar(strid);
                var str = replaceAt(strid, 15, "1");
                var strelement = document.getElementById(str);
                $(strelement).next().css('background-position', '0px 0px');


                //alert(str);
            }
            StoreRating($(this).attr("id"));
        });

        function ResetStar(strid) {
            debugger;
            var arrayOfStrings = strid.split('-');
            var index = arrayOfStrings[3];
            var strelement1 = document.getElementById(strid);
            if ($(strelement1).next().css('background-position') == "0px -16px") {
                var startindex = index;
                for (var i = startindex; i >= 1; i--) {
                    var strele = replaceAt(strid, 15, i);
                    var strelement = document.getElementById(strele);
                    $(strelement).next().css('background-position', '0px 0px');
                }
            }
            else {

                if (index < 5) {
                    var startindex = parseInt(index) + 1;
                    for (var i = startindex; i <= 5; i++) {
                        var strele = replaceAt(strid, 15, i);
                        var strelement = document.getElementById(strele);
                        $(strelement).next().css('background-position', '0px -16px');
                    }
                }
            }

        }

        // $(document).on('mouseover', '.rating-input', function () {
        //            var strid = $(this).attr("id");
        //            var str = replaceAt(strid, 15, "1");
        //            var strelement = document.getElementById(str);
        //            $(strelement).next().css('background-position', '0px 0px');

        //        });


        function replaceAt(s, n, t) {
            return s.substring(0, n) + t + s.substring(n + 1);
        }

        function StoreRating(ratingid) {
            PageMethods.UpdateRating(ratingid, onSuccess, onFailure);
        }

        function onSuccess(result) {
            //alert(result);
        }


        function onFailure(error) {
            //alert(error);
        }

        function SubmitReview(bmssctid) {
            //alert("BMSSCTID: " + bmssctid);
            var txtreviewid = "txtreview_" + bmssctid;
            var txtreview = document.getElementById(txtreviewid).value;

            //alert(txtreview);
            PageMethods.UpdateReview(bmssctid, txtreview, onSuccess1, onFailure1);
            return false;
        }

        function onSuccess1(result) {
            //alert(result);
        }


        function onFailure1(error) {
            //alert(error);
        }
        var Tawk_API = Tawk_API || {};
        Tawk_API.visitor = {
            name: '<%: username %>',
            email: '<%: loginid %>'
        };

        var Tawk_LoadStart = new Date();


    </script>

</asp:Content>


