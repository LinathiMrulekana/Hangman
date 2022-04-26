using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;
using Hangman.Core.Game;

namespace HangmanGameConsole
{
    internal class Program
    {
       
            static void Main(string[] args)
            {
            
                   ConsoleColor oldColor = Console.ForegroundColor;

                   Console.ForegroundColor = ConsoleColor.Green;
                   Console.SetCursorPosition(10, 2);
                   Console.WriteLine("Welcome to Hangman!!");

                   var hangman = new HangmanGame();
                   hangman.Run();

                   Console.ForegroundColor = oldColor;


                   Console.SetCursorPosition(20, 25);
                   Console.WriteLine("Thank you for playing");
                   Console.ReadLine();
            }
    }       
}
