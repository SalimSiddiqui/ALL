<%@ Page Language="VB" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="Admin_login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Welcome To Malik Associates </title>
    <link href="../StyleSheet/styles.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet/menu_style.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="WOW Slider, 3d jQuery Slider, jQuery Slider 3d" />
    <meta name="description" content="WOWSlider created with WOW Slider, a free wizard program that helps you easily generate beautiful web slideshow" />
    <!-- Start WOWSlider.com HEAD section -->
    <link rel="stylesheet" type="text/css" href="../banner/engine1/style.css" />
    <style type="text/css">
        a#vlb
        {
            display: none;
        }
    </style>

    <script type="text/javascript" src="../banner/engine1/jquery.js"></script>

    <script type="text/javascript" src="../banner/engine1/wowslider.js"></script>

    <!-- End WOWSlider.com HEAD section -->
</head>
<body>
    <form id="form1" runat="server">
    <!--header starts-->
    <div id="header_p" style="border-bottom:1px solid #069;">
        <div id="header">
            <div class="logoarrange">
            </div>
            <%--<div class="h_menu right_drag">
                <div class="menu_container">
<ul>
<li>
<div class="main_list">
<div class="one"></div>
<div class="two"><a href="../Member/index.aspx">Home</a></div>
<div class="three"></div>
</div>
</li>

<li>
<div class="main_list">
<div class="one"></div>
<div class="two"><a href="../Member/Service.aspx">Services </a></div>
<div class="three"></div>
</div>
</li>


<li>
<div class="main_list">
<div class="one"></div>
<div class="two"><a href="../Member/Portfolio.aspx">Portfolio</a></div>
<div class="three"></div>
</div>
</li>

<li>
<div class="main_list">
<div class="one"></div>
<div class="two"><a href="../Member/Testimonial.aspx">Testimonial </a></div>
<div class="three"></div>
</div>
</li>

<li>
<div class="main_list">
<div class="one"></div>
<div class="two"><a href="../Member/Blog.aspx">Blog </a></div>
<div class="three"></div>
</div>
</li>


<li>
<div class="main_list">
<div class="one"></div>
<div class="two"><a href="../Member/ContactUs.aspx">Contact Us </a></div>
<div class="three"></div>
</div>
</li>







</ul>


</div>
            </div>--%>
        </div>
    </div>
    <!--header close-->
    <!--banner starts-->
    <%--<div id="banner_p">
        <div id="banner">
            <div class="swf">
               
                <div id="wowslider-container1">
                    <div class="ws_images">
                        <span>
                            <img src="../banner/data1/images/banner1.jpg" alt="banner1" title="banner1" id="wows0" /></span>
                        <span>
                            <img src="../banner/data1/images/banner2.jpg" alt="banner2" title="banner2" id="wows1" /></span>
                     
                    </div>
                    <div class="ws_bullets">
                        <div>
                            <a href="#wows0" title="banner1">
                                <img src="../banner/data1/tooltips/banner1.jpg" alt="banner1" />1</a> <a href="#wows1"
                                    title="banner2">
                                    <img src="../banner/data1/tooltips/banner2.jpg" alt="banner2" />2</a> 
                        </div>
                    </div>
                    <a style="display: none" href="http://wowslider.com">jQuery Slider With Caption by WOWSlider.com
                        v2.0</a>
                </div>

                <script type="text/javascript" src="../banner/engine1/script.js"></script>

               
            </div>
        </div>
    </div>--%>
    <!--banner close-->
    <div id="container">
        <!--content starts-->
        <div id="content" style="min-height:475px;">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />


            <div class="for_password" style="background: #fff; -webkit-border-radius: 10px; -moz-border-radius: 10px;
                border-radius: 10px; padding:2px;">
                <!--third box-->
                <div class="detail_heading">
                    <p>
                        Administrator Login
                        <asp:Label ID="lbladminmsg" runat="server" ForeColor="Red" Font-Size="11px"></asp:Label></p>
                </div>
                <br />
                <div class="member11">
                    <table width="100%" border="0" cellspacing="2" cellpadding="2">
                        <tr>
                            <td width="30%" align="right" valign="top">
                                <strong>Login Type </strong>
                            </td>
                            <td align="right" style="width: 1%;" valign="top">
                                <strong>:</strong>
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="ddllogintyp" CssClass="txt_box" Width="162px" runat="server">
                                    <asp:ListItem Value="admin">Admin</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" align="right" valign="top">
                                <strong>User Name </strong>
                            </td>
                            <td align="right" style="width: 1%;" valign="top">
                                <strong>:</strong>
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="TextBox3" runat="server" MaxLength="40" CssClass="txt_box"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="TextBox3" CssClass="content1" ErrorMessage="*"
                                    ID="RequiredFieldValidator1" runat="server" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="12"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" align="right" valign="top">
                                <strong>Password</strong></span>
                            </td>
                            <td align="right" style="width: 1%;" valign="top">
                                <strong>:</strong>
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" MaxLength="40" CssClass="txt_box">admin</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox4"
                                    CssClass="content1" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="12"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" align="right" valign="middle">
                                &nbsp;
                            </td>
                            <td align="right" valign="middle">
                            </td>
                            <td align="left" valign="top">
                                <asp:ImageButton ID="ImageButton1" runat="server" ValidationGroup="12" ImageUrl="~/images/Button/login.png" />
                            </td>
                        </tr>
                    </table>
                </div>
                <!--third box-->
            </div>
        </div>
    </div>
    <div id="footer_p">
        <div id="footer">
            <div class="f_menu left_drag">
                <a href="#">Home</a><span>|</span> <a href="#">About Us</a><span>|</span> <a href="#">
                    Terms &amp; Conditions</a><span>|</span> <a href="#">Privacy Policy</a><span>|</span>
                <a href="#">Legal</a><span>|</span> <a href="#">FAQs</a><span>|</span> <a href="#">Franchisee</a><span>|</span>
                <a href="#">Contact</a>
                <p>
                    © 2010 Malik Associates | <a href="#">Terms of service</a> | <a href="#">Privacy policy</a>
                </p>
            </div>
            <div class="followUs right_drag">
                <div class="labs">
                    <label class="labs">
                        Connect with us:</label>
                </div>
                <div class="labs">
                    <a href="#">
                        <img src="../images/tweeter.png" alt="Tweeter" title="Tweeter" /></a> <a href="#">
                            <img src="../images/fb.png" alt="Facebook" title="Facebook" /></a> <a href="#">
                                <img src="../images/linkedin.png" alt="Linkedin" title="Linkedin" /></a>
                    <a href="#">
                        <img src="../images/mail.png" alt="Google Plus" title="Google Plus" /></a>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
