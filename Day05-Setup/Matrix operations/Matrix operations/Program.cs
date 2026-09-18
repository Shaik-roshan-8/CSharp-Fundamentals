using System;
namespace Day05
{
    class Matrix
    {
        static void Main()
        {
            int[,] matrix1 = new int[3, 3];
            int[,] matrix2 = new int[3, 3];

            Console.WriteLine("Enter values for matrix 1");
            for (int i = 0; i<3; i++)
            {
                for (int j = 0; j<3; j++)
                {
                    while(true)
                    {
                        Console.WriteLine($"Enter the value for matrix[{i} , {j}]");
                        string? input = Console.ReadLine();

                        if(int.TryParse(input, out int value))
                        {
                            matrix1[i,j] = value;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                    }
                    
                }
            }
            Console.WriteLine("Enter values for matrix 2");
            for(int i = 0; i<3;i++)
            {
                for(int j = 0;j<3;j++)
                {
                    while(true)
                    {
                        Console.WriteLine($"Enter value for matrix[{i},{j}]");
                        string? input = Console.ReadLine();

                        if (int.TryParse(input, out int value))
                        {
                            matrix2[i, j] = value;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                         
                    }
                }
            }

            Console.WriteLine("Printing matrices");
            Console.WriteLine("Matrix 1 : ");
            for(int i = 0; i <3;i++)
            {
                for(int j =0; j<3;j++)
                {
                    Console.Write($"{ matrix1[i, j],4}" + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Matrix 2 : ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{matrix2[i, j],4}"+ "\t");
                }
                Console.WriteLine();
            }

            int[,] sum = new int[3, 3];
            for(int i = 0;i < 3;i++)
            {
                for(int j = 0;j < 3;j++)
                {
                    sum[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            Console.WriteLine("sum:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{sum[i, j],4}" + "\t");
                }
                Console.WriteLine();
            }

            int[,] diferrence = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    diferrence[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            Console.WriteLine("Diferrence : ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{diferrence[i, j],4}" + "\t");
                }
                Console.WriteLine();
            }

            int[,] product = new int[3, 3];
            for(int i =0; i < 3;i++)
            {
                for(int j = 0;j < 3;j++)
                {
                    product[i, j] = 0;
                    for(int k  = 0;k < 3;k++)
                    {
                        product[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            Console.WriteLine("Product :");
            for(int i = 0;i < 3;i++)
            {
                for(int j=0;j < 3;j++)
                {
                    Console.Write($"{product[i,j],4}" +  "\t");

                }
                Console.WriteLine();
            }

            int[,] transpose = new int[3,3];
            for(int i =0;i<3;i++)
            {
                for(int j=0 ; j<3;j++)
                {
                    transpose[i,j] = matrix1[j,i];
                }
            }
            Console.WriteLine("Transpose :");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{transpose[i, j],4}"+ "\t");
                }
                Console.WriteLine();
            }

            int sumofdiagonal = 0;
            for(int i =0; i<3;i++)
            {
                sumofdiagonal += matrix1[i, i];
            }
            Console.WriteLine("Sum of main diagonal :");
            Console.WriteLine(sumofdiagonal);






        }
        
    }
}