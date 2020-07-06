﻿///<Summary>
///</Summry>

using System;
using Udev.UserMasterPage.Classes;
using System.Globalization;
using System.Data;

public partial class Admin_EpathAdminDashboard : System.Web.UI.Page
{
    # region Variables
    Student_BLogic BAL_Student_BLogic;
    Student oStudent;
    EduResourceBlogic obj_Eduresource;
    # endregion

    #region Properties
    #endregion

    #region Page events
    protected void Page_Load(object sender, EventArgs e)
    {
        lblCount.Text = Application["NoOfVisitors"].ToString();
        if (!IsPostBack)
        {
            if (AppSessions.RoleID.ToString() == "1")
            {
                BindRegistrationGrid("Top");
            }
            if(AppSessions.RoleID.ToString() == "17")
            {
                BindEduresource();
            }
        }
    }
    protected void lnkViewAllAdmission_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Report/RegistrationReport.aspx");
    }

    private void BindRegistrationGrid(string p)
    {
        try
        {
            BAL_Student_BLogic = new Student_BLogic();
            DataSet dsTeacherNotes = new DataSet();
            dsTeacherNotes = BAL_Student_BLogic.BAL_Registration_Select(p,"","");
            if (dsTeacherNotes.Tables[0].Rows.Count > 0)
            {
                gvRegistration.DataSource = dsTeacherNotes.Tables[0];
                gvRegistration.DataBind();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }
    private void BindEduresource()
    {
        try
        {
            obj_Eduresource = new EduResourceBlogic();
            DataSet dseduresource = new DataSet();
            dseduresource = obj_Eduresource.SelectEduresource();
            if (dseduresource.Tables[0].Rows.Count > 0)
            {
                grdviewedu.DataSource = dseduresource.Tables[0];
                grdviewedu.DataBind();
            }
        }
        catch (Exception ex)
        {
            WebMsg.Show(ex.Message);
        }
    }

    #endregion

    #region Control events
    #endregion

    #region User defined functions
    protected override void InitializeCulture()
    {
        string culture = Convert.ToString(Session[Global.SESSION_KEY_CULTURE]);
        // 'set culture to current thread 
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        //call base class 
        base.InitializeCulture();
    }
    #endregion

}