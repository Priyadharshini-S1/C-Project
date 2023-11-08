using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class ViewProduct
    {
        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=Database1;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
        public static string ProductName;
        public static string ProductDescription;
        public static string ProductType;
        public static int ProductPrice;
        public static int ProductQuantity;
        public static string id;
        public  static void  GetProductDetails()
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("getproduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Product Id :{reader["Productid"]}," + "\n" +
                                $"Product Name :{reader["ProductName"]}," + "\n" +
                                $"Product Description :{reader["ProductDescription"]}," + "\n" +
                                $"Product Type :{reader["ProductType"]}," + "\n" +
                                $"Product Price :{reader["ProductPrice"]}," + "\n" +
                                $"Product Quantity :{reader["ProductQuantity"]}");
                            Console.WriteLine("________________________________________________________________________");
                        }
                    }
                }
            }

        }
    }
}
