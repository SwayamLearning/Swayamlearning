<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentRegistration.aspx.cs" Inherits="NewPublic_Homepage_Registration_StudentRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Registration</title>
    <link rel="stylesheet" href="vendor/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="vendor/font-awesome/css/font-awesome.min.css">
    <!-- Custom Font Icons CSS-->
    <link rel="stylesheet" href="css/landy-iconfont.css">
    <!-- Google fonts - Open Sans-->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,700,800">
    <link href="../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="page-wrapper bg-gra-02 p-t-130 p-b-100 font-poppins">

            <div class="wrapper wrapper--w680">
                <div class="card card-4">
                    <div class="card-body">
                        <h2 class="title">Registration Form</h2>
                        <div class="row row-space">
                            <div class="col-2">
                                <div class="input-group">
                                    <asp:Label ID="lblFname" Text="First Name" runat="server" CssClass="label"></asp:Label>
                                    <asp:TextBox ID="txtFname" CssClass="input--style-4" runat="server"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                    <asp:Label ID="lblLastname" Text="Last Name" runat="server" CssClass="label"></asp:Label>
                                    <asp:TextBox ID="txtLname" CssClass="input--style-4" runat="server"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="row row-space">
                            <div class="col-2">
                                <div class="input-group">
                                    <asp:Label ID="lblEmail" Text="Email" runat="server" CssClass="label"></asp:Label>
                                    <asp:TextBox ID="txtEmail" CssClass="input--style-4" runat="server"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                    <asp:Label ID="lblContact" Text="Contact" runat="server" CssClass="label"></asp:Label>
                                    <asp:TextBox ID="txtContact" CssClass="input--style-4" runat="server"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="row row-space">
                            <div class="col-2">
                                <div class="input-group">
                                    <asp:Label ID="LblBMS" Text="BMS(Board Medium & Standard)" runat="server" CssClass="label"></asp:Label>
                                    <asp:DropDownList ID="ddlBMSAdd" runat="server" CssClass="rs-select2">
                                        <asp:ListItem Value="0" Text="--Select--" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                    <asp:Label ID="Lblschool" Text="School" runat="server" CssClass="label"></asp:Label>
                                     <asp:TextBox ID="txtSchool" CssClass="input--style-4" runat="server"></asp:TextBox>
                                </div>
                            </div>


                        </div>
                    </div>


                </div>
            </div>
        </div>
    </form>

</body>
</html>

