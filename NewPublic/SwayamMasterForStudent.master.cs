using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class NewPublic_SwayamMasterForStudent : System.Web.UI.MasterPage
{
  
    Student_DashBoard_BLogic obj_BAL_Student_Dashboard;
    StudentDash obj_Student_Dashboard;
    public string board, medium, standard, subject;
    protected void Page_Load(object sender, EventArgs e)
    {
        AppSessions.Board = "GSEB";
        AppSessions.Medium = "Gujarati";
        AppSessions.Standard = "Standard - 08 (Sem - 1)";
        AppSessions.RoleID = 4;

        if (AppSessions.RoleID != 0)
        {
            switch (AppSessions.RoleID)
            {
                case (int)EnumFile.Role.Student:
                    board = AppSessions.Board.ToString();
                    medium = AppSessions.Medium.ToString();
                    standard = AppSessions.Standard.ToString();
                    break;


                case (int)EnumFile.Role.Teacher:
                    break;

                default:
                    break;
            }
            // GetStudentDetailBMS();
        }

        else
        {
            if (AppSessions.RoleID == null && AppSessions.RoleID == 0)
            {
            }
        }
    }
    public static DataTable dtSubjects;
    public static DataTable dtChapters;


    protected void lbtnSignOut_Click(object sender, EventArgs e)
    {
        Session["StudentID"] = null;
        Response.Redirect("SwayamHomePage.aspx");
    }

    public void logout_click()
    {
        HttpContext.Current.Session.Clear();
        Response.Redirect("SwayamHomePage.aspx");
    }
}
