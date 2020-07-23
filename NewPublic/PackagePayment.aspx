<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/materialMaster.master" AutoEventWireup="true" CodeFile="PackagePayment.aspx.cs" Inherits="NewPublic_PackagePayment" meta:resourcekey="PageResource1"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        h3 {
            font-size: 30px !important;
            font-weight: bold !important;
            color: #17476E !important;
        }

        .lblstatic {
            font-size: 14px;
            font-weight: bold;
            color: #17476E;
        }

        .lbltable {
            font-size: 14px;
            font-weight: bold;
            color: #ff9801;
        }

        ul li {
            display: inline;
        }

        .cardstyle {
            padding: 20px !important;
            text-align: left;
        }
        ul.columns>li {
  display: inline-block;
   
  margin-left:-30px;
  
  padding-left:35px;
 
}
ul.columns>li:before {
  content: '◦';
  position: relative;
  font-size: 1.3em;
  font-weight: bold;
  top: 1px;
  left: -3px;
}
ul.columns>li>a
{
    text-decoration: underline !important;
}
.text-hp
{
    padding:10px 0px;
    margin-left:-40px;
}
.btnblock
{
    padding:30px 0px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container packagewrapper">
        <div class="row">
            <div class="col-md-12">
                <div class="card cardstyle">
                    <h3 class="card-title"><a>
                        <asp:Label ID="Label5" runat="server" Text="Package Details" meta:resourcekey="LblPPackagenaeDetailTitle"></asp:Label></a></h3>
                    <div class="card-body">
                        <div class="form-row">
                            <div class="form-group col-md-3 lblstatic">
                                <h4>
                                    <asp:Label ID="LblPackagename" runat="server" Text="PackageName" meta:resourcekey="LblPackagenameResource1"></asp:Label></h4>
                            </div>
                            <div class="form-group col-md-3 lbltable">
                                <h4>
                                    <asp:Label ID="lblpackname" runat="server" meta:resourcekey="lblpacknameResource1"></asp:Label></h4>

                            </div>

                       <%-- </div>
                        <div class="form-row">--%>
                            <div class="form-group col-md-3 lblstatic">
                                <h4>
                                    <asp:Label ID="lbl" runat="server" meta:resourcekey="lblResource1" Text="Product Type"></asp:Label></h4>
                            </div>
                            <div class="form-group col-md-3 lbltable">
                                <h4>
                                    <asp:Label ID="lblprod" runat="server" meta:resourcekey="lblprodResource1" Text="Online Subscription"></asp:Label>
                                </h4>
                            </div>

                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-3 lblstatic">
                                <h4>
                                    <asp:Label ID="Lblvaltitle" runat="server" Text="Validity" meta:resourcekey="LblvaltitleResource1"></asp:Label></h4>
                            </div>
                            <div class="form-group col-md-3 lbltable">
                                <h4>
                                    <asp:Label ID="lblvalidity" runat="server" meta:resourcekey="lblvalidityResource1"></asp:Label></h4>

                            </div>

                       <%-- </div>
                        <div class="form-row">--%>
                            <div class="form-group col-md-3 lblstatic">
                                <h4>
                                    <asp:Label ID="lblpricetitle" runat="server" Text="Price" meta:resourcekey="lblpricetitleResource1"></asp:Label></h4>
                            </div>
                            <div class="form-group col-md-3 lbltable">
                                <h4>
                                    <asp:Label ID="lblprice" runat="server" meta:resourcekey="lblpriceResource1"></asp:Label></h4>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="card cardstyle">
                    <h3 class="card-title"><a> <asp:Label ID="lblStudentDetailTitle" Text="Student Details" runat="server" meta:resourcekey="lblStudentDetailTitleResource1"></asp:Label></a></h3>
                    <div class="card-body">
                        <div class="form-row">
                            <div class="form-group col-md-2 lblstatic">
                                <h4>
                                    <asp:Label ID="Label1" runat="server" Text="Name" meta:resourcekey="Label1Resource1"></asp:Label></h4>
                            </div>
                            <div class="form-group col-md-4 lbltable">
                                <h4>
                                    <asp:Label ID="Lblfname" runat="server" meta:resourcekey="LblfnameResource1"></asp:Label></h4>

                            </div>

                       <%-- </div>
                        <div class="form-row">--%>
                            <div class="form-group col-md-3 lblstatic">
                                <h4>
                                    <asp:Label ID="Label3" runat="server" Text="Mobile Number" meta:resourcekey="Label3Resource1"></asp:Label></h4>
                            </div>
                            <div class="form-group col-md-3 lbltable">
                                <h4>
                                    <asp:Label ID="Lblmobile" runat="server" meta:resourcekey="LblmobileResource1"></asp:Label></h4>

                            </div>

                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-2 lblstatic">
                                <h4>
                                    <asp:Label ID="Label4" runat="server" Text="Email" meta:resourcekey="Label4Resource1"></asp:Label></h4>
                            </div>
                            <div class="form-group col-md-4 lbltable">
                                <h4>
                                    <asp:Label ID="LblEmail" runat="server" meta:resourcekey="LblEmailResource1"></asp:Label>
                                </h4>
                            </div>

                      <%--  </div>
                        <div class="form-row">--%>
                            <div class="form-group col-md-5 lbltable">
                                <h4>
                                    <asp:TextBox ID="txtAddress" runat="server" placeholder="Address" CssClass="form-control " meta:resourcekey="txtAddressResource1"></asp:TextBox>
                                </h4>
                            </div>
                            </div>
                           

                        
                        <div class="form-row">
                             <div class="form-group col-md-3 lbltable">
                                <h4>
                                    <asp:TextBox ID="txtZipCode" runat="server" placeholder="Pin Code" CssClass="form-control " meta:resourcekey="txtZipCodeResource1"></asp:TextBox>
                                </h4>
                            </div>
                            <div class="form-group col-md-3 lbltable">
                                <h4>
                                    <asp:TextBox ID="txtCity" runat="server" placeholder="City" CssClass="form-control " meta:resourcekey="txtCitynameResource1"></asp:TextBox>
                                </h4>
                            </div>                            
                       <%-- </div>
                        <div class="form-row">  --%>                          
                            <div class="form-group col-md-3">
                                <asp:DropDownList ID="ddlStateID" runat="server" CssClass="form-control" meta:resourcekey="ddlStateIDResource1">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldStateID" runat="server" ErrorMessage="Please select State"
                                    ValidationGroup="a" ControlToValidate="ddlStateID" meta:resourcekey="ReqFieldStateIDResource1">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group col-md-3">
                                <asp:DropDownList ID="ddlCountryID" runat="server" CssClass="form-control dropdown" meta:resourcekey="ddlCountryIDResource1" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqFieldCountryID" runat="server" ErrorMessage="Please select country"
                                    ValidationGroup="a" ControlToValidate="ddlCountryID" meta:resourcekey="ReqFieldCountryIDResource1">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <%--    <div class="form-row">
                            <div class="form-group col-md-6 lblstatic">
                                <h4> <asp:Label ID="Label5" runat="server" Text="Address"></asp:Label></h4> 
                            </div>
                             

                        </div>--%>
                        <%-- <div class="form-row">
                            <div class="form-group col-md-6 lbltable">
                                <h4> <asp:Label ID="LblAddress" runat="server"></asp:Label></h4> 
                            </div>
                            

                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:CheckBox ID="CheckBox1" runat="server" meta:resourcekey="CheckBox1Resource1" />
                <span style="margin-left: 2px;"><asp:Label ID="lblTCNote" Text="I have read and  agree to the  terms and conditions." runat="server" meta:resourcekey="lblTCNoteResource1"></asp:Label>
                    
                     </span>

            </div>
        </div>
        <div class="row btnblock">
             <div class="col-md-12">
            <asp:Button class="btn-primary" Text="Continue" OnClick="btncontinue_Click" OnClientClick="javascript:return Check();" ID="btncontinue" runat="server" meta:resourcekey="btncontinueResource1"></asp:Button>

            &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;
                          <asp:Button class="btn-danger" Text="cancel" OnClick="btncancel_Click"  ID="btncancel" runat="server" meta:resourcekey="btncancelResource1"></asp:Button>
           </div>
        </div>
        <div class="row">
            <div class="col-md-12">
            <div   class="text-hp">
                <ul class="columns">
                    <li><a target="_blank" href="../Policy/PrivacyPolicy.htm">Privacy Policy</a> </li>
                    <li><a target="_blank" href="../Policy/TermsAndConditions.htm">Terms &amp; Condition</a>
                    </li>
                    <li><a target="_blank" href="../Policy/CancellationPolicy.htm">Cancellation Policy</a>
                    </li>
                </ul>
            </div>
                </div>
        </div>
    </div>
    <script type="text/javascript">
        function Check() {
            debugger;
            var chkPassport = document.getElementById("<%=CheckBox1.ClientID %>");
            if (chkPassport.checked) {
                return true;
            } else {
                alert("Accept the tems and conditions.");
                return false;
            }

        }
        function redirect()

        {
            debugger;
            window.locatio.href = "../Dashboard/StudentDashboard.aspx";

        }
    </script>
</asp:Content>

