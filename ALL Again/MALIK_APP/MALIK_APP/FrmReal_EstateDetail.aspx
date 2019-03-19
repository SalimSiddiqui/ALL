<%@ Page Title="" Language="C#" MasterPageFile="~/PropertyMaster.master" AutoEventWireup="true" CodeFile="FrmReal_EstateDetail.aspx.cs" Inherits="FrmReal_EstateDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <div class="right">
    <div class="example-wrapper adjust">
                  <p class="detail_heading">Property Detail</p>
                  <div class="property_outer">
        <div class="property_detail">
                      <div class="property_image">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                <td align="center" colspan="3"><div class="prop_image_cont"><img src="images/prop_image1.png" width="240" height="151" /></div></td>
              </tr>
                          <tr>
                <td><div class="thumb_cont"><img src="images/prop_thumb1.png" width="65" height="41" /></div></td>
                <td><div class="thumb_cont"><img src="images/prop_thumb1.png" width="65" height="41" /></div></td>
                <td><div class="thumb_cont"><img src="images/prop_thumb1.png" width="65" height="41" /></div></td>
              </tr>
                        </table>
          </div>
                      <div class="property_content">
            <p class="prop_name">4545 Sabadell ST Las Vegas, NV 89450</p>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                <td>City:</td>
                <td class="td_cont">Chandausi</td>
                <td>Area:</td>
                <td class="td_cont">2700 Sq. Ft.</td>
              </tr>
                          <tr>
                <td>Price:</td>
                <td class="td_cont rs">INR 60,00,000</td>
                <td>Status:</td>
                <td class="td_cont">For Sale</td>
              </tr>
                          <tr>
                <td colspan="4">24 Stories building, build on 4000 sq meter area, loacted near Jagrani Hospital, ring road.  24 Stories building, build on 4000 sq meter area, loacted near Jagrani Hospital, ring road.  24 Stories building, build on 4000 sq meter area, loacted near Jagrani Hospital, ring road.  24 Stories building, build on 4000 sq meter area, loacted near Jagrani Hospital, ring road.  24 Stories building, build on 4000 sq meter area, loacted near Jagrani Hospital, ring road.<br />
                              
                              <!--popup --> 
                              <a href="#login-box" class="login-window">
                  <p class="enquiry login-window">Enquiry</p>
                  </a>
                              
                              
                              <p class="download"><a href="#">Download</a></p></td>
              </tr>
                        </table>
          </div>
                    </div>
      </div>
                  <div class="clr"></div>
                </div>
  </div>
  <div id="login-box" class="login-popup"> <a href="#" class="close"><img src="images/close_pop.png" class="btn_close" title="Close Window" alt="Close" /></a>
                    <div class="enquiry_heading">Enquiry Form</div>
                    <div class="enquiry_content">
                                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                                      <td valign="top"><p>Name:</p></td>
                                      <td><input name="name" type="text" /></td>
                                    </tr>
                        <tr>
                                      <td valign="top"><p>Address:</p></td>
                                      <td><textarea name="address" cols="" rows="">&nbsp;</textarea></td>
                                    </tr>
                        <tr>
                                      <td valign="top"><p>Email:</p></td>
                                      <td><input name="name" type="text" /></td>
                                    </tr>
                        <tr>
                                      <td valign="top"><p>Remarks:</p></td>
                                      <td><textarea name="address" cols="" rows="">&nbsp;</textarea></td>
                                    </tr>
                        <tr>
                                      <td valign="top"></td>
                                      <td><button type="submit">Submit</button>
                            <button type="reset">Reset</button></td>
                                    </tr>
                      </table>
                                </div>
                  </div>
                              
                              <!--end popup -->
</asp:Content>

