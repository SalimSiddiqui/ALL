<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="Services" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/angular.js" type="text/javascript"></script>
    <script src="Scripts/js/NgServices.js" type="text/javascript"></script>

</head>
<body ng-app="mainapp">
    <form id="form1" runat="server">
    <div ng-controller="GetnumderCtrl">
    <input id="Button1" type="button" value="button" ng-click="GenerateNumber()" />
    {{randomnumber}}||{{rand}}
    </div>

    <div ng-controller="GetnumderCtrl2">
    <input id="Button2" type="button" value="button" ng-click="GenerateNumber2()" />
    {{randomnumber2}}
    </div>
    

    <div ng-controller="GetnumderCtrl3">
    <input id="Button3" type="button" value="button" ng-click="GenerateNumber3()" />
    {{randomnumber3}}
    </div>
     <div ng-controller="GetnumderCtrl4">    
    {{randomnumber4}}
    </div>


    <div ng-controller="MyCtrl"> <label>Name (two-way binding): 
    <input type="text" ng-model="name" /></label> <strong>Your name (one-way binding):</strong> {{::name}}<br /> <strong>Your name (normal binding):</strong> {{name}} </div>
    </form>
</body>
</html>
