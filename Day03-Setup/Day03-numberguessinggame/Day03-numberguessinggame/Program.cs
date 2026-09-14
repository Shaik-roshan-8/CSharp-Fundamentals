using System;
namespace Day03
{
    class Numberguessing
    {
        static void Main(string[] args)
        {
            string? playAgain = "y";
            do
            {
                Random random = new Random();
                int numberToGuess = random.Next(1, 101);
                int userGuess = 0;
                int attempts = 0;
                Console.WriteLine("Welcome to the Number Guessing Game!");
                Console.WriteLine("I have selected a number between 1 and 100. Can you guess it?");
                while (userGuess != numberToGuess)
                {
                    Console.Write("Enter your guess: ");
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out userGuess))
                    { 
                        if (userGuess < numberToGuess)
                        {
                            Console.WriteLine("Too low! Try again.");
                            attempts++;
                        }
                        else if (userGuess > numberToGuess)
                        {
                            Console.WriteLine("Too high! Try again.");
                            attempts++;
                        }
                        else
                        {
                            Console.WriteLine($"Congratulations! You've guessed the number {numberToGuess} in {attempts} attempts.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                }
                Console.WriteLine("Do you want to play again? (y/n)");
                playAgain = Console.ReadLine();
            }

            while (playAgain?.ToLower() == "y");
        }
    }
}
