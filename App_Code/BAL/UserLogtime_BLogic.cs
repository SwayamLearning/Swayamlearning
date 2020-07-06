using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UserLogtime_BLogic
/// </summary>
public class UserLogtime_BLogic
{
    UserLogtime Userlogtime = new UserLogtime();

    DataAccess DAL_UserLogtime;
    ArrayList arrParameter;
    public UserLogtime_BLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //**Insert query

    public int BAL_logtime_Insert(UserLogtime usrlogtime)
    {
        this.DAL_UserLogtime = new DataAccess();
        this.arrParameter = new ArrayList();
        this.arrParameter.Add(new parameter("User_Id ", usrlogtime.Userid));
        this.arrParameter.Add(new parameter("Session_Id ", usrlogtime.SessionId));
        this.arrParameter.Add(new parameter("Login_time ", usrlogtime.logintime));
        //this.arrParameter.Add(new parameter("Logout_time  ", usrlogtime.logouttime));
        this.arrParameter.Add(new parameter("offline  ", usrlogtime.isOffline));
        int t1 = 0;
        t1 = DAL_UserLogtime.DAL_InsertUpdate_Return("Proc_UserLogintime_Insert", arrParameter);
        return t1;
    }
    public void BAL_Logtime_Update(UserLogtime usrlogtime)
    {
        this.DAL_UserLogtime = new DataAccess();
        this.arrParameter = new ArrayList();
        this.arrParameter.Add(new parameter("User_Id ", usrlogtime.Userid));
        this.arrParameter.Add(new parameter("Session_Id ", usrlogtime.SessionId));
        //this.arrParameter.Add(new parameter("Login_time ", usrlogtime.logintime));
        this.arrParameter.Add(new parameter("Logout_time  ", usrlogtime.logouttime));
        this.arrParameter.Add(new parameter("offline  ", usrlogtime.isOffline));
        DAL_UserLogtime.DAL_InsertUpdate("Update_UserLogintime", arrParameter);
    }
    public void BAL_Logtime_Delete(UserLogtime usrlogtime)
    {
        this.DAL_UserLogtime = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("User_Id ", usrlogtime.Userid));
        this.arrParameter.Add(new parameter("Session_Id ", usrlogtime.SessionId));

        DAL_UserLogtime.DAL_Delete("Delete_UserLogintime", arrParameter);
    }
    public void BAL_Visitors_Update(int count)
    {
        this.DAL_UserLogtime = new DataAccess();
        this.arrParameter = new ArrayList();
        this.arrParameter.Add(new parameter("value ", 1));
         
        DAL_UserLogtime.DAL_InsertUpdate("PROC_Update_VisitorsCount", arrParameter);
    }
    public DataSet BAL_Visitors_Count()
    {
        this.DAL_UserLogtime = new DataAccess();
        this.arrParameter = new ArrayList();
       

       return  DAL_UserLogtime.DAL_SelectALL("PROC_select_VisitorsCount");
    }
}