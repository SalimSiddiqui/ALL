<%@ Page Title="" Language="C#" MasterPageFile="~/PropertyMaster.master" AutoEventWireup="true" CodeFile="FrmReal_Estate.aspx.cs" Inherits="FrmReal_Estate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="right">
                <div class="welcome properties">
                    <p class="heading">
                        Our Properties</p>
                    <div class="welcome_content">
                        <p>
                            Malik Real Estate is a team of dedicated and talented individuals with an experience
                            of more than a decade in providing lands, flats and offices in very attractive price
                            which suits your budget and our latest venture of Malik Real Estate is at the forefront
                            of providing services in the field of property and Real Estate through online portals
                            in all over UAE and India so any property land or flat holders can register their
                            property on our web portal for buying, selling, renting and leasing purpose.</p>
                        <p>
                            Malik Real Estate and Properties was created with one goal in mind to strive to
                            present a standard of real estate services yet to be offered through our unsurpassed
                            customer service and unique licenses in place. As one of the pioneers in the real
                            estate market, we offer Property Management, Advisory, Valuations and certified
                            sales and leasing brokerage, confidently offering our clients services that no other
                            company can match.</p>
                        <p>
                            Our Property Consultants, Contractors and Architects are fully trained to cater
                            to your real estate needs. Whether you are looking to buy, sell or rent, we offer
                            all the services that you require as our client. So come with Malik Real Estate
                            for your property needs and we assure you to provide best services and cost effective
                            flats and other properties and we are committed to save you both time and money.
                        </p>
                    </div>
                </div>
                <div class="clr">
                </div>
                <div class="example-wrapper">
                    <p class="slider_heading">
                        FEATURED PROPERTIES</p>
                    <div class="clr">
                    </div>
                    <br />
                    <div id="services-example-1" class="theme1">
                        <ul style="visibility: visible !important">
                           <%=PropertiesAdd.ToString()%>
                        </ul>
                        <!--	###############		-	TOOLBAR (LEFT/RIGHT) BUTTONS	-	###############	 -->
                        <div class="toolbar">
                            <div class="left">
                            </div>
                            <div class="right">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clr">
                </div>
            </div>
</asp:Content>

