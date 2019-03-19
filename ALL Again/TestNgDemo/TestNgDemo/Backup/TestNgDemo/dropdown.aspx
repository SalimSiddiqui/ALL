<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dropdown.aspx.cs" Inherits="TestNgDemo.dropdown" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/angular.min.js" type="text/javascript"></script>
    <script src="Scripts/JScript.js" type="text/javascript"></script>
    <script src="Scripts/Fillddl.js" type="text/javascript"></script>
</head>
<body ng-app="myApp">
    <form id="form1" runat="server">
    <div ng-controller="ddlctrl">
        <%--<select id="select" ng-repeat="item in countryList">
    <option value={{item.StudentID}}>{{item.StudentName}}</option>
    </select>--%>
         
           
            <select name="users" ng-options="user.StudentID as user.StudentName for user in StudentList" ng-model="user.StudentID" ng-change="fillCity(user.StudentID)">
                <option value="">--Select User--</option>
            </select>
            <select name="userss" ng-options="users.StudentID as users.StudentName for users in StudentListCity"  ng-model="users.StudentID" ng-change="fillMoh(user.StudentID)" >
                <option value="">--Select User--</option>
            </select>
            <select name="userss" ng-options="users.StudentID as users.StudentName for users in StudentListMoh"  ng-model="users.a" >
                <option value="">--Select User--</option>
            </select>

    </div>
    </form>
</body>
</html>
