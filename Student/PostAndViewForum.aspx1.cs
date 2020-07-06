using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_PostAndViewForum : System.Web.UI.Page
{
    #region "Declaration"

    Forum_BAL oForum_BAL;
    Forum oForum;

    #endregion

    #region Properties

    string SortDirection
    {
        get
        {
            object o = this.ViewState["SortDirection"];
            if (o == null)
            {
                return string.Empty;
            }
            else
            {
                return (string)o;
            }
        }

        set
        {
            this.ViewState["SortDirection"] = value;
        }
    }
    string SortField
    {
        get
        {
            object o = this.ViewState["SortField"];
            if (o == null)
            {
                return string.Empty;
            }
            else
            {
                return (string)o;
            }
        }

        set
        {
            this.ViewState["SortField"] = value;
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GridView1.DataSource = ParentCommentIDAcess.GetAllReplyDetails();
            GridView1.DataBind();
            // BindPostGrid();
        }

    }

    //public System.Collections.Generic.List<DataAccess.Employees> Empl
    //{
    //    get
    //    {
    //        return DataAccess.GetAllemployees(this.ParentCommentID);
    //    }
    //}
    private void BindPostGrid()
    {
        oForum = new Forum();
        oForum_BAL = new Forum_BAL();
        oForum.BMSID = AppSessions.BMSID;
        oForum.UserID = AppSessions.StudentID;
        DataSet ods = oForum_BAL.Forum_Select_All_Userwise(oForum);

        GridViewOperations GrvOperation = new GridViewOperations();
        //GrvOperation.BindGridWithSorting(this.GvPost, ods, this.SortField, this.SortDirection);
        GrvOperation.BindGridWithSorting(this.GridView1, ods, this.SortField, this.SortDirection);
    }
    protected void btnpost_Click(object sender, EventArgs e)
    {
        oForum_BAL = new Forum_BAL();
        oForum = new Forum();

        //oForum.Post = TxtForum.Value;
        oForum.PostedBy = AppSessions.StudentID;

        bool IsInsert = oForum_BAL.Forum_Insert(oForum);

        if (IsInsert)
        {
            WebMsg.Show("Post has been created successfully.");
            ResetControl();
        }
        else
            WebMsg.Show("There is some problem to create post, please try again.");
    }
    private void ResetControl()
    {
        //TxtForum.Value = "";
    }
    
    protected void btnReplyParent_Click(object sender, EventArgs e)
    {
        GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
        Label lblchildCommentid = (Label)row.FindControl("lb1COmmenId");
        TextBox txtCommentParent = (TextBox)row.FindControl("textCommentReplyParent");

        DataAccess DAL_Teacher_Dashboard = new DataAccess();
        System.Collections.ArrayList arrParameter = new System.Collections.ArrayList();

        arrParameter.Add(new parameter("UserID", AppSessions.StudentID));
        arrParameter.Add(new parameter("QuestionAnswer", txtCommentParent.Text));
        arrParameter.Add(new parameter("ForumID", lblchildCommentid.Text));

        DAL_Teacher_Dashboard.DAL_InsertUpdate("StudentTeacherForumReply", arrParameter);

        //SqlCommand cmd = new SqlCommand("StudentTeacherForumReply", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@UserID", AppSessions.StudentID);
        //cmd.Parameters.AddWithValue("@QuestionAnswer", txtCommentParent.Text);
        //cmd.Parameters.AddWithValue("@ForumID", lblchildCommentid.Text);
        //con.Open();
        //cmd.ExecuteNonQuery();
        //con.Close();

        GridView1.DataSource = ParentCommentIDAcess.GetAllReplyDetails();
        GridView1.DataBind();
    }
}