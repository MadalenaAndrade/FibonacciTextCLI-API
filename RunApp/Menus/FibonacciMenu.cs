using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LenaLearning;

namespace RunApp.Menus
{
    public class FibonacciMenu
    {
        private Fibonacci fibonacci = new Fibonacci();

        public void Run()
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();
                Console.WriteLine("\n=== Fibonacci calculator ===\n");
                Console.WriteLine("1. Calculate the Fibonacci number");
                Console.WriteLine("2. Calculate Fibonacci sequence up to n-th number");
                Console.WriteLine("3. Calculate Fibonacci sequence between two n numbers");
                Console.WriteLine("4. Go back");
                Console.WriteLine("5. Exit App");
                Console.Write("\nChoose one option: ");

                string choice = Console.ReadLine();
                choice = Regex.Replace(choice, @"[\s.]", "");

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            FibonacciNumberCalculator();
                            break;
                        case "2":
                            Console.Clear();
                            FibonacciSequenceUpToCalculator();
                            break;
                        case "3":
                            Console.Clear();
                            FibonacciSequenceBetweenCalculator();
                            break;
                        case "4":
                            back = true;
                            break;
                        case "5":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("\nInvalid option. Try again.");
                            Console.WriteLine("\nPress Enter to continue...");
                            Console.ReadLine();
                            break;

                    }
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine($"Error: {ex.Message}"); 
                }
            }
        }

        //submethods
        private void FibonacciNumberCalculator()
        {
            while (true)
            {
                Console.Write("\nEnter a positive integer to calculate the Fibonacci number (type 'r' to return or 'e' to exit app): ");
                
                string userInput = Console.ReadLine();
                if (userInput.ToUpper() == "R")
                {
                    break;
                }

                if (userInput.ToUpper() == "E")
                {
                    Environment.Exit(0);
                }

                Console.WriteLine();

                try
                {
                    int n = Int32.Parse(userInput);
                    Console.WriteLine($"The Fibonacci number of {n} is {fibonacci.GetFibonacciNumberOf(n)}");
                }
                catch (MyException ex) 
                { 
                    Console.WriteLine($"Error: {ex.Message}"); 
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine($"criticar error: {ex.Message}");
                }
                
            }
        }

        private void FibonacciSequenceUpToCalculator()
        {
            while (true)
            {
                Console.Write("\nEnter a positive integer to calculate the Fibonacci sequence up to it (type 'r' to return or 'e' to exit app): ");

                string userInput = Console.ReadLine();
                if (userInput.ToUpper() == "R")
                {
                    break;
                }

                if (userInput.ToUpper() == "E")
                {
                    Environment.Exit(0);
                }

                Console.WriteLine();

                try
                {
                    int n = Int32.Parse(userInput);
                    Console.WriteLine($"Fibonacci numbers up to {n}:");
                    Console.WriteLine($"{string.Join(" | ", fibonacci.CalcFibonacciUpTo(n))}");
                }
                catch (MyException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"criticar error: {ex.Message}");
                }
            }
        }

        private void FibonacciSequenceBetweenCalculator()
        {
            while (true)
            {
                Console.WriteLine("\nEnter two positive integer to calculate the Fibonacci sequence between them (type 'r' to return or 'e' to exit app): ");
                Console.Write("Start number: ");

                string startInput = Console.ReadLine();

                Console.WriteLine();
                if (startInput.ToUpper() == "R")
                {
                    break;
                }

                if (startInput.ToUpper() == "E")
                {
                    Environment.Exit(0);
                }

                Console.Write("End number: ");
                string endInput = Console.ReadLine();

                Console.WriteLine();
                if (endInput.ToUpper() == "R")
                {
                    break;
                }

                if (endInput.ToUpper() == "E")
                {
                    Environment.Exit(0);
                }

                Console.WriteLine();

                try
                {
                    int start = Int32.Parse(startInput);
                    int end = Int32.Parse(endInput);
                    Console.WriteLine($"Fibonacci numbers between {start} and {end}:");
                    Console.WriteLine($"{string.Join(" | ", fibonacci.CalcFibonacciBetween(start, end))}");
                }
                catch (MyException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"criticar error: {ex.Message}");
                }
            }
        }
    }
}
