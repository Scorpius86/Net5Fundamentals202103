using System;
using System.Collections.Generic;
using System.Threading;

namespace Net5.Fundaetals.Game.TicTacToe
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static string player1, player2;
        static int player = 1;
        static int chance;
        static int flag = 0;
        static int wins_p1, wins_p2, match_numbers;
        static int match_counter = 0;

        static void Main(string[] args)
        {

            Console.Write("How many matches?: ");
            match_numbers = int.Parse(Console.ReadLine());

            Console.Write("Player 1 nick: ");
            player1 = Console.ReadLine();

            Console.Write("Player 2 nick: ");
            player2 = Console.ReadLine();

            while (match_counter < match_numbers)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Score: ");
                    Console.WriteLine("{0}: {1}", player1, wins_p1);
                    Console.WriteLine("{0}: {1}", player2, wins_p2);
                    Console.WriteLine("{0} is X and {1} is O!", player1, player2);
                    Console.WriteLine("");
                    if (player % 2 == 0)
                    {

                        Console.WriteLine("{0} turn", player2);

                    }

                    else
                    {

                        Console.WriteLine("{0} turn", player1);

                    }

                    Console.WriteLine("");
                    Board();
                    chance = int.Parse(Console.ReadLine());
                    if (arr[chance] != 'X' && arr[chance] != '0')
                    {
                        if (player % 2 == 0)
                        {
                            arr[chance] = 'O';
                            player++;
                        }
                        else
                        {
                            arr[chance] = 'X';
                            player++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("This place {0} is marked with {1}", chance, arr[chance]);
                        Console.WriteLine("");
                        Console.WriteLine("Loading.....");
                        Thread.Sleep(2000);
                    }

                    flag = CheckWinner();

                } while (flag != 1 && flag != -1);

                Console.Clear();
                Board();

                if (flag == 1 && ((player % 2) + 1 == 1))
                {
                    wins_p1++;
                    Console.WriteLine("Score: ");
                    Console.WriteLine("{0}: {1}", player1, wins_p1);
                    Console.WriteLine("{0}: {1}", player2, wins_p2);

                    Console.WriteLine("{0} wins!", player1);
                }

                else if (flag == 1 && ((player % 2) + 1 != 1))
                {
                    wins_p2++;
                    Console.WriteLine("Score: ");
                    Console.WriteLine("{0}: {1}", player1, wins_p1);
                    Console.WriteLine("{0}: {1}", player2, wins_p2);

                    Console.WriteLine("{0} wins!", player2);
                }
                else

                {
                    Console.WriteLine("Score: ");
                    Console.WriteLine("{0}: {1}", player1, wins_p1);
                    Console.WriteLine("{0}: {1}", player2, wins_p2);

                    Console.WriteLine("Draw!");
                }

                Console.ReadLine();

                match_counter++;

            }

            if (wins_p1 <= wins_p2)
            {
                Console.WriteLine("{0} wins!", player2);
                Console.WriteLine("Score: ");
                Console.WriteLine("{0}: {1}", player1, wins_p1);
                Console.WriteLine("{0}: {1}", player2, wins_p2);
            }
            else
            {
                Console.WriteLine("{0} wins!", player1);
                Console.WriteLine("Score: ");
                Console.WriteLine("{0}: {1}", player1, wins_p1);
                Console.WriteLine("{0}: {1}", player2, wins_p2);
            }


        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private static void Board()
        {
            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);

            Console.WriteLine("     |     |      ");
        }

        private static int CheckWinner()

        {
            #region Horizontal

            if (arr[1] == arr[2] && arr[2] == arr[3])
            { return 1; }

            else if (arr[4] == arr[5] && arr[5] == arr[6])
            { return 1; }

            else if (arr[6] == arr[7] && arr[7] == arr[8])
            { return 1; }

            #endregion

            #region Vertical

            else if (arr[1] == arr[4] && arr[4] == arr[7])
            { return 1; }

            else if (arr[2] == arr[5] && arr[5] == arr[8])
            { return 1; }

            else if (arr[3] == arr[6] && arr[6] == arr[9])
            { return 1; }

            #endregion

            #region Diagonal

            else if (arr[1] == arr[5] && arr[5] == arr[9])
            { return 1; }

            else if (arr[3] == arr[5] && arr[5] == arr[7])
            { return 1; }

            #endregion

            #region Draw

            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')

            { return -1; }

            #endregion

            else { return 0; }

        }
    }
}
