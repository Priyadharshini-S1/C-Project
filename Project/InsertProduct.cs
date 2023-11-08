using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class InsertProducts 
    {
        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=Database1;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
        public static string ProductName;
        public static string ProductDescription;
        public static string ProductType;
        public static int ProductPrice;
        public static int ProductQuantity;
        public static string id;


        public static void InsertProduct(string n,string d,string t,int p,int q)

        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("insertproduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductName",n);
                    cmd.Parameters.AddWithValue("@ProductDescription", d);
                    cmd.Parameters.AddWithValue("@ProductType", t);
                    cmd.Parameters.AddWithValue("@ProductPrice", p);
                    cmd.Parameters.AddWithValue("@ProductQuantity", q);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Product successfully added");
                    Console.WriteLine("Please find the Product details below :");

                    GetProductByName(n);


                }
            }

        }
        public static void GetUserInputs()
        {
            Console.WriteLine("Enter the product name :");
            ProductName = Console.ReadLine();

            Console.WriteLine("Enter the product description :");
            ProductDescription = Console.ReadLine();

            Console.WriteLine("Enter the Type of the product :");
            ProductType = Console.ReadLine();

            Console.WriteLine("Enter the Product price :");
            ProductPrice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the product quantity:");
            ProductQuantity = Convert.ToInt32(Console.ReadLine());

            InsertProduct(ProductName,ProductDescription, ProductType, ProductPrice,ProductQuantity);
        }

        public static void GetProductByName(string n)

        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("getproductbyname", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productname",n);

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
                        }
                    }
                }
            }
        }

    }
}
