using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Hirs.Coverter;
//using System.IO;
//using iTextSharp.text;

//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;


using System.Text;
using System.Net;
using System.Web.Services;
using SelectPdf;
using System.IO;




public partial class Invoice : System.Web.UI.Page
{
    private bool startConversion = false;

    #region Declaration
    string TransactionID;
    #endregion

    #region Page Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string package = HttpUtility.UrlDecode(Request.QueryString[0]);
            string subject = HttpUtility.UrlDecode(Request.QueryString[1]);
            string ValidFrom = HttpUtility.UrlDecode(Request.QueryString[2]);
            string Price = HttpUtility.UrlDecode(Request.QueryString[3]);
            string NoOfMonth = HttpUtility.UrlDecode(Request.QueryString[4]);
            string ValidTill = HttpUtility.UrlDecode(Request.QueryString[5]);
            TransactionID = HttpUtility.UrlDecode(Request.QueryString[6]);
            string RegistrationDate = HttpUtility.UrlDecode(Request.QueryString[7]);
            string stateName = HttpUtility.UrlDecode(Request.QueryString[8]);
            RegistrationDate = Convert.ToDateTime(RegistrationDate).ToString("dd MMM, yyyy");

            lblstudentname.Text = "Name: " + AppSessions.UserName;
            lblpackagename.Text = package;
            lblsubject.Text = subject;
            lblfromdate.Text = Convert.ToDateTime(ValidFrom).ToString("dd MMM, yyyy");
            double unitprice = Convert.ToDouble(Price) / 1.18;
            double cgst = Convert.ToDouble(unitprice) * (0.09);
            double sgst = Convert.ToDouble(unitprice) * (0.09);
            


            price.Text = Convert.ToDouble(unitprice).ToString("00.00");
            lblvalidtill.Text = Convert.ToDateTime(ValidTill).ToString("dd MMM, yyyy");
            //lblmonth.Text = NoOfMonth;
            DateTime date1 = Convert.ToDateTime(ValidFrom);
            DateTime date2 = Convert.ToDateTime(ValidTill);
            lblmonth.Text = Convert.ToString(((date2.Year - date1.Year) * 12) + date2.Month - date1.Month);
            lbltotal.Text = price.Text;

            DataSet dsSettings = new DataSet();
            Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("PaymentDiscout");
            string PaymentDiscout = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

            dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("PaymentTax");
            string PaymentTax = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();



            lbldiscount.Text = Convert.ToDecimal(PaymentDiscout).ToString("00.00");
            double discount = Convert.ToDouble(PaymentDiscout);
            if (stateName == "Gujarat")
            {
                lbltax.Text = Convert.ToDouble(cgst).ToString("00.00");
                Lblsgst.Text = Convert.ToDouble(sgst).ToString("00.00");
                lblCgstTitle.Text = "CGST @9%";
                Lblsgst.Visible = true;
                lblplussign.Visible = true;
                Lblsgst.Visible = true;
                SGSTRow.Visible = true;
            }
            else
            {
                lbltax.Text = Convert.ToDouble(cgst+sgst).ToString("00.00");
                lblCgstTitle.Text = "IGST @18%";
                Lblsgst.Visible = false;
                lblplussign.Visible = false;
                Lblsgst.Visible = false;
                SGSTRow.Visible = false;
            }
            double grandtotal = unitprice + cgst + sgst - discount;
            //lblgrandtotal.Text = (Convert.ToDecimal(price.Text) - Convert.ToDecimal(lbldiscount.Text) + Convert.ToDecimal(lbltax.Text)).ToString();
            lblgrandtotal.Text = grandtotal.ToString("00.00");
            //  Convert.ToDecimal(price.Text) - Convert.ToDecimal(lbldiscount.Text) + Convert.ToDecimal(lbltax.Text).ToString()+ Convert.ToDecimal(Lblsgst.Text);

            ConvertToWord(lblgrandtotal.Text);
            string source = AppSessions.BMS.ToString();
            string[] stringSeparators = new string[] { ">>" };
            string[] result;
            result = source.Split(stringSeparators, StringSplitOptions.None);
            lblboard.Text = "Board: " + result[0];
            lblmideum.Text = "Medium: " + result[1];
            lblstandard.Text = "Standard: " + result[2];
            lblinvoicedate.Text = "Invoice Date: " + RegistrationDate.ToString();
            GetInvoiceNumber();


        }
        catch (Exception ex)
        {

        }


    }
    #endregion

    #region Methods

    protected void ConvertToWord(string numericvalue)
    {
        try
        {
            MultiCurrency OMultiCurrency = new MultiCurrency(Criteria.Indian);

            string digit = numericvalue.Trim();
            string FinalValue = string.Empty;
            string[] decimlacount = digit.Split('.');
            if (decimlacount.Length > 2)
            {
                FinalValue = "Only one decimal point allowed";
            }
            else if (decimlacount.Length == 1)
            {
                FinalValue = OMultiCurrency.ConvertToWord(digit, System.Drawing.Color.Black);
            }
            else
            {
                if (decimlacount[1].ToString() == "00")
                {
                    FinalValue = OMultiCurrency.ConvertToWord(digit.Substring(0, digit.IndexOf('.')), System.Drawing.Color.Black) + "Rupees Only";
                }
                else
                {
                    FinalValue = OMultiCurrency.ConvertToWord(digit.Substring(0, digit.IndexOf('.')), System.Drawing.Color.Black);
                    FinalValue = FinalValue + "Rupees and ";
                    OMultiCurrency = new MultiCurrency(Criteria.Indian);
                    FinalValue = FinalValue + OMultiCurrency.ConvertToWord(digit.Substring(digit.IndexOf('.') + 1), System.Drawing.Color.Black);
                    FinalValue = FinalValue + "Paisa Only";
                }
            }
            lblnumericstring.Text += FinalValue;
        }
        catch (Exception ex)
        {
        }
    }

    protected void GetInvoiceNumber()
    {
        try
        {
            DataAccess ODataAccess = new DataAccess();
            DataTable dtInvoiceNo = new DataTable();
            dtInvoiceNo = ODataAccess.GetDataTable("Select InvoiceID,Amount from TransactionMaster where TransactionID = '" + TransactionID + "'");
            lblinvoicenumber.Text = "Invoice No: " + dtInvoiceNo.Rows[0]["InvoiceID"].ToString();
            //price.Text = dtInvoiceNo.Rows[0]["Amount"].ToString();
            //price.Text = Convert.ToDecimal(dtInvoiceNo.Rows[0]["Amount"].ToString()).ToString("0.00");
            //lbltotal.Text = price.Text;


        }
        catch (Exception ex)
        {
        }
    }

    #endregion

    protected override void Render(HtmlTextWriter writer)
    {
        if (startConversion)
        {
            btnExportInvoice.Visible = false;
            // get html of the page
            TextWriter myWriter = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(myWriter);
            base.Render(htmlWriter);

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // create a new pdf document converting the html string of the page
            PdfDocument doc = converter.ConvertHtmlString(
                myWriter.ToString(), Request.Url.AbsoluteUri);

            // save pdf document
            doc.Save(Response, false, "Invoice.pdf");

            // close pdf document
            doc.Close();
           btnExportInvoice.Visible = true;
        }
        else
        {
            // render web page in browser
            base.Render(writer);
        }
    }
    #region CommentedExport
    //protected void btndownload_Click(object sender, EventArgs e)
    //{
    //    //Response.ContentType = "application/pdf";
    //    //Response.AddHeader("content-disposition", "attachment;filename=Invoice.pdf");
    //    //Response.Charset = "UTF-8";
    //    //Response.ContentEncoding = System.Text.Encoding.UTF8;
    //    //Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    //StringWriter sw = new StringWriter();
    //    //HtmlTextWriter hw = new HtmlTextWriter(sw);
    //    //pnlInvoice.RenderControl(hw);
    //    //StringReader sr = new StringReader(sw.ToString());
    //    //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
    //    //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //    //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //    //pdfDoc.Open();
    //    ////PdfPTable table = new PdfPTable(2);
    //    ////table.WidthPercentage = 100;

    //    ////PdfPCell cell = new PdfPCell(new Phrase("Test"));
        
    //    ////cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
    //    ////cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
    //    ////cell.BackgroundColor = new iTextSharp.text.BaseColor(51, 102, 102);

    //    ////table.AddCell(cell);
    //    ////pdfDoc.Add(table);
    //    //htmlparser.Parse(sr);
    //    //pdfDoc.Close();
    //    //Response.Write(pdfDoc);
    //    //Response.End();

    //    DownloadAsPDF();

    //}
    //public void DownloadAsPDF()
    //{
    //    try
    //    {
    //        string strHtml = string.Empty;
    //        string pdfFileName = Request.PhysicalApplicationPath + "\\" + "Invoicebtndownload_Click.pdf";
    //        StringWriter sw = new StringWriter();
    //        HtmlTextWriter hw = new HtmlTextWriter(sw);
    //        pnlInvoice.RenderControl(hw);
    //        StringReader sr = new StringReader(sw.ToString());
    //        strHtml = sr.ReadToEnd();
    //        sr.Close();

    //        string HTMLBodyContent = "<div style='font-family:arial unicode ms;'>" + strHtml + "</div>";

    //        CreatePDFFromHTMLFile(HTMLBodyContent, pdfFileName);

    //        Response.ContentType = "application/x-download";
    //        Response.AddHeader("Content-Disposition", string.Format("attachment; filename=\"{0}\"", "Invoice.pdf"));
    //        Response.ContentEncoding = Encoding.UTF8;
    //        Response.WriteFile(pdfFileName);
    //        Response.HeaderEncoding = Encoding.UTF8;
    //        Response.Flush();
    //        Response.End();
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //    }
    //}

    //private void CreatePDFFromHTMLFile(string html, string FileName)
    //{
        
    //    TextReader reader = new StringReader(html);
    //    Document document = new Document(PageSize.A4, 5, 5, 5, 5);
    //    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(FileName, FileMode.Create));
    //    HTMLWorker worker = new HTMLWorker(document);

    //    document.Open();        
    //    FontFactory.Register("C:\\Windows\\Fonts\\ARIALUNI.TTF", "arial unicode ms");        
    //    iTextSharp.text.html.simpleparser.StyleSheet ST = new iTextSharp.text.html.simpleparser.StyleSheet();
    //    ST.LoadTagStyle("body", "encoding", "Identity-H");        
    //    worker.SetStyleSheet(ST);// = ST;
    //    worker.StartDocument();
    //    worker.Parse(reader);

        
    //    worker.EndDocument();
    //    worker.Close();
    //    document.Close();
    //}
    //protected void btntest_Click(object sender, EventArgs e)
    //{
    //    ////Create a byte array that will eventually hold our final PDF
    //    //Byte[] bytes;

    //    ////Boilerplate iTextSharp setup here
    //    ////Create a stream that we can write to, in this case a MemoryStream
    //    //using (var ms = new MemoryStream())
    //    //{
    //     Response.ContentType = "application/pdf";
    //    Response.AddHeader("content-disposition", "attachment;filename=Invoice.pdf");
    //    //Response.Charset = "UTF-8";
    //    //Response.ContentEncoding = System.Text.Encoding.UTF8;
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //        //Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF
    //        using (var doc = new Document())
    //        {

    //            //Create a writer that's bound to our PDF abstraction and our stream
    //            using (var writer = PdfWriter.GetInstance(doc,  Response.OutputStream))
    //            {

    //                //Open the document for writing
    //                doc.Open();

    //                //Our sample HTML and CSS
    //                StringWriter sw = new StringWriter();
    //                HtmlTextWriter hw = new HtmlTextWriter(sw);
    //                pnlInvoice.RenderControl(hw);

    //                var example_html = @"<p>This <em>is </em><span class=""headline"" style=""text-decoration: underline;"">જુલાઈ</span> <strong>sample <em> text</em></strong><span style=""color: red;"">!!!</span></p>";
    //                var example_css = @".headline{font-size:200%}";

    //                /**************************************************
    //                 * Example #1                                     *
    //                 *                                                *
    //                 * Use the built-in HTMLWorker to parse the HTML. *
    //                 * Only inline CSS is supported.                  *
    //                 * ************************************************/

    //                //Create a new HTMLWorker bound to our document
    //                using (var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(doc))
    //                {

    //                    //HTMLWorker doesn't read a string directly but instead needs a TextReader (which StringReader subclasses)
    //                    using (var sr = new StringReader(example_html))
    //                    {

    //                        //Parse the HTML
    //                        htmlWorker.Parse(sr);
    //                    }
    //                }

    //                doc.Close();
    //                Response.Write(doc);
    //                Response.End();
    //            }
    //        }

    //        //After all of the PDF "stuff" above is done and closed but **before** we
    //        //close the MemoryStream, grab all of the active bytes from the stream
    //    //    //bytes = ms.ToArray();
    //    //}
    //    ////var testFile = Path.Combine(Server.MapPath("~/InvoicePath/"), "test.pdf");
    //    ////System.IO.File.WriteAllBytes(testFile, bytes);
    //    ////Response.Redirect(testFile);
    //}
   
    //protected void btnNrecoExport_Click(object sender, EventArgs e)
    //{
    //   // WebMethod();
    //}

    //private void WebMethod()
    //{
    //    #region Code for Generate PDF file
    //    //string relativePath = "NewPublic/PDFGenerator.aspx/GetStudentInvoice";
    //    // this works, because the protocol is included in the string

    //    string uriS = (Request.Url.ToString()).Replace("/Invoice.aspx?", "/NewPublic/PDFGenerator.aspx?RptType=StudentInvoice&InvoiceID=1&");
    //    WebRequest request = (HttpWebRequest)WebRequest.Create(uriS);
    //    request.Timeout = 500000;
    //    var response = request.GetResponse();
    //    WebHeaderCollection header = response.Headers;
    //    var encoding = System.Text.Encoding.UTF8;
       
    //    using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
    //    {
    //        using (var memstream = new MemoryStream())
    //        {
    //            var buffer = new byte[5000];
    //            var bytesRead = default(int);
    //            while ((bytesRead = reader.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
    //                memstream.Write(buffer, 0, bytesRead);

    //            Response.Clear();
    //            Response.ContentType = "Application/pdf";
    //            Response.AddHeader("Content-Disposition", "attachment; filename=Offerletter.pdf");
    //            Response.BinaryWrite(memstream.ToArray());
    //            Response.Flush();
    //            //Response.Close();
    //            memstream.Flush();
    //            memstream.Close();
    //            //Response.End();
    //        }
    //    }
    //    #endregion
    //}
    #endregion CommentedExport
    protected void btnExportInvoice_Click(object sender, EventArgs e)
    {
        startConversion = true;
    }
}
