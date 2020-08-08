<%@ Page Title="" Language="C#" MasterPageFile="~/NewPublic/materialMaster.master" AutoEventWireup="true" CodeFile="PackageBuy.aspx.cs" Inherits="NewPublic_PackageBuy" culture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .packagewrapper
        {
            padding-top:50px;
        }
        .productcard {
            padding: 10px;
        }
        h3
        {
            font-size:30px !important;
            font-weight:bold !important;
            color:#17476E !important;
        }
        .lblstatic
        {
            font-size:14px;
            font-weight:bold;
             color: #17476E;
        }
        .lbltable
        {
            font-size:14px;
            font-weight:bold;
             color: #ff9801;
        }
       
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container packagewrapper">
        <div class="row">
            <div class="col-lg-8 col-md-8">
                <div class="card productcard">
                  <h3 class="card-title"><a>
                      <asp:Label ID="Label3" runat="server" Text="Package Details" meta:resourcekey="LblPPackagenaeDetailTitle"></asp:Label></a></h3>
                    <div class="card-body">
                         <div class="form-row">
                            <div class="form-group col-md-4 lblstatic">
                                <h4> <asp:Label ID="LblPPackagenae" runat="server" Text="PackageName" meta:resourcekey="LblPPackagenaeResource1"></asp:Label></h4> 
                            </div>
                             <div class="form-group col-md-6 lbltable">
                                <h4> <asp:Label ID="lblpackname" runat="server" meta:resourcekey="lblpacknameResource1"></asp:Label></h4> 
                            </div>
                            

                        </div>
                         <div class="form-row">
                             <div class="form-group col-md-4 lblstatic">
                                <h4> <asp:Label ID="lbl" runat="server" meta:resourcekey="lblResource1">Product Type</asp:Label></h4> 
                            </div>
                             <div class="form-group col-md-6 lbltable">
                                <h4> <asp:Label ID="lblprod" runat="server" meta:resourcekey="lblprodResource1">Online Subscription </asp:Label> </h4> 
                            </div>

                        </div>
                         <div class="form-row">
                            <div class="form-group col-md-4 lblstatic">
                                <h4> <asp:Label ID="Lblvaltitle" runat="server" Text="Validity" meta:resourcekey="LblvaltitleResource1"></asp:Label></h4> 
                            </div>
                             <div class="form-group col-md-6 lbltable">
                                <h4> <asp:Label ID="lblvalidity" runat="server" meta:resourcekey="lblvalidityResource1"></asp:Label></h4> 
                            </div>

                        </div>
                         <div class="form-row">
                            
                             <div class="form-group col-md-4 lblstatic">
                                <h4> <asp:Label ID="lblpricetitle" runat="server" Text="Price" meta:resourcekey="lblpricetitleResource1"></asp:Label></h4> 
                            </div>
                             <div class="form-group col-md-6 lbltable">
                                <h4> <asp:Label ID="lblprice" runat="server" meta:resourcekey="lblpriceResource1"></asp:Label></h4> 
                            </div>

                        </div>

                    </div>
                </div>
            </div>
             <div class="col-lg-3 col-md-3">
	            <div class="card">
	                <div class="card-body">
	                     
	                        <div class="form-group"> <label>Have coupon?</label>
	                             
                                     <asp:TextBox id="Txtcoupon" runat="server"  class="form-control"  placeholder="Coupon code" meta:resourcekey="TxtcouponResource1"></asp:TextBox>  
                                </div>
                                    <%-- <asp:button  class="btn btn-primary"   Text="Apply"   ID="btncoupon" runat="server"> </asp:button>  --%>
                            <asp:button  Cssclass="btn-outline-primary waves-effect"  Text="Apply" OnClientClick="return applycoupon()"  ID="Button1" runat="server" meta:resourcekey="Button1Resource1"> </asp:button>  
                                       <%--<asp:button  Cssclass="btn btn-outline-info waves-effect"  Text="Apply" OnClientClick="return applycoupon()"  ID="btnApply" runat="server"> </asp:button>  --%>
                                   <%--  <button class="btn btn-outline-info waves-effect" type="submit" runat="server" onclick="return applycoupon();">Apply</button>--%>
                </div>
                    </div>
                 <div class="card">
	                             <div class="card-body">
	                       
	      
	          
	                     <div class="form-group">  
	                             
                                     <asp:Label ID="Label1" runat="server" Text="Discount:" meta:resourcekey="Label1Resource1"></asp:Label>  
                                     <asp:Label ID="lbldiscount" runat="server" Text=" " meta:resourcekey="lbldiscountResource1"></asp:Label>  
                               <%-- </div> &nbsp;
                         <div class="form-group">  --%>
	                            &nbsp;&nbsp;&nbsp;&nbsp;
                                     <asp:Label ID="Label2" runat="server" Text="Total:" meta:resourcekey="Label2Resource1"></asp:Label>  
                                     <asp:Label ID="lbltotal" runat="server" Text=" " meta:resourcekey="lbltotalResource1"></asp:Label>  
                                </div>
                            <br />
                                 <asp:button  Cssclass="btn-indigo"  Text="Buy Package" OnClick="btnconfirm_Click"  ID="btnconfirm" runat="server" meta:resourcekey="btnconfirmResource1"> </asp:button>  
                                
                     </div>
	                             
	                        </div>
                         
	                </div>
	            &nbsp;&nbsp;&nbsp;
	            </div>
	         
        </div>
    
   <marquee><asp:Label ID="lblmarqueePayment" runat="server" Text=""></asp:Label></marquee>
   <script>
       function applycoupon()
       {
           debugger;
           var couponcode = document.getElementById('<%=Txtcoupon.ClientID %>').value;
           PageMethods.Checkcouponcode(couponcode, OnSuccess, onError);
           function OnSuccess(result) {
               debugger;
 
             
               var success = result[0];
               if (result[0] == "valid")
               {
                   alert("coupon code valid and is applied");
                   var label = document.getElementById("<%=lbldiscount.ClientID %>");
                    alert(label);
                        //Set the value of Label.
                    label.innerHTML = result[1];
                
                //    document.getElementById('<%=lbldiscount.ClientID %>').value = result[1];
                    var label2 = document.getElementById("<%=lbltotal.ClientID %>");
                    alert(label2);
                        //Set the value of Label.
                    label2.innerHTML = result[2];
                
                //   document.getElementById('<%=lbltotal.ClientID %>').value = result[2];
               }
           }

           function onError(result) {
               debugger;
               alert('Cannot process your request at the moment, please try later.');
           }
           return false;
       }
   </script>
</asp:Content>

