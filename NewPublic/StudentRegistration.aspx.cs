using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewPublic_StudentRegistration : System.Web.UI.Page
{
    SYS_Role obj_SYS_Role;
    SYS_Role_BLogic obj_BAL_SYS_Role;
    StudentDash StudentDash;
    Student_DashBoard_BLogic BLogic_Student;
    Employee OEmployee;
    Teacher_Dashboard_BLogic BAL_Forgetpassword;
    SYS_BMS_BLogic BSysBMS = new SYS_BMS_BLogic();
    string strpassword = string.Empty;
    Student_BLogic BAL_Student;
    Student Student;
    SYS_Subject_BLogic Blogic_Subject = new SYS_Subject_BLogic();
    Employee_BLogic Blogic_Employee = new Employee_BLogic();
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
            strpassword = System.Web.Security.Membership.GeneratePassword(6, 0);

            Random rnd = new Random();
            strpassword = Regex.Replace(strpassword, @"[^a-zA-Z0-9]", m => "" + rnd.Next(1, 9) + "");

            ViewState["strpassword"] = strpassword;
            //GetBMS();
            Get_Boards();
            AppSessions.RoleID = 0;
            Session["LoginURl"] = Request.Url.AbsoluteUri;
            string culture = ViewState["cultreinfo"].ToString();
            if(culture=="gu-IN")
            {

                //lblname.Visible = true;
                //lblname.Text = "નામ";
                //lbllastname.Visible = true;
                //lbllastname.Text = "અટક";
                //lblschoolname.Visible = true;
                //lblschoolname.Text = "સ્કૂલ નામ";
                //lblemail.Visible = true;
                //lblemail.Text = "ઇમેઇલ";
                //lblmob.Visible = true;
                //lblmob.Text = "મોબાઇલ";
                string contact = "મોબાઇલ".ToString();  
                string fname =  "નામ".ToString();
                string lname =  "અટક".ToString();
                string sname = "સ્કૂલ નામ".ToString();
               string email =  "ઇમેઇલ".ToString();
               string username = "વપરાશકર્તા નામ".ToString();
               string signup = "સાઇન અપ".ToString();
                txtContactNo.Attributes.Add("Placeholder", contact);
                txtFirstName.Attributes.Add("Placeholder", fname);
                txtLastName.Attributes.Add("Placeholder", lname);
                txtSchoolname.Attributes.Add("Placeholder",sname);
                txtEmail.Attributes.Add("Placeholder", email);
                txtusername.Attributes.Add("Placeholder", username);
                btnsubmit.Text = signup.ToString();
                Label1.Text = "કૃપા કરીને તમારી વિગતો ભરો";
                Label3.Text = "હોમ પેજ";
            }
            if (culture == "hi-IN")
                {
                //lblname.Visible = true;
                //lblname.Text = "નામ";
                //lbllastname.Visible = true;
                //lbllastname.Text = "અટક";
                //lblschoolname.Visible = true;
                //lblschoolname.Text = "સ્કૂલ નામ";
                //lblemail.Visible = true;
                //lblemail.Text = "ઇમેઇલ";
                //lblmob.Visible = true;
                //lblmob.Text = "મોબાઇલ";
                string contact = "मोबाइल".ToString();
                string fname = "नाम".ToString();
                string lname = "उपनाम".ToString();
                string sname = "विद्यालय का नाम".ToString();
                string email = "ईमेल".ToString();
                string username = "उपयोगकर्ता नाम".ToString();
               string signup = "साइन अप".ToString(); 
                txtContactNo.Attributes.Add("Placeholder", contact);
                txtFirstName.Attributes.Add("Placeholder", fname);
                txtLastName.Attributes.Add("Placeholder", lname);
                txtSchoolname.Attributes.Add("Placeholder", sname);
                txtEmail.Attributes.Add("Placeholder", email);
                txtusername.Attributes.Add("Placeholder", username);
                btnsubmit.Text = signup.ToString();
                Label1.Text = "कृपया अपना विवरण भरें";
                Label3.Text = "मुख पृष्ठ";
                }
            ViewState["txtotp"] = TxtOTP.Text;
            }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int t1 = 0;

        //if (TxtBxCap.Text.Trim() != "")
        //{
        //Captcha1.ValidateCaptcha(TxtBxCap.Text.Trim());
        try
        {
            //if (verifyLoginID())
            //    {
                //if (!CheckPasswordComplexcity())
                //{
                //    WebMsg.Show("Invalid password format, please enter minimum 6 alphanumeric character with @ # $ %. Sign.");
                //    return;
                //}
                /*if (txtPassword.Text.Length < 6)
                {
                    WebMsg.Show("Minimum 6 character required in password");
                    return;
                }*/
                //if (rblrole.Text == "Student")
                //    {
                //verification of OTP

                string otp = Session["OTP"].ToString();
                string txtotp = Session["OTP"].ToString();
                if (otp == txtotp)
                    { 
                Student = new Student();
                BAL_Student = new Student_BLogic();
                Student.schoolid = GetDefaultSchoolID();
                Student.divisionid = 1;
                Student.bmsid = (int)ViewState["BMSID"];
                //ViewState["BMSID"] = int.Parse(ddlBMS.SelectedValue);
                Student.loginid = txtusername.Text;
                    Student.emailid = txtEmail.Text;
                //Student.password = txtPassword.Text;
                Student.password = ViewState["strpassword"].ToString();
                Student.firstname = txtFirstName.Text;
                Student.lastname = txtLastName.Text;
                Student.schoolname = txtSchoolname.Text;
                //Student.contactno = Convert.ToInt64(txtContactNo.Text);
                Student.mobilenostring = txtContactNo.Text;
                Student.emailid = txtEmail.Text;

                Student.PaymentType = 'I';
                t1 = BAL_Student.BAL_Student_Insert_Online(Student, "OnlineReg");
                InsertIntoStudentPackageDetails(t1);
                if (t1 > 0)
                    {
                    // string msg = "Registration successful. Login details sent to the Registered Email Id";
                    // WebMsg.Show("Registration successful. Login details sent to the Registered Email Id");
                    // ScriptManager.RegisterStartupScript(this, GetType(), msg, "alertMessage();", true);
                    dvsuccessmessage.Visible = true;
                    //    Response.Redirect("UserLogin.aspx", false);
                    //RedirectToDashboard();
                    }
                ClearRegisterControls();
                }
              else
                {
                    TxtOTP.Visible = false;
                    Btnresendotp.Visible = true;
                WebMsg.Show("OTP MISMATCH..");
                }
                    //} 
                //if (rblrole.Text == "Teacher")
                //    {
                //    Employee teacher = new Employee();
                //    teacher.firstname = txtFirstName.Text;
                //    teacher.lastname = txtLastName.Text;
                //    teacher.roleid = 16;
                //    teacher.loginid = txtEmail.Text;
                //    teacher.code = txtFirstName.Text + txtLastName.Text + "12345";
                //    //Student.password = txtPassword.Text;
                //    teacher.password = ViewState["strpassword"].ToString();
                     
                //    //Student.contactno = Convert.ToInt64(txtContactNo.Text);
                //    teacher.contactno = Convert.ToInt32(txtContactNo.Text);
                //    teacher.emailid = txtEmail.Text;
                //    Int32 t2 = Blogic_Employee.Bal_online_employee_insert(teacher);
                //     //Int32 t2=Blogic_Employee.BAL_Employee_Insert(teacher, "OnlineReg");
                //    if (t2 >0)
                //        {
                //        dvsuccessmessage.Visible = true;
                //        ClearRegisterControls();
                //        }
                //    }
            //}
            //else
            //{
            //    WebMsg.Show("LoginID already exist..");
            //}
        }
        catch (FormatException fe)
        {
            //WebMsg.Show("Invalid birthdate");
            //txtBirthdate.Focus();
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        finally
        { }

        //}
        //else
        //{
        //    WebMsg.Show("Please enter code");

        //}

    }

    protected void ClearRegisterControls()
    {
        try
        {
            txtEmail.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtSchoolname.Text = string.Empty;
            //rblrole.SelectedIndex = 0;
            ddlBoard.SelectedIndex = 0;
            ddlMedium.SelectedIndex = 0;
            ddlStandard.SelectedIndex = 0;
            ddlMedium.DataSource = null; ddlMedium.DataBind(); ddlMedium.Enabled = false;
            ddlStandard.DataSource = null; ddlStandard.DataBind(); ddlStandard.Enabled = false;
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void RedirectToDashboard()
    {
        try
        {
            // 0 Indicates Student

            StudentDash = new StudentDash();
            BLogic_Student = new Student_DashBoard_BLogic();

            DataSet dtLogin = new DataSet();
            DataTable LoginInfo = new DataTable();
            DataTable UserInfo = new DataTable();

            obj_SYS_Role = new SYS_Role();
            obj_BAL_SYS_Role = new SYS_Role_BLogic();
            obj_SYS_Role.Username = txtEmail.Text;
            obj_SYS_Role.Password = ViewState["strpassword"].ToString();

            //obj_SYS_Role.roleid = Convert.ToInt16(DdlRole.SelectedValue);
            //if (uctxtEmail.Text != "" && uctxtpass.Text != "")
            //{

            dtLogin = obj_BAL_SYS_Role.BAL_SYS_Student_Login(obj_SYS_Role);
            LoginInfo = dtLogin.Tables[0];
            //}
            if (LoginInfo.Rows.Count > 0 && LoginInfo != null)
            {
                AppSessions.AppUserType = "Student";

                AppSessions.StudentID = Convert.ToInt32(LoginInfo.Rows[0]["StudentID"].ToString());
                AppSessions.UserName = LoginInfo.Rows[0]["FirstName"].ToString();

                AppSessions.BMSID = Convert.ToInt32(LoginInfo.Rows[0]["BMSID"].ToString());
                AppSessions.BMS = LoginInfo.Rows[0]["BMS"].ToString();

                AppSessions.BoardID = Convert.ToInt32(LoginInfo.Rows[0]["BoardID"].ToString());
                AppSessions.Board = LoginInfo.Rows[0]["Board"].ToString();

                AppSessions.MediumID = Convert.ToInt32(LoginInfo.Rows[0]["MediumID"].ToString());
                AppSessions.Medium = LoginInfo.Rows[0]["Medium"].ToString();

                AppSessions.StandardID = Convert.ToInt32(LoginInfo.Rows[0]["StandardID"].ToString());
                AppSessions.Standard = LoginInfo.Rows[0]["Standard"].ToString();

                AppSessions.DivisionID = Convert.ToInt32(LoginInfo.Rows[0]["DivisionID"].ToString());
                //AppSessions.Division = LoginInfo.Rows[0]["Division"].ToString();

                AppSessions.SchoolID = Convert.ToInt32(LoginInfo.Rows[0]["SchoolID"].ToString());
                //AppSessions.SchoolName = LoginInfo.Rows[0]["SchoolName"].ToString();

                AppSessions.Role = LoginInfo.Rows[0]["Role"].ToString();
                AppSessions.RoleID = Convert.ToInt32(LoginInfo.Rows[0]["RoleID"].ToString());

                AppSessions.IsFreePackage = IsFreePackage();


                //AppSessions.EmailID = Convert.ToString(LoginInfo.Rows[0]["EmailID"]);

                //yourLoginMethodStudent(LoginInfo);
                bool AllowMultipleSession = false;
                AllowMultipleSession = Convert.ToBoolean(LoginInfo.Rows[0]["AllowMultipleSession"].ToString());


                //Hashtable sessions1 = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
                //HttpSessionState existingUserSession1 = (HttpSessionState)sessions1[Session["StudentID"].ToString()];
                //if (existingUserSession1 != null)
                //{
                //    Response.Redirect("../Dashboard/StudentDashboard.aspx");
                //}

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
                        ////existingUserSession[Session["EmpolyeeID"].ToString()] = null;
                        //logout current logged in user
                        WebMsg.Show("you are already logged in.");
                        return;
                    }
                }

                ////////getting the pointer to the Session of the current logged in user
                yourLoginMethodStudent(LoginInfo);
                //ProceedToRedirectPage(LoginInfo);

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
                //ds = BLogic_Student.BAL_Validate_Student(StudentDash);
                ds = BLogic_Student.BAL_Validate_Student_Package(StudentDash);
                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), "LoginId: " + txtEmail.Text, 0);


                if (AllowPayment == true)
                {
                    //Session["ShowPaymentPages"] = "yes";
                    if (ds != null && dtLogin.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Session["CheckValidity"] = "Yes";
                            ProceedToRedirect();
                        }
                        else
                        {

                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('We have sent your Login details on your registered Email Address, kindly check your Email to get your Password.  ');window.open('../DashBoard/StudentDashboard.aspx','_self');", true);

                            //Response.Redirect("~/DashBoard/StudentDashboard.aspx", false);
                            //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Congratulation! You got free trial for 30 days. \\n We have sent your Login details on your registered Email Address.  ');window.open('../DashBoard/StudentDashboard.aspx','_self');", true);
                            TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.PackageSelection), "LoginId: " + txtEmail.Text, 0);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('We have sent your Login details on your registered Email Address, kindly check your Email to get your Password.  ');window.open('../DashBoard/StudentDashboard.aspx','_self');", true);
                        //Response.Redirect("~/DashBoard/StudentDashboard.aspx", false);
                        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.PackageSelection), "LoginId: " + txtEmail.Text, 0);

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
        catch (Exception)
        {


        }
    }

    public void InsertIntoStudentPackageDetails(int studentid)
    {
        try
        {
            //Student = new Student();
            //if (rblrole.Text == "Student")
            //    {
                BAL_Student = new Student_BLogic();
                Package_BLogic Blogic_Package = new Package_BLogic();
                //Student.bmsid = Convert.ToInt32(ViewState["BMSID"]);
                int BMSID = Convert.ToInt32(ViewState["BMSID"]);
                DataSet dsPackageID = BAL_Student.BAL_Student_SelectPackageID(BMSID);

                if (dsPackageID != null && dsPackageID.Tables.Count > 0)
                    {
                    if (dsPackageID.Tables[0].Rows.Count > 0)
                        {

                        Session["dsTrailPAckage"] = dsPackageID.Tables[0];
                        Package Opackage = new Package();

                        Opackage.StudentID = studentid;
                        Opackage.PackageFD_ID = Convert.ToInt64(dsPackageID.Tables[0].Rows[0]["PackageID"].ToString());
                        Opackage.Price = 500;
                        int result = Blogic_Package.BAL_Student_TrialPackage_Insert(Opackage);
                        if (result > 0)
                            {
                         string culture = ViewState["cultreinfo"].ToString();
                        if (culture == "gu-IN")
                        {
                            
                            if (!string.IsNullOrEmpty(txtEmail.Text))
                                {
                                string MailContent = DefaultEmailBodygujarati("yes");
                                string strResponce = SendMail(txtEmail.Text, "નવી નોંધણી વિગતો", MailContent);
                                }
                            string smscontent = DefaultSMSbodyGujarati("Yes");
                            bool strresponse = EmailUtility.SendSms(txtContactNo.Text, smscontent,"1","1");

                        }
                        else
                            if (culture == "hi-IN")
                            {

                            if (!string.IsNullOrEmpty(txtEmail.Text))
                                {
                                string MailContent = DefaultEmailBodyHindi("yes");
                                string strResponce = SendMail(txtEmail.Text, "नया पंजीकरण विवरण", MailContent);
                                }
                            string smscontent = DefaultSMSbodyHindi("Yes");
                            bool strresponse = EmailUtility.SendSms(txtContactNo.Text, smscontent, "1", "1");

                            }
                        else
                        {
                            if (!string.IsNullOrEmpty(txtEmail.Text))
                                {
                                string MailContent = DefaultEmailBody("yes");
                                string strResponce = SendMail(txtEmail.Text, "New Registration Details", MailContent);
                                }
                            string smscontent = DefaultSMSbody("Yes");
                            bool strresponse = EmailUtility.SendSms(txtContactNo.Text, smscontent, "1","0");
                            }
                            //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Your message.');window.open('AnotherPage.aspx','_self');", true);
                            //WebMsg.Show("Congratulation! You got free trial for 30 days");
                            }
                        }
                    else
                        {
                        string MailContent = DefaultEmailBody();
                        string strResponce = SendMail(txtEmail.Text, "New Registration Details", MailContent);
                        }
                    }
                //}
           
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string DefaultSMSbody(string ISFreeTrial=null)
        {
        string msg;
        msg = "Dear  " + txtFirstName.Text + "\n"+ "Thank you for registering with SwayamLearning"+ "\n";
        msg = msg + "visit:http://swayamlearning.org with \n Loginid:" + txtusername.Text + "\n"+"Password:" + ViewState["strpassword"].ToString();
        msg = msg + "\n" + "Swayam Learning - Support Team";
        return msg;
        }
    public string DefaultSMSbodyGujarati(string ISFreeTrial = null)
        {
        string msg;
        msg = "પ્રિય  " + txtFirstName.Text + "\n"+"સ્વયલેરિંગ સાથે નોંધણી કરવા બદલ આભાર";
        msg = msg + "\n"+ "વેબસાઇટ http://swayamlearning.org \nલૉગિન આઈડી:" + txtusername.Text +"\n"+ "પાસવર્ડ:" + ViewState["strpassword"].ToString();
        msg = msg + "\n"+ "સ્વયમ લર્નિંગ - સપોર્ટ ટીમ";
        return msg;
        }
    public string DefaultSMSbodyHindi(string ISFreeTrial = null)
        {
        string msg;
        msg = "પ્રિય  " + txtFirstName.Text + "\n" + "स्वयं लर्निंग के साथ पंजीकरण करने के लिए धन्यवाद";
        msg = msg + "\n" + "वेबसाइट http://swayamlearning.org \nलॉगिन आईडी" + txtusername.Text + "\n" + "पासवर्ड:" + ViewState["strpassword"].ToString();
        msg = msg + "\n" + "स्वयं लर्निंग - सपोर्ट टीम ";
        return msg;
        }
    protected string DefaultEmailBody(string ISFreeTrial = null)
    {
        StringBuilder oBuilder = new StringBuilder();
        try
        {
            oBuilder.Append("<!DOCTYPE html><html><head>");
            oBuilder.Append("<style type=text/css> th {color: #685858;} table tr:nth-child(odd) { background-color: #DBDBDB; border-bottom: 1px SOLID GRAY; }  p { text-align:justify; line-height:1.4em; }  </style> ");
            oBuilder.Append("</head><body>");

            //oBuilder.Append("<div style='font-family: Calibri,Cambria,verdana; color: #4C3636;'>");
            oBuilder.Append("<div style='font-family:Trebuchet MS,Georgia,Verdana,Tahoma;color:#4C3636;'>");
            oBuilder.Append("<table width=72% style='margin: 10px; border: 5px SOLID SILVER; border-radius: 5px;' border=0>");
            oBuilder.Append("<tr><td><div style='background-color: #2f378e; height: 30px; font-size: 21px; font-weight: bold;padding: 10px;'><span style='color: white; display: block;'>SwayamLearning</span></div></td></tr>");
            oBuilder.Append("<tr><td style='font-size: 16px;'>");
            oBuilder.Append("<div id=dvcontent style='font-size: 14px; padding: 20px; background-color: #F4F4F4;'>");
            oBuilder.Append("Dear " + txtFirstName.Text + ",  <p> Thank you for registering with SwayamLearning. We welcome you to the world of experiential learning to make your learning process efficient and effective.</p> ");

            //oBuilder.Append("Dear " + txtFirstName.Text + "<br /><br />Thank you for registering with E-Pathshala. We welcome you to the world of experiential learning so as to make learning interesting for you.<br /><br />We have different packages for " + ddlBMS.SelectedItem.Text + " as below:<br /><br /><center> ");
            //oBuilder.Append("<table border=0 cellpadding=5 cellspacing=0 width=80% style='border: 1px SOLID #9B9B9B;'>");
            //oBuilder.Append("<tr style='background-color: #CECECE;'><th>BMS</th><th>Subject</th><th>Price</th></tr>");
            //// Dynamice for available packages
            //oBuilder.Append("<tr><td>Gujarat Board>> Gujarati Medium >> Standar-08</td><td>English</td><td style='text-align: right;'>200</td></tr>");
            //oBuilder.Append("<tr><td style='width: 60%;'>Gujarat Board>> Gujarati Medium >> Standar-08</td><td style='width: 30%;'>English</td><td style='width: 10%; text-align: right;'>200</td></tr>");
            //oBuilder.Append("</table></center><br />");

            if (ISFreeTrial != null && ISFreeTrial.ToString().ToLower() == "yes")
            {
                DataTable dtTrialPackage = (DataTable)Session["dsTrailPAckage"];
                //string strBMS = ddlBMS.SelectedItem.Text.Replace(">>", ">");
                //string[] BMS = strBMS.Split('>');
                string Board = ddlBoard.SelectedItem.ToString();
                string Medium = ddlMedium.SelectedItem.ToString(); ;
                string Standard = ddlStandard.SelectedItem.ToString();

                //oBuilder.Append(" <p> We are pleased to provide you access to ePathshala package for " + dtTrialPackage.Rows[0]["NoOfMonth"].ToString() + " days for " + Board + " Board " + Medium + " Medium " + Standard + ". ");
                oBuilder.Append(" <p> We are pleased to provide you access to Swayam Learning package for " + dtTrialPackage.Rows[0]["NoOfMonth"].ToString() + " day(s) as an introductory promotional offer for selected standard.");
                oBuilder.Append("<br />Discover how SwayamLearning helps you like a teacher/friend. </p>");
                oBuilder.Append("<div><center>");
                oBuilder.Append("<table border=0 cellpadding=5 cellspacing=0 style='border-collapse: collapse; border: 1px SOLID #9B9B9B; width=80%'>");
                oBuilder.Append("<tr style='background-color: #CECECE;'><th>Package Name</th><th>Subject</th><th>Start From</th><th>Valid Till</th> </tr>");

                for (int i = 0; i < dtTrialPackage.Rows.Count; i++)
                {
                    oBuilder.Append("<tr><td>" + dtTrialPackage.Rows[i]["PackageName"].ToString() + "</td><td>" + dtTrialPackage.Rows[i]["Subject"].ToString() + "</td><td style='text-align: center;'>" + DateTime.Now.ToString("dd MMM, yyyy") + "</td><td style='text-align: center;'>" + DateTime.Now.AddDays(Convert.ToInt32(dtTrialPackage.Rows[0]["NoOfMonth"].ToString())).ToString("dd MMM, yyyy") + "</td></tr>");
                }
                oBuilder.Append("</table> </center></div><br />");
            }

            //oBuilder.Append("<div><p> We wish you happy learning and also wish to strengthen your knowledge, increase your confidence and achieve better performance.<br />We look forward to a wonderful learning experience with us and relationship with us.  </p> <b>Your Login details are as below:  </b></div><br/>");
            oBuilder.Append("<div><p>We look forward to a wonderful learning experience and relationship with us.  </p> <b>Your Login details are as below:  </b></div><br/>");

            oBuilder.Append("<div><table border=0 cellpadding=5 cellspacing=3 style='border-collapse: collapse;border: 1px SOLID #9B9B9B; margin-left: 90px; width=40%'>");
            oBuilder.Append("<tr><td>Visit:</td><td>http://swayamlearning.org/</td></tr>");
            oBuilder.Append("<tr><td class=style2>Login ID:</td><td class=style1><b>" + txtusername.Text + "</b></td></tr>");
            oBuilder.Append("<tr><td class=style2>Password:</td><td class=style1><b>" + ViewState["strpassword"].ToString() + "</b></td></tr>");
            oBuilder.Append("<tr><td class=style2 colspan=2>Please do reach us on support@swayamlearning.org for your queries or suggestion.</td></tr>");
            oBuilder.Append("</table></div><br />");
            oBuilder.Append("<div>Thank You,<br />Swayam Learning - Support Team.</div></div>");
            oBuilder.Append("</td></tr>");
            oBuilder.Append("<tr><td><div style='background-color: #E4722B; height: 24px; font-size: 18px; font-weight: bold;padding: 5px;'>");
            oBuilder.Append("<div><table border=0 cellpadding=0 cellspacing=0 style='background:none;color:Black;'>");
            //oBuilder.Append("<tr  style='background:none;color:Black;'><td><span style='color: white; display: block;'>FOLLOW US!</span></td>");
            //oBuilder.Append("<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>");
            //oBuilder.Append("<td>&nbsp;<a href=https://www.facebook.com/myepathshala><img src=https://cdn3.iconfinder.com/data/icons/peelicons-vol-1/50/Facebook-48.png height=36 /></a></td>");
            //oBuilder.Append("<td>&nbsp;<a href=https://twitter.com/EpathshalaEpath><img src=https://cdn3.iconfinder.com/data/icons/peelicons-vol-1/50/Twitter-48.png height=36 /></a></td>");

            oBuilder.Append("</tr></table></div></div></td></tr>");

            //oBuilder.Append("<span style='color: white; display: block;'>FOLLOW US!</span> <a href=https://www.facebook.com/myepathshala> <img alt=Epathshala width=26px height=23px src=App_Themes/Images/FBIcon.png /> <a>  <a href=https://twitter.com/EpathshalaEpath> <img alt=Epathshala width=26px height=23px src=App_Themes/Images/twitter.png /> <a> </div> </td> </tr>");
            oBuilder.Append("<tr> <td style='padding: 20px;'> Please do not reply this message. Queries? Contact. Customer Support. <br /> opp. St. Xavier's College, Mithakhali, Navrangpura, Ahmedabad, Gujarat 380009. </td></tr>");
            oBuilder.Append(" </table></div>");



            //oBuilder.Append("<p>Thank you for registration in Epathshala <br /><br />");
            //oBuilder.Append("Best Regards,<br />Admin.</p>");
            //oBuilder.Append("</div></div>");
            //oBuilder.Append("</body></html>");

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return oBuilder.ToString();
    }
    protected string DefaultEmailBodygujarati(string ISFreeTrial = null)
    {
        StringBuilder oBuilder = new StringBuilder();
        try
        {
            oBuilder.Append("<!DOCTYPE html><html><head>");
            oBuilder.Append("<style type=text/css> th {color: #685858;} table tr:nth-child(odd) { background-color: #DBDBDB; border-bottom: 1px SOLID GRAY; }  p { text-align:justify; line-height:1.4em; }  </style> ");
            oBuilder.Append("</head><body>");

            //oBuilder.Append("<div style='font-family: Calibri,Cambria,verdana; color: #4C3636;'>");
            oBuilder.Append("<div style='font-family:Shruti;color:#4C3636;'>");
            oBuilder.Append("<table width=72% style='margin: 10px; border: 5px SOLID SILVER; border-radius: 5px;' border=0>");
            oBuilder.Append("<tr><td><div style='background-color: #2f378e; height: 30px; font-size: 21px; font-weight: bold;padding: 10px;'><span style='color: white; display: block;'>SwayamLearning</span></div></td></tr>");
            oBuilder.Append("<tr><td style='font-size: 16px;'>");
            oBuilder.Append("<div id=dvcontent style='font-size: 14px; padding: 20px; background-color: #F4F4F4;'>");
            oBuilder.Append("પ્રિય " + txtFirstName.Text + ",  <p> સ્વયલેરિંગ સાથે નોંધણી કરવા બદલ આભાર.</p> ");

            //oBuilder.Append("Dear " + txtFirstName.Text + "<br /><br />Thank you for registering with E-Pathshala. We welcome you to the world of experiential learning so as to make learning interesting for you.<br /><br />We have different packages for " + ddlBMS.SelectedItem.Text + " as below:<br /><br /><center> ");
            //oBuilder.Append("<table border=0 cellpadding=5 cellspacing=0 width=80% style='border: 1px SOLID #9B9B9B;'>");
            //oBuilder.Append("<tr style='background-color: #CECECE;'><th>BMS</th><th>Subject</th><th>Price</th></tr>");
            //// Dynamice for available packages
            //oBuilder.Append("<tr><td>Gujarat Board>> Gujarati Medium >> Standar-08</td><td>English</td><td style='text-align: right;'>200</td></tr>");
            //oBuilder.Append("<tr><td style='width: 60%;'>Gujarat Board>> Gujarati Medium >> Standar-08</td><td style='width: 30%;'>English</td><td style='width: 10%; text-align: right;'>200</td></tr>");
            //oBuilder.Append("</table></center><br />");

            if (ISFreeTrial != null && ISFreeTrial.ToString().ToLower() == "yes")
            {
                DataTable dtTrialPackage = (DataTable)Session["dsTrailPAckage"];
                //string strBMS = ddlBMS.SelectedItem.Text.Replace(">>", ">");
                //string[] BMS = strBMS.Split('>');
                string Board = ddlBoard.SelectedItem.ToString();
                string Medium = ddlMedium.SelectedItem.ToString(); ;
                string Standard = ddlStandard.SelectedItem.ToString();

                //oBuilder.Append(" <p> We are pleased to provide you access to ePathshala package for " + dtTrialPackage.Rows[0]["NoOfMonth"].ToString() + " days for " + Board + " Board " + Medium + " Medium " + Standard + ". ");
                oBuilder.Append(" <p> સ્વયમ શીખવાનું પેકેજ " + dtTrialPackage.Rows[0]["NoOfMonth"].ToString() + " સ્વયમ શીખવાનું પેકેજ 60 દિવસ માટે મફત છે</p>");
                //oBuilder.Append("<br />Discover how SwayamLearning helps you like a teacher/friend. </p>");
                oBuilder.Append("<div><center>");
                oBuilder.Append("<table border=0 cellpadding=5 cellspacing=0 style='border-collapse: collapse; border: 1px SOLID #9B9B9B; width=80%'>");
                oBuilder.Append("<tr style='background-color: #CECECE;'><th>પેકેજ નામ</th><th>વિષય</th><th>પ્રારંભ તારીખ</th><th>અંતિમ તારીખ</th> </tr>");

                for (int i = 0; i < dtTrialPackage.Rows.Count; i++)
                {
                    oBuilder.Append("<tr><td>" + dtTrialPackage.Rows[i]["PackageName"].ToString() + "</td><td>" + dtTrialPackage.Rows[i]["Subject"].ToString() + "</td><td style='text-align: center;'>" + DateTime.Now.ToString("dd MMM, yyyy") + "</td><td style='text-align: center;'>" + DateTime.Now.AddDays(Convert.ToInt32(dtTrialPackage.Rows[0]["NoOfMonth"].ToString())).ToString("dd MMM, yyyy") + "</td></tr>");
                }
                oBuilder.Append("</table> </center></div><br />");
            }

            //oBuilder.Append("<div><p> We wish you happy learning and also wish to strengthen your knowledge, increase your confidence and achieve better performance.<br />We look forward to a wonderful learning experience with us and relationship with us.  </p> <b>Your Login details are as below:  </b></div><br/>");
            oBuilder.Append("<div><p>અમે એક અદ્ભુત ભણતર અનુભવ અને અમારી સાથેના સંબંધની રાહ જોતા હોઈએ છીએ.  </p> <b>લોગીન વિગતો  </b></div><br/>");

            oBuilder.Append("<div><table border=0 cellpadding=5 cellspacing=3 style='border-collapse: collapse;border: 1px SOLID #9B9B9B; margin-left: 90px; width=40%'>");
            oBuilder.Append("<tr><td>વેબસાઇટ:</td><td>http://swayamlearning.org/</td></tr>");
            oBuilder.Append("<tr><td class=style2>લૉગિન આઈડી:</td><td class=style1><b>" + txtusername.Text + "</b></td></tr>");
            oBuilder.Append("<tr><td class=style2>પાસવર્ડ:</td><td class=style1><b>" + ViewState["strpassword"].ToString() + "</b></td></tr>");
            oBuilder.Append("<tr><td class=style2 colspan=2પ્રશ્નો અને સપોર્ટ માટે support@swayamlearning.org પર અમારો સંપર્ક કરો.</td></tr>");
            oBuilder.Append("</table></div><br />");
            oBuilder.Append("<div>આભાર,<br />સ્વયમ લર્નિંગ - સપોર્ટ ટીમ.</div></div>");
            oBuilder.Append("</td></tr>");
            oBuilder.Append("<tr><td><div style='background-color: #E4722B; height: 24px; font-size: 18px; font-weight: bold;padding: 5px;'>");
            oBuilder.Append("<div><table border=0 cellpadding=0 cellspacing=0 style='background:none;color:Black;'>");
            //oBuilder.Append("<tr  style='background:none;color:Black;'><td><span style='color: white; display: block;'>FOLLOW US!</span></td>");
            //oBuilder.Append("<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>");
            //oBuilder.Append("<td>&nbsp;<a href=https://www.facebook.com/myepathshala><img src=https://cdn3.iconfinder.com/data/icons/peelicons-vol-1/50/Facebook-48.png height=36 /></a></td>");
            //oBuilder.Append("<td>&nbsp;<a href=https://twitter.com/EpathshalaEpath><img src=https://cdn3.iconfinder.com/data/icons/peelicons-vol-1/50/Twitter-48.png height=36 /></a></td>");

            oBuilder.Append("</tr></table></div></div></td></tr>");

            //oBuilder.Append("<span style='color: white; display: block;'>FOLLOW US!</span> <a href=https://www.facebook.com/myepathshala> <img alt=Epathshala width=26px height=23px src=App_Themes/Images/FBIcon.png /> <a>  <a href=https://twitter.com/EpathshalaEpath> <img alt=Epathshala width=26px height=23px src=App_Themes/Images/twitter.png /> <a> </div> </td> </tr>");
            oBuilder.Append("<tr> <td style='padding: 20px;'> કૃપા કરીને આ સંદેશનો જવાબ ન આપો. પ્રશ્નો? સંપર્ક કરો. ગ્રાહક સેવા.<br /> સેન્ટ ઝેવિયર્સ કોલેજ નજીક, મીઠાખાળી, નવરંગપુરા, અમદાવાદ, ગુજરાત 380009. </td></tr>");
            oBuilder.Append(" </table></div>");



            //oBuilder.Append("<p>Thank you for registration in Epathshala <br /><br />");
            //oBuilder.Append("Best Regards,<br />Admin.</p>");
            //oBuilder.Append("</div></div>");
            //oBuilder.Append("</body></html>");

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return oBuilder.ToString();
    }
    protected string DefaultEmailBodyHindi(string ISFreeTrial = null)
        {
        StringBuilder oBuilder = new StringBuilder();
        try
            {
            oBuilder.Append("<!DOCTYPE html><html><head>");
            oBuilder.Append("<style type=text/css> th {color: #685858;} table tr:nth-child(odd) { background-color: #DBDBDB; border-bottom: 1px SOLID GRAY; }  p { text-align:justify; line-height:1.4em; }  </style> ");
            oBuilder.Append("</head><body>");

            //oBuilder.Append("<div style='font-family: Calibri,Cambria,verdana; color: #4C3636;'>");
            oBuilder.Append("<div style='font-family:Shruti;color:#4C3636;'>");
            oBuilder.Append("<table width=72% style='margin: 10px; border: 5px SOLID SILVER; border-radius: 5px;' border=0>");
            oBuilder.Append("<tr><td><div style='background-color: #2f378e; height: 30px; font-size: 21px; font-weight: bold;padding: 10px;'><span style='color: white; display: block;'>SwayamLearning</span></div></td></tr>");
            oBuilder.Append("<tr><td style='font-size: 16px;'>");
            oBuilder.Append("<div id=dvcontent style='font-size: 14px; padding: 20px; background-color: #F4F4F4;'>");
            oBuilder.Append("प्रिय " + txtFirstName.Text + ",  <p> हमारे साथ पंजीकरण करने के लिए धन्यवाद.</p> ");

            //oBuilder.Append("Dear " + txtFirstName.Text + "<br /><br />Thank you for registering with E-Pathshala. We welcome you to the world of experiential learning so as to make learning interesting for you.<br /><br />We have different packages for " + ddlBMS.SelectedItem.Text + " as below:<br /><br /><center> ");
            //oBuilder.Append("<table border=0 cellpadding=5 cellspacing=0 width=80% style='border: 1px SOLID #9B9B9B;'>");
            //oBuilder.Append("<tr style='background-color: #CECECE;'><th>BMS</th><th>Subject</th><th>Price</th></tr>");
            //// Dynamice for available packages
            //oBuilder.Append("<tr><td>Gujarat Board>> Gujarati Medium >> Standar-08</td><td>English</td><td style='text-align: right;'>200</td></tr>");
            //oBuilder.Append("<tr><td style='width: 60%;'>Gujarat Board>> Gujarati Medium >> Standar-08</td><td style='width: 30%;'>English</td><td style='width: 10%; text-align: right;'>200</td></tr>");
            //oBuilder.Append("</table></center><br />");

            if (ISFreeTrial != null && ISFreeTrial.ToString().ToLower() == "yes")
                {
                DataTable dtTrialPackage = (DataTable)Session["dsTrailPAckage"];
                //string strBMS = ddlBMS.SelectedItem.Text.Replace(">>", ">");
                //string[] BMS = strBMS.Split('>');
                string Board = ddlBoard.SelectedItem.ToString();
                string Medium = ddlMedium.SelectedItem.ToString(); ;
                string Standard = ddlStandard.SelectedItem.ToString();

                //oBuilder.Append(" <p> We are pleased to provide you access to ePathshala package for " + dtTrialPackage.Rows[0]["NoOfMonth"].ToString() + " days for " + Board + " Board " + Medium + " Medium " + Standard + ". ");
                oBuilder.Append(" <p>स्वयं लर्निंग पैकेज  " + dtTrialPackage.Rows[0]["NoOfMonth"].ToString() + " स्वयं लर्निंग पैकेज  15 દિવસ माटे मफत</p>");
                //oBuilder.Append("<br />Discover how SwayamLearning helps you like a teacher/friend. </p>");
                oBuilder.Append("<div><center>");
                oBuilder.Append("<table border=0 cellpadding=5 cellspacing=0 style='border-collapse: collapse; border: 1px SOLID #9B9B9B; width=80%'>");
                oBuilder.Append("<tr style='background-color: #CECECE;'><th>पैकेज नाम </th><th>વિષય</th><th>आरंभ तारीख</th><th>समाप्त तारीख </th> </tr>");

                for (int i = 0; i < dtTrialPackage.Rows.Count; i++)
                    {
                    oBuilder.Append("<tr><td>" + dtTrialPackage.Rows[i]["PackageName"].ToString() + "</td><td>" + dtTrialPackage.Rows[i]["Subject"].ToString() + "</td><td style='text-align: center;'>" + DateTime.Now.ToString("dd MMM, yyyy") + "</td><td style='text-align: center;'>" + DateTime.Now.AddDays(Convert.ToInt32(dtTrialPackage.Rows[0]["NoOfMonth"].ToString())).ToString("dd MMM, yyyy") + "</td></tr>");
                    }
                oBuilder.Append("</table> </center></div><br />");
                }

            //oBuilder.Append("<div><p> We wish you happy learning and also wish to strengthen your knowledge, increase your confidence and achieve better performance.<br />We look forward to a wonderful learning experience with us and relationship with us.  </p> <b>Your Login details are as below:  </b></div><br/>");
            oBuilder.Append("<div><p>हम एक अद्भुत सीखने के अनुभव और हमारे साथ एक रिश्ते के लिए तत्पर हैं।  </p> <b>लॉगइन विवरण  </b></div><br/>");

            oBuilder.Append("<div><table border=0 cellpadding=5 cellspacing=3 style='border-collapse: collapse;border: 1px SOLID #9B9B9B; margin-left: 90px; width=40%'>");
            oBuilder.Append("<tr><td>वेबसाइट:</td><td>http://swayamlearning.org/</td></tr>");
            oBuilder.Append("<tr><td class=style2>लॉगिन आईडी:</td><td class=style1><b>" + txtusername.Text + "</b></td></tr>");
            oBuilder.Append("<tr><td class=style2>पासवर्ड</ td><td class=style1><b>" + ViewState["strpassword"].ToString() + "</b></td></tr>");
            oBuilder.Append("<tr><td class=style2 colspan=2सवाल और समर्थन के लिए support@swayamlearning.org पर हमसे संपर्क करें.</td></tr>");
            oBuilder.Append("</table></div><br />");
            oBuilder.Append("<div>धन्यवाद,<br />स्वयं लर्निंग  - सपोर्ट टीम .</div></div>");
            oBuilder.Append("</td></tr>");
            oBuilder.Append("<tr><td><div style='background-color: #E4722B; height: 24px; font-size: 18px; font-weight: bold;padding: 5px;'>");
            oBuilder.Append("<div><table border=0 cellpadding=0 cellspacing=0 style='background:none;color:Black;'>");
            //oBuilder.Append("<tr  style='background:none;color:Black;'><td><span style='color: white; display: block;'>FOLLOW US!</span></td>");
            //oBuilder.Append("<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>");
            //oBuilder.Append("<td>&nbsp;<a href=https://www.facebook.com/myepathshala><img src=https://cdn3.iconfinder.com/data/icons/peelicons-vol-1/50/Facebook-48.png height=36 /></a></td>");
            //oBuilder.Append("<td>&nbsp;<a href=https://twitter.com/EpathshalaEpath><img src=https://cdn3.iconfinder.com/data/icons/peelicons-vol-1/50/Twitter-48.png height=36 /></a></td>");

            oBuilder.Append("</tr></table></div></div></td></tr>");

            //oBuilder.Append("<span style='color: white; display: block;'>FOLLOW US!</span> <a href=https://www.facebook.com/myepathshala> <img alt=Epathshala width=26px height=23px src=App_Themes/Images/FBIcon.png /> <a>  <a href=https://twitter.com/EpathshalaEpath> <img alt=Epathshala width=26px height=23px src=App_Themes/Images/twitter.png /> <a> </div> </td> </tr>");
            oBuilder.Append("<tr> <td style='padding: 20px;'> कृपया इस संदेश का जवाब न दें। प्रशन ? संपर्क करें। ग्राहक सेवा.<br /> सेंट जेवियर्स कॉलेज के पास, मिताखली, नवरंगपुरा, अहमदाबाद, गुजरात 380009।</td></tr>");
            oBuilder.Append(" </table></div>");



            //oBuilder.Append("<p>Thank you for registration in Epathshala <br /><br />");
            //oBuilder.Append("Best Regards,<br />Admin.</p>");
            //oBuilder.Append("</div></div>");
            //oBuilder.Append("</body></html>");

            }
        catch (Exception ex)
            {
            WebMsg.Show(ex.Message);
            }
        return oBuilder.ToString();
        }
    private string sendsms(string contactno,string smscontent,string acusage)
        {
        string Response = string.Empty;
        if (!string.IsNullOrEmpty(contactno))
            {
            bool IsSendSuccess = EmailUtility.SendSms(contactno, smscontent,acusage,"0");
            if (IsSendSuccess)
                Response = "Send email successfully.";
            else
                Response = "Send email failed.";
            }
        else
            {
            Response="Send Sms failed.[contanct number] is empty]";
            }
        return Response;
        }
    private string SendMail(string emailid, string mailsubject, string mailcontent)
    {
        string Response = string.Empty;
        if (!string.IsNullOrEmpty(emailid))
        {
            ArrayList alistEmailAddress = new ArrayList();
            alistEmailAddress.Add(emailid);
            if (alistEmailAddress.Count > 0)
            {
                bool IsSendSuccess = EmailUtility.SendEmail(alistEmailAddress, mailsubject, mailcontent);
                if (IsSendSuccess)
                    Response = "Send email successfully.";
                else
                    Response = "Send email failed.";
            }
        }
        else
        {
            Response = "Send email failed.[Email address is empty]";
        }
        return Response;
    }

    
    private int GetDefaultSchoolID()
    {
        int schoolid = 0;

        DataSet dsSettings;
        Teacher_Dashboard_BLogic obj_BAL_Teacher_Dashboard;

        obj_BAL_Teacher_Dashboard = new Teacher_Dashboard_BLogic();
        dsSettings = new DataSet();

        dsSettings = obj_BAL_Teacher_Dashboard.BAL_Select_CoveredUncoverChapterTopic_Settings("DefaultSchoolID");

        if (dsSettings.Tables[0].Rows.Count > 0)
            schoolid = Convert.ToInt32(Convert.ToString(dsSettings.Tables[0].Rows[0]["value"]));
        else
            schoolid = 0;

        return schoolid;
    }

    protected bool verifyLoginID()
    {
        bool Flag = true;
        try
        {
            BAL_Student = new Student_BLogic();
            Student = new Student();
            DataSet ds = new DataSet();

            //Student.loginid = txtEmail.Text;
            Student.loginid = txtusername.Text;
            ds = BAL_Student.BAL_Verify_Student(Student);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                string LoginID = ds.Tables[0].Rows[0]["LoginID"].ToString();
                if (LoginID != string.Empty)
                {
                    Flag = false;
                    // WebMsg.Show("LoginID already exist..");
                }
            }

        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
        return Flag;
    }
 

    

    

    //public DataSet CheckLoginStudentPortal(string name)
    //{
    //    obj_SYS_Role = new SYS_Role();
    //    obj_BAL_SYS_Role = new SYS_Role_BLogic();
    //    obj_SYS_Role.Username = txtusername.Text;
    //    obj_SYS_Role.Name = name;

    //    DataSet dtLogin = new DataSet();
    //    dtLogin = obj_BAL_SYS_Role.BAL_SYS_Check_Login_studentportal(obj_SYS_Role);
    //    return dtLogin;
    //}

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

            }
            else if (cookiesstatus == "CookiesNotSet")
            {
                //Response.Redirect("~/Dashboard/TeacherDashboard.aspx");
                Response.Redirect("~/Dashboard/DashboardTeacher.aspx");
            }
        }
        catch (Exception)
        {
        }
    }
    private void ProceedToRedirect()
    {
        Response.Redirect("~/Dashboard/StudentDashboard.aspx", false);
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
    protected void ddlBoard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBoard != null && ddlBoard.SelectedIndex > 0)
        {
            DataSet dsmedium = new DataSet();
            dsmedium = BSysBMS.Get_AllMediumByBoardID(int.Parse(ddlBoard.SelectedValue));
            if (dsmedium.Tables[0].Rows.Count > 0)
            {
                ddlMedium.DataSource = dsmedium;
                ddlMedium.DataTextField = "Medium";
                ddlMedium.DataValueField = "MediumID";
                ddlMedium.DataBind();
                string cultureinfo = ViewState["cultreinfo"].ToString();
                if (cultureinfo == "en-US")
                {
                    ddlMedium.Items.Insert(0, new ListItem("----Select Medium----", "0"));
                }
                else if (cultureinfo == "gu-IN")
                {
                    ddlMedium.Items.Insert(0, new ListItem("----માધ્યમ પસંદ કરો----", "0"));
                }
                else if (cultureinfo == "hi-IN")
                    ddlMedium.Items.Insert(0, new ListItem("----माध्यम का चयन करें----", "0"));
                //  ddlMedium.Items.Insert(0, "--Select Medium--");
                ddlMedium.Enabled = true;
            }
        }


    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlBoard != null && ddlBoard.SelectedIndex > 0) && (ddlMedium != null && ddlMedium.SelectedIndex > 0))
        {
            DataSet dsstandard = new DataSet();
            dsstandard = BSysBMS.Get_AllStandardByBoardMediumID(int.Parse(ddlBoard.SelectedValue), int.Parse(ddlMedium.SelectedValue));
            if (dsstandard.Tables[0].Rows.Count > 0)
            {
                ddlStandard.DataSource = dsstandard;
                ddlStandard.DataTextField = "Standard";
                ddlStandard.DataValueField = "StandardId";
                ddlStandard.DataBind();
                string cultureinfo = ViewState["cultreinfo"].ToString();
                if (cultureinfo == "en-US")
                {
                    ddlStandard.Items.Insert(0, new ListItem("--Select Standard--", "0"));
                }
                else if (cultureinfo == "gu-IN")
                {
                    ddlStandard.Items.Insert(0, new ListItem("--ધોરણ પસંદ કરો--", "0"));
                }
                else if (cultureinfo == "hi-IN")
                {
                    ddlStandard.Items.Insert(0, new ListItem("--वर्ग का चयन करें--", "0"));
                }
                    //ddlStandard.Items.Insert(0, "--Select Standard--");
                    ddlStandard.Enabled = true;
            }
        }

    }
    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlBoard != null && ddlBoard.SelectedIndex > 0) && (ddlMedium != null && ddlMedium.SelectedIndex > 0) && (ddlStandard != null && ddlStandard.SelectedIndex > 0))
        {
            SYS_Division_BLogic obj_DivBlogic = new SYS_Division_BLogic();

            int param_boardsid = int.Parse(ddlBoard.SelectedValue);
            int param_mediumid = int.Parse(ddlMedium.SelectedValue);
            int param_standardid = int.Parse(ddlStandard.SelectedValue);

            //ViewState["BMSID"] = obj_DivBlogic.BAL_SYS_SelectBMSID(param_boardsid, param_mediumid, param_standardid);
            Int32 bmsid = obj_DivBlogic.BAL_SYS_SelectBMSID(param_boardsid, param_mediumid, param_standardid);
            DataSet dssubject = new DataSet();
            dssubject = Blogic_Subject.BAL_SYS_Subject_SelectByBMSID(bmsid);
            //if (dssubject.Tables[0].Rows.Count > 0)
            //    {
            //    ddlSubject.DataSource = dssubject;
            //    ddlSubject.DataTextField = "Subject";
            //    ddlSubject.DataValueField = "SubjectID";
            //    ddlSubject.DataBind();
            //    string cultureinfo = ViewState["cultreinfo"].ToString();
            //    if (cultureinfo == "en-US")
            //    {
            //        ddlSubject.Items.Insert(0, new ListItem("--Select Subject--", "0"));
            //    }
            //    else
            //    {
            //        ddlSubject.Items.Insert(0, new ListItem("--વિષય પસંદ કરો--", "0"));
            //    }
            //  //  ddlSubject.Items.Insert(0, "--Select Subject--");
            //    ddlSubject.Enabled = true;
            //    }
            ViewState["BMSID"] = bmsid;
            }

    }
    public void Get_Boards()
    {
        DropDownFill DdlFilling = new DropDownFill();
        DataSet dsBoard = new DataSet();
        dsBoard = BSysBMS.Get_AllBoards();
        if (dsBoard.Tables[0].Rows.Count > 0)
        {
            ddlBoard.DataSource = dsBoard;
            ddlBoard.DataTextField = "Board";
            ddlBoard.DataValueField = "BoardID";
            ddlBoard.DataBind();
            string cultureinfo = ViewState["cultreinfo"].ToString();
            if (cultureinfo == "en-US")
            {
                ddlBoard.Items.Insert(0, new ListItem("--Select Board--", "0"));
              //  Insert(0, "--Select Board--");
            }
            else
            
                if(cultureinfo=="gu-IN")
            { 
                ddlBoard.Items.Insert(0, new ListItem("--બોર્ડ પસંદ કરો--", "0"));
              //  ddlBoard.Items.Insert(0, "--બોર્ડ પસંદ કરો--");
            }
            else if(cultureinfo=="hi-IN")
            {
                ddlBoard.Items.Insert(0, new ListItem("--बोर्ड का चयन करें--", "0"));
            }
        }
    }
    
    protected void txtContactNo_TextChanged(object sender, EventArgs e)
        {
        if (verifyLoginID())
            {

            btnsubmit.Enabled = false;
            OTPGenerator otpgen = new OTPGenerator();
            string OTP;
            string numbers = "1234567890";
            OTP = otpgen.GenerateOTP(numbers);
            Session["OTP"] = OTP;
            string messagecontent;
            messagecontent = "OTP verification code:" + OTP;
            bool issuccess;
            string culture = ViewState["cultreinfo"].ToString();
            if (culture == "gu-IN")
                {
                issuccess = EmailUtility.SendSms(txtContactNo.Text, messagecontent, "1","1");
                }
            else
                issuccess = EmailUtility.SendSms(txtContactNo.Text, messagecontent,"1", "0");

            if (issuccess)
                {
                TxtOTP.Visible = true;
                btnsubmit.Enabled = false;
                Session["OTP"] = OTP;
                Page.SetFocus(TxtOTP);
                }
            else
                {
                TxtOTP.Visible = false;
                Btnresendotp.Visible = true;
                /// LblOTP.Text = "OTP sending error retry again";
                }
            }
        else
            {
            WebMsg.Show("loginid already exists");
            }
        //string url = "http://sms.madhavtechnolabs.com/submitsms.jsp?user=SWAYAM&key=SW@ML#20&mobile="+txtContactNo+"&message=OTP= " + OTP + "&senderid=SWAYAMLEARN&accusage=1";


        }


    protected void btnrResendotp_Click(object sender, EventArgs e)
        {
        OTPGenerator otpgen = new OTPGenerator();
        string OTP;
        string numbers = "1234567890";
        OTP = otpgen.GenerateOTP(numbers);
        Session["OTP"] = OTP;
        string messagecontent;
        messagecontent = "OTP verification code:" + OTP;
        bool issuccess;
        string culture = ViewState["cultreinfo"].ToString();
        if (culture == "gu-IN")
            {
            issuccess = EmailUtility.SendSms(txtContactNo.Text, messagecontent, "1","1");
            }
        else
            {
            issuccess = EmailUtility.SendSms(txtContactNo.Text, messagecontent, "1", "0");
            }
        if (issuccess)
            TxtOTP.Visible = true;
        else
            {
            TxtOTP.Visible = false;
            Btnresendotp.Visible = true;
            /// LblOTP.Text = "OTP sending error retry again";
            }

        }

    protected void TxtOTP_TextChanged(object sender, EventArgs e)
        {
        string otp = Session["OTP"].ToString();
        string txtotp = TxtOTP.Text;
        if (otp == txtotp)
            {
            btnsubmit.Enabled = true;
            }
        else
            {
            TxtOTP.Text = "";
            TxtOTP.Visible = true;
            TxtOTP.Enabled = true;
         
             
            btnsubmit.Enabled = false;
       //   ClearRegisterControls();
            //Btnresendotp.Visible = true;
            WebMsg.Show("OTP MISMATCH..Try Again");
          //  Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
        }
        }
    
    [System.Web.Services.WebMethod]
    public static string CheckEmail(string useroremail)
    {
        string usernameexist = "false";
        Student_BLogic Blogic = new Student_BLogic();
        Student Student = new Student();
        DataSet ds = new DataSet();     
       

        //Student.loginid = txtEmail.Text;
        Student.loginid = useroremail;
        ds = Blogic.BAL_Verify_Student(Student);
        // bool existUName=Blogic.BAL_Student_UserNameExists(username);
        if (ds.Tables[0].Rows.Count > 0)
        {
            usernameexist = ds.Tables[0].Rows[0]["LoginID"].ToString();
            usernameexist = "true";
            
        }
        else
        {
            usernameexist = "false";
        }
        
        return usernameexist;
       

       // return retval;
    }  
}