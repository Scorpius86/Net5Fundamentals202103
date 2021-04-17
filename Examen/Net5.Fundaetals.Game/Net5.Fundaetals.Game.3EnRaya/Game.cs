using System;
using System.Collections.Generic;
using System.Text;

namespace Net5.Fundaetals.Game._3EnRaya
{
    public class Game
    {
        int[,] board = new int[3, 3]; //Y,X
        char[,] boardView = new char[3, 3]; //Y,X
        int count;
        int val;
        int oldY;
        int oldX;
        int newY = 1;
        int newX = 1;
        Difficulty difficulty = Difficulty.Easy;
        TypeGame typeGame = TypeGame.VsComputer;

        char gamePiece;
        string playerOneName = "You";
        string playerTwoName = "Computer";
        char playerWin = ' ';
        string messageResult = "";        
        Random rnd = new Random();
        bool AutoaticTurn = true;
        bool exit = false;
        bool endMatch = false;

        public void Run() {            
            MainMenu();
        }        
        private void NewMatch()
        {
            if (typeGame == TypeGame.VsComputer)
            {
                playerOneName = "You";
                playerTwoName = "Computer";
            }
            else
            {
                playerOneName = "Player 1";
                playerTwoName = "Player 2";
            }
            Reset();
        }
        private void Reset()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = 0;
                    boardView[i, j] = ' ';
                }
            }

            count = 0;
            val = 1;
            gamePiece = 'X';            
            endMatch = false;
        }
        private bool DoPlay(int y, int x)
        {
            //Y,X
            if (board[y, x] == 0) //if empty
            {
                oldY = newY;
                oldX = newX;
                newY = y;
                newX = x;
                boardView[y, x] = gamePiece;
                board[y, x] = val;
                ChangePlayer();
                CheckWin(y, x, board[y, x]);
                return true;
            }
            else
                return false;
        }
        private void ChangePlayer()
        {
            if (gamePiece == 'X')
            {
                gamePiece = 'O';
                val = 4;
                count++;
            }
            else
            {
                gamePiece = 'X';
                val = 1;
                count++;
            }
        }
        private void CheckWin(int y, int x, int v)
        {
            if (count == 1)
                if (typeGame == TypeGame.VsComputer)
                    AutoaticTurn = true;
            if (count > 4)
            {
                if (
                    (board[y, 0] + board[y, 1] + board[y, 2] == v * 3) || //Check row by last move
                    (board[0, x] + board[1, x] + board[2, x] == v * 3)    //Check colum by last move
                )
                {
                    count = v;
                }
                else
                {
                    if (
                        (board[0, 0] + board[1, 1] + board[2, 2] == v * 3) || //Check Diagonal - Left to Right
                        (board[2, 0] + board[1, 1] + board[0, 2] == v * 3)    //Check Diagonal - Right to Left
                    )
                    {
                        count = v;
                    }
                    else
                    {
                        if (count == 9)
                        {
                            count = 0;
                        }
                    }
                }
                if (count == 1 || count == 0)
                {
                    if (count == 1)
                    {
                        messageResult = playerOneName + " (Playing X) Wins!";
                        playerWin = 'X';
                    }
                    if (count == 0)
                    {
                        messageResult = "The Game is a Draw!";
                        playerWin = ' ';
                    }
                    endMatch = true;
                }
                else
                if (count == 4)
                {
                    messageResult = playerTwoName + " (Playing O) Wins!";
                    playerWin = 'O';
                    string temp = playerOneName;
                    playerOneName = playerTwoName;
                    playerTwoName = temp;
                    endMatch = true;
                }
            }
        }
        private void ComputerPlay(int v)
        {
            bool carry = true;

            if (difficulty == Difficulty.Hard)
                carry = WinOrStop(oldY, oldX, v);
            if ((difficulty == Difficulty.Medium || difficulty == Difficulty.Hard) && carry)
            {
                if (v == 1)
                    carry = WinOrStop(newY, newX, 4);
                else
                    carry = WinOrStop(newY, newX, 1);
            }
            if (carry)
                DoAny();
        }
        private bool WinOrStop(int y, int x, int v)
        {
            if (board[y, 0] + board[y, 1] + board[y, 2] == v * 2) // (X axis) - Check if there is only one box left to win
            {
                for (int i = 0; i < 3; i++) // Iterate until missing box is found
                {
                    if (DoPlay(y, i))
                    {
                        return false;
                    }
                }
            }
            else if (board[0, x] + board[1, x] + board[2, x] == v * 2) // (Y axis) - Check if there is only one box left to win
            {
                for (int i = 0; i < 3; i++) // Iterate until missing box is found
                {
                    if (DoPlay(i, x))
                        return false;
                }
            }
            else if (board[0, 0] + board[1, 1] + board[2, 2] == v * 2) // (Diagonal Left to Right) - Check if there is only one box left to win
            {
                for (int i = 0; i < 3; i++) // Iterate until missing box is found
                {
                    if (DoPlay(i, i))
                        return false;
                }
            }
            else if (board[2, 0] + board[1, 1] + board[0, 2] == v * 2) // (Diagonal Right to Left) - Check if there is only one box left to win
            {
                for (int i = 0, j = 2; i < 3; i++, j--) // Iterate until missing box is found
                {
                    if (DoPlay(i, j))
                        return false;
                }
            }

            return true;
        }
        private void DoAny()
        {
            int y = 2, x = 0;
            switch (count)
            {
                case 0:
                    DoPlay(0, 0);
                    break;
                case 1:
                    if (!(DoPlay(1, 1)))
                        DoPlay(0, 0);
                    break;
                case 2:
                    if (!(DoPlay(2, 2)))
                        DoPlay(0, 2);
                    break;
                case 3:
                    if ((board[0, 1] + board[1, 1] + board[2, 1]) == val)
                    {
                        DoPlay(0, 1);
                    }
                    else if ((board[1, 0] + board[1, 1] + board[1, 2]) == val)
                    {
                        DoPlay(1, 0);
                    }
                    else if (board[0, 1] != 0)
                    {
                        DoPlay(0, 2);
                    }
                    else
                    {
                        DoPlay(2, 0);
                    }

                    break;
                default:
                    while (!(DoPlay(y, x)))
                    {
                        y = rnd.Next(3);
                        x = rnd.Next(3);
                    }
                    break;
            }
        }
        private void DoPlayYX(int y,int x)
        {
            if (DoPlay(y, x) && AutoaticTurn == true)
            {
                ComputerPlay(val);
            }
        }
        private void MainMenu()
        {
            do
            {
                Console.Clear();
                //                                  10        20        30        40 
                //                        0123456789012345678901234567890123456789012
                Console.WriteLine(/*00*/$"┌─────────────────────────────────────────┐");
                Console.WriteLine(/*01*/$"│            3 en raya (Michi)            │");
                Console.WriteLine(/*02*/$"├─────────────────────────────────────────┤");
                Console.WriteLine(/*03*/$"│                                         │");
                Console.WriteLine(/*04*/$"│   (1) - Start game                      │");
                Console.WriteLine(/*05*/$"│   (2) - Set Difficulty ({difficulty.ToString()})".PadRight(42,' ')+ "│");
                Console.WriteLine(/*06*/$"│   (3) - Set Type ({typeGame.ToString()}) ".PadRight(42, ' ') + "│");                
                Console.WriteLine(/*07*/$"│   (0) - Exit                            │");
                Console.WriteLine(/*08*/$"│                                         │");
                Console.WriteLine(/*09*/$"├─────────────────────────────────────────┤");
                Console.WriteLine(/*10*/$"│   Choose your option :                  │");
                Console.WriteLine(/*11*/$"└─────────────────────────────────────────┘");
                Console.SetCursorPosition(25,10);
                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "0":
                        exit = true;
                        break;
                    case "1":
                        Console.Clear();
                        Play();                        
                        break;
                    case "2":
                        DifficultyMenu();
                        break;
                    case "3":
                        TypeGameMenu();
                        break;
                    default:
                        break;
                }
            } while (!exit);
        }
        private void DifficultyMenu()
        {
            bool back = false;

            do
            {
                Console.Clear();
                //                                  10        20        30        40 
                //                        0123456789012345678901234567890123456789012
                Console.WriteLine(/*00*/$"┌─────────────────────────────────────────┐");
                Console.WriteLine(/*01*/$"│     3 en raya (Michi) - Difficulty      │");
                Console.WriteLine(/*02*/$"├─────────────────────────────────────────┤");
                Console.WriteLine(/*03*/$"│                                         │");                
                Console.WriteLine(/*04*/$"│ {(difficulty == Difficulty.Easy ? "->" : "  ")}(1) - Easy".PadRight(42, ' ') + "│");
                Console.WriteLine(/*05*/$"│ {(difficulty == Difficulty.Medium ? "->" : "  ")}(2) - Medium".PadRight(42, ' ') + "│");
                Console.WriteLine(/*06*/$"│ {(difficulty == Difficulty.Hard ? "->" : "  ")}(3) - Hard".PadRight(42, ' ') + "│");
                Console.WriteLine(/*07*/$"│   (0) - Cancel                          │");
                Console.WriteLine(/*08*/$"│                                         │");
                Console.WriteLine(/*09*/$"├─────────────────────────────────────────┤");
                Console.WriteLine(/*10*/$"│   Choose your option :                  │");
                Console.WriteLine(/*11*/$"└─────────────────────────────────────────┘");
                Console.SetCursorPosition(25, 10);

                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "0":
                        back = true;
                        break;
                    case "1":
                        difficulty = Difficulty.Easy;
                        back = true;
                        break;
                    case "2":
                        difficulty = Difficulty.Medium;
                        back = true;
                        break;
                    case "3":
                        difficulty = Difficulty.Hard;
                        back = true;
                        break;
                    default:
                        break;
                }
            } while (!back);
        }
        private void TypeGameMenu()
        {
            bool back = false;

            do
            {
                Console.Clear();
                //                                  10        20        30        40 
                //                        0123456789012345678901234567890123456789012
                Console.WriteLine(/*00*/$"┌─────────────────────────────────────────┐");
                Console.WriteLine(/*01*/$"│        3 en raya (Michi) - Type         │");
                Console.WriteLine(/*02*/$"├─────────────────────────────────────────┤");
                Console.WriteLine(/*03*/$"│                                         │");
                Console.WriteLine(/*04*/$"│ {(typeGame == TypeGame.VsComputer ? "->" : "  ")}(1) - VsComputer".PadRight(42, ' ') + "│");
                Console.WriteLine(/*05*/$"│ {(typeGame == TypeGame.VsPlayer ? "->" : "  ")}(2) - VsPlayer".PadRight(42, ' ') + "│");                
                Console.WriteLine(/*06*/$"│   (0) - Cancel                          │");
                Console.WriteLine(/*07*/$"│                                         │");
                Console.WriteLine(/*08*/$"├─────────────────────────────────────────┤");
                Console.WriteLine(/*09*/$"│   Choose your option :                  │");
                Console.WriteLine(/*10*/$"└─────────────────────────────────────────┘");
                Console.SetCursorPosition(25, 9);

                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "0":
                        back = true;
                        break;
                    case "1":                        
                        typeGame = TypeGame.VsComputer;
                        AutoaticTurn = true;
                        back = true;
                        break;
                    case "2":                        
                        typeGame = TypeGame.VsPlayer;
                        AutoaticTurn = false;
                        back = true;
                        break;                    
                    default:
                        break;
                }
            } while (!back);
        }
        private void RenderBoard()
        {
            string label =  (gamePiece=='X'?playerOneName:playerTwoName) + " to Play NOW.";

            /*
            boardView[0, 0] = 'O';
            boardView[0, 1] = 'X';
            boardView[0, 2] = 'O';
            boardView[1, 0] = 'X';
            boardView[1, 1] = 'O';
            boardView[1, 2] = 'X';
            boardView[2, 0] = 'O';
            boardView[2, 1] = 'X';
            boardView[2, 2] = 'O';
            */
            
            //Console.WriteLine("       │ ▄▀▀▀▄ │       ");
            //Console.WriteLine("       │ █   █ │       ");            
            //Console.WriteLine("       │ ▀▄▄▄▀ │       ");

            //Console.WriteLine("       │ ▀▄ ▄▀ │       ");
            //Console.WriteLine("       │   █   │       ");            
            //Console.WriteLine("       │ ▄▀ ▀▄ │       ");

            //Console.WriteLine("       │ ▄▀▀▀▄ │ ▀▀█   │ ▀▀▀▀▄ │ ▀▀▀▀▄ │ █   █ │ █▀▀▀▀ │ ▄▀▀▀  │ ▀▀▀▀▄ │ ▄▀▀▀▄ │ ▄▀▀▀▄     ");
            //Console.WriteLine("       │ █ █ █ │   █   │ ▄■■■▀ │  ■■■  │ ▀■■■█ │ ▀■■■▄ │ █■■■▄ │     █ │  ■■■  │ ▀■■■█     ");            
            //Console.WriteLine("       │ ▀▄▄▄▀ │ ▄▄█▄▄ │ █▄▄▄▄ │ ▄▄▄▄▀ │     █ │ ▄▄▄▄▀ │ ▀▄▄▄▀ │     █ │ ▀▄▄▄▀ │  ▄▄▄▀     ");

            Console.Clear();
            //                                  10        20        30        40 
            //                        0123456789012345678901234567890123456789012
            Console.WriteLine(/*00*/$"┌─────────────────────────────────────────┐");
            Console.WriteLine(/*01*/$"│            3 en raya (Michi)            │");
            Console.WriteLine(/*02*/$"├─────────────────────────────────────────┤");
            Console.WriteLine(/*03*/$"│                                         │");
            Console.WriteLine(/*04*/$"│        Difficulty : {difficulty.ToString()}".PadRight(42,' ')+"│");
            Console.WriteLine(/*05*/$"│        Type game  : {typeGame.ToString()}".PadRight(42, ' ') + "│");
            Console.WriteLine(/*06*/$"│                                         │");
            Console.WriteLine(/*07*/$"│                                         │");

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.Write(/*08*/ "│          ");
            Console.ForegroundColor = boardView[0, 0] == 'X' ? ConsoleColor.Red : (boardView[0, 0] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[0, 0] == 'O' ? "▄▀▀▀▄" : (boardView[0, 0] == 'X' ? "▀▄ ▄▀" : "▄▀▀▀▄"));
            Console.ResetColor();
            Console.Write(" │ ");            
            Console.ForegroundColor = boardView[0, 1] == 'X' ? ConsoleColor.Red : (boardView[0, 1] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[0, 1] == 'O' ? "▄▀▀▀▄" : (boardView[0, 1] == 'X' ? "▀▄ ▄▀" : "▀▀█  "));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[0, 2] == 'X' ? ConsoleColor.Red : (boardView[0, 2] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[0, 2] == 'O' ? "▄▀▀▀▄" : (boardView[0, 2] == 'X' ? "▀▄ ▄▀" : "▀▀▀▀▄"));
            Console.ResetColor();
            Console.WriteLine("          │");

            Console.Write(/*09*/ "│          ");
            Console.ForegroundColor = boardView[0, 0] == 'X' ? ConsoleColor.Red : (boardView[0, 0] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[0, 0] == 'O' ? "█   █" : (boardView[0, 0] == 'X' ? "  █  " : "█ █ █"));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[0, 1] == 'X' ? ConsoleColor.Red : (boardView[0, 1] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[0, 1] == 'O' ? "█   █" : (boardView[0, 1] == 'X' ? "  █  " : "  █  "));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[0, 2] == 'X' ? ConsoleColor.Red : (boardView[0, 2] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[0, 2] == 'O' ? "█   █" : (boardView[0, 2] == 'X' ? "  █  " : "▄■■■▀"));
            Console.ResetColor();
            Console.WriteLine("          │");

            Console.Write(/*10*/ "│          ");
            Console.ForegroundColor = boardView[0, 0] == 'X' ? ConsoleColor.Red : (boardView[0, 0] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[0, 0] == 'O' ? "▀▄▄▄▀" : (boardView[0, 0] == 'X' ? "▄▀ ▀▄" : "▀▄▄▄▀"));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[0, 1] == 'X' ? ConsoleColor.Red : (boardView[0, 1] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[0, 1] == 'O' ? "▀▄▄▄▀" : (boardView[0, 1] == 'X' ? "▄▀ ▀▄" : "▄▄█▄▄"));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[0, 2] == 'X' ? ConsoleColor.Red : (boardView[0, 2] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[0, 2] == 'O' ? "▀▄▄▄▀" : (boardView[0, 2] == 'X' ? "▄▀ ▀▄" : "█▄▄▄▄"));
            Console.ResetColor();
            Console.WriteLine("          │");
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////            
            Console.WriteLine(/*11*/$"│         ───────┼───────┼───────         │");
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.Write(/*12*/ "│          ");
            Console.ForegroundColor = boardView[1, 0] == 'X' ? ConsoleColor.Red : (boardView[1, 0] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[1, 0] == 'O' ? "▄▀▀▀▄" : (boardView[1, 0] == 'X' ? "▀▄ ▄▀" : "▀▀▀▀▄"));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[1, 1] == 'X' ? ConsoleColor.Red : (boardView[1, 1] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[1, 1] == 'O' ? "▄▀▀▀▄" : (boardView[1, 1] == 'X' ? "▀▄ ▄▀" : "█   █"));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[1, 2] == 'X' ? ConsoleColor.Red : (boardView[1, 2] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[1, 2] == 'O' ? "▄▀▀▀▄" : (boardView[1, 2] == 'X' ? "▀▄ ▄▀" : "█▀▀▀▀"));
            Console.ResetColor();
            Console.WriteLine("          │");

            Console.Write(/*13*/ "│          ");
            Console.ForegroundColor = boardView[1, 0] == 'X' ? ConsoleColor.Red : (boardView[1, 0] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[1, 0] == 'O' ? "█   █" : (boardView[1, 0] == 'X' ? "  █  " : " ■■■ "));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[1, 1] == 'X' ? ConsoleColor.Red : (boardView[1, 1] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[1, 1] == 'O' ? "█   █" : (boardView[1, 1] == 'X' ? "  █  " : "▀■■■█"));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[1, 2] == 'X' ? ConsoleColor.Red : (boardView[1, 2] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[1, 2] == 'O' ? "█   █" : (boardView[1, 2] == 'X' ? "  █  " : "▀■■■▄"));
            Console.ResetColor();
            Console.WriteLine("          │");

            Console.Write(/*14*/ "│          ");
            Console.ForegroundColor = boardView[1, 0] == 'X' ? ConsoleColor.Red : (boardView[1, 0] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[1, 0] == 'O' ? "▀▄▄▄▀" : (boardView[1, 0] == 'X' ? "▄▀ ▀▄" : "▄▄▄▄▀"));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[1, 1] == 'X' ? ConsoleColor.Red : (boardView[1, 1] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[1, 1] == 'O' ? "▀▄▄▄▀" : (boardView[1, 1] == 'X' ? "▄▀ ▀▄" : "    █"));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[1, 2] == 'X' ? ConsoleColor.Red : (boardView[1, 2] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[1, 2] == 'O' ? "▀▄▄▄▀" : (boardView[1, 2] == 'X' ? "▄▀ ▀▄" : "▄▄▄▄▀"));
            Console.ResetColor();
            Console.WriteLine("          │");
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////            
            Console.WriteLine(/*15*/$"│         ───────┼───────┼───────         │");
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////         
            Console.Write(/*16*/ "│          ");
            Console.ForegroundColor = boardView[2, 0] == 'X' ? ConsoleColor.Red : (boardView[2, 0] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[2, 0] == 'O' ? "▄▀▀▀▄" : (boardView[2, 0] == 'X' ? "▀▄ ▄▀" : "▄▀▀▀ "));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[2, 1] == 'X' ? ConsoleColor.Red : (boardView[2, 1] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[2, 1] == 'O' ? "▄▀▀▀▄" : (boardView[2, 1] == 'X' ? "▀▄ ▄▀" : "▀▀▀▀▄"));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[2, 2] == 'X' ? ConsoleColor.Red : (boardView[2, 2] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[2, 2] == 'O' ? "▄▀▀▀▄" : (boardView[2, 2] == 'X' ? "▀▄ ▄▀" : "▄▀▀▀▄"));
            Console.ResetColor();
            Console.WriteLine("          │");

            Console.Write(/*17*/ "│          ");
            Console.ForegroundColor = boardView[2, 0] == 'X' ? ConsoleColor.Red : (boardView[2, 0] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[2, 0] == 'O' ? "█   █" : (boardView[2, 0] == 'X' ? "  █  " : "█■■■▄"));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[2, 1] == 'X' ? ConsoleColor.Red : (boardView[2, 1] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[2, 1] == 'O' ? "█   █" : (boardView[2, 1] == 'X' ? "  █  " : "    █"));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[2, 2] == 'X' ? ConsoleColor.Red : (boardView[2, 2] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[2, 2] == 'O' ? "█   █" : (boardView[2, 2] == 'X' ? "  █  " : " ■■■ "));
            Console.ResetColor();
            Console.WriteLine("          │");

            Console.Write(/*18*/ "│          ");
            Console.ForegroundColor = boardView[2, 0] == 'X' ? ConsoleColor.Red : (boardView[2, 0] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[2, 0] == 'O' ? "▀▄▄▄▀" : (boardView[2, 0] == 'X' ? "▄▀ ▀▄" : "▀▄▄▄▀"));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[2, 1] == 'X' ? ConsoleColor.Red : (boardView[2, 1] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[2, 1] == 'O' ? "▀▄▄▄▀" : (boardView[2, 1] == 'X' ? "▄▀ ▀▄" : "    █"));
            Console.ResetColor();
            Console.Write(" │ ");
            Console.ForegroundColor = boardView[2, 2] == 'X' ? ConsoleColor.Red : (boardView[2, 2] == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write(boardView[2, 2] == 'O' ? "▀▄▄▄▀" : (boardView[2, 2] == 'X' ? "▄▀ ▀▄" : "▀▄▄▄▀"));
            Console.ResetColor();
            Console.WriteLine("          │");
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                        
            Console.WriteLine(/*19*/$"│                                         │");
            Console.WriteLine(/*20*/$"│                                         │");
            Console.WriteLine(/*21*/$"├─────────────────────────────────────────┤");
            
            Console.Write(/*22*/$"│   ");
            Console.ForegroundColor = gamePiece == 'X' ? ConsoleColor.Red : (gamePiece == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write($"{ label} {gamePiece} : ".PadRight(38, ' '));
            Console.ResetColor();
            Console.WriteLine("│");
            Console.WriteLine(/*23*/$"└─────────────────────────────────────────┘");
            //                                  10        20        30        40 
            //                        0123456789012345678901234567890123456789012
        }
        private void SelectBox()
        {
            Console.SetCursorPosition(30,22);
            string opt = Console.ReadLine();
            switch (opt)
            {
                case "0":
                    DoPlayYX(0, 0);
                    break;
                case "1":
                    DoPlayYX(0, 1);
                    break;
                case "2":
                    DoPlayYX(0, 2);
                    break;
                case "3":
                    DoPlayYX(1, 0);
                    break;
                case "4":
                    DoPlayYX(1, 1);
                    break;
                case "5":
                    DoPlayYX(1, 2);
                    break;
                case "6":
                    DoPlayYX(2, 0);
                    break;
                case "7":
                    DoPlayYX(2, 1);
                    break;
                case "8":
                    DoPlayYX(2, 2);
                    break;
                default:
                    break;
            }
        }

        private void Play()
        {
            NewMatch();
            do
            {
                RenderBoard();
                SelectBox();                
            } while (!endMatch);
            RenderResult();
        }
        private void RenderResult()
        {
            RenderBoard();
            Console.SetCursorPosition(0, 22);            
            Console.Write(/*22*/$"│   ");
            Console.ForegroundColor = playerWin == 'X' ? ConsoleColor.Red : (playerWin == 'O' ? ConsoleColor.Blue : ConsoleColor.Gray);
            Console.Write($"{ messageResult}".PadRight(38, ' '));
            Console.ResetColor();
            Console.WriteLine("│");
            Console.WriteLine(/*23*/$"│   Press any key to continue".PadRight(42, ' ') + "│");
            Console.WriteLine(/*24*/$"└─────────────────────────────────────────┘");
            Console.ReadKey();
        }
    }
}
