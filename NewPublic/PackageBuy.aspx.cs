using CCA.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class NewPublic_PackageBuy : System.Web.UI.Page
    {
    #region Declaration
    Student_DashBoard_BLogic obj_BAL_Student_Dashboard;
    StudentDash obj_Student_Dashboard;
    string Pageindex = string.Empty;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
        {
        if(!IsPostBack)
            {
            //      GetStudentcurrentPackage();
            if (Request.QueryString["PageIndex"] != null)
                {
                Pageindex = Request.QueryString["PageIndex"].ToString();

                if (Pageindex == "1")
                    {
                    System.Web.UI.HtmlControls.HtmlGenericControl currdiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("dropdownmenu");
                    currdiv.Style.Add("display", "none");
                    // ((HtmlGenericControl)this.Page.FindControl("dropdown-content")).Style.Add("display", "none");
                    }
                }
                GetPaidpackagedetails();

            }
        }

    protected void GetStudentcurrentPackage()
        {
        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();
        obj_Student_Dashboard.StudentID = AppSessions.StudentID;
        DataSet ds = new DataSet();
        ds = obj_BAL_Student_Dashboard.BAL_Student_ExpiryNotification1(obj_Student_Dashboard);
        if (ds.Tables[1].Rows.Count>0)
            {
            //lblpackageName.Text = ds.Tables[1].Rows[0]["PackageName"].ToString();
            //LblSubjects.Text = ds.Tables[1].Rows[0]["Subject"].ToString();
            //LblValidity.Text= ds.Tables[1].Rows[0]["FromDate"].ToString()+"-"+ ds.Tables[1].Rows[0]["ValidTill"].ToString();
            //LblPrice.Text = ds.Tables[1].Rows[0]["Price"].ToString();
            }


        }
    protected void GetPaidpackagedetails()
        {
        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();
        obj_Student_Dashboard.StudentID = AppSessions.StudentID;
         int BMSID = Convert.ToInt16(AppSessions.BMSID);
        DataSet ds = new DataSet();
        ds = obj_BAL_Student_Dashboard.BAL_Student_ALL_Not_Purchased_Package(BMSID,AppSessions.StudentID,null);
        if (ds.Tables[0].Rows.Count > 0)
            {
          
            lblpackname.Text = ds.Tables[0].Rows[0]["PackageName"].ToString();
         //   LblPSubjects.Text = ds.Tables[0].Rows[0]["Subject"].ToString();
            int days = Convert.ToInt16(ds.Tables[0].Rows[0]["NoOfMonth"].ToString());
            days = days - 1;
            string validtill = DateTime.Today.AddDays(days).ToString("MMMM dd, yyyy");
            string fromdate = DateTime.Today.ToString("MMMM dd, yyyy");
          //  fromdate = DateTime.Today.ToString("MMMM dd, yyyy");
            lblvalidity.Text = fromdate + " to " + validtill;
            lblprice.Text = "Rs. "+ ds.Tables[0].Rows[0]["Price"].ToString();
            Session["price"]= ds.Tables[0].Rows[0]["Price"].ToString();
            lbldiscount.Text = "0";
            lbltotal.Text = ds.Tables[0].Rows[0]["Price"].ToString();


            }
        }


    [WebMethod]
    public static List<string> Checkcouponcode(string Couponcode)
        {
        
        Common_Blogic cbl = new Common_Blogic();
        DataSet dcoupon = new DataSet();
        List<string> result = new List<string>();
        dcoupon = cbl.BAL_Select_CouponInfo(Couponcode);
        if(dcoupon.Tables[0].Rows.Count>0)
            {
            result.Add("valid");
            int discountprice;
            int  discount   = Convert.ToInt16(dcoupon.Tables[0].Rows[0]["Discount"].ToString());
          int  maxdiscount = Convert.ToInt16(dcoupon.Tables[0].Rows[0]["MaxDiscount"].ToString());
            int price = Convert.ToInt16(HttpContext.Current.Session["price"].ToString());
            discountprice = (price * discount)/100;
            if(discountprice>maxdiscount)
                {
                discountprice = maxdiscount;
                }
            int finaltotal = price - discountprice;
            result.Add(Convert.ToString(discountprice));
            result.Add(Convert.ToString(finaltotal));
            HttpContext.Current.Session["finalprice"] = finaltotal;
            }
        
             

        return result;
        }
    protected void btnconfirm_Click(object sender, EventArgs e)
        {
        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();
        obj_Student_Dashboard.StudentID = AppSessions.StudentID;
        int BMSID = Convert.ToInt16(AppSessions.BMSID);
        string validity = "";
        DataSet ds = new DataSet();
        DateTime now = DateTime.Now;
        ds = obj_BAL_Student_Dashboard.BAL_Student_ALL_Not_Purchased_Package(BMSID, AppSessions.StudentID, null);
        if (ds.Tables[0].Rows.Count > 0)
            {
            DataTable dt = new DataTable();
            dt.Columns.Add("PackageID", typeof(string));
            dt.Columns.Add("PackageName", typeof(string));
            dt.Columns.Add("Subject", typeof(string));
            dt.Columns.Add("NoOfMonth", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            dt.Columns.Add("PackageType", typeof(string));
            dt.Columns.Add("ActivateOn", typeof(string));

            dt.Columns.Add("ExpiryDate", typeof(string));
            DataRow dtrow = dt.NewRow();
            dtrow["PackageID"] = ds.Tables[0].Rows[0]["PackageID"].ToString();
            dtrow["PackageName"] = ds.Tables[0].Rows[0]["PackageName"].ToString();           //Bind Data to Columns
            dtrow["Subject"] = ds.Tables[0].Rows[0]["Subject"].ToString();
            dtrow["NoOfMonth"] = ds.Tables[0].Rows[0]["NoOfMonth"].ToString();
            validity = ds.Tables[0].Rows[0]["NoOfMonth"].ToString();
          
                dtrow["Price"] = lbltotal.Text.ToString();
           

            dtrow["PackageType"] = "combo";
            dtrow["ActivateOn"] = DateTime.Today.ToString("dd/MMM/yyyy");
            now = now.AddDays(Convert.ToInt32(validity));
            now = now.AddDays(-1);
            //now = now.Date.ToString("dd/MMM/yyyy");
            dtrow["ExpiryDate"] = now.Date.ToString("dd/MMM/yyyy");
            dt.Rows.Add(dtrow);
            Session["SelectedPackage"] = dt;
            }
        Session["CurrencyType"] = "INR";
        Session["country_name"] = "India";
        if (Request.QueryString["PageIndex"] != null)
            Pageindex = Request.QueryString["PageIndex"].ToString();


        if (Pageindex == "1")
            Response.Redirect("PackagePayment.aspx?PageIndex=1");
        else Response.Redirect("PackagePayment.aspx");
        //string merchant_id = "264897"; //"99522";
        //string access_code = "AVJH93HG41AV94HJVA"; //"AVFW65DE39BV30WFVB";
        //string Working_key = "198C5C10C9BC8B5FEB23250E347F7A4C"; //"E85FE1783919FA34A4758580E844135A";
        //  string amount = PackagePrice.ToString();  //"1";
        //string requesturl = "";
        //string ccaRequest = "";
        //CCACrypto ccaCrypto = new CCACrypto();
        //Uri redirect_Uri = new Uri(System.Web.HttpContext.Current.Request.Url, "PaymentResponse.aspx");
        //string redirect_url = redirect_Uri.ToString();

        //Uri cancel_Uri = new Uri(System.Web.HttpContext.Current.Request.Url, "PackageBuy.aspx");
        //string cancel_url = cancel_Uri.ToString();
        //decimal PackagePrice = 10;//Convert.ToDecimal(Session["PackagePrice"].ToString().Trim());
        //  string TransactionID = "Tran1";
        //  ccaRequest = "tid=" + TransactionID;
        //ccaRequest += "&merchant_id=" + merchant_id;
        //ccaRequest += "&order_id=" + TransactionID+"1";
        //ccaRequest += "&amount=" + PackagePrice;
        //ccaRequest += "&currency=" + "INR";
        //ccaRequest += "&redirect_url=" + redirect_url + "&cancel_url=" + cancel_url;
        //   string CCAvenue_URL = "https://test.ccavenue.com/transaction/transaction.do?command=initiateTransaction&encRequest=";
        // string CCAvenue_URL = "https://secure.ccavenue.com/transaction/transaction.do?command=initiateTransaction&encRequest=";
        //    string strEncRequest = ccaCrypto.Encrypt(ccaRequest, Working_key);
        //requesturl = "https://secure.ccavenue.com/transaction/transaction.do?command=initiateTransaction&encRequest=" + strEncRequest + "&access_code=" + access_code;
        //requesturl = CCAvenue_URL + strEncRequest + "&access_code=" + access_code;
        // InsertIntoTransactionMaster("CCAvenue");
        //Response.Redirect(requesturl, false);
        }
    }