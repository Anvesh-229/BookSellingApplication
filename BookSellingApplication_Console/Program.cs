using BookSellingApp_Infrastructure;
using BookSellingApplication_DataAccess.Data;
using BookSellingApplication_Model.Models;
using Microsoft.Identity.Client;
using Serilog;

class Program
{
    static ApplicationDbContext context = new ApplicationDbContext();
    static CustomerRepository<Customer> customerrepo = new CustomerRepository<Customer>();
    static AdminRepository<Admin> adminRepository = new AdminRepository<Admin>();
    static BookRepository<Book> bookRepository = new BookRepository<Book>();
    static CartRepository<Cart> cartRepository = new CartRepository<Cart>();
    static PurchasingRepository<Purchase> purchasingRepository = new PurchasingRepository<Purchase>();
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()

            .WriteTo.Console(outputTemplate: "{Message:lj}{NewLine}")

            .CreateLogger();
        Console.WriteLine(@"
1.Admin
2.Customer
2.Exit");
        var choice = int.Parse(Console.ReadLine());
        while(true)
        {
            switch(choice)
            {
                case 1:
                    Console.WriteLine("Please Enter your Admin ID");
                    int AdminId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please Enter your password");
                    var Admin_Password = Console.ReadLine();
                    Log.Information("Your operation of Login will be started shortly...");
                    var Userfound = adminRepository.Login(AdminId , Admin_Password);
                    if (Userfound)
                    {
                        Log.Information("Login Succesfull...");
                        Console.WriteLine(@"Choose an Option
1.Add Book
2.Remove Book
3.Exit
");
                        var choice2 = int.Parse(Console.ReadLine());
                        switch(choice2 )
                        {
                            case 1:
                                Console.WriteLine("Enter your Book Title: ");
                                var Book_Title = Console.ReadLine();


                                Console.WriteLine("Enter your Publisher Name: ");
                                var Boook_publisher = Console.ReadLine();


                                Console.WriteLine("Enter the price of the Book: ");
                                var Book_Price = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter the Available Quantity : ");
                                var Book_Availability = int.Parse(Console.ReadLine());

                                Console.WriteLine(@"
Category_Id = 1, Category_Name = Historic
Category_Id = 2, Category_Name = Thriller
Category_Id = 3, Category_Name = Mystery
Category_Id = 4, Category_Name = Fiction
Category_Id = 5, Category_Name = Action
Category_Id = 6, Category_Name = Action & Adventure
Category_Id = 7, Category_Name = Comics
Category_Id = 8, Category_Name = Fantasy
Category_Id = 9, Category_Name = Horror
Category_Id = 10, Category_Name = Romantic
Category_Id = 11, Category_Name = Biography
Category_Id = 12, Category_Name = Science
");

                                Console.WriteLine("Please select a category Id from the above list : ");
                                var Book_category = int.Parse(Console.ReadLine());

                                var Book = new Book() { Title = Book_Title , Publisher = Boook_publisher , Price = Book_Price, Available_Quantity = Book_Availability, Category_ID = Book_category };
                                Log.Information("Your operation to add Book will be started shortly...");
                                bookRepository.AddBook(Book);
                                Log.Information("Book Added Successfully");
                                break;

                            case 2:
                                Console.WriteLine("Enter the Book Id to be deleted");
                                var Book_IdToDelete =int.Parse(Console.ReadLine());
                                Log.Information("Your operation to delete Book will be started shortly...");
                                bookRepository.RemoveBook(Book_IdToDelete);
                                Log.Information("Book has been removed successfully...");
                                break;
                            case 3:
                                break;
                        }

                    }
                    else
                    {
                        Log.Information("Login Failed...");
                    }
                    break;

                case 2:
                    Console.WriteLine(@"
1.Login
2.Register
3.Exit");
                    var choice1 = int.Parse(Console.ReadLine());
                    switch (choice1)
                    {
                        case 1:
                            Console.WriteLine("Please Enter your Customer ID");
                            int Customer_ID = int.Parse(Console.ReadLine());
                            Console.WriteLine("Please Enter your password");
                            var cust_password = Console.ReadLine();
                            Log.Information("Your operation to Login as customer will be started shortly...");
                            var Customersearch = customerrepo.Login(Customer_ID, cust_password);
                            if (Customersearch)
                            {
                                Log.Information("Login Successfull...!");
                                Console.WriteLine(@"
1.Browse a Book by Book Id
2.Get all Book by category Id
3.View the cart
4.Purchase the cart
5.Add items to purchase
6.Remove items from Cart
7.Exit");

                                var choice4 = int.Parse(Console.ReadLine());
                                switch(choice4)
                                {
                                    case 1:
                                        Console.WriteLine("Enter your FirstName: ");
                                        var SearchBook = int.Parse(Console.ReadLine());
                                        Log.Information("Book Searching has Started...");
                                        bookRepository.GetBook(SearchBook);
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter your FirstName: ");
                                        var SearchBookbycategoryId = int.Parse(Console.ReadLine());
                                        Log.Information("Book Searching has Started based on category...");
                                        bookRepository.GetBooksInCategory(SearchBookbycategoryId);

                                        Console.WriteLine(@"
1.Add book to cart
2.Remove the product from Cart
3.Exit");
                                        int choice5 = int.Parse(Console.ReadLine());
                                        switch(choice5)
                                        {
                                            case 1:
                                                Console.WriteLine("Enter your bookid to be added to cart : ");
                                                var BookIdToCart = int.Parse(Console.ReadLine());


                                                Console.WriteLine("Enter your Book Title : ");
                                                var Cart_Title = Console.ReadLine();

                                                Console.WriteLine("Enter the Quanity to be added : ");
                                                var Cart_Quantity = Console.ReadLine();


                                                var CartDetailsToBeAdded = new Cart() { Book_Id = BookIdToCart , Title = Cart_Title , Quantity = Cart_Quantity, CustomerId = Customer_ID };
                                                cartRepository.AddToCart(CartDetailsToBeAdded);
                                                Log.Information("Added to Cart Successfully...");

                                                break;
                                            case 2:
                                                Console.WriteLine("Enter the BookId");
                                                var BookIdTbeRemovedFromCart = int.Parse(Console.ReadLine());
                                                Log.Information("Your request to remove has will be started shortly...");
                                                cartRepository.RemoveFromCart(BookIdTbeRemovedFromCart, Customer_ID);
                                                Log.Information("Your request to remove has completed Successfully...");
                                                break;
                                            case 3:
                                                Log.Information("Your operation to exit will be started shortly...");
                                                choice = 3;
                                                break;
                                        }


                                        break;
                                    case 3:
                                        Log.Information("Your Operation to view cart has been started...");
                                        cartRepository.ViewCart(Customer_ID);
                                        Log.Information("Your Operation to view cart has been completed");
                                        break;
                                    case 4:
                                        Log.Information("Your operation to purchase items will be started shrtly...");
                                        purchasingRepository.PurchaseAllCartItems(Customer_ID);
                                        Log.Information("Your Operation to purchase cart has been completed...");
                                        break;
                                    case 5:
                                        Log.Information("Your operation to purchase a single cart Id has started...");
                                        Console.WriteLine("Enter the cart Id to be purchased : ");
                                        var cartIdToBePurchasedSeperately = int.Parse(Console.ReadLine());
                                        purchasingRepository.PurchseCartItemsSeperately(cartIdToBePurchasedSeperately, Customer_ID);
                                        Log.Information("Your Operation to purchase cart Id has been completed...");
                                        break;

                                    case 6:
                                        Console.WriteLine("Enter the Cart Id to be removed : ");
                                        var CartId = int.Parse(Console.ReadLine());
                                        Log.Information("Your Operation to remove Cart Id will be started shortly");
                                        cartRepository.RemoveFromCart(CartId, Customer_ID);
                                        Log.Information("Your cart item has been deleted");
                                        break;
                                    case 7:
                                        Log.Information("Your Operation to exit will be started shortly...");
                                        choice = 3;
                                        break;

                                }
                            }
                            else
                            {
                                Log.Information("Login Failed...!");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter your FirstName: ");
                            var firstname = Console.ReadLine();


                            Console.WriteLine("Enter your LastName: ");
                            var lastname = Console.ReadLine();


                            Console.WriteLine("Enter your Email Address : ");
                            var email = Console.ReadLine();

                            Console.WriteLine("Enter your Address : ");
                            var address = Console.ReadLine();


                            Console.WriteLine("Keep your Password : ");
                            var password = Console.ReadLine();

                            var customer = new Customer() { FirstName = firstname, LastName = lastname, Email = email, Address = address, Password = password };
                            Log.Information("Your operation to register will be started shortly...");
                            customerrepo.Register(customer);
                            Log.Information("Registration Successfull");
                            break;
                        case 3:
                            Log.Information("Your Operation to exit has been started...");
                            break;

                    }
                    break;
            }
            if(choice == 3)
            {
                Log.Information("You have exited from the application succesfully...");
                break;
            }
        }
        
        
    }

}