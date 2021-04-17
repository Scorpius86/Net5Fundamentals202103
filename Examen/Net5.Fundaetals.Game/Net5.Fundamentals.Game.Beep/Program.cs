using System;
using System.Collections.Generic;
using System.Timers;

namespace Net5.Fundamentals.Game.Beep
{
    class Program
    {
        static void Main(string[] args)
        {
            SuperMario superMario = new SuperMario();
            Tetris tetris = new Tetris();            
            StarWars starWars = new StarWars();
            superMario.PlaySong();
        }
    }
}
