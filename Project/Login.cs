using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Login
    {
        public string username;

        public string pwd { get; set; }

        static SqlCommand cmd;

        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=Database1;Persist Security Info=False;User ID=sa;Password='sql@123';Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";

        public static void ShowMenu()
        {

            Program p = new Program();
            p.Menu();
            Console.WriteLine("Would you like to continue (Y / N)");
            char choice = Convert.ToChar(Console.ReadLine());
            while (choice == 'Y' || choice == 'y' && choice != 'N')
            {
                p.Menu();
            }
        }
        public void LoginUserInput()
        {
            Console.WriteLine("Enter username");
            username = Console.ReadLine();
            Console.WriteLine("Enter password");
            pwd = Console.ReadLine();
           
            Console.WriteLine("_____________________________________");

        }

        public void logincheck()
        {
            using (var con = new SqlConnection(connectionString))
            {

                LoginUserInput();

                using (var cmd = new SqlCommand("select dbo.loginchecking(@username,@pwd)", con))
                {

                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@pwd", pwd);
                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());


                    if (count == 1)
                    {

                        Console.WriteLine("welcome " + username);
                       ShowMenu();


                    }
                    else
                    {
                        Console.WriteLine("User profile not available,Register Yourself");
                        Console.WriteLine("Choose \n 1.Register Yourself \n 2.Exit");
                        int options = Convert.ToInt32(Console.ReadLine());
                        switch (options)
                        {
                            case 1:
                                UserRegistrations userRegistrations = new UserRegistrations();
                                userRegistrations.UserRegistration();
                                break;

                            case 2:
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
        }


    }
}
