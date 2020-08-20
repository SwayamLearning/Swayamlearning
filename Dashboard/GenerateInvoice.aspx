<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SwayamAdminMaster.master" AutoEventWireup="true" CodeFile="GenerateInvoice.aspx.cs" Inherits="Admin_GenerateInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">
        <div class="row">
            <div class="col-md-4">
                 
                        From Date:
                           
                        <asp:TextBox ID="TxtFrom" runat="server" TextMode="Date"></asp:TextBox>
                     
                </div>
               
               
            
            <div class="col-md-8">
                <div class="row">
                     
                        To Date
                          
                    
                        <asp:TextBox ID="TxttoDate" runat="server" TextMode="Date"></asp:TextBox>
                  
                    
                        <asp:Button ID="btnsearch" runat="server" Text="Display" OnClick="btnsearch_Click" />
                     
                        <asp:Button ID="btnExportInvoice" runat="server" OnClick="btnExportInvoice_Click" Text="Export Invoices" />
                     
                </div>
               
               
            </div>
        </div>

        <asp:GridView ID="gridTransaction" runat="server" AllowPaging="true" AutoGenerateColumns="false" EmptyDataText="No Records found" ShowHeaderWhenEmpty="true" CssClass="table table-striped table-bordered table-hover"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"
            OnPageIndexChanging="gridTransaction_PageIndexChanging">
            <AlternatingRowStyle BackColor="#CCCCCC" />
             <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="TransactionID Ref" />
                    <asp:BoundField DataField="StudentName" HeaderText="Student Name"  />
                    <asp:BoundField DataField="PurchaseDate" HeaderText="Purchase Date"  />
                    <asp:BoundField DataField="Price" HeaderText="Price" Visible="false" />
                    
                    <asp:BoundField DataField="FromDate" HeaderText="Activation Date" DataFormatString="{0:dd MMM, yyyy}"  />
                    <asp:BoundField DataField="ValidTill" HeaderText="Validity" DataFormatString="{0:dd MMM, yyyy}" />
                   <%-- <asp:BoundField DataField="Status" HeaderText="Status" />--%>
                    <asp:TemplateField HeaderText="View">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("~/Invoice.aspx?PackageName={0}&Subject={1}&ActivateOn={2}&Price={3}&NoOfMonth={4}&ValidTill={5}&TransactionID={6}&RegisteredOn={7}&StateName={8}",
                    HttpUtility.UrlEncode(Eval("PackageName").ToString()), HttpUtility.UrlEncode(Eval("Subject").ToString()), HttpUtility.UrlEncode(Eval("FromDate").ToString()) , HttpUtility.UrlEncode(Eval("Price").ToString()), HttpUtility.UrlEncode(Eval("NoOfMonth").ToString()), HttpUtility.UrlEncode(Eval("ValidTill").ToString()), HttpUtility.UrlEncode(Eval("TransactionID").ToString()), HttpUtility.UrlEncode(Eval("ActivateOn").ToString()), HttpUtility.UrlEncode(Eval("StateName").ToString())) %>'
                                Text="View" Target="_blank" ForeColor="Blue" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <span style="color: #000000; font-size: x-large; font-weight: bold; font-family: 'Times New Roman', Times, serif">No Data Found.</span>
                </EmptyDataTemplate>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="#cfcfcf" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:GridView>

       
    </div>
</asp:Content>

