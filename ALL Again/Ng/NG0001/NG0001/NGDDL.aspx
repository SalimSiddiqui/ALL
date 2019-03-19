<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NGDDL.aspx.cs" Inherits="NGDDL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/angular.js" type="text/javascript"></script>
    <script src="Scripts/js/NgDDL.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body ng-app="Demo">
    <form id="form1" runat="server">
    <div ng-controller="MyCtrl">
        <table class="style1">
            <tr>
                <td>
                    <table>
                        <thead>
                            <tr>
                                <th>
                                    Department Id
                                </th>
                                <th>
                                    Department Name
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr ng-repeat="depart in Department">
                                <td>
                                    {{depart.Id}}
                                </td>
                                <td>
                                    {{depart.Dep| uppercase}}
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td valign="top">
                    <select  ng-model="selectitem">
                        <option>-------Select----------</option>
                        <option ng-repeat="depart in Department" value="{{depart.Id}}">{{depart.Dep}}</option>
                    </select>
                    {{selectitem}}
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
