using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewPublic_StudentQuery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //txtUserName.Text = AppSessions.UserName.ToString();
        //TxtEmail.Text = AppSessions.LoginID.ToString();
        if (AppSessions.LoginID != "0" && AppSessions.LoginID.Trim() != string.Empty)
        {
            BindSubject();
        }
        else
        {
            Response.Redirect("SwayamHomePage.aspx");
        }
    }

    protected void BindSubject()
    {
        try
        {
            Student_DashBoard_BLogic obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            DataSet ds = new DataSet();
            ds = obj_BAL_Student_Dashboard.BAL_Student_Purchased_Package("", Convert.ToInt32(AppSessions.BMSID), Convert.ToInt32(AppSessions.StudentID));
            DataTable dt = new DataTable();
            dt.Columns.Add("SubjectID", typeof(Int32));
            dt.Columns.Add("Subject", typeof(string));

            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    if (ds.Tables[0].Rows[i]["PackageType"].ToString().ToLower() == "combo")
                    {
                        string[] subjects = ds.Tables[0].Rows[i]["subject"].ToString().Split(',');
                        string[] subjectsid = ds.Tables[0].Rows[i]["subjectid"].ToString().Split(',');
                        for (int subcnt = 0; subcnt < subjects.Length; subcnt++)
                        {
                            DataRow dr = dt.NewRow();
                            dr["SubjectID"] = subjectsid[subcnt].ToString().Trim();
                            dr["Subject"] = subjects[subcnt].ToString().Trim();

                            dt.Rows.Add(dr);
                        }
                    }

                    else
                    {

                        DataRow dr = dt.NewRow();
                        dr["SubjectID"] = ds.Tables[0].Rows[i]["Subjectid"].ToString().Trim();
                        dr["Subject"] = ds.Tables[0].Rows[i]["Subject"].ToString().Trim();
                        dt.Rows.Add(dr);
                    }
                }
                DataTable dt1 = dt.DefaultView.ToTable(true, "SubjectID", "Subject");
                DataView dv = dt1.DefaultView;
                dv.Sort = "Subject";
                dt = dv.ToTable();
                //ddlsubjectlist.DataSource = dt;
                //ddlsubjectlist.DataValueField = "SubjectID";
                //ddlsubjectlist.DataTextField = "Subject";
                //ddlsubjectlist.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }

    [WebMethod]
    public static IEnumerable<SYS_Subject> SelectSubject(string Operation)
    {
        List<SYS_Subject> MySubjects = new List<SYS_Subject>();
        try
        {
            Student_DashBoard_BLogic obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            DataSet ds = new DataSet();
            ds = obj_BAL_Student_Dashboard.BAL_Student_Purchased_Package("", Convert.ToInt32(AppSessions.BMSID), Convert.ToInt32(AppSessions.StudentID));
            DataTable dt = new DataTable();
            dt.Columns.Add("SubjectID", typeof(Int32));
            dt.Columns.Add("Subject", typeof(string));
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    if (ds.Tables[0].Rows[i]["PackageType"].ToString().ToLower() == "combo")
                    {

                        string[] subjects = ds.Tables[0].Rows[i]["subject"].ToString().Split(',');
                        string[] subjectsid = ds.Tables[0].Rows[i]["subjectid"].ToString().Split(',');
                        for (int subcnt = 0; subcnt < subjects.Length; subcnt++)
                        {
                            //DataRow dr = dt.NewRow();
                            //dr["SubjectID"] = subjectsid[subcnt].ToString().Trim();
                            //dr["Subject"] = subjects[subcnt].ToString().Trim();

                            //dt.Rows.Add(dr);

                            MySubjects.Add(new SYS_Subject
                            {
                                subjectid = Convert.ToInt32(subjectsid[subcnt].ToString().Trim()),
                                subject = subjects[subcnt].ToString().Trim(),
                            });
                        }
                    }

                    else
                    {

                        //DataRow dr = dt.NewRow();
                        //dr["SubjectID"] = ds.Tables[0].Rows[i]["Subjectid"].ToString().Trim();
                        //dr["Subject"] = ds.Tables[0].Rows[i]["Subject"].ToString().Trim();
                        //dt.Rows.Add(dr);


                        MySubjects.Add(new SYS_Subject
                        {
                            subjectid = Convert.ToInt32(ds.Tables[0].Rows[i]["Subjectid"].ToString().Trim()),
                            subject = ds.Tables[0].Rows[i]["Subject"].ToString().Trim(),
                        });
                    }
                    //DataTable dt1 = dt.DefaultView.ToTable(true, "SubjectID", "Subject");
                    //DataView dv = dt1.DefaultView;
                    //dv.Sort = "Subject";
                    //dt = dv.ToTable();




                    // using (SqlConnection con = new SqlConnection("Data Source=vp\\sql2012;Initial Catalog=epathshaladb;User ID=sa;Password=swayam@123"))
                    //{
                    //  SqlCommand objComm = new SqlCommand("SELECT *FROM dbo.Books ORDER BY BookID DESC", con);
                    // con.Open();

                    //SqlDataReader reader = objComm.ExecuteReader();

                    // POPULATE THE LIST WITH DATA.
                    //while (reader.Read())
                    //{
                    //    MyBooks.Add(new Books
                    //    {
                    //        BookID = Convert.ToInt32(reader["BookID"]),
                    //        BookName = reader["BookName"].ToString(),
                    //    });
                    //}

                    //con.Close();
                }

            }
        }
        catch (Exception)
        {

            throw;
        }

        return MySubjects;
    }

    [WebMethod]
    public static IEnumerable<SYS_Chapter> SelectChapter(string Operation)
    {
        List<SYS_Chapter> MyChapter = new List<SYS_Chapter>();
        try
        {
            Student_DashBoard_BLogic obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            StudentDash obj_Student_Dashboard = new StudentDash();
            obj_Student_Dashboard.SubjectID = Convert.ToInt16(Operation);
            obj_Student_Dashboard.BMSID = Convert.ToInt32(AppSessions.BMSID);
            obj_Student_Dashboard.StudentID = Convert.ToInt32(AppSessions.StudentID);

            DataSet ds = new DataSet();
            ds = obj_BAL_Student_Dashboard.BAL_Select_All_Chapters_Topics(obj_Student_Dashboard);
            DataTable dt = new DataTable();
            dt.Columns.Add("ChapterID", typeof(Int32));
            dt.Columns.Add("Chapter", typeof(string));
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    MyChapter.Add(new SYS_Chapter
                    {
                        chapterid = Convert.ToInt32(ds.Tables[0].Rows[i]["ChapterID"].ToString().Trim()),
                        chapter = ds.Tables[0].Rows[i]["Chapter"].ToString().Trim(),
                    });
                }

            }
        }
        catch (Exception)
        {

            throw;
        }

        return MyChapter;
    }

    [WebMethod]
    public static IEnumerable<SYS_Topic> SelectTopic(string Operation, string Operation1)
    {
        List<SYS_Topic> MyTopic = new List<SYS_Topic>();
        try
        {
           // DataSet ds = new DataSet();
            //SYS_Role obj_SYS_Role = new SYS_Role();
            //SYS_Role_BLogic obj_BAL_SYS_Role = new SYS_Role_BLogic();
            
            //DataSet dsSelect = new DataSet();
            //ds = obj_BAL_SYS_Role.BAL_Select_Chapters(Convert.ToInt64(AppSessions.BMSID), Convert.ToInt16(Operation));


            Student_DashBoard_BLogic obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            StudentDash obj_Student_Dashboard = new StudentDash();
            obj_Student_Dashboard.SubjectID = Convert.ToInt16(Operation);
            obj_Student_Dashboard.BMSID = Convert.ToInt32(AppSessions.BMSID);
            obj_Student_Dashboard.StudentID = Convert.ToInt32(AppSessions.StudentID);

            DataSet ds = new DataSet();
            ds = obj_BAL_Student_Dashboard.BAL_Select_All_Chapters_Topics(obj_Student_Dashboard);


            DataTable dt = ds.Tables[1];
            DataRow[] dr = dt.Select("ChapterID = "+ Convert.ToInt32(Operation1));

            //ds = obj_BAL_Student_Dashboard.BAL_Select_All_Chapters_Topics(obj_Student_Dashboard);
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("TopicID", typeof(Int32));
            dt1.Columns.Add("Topic", typeof(string));
            
            foreach (DataRow drLoop in dr)
            {
                MyTopic.Add(new SYS_Topic
                {
                    topicid = Convert.ToInt32(drLoop["TopicID"].ToString().Trim()),
                    topic = drLoop["Topic"].ToString().Trim(),
                });
                break;

            }


            //    if (ds.Tables[0].Rows.Count > 0 && ds != null)
            //{
            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        MyTopic.Add(new SYS_Topic
            //        {
            //            topicid = Convert.ToInt32(ds.Tables[0].Rows[i]["TopicID"].ToString().Trim()),
            //            topic = ds.Tables[0].Rows[i]["Topic"].ToString().Trim(),
            //        });
            //    }

            //}
        }
        catch (Exception)
        {

            throw;
        }

        return MyTopic;
    }
    public class Subjects
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        //public string Category { get; set; }
        //public decimal Price { get; set; }
        //public string Operation { get; set; }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //Forum_BAL frmbal = new Forum_BAL();
            //Forum forum = new Forum();
            //string post;
            //int postedby;
            //post = DDLsubject.SelectedItem.ToString() + txtDesc.Text;
            //postedby = AppSessions.StudentID;
            //forum.Post = post;
            //forum.PostedBy = postedby;
            //frmbal.Forum_Insert(forum);

            //Resetcontrols();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        finally
        {
            WebMsg.Show("Will getback shortly!!!");
        }

    }
    [WebMethod]
    public static string SaveDetails(string Question,int SubjectID,int chapterID,int TopicID)
    {
        Forum_BAL frmbal = new Forum_BAL();
        Forum forum = new Forum();
        forum.BMSID = AppSessions.BMSID;
        forum.SubjectID = Convert.ToInt32(SubjectID);
        forum.ChapterID = Convert.ToInt32(chapterID);
        forum.TopicID = Convert.ToInt32(TopicID);
        forum.UserName = AppSessions.UserName;
        DataSet ds = frmbal.Select_BMSSCTID(forum);
        forum.BMSSCTID = Convert.ToInt32(ds.Tables[0].Rows[0]["BMSSCTID"].ToString());
        forum.Post = Question;
        frmbal.Forum_InsertQuery(forum);
        
        return "Your query inserted successfully.....";

    }
    public void Resetcontrols()
    {
        //txtDesc.Text = "";
        //DDLsubject.SelectedIndex = 0;
    }
}