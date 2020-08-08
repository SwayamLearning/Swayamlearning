<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentResponse.aspx.cs" Inherits="NewPublic_PaymentResponse" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div align="center" style="vertical-align: middle; margin-top: 110px; margin-left: 170px;
        width: 70%">
         
        <table style="border-width: 1px; height: 167px; width: 70%; border-collapse: collapse;
            border: 1px solid black;">
            
            <tr>
                <td align="left" style="width: 20%; padding-left: 10px; padding-bottom: 30px; padding-top: 20px;">
                   <img style="margin-top: -9px; margin-right: 10px; padding: 0;" src="../NewPublic/img/newlogo.jpg"  alt="Swayam Learning" width="200"
                </td>
                <td align="left" style="width: 80%; padding-left: 50px; padding-bottom: 30px; padding-top: 20px;">
                    <h1>
                        <asp:Label ID="lblthankyou" runat="server" meta:resourcekey="lblthankyouResource1" ></asp:Label></h1>
                    <br />
                    <h3>
                        <asp:Label ID="lbltransactionnumber" runat="server" meta:resourcekey="lbltransactionnumberResource1"></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="lblmessage1" meta:resourcekey="lblmessage1Resource1"></asp:Label>
                    </h3>
                </td>
            </tr>
            
            <tr align="center">
                <td colspan="2" style="width: 100%; height: 2px;" >
                    Please do not refresh the page or click the "Back" or "Close" button of your browser.
                    <img src="../App_Themes/Responsive/web/v11_wait_bar.gif" height="30px" width="100%"
                        alt="Please wait" />
                </td>
            </tr>
        </table>
    </div>
        <div class="container packagewrapper">
        <asp:Label ID="lblmarqueePayment" runat="server" Text="" meta:resourcekey="lblmarqueePaymentResource1" ForeColor="#17476E" Font-Bold="true"></asp:Label>
    </div>
    </form>
</body>
</html>
