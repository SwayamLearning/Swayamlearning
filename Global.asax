<%@ Application Language="C#" %>
<script RunAt="server">

    //void Application_BeginRequest(object sender, EventArgs e)
    //{


    //}
    void Application_BeginRequest(object sender, EventArgs e)
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
    void Application_Start(object sender, EventArgs e)
        {
        Application["NoOfVisitors"] = 0;
        //EmailUtility.GetEmailSettings();
        // if (!CommonUtility.GetLicenseInfo())
        // {
        //     CommonUtility.RemoveKeyFromXML();
        //     HttpContext.Current.Response.Redirect("~/Dashboard/License.aspx");
        //}
        }

    void Application_End(object sender, EventArgs e)
        {
        //  Code that runs on application shutdown
        //Session.Abandon();

        try
            {
            Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
            if (sessions == null)
                {
                sessions = new Hashtable();
                }

            Session.Abandon();
            sessions.Remove(Session["EmpolyeeID"].ToString());

            Application.Lock();
            Application["WEB_SESSIONS_OBJECT"] = sessions;
            Application.UnLock();


            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            //Response.Redirect("~/Index.aspx");
            }
        catch (Exception ex)
            {
            //Response.Redirect("~/Index.aspx");
            }



        }

    void Application_Error(object sender, EventArgs e)
        {
        // Code that runs when an unhandled error occurs

        }

    void Session_Start(object sender, EventArgs e)
        {
        // Code that runs when a new session is started
        Session["LANG"] = "en-US"; ;
        Session["Varnindra"] = "en-US";
        Application.Lock();
        Application["NoOfVisitors"] = (int)Application["NoOfVisitors"] + 1;
        int count =(int) Application["NoOfVisitors"];
        UserLogtime_BLogic bal_logic = new UserLogtime_BLogic();
        bal_logic.BAL_Visitors_Update(count);


        Application.UnLock();

        TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), StringEnum.stringValueOf(EnumFile.AccessedPages.Homepage), "Page", StringEnum.stringValueOf(EnumFile.Events.Load), Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.SessionStarted), "Session Started", 0);
        }

    void Session_End(object sender, EventArgs e)
        {
        //try
        //    {
        //    //TrackLog_Utils.Log_StudentActivity(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), StringEnum.stringValueOf(EnumFile.AccessedPages.Homepage), "Page", StringEnum.stringValueOf(EnumFile.Events.Load), Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.SessionEnded), "Session Ended", 0);
        //    TrackLog_Utils.Log(Convert.ToInt32(AppSessions.SchoolID), Convert.ToInt32(AppSessions.EmployeeOrStudentID), Convert.ToInt16(AppSessions.DivisionID), StringEnum.stringValueOf(EnumFile.AccessedPages.Homepage), "Page", StringEnum.stringValueOf(EnumFile.Events.Load), Convert.ToDateTime(System.DateTime.Now), HttpContext.Current.Session.SessionID, StringEnum.stringValueOf(EnumFile.Activity.SessionEnded), "Session Ended", 0);
        //    Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
        //    if (sessions == null)
        //        {
        //        sessions = new Hashtable();
        //        }
        //    string studentid = AppSessions.StudentID.ToString();
        //    HttpSessionState existingUserSession = (HttpSessionState)sessions[studentid];
        //    sessions.Remove(studentid);
        //    if (existingUserSession != null)
        //        {
        //        existingUserSession = null;
        //        }
        //    Session.Abandon();
        //    sessions.Remove(Session["StudentID"].ToString());

        //    Application.Lock();
        //    Application["WEB_SESSIONS_OBJECT"] = sessions;
        //    Application.UnLock();


        //    HttpContext.Current.Session.Clear();
        //    HttpContext.Current.Session.Abandon();
        //    Response.Redirect("~/Index.aspx");


        //    }
        //catch (Exception ex)
        //    {





        //        Response.Redirect("~/Index.aspx");
        //    }
        }

</script>
