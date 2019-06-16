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

            string guessPrompt = "GUESS THE HARRY POTTER CHARACTER?";
            for (int i = 0; i < guessPrompt.Length; i++)
            {
                int printWait = 100;
                Thread.Sleep(printWait);
                Console.Write(guessPrompt[i]);
            }

            int wait = 1500;
            Thread.Sleep(wait);

            string[] charactersForGame = File.ReadAllLines(filePath);
            Random grabRandomNumber = new Random();

            // Populates random word based off of random number.
            int getRandomWord = grabRandomNumber.Next(0, charactersForGame.Length - 1);
            string wordForGame = charactersForGame[getRandomWord].ToUpper();

            // Sets up list for guessed letters
            List<string> letterGuessed = new List<string>();

            // Sets up lines to display on game board for words
            char[] letterArray = wordForGame.ToCharArray();
            char[] lineArray = new char[letterArray.Length];

            for (int i = 0; i < lineArray.Length; i++)
            {
                lineArray[i] = '_';
            }

            // Game Play Logic
            bool playingGame = true;

            while (playingGame)
            {
                Console.Clear();
                    Console.WriteLine("CHARACTER NAME");
                for (int i = 0; i < lineArray.Length; i++)
                    {
                        Console.Write($"{lineArray[i]}");
                    }
            

                Console.WriteLine();
                Console.Write("Guesses made: [");
                foreach (var letter in letterGuessed)
                {
                    Console.Write($"{letter} ");
                }
                Console.Write("]");
                Console.WriteLine();

                Console.WriteLine("Guess a letter:");
                string userGuess = Console.ReadLine().ToUpper();

                if (userGuess.Length > 1)
                {
                    Console.WriteLine("Only one letter at a time please.");
                }
                // Compare input letter to hidden word
                else if (userGuess.Length == 1)
                {
                    letterGuessed.Add(userGuess);
                    char letterToCompare = Convert.ToChar(userGuess);

                    for (int i = 0; i < lineArray.Length; i++)
                    {
                        if (letterArray[i] == letterToCompare)
                        {
                            Console.WriteLine("BOOM GOT ONE!!");
                            lineArray[i] = letterToCompare;
                        }
                    }
                }
                Thread.Sleep(wait);

                // Checks array for any '_', ends game if none are present. 
                for (int i = 0; i < lineArray.Length; i++)
                {
                    string completeWordCheck = new string(lineArray);
                    if (!completeWordCheck.Contains('_'))
                    {
                        playingGame = false;
                    }
                }
            }
            if (!playingGame)
            {
                Console.Clear();
                string wonGame = "YOU GOT IT!?!";
                for (int i = 0; i < wonGame.Length; i++)
                {
                    int printWait = 100;
                    Thread.Sleep(printWait);
                    Console.Write(wonGame[i]);
                }
                Console.WriteLine();
                Console.Write($"{wordForGame}");
                string wonImage = @"                                        
                                         _ __
        ___                             | '  \
   ___  \ /  ___         ,'\_           | .-. \        /|
   \ /  | |,'__ \  ,'\_  |   \          | | | |      ,' |_   /|
 _ | |  | |\/  \ \ |   \ | |\_|    _    | |_| |   _ '-. .-',' |_   _
// | |  | |____| | | |\_|| |__    //    |     | ,'_`. | | '-. .-',' `. ,'\_
\\_| |_,' .-, _  | | |   | |\ \  //    .| |\_/ | / \ || |   | | / |\  \|   \
 `-. .-'| |/ / | | | |   | | \ \//     |  |    | | | || |   | | | |_\ || |\_|
   | |  | || \_| | | |   /_\  \ /      | |`    | | | || |   | | | .---'| |
   | |  | |\___,_\ /_\ _      //       | |     | \_/ || |   | | | |  /\| |
   /_\  | |           //_____//       .||`      `._,' | |   | | \ `-' /| |
        /_\           `------'        \ |              `.\  | |  `._,' /_\
                                       \|                    `.\                
";
                Console.WriteLine(wonImage);

            }
        }

        public static bool AddToFile(string userAdd)
        {
            string filePath = "../TestFile.txt";

            if (File.Exists(filePath))
            {
                string[] fileCharacters = File.ReadAllLines(filePath);
                for (int i = 0; i < fileCharacters.Length; i++)
                {
                    if (fileCharacters[i] == userAdd)
                    {
                        return false;
                    }
                }
            }
            using (StreamWriter w = File.AppendText(filePath))
            {
                w.WriteLine(userAdd);
            }
            return true;
        }



        /// <summary>
        /// View text file contents.
        /// </summary>
        /// <param name="filePath">Array of strings populated from a text file</param>
        public static void ViewCharacters(string filePath)
        {

            string[] testFile = File.ReadAllLines(filePath);
            for (int i = 0; i < testFile.Length; i++)
            {

                Console.WriteLine(testFile[i]);
            }
        }

        /// <summary>
        /// Add new lines of text to file for guessing game.
        /// </summary>
        /// <param name="filePath">Array of strings populated from a text file</param>
        public static void AddCharacters(string filePath)
        {
            Console.Clear();
            Console.WriteLine("Here are the current characters in the game:");
            Console.WriteLine();
            string[] testFile = File.ReadAllLines(filePath);
            for (int i = 0; i < testFile.Length; i++)
            {

                Console.WriteLine(testFile[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Who would you like to add?");
            string userAdd = Console.ReadLine();
            AddToFile(userAdd);


            Console.WriteLine($"The character was added to the file.");
        }

        /// <summary>
        /// Remove lines of text from file to no longer allow in guessing game.
        /// </summary>
        /// <param name="filePath">Array of strings populated from a text file</param>
        public static void RemoveCharacters (string filePath)
        {
            Console.WriteLine("Coming soon");
        }


    }
}
