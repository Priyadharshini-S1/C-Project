using Project;

class Program
{
       public void Menu()
        {
            Console.WriteLine("Choose \n 1.View All products \n 2.Insert Product \n 3.Update Product \n 4.Delete Product \n 5.Exit");
            Console.WriteLine("What do you Need ????");
            int options = Convert.ToInt32(Console.ReadLine());
            

        switch (options)
        {

            case 1:
                ViewProduct.GetProductDetails();
                break;
            case 2:
                InsertProducts.GetUserInputs();
                break;
            case 3:
                UpdateProducts.UpdateProduct();
                break;
            case 4:
                DeleteProducts.DeleteProduct();
                break;
            case 5:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option");
                break;

        }
    }
        public static void Main()
        {
            Console.WriteLine("Welcome to  Online Clothing Store");
            Console.WriteLine("\n **************************************");
            Login lg = new Login();
            lg.logincheck();
            
        }
    }


