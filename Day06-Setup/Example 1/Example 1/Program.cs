using System;
namespace Day06
{
    public class BankAccount
    {
        private decimal _balance;
        private static int _accountCounter = 1000;

        public string AccountNumber { get; }
        public string Owner { get; private set; }
        public DateTime openedOn { get; }

        public decimal Balance => _balance;
        public bool IsOverdarwn => _balance < 0;

        public const decimal MinimumOpeningBalance = 500m;

        public BankAccount(string owner, decimal openingbalance)
        {
            if (string.IsNullOrEmpty(owner))
                throw new ArgumentException("owner name is required.", nameof(owner));
            if (openingbalance < MinimumOpeningBalance)
                throw new ArgumentException($"Opening balance must be at least {MinimumOpeningBalance:N2}");

            _accountCounter++;
            AccountNumber = $"AC{_accountCounter}";
            Owner = owner.Trim();
            _balance = openingbalance;
            openedOn = DateTime.Now;
        }

        public BankAccount(string owner) : this(owner, MinimumOpeningBalance) { }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit must be positive");
            _balance += amount;
        }
        public bool TRyWithdraw(decimal amount, out string reason)
        {
            if (amount <= 0)
            {
                reason = "Amount must be positive."; return false;
            }
            if (amount > Balance)
            {
                reason = "Insufficient funds ."; return false;
            }

            _balance -= amount;
            reason = "OK";
            return true;
        }

        public void Rename (string newOwner)
        {
            if (string.IsNullOrWhiteSpace(newOwner))
                throw new ArgumentException("Owner name is required.");
            Owner = newOwner.Trim();
        }
        public override string ToString()
            => $"{AccountNumber}  {Owner,-18}  {_balance,12:N2}";
    }

    class Program
    {
        static void Main()
        {
            var a = new BankAccount("Asha Pandey" , 5000m);
            var b = new BankAccount("Ravi Kumar");

            a.Deposit(2500m);

            if (a.TRyWithdraw(1000m, out string why))
                Console.WriteLine("Withdrawl successful.");
            else 
                Console.WriteLine($"Withdrawl refused : {why}");

            if (!a.TRyWithdraw(9999999m, out why))
                Console.WriteLine($"Withdraw refused : {why}");

            Console.WriteLine(a);
            Console.WriteLine(b);

          


        }
    }
}