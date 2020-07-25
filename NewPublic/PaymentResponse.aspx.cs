using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data;
using System.Collections;
using System.Text;
using CCA.Util;

public partial class NewPublic_PaymentResponse : System.Web.UI.Page
{
    #region Declaration
    Package_BLogic Blogic_Package;
    Package PPackage;
    #endregion
    protected override void InitializeCulture()
    {
        HttpCookie cookie = Request.Cookies["CultureInfo"];

        if (cookie != null && cookie.Value != null)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie.Value);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie.Value);
            ViewState["cultreinfo"] = cookie.Value;
        }
        else
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            ViewState["cultreinfo"] = "en-US";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //string CCAvenue_Working_key = "198C5C10C9BC8B5FEB23250E347F7A4C";
        //string Working_key = CCAvenue_Working_key;
        //CCACrypto ccaCrypto = new CCACrypto();
        //string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], Working_key);
        //
        if (!IsPostBack)
        {
            CCAvenueTransation();
        }
    }
    protected void RedirectPage()
    {

        Response.AddHeader("REFRESH", "10;URL=PackageBuy.aspx");

    }
    protected string GetInvoiceID()
    {
        string InvoiceID = string.Empty;

        DataAccess ODataAccess = new DataAccess();
        DataTable dtInvoiceNumber = new DataTable();

        dtInvoiceNumber = ODataAccess.GetDataTable("select Top(1) InvoiceID from TransactionMaster order by InvoiceID DESC");

        if (dtInvoiceNumber != null)
        {
            if (dtInvoiceNumber.Rows.Count > 0)
            {

                InvoiceID = dtInvoiceNumber.Rows[0]["InvoiceID"].ToString();
                if (InvoiceID != string.Empty)
                {
                    int NewInvoiceNumber = Convert.ToInt32(InvoiceID.Substring(6));
                    NewInvoiceNumber = NewInvoiceNumber + 1;

                    if (DateTime.Now.ToString("MM") == InvoiceID.Substring(0, 2).ToString())
                    {
                        InvoiceID = DateTime.Now.ToString("MM") + DateTime.Now.ToString("yyyy") + NewInvoiceNumber.ToString().PadLeft(4, '0');
                    }
                    else
                    {
                        InvoiceID = DateTime.Now.ToString("MM") + DateTime.Now.ToString("yyyy") + "0001";
                    }
                }
                else
                {
                    InvoiceID = DateTime.Now.ToString("MM") + DateTime.Now.ToString("yyyy") + "0001";
                }
                return InvoiceID;
            }

            else
            {
                InvoiceID = DateTime.Now.ToString("MM") + DateTime.Now.ToString("yyyy") + "0001";
            }
        }

        return InvoiceID;
    }
    protected void SendTransactionDetails(string BuildEmailBody, string EmailID)
    {
        DataSet dsSettings = new DataSet();
        Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("TransactionMailID");
        string TransactionMailIDList = "support@swayamlearning.org";
        ArrayList alistEmailAddress = new ArrayList();
        alistEmailAddress.Add(TransactionMailIDList);
        alistEmailAddress.Add(EmailID);
        // ArrayList alistEmailAddress = new ArrayList(TransactionMailIDList.Split(','));
        //CommiteAgain
        string response = SendMail(alistEmailAddress, "Transaction Detail ", BuildEmailBody);

    }
    private static string SendMail(ArrayList emailId, string mailSubject, string mailContent)
    {
        string Response = string.Empty;


        if (emailId.Count > 0)
        {
            bool IsSendSuccess = EmailUtility.SendEmail(emailId, mailSubject, mailContent);
            if (IsSendSuccess)
                Response = "Email Sent Successfully.";
            else
                Response = "Sending Email failed.";
        }
        return Response;
    }

    private string SendSMS(string mobilenumber, string smscontent)
    {
        bool IsSendSuccess = EmailUtility.SendSms(mobilenumber, smscontent, "1", "0");
        string Response;
        if (IsSendSuccess)
            Response = "SMS Sent Successfully.";
        else
            Response = "Sending SMS failed.";
        return Response;
    }

    protected string BuildEmailBody(string productname, string clientname, string mobilenumber, string Emailid, decimal amount, string BankName, string strDateTime, string transferstatus, string MerchantTransactionID, string AtomTransactionID)
    {
        StringBuilder oBuilder = new StringBuilder();
        try
        {
            oBuilder.Append("<div style=\'font-family: Calibri,Cambria,verdana; color: #4C3636;\'>");
            oBuilder.Append("<div style=\'font-family: Trebuchet MS,Georgia,Verdana,Tahoma; color: #4C3636;\'>");
            oBuilder.Append("<table width=72% style=\'margin: 10px; border: 5px SOLID SILVER; border-radius: 5px;\' border=0>");
            oBuilder.Append("<tr> <td> ");
            oBuilder.Append("<div style=\'background-color: #2f378e; height: 35px; font-size: 21px; font-weight: bold; padding: 10px;\'> <span style=\'color: white; display: block;\'>Transaction Response</span></div>");
            oBuilder.Append("</td></tr>");
            oBuilder.Append("<tr> <td style=\'font-size: 16px;\'>");
            oBuilder.Append("<div id=dvcontent style=\'font-size: 14px; padding: 20px; background-color: #F4F4F4;\'> ");
            oBuilder.Append("<div><table border=1 width=100% >");
            oBuilder.Append(" <tr> <td style=\' width: 235px;\'> Product </td> <td style=\' width: 235px;\'> " + productname + " </td> </tr>");
            oBuilder.Append("<tr> <td style=\' width: 235px;\'> Client Name </td> <td style=\' width: 235px;\'> " + clientname + " </td> </tr>");
            oBuilder.Append("<tr> <td style=\' width: 235px;\'> Mobile Number </td> <td style=\' width: 235px;\'> " + mobilenumber + " </td> </tr>");
            oBuilder.Append("<tr> <td style=\' width: 235px;\'> Email Address </td> <td style=\' width: 235px;\'> " + Emailid + " </td> </tr>");
            oBuilder.Append("<tr> <td style=\' width: 235px;\'> Amount Transferred </td> <td style=\' width: 235px;\'> " + amount.ToString("F") + " (INR) </td> </tr>");
            oBuilder.Append("<tr> <td style=\' width: 235px;\'> Bank Name </td> <td style=\' width: 235px;\'> " + BankName + " </td> </tr>");
            oBuilder.Append("<tr> <td style=\' width: 235px;\'> Date and Time </td> <td style=\' width: 235px;\'> " + strDateTime + "  </td> </tr>");
            oBuilder.Append("<tr> <td> Funds Transfer Status </td> <td style=\' width: 235px;\'> " + transferstatus + "  </td> </tr>");
            oBuilder.Append("<tr> <td style=\' width: 235px;\'> Merchant Transaction ID </td> <td style=\' width: 235px;\'> " + MerchantTransactionID + " </td> </tr>");
            oBuilder.Append("<tr> <td style=\' width: 235px;\'> Transaction ID </td> <td style=\' width: 235px;\'> " + AtomTransactionID + " </td> </tr>");
            oBuilder.Append("</table> </div> </div></td></tr></table></div></div>");
        }
        catch
        {

        }
        return oBuilder.ToString();
    }
    protected string BuildSMSBody(string orderid, string orderstatus, string trackingid, string amount, string billingname)
    {
        string message = string.Empty;
        try
        {

            message = "Dear" + billingname;
            message = message + "status of transaction is " + orderstatus + "!!" + "orderid=" + orderid + "-" + "amount=" + amount;

        }
        catch
        {

        }
        return message;
    }
    protected void CCAvenueTransation()
    {
        try
        {
            DataSet dsSettings = new DataSet();
            Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();

            //dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("CCAvenue_Working_key");
            //string CCAvenue_Working_key = dsSettings.Tables[0].Rows[0]["value"].ToString().Trim();

            //Development Server
            //string CCAvenue_Working_key="8A9A03150204BA6F759C94F100A895C6";
            //Live Server


            //Development Server test environment
             string CCAvenue_Working_key="8A9A03150204BA6F759C94F100A895C6";
            //Live Server test environment
            //  string CCAvenue_Working_key = "38135271AB5444D9D3F50D7051586C90";
            //Live server production environment
          //  string CCAvenue_Working_key = "6FE78A90A0D0AD43A6549E1F4D3F1562";
            string Working_key = CCAvenue_Working_key;
            
            CCACrypto ccaCrypto = new CCACrypto();
            NameValueCollection Params2 = Request.Form;
            string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], Working_key);
            // txtResponse.Text = encResponse;
            NameValueCollection Params = new NameValueCollection();
            string[] segments = encResponse.Split('&');
            foreach (string seg in segments)
            {
                string[] parts = seg.Split('=');
                if (parts.Length > 0)
                {
                    string Key = parts[0].Trim();
                    string Value = parts[1].Trim();
                    Params.Add(Key, Value);
                }
            }

            string order_id = Params["order_id"];
            string tracking_id = Params["tracking_id"];
            string bank_ref_no = Params["bank_ref_no"];
            string order_status = Params["order_status"];
            string failure_message = Params["failure_message"];
            string payment_mode = Params["payment_mode"];
            string card_name = Params["card_name"];
            string status_code = Params["status_code"];
            string status_message = Params["status_message"];
            string currency = Params["currency"];
            string amount = Params["amount"];
            string billing_name = Params["billing_name"];
            string billing_address = Params["billing_address"];
            string billing_city = Params["billing_city"];
            string billing_state = Params["billing_state"];
            string billing_zip = Params["billing_zip"];
            string billing_country = Params["billing_country"];
            string billing_tel = Params["billing_tel"];
            string billing_email = Params["billing_email"];
            string delivery_name = Params["delivery_name"];
            string delivery_address = Params["delivery_address"];
            string delivery_city = Params["delivery_city"];
            string delivery_state = Params["delivery_state"];
            string delivery_zip = Params["delivery_zip"];
            string delivery_country = Params["delivery_country"];
            string delivery_tel = Params["delivery_tel"];
            string merchant_param1 = Params["merchant_param1"];
            string merchant_param2 = Params["merchant_param2"];
            string merchant_param3 = Params["merchant_param3"];
            string merchant_param4 = Params["merchant_param4"];
            string merchant_param5 = Params["merchant_param5"];
            string vault = Params["vault"];
            string offer_type = Params["offer_type"];
            string offer_code = Params["offer_code"];
            string discount_value = Params["discount_value"];
            string mer_amount = Params["mer_amount"];
            string eci_value = Params["eci_value"];
            string retry = Params["retry"];
            string response_code = Params["response_code"];
            PPackage = new Package();
            PPackage.TransactionID = order_id;
            PPackage.PaymentGateway = "CCAvenue";
            PPackage.PaymentMode = payment_mode;
            PPackage.CardName = card_name;
            PPackage.CCAvenueStatusCode = status_code;
            PPackage.Currency = currency;
            PPackage.Country = billing_country;
            PPackage.Vault = vault;
            PPackage.OfferType = offer_type;
            PPackage.OfferCode = offer_code;
            PPackage.Discount = Convert.ToDecimal(discount_value);
            PPackage.MerchantAmount = Convert.ToDecimal(mer_amount);
            PPackage.ECIValue = eci_value;
            PPackage.Retry = retry;
            PPackage.ResponseCode = response_code;

            string[] Ord = order_id.Split('/');
            string strOrderid = Ord[0].ToString();
            string[] stdId = Ord[1].ToString().Split(':');

            if (order_status.ToUpper().Trim() != "FAILURE" && order_status.ToUpper().Trim() != "ABORTED")
            {

                string culture = ViewState["cultreinfo"].ToString();
                if (culture == "gu-IN")
                {
                    lblthankyou.Text = " આભાર ";
                    lblthankyou.ForeColor = System.Drawing.Color.Black;
                    lblmessage1.Text = " તમારો લેવડદેવડ સફળતાપૂર્વક છે આગળના ઉપયોગ માટે કૃપા કરીને તમારો વ્યવહાર નંબર નોંધો.     ";
                    lbltransactionnumber.Text = "તમારો વ્યવહાર નંબર છે: " + strOrderid;
                }
                else if (culture == "hi-IN")
                {
                    lblthankyou.Text = " धन्यवाद ";
                    lblthankyou.ForeColor = System.Drawing.Color.Black;
                    lblmessage1.Text = " आपका लेन-देन सफल है कृपया आगे उपयोग के लिए अपने लेनदेन नंबर को नोट करें. ";
                    lbltransactionnumber.Text = "आपका लेनदेन नंबर है: " + strOrderid;
                }
                else
                {
                    lblthankyou.Text = " Thank You ";
                    lblthankyou.ForeColor = System.Drawing.Color.Black;
                    lblmessage1.Text = " Your Transaction is successfull Please note down your Transaction number for further use. ";
                    lbltransactionnumber.Text = "Your Transaction Number is: " + strOrderid;

                }
              

                // order_id = Session["TransactionID"].ToString();
                Blogic_Package = new Package_BLogic();
                PPackage = new Package();

                PPackage.PackageFD_ID = 0;
                PPackage.StudentID = Convert.ToInt32(stdId[0].ToString());
                PPackage.PackageActivationDate = DateTime.Now.Date;
                PPackage.EndDate = DateTime.Now.Date;
                PPackage.TransactionID = strOrderid.ToString();
                Blogic_Package.BAL_Student_Package_Insert(PPackage);

                //DataTable dt = (DataTable)(Session["SelectedPackage"]);
                //for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //    PPackage.PackageFD_ID = Convert.ToInt64(dt.Rows[i]["PackageID"].ToString());
                //    PPackage.StudentID = AppSessions.StudentID;
                //    PPackage.PackageActivationDate = Convert.ToDateTime(dt.Rows[i]["ActivateOn"].ToString());
                //    PPackage.EndDate = Convert.ToDateTime(dt.Rows[i]["ExpiryDate"].ToString());
                //    PPackage.TransactionID = order_id.ToString();
                //    Blogic_Package.BAL_Student_Package_Insert(PPackage);
                //    }

                PPackage = new Package();
                PPackage.TransactionID = strOrderid;
                PPackage.Status = order_status;
                PPackage.InvoiceID = GetInvoiceID();
                Blogic_Package.BAL_Student_Package_Update_TransactionMaster(PPackage, "Transaction is successfull", tracking_id, "CCAvenue", "", bank_ref_no, delivery_name, billing_email, billing_tel, billing_address, "", "", "");
                if (billing_email != "")
                    SendTransactionDetails(BuildEmailBody("Swayam Learning", delivery_name, billing_tel, billing_email, Convert.ToDecimal(amount), card_name, DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"), order_status.ToString(), strOrderid, tracking_id), billing_email);
                if (billing_tel != "")
                    SendSMS(billing_tel, BuildSMSBody(strOrderid, order_status, tracking_id, amount, billing_name));
                string message = "Transaction successful Login again ";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert(" + message + ")", true);
                AppSessions.StudentID = Convert.ToInt32(stdId[0].ToString());
                Response.AddHeader("REFRESH", "10;URL=../Logout.aspx?param=" + stdId[0].ToString());
            }

            else if (order_status.ToUpper().Trim() == "ABORTED")
            {

                lblthankyou.ForeColor = System.Drawing.Color.Black;
                string culture = ViewState["cultreinfo"].ToString();
                if (culture == "gu-IN")
                {

                    lblmessage1.Text = " તમે લેવડદેવડ રદ કર્યો છે.";
                }
                else if (culture == "hi-IN")
                {
                    lblmessage1.Text = " आपने लेन-देन रद्द कर दिया है।";
                }
                else
                {
                    lblmessage1.Text = " You have cancelled transaction.";
                }
              

                Blogic_Package = new Package_BLogic();
                PPackage = new Package();
                PPackage.TransactionID = strOrderid;
                PPackage.Status = order_status;
                Blogic_Package.BAL_Student_Package_Update_TransactionMaster(PPackage, "Transaction cancelled by user.", tracking_id, "CCAvenue", "", bank_ref_no, delivery_name, billing_email, billing_tel, billing_address, "", "", "");
                if (billing_email != "")
                    SendTransactionDetails(BuildEmailBody("Swayam Learning", billing_name, billing_tel, billing_email, Convert.ToDecimal(amount), card_name, DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"), "Transaction cancelled by user.", strOrderid, tracking_id), billing_email);
                //if (billing_tel != "")
                //{
                //    //  SendTransactionDetails(BuildSMSBody("Swayam Learning",AppSessions.UserName,Session))
                //}
                AppSessions.StudentID = Convert.ToInt32(stdId[0].ToString());
                Response.AddHeader("REFRESH", "10;URL=../Logout.aspx?param=" + stdId[0].ToString());
               // RedirectPage();
                //Response.AddHeader("REFRESH", "10;URL=../Dashboard/StudentDashboard.aspx");
            }
            else
            {
                string culture = ViewState["cultreinfo"].ToString();
                if (culture == "gu-IN")
                {
                    lblthankyou.Text = " અસુવિધા બદલ માફ કરજો ";
                    lblthankyou.ForeColor = System.Drawing.Color.Red;
                    lblmessage1.Text = "વ્યવહાર સફળ નથી, કૃપા કરીને ફરીથી પ્રયાસ કરો ....";
                    lblmessage1.ForeColor = System.Drawing.Color.Red;
                }
                else if (culture == "hi-IN")
                {
                    lblthankyou.Text = " असुविधा के लिए खेद है ";
                    lblthankyou.ForeColor = System.Drawing.Color.Red;
                    lblmessage1.Text = "लेन-देन सफल नहीं है कृपया पुनः प्रयास करें ...।";
                    lblmessage1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblthankyou.Text = " Sorry for inconvenience ";
                    lblthankyou.ForeColor = System.Drawing.Color.Red;
                    lblmessage1.Text = "Transaction is not successful please try again....";
                    lblmessage1.ForeColor = System.Drawing.Color.Red;
                }
                Blogic_Package = new Package_BLogic();
              
                PPackage.TransactionID = strOrderid;
                PPackage.Status = order_status;

                //PPackage.InvoiceID = GetInvoiceID();
                Blogic_Package.BAL_Student_Package_Update_TransactionMaster(PPackage, "Transaction is not successful", tracking_id, "CCAvenue", "", bank_ref_no, delivery_name, billing_email, billing_tel, billing_address, "", "", "");

                if (billing_email != "")
                SendTransactionDetails(BuildEmailBody("Swayam Learning", delivery_name, billing_tel, billing_email, Convert.ToDecimal(amount), card_name, DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"), "Fail", strOrderid, tracking_id), billing_email);


                AppSessions.StudentID = Convert.ToInt32(stdId[0].ToString());
                Response.AddHeader("REFRESH", "10;URL=../Logout.aspx?param=" + stdId[0].ToString());
                //Response.AddHeader("REFRESH", "10;URL=SelectPackage.aspx");
            }
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert(" + ex.Message.ToString() + ")", true);
        }
    }
}