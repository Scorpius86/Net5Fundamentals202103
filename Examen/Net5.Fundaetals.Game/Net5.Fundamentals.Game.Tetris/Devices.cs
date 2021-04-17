using System;
using System.Collections.Generic;
using System.Text;

namespace Net5.Fundamentals.Game.Tetris
{
    public class Devices
    {
        private Brain brain { get; set; }
        private ConsoleKeyInfo InputKey { get; set; }

        public Devices()
        {
            brain = new Brain();
        }

        public void InputHandler(State state)
        {
            switch (InputKey.Key)
            {
                // Left arrow = move left (if it doesn't collide)
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (!brain.Collision(state.CurrentIndex, state.BG, state.CurrentX - 1, state.CurrentY, state.CurrentRot,state)) state.CurrentX -= 1;
                    break;

                // Right arrow = move right (if it doesn't collide)
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (!brain.Collision(state.CurrentIndex, state.BG, state.CurrentX + 1, state.CurrentY, state.CurrentRot,state)) state.CurrentX += 1;
                    break;

                // Rotate block (if it doesn't collide)
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    int newRot = state.CurrentRot + 1;
                    if (newRot >= 4) newRot = 0;
                    if (!brain.Collision(state.CurrentIndex, state.BG, state.CurrentX, state.CurrentY, newRot,state)) state.CurrentRot = newRot;

                    break;

                // Move the block instantly down (hard drop)
                case ConsoleKey.Spacebar:
                    int i = 0;
                    while (true)
                    {
                        i++;
                        if (brain.Collision(state.CurrentIndex, state.BG, state.CurrentX, state.CurrentY + i, state.CurrentRot,state))
                        {
                            state.CurrentY += i - 1;
                            break;
                        }

                    }
                    state.Score += i + 1;
                    break;

                // Quit
                case ConsoleKey.Escape:
                    Environment.Exit(1);
                    break;

                // Hold block
                case ConsoleKey.Enter:

                    // If there isnt a current held block:
                    if (state.HoldIndex == -1)
                    {
                        state.HoldIndex = state.CurrentIndex;
                        state.HoldChar = state.CurrentChar;
                        brain.NewBlock(state);
                    }
                    // If there is:
                    else
                    {
                        if (!brain.Collision(state.HoldIndex, state.BG, state.CurrentX, state.CurrentY, 0,state)) // Check for collision
                        {

                            // Switch current and hold
                            int c = state.CurrentIndex;
                            char ch = state.CurrentChar;
                            state.CurrentIndex = state.HoldIndex;
                            state.CurrentChar = state.HoldChar;
                            state.HoldIndex = c;
                            state.HoldChar = ch;
                        }

                    }
                    break;

                // Move down faster
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    state.Timer = state.MaxTime;
                    break;
                default:
                    break;
            }

            InputKey = new ConsoleKeyInfo(); // Reset input var
        }
        public void Input()
        {
            while (true)
            {
                // Get input
                InputKey = Console.ReadKey(true);
            }
        }
        public void PlaySong()
        {
            //Songs songs = new Songs();
            StarWarsSong starWarsSong = new StarWarsSong();
            while (true)
            {
                starWarsSong.Play();
            }
        }
    }
}
