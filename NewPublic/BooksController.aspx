<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BooksController.aspx.cs"
    Inherits="NewPublic_BooksController" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.5.0/angular.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/angular-ui-grid/4.6.3/ui-grid.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/angular-ui-grid/4.6.3/ui-grid.min.css"
        type="text/css">
    <style>
        p, div {
            font: 15px Verdana;
        }

        .uiGrd {
            width: 550px;
            height: 300px;
        }
    </style>

    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/angularjs/1.2.5/angular.min.js"></script>--%>
    <script type="text/javascript">
        angular.module("myapp", [])
        .controller("MyController", function ($scope, $http) {
            $scope.retData = {};
            $scope.retData.getResult = function (item, event) {
                $http.post('BooksController.aspx/GetEmployees', { data: {} })
                .success(function (data, status, headers, config) {
                    $scope.retData.result = data.d;
                })
                .error(function (data, status, headers, config) {
                    $scope.status = status;
                });
            }
        }).config(function ($httpProvider) {
            $httpProvider.defaults.headers.post = {};
            $httpProvider.defaults.headers.post["Content-Type"] = "application/json; charset=utf-8";
        });
    </script>



    <script>
        var myApp = angular.module('myApp', ['ui.grid']);

        myApp.controller('myController',
        function ($scope, $http) {
            debugger;


            $scope.gridOptions = {
                
                enableSorting: true,

                columnDefs: [

                { field: 'BookName' },

                { field: 'Category' },

                { field: 'Price', enableSorting: false }

                ],

                onRegisterApi: function (gridApi) {
                    alert(gridApi);
                    $scope.grid1Api = gridApi;

                }
            };


            $scope.title = "AngularJS UI-Grid Example";

            Perform_CRUD('READ');

            function Perform_CRUD(ops) {
               // alert(ops);
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
                                BookName: data.d[i].BookName,
                                Category: data.d[i].Category,
                                Price: data.d[i].Price
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div ng-app="myApp" ng-controller="myController">
            <p>
                {{title}}
            </p>
            <div class="uiGrd" id="grd" ui-grid="gridData">
                <div ng-repeat="option in gridOptions" class="gridStyle" ng-grid="option"></div>
            </div>
        </div>
    </form>
</body>
</html>
