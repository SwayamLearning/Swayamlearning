using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard_MediaDashboard : System.Web.UI.Page
{
    Student_BLogic BAL_Student_BLogic;
    Student oStudent;
    protected void Page_Load(object sender, EventArgs e)
    {
        Common_Blogic cbl = new Common_Blogic();
        UserLogtime_BLogic bal_logic = new UserLogtime_BLogic();
        DataSet ds = new DataSet();

        //Session.Abandon();
        //Session.Clear();
        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //sb.Append("<script type = 'text/javascript'>");
        //sb.Append("if(history.length>=0)history.go(+1)");
     
        //sb.Append("</script>");
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString()); 
    //    Page.RegisterClientScriptBlock("", "<script>if(history.length>=0)history.go(+1);</script>");
        if (!IsPostBack)
        {
            ds = bal_logic.BAL_Visitors_Count();

            string count = ds.Tables[0].Rows[0]["Visitorscount"].ToString();
            Label lblvisitor = (Label)Master.FindControl("lblvisitorscount");
            Label lblgseb = (Label)Master.FindControl("LblGSEB");
            Label lblcbsehin = (Label)Master.FindControl("Lblcbsehin");
            Label lblcbseeng = (Label)Master.FindControl("Lblcbseeng");
            Label lblUP = (Label)Master.FindControl("LblIP");
            lblvisitor.Text = count;

           

            BindRegistrationGrid("TOP");

        }

    }

    private void BindRegistrationGrid(string p)
    {
        try
        {
            BAL_Student_BLogic = new Student_BLogic();
            DataSet dsTeacherNotes = new DataSet();
            dsTeacherNotes = BAL_Student_BLogic.BAL_Registration_Select(p, "", "");
            if (dsTeacherNotes.Tables[0].Rows.Count > 0)
            {
                gvRegistration.DataSource = dsTeacherNotes.Tables[0];
                gvRegistration.DataBind();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    public void gvRegistration_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {

        gvRegistration.PageIndex = e.NewPageIndex;
        BindRegistrationGrid("TOP");
    }
}

