using System;
namespace Day03
{
    class ATM
    {
        const int PIN = 1234;
        const decimal StartingBalance = 10000m;
        const int WithdrawMultiple = 100;
        const int MaxAttempts = 3;
        static void Main()
        {
            decimal balance = StartingBalance;
            string transactionHistory = "";
            int attempts = 0;

            while (attempts < MaxAttempts)
            {
                Console.WriteLine("Please enter your PIN:");
                string? enteredPin = Console.ReadLine();

                if (VerifyPin(enteredPin))
                {
                    int userchoice;

                    do
                    {
                        ShowMenu();
                        string? input = Console.ReadLine();

                        if (int.TryParse(input, out userchoice))
                        {
                            switch (userchoice)
                            {
                                case 1:
                                    PrintBalance(balance);
                                    break;
                                case 2:
                                    decimal depositAmount = ReadAmount("Enter deposit amount");
                                    deposit(ref balance, depositAmount);
                                    transactionHistory += $"Amount: {depositAmount} deposited succesfully and new balance is {balance}";
                                    break;
                                case 3:
                                    decimal withdrawAmount = ReadAmount("Enter withdraw amount");
                                    if (TryWithdraw(ref balance, withdrawAmount))
                                    {
                                        transactionHistory += $"Withdrawn: {withdrawAmount}, Balance: {balance}\n";
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine(transactionHistory == "" ? " No Transactions yet" : transactionHistory);
                                    break;
                                case 5:
                                    Console.WriteLine("Thank you. Goodbye!");
                                    break;

                                default:
                                    Console.WriteLine("Invalid choice. Please select 1–5.");
                                    break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            userchoice = 0;
                        }

                    }
                    while (userchoice != 5);

                }
                else
                {
                    Console.WriteLine("Invalid pin try again");
                    attempts++;
                }
            }
            Console.WriteLine("out of attempts");



            static void ShowMenu()
            {
                Console.WriteLine("choose an option 1 . Check balance 2. deposit 3. withdraw 4. transactionhistory 5. exit");
            }
            
            static bool VerifyPin(string entered)
            {
                if (int.TryParse(entered, out int enteredpin)) 
                {
                    return enteredpin == PIN;
                }
                return false;
            }
            static decimal ReadAmount(string prompt)
            {
                Console.WriteLine($"{prompt}");
                string? input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal amount))
                {
                    return amount;
                }
                else
                {
                    Console.WriteLine("Invalid amount");
                    return 0;
                }





            }
            
            static bool TryWithdraw(ref decimal balance, decimal amount)
            {
                if (amount > 0 && amount % WithdrawMultiple == 0 && amount <= balance)
                {
                    balance -= amount;
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid amount must be multiples of 100 and less than balance");
                    return false;
                }

            }
            static void deposit(ref decimal balance, decimal amount)
            {
                if (amount > 0)
                {
                    balance += amount;
                    Console.WriteLine($"deposited successfully and new balance is {balance}");
                }
                else
                {
                    Console.WriteLine("Invalid amount");

                }
            }
            static void PrintBalance(decimal balance)
            {
                Console.WriteLine($"Your available balance is {balance}");
            }

        }
    }
}