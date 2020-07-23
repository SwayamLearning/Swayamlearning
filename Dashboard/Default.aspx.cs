using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CCA.Util;

public partial class Dashboard_Default : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
        {

        }

    protected void btnccavenue_Click(object sender, EventArgs e)
        {
        string merchant_id = "264897"; //"99522";
        string access_code = "AVJH93HG41AV94HJVA"; //"AVFW65DE39BV30WFVB";
        string Working_key = "8A9A03150204BA6F759C94F100A895C6"; //"E85FE1783919FA34A4758580E844135A";
     //   string amount = "1";  //"1";
        string requesturl = "";
        string ccaRequest = "";
        CCACrypto ccaCrypto = new CCACrypto();
        Session["country_name"] = "India";
        
        Uri redirect_Uri;
        string resurl = string.Empty;
        
            redirect_Uri = new Uri(System.Web.HttpContext.Current.Request.Url, "../NewPublic/CCAvenueResponse.aspx");
        // Uri redirect_Uri = new Uri(System.Web.HttpContext.Current.Request.Url, "../NewPublic/CCAvenueResponse.aspx?PageIndex=1");
        string redirect_url = redirect_Uri.ToString();

        Uri cancel_Uri = new Uri(System.Web.HttpContext.Current.Request.Url, "../NewPublic/PackageBuy.aspx");
        string cancel_url = cancel_Uri.ToString();
        decimal PackagePrice = 10;//Convert.ToDecimal(Session["PackagePrice"].ToString().Trim());
        string TransactionID = "";
        string billing_name = "std1";
        // string billing_country = "India";
        string billing_tel = "1234567890";
        string billing_email = "abc@gmail.com";
        Random rnd = new Random();
        TransactionID ="1"+ rnd.Next(1000);
        ccaRequest = "tid=" + TransactionID;
        ccaRequest += "&merchant_id=" + merchant_id;
        ccaRequest += "&order_id=" + TransactionID; 
        ccaRequest += "&amount=" + PackagePrice;
        ccaRequest += "&currency=" + "INR";
        ccaRequest += "&redirect_url=" + redirect_url + "&cancel_url=" + cancel_url;
        ccaRequest += "&billing_name=" + billing_name;
        ccaRequest += "&billing_tel=" + billing_tel;
        ccaRequest += "&billing_email=" + billing_email;
         string CCAvenue_URL = "https://test.ccavenue.com/transaction/transaction.do?command=initiateTransaction&encRequest=";
     //   string CCAvenue_URL = "https://secure.ccavenue.com/transaction/transaction.do?command=initiateTransaction&encRequest=";
        string strEncRequest = ccaCrypto.Encrypt(ccaRequest, Working_key);
        //   requesturl = "https://secure.ccavenue.com/transaction/transaction.do?command=initiateTransaction&encRequest=" + strEncRequest + "&access_code=" + access_code;
        requesturl = CCAvenue_URL + strEncRequest + "&access_code=" + access_code;
       
        Response.Redirect(requesturl, false);
        }
    }