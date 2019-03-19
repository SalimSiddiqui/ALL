<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Angular_try01.aspx.cs" Inherits="Angular_try01" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" ng-app="customersApp">
<head runat="server">
    <title>CRUD App using AngularJS</title>
    <link href="~/Content/css/ng-grid.min.css" rel="stylesheet" />
    <link href="~/Content/css/style.css" rel="stylesheet" />
    <script src="Scripts/js/jquery-1.10.1.min.js" language="javascript" type="text/javascript"></script>
    <script src="Scripts/js/angular.min.js" language="javascript" type="text/javascript"></script>
    <script src="Scripts/js/ng-grid.min.js" language="javascript" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

    </script>
    <script language="javascript" type="text/javascript">

        var customersApp = angular.module('customersApp', ['ngGrid']);
var url = 'api/Customer';

//the factory object for the webAPI call.
customersApp.factory('customerRepository', function ($http) {
    return {
        getCustomers: function (callback) {
               
            $http.get(url).success(callback);
        }
        ,
        //method for insert
        insertUser: function (callback,user) {
            var user = { "id": user.id, "city": user.city, "name": user.name, "address": user.address, "contactNo": user.contactNo, "emailId": user.emailId };
            $http.post(url, user).success(callback);
        }
            ,
        //method for update
        updateUser: function (callback,user) {
            var user = { "id": user.id, "city": user.city, "name": user.name, "address": user.address, "contactNo": user.contactNo, "emailId": user.emailId };
            alert(user.id);
            $http.put(url + '/' + user.id, user).success(callback);
        }
        ,
        //method for delete
        deleteUser: function (callback, id) {
            $http.delete(url + '/' + id).success(callback);
        }

                    
    }
});

//controller   
customersApp.controller('customerCtrl', function ($scope, customerRepository) {
    getCustomers();
    function getCustomers() {
        customerRepository.getCustomers(function (results) {
            $scope.customerData = results;
        })
    }

    $scope.setScope = function (obj, action) {
        
        $scope.action = action;
        $scope.New = obj;
    }
       
        $scope.gridOptions = {
            data: 'customerData',
            showGroupPanel: true,
            columnDefs: [{ field: 'name', displayName: 'Name' , width: '15%'},
                { field: 'city', displayName: 'City', width: '15%' },
                { field: 'address', displayName: 'Address', width: '15%' },
                { field: 'contactNo', displayName: 'Contact No', width: '15%' },
                { field: 'emailId', displayName: 'Email Id', width: '15%' },
                { displayName: 'Options', cellTemplate: '<input type="button" ng-click="setScope(row.entity,\'edit\')" name="edit"  value="Edit">&nbsp;<input type="button" ng-click="DeleteUser(row.entity.id)"  name="delete"  value="Delete">', width: '25%' }
            ]
        };

    
        $scope.update = function () {
            if ($scope.action == 'edit') {
                customerRepository.updateUser(function () {
                    $scope.status = 'customer updated successfully';
                    alert('customer updated successfully');
                    getCustomers();
                }, $scope.New)
                $scope.action = '';
            }
            else
            {
                customerRepository.insertUser(function () {
                    alert('customer inserted successfully');
                    getCustomers();
                }, $scope.New)
                
            }


        }

        $scope.DeleteUser = function (id) {
            customerRepository.deleteUser(function () {
                alert('Customer deleted');
                getCustomers();
            }, id)

        }

});


        
    </script>
</head>
<body ng-controller="customerCtrl">
    <div class="gridStyle" ng-grid="gridOptions">
    </div>
    <form name="myForm">
    <b>{{action | uppercase}} </b></br> <span><b>Customer Details</b></span>
    <table>
        <tr>
            <td>
                Id
            </td>
            <td>
                <input type="text" ng-model="New.id" />*(PLEASE ENTER UNIQUE ID)
            </td>
        </tr>
        <tr>
            <td>
                Name
            </td>
            <td>
                <input type="text" ng-model="New.name" />
            </td>
        </tr>
        <tr>
            <td>
                City
            </td>
            <td>
                <input type="text" ng-model="New.city" />
            </td>
        </tr>
        <tr>
            <td>
                Address
            </td>
            <td>
                <input type="text" ng-model="New.address" />
            </td>
        </tr>
        <tr>
            <td>
                Contact No
            </td>
            <td>
                <input type="text" ng-model="New.contactNo" />
            </td>
        </tr>
        <tr>
            <td>
                Email-Id
            </td>
            <td>
                <input type="text" ng-model="New.emailId" />
            </td>
        </tr>
    </table>
    <input id="Submit1" ng-click="update()" type="submit" value="submit" />
    </form>
</body>
</html>
