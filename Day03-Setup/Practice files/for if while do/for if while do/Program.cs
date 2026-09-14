for (int row = 1; row <= 3; row++)
{
    for (int col = 1; col <= 3; col++)
    {
        Console.Write($"{row * col,3}");
    }
    Console.WriteLine(); // newline after each row
}