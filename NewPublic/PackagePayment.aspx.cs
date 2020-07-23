using CCA.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


public partial class NewPublic_PackagePayment : System.Web.UI.Page
{
    decimal PackagePrice;
    string TransactionID = string.Empty;
    string Pageindex = string.Empty;
    SYS_State_BLogic BAL_SYS_State;
    SYS_State SYS_State;
    SYS_Country PCountry = new SYS_Country();
    SYS_Country_BLogic BLCountry = new SYS_Country_BLogic();
    SYS_State_BLogic BLState = new SYS_State_BLogic();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["PageIndex"] != null)
        {
           Pageindex = Request.QueryString["PageIndex"].ToString();

           if (Pageindex == "1")
             {
                System.Web.UI.HtmlControls.HtmlGenericControl currdiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("dropdownmenu");
                currdiv.Style.Add("display", "none");
                }
         }
        if (!IsPostBack)
        {
            if (Request.QueryString["PageIndex"] != null)
            {
                Pageindex = Request.QueryString["PageIndex"].ToString();

                if (Pageindex == "1")
                {
                    System.Web.UI.HtmlControls.HtmlGenericControl currdiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("dropdownmenu");
                    currdiv.Style.Add("display", "none");
                    }
            }
            DataTable dt = (DataTable)(Session["SelectedPackage"]);
            if (dt != null)
            {
                lblpackname.Text = dt.Rows[0]["PackageName"].ToString();    
                lblvalidity.Text = "1 year- Till  " + dt.Rows[0]["ExpiryDate"].ToString();
                lblprice.Text = dt.Rows[0]["Price"].ToString();
            }
            Session["PackagePrice"] = Convert.ToInt32(Convert.ToDouble(dt.Rows[0]["Price"].ToString()));
            PackagePrice = Convert.ToDecimal(Session["PackagePrice"].ToString().Trim());
            GetStudentDetails1();

            DataSet dsCountries = new DataSet();
            PCountry.countryid = Convert.ToInt32(EnumFile.AssignValue.Zero);
            dsCountries = BLCountry.BAL_SYS_Country_Select(PCountry, "Select");
            BindDropDown(dsCountries, ddlCountryID);
            BindState();
        }
    }
    private void BindState()
    {
        if (ddlCountryID.SelectedValue != ((int)EnumFile.AssignValue.Zero).ToString())
        {
            ddlStateID.Items.Clear();
            BLState.BindListByID(ddlStateID, "ByCountryID", int.Parse(ddlCountryID.SelectedValue));
            ddlStateID.Enabled = true;
            ddlStateID.SelectedIndex = 1;
        }
        else if (ddlCountryID.SelectedValue == ((int)EnumFile.AssignValue.Zero).ToString())
        {
            ddlStateID.Items.Clear();
            ddlStateID.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
            ddlStateID.Items[0].Value = ((int)EnumFile.AssignValue.Zero).ToString();
            ddlStateID.Enabled = false;

        }
    }
    private void BindDropDown(DataSet dsCountries, DropDownList ddl)
    {
        ddl.DataSource = dsCountries;
        ddl.DataTextField = dsCountries.Tables[0].Columns["Country"].ToString();
        ddl.DataValueField = dsCountries.Tables[0].Columns["CountryID"].ToString();
        ddl.DataBind();
        //ddl.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
        //ddl.Items[0].Value = ((int)EnumFile.AssignValue.One).ToString();
    }
    private void BindDropDownState(DataSet dsCountries, DropDownList ddl)
    {
        ddl.DataSource = dsCountries;
        ddl.DataTextField = dsCountries.Tables[0].Columns["State"].ToString();
        ddl.DataValueField = dsCountries.Tables[0].Columns["StateID"].ToString();
        ddl.DataBind();
        //ddl.Items.Insert(Convert.ToInt32(EnumFile.AssignValue.Zero), "-- Select --");
        //ddl.Items[0].Value = ((int)EnumFile.AssignValue.One).ToString();
    }
    protected void GetStudentDetails1()
    {
        DataTable DTStudent = new DataTable();
        try
        {
            DataAccess ODataAccessEpathshalaStudent = new DataAccess();
            DTStudent = ODataAccessEpathshalaStudent.GetDataTable("select * from Student where StudentID = '" + AppSessions.StudentID + "'");
            Lblfname.Text = DTStudent.Rows[0]["firstName"].ToString() + " " + DTStudent.Rows[0]["lastName"].ToString();
            LblEmail.Text = DTStudent.Rows[0]["emailid"].ToString();
            txtAddress.Text = DTStudent.Rows[0]["Address"].ToString();
            txtZipCode.Text = DTStudent.Rows[0]["zipcode"].ToString();
            txtCity.Text = DTStudent.Rows[0]["City"].ToString();
            if (DTStudent.Rows[0]["ContactNo"].ToString() != "0")
            {
                Lblmobile.Text = DTStudent.Rows[0]["ContactNo"].ToString();
            }
            // LblAddress.Text = DTStudent.Rows[0]["Address"].ToString();


            DataTable dt = (DataTable)(Session["SelectedPackage"]);


        }
        catch (Exception ex)
        {
        }

    }
    protected void btncontinue_Click(object sender, EventArgs e)
    {
        string merchant_id = "264897"; //"99522";
        string access_code = "AVJH93HG41AV94HJVA"; //"AVFW65DE39BV30WFVB";
        string Working_key = "8A9A03150204BA6F759C94F100A895C6"; //"E85FE1783919FA34A4758580E844135A";

        //production server test keys
        //  string access_code = "AVIE93HG33AO20EIOA"; //"AVFW65DE39BV30WFVB";
        //   string Working_key = "38135271AB5444D9D3F50D7051586C90"; //"E85FE1783919FA34A4758580E844135A";

        //production server production keys
        //string access_code = "AVIE93HG33AO20EIOA"; //"AVFW65DE39BV30WFVB";
        //string Working_key = "6FE78A90A0D0AD43A6549E1F4D3F1562"; //"E85FE1783919FA34A4758580E844135A";

        string amount = Session["PackagePrice"].ToString();  //"1";
        string requesturl = "";
        string ccaRequest = "";
        CCACrypto ccaCrypto = new CCACrypto();
        Session["country_name"] = "India";
        string studentid = AppSessions.StudentID.ToString();
        string bmsid = AppSessions.BMSID.ToString();
        Uri redirect_Uri;
        string resurl = string.Empty;


        if (Pageindex == "1")
        {
            resurl = "../NewPublic/PaymentResponse.aspx";
            redirect_Uri = new Uri(System.Web.HttpContext.Current.Request.Url, resurl);
        }
        else
            redirect_Uri = new Uri(System.Web.HttpContext.Current.Request.Url, "../NewPublic/PaymentResponse.aspx");
        // Uri redirect_Uri = new Uri(System.Web.HttpContext.Current.Request.Url, "../NewPublic/CCAvenueResponse.aspx?PageIndex=1");
        string redirect_url = redirect_Uri.ToString();

        Uri cancel_Uri = new Uri(System.Web.HttpContext.Current.Request.Url, "PaymentResponse.aspx");
        string cancel_url = cancel_Uri.ToString();
        decimal PackagePrice = Convert.ToDecimal(Session["PackagePrice"].ToString().Trim());
        string TransactionID = "";
        string billing_name = Lblfname.Text;
        // string billing_country = "India";
        string billing_tel = Lblmobile.Text;
        string billing_email = LblEmail.Text;
        Random rnd = new Random();
        TransactionID = GetTransactionID("CCAvenue");// + rnd.Next(1000);
        ccaRequest = "tid=" + TransactionID;
        ccaRequest += "&merchant_id=" + merchant_id;
        ccaRequest += "&order_id=" + TransactionID + "/" + studentid + ":" + bmsid;
        ccaRequest += "&amount=" + PackagePrice;
        ccaRequest += "&currency=" + "INR";
        ccaRequest += "&redirect_url=" + redirect_url + "&cancel_url=" + cancel_url;
        ccaRequest += "&billing_name=" + billing_name;
        ccaRequest += "&billing_tel=" + billing_tel;
        ccaRequest += "&billing_address=" + txtAddress.Text;
        ccaRequest += "&billing_city=" + txtCity.Text;
        ccaRequest += "&billing_zip=" + txtZipCode.Text;
        ccaRequest += "&billing_state=" + ddlStateID.SelectedItem.Text.ToString();
        ccaRequest += "&billing_country=" + ddlCountryID.SelectedItem.Text.ToString();
        ccaRequest += "&billing_email=" + billing_email;
       string CCAvenue_URL = "https://test.ccavenue.com/transaction/transaction.do?command=initiateTransaction&encRequest=";
       // string CCAvenue_URL = "https://secure.ccavenue.com/transaction/transaction.do?command=initiateTransaction&encRequest=";
        string strEncRequest = ccaCrypto.Encrypt(ccaRequest, Working_key);
        //   requesturl = "https://secure.ccavenue.com/transaction/transaction.do?command=initiateTransaction&encRequest=" + strEncRequest + "&access_code=" + access_code;
        requesturl = CCAvenue_URL + strEncRequest + "&access_code=" + access_code;
        InsertIntoTransactionMaster(TransactionID);
        Response.Redirect(requesturl, false);
        // Session["TransactionID"] = "20071400001947";
        //    Response.Redirect(redirect_url);
    }
    public async System.Threading.Tasks.Task InsertIntoTransactionMaster(string TransactionID)
    {
        try
        {
            DataTable dt = (DataTable)Session["SelectedPackage"];
            Session["EndDate"] = dt.Rows[0]["ExpiryDate"].ToString();
            Package_BLogic OPackage_Blogic = new Package_BLogic();
            Package Opackage = new Package();
            string packageID = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                packageID += dt.Rows[i]["PackageID"].ToString() + ",";
            }
            Opackage.StudentID = Convert.ToInt32(AppSessions.StudentID);
            Opackage.PackgeID = packageID.Substring(0, packageID.Length - 1);
            PackagePrice = Convert.ToDecimal(Session["PackagePrice"].ToString().Trim());
            Opackage.Price = PackagePrice;
            Opackage.Status = "In Progress";

            Session["TransactionID"] = TransactionID.ToString();
            Opackage.TransactionID = TransactionID.ToString().Trim();
            Opackage.BMSID = AppSessions.BMSID;
            Opackage.BoardID = AppSessions.BoardID;
            Opackage.MediumID = AppSessions.MediumID;
            Opackage.StandardID = AppSessions.StandardID;
            // Opackage.ProductID = Productid.ToString();
            //student address update
            OPackage_Blogic.InsertTransactionDetailsWithStudentDetails(Opackage, txtAddress.Text, txtCity.Text, txtZipCode.Text, ddlCountryID.SelectedItem.Text, ddlStateID.SelectedItem.Text);
            // OPackage_Blogic.InsertTransactionDetails(Opackage);
            }
        catch (Exception ex)
        {
        }
    }
    protected string GetTransactionID(string ProductID)
    {
        string NewTransactionID = string.Empty;
        //string CCavenueTransactionID = string.Empty;
        try
                  {
            Package_BLogic OPackageBlogic = new Package_BLogic();
            DataSet dsTransactionID = new DataSet();

            dsTransactionID = OPackageBlogic.BAL_Select_TransactionID(ProductID);
            if (dsTransactionID != null)
            {
                if (dsTransactionID.Tables[0].Rows.Count > 0)
                {
                    if (ProductID.ToString().ToLower() == "ccavenue")
                    {

                        NewTransactionID = dsTransactionID.Tables[0].Rows[0]["TXNNO"].ToString();
                        if (NewTransactionID != string.Empty)
                        {
                            long NewTransactionNumber = Convert.ToInt64(NewTransactionID.Substring(6));
                            NewTransactionNumber = NewTransactionNumber + 1;

                            //if (DateTime.Now.ToString("dd") == NewTransactionID.Substring(4, 2).ToString())
                            //{
                                NewTransactionID = DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + NewTransactionNumber.ToString().PadLeft(5, '0');
                            //}
                            //else
                            //{
                            //    NewTransactionID = DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + "00001";
                            //}

                        }
                        else
                        {
                            NewTransactionID = DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + "00001";

                        }

                    }
                    else
                    {
                        string strTransactionID = dsTransactionID.Tables[0].Rows[0]["TXNNO"].ToString();

                        if (strTransactionID.ToString().Trim() == string.Empty)
                        {
                            NewTransactionID = "TXN1";
                        }
                        else
                        {
                            int TransactionCount = Convert.ToInt32(strTransactionID);
                            TransactionCount = TransactionCount + 1;
                            NewTransactionID = "TXN" + TransactionCount.ToString().Trim();
                        }

                    }
                }
                else
                {
                    if (ProductID.ToString().ToLower() == "ccavenue")
                    {
                        NewTransactionID = DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + "000001";
                    }
                    else
                    {
                        NewTransactionID = "TXN1";
                    }
                }
            }
            return NewTransactionID;
        }
        catch (Exception ex)
        {
            return "";
        }

    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Dashboard/StudentDashboard.aspx");
    }
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindState();
    }


}