using System;
using E_Commerce_Console_App_RealTime;

namespace E_Commerce_RealTime_App
{

    public class _Main
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("======================================= ** E - Commerce System ** =====================================");
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("                                            1. Admin Panel                                             ");
                Console.WriteLine("                                            2. User Login                                              ");
                Console.WriteLine("                                            3. User Registraton                                        ");
                Console.WriteLine("                                            4. Exit                                                    ");
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=======================================================================================================");
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

                E_CommerceInterface _E_CommerceMethod = new E_CommerceMethods();

                switch (Choice)
                {
                    case 1:
                        _E_CommerceMethod.AdminLogin();
                        break;
                }

            }






        }
    }
}