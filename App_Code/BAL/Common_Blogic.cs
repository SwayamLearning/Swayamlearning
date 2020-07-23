using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for Common_Blogic
/// </summary>
public class Common_Blogic
{
    DataAccess DA;
    ArrayList arrParameter;
	
    /// <summary>
    /// Method will be used to select email contact from database.
    /// </summary>
    /// <param name="GroupName">Indicate group name.</param>
    /// <returns>Dataset</returns>
    public DataSet BAL_Select_Report_Contact(string GroupName)
    {
        DA = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("GroupName", GroupName));
        return DA.DAL_Select("Peoc_Get_Report_Contact_GroupWise", arrParameter);
    }
    public DataSet BAL_Select_offer()
    {
        DA = new DataAccess();
        arrParameter = new ArrayList();
        return DA.DAL_Select("tbloffer_Get_offer", arrParameter);
    }

    public bool Inquiry_Insert(Inquiry inq)
    {
        DA = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("Name", inq.Name));
        this.arrParameter.Add(new parameter("Email", inq.Email));
        this.arrParameter.Add(new parameter("ContatNo", inq.Contactno));
        this.arrParameter.Add(new parameter("Role", inq.Role));
        this.arrParameter.Add(new parameter("SchooName", inq.SChoolName));
        this.arrParameter.Add(new parameter("Message", inq.Message));
        return this.DA.DAL_InsertUpdateWithStatus("PROC_INSERT_Inquiry", this.arrParameter);
    }
    public DataSet BAL_Registration_count()
    {
        DA = new DataAccess();
        arrParameter = new ArrayList();
        return DA.DAL_Select("Proc_Registration_count", arrParameter);
    }

    public DataSet BAL_Registration_count_monthwise()
    {
        DA = new DataAccess();
        arrParameter = new ArrayList();
        return DA.DAL_Select("Proc_Registration_count_monthwise", arrParameter);
    }

    //change 13-07-2020
    public DataSet BAL_Select_CouponInfo(string Couponcode)
        {
        DA = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("Couponcode", Couponcode));
        return DA.DAL_Select("Proc_Select_CouponDetails", arrParameter);
        }
    }