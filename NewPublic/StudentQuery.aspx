<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/materialMaster.master" AutoEventWireup="true" CodeFile="StudentQuery.aspx.cs" Inherits="NewPublic_StudentQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <%--<script src="https://unpkg.com/@ionic/core@latest/dist/ionic.js"></script>
    <link href="https://unpkg.com/@ionic/core@latest/css/ionic.bundle.css" rel="stylesheet" />--%>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.5.0/angular.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/angular-ui-grid/4.6.3/ui-grid.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/angular-ui-grid/4.6.3/ui-grid.min.css"
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        p, div {
            font: 15px Verdana;
        }

        .uiGrd {
            width: 550px;
            height: 300px;
        }
    </style>




    <div id="row" class="row" style="margin-top: 70px; margin-left: 10px; margin-right: 10px;">
        <div class="col-md-9 mb-md-0 mb-5">

            <div class="row">

                <div class="col-md-12">
                    <div class="md-form mb-0">
                       
                        <asp:DropDownList runat="server" ID="ddlsubjectlist" AutoPostBack="false" Visible="false">
                        </asp:DropDownList>

                        <div ng-app="myApp" ng-controller="myCtrl">

                            <div class="row">
                                <div class="col-md-4">
                                 
                                         Subject:
                                    <br />
                            <select name="level" ng-model="selectedSubject" ng-options="x.subject1 for x in SubjectName"  ng-change="FillChapter()">
                                <option value="">-- Select a Subject --</option>
                            </select>
                                   
                                </div>
                                 <div class="col-md-4">
                                    
                                         Chapter:
                                     <br />
                            <select ng-model="selectedChapter" ng-options="x.Chapter1 for x in ChapterName" ng-change="FillTopic()"  >
                                <option value="">-- Select a Chapter --</option>
                            </select>
                                
                                </div>
                                 <div class="col-md-4">
                                         Topic:
                                     <br />
                            <select ng-model="selectedTopic" ng-options="x.Topic1 for x in TopicName">
                                <option value="">-- Select a Topic --</option>
                            </select>
                                   
                                </div>
                          </div>


          <%--  <div class="row">
                 <div class="col-md-12">
                    <div class="md-form mb-0">
                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>
                </div>

            </div>
         --%>
            <div class="row">
                <div class="col-md-12">
                    <div class="md-form mb-0" style="border: 1px solid silver; min-width: 100%;">
                        <asp:Label ID="LblDesc" runat="server" Text="Description"></asp:Label>
                       <%-- <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="2" CssClass="form-control"></asp:TextBox>--%>
                        <textarea id="textareaEdit" ng-model="txtDesc" style="width:100%"></textarea>
                     
                        <%--<asp:RequiredFieldValidator ID="rqfld1" runat="server" ControlToValidate="txtDesc" ValidationGroup="vsupport" ErrorMessage="Description cannot be blank"></asp:RequiredFieldValidator>--%>
                    </div>

                </div>
            </div>
            <br />
            <br />
            <div class="row">

                <div class="col-md-12">
                <%--    <asp:Button ID="btnsubmit" CssClass="btn-blue" runat="server" Text="Submit" OnClientClick="" OnClick="btnsubmit_Click" ValidationGroup="vsupport" />--%>
                    <input type="button" value="Submit" ng-click="insertData()" />
                </div>

            </div>
            <div class="row">

                <div class="md-form mb-0" style="border: 1px solid silver; min-width: 100%;">
                    <%--<asp:ValidationSummary ID="valid1" runat="server" CssClass="form-control" DisplayMode="List" ShowMessageBox="true" ShowSummary="true" />--%>
                </div>
            </div>
        </div>
            
                    </div>
                </div>
               

            </div>
        
                        </div>
    </div>



    <%--<div class="row" style="margin-top:70px;margin-left:180px;">
        
    
    </div>--%>








<%--    <script src="../App_Themes/bootstrap-3.3.7-dist/js/bootstrap.js"></script>--%>

    <%--<script>
        var myApp = angular.module('myApp', ['ui.grid']);

        myApp.controller('myController',
        function ($scope, $http) {
            debugger;


            $scope.gridOptions = {

                enableSorting: true,

                columnDefs: [

                { field: 'BookName' },

                //{ field: 'Category' },

                //{ field: 'Price', enableSorting: false }

                ],

                onRegisterApi: function (gridApi) {
                    alert(gridApi);
                    $scope.grid1Api = gridApi;

                }
            };


            $scope.title = "AngularJS UI-Grid Example";

            Perform_CRUD('READ');
            function Perform_CRUD(ops) {
                 alert(ops);
                debugger;
                var request = {
                    method: 'post',
                    url: 'BooksController.aspx/Perform_CRUD',
                    data: {
                        Operation: ops
                    },
                    dataType: 'json',
                    contentType: "application/json"
                };

                $scope.arrBooks = new Array;

                // POST DATA WITH $http.
                $http(request)
                    .success(function (data) {
                        // alert(data.d);
                        var i = 0;      // JUST A COUNTER.

                        // LOOP THROUGH EACH DATA.
                        angular.forEach(data.d, function () {
                            //alert(data.d[i].BookName);
                            var b = {
                                BookID: data.d[i].BookID,
                                BookName: data.d[i].BookName
                                //Category: data.d[i].Category,
                                //Price: data.d[i].Price
                            };

                            $scope.arrBooks.push(b);    // ADD DATA TO THE ARRAY.
                            i += 1;
                        });

                    })
                    .error(function (data, status, headers, config) {
                        alert(data);
                    });

                $scope.gridData = { data: 'arrBooks' };
            };
        });
    </script>--%>

    <script>



        //var myApp = angular.module('myApp', ['ui.grid']);
        var app = angular.module('myApp', []);
        app.controller('myCtrl',
        function ($scope, $http) {
            debugger;
            //$scope.title = "AngularJS UI-Grid Example";
            Perform_CRUD('READ');

            function Perform_CRUD(ops) {
                // alert(ops);
                debugger;
                var request = {
                    method: 'post',
                    url: 'StudentQuery.aspx/SelectSubject',
                    data: {
                        Operation: ops
                    },
                    dataType: 'json',
                    contentType: "application/json"
                };

                $scope.arrSubjects = new Array;

                // POST DATA WITH $http.
                $http(request)
                    .success(function (data) {
                        // alert(data.d);
                        var i = 0;      // JUST A COUNTER.

                        // LOOP THROUGH EACH DATA.
                        angular.forEach(data.d, function () {
                            //  alert(data.d[i].subject);
                            var b = {
                                subjectid1: data.d[i].subjectid,
                                subject1: data.d[i].subject,
                            };

                            $scope.arrSubjects.push(b);    // ADD DATA TO THE ARRAY.
                            //alert(b);
                            // $scope.BookNames = [{ BookName: data.d[i].BookName, BookID: data.d[i].BookID }];
                            i += 1;
                        });
                    })
                    .error(function (data, status, headers, config) {
                        alert(data);
                    });
                $scope.SubjectName = $scope.arrSubjects;
            };

            $scope.FillChapter = function () {

                var request = {
                    method: 'post',
                    url: 'StudentQuery.aspx/SelectChapter',
                    data: {
                        Operation: $scope.selectedSubject.subjectid1
                    },
                    dataType: 'json',
                    contentType: "application/json"
                };

                $scope.arrChapters = new Array;
                $http(request)
                    .success(function (data) {
                        var i = 0;
                        // LOOP THROUGH EACH DATA.
                        angular.forEach(data.d, function () {
                            //  alert(data.d[i].chapter);
                            var b = {
                                ChapterID1: data.d[i].chapterid,
                                Chapter1: data.d[i].chapter,
                            };

                            $scope.arrChapters.push(b);    // ADD DATA TO THE ARRAY.
                            i += 1;
                        });

                    })
                    .error(function (data, status, headers, config) {
                      
                        alert("error");
                    });
                $scope.ChapterName = $scope.arrChapters;

            };

            $scope.FillTopic = function () {
                debugger;
                var request = {
                    method: 'post',
                    url: 'StudentQuery.aspx/SelectTopic',
                    data: {
                        Operation: $scope.selectedSubject.subjectid1,
                        Operation1: $scope.selectedChapter.ChapterID1
                    },
                    dataType: 'json',
                    contentType: "application/json"
                };

                $scope.arrTopics = new Array;
                $http(request)
                    .success(function (data) {
                        var i = 0;
                        // LOOP THROUGH EACH DATA.
                        angular.forEach(data.d, function () {

                            var b = {
                                TopicID1: data.d[i].topicid,
                                Topic1: data.d[i].topic,
                            };

                            $scope.arrTopics.push(b);    // ADD DATA TO THE ARRAY.
                            i += 1;
                        });

                    })
                    .error(function (data, status, headers, config) {

                        alert("error");
                    });
                $scope.TopicName = $scope.arrTopics;

            };

            $scope.insertData = function () {
                debugger;
                var request = {
                    method: 'post',
                    url: 'StudentQuery.aspx/SaveDetails',
                    data: {
                        Question: $scope.txtDesc,
                        SubjectID: $scope.selectedSubject.subjectid1,
                        chapterID: $scope.selectedChapter.ChapterID1,
                        TopicID: $scope.selectedTopic.TopicID1
                    },
                    dataType: 'json',
                    contentType: "application/json"
                };

                //$scope.arrTopics = new Array;
                $http(request)
                    .success(function (data) {
                        alert(data.d);
                        $scope.selectedSubject = $scope.SubjectName[0].value;
                        $scope.selectedChapter = $scope.ChapterName[0].value;
                        $scope.selectedTopic = $scope.TopicName[0].value;
                        $scope.txtDesc = "";

                        $scope.arrTopics = new Array;
                        $scope.TopicName = $scope.arrTopics;
                        $scope.arrChapters = new Array;
                        $scope.ChapterName = $scope.arrChapters;
                    })
                    .error(function (data, status, headers, config) {

                        alert("error");
                    });
                //$scope.TopicName = $scope.arrTopics;

            };
        });
    </script>
 <%--   <div ng-app="myApp" ng-controller="myController">
        <p>
            {{title}}
        </p>
        <div class="uiGrd" id="grd" ui-grid="gridData">
            <div ng-repeat="option in gridOptions" class="gridStyle" ng-grid="option"></div>
        </div>



        <select ng-model="selectedName" ng-options="x for x in names">
        </select>

    </div>--%>


    
</asp:Content>

