using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;
public partial class NewPublic_contact : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //Page.StyleSheetTheme = "";
        Page.Theme = "";
    }
    protected override void InitializeCulture()
        {
        HttpCookie cookie = Request.Cookies["CultureInfo"];
        //string language = Session["ddindex"].ToString();
        //HttpCookie cookie = new HttpCookie("CultureInfo");
       
        //if (language == "0")
        //{
        //    cookie.Value = "en-US";

        //}
        //else if(language=="1")
        //{
        //    cookie.Value = "gu-IN";
        //}
        //else
        //    if (language=="2")
        //{
        //    cookie.Value = "hi-IN";
        //}
        
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

        if (!IsPostBack)
        {
            Response.Buffer = true;
            Response.CacheControl = "no-cache";
            Response.AddHeader("Pragma", "no-cache");
            Response.Expires = -1441;
            DropDownList ddllanguage1 = (DropDownList)Page.Master.FindControl("ddlLanguage1");
            ddllanguage1.Visible = false;

            DropDownList ddllanguage2 = (DropDownList)Page.Master.FindControl("ddlLanguage2");

            ddllanguage2.Visible = false;

        }
        if (ViewState["cultreinfo"].ToString() == "gu-IN")
            {
            TxtUserName.Attributes.Add("Placeholder", "નામ *");
            TxtUserMail.Attributes.Add("Placeholder", "ઇમેઇલ *");
            txtcontact.Attributes.Add("Placeholder", "મોબાઇલ નંબર *");
            TxtMessage.Attributes.Add("Placeholder", "તમારો પ્રશ્ન અહીં દાખલ કરો");
            TxtSchool.Attributes.Add("Placeholder", "સ્કૂલ");
            Emailtext.InnerText = "ઇમેઇલ";
            //visit.InnerText = "એડ્રેસ";
            //ptag.InnerText = "સેન્ટ ઝેવિયર્સ કોલેજ નજીક" + "\n" + "મીતાખાલી" + "\n" + "નવરંગપુરા" + "\n" + "અમદાવાદ, ગુજરાત-380009" + "\n";
            hcontact.InnerText = "અમારો સંપર્ક કરો";
            lblusername.InnerText = "નામ *";
            lblEmail.InnerText = "ઇમેઇલ *";
            lblcontact.InnerText = "મોબાઇલ નંબર *";
            lblMessage.InnerText = "તમારો પ્રશ્ન અહીં દાખલ કરો";
            lblschool.InnerText = "સ્કૂલ";
            btnsubmitquery.Value = "સંદેશ મોકલો";
          
            rblrole.Items[0].Text = "સ્ટુડન્ટ";
            rblrole.Items[2].Text = "સ્કૂલ";
            rblrole.Items[1].Text = "ટીચર";

        }
        if (ViewState["cultreinfo"].ToString() == "hi-IN")
            {
            TxtUserName.Attributes.Add("Placeholder", "नाम * ");
            TxtUserMail.Attributes.Add("Placeholder", "ईमेल *");
            txtcontact.Attributes.Add("Placeholder", "मोबाइल नंबर *");
            TxtMessage.Attributes.Add("Placeholder", "यहाँ अपना प्रश्न दर्ज करें");
            TxtSchool.Attributes.Add("Placeholder","स्कूल");
            Emailtext.InnerText = "ईमेल";
            lblschool.InnerText = "स्कूल";
            rblrole.Items[0].Text = "स्टूडेंट";
            rblrole.Items[2].Text = "स्कूल";
            rblrole.Items[1].Text = "टीचर";
            //  visit.InnerText = "पता";
            // ptag.InnerText = "सेंट जेवियर्स कॉलेज के पास" + "\n" + "मिथकली" + "\n" + "नवरंगपुराરા" + "\n" + "अहमदाबाद , गुजरात-३८०००९" + "\n";
            hcontact.InnerText = "संपर्क करें";
            lblusername.InnerText = "नाम *";
            lblEmail.InnerText = "ईमेल *";
            lblcontact.InnerText = "मोबाइल नंबर *";
            lblMessage.InnerText = "यहाँ अपना प्रश्न दर्ज करें";
            btnsubmitquery.Value = "मेसेज भेजें";
            }
    }



    protected void btnsubmitquery_Click(object sender, EventArgs e)
        {

        //Insert into inquiry table
        Inquiry inq = new Inquiry();
        Common_Blogic cb = new Common_Blogic();
        inq.Name = TxtUserName.Value;
        inq.Email = TxtUserMail.Value;
        inq.Contactno = txtcontact.Value;
        inq.Message = TxtMessage.Value;
        inq.SChoolName = TxtSchool.Value;
        inq.Role = rblrole.SelectedValue;
        bool result=cb.Inquiry_Insert(inq);
        string Message=string.Empty;



            ArrayList MailTo = new ArrayList();
            MailTo.Add("support@swayamlearning.org");
            //MailTo.Add("shyamala@nivedh.co.in");
            
            bool IssendSuccess = EmailUtility.SendEmail(MailTo, GetMailSubject(), GetMailBody(TxtUserName.Value, TxtUserMail.Value, txtcontact.Value, TxtMessage.Value,TxtSchool.Value,rblrole.SelectedItem.Text));
        if (IssendSuccess)
            if (ViewState["cultreinfo"].ToString() == "gu-IN")
            {
                Message = "અમારી સાથે સંપર્કમાં આવવા બદલ આભાર.જલ્દી પાછા મળશે";
            //    WebMsg.Show("અમારી સાથે સંપર્કમાં આવવા બદલ આભાર.જલ્દી પાછા મળશે");
                // Response.Write("<script>alert('અમારી સાથે સંપર્કમાં આવવા બદલ આભાર.જલ્દી પાછા મળશે');window.location.href='SwayamDemoHomePage.aspx'; return false;</script>");
            }
            else if (ViewState["cultreinfo"].ToString() == "hi-IN")

            {
                Message = "हमसे संपर्क करने के लिए धन्यवाद। जल्द ही मिलते हैं";
              //  WebMsg.Show("हमसे संपर्क करने के लिए धन्यवाद। जल्द ही मिलते हैं");
                //Response.Write("<script>alert('हमसे संपर्क करने के लिए धन्यवाद। जल्द ही मिलते हैं');window.location.href='SwayamDemoHomePage.aspx'; return false;</script>");
            }
            else
            {
                Message = "Thank you for getting in touch with us. We will reach out to you soon";
              //  WebMsg.Show("Thank you for getting in touch with us. We will reach out to you soon");
                //   Response.Write("<script>alert('Thank you for getting in touch with us. We will reach out to you soon');window.location.href='SwayamDemoHomePage.aspx'; return false;</script>");
            }
        else
        {
            if (ViewState["cultreinfo"].ToString() == "gu-IN")

            {
                Message = "મેહરબાની કરી ને ફરી થી પ્રયાસ કરો";
             //   WebMsg.Show("મેહરબાની કરી ને ફરી થી પ્રયાસ કરો");

                //Response.Write("<script>alert('મેહરબાની કરી ને ફરી થી પ્રયાસ કરો');</script>");
            }
            else
                 if (ViewState["cultreinfo"].ToString() == "hi-IN")
            {
                Message = "कृपया पुन: प्रयास करें";
              //  WebMsg.Show("कृपया पुन: प्रयास करें");
                //  Response.Write("<script>alert('कृपया पुन: प्रयास करें');</script>");
            }
            else
            {
                Message = "Sorry, we are not able to process your request at this time, Please try again later.";
            }
          //  WebMsg.Show("Sorry, we are not able to process your request at this time, Please try again later.");

            //Response.Write("<script>alert('Sorry, we are not able to process your request at this time, Please try again later.');window.location.href='SwayamDemoHomePage.aspx'; return false;</script>");
        }
        ShowMessage_Redirect(this.Page, Message, "SwayamDemoHomePage.aspx");
        clearcontrols();
         

        }

    protected void clearcontrols()
        {
        TxtUserName.Value = "";
        TxtUserMail.Value = "";
        txtcontact.Value = "";
        TxtMessage.Value = "";
        TxtSchool.Value = "";
        }
    private string GetMailBody(string name, string email, string phone, string comment,string school,string role)
        {
        StringBuilder oBuilder = new StringBuilder();
        oBuilder.Append("<div style='width: 700px; background-color: #71af32; padding:10px 0px 10px 10px; font-weight: bold;'>Query From ContactUs Page</div>");
        oBuilder.Append("<div style='width: 700px; background-color: #fff; padding:20px 0px 20px 8px; border: 1px solid #71af32;font-weight: bold;'>");
        oBuilder.Append("<table border='0' cellpadding='0' cellspacing='0'>");
        oBuilder.Append("<tr style='height:30px;'>");
        oBuilder.Append("<td style='width: 100px; text-align: right; padding-right: 10px;'>");
        oBuilder.Append("Name:");
        oBuilder.Append("</td>");
        oBuilder.Append("<td>");
        oBuilder.Append(name);
        oBuilder.Append("</td>");
        oBuilder.Append("</tr>");
        oBuilder.Append("<tr style='height:30px;'>");
        oBuilder.Append("<td style='width: 100px; text-align: right; padding-right: 10px;'>");
        oBuilder.Append("Email:");
        oBuilder.Append("</td>");
        oBuilder.Append("<td>");
        oBuilder.Append(email);
        oBuilder.Append("</td>");
        oBuilder.Append("</tr>");
        oBuilder.Append("<tr style='height:30px;'>");
        oBuilder.Append("<td style='width: 100px; text-align: right; padding-right: 10px;'>");
        oBuilder.Append("Phone:");
        oBuilder.Append("</td>");
        oBuilder.Append("<td>");
        oBuilder.Append(phone);
        oBuilder.Append("</td>");
        oBuilder.Append("</tr>");
        oBuilder.Append("<tr style='height:30px;'>");
        oBuilder.Append("<td style='width: 100px; text-align: right; padding-right: 10px;'>");
        oBuilder.Append("School Name:");
        oBuilder.Append("</td>");
        oBuilder.Append("<td>");
        oBuilder.Append(school);
        oBuilder.Append("</td>");
        oBuilder.Append("</tr>");
        oBuilder.Append("<tr style='height:30px;'>");
        oBuilder.Append("<td style='width: 100px; text-align: right; padding-right: 10px;'>");
        oBuilder.Append("Role:");
        oBuilder.Append("</td>");
        oBuilder.Append("<td>");
        oBuilder.Append(role);
        oBuilder.Append("</td>");
        oBuilder.Append("</tr>");
        oBuilder.Append("<tr style='height:30px;'>");
        oBuilder.Append("<td style='width: 100px; text-align: right; padding-right: 10px; vertical-align: top;'>");
        oBuilder.Append("Comment:");
        oBuilder.Append("</td>");
        oBuilder.Append("<td style='vertical-align: top;'>");
        oBuilder.Append(comment);
        oBuilder.Append("</td>");
        oBuilder.Append("</tr>");
        oBuilder.Append("</table>");
        oBuilder.Append("</div>");

        return Convert.ToString(oBuilder);
        }
    public string GetMailSubject()
        {
        return "Query From ContactUs page: " + DateTime.Now.ToString("dd MMM, yyyy");
        }
    public void ShowMessage_Redirect(System.Web.UI.Page page, string Message, string Redirect_URL)
    {
        string alertMessage = "<script language=\"javascript\" type=\"text/javascript\">";

        alertMessage += "alert('" + Message + "');";
        alertMessage += "window.location.href=\"";
        alertMessage += Redirect_URL;
        alertMessage += "\";";
        alertMessage += "</script>";

        ClientScript.RegisterClientScriptBlock(GetType(), "alertMessage ", alertMessage);

    }
}
