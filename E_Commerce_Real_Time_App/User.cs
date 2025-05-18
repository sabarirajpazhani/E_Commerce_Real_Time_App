using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using E_Commerce_Console_App_RealTime;

namespace E_Commerce_RealTime_App
{
    class OrderProduct
    {
        public int OrderID { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public long UserPhone { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionID { get; set; }

        public DateOnly OrderedDate { get; private set; }
        public DateOnly DeliveryDate { get; private set; }
        public OrderProduct(int orderID, int productId, string productName, int productPrice, int quantity, int totalPrice, int userID, string userName, string userEmail, long userPhone, string address, string paymentMethod, string transactionID)
        {
            OrderID = orderID;
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            Quantity = quantity;
            TotalPrice = totalPrice;
            UserID = userID;
            UserName = userName;
            UserEmail = userEmail;
            UserPhone = userPhone;
            Address = address;
            PaymentMethod = paymentMethod;
            TransactionID = transactionID;

        }
        public OrderProduct(int productId, string productName, int productPrice, int quantity, int totalPrice,int userID)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            Quantity = quantity;
            TotalPrice = totalPrice;
            UserID = userID;

        }

        public void DisplayBillOfOrder(int orderID, int productId, string productName, int productPrice, int quantity, int totalPrice,int userID, string userName, string userEmail, long userPhone, string address, string paymentMethod, string transactionID)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                   ------ ** ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Order Bill ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("** ------");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                        Order ID       : ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(orderID);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                        Product ID     : ");
            Console.ResetColor();
            Console.WriteLine(productId);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                        Product Name   : ");
            Console.ResetColor();
            Console.WriteLine(productName);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                        Product Price  : ");
            Console.ResetColor();
            Console.WriteLine(productPrice);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                        Quantity       : ");
            Console.ResetColor();
            Console.WriteLine(quantity);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                        Total Price    : ");
            Console.ResetColor();
            Console.WriteLine(totalPrice);

            OrderedDate = DateOnly.FromDateTime(DateTime.Now);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                        Ordered Date   : ");
            Console.ResetColor();
            Console.WriteLine(OrderedDate);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                                   ----------------------------                                        ");
            Console.ResetColor();
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                        User ID c      : ");
            Console.ResetColor();
            Console.WriteLine(userID);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                        User Name      : ");
            Console.ResetColor();
            Console.WriteLine(userName);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                        User Email     : ");
            Console.ResetColor();
            Console.WriteLine(userEmail);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                        User Phone No  : ");
            Console.ResetColor();
            Console.WriteLine(userPhone);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                        Payment Type    : ");
            Console.ResetColor();
            Console.WriteLine(PaymentMethod);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                        Transaction ID  : ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(transactionID);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("                                    Total Amount    : ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(totalPrice);
            Console.WriteLine();

            DateOnly DeliveryDate = OrderedDate.AddDays(3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("                                    Delivery Date   : ");
            Console.ResetColor();
            Console.WriteLine(DeliveryDate);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine();

            AddOrderInData(orderID, productId, productName, productPrice, quantity, totalPrice,userID, userName, userEmail, userPhone, address, paymentMethod, OrderedDate, DeliveryDate, transactionID);
        }

        public void AddOrderInData(int orderID, int productId, string productName, int productPrice, int quantity, int totalPrice,int userID, string userName, string userEmail, long userPhone, string address, string paymentMethod, DateOnly OrderedDate, DateOnly DeliveryDate, string transactionID)
        {
            string OrderedData = $"{orderID},{productId},{productName},{productPrice},{quantity},{totalPrice},{userID},{userName},{userEmail},{userPhone},{address},{paymentMethod},{transactionID},{OrderedDate:dd-MM-yyyy},{DeliveryDate:dd-MM-yyyy}";

            File.AppendAllText(User.UserOrderFilePath, OrderedData + Environment.NewLine);

        }

    }

    class CartProducts : OrderProduct
    {

        public CartProducts(int userId,int productId, string productName, int productPrice, int quantity, int totalPrice)
            : base(productId, productName, productPrice, quantity, totalPrice,userId)
        {

        }

        public void AddCartDataToFile(int userId, int productId, string productName, int productPrice, int quantity, int totalPrice)
        {

            string CartData = $"{productId},{productName},{productPrice},{quantity},{totalPrice},{userId}";

            string cartFileName = $"{userId}.txt";
            string cartFilePath = Path.Combine(User.CartDataDirectory, cartFileName);

            int TotalPrice = 0;


            if (!Directory.Exists(User.CartDataDirectory))
            {
                Directory.CreateDirectory(User.CartDataDirectory);
            }

            if (!File.Exists(cartFilePath))
            {
                string cartData = $"{productId},{productName},{productPrice},{quantity},{totalPrice}";
                File.AppendAllText(cartFilePath, cartData + Environment.NewLine);
                return;
            }   

            List<string> updatedLines = new List<string>();
            bool productFound = false;

            foreach (string line in File.ReadAllLines(cartFilePath))
            {
                string[] parts = line.Split(',');

                if (parts[0] == productId.ToString() && parts[1] == productName)
                {
                    int existingQuantity = int.Parse(parts[3]);
                    int newQuantity = existingQuantity + quantity;
                    parts[3] = newQuantity.ToString();

                    int existingTotal = int.Parse(parts[4]);
                    int newTotal = existingTotal + totalPrice;
                    parts[4] = newTotal.ToString();

                    productFound = true;
                }

                updatedLines.Add(string.Join(",", parts));
            }


            if (!productFound)
            {
                string newProductLine = $"{productId},{productName},{productPrice},{quantity},{totalPrice}";
                updatedLines.Add(newProductLine);
            }


            File.WriteAllLines(cartFilePath, updatedLines);
        }
    }


    internal class User
    {


        public static string UserOrderFilePath = @"D:\File_Handling\E-Commerce\OrderUserData\UserOrdedData.txt";

        //public static string CartDataFilePath = @"D:\File_Handling\E-Commerce\CartData.txt";
        public static string CartDataDirectory = @"D:\File_Handling\E-Commerce\CartData";

        public static Hashtable Order = new Hashtable();

        public static Hashtable CartTotalPrice = new Hashtable();

        public static int OrderID = 1000;
        public void UserProduct(int userID, string UserNameOrder, string UserEmailOrder)
        {
            while (true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("---------------------------------------- ** Shoping Panel **-------------------------------------------");
                Console.ResetColor();
                Console.WriteLine();

                Console.WriteLine("                                         1. Order the Product                                          ");
                Console.WriteLine("                                         2. View the Order                                             ");
                Console.WriteLine("                                         3. View the Cart                                              ");
                Console.WriteLine("                                         4. Exit                                                       ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.WriteLine();

                int Choice = 0;
            Choice:
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Enter the Choice : ");
                    Console.ResetColor();
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Invalid Choice! Choice must not be Zero");
                        Console.ResetColor();
                        Console.WriteLine();
                        goto Choice;
                    }
                    if (choice > 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice! Choice must be between 1 and 4");
                        Console.ResetColor();
                        goto Choice;
                    }

                    Choice = choice;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice! Input must not contain characters, symbols, or whitespace");
                    Console.ResetColor();
                    goto Choice;
                }
                catch (OverflowException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice! Please Enter the Valid Choice");
                    Console.ResetColor();
                    goto Choice;
                }

                E_CommerceInterface _E_CommerceMethods = new E_CommerceMethods();

                switch (Choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("                           You have selected option '1' to Order the Product                           ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        Product:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("                                          List Of Products                                             ");
                        Console.ResetColor();
                        Console.WriteLine();

                        _E_CommerceMethods.DisplayAllProducts(Admin.ProductDetails);

                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                              -------- Choose the Product Category --------                            ");
                        Console.ResetColor();
                        Console.WriteLine();
                        int sno = 1;
                        foreach (string i in Admin.Category)
                        {
                            Console.WriteLine($"                                  {sno}. {i}");
                            sno++;
                        }
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                              ---------------------------------------------");
                        Console.ResetColor();


                        string ProductsCategory = "None";

                    CategoryNumber:
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter the Category Number : ");
                            Console.ResetColor();
                            int categoryNumber = int.Parse(Console.ReadLine());

                            if (categoryNumber == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Category Number! Category Number must not be Zero");
                                Console.ResetColor();
                                goto CategoryNumber;
                            }
                            if (categoryNumber > 7)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Category Number! Category Number must be between 1 and 7");
                                Console.ResetColor();
                                goto CategoryNumber;
                            }
                            ProductsCategory = Admin.Category[categoryNumber - 1];
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Category Number! Input must not contain characters, symbols, or whitespace");
                            Console.ResetColor();
                            goto CategoryNumber;
                        }
                        catch (OverflowException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Category Number! Please Enter the Valid Category Number");
                            Console.ResetColor();
                            goto CategoryNumber;
                        }

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"                                Here the {ProductsCategory} Items                                     ");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine(
                            $"{"Product ID",-15}" +
                            $"{"Product Name",-25}" +
                            $"{"Product Category",-25}" +
                            $"{"Product Price",-20}"
                        );
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                        Console.WriteLine();
                        Console.ResetColor();
                        foreach (DictionaryEntry i in Admin.ProductDetails)
                        {
                            Product product = (Product)i.Value;

                            if (product.ProductCategory == ProductsCategory)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write($"{product.Product_ID,-15}");

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($"{product.ProductName,-25}");

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write($"{product.ProductCategory,-25}");

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{product.ProductPrice,-19}");

                                Console.ResetColor();
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                        Console.WriteLine();
                        Console.ResetColor();


                        string ProductName = "None";

                    ID:
                        try
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter the Product ID : ");
                            Console.ResetColor();
                            int productId = int.Parse(Console.ReadLine());

                            if (!Admin.ProductDetails.ContainsKey(productId))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Product ID Not Found");
                                Console.ResetColor();
                                goto ID;
                            }

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("Enter the Quantity of the Product  : ");
                            Console.ResetColor();
                            int quantity = int.Parse(Console.ReadLine());

                            int productPrice = 0;

                            int totalAmount = 0;






                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("                                    -------- Choice the Option --------                                ");
                            Console.ResetColor();
                            Console.WriteLine();
                            Console.WriteLine("                                      1. Purchase the Product (Order)                                  ");
                            Console.WriteLine("                                      2. Add into Cart                                                 ");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("                                    -----------------------------------                                ");
                            Console.ResetColor();
                            Console.WriteLine();
                        Option:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter the Choice : ");
                            Console.ResetColor();
                            int choice = int.Parse(Console.ReadLine());

                            Product product = (Product)Admin.ProductDetails[productId];

                            if (choice == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Choice! Choice must not be Zero");
                                Console.ResetColor();
                                goto Option;
                            }

                            if (choice > 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Choice! Enter the Correct Choice");
                                Console.ResetColor();
                                goto Option;
                            }

                            if (choice == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("                                    -------- Purchasing Product --------                                ");
                                Console.ResetColor();
                                Console.WriteLine();

                                
                                //var product = (Product) Admin.ProductDetails[i];

                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("                                               Products Details                                          ");
                                Console.ResetColor();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("                                          Product ID         : ");
                                Console.ResetColor();
                                Console.WriteLine(product.Product_ID);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("                                          Product Name       : ");
                                Console.ResetColor();
                                Console.WriteLine(product.ProductName);

                                ProductName = product.ProductName;

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("                                          Product Category   : ");
                                Console.ResetColor();
                                Console.WriteLine(product.ProductCategory);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("                                          Product Price      : ");
                                Console.ResetColor();
                                Console.WriteLine(product.ProductPrice);
                                Console.WriteLine();

                                productPrice = product.ProductPrice;

                                totalAmount = quantity * product.ProductPrice;

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("                                                Description                                                ");
                                Console.ResetColor();
                                Console.WriteLine();
                                Console.WriteLine($"                                {product.ProductDescription}                                     ");

                                product.Stock = product.Stock - quantity;
                                if (product.Stock == 0)
                                {
                                    Admin.ProductDetails.Remove(productId);
                                }

                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("                                    ------------------------------------                                ");
                                Console.ResetColor();
                                Console.WriteLine();
                            valid:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("If you Want to Place the Order (Y/N) : ");
                                Console.ResetColor();
                                Console.WriteLine();

                                char decision = char.Parse(Console.ReadLine());
                                if (decision == 'y' || decision == 'Y')
                                {
                                    string UserName = "None";
                                    string UserEmail = "None";
                                    long UserPhone = 0;

                                UserName:
                                    try
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.Write("Enter the User Name                    : ");
                                        Console.ResetColor();
                                        string userName = Console.ReadLine();
                                        _E_CommerceMethods.isNullString(userName);
                                        _E_CommerceMethods.isValidString(userName);
                                        UserName = userName;
                                    }
                                    catch (IsNullExpection e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(e.Message);
                                        Console.ResetColor();
                                        goto UserName;
                                    }
                                    catch (IsValidStringExpection e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(e.Message);
                                        Console.ResetColor();
                                        goto UserName;
                                    }

                                UserEmail:
                                    try
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("Enter the User Email                   : ");
                                        Console.ResetColor();
                                        string userEmail = Console.ReadLine();
                                        _E_CommerceMethods.IsValidEmail(userEmail);
                                        _E_CommerceMethods.isNullString(userEmail);
                                        UserEmail = userEmail;
                                    }
                                    catch (Exceptions e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(e.Message);
                                        Console.ResetColor();
                                        goto UserEmail;

                                    }
                                    catch (IsNullExpection e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Email is required. The field cannot be Empty");
                                        Console.ResetColor();
                                        goto UserEmail;
                                    }

                                UserPhone:
                                    try
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("Enter the User Phone No.               : ");
                                        Console.ResetColor();
                                        long userPhone = long.Parse(Console.ReadLine());
                                        if (userPhone == 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Please Enter the Phone Number, The Field cannot be Empty");
                                            Console.ResetColor();
                                            goto UserPhone;
                                        }
                                        if (userPhone.ToString().Length < 10)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("The phone number must contain exactly 10 digits");
                                            Console.ResetColor();
                                            goto UserPhone;
                                        }

                                        UserPhone = userPhone;

                                    }
                                    catch (FormatException e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Please enter a Valid Phone Number");
                                        Console.ResetColor();
                                        goto UserPhone;
                                    }

                                    Console.ForegroundColor = ConsoleColor.Green;

                                    Console.WriteLine("Enter Your Address (Don't use Comma    : ");
                                    Console.ResetColor();
                                    String Address = Console.ReadLine();
                                    Console.WriteLine();

                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("                                 ------ $ Select Payment Method $ ------                              ");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    Console.WriteLine("                                             1. Credit Card                                           ");
                                    Console.WriteLine("                                             2. Debit Card                                            ");
                                    Console.WriteLine("                                             3. Net Banking                                           ");
                                    Console.WriteLine("                                             4. UPI                                                   ");
                                    Console.WriteLine("                                             5. Cash On Delivery                                      ");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("                                ---------------------------------------                              ");
                                    Console.ResetColor();

                                    int PaymentChoice = 0;

                                payChoice:
                                    try
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("Enter the Choice : ");
                                        Console.ResetColor();

                                        int paymentChoice = int.Parse(Console.ReadLine());

                                        if (paymentChoice == 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid choice! Choice must not be Zero");
                                            Console.ResetColor();
                                            goto payChoice;
                                        }
                                        if (paymentChoice > 6)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid choice! Choice must be between 1 and 4");
                                            Console.ResetColor();
                                            goto payChoice;
                                        }

                                        PaymentChoice = paymentChoice;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid choice! Input must not contain characters, symbols, or whitespace");
                                        Console.ResetColor();
                                        goto payChoice;
                                    }
                                    catch (OverflowException e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid choice! Please Enter the Valid Choice");
                                        Console.ResetColor();
                                        goto payChoice;
                                    }

                                    OrderID++;

                                    string PaymentMethod = "None";
                                    int Amount = 0;
                                    string TransactionID = "None";

                                    if (PaymentChoice == 1)
                                    {
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("                                        You selected Credit Card                                      ");
                                        Console.ResetColor();
                                        Console.WriteLine();

                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("Total Amount : ");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine(totalAmount);
                                        Console.ResetColor();
                                        Console.WriteLine();

                                    Amount:
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter the Amount for Pay : ");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Amount = int.Parse(Console.ReadLine());
                                        Console.ResetColor();
                                        if (Amount == totalAmount)
                                        {

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.Write("Enter Card Number (16 Digits): ");
                                            Console.ResetColor();
                                            string cardNumber = Console.ReadLine();
                                            Console.WriteLine();

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.Write("Enter CVV (Card Verification Value) (6 Digits): ");
                                            Console.ResetColor();
                                            string cardCVV = Console.ReadLine();
                                            Console.WriteLine();

                                            PaymentMethod = "Credit Card";




                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.WriteLine("Payment Successful using Credit Card!");
                                            Console.ResetColor();
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Enter the Correct Amount");
                                            Console.ResetColor();
                                            Console.WriteLine();
                                            goto Amount;
                                        }


                                        Console.WriteLine();

                                        TransactionID = $"TXN-{DateTime.Now:yyyyddMMHHmmssfff}-{new Random().Next(1000, 9999)}";

                                        OrderProduct orderProduct = new OrderProduct(OrderID, productId, ProductName, productPrice, quantity, totalAmount,userID, UserName, UserEmail, UserPhone, Address, PaymentMethod, TransactionID);

                                        orderProduct.DisplayBillOfOrder(OrderID, productId, ProductName, productPrice, quantity, totalAmount,userID, UserName, UserEmail, UserPhone, Address, PaymentMethod, TransactionID);
                                    

                                    }
                                    else if (PaymentChoice == 2)
                                    {
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("                                        You selected Debit Card                                      ");
                                        Console.ResetColor();
                                        Console.WriteLine();

                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("Total Amount : ");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine(totalAmount);
                                        Console.ResetColor();
                                        Console.WriteLine();

                                    Amount:
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter the Amount for Pay : ");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Amount = int.Parse(Console.ReadLine());
                                        Console.ResetColor();
                                        if (Amount == totalAmount)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.Write("Enter Card Number (16 Digits): ");
                                            Console.ResetColor();
                                            string cardNumber = Console.ReadLine();
                                            Console.WriteLine();

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Enter CVV (Card Verification Value) (6 Digits): ");
                                            Console.ResetColor();
                                            string cardCVV = Console.ReadLine();
                                            Console.WriteLine();

                                            PaymentMethod = "Debit Card";


                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.WriteLine("Payment Successful using Credit Card!");
                                            Console.ResetColor();
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Enter the Correct Amount");
                                            Console.ResetColor();
                                            Console.WriteLine();
                                            goto Amount;
                                        }

                                       

                                        Console.WriteLine();

                                        TransactionID = $"TXN-{DateTime.Now:yyyyddMMHHmmssfff}-{new Random().Next(1000, 9999)}";

                                        OrderProduct orderProduct = new OrderProduct(OrderID, productId, ProductName, productPrice, quantity, totalAmount,userID, UserName, UserEmail, UserPhone, Address, PaymentMethod, TransactionID);

                                        orderProduct.DisplayBillOfOrder(OrderID, productId, ProductName, productPrice, quantity, totalAmount,userID, UserName, UserEmail, UserPhone, Address, PaymentMethod, TransactionID);

                                    
                                    }
                                    else if (PaymentChoice == 3)
                                    {
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("                                        You selected Net Banking                                       ");
                                        Console.ResetColor();
                                        Console.WriteLine();

                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("Total Amount : ");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine(totalAmount);
                                        Console.ResetColor();
                                        Console.WriteLine();

                                    Amount:
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter the Amount for Pay : ");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Amount = int.Parse(Console.ReadLine());
                                        Console.ResetColor();
                                        if (Amount == totalAmount)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.Write("Enter your Bank Name         : ");
                                            Console.ResetColor();
                                            string BanName = Console.ReadLine();
                                            Console.WriteLine();

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.Write("Enter your Account Number    : ");
                                            Console.ResetColor();
                                            string ACNumber = Console.ReadLine();
                                            Console.WriteLine();

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.Write("Enter your IFSC Code         : ");
                                            Console.ResetColor();
                                            string ifscCode = Console.ReadLine();
                                            Console.WriteLine();

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Enter Password (6 Digits)    : ");
                                            Console.ResetColor();
                                            string cardCVV = Console.ReadLine();
                                            Console.WriteLine();

                                            PaymentMethod = "Net Banking";


                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.WriteLine("Payment Successful using Credit Card!");
                                            Console.ResetColor();
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Enter the Correct Amount");
                                            Console.ResetColor();
                                            Console.WriteLine();
                                            goto Amount;
                                        }

                                        

                                        Console.WriteLine();

                                        TransactionID = $"TXN-{DateTime.Now:yyyyddMMHHmmssfff}-{new Random().Next(1000, 9999)}";

                                        OrderProduct orderProduct = new OrderProduct(OrderID, productId, ProductName, productPrice, quantity, totalAmount,userID, UserName, UserEmail, UserPhone, Address, PaymentMethod, TransactionID);

                                        orderProduct.DisplayBillOfOrder(OrderID, productId, ProductName, productPrice, quantity, totalAmount,userID, UserName, UserEmail, UserPhone, Address, PaymentMethod, TransactionID);

                                    

                                    }
                                    else if (PaymentChoice == 4)
                                    {
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("                                            You selected UPI                                         ");
                                        Console.ResetColor();
                                        Console.WriteLine();

                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("Total Amount : ");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine(totalAmount);
                                        Console.ResetColor();
                                        Console.WriteLine();

                                    Amount:
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Enter the Amount for Pay : ");
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Amount = int.Parse(Console.ReadLine());
                                        Console.ResetColor();
                                        if (Amount == totalAmount)
                                        {

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.Write("Enter your UPI ID (e.g., user.id@bank)  : ");
                                            Console.ResetColor();
                                            string UPIid = Console.ReadLine();
                                            Console.WriteLine();


                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("Enter your UPI Pin (6 Digits): ");
                                            Console.ResetColor();
                                            string upiPin = Console.ReadLine();
                                            Console.WriteLine();

                                            PaymentMethod = "UPI";


                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.WriteLine("Payment Successful using Credit Card!");
                                            Console.ResetColor();
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Enter the Correct Amount");
                                            Console.ResetColor();
                                            Console.WriteLine();
                                            goto Amount;
                                        }


                                        Console.WriteLine();

                                        TransactionID = $"TXN-{DateTime.Now:yyyyddMMHHmmssfff}-{new Random().Next(1000, 9999)}";

                                        OrderProduct orderProduct = new OrderProduct(OrderID, productId, ProductName, productPrice, quantity, totalAmount,userID, UserName, UserEmail, UserPhone, Address, PaymentMethod, TransactionID);

                                        orderProduct.DisplayBillOfOrder(OrderID, productId, ProductName, productPrice, quantity, totalAmount,userID, UserName, UserEmail, UserPhone, Address, PaymentMethod, TransactionID);

                                    
                                    }
                                    else if (PaymentChoice == 5)
                                    {
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("                                          You selected Cash On Delivery                                       ");
                                        Console.ResetColor();
                                        Console.WriteLine();

                                        string OrderedAddress = "None";
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.Write("Please confirm your delivery address:");
                                        Console.ResetColor();
                                        Console.WriteLine(Address);
                                        Console.WriteLine();

                                    decision:
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("Do you want to continue with this address? (Y) or update the address? (N) :");
                                        Console.ResetColor();
                                        char ch = char.Parse(Console.ReadLine());
                                        if (ch == 'y' || ch == 'Y')
                                        {
                                            OrderedAddress = Address;
                                        }
                                        else if (ch == 'N' || ch == 'n')
                                        {
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write("Enter the New Address : ");
                                            Console.ResetColor();
                                            OrderedAddress = Console.ReadLine();
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            Console.WriteLine("Address id Successfully Updated");
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid Choice! Enter the Correct Choice");
                                            Console.ResetColor();
                                            goto decision;
                                        }
                                        PaymentMethod = "Cash on Delivery";

                                    phoneNumber:
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.Write("Enter the Phone Number for OTP : ");
                                        Console.ResetColor();
                                        string phoneNumber = Console.ReadLine();

                                        foreach (string i in File.ReadAllLines(RegisterUser.userRegisterFilePath))
                                        {
                                            string[] lines = i.Split(',');

                                            if (lines.Length >= 4 && lines[1] == UserName && lines[2] == UserEmail && lines[3] == phoneNumber.ToString())
                                            {

                                                for (int j = 5; j >= 0; j--)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.Write("                                               Sending OTP : ");
                                                    Console.ResetColor();
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.Write($"{j}   \r");
                                                    Console.ResetColor();
                                                    Thread.Sleep(1000);
                                                }

                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("                                                         OTP : ");
                                                Console.ResetColor();
                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                int opt = new Random().Next(1121, 9879);
                                                Console.WriteLine(opt);
                                                Console.WriteLine();
                                            OTP:
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("Enter the OTP : ");
                                                Console.ResetColor();
                                                string otpInput = Console.ReadLine();
                                                int OTP;
                                                if (!int.TryParse(otpInput, out OTP))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Invalid OTP. Please enter numbers only.");
                                                    Console.ResetColor();
                                                    goto OTP;
                                                }

                                                if (opt == OTP)
                                                {
                                                    Console.WriteLine();
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.WriteLine("Your order has been placed successfully!");
                                                    Console.ResetColor();
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Incorrect OTP. Please try again.");
                                                    Console.ResetColor();
                                                    goto OTP;
                                                }

                                                break;
                                            }
                                        }

                                        Console.WriteLine();

                                        TransactionID = "Nill";

                                        OrderProduct orderProduct = new OrderProduct(OrderID, productId, ProductName, productPrice, quantity, totalAmount,userID, UserName, UserEmail, UserPhone, Address, PaymentMethod, TransactionID);

                                        orderProduct.DisplayBillOfOrder(OrderID, productId, ProductName, productPrice, quantity, totalAmount,userID, UserName, UserEmail, UserPhone, Address, PaymentMethod, TransactionID);

                                    }

                                }
                                else if (decision == 'n' || decision == 'N')
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("Okay!! Thank You...");
                                    Console.ResetColor();

                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Enter the Decisoin Correctly");
                                    Console.ResetColor();
                                    goto valid;
                                }
                            }

                            else if (choice == 2)
                            {
                                Console.WriteLine();
                                int cartProductID = productId;
                                string cartProductName = product.ProductName;
                                int cartProductPrice = product.ProductPrice;
                                int cartQuantity = quantity;
                                int cartTotalPrice = cartProductPrice * quantity;

                                CartProducts cart = new CartProducts(userID, cartProductID, cartProductName, cartProductPrice, cartQuantity, cartTotalPrice);

                                // Add to user's cart file
                                cart.AddCartDataToFile(userID, cartProductID, cartProductName, cartProductPrice, cartQuantity, cartTotalPrice);

                                // Update total price in dictionary
                                if (CartTotalPrice.Contains(cartProductName))
                                {
                                    CartTotalPrice[cartProductName] = (int)CartTotalPrice[cartProductName] + cartTotalPrice;
                                }
                                else
                                {
                                    CartTotalPrice[cartProductName] = cartTotalPrice;
                                }

                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"{cartProductName} is Successfully Added to Cart !");
                                Console.ResetColor();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("If you want to Continue Purchasing (Y/N) : ");
                                Console.ResetColor();
                                char ch = char.Parse(Console.ReadLine());

                                if (ch == 'y' || ch == 'Y')
                                {
                                    goto Product;
                                }
                                else if (ch == 'n' || ch == 'N')
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("Thank You....!!");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Enter the Decision Properly");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                }
                            }


                        }
                        catch (FormatException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid ID! Product ID must not contain letters, symbols, or whitespace.");
                            Console.ResetColor();
                            goto ID;
                        }
                        catch (OverflowException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid ID! Please enter the correct Product ID as per the given data.");
                            Console.ResetColor();
                            goto ID;
                        }





                        break;

                    case 2:

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("                            You have selected option '2' to View the Order                             ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("                                Here are the details of your Order                                     ");
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("User ID    : ");
                        Console.ResetColor();
                        Console.WriteLine(userID);

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("User Name  : ");
                        Console.ResetColor();
                        Console.WriteLine(UserNameOrder);

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("User Eamil : ");
                        Console.ResetColor();
                        Console.WriteLine(UserEmailOrder);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(new string('-', 125));
                        Console.ResetColor();

                        Console.WriteLine(
                            $"{"Order ID",-12}" +
                            $"{"Product ID",-13}" +
                            $"{"Product Name",-25}" +
                            $"{"Quantity",-10}" +
                            $"{"Total Price",-14}" +
                            $"{"Payment Mode",-20}" +
                            $"{"Order Date",-15}" +
                            $"{"Delivery Date",-15}"
                        );

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(new string('-', 125));
                        Console.ResetColor();

                        foreach (string i in File.ReadAllLines(UserOrderFilePath))
                        {
                            string[] lines = i.Split(',');

                            if (lines.Length < 15) continue;

                            if (lines[6] == userID.ToString())
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write($"{lines[0],-12}");
                                Console.ResetColor();

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($"{lines[1],-13}");
                                Console.ResetColor();

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write($"{lines[2],-25}");
                                Console.ResetColor();

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($"{lines[4],-10}");
                                Console.ResetColor();

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write($"{lines[5],-14}");
                                Console.ResetColor();

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($"{lines[11],-20}");
                                Console.ResetColor();

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write($"{lines[13],-15}");
                                Console.ResetColor();

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"{lines[14],-15}");
                                Console.ResetColor();
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(new string('-', 125));
                        Console.ResetColor();

                        break;


                    case 3:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("                            You have selected option '3' to View Cart Items                            ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("                                Here are the details of your Cart Items                                ");
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("User ID    : ");
                        Console.ResetColor();
                        Console.WriteLine(userID);

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("User Name  : ");
                        Console.ResetColor();
                        Console.WriteLine(UserNameOrder);

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("User Eamil : ");
                        Console.ResetColor();
                        Console.WriteLine(UserEmailOrder);
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine(
                            $"{"Product ID",-15}" +
                            $"{"Product Name",-25}" +
                            $"{"Total",-12}" +
                            $"{"Quantity",-12}" +
                            $"{"Total Price",-15}"
                        );
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        string fileName = $"{userID}.txt";
                        string cartFilePath = Path.Combine(User.CartDataDirectory, fileName);

                        foreach(string i in File.ReadAllLines(cartFilePath))
                        {
                            string[] lines = i.Split(',');

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write($"{lines[0],-15}");
                            Console.ResetColor();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{lines[1],-25}");
                            Console.ResetColor();

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write($"{lines[2],-12}");
                            Console.ResetColor();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{lines[3],-12}");
                            Console.ResetColor();

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"{lines[4],-15}");
                            Console.ResetColor();
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();

                        break;



                    case 4:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Thank You....!! for Purshasing");
                        Console.ResetColor();
                        Console.WriteLine();

                        break;
                }

                if (Choice == 4)
                {
                    break;
                }
            }
        }
    }
}