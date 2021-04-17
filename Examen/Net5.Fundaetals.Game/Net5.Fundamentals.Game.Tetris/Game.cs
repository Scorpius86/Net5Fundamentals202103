using Net5.Fundamentals.Game.Tetris;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Net5.Fundamentals.Game.Tetris
{
    public class Game
    {
        private State state { get; set; }
        private Renderer renderer { get; set; }
        private Brain brain { get; set; }
        private Devices devices { get; set; }
        public Game()
        {
            state = new State();            
            brain = new Brain();
            renderer = new Renderer();
            devices = new Devices();
        }

        public void Play()
        {
            // Make the console cursor invisible
            Console.CursorVisible = false;

            // Title
            Console.Title = "Tetris";

            // Start the inputthread to get live inputs
            Thread inputThread = new Thread(devices.Input);
            inputThread.Start();

            // Start Song
            Thread songThread = new Thread(devices.PlaySong);
            songThread.Start();

            // Generate bag / current block
            state.Bag = brain.GenerateBag();
            state.NextBag = brain.GenerateBag();
            brain.NewBlock(state);

            // Generate an empty bg
            for (int y = 0; y < state.MapSizeY; y++)
                for (int x = 0; x < state.MapSizeX; x++)
                {
                    state.BG[y, x] = '░';
                }

            while (true)
            {

                // Force block down
                if (state.Timer >= state.MaxTime)
                {
                    // If it doesn't collide, just move it down. If it does call BlockDownCollision
                    if (!brain.Collision(state.CurrentIndex, state.BG, state.CurrentX, state.CurrentY + 1, state.CurrentRot, state)) state.CurrentY++;
                    else brain.BlockDownCollision(state);

                    state.Timer = 0;
                }
                state.Timer++;

                // INPUT
                devices.InputHandler(state); // Call InputHandler    
                
                renderer.Render(state);

                Thread.Sleep(20); // Wait to not overload the processor (I think it's better because it has no impact on game feel)
            }


        }
       
    }
}

