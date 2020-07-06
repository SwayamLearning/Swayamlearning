using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ParentCommentIDAcess
/// </summary>
/// 
public class ParentComment
{
    public int ForumID { get; set; }
    public string CommentDate { get; set; }
    public string CommentMessage { get; set; }
    public string UserName { get; set; }
    public List<DataAccess.Employees> Empl
    {
        get
        {
            return DataAccess.GetAllForum(this.ForumID);
        }
    }


}
public class ParentCommentIDAcess
{

    public static List<ParentComment> GetAllReplyDetails()
    {
        List<ParentComment> listDepartments = new List<ParentComment>();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.AppSettings["EpathshalaCon"];

        using (SqlConnection con = new SqlConnection(conn.ConnectionString))
        {

            SqlCommand cmd = new SqlCommand("SelectStudentTeacherForumData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "SelectStudentTeacherForumData";
            cmd.Parameters.AddWithValue("@BMSID", AppSessions.BMSID);
            cmd.Parameters.AddWithValue("@RoleID", AppSessions.RoleID);

            //SqlCommand cmd = new SqlCommand("Select ForumID,Question as Forum, CONVERT(CHAR(15), CreatedDate, 106) PostedOn,	std.FirstName + ' ' + std.LastName PostedBy from StudentTeacherForum frm INNER JOIN Student std ON frm.UserID = std.StudentID Where frm.UserID = "+ AppSessions.StudentID +" and frm.BMSID = "+ AppSessions.BMSID +" order by frm.CreatedDate desc;", con);
            //SqlCommand cmd = new SqlCommand("Select ForumID,Question as Forum, CONVERT(CHAR(15), CreatedDate, 106) PostedOn,	std.FirstName + ' ' + std.LastName PostedBy from StudentTeacherForum frm INNER JOIN Student std ON frm.UserID = std.StudentID Where frm.BMSID = " + AppSessions.BMSID + " order by frm.CreatedDate desc;", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())

            {
                ParentComment parent = new ParentComment();
                parent.ForumID = Convert.ToInt32(rdr["ForumID"]);
                parent.UserName = rdr["PostedBy"].ToString();
                string date = rdr["PostedOn"].ToString();
                date = date.Substring(0, date.LastIndexOf("/") + 5);
                parent.CommentDate = date;
                parent.CommentMessage = rdr["Forum"].ToString();
                listDepartments.Add(parent);
            }
        }
        return listDepartments;
    }

}
