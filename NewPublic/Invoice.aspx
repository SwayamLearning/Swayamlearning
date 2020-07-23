<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/materialMaster.master" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="NewPublic_Invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }
        .auto-style2 {
            font-weight: bold;
        }
        .auto-style3 {
            width: 68px;
        }
        .auto-style4 {
            width: 384px;
        }
        .auto-style5 {
            width: 219px;
        }
        .auto-style6 {
            width: 152px;
        }
        .auto-style7 {
            width: 250px;
        }
        .auto-style8 {
            width: 400px;
        }
        .auto-style9 {
            width: 387px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="btndownload" Text="Download Invoice" runat="server" OnClick="btndownload_Click"/>
    <asp:Panel ID="Panel1" runat="server">
        <table class="w-100">
            <tr>
                 <td class="auto-style3"><img src="../App_Themes/Home/Homepagenewimages/Logonew.jpg" width="70" /></td>

            </tr>
            <tr>
                
                
                <td class="text-center">
                    
                    <strong class="auto-style2">Invoice Receipt</strong></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; I<strong class="auto-style2">nvoice Number</strong>:<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    &nbsp;&nbsp;&nbsp; <strong class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Invoice Date</strong>:<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="w-100">
                        <tr>
                             <td class="auto-style9">&nbsp;</td>
                            <td class="auto-style8">
                                
                                Customer Address<br /> </td>
                           
                            <td>Seller Address</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                             <td class="auto-style9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                            <td class="auto-style8">
                                <table>
                            <tr>
                                <td>
                                <asp:Label ID="LblCustname" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                <asp:Label ID="LblCustAddress" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                <asp:Label ID="LblCustEmail" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                <asp:Label ID="LblCustMobile" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                                </td>
                           
                            <td>
                                 <table>
                            <tr>
                                <td><asp:Label ID="Label17" runat="server" Text="Swayam learning Private Limited"></asp:Label></td>
                                
                            </tr>
                            <tr>
                               <td><asp:Label ID="Label18" runat="server" Text="Shanti Niwas Opp.St.Xaviers college"></asp:Label></td> 
                            </tr>
                            <tr>
                                  <td><asp:Label ID="Label19" runat="server" Text="Navarangpura,Ahmedabad -380 009."></asp:Label></td> 
                            </tr>
                            <tr>
                                  <td><asp:Label ID="Label20" runat="server" Text="Gujarat,India" ></asp:Label></td> 
                            </tr>
                        </table>
                            </td>
                            </tr>
                    </table>
                </td>
            </tr>
       
        
        <tr>
            <td>
                <table class="w-100">
                    <tr>
                        <td class="auto-style3">Sno</td>
                        <td class="auto-style4">Description</td>
                        <td class="auto-style5">Quantity</td>
                        <td class="auto-style6">Unit Price</td>
                        <td>Tax</td>
                        <td>Amount</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:Label ID="LblSno" runat="server" Text="1"></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <asp:Label ID="LblPackage" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="auto-style5">
                            <asp:Label ID="LblQuantity" runat="server" Text="1"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="Lblunitprice" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LblTax" runat="server" Text="18%"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LblAmount" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3"></td>
                        <td class="auto-style4"></td>
                        <td class="auto-style5"></td>
                        <td class="auto-style6"></td>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="Sub Total"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Lblsubtotal" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3"></td>
                        <td class="auto-style4"></td>
                        <td class="auto-style5"></td>
                        <td class="auto-style6"></td>
                        <td>
                            <asp:Label ID="LblCGST" runat="server" Text="CGST 9%"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LblCGSTAmount" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3"></td>
                        <td class="auto-style4"></td>
                        <td class="auto-style5"></td>
                        <td class="auto-style6"></td>
                        <td>
                            <asp:Label ID="LblSGST" runat="server" Text="SGST 9%"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LblSGSTamt" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3"></td>
                        <td class="auto-style4"></td>
                        <td class="auto-style5"></td>
                        <td class="auto-style6"></td>
                        <td>
                            <asp:Label ID="Label15" runat="server" Text="Total Rs:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LblTotal" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>This is a computer generated invoice and does not require any signature. </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        </table>
    </asp:Panel>

</asp:Content>

