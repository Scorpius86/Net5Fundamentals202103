using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Net5.Fundamentals.Game.Tetris
{
    public class Brain
    {
        private Renderer renderer { get; set; }
        public Brain()
        {
            renderer = new Renderer();
        }
        
        public void BlockDownCollision(State state)
        {

            // Add blocks from current to background
            for (int i = 0; i < state.Blocks.GetLength(2); i++)
            {
                state.BG[state.Blocks[state.CurrentIndex, state.CurrentRot, i, 1] + state.CurrentY, state.Blocks[state.CurrentIndex, state.CurrentRot, i, 0] + state.CurrentX] = state.CurrentChar;
            }

            // Loop 
            while (true)
            {
                // Check for line
                int lineY = Line(state.BG,state);

                // If a line is detected
                if (lineY != -1)
                {
                    ClearLine(lineY,state);

                    continue;
                }
                break;
            }
            // New block
            NewBlock(state);

        }
        private void ClearLine(int lineY, State state)
        {
            state.Score += 40;
            // Clear said line
            for (int x = 0; x < state.MapSizeX; x++) state.BG[lineY, x] = '░';

            // Loop through all blocks above line
            for (int y = lineY - 1; y > 0; y--)
            {
                for (int x = 0; x < state.MapSizeX; x++)
                {
                    // Move each character down
                    char character = state.BG[y, x];
                    if (character != '░')
                    {
                        state.BG[y, x] = '░';
                        state.BG[y + 1, x] = character;
                    }

                }
            }
        }
        public int[] GenerateBag()
        {
            Random random = new Random();
            int n = 7;
            int[] ret = { 0, 1, 2, 3, 4, 5, 6, 7 };
            while (n > 1)
            {
                int k = random.Next(n--);
                int temp = ret[n];
                ret[n] = ret[k];
                ret[k] = temp;

            }
            return ret;

        }
        public bool Collision(int index, char[,] bg, int x, int y, int rot,State state)
        {

            for (int i = 0; i < state.Blocks.GetLength(2); i++)
            {
                // Check if out of bounds
                if (state.Blocks[index, rot, i, 1] + y >= state.MapSizeY || state.Blocks[index, rot, i, 0] + x < 0 || state.Blocks[index, rot, i, 0] + x >= state.MapSizeX)
                {
                    return true;
                }
                // Check if not '-'
                if (bg[state.Blocks[index, rot, i, 1] + y, state.Blocks[index, rot, i, 0] + x] != '░')
                {
                    return true;
                }
            }

            return false;
        }
        private int Line(char[,] bg,State state)
        {
            for (int y = 0; y < state.MapSizeY; y++)
            {
                bool i = true;
                for (int x = 0; x < state.MapSizeX; x++)
                {
                    if (bg[y, x] == '░')
                    {
                        i = false;
                    }
                }
                if (i) return y;
            }

            // If no line return -1
            return -1;
        }
        public  void NewBlock(State state)
        {
            // Check if new bag is necessary
            if (state.BagIndex >= 7)
            {
                state.BagIndex = 0;
                state.Bag = state.NextBag;
                state.NextBag = GenerateBag();
            }

            // Reset everything
            state.CurrentY = 0;
            state.CurrentX = 4;
            state.CurrentChar = state.PixelTypes[state.Bag[state.BagIndex]];
            state.CurrentIndex = state.Bag[state.BagIndex];

            // Check if the next block position collides. If it does its gameover
            if (Collision(state.CurrentIndex, state.BG, state.CurrentX, state.CurrentY, state.CurrentRot,state) && state.Amount > 0)
            {
                GameOver();
            }
            state.BagIndex++;
            state.Amount++;
        }
        private void GameOver()
        {
            Environment.Exit(1);
        }
    }
}
