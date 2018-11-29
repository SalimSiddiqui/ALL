<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DropDownDemo.aspx.cs" Inherits="DropDownDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/js/angular.min.js"></script>
    <script src="Scripts/angular.intellisense.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        var phonecatApp = angular.module('phonecatApp', [])

        phonecatApp.controller('PhoneListCtrl', function ($scope) {
            $scope.phones = [
    { 'name': 'Nexus S',
        'snippet': 'Fast just got faster with Nexus S.',
        'age': 1
    },
    { 'name': 'Motorola XOOM™ with Wi-Fi',
        'snippet': 'The Next, Next Generation tablet.',
        'age': 2
    },
    { 'name': 'MOTOROLA XOOM™',
        'snippet': 'The Next, Next Generation tablet.',
        'age': 3
    }
  ];

            $scope.orderProp = 'age';
        });
    </script>
</head>
<body>
    <form id="form1" runat="server" ng-app="phonecatApp">
    <div ng-model="PhoneListCtrl">
        Search:
        <input ng-model="query">
        Sort by:
        <select ng-model="orderProp">
            <option value="name">Alphabetical</option>
            <option value="age">Newest</option>
        </select>
    </div>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
