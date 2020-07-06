using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Inquiry
/// </summary>
public class Inquiry
{
    public Inquiry()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    string role;

    public string Role
    {
        get { return role; }
        set { role = value; }
    }
    string email;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    string contactno;

    public string Contactno
    {
        get { return contactno; }
        set { contactno = value; }
    }
    string schoolname;

    public string SChoolName
    {
        get { return schoolname; }
        set { schoolname = value; }
    }
    string message;

    public string Message
    {
        get { return message; }
        set { message = value; }
    }
}