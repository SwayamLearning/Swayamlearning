<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ManagementMaster.master" EnableEventValidation="true"  AutoEventWireup="true" CodeFile="MediaDashboard.aspx.cs" Inherits="Dashboard_MediaDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta http-equiv="Refresh" content="120" />    
     <style>
         .grid
         {
             font-size:15px !important;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <%--  <div class="row">
                            <div class="col-lg-6">
                                <div class="card mb-4">
                                    <div class="card-header"><i class="fas fa-chart-bar mr-1"></i>Bar Chart Example</div>
                                    <div class="card-body"><canvas id="myBarChart" width="100%" height="50"></canvas></div>
                                    <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="card mb-4">
                                    <div class="card-header"><i class="fas fa-chart-pie mr-1"></i>Pie Chart Example</div>
                                    <div class="card-body"><canvas id="myPieChart" width="100%" height="50"></canvas></div>
                                    <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
                                </div>
                            </div>
                        </div>--%>
    <div class="row">
        <div class="col-md-4">
            <asp:DropDownList ID="ddlregister"   AutoPostBack="true" CssClass="form-control" runat="server" IndexChanged = "OnSelectedIndexChanged">
             
                 <asp:ListItem Value="0">Free</asp:ListItem>
          <asp:ListItem Value="1">Paid</asp:ListItem>
     </asp:DropDownList>
   
        </div>
          <div class="col-md-4">
               <asp:Button ID="btndownload" Text="Download excel" runat="server" OnClick="btndownload_Click" />
        </div>
    </div>
     
     <div class="card mb-4">
                            <div class="card-header"><i class="fas fa-table mr-1"></i>Registration Details</div>
                            <div class="card-body">
                                <div class="table-responsive grid">
                                    <asp:GridView ID="gvRegistration" runat="server" AutoGenerateColumns="False"  
                        CssClass="table table-striped table-bordered table-hover dt-responsive"  AllowPaging="true" 
    AllowSorting="true" OnPageIndexChanging="gvRegistration_PageIndexChanging"
    PageSize = "10" >
                        <Columns>
                            <asp:TemplateField HeaderText="Student Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblSchool" runat="server" Text='<%# Eval("StudentName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText=" Board and Standard">
                                <ItemTemplate>
                                    <asp:Label ID="lblSchool" runat="server" Text='<%# Eval("BMS") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblBMSSCT" runat="server" Text='<%# Eval("ContactNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EmailID">
                                <ItemTemplate>
                                    <asp:Label ID="lblNote" runat="server" Text='<%# Eval("EmailID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Registration Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedOn" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy}", Eval("CreatedOn")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            No Registration Found
                        </EmptyDataTemplate>
                    </asp:GridView>
                                </div>
                            </div>
                        </div>

   <script type="text/javascript">
       window.onload = function () {
           debugger;
            window.history.forward(1);
        }
    </script>
</asp:Content>

