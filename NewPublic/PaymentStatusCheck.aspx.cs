using CCA.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewPublic_PaymentStatusCheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCheckStatus_Click(object sender, EventArgs e)
    {
        string merchant_id = "264897"; //"99522";
        string access_code = "AVJH93HG41AV94HJVA"; //"AVFW65DE39BV30WFVB";
        string Working_key = "198C5C10C9BC8B5FEB23250E347F7A4C"; //"E85FE1783919FA34A4758580E844135A";
        object EncReq = new
        {
            reference_no = "",
            order_no = txtOrderID.Text.Trim(),
            
        };
        string ccaRequest = (new JavaScriptSerializer()).Serialize(EncReq);
        CCACrypto ccaCrypto = new CCACrypto();
        string strEncRequest = ccaCrypto.Encrypt(ccaRequest, Working_key);
        string apiUrl = "https://api.ccavenue.com/apis/servlet/DoWebTrans";
        object input = new
        {
            enc_request = strEncRequest,
            access_code = access_code,
            command = "orderStatusTracker",
            request_type = "JSON",
            version = "1.1"

        };
        string inputJson = (new JavaScriptSerializer()).Serialize(input);
        WebClient client = new WebClient();
        client.Headers["Content-type"] = "application/json";
        client.Encoding = Encoding.UTF8;
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        string json = client.UploadString(apiUrl, inputJson);

    }
}