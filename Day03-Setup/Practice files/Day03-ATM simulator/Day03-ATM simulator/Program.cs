using System;
using System.Net.NetworkInformation;
namespace Day03
{
    class ATMsimulator
    {
        public static void Main(string[] args)
        {
            decimal Balance = 10000m;
            int securedPin = 1234;
            int userchoice = 0;
            int attempts = 0;
            decimal depositamount   = 0m;
            decimal amount = 0m;
            int pin = 0;
            decimal amounttowithdraw = 0;
            string transactionhistory = ($"total amount = {Balance} , amount deposited = {depositamount}, amount withdrwan = {amounttowithdraw}");
           

            do
            {

                Console.WriteLine("Enter your pin");
                string inputPin = Console.ReadLine();
                if (int.TryParse(inputPin, out pin))
                {
                    if (securedPin == pin )
                    {
                        Console.WriteLine("Hello please select the options below");
                        Console.WriteLine("1.Chekbalance 2.deposit 3. withdraw  4.viewtransactionhistory 5.exit");

                        string input = Console.ReadLine();
                        int.TryParse(input, out userchoice);

                        if(userchoice == 1)
                        {
                            Console.WriteLine($"Your avaliable balance is {Balance}");
                        }
                        else if (userchoice == 2)
                        {
                            Console.WriteLine("Enter deposit amount");
                            string amounttodeposit = Console.ReadLine();
                            if (decimal.TryParse(amounttodeposit, out amount) &&  amount!= 0)
                            {
                                Balance = Balance + amount;
                                Console.WriteLine($"Amount deposited succesfully and your avalaible balance is {Balance}");
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount");
                            }   
                        }
                        else if ( userchoice == 3 )
                        {
                            Console.WriteLine("Enter withdraw amount");
                            string withdrawInput = Console.ReadLine();
                            if (decimal.TryParse(withdrawInput, out amounttowithdraw) && amounttowithdraw != 0 && amounttowithdraw % 100 == 0 && amounttowithdraw < Balance)
                            {
                                Balance = Balance - amounttowithdraw;
                                Console.WriteLine($"Amount withdrawl succesful and your avalaible balance is {Balance}");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input");
                            }
                        }

                        if (!int.TryParse(input, out userchoice))
                        {
                            Console.WriteLine("Enter valid input");
                        }
                        else if (userchoice == 0)
                        {
                            Console.WriteLine("Enter valid input");
                        }
                        else if (userchoice <= 0)
                        {
                            Console.WriteLine("Enter valid input");
                        }
                        else if (userchoice < 0 || userchoice > 5)
                        {
                            Console.WriteLine("Enter valid input");
                        }
                        else
                        {
                            Console.WriteLine($"you selected {userchoice}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your pin is incorrect");
                        attempts++;

                    }

                }
            } while (attempts < 3);
            Console.WriteLine("Out of attempts");



        }    
    }
}