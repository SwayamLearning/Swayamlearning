using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_AdminMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (AppSessions.EmpolyeeID.ToString() == "0" || AppSessions.StudentID.ToString() == string.Empty)
            {
                Response.Redirect("../NewPublic/login.aspx");
            }
            //else
            //{
            //    Response.Redirect("../Dashboard/EpathAdminDashboard.aspx");
            //}
            if(AppSessions.RoleID.ToString()=="17")
            {
                lireports.Visible = false;
                master.Visible = false;
                user.Visible = false;

            }
        }
    }
    
}
