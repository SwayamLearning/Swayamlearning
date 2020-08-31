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
using System.Threading;
using System.Threading.Tasks;

public partial class Dashboard_BulkInvoice : System.Web.UI.Page
{
    Report rpt;
    private bool startConversion = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            // Package_BLogic PackageLogic = new Package_BLogic();
            //DataSet dstudent = PackageLogic.BAL_Select_studentdetails("837");
            // GridView1.DataSource = dstudent;
            // GridView1.DataBind();
            if (Request.QueryString.Count > 1)
            {
                if (Request.QueryString[0] != null && Request.QueryString[0] != null)
                {
                    string FromDate = HttpUtility.UrlDecode(Request.QueryString[0]);
                    string ToDate = HttpUtility.UrlDecode(Request.QueryString[1]);
                  string TransactionIDs= HttpUtility.UrlDecode(Request.QueryString[2]);

                    BindTransactionGrid(FromDate, ToDate, TransactionIDs);

                  
                }
            }

        }
    }


    public void BindTransactionGrid(string fromdate, string todate,string TransactionID)
    {

        try
        {
            //Task task = new Task(() =>
            //{
                Package_BLogic packagelogic = new Package_BLogic();
                DataSet dtransaction = new DataSet();
                DateTime dt2 = new DateTime(2020, 07, 20);

                if (fromdate == "") fromdate = null;
                if (todate == "") todate = null;
                dtransaction = packagelogic.BAL_Select_Successful_TransactionForPirnt("Success", fromdate, todate, TransactionID);
                if (dtransaction != null)
                {
                    if (dtransaction.Tables[0].Rows.Count > 0 && dtransaction != null)
                    {
                        GridView1.DataSource = dtransaction.Tables[0];
                        GridView1.DataBind();
                        startConversion = true;

                    }
                }
            //});
            //task.Start();
            //task.Wait();
           

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.ToString());
        }
    }


    //public void BindTransactionGrid(string fromdate, string todate)
    //{

    //    try
    //    {
    //        Package_BLogic packagelogic = new Package_BLogic();
    //        DataSet dtransaction = new DataSet();
    //        DateTime dt2 = new DateTime(2020, 07, 20);

    //        if (fromdate == "") fromdate = null;
    //        if (todate == "") todate = null;
    //        dtransaction = packagelogic.BAL_Select_Successful_Transaction("Success", fromdate, todate);
    //        if (dtransaction.Tables[0].Rows.Count > 0 && dtransaction != null)
    //        {
    //            GridView1.DataSource = dtransaction.Tables[0];
    //            GridView1.DataBind();
    //            startConversion = true;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        WebMsg.Show(ex.ToString());
    //    }
    //}
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
            string filename = DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString()+DateTime.Now.Day.ToString()+DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "_Invoice.pdf";
            //string filename =  "_Invoice.pdf";
            // save pdf document
            doc.Save(Response, false, filename);

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
    protected void btnExportInvoice_Click(object sender, EventArgs e)
    {
        startConversion = true;
    }
}