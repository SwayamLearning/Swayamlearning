using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data.SqlClient;
using System.Web.Services;

public partial class NewPublic_BooksController : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
       

    }

    [WebMethod]
    public static string GetEmployees()
    {
        return "Hello World";
    }


    [WebMethod]
    public static IEnumerable<Books> Perform_CRUD(string Operation)
    {
        List<Books> MyBooks = new List<Books>();
        try
        {
            
            using (SqlConnection con = new SqlConnection("Data Source=vp\\sql2012;Initial Catalog=epathshaladb;User ID=sa;Password=swayam@123"))
            {
                SqlCommand objComm = new SqlCommand("SELECT *FROM dbo.Books ORDER BY BookID DESC", con);
                con.Open();

                SqlDataReader reader = objComm.ExecuteReader();

                // POPULATE THE LIST WITH DATA.
                while (reader.Read())
                {
                    MyBooks.Add(new Books
                    {
                        BookID = Convert.ToInt32(reader["BookID"]),
                        BookName = reader["BookName"].ToString(),
                        Category = reader["Category"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"])
                    });
                }

                con.Close();
            }

        }
        catch (Exception)
        {

            throw;
        }
       
        return MyBooks;
    }

    public class Books
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Operation { get; set; }
    }
}