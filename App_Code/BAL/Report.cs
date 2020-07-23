using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

public class Report
{
    DataAccess Dal_Report;
    ArrayList arrParameter;
    public DataSet GetClasswiseCoveredDetails()
    {
        this.Dal_Report = new DataAccess();
        return this.Dal_Report.DAL_SelectALL("Proc_ClasswiseCoveredSyllabus");
    }
    public DataSet GetInvoiceDetails(string studentid)
        {
        this.Dal_Report = new DataAccess();
        arrParameter = new ArrayList();
        arrParameter.Add(new parameter("studentid", studentid));
        
        return this.Dal_Report.DAL_Select("Proc_Get_InvoiceDetails",arrParameter);
        }
}
