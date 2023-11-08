using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class UserRegistrations
    {
        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=Database1;Persist Security Info=False;User ID=sa;Password='sql@123';Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
        public string username;
        public string pwd { get; set; }

        static SqlCommand cmd;

        public void UserRegistration()
        {
            Console.WriteLine("Enter username");
            username = Console.ReadLine();
            Console.WriteLine("Enter password");
            pwd = Console.ReadLine();

            Console.WriteLine("_____________________________________");

            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("userregistration", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@pwd", pwd);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("User registration successfull");
                   
                    Login.ShowMenu();

                }
            }
        }
    }
}
