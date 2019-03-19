<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="TestNgDemo.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
     
    <script src="Scripts/angular.min.js" type="text/javascript"></script>
    <script>

        var app = angular.module("myApp", [])
        app.controller("Myctrl", function ($scope, $http) {


            GetAllRecords();
            function GetAllRecords()
            {
                $http.get('http://localhost:19742/WebService/Employee.asmx/GetEmployees').then(function (response) { $scope.EmployeeData = response.data; }, function () { alert("Failed TO Get Records") });
            }


            $scope.Insert = function (formdata)
            {
                var Id = formdata.Id;
                var Name = formdata.Name;
                var Gender = formdata.Gender;
                var Salary = formdata.Salary;
               
                $http.get('http://localhost:19742/WebService/Employee.asmx/AddEmployee',
             {
                 params: { Id: Id, Name: Name, Gender: Gender, Salary: Salary },

             }
         ).then(function (res) { alert("Success Fully Inserted"); GetAllRecords(); }, function () { alert("Failed Insert Record"); });

            }



            $scope.Update = function (formdata)
            {


                var Id = formdata.Id;
                var Name = formdata.Name;
                var Gender = formdata.Gender;
                var Salary = formdata.Salary;

                $http.get('http://localhost:19742/WebService/Employee.asmx/UpdateEmployee',
             {
                 params: { Id: Id, Name: Name, Gender: Gender, Salary: Salary },

             }
         ).then(function (res) { alert("Success Fully Updated"); GetAllRecords(); }, function () { alert("Failed Update Record"); });



            }

            //Eiti Logic
            $scope.EditRecord = function (index) {
                alert("hi");
                $scope.Employee = { Id: $scope.EmployeeData[index].Id, Name: $scope.EmployeeData[index].Name, Gender: $scope.EmployeeData[index].Gender, Salary: $scope.EmployeeData[index].Salary }


            }




            //Deletion Logi
            $scope.DeleteEmp=function(Id)
            {
                alert(Id);

                $http.get('http://localhost:19742/WebService/Employee.asmx/DeleteEmployee',
          {
              params: { Id: Id },

          }
      ).then(function (res) { alert("Delete record is SUccess"); GetAllRecords(); }, function () { alert("Failed to Delete Record"); });


            }


            });
      </script>


</head>
<body ng-app="myApp" ng-controller="Myctrl">

    <%--<table border="1">
        <tr ng-repeat="item in EmployeeData">
            <td>{{item.Id}}</td>
            <td>{{item.Name}}</td>
            <td>{{item.Gender}}</td>
            <td>{{item.Salary}}</td>
            <td><input type="button" ng-click="DeleteEmp(item.Id)" value="Delete" /></td>
            <td><input type="button" ng-click="EditRecord($index)" value="Edit" /></td>
        </tr>
    </table>--%>
    <br />
    <input type="text" ng-model="Employee.Id" placeholder="Enter Employee Id" /><br />
    <input type="text" ng-model="Employee.Name" placeholder="Enter Employee Name" /><br />
    <input type="text" ng-model="Employee.Gender" placeholder="Enter Employee Gender" /><br />
    <input type="text" ng-model="Employee.Salary" placeholder="Enter Employee Salary" /><br />

    <input type="button" ng-click="Insert(Employee)" value="Insert Record">
    <input type="button" ng-click="Update(Employee)" value="Update Record">

</body>
</html>
