using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SYS_Resource_Blogic
/// </summary>
public class SYS_Resource_Blogic
    {
    DataAccess DAL_Student;
    ArrayList arrParameter;
    public SYS_Resource_Blogic()
        {
        //
        // TODO: Add constructor logic here
        //
        }
    public void BAL_SYSResource_Insert(SYS_Resource src)
        {
        this.DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("ResourceType", src.ResourceType));
        arrParameter.Add(new parameter("PackageType", src.PackageType));
        arrParameter.Add(new parameter("BMSSCTID", src.bmssctid));
        arrParameter.Add(new parameter("URL", src.url));
        
        DAL_Student.DAL_InsertUpdate("Proc_SysResource_Insert", arrParameter);
        }
    public void BAL_SYSResource_Update(SYS_Resource src)
        {
        this.DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("ResourceId", src.ResourceId));
        arrParameter.Add(new parameter("ResourceType", src.ResourceType));
        arrParameter.Add(new parameter("PackageType", src.PackageType));
        arrParameter.Add(new parameter("BMSSCTID", src.bmssctid));
        arrParameter.Add(new parameter("URL", src.url));

        DAL_Student.DAL_InsertUpdate("Proc_SysResource_Update", arrParameter);
        }
    public void BAL_SYSResource_delete(SYS_Resource src)
        {
        this.DAL_Student = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("ResourceId", src.ResourceId));
         
        DAL_Student.DAL_InsertUpdate("Proc_SysResource_delete", arrParameter);
        }
    public DataSet BAL_SYSResource_selectall()
        {
        DAL_Student = new DataAccess();
        return DAL_Student.DAL_SelectALL("Proc_SysResource_selectall");
        }
    public DataSet BAL_SYSResource_select(SYS_Resource src)
        {
        DAL_Student = new DataAccess();
        arrParameter.Add(new parameter("ResourceId", src.ResourceId));
        return DAL_Student.DAL_SelectALL("Proc_SysResource_select");
        }
    public DataSet BAL_SYSResource_selecturl(SYS_Resource src)
        {
        DAL_Student = new DataAccess();
        arrParameter.Add(new parameter("BMSSCTID", src.bmssctid));
        return DAL_Student.DAL_Select("Proc_SysResource_URL",arrParameter);
        }
    }