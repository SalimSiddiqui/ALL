<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NgSorting.aspx.cs" Inherits="NgSorting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/angular.js" type="text/javascript"></script>
    <script src="Scripts/js/NgDDL.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div ng-app="Demo" ng-controller="Sorting">
        <table>
            <tr>
                <td>
                    <table>
                        <thead>
                            <tr>
                                <th>
                                    BusinessEntityID
                                </th>
                                <th>
                                    First Name
                                </th>
                                <th>
                                    Last Name
                                </th>
                                <th>
                                    Date
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr ng-repeat="person in persons">
                                <td>
                                    {{person.BusinessEntityID}}
                                </td>
                                <td>
                                    {{person.FirstName}}
                                </td>
                                <td ng-bind="person.LastName">
                                  
                                </td>
                                <td >
                                 
                                </td>
                            </tr>
                        </tbody>
                    </table>
    </div>
    </form>
</body>
</html>
