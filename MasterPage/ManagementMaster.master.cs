using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_ManagementMaster : System.Web.UI.MasterPage
{
    Common_Blogic cbl = new Common_Blogic();
    protected void Page_Load(object sender, EventArgs e)
        {

        Session.Abandon();
        Session.Clear();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("if(history.length>=0)history.go(+1)");

        DataSet dregcount = new DataSet();
        dregcount = cbl.BAL_Registration_count();
        if (dregcount.Tables.Count > 0)
            {
          
           
         

            if (dregcount.Tables[0].Rows.Count > 0)
                {
                string GSEBcount = Convert.ToString(dregcount.Tables[0].Rows[0]["GSEBcount"]);
                LblGSEB.Text = GSEBcount;
                }
            if (dregcount.Tables[1].Rows.Count > 0)
                {
                string UPCount = Convert.ToString(dregcount.Tables[1].Rows[0]["UPcount"]);
                LblIP.Text = UPCount;
                }
            if (dregcount.Tables[2].Rows.Count > 0)
                {
                string CBSEEngcount = Convert.ToString(dregcount.Tables[2].Rows[0]["cbseengcount"]);
                Lblcbseeng.Text = CBSEEngcount;
                }
            if (dregcount.Tables[3].Rows.Count > 0)
                {
                string CBSEHINcount = Convert.ToString(dregcount.Tables[3].Rows[0]["cbsehindicount"]);
                Lblcbsehin.Text = CBSEHINcount;
                    
                }

            }

            Bindgrid( );

        }

    private void Bindgrid( )
        {
       
        DataSet dmonthwise = new DataSet();
        dmonthwise = cbl.BAL_Registration_count_monthwise();
        if (dmonthwise.Tables.Count > 0)
            {

            if (dmonthwise.Tables[0].Rows.Count > 0)
                {
                GridGSEB.DataSource = dmonthwise.Tables[0];
                GridGSEB.DataBind();
                }

            if (dmonthwise.Tables[1].Rows.Count > 0)
                {
                GridUP.DataSource = dmonthwise.Tables[1];
                GridUP.DataBind();
                }

            if (dmonthwise.Tables[2].Rows.Count > 0)
                {
                GridCBSEHin.DataSource = dmonthwise.Tables[2];
                GridCBSEHin.DataBind();
                }
          
            if (dmonthwise.Tables[3].Rows.Count > 0)
                {
                GridCBSEEng.DataSource = dmonthwise.Tables[3];
                GridCBSEEng.DataBind();
                }

            }
        }

    public void GridGSEB_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {

        GridGSEB.PageIndex = e.NewPageIndex;
        Bindgrid();
        }
    public void GridUP_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {

        GridUP.PageIndex = e.NewPageIndex;
        Bindgrid();
        }
    public void GridCBSEHin_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {

        GridCBSEHin.PageIndex = e.NewPageIndex;
        Bindgrid();
        }
    public void GridCBSEEng_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {

        GridCBSEEng.PageIndex = e.NewPageIndex;
        Bindgrid();
        }
    }
