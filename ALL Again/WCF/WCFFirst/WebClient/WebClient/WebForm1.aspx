﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebClient.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <fieldset style="width: 287px; height: 42px;">
    <legend>Client</legend>
    <div style="width: 50px">
        <asp:TextBox ID="txt" runat="server"></asp:TextBox>
        <asp:Button ID="btngetmsg" runat="server" Text="GetMessage" 
            onclick="btngetmsg_Click"/>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div>

    </fieldset>

    <fieldset style="width: 287px; height: 42px">
    <legend>Client</legend>

        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />

    </fieldset>
    </form>
</body>
</html>
