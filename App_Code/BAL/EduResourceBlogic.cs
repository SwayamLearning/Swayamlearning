using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for EduResourceBlogic
/// </summary>
public class EduResourceBlogic
{
    DataAccess DAL_SYS_Package;
    ArrayList arrParameter;
    public EduResourceBlogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int InsertEduresource(string bmsid,string subjectid,string chapterid,string resource,string resourceurl)
    {
        int Value = 0;
         
        this.DAL_SYS_Package = new DataAccess();
        this.arrParameter = new ArrayList();

         ;
        arrParameter.Add(new parameter("BMSID", bmsid));
        arrParameter.Add(new parameter("SubjectID", subjectid));
        arrParameter.Add(new parameter("ChapterID",chapterid));
        arrParameter.Add(new parameter("Resource", resource));
        arrParameter.Add(new parameter("ResourceURL", resourceurl));
     



        Value = DAL_SYS_Package.DAL_InsertUpdate_Return("Eduresource_Insert", arrParameter);
        return Value;
    }

    public DataSet SelectEduresource()
    {
        DAL_SYS_Package = new DataAccess();
        arrParameter = new ArrayList();
        
        return DAL_SYS_Package.DAL_SelectALL("Eduresource_Select");
    } 
}