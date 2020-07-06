﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Web.SessionState;

public partial class NewPublic_UserLogin : System.Web.UI.Page
{

    SYS_Role obj_SYS_Role;
    SYS_Role_BLogic obj_BAL_SYS_Role;
    StudentDash StudentDash;
    Student_DashBoard_BLogic BLogic_Student;
    Employee OEmployee;
    Teacher_Dashboard_BLogic BAL_Forgetpassword;
    protected override void InitializeCulture()
    {
        HttpCookie cookie = Request.Cookies["CultureInfo"];

        if (cookie != null && cookie.Value != null)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie.Value);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie.Value);
            ViewState["cultreinfo"] = cookie.Value;
        }
        else
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            ViewState["cultreinfo"] = "en-US";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["logout"] != null)
                {
                    HttpContext.Current.Session.Clear();
                }
            }
            catch {
            }
            string culture = ViewState["cultreinfo"].ToString();

            if (culture == "gu-IN")
            {

                button1.InnerText = "પાસવર્ડ ભૂલી ગયા છો";
                ucchkRememberMe.Text = "યાદ";
                Label7.Text = "હોમ";
            }
            if (culture == "hi-IN")
            {
                button1.InnerText = "पासवर्ड भूल गए?";
                ucchkRememberMe.Text = "याद रखना";
                Label7.Text = "होम";
            }
            //if (culture == "gu-IN")
            //{
            //    button1.InnerText = "પાસવર્ડ ભૂલી ગયા છો";
            //    ucchkRememberMe.Text = "યાદ";
            //}

            if (Request.Cookies["UserName"] != null)

                uctxtUserName.Text = Request.Cookies["UserName"].Value;

            if (Request.Cookies["Password"] != null)

                uctxtUserPassword.Attributes.Add("value", Request.Cookies["Password"].Value);
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                ucchkRememberMe.Checked = true;
            
            uctxtUserName.Text = string.Empty;
            uctxtUserPassword.Text = string.Empty;
            ucinvalididpassword.Text = string.Empty;

            if (!string.IsNullOrEmpty(Request.QueryString["frm"]))
            {
                if (Convert.ToString(Request.QueryString["frm"]) == "cp")
                {
                    WebMsg.Show("Change password successfully, please login with new password");
                    return;
                }
            }
        }
    }
    protected void btnfp_Click(object sender, EventArgs e)
    {
        WebMsg.Show("code behind");
    }
    
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {

            if (uctxtUserName.Text == string.Empty || uctxtUserPassword.Text == string.Empty)
            {
                WebMsg.Show("Please enter User ID and Password");
            }
            else
            {
                StoreCookie();
                int status = CheckLogin();
                if (status == 2)
                {
                    uctxtUserName.Text = string.Empty;
                    uctxtUserPassword.Text = string.Empty;
                    ucinvalididpassword.Text = "Invalid User ID or Password";

                    return;
                }
                else if (status == 0)
                {
                    // 0 Indicates Student

                    StudentDash = new StudentDash();
                    BLogic_Student = new Student_DashBoard_BLogic();

                    DataSet dtLogin = new DataSet();
                    DataTable LoginInfo = new DataTable();
                    DataTable UserInfo = new DataTable();

                    obj_SYS_Role = new SYS_Role();
                    obj_BAL_SYS_Role = new SYS_Role_BLogic();
                    obj_SYS_Role.Username = uctxtUserName.Text;
                    obj_SYS_Role.Password = uctxtUserPassword.Text;

                    dtLogin = obj_BAL_SYS_Role.BAL_SYS_Student_Login(obj_SYS_Role);
                    LoginInfo = dtLogin.Tables[0];
                    if (LoginInfo.Rows.Count > 0 && LoginInfo != null)
                    {
                        AppSessions.AppUserType = "Student";

                        AppSessions.StudentID = Convert.ToInt32(LoginInfo.Rows[0]["StudentID"].ToString());
                        AppSessions.UserName = LoginInfo.Rows[0]["FirstName"].ToString();

                        AppSessions.LoginID = LoginInfo.Rows[0]["LoginID"].ToString();

                        AppSessions.BMSID = Convert.ToInt32(LoginInfo.Rows[0]["BMSID"].ToString());
                        AppSessions.BMS = LoginInfo.Rows[0]["BMS"].ToString();

                        AppSessions.BoardID = Convert.ToInt32(LoginInfo.Rows[0]["BoardID"].ToString());
                        AppSessions.Board = LoginInfo.Rows[0]["Board"].ToString();

                        AppSessions.MediumID = Convert.ToInt32(LoginInfo.Rows[0]["MediumID"].ToString());
                        AppSessions.Medium = LoginInfo.Rows[0]["Medium"].ToString();

                        AppSessions.StandardID = Convert.ToInt32(LoginInfo.Rows[0]["StandardID"].ToString());
                        AppSessions.Standard = LoginInfo.Rows[0]["Standard"].ToString();
                        AppSessions.DivisionID = Convert.ToInt32(LoginInfo.Rows[0]["DivisionID"].ToString());
                        AppSessions.SchoolID = Convert.ToInt32(LoginInfo.Rows[0]["SchoolID"].ToString());
                        AppSessions.Role = LoginInfo.Rows[0]["Role"].ToString();
                        AppSessions.RoleID = Convert.ToInt32(LoginInfo.Rows[0]["RoleID"].ToString());
                        AppSessions.IsFreePackage = IsFreePackage();
                        //IsFreePackage();

                        bool AllowMultipleSession = false;
                        AllowMultipleSession = Convert.ToBoolean(LoginInfo.Rows[0]["AllowMultipleSession"].ToString());

                        if (AllowMultipleSession == false)
                        {
                            Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
                            if (sessions == null)
                            {
                                sessions = new Hashtable();
                            }

                            HttpSessionState existingUserSession = (HttpSessionState)sessions[Session["StudentID"].ToString()];
                            if (existingUserSession != null)
                            {
                                Session["StudentID"] = null;
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('You are already Logged In.')</script>", false);
                                return;
                            }
                        }

                        yourLoginMethodStudent(LoginInfo);
                        bool AllowPayment = false;
                        DataSet dsPaymentInfo = new DataSet();
                        dsPaymentInfo = BLogic_Student.BAL_Select_PaymentPagesInfo("Payment");
                        if (dsPaymentInfo != null & dsPaymentInfo.Tables.Count > 0)
                        {
                            if (dsPaymentInfo.Tables[0].Rows.Count > 0)
                            {
                                string a = dsPaymentInfo.Tables[0].Rows[0]["value"].ToString();
                                if (a == "0")
                                {
                                    AllowPayment = false;
                                }
                                else
                                {
                                    AllowPayment = true;
                                }
                            }
                        }

                        DataSet ds = new DataSet();
                        StudentDash.StudentID = AppSessions.StudentID;
                        ds = BLogic_Student.BAL_Validate_Student_Package(StudentDash);
                        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), "LoginId: " + uctxtUserName.Text, 0);

                        if (AllowPayment == true)
                        {
                            if (ds != null && dtLogin.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    Session["CheckValidity"] = "Yes";
                                    ProceedToRedirect();
                                }
                                else
                                {
                                    Response.Redirect("~/DashBoard/SelectPackage.aspx", false);
                                    TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.PackageSelection), "LoginId: " + uctxtUserName.Text, 0);
                                }
                            }
                            else
                            {
                                Response.Redirect("~/DashBoard/SelectPackage.aspx", false);
                                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.PackageSelection), "LoginId: " + uctxtUserName.Text, 0);
                            }
                        }
                        else
                        {
                            Session["CheckValidity"] = "Yes";
                            Session["ShowPaymentPages"] = "No";
                            ProceedToRedirect();
                        }
                    }
                }

                else if (status == 1)
                {
                    // 1 Indicates Teacher
                    DataSet dtLogin = new DataSet();
                    DataTable LoginInfo = new DataTable();
                    DataTable UserInfo = new DataTable();

                    obj_SYS_Role = new SYS_Role();
                    obj_BAL_SYS_Role = new SYS_Role_BLogic();
                    obj_SYS_Role.Username = uctxtUserName.Text;
                    obj_SYS_Role.Password = uctxtUserPassword.Text;
                    dtLogin = obj_BAL_SYS_Role.BAL_SYS_Active_Login(obj_SYS_Role);
                    LoginInfo = dtLogin.Tables[0];

                    if (LoginInfo.Rows.Count > 0 && LoginInfo != null && LoginInfo.Rows[0]["Status"].ToString().Equals("1"))
                    {
                        if (dtLogin.Tables[1].Rows[0]["RoleID"].ToString() != "3")
                        {
                            bool AllowMultipleSession = false;
                            UserInfo = dtLogin.Tables[1];
                            if (UserInfo.Rows.Count > 0 && UserInfo != null)
                            {

                                AppSessions.AppUserType = "School";
                                AppSessions.EmpolyeeID = int.Parse(UserInfo.Rows[0]["EmployeeID"].ToString());
                                AppSessions.RoleID = int.Parse(UserInfo.Rows[0]["RoleID"].ToString());
                                AppSessions.SchoolID = int.Parse(UserInfo.Rows[0]["SchoolID"].ToString());
                                AppSessions.UserName = UserInfo.Rows[0]["FirstName"].ToString();
                                AppSessions.SchoolName = UserInfo.Rows[0]["Name"].ToString();
                                AppSessions.Role = UserInfo.Rows[0]["Role"].ToString();

                                AllowMultipleSession = Convert.ToBoolean(UserInfo.Rows[0]["AllowMultipleSession"].ToString());
                                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LoginPage", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), "LoginId: " + uctxtUserName.Text, 0);
                            }

                            if (AllowMultipleSession == false)
                            {
                                Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
                                if (sessions == null)
                                {
                                    sessions = new Hashtable();
                                }

                                HttpSessionState existingUserSession = (HttpSessionState)sessions[Session["EmpolyeeID"].ToString()];
                                if (existingUserSession != null)
                                {
                                }
                                else
                                {
                                    yourLoginMethod(UserInfo);
                                }
                            }
                            else
                            {
                                yourLoginMethod(UserInfo);
                                RedirectToTeacherDashboard("CookiesNotSet");
                            }
                        }
                        else
                        {
                            // For Teacher Redirection

                            bool AllowMultipleSession = false;
                            UserInfo = dtLogin.Tables[1];
                            if (UserInfo.Rows.Count > 0 && UserInfo != null)
                            {
                                Session["UserInfoTable"] = UserInfo;

                                ViewState["AppUserType"] = "School";
                                ViewState["EmpolyeeID"] = int.Parse(UserInfo.Rows[0]["EmployeeID"].ToString());
                                ViewState["RoleID"] = int.Parse(UserInfo.Rows[0]["RoleID"].ToString());
                                ViewState["SchoolID"] = int.Parse(UserInfo.Rows[0]["SchoolID"].ToString());
                                ViewState["UserName"] = UserInfo.Rows[0]["FirstName"].ToString();
                                ViewState["SchoolName"] = UserInfo.Rows[0]["Name"].ToString();
                                ViewState["Role"] = UserInfo.Rows[0]["Role"].ToString();

                                AllowMultipleSession = Convert.ToBoolean(UserInfo.Rows[0]["AllowMultipleSession"].ToString());
                                TrackLog_Utils.Log(Convert.ToInt32(ViewState["SchoolID"]), Convert.ToInt32(ViewState["EmpolyeeID"]), Convert.ToInt16(AppSessions.DivisionID), "LoginMasterPage.master", "ucbtnGo", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), ViewState["UserName"] + " (" + uctxtUserName.Text + ") From " + ViewState["SchoolName"] + " school Logged in.", 0);
                            }

                            if (AllowMultipleSession == false)
                            {
                                Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
                                if (sessions == null)
                                {
                                    sessions = new Hashtable();
                                }
                                HttpSessionState existingUserSession = (HttpSessionState)sessions[ViewState["EmpolyeeID"].ToString()];
                                if (existingUserSession != null)
                                {
                                    WebMsg.Show("This user is already logged in");
                                }
                                else
                                {
                                    yourLoginMethod(UserInfo);

                                }
                            }
                            else
                            {
                                yourLoginMethod(UserInfo);
                                RedirectToTeacherDashboard("CookiesNotSet");
                            }

                        }
                    }
                    else
                    {
                        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LoginPage", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginFailed), "LoginId: " + uctxtUserName.Text + " , Password: " + uctxtUserPassword.Text, 0);
                        WebMsg.Show("Authentication Failed,unable to login");
                    }
                }

                uctxtUserName.Text = string.Empty;
                uctxtUserPassword.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void btnforgot_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            OEmployee = new Employee();
            BAL_Forgetpassword = new Teacher_Dashboard_BLogic();
            OEmployee.emailid = uctxtEmail.Text;
            ArrayList arrParameter = new ArrayList();
            string subjectEmail = "Login Information";
            arrParameter.Add(uctxtEmail.Text);
            ds = BAL_Forgetpassword.BAL_Emailid_Select(OEmployee);
            ViewState["PasswordData"] = ds;
            string unicode = "0";
            string culture = ViewState["cultreinfo"].ToString();
            //if (ds.Tables.Count > 0 & ds != null)
            //    {
            if (ds.Tables[0].Rows.Count > 0)
            {

                //if (EmailUtility.SendEmail(arrParameter, subjectEmail, GenerateMailBodyForgetPassword()))
                // {
                if (culture == "gu-IN" || culture == "hi-IN")
                {
                    unicode = "1";
                }

                if (EmailUtility.SendSms(uctxtEmail.Text, GenerateSMSbodyForgotPassword(), "1", unicode))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password has been sent to your Mobile successfully.');window.location ='UserLogin.aspx';", true);
                    ClearControls();
                }
                else
                {
                    WebMsg.Show("SMS Failed");
                    ClearControls();
                }
            }
            //else if (ds.Tables[1].Rows.Count > 0)
            //        {
            //        if (EmailUtility.SendEmail(arrParameter, subjectEmail, GenerateEmailBody()))
            //            {
            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password has been sent to your email successfully.');window.location ='UserLogin.aspx';", true);
            //            ClearControls();
            //            }
            //        else
            //            {
            //            WebMsg.Show("Email Failed");
            //            ClearControls();
            //            }
            //        }
            else
            {
                WebMsg.Show("Invalid Login Id");
                ClearControls();
            }
        }
        //    }

        //else
        //    {
        //    WebMsg.Show("Invalid Login");
        //    }
        //   }

        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    private void ProceedToRedirect()
    {
        UserLogtime userlogtime = new UserLogtime();
        UserLogtime_BLogic userblogic = new UserLogtime_BLogic();
        HttpSessionState ss = HttpContext.Current.Session;
        userlogtime.Userid = AppSessions.StudentID;
        Session["studentid"] = AppSessions.StudentID;
        userlogtime.SessionId = ss.SessionID;
        userlogtime.logintime = DateTime.Now;
        userlogtime.isOffline = false;
        int status = userblogic.BAL_logtime_Insert(userlogtime);
        Response.Redirect("~/Dashboard/StudentDashboard.aspx", false);
    }
    void yourLoginMethod(DataTable UserInfo)
    {
        try
        {
            Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
            if (sessions == null)
            {
                sessions = new Hashtable();
            }
            Session["EmpolyeeID"] = UserInfo.Rows[0]["EmployeeID"].ToString();
            sessions[Session["EmpolyeeID"].ToString()] = Session;
            Application.Lock(); //lock to prevent duplicate objects
            Application["WEB_SESSIONS_OBJECT"] = sessions;
            Application.UnLock();
        }
        catch (Exception)
        {
        }
    }

    void yourLoginMethodStudent(DataTable UserInfo)
    {
        try
        {
            Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
            if (sessions == null)
            {
                sessions = new Hashtable();
            }

            Session["StudentID"] = UserInfo.Rows[0]["StudentID"].ToString();

            sessions[Session["StudentID"].ToString()] = Session;
            Application.Lock(); //lock to prevent duplicate objects
            Application["WEB_SESSIONS_OBJECT"] = sessions;
            Application.UnLock();
        }
        catch (Exception)
        {


        }

    }
    protected void StoreCookie()
    {
        try
        {
            if (ucchkRememberMe.Checked == true)
            {
                HttpCookie loginCookie = new HttpCookie("loginCookie");
                loginCookie["UserName"] = uctxtUserName.Text;
                loginCookie["Password"] = uctxtUserPassword.Text;
                loginCookie.Expires.AddDays(7);
                Response.Cookies.Add(loginCookie);
            }
            else
            {
                if (Request.Cookies["loginCookie"] != null)
                {
                    HttpCookie Cookie = Request.Cookies["loginCookie"];
                    Cookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(Cookie);
                }
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    private void RedirectToTeacherDashboard(string cookiesstatus)
    {
        try
        {
            if (Session["UserInfoTable"] != null)
            {
                DataTable dtUsetInfo = new DataTable();
                dtUsetInfo = (DataTable)Session["UserInfoTable"];
                AppSessions.AppUserType = "School";
                AppSessions.EmpolyeeID = int.Parse(dtUsetInfo.Rows[0]["EmployeeID"].ToString());
                AppSessions.RoleID = int.Parse(dtUsetInfo.Rows[0]["RoleID"].ToString());
                AppSessions.SchoolID = int.Parse(dtUsetInfo.Rows[0]["SchoolID"].ToString());
                AppSessions.UserName = dtUsetInfo.Rows[0]["FirstName"].ToString();
                AppSessions.SchoolName = dtUsetInfo.Rows[0]["Name"].ToString();
                AppSessions.Role = dtUsetInfo.Rows[0]["Role"].ToString();
                AppSessions.IsAllowSendEmail = (!dtUsetInfo.Columns.Contains("AllowSendEmail") ? false : Convert.ToBoolean(Convert.ToString(dtUsetInfo.Rows[0]["AllowSendEmail"])));
            }
            if (cookiesstatus == "CookiesSet")
            {
                //AppSessions.BoardID = int.Parse(ddlBoard.SelectedValue);
                //AppSessions.Board = ddlBoard.SelectedItem.Text;
                //AppSessions.SubjectID = int.Parse(ddlSubject.SelectedValue);
                //AppSessions.Subject = ddlSubject.SelectedItem.Text;
                //AppSessions.DivisionID = int.Parse(ddlDivision.SelectedValue);
                //AppSessions.Division = ddlDivision.SelectedItem.Text;

                //HttpCookie myCookie = new HttpCookie(Convert.ToString(AppSessions.EmpolyeeID) + "TeacherDropDown");
                //myCookie["BoardVal"] = ddlBoard.SelectedValue;
                //myCookie["SubjectVal"] = ddlSubject.SelectedValue;
                //myCookie["DivisionVal"] = ddlDivision.SelectedValue;
                //myCookie.Expires = DateTime.Now.AddDays(7);
                //Response.Cookies.Add(myCookie);

                //TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LoginMasterPage.master", "btnOk", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.ActivitySelected), "BMS ID: " + AppSessions.BoardID.ToString() + ", BMS: " + AppSessions.Board + " , DivisionID: " + AppSessions.DivisionID + ", Division : " + AppSessions.Division + " , SubjectID: " + AppSessions.SubjectID + ", Subject : " + AppSessions.Subject + " , Teacher : " + AppSessions.UserName, 0);

                //Response.Redirect("~/Dashboard/TeacherDashboard.aspx");
            }
            else if (cookiesstatus == "CookiesNotSet")
            {
                //Change Date: 07-06-2020..for management login      

                if ((AppSessions.RoleID).ToString() == "18")
                {
                    Response.Redirect("~/Dashboard/MediaDashboard.aspx");
                }
                else if ((AppSessions.RoleID).ToString() == "3")
                {
                    Response.Redirect("~/Dashboard/DashboardTeacher.aspx");
                }
                //Response.Redirect("~/Dashboard/TeacherDashboard.aspx");
              //  Response.Redirect("~/Dashboard/DashboardTeacher.aspx");
            }
        }
        catch (Exception)
        {
        }
    }
    public int CheckLogin()
    {
        obj_SYS_Role = new SYS_Role();
        obj_BAL_SYS_Role = new SYS_Role_BLogic();
        obj_SYS_Role.Username = uctxtUserName.Text;
        obj_SYS_Role.Password = uctxtUserPassword.Text;


        DataSet dtLogin = new DataSet();
        DataTable LoginInfo = new DataTable();

        dtLogin = obj_BAL_SYS_Role.BAL_SYS_Check_Login(obj_SYS_Role);
        LoginInfo = dtLogin.Tables[0];

        int status = Convert.ToInt16(LoginInfo.Rows[0]["Status"].ToString());

        return status;

    }
    protected string IsFreePackage()
    {
        try
        {
            string strresult = string.Empty;
            obj_BAL_SYS_Role = new SYS_Role_BLogic();
            DataSet dtPackageDetails = new DataSet();
            dtPackageDetails = obj_BAL_SYS_Role.BAL_SYS_Select_IsFreePackage(Convert.ToInt32(AppSessions.StudentID));
            double packageprice = Convert.ToDouble(dtPackageDetails.Tables[0].Rows[0]["Price"].ToString());
            if (packageprice > 0)
            {
                strresult = "paid";
            }
            else
            {
                strresult = "free";
            }
            return strresult;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        uctxtUserName.Text = string.Empty;
        uctxtUserPassword.Text = string.Empty;
        ucinvalididpassword.Text = string.Empty;
    }


    //*******Code for forgot password**************

    protected void ClearControls()
    {
        try
        {
            uctxtEmail.Text = string.Empty;
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    protected string GenerateEmailBody()
    {
        DataSet ds = new DataSet();
        string Body = string.Empty;
        ds = (DataSet)ViewState["PasswordData"];
        try
        {
            string Pwd = ds.Tables[0].Rows[0]["Password"].ToString();
            string Name = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds.Tables[0].Rows[0]["LastName"].ToString();
            char[] separator = new char[] { '@' };
            //string[] strSplitArr = uctxtEmail.Text.Split(separator);
            // string username = strSplitArr[0];

            Body = "<b>Hello &nbsp;" + Name + ",<b/><br/><br/>";

            Body += "<b>Date:<b/>" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "<br/";
            //Body += "<b>Email:<b/>" + uctxtEmail.Text + "<br/>";
            Body += "<b>Password:<b/>" + Pwd + "<br/><br/><br/>";

            Body += "<b>Thank You,<b/><br/>";
            Body += "<b>" + EmailUtility.USERNAME + "<b/>";
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return Body;
    }
    protected string GenerateSMSbodyForgotPassword()
        {
        string culture = ViewState["cultreinfo"].ToString();
        string smsmessage;
        DataSet ds = new DataSet();
        string Body = string.Empty;
        ds = (DataSet)ViewState["PasswordData"];
        string Pwd = ds.Tables[0].Rows[0]["Password"].ToString();
        string Name = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds.Tables[0].Rows[0]["LastName"].ToString();
        string loginid = uctxtEmail.Text;
        if (culture == "gu-IN")
            {
            smsmessage = "પ્રિય" +" "+ Name+"\n";
            smsmessage = "તમારું  લગિન આઈડી: " + loginid + "\n";
            smsmessage = smsmessage + "પાસવર્ડ: " + Pwd + "\n";
            smsmessage = smsmessage + "સ્વયમ લર્નિંગ - સપોર્ટ ટીમ.";
            }
        else
            {
            smsmessage = "Dear" + Name + "\n";
            smsmessage = "your Loginid: " + loginid + "\n";
            smsmessage = smsmessage + "Password: " + Pwd + "\n";
            smsmessage = smsmessage + "Swayam Learning - Support team";
            }
        return smsmessage;
            }

    protected string GenerateMailBodyForgetPassword()
    {
        string culture = ViewState["cultreinfo"].ToString();
        string filename;
        if (culture == "gu-IN")
        {
             filename = AppDomain.CurrentDomain.BaseDirectory + "\\Mail Template\\ForgotpasswordinGujarati.txt";
        }
        else
             filename = AppDomain.CurrentDomain.BaseDirectory + "\\Mail Template\\ForgetPassword.txt";
        string MailFormat = System.IO.File.ReadAllText(filename);
        DataSet ds = new DataSet();
        string Body = string.Empty;
        ds = (DataSet)ViewState["PasswordData"];
        try
        {
            string Pwd = ds.Tables[0].Rows[0]["Password"].ToString();
            string Name = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds.Tables[0].Rows[0]["LastName"].ToString();
            Body = MailFormat;
            Body = Body.Replace("#username", Name);
            Body = Body.Replace("#loginid", uctxtEmail.Text);
            Body = Body.Replace("#password", Pwd);
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }

        return Body;
    }
}
