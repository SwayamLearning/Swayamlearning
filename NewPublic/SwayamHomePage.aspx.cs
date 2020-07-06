using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;

public partial class NewPublic_SwayamHomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //protected override void InitializeCulture()
    //{
    //    string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
    //    // 'set culture to current thread 
    //    System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
    //    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
    //    //call base class 
    //    base.InitializeCulture();
    //}

    //protected override void InitializeCulture()
    //{
    //    string culture = Convert.ToString("gu-IN");
    //    // 'set culture to current thread
    //    System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
    //    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
    //    //call base class
    //    base.InitializeCulture();
    //}

    //protected override void InitializeCulture()
    //{
    //    if (Session["culture"] != null)
    //    {
    //        DropDownList lblUserVal = (DropDownList)Page.Master.FindControl("cmbCulture");
    //        string culture = Session["culture"].ToString();
    //        //culture = "gu-IN";

    //        if (string.IsNullOrEmpty(culture))
    //            culture = "Auto";
    //        //Use this
    //        UICulture = culture;
    //        Culture = culture;
    //        //OR This
    //        if (culture != "Auto")
    //        {
    //            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo(culture);
    //            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
    //            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
    //        }

    //        base.InitializeCulture();
    //    }
       
    //}
}