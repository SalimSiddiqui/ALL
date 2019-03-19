/// <reference path="../angular.js" />
/// service

var application = angular.module("myapp", []);
application.controller('myController', function ($scope) {
    $scope.obj = { value: 1 };
    $('.digest').click(function () {
        console.log("digest clicked!");
        console.log($scope.obj.value++); //update value 
       $scope.$digest();
    });
});