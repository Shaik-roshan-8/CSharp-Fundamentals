using System;
namespace Day06
{
    class Seat
    {
        public char Row { get; }
        public int Number { get; }
        public bool IsOccupied { get; private set; }
        public string? BookingReference { get; private set; }

        public Seat(char row, int number)  // constructer 
        {
            Row = row;
            Number = number;
            IsOccupied = false;
            BookingReference = "";
        }
        public bool Book(string reference)
        {
            if (IsOccupied)
                return false;

            IsOccupied = true;
            BookingReference = reference;
            return true;
        }
        public bool Cancel()
        {
            if (!IsOccupied)
                return false;

            IsOccupied = false;
            BookingReference = "";
            return true;

        }
        public override string ToString()
        {
            return IsOccupied ? BookingReference : "0";
        }
    }
    class Cinema
    {
        private Seat[,] _seats;
        private int _rows;
        private int _cols;

        public Cinema(int rows, int cols)
        {
            _rows = rows;
            _cols = cols;
            _seats = new Seat[rows, cols];

            for (int i = 0; i < _rows; i++)
            {
                char rowletter = (char)('A' + i);
                for (int j = 0; j < _cols; j++)
                {
                    _seats[i, j] = new Seat(rowletter, j + 1);
                }
            }
        }
        private bool TryGetIndices(string row, string column, out int rowIndex, out int colIndex)
        {
            rowIndex = -1;
            colIndex = -1;

            if (string.IsNullOrEmpty(row) || row.Length != 1 || row[0] < 'A' || row[0] >= (char)('A' + _rows))
            {
                Console.WriteLine($"Invalid row, must be between A-{(char)('A' + _rows - 1)}");
                return false;
            }
            if (!int.TryParse(column, out int seat) || seat < 1 || seat > 100)
            {
                Console.WriteLine($"Invalid seat number, must be 1-{_cols}");
                return false;
            }
            rowIndex = row[0] - 'A';
            colIndex = seat - 1;
            return true;
        }
        public void BookSeat(string row, string column)
        {
            if (!TryGetIndices(row, column, out int rowIndex, out int colIndex))
                return;
            Seat seat = _seats[rowIndex, colIndex];
            if (seat.IsOccupied)
            {
                Console.WriteLine($"Seat {row}{column} already booked");
                return;
            }
            Random rnd = new Random();
            string reference = $"R{seat.Row}S{seat.Number}-{rnd.Next(100 , 900)}";
            seat.Book(reference);
            Console.WriteLine($"Seat {row}{column} booked successfully, booking ref = {reference}");
        }
        public void CancelSeat(string row, string column)
        {
            if (!TryGetIndices(row, column, out int rowIndex, out int colIndex))
                return;

            Seat seat = _seats[rowIndex, colIndex];
            if (seat.Cancel())
                Console.WriteLine($"Booking for seat {row}{column} cancelled");
            else
                Console.WriteLine($"Seat {row}{column} is not booked");
        }
        public void PrintChart()
        {
            Console.Write("    ");
            for (int j = 1; j <= _cols; j++)
                Console.Write($"{j,10}");
            Console.WriteLine();

            for (int i = 0; i < _rows; i++)
            {
                char letter = (char)('A' + i);
                Console.Write($"{letter,-4}");
                for (int j = 0; j < _cols; j++)
                    Console.Write($"{_seats[i, j],10}");
                Console.WriteLine();
            }
        }
        public void FindAdjacentSeats(int n)
        {
            for (int i = 0; i < _rows; i++)
            {
                int count = 0;
                for (int j = 0; j < _cols; j++)
                {
                    if (!_seats[i, j].IsOccupied)
                    {
                        count++;
                        if (count == n)
                        {
                            char rowLetter = (char)('A' + i);
                            Console.WriteLine($"Found {n} adjacent seats in row {rowLetter}, starting at seat {j - n + 2}");
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
        public void ShowOccupancy()
        {
            int totalSeats = _rows * _cols;
            int bookedSeats = 0;

            for (int i = 0; i < _rows; i++)
                for (int j = 0; j < _cols; j++)
                    if (_seats[i, j].IsOccupied)
                        bookedSeats++;

            double percentage = (double)bookedSeats / totalSeats * 100;
            Console.WriteLine($"Occupancy: {percentage:F2}% ({bookedSeats}/{totalSeats} seats booked)");


        }
        class Program
        {
            static void Main()
            {
                Cinema cinema = new Cinema(8, 12);
                Menu(cinema);
            }

            static void Menu(Cinema cinema)
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

                    string? input = Console.ReadLine();
                    if (!int.TryParse(input, out int choice))
                    {
                        Console.WriteLine("Invalid input");
                        continue;
                    }

                    if (choice == 1)
                    {
                        cinema.PrintChart();
                    }
                    else if (choice == 2)
                    {
                        Console.Write("Row (A-H): ");
                        string row = Console.ReadLine()?.ToUpper() ?? "";
                        Console.Write("Seat (1-12): ");
                        string col = Console.ReadLine() ?? "";
                        cinema.BookSeat(row, col);
                    }
                    else if (choice == 3)
                    {
                        Console.Write("Row (A-H): ");
                        string row = Console.ReadLine()?.ToUpper() ?? "";
                        Console.Write("Seat (1-12): ");
                        string col = Console.ReadLine() ?? "";
                        cinema.CancelSeat(row, col);
                    }
                    else if (choice == 4)
                    {
                        Console.Write("How many adjacent seats? ");
                        int.TryParse(Console.ReadLine(), out int n);
                        cinema.FindAdjacentSeats(n);
                    }
                    else if (choice == 5)
                    {
                        cinema.ShowOccupancy();
                    }
                    else if (choice == 6)
                    {
                        break;
                    }
                }
            }
        }
    }
}
