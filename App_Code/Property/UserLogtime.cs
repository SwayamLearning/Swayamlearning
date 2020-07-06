using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserLogtime
/// </summary>
public class UserLogtime
{
    public UserLogtime()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    Int32 _id;
    Int32 _userId;
    string _SesionId;
    DateTime _logintime;
    DateTime _logoutime;
    bool _isOffline;

    public int id
    {
        get { return _id; }
        set { _id = value; }
    }
    public int Userid
    {
        get { return _userId; }
        set { _userId = value; }
    }
    public string SessionId
    {
        get { return _SesionId; }
        set { _SesionId = value; }
    }
    public bool isOffline
    {
        get { return _isOffline; }
        set { _isOffline = value; }
    }
    public DateTime logintime
    {
        get { return _logintime; }
        set { _logintime = value; }
    }

    public DateTime logouttime
    {
        get { return _logoutime; }
        set { _logoutime = value; }
    }
}