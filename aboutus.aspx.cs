using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewPublic_aboutus : System.Web.UI.Page
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
        //else if (language == "1")
        //{
        //    cookie.Value = "gu-IN";
        //}
        //else
        //    if (language == "2")
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
            DropDownList ddllanguage1 = (DropDownList)Page.Master.FindControl("ddlLanguage1");
            ddllanguage1.Visible = false;

            DropDownList ddllanguage2 = (DropDownList)Page.Master.FindControl("ddlLanguage2");

            ddllanguage2.Visible = false;

        }
    }
}