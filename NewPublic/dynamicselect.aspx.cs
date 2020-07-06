using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Web.Services;

public partial class NewPublic_dynamicselect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //public string test(DataSet ds)
    //{
    //    using (var memoryStream = new MemoryStream())
    //    {
    //        using (TextWriter streamWriter = new StreamWriter(memoryStream))
    //        {
    //            var xmlSerializer = new XmlSerializer(typeof(DataSet));
    //            xmlSerializer.Serialize(streamWriter, ds);
    //            return Encoding.UTF8.GetString(memoryStream.ToArray());
    //        }
    //    }
    //}

    [WebMethod]
    public static string Perform_CRUD()
    {
        List<Books> MyBooks = new List<Books>();
        try
        {

            using (SqlConnection con = new SqlConnection("Data Source=vp\\sql2012;Initial Catalog=epathshaladb;User ID=sa;Password=swayam@123"))
            {
                SqlCommand objComm = new SqlCommand("SELECT *FROM dbo.Books ORDER BY BookID DESC", con);
                
                SqlDataAdapter daAuthors = new SqlDataAdapter("SELECT *FROM dbo.Books ORDER BY BookID DESC", con);
                con.Open();

                DataSet dsbooks = new DataSet();
                daAuthors.Fill(dsbooks);

                using (var memoryStream = new MemoryStream())
                {
                    using (TextWriter streamWriter = new StreamWriter(memoryStream))
                    {
                        var xmlSerializer = new XmlSerializer(typeof(DataSet));
                        xmlSerializer.Serialize(streamWriter, daAuthors);
                        return Encoding.UTF8.GetString(memoryStream.ToArray());
                    }
                }

                //SqlDataReader reader = objComm.ExecuteReader();

                //// POPULATE THE LIST WITH DATA.
                //while (reader.Read())
                //{
                //    MyBooks.Add(new Books
                //    {
                //        BookID = Convert.ToInt32(reader["BookID"]),
                //        BookName = reader["BookName"].ToString(),
                //    });
                //}

                con.Close();
            }

        }
        catch (Exception)
        {

            throw;
        }

        //return MyBooks.ToArray();
    }

    public class Books
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        //public string Category { get; set; }
        //public decimal Price { get; set; }
        //public string Operation { get; set; }
    }
    public static string ToXML(DataSet ds)
    {
        using (var memoryStream = new MemoryStream())
        {
            using (TextWriter streamWriter = new StreamWriter(memoryStream))
            {
                var xmlSerializer = new XmlSerializer(typeof(DataSet));
                xmlSerializer.Serialize(streamWriter, ds);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }
    }

}