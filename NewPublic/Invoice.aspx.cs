using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class NewPublic_Invoice : System.Web.UI.Page
    {
    #region Declaration
    Report rpt;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
        {
        if(!IsPostBack)
            {
            string studentid = AppSessions.StudentID.ToString();
            FillInvoiceDetails(studentid);
            }
        }
    protected void FillInvoiceDetails(string studentid)
        {
        rpt = new Report();
        DataSet dinvoicedet = new DataSet();
        dinvoicedet = rpt.GetInvoiceDetails(studentid);
        
        if(dinvoicedet.Tables[0].Rows.Count>0)
            {
             string custname= dinvoicedet.Tables[0].Rows[0]["CustomerName"].ToString();
            string  custbillingaddress = dinvoicedet.Tables[0].Rows[0]["BillingAddress"].ToString();
            string customerEmail = dinvoicedet.Tables[0].Rows[0]["CustomerEmailID"].ToString();
            string customermobileno= dinvoicedet.Tables[0].Rows[0]["CustomerMobileNo"].ToString();
            LblPackage.Text= dinvoicedet.Tables[0].Rows[0]["PackageName"].ToString();
            int packageprice = Convert.ToInt16(dinvoicedet.Tables[0].Rows[0]["Price"].ToString());
            double unitprice = packageprice / 1.18;
            Lblunitprice.Text = unitprice.ToString();
            LblAmount.Text= unitprice.ToString();
            Lblsubtotal.Text = unitprice.ToString();
            double cgst = unitprice * (0.09);
            double sgst = unitprice * (0.09);
            LblCGSTAmount.Text = cgst.ToString();
            LblSGSTamt.Text = sgst.ToString();
            double total = unitprice + cgst + sgst;
            LblTotal.Text = total.ToString();
            }
        }

    protected void btndownload_Click(object sender, EventArgs e)
        {
        exportpdf();
        }
    private void exportpdf()
        {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Invoice.odf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        Panel1.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 100f, 10f);
        HTMLWorker htmlparser = new HTMLWorker(pdfdoc);
        PdfWriter.GetInstance(pdfdoc, Response.OutputStream);
        pdfdoc.Open();
        htmlparser.Parse(sr);
        pdfdoc.Close();
        Response.Write(pdfdoc);
        Response.End();
             


        }
    }