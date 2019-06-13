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
            string filePath = "../TestFile.txt";
            while (true)
            {
                int userSelection = MenuSelection();

                if (userSelection == 1)
                {
                    Console.WriteLine("We are doing things");
                }
                if (userSelection == 2)
                {
                    int editMenuReturn = EditMenu();

                    if (editMenuReturn == 1)
                    {
                        MenuSelection();
                    }
                    if (editMenuReturn == 2)
                    {
                        ViewCharacters(filePath);
                    }
                    if (editMenuReturn == 3)
                    {
                        AddCharacters(filePath);
                    }
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

        public static int EditMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1: Main Menu");
            Console.WriteLine("2: View Harry Potter Characters");
            Console.WriteLine("3: Add A Character");
            Console.WriteLine("4: Delete A Character");

            string editMenuChoice = Console.ReadLine();
            int editMenuReturn = Convert.ToInt32(editMenuChoice);

            return editMenuReturn;
        }

        public static void ViewCharacters(string filePath)
        {

            string[] testFile = File.ReadAllLines(filePath);
            for (int i = 0; i < testFile.Length; i++)
            {

                Console.WriteLine(testFile[i]);
            }
        }

        public static void AddCharacters(string filePath)
        {
            string[] testAdd = { "Jon Rice", "Alex Oleszko" };
            File.AppendAllLines(filePath, testAdd);
            Console.WriteLine($"The text: {testAdd} was added to the file.");
        }


        static void FileAppendText(string path)
        {
            string[] words = {
                "to think of many things!",
                "of ships and shoes and ceiling wax",
                "and cabbages and kings!"
            };
            File.AppendAllLines(path, words);

            string phrase = "Cat in the Hat!";
            File.AppendAllText(path, phrase);
        }
    }
}
