using System;
using System.ComponentModel.Design;
namespace Day05
{
    class SeatingChart
    {
        static void Main()
        {
            string[,] cinema = new string[8, 12];
            for (int i = 0; i < cinema.GetLength(0); i++)
            {
                for (int j = 0; j < cinema.GetLength(1); j++)
                {
                    cinema[i, j] = "0";
                }
            }
            Menu(cinema);
        }
        static void Menu(string[,] cinema)
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to Movie Theatre");
                Console.WriteLine("1. View Chart");
                Console.WriteLine("2. Book Seat");
                Console.WriteLine("3. Cancel Booking");
                Console.WriteLine("4. Find Adjacent Seats");
                Console.WriteLine("5. Show Occupancy");
                Console.WriteLine("6. Exit");

                int choice;
                string? input = Console.ReadLine();
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                if (choice == 1) PrintChart(cinema);
                else if (choice == 2)
                {
                    Console.Write("Row (A-H): ");
                    string? row = Console.ReadLine().ToUpper();
                    Console.Write("Seat (1-12): ");
                    string? col = Console.ReadLine();
                    BookSeat(cinema, row, col);
                }
                else if (choice == 3)
                {
                    Console.Write("Row (A-H): ");
                    string? row = Console.ReadLine().ToUpper();
                    Console.Write("Seat (1-12): ");
                    string? col = Console.ReadLine();
                    CancelSeat(cinema, row, col);
                }
                else if (choice == 4)
                {
                    int n;
                    Console.Write("How many adjacent seats? ");
                    string? adjacent = Console.ReadLine();
                    int.TryParse(adjacent, out n);
                    FindAdjacentSeats(cinema, n);
                }
                else if (choice == 5)
                {
                    ShowOccupancy(cinema);
                }
                else if (choice == 6) break;
            }
        }
        static void PrintChart(string[,] cinema)
        {
            Console.Write("    ");
            for (int j = 1; j <= cinema.GetLength(1); j++)
            {
                Console.Write($"{j,10}");
            }
            Console.WriteLine();

            for (int i = 0; i < cinema.GetLength(0); i++)
            {
                char letter = (char)('A' + i);
                Console.Write($"{letter,-4}");
                for (int j = 0; j < cinema.GetLength(1); j++)
                {
                    Console.Write($"{cinema[i, j],10}");
                }
                Console.WriteLine();

            }
        }
        static void BookSeat(string[,] cinema, string row, string column)
        {
            if (row.Length != 1 || row[0] < 'A' || row[0] > 'H')
            {
                Console.WriteLine("Invalid row must between A-H"); // doubt here where does this return leads
                return;
            }
            if (!int.TryParse(column, out int seat) || seat < 1 || seat > 12)
            {
                Console.WriteLine("Invalid seat number Must be 1 - 12");
                return;
            }
            int rowindex = row[0] - 'A'; // doubt here
            int seatindex = seat - 1;

            if (cinema[rowindex, seatindex] == "0")
            {
                Random rnd = new Random();
                string bookingref = $"R{row}S{seat} - {rnd.Next(100, 999)}";
                cinema[rowindex, seatindex] = $"{bookingref,10}";
                Console.WriteLine($"Seat {row}{seat} booked succesfully booking ref = {bookingref}");
            }
            else
            {
                Console.WriteLine($"Seat{row}{seat} already booked ");
            }
        }
        static void CancelSeat(string[,] cinema, string row, string column)
        {
            if (row.Length != 1 || row[0] < 'A' || row[0] > 'H')
            {
                Console.WriteLine("Invalid row must between A-H");
                return;
            }
            if (!int.TryParse(column, out int seat) || seat < 1 || seat > 12)
            {
                Console.WriteLine("Invalid seat number Must be 1 - 12");
                return;
            }
            int rowindex = row[0] - 'A';
            int seatindex = seat - 1;

            if (cinema[rowindex, seatindex] != "0")
            {
                cinema[rowindex, seatindex] = "0";
                Console.WriteLine($"Booking for Seat {row}{seat} cancelled");
            }
            else
            {
                Console.WriteLine($"Seat{row}{seat} is not booked ");
            }
        }
        static void FindAdjacentSeats(string[,] cinema, int n)
        {
            for (int i = 0; i < cinema.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < cinema.GetLength(1); j++)
                {
                    if (cinema[i, j] == "0")
                    {
                        count++;
                        if (count == n)
                        {
                            char rowletter = (char)('A' + i);
                            Console.WriteLine($"Found {n} adjacent seats in row {rowletter}, starting at seat {j - n + 2}");
                            return;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }
            Console.WriteLine($"No {n} adjacent free seats found.");
        }
        static void ShowOccupancy(string[,] cinema)
        {
            int totalSeats = cinema.GetLength(0) * cinema.GetLength(1);
            int bookedSeats = 0;

            for (int i = 0; i < cinema.GetLength(0); i++)
            {
                for (int j = 0; j < cinema.GetLength(1); j++)
                {
                    if (cinema[i, j] == "0")
                    {
                        bookedSeats++;
                    }

                }
            }
            double percentage = (double)bookedSeats / totalSeats * 100;
            Console.WriteLine($"Occupancy: {percentage:F2}% ({bookedSeats}/{totalSeats} seats booked)");
        }
    }
}