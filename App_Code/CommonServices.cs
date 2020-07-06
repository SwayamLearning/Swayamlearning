using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AjaxControlToolkit;
using System.Collections;
using System.Collections.Specialized;
using System.Data;

/// <summary>
/// Summary description for CommonServices
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class CommonServices : System.Web.Services.WebService {

    public CommonServices () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    public CascadingDropDownNameValue[] GetBoards(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> cascadingValues = new List<CascadingDropDownNameValue>();

        DataAccess da = new DataAccess();
        DataSet dsResultBoards = da.DAL_SelectALL("GetAllBoards_BMS");
        if (dsResultBoards != null && dsResultBoards.Tables.Count > 0 && dsResultBoards.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in dsResultBoards.Tables[0].Rows)
            {
                cascadingValues.Add(new CascadingDropDownNameValue(dr["Board"].ToString(), dr["BoardID"].ToString()));
            }
        }

        return cascadingValues.ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="knownCategoryValues"></param>
    /// <param name="category"></param>
    /// <returns></returns>
    [WebMethod]
    public CascadingDropDownNameValue[] Mediums_By_BoardId(string knownCategoryValues, string category)
    {
        ArrayList aLstparams = new ArrayList();
        int BoardID;
        List<CascadingDropDownNameValue> cascadingValues = new List<CascadingDropDownNameValue>();

        StringDictionary countrydetails = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        BoardID = Convert.ToInt32(countrydetails["Boards"]);

        aLstparams.Add(new parameter("BoardId", BoardID));

        DataAccess da = new DataAccess();
        DataSet dsResultMediums = da.DAL_Select("GetAllMedium_BMS", aLstparams);

        if (dsResultMediums != null && dsResultMediums.Tables.Count > 0 && dsResultMediums.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in dsResultMediums.Tables[0].Rows)
            {
                cascadingValues.Add(new CascadingDropDownNameValue(dr["Medium"].ToString(), dr["MediumId"].ToString()));
            }
        }

        return cascadingValues.ToArray();
    }

    /// <summary>
    /// To Get List of Values of Availabled Standards in Perticular Boards and Medium Of Education.
    /// </summary>
    /// <param name="knownCategoryValues"></param>
    /// <param name="category"></param>
    /// <returns></returns>
    [WebMethod]
    public CascadingDropDownNameValue[] Standard_ByBoard_MediumIds(string knownCategoryValues, string category)
    {
        ArrayList aLstparams = new ArrayList();
        int BoardID, MediumId;
        List<CascadingDropDownNameValue> cascadingValues = new List<CascadingDropDownNameValue>();

        StringDictionary countrydetails = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        BoardID = Convert.ToInt32(countrydetails["Boards"]);
        MediumId = Convert.ToInt32(countrydetails["Mediums"]);

        aLstparams.Add(new parameter("BoardId", BoardID));
        aLstparams.Add(new parameter("MediumId", MediumId));

        DataAccess da = new DataAccess();

        DataSet dsResultStandard = da.DAL_Select("GetAllStandard_BMS", aLstparams);

        if (dsResultStandard != null && dsResultStandard.Tables.Count > 0 && dsResultStandard.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in dsResultStandard.Tables[0].Rows)
            {
                cascadingValues.Add(new CascadingDropDownNameValue(dr["Standard"].ToString(), dr["StandardId"].ToString()));
            }
        }

        return cascadingValues.ToArray();
    }
    
}
