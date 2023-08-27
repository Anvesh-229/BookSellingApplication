using BookSellingApplication_DataAccess.Data;
using BookSellingApplication_Model.Models;
using Microsoft.Identity.Client;
class Program
{
    static ApplicationDbContext context = new ApplicationDbContext();

    public static void Main(string[] args)
    {
        
        Console.WriteLine(@"
1.Login
2.Rgister
2.Exit");
        var choice = int.Parse(Console.ReadLine());
        while (true)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Please Enter your Customer ID");
                    int Customer_ID = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please Enter your password");
                    var cust_password = Console.ReadLine();
                    var Userfound = customerrepo.Login(Customer_ID, cust_password);
                    if (Userfound)
                    {
                        Console.WriteLine("Login Successfull...!");
                    }
                    else
                    {
                        Console.WriteLine("Login Failed...!");
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter your FirstName: ");
                    var firstname = Console.ReadLine();


                    Console.WriteLine("Enter your LastName: ");
                    var lastname = Console.ReadLine();


                    Console.WriteLine("Enter your Email Address : ");
                    var email = Console.ReadLine();


                    Console.WriteLine("Keep your Password : ");
                    var password = Console.ReadLine();

                    var customer = new Customer() { FirstName = firstname, LastName = lastname, Email = email, password = password };
                    customerrepo.Register(customer);
                    context.SaveChanges();
                    Console.WriteLine("Registration Successfull");
                    choice = 3;
                    break;
                case 3:
                    break;
            }

            if (choice == 3)
            {
                break;
            }
        }

    }


}