<%@ Page Title="" Language="C#" MasterPageFile="~/Tour_Travel.master" AutoEventWireup="true" CodeFile="FrmTravel_Detail.aspx.cs" Inherits="FrmTravel_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="main_content">
            <div class="left">
                <div class="news">
                    <p class="heading">
                        Recent News</p>
                    <div class="outer">
                        <ul class="vertical-ticker">
                           <%=ShowDate.ToString() %>
                        </ul>
                    </div>
                </div>
                <div class="associates">
                    <p class="heading">
                        Our Associates</p>
                    <div class="associates_outer">
                        <ul class="vertical-ticker_associates">
                            <li>
                                <div>
                                    <img src="images/eldico.png" width="170" height="90" /></div>
                            </li>
                            <li>
                                <div>
                                    <img src="images/omaxe.png" width="170" height="90" /></div>
                            </li>
                            <li>
                                <div>
                                    <img src="images/dlf.png" width="170" height="90" /></div>
                            </li>
                            <li>
                                <div>
                                    <img src="images/eldico.png" width="170" height="90" /></div>
                            </li>
                            <li>
                                <div>
                                    <img src="images/omaxe.png" width="170" height="90" /></div>
                            </li>
                            <li>
                                <div>
                                    <img src="images/dlf.png" width="170" height="90" /></div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="right">
                <div class="example-wrapper adjust">
                    <p class="detail_heading">
                        Flight Detail</p>
                    <div class="property_outer">
                        <div class="property_detail">
                            <div class="property_image">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="center" colspan="3">
                                            <div class="prop_image_cont">
                                                <img src="<%=Image %>" width="240" height="151" /></div>
                                        </td>
                                    </tr>                                    
                                </table>
                            </div>
                            <div class="property_content">
                                <p class="prop_name">
                                    <%=flightname %></p>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            City From:
                                        </td>
                                        <td class="td_cont">
                                            Chandausi
                                        </td>
                                        <td>
                                            City To:
                                        </td>
                                        <td class="td_cont">
                                            Mumbai
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Date Time:
                                        </td>
                                        <td class="td_cont rs">
                                           <%=Remark %>
                                        </td>
                                        <td>
                                            Ticket:
                                        </td>
                                        <td class="td_cont">
                                            INR <%=price %>/-
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                           <%=Overview %><br />
                                            <!--popup -->
                                            <a href="#login-box" class="login-window">
                                                <p class="enquiry login-window">
                                                    Enquiry</p>
                                            </a>
                                            <div id="login-box" class="login-popup">
                                                <a href="#" class="close">
                                                    <img src="images/close_pop.png" class="btn_close" title="Close Window" alt="Close" /></a>
                                                <div class="enquiry_heading">
                                                    Enquiry Form</div>
                                                <div class="enquiry_content">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="top">
                                                                <p>
                                                                    Name:</p>
                                                            </td>
                                                            <td>
                                                                <input name="name" type="text" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <p>
                                                                    Address:</p>
                                                            </td>
                                                            <td>
                                                                <textarea name="address" cols="" rows="">&nbsp;</textarea>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <p>
                                                                    Email:</p>
                                                            </td>
                                                            <td>
                                                                <input name="name" type="text" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <p>
                                                                    Remarks:</p>
                                                            </td>
                                                            <td>
                                                                <textarea name="address" cols="" rows="">&nbsp;</textarea>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                            </td>
                                                            <td>
                                                                <button type="submit">
                                                                    Submit</button>
                                                                <button type="reset">
                                                                    Reset</button>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                            <!--end popup -->
                                            <p class="download">
                                                <a href="#">Download</a></p>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="clr">
                    </div>
                </div>
            </div>
        </div>
        <div class="clr">
        </div>
</asp:Content>

