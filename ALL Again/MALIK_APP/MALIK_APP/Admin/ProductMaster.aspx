<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ProductMaster.aspx.cs" Inherits="Admin_ProductMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
       <div class="pin" style="width:99%; padding:3px; ">
    
    <center>
        
        <div style="width: 100%;" class="detail_heading">
            <table width="100%">
                <tr>                    
                    <td><p>Product Master</p></td>
                    <td style="text-align: right;">
                        <asp:ImageButton ID="ImageButton1" ImageUrl="../images/Button/document-new.png" runat="server"
                            OnClick="ImageButton1_Click" ToolTip="Add New" />
                    </td>
                </tr>
            </table>
           </div> 

            <table width="100%" style="margin-bottom:8px;">
                <tr>
               
                    <td valign="top" width="36%">
                        <asp:TextBox ID="txtSearchProid" runat="server" placeholder="Product Code" CssClass="txt_box"></asp:TextBox>&nbsp;
                        <asp:TextBox ID="txtSearchProName" runat="server" placeholder="Product Name" CssClass="txt_box"></asp:TextBox>&nbsp;
                        
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
        <%--<div style="height: 5px; width: 100%;">
        </div>--%>
        <div style="width:100%;">
            <asp:Label ID="lblrow_id" runat="server" Visible="false" Text=""></asp:Label>
            <center>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" Width="100%" CssClass="table" AutoGenerateColumns="False"
                    EmptyDataText="Record Not Found" BorderStyle="None" EmptyDataRowStyle-HorizontalAlign="Center" OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowCommand="GridView1_RowCommand">
                    <PagerSettings Mode="Numeric" />
                    <PagerStyle  CssClass="tr" HorizontalAlign="Center" ForeColor="white"  />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%=++sr %>
                            </ItemTemplate>
                            <ItemStyle Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Code" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblcate" runat="server" Text='<%# Bind("Produt_Code") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&nbsp;&nbsp;Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                            <ItemStyle CssClass="tt_lft" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actual Price" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Product_Price") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="tt_rft" HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Offer Price" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Offer_Price") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="tt_rft" HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="LabelQ3" runat="server" Text='<%# Bind("Product_Qty") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&nbsp;&nbsp;Description" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="LabelDE3" runat="server" Text='<%# Bind("Product_Description") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="tt_lft" HorizontalAlign="Justify" Width="380px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="50px" ImageUrl='<%# Eval("Product_Image") %>'
                                    Width="80px" />
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="../images/Button/019.png"
                                    CommandArgument='<%# Bind("Produt_Code")%>' CommandName="RegEdit" />
                                &nbsp;<asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="../images/Button/101.png"
                                    CommandArgument='<%# Bind("Produt_Code")%>' CommandName="RegDelete" OnClientClick="return confirm('Are you sure you want to Delete?')" />
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
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
                    Product Master</p>
            </div>
            <table width="100%">
                <tr>
                    <td align="right" width="20%" >
                       <b> Category :</b>
                    </td>
                    <td width="30%">
                        <asp:DropDownList ID="ddlcategory" runat="server" Width="95%" CssClass="txt_box ">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            CssClass="ErrorMsg" ControlToValidate="ddlcategory" ValidationGroup="Reg_Img"
                            InitialValue="--Select--"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" width="20%">
                        <b>Product Name :</b>
                    </td>
                    <td  width="30%">
                        <asp:TextBox ID="txtprdname" runat="server" MaxLength="50"  CssClass="txt_box " ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                            CssClass="ErrorMsg" ControlToValidate="txtprdname" ValidationGroup="Reg_Img"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                       <b> Actual Price :</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtprdprice" runat="server" MaxLength="50"  CssClass="txt_box " ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            CssClass="ErrorMsg" ControlToValidate="txtprdprice" ValidationGroup="Reg_Img"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                       <b> Offer Price :</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOfferPrice" runat="server" MaxLength="50"  CssClass="txt_box " ></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            CssClass="ErrorMsg" ControlToValidate="txtOfferPrice" ValidationGroup="Reg_Img"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                       <b> Description :</b>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine"  CssClass="txt_box " Width="96%" Height="40"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                            CssClass="ErrorMsg" ControlToValidate="txtdescription" ValidationGroup="Reg_Img"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    <b>Quantity :</b>
                    </td>
                    <td>
                    <asp:TextBox ID="txtQuantity" runat="server" Width="90%"  CssClass="txt_box "></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                            CssClass="ErrorMsg" ControlToValidate="txtQuantity" ValidationGroup="Reg_Img"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                       <b> Product Image :</b>
                    </td>
                    <td>
                        <asp:FileUpload ID="ProductImage" runat="server" Width="160"  CssClass="txt_box " />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                            CssClass="ErrorMsg" ControlToValidate="ProductImage" ValidationGroup="Reg_Img"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="padding-right: 25px; text-align: right;" colspan="4">
                        <asp:ImageButton ID="imgBtnSubmit" runat="server" ImageUrl="../images/Button/save.png"
                            ValidationGroup="Reg_Img" OnClick="imgBtnSubmit_Click" />
                        &nbsp;&nbsp;<asp:ImageButton ID="imgBtnReset" runat="server" CausesValidation="false"
                            ImageUrl="../images/Button/reset.png" OnClick="imgBtnReset_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Label ID="lblprdid" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" CancelControlID="ImageButton2"
        TargetControlID="Label4" PopupControlID="Panel1" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtprdprice"
        FilterMode="ValidChars" FilterType="Numbers" ValidChars="0123456789.">
    </cc1:FilteredTextBoxExtender>
    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtOfferPrice"
        FilterMode="ValidChars" FilterType="Numbers" ValidChars="0123456789.">
    </cc1:FilteredTextBoxExtender>
    </div>
</asp:Content>
