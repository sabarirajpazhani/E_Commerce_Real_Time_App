using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using E_Commerce_Console_App_RealTime;

namespace E_Commerce_RealTime_App
{
    class UserPanel
    {
        public int UserId { get; private set; }
        public string UserName { get; private set; }
        public string UserEmail { get; private set; }
        public long UserPhone { get; private set; }
        public string UserPassword { get; private set; }

        public UserPanel(int UserId, string UserName, string UserEmail, long UserPhone, string UserPassword)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.UserEmail = UserEmail;
            this.UserPhone = UserPhone;
            this.UserPassword = UserPassword;
        }

        public void DisplayRegistedUser(int UserId, string UserName, string UserEmail, long UserPhone, string UserPassword)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("                             ------- >> ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Registed User Details ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("<< -------                               ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                     User ID         :");
            Console.ResetColor();
            Console.WriteLine(UserId);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                     User Name       :");
            Console.ResetColor();
            Console.WriteLine(UserName);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                     User Email      :");
            Console.ResetColor();
            Console.WriteLine(UserEmail);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                     User Phone      :");
            Console.ResetColor();
            Console.WriteLine(UserPhone);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("                             -------------------------------------------                               ");
            Console.ResetColor();
            Console.WriteLine();
        }
    }

    class RegisterUser : UserPanel
    {
        public static string userRegisterFilePath = @"D:\FileHandling\E_Commerce\User_Registration.txt";

        public static int userID = 100;

        E_CommerceInterface _E_CommerceMethods = new E_CommerceMethods();

        public RegisterUser() : base(0, "", "", 0, "") { }
        public RegisterUser(int UserId, string UserName, string UserEmail, long UserPhone, string UserPassword) : base(UserId, UserName, UserEmail, UserPhone, UserPassword) { }

        public void Register()
        {
            int UserId = 0;
            string UserName = "None";
            string UserEmail = "None";
            long UserPhone = 0;
            string UserPassword = "None";

        UserName:
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("                                 Enter the User Name       : ");
                Console.ResetColor();
                string userName = Console.ReadLine();
                _E_CommerceMethods.isValidString(userName);
                _E_CommerceMethods.isNullString(userName);

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
                Console.Write("                                 Enter the User Phone No.  : ");
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

            Console.WriteLine();

            foreach (var i in File.ReadAllLines(userRegisterFilePath))
            {
                string[] lines = i.Split(',');
                if (lines[2] == UserEmail && long.Parse(lines[3]) == UserPhone)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("User already exists. Please proceed to user login");
                    Console.ResetColor();

                    Console.WriteLine();
                    Console.WriteLine("Press any Key...");
                    Console.ReadKey(true);
                    return;
                }
                else
                {
                    continue;
                }
            }

        password:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("                                Enter the User Password    : ");
            Console.ResetColor();
            string password = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                Enter the Confirmation Password : ");
            Console.ResetColor();
            string ConfirmationPass = Console.ReadLine();

            if (password == ConfirmationPass)
            {
                UserPassword = ConfirmationPass;

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Successfully Registered  :)");
                Console.ResetColor();
                Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Confirmation password does not match.Please re - enter the password correctly :(");
                Console.ResetColor();
                goto password;
            }




            userID++;
            UserId = userID;


            RegisterUser NewUser = new(UserId, UserName, UserEmail, UserPhone, UserPassword);
            NewUser.DisplayRegistedUser(UserId, UserName, UserEmail, UserPhone, UserPassword);

            string userDetails = $"{UserId},{UserName},{UserEmail},{UserPhone},{UserPassword}";

            File.AppendAllText(userRegisterFilePath, userDetails + Environment.NewLine);


        }
    }
    internal class UserRegistration
    {
        public void UserRegister()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                                -------- ** Welcome User!! ** --------                                ");
            Console.ResetColor();
            Console.WriteLine();

            RegisterUser User = new RegisterUser();
            User.Register();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                                Now you can Login and Order the Products                                ");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}