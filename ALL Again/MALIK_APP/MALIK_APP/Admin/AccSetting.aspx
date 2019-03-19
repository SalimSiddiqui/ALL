<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AccSetting.aspx.cs" Inherits="admin_AccSetting"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="first_in" style="background:#fff">
            <div class="detail_heading">                
                    <table width="100%">
                    <tr>
                    <td width="30%"><p>Change Password</p></td>
                    <td ><asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label></td>
                    </tr>
                    </table>
            </div>
            <table cellspacing="2" cellpadding="1">
                <tr>
                    <td align="right" width="40%">
                        <strong>Old Password : </strong>
                    </td>
                    <td>
                        <asp:TextBox  TextMode="Password" ID="txtold" CssClass="txt_box" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <strong>New Password : </strong>
                    </td>
                    <td>
                        <asp:TextBox TextMode="Password" CssClass="txt_box" ID="txtnew" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <strong>Confirm New Password : </strong>
                    </td>
                    <td>
                        <asp:TextBox TextMode="Password" CssClass="txt_box" ID="txtcon" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtnew"
                            ControlToValidate="txtcon" ErrorMessage="Missmatch"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        
                    </td>
                    <td>
                        <asp:ImageButton ID="btnchange" ImageUrl="~/images/Button/passwod.png" runat="server"
                            OnClick="btnchange_Click" />
                        &nbsp;
                        <asp:ImageButton ID="ImageButton1" OnClientClick="return resetField()" ImageUrl="~/images/Button/cancel.png"
                            runat="server" OnClick="ImageButton1_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
