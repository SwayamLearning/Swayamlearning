/// <summary> 
/// <Description>CALL ON UNLOAD MASTERPAGE </Description>
/// <DevelopedBy>"NARENDRASINH"</DevelopedBy>
/// <DevelopedDate></DevelopedDate>
/// <UpdatedBy>"NARENDRASINH"</UpdatedBy>
/// <UpdatedDate></UpdatedDate>
/// </summary>

using System;
using System.Web;
using System.Collections;
using System.Web.SessionState;

public partial class Logout : System.Web.UI.Page
{
    # region Variables
    # endregion

    # region Properties
    # endregion

    # region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
            //if (sessions == null)
            //{
            //    sessions = new Hashtable();
            //}

         
            //Changed date:07-06-2020 Reason:update userlogtime for students
            UserLogtime_BLogic userblogic = new UserLogtime_BLogic();
            HttpSessionState ss = HttpContext.Current.Session;
            string studentid = AppSessions.StudentID.ToString();
            if (studentid != "0")
            {
                UserLogtime userlogtime = new UserLogtime();
                userlogtime.Userid = Convert.ToInt32(studentid);//AppSessions.StudentID;
                userlogtime.SessionId = ss.SessionID;
                userlogtime.logouttime = DateTime.Now;
                userlogtime.isOffline = true;
                userblogic.BAL_Logtime_Update(userlogtime);
            }
          //  ss.RemoveAll();
          
            Hashtable sessions = (Hashtable)Application["WEB_SESSIONS_OBJECT"];
            if (sessions == null)
            {
                sessions = new Hashtable();
            }
            HttpSessionState existingUserSession = (HttpSessionState)sessions[studentid];
            sessions.Remove(studentid);
            if (existingUserSession != null)
            {
                existingUserSession = null;
            }
        
            Session.RemoveAll();
            Session.Abandon();
          
            Application.Lock();
            Application["WEB_SESSIONS_OBJECT"] = sessions;
            Application.UnLock();


            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();



            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
           
            Response.Redirect("SwayamDemoHomepage.aspx");
 
            }
        catch (Exception ex)
        {
        }
    }
    # endregion

    # region Control events
    # endregion
    
    # region User defined function
    # endregion
}