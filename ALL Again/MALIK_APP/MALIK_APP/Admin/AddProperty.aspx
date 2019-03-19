<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AddProperty.aspx.cs" Inherits="admin_AddProperty" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 17px;
        }
    </style>
    <link rel="Stylesheet" type="text/css" href="../Upload/uploader.css" />
    <script language="javascript" type="text/javascript" src="../Upload/uplodare.js"></script>
    <script language="javascript" type="text/javascript">
     
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
    
    <div class="content">
        <div class="pin" style="width: 100%">
            <div class="detail_heading">
                <p>
                    Property Entry <span>(<%=count%>
                        Rows found) </span>
                </p>
            </div>
            <div class="member11">
                <table width="100%">
                    <tr>
                        <td class="style1" colspan="4">
                            &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                            <strong>Property Title :</strong>
                        </td>
                        <td width="30%">
                            <asp:TextBox ID="txtptotitle" CssClass="txt_box" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtptotitle"
                                ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right" width="20%">
                            <strong>State :</strong>
                        </td>
                        <td width="30%">
                            <asp:DropDownList ID="ddlstate" CssClass="txt_box" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >
                            <strong>Purpose :</strong>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlperpose" CssClass="txt_box" runat="server">
                                <asp:ListItem Value="Rent">Rent</asp:ListItem>
                                <asp:ListItem Value="Sale">Buy/Sale</asp:ListItem>
                                <asp:ListItem Value="Lease">Lease</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <strong>City :</strong>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlcity" CssClass="txt_box" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <strong>Price :</strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txtprice" MaxLength="10" CssClass="txt_box" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtprice"
                                ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right">
                            <strong>Sqt. Rate  :</strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbv" MaxLength="10" Width="70px" CssClass="txt_box" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtbv"
                                ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender runat="server" ID="filtertextbox1" TargetControlID="txtbv"
                                ValidChars=".0123456789">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <strong>Type :</strong>
                        </td>
                        <td>
                            <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtprice"
                                ValidChars=".0123456789">
                            </cc1:FilteredTextBoxExtender>
                            <asp:DropDownList ID="ddltype" CssClass="txt_box" runat="server">
                                <asp:ListItem Value="Residential">Residential</asp:ListItem>
                                <asp:ListItem Value="Commercial">Commercial</asp:ListItem>
                                <asp:ListItem Value="Agriculture">Agriculture</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <strong>Upload Brochure :</strong>
                        </td>
                        <td valign="top">
                            <asp:FileUpload ID="FileUpload2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <strong>Url :</strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txturl" CssClass="txt_box" runat="server"></asp:TextBox>
                        </td>
                        <td rowspan="3" valign="top" align="right">
                            <strong>Upload Image :</strong>
                        </td>
                        <td valign="top" rowspan="3" align="left">
                            <p id="upload-area">
                                <input id="files" onchange="handleFileSelect(event)" type="file" runat="server"  />
                            </p>                            
                          <div id="list" runat="server" style="margin-top:5px;width: 99%; height: 70px; overflow-x: hidden;
                                overflow-y: visible">
                            </div> 
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <strong>Description :</strong>
                        </td>
                        <td rowspan="2" valign="top" >
                            <asp:TextBox ID="txtdetail" Height="60px" CssClass="txt_box" runat="server" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtdetail"
                                ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="right">
                            &nbsp;
                            <asp:CheckBox ID="chkshow" runat="server" Text="Show Home on page" />
                        </td>
                        <td colspan="2">
                            <asp:ImageButton ID="imgbtnsave" runat="server" ImageUrl="~/images/Button/save.png"
                                OnClick="ImageButton1_Click" ValidationGroup="save" />
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Button/cancel.png"
                                OnClick="ImageButton2_Click" />
                            <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table" EnableModelValidation="True"
                                AllowPaging="True" CellPadding="1" ShowFooter="True" CellSpacing="1" AutoGenerateColumns="False"
                                PageSize="20" EmptyDataText="No Data" OnPageIndexChanging="GridView1_PageIndexChanging"
                                OnRowCommand="GridView1_RowCommand">
                                <AlternatingRowStyle CssClass="tr2" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                        <%=++sr %>
                                            <asp:Label runat="server" ID="lblsr" Text='<%# Bind("Id") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="tr" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Pro_Name" HeaderText="Property Name">
                                        <HeaderStyle CssClass="tr" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="tt_lft" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="city" HeaderText="City">
                                        <HeaderStyle CssClass="tr" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="tt_lft" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BV" HeaderText="Sqt. Rate">
                                        <HeaderStyle CssClass="tr" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="tt_lft" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Status" HeaderText="Status">
                                        <HeaderStyle CssClass="tr" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="tt_lft" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%#Bind("id") %>'
                                                CommandName="EditRow">Edit</asp:LinkButton>
                                            |
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Bind("id") %>'
                                                CommandName="Activate" ToolTip="Click For activate and deactivate" Text='<%# Bind("status") %>'></asp:LinkButton>
                                            |
                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Bind("id") %>'
                                                CommandName="DeleteRow">Delete</asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="tr" />
                                        <ItemStyle CssClass="tt_lft" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle HorizontalAlign="Right" />
                                <RowStyle CssClass="tr1" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
     <script type="text/javascript">
        // document.getElementById('files').addEventListener('change', handleFileSelect, false); 
    </script>
    
    
</asp:Content>
