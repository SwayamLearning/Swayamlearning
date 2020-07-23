using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using Udev.UserMasterPage.Classes;
using System.Web.UI;
using System.Web;
using System.Web.Services;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Diagnostics;

public partial class Student_StudentDashboard : System.Web.UI.Page
    {
    #region Variables
    Student_DashBoard_BLogic obj_BAL_Student_Dashboard;
    StudentDash obj_Student_Dashboard;
    public string path = string.Empty;
    public string username, loginid, subjectclicked;
    string clientsecret = "BVcWcJOswitfQmiiJ3fncivI";
    string clientid = "809888022564-utvifb60a3cphn9e05j6ui0s5a02kp2c.apps.googleusercontent.com";

    #endregion

    #region Culture

    //protected override void InitializeCulture()
    //{
    //    string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
    //    // 'set culture to current thread
    //    System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
    //    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
    //    //call base class
    //    base.InitializeCulture();
    //}
    protected override void InitializeCulture()
        {
        HttpCookie cookie = Request.Cookies["CultureInfo"];

        if (cookie != null && cookie.Value != null)
            {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie.Value);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie.Value);
            }
        else
            {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }
        }

    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
        {
        //Session.Timeout = 1;
        //Changed date:07-06-2020 Reason:prevent direct access to page without login

        if ((AppSessions.StudentID.ToString() == "0") || (AppSessions.StudentID.ToString() == null))
            Response.Redirect("../SwayamDemoHomepage.aspx");



        if (!IsPostBack)
            {
            //for chat session
            if (Request.QueryString["Class"] != null)

                {
                Response.Redirect("../SwayamDemoHomepage.aspx");
                //AppSessions.IsFreePackage = "demo";
                //AppSessions.Board = "GSEB";
                //AppSessions.Medium = "Gujarati";
                //string strclass = Request.QueryString["Class"];
                //if (strclass == "1")
                //    {
                //    username = "std1Demo";
                //    loginid = "std1Demo";
                //    AppSessions.LoginID = loginid;
                //    AppSessions.UserName = "std1 Demo";
                //    AppSessions.UserID = 249;
                //    AppSessions.StudentID = 249;
                //    AppSessions.BMSID = 1;
                //    AppSessions.RoleID = 4;
                //    AppSessions.Standard = "Standard - 01 (Sem - 1)";
                //    Session["StudentID"] = 249;
                //    Session["BMSID"] = 1;

                //    }
                //else if (strclass == "2")
                //    {
                //    username = "std2Demo";
                //    loginid = "std2Demo";
                //    AppSessions.LoginID = loginid;
                //    AppSessions.UserName = "std2 Demo";
                //    AppSessions.UserID = 250;
                //    AppSessions.StudentID = 250;
                //    AppSessions.BMSID = 2;
                //    AppSessions.RoleID = 4;
                //    AppSessions.Standard = "Standard - 02 (Sem - 1)";
                //    Session["StudentID"] = 250;
                //    Session["BMSID"] = 2;
                //    }
                //else if (strclass == "3")
                //    {
                //    username = "std3Demo";
                //    loginid = "std3Demo";
                //    AppSessions.LoginID = loginid;
                //    AppSessions.UserName = "std3 Demo";
                //    AppSessions.UserID = 251;
                //    AppSessions.StudentID = 251;
                //    AppSessions.BMSID = 3;
                //    AppSessions.RoleID = 4;
                //    AppSessions.Standard = "Standard - 03 (Sem - 1)";
                //    Session["StudentID"] = 251;
                //    Session["BMSID"] = 3;
                //    }
                //else if (strclass == "4")
                //    {
                //    username = "std4Demo";
                //    loginid = "std4Demo";
                //    AppSessions.LoginID = loginid;
                //    AppSessions.UserName = "std4 Demo";
                //    AppSessions.UserID = 252;
                //    AppSessions.StudentID = 252;
                //    AppSessions.BMSID = 4;
                //    AppSessions.RoleID = 4;
                //    AppSessions.Standard = "Standard - 04 (Sem - 1)";
                //    Session["StudentID"] = 252;
                //    Session["BMSID"] = 4;
                //    }
                //else if (strclass == "5")
                //    {
                //    username = "std5Demo";
                //    loginid = "std5Demo";
                //    AppSessions.LoginID = loginid;
                //    AppSessions.UserName = "std5 Demo";
                //    AppSessions.UserID = 253;
                //    AppSessions.StudentID = 253;
                //    AppSessions.BMSID = 5;
                //    AppSessions.RoleID = 4;
                //    AppSessions.Standard = "Standard - 05 (Sem - 1)";
                //    Session["StudentID"] = 253;
                //    Session["BMSID"] = 5;
                //    }
                //else if (strclass == "6")
                //    {
                //    username = "std6Demo";
                //    loginid = "std6Demo";
                //    AppSessions.LoginID = loginid;
                //    AppSessions.UserName = "std6 Demo";
                //    AppSessions.UserID = 254;
                //    AppSessions.StudentID = 254;
                //    AppSessions.BMSID = 6;
                //    AppSessions.RoleID = 4;
                //    AppSessions.Standard = "Standard - 06 (Sem - 1)";
                //    Session["StudentID"] = 254;
                //    Session["BMSID"] = 6;
                //    }
                //else if (strclass == "7")
                //    {
                //    username = "std7Demo";
                //    loginid = "std7Demo";
                //    AppSessions.LoginID = loginid;
                //    AppSessions.UserName = "std7 Demo";
                //    AppSessions.UserID = 255;
                //    AppSessions.StudentID = 255;
                //    AppSessions.BMSID = 7;
                //    AppSessions.RoleID = 4;
                //    AppSessions.Standard = "Standard - 07 (Sem - 1)";
                //    Session["StudentID"] = 255;
                //    Session["BMSID"] = 7;

                //    }
                //else if (strclass == "8")
                //    {
                //    username = "std8Demo";
                //    loginid = "std8Demo";
                //    AppSessions.LoginID = loginid;
                //    AppSessions.UserName = "std8 Demo";
                //    AppSessions.UserID = 256;
                //    AppSessions.StudentID = 256;
                //    AppSessions.BMSID = 8;
                //    AppSessions.RoleID = 4;
                //    AppSessions.Standard = "Standard - 08 (Sem - 1)";
                //    Session["StudentID"] = 256;
                //    Session["BMSID"] = 8;
                //    }

                //else if (strclass == "6UP")
                //    {
                //    AppSessions.IsFreePackage = "demo";
                //    AppSessions.Board = "UP";
                //    AppSessions.Medium = "Hindi";
                //    username = "std6UPDemo";
                //    loginid = "std6UPDemo";
                //    AppSessions.LoginID = loginid;
                //    AppSessions.UserName = "std6 Demo";
                //    AppSessions.UserID = 260;
                //    AppSessions.StudentID = 260;
                //    AppSessions.BMSID = 40;
                //    AppSessions.RoleID = 4;
                //    AppSessions.Standard = "Standard - 06";
                //    Session["StudentID"] = 260;
                //    Session["BMSID"] = 40;
                //    }
                //else if (strclass == "7UP")
                //    {
                //    AppSessions.IsFreePackage = "demo";
                //    AppSessions.Board = "UP";
                //    AppSessions.Medium = "Hindi";
                //    username = "std7UPDemo";
                //    loginid = "std7UPDemo";
                //    AppSessions.LoginID = loginid;
                //    AppSessions.UserName = "std7 Demo";
                //    AppSessions.UserID = 261;
                //    AppSessions.StudentID = 261;
                //    AppSessions.BMSID = 41;
                //    AppSessions.RoleID = 4;
                //    AppSessions.Standard = "Standard - 07";
                //    Session["StudentID"] = 261;
                //    Session["BMSID"] = 41;
                //    }
                //else if (strclass == "8UP")
                //    {
                //    AppSessions.IsFreePackage = "demo";
                //    AppSessions.Board = "UP";
                //    AppSessions.Medium = "Hindi";
                //    username = "std8UPDemo";
                //    loginid = "std8UPDemo";
                //    AppSessions.LoginID = loginid;
                //    AppSessions.UserName = "std8 Demo";
                //    AppSessions.UserID = 262;
                //    AppSessions.StudentID = 262;
                //    AppSessions.BMSID = 42;
                //    AppSessions.RoleID = 4;
                //    AppSessions.Standard = "Standard - 08";
                //    Session["StudentID"] = 262;
                //    Session["BMSID"] = 42;
                //    }
                //else if (strclass == "9UP")
                //    {
                //    AppSessions.IsFreePackage = "demo";
                //    AppSessions.Board = "UP";
                //    AppSessions.Medium = "Hindi";
                //    username = "std9UPDemo";
                //    loginid = "std9UPDemo";
                //    AppSessions.LoginID = loginid;
                //    AppSessions.UserName = "std9 Demo";
                //    AppSessions.UserID = 263;
                //    AppSessions.StudentID = 263;
                //    AppSessions.BMSID = 43;
                //    AppSessions.RoleID = 4;
                //    AppSessions.Standard = "Standard - 09";
                //    Session["StudentID"] = 263;
                //    Session["BMSID"] = 43;
                //    }
                //else if (strclass == "10UP")
                //    {
                //    AppSessions.IsFreePackage = "demo";
                //    AppSessions.Board = "UP";
                //    AppSessions.Medium = "Hindi";
                //    username = "std10UPDemo";
                //    loginid = "std10UPDemo";
                //    AppSessions.LoginID = loginid;
                //    AppSessions.UserName = "std10 Demo";
                //    AppSessions.UserID = 264;
                //    AppSessions.StudentID = 264;
                //    AppSessions.BMSID = 39;
                //    AppSessions.RoleID = 4;
                //    AppSessions.Standard = "Standard - 10";
                //    Session["StudentID"] = 264;
                //    Session["BMSID"] = 39;
                //    }
                //else if (strclass == "11UP")
                //    {
                //    AppSessions.IsFreePackage = "demo";
                //    AppSessions.Board = "UP";
                //    AppSessions.Medium = "Hindi";
                //    username = "std11UPDemo";
                //    loginid = "std11UPDemo";
                //    AppSessions.LoginID = loginid;
                //    AppSessions.UserName = "std11 Demo";
                //    AppSessions.UserID = 265;
                //    AppSessions.StudentID = 265;
                //    AppSessions.BMSID = 44;
                //    AppSessions.RoleID = 4;
                //    AppSessions.Standard = "Standard - 11";
                //    Session["StudentID"] = 265;
                //    Session["BMSID"] = 44;
                //    }
                //else if (strclass == "12UP")
                //    {
                //    AppSessions.IsFreePackage = "demo";
                //    AppSessions.Board = "UP";
                //    AppSessions.Medium = "Hindi";
                //    username = "std12UPDemo";
                //    loginid = "std12UPDemo";
                //    AppSessions.LoginID = loginid;
                //    AppSessions.UserName = "std12 Demo";
                //    AppSessions.UserID = 266;
                //    AppSessions.StudentID = 266;
                //    AppSessions.BMSID = 45;
                //    AppSessions.RoleID = 4;
                //    AppSessions.Standard = "Standard - 12";
                //    Session["StudentID"] = 266;
                //    Session["BMSID"] = 45;
         //   }


                }
            else
                {
                username = AppSessions.UserName.ToString();
                loginid = AppSessions.LoginID.ToString();
                }
            BindSubjectList();
            int bmsid = AppSessions.BMSID;
            //if((bmsid==1)||(bmsid==13))
            //    {
            //    btnactivity.Visible = true;
            //    }
            //else
            //    {
            //    btnactivity.Visible=false;
            //    }
            GetExpiryNotification();
            if (rbSubjectList.Items.Count > 0)
                rbSubjectList.SelectedIndex = 0;
            GetProfileComplateCount();
            //  GetPerformanceChartdata();
            }
         
        }
    #endregion

    #region User Define Function

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
            //}

            //if (Session["UserPackage"] == "Combo")
            //{
            //    obj_Student_Dashboard.StudentID = AppSessions.StudentID;
            //    obj_Student_Dashboard.Mode = "Combo";
            //    DataSet ds = new DataSet();
            //    ds = obj_BAL_Student_Dashboard.BAL_Student_ExpiryNotification1(obj_Student_Dashboard);
            //    if (ds.Tables[0].Rows.Count > 0 && ds != null)
            //    {
            //        fsExpiryNotification.Visible = true;
            //        gvComboExpiryNotification.Visible = true;
            //        gvComboExpiryNotification.DataSource = ds.Tables[0];
            //        gvComboExpiryNotification.DataBind();
            //    }
            //}

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
    protected string Limit(object Desc, int length)
        {
        StringBuilder strDesc = new StringBuilder();
        strDesc.Insert(0, Desc.ToString());

        if (strDesc.Length > length)
            {
            return strDesc.ToString().Substring(0, length) + "...";
            }
        else
            {
            return strDesc.ToString();
            }
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
                    //else
                    //{
                    //    BMSID = Convert.ToInt32(dsData.Tables[0].Rows[0]["BMSID"].ToString());
                    //    ViewState["StudentBMS"] = BMSID;
                    //    Session["UserPackage"] = "Combo";
                    //}
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

    private DataTable _dtChapters;

    public DataTable dtChapters
        {
        get
            {
            return _dtChapters;
            }
        set
            {
            _dtChapters = value;
            // NewPublic_materialMaster.dtChapters = value;
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
                //changed 2805
                string board = AppSessions.Board.ToString();
                string medium = AppSessions.Medium.ToString();
                string standard = AppSessions.Standard.ToString();
                lblbmsdet.Text = board + ">>" + medium + ">>" + standard;
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


                int studentID = Convert.ToInt32(Session["StudentID"]);
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
                    //changed 2805
                    dv.Sort = "SubjectID";
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


    public string GetNodeText(string nodetext)
        {
        string finaleString = string.Empty;

        try
            {

            if (nodetext.Length > 24)
                {
                while (nodetext.Length > 24)
                    {
                    if (nodetext.Substring(24, 1) == " ")
                        {


                        finaleString += nodetext.Substring(0, 24) + "<br />";
                        nodetext = nodetext.Substring(25);

                        if (nodetext.Length <= 24)
                            {
                            finaleString += nodetext;
                            break;
                            }

                        }
                    else
                        {

                        string tempstring = nodetext.Substring(0, 24);
                        if (tempstring.Contains(" "))
                            {
                            finaleString += tempstring.Substring(0, tempstring.LastIndexOf(' ')) + "<br />";
                            nodetext = nodetext.Substring(Convert.ToInt32(tempstring.LastIndexOf(' ')) + 1);
                            }
                        else
                            {
                            finaleString += tempstring + "<br />";
                            if (nodetext.Substring(24).Length <= 24)
                                {
                                finaleString += nodetext.Substring(24);
                                break;
                                }
                            }

                        }

                    if (nodetext.Substring(0).Length <= 24)
                        {
                        finaleString += nodetext.Substring(0);
                        break;
                        }

                    }
                }
            else
                {
                finaleString = nodetext;
                }

            return finaleString;
            }
        catch (Exception ex)
            {
            return finaleString;
            }
        }


    public void DisableDropDwon(DropDownList[] disddl)
        {
        foreach (DropDownList dl in disddl)
            {
            dl.Enabled = false;
            dl.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
            }
        }

    public void EnableDropDwon(DropDownList[] disddl)
        {
        foreach (DropDownList dl in disddl)
            {
            dl.Enabled = true;
            dl.SelectedIndex = ((int)EnumFile.AssignValue.Zero);
            }
        }



    //public void IsAllow_Enable_Settings(DataSet dsSettings)
    //{

    //    if (dsSettings != null)
    //    {
    //        if (dsSettings.Tables.Count > 0)
    //        {

    //            if (dsSettings.Tables[0].Rows.Count > 0)
    //            {

    //                object datatype = dsSettings.Tables[0].Rows[0]["Type"].ToString();
    //                object val = dsSettings.Tables[0].Rows[0]["value"].ToString();

    //                if (Convert.ToBoolean(Convert.ToInt16(val)))
    //                {
    //                    rblChapters.Visible = true;
    //                    ddlChapter.Enabled = true;
    //                    ddlTopic.Enabled = true;
    //                }
    //                else
    //                {
    //                    rblChapters.Visible = false;
    //                    ddlChapter.Enabled = false;
    //                    ddlTopic.Enabled = false;
    //                }
    //            }
    //        }
    //    }


    //}
    #endregion

    protected void lnkviewmore_Click(object sender, EventArgs e)
        {
        Response.Redirect("../Report/StudentPackageReport.aspx");
        }
    protected void lnkviewmore1_Click(object sender, EventArgs e)
        {
        Response.Redirect("../Report/StudentPackageReport.aspx");

        }

    #region StudentDashboard Related New

    #region WebMethod

    [WebMethod]
    public static string SubjectSelection(string SubjectID, string SubjectName)
        {
        if(SubjectID=="173")
            {
            try
                {
                Process p = new Process();
                string filename = System.Web.HttpContext.Current.Server.MapPath("../Barakhdi - App/Barakhdi - App.exe");
                p.StartInfo.FileName = filename;
                p.Start();
                return "";
                }
            catch (Exception ex)
                {
                WebMsg.Show(ex.ToString());
                }
           
            }
        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), StringEnum.stringValueOf(EnumFile.AccessedPages.StudentDashboard), "Subject List", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.SubjectExplored), "Subject Name: " + SubjectName, 0);

        AppSessions.SubjectID = Convert.ToInt16(SubjectID);
        Student_DashBoard_BLogic obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        StudentDash obj_Student_Dashboard = new StudentDash();

        obj_Student_Dashboard.BMSID = Convert.ToInt64(AppSessions.BMSID);
        obj_Student_Dashboard.SubjectID = Convert.ToInt16(AppSessions.SubjectID);
        obj_Student_Dashboard.StudentID = Convert.ToInt64(AppSessions.StudentID);

        DataSet dsSelect = new DataSet();
        dsSelect = obj_BAL_Student_Dashboard.BAL_Select_All_Chapters_Topics(obj_Student_Dashboard);

        if (dsSelect.Tables[0].Rows.Count < 1)
            return "";

        return BuildTopicChapterHTML(dsSelect);
        }
    [WebMethod]
    public static string SubjectSelectionSearch(string SearchKeyword)
        {
        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), StringEnum.stringValueOf(EnumFile.AccessedPages.StudentDashboard), "Search Panel", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.SearchExecute), "Search Keyword: " + SearchKeyword, 0);

        Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        DataSet oResult = new DataSet();
        oResult = obj_BAL_Teacher_Dashboard.BAL_BSMSearchResult(SearchKeyword);

        if (oResult.Tables[0].Rows.Count < 1)
            {
            return "<div style=\"text-align:center;\">No search result found for \"<span style=\"color: #71af32;font-weight: bold;\">" + SearchKeyword + "</span>\"<div>";
            }
        return BuildTopicChapterHTMLWithSubject(oResult);
        }
    [WebMethod]
    public static string TopicSelection(string SubjectID, string ChapterID, string TopicID, string TopicName, bool iscover)
        {
        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), StringEnum.stringValueOf(EnumFile.AccessedPages.StudentDashboard), "Chapter Topic List", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ChapterExplored), "Topic Name: " + TopicName, 0);

        Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        Teacher_Dashboard obj_Teacher_Dashboard = new Teacher_Dashboard();

        obj_Teacher_Dashboard.BMSID = Convert.ToInt64(AppSessions.BMSID);
        obj_Teacher_Dashboard.SubjectID = Convert.ToInt16(AppSessions.SubjectID);

        obj_Teacher_Dashboard.ChapterID = Convert.ToInt64(ChapterID);
        obj_Teacher_Dashboard.TopicID = Convert.ToInt64(TopicID);

        string ContentFolderPath = string.Empty;
        int bmssctid = obj_BAL_Teacher_Dashboard.BAL_Select_BMS_SCTID(obj_Teacher_Dashboard);

        if (bmssctid > (int)EnumFile.AssignValue.Zero)
            {
            //Session["ChapterTopic"] = ddlChapter.SelectedItem.ToString() + " >> " + ddlTopic.SelectedItem.ToString();
            AppSessions.BMSSCTID = bmssctid;
            if ((AppSessions.IsFreePackage == "free") || (AppSessions.IsFreePackage == "demo"))//free
                {
                if (AppSessions.IsFreePackage == "free")
                    {
                    ContentFolderPath = System.Web.HttpContext.Current.Server.MapPath("../EduResource/Free/" + bmssctid);
                    }
                else
                    ContentFolderPath = System.Web.HttpContext.Current.Server.MapPath("../EduResource/Demo/" + bmssctid + "_Demo");
                //ContentFolderPath = AppDomain.CurrentDomain.BaseDirectory + "EduResource\\" + bmssctid + "_Demo";
                if (Directory.Exists(ContentFolderPath))
                    {
                    DataTable dt = FillResourceDemo(bmssctid, ContentFolderPath);
                    if (dt.Rows.Count > 0)
                        return BuildContentHTML(iscover, bmssctid, dt);
                    else
                        return GetAvailableTopicHTML();
                    }
                else
                    {
                    return GetAvailableTopicHTML();
                    }
                }
            else if (AppSessions.IsFreePackage == "paid")//paid
                {
                ContentFolderPath = System.Web.HttpContext.Current.Server.MapPath("../EduResource/" + bmssctid);
                if (Directory.Exists(ContentFolderPath))
                    {
                    DataTable dt = FillResource(bmssctid, ContentFolderPath);
                    if (dt.Rows.Count > 0)
                        return BuildContentHTML(iscover, bmssctid, dt);
                    else
                        return "<div title='" + bmssctid + "'>No Resource Available</div>";
                    }
                else
                    return "<div title='" + bmssctid + "'>No Resource Available</div>";
                }
            else
                {
                //HttpContext.Current.Response.Redirect("../OtherPages/Landing.aspx", false);
                return "";
                }
            }
        else
            {
            return "<div title='" + bmssctid + "'>OOPS! There is some problem, please <span style=\"color: #71af32;font-weight: bold;cursor:pointer;\" onclick=\"javascript:return RefreshPage();\">refresh</span> page and try again.<div>";
            }
        }
    [WebMethod]
    public static KeyValueData[] UpdateCoveredSyllabus(string subjectid)
        {
        AppSessions.SubjectID = Convert.ToInt32(subjectid);
        List<KeyValueData> olst = new List<KeyValueData>();
        int CoveredChapters = 0;
        int UncoveredChapters = 0;
        Student_DashBoard_BLogic obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        StudentDash obj_Student_Dashboard = new StudentDash();

        obj_Student_Dashboard.BMSID = Convert.ToInt64(AppSessions.BMSID);
        obj_Student_Dashboard.SubjectID = Convert.ToInt16(AppSessions.SubjectID);
        obj_Student_Dashboard.StudentID = Convert.ToInt64(AppSessions.StudentID);

        DataSet dsSelect = new DataSet();

        dsSelect = obj_BAL_Student_Dashboard.BAL_Select_Chart_Data(obj_Student_Dashboard);

        if (dsSelect.Tables[0].Rows.Count > ((int)EnumFile.AssignValue.Zero))
            {
            CoveredChapters = Convert.ToInt32(dsSelect.Tables[0].Rows[0]["Covered"].ToString());
            UncoveredChapters = 100 - CoveredChapters;
            }
        KeyValueData okey = new KeyValueData();
        okey.Key = Convert.ToString("data-percent");
        okey.Value = Convert.ToString(CoveredChapters);
        olst.Add(okey);


        okey = new KeyValueData();
        okey.Key = Convert.ToString("data-text");
        okey.Value = Convert.ToString(CoveredChapters) + "%";
        olst.Add(okey);

        return olst.ToArray();
        }
    [WebMethod]
    public static string SaveStudentFinishActivity(string bmssctid, string studentid, string ActivityFeedback)
        {
        string response = string.Empty;
        //if ((Convert.ToString(AppSessions.BMSSCTID) == bmssctid) && (Convert.ToString(AppSessions.StudentID) == studentid))
        //{
        ClassRoomActivityLog ClassRoomActivityLog = new ClassRoomActivityLog();
        ClassRoomActivityLog_BLogic BAL_ClassRoomActivityLog = new ClassRoomActivityLog_BLogic();

        ClassRoomActivityLog.bmssctid = Convert.ToInt32(bmssctid);
        ClassRoomActivityLog.Studentid = AppSessions.StudentID;
        ClassRoomActivityLog.ActivityFeedback = ActivityFeedback;
        //ClassRoomActivityLog.FeedbackRating = Convert.ToInt32(strrating);

        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), StringEnum.stringValueOf(EnumFile.AccessedPages.StudentDashboard), "Finish Activity", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.AllActivityFinished), "Feedback: " + ActivityFeedback, Convert.ToInt32(bmssctid));

        int result = BAL_ClassRoomActivityLog.BAL_ClassRoomActivityLog_Insert_Student(ClassRoomActivityLog);

        if (result == Convert.ToInt32(EnumFile.Result.TopicNotCovered))
            response = "Covered successfully";
        else if (result == Convert.ToInt32(EnumFile.Result.TopicCovered))
            response = "Already covered";
        //}
        //else
        //{
        //    response = "Failed";
        //}
        return response;
        }
    [WebMethod]
    public static void LogResourceAccess(string resource, string resourcepath)
        {
        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), StringEnum.stringValueOf(EnumFile.AccessedPages.StudentDashboard), "Educational Resources List", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, resource + StringEnum.stringValueOf(EnumFile.Activity.ResourceExplored), "Resource Location: " + resourcepath, 0);
        }

    private DataTable _dtexamResult;
    public DataTable dtexamResult
        {
        get
            {
            return _dtexamResult;
            }
        set
            {
            _dtexamResult = value;


            }
        }


    [WebMethod]
    public static List<object> GetPerformanceChartdata(int subjectid)
        {
        StringBuilder sb = new StringBuilder();
        List<object> iData = new List<object>();
        List<string> labels = new List<string>();
        List<string> lst_dataItem_1 = new List<string>();
        try
            {

            //int subjectid = Convert.ToInt16(AppSessions.SubjectID);
            //int subjectid = 1;
            int studentid = Convert.ToInt32(AppSessions.StudentID);
            int bmsid = Convert.ToInt32(AppSessions.BMSID);


            DataTable dtexam = new DataTable();
            dtexam.Columns.Add("Chapter", typeof(string));
            dtexam.Columns.Add("ObtainedPercentage", typeof(string));


            DataSet dsResult = new DataSet();
            ReportsForResult Report_Bal = new ReportsForResult();


            string data;

            // dsResult = Report_Bal.BAL_SYS_ResultRPTByStudentSubDetails(studentid, subjectid,bmsid);
            dsResult = Report_Bal.BAL_SYS_Student_Performance_Chart(studentid, subjectid, bmsid);

            //sb.Append("[");

            if (dsResult.Tables[0].Rows.Count > 0 && dsResult != null)
                {
                for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                    {
                    //int count = dsResult.Tables[0].Rows.Count;
                    //DataRow dr = dtexam.NewRow();

                    //dr["Chapter"] = dsResult.Tables[0].Rows[0]["Chapter"].ToString();
                    //dr["ObtainedPercentage"] = dsResult.Tables[0].Rows[0]["ObtainedPercentage"].ToString(); ;
                    //dtexam.Rows.Add(dr);
                    //sb.Append("{");
                    //System.Threading.Thread.Sleep(50);
                    //string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                    //sb.Append(string.Format("text :'{0}', value:{1}, color: '{2}'", dsResult.Tables[0].Rows[0]["Chapter"].ToString(), dsResult.Tables[0].Rows[0]["ObtainedPercentage"].ToString(), color));
                    //sb.Append("},");
                    labels.Add(dsResult.Tables[0].Rows[i]["Chapter"].ToString());
                    // lst_dataItem_1.Add(Convert.ToInt32(dsResult.Tables[0].Rows[i]["ObtainedPercentage"]));
                    if (dsResult.Tables[0].Rows[i]["ObtainedPercentage"].ToString().Length > 0)
                        {
                        lst_dataItem_1.Add(dsResult.Tables[0].Rows[i]["ObtainedPercentage"].ToString());
                        }
                    else
                        {
                        lst_dataItem_1.Add(null);
                        }


                    }
                iData.Add(labels);
                iData.Add(lst_dataItem_1);
                }

            else
                {
                DataRow dr = dtexam.NewRow();
                dr["chapter"] = "";
                dr["ObtainedPercentage"] = "";
                dtexam.Rows.Add(dr);

                }
            //sb = sb.Remove(sb.Length - 1, 1);
            //sb.Append("]");


            }
        catch (Exception ex)
            {
            WebMsg.Show("" + ex.Message.ToString());
            }
        //return sb.ToString();
        return iData;
        }

    #endregion



    #region Other Method

    private static string GetAvailableTopicHTML()
        {
        StringBuilder oBuilder = new StringBuilder();
        Student_DashBoard_BLogic obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        StudentDash obj_Student_Dashboard = new StudentDash();

        obj_Student_Dashboard.BMSID = Convert.ToInt64(AppSessions.BMSID);
        obj_Student_Dashboard.SubjectID = Convert.ToInt16(AppSessions.SubjectID);
        obj_Student_Dashboard.StudentID = Convert.ToInt64(AppSessions.StudentID);

        DataSet dsSelect = new DataSet();
        dsSelect = obj_BAL_Student_Dashboard.BAL_Select_All_Chapters_Topics(obj_Student_Dashboard);

        oBuilder.Append("<div><div style=\"text-align:left;\"> This is limited period trial account for evaluation.<br><br>You have access to some sample educational resources. Please find sample educational resources in topic \"<span style=\"color: #71af32;font-weight: bold;\">");

        int i = 0;
        foreach (DataRow odr in dsSelect.Tables[1].Rows)
            {
            string bmssct = Convert.ToString(odr["BMSSCTID"]);
            string ContentFolderPath = System.Web.HttpContext.Current.Server.MapPath("../EduResource/" + Convert.ToString(odr["BMSSCTID"]) + "_Demo");
            if (Directory.Exists(ContentFolderPath))
                {
                i = i + 1;
                if (i <= 1)
                    oBuilder.Append(Convert.ToString(odr["Topic"]));
                else
                    oBuilder.Append(", " + Convert.ToString(odr["Topic"]));
                }
            }
        if (i == 0)
            {
            oBuilder = new StringBuilder();
            oBuilder.Append("<div>No demo content available for current chapter/topic list.</div>");
            }
        else
            oBuilder.Append("</span>\". <br><br>Kindly buy the desired package to access all educational resources. <a style=\"color: #71af32;font-weight: bold;\" href=\"BuyPackage.aspx\">Click here</a></div></div>");

        return Convert.ToString(oBuilder);
        }
    private static string BuildContentHTML(bool iscover, int bmssctid, DataTable dt, string topic = "")
        {
        StringBuilder oBuilder = new StringBuilder();
        StudentWiseCoveredSyllabus objSwcs = new StudentWiseCoveredSyllabus();
        int studentID = Convert.ToInt32(HttpContext.Current.Session["StudentID"].ToString());
        dt.DefaultView.Sort = "Ext";
        dt = dt.DefaultView.ToTable();

        //dt.DefaultView.Sort = "Ext ASC"; 
        Boolean isVideoCovered = objSwcs.BAL_IsResourceTypeCovered(studentID, bmssctid, resourceType.Video);
        Boolean isTestCovered = objSwcs.BAL_IsResourceTypeCovered(studentID, bmssctid, resourceType.Test);

        List<DataTable> dtext = dt.AsEnumerable().GroupBy(row => row.Field<string>("Ext")).Select(g => g.CopyToDataTable()).ToList();

        for (int i = 0; i < dtext.Count; i++)
            {
            if ((dtext[i].Rows[0]["Ext"].ToString().ToLower() == ".mp4") || (dtext[i].Rows[0]["Ext"].ToString().ToLower() == ".swf")|| (dtext[i].Rows[0]["Ext"].ToString().ToLower() == ".m4v"))
                {
                //ext.ToString().Equals(".swf"
                oBuilder.Append("<div class=\"col-sm-12\" >");
                oBuilder.Append("<span style=\"font-size:14px;Font-weight:500;color:#c2822b;\"> Learn</span>");
                }
            if (dtext[i].Rows[0]["Ext"].ToString().ToLower() == ".test")
                {
                oBuilder.Append("<div class=\"col-sm-12\" >");
                oBuilder.Append("<span style =\"font-size:14px;Font-weight:500;color:#c2822b;\"> Take Test</span>");
                }
            if (dtext[i].Rows[0]["Ext"].ToString().ToLower() == ".pdf")
            {
                oBuilder.Append("<div class=\"col-sm-12\" >");
                oBuilder.Append("<span style =\"font-size:14px;Font-weight:500;color:#c2822b;\"> View TextBook</span>");
            }
            int j = 1;
            foreach (DataRow dr in dtext[i].Rows)
                {
                //string var = "<button type=\"button\" data-toggle=\"modal\" data-target=\"#myModal\" class=\"btn btn-outline-primary\" onclick=\"javascript:return PlayContent('" + dr["Resource"] + "','" + dr["Ext"] + "','" + dr["ResourcePath"] + "','" + bmssctid + "');\">" + Regex.Replace(Convert.ToString(dr["Resource"]), "^[\\d]*", "", RegexOptions.IgnoreCase) + "</button>";
                var resourceName = Regex.Replace(Convert.ToString(dr["Resource"]), "^[\\d]*", "", RegexOptions.IgnoreCase);

                //if (resourceName.ToLower() == "pretest" || resourceName.ToLower() == "posttest")
                //{
                //    resourceName = "Quiz";
                //}

                if (resourceName.ToLower() == "pretest")
                    {
                    resourceName = "Pre-test";
                    }

                if (resourceName.ToLower() == "posttest")
                    {
                    resourceName = "Post-test";
                    }
                resourceName = resourceName.Trim();
                string var = "";

                if ((dtext[i].Rows[0]["Ext"].ToString().ToLower() == ".mp4") || (dtext[i].Rows[0]["Ext"].ToString().ToLower() == ".swf")|| (dtext[i].Rows[0]["Ext"].ToString().ToLower() == ".m4v"))
                    {
                    string FullPath = "../NewPublic/img/Learn.png";
                    HttpContext.Current.Session["ContentPath"] = dr["ResourcePath"];
                    HttpContext.Current.Session["free"] = AppSessions.IsFreePackage;

                    HttpContext.Current.Session["ContentType"] = "video/mp4";
                    //var = "<img alt=\"\" src=\"" + FullPath + "\"  ><button  data-bmssctID=\"" + bmssctid + "\"  type=\"button\" data-toggle=\"modal\" data-target=\"#myModal\" class=\"btn btn-outline-primary\" onclick=\"javascript:return PlayContent('" + dr["Resource"] + "','" + dr["Ext"] + "','" + dr["ResourcePath"] + "','" + bmssctid + "');\">" + topic + "</button> ";
                    var = "<img   alt=\"\" src=\"" + FullPath + "\"width=\"20\"   ><a href=\"\"  style=\" color: black !important;   border: 0px solid #f6f7f7 !important; width:50%;\"  data-bmssctID=\"" + bmssctid + "\"  data-toggle=\"modal\" data-target=\"#myModal\" onclick=\"javascript:return PlayContent('" + dr["Resource"] + "','" + dr["Ext"] + "','" + dr["ResourcePath"] + "','" + bmssctid + "');\">" + topic + "-" + j + "</a> ";

                    }
                j = j + 1;
                if (dtext[i].Rows[0]["Ext"].ToString().ToLower() == ".test")
                    {
                    string FullPath = "../NewPublic/img/Practice.png";
                    //var = "<img alt=\"\" src=\"" + FullPath + "\"  ><button  style=\"background-color: #f6f7f7; color: black !important;   border: 0px solid #f6f7f7 !important; width:50%;\" data-bmssctID=\"" + bmssctid + "\"   data-toggle=\"modal\" data-target=\"#myModal\" class=\"btn btn-outline-primary\" onclick=\"javascript:return PlayContent('" + dr["Resource"] + "','" + dr["Ext"] + "','" + dr["ResourcePath"] + "','" + bmssctid + "');\">" + resourceName + "</button> ";
                    var = "<img alt=\"\" src=\"" + FullPath + "\"width=\"20\" ><a href=\"\"  style=\" color: black !important;   border: 0px solid #f6f7f7 !important; width:50%;\" data-bmssctID=\"" + bmssctid + "\"   data-toggle=\"modal\" data-target=\"#myModal\"  onclick=\"javascript:return PlayContent('" + dr["Resource"] + "','" + dr["Ext"] + "','" + dr["ResourcePath"] + "','" + bmssctid + "');\">" + resourceName + "</a> ";
                    }
                //****change for displaying textbook ****/
                if (dtext[i].Rows[0]["Ext"].ToString().ToLower() == ".pdf")
                {
                    string FullPath = "../NewPublic/img/Book.png";
                    //var = "<img alt=\"\" src=\"" + FullPath + "\"  ><button  style=\"background-color: #f6f7f7; color: black !important;   border: 0px solid #f6f7f7 !important; width:50%;\" data-bmssctID=\"" + bmssctid + "\"   data-toggle=\"modal\" data-target=\"#myModal\" class=\"btn btn-outline-primary\" onclick=\"javascript:return PlayContent('" + dr["Resource"] + "','" + dr["Ext"] + "','" + dr["ResourcePath"] + "','" + bmssctid + "');\">" + resourceName + "</button> ";
                    var = "<img alt=\"\" src=\"" + FullPath + "\"width=\"20\" ><a href=\"\"  style=\" color: black !important;   border: 0px solid #f6f7f7 !important; width:50%;\" data-bmssctID=\"" + bmssctid + "\"   data-toggle=\"modal\" data-target=\"#myModal\"  onclick=\"javascript:return PlayContent('" + dr["Resource"] + "','" + dr["Ext"] + "','" + dr["ResourcePath"] + "','" + bmssctid + "');\">" + resourceName + "</a> ";
                }

                if ((dr["Ext"].ToString().ToLower() == ".mp4") || (dr["Ext"].ToString().ToLower()  == ".swf")|| (dr["Ext"].ToString().ToLower() == ".m4v"))                    {
                    //var = var.Replace("btn-outline-primary", "btn-outline-secondary");
                    objSwcs.BAL_AppendStudentWiseCoveredDetails(studentID, bmssctid, dr["Resource"].ToString(), "Video", false, null);
                    }
                else if (dr["Ext"].ToString().ToLower() == ".pdf")
                    {
                    //var = var.Replace("btn-outline-primary", "btn-outline-warning");
                    //Make button disabled if video is not covered---------------
                    if (isVideoCovered == false)
                        {
                        //var = var.Replace("btn-outline-warning", "disabled");
                        var = var.Replace("<button ", "<button disabled ");
                        }
                    }
                else if (dr["Ext"].ToString().ToLower() == ".test")
                    {
                    var = var.Replace("btn-outline-primary", "btn-outline-success");
                    //Make button disabled if video is not covered---------------
                    if (isVideoCovered == false)
                        {
                        //var = var.Replace("btn-outline-success", "disabled");
                        if (dr["Resource"].ToString().ToLower() == "posttest")
                            var = var.Replace("<button ", "<button disabled ");
                        }

                    objSwcs.BAL_AppendStudentWiseCoveredDetails(studentID, bmssctid, dr["Resource"].ToString(), "Test", false, null);
                    }
                else
                    {
                    //var = var.Replace("btn-outline-primary", "btn-outline-primary");
                    //Make button disabled if video is not covered---------------
                    if (isVideoCovered == false)
                        {
                        //var = var.Replace("btn-outline-primary", "disabled");
                        var = var.Replace("<button ", "<button disabled ");
                        }
                    }

                oBuilder.Append("</br>");
                oBuilder.Append(var);


                //Builder.Append("<div onclick=\"javascript:return PlayContent('" + dr["Resource"] + "','" + dr["Ext"] + "','" + dr["ResourcePath"] + "','" + bmssctid + "');\">" + Regex.Replace(Convert.ToString(dr["Resource"]), "^[\\d]*", "", RegexOptions.IgnoreCase) + "</div>");

                //oBuilder.Append("<table cellspacing='2' cellpadding='2' border='1' style='width:100%;'  class='GridViewForRes'>");
                //oBuilder.Append("<tbody><tr align='left' class='GridViewItemForRes'>");
                //oBuilder.Append("<td>");
                //oBuilder.Append("<div onclick=\"javascript:return PlayContent('" + dr["Resource"] + "','" + dr["Ext"] + "','" + dr["ResourcePath"] + "','" + bmssctid + "');\">" + Regex.Replace(Convert.ToString(dr["Resource"]), "^[\\d]*", "", RegexOptions.IgnoreCase) + "</div>");
                //oBuilder.Append("</td>");
                //oBuilder.Append("</tr>");
                //oBuilder.Append("</tbody></table>");
                }

            oBuilder.Append("</div>");
            }

        oBuilder.Append("<div class=\"d-none\" >");

        //d-none

        string htmlstring = GetFeedBackAndRating(bmssctid, AppSessions.StudentID);
        oBuilder.Append(htmlstring);

        oBuilder.Append("<div style=\"text-align:right; margin-top:10px; margin-bottom:-10px;\" class=sr><input id=\"btnsubmitreview\" type=\"submit\" onclick=\"javascript:return SubmitReview('" + AppSessions.BMSSCTID + "');\" value=\"Submit\" name=\"btnSubmit\"></div>");
        if (dt.Rows.Count > 0 && !iscover)
            oBuilder.Append("<div style=\"text-align:center; margin-top:10px; margin-bottom:-10px;\"><input id=\"btnsubmitfeedback\" type=\"submit\" onclick=\"javascript:return showfeedback('" + AppSessions.BMSSCTID + "','" + Convert.ToString(AppSessions.StudentID) + "');\" value=\"Finish Activity\" name=\"btnSave\"></div>");

        oBuilder.Append("</div>");

        return Convert.ToString(oBuilder);
        }

    private static string GetFeedBackAndRating(int BMSSCTID, int StudentID)
        {
        string htmlstring = string.Empty;
        DataSet OActivityFeedback = new DataSet();
        Student_DashBoard_BLogic obj_BAL_Student_Dashboard = new Student_DashBoard_BLogic();
        OActivityFeedback = obj_BAL_Student_Dashboard.BAL_Select_ActivityFeedbackReviewRatingStudent(BMSSCTID, StudentID);
        int intrating = 0;
        string strfeedback = string.Empty;
        if (OActivityFeedback.Tables[0].Rows.Count > 0)
            {
            if (OActivityFeedback.Tables[0].Rows[0]["FeedbackRating"].ToString() != string.Empty)
                intrating = Convert.ToInt32(OActivityFeedback.Tables[0].Rows[0]["FeedbackRating"].ToString());
            if (OActivityFeedback.Tables[0].Rows[0]["ActivityFeedback"].ToString() != string.Empty)
                strfeedback = OActivityFeedback.Tables[0].Rows[0]["ActivityFeedback"].ToString();
            }
        htmlstring = "<div style=\'margin-top: 10px;\' class=starr> <span class=rating> <span class=rtng>Rating :</span> ";

        htmlstring += "<input type=radio class=rating-input id=rating-input-1-5-" + BMSSCTID + "  name=rating-input-1-" + BMSSCTID + "/>";
        if (intrating == 5)
            htmlstring += "<label for=rating-input-1-5-" + BMSSCTID + " class=rating-star style=\'background-position: 0px 0px;\'></label>";
        else
            htmlstring += "<label for=rating-input-1-5-" + BMSSCTID + " class=rating-star></label>";

        htmlstring += "<input type=radio class=rating-input id=rating-input-1-4-" + BMSSCTID + " name=rating-input-1-" + BMSSCTID + "/>";
        if (intrating >= 4)
            htmlstring += "<label for=rating-input-1-4-" + BMSSCTID + " class=rating-star style=\'background-position: 0px 0px;\'></label>";
        else
            htmlstring += "<label for=rating-input-1-4-" + BMSSCTID + " class=rating-star></label>";

        htmlstring += "<input type=radio class=rating-input id=rating-input-1-3-" + BMSSCTID + " name=rating-input-1-" + BMSSCTID + "/>";
        if (intrating >= 3)
            htmlstring += "<label for=rating-input-1-3-" + BMSSCTID + " class=rating-star style=\'background-position: 0px 0px;\'></label>";
        else
            htmlstring += "<label for=rating-input-1-3-" + BMSSCTID + " class=rating-star></label>";

        htmlstring += "<input type=radio class=rating-input id=rating-input-1-2-" + BMSSCTID + " name=rating-input-1-" + BMSSCTID + "/>";
        if (intrating >= 2)
            htmlstring += "<label for=rating-input-1-2-" + BMSSCTID + " class=rating-star style=\'background-position: 0px 0px;\'></label>";
        else
            htmlstring += "<label for=rating-input-1-2-" + BMSSCTID + " class=rating-star></label>";

        htmlstring += "<input type=radio class=rating-input id=rating-input-1-1-" + BMSSCTID + " name=rating-input-1-" + BMSSCTID + "/>";
        if (intrating >= 1)
            htmlstring += "<label for=rating-input-1-1-" + BMSSCTID + " class=rating-star style=\'background-position: 0px 0px;\'></label>";
        else
            htmlstring += "<label for=rating-input-1-1-" + BMSSCTID + " class=rating-star ></label>";

        htmlstring += "</span></div>";

        htmlstring += "<div style=\"text-align:left; margin-top:10px; margin-bottom:-10px; margin-left:2px;\" class=txtreview> <textarea id=txtreview_" + BMSSCTID + " name=txtfeedback rows=2 cols=35> " + strfeedback + " </textarea> </div>";



        return htmlstring;
        }

    private static string BuildContentHTMLDisable(bool iscover, int bmssctid, DataTable dt)
        {
        StringBuilder oBuilder = new StringBuilder();

        foreach (DataRow dr in dt.Rows)
            {
            oBuilder.Append("<table cellspacing='2' cellpadding='2' border='1' style='width:100%;'  class='GridViewForRes'>");
            oBuilder.Append("<tbody><tr align='left' class='GridViewItemForRes'>");
            oBuilder.Append("<td>");
            oBuilder.Append("<div onclick=\"javascript:alert('Subscribe First');\">" + Regex.Replace(Convert.ToString(dr["Resource"]), "^[\\d]*", "", RegexOptions.IgnoreCase) + "</div>");
            oBuilder.Append("</td>");
            oBuilder.Append("</tr>");
            oBuilder.Append("</tbody></table>");
            }
        if (dt.Rows.Count > 0 && !iscover)
            oBuilder.Append("<div style=\"text-align:center; margin-top:10px; margin-bottom:-10px;\"><input id=\"btnsubmitfeedback\" type=\"submit\" value=\"Finish Activity\" name=\"btnSave\"></div>");

        oBuilder.Append("<div onclick=\"javascript:return RedirectToBuy();\" class=\"hoversubscribe\" style=\"width: 100%; cursor:pointer; height: 100%;  position: absolute;  top: 0;  left: 0%;z-index: 10;\"><div width=\"100%\" height=\"100%\"></div></div>");

        return Convert.ToString(oBuilder);
        }
    //change 09-07-2020
    private static string BuildContentHTMLDisablenew(bool iscover, int bmssctid, string topic)
        {
        StringBuilder oBuilder = new StringBuilder();


        string var = ""; string FullPath;
        oBuilder.Append("<div class=\"col-sm-12\" onclick=\"javascript:alert('Not Available for this package');\" >");
        oBuilder.Append("<span style=\"font-size:14px;Font-weight:500;color:#c2822b;\"> Learn</span>");
          FullPath = "../NewPublic/img/Learn.png";
        var = "<img   alt=\"\" src=\"" + FullPath + "\"width=\"20\"   ><a href=\"#\"  style=\" color: black !important;   border: 0px solid #f6f7f7 !important; width:50%;\"  );\">" + topic + "</a> ";
        oBuilder.Append("</br>");
        oBuilder.Append(var);
        oBuilder.Append("</div>");
       






        return Convert.ToString(oBuilder);
        }
    [WebMethod]
    public static string UpdateRating(string ratingid)
        {
        string strresponce = string.Empty;
        try
            {
            string[] strratingid = ratingid.Split('-');

            ClassRoomActivityLog ClassRoomActivityLog = new ClassRoomActivityLog();
            ClassRoomActivityLog_BLogic BAL_ClassRoomActivityLog = new ClassRoomActivityLog_BLogic();

            ClassRoomActivityLog.bmssctid = Convert.ToInt32(strratingid[4].ToString());
            ClassRoomActivityLog.Studentid = AppSessions.StudentID;
            ClassRoomActivityLog.FeedbackRating = Convert.ToInt32(strratingid[3].ToString());

            int result = BAL_ClassRoomActivityLog.BAL_ClassRoomActivityLog_InsertRating_Student(ClassRoomActivityLog);


            strresponce = "Rating stored sucessfully";

            }
        catch (Exception)
            {
            strresponce = "Error while storing rating";
            }
        return strresponce;
        }

    [WebMethod]
    public static string UpdateReview(int BMSSCTID, string txtreview)
        {
        try
            {
            string strresponce = string.Empty;
            try
                {
                ClassRoomActivityLog ClassRoomActivityLog = new ClassRoomActivityLog();
                ClassRoomActivityLog_BLogic BAL_ClassRoomActivityLog = new ClassRoomActivityLog_BLogic();

                ClassRoomActivityLog.bmssctid = Convert.ToInt32(BMSSCTID);
                ClassRoomActivityLog.Studentid = AppSessions.StudentID;
                ClassRoomActivityLog.ActivityFeedback = txtreview;


                int result = BAL_ClassRoomActivityLog.BAL_ClassRoomActivityLog_InsertRating_Student(ClassRoomActivityLog);


                strresponce = "Review sumitted sucessfully.";

                }
            catch (Exception)
                {
                strresponce = "Error while submitting review.";
                }
            return strresponce;

            }
        catch (Exception)
            {

            throw;
            }
        }
    private static string BuildThumbnailHTML(int bmssctid)
        {
        StringBuilder oBuilder = new StringBuilder();

        string ContentFolderPath = string.Empty;

        // if (AppSessions.IsFreePackage == "free")//free
        //ContentFolderPath = System.Web.HttpContext.Current.Server.MapPath("../EduResource/" + bmssctid + "_Demo");
        //else if (AppSessions.IsFreePackage == "paid")//paid
        ContentFolderPath = System.Web.HttpContext.Current.Server.MapPath("../EduResource/" + bmssctid);

        string strReturn = string.Empty;
        if (Directory.Exists(ContentFolderPath))
            {
            string[] Files = Directory.GetFiles(ContentFolderPath, "*.jpg");


            if (Files.Length > 0)
                {
                string FileName = Path.GetFileName(Files[0]);
                string FullPath = string.Empty;
                //if (AppSessions.IsFreePackage == "free")//free
                //  FullPath = "../EduResource/" + bmssctid + "_Demo" + "/" + FileName;
                //else if (AppSessions.IsFreePackage == "paid")//paid
                FullPath = "../EduResource/" + bmssctid + "/" + FileName;
                strReturn = FullPath;
                oBuilder.Append("<div id=\"output\" style=\"width: 100%; margin-bottom: 5px;\"><img alt=\"\" src=\"" + FullPath + "\" width=\"100%\" class=\"content_photo\" onload=\"javascript:ApplyJS();\"></div>");
                }
            else
                {
                oBuilder.Append("<div id=\"output\" style=\"width: 100%; margin-bottom: 5px;\"><img alt=\"no content\" width=\"100%\" src=\"../App_Themes/Green/Images/NoContentPreview.png\" class=\"content_photo\" onload=\"javascript:ApplyJS();\"></div>");
                strReturn = "../App_Themes/Green/Images/NoContentPreview.png";
                }
            }
        else
            {
            oBuilder.Append("<div id=\"output\" style=\"width: 100%; margin-bottom: 5px;\"><img alt=\"no content\" width=\"100%\" src=\"../App_Themes/Green/Images/NoContentPreview.png\" class=\"content_photo\" onload=\"javascript:ApplyJS();\"></div>");
            strReturn = "../App_Themes/Green/Images/NoContentPreview.png";
            }
        return Convert.ToString(oBuilder);
        //return strReturn;
        }

    protected static string BuildTopicChapterHTML(DataSet dsSelect)
        {
        StringBuilder oBuilder = new StringBuilder();
        int i = 0;
        bool iscontentavailable = false;

        foreach (DataRow odr in dsSelect.Tables[0].Rows)
            {
            DataRow[] dataRows = dsSelect.Tables[1].Select("ChapterID = " + odr["ChapterID"] + "");
            i = 0;
            foreach (DataRow odrtopic in dataRows)
                {
                if (i == 0)
                    {
                    i++;
                    }
                else
                    {
                    continue;
                    }
                //change 09-07-2020
                if (AppSessions.IsFreePackage == "free")
                    {
                    iscontentavailable = true;
                    }
                else
                    {
                    if (CheckFolderExists(Convert.ToInt32(odrtopic["BMSSCTID"])))
                        {
                        iscontentavailable = true;
                        }
                    else
                        {
                        iscontentavailable = false;
                        }
                    }

                if (iscontentavailable)
                    {
                    var bmsSctID = odrtopic["BMSSCTID"];
                    var topic = " " + odrtopic["Topic"];
                    //var chNo = "Ch. " + odrtopic["SequenceNo"] + "." + odrtopic["TopicIndex"];
                    var chapterNo = odrtopic["SequenceNo"];


                    oBuilder.Append("<div class=\"col-md-3 col-12\" data-isCard=\"true\" data-chapter=\"" + topic + "\" >");
                    oBuilder.Append("<div class=\"card\">");

                    if (Convert.ToBoolean(odrtopic["IsCurrent"]) == true)
                        {
                        //Make card expanded on current chapter topic
                        oBuilder.Append("<div class=\"card-header\" data-toggle=\"collapse\" href=\"#collapse" + bmsSctID + "\" role=\"button\" aria-expanded=\"true\" aria-controls=\"collapse" + bmsSctID + "\">");
                        }
                    else
                        {
                        //Make card collapsed on not current chapter topic
                        oBuilder.Append("<div class=\"card-header collapsed\" data-toggle=\"collapse\" href=\"#collapse" + bmsSctID + "\" role=\"button\" aria-expanded=\"false\" aria-controls=\"collapse" + bmsSctID + "\">");
                        }

                    //oBuilder.Append("<div class=\"text-secondary\"> Chapter " + chapterNo + "</div>");
                    oBuilder.Append("<div class=\"text-secondary\">  " + topic + "</div>");
                    //oBuilder.Append("<h5 class=\"text-primary align-baseline\" id=\"chapter" + bmsSctID + "\" ><strong>" + topic + "</strong></h5>");
                    oBuilder.Append("<h5 class=\"text-primary align-baseline\" id=\"chapter" + bmsSctID + "\" ></h5>");
                    if (Convert.ToBoolean(odrtopic["IsCovered"]) == true)
                        {
                        //Show tick icon on covered chapter topic
                        oBuilder.Append("<h4><i class=\"fa fa-check-circle pull-right CoveredChapter\" aria-hidden=\"false\"></i></h4>");
                        }
                    oBuilder.Append("</div>");

                    if (Convert.ToBoolean(odrtopic["IsCurrent"]) == true)
                        {
                        //Make card body expanded on not current chapter topic

                        //oBuilder.Append(" <div class=\"card-body\" id=\"collapse" + bmsSctID + "\">");
                        oBuilder.Append(" <div class=\"card-body\" id=\"collapse" + bmsSctID + "\">");
                        oBuilder.Append(" <div class=\"container-fluid\">");
                        oBuilder.Append(" <div class=\"row\">");

                        }
                    else
                        {
                        //Make card collapsed on current chapter topic

                        oBuilder.Append(" <div class=\"card-body collapse\" id=\"collapse" + bmsSctID + "\">");
                        oBuilder.Append(" <div class=\"container-fluid\">");
                        oBuilder.Append(" <div class=\"row\">");

                        }


                    //oBuilder.Append(BuildThumbnailHTML(Convert.ToInt32(odrtopic["BMSSCTID"])));
                    oBuilder.Append(SeprateContent(Convert.ToInt32(odrtopic["BMSSCTID"]), Convert.ToBoolean(odrtopic["IsCovered"]), topic.ToString()));
                    oBuilder.Append("</div>");

                    oBuilder.Append("</div>");
                    oBuilder.Append("</div>");
                    oBuilder.Append("</div>");
                    oBuilder.Append("</div>");

                    //oBuilder.Append("<div class=\"grid-item col-xs-12 col-sm-6 col-md-4 col-xl-4 NoPadding\">");
                    //oBuilder.Append("<div class=\"Activity grid-item-content\">");
                    //oBuilder.Append("<div class=\"ActivityHeadingNormal\">");
                    //oBuilder.Append(odrtopic["Topic"]);
                    //oBuilder.Append("</div>");
                    //oBuilder.Append("<div class=\"Content\" style=\"position:relative;\">");
                    //oBuilder.Append(BuildThumbnailHTML(Convert.ToInt32(odrtopic["BMSSCTID"])));
                    //oBuilder.Append(SeprateContent(Convert.ToInt32(odrtopic["BMSSCTID"]), Convert.ToBoolean(odrtopic["IsCovered"])));
                    //oBuilder.Append("</div>");
                    //oBuilder.Append("</div>");
                    //oBuilder.Append("</div>");

                    //odrtopic["imagePath"] = BuildThumbnailHTML(Convert.ToInt32(odrtopic["BMSSCTID"]));
                    //  }
                    }

                }
            }


        if (iscontentavailable == true)
            {
            return Convert.ToString(oBuilder);
            }
        else
            {
            //oBuilder.Append("<div class=\"col-8\"><h3 style=\"color:red;\"> Resource not available </h3></div>");
            return Convert.ToString(oBuilder);
            }

        //oBuilder.Append("<div class=\"col-sm-12\">");
        //oBuilder.Append("<div class=\"grid\" data-masonry=\"{ &quot;itemSelector&quot;: &quot;.grid-item&quot; }\">");

        //foreach (DataRow odr in dsSelect.Tables[0].Rows)
        //{
        //    DataRow[] dataRows = dsSelect.Tables[1].Select("ChapterID = " + odr["ChapterID"] + "");
        //    foreach (DataRow odrtopic in dataRows)
        //    {
        //        if (CheckFolderExists(Convert.ToInt32(odrtopic["BMSSCTID"])))
        //        {
        //            oBuilder.Append("<div class=\"grid-item col-xs-12 col-sm-6 col-md-4 col-xl-4 NoPadding\">");
        //            oBuilder.Append("<div class=\"Activity grid-item-content\">");
        //            oBuilder.Append("<div class=\"ActivityHeadingNormal\">");
        //            oBuilder.Append(odrtopic["Topic"]);
        //            oBuilder.Append("</div>");
        //            oBuilder.Append("<div class=\"Content\" style=\"position:relative;\">");
        //            oBuilder.Append(BuildThumbnailHTML(Convert.ToInt32(odrtopic["BMSSCTID"])));
        //            oBuilder.Append(SeprateContent(Convert.ToInt32(odrtopic["BMSSCTID"]), Convert.ToBoolean(odrtopic["IsCovered"])));
        //            oBuilder.Append("</div>");
        //            oBuilder.Append("</div>");
        //            oBuilder.Append("</div>");

        //            odrtopic["imagePath"] = BuildThumbnailHTML(Convert.ToInt32(odrtopic["BMSSCTID"]));
        //        }
        //    }
        //}
        //oBuilder.Append("</div>");
        //oBuilder.Append("</div>");
        //return Convert.ToString(oBuilder);
        }
    private static string BuildTopicChapterHTMLWithSubject(DataSet dsSelect)
        {
        StringBuilder oBuilder = new StringBuilder();

        oBuilder.Append("<div class=\"col-sm-12\">");
        oBuilder.Append("<div class=\"grid\" data-masonry=\"{ &quot;itemSelector&quot;: &quot;.grid-item&quot; }\">");

        foreach (DataRow odr in dsSelect.Tables[0].Rows)
            {
            DataRow[] dataRows = dsSelect.Tables[1].Select("ChapterID = " + odr["ChapterID"] + "");
            foreach (DataRow odrtopic in dataRows)
                {
                if (CheckFolderExists(Convert.ToInt32(odrtopic["BMSSCTID"])))
                    {
                    oBuilder.Append("<div class=\"grid-item col-xs-12 col-sm-6 col-md-4 col-xl-4 NoPadding\">");
                    oBuilder.Append("<div class=\"Activity grid-item-content\">");
                    oBuilder.Append("<div class=\"ActivityHeadingNormal\">");
                    oBuilder.Append(odrtopic["Topic"]);
                    oBuilder.Append("</div>");
                    oBuilder.Append("<div class=\"Content\" style=\"position:relative;\">");
                    oBuilder.Append(BuildThumbnailHTML(Convert.ToInt32(odrtopic["BMSSCTID"])));
                    oBuilder.Append(SeprateContent(Convert.ToInt32(odrtopic["BMSSCTID"]), Convert.ToBoolean(odrtopic["IsCovered"])));
                    oBuilder.Append("</div>");
                    oBuilder.Append("</div>");
                    oBuilder.Append("</div>");
                    }
                }
            }
        oBuilder.Append("</div>");
        oBuilder.Append("</div>");
        return Convert.ToString(oBuilder);
        }
    private static DataTable FillResource(int bmssctid, string ContentFolderPath)
        {
        DataTable dt = new DataTable();
        try
            {
            //E:\SourceSafe Project\EpathshalaResponsive\Epathshala\EduResource\3829
            string[] ContentSubFolderList = Directory.GetDirectories(ContentFolderPath);
            int ContentFolderPathLength = ContentFolderPath.Length + 1;

            dt.Columns.Add("ResourcePath");
            dt.Columns.Add("Resource");
            dt.Columns.Add("Ext");
            DataRow dr;

            #region PreTest

            bool Pretest, IsPostTest = false;
            Teacher_Dashboard_BLogic td = new Teacher_Dashboard_BLogic();
            Int64 count = td.BAL_Select_QuestionBankIDCount(bmssctid, IsPostTest);
            if (getConfigValue("Pretest") == "1" && count > 0)
                {
                Pretest = true;
                }
            else
                {
                Pretest = false;
                }
            if (Pretest)
                {
                if (AppSessions.StudentID != null && AppSessions.StudentID != 0)
                    {
                    dr = dt.NewRow();
                    dr["Resource"] = "Pretest";
                    dr["ResourcePath"] = "../Student/StudentAssessment.aspx?Level=1&TestType=Pretest";
                    dr["Ext"] = ".Test";
                    dt.Rows.Add(dr);
                    }
                else
                    {
                    dr = dt.NewRow();
                    dr["Resource"] = "Pretest";
                    dr["ResourcePath"] = "../Teacher/TeacherAssessment.aspx?Level=1&TestType=Pretest";
                    dr["Ext"] = ".Test";
                    dt.Rows.Add(dr);
                    }
                }

            #endregion

            #region Content

            foreach (string ContentSubFolderPath in ContentSubFolderList)
                {
                //E:\SourceSafe Project\EpathshalaResponsive\Epathshala\EduResource\3829\01 Animation
                //E:\SourceSafe Project\EpathshalaResponsive\Epathshala\EduResource\3829\01 Video Presentation
                //E:\SourceSafe Project\EpathshalaResponsive\Epathshala\EduResource\3829\01 Work-sheet

                string FullPath = string.Empty;
                string FileName = string.Empty;
                string ext = string.Empty;

                string[] Files = Directory.GetFiles(ContentFolderPath + "\\" + ContentSubFolderPath.Substring(ContentFolderPathLength) + "\\");

                if (Files.Length > 0)
                    {
                    FileName = Path.GetFileName(Files[0]);
                    ext = Path.GetExtension(Files[0]);
                    ext = ext.ToLower();

                    if (ext.ToString().Equals(".scc"))
                        {
                        FileName = Path.GetFileName(Files[1]);
                        ext = Path.GetExtension(Files[1]);
                        }

                    FullPath = ContentSubFolderPath + "\\" + FileName;

                    if (FileName != string.Empty)
                        {
                        dr = dt.NewRow();
                        if (FullPath.Contains("NoContent\\"))
                            FullPath = "../EduResource/" + "NoContent" + "/" + ContentSubFolderPath.Substring(ContentFolderPathLength) + "/" + FileName;
                        else
                            FullPath = "../EduResource/" + bmssctid + "/" + ContentSubFolderPath.Substring(ContentFolderPathLength) + "/" + FileName;

                        ext = ext.ToLower();
                        if (ext.ToString().Equals(".pdf"))
                            {
                            dr["Resource"] = ContentSubFolderPath.Substring(ContentFolderPathLength);
                            dr["ResourcePath"] = FullPath;
                            dr["Ext"] = ext;
                            }
                        else if (ext.ToString().Equals(".swf") || ext.ToString().Equals(".mp4") || ext.ToString().Equals(".m4v"))
                            {
                            dr["Resource"] = ContentSubFolderPath.Substring(ContentFolderPathLength);
                            dr["ResourcePath"] = FullPath;
                            dr["Ext"] = ext;
                            }
                        else if (ext.ToString().Equals(".htm") || ext.ToString().Equals(".html"))
                            {
                            dr["Resource"] = ContentSubFolderPath.Substring(ContentFolderPathLength);
                            dr["ResourcePath"] = FullPath;
                            dr["Ext"] = ext;
                            }
                        else
                            {
                            dr = null;
                            }

                        if (dr != null)
                            {
                            dt.Rows.Add(dr);
                         
                            HttpContext.Current.Session["ContentPath"] = FullPath;
 
                            HttpContext.Current.Session["ContentType"] = "video/mp4";
                            }
                        }
                    }
                }

            #endregion

            #region Posttest

            bool AllLevel;
            if (getConfigValue("AllLevel") == "0")
                {
                AllLevel = true;
                }
            else
                {
                AllLevel = false;
                }
            bool PosttestAllow;
            IsPostTest = true;
            Int64 countpost = td.BAL_Select_QuestionBankIDCount(bmssctid, IsPostTest);
            if (getConfigValue("Posttest") == "1" && countpost > 0)
                PosttestAllow = true;
            else
                PosttestAllow = false;
            if (PosttestAllow)
                {
                if (AllLevel)
                    {
                    if (AppSessions.StudentID != null && AppSessions.StudentID != 0)
                        {
                        dr = dt.NewRow();
                        dr["Resource"] = "Posttest";
                        dr["ResourcePath"] = "../Student/StudentAssessment.aspx?Level=0&TestType=Posttest";
                        dr["Ext"] = ".Test";
                        dt.Rows.Add(dr);
                        }
                    else
                        {
                        dr = dt.NewRow();
                        dr["Resource"] = "Posttest";
                        dr["ResourcePath"] = "../Teacher/TeacherAssessment.aspx?Level=0&TestType=Posttest";
                        dr["Ext"] = ".Test";
                        dt.Rows.Add(dr);
                        }
                    }
                else
                    {
                    for (int n = 1; n < 4; n++)
                        {
                        if (AppSessions.StudentID != null && AppSessions.StudentID != 0)
                            {
                            dr = dt.NewRow();
                            dr["Resource"] = "Posttest Level-" + n;
                            dr["ResourcePath"] = "../Student/StudentAssessment.aspx?Level=" + n + "&TestType=Posttest";
                            dr["Ext"] = ".Test";
                            dt.Rows.Add(dr);
                            }
                        else
                            {
                            if (n == 1)
                                {
                                dr = dt.NewRow();
                                dr["Resource"] = "Posttest Level-" + n;
                                dr["ResourcePath"] = "../Teacher/TeacherAssessment.aspx?Level=" + n + "&TestType=Posttest";
                                dr["Ext"] = ".Test";
                                dt.Rows.Add(dr);
                                }
                            }
                        }
                    }
                }
            #endregion
            }
        catch (Exception ex)
            {

            }
        return dt;
        }
    private static DataTable FillResourceDemo(int bmssctid, string ContentFolderPath)
        {
        DataTable dt = new DataTable();
        try
            {
            //E:\SourceSafe Project\EpathshalaResponsive\Epathshala\EduResource\3829
            string[] ContentSubFolderList = Directory.GetDirectories(ContentFolderPath);
            int ContentFolderPathLength = ContentFolderPath.Length + 1;

            dt.Columns.Add("ResourcePath");
            dt.Columns.Add("Resource");
            dt.Columns.Add("Ext");
            DataRow dr;

            #region PreTest

            bool Pretest, IsPostTest = false;
            Teacher_Dashboard_BLogic td = new Teacher_Dashboard_BLogic();
            Int64 count = td.BAL_Select_QuestionBankIDCount(bmssctid, IsPostTest);
            if (getConfigValue("Pretest") == "1" && count > 0)
                {
                Pretest = true;
                }
            else
                {
                Pretest = false;
                }
            if (Pretest)
                {
                if (AppSessions.StudentID != null && AppSessions.StudentID != 0)
                    {
                    dr = dt.NewRow();
                    dr["Resource"] = "Pretest";
                    dr["ResourcePath"] = "../Student/StudentAssessment.aspx?Level=0&TestType=Pretest";
                    dr["Ext"] = ".Test";
                    dt.Rows.Add(dr);
                    }
                else
                    {
                    dr = dt.NewRow();
                    dr["Resource"] = "Pretest";
                    dr["ResourcePath"] = "../Teacher/TeacherAssessment.aspx?Level=0&TestType=Pretest";
                    dr["Ext"] = ".Test";
                    dt.Rows.Add(dr);
                    }
                }

            #endregion

            #region Content

            foreach (string ContentSubFolderPath in ContentSubFolderList)
                {
                //E:\SourceSafe Project\EpathshalaResponsive\Epathshala\EduResource\3829\01 Animation
                //E:\SourceSafe Project\EpathshalaResponsive\Epathshala\EduResource\3829\01 Video Presentation
                //E:\SourceSafe Project\EpathshalaResponsive\Epathshala\EduResource\3829\01 Work-sheet

                string FullPath = string.Empty;
                string FileName = string.Empty;
                string ext = string.Empty;

                string[] Files = Directory.GetFiles(ContentFolderPath + "\\" + ContentSubFolderPath.Substring(ContentFolderPathLength) + "\\");

                if (Files.Length > 0)
                    {
                    FileName = Path.GetFileName(Files[0]);
                    ext = Path.GetExtension(Files[0]);
                    ext = ext.ToLower();

                    if (ext.ToString().Equals(".scc"))
                        {
                        FileName = Path.GetFileName(Files[1]);
                        ext = Path.GetExtension(Files[1]);
                        }

                    FullPath = ContentSubFolderPath + "\\" + FileName;

                    if (FileName != string.Empty)
                        {
                        dr = dt.NewRow();
                        if (FullPath.Contains("NoContent\\"))
                            FullPath = "../EduResource/" + "NoContent" + "/" + ContentSubFolderPath.Substring(ContentFolderPathLength) + "/" + FileName;
                        else
                             if ((AppSessions.IsFreePackage == "free") || (AppSessions.IsFreePackage == "demo"))//free
                            {
                            if (AppSessions.IsFreePackage == "free")
                                {
                                FullPath = "../EduResource/free/" + bmssctid + "/" + ContentSubFolderPath.Substring(ContentFolderPathLength) + "/" + FileName;
                                }
                            else
                                {
                                FullPath = "../EduResource/Demo/" + bmssctid + "_Demo" + "/" + ContentSubFolderPath.Substring(ContentFolderPathLength) + "/" + FileName;
                                }
                            }
                        else
                            {
                            FullPath = "../EduResource/" + bmssctid  + "/" + ContentSubFolderPath.Substring(ContentFolderPathLength) + "/" + FileName;

                            }
                        //    FullPath = "../EduResource/Demo" + bmssctid + "_Demo" + "/" + ContentSubFolderPath.Substring(ContentFolderPathLength) + "/" + FileName;
                        //   FullPath = ContentFolderPath + "\\"+ ContentSubFolderPath.Substring(ContentFolderPathLength) + "/" + FileName;

                        ext = ext.ToLower();
                        if (ext.ToString().Equals(".pdf"))
                            {
                            dr["Resource"] = ContentSubFolderPath.Substring(ContentFolderPathLength);
                            dr["ResourcePath"] = FullPath;
                            dr["Ext"] = ext;
                            }
                        else if (ext.ToString().Equals(".swf") || ext.ToString().Equals(".mp4")|| ext.ToString().Equals(".m4v"))
                            {
                            dr["Resource"] = ContentSubFolderPath.Substring(ContentFolderPathLength);
                            //dr["ResourcePath"] = FullPath;
                            dr["ResourcePath"] = FileName;
                            dr["Ext"] = ext;
                            }
                        else if (ext.ToString().Equals(".htm") || ext.ToString().Equals(".html"))
                            {
                            dr["Resource"] = ContentSubFolderPath.Substring(ContentFolderPathLength);
                            dr["ResourcePath"] = FullPath;
                            dr["Ext"] = ext;
                            }
                        else
                            {
                            dr = null;
                            }

                        if (dr != null)
                            {
                            dt.Rows.Add(dr);

                            HttpContext.Current.Session["ContentPath"] = FullPath;

                            HttpContext.Current.Session["ContentType"] = "video/mp4";
                            }
                        }
                    }
                }

            #endregion

            #region Posttest

            bool AllLevel;
            if (getConfigValue("AllLevel") == "0")
                {
                AllLevel = true;
                }
            else
                {
                AllLevel = false;
                }
            bool PosttestAllow;
            IsPostTest = true;
            Int64 countpost = td.BAL_Select_QuestionBankIDCount(bmssctid, IsPostTest);
            if (getConfigValue("Posttest") == "1" && countpost > 0)
                PosttestAllow = true;
            else
                PosttestAllow = false;
            if (PosttestAllow)
                {
                if (AllLevel)
                    {
                    if (AppSessions.StudentID != null && AppSessions.StudentID != 0)
                        {
                        dr = dt.NewRow();
                        dr["Resource"] = "Posttest";
                        dr["ResourcePath"] = "../Student/StudentAssessment.aspx?Level=0&TestType=Posttest";
                        dr["Ext"] = ".Test";
                        dt.Rows.Add(dr);
                        }
                    else
                        {
                        dr = dt.NewRow();
                        dr["Resource"] = "Posttest";
                        dr["ResourcePath"] = "../Teacher/TeacherAssessment.aspx?Level=0&TestType=Posttest";
                        dr["Ext"] = ".Test";
                        dt.Rows.Add(dr);
                        }
                    }
                else
                    {

                    // Code for posttest level 0
                    //dr = dt.NewRow();
                    //dr["Resource"] = "Posttest";
                    //dr["ResourcePath"] = "../Student/StudentAssessment.aspx?Level=0&TestType=Posttest";
                    //dr["Ext"] = ".Test";
                    //dt.Rows.Add(dr);

                    // Code for level wise post test

                    for (int n = 1; n < 4; n++)
                        {
                        if (AppSessions.StudentID != null && AppSessions.StudentID != 0)
                            {
                            dr = dt.NewRow();
                            dr["Resource"] = "Posttest Level-" + n;
                            dr["ResourcePath"] = "../Student/StudentAssessment.aspx?Level=" + n + "&TestType=Posttest";
                            dr["Ext"] = ".Test";
                            dt.Rows.Add(dr);
                            }
                        else
                            {
                            if (n == 1)
                                {
                                dr = dt.NewRow();
                                dr["Resource"] = "Posttest Level-" + n;
                                dr["ResourcePath"] = "../Teacher/TeacherAssessment.aspx?Level=" + n + "&TestType=Posttest";
                                dr["Ext"] = ".Test";
                                dt.Rows.Add(dr);
                                }
                            }
                        }
                    }
                }
            #endregion
            }
        catch (Exception ex)
            {

            }
        return dt;
        }
    private static string getConfigValue(string value)
        {
        string RndoKey = "";
        DataSet dsConfigSettings = new DataSet();

        SYS_TeacherActivityFeedback_BLogic objGetConfigValue = new SYS_TeacherActivityFeedback_BLogic();
        dsConfigSettings = objGetConfigValue.BAL_Select_IsActivityFeedback_Settings(value);

        if (dsConfigSettings.Tables.Count > 0)
            {
            if (dsConfigSettings.Tables[0].Rows.Count > 0)
                {
                RndoKey = dsConfigSettings.Tables[0].Rows[0]["value"].ToString();
                }
            }
        return RndoKey;
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
    public class KeyValueData
        {
        public string Key { get; set; }
        public string Value { get; set; }
        }

    #endregion

    #endregion

    private static string SeprateContent(int bmssctid, bool iscover, string topic = "")
        {
        string ContentFolderPath = string.Empty;

        if (bmssctid > (int)EnumFile.AssignValue.Zero)
            {
            DataTable dt = new DataTable();
            //Session["ChapterTopic"] = ddlChapter.SelectedItem.ToString() + " >> " + ddlTopic.SelectedItem.ToString();
            AppSessions.BMSSCTID = bmssctid;


            if ((AppSessions.IsFreePackage == "free") || (AppSessions.IsFreePackage == "demo"))//free
                {
                if (AppSessions.IsFreePackage == "free")
                    {
                    ContentFolderPath = System.Web.HttpContext.Current.Server.MapPath("../EduResource/Free/" + bmssctid);
                    }
                else
                    ContentFolderPath = System.Web.HttpContext.Current.Server.MapPath("../EduResource/Demo/" + bmssctid + "_Demo");
                // ContentFolderPath = System.Web.HttpContext.Current.Server.MapPath("../EduResource/" + bmssctid + "_Demo");
                //ContentFolderPath = AppDomain.CurrentDomain.BaseDirectory + "EduResource\\" + bmssctid + "_Demo";
                if (Directory.Exists(ContentFolderPath))
                    {
                    dt = new DataTable();
                    dt = FillResourceDemo(bmssctid, ContentFolderPath);
                    if (dt.Rows.Count > 0)
                        return BuildContentHTML(iscover, bmssctid, dt, topic);
                    else
                        // return LoadDisableContentHTML(bmssctid, iscover, ref ContentFolderPath, ref dt);
                        //change 09-07-2020
                        return BuildContentHTMLDisablenew(iscover, bmssctid, topic);
                    }
                else
                    //change 09-07-2020
                    //  return LoadDisableContentHTML(bmssctid, iscover, ref ContentFolderPath, ref dt);
                    return BuildContentHTMLDisablenew(iscover, bmssctid, topic);
                }
            else if (AppSessions.IsFreePackage == "paid")//paid
                {
                ContentFolderPath = System.Web.HttpContext.Current.Server.MapPath("../EduResource/" + bmssctid);
                if (Directory.Exists(ContentFolderPath))
                    {
                    dt = new DataTable();
                    dt = FillResourceDemo(bmssctid, ContentFolderPath);
                    if (dt.Rows.Count > 0)
                        return BuildContentHTML(iscover, bmssctid, dt, topic);
                    else
                        return "<div title='" + bmssctid + "'>No Resource Available</div>";
                    }
                else
                    return "<div title='" + bmssctid + "'>No Resource Available</div>";
                }
            else
                {
                //HttpContext.Current.Response.Redirect("../OtherPages/Landing.aspx", false);
                return "";
                }
            }
        else
            {
            return "<div title='" + bmssctid + "'>OOPS! There is some problem, please <span style=\"color: #71af32;font-weight: bold;cursor:pointer;\" onclick=\"javascript:return RefreshPage();\">refresh</span> page and try again.<div>";
            }
        }

    private static string LoadDisableContentHTML(int bmssctid, bool iscover, ref string ContentFolderPath, ref DataTable dt)
        {
        ContentFolderPath = System.Web.HttpContext.Current.Server.MapPath("../EduResource/" + bmssctid);
        if (Directory.Exists(ContentFolderPath))
            {
            dt = new DataTable();
            dt = FillResource(bmssctid, ContentFolderPath);
            if (dt.Rows.Count > 0)
                return BuildContentHTMLDisable(iscover, bmssctid, dt);
            else
                return "<div title='" + bmssctid + "'>No Resource Available</div>";
            }
        else
            //change 09-07-2020
            return "<div title='" + bmssctid + "'> Resource not available for this package</div>";
        }

    private static bool CheckFolderExists(int bmssctid)
        {
        string ContentFolderPathFree = string.Empty;
        string ContentFolderPathPaid = string.Empty;

        if (bmssctid > (int)EnumFile.AssignValue.Zero)
            {

            if ((AppSessions.IsFreePackage == "free") || (AppSessions.IsFreePackage == "demo"))//free
                {
                if (AppSessions.IsFreePackage == "free")
                    {
                    ContentFolderPathFree = System.Web.HttpContext.Current.Server.MapPath("../EduResource/Free/" + bmssctid);
                    }
                else
                     if (AppSessions.IsFreePackage == "demo")
                    {
                    ContentFolderPathFree = System.Web.HttpContext.Current.Server.MapPath("../EduResource/Demo/" + bmssctid + "_Demo");
                    }
                

              //  ContentFolderPathPaid = System.Web.HttpContext.Current.Server.MapPath("../EduResource/" + bmssctid);

                if (Directory.Exists(ContentFolderPathFree) || Directory.Exists(ContentFolderPathPaid))
                    return true;
                else
                    return false;
                }
            else if (AppSessions.IsFreePackage == "paid")//paid
                {
                ContentFolderPathPaid = System.Web.HttpContext.Current.Server.MapPath("../EduResource/" + bmssctid);
                if (Directory.Exists(ContentFolderPathPaid))
                    return true;
                else
                    return false;
                }
            else
                return false;
            }
        else
            return false;
        }


    [System.Web.Services.WebMethod]
    public static void log_StudentWiseCoveredSyllabus(string resource, int bmssctID)
        {

        int studentID = Convert.ToInt32(HttpContext.Current.Session["StudentID"].ToString());
        //resource = 'Video Presentation';

        StudentWiseCoveredSyllabus obj = new StudentWiseCoveredSyllabus();
        obj.BAL_AppendStudentWiseCoveredDetails(studentID, bmssctID, resource, "", true, new DateTime().ToString());
        }

    [System.Web.Services.WebMethod]
    public static string navigateToChapters(string subject)
        {
        return "Navigate";
        //HttpContext.Current.Response.Redirect("displaypage.aspx");

        //return "Hello " + subject + Environment.NewLine + "The Current Time is: " + DateTime.Now.ToString();
        }

    [System.Web.Services.WebMethod]
    public static string GetCurrentTime(string name)
        {
        return "Hello " + name + Environment.NewLine + "The Current Time is: "
         + DateTime.Now.ToString();
        }


    protected void btnactivity_Click(object sender, EventArgs e)
        {
        try
            {
            Process p = new Process();
            string filename = Server.MapPath("../Barakhdi - App/Barakhdi - App.exe");
            p.StartInfo.FileName = filename;
            p.Start();
            BindSubjectList();
            }
        catch(Exception ex)
            {
            WebMsg.Show(ex.ToString());
            }
        }
    }