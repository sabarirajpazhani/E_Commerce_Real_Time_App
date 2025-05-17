using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using E_Commerce_RealTime_App;
using E_Commerce_RealTime_App.Exceptions;

namespace E_Commerce_Console_App_RealTime
{
    internal interface E_CommerceInterface
    {
        void AdminLogin();
        void UserRegistration();
        void UserLogin();
        void isNullString(string student_Name);
        void isValidString(string student_Name);
        void DisplayAllProducts(Hashtable ProductDetails);
        void IsValidEmail(string userEmail);
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

        public void IsValidEmail(string userEmail)
        {
            if (!Regex.IsMatch(userEmail, @"^[a-zA-Z0-9._%+-]+@gmail.com$"))
            {
                throw new Exceptions("\"Invalid email format. Please enter a valid email address like 'example@domain.com' ");
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
            string AdminFilePath = @"D:\FileHandling\E_Commerce\Admin.txt";


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

        public void UserRegistration()
        {
            UserRegistration UserRegister = new UserRegistration();
            UserRegister.UserRegister();
        }

        public void UserLogin()
        {

            string userFilePath = @"D:\FileHandling\E_Commerce\User_Registration.txt";

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                               --------->> User Login Portal <<---------                               ");
            Console.ResetColor();
            Console.WriteLine();

            string UserName = "None";
            string UserEmail = "None";
            string UserPassword = "None";
        UserName:
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("                                 Enter the User Name       : ");
                Console.ResetColor();
                string userName = Console.ReadLine();
                isValidString(userName);
                isNullString(userName);

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
                Console.Write("                                 Enter the User Email      : ");
                Console.ResetColor();
                string userEmail = Console.ReadLine();
                IsValidEmail(userEmail);
                isNullString(userEmail);
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

        UserPassword:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("                                 Enter the User Password   : ");
            Console.ResetColor();
            UserPassword = Console.ReadLine();


            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                               -----------------------------------------                               ");
            Console.ResetColor();
            Console.WriteLine();

            bool userFound = false;
            bool passwordCorrect = false;

            foreach (var i in File.ReadAllLines(userFilePath))
            {
                string[] dataAuth = i.Split(',');

                if (dataAuth[1] == UserName && dataAuth[2] == UserEmail)
                {
                    userFound = true;

                    if (dataAuth[4] == UserPassword)
                    {
                        passwordCorrect = true;
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Authorized.....!!");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"                          ----------- ** Welcome {UserName} ! ** -----------                           ");
                        Console.ResetColor();
                        Console.WriteLine();

                        User user = new User();
                        user.UserProduct(UserName, UserEmail);


                        break;
                    }
                }
            }

            if (!userFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User Not Found! Please register before logging in.");
                Console.ResetColor();
                goto UserName;
            }
            else if (!passwordCorrect)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect Password! Please try again.");
                Console.ResetColor();
                goto UserPassword;
            }

        }
    }
}