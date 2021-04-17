using System;
using System.Collections.Generic;
using System.Text;

namespace Net5.Fundamentals.Game.Tetris
{
    public class Renderer
    {        
        public void Render(State state)
        {
            // RENDER CURRENT
            char[,] view = RenderView(state); // Render view (Playing field)

            // RENDER HOLD
            char[,] hold = RenderHold(state); // Render hold (the current held block)


            //RENDER UP NEXT
            char[,] next = RenderUpNext(state); // Render the next three blocks as an 'up next' feature

            // PRINT VIEW
            Print(view, hold, next, state); // Print everything to the screen
        }
        private char[,] RenderView(State state)
        {
            char[,] view = new char[state.MapSizeY, state.MapSizeX];

            // Make view equal to bg
            for (int y = 0; y < state.MapSizeY; y++)
                for (int x = 0; x < state.MapSizeX; x++)
                    view[y, x] = state.BG[y, x];



            // Overlay current
            for (int i = 0; i < state.Blocks.GetLength(2); i++)
            {
                view[state.Blocks[state.CurrentIndex, state.CurrentRot, i, 1] + state.CurrentY, state.Blocks[state.CurrentIndex, state.CurrentRot, i, 0] + state.CurrentX] = state.CurrentChar;
            }
            return view;
        }
        private char[,] RenderHold(State state)
        {
            char[,] hold = new char[state.HoldSizeY, state.HoldSizeX];
            // Hold = ' ' array
            for (int y = 0; y < state.HoldSizeY; y++)
                for (int x = 0; x < state.HoldSizeX; x++)
                    hold[y, x] = ' ';


            // If there is a held block
            if (state.HoldIndex != -1)
            {
                // Overlay blocks from hold
                for (int i = 0; i < state.Blocks.GetLength(2); i++)
                {
                    hold[state.Blocks[state.HoldIndex, 0, i, 1] + 1, state.Blocks[state.HoldIndex, 0, i, 0] + 1] = state.HoldChar;
                }
            }
            return hold;
        }
        private char[,] RenderUpNext(State state)
        {
            // Up next = ' ' array   
            char[,] next = new char[state.MapSizeY, state.UpNextSize];
            for (int y = 0; y < state.MapSizeY; y++)
                for (int x = 0; x < state.UpNextSize; x++)
                    next[y, x] = ' ';


            int nextBagIndex = 0;
            for (int i = 0; i < 3; i++) // Next 3 blocks
            {

                for (int l = 0; l < state.Blocks.GetLength(2); l++)
                {
                    if (i + state.BagIndex >= 7) // If we need to acces the next bag
                        next[state.Blocks[state.NextBag[nextBagIndex], 0, l, 1] + 5 * i, state.Blocks[state.NextBag[nextBagIndex], 0, l, 0] + 1] = state.PixelTypes[state.NextBag[nextBagIndex]];
                    else
                        next[state.Blocks[state.Bag[state.BagIndex + i], 0, l, 1] + 5 * i, state.Blocks[state.Bag[state.BagIndex + i], 0, l, 0] + 1] = state.PixelTypes[state.Bag[state.BagIndex + i]];


                }
                if (i + state.BagIndex >= 7) nextBagIndex++;
            }
            return next;

        }
        private void Print(char[,] view, char[,] hold, char[,] next,State state)
        {
            for (int y = 0; y < state.MapSizeY; y++)
            {

                for (int x = 0; x < state.HoldSizeX + state.MapSizeX + state.UpNextSize; x++)
                {
                    char i = ' ';
                    // Add hold + Main View + up next to view (basically dark magic)
                    if (x < state.HoldSizeX) i = hold[y, x];
                    else if (x >= state.HoldSizeX + state.MapSizeX) i = next[y, x - state.MapSizeX - state.UpNextSize];
                    else i = view[y, (x - state.HoldSizeX)];


                    // Colours
                    switch (i)
                    {
                        case 'O':
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write('█');
                            break;
                        case 'I':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write('█');
                            break;

                        case 'T':
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write('█');
                            break;

                        case 'S':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write('█');
                            break;
                        case 'Z':
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            //Console.Write(i);
                            Console.Write('█');
                            break;
                        case 'L':
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write('█');
                            break;

                        case 'J':
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write('█');
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(i);
                            break;
                    }

                }
                if (y == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("   " + state.Score);
                }
                Console.WriteLine();
            }

            // Reset console cursor position
            Console.SetCursorPosition(0, Console.CursorTop - state.MapSizeY);
        }
    }
}
