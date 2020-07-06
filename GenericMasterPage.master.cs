using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_GenericMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
        {

        if (!IsPostBack)
            {
            if (Session["ddindex"] != null)
                {
                ddlLanguage2.SelectedValue = Session["ddindex"].ToString();
                ddlLanguage2.SelectedIndex = Convert.ToInt32(Session["ddindex"].ToString());
                ddlLanguage1.SelectedValue = Session["ddindex"].ToString();
                ddlLanguage1.SelectedIndex = Convert.ToInt32(Session["ddindex"].ToString());
                }
            else
                {
                ddlLanguage2.SelectedValue = Thread.CurrentThread.CurrentCulture.Name;
                }
           // ddlLanguage2.SelectedValue = Thread.CurrentThread.CurrentCulture.Name;
            }
        }
    protected void ddlLanguage2_SelectedIndexChanged(object sender, EventArgs e)
        {

        HttpCookie cookie = new HttpCookie("CultureInfo");
        cookie.Value = ddlLanguage2.SelectedValue;
        Response.Cookies.Add(cookie);

        Thread.CurrentThread.CurrentCulture = new CultureInfo(ddlLanguage2.SelectedValue);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddlLanguage2.SelectedValue);
        ddlLanguage2.Enabled = false;
       
        if (cookie.Value == "en-US")
            {
            Session["ddindex"] = 0;
            }
        else if (cookie.Value == "gu-IN")
            {
            Session["ddindex"] = 1;
            }
        else Session["ddindex"] = 2;
        Server.Transfer(Request.Path);
        }
    protected void ddlLanguage1_SelectedIndexChanged(object sender, EventArgs e)
        {

        HttpCookie cookie = new HttpCookie("CultureInfo");
        cookie.Value = ddlLanguage1.SelectedValue;
        Response.Cookies.Add(cookie);

        Thread.CurrentThread.CurrentCulture = new CultureInfo(ddlLanguage1.SelectedValue);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddlLanguage1.SelectedValue);
        ddlLanguage1.Enabled = false;
        if (cookie.Value == "en-US")
            {
            Session["ddindex"] = 0;
            }
        else if (cookie.Value == "gu-IN")
            {
            Session["ddindex"] = 1;
            }
        else Session["ddindex"] = 2;
        Server.Transfer(Request.Path);

        }
    }
