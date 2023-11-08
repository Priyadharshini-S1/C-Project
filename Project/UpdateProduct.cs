using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class UpdateProducts
    {
        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=Database1;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
        public static string ProductName;
        public static string ProductDescription;
        public static string ProductType;
        public static int ProductPrice;
        public static int ProductQuantity;
        public static string id;
        public static void UpdateProduct()
        {
            Console.WriteLine("Enter the Product Id :");
            id = Console.ReadLine();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("select dbo.idchecking(@Productid)", con))
                {
                    cmd.Parameters.AddWithValue("@Productid", id);
                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 1)
                    {
                        Console.WriteLine("*************************************************");
                        Console.WriteLine("Please find the Product details below :");
                        call(id);
                        callUpdateId();

                    }
                    else if (count == 0)
                    {
                        Console.WriteLine("Product id is not found");


                    }

                }
            }
        }

        public static void call(string n)
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("getproductbyid", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Productid", n);

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
        public static void callUpdateId()
        {

            Console.WriteLine("What would you like to update?\n Select \n1.ProductName \n2.ProductDescription \n3.Product type \n4.Product Price \n5.Product quantity \n6.Select All\n7.Exit");
            int value = Convert.ToInt32(Console.ReadLine());
            switch (value)
            {
                case 1:

                    Console.WriteLine("Enter the Product name:");
                    ProductName = Console.ReadLine();
                    using (var con = new SqlConnection(connectionString))
                    {
                        using (var cmd = new SqlCommand("updateproductname", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ProductName", ProductName);
                            cmd.Parameters.AddWithValue("@Productid", id);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Product details successfully updated");

                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the Product Description:");
                    ProductDescription = Console.ReadLine();
                    using (var con = new SqlConnection(connectionString))
                    {
                        using (var cmd = new SqlCommand("updateproductdesc", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ProductDescription", ProductDescription);
                            cmd.Parameters.AddWithValue("@Productid", id);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Product details successfully updated");

                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter the Product Type:");
                    ProductType = Console.ReadLine();
                    using (var con = new SqlConnection(connectionString))
                    {
                        using (var cmd = new SqlCommand("updateproducttype", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ProductType", ProductType);
                            cmd.Parameters.AddWithValue("@Productid", id);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Product details successfully updated");

                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter the Product Price:");
                    ProductPrice = Convert.ToInt32(Console.ReadLine());
                    using (var con = new SqlConnection(connectionString))
                    {
                        using (var cmd = new SqlCommand("updateproductprice", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ProductPrice", ProductPrice);
                            cmd.Parameters.AddWithValue("@Productid", id);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Product details successfully updated");

                        }
                    }
                    break;

                case 5:
                    Console.WriteLine("Enter the Product Quantity:");
                    ProductQuantity = Convert.ToInt32(Console.ReadLine());
                    using (var con = new SqlConnection(connectionString))
                    {
                        using (var cmd = new SqlCommand("updateproductquantity", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ProductQuantity", ProductQuantity);
                            cmd.Parameters.AddWithValue("@Productid", id);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Product details successfully updated");

                        }
                    }
                    break;

                case 6:
                    Console.WriteLine("Please enter the details of the product to be updated");
                    GetUserInputs();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
            }
            Login.ShowMenu();
        }
        public static void GetProduct(string ProductName,string ProductDescription,string ProductType,int ProductPrice,int ProductQuantity)
        {
                    using (var con = new SqlConnection(connectionString))
                    {
                        using (var cmd = new SqlCommand("updateproduct", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Productid", id);
                            cmd.Parameters.AddWithValue("@ProductName", ProductName);
                            cmd.Parameters.AddWithValue("@ProductDescription", ProductDescription);
                            cmd.Parameters.AddWithValue("@ProductType", ProductType);
                            cmd.Parameters.AddWithValue("@ProductPrice", ProductPrice);
                            cmd.Parameters.AddWithValue("@ProductQuantity", ProductQuantity);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Product details successfully updated");


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

            GetProduct(ProductName, ProductDescription, ProductType, ProductPrice, ProductQuantity);
        }
    }
}
