<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="SafarRegistration.aspx.cs" Inherits="Admin_SafarRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    
  
    
   <div class="pin" style="width:100%;">
       
        <div class="detail_heading" style="width:100%;">
            <table width="100%">
                <tr>
              
                    <td>
                       <p> <asp:Label ID="hh" Text="Upload Iamge Details" runat="server"
                            Font-Size="15px" Font-Bold="true"></asp:Label></p>
                    </td>
                    <td align="right">
                    <asp:ImageButton ID="ImageButton1" ImageUrl="../images/Button/document-new.png" runat="server"
                            OnClick="Unnamed1_Click" ToolTip="Add New" />
                    </td>
                </tr>
            </table>
        </div>

            <table width="100%" style="margin-bottom:8px;">
                <tr>
                    <td style="width: 50%; padding-left: 0px; padding-top: 3px; text-align: left;">
                        <asp:DropDownList ID="ddlcategory_Id" runat="server" Width="210px" OnSelectedIndexChanged="ddlcategory_Id_SelectedIndexChanged"
                            ForeColor="#404040" CssClass="txt_box" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label ID="LblmsgHead" ForeColor="Red" Font-Size="11px" runat="server"></asp:Label>
                    </td>
                    <td style="width: 50%; padding-left: 1px; padding-top: 3px; text-align: right;">
                        
                    </td>
                </tr>
            </table>
       

 
    <center>
        
        <div>
            <asp:Label ID="lblrow_id" runat="server" Visible="false" Text=""></asp:Label>
            <center>
                <asp:GridView ID="GridView1" runat="server" CssClass="table" AllowPaging="True" AutoGenerateColumns="False"
                    EmptyDataText="Record Not Found" EmptyDataRowStyle-HorizontalAlign="Center" BorderStyle="None" OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowCommand="GridView1_RowCommand">
                    <PagerSettings Mode="Numeric" />
                    <PagerStyle  CssClass="tr" HorizontalAlign="Center" ForeColor="white"  />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%-- <%#index++%>--%>
                                <asp:Label ID="lblsrm" runat="server" Text='<%# Bind("srm") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&nbsp;&nbsp;Category Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblcate" runat="server" Text='<%# Bind("Cat_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="110px" CssClass="tt_lft" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&nbsp;&nbsp;Image Title" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Img_Title") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="150px" CssClass="tt_lft" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&nbsp;&nbsp;Remarks" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="170px" CssClass="tt_lft" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&nbsp;&nbsp;Over View" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("OverView") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="tt_lft" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="35px" ImageUrl='<%# Eval("Img_Path") %>'
                                    Width="80px" />
                            </ItemTemplate>
                            <ItemStyle Width="82px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="../images/Button/019.png"
                                    CommandArgument='<%# Bind("Row_Id")%>' CommandName="RegEdit" />
                                &nbsp;<asp:ImageButton ID="ImgDelete" runat="server" ImageUrl="../images/Button/101.png"
                                    CommandArgument='<%# Bind("Row_Id")%>' CommandName="RegDelete" OnClientClick="return confirm('Are you sure you want to Delete?')" />
                            </ItemTemplate>
                            <ItemStyle Width="60px" />
                        </asp:TemplateField>
                    </Columns>
                       <AlternatingRowStyle CssClass="tr2" />
                     <HeaderStyle CssClass="tr" />
                   <RowStyle CssClass="tr1" />
                    <FooterStyle ForeColor="Black"  />
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
                    Registration Form</p>
            </div>
            <table width="100%">
                <tr>
                    <td colspan="2" style="font-size: 11px; color: Red; text-align: right; padding-right: 12px;">
                        <asp:Label ID="LblMsg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                       <b> Image Category* :</b>
                    </td>
                    <td width="72%">
                        <p>
                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="txt_box">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                CssClass="ErrorMsg" ControlToValidate="ddlCategory" InitialValue="Selected Image Category"
                                ValidationGroup="Reg_Img"></asp:RequiredFieldValidator>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                       <b> Image Title* :</b>
                    </td>
                    <td width="72%">
                        <p>
                            <asp:TextBox ID="txtImgTitle" runat="server" MaxLength="50" CssClass="boxes_drop" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                CssClass="ErrorMsg" ControlToValidate="txtImgTitle" ValidationGroup="Reg_Img"></asp:RequiredFieldValidator>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                       <b> Remarks* :</b>
                    </td>
                    <td width="72%">
                        <p>
                            <asp:TextBox ID="txtReamrk" MaxLength="50" runat="server" CssClass="boxes_drop" Width="93%" TextMode="MultiLine"  Height="60px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                CssClass="ErrorMsg" ControlToValidate="txtReamrk" ValidationGroup="Reg_Img"></asp:RequiredFieldValidator>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                       <b> Over View* :</b>
                    </td>
                    <td width="72%">
                        <p>
                            <asp:TextBox ID="txtOverView" MaxLength="1000" runat="server" CssClass="boxes_drop" Width="93%"
                                Height="60px" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                CssClass="ErrorMsg" ControlToValidate="txtOverView" ValidationGroup="Reg_Img"></asp:RequiredFieldValidator>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                       <b> Price* :</b>
                    </td>
                    <td width="72%">
                        <p>
                            <asp:TextBox ID="txtPrice" MaxLength="11" runat="server" CssClass="boxes_drop" Width="50%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                CssClass="ErrorMsg" ControlToValidate="txtPrice" ValidationGroup="Reg_Img"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPrice"
                                ValidChars=".1234567890" FilterMode="ValidChars">
                            </cc1:FilteredTextBoxExtender>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                       <b> Image Upload* :</b>
                    </td>
                    <td width="72%" align="left">
                        <p>
                            <asp:FileUpload ID="FileUploadImage" Style="padding-left: 2px;" runat="server" CssClass="boxes_drop" />
                            <asp:HyperLink ID="ImageOldUrl" Target="_blank" runat="server">DownLoad</asp:HyperLink>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td style="padding-right: 25px; text-align: right;" colspan="2">
                        <asp:ImageButton ID="imgBtnSubmit" runat="server" ImageUrl="../images/Button/save.png"
                            ValidationGroup="Reg_Img" OnClick="imgBtnSubmit_Click" />
                        &nbsp;&nbsp;<asp:ImageButton ID="imgBtnReset" runat="server" CausesValidation="false"
                            ImageUrl="../images/Button/reset.png" OnClick="imgBtnReset_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
   </div>
    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" CancelControlID="ImageButton2"
        TargetControlID="Label4" PopupControlID="Panel1" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>

    
</asp:Content>
