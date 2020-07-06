<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/materialMaster.master" AutoEventWireup="true" CodeFile="dynamicselect.aspx.cs" Inherits="NewPublic_dynamicselect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.3.8/angular.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js"></script>
    <script>
        var myApp = angular.module('myApp', []);

        myApp.controller('myController', function ($scope, $http) {

            var arrBooks = new Array();

            $http.post("dynamicselect.aspx/Perform_CRUD").success(function (xml) {
                alert(xml);
                $(xml).find('List').each(function () {
                    alert($(this).find('BookName').text());
                    arrBooks.push($(this).find('BookName').text())
                });

                $scope.list = arrBooks;
            }).error(function (status) {
                alert(status);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div ng-app="myApp"
        ng-controller="myController">

        <select ng-model="your_selection" ng-options="b for b in list">
            <option value="">-- Select a Book --</option>
        </select>

        <p>You have selected: {{ your_selection }}</p>
    </div>
</asp:Content>

