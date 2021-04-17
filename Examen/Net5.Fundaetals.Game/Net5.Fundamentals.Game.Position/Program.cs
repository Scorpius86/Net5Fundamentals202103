using System;
using System.Threading;

namespace Net5.Fundamentals.Game.Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int colSize = 150;
            int rowSize = 50;

            Console.WindowWidth = colSize;
            Console.WindowHeight = rowSize;
                        
            for (int col = 0; col < colSize; col++)
            {
                for (int row = 0; row < rowSize; row++)
                {
                    Console.SetCursorPosition(col, row);
                    if (col == 0 || row == 0 || col == colSize-1 || row == rowSize-1)
                    {
                        Thread.Sleep(2);
                        Console.Write("*");                        
                    }
                }                
            }

            for (int i = 1; i < 5; i++)
                Console.Beep(1000, 400);

            Console.ReadKey();
        }
    }
}
