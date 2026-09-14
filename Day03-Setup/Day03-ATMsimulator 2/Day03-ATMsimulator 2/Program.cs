using System;
using System.ComponentModel.Design;
namespace Day03
{
    class ATM
    {
        static void Main()
        {
            decimal balance = 10000m;
            int pin = 1234;
            int attempts = 0;
            int inputpinint = 0;
            int userchoice = 0;
            decimal amounttodeposit = 0m;
            decimal amounttowithdraw = 0m;
            string transactionhistory = "";
            do
            {
                Console.WriteLine("Please enter your pin");
                string? inputpin = Console.ReadLine();
                if (int.TryParse(inputpin, out inputpinint) && inputpinint == pin)
                {
                    Console.WriteLine("choose an option 1 . Check balance 2. deposit 3. withdraw 4. transactionhistory 5. exit");
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out userchoice) && userchoice <= 5 && userchoice > 0 )
                    {
                        switch (userchoice)
                        {
                            case 1:
                                Console.WriteLine($"Your available balance is {balance}");
                                break;

                            case 2:
                                Console.WriteLine("Enter an amount to deposit");
                                string? d= Console.ReadLine();
                                if (Decimal.TryParse(d, out amounttodeposit) && amounttodeposit != 0)
                                {
                                    balance = balance + amounttodeposit;
                                    transactionhistory += ($"Deposited: {amounttodeposit} , Balance: {balance}\n");
                                    Console.WriteLine($"Deposited succesfully available balance is {balance}");
                                }
                                else
                                    Console.WriteLine("Invalid input");
                                break;

                            case 3:
                                Console.WriteLine("Enter amount to withdraw");
                                string? w = Console.ReadLine();
                                if (Decimal.TryParse(w, out amounttowithdraw) && amounttowithdraw != 0 && amounttowithdraw % 100 == 0 && amounttowithdraw < balance)
                                {
                                    balance = balance - amounttowithdraw;
                                    transactionhistory += ($"withdrwan  : {amounttowithdraw}   , balance : {balance}\n");
                                    Console.WriteLine($"Amount withdrawn succes and your available balance is {balance}");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input Enter in multiples of 100");
                                }
                                break;
                             case 4 :
                                Console.WriteLine(transactionhistory == "" ? "You do not have collections yet" : transactionhistory);
                                break;
                            case 5 :
                                Console.WriteLine("Thankyou");
                                    return;




                            }
                            
                    }
                    else
                    {
                        Console.WriteLine("Invalid input select options from 1 to 5 "); 
                        return;

                    }
                }
                else
                {
                    Console.WriteLine("Invalid Pin please try again");
                    attempts++;
                }
                

               

            }
            while (attempts < 3);
            Console.WriteLine("out of attempts");

        }
    }
}