<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TestNgDemo.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/angular.min.js" type="text/javascript"></script>
    <script src="Scripts/JScript.js" type="text/javascript"></script>
    <title></title>
</head>
<body ng-app="demoapp">
    <form id="form1" runat="server">
    <div ng-controller="democtrl">

        <asp:Button ID="Button1" runat="server" Text="Button" ng-click="Insert()" />
        {{mess}}
    </div>
    </form>
</body>
</html>
