using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RunApp.Menus
{
    public class AppMainMenu
    {
        public void Run() //main menu method for the app
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\n=== LenaLearning App ===\n");
                Console.WriteLine("1. Use Fibonacci calculator");
                Console.WriteLine("2. Use word processor");
                Console.WriteLine("3. Exit app");
                Console.Write("\nChoose one option: ");

                string choice = Console.ReadLine(); //user input, user can put 1. or 1 with spaces, regex!

                choice = Regex.Replace(choice, @"[\s.]", "");

                switch (choice)
                {
                    case "1":
                        FibonacciMenu fibonacciMenu = new FibonacciMenu();
                        fibonacciMenu.Run();
                        break;
                    case "2":
                        WordProcessorMenu wordProcessorMenu = new WordProcessorMenu();
                        wordProcessorMenu.Run();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        Console.WriteLine("\nPress Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

    }
}
