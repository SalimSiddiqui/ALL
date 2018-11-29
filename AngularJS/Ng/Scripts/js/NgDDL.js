/// <reference path="../angular.js" />
var app = angular.module("Demo", []);
app.controller("MyCtrl", function ($scope, $http) {
    $http.get("WebService/DDL_Service.asmx/GetDepartmentJson").then(function (respose) {
        $scope.Department = respose.data;       
    });

});

app.controller("Sorting", function ($scope,$http) {
    $http.get("WebService/DDL_Service.asmx/GetpersonDetails").then(function (response) {
        $scope.persons = response.data;
    });
});



