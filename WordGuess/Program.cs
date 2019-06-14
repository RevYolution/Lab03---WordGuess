using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

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
                    PlayGame(filePath);
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
                    if (editMenuReturn == 4)
                    {
                        RemoveCharacters(filePath);
                    }
                    if (editMenuReturn == 5)
                    {
                        break;
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
            Console.WriteLine("5: Exit");

            string editMenuChoice = Console.ReadLine();
            int editMenuReturn = Convert.ToInt32(editMenuChoice);

            return editMenuReturn;
        }

        /// <summary>
        /// Populates guessing game with random text line from file.
        /// </summary>
        /// <param name="filePath">Array of strings populated from a text file</param>
        public static void PlayGame(string filePath)
        {
            Console.Clear();
            Console.WriteLine();

            string guessPrompt = "WHO'S THAT CHARACTER?";
            for (int i = 0; i < guessPrompt.Length; i++)
            {
                int printWait = 100;
                Thread.Sleep(printWait);
                Console.Write(guessPrompt[i]);
            }


            string[] charactersForGame = File.ReadAllLines(filePath);
            Random grabRandomNumber = new Random();

            // Populates random word based off of random number.
            int getRandomWord = grabRandomNumber.Next(0, charactersForGame.Length - 1);
            string wordForGame = charactersForGame[getRandomWord];
            //Console.WriteLine($"{wordForGame}");
            // Sets up list for guessed letters
            List<string> letterGuessed = new List<string>();

            // Sets up lines to display on game board for words
            char[] letterArray = wordForGame.ToCharArray();
            char[] lineArray = new char[letterArray.Length];

            for (int i = 0; i < lineArray.Length; i++)
            {
                lineArray[i] = '_';
            }

            bool playingGame = true;

            //while (playingGame)
            //{
            //Console.Clear();
            Console.WriteLine();
            for (int i = 0; i < lineArray.Length; i++)
                {
                    Console.Write($"{lineArray[i]}");
                }
            //}

            Console.WriteLine();
            Console.Write("Guesses made: [");
            foreach (var letter in letterGuessed)
            {
                Console.Write($"{letter} ");
            }
            Console.Write("]");
            Console.WriteLine();

            Console.WriteLine("Guess a letter:");
            string userGuess = Console.ReadLine();

            if (userGuess.Length > 1)
            {
                Console.WriteLine("Only one letter at a time please.");
            }
            else if (userGuess.Length == 1)
            {
                letterGuessed.Add(userGuess);
                char letterToCompare = Convert.ToChar(userGuess);

                //char letterToCompare = char.Parse(letterGuessed);
                for (int i = 0; i < lineArray.Length; i++)
                {
                    if (letterArray[i] == letterToCompare)
                    {
                        Console.WriteLine("BOOM GOT ONE!!");
                        lineArray[i] = letterToCompare;
                    }
                }
            }
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

            string[] testFile = File.ReadAllLines(filePath);
            for (int i = 0; i < testFile.Length; i++)
            {

                Console.WriteLine(testFile[i]);
            }
            Console.WriteLine($"The text was added to the file.");
        }

        public static void RemoveCharacters (string filePath)
        {
            Console.WriteLine("Coming soon");
        }


    }
}
