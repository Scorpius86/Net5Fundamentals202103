using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Net5.Fundamentals.Game.Beep
{
    public class Tetris
    {
        enum CellStates { Empty, Dead, Alive }
        enum Movement { Left, Down, Right, RotLeft, RotRight }

        float SpeedUp = 0.8f;
        float Delay = 1000;
        const int Height = 22;
        const int Width = 10;

        CellStates[,] World = new CellStates[Width, Height];
        Random Rand = new Random();
        Timer Timer = new Timer();

        static int[,] Pieces = new int[,] { { 0, 1, 1, 1, 2, 1, 3, 1 }, { 0, 0, 0, 1, 1, 1, 2, 1 }, { 0, 1, 1, 1, 2, 0, 2, 1 },
        { 1, 0, 2, 0, 1, 1, 2, 1 }, { 0, 1, 1, 0, 1, 1, 2, 0 }, { 0, 1, 1, 0, 1, 1, 2, 1 }, { 0, 0, 1, 0, 1, 1, 2, 1 } };

        public void PlayGame()
        {
            Console.CursorVisible = false;
            Console.Title = "TETRIS";
            Console.SetWindowSize(Width * 2, Height + 1);

            System.Threading.Tasks.Task.Run((Action)PlaySong);

            SpawnPiece();

            Draw();

            Timer.Elapsed += Tick;
            Timer.Interval = Delay;
            Timer.Start();

            ConsoleKeyInfo cki;
            while ((cki = Console.ReadKey(true)) != null)
                Input(cki.Key);
        }

        private void Input(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Q:
                    break;
                case ConsoleKey.E:
                    break;
                case ConsoleKey.A:
                    MovePiece(Movement.Left);
                    break;
                case ConsoleKey.S:
                    Tick(null, null);
                    break;
                case ConsoleKey.D:
                    MovePiece(Movement.Right);
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(Environment.ExitCode);
                    break;
            }
        }
        private void SpawnPiece()
        {
            int rand = Rand.Next(7);
            bool exit = false;

            for (int i = 0; i < 8; i += 2)
            {
                if (World[Pieces[rand, i] + Width / 2 - 2, Pieces[rand, i + 1]] != CellStates.Empty)
                    exit = true;
                else
                    World[Pieces[rand, i] + Width / 2 - 2, Pieces[rand, i + 1]] = CellStates.Alive;
            }

            Draw();

            if (exit) Environment.Exit(Environment.ExitCode);
        }

        private void Draw()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                    sb.Append(World[x, y] == CellStates.Empty ? "░░" : "██");
                sb.AppendLine();
            }

            Console.Clear();
            Console.Write(sb.ToString());
        }

        private void KillAll()
        {
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    if (World[x, y] == CellStates.Alive)
                        World[x, y] = CellStates.Dead;

            RemoveLines();
            SpawnPiece();
        }

        private void RemoveLines()
        {
            for (int y = 0; y < Height; y++)
            {
                int filled = 0;
                for (int x = 0; x < Width; x++)
                    if (World[x, y] != CellStates.Empty)
                        filled++;

                if (filled == Width)
                {
                    Delay *= SpeedUp;

                    for (int i = y - 1; i >= 0; i--)
                    {
                        for (int x = 0; x < Width; x++)
                        {
                            if (World[x, i] != CellStates.Empty)
                                World[x, i + 1] = CellStates.Dead;
                            World[x, i] = CellStates.Empty;
                        }
                    }
                }

            }
        }

        private void Tick(object sender, ElapsedEventArgs e)
        {
            MovePiece(Movement.Down);

            Timer.Interval = Delay;
            Timer.Start();
        }

        private void MovePiece(Movement direction)
        {
            HashSet<Point> toUpdate = new HashSet<Point>();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (World[x, y] == CellStates.Alive)
                    {
                        if (y == Height - 1 || World[x, y + 1] == CellStates.Dead)
                        {
                            KillAll();
                            toUpdate = new HashSet<Point>();
                            break;
                        }
                        else
                        {
                            toUpdate.Add(new Point(x, y));
                        }
                    }
                }
            }

            int xOff = 0;
            int yOff = 0;

            switch (direction)
            {
                case Movement.Left:
                    xOff = -1;
                    break;
                case Movement.Down:
                    yOff = 1;
                    break;
                case Movement.Right:
                    xOff = 1;
                    break;

            }

            bool valid = true;
            foreach (Point point in toUpdate)
            {
                valid = point.x + xOff >= 0 && point.x + xOff < Width && point.y + yOff >= 0 && point.y + yOff < Height;
                if (!valid) break;
            }

            if (valid)
            {
                foreach (Point point in toUpdate)
                    World[point.x, point.y] = CellStates.Empty;
                foreach (Point point in toUpdate)
                    World[point.x + xOff, point.y + yOff] = CellStates.Alive;

                Draw();
            }
        }

        //https://gist.github.com/XeeX/6220067
        public void PlaySong()
        {
            Console.Beep(1320, 500);
            Console.Beep(990, 250);
            Console.Beep(1056, 250);
            Console.Beep(1188, 250);
            Console.Beep(1320, 125);
            Console.Beep(1188, 125);
            Console.Beep(1056, 250);
            Console.Beep(990, 250);
            Console.Beep(880, 500);
            Console.Beep(880, 250);
            Console.Beep(1056, 250);
            Console.Beep(1320, 500);
            Console.Beep(1188, 250);
            Console.Beep(1056, 250);
            Console.Beep(990, 750);
            Console.Beep(1056, 250);
            Console.Beep(1188, 500);
            Console.Beep(1320, 500);
            Console.Beep(1056, 500);
            Console.Beep(880, 500);
            Console.Beep(880, 500);
            System.Threading.Thread.Sleep(250);
            Console.Beep(1188, 500);
            Console.Beep(1408, 250);
            Console.Beep(1760, 500);
            Console.Beep(1584, 250);
            Console.Beep(1408, 250);
            Console.Beep(1320, 750);
            Console.Beep(1056, 250);
            Console.Beep(1320, 500);
            Console.Beep(1188, 250);
            Console.Beep(1056, 250);
            Console.Beep(990, 500);
            Console.Beep(990, 250);
            Console.Beep(1056, 250);
            Console.Beep(1188, 500);
            Console.Beep(1320, 500);
            Console.Beep(1056, 500);
            Console.Beep(880, 500);
            Console.Beep(880, 500);
            System.Threading.Thread.Sleep(500);
            PlaySong();
        }

        struct Point
        {
            public int x, y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
