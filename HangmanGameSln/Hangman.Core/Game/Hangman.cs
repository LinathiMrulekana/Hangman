using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;

        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
        }

        public void Run()
        {

            string[] names = { "bees", "monkey", "cobra", "beautifull", "cute", "earth", "mars", "classes", "nine", "one", "house", "life", "bored", "me", "none" };
           Console.WriteLine("There are "+names.Length+" names");

            int livesLeft = 6;

            Random random = new Random();
            int guessIndex = random.Next(names.Length);

            string wordToGuess = names[guessIndex];

            string guessProgress = string.Empty;

            for(int i = 0; i < wordToGuess.Length; i++)
            {
                guessProgress = guessProgress + "_";
            }


            while (true)
            {

                _renderer.Render(5, 5, livesLeft);

                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Your current guess: ");
                Console.WriteLine(guessProgress);
                Console.SetCursorPosition(0, 15);

                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("What is your next guess: ");
                string nextGuess = Console.ReadLine();

                char[] guessProgressArray = guessProgress.ToCharArray();

                bool correctGuess = false;

                for (int index = 0; index < wordToGuess.Length; index++)
                {
                    if (wordToGuess[index] == nextGuess[0] && livesLeft != 0)
                    {
                        guessProgressArray[index] = wordToGuess[index];
                        correctGuess = true;
                        Console.WriteLine("YOU WIN");
                        
                    }
                }
                guessProgress = new string(guessProgressArray);

                if (!correctGuess)
                {
                    livesLeft--;
                    
                }
                if (livesLeft == 0)
                {
                    Console.WriteLine("YOU LOSE");
                }
            }
            
        }

    }
}
