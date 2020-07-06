using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Web.SessionState;
using ASPSnippets.GoogleAPI;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Text;

using System.Globalization;
using System.Web.SessionState;
using System.Threading;

public partial class NewPublic_SwayamMaster : System.Web.UI.MasterPage
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

    public class GoogleProfile
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public Image Image { get; set; }
        public List<Email> Emails { get; set; }
        public string Gender { get; set; }
        public string ObjectType { get; set; }
    }

    public class Email
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }

    public class Image
    {
        public string Url { get; set; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cmbCulture.SelectedValue = Thread.CurrentThread.CurrentCulture.Name;
            strpassword = System.Web.Security.Membership.GeneratePassword(6, 0);

            Random rnd = new Random();
            strpassword = Regex.Replace(strpassword, @"[^a-zA-Z0-9]", m => "" + rnd.Next(1, 9) + "");

            ViewState["strpassword"] = strpassword;
            //GetBMS();
            Get_Boards();
            AppSessions.RoleID = 0;
            Session["LoginURl"] = Request.Url.AbsoluteUri;

            //#region code for sign in with google

            //if (txtusername.Text == string.Empty || txtpassword.Text == string.Empty)
            //{
            //    GoogleConnect.ClientId = "809888022564-reftuvdmq1s5ihbk9gdd418qm4b65qei.apps.googleusercontent.com";
            //    GoogleConnect.ClientSecret = "zmeA-wB6oq4cWAC70hXQNMPa";
            //    GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];

            //    if (!string.IsNullOrEmpty(Request.QueryString["code"]))
            //    {
            //        string code = Request.QueryString["code"];
            //        string json = GoogleConnect.Fetch("me", code);
            //        GoogleProfile profile = new JavaScriptSerializer().Deserialize<GoogleProfile>(json);
            //        string profileid = profile.Id;
            //        string profiledisplayname = profile.DisplayName;
            //        string email = profile.Emails.Find(Email => Email.Type == "account").Value;
            //        AppSessions.UserName = profiledisplayname;
            //        AppSessions.LoginID = email;
            //        StoreCookie();
            //        //int status = CheckLoginStudentPortal(profiledisplayname);
            //        DataSet dsLogIn = CheckLoginStudentPortal(profiledisplayname);
            //        //AppSessions.BMSID = Convert.ToInt32(dsLogIn.Tables[0].Rows[0]["BMSID"].ToString());
            //        //Response.Write(dsLogIn.Tables[0].Rows[0]["BMSID"]);
            //        if (dsLogIn.Tables[0].Rows[0]["BMSID"].ToString() == string.Empty)
            //        {
            //            MdlPopupGetBMS.Show();
            //            DataAccess da = new DataAccess();
            //            DataSet dsResultBoards = da.DAL_SelectALL("GetAllBoards_BMS");
            //            DdlBoard.DataSource = dsResultBoards;
            //            DdlBoard.DataTextField = "Board";
            //            DdlBoard.DataValueField = "BoardID";
            //            DdlBoard.DataBind();
            //        }
            //        else
            //        {
            //            Response.Redirect("../Dashboard/StudentDashboard.aspx");
            //        }
            //    }
            //    if (Request.QueryString["error"] == "access_denied")
            //    {
            //        ucinvalididpassword.Text = "Invalid User ID or Password";
            //    }
            //}
            //#endregion
        }
    }


    //[System.Web.Services.WebMethod()]
    //[System.Web.Script.Services.ScriptMethod()]
    //public static List<ListItem> GetMedium(int BoardID = 1)
    //{
    //    ArrayList aLstparams = new ArrayList();
    //    aLstparams.Add(new parameter("BoardId", BoardID));
    //    DataAccess da = new DataAccess();
    //    DataSet dsResultMediums = da.DAL_Select("GetAllMedium_BMS", aLstparams);
    //    List<ListItem> customers = new List<ListItem>();
    //    DataTableReader rd = dsResultMediums.Tables[0].CreateDataReader();
        
    //    while (rd.Read())
    //    {
    //        customers.Add(new ListItem
    //        {
    //            Value = rd["MediumId"].ToString(),
    //            Text = rd["Medium"].ToString()
    //        });
    //    }
        
    //    return customers;
    //}

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int t1 = 0;

        //if (TxtBxCap.Text.Trim() != "")
        //{
        //Captcha1.ValidateCaptcha(TxtBxCap.Text.Trim());
        try
        {
            if (verifyLoginID())
            {
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
                Student = new Student();
                BAL_Student = new Student_BLogic();
                Student.schoolid = GetDefaultSchoolID();
                Student.divisionid = 1;
                Student.bmsid = (int)ViewState["BMSID"];
                //ViewState["BMSID"] = int.Parse(ddlBMS.SelectedValue);
                Student.loginid = txtEmail.Text;
                //Student.password = txtPassword.Text;
                Student.password = ViewState["strpassword"].ToString();
                Student.firstname = txtFirstName.Text;
                Student.lastname = txtLastName.Text;
                Student.schoolname = txtSchoolname.Text;
                //Student.contactno = Convert.ToInt64(txtContactNo.Text);
                Student.mobilenostring = txtContactNo.Text;
                Student.emailid = txtEmail.Text;

                //DateTime fromdatetime;

                //string d = txtBirthdate.Text;
                //d = d.Replace("-", "/");
                //DateTime dt;
                //try
                //{
                //    dt = DateTime.ParseExact(d, "d/M/yyyy", CultureInfo.InvariantCulture);
                //}
                //catch (Exception)
                //{
                //    dt = DateTime.ParseExact(d, "M/d/yyyy", CultureInfo.InvariantCulture); ;
                //}

                //= DateTime.ParseExact(d, "d/M/yyyy", CultureInfo.InvariantCulture);
                // for both "1/1/2000" or "25/1/2000" formats
                //string newString = dt.ToString("dd/MMM/yyyy");
                //Student.dateofbirth = dt;
                //if (DateTime.TryParse(txtBirthdate.Text, out fromdatetime))
                //{
                //    Student.dateofbirth = fromdatetime;
                //}

                //if (RlstGender.SelectedValue == "1")
                //{
                //    Student.gender = 'M';
                //}
                //else if (RlstGender.SelectedValue == "2")
                //{
                //    Student.gender = 'F';
                //}
                Student.PaymentType = 'I';
                //if (Captcha1.UserValidated)
                //{
                t1 = BAL_Student.BAL_Student_Insert_Online(Student, "OnlineReg");
                InsertIntoStudentPackageDetails(t1);
                //}
                //else
                //{
                //    WebMsg.Show("Please enter the correct Captcha code");

                //}
                if (t1 > 0)
                {
                    //ScriptManager.RegisterStartupScript(this.Page, GetType(), "Message", "You are successfully registered", false);
                    //string MailContent = DefaultEmailBody();
                    //string strResponce = SendMail(txtEmail.Text, "New Registration Details:", MailContent);

                    //WebMsg.Show("Your registration was successfull. We have sent your Login details on your registered Email Address.");
                    // ShowMessage("Your registration was successfull. We have sent your Login details on your registered Email Address.");
                    RedirectToDashboard();
                    //AppSessions.StudentID = t1;
                    //AppSessions.BMSID = (int)ViewState["BMSID"];
                    //Response.Redirect("~/Dashboard/StudentDashboard.aspx", false);



                    //WebMsg.Show(strResponce);
                    //ClearRegisterControls();
                    //Response.Redirect("Login.aspx");
                }
                ClearRegisterControls();
            }
            else
            {
                WebMsg.Show("LoginID already exist..");
            }
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
                    int result = Blogic_Package.BAL_Student_TrialPackage_Insert(Opackage);
                    if (result > 0)
                    {
                        string MailContent = DefaultEmailBody("yes");
                        string strResponce = SendMail(txtEmail.Text, "New Registration Details", MailContent);
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
        }
        catch (Exception ex)
        {
        }
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
            oBuilder.Append("<tr><td><div style='background-color: #2f378e; height: 30px; font-size: 21px; font-weight: bold;padding: 10px;'><span style='color: white; display: block;'>EPATHSHALA</span></div></td></tr>");
            oBuilder.Append("<tr><td style='font-size: 16px;'>");
            oBuilder.Append("<div id=dvcontent style='font-size: 14px; padding: 20px; background-color: #F4F4F4;'>");
            oBuilder.Append("Dear " + txtFirstName.Text + ",  <p> Thank you for registering with ePathshala. We welcome you to the world of experiential learning to make your learning process efficient and effective.</p> ");

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
                oBuilder.Append(" <p> We are pleased to provide you access to ePathshala package for " + dtTrialPackage.Rows[0]["NoOfMonth"].ToString() + " day(s) as an introductory promotional offer for selected standard.");
                oBuilder.Append("<br />Discover how E-Pathshala helps you like a teacher/friend. </p>");
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
            oBuilder.Append("<tr><td>Visit:</td><td>http://epathshala.co.in/</td></tr>");
            oBuilder.Append("<tr><td class=style2>Login ID:</td><td class=style1><b>" + txtEmail.Text + "</b></td></tr>");
            oBuilder.Append("<tr><td class=style2>Password:</td><td class=style1><b>" + ViewState["strpassword"].ToString() + "</b></td></tr>");
            oBuilder.Append("<tr><td class=style2 colspan=2>Please do reach us on info@epath.net.in for your queries or suggestion.</td></tr>");
            oBuilder.Append("</table></div><br />");
            oBuilder.Append("<div>Thank You,<br />ePathshala - Support Team.</div></div>");
            oBuilder.Append("</td></tr>");
            oBuilder.Append("<tr><td><div style='background-color: #E4722B; height: 24px; font-size: 18px; font-weight: bold;padding: 5px;'>");
            oBuilder.Append("<div><table border=0 cellpadding=0 cellspacing=0 style='background:none;color:Black;'>");
            oBuilder.Append("<tr  style='background:none;color:Black;'><td><span style='color: white; display: block;'>FOLLOW US!</span></td>");
            oBuilder.Append("<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>");
            oBuilder.Append("<td>&nbsp;<a href=https://www.facebook.com/myepathshala><img src=https://cdn3.iconfinder.com/data/icons/peelicons-vol-1/50/Facebook-48.png height=36 /></a></td>");
            oBuilder.Append("<td>&nbsp;<a href=https://twitter.com/EpathshalaEpath><img src=https://cdn3.iconfinder.com/data/icons/peelicons-vol-1/50/Twitter-48.png height=36 /></a></td>");

            oBuilder.Append("</tr></table></div></div></td></tr>");

            //oBuilder.Append("<span style='color: white; display: block;'>FOLLOW US!</span> <a href=https://www.facebook.com/myepathshala> <img alt=Epathshala width=26px height=23px src=App_Themes/Images/FBIcon.png /> <a>  <a href=https://twitter.com/EpathshalaEpath> <img alt=Epathshala width=26px height=23px src=App_Themes/Images/twitter.png /> <a> </div> </td> </tr>");
            oBuilder.Append("<tr> <td style='padding: 20px;'> Please do not reply this message. Queries? Contact. Customer Support. <br /> Arraycom India Ltd. 13, GIDC, Gandhinagar, 382025. </td></tr>");
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

            Student.loginid = txtEmail.Text;
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
    protected void btnswayamlogin_click(object sender, EventArgs e)
    {
        try
        {
            if (txtusername.Text == string.Empty || txtpassword.Text == string.Empty)
            {
                WebMsg.Show("Please enter User ID and Password");
            }
            else
            {
                StoreCookie();
                int status = CheckLogin();
                if (status == 2)
                {
                    txtusername.Text = string.Empty;
                    txtpassword.Text = string.Empty;
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
                    obj_SYS_Role.Username = txtusername.Text;
                    obj_SYS_Role.Password = txtpassword.Text;

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
                        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), "LoginId: " + txtusername.Text, 0);

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
                                    TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.PackageSelection), "LoginId: " + txtusername.Text, 0);
                                }
                            }
                            else
                            {
                                Response.Redirect("~/DashBoard/SelectPackage.aspx", false);
                                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), "Login", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.PackageSelection), "LoginId: " + txtusername.Text, 0);
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
                    obj_SYS_Role.Username = txtusername.Text;
                    obj_SYS_Role.Password = txtpassword.Text;
                    dtLogin = obj_BAL_SYS_Role.BAL_SYS_Active_Login_Swayam(obj_SYS_Role);
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
                                //AppSessions.BMSID = Convert.ToInt32(UserInfo.Rows[0]["BMSID"].ToString());
                                //AppSessions.SubjectID = Convert.ToInt32(UserInfo.Rows[0]["SubjectID"].ToString());

                                AllowMultipleSession = Convert.ToBoolean(UserInfo.Rows[0]["AllowMultipleSession"].ToString());
                                TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LoginPage", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), "LoginId: " + txtusername.Text, 0);
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
                                AppSessions.BMSID = Convert.ToInt32(UserInfo.Rows[0]["BMSID"].ToString());
                                AppSessions.SubjectID = Convert.ToInt32(UserInfo.Rows[0]["SubjectID"].ToString());

                                AllowMultipleSession = Convert.ToBoolean(UserInfo.Rows[0]["AllowMultipleSession"].ToString());
                                TrackLog_Utils.Log(Convert.ToInt32(ViewState["SchoolID"]), Convert.ToInt32(ViewState["EmpolyeeID"]), Convert.ToInt16(AppSessions.DivisionID), "LoginMasterPage.master", "ucbtnGo", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginSuccess), ViewState["UserName"] + " (" + txtusername.Text + ") From " + ViewState["SchoolName"] + " school Logged in.", 0);
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
                        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmpolyeeID), Convert.ToInt16(AppSessions.DivisionID), "LoginPage", "btnLogin", "Click", Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.LoginFailed), "LoginId: " + txtusername.Text + " , Password: " + txtpassword.Text, 0);
                        WebMsg.Show("Authentication Failed,unable to login");
                    }
                }

                txtusername.Text = string.Empty;
                txtpassword.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    protected void StoreCookie()
    {
        try
        {
            if (ucchkRememberMe.Checked == true)
            {
                HttpCookie loginCookie = new HttpCookie("loginCookie");
                loginCookie["UserName"] = txtusername.Text;
                loginCookie["Password"] = txtpassword.Text;
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

    public int CheckLogin()
    {
        obj_SYS_Role = new SYS_Role();
        obj_BAL_SYS_Role = new SYS_Role_BLogic();
        obj_SYS_Role.Username = txtusername.Text;
        obj_SYS_Role.Password = txtpassword.Text;


        DataSet dtLogin = new DataSet();
        DataTable LoginInfo = new DataTable();

        dtLogin = obj_BAL_SYS_Role.BAL_SYS_Check_Login(obj_SYS_Role);
        LoginInfo = dtLogin.Tables[0];

        int status = Convert.ToInt16(LoginInfo.Rows[0]["Status"].ToString());

        return status;

    }

    public DataSet CheckLoginStudentPortal(string name)
    {
        obj_SYS_Role = new SYS_Role();
        obj_BAL_SYS_Role = new SYS_Role_BLogic();
        obj_SYS_Role.Username = txtusername.Text;
        obj_SYS_Role.Name = name;

        DataSet dtLogin = new DataSet();
        dtLogin = obj_BAL_SYS_Role.BAL_SYS_Check_Login_studentportal(obj_SYS_Role);
        return dtLogin;
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
    protected void btnsigninwithgoogle_Click(object sender, EventArgs e)
    {
        GoogleConnect.Authorize("profile", "email");
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
                ddlMedium.Items.Insert(0, "--Select Medium--");
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
                ddlStandard.Items.Insert(0, "--Select Standard--");
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

            ViewState["BMSID"] = obj_DivBlogic.BAL_SYS_SelectBMSID(param_boardsid, param_mediumid, param_standardid);
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
            ddlBoard.Items.Insert(0, "--Select Board--");
        }
    }
    protected void cmbCulture_SelectedIndexChanged(object sender, EventArgs e)
    {

        HttpCookie cookie = new HttpCookie("CultureInfo");
        cookie.Value = cmbCulture.SelectedValue;
        Response.Cookies.Add(cookie);

        Thread.CurrentThread.CurrentCulture = new CultureInfo(cmbCulture.SelectedValue);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(cmbCulture.SelectedValue);
        cmbCulture.Enabled = false;
        Server.Transfer(Request.Path);
       
    }


}
