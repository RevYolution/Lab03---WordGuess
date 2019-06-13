using System;

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

                throw;
            }
        }

        public static void MainMenu()
        {
            while (true)
            {
                int userSelection = MenuSelection();

                if (userSelection == 1)
                {
                    Console.WriteLine("We are doing things");
                }
                if (userSelection == 2)
                {

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
    }
}
