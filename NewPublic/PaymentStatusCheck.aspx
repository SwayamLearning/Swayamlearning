<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentStatusCheck.aspx.cs" Inherits="NewPublic_PaymentStatusCheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblOrderidTitle" runat="server" Text="Order ID : "></asp:Label><asp:TextBox ID="txtOrderID" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnCheckStatus" runat="server" Text="Check Status" OnClick="btnCheckStatus_Click" />
    </div>
    </form>
</body>
</html>
