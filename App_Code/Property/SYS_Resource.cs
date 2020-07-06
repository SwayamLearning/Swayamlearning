using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SYS_Resource
/// </summary>
public class SYS_Resource
    {
    public SYS_Resource()
        {
        //
        // TODO: Add constructor logic here
        //
        }
    public string ResourceId {get;set;}
    public string ResourceType { get; set; }
    public string PackageType { get; set; }
    public string bmssctid { get; set; }
    public string url { get; set; }
    }