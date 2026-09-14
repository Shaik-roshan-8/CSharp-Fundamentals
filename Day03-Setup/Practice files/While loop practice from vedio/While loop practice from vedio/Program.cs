using System;

namespace Day03
{
    class whilepractice
    {
        static void Main(String[] args)
        {
            string user = "roshan";
            string guessuser = "";
            int guesscount = 0;
            int guesslimit = 3;
            bool outofguesses = false;

            while (guessuser != user && !outofguesses)
            {
                if (guesscount < guesslimit)
                {
                    Console.WriteLine("Enter your username: ");
                    guessuser = Console.ReadLine();
                    guesscount++;
                }
                else
                {
                    outofguesses = true;

                }
            }

                if(outofguesses)
                {
                    Console.WriteLine("You are out of guesses");
                }
                else
                {
                    Console.WriteLine("You are logged in");
                }

        }
    }
}