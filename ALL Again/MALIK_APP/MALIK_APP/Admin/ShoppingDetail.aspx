<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ShoppingDetail.aspx.cs" Inherits="Admin_ShoppingDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
     <div class="pin" style="width:99%; padding:3px; ">
    <center>
       
        <div style="width: 100%;" class="detail_heading">
            <table width="100%">
                <tr>
                    <td>
                    <p>Shopping Detail</p>
                    </td>
                </tr>
            </table>
        </div>
        
            <table width="100%">
                <tr>
                    <td valign="top" width="72%">
                        <asp:TextBox ID="txtSearchTraId" runat="server" placeholder="Transaction ID" CssClass="txt_box"></asp:TextBox>&nbsp;
                        <asp:TextBox ID="txtSearchUserName" runat="server" placeholder="User Name" CssClass="txt_box"></asp:TextBox>&nbsp;
                        <asp:TextBox ID="txtDateFrom" runat="server" placeholder="From" CssClass="txt_box"></asp:TextBox>&nbsp;
                        <asp:TextBox ID="txtDateTo" runat="server" placeholder="To" CssClass="txt_box"></asp:TextBox>&nbsp;
        
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateFrom"
                            PopupButtonID="txtDateFrom" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateTo"
                            PopupButtonID="txtDateTo" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDateTo"
                            Mask="99/99/9999" MaskType="Date">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtDateFrom"
                            Mask="99/99/9999" MaskType="Date">
                        </cc1:MaskedEditExtender>
                    </td>
                    <td align="left">
                                    <asp:ImageButton ID="imgBtnSearch" runat="server" ImageUrl="~/images/Button/go.png"
                            OnClick="imgBtnSearch_Click" />
                        <asp:Label ID="LblmsgHead" ForeColor="Red" Font-Size="11px" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        
    </center>
    <center>
       
         <div style="width:100%;">
            <asp:Label ID="lblrow_id" runat="server" Visible="false" Text=""></asp:Label>
            <center>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BorderStyle="None" Width="100%" CssClass="table" AutoGenerateColumns="False"
                    EmptyDataText="Record Not Found" EmptyDataRowStyle-HorizontalAlign="Center" OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowCommand="GridView1_RowCommand" DataKeyNames="Deliver_Status">
                    <PagerSettings Mode="Numeric" />
                    <PagerStyle  CssClass="tr" HorizontalAlign="Center" ForeColor="white"  />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%=++sr %>
                            </ItemTemplate>
                            <ItemStyle Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Transaction ID" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblcate" runat="server" Text='<%# Bind("Trans_id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&nbsp;&nbsp;User Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("User_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="tt_lft" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&nbsp;&nbsp;E-mail" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("User_Email") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="tt_lft" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile No." ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Mobile_No") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&nbsp;&nbsp;Address" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="LabelQ3" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="tt_lft" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Purchase Date" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="LabelDE3" runat="server" Text='<%# Bind("Entry_Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Deliver Status" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%if (GridView1.DataKeys[index++]["Deliver_Status"].ToString() == "0")
                                  { %>
                                <asp:LinkButton ID="lnkStatus" runat="server" Text='<%# Eval("Status") %>' Width="80px"
                                    CommandName="DStatus" CommandArgument='<%#Bind("Trans_id") %>' />
                                <%} %>
                                <%else
                                    { %>
                                <asp:Label ID="lblPPStat" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                <%} %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Detail" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="ViewProduct" CommandArgument='<%#Bind("Trans_id") %>'>View</asp:LinkButton>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle CssClass="tr2" />
                     <HeaderStyle CssClass="tr" />
                   <RowStyle CssClass="tr1" />
                    <FooterStyle  />
                </asp:GridView>
            </center>
        </div>
    </center>
    <asp:Panel ID="Panel1" runat="server">
        <div class="registration">
            <div class="close">
                
                <asp:ImageButton ID="ImageButton2" CausesValidation="false" ImageUrl="../images/Button/close.png"
                    runat="server" />
            </div>
            <div class="detail_heading">
                <p>
                    Product Detail <img src="../images/Print1.png" onclick="CallPrint12('PrdDet','');" title="Print" /></p>
            </div>
            <table width="100%" id="PrdDet">            
            <tr>
            <td align="right"><strong>Transaction ID : </strong></td>
            <td><asp:Label ID="TransactionId" runat="server" Text=""></asp:Label></td>
            <td align="right"><strong>Purchase Date : </strong></td>
            <td><asp:Label ID="PurhaseDate" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            <td align="right"><strong>User Name : </strong></td>
            <td><asp:Label ID="UserName" runat="server" Text=""></asp:Label></td>
            <td align="right"><strong>Address : </strong></td>
            <td><asp:Label ID="Address" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
            <td align="right"><strong>Mobile No. : </strong></td>
            <td><asp:Label ID="MobileNo" runat="server" Text=""></asp:Label></td>
            <td align="right"><strong>Billing Amount : </strong></td>
            <td><asp:Label ID="BillingAmount" runat="server" Text=""></asp:Label></td>
            </tr>
          
                <tr>
                    <td align="center" colspan="4">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                             ShowHeader="true" BorderStyle="None" Width="100%" CssClass="table" ShowFooter="false"
                            >
                           
                            <PagerStyle  CssClass="tr" HorizontalAlign="Center" ForeColor="white"  />
                            <Columns>
                                <asp:TemplateField HeaderText="Image">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" ImageUrl='<%# Bind("Product_Image","../Admin/{0}") %>' runat="server"
                                            Height="33px" Width="42px" /></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&nbsp;&nbsp;Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblppr" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="tt_lft" HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>                               
                                <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                    </ItemTemplate>   
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center" />                                 
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsub" runat="server" Text='<%# Bind("Total_Amount")%>'></asp:Label>
                                    </ItemTemplate>                                   
                                    <ItemStyle CssClass="tt_rft" HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                
                            </Columns>
                             <AlternatingRowStyle CssClass="tr2" />
                     <HeaderStyle CssClass="tr" />
                   <RowStyle CssClass="tr1" />
                    <FooterStyle  />                   
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
      <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" CancelControlID="ImageButton2"
        TargetControlID="Label4" PopupControlID="Panel1" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    </div>
</asp:Content>
