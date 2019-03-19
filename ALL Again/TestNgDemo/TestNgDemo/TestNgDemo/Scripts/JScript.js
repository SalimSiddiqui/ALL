/// <reference path="angular.min.js" />


 
        var app = angular.module("myApp", []);
        app.controller("myCntrl", function ($scope, $http, $log) {
            $scope.studentorder = "StudetnName";
            $scope.studetnName = "";
            function Clear() {
                $scope.student.StudentName = '';
            };
            $scope.Save = function () {

                var city = {};
                city.StudentName = "Mumbai";


                var httpreq = {
                    method: 'POST',
                    //url: 'Default.aspx/Save',
                    url: 'WebService1.asmx/InsertSave',
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                        'dataType': 'json'
                    },
                    //                    data: { students: city }
                    data: "{student:" + JSON.stringify($scope.student) + "}"
                }
                $http(httpreq).success(function (response) {
                    $scope.fillList();
                    Clear();
                    alert("Saved successfully.");
                })
            };



            $scope.Delete = function (SID) {
                if (confirm("Are you sure want to delete?")) {
                    var httpreq = {
                        method: 'POST',
                        //url: 'Default.aspx/Delete',
                        url: 'WebService1.asmx/deleteStudent',
                        headers: {
                            'Content-Type': 'application/json; charset=utf-8',
                            'dataType': 'json'
                        },
                        data: { StudentID: SID }
                    }
                    $http(httpreq).success(function (response) {
                        $scope.fillList();
                        alert("Deleted successfully.");
                    })
                }
            };
            $scope.fillList = function () {
                $scope.studetnName = "";
                var httpreq = {
                    method: 'POST',
                    // url: 'Default.aspx/GetList',
                    url: 'WebService1.asmx/GetList',
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                        'dataType': 'json'
                    },
                    data: {}
                }
                $http(httpreq).success(function (response) {
                    $scope.StudentList = response.d;
                })
            };

            $scope.getStudentById = function (studentId) {
                $scope.notshow = true;
                var Http = {
                    method: 'POST',
                    url: 'WebService1.asmx/GetStudentById',
                    headers: { 'Content-Type': 'application/json; charset=utf-8',
                        'dataType': 'json'
                    },
                    data: { StudentId: studentId }
                }
                $http(Http).success(function (response) {

                    // StudentName = response.d.StudentName;

                    $scope.student = {
                        StudentName: response.d.StudentName,
                        StudentID: response.d.StudentID

                    };
                    //$log.log(response);
                }).error(function (error) {
                    //Showing error message
                    $scope.status = 'Unable to retrieve people' + error.message;
                });
            };

            $scope.updateStudent = function () {


                var http = {
                    method: 'POST',
                    url: 'WebService1.asmx/UpdateStudent',
                    headers: {
                        'ContentType': 'application/json; charset=utf-8',
                        'dataType': 'json'
                    },
                    //data: JSON.stringify($scope.student)
                    data: "{student:" + JSON.stringify($scope.student) + "}"
                }
                $http(http).success(function (response) {
                    $scope.fillList();
                    $scope.notshow = false;
                    Clear();
                    alert("Uppdated successfully.");
                });
            };
            $scope.fillList();
        });
   