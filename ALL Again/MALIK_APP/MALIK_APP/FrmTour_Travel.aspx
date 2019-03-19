<%@ Page Title="" Language="C#" MasterPageFile="~/Tour_Travel.master" AutoEventWireup="true" CodeFile="FrmTour_Travel.aspx.cs" Inherits="FrmTour_Travel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="main_content">
        <div class="packages_cont">
            <div class="packages">
                <div class="package_heading">
                    Popular Packages</div>
              <%--  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="53%" rowspan="4">
                            <div class="package_image">
                            <a href="FrmTravel_Detail.aspx">
                                <img src="images/package_img.png" width="120" height="75" /></a></div>
                        </td>
                        <td>
                            <p class="airline_name">
                                King Fisher</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_duration">
                                7 Days and 6 Nights</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_price">
                                INR 2500/-</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_per_cost">
                                INR per person</p>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="53%" rowspan="4">
                            <div class="package_image">
                                <a href="FrmTravel_Detail.aspx">
                                <img src="images/package_img.png" width="120" height="75" /></a></div>
                        </td>
                        <td>
                            <p class="airline_name">
                                King Fisher</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_duration">
                                7 Days and 6 Nights</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_price">
                                INR 2500/-</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_per_cost">
                                INR per person</p>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="53%" rowspan="4">
                            <div class="package_image">
                                <a href="FrmTravel_Detail.aspx">
                                <img src="images/package_img.png" width="120" height="75" /></a></div>
                        </td>
                        <td>
                            <p class="airline_name">
                                King Fisher</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_duration">
                                7 Days and 6 Nights</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_price">
                                INR 2500/-</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_per_cost">
                                INR per person</p>
                        </td>
                    </tr>
                </table>
                <div class="more">
                    <a href="#">More...</a></div>--%>
                    <%=first.ToString()%>
         </div>
            <div class="packages mid">
                <div class="package_heading">
                    Latest Flight Deals</div>
              <%--  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="53%" rowspan="4">
                            <div class="package_image">
                                <a href="FrmTravel_Detail.aspx">
                                <img src="images/package_img.png" width="120" height="75" /></a></div>
                        </td>
                        <td>
                            <p class="airline_name">
                                King Fisher</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_duration">
                                7 Days and 6 Nights</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_price">
                                INR 2500/-</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_per_cost">
                                INR per person</p>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="53%" rowspan="4">
                            <div class="package_image">
                                <a href="FrmTravel_Detail.aspx">
                                <img src="images/package_img.png" width="120" height="75" /></a></div>
                        </td>
                        <td>
                            <p class="airline_name">
                                King Fisher</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_duration">
                                7 Days and 6 Nights</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_price">
                                INR 2500/-</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_per_cost">
                                INR per person</p>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="53%" rowspan="4">
                            <div class="package_image">
                                <a href="FrmTravel_Detail.aspx">
                                <img src="images/package_img.png" width="120" height="75" /></a></div>
                        </td>
                        <td>
                            <p class="airline_name">
                                King Fisher</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_duration">
                                7 Days and 6 Nights</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_price">
                                INR 2500/-</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_per_cost">
                                INR per person</p>
                        </td>
                    </tr>
                </table>
                <div class="more">
                    <a href="#">More...</a></div>--%>
                    <%=second.ToString()%>
            </div>
            <div class="packages last">
                <div class="package_heading">
                    Special Offers</div>
               <%-- <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="53%" rowspan="4">
                            <div class="package_image">
                                <a href="FrmTravel_Detail.aspx">
                                <img src="images/package_img.png" width="120" height="75" /></a></div>
                        </td>
                        <td>
                            <p class="airline_name">
                                King Fisher</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_duration">
                                7 Days and 6 Nights</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_price">
                                INR 2500/-</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_per_cost">
                                INR per person</p>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="53%" rowspan="4">
                            <div class="package_image">
                                <a href="FrmTravel_Detail.aspx">
                                <img src="images/package_img.png" width="120" height="75" /></a></div>
                        </td>
                        <td>
                            <p class="airline_name">
                                King Fisher</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_duration">
                                7 Days and 6 Nights</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_price">
                                INR 2500/-</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_per_cost">
                                INR per person</p>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="53%" rowspan="4">
                            <div class="package_image">
                                <a href="FrmTravel_Detail.aspx">
                                <img src="images/package_img.png" width="120" height="75" /></a></div>
                        </td>
                        <td>
                            <p class="airline_name">
                                King Fisher</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_duration">
                                7 Days and 6 Nights</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_price">
                                INR 2500/-</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="package_per_cost">
                                INR per person</p>
                        </td>
                    </tr>
                </table>
                <div class="more">
                    <a href="#">More...</a></div>--%>
                    <%=third.ToString()%>
            </div>
        </div>
    </div>
</asp:Content>

