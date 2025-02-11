
using System.Text.RegularExpressions;
using LenaLearning;

namespace RunApp.Menus
{
    public class WordProcessorMenu
    {
        private WordProcessor wordProcessor = new WordProcessor();

        public void Run()
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();
                Console.WriteLine("\n=== Word Processor ===");
                Console.WriteLine("1. Check the actual text in the processor");
                Console.WriteLine("2. Set new text ");
                Console.WriteLine("3. Count words of the setted text");
                Console.WriteLine("4. Count a specific word ocurrence in the setted text");
                Console.WriteLine("5. Count the number of sentences in the setted text ");
                Console.WriteLine("6. Get character at a choosen position");
                Console.WriteLine("7. Get word at character position");
                Console.WriteLine("8. Get the nth word depending on the number entered ");
                Console.WriteLine("9. Go back");
                Console.WriteLine("10. Exit App");
                Console.Write("\nChoose one option: ");

                string choice = Console.ReadLine();
                choice = Regex.Replace(choice, @"[\s.]", "");

                try
                {
                    switch (choice)
                    {
                        case "1":
                            if (ValidateText())
                            {
                                Console.Clear();
                                Console.WriteLine("\nText present in the processor: ");
                                Console.WriteLine($"{wordProcessor.Text}");
                            }
         
                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("\nEnter new text: ");
                            wordProcessor.Text = Console.ReadLine();
                            Console.WriteLine("Text set sucessfully.");
                            break;
                        case "3":
                            Console.Clear();
                            if (ValidateText())
                            {
                                Console.WriteLine("\nSentence:");
                                Console.WriteLine($"{wordProcessor.Text}\n");
                                Console.WriteLine($"Words count: {wordProcessor.CountWords()}");
                            }
                            break;
                        case "4":
                            Console.Clear();
                            if (ValidateText())
                            {
                                Console.WriteLine("\nSentence:");
                                Console.WriteLine($"'{wordProcessor.Text}'\n");
                                Console.Write("\nEnter word to count: ");
                                string word = Console.ReadLine();
                                Console.WriteLine($"Ocurrences of '{word}': {wordProcessor.CountWordEntry(word)}");
                            }
                            break;
                        case "5":
                            Console.Clear();
                            if (ValidateText())
                            {
                                Console.WriteLine("\nSentence:");
                                Console.WriteLine($"'{wordProcessor.Text}'\n");
                                Console.WriteLine($"Sentences count: {wordProcessor.GetPhraseCount()}");
                            }
                            break;
                        case "6":
                            Console.Clear();
                            if (ValidateText())
                            {
                                Console.WriteLine("\nSentence:");
                                Console.WriteLine($"'{wordProcessor.Text}'\n");
                                Console.Write("Enter character position: ");
                                int position = Int32.Parse(Console.ReadLine());
                                Console.WriteLine($"The character at position {position}");
                                Console.WriteLine($"is '{wordProcessor.GetCharacterAt(position)}'");
                            }
                            break;
                        case "7":
                            Console.Clear();
                            if (ValidateText())
                            {
                                Console.WriteLine("\nSentence:");
                                Console.WriteLine($"'{wordProcessor.Text}'\n");
                                Console.Write("Enter character position: ");
                                int charPosition = Int32.Parse(Console.ReadLine());
                                Console.WriteLine($"The word at character position {charPosition}");
                                Console.WriteLine($"is '{wordProcessor.GetWordAtCharacterPosition(charPosition)}'");
                            }
                            break;
                        case "8":
                            Console.Clear();
                            if (ValidateText())
                            {
                                Console.WriteLine("\nSentence:");
                                Console.WriteLine($"'{wordProcessor.Text}'\n");
                                Console.Write("Enter place of word: ");
                                int place = Int32.Parse(Console.ReadLine());
                                Console.WriteLine($"The word number {place}");
                                Console.WriteLine($"is '{wordProcessor.GetWordByWordPosition(place)}'");
                            }
                            break;
                        case "9":
                            back = true;
                            break;
                        case "10":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("\nInvalid option. Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        private bool ValidateText()
        {
            if (string.IsNullOrEmpty(wordProcessor.Text))
            {
                Console.WriteLine("No text set. Please set a text first");
                return false;
            }
            return true;
        }
    }
}
