using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using E_Commerce_RealTime_App;
using E_Commerce_RealTime_App.Exceptions;

namespace E_Commerce_Console_App_RealTime
{
    internal interface E_CommerceInterface
    {
        void AdminLogin();
        void isNullString(string student_Name);
        void isValidString(string student_Name);
        void DisplayAllProducts(Hashtable ProductDetails);
    }

    public class E_CommerceMethods : E_CommerceInterface
    {
        public void isNullString(string student_Name)
        {
            if (string.IsNullOrWhiteSpace(student_Name))
            {
                throw new IsNullExpection("Name cannot be Empty");
            }
        }

        public void isValidString(string student_Name)
        {
            if (!Regex.IsMatch(student_Name, @"^[a-zA-Z .]+$"))
            {
                throw new IsValidStringExpection("Name must contains alphabets only not number and special characters");
            }
        }

        public void DisplayAllProducts(Hashtable ProductDetails)
        {
            var SortedProducts = ProductDetails.Cast<DictionaryEntry>().OrderBy(x => x.Key);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine(
                $"{"Product ID",-15}" +
                $"{"Product Name",-25}" +
                $"{"Product Category",-25}" +
                $"{"Product Price",-20}" +
                $"{"Product Stock",-15}"
            );
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.ResetColor();

            foreach (DictionaryEntry i in SortedProducts)
            {
                var _Product = (Product)i.Value;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{_Product.Product_ID,-15}");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{_Product.ProductName,-25}");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{_Product.ProductCategory,-25}");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{_Product.ProductPrice,-20}");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{_Product.Stock,-15}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

        }

        public void AdminLogin()
        {
            string AdminFilePath = @"D:\File_Handling\E-Commerce\AdminAuth.txt";


            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                                 --------->> Welcome Admin <<---------                                 ");
            Console.ResetColor();
            Console.WriteLine();
        AdminUserName:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter the User Admin Name : ");
            Console.ResetColor();
            string AdminUserName = Console.ReadLine();


            if (File.Exists(AdminFilePath))
            {
                foreach (string i in File.ReadAllLines(AdminFilePath))
                {
                    string[] admin = i.Split(',');
                    if (admin[0] == AdminUserName)
                    {
                    Password:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter Admin Password : ");
                        Console.ResetColor();

                        string password = Console.ReadLine();

                        if (admin[1] == password)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Authorized :)");
                            Console.ResetColor();

                            Admin _admin = new Admin();
                            _admin.AdminPanel();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Password! Please Enter the Valid Password");
                            Console.ResetColor();
                            goto Password;
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Admin User Name. Enter the Correct Admin User Name ");
                        Console.ResetColor();
                        goto AdminUserName;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The admin database is disconnected.Please verify the path and reconnect");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}

