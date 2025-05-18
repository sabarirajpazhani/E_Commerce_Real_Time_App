using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_Console_App_RealTime;

namespace E_Commerce_RealTime_App
{
    class Product
    {
        public int Product_ID { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public int ProductPrice { get; set; }
        public int Stock { get; set; }
        public string ProductDescription { get; set; }

        public Product(int Product_ID, string ProductName, string ProductCategory, int ProductPrice, int Stock, string ProductDescription)
        {
            this.Product_ID = Product_ID;
            this.ProductName = ProductName;
            this.ProductCategory = ProductCategory;
            this.ProductPrice = ProductPrice;
            this.Stock = Stock;
            this.ProductDescription = ProductDescription;
        }

        public void DisplayProduct(int Product_ID, string ProductName, string ProductCategory, int ProductPrice, int Stock)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                              --------- Newly Registed Products ---------                              ");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"                                         Product ID         : ");
            Console.ResetColor();
            Console.WriteLine(Product_ID);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"                                         Product Name       : ");
            Console.ResetColor();
            Console.WriteLine(ProductName);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"                                         Product Category   : ");
            Console.ResetColor();
            Console.WriteLine(ProductCategory);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"                                         Product Price      : ");
            Console.ResetColor();
            Console.WriteLine(ProductPrice);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"                                         Product Stock      : ");
            Console.ResetColor();
            Console.WriteLine(Stock);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                              -------------------------------------------                              ");
            Console.ResetColor();
            Console.WriteLine();

        }

    }
    internal class Admin
    {
        public static int product_ID = 108;

        public static Hashtable ProductDetails = new Hashtable()
        {
            {
                101, new Product(
                    101,
                    "Wireless Mouse",
                    "Electronics",
                    799,
                    25,
                    "Ergonomic wireless mouse with 2.4GHz connectivity and silent clicks."
                )
            },
            {
                102, new Product(
                    102,
                    "Bluetooth Headphones",
                    "Electronics",
                    1599,
                    30,
                    "Over-ear Bluetooth headphones with deep bass and 20 hours of battery life."
                )
            },
            {
                103, new Product(
                    103,
                    "Mens Casual Shirt",
                    "Fashion",
                    1199,
                    40,
                    "Cotton slim-fit casual shirt for men, available in multiple colors."
                )
            },
            {
                104, new Product(
                    104,
                    "Non stick Cookware Set",
                    "Home & Kitchen",
                    2499,
                    15,
                    "5-piece non-stick cookware set with lids, ideal for healthy cooking."
                )
            },
            {
                105, new Product(
                    105,
                    "Face Wash Gel",
                    "Beauty & Personal Care",
                    349,
                    50,
                    "Gentle foaming gel with vitamin C for daily skincare routine."
                )
            },
            {
                106, new Product(
                    106,
                    "Digital Thermometer",
                    "Health & Wellness",
                    299,
                    60,
                    "Accurate digital thermometer with fast readings and memory function."
                )
            },
            {
                107, new Product(
                    107,
                    "Self Help Book",
                    "Books & Stationary",
                    599,
                    100,
                    "Transform your habits and life with proven techniques from James Clear."
                )
            },
            {
                108, new Product(
                    108,
                    "Yoga Mat",
                    "Sports & Outdoors",
                    899,
                    35,
                    "Non-slip yoga mat with comfortable cushioning and carrying strap."
                )
            }
        };

        public static List<string> Category = new List<string> { "Electronics", "Fashion", "Home & Kitchen", "Beauty & Personal Care", "Health & Wellness", "Books & Stationary", "Sports & Outdoors" };

        public void AdminPanel()
        {
            E_CommerceInterface _E_CommerceMethods = new E_CommerceMethods();


            while (true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("------------------------------------------- ** Admin Panel ** -----------------------------------------");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("                                            1. Add the Products                                        ");
                Console.WriteLine("                                            2. Update the Product                                      ");
                Console.WriteLine("                                            3. Delete the Product                                      ");
                Console.WriteLine("                                            4. View All the Products                                   ");
                Console.WriteLine("                                            5. View All the Orders                                     ");
                Console.WriteLine("                                            6. Exit                                                    ");
                Console.WriteLine();
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
                        Console.WriteLine("Invalid choice! Choice must not be Zero");
                        Console.ResetColor();
                        goto Choice;
                    }
                    if (choice > 6)
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

                int Product_ID = 0;
                string ProductName = "None";
                string ProductCategory = "None";
                int ProductPrice = 0;
                int Stock = 0;
                string ProductDescription = "None";
                switch (Choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("                           You have selected option '1' to add a new product                           ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                    ProductName:
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter the Product Name : ");
                            Console.ResetColor();
                            string productName = Console.ReadLine();
                            _E_CommerceMethods.isNullString(productName);
                            _E_CommerceMethods.isValidString(productName);
                            ProductName = productName;
                        }
                        catch (IsNullExpection e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ResetColor();
                            goto ProductName;
                        }
                        catch (IsValidStringExpection e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ResetColor();
                            goto ProductName;
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                              -------- Choose the Product Category --------                            ");
                        Console.ResetColor();
                        Console.WriteLine();
                        int sno = 1;
                        foreach (string i in Category)
                        {
                            Console.WriteLine($"                                  {sno}. {i}");
                            sno++;
                        }
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                              ---------------------------------------------");
                        Console.ResetColor();

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
                            ProductCategory = Category[categoryNumber - 1];
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

                    ProductPrice:
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter the Product Price : ");
                            Console.ResetColor();
                            int productPrice = int.Parse(Console.ReadLine());

                            if (productPrice == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Product Price! Product Price must not be Zero");
                                Console.ResetColor();
                                goto ProductPrice;
                            }

                            ProductPrice = productPrice;
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Product Price! Price must not contain characters, symbols, or whitespace");
                            Console.ResetColor();
                            goto ProductPrice;
                        }
                        catch (OverflowException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Product Price! Please Enter the Valid Product Price");
                            Console.ResetColor();
                            goto ProductPrice;
                        }

                    Stock:
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter the Product Stock : ");
                            Console.ResetColor();
                            int stock = int.Parse(Console.ReadLine());

                            if (stock == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Stock! Stock must not be Zero");
                                Console.ResetColor();
                                goto Stock;
                            }

                            Stock = stock;
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Stock! Stock must not contain characters, symbols, or whitespace");
                            Console.ResetColor();
                            goto Stock;
                        }
                        catch (OverflowException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Product Stock! Please Enter the Valid Stock");
                            Console.ResetColor();
                            goto Stock;
                        }

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"                       -------- Enter the Description of {ProductName} --------                       ");
                        Console.ResetColor();
                        Console.WriteLine();
                        ProductDescription = Console.ReadLine();

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"                       --------------------------------------------------------                       ");
                        Console.ResetColor();

                        product_ID++;
                        Product_ID = product_ID;

                        Product products = new Product(Product_ID, ProductName, ProductCategory, ProductPrice, Stock, ProductDescription);

                        products.DisplayProduct(Product_ID, ProductName, ProductCategory, ProductPrice, Stock);

                        ProductDetails.Add(Product_ID, products);
                        Console.WriteLine();
                        break;


                    case 2:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("                          You have selected option '2' to Update the Products                          ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("                                   ------- Here the Products -------                                 ");
                        Console.ResetColor();
                        Console.WriteLine();

                        _E_CommerceMethods.DisplayAllProducts(ProductDetails);

                    Product_ID:
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Enter the Product ID to Update : ");
                            Console.ResetColor();
                            int productId = int.Parse(Console.ReadLine());

                            if (productId == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid ID! Product ID must not be Zero");
                                Console.ResetColor();
                                goto Product_ID;
                            }
                            Product_ID = productId;
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid ID! Input must not contain characters, symbols, or whitespace");
                            Console.ResetColor();
                            goto Product_ID;
                        }
                        catch (OverflowException e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid ID! Please Enter the Valid ID");
                            Console.ResetColor();
                            goto Product_ID;
                        }

                        if (ProductDetails.ContainsKey(Product_ID))
                        {
                            while (true)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("                               ------- Choose an option to Update -------                            ");
                                Console.ResetColor();
                                Console.WriteLine("                                 1. Press '1' to Update the Product Name                             ");
                                Console.WriteLine("                                 2. Press '2' to Update the Product Category                         ");
                                Console.WriteLine("                                 3. Press '3' to Update the Product Price                            ");
                                Console.WriteLine("                                 4. Press '4' to Update the Product Stock                            ");
                                Console.WriteLine("                                 5. Exit                                                             ");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("                               -------------------------------------------                           ");
                                Console.ResetColor();
                                Console.WriteLine();

                            option:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Enter the Option to Update : ");
                                Console.ResetColor();
                                int option = int.Parse(Console.ReadLine());

                                if (option == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid Option! Option must not be Zero. Re-Entet the Option Again");
                                    Console.ResetColor();
                                    goto option;
                                }
                                if (option > 5)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid Option! Option must be between 1 and 6");
                                    Console.ResetColor();
                                    goto option;
                                }


                                if (option == 1)
                                {
                                    string UpdatedProdName = "None";
                                UpdatedProdName:
                                    try
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("Enter the Updated Product Name : ");
                                        Console.ResetColor();
                                        string updatedProdName = Console.ReadLine();
                                        _E_CommerceMethods.isNullString(updatedProdName);
                                        _E_CommerceMethods.isValidString(updatedProdName);
                                        UpdatedProdName = updatedProdName;
                                    }
                                    catch (IsNullExpection e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(e.Message);
                                        Console.ResetColor();
                                        goto UpdatedProdName;
                                    }
                                    catch (IsValidStringExpection e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(e.Message);
                                        Console.ResetColor();
                                        goto UpdatedProdName;
                                    }

                                    if (ProductDetails[Product_ID] is Product p)
                                    {
                                        p.ProductName = UpdatedProdName;
                                    }

                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("Product Name has been Successfully Updated :)");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                }
                                else if (option == 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("                              -------- Choose the Product Category --------                            ");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    int Sno = 1;
                                    foreach (string i in Category)
                                    {
                                        Console.WriteLine($"                                  {Sno}. {i}");
                                        Sno++;
                                    }
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("                              ---------------------------------------------");
                                    Console.ResetColor();

                                UpdatedCategoryNumber:
                                    string UpdatedCategory = "None";
                                    try
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("Enter the Updated Category Number : ");
                                        Console.ResetColor();
                                        int updatedCategoryNumber = int.Parse(Console.ReadLine());

                                        if (updatedCategoryNumber == 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid Category Number! Category Number must not be Zero");
                                            Console.ResetColor();
                                            goto UpdatedCategoryNumber;
                                        }
                                        if (updatedCategoryNumber > 7)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid Category Number! Category Number must be between 1 and 7");
                                            Console.ResetColor();
                                            goto UpdatedCategoryNumber;
                                        }
                                        UpdatedCategory = Category[updatedCategoryNumber - 1];

                                        if (ProductDetails[Product_ID] is Product p)
                                        {
                                            p.ProductCategory = UpdatedCategory;
                                        }
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("Product Category has been Successfully Updated :)");
                                        Console.ResetColor();
                                        Console.WriteLine();
                                    }
                                    catch (FormatException)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid Category Number! Input must not contain characters, symbols, or whitespace");
                                        Console.ResetColor();
                                        goto UpdatedCategoryNumber;
                                    }
                                    catch (OverflowException e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid Category Number! Please Enter the Valid Category Number");
                                        Console.ResetColor();
                                        goto UpdatedCategoryNumber;
                                    }

                                }

                                else if (option == 3)
                                {
                                    int UpdatedProdPrice = 0;
                                UpdatedProdPrice:
                                    try
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("Enter the Updated Product Price : ");
                                        Console.ResetColor();
                                        int updatedProdPrice = int.Parse(Console.ReadLine());

                                        if (updatedProdPrice == 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid Price! Product Price must not be Zero");
                                            Console.ResetColor();
                                            goto UpdatedProdPrice;
                                        }
                                        UpdatedProdPrice = updatedProdPrice;
                                    }
                                    catch (IsNullExpection e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(e.Message);
                                        Console.ResetColor();
                                        goto UpdatedProdPrice;
                                    }
                                    catch (IsValidStringExpection e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(e.Message);
                                        Console.ResetColor();
                                        goto UpdatedProdPrice;
                                    }

                                    if (ProductDetails[Product_ID] is Product p)
                                    {
                                        p.ProductPrice = UpdatedProdPrice;
                                    }

                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("Product Price has been Successfully Updated :)");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                }

                                else if (option == 4)
                                {
                                    int UpdatedProdStock = 0;
                                UpdatedStock:
                                    try
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("Enter the Updated Product Stock : ");
                                        Console.ResetColor();
                                        int updatedProdStock = int.Parse(Console.ReadLine());

                                        if (updatedProdStock == 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid Stock! Product Price must not be Zero");
                                            Console.ResetColor();
                                            goto UpdatedStock;
                                        }
                                        UpdatedProdStock = updatedProdStock;
                                    }
                                    catch (IsNullExpection e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(e.Message);
                                        Console.ResetColor();
                                        goto UpdatedStock;
                                    }
                                    catch (IsValidStringExpection e)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(e.Message);
                                        Console.ResetColor();
                                        goto UpdatedStock;
                                    }

                                    if (ProductDetails[Product_ID] is Product p)
                                    {
                                        p.Stock = UpdatedProdStock;
                                    }

                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("Product Stock has been Successfully Updated :)");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                }

                                else if (option == 5)
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("Thank You...!!");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    break;
                                }
                            }


                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Product ID Not Found !");
                            Console.ResetColor();
                            goto Product_ID;
                        }

                        break;


                    case 3:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("                          You have selected option '3' to Delete thee Products                         ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();


                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("                                   ------- Here the Products -------                                 ");
                        Console.ResetColor();
                        Console.WriteLine();

                        _E_CommerceMethods.DisplayAllProducts(ProductDetails);

                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the Product ID for Delete : ");
                        Console.ResetColor();
                        int ProductID = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        ProductDetails.Remove(ProductID);

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Product ID - {ProductID} has been Successfully Deleted");
                        Console.ResetColor();
                        Console.WriteLine();

                        break;



                    case 4:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("                           You have selected option '4' to View all Products                           ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("                                      Here are all the products                                         ");
                        Console.ResetColor();
                        Console.WriteLine();

                        _E_CommerceMethods.DisplayAllProducts(ProductDetails);

                        break;

                    case 6:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Thank You Admin!!!");
                        Console.ResetColor();
                        Console.WriteLine();

                        break;
                }

                if (Choice == 6)
                {
                    return;
                }

            }
        }
    }
}