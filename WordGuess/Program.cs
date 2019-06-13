using System;
using System.IO;

namespace WordGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MainMenu();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Thank you for playing. See you next time.");
            }
        }

        public static void MainMenu()
        {
            string filePath = "/TestFile.txt";
            while (true)
            {
                int userSelection = MenuSelection();

                if (userSelection == 1)
                {
                    Console.WriteLine("We are doing things");
                }
                if (userSelection == 2)
                {
                    EditMenu(filePath);
                }
                if (userSelection == 3)
                {
                    break;
                }
            }
        }

        public static int MenuSelection()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1: Play the Harry Potter Word Guess Game");
            Console.WriteLine("2: Edit Menu");
            Console.WriteLine("3: Exit");

            string userChoice = Console.ReadLine();
            int choiceNumber = Convert.ToInt32(userChoice);

            return choiceNumber;
        }

        public static void EditMenu(string filePath)
        {
            string[] testFile = File.ReadAllLines(filePath);
            for (int i = 0; i < testFile.Length; i++)
            {
                Console.WriteLine(testFile[i]);
            }
        }
    }
}
