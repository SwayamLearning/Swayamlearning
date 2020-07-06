using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Dashboard_StudentDashboardSwaAcademy : System.Web.UI.Page
{
    public string username, loginid, subjectclicked;
    Student_DashBoard_BLogic obj_BAL_Student_Dashboard;
    StudentDash obj_Student_Dashboard;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //for chat session

                username = AppSessions.UserName.ToString();
                loginid = AppSessions.LoginID.ToString();

                BindSubjectList();
                GetExpiryNotification();
                if (rbSubjectList.Items.Count > 0)
                    rbSubjectList.SelectedIndex = 0;
                GetProfileComplateCount();
                //  GetPerformanceChartdata();
            }
        }
        catch (Exception ex)
        {


        }

    }
    protected void lnkviewmore_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Report/StudentPackageReport.aspx");
    }
    protected void lnkviewmore1_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Report/StudentPackageReport.aspx");

    }
    private DataTable _dtSubjects;

    public DataTable dtSubjects
    {
        get
        {
            return _dtSubjects;
        }
        set
        {
            _dtSubjects = value;
            NewPublic_materialMaster.dtSubjects = value;
        }
    }
    protected void BindSubjectList()
    {
        try
        {
            if (Session["ShowPaymentPages"] != null)
            {
                ViewState["StudentBMS"] = AppSessions.BMSID;
            }
            else
            {
                GetStudentDetailBMS();
            }
            obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
            obj_Student_Dashboard = new StudentDash();
            ArrayList Alist = new ArrayList();

            if (ViewState["ArrayList"] != null)
            {
                Alist = (ArrayList)ViewState["ArrayList"];
                string PackageFDID = string.Empty;
                for (int i = 0; i < Alist.Count; i++)
                {
                    if (PackageFDID != string.Empty)
                    {
                        PackageFDID = PackageFDID + "," + Alist[i].ToString();
                    }
                    else
                    {
                        PackageFDID = PackageFDID + Alist[i].ToString();
                    }
                }

                obj_Student_Dashboard.BMSID = AppSessions.BMSID;
                obj_Student_Dashboard.PackageFDID = PackageFDID;
                obj_Student_Dashboard.Mode = "Selected";
                DataSet ds = new DataSet();
                //ds = obj_BAL_Student_Dashboard.BAL_Student_Subject_Select(obj_Student_Dashboard);
                ds = obj_BAL_Student_Dashboard.BAL_Student_Purchased_Package("", Convert.ToInt32(AppSessions.BMSID), Convert.ToInt32(AppSessions.StudentID));

                DataTable dt = new DataTable();
                dt.Columns.Add("SubjectID", typeof(Int32));
                dt.Columns.Add("Subject", typeof(string));
                dt.Columns.Add("Covered", typeof(int));
                dt.Columns.Add("NotCovered", typeof(int));
                dt.Columns.Add("Colour", typeof(string));


                int studentID = Convert.ToInt16(Session["StudentID"]);
                int bmsID = Convert.ToInt16(Session["BMSID"]);
                StudentWiseCoveredSyllabus swcs = new StudentWiseCoveredSyllabus();
                int subjectID;
                DataSet coveredSubjectInfo = null;
                int covered = 0;
                string colour = string.Empty;
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
                                //BAL_GET_SubjectWiseCoveredPercentage(int studentID, int bmsID, int subjectID)
                                //StudentWiseCoveredSyllabus sc = new StudentWiseCoveredSyllabus();
                                subjectID = Convert.ToInt16(subjectsid[subcnt].ToString().Trim());
                                coveredSubjectInfo = swcs.BAL_GET_SubjectWiseCoveredPercentage(studentID, bmsID, subjectID);
                                covered = Convert.ToInt16(coveredSubjectInfo.Tables[0].Rows[0]["coveredPercentage"].ToString());
                                colour = coveredSubjectInfo.Tables[0].Rows[0]["colour"].ToString();
                                DataRow dr = dt.NewRow();
                                dr["SubjectID"] = subjectsid[subcnt].ToString().Trim();
                                dr["Subject"] = subjects[subcnt].ToString().Trim();
                                dr["Covered"] = covered;
                                dr["NotCovered"] = (100 - covered);
                                dr["Colour"] = colour;
                                dt.Rows.Add(dr);
                            }
                        }
                        else
                        {

                            //StudentWiseCoveredSyllabus sc = new StudentWiseCoveredSyllabus();
                            subjectID = Convert.ToInt16(ds.Tables[0].Rows[i]["Subjectid"].ToString().Trim());
                            coveredSubjectInfo = swcs.BAL_GET_SubjectWiseCoveredPercentage(studentID, bmsID, subjectID);
                            covered = Convert.ToInt16(coveredSubjectInfo.Tables[0].Rows[0]["coveredPercentage"].ToString());
                            colour = coveredSubjectInfo.Tables[0].Rows[0]["colour"].ToString();

                            DataRow dr = dt.NewRow();
                            dr["SubjectID"] = ds.Tables[0].Rows[i]["Subjectid"].ToString().Trim();
                            dr["Subject"] = ds.Tables[0].Rows[i]["Subject"].ToString().Trim();
                            dr["Covered"] = covered;
                            dr["NotCovered"] = (100 - covered);
                            dr["Colour"] = colour;
                            dt.Rows.Add(dr);
                        }

                    }
                    DataTable dt1 = dt.DefaultView.ToTable(true, "SubjectID", "Subject", "Covered", "NotCovered", "Colour");
                    DataView dv = dt1.DefaultView;
                    dv.Sort = "Subject";
                    dt = dv.ToTable();
                    dtSubjects = dt;
                    // dt = dt.DefaultView.ToTable(true);
                    rbSubjectList.DataSource = dt;
                    rbSubjectList.DataValueField = "SubjectID";
                    rbSubjectList.DataTextField = "Subject";
                    rbSubjectList.DataBind();
                    //TO DO SELECT FIRST


                }
            }

            if (ViewState["StudentBMS"] != null)
            {
                obj_Student_Dashboard.BMSID = Convert.ToInt64(ViewState["StudentBMS"]);
                obj_Student_Dashboard.Mode = "All";
                DataSet ds = new DataSet();
                ds = obj_BAL_Student_Dashboard.BAL_Student_Subject_Select(obj_Student_Dashboard);
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    rbSubjectList.DataSource = ds.Tables[0];
                    rbSubjectList.DataValueField = "SubjectID";
                    rbSubjectList.DataTextField = "Subject";
                    rbSubjectList.DataBind();
                    rbSubjectList.SelectedIndex = 0;
                }
            }

            if (rbSubjectList.DataSource != null)
            {

            }
            else
            {
                Response.Redirect("SelectPackage.aspx", false);
            }


        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected void GetExpiryNotification()
    {
        try
        {

            if (ViewState["StudentBMS"] == null)
            {


                obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
                obj_Student_Dashboard = new StudentDash();

                //if (Session["UserPackage"] == "Single")
                //{
                obj_Student_Dashboard.StudentID = AppSessions.StudentID;
                // obj_Student_Dashboard.Mode = "Single";
                DataSet ds = new DataSet();
                ds = obj_BAL_Student_Dashboard.BAL_Student_ExpiryNotification1(obj_Student_Dashboard);
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    fsExpiryNotification.Visible = true;
                    gvSubjectExpiryNotification.Visible = true;
                    if (ds.Tables[0].Rows.Count > 2)
                    {
                        gvSubjectExpiryNotification.DataSource = SelectTopDataRow(ds.Tables[0], 2);
                        lnkviewmore.Visible = true;
                    }
                    else
                    {
                        gvSubjectExpiryNotification.DataSource = ds.Tables[0];
                        lnkviewmore.Visible = false;
                    }

                    gvSubjectExpiryNotification.DataBind();
                }
                else
                {
                    Response.Redirect("~/DashBoard/SelectPackage.aspx");

                }
                if (ds.Tables[1].Rows.Count > 0 && ds != null)
                {
                    gvExpiredPackageList.Visible = true;

                    if (ds.Tables[1].Rows.Count > 2)
                    {
                        gvExpiredPackageList.DataSource = SelectTopDataRow(ds.Tables[1], 2);
                        lnkviewmore1.Visible = true;
                    }
                    else
                    {
                        gvExpiredPackageList.DataSource = ds.Tables[1];
                        lnkviewmore1.Visible = false;
                    }
                    gvExpiredPackageList.DataBind();
                }

            }
          
           

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    public DataTable SelectTopDataRow(DataTable dt, int count)
    {
        DataTable dtn = dt.Clone();
        for (int i = 0; i < count; i++)
        {
            dtn.ImportRow(dt.Rows[i]);
        }

        return dtn;
    }
    public void GetProfileComplateCount()
    {
        Student_DashBoard_BLogic obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        StudentDash obj_Student_Dashboard = new StudentDash();

        obj_Student_Dashboard.BMSID = Convert.ToInt64(AppSessions.BMSID);
        obj_Student_Dashboard.SubjectID = Convert.ToInt16(AppSessions.SubjectID);
        obj_Student_Dashboard.StudentID = Convert.ToInt64(AppSessions.StudentID);

        DataSet dsSelect = new DataSet();
        dsSelect = obj_BAL_Student_Dashboard.BAL_Student_GetComplateProfile(obj_Student_Dashboard);

        int totalfield = dsSelect.Tables[0].Columns.Count;
        int filledbyuser = 0;

        if (dsSelect.Tables[0].Rows.Count == 1)
        {
            foreach (DataColumn col in dsSelect.Tables[0].Columns)
            {
                string val = string.Empty;
                val = Convert.ToString(dsSelect.Tables[0].Rows[0][col.ColumnName]);
                if (!string.IsNullOrEmpty(val))
                    filledbyuser++;
            }
        }

        int per = (filledbyuser * 100) / totalfield;
        if (per >= 100)
            dvprofilepercentage.Style["display"] = "none";
        else
            profilepercentage.Attributes.Add("data-percentage", Convert.ToString(per));
    }
    protected void GetStudentDetailBMS()
    {
        DataSet dsData = new DataSet();
        DataSet dsLogin = new DataSet();
        obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        obj_Student_Dashboard = new StudentDash();
        ArrayList Alist = new ArrayList();
        //int BMSID = 0;
        try
        {
            obj_Student_Dashboard.StudentID = AppSessions.StudentID;
            //dsData = obj_BAL_Student_Dashboard.BAL_Validate_Student(obj_Student_Dashboard);
            dsData = obj_BAL_Student_Dashboard.BAL_Student_PackageDetails(AppSessions.StudentID, AppSessions.BMSID);

            //dsData = obj_BAL_Student_Dashboard.BAL_Student_ExpiryNotification1(obj_Student_Dashboard);
            if (dsData != null && dsData.Tables.Count > 0)
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    string SubjectID = dsData.Tables[0].Rows[0]["SubjectID"].ToString();
                    if (SubjectID != string.Empty)
                    {


                        for (int i = 0; i < dsData.Tables[0].Rows.Count; i++)
                        {
                            Alist.Add(dsData.Tables[0].Rows[i]["PackageFD_ID"].ToString());
                        }
                        ViewState["ArrayList"] = Alist;
                        //Session["UserPackage"] = "Single";
                    }
                    
                }
                else if (dsData.Tables[0].Rows.Count > 1)
                {
                    Response.Redirect("~/DashBoard/SelectPackage.aspx");
                }
            }
            else
            {
                Response.Redirect("~/DashBoard/SelectPackage.aspx");
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
}