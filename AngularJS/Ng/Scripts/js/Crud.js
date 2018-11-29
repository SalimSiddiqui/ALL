
/// <reference path="../angular.js" />


 
 
        var app = angular.module("myApp", [])
        app.controller("myCntrl", function ($scope, $http) {
            $scope.studentorder = "StudetnID";
            $scope.studetnName = "";
            $scope.Save = function () {
                var httpreq = {
                    method: 'POST',
                    url: 'WebService/DDL_Service.asmx/Save',
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                        'dataType': 'json'
                    },
                    data: { StudentName: $scope.studetnName }
                }
                $http(httpreq).success(function (response) {
                    $scope.fillList();
                    alert("Saved successfully.");
                })
            };
            $scope.Delete = function (SID) {
                if (confirm("Are you sure want to delete?")) {
                    var httpreq = {
                        method: 'POST',
                        url: 'Default.aspx/Delete',
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
            //            $scope.fillList = function () {
            //                $scope.studetnName = "";
            //                var httpreq = {
            //                    method: 'POST',
            //                    url: 'WebService/DDL_Service.asmx/GetList',
            //                    headers: {
            //                        'Content-Type': 'application/json; charset=utf-8',
            //                        'dataType': 'json'
            //                    },
            //                    data: {}
            //                }
            //                $http(httpreq).success(function (response) {

            //                    $scope.StudentList = response.d;
            //                })
            //            };


            $scope.Select = function (SID) {
                alert('62');
                var httpreq = {
                    method: 'POST',
                    url: 'WebService/DDL_Service.asmx/Select',
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                        'dataType': 'json'
                    },
                    data: { StudentID: SID }
                }
                $http(httpreq).success(function (response) {
                    $scope.studetnName = response.d[0].StudentName;
                    $scope.stuid = response.d[0].StudentID;
                    $scope.upshow = true;

                })

            };



            $scope.Update = function () {
                var httpreq = {
                    method: 'POST',
                    url: 'Default.aspx/Update',
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                        'dataType': 'json'
                    },
                    data: { StudentName: $scope.studetnName, StudentID: $scope.stuid
                    }
                }
                $http(httpreq).success(function (response) {
                    $scope.fillList();
                    $scope.upshow = false;
                    alert("Upate successfully.");
                })
            };


            $scope.fillList();
        });

        app.controller("myCntrl", function ($scope, $http) {
            alert('ass');
            $http.get("WebService/DDL_Service.asmx/GetList").then(function (response) {
                $scope.StudentList = response.data;

            });


            $scope.Select = function (SID) {
                alert('112');
                var httpreq = {
                    method: 'GET',
                    url: 'WebService/DDL_Service.asmx/Select',
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                        'dataType': 'json'
                    },
                    params: { StudentID: JSON.stringify(SID) }

                }
                $http(httpreq).success(function (response) {
                    return response;

                })

            };


            $scope.Save = function ($scope, $http) {
                var httpreq = {
                    method: 'POST',
                    url: 'WebService/DDL_Service.asmx/Save',
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                        'dataType': 'json'
                    },
                    data: { studetnName: $scope.StudentName }
                }
                alert($scope.StudentName)
                console.log('Car Name=' + $scope.StudentName);
                $http(httpreq).success(function (response) {
                    //   $scope.fillList();
                    alert("Saved successfully.");
                })
            };



        });


      




    
