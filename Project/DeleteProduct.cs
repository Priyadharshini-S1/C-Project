using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class DeleteProducts
    {
        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=Database1;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
        public static string id;
        public static void DeleteProduct()
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
                        UpdateProducts.call(id);
                        Console.WriteLine("Are you sure that you want to delete this product ? (Y /N)");
                        char choice = Convert.ToChar(Console.ReadLine());
                        if (choice == 'Y' || choice == 'y')
                        {
                            using (var conn = new SqlConnection(connectionString))
                            {
                                using (var cmdd = new SqlCommand("deleteproduct", conn))
                                {
                                    cmdd.CommandType = CommandType.StoredProcedure;
                                    cmdd.Parameters.AddWithValue("@Productid", id);
                                    conn.Open();
                                    cmdd.ExecuteNonQuery();
                                }
                            }
                            Console.WriteLine("Product successfully deleted");
                        }
                        else
                        {
                            Console.WriteLine("Product not deleted ");
                        }
                    }
                    else if (count == 0)
                    {
                        Console.WriteLine("Product id is not found,so product is not deleted");
                    }
                }
            }
        }

    }
}
