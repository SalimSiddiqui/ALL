<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="right">
      <div class="our_ventures" style="float:left;">
        <p class="heading" style="margin-bottom:10px;">Our Ventures</p>
        <div id="allinone_carousel_powerful">
          <div class="myloader"></div>
          <!-- CONTENT -->
          <ul class="allinone_carousel_list">
            <li><img src="images/malik_tours.png" width="216" height="189" alt="" /></li>
            <li><img src="images/recharge_world.png" alt="" /></li>
            <li><img src="images/it_solutions.png" alt="" /></li>
            <li><img src="images/real_estate.png" alt="" /></li>
            <li><img src="images/gktrading.png" alt="" /></li>
          </ul>
        </div>
      </div>
      <div class="content_sep"></div>
      <div class="our_services" style="float:right;">
        <p class="heading">Our Services</p>
        <div id="slideshow"> <img src="images/jewellry.png" width="216px" height="189px" alt="Slideshow Image 1" class="active" /> <img src="images/it_solutions.png" alt="Slideshow Image 2" /> <img src="images/malik_tours.png" alt="Slideshow Image 3" /> <img src="images/recharge_world.png" alt="Slideshow Image 4" /> </div>
      </div>
      <div class="clr"></div>
      <div class="welcome">
        <p class="heading">Welcome to Malik Associates</p>
        <div class="welcome_content">
          <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>
          <div class="continue"> <a href="#">Continue Reading.....</a></div>
        </div>
      </div>
    </div>
</asp:Content>

