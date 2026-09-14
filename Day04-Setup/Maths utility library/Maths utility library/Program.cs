using System;
namespace Day04
{
    class PrimeNumbers
    {
        static void Main()
        {
            Console.WriteLine(IsPrime(7));
            Console.WriteLine(Factorial(5));
            Console.WriteLine(Gcd(48,18));
            Console.WriteLine(palindrome(121));
            Console.WriteLine(reversedigit(12345));
            Console.WriteLine(Sumofdigits(123456));
        }
        /// <summary>
        /// To find a number is prime or not
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static bool IsPrime(int number)
        {
            if(number < 2) 
                return false;
            if(number == 2)
                return true;

            for(int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
                
            }
            return true;

                    
           
        }
        /// <summary>
        /// To find the factorial of the number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static int Factorial(int number)
        {
            int result = 1;
            for ( int i = 1; i <= number ; i++)
            {
                result *= i;
            }
            return result;
        }
        /// <summary>
        /// To find the GCD of numbers
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        static int Gcd(int number1, int number2)
        {
            while (number2 != 0)
            {
                int remainder = number1 % number2;
                number1 = number2;
                number2 = remainder;
            }
            return number1;

        }
        /// <summary>
        /// To find LCM of numbers
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        static int lcm(int number1 , int number2)
        {
            int lcm = number1 * number2 / Gcd(number1, number2);
            return lcm;
        }
        /// <summary>
        /// To find if the number is palindrome or not 
        /// </summary>
        /// <param name="number1"></param>
        /// <returns></returns>
        static bool palindrome(int number1)
        {
            int reversed = 0;
            int original = number1;
            while (number1>0)
            {
                int digit = number1 % 10; // to get last digit
                reversed = reversed*10 + digit; // to shift digits to left and add digit
                number1 = number1 / 10; // removes last digit
            }
            return reversed == original ;
        }
        /// <summary>
        /// To reverse a number
        /// </summary>
        /// <param name="number1"></param>
        /// <returns></returns>
        static int reversedigit(int number1)
        {
            int reversed = 0;
            while (number1 >0)
            {
                int digit = number1 % 10;
                reversed = reversed * 10 + digit;
                number1 = number1 / 10;
            }
            return reversed;

        }
        /// <summary>
        /// To find the sum of digits in a number
        /// </summary>
        /// <param name="number1"></param>
        /// <returns></returns>
        static int Sumofdigits(int number1)
        {
            int sum = 0;
            while (number1 >0)
            {
                int digit = number1 % 10;
                sum+= digit;
                number1 = number1 / 10;
            }
            return sum;
        }

           
            


   

    }
}