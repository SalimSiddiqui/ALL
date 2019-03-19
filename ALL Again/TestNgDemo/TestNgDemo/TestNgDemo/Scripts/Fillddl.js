/// <reference path="angular.min.js" />
/// <reference path="JScript.js" />

app.controller("ddlctrl", function ($scope, $http) {
    $scope.countryList = null;
    $scope.filldropdown = function () {
        var http = {
            method: 'POST',
            url: 'WebService1.asmx/Fillddl',
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
                'dataType': 'json'
            },
            data: {}
        }
        $http(http).success(function (response) {
           
            $scope.StudentList = response.d;
        })
    }
    $scope.filldropdown();
    $scope.fillCity = function (Id) {
        var http = {
            method: 'POST',
            url: 'WebService1.asmx/FillCity',
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
                'dataType': 'json'
            },
            data: {Id:Id}
        }
        $http(http).success(function (response) {

            $scope.StudentListCity = response.d;
        })
    }

    $scope.fillMoh = function (Id) {
        var http = {
            method: 'POST',
            url: 'WebService1.asmx/FillMoh',
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
                'dataType': 'json'
            },
            data: { Id: Id }
        }
        $http(http).success(function (response) {

            $scope.StudentListMoh = response.d;
        })
    }
});
