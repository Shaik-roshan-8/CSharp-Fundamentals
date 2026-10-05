using System;
namespace Day07
{
    class Program
    {
        public static void Main()
        {
            IPaymentMethod[] methods = new IPaymentMethod[]
            {
                new CreditCardPayment("1234567812345678", new DateOnly(2024, 6, 12)),
                new UpiPayment("user@upi"),
                new NetBanking("1234567890123456", "SBIN0001234"),
                new CashOnDelivery()
            };

            PaymentProcessor processor = new PaymentProcessor();
            foreach (var method in methods)
            {
                processor.ProcessPayment(method, 1000m);
            }
        }


        interface IPaymentMethod
        {
            public bool ProcessPayment(decimal amount, out string reference);
            public string Displayname { get; }

        }
        public abstract class OnlinePayment : IPaymentMethod
        {
            public abstract bool ProcessPayment(decimal amount, out string reference);
            public abstract string Displayname { get; }

            public virtual void ApplyTransactionfee(double amount)
            {
                double fee = 0.02;
                double transactionFee = amount * fee;
                amount = amount - transactionFee;
            }
            public virtual string GenerateReference()
            {
                return Guid.NewGuid().ToString();
            }

        }
        class CreditCardPayment : OnlinePayment
        {
            public override string Displayname => "Credit Card Payment";
            private string cardNumber;
            private DateOnly expirydate;

            public CreditCardPayment(string cardNumber, DateOnly expirydate)
            {
                if (string.IsNullOrWhiteSpace(cardNumber))
                {
                    throw new ArgumentException("Card number cannot be null or empty.", nameof(cardNumber));
                }
                if (expirydate == DateOnly.MinValue)
                {
                    throw new ArgumentException("Expiry date cannot be null or empty.", nameof(expirydate));
                }
                if (cardNumber.Length != 16)
                {
                    throw new ArgumentException("Invalid card number format.", nameof(cardNumber));
                }
                this.cardNumber = cardNumber;
                this.expirydate = expirydate;
            }
            public override bool ProcessPayment(decimal amount, out string reference)
            {
                reference = GenerateReference();
                ApplyTransactionfee((double)amount);
                return true;
            }

        }
        class UpiPayment : OnlinePayment
        {
            public override string Displayname => "UPI Payment";
            private string upiId;
            public UpiPayment(string upiId)
            {
                if (upiId.Contains("@") == false || upiId.Count(c => c == '@') != 1 || upiId.StartsWith("@") || upiId.EndsWith("@"))
                {
                    throw new ArgumentException("Invalid UPI ID format.", nameof(upiId));
                }
                if (string.IsNullOrWhiteSpace(upiId))
                {
                    throw new ArgumentException("UPI ID cannot be null or empty.", nameof(upiId));
                }

                this.upiId = upiId;
            }
            public override bool ProcessPayment(decimal amount, out string reference)
            {
                reference = GenerateReference();
                ApplyTransactionfee((double)amount);
                return true;
            }
        }
        class NetBanking : OnlinePayment
        {
            public override string Displayname => "Net Banking Payment";
            private string accountNumber;
            private string ifscCode;
            public NetBanking(string accountNumber, string ifscCode)
            {
                if (string.IsNullOrWhiteSpace(accountNumber))
                {
                    throw new ArgumentException("Account number cannot be null or empty.", nameof(accountNumber));
                }
                if (string.IsNullOrWhiteSpace(ifscCode))
                {
                    throw new ArgumentException("IFSC code cannot be null or empty.", nameof(ifscCode));
                }
                if (accountNumber.Length < 9 || accountNumber.Length > 18)
                {
                    throw new ArgumentException("Invalid account number format.", nameof(accountNumber));
                }
                if (ifscCode.Length != 11 || !ifscCode.All(c => char.IsLetterOrDigit(c)))
                {
                    throw new ArgumentException("Invalid IFSC code format.", nameof(ifscCode));
                }
                this.accountNumber = accountNumber;
                this.ifscCode = ifscCode;
            }
            public override bool ProcessPayment(decimal amount, out string reference)
            {
                reference = GenerateReference();
                ApplyTransactionfee((double)amount);
                return true;
            }
        }
        class CashOnDelivery : IPaymentMethod
        {
            public string Displayname => "Cash on Delivery";
            public bool ProcessPayment(decimal amount, out string reference)
            {
                if (amount >= 50000m || amount <= 0m)
                {
                    throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
                }
                reference = GenerateReference();
                return true;
            }
            private string GenerateReference()
            {
                return Guid.NewGuid().ToString();
            }
        }
        class PaymentProcessor
        {
            private string? Transactionlog;
            public void ProcessPayment(IPaymentMethod paymentMethod, decimal amount)
            {
                if (paymentMethod == null)
                {
                    throw new ArgumentNullException(nameof(paymentMethod), "Payment method cannot be null.");
                }
                if (amount <= 0)
                {
                    throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
                }
                if (paymentMethod.ProcessPayment(amount, out string reference))
                {
                    Console.WriteLine($"Payment of {amount:C} processed successfully using {paymentMethod.Displayname}. Reference: {reference}");
                    Transactionlog += $"Payment of {amount:C} processed successfully using {paymentMethod.Displayname}. Reference: {reference}\n";
                }
                else
                {
                    Console.WriteLine($"Payment of {amount:C} failed using {paymentMethod.Displayname}.");
                    Transactionlog += $"Payment of {amount:C} failed using {paymentMethod.Displayname}.\n";
                }
            }
        }
    }
}