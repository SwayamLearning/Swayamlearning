<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BulkInvoice.aspx.cs" Inherits="Dashboard_BulkInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
        table
        {
            border-collapse: collapse;
            border: 1px solid black;
        }
        
        .tdstyle
        {
            border-color: #000000;
            border-right-style: solid;
            border-right-width: 1px;
        }
        
        
        .style2
        {
            border-right: 1px solid #000000;
            width: 30%;
            height: 37px;
            border-left-color: #000000;
            border-top-color: #000000;
            border-bottom-color: #000000;
        }
        .style3
        {
            border-right: 1px solid #000000;
            width: 10%;
            height: 37px;
            border-left-color: #000000;
            border-top-color: #000000;
            border-bottom-color: #000000;
        }
        .style4
        {
            width: 30%;
            height: 32px;
        }
        .style5
        {
            width: 10%;
            height: 32px;
        }
        .style6
        {
            width: 29%;
            height: 32px;
        }
        .style7
        {
            border-right: 1px solid #000000;
            width: 29%;
            height: 37px;
            border-left-color: #000000;
            border-top-color: #000000;
            border-bottom-color: #000000;
        }
    
                                    #packageDetail *{
                                        padding:5px;
                                    }

                                    #packageDetail tr td:nth-child(4),
                                    #packageDetail tr td:nth-child(5) {
                                        min-width:111px !important; 
                                    }

                                    #packageDetail th {
                                        text-align: center !important;
                                    }

                                    #packageDetail tr td:nth-child(6) {
                                        min-width: 75px !important;
                                    }

                                </style>
    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-69363607-1', 'auto');
        ga('send', 'pageview');

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnExportInvoice" runat="server" Text="Dwonload Invoice" OnClick="btnExportInvoice_Click" Visible="false" />
            <asp:Panel ID="pnlInvoice" runat="server">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="false" BorderStyle="None" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="View">                      
                            <ItemTemplate>
                                <asp:Panel ID="pnlInvoice" runat="server">
                                    <table style="width: 100%;" cellpadding="10" id="tblinvoice" runat="server"  border="1">
                                        <tr style="border-color: #000000; border-bottom-style: solid; border-bottom-width: 1px;" >
                                            <td style="width: 60%;">
                                                <img src="App_Themes/Home/Homepagenewimages/SwayamTMlogo.jpg" width="150" id="dvICICIEpath" alt="Swayam Learning" />
                                                <%--<img src="App_Themes/Responsive/web/logo.png" alt="Epathshala logo" id="dvICICIEpath"
                                runat="server" />--%>
                                            </td>
                                            <td align="right" style="width: 30%; text-align: right">
                                                <div align="left">
                                                    Swayam Learning Pvt Ltd
                                <br />
                                                    opp. St. Xavier's College, Mithakhali, Navrangpura, Ahmedabad-380009
                                <br />
                                                    Gujarat,India.
                                <br />
                                                    GSTIN:24AAKCS6851N1ZQ
                                 <br />
                                                    PAN Number:AAKCS6851N
                                 <br />
                                                    State Name:Gujarat,Code:24
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">Tax Invoice</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 80%;">
                                                
                                                <asp:Label ID="lblStudentName2" runat="server" Text='<%# "Student Name:  "+ Eval("StudentName").ToString()%>'></asp:Label>
                                                
                                                <br />
                                                <table style="border: none; width: 100%;" border="0" width="100%">
                                                    <tr style="width: 100%;">
                                                        <td style="width: 20%;">
                                                            <asp:Label ID="lblboard" runat="server" Text='<%# "Board: "+ Eval("BOARD").ToString() %>'></asp:Label>
                                                        </td>
                                                        <td style="width: 20%;">
                                                            <asp:Label ID="lblmideum" runat="server" Text='<%# "Medium: "+Eval("MEDIUM").ToString() %>'></asp:Label>
                                                        </td>
                                                        <td align="right" style="padding-right: 40px;">
                                                            <asp:Label ID="lblstandard" runat="server" Text='<%# "Standard: "+Eval("MEDIUM").ToString() %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="width: 100%;">
                                                        <td style="width: 20%;">
                                                            <asp:Label ID="lblStateName" runat="server" Text='<%# "State Name: "+Eval("StateName").ToString() %>'></asp:Label>
                                                        </td>
                                                        <td style="width: 20%;">
                                                            <asp:Label ID="lblStateCode1" runat="server" Text='<%# "State Code: "+Eval("StateCode").ToString() %>'></asp:Label>
                                                        </td>
                                                        <td style="width: 20%;"></td>
                                                    </tr>
                                                </table>
                                                <%-- <span>Board:</span> <u><span style="padding-left: 10px;">Gujarat</span> </u><span
                        style="padding-left: 40px;">Midium:</span> <u><span style="padding-left: 10px;">Gujarati
                        </span></u><span style="padding-left: 40px">Standard:</span> <u><span style="padding-left: 10px;">
                            standard 7 (sem-02) </span></u>--%>
                                                <br />
                                            </td>
                                            <td align="right" style="width: 20%;">
                                                <asp:Label ID="lblinvoicenumber" runat="server" Text='<%# "Invoice No: "+Eval("invoiceid").ToString() %>'></asp:Label>
                                                <br />
                                                <asp:Label ID="lblinvoicedate" runat="server" Text='<%# "Invoice Date: "+Eval("ActivateOn").ToString() %>'></asp:Label>
                                                <%--<span>Invoice Date: </span>23 Apr,2015--%>
                                            </td>
                                        </tr>
                                        <%--<tr>
                <td class="style1">
                </td>
                <td class="style1">
                </td>
            </tr>--%>
                                        <tr>
                                            <td colspan="2" width="100%">
                                                <div>



                                                    <table width="100%" style="border-left: 0px solid rgb(0, 0, 0); border-bottom: 0px solid rgb(0, 0, 0); border-right: 0px solid rgb(0, 0, 0);"
                                                        id="packageDetail">
                                                        <tr style="border-color: #000000; border-bottom-style: solid; border-bottom-width: 1px;">
                                                            <th style="border-right: 1px solid #000000; border-left-color: #000000; border-top-color: #000000; border-bottom-color: #000000;"
                                                                class="style4">Package Name
                                                            </th>
                                                            <th style="border-right: 1px solid #000000; border-left-color: #000000; border-top-color: #000000; border-bottom-color: #000000;"
                                                                class="style6">Subject
                                                            </th>
                                                            <th style="border-right: 1px solid #000000; border-left-color: #000000; border-top-color: #000000; border-bottom-color: #000000;"
                                                                class="style6">SAC Code
                                                            </th>
                                                            <th style="border-right: 1px solid #000000; border-left-color: #000000; border-top-color: #000000; border-bottom-color: #000000;"
                                                                class="style5">No Of Days
                                                            </th>
                                                            <th style="border-right: 1px solid #000000; border-left-color: #000000; border-top-color: #000000; border-bottom-color: #000000;"
                                                                class="style5">Valid From
                                                            </th>
                                                            <th style="border-right: 1px solid #000000; border-left-color: #000000; border-top-color: #000000; border-bottom-color: #000000;"
                                                                class="style5">Valid Till
                                                            </th>
                                                            <th style="border-right: 1px solid #000000; border-left-color: #000000; border-top-color: #000000; border-bottom-color: #000000;"
                                                                class="style5">Price
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td class="style2">
                                                                <asp:Label ID="lblpackagename" runat="server" Text='<%# Eval("PackageName").ToString() %>'></asp:Label>
                                                            </td>
                                                            <td class="style7">
                                                                <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("Subject").ToString() %>'></asp:Label>
                                                            </td>
                                                            <td class="style3" align="center">
                                                                <asp:Label ID="lblSACcode" runat="server" Text='<%# Eval("SACCode").ToString() %>'></asp:Label>
                                                            </td>
                                                            <td class="style3" align="right" style="padding-right: 4px;">
                                                                <asp:Label ID="lblmonth" runat="server" Text='<%# Eval("NoOfMonth").ToString() %>'></asp:Label>
                                                            </td>
                                                            <td class="style3" align="center">
                                                                <asp:Label ID="lblfromdate" runat="server" Text='<%# Eval("FromDate").ToString() %>'></asp:Label>
                                                            </td>
                                                            <td class="style3" align="center">
                                                                <asp:Label ID="lblvalidtill" runat="server" Text='<%# Eval("ValidTill").ToString() %>'></asp:Label>
                                                            </td>
                                                            <td class="style3" align="right">
                                                                <asp:Label ID="price" runat="server" Text='<%# Eval("BeforeTax").ToString() %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr style="border-color: #000000; border-top-style: solid; border-top-width: 1px;">
                                                            <td colspan="6" align="right" style="border-color: #000000; border-right-style: solid; border-right-width: 1px;">
                                                                <span style="padding-right: 10px;">Total</span>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lbltotal" runat="server" Text='<%# Eval("BeforeTax").ToString() %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="right" style="border-color: #000000; border-right-style: solid; border-right-width: 1px;">
                                                                <span style="padding-right: 10px;">Discount</span>
                                                            </td>
                                                            <td align="right">-&nbsp;<asp:Label ID="lbldiscount" runat="server" Text='<%# Eval("Discount").ToString() %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" align="right" style="border-color: #000000; border-right-style: solid; border-right-width: 1px;">
                                                                <span style="padding-right: 10px;">
                                                                    <asp:Label ID="lblCgstTitle" runat="server" Text='<%# Eval("StateCode").ToString() == "24" ? "CGST @9%": "IGST @18%" %>' ></asp:Label>
                                                                </span>
                                                            </td>
                                                            <td align="right">+&nbsp;<asp:Label ID="lbltax" runat="server" Text='<%# Eval("StateCode").ToString() == "24" ? Convert.ToDecimal(Eval("GSTAmount"))/2 : Eval("GSTAmount") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="SGSTRow" runat="server">
                                                            <td colspan="6" align="right" style="border-color: #000000; border-right-style: solid; border-right-width: 1px;">
                                                                <span style="padding-right: 10px;">
                                                                    <asp:Label ID="lblSgstTitle" runat="server" Text='<%# Eval("StateCode").ToString() == "24" ? "SGST @9%": "" %>'></asp:Label></span>
                                                            </td>
                                                            <td align="right">+&nbsp;<asp:Label ID="Lblsgst" runat="server" Text='<%# Eval("StateCode").ToString() == "24" ? Convert.ToDecimal(Eval("GSTAmount"))/2 : 0 %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr style="border-color: #000000; border-top-style: solid; border-top-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;">
                                                            <td colspan="6" align="right" style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000">
                                                                <span style="padding-right: 10px;">Grand Total</span>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Label ID="lblgrandtotal" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="height: 20%; border-color: #000000; border-bottom-style: solid; border-bottom-width: 1px;">
                                                                <asp:Label ID="lblnumericstring" runat="server"></asp:Label>
                                                                <br />
                                                                <br />
                                                                <br />
                                                                Thanks for your purchase.
                                                            </td>
                                                            <td colspan="4" style="height: 20%; border-color: #000000; border-bottom-style: solid; border-bottom-width: 1px; font-size: 14px; font-weight: bold; text-align: right">
                                                                <asp:Label ID="Label1" runat="server" Text="For Swayam Learning Private Limited"></asp:Label>
                                                                <br />
                                                                <br />
                                                                <br />
                                                                Authorized Signatory
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" style="font-size: 12px">
                                                                <u><b><span>Terms and condition</span> </b></u>
                                                                <br />
                                                                This is computer generated invoice and do not require any stamp or signature.
                                            <br />
                                                                The package(s) purchased is/are not transferable and refundable.
                                            <br />

                                                                Total payable amount is quoted in Indian Rupees, inclusive of all taxes and any additional
                                            charges.
                                            <br />
                                                                Terms and conditions subject to change without any notice.
                                            <br />
                                                                If you have any question regarding this invoice, contact support@swayamlearning.org
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>

        </div>
    </form>
</body>
</html>
