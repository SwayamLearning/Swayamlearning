using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading.Tasks;

public partial class Admin_GenerateInvoice : System.Web.UI.Page
{
    Package_BLogic packagelogic;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TxttoDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            DateTime dt2 = new DateTime(2020, 07, 20);
            TxtFrom.Attributes["min"] = dt2.ToString("dd-MM-yyyy");
            TxtFrom.Text = dt2.ToString("dd-MM-yyyy");
            btnExportInvoice.Visible = false;
        }

    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (TxtFrom.Text != "")
        {
            if (TxttoDate.Text == "")
            {
                TxttoDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            }
        }
        if (TxtFrom.Text == "")
        {
            DateTime dt2 = new DateTime(2020, 07, 20);
            TxtFrom.Text = dt2.ToString("dd-MM-yyyy");
        }

        BindTransactionGrid();
    }

    public void BindTransactionGrid()
    {

        try
        {
            packagelogic = new Package_BLogic();
            DataSet dtransaction = new DataSet();
            string fromdate = TxtFrom.Text;
            string todate = TxttoDate.Text;
            if (fromdate == "") fromdate = null;
            if (todate == "") todate = null;
            dtransaction = packagelogic.BAL_Select_Successful_Transaction("Success", fromdate, todate);
            if (dtransaction.Tables[0].Rows.Count > 0 && dtransaction != null)
            {
                gridTransaction.DataSource = dtransaction.Tables[0];
                gridTransaction.DataBind();
                btnExportInvoice.Visible = true;
            }
            else
            {
                gridTransaction.DataSource = null;
                gridTransaction.DataBind();
                btnExportInvoice.Visible = false;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.ToString());
        }
    }
    public void gridTransaction_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {

        gridTransaction.PageIndex = e.NewPageIndex;
        BindTransactionGrid();
    }

    protected void btnExportInvoice_Click(object sender, EventArgs e)
    {
        if (TxtFrom.Text != "")
        {
            if (TxttoDate.Text == "")
            {
                TxttoDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            }
        }
        if (TxtFrom.Text == "")
        {
            DateTime dt2 = new DateTime(2020, 07, 20);
            TxtFrom.Text = dt2.ToString("dd-MM-yyyy");
        }

        string transactionStr = "";
        int count = 0;

        string script = "";
        string pageurl = "";
        foreach (GridViewRow gr in gridTransaction.Rows)
        {
            if (transactionStr == "")
            {
                transactionStr = "" + gridTransaction.DataKeys[gr.RowIndex]["TransactionID"].ToString() + "";
            }
            else
            {
                transactionStr = transactionStr + "," + gridTransaction.DataKeys[gr.RowIndex]["TransactionID"].ToString() ;
            }
            count = count + 1;
            if (count == 5)
            {
                pageurl = "BulkInvoice.aspx?Frm=" + TxtFrom.Text + "&TD=" + TxttoDate.Text + "&TransactionIDs=" + transactionStr;
                script = script + "window.open('" + pageurl + "','_blank');";
                count = 0;
                transactionStr = "";
            }

        }

        // pageurl = "BulkInvoice.aspx?Frm=" + TxtFrom.Text + "&TD=" + TxttoDate.Text + "&TransactionId=" + "2007241264595";
        //script = "window.open('" + pageurl + "','_blank');";
       // pageurl = "BulkInvoice.aspx?Frm=" + TxtFrom.Text + "&TD=" + TxttoDate.Text + "&TransactionId=" + "'2007241264595'";
        //script = script + "window.open('" + pageurl + "','_blank');";


            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", script, true);
        
    }
}