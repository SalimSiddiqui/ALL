/// <reference path="../angular.js" />
/// service

var application = angular.module("myapp", []);
var myController = application.controller("myController", function ($scope) {
    $scope.name = 'dotnet-tricks.com'; // //watching change in name value
   $scope.counter = 0;

   $scope.$watch('name', function (newValue, oldValue)
   { $scope.counter = $scope.counter + 1; }); 
  });