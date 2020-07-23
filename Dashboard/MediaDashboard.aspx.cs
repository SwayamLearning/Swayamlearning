using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp;
using System.IO;

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

         


            }
        if (ddlregister.SelectedValue == "0")
            {
            BindRegistrationGrid("Free");
            }
        else if (ddlregister.SelectedValue == "1")
            {
            BindRegistrationGrid("Paid");
            }


        }
    public override void VerifyRenderingInServerForm(Control control)
        {
        /* Verifies that the control is rendered */
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
        if (ddlregister.SelectedValue == "0")
            {
            BindRegistrationGrid("Free");
            }
        else if (ddlregister.SelectedValue == "1")
            {
            BindRegistrationGrid("Paid");
            }
        }

    protected void btndownload_Click(object sender, EventArgs e)
        {
        string filename = string.Empty;
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
      
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        StringWriter swr = new StringWriter();
        HtmlTextWriter htmlwr = new HtmlTextWriter(swr);
        gvRegistration.AllowPaging = false;
        if (ddlregister.SelectedValue == "0")
            {
            BAL_Student_BLogic = new Student_BLogic();
            DataSet dsTeacherNotes = new DataSet();
            dsTeacherNotes = BAL_Student_BLogic.BAL_Registration_Select("Free", "", "");
            if (dsTeacherNotes.Tables[0].Rows.Count > 0)
                {
                gvRegistration.DataSource = dsTeacherNotes.Tables[0];
                gvRegistration.DataBind();
                
                }
            filename = "Free_";
            }
        else if (ddlregister.SelectedValue == "1")
            {
            BindRegistrationGrid("Paid");
            filename = "Paid_";
            }
        Response.AddHeader("content-disposition", "attachment;filename="+filename+"Registration.xls");
        gvRegistration.RenderControl(htmlwr);
        Response.Output.Write(swr.ToString());
        Response.Flush();
        Response.End();
        }
    protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
        string p = ddlregister.SelectedItem.Value;
        BindRegistrationGrid(p);
        }
    }

