using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SwayamDemoHomepage : System.Web.UI.Page
    {
    public string backgroundImage ;
    protected void Page_Load(object sender, EventArgs e)
        {
        if (!IsPostBack)
            {
            // set dropdown default value using selectedvalue
            if (Session["ddindex"] != null)
                {
                if (Session["ddindex"].ToString() == "0")
                    {
                 //   backgroundImage = "App_Themes/Home/Homepagenewimages/Banner1_English_Desktop.jpg";
                    //DesktopBanner1.Style["background-image"]=
                    //DesktopBanner1.Style["background-image"] = Page.ResolveUrl("App_Themes/Home/Homepagenewimages/Banner1_English_Desktop.jpg");
                   // DesktopBanner1.Attributes.Add("style", " background-image: url('../Homepagenewimages/Banner1_English_Desktop.jpg')");

                    //imgdesktop1.Src = "App_Themes/Home/Homepagenewimages/Banner1_English_Desktop.jpg";
                   // imgmobile1.Src = "App_Themes/Home/Homepagenewimages/Banner1_English_Mobile.jpg";
                }
                if (Session["ddindex"].ToString() == "1")
                    {

                 //   backgroundImage = "App_Themes/Home/Homepagenewimages/Banner1_Gujarati_Desktop.jpg";
                    // DesktopBanner1.Attributes.Add("style", " background-image: url('App_Themes/Home/Homepagenewimages/Banner1_Gujarati_Desktop.jpg');");
                  //  DesktopBanner1.Attributes.Add("style", " background-image: url('../Homepagenewimages/Banner1_English_Desktop.jpg')");
                    //DesktopBanner1.Style["background-image"] = Page.ResolveUrl("App_Themes/Home/Homepagenewimages/Banner1_Gujarati_Desktop.jpg");
                    //imgdesktop1.Src = "App_Themes/Home/Homepagenewimages/Banner1_Gujarati_Desktop.jpg";
                  //  imgmobile1.Src = "App_Themes/Home/Homepagenewimages/Banner1_Gujarati_Mobile.jpg";
                }
                if (Session["ddindex"].ToString() == "2")
                    {
                  //  backgroundImage = "App_Themes/Home/Homepagenewimages/Banner1_Hindi_Desktop";
                 //   DesktopBanner1.Attributes.Add("style", " background-image: url('../Homepagenewimages/Banner1_English_Desktop.jpg')");
                    // DesktopBanner1.Attributes.Add("style", " background-image: url('App_Themes/Home/Homepagenewimages/Banner1_Hindi_Desktop.jpg');");
                    // DesktopBanner1.Style["background-image"] = Page.ResolveUrl("App_Themes/Home/Homepagenewimages/Banner1_Hindi_Desktop.jpg");
                    //imgdesktop1.Src = "App_Themes/Home/Homepagenewimages/Banner1_Hindi_Desktop.jpg";
                 //   imgmobile1.Src = "App_Themes/Home/Homepagenewimages/Banner1_Hindi_Mobile.jpg";
                }

                }
            }
        }
    }