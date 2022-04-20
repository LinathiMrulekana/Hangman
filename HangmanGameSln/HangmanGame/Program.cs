using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;
using Hangman.Core.Game;

namespace HangmanGameConsole
{
    internal class Program
    {
        private static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("+---+");
                Console.WriteLine("o   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("+---+");
                Console.WriteLine("o   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine(" +-----+");
                Console.WriteLine(" o     |");
                Console.WriteLine("/|     |");
                Console.WriteLine("       |");
                Console.WriteLine("     ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine(" +-----+");
                Console.WriteLine(" o     |");
                Console.WriteLine("/ \    |");
                Console.WriteLine("       |");
                Console.WriteLine("     ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine(" +-----+");
                Console.WriteLine(" o     |");
                Console.WriteLine("/ \    |");
                Console.WriteLine("/      |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("  +------+");
                Console.WriteLine(" o      |");
                Console.WriteLine("/|\     |");
                Console.WriteLine("/ \     |");
                Console.WriteLine("   ===");
            }
        }
        private static int printWord(List<char> guessedLettter , string randomWord)
        {
            int counter = 0;
            int rightLetter = 0;
            Console.Write(" ");
            foreach (char c in randomWord)
            {
                if (guessedLettter.Contains(c))
                {
                    Console.WriteLine(c + " ");
                    rightLetter++;
                }
                else
                {
                    Console.WriteLine(" ");
                }
                counter++;
            }
            return rightLetter;
        }
        private static void printLines(string randomWord)
        {
            Console.WriteLine(" ");
            foreach (char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.WriteLine(" ");
            }
        }
            static void Main(string[] args)
            {
            Console.WriteLine("         Welcome to hangman :)       ");
            Console.WriteLine("======================================");

            Random random = new Random();
            List<string> wordDict = new List<string> { "sunflower", "sunrise","groes","howdy"};
            int index = random.Next(wordDict.Count);
            string randomWord = wordDict[index];            

            int lengthofwordtoGuess = randomWord.Length;
            int amountoftimeWrong = 0;
            List<char> currentLetterGuessed = new List<char>();
            int currentLettersRight = 0;

            while (amountoftimeWrong != 6 && currentLettersRight != lengthofwordtoGuess)
            {
                Console.WriteLine("Letters guessed so far: ");
                foreach (char letter in currentLetterGuessed)
                {
                    Console.WriteLine(letter + " ");
                }
                Console.WriteLine(" Guess a letter: ");
                char letterGuessed = Console.ReadLine()[0];
                if (currentLetterGuessed.Contains(letterGuessed))
                {
                    Console.WriteLine("Already guessed this letter");
                    printHangman(amountoftimeWrong);
                    currentLettersRight = printWord(currentLetterGuessed , randomWord);
                    printLines(randomWord);
                }
                else
                {
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++) { if (letterGuessed == randomWord[i]) { right = true; } }
                    if (right)
                    {
                        printHangman(amountoftimeWrong);
                        currentLetterGuessed.Add(letterGuessed);
                        currentLettersRight = printWord(currentLetterGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    else
                    {
                        amountoftimeWrong++;
                        currentLetterGuessed.Add(letterGuessed);
                        printHangman(amountoftimeWrong);
                        currentLettersRight = printWord(currentLetterGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }

            }
            Console.WriteLine("GAME OVER   :)");

                /*   ConsoleColor oldColor = Console.ForegroundColor;

                   Console.ForegroundColor = ConsoleColor.Green;
                   Console.SetCursorPosition(10, 2);
                   Console.Write("Welcome to Hangman!!");

                   var hangman = new HangmanGame();
                   hangman.Run();

                   Console.ForegroundColor = oldColor;


                   Console.SetCursorPosition(20, 25);
                   Console.WriteLine("Thank you for playing");
                   Console.ReadLine();*/
            }
    }       
}
