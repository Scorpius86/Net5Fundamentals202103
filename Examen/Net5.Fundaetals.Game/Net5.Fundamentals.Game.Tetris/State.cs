using System;
using System.Collections.Generic;
using System.Text;

namespace Net5.Fundamentals.Game.Tetris
{
    public class State
    {
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public int CurrentIndex { get; set; }
        public char CurrentChar { get; set; }
        public int CurrentRot { get; set; }

        public int HoldSizeX { get; set; }
        public int HoldSizeY { get; set; }
        public int HoldIndex { get; set; }
        public char HoldChar { get; set; }

        public int[] Bag { get; set; }
        public int BagIndex { get; set; }
        public int[] NextBag { get; set; }
        
        public char[,] BG { get; set; }
        public int[,,,] Blocks { get; set; }

        public int UpNextSize { get; set; }
        public string PixelTypes { get; set; }        
        public int Score { get; set; }

        public int MapSizeX { get; set; }
        public int MapSizeY { get; set; }

        public ConsoleKeyInfo Input { get; set; }

        public int MaxTime { get; set; }
        public int Timer { get; set; }
        public int Amount { get; set; }

        public State()
        {
            // Map / BG 
            MapSizeX = 10;
            MapSizeY = 20;
            BG = new char[MapSizeY, MapSizeX];
            Blocks = GetBlocks();
            Score = 0;

            // Hold variables
            HoldSizeX = 6;
            HoldSizeY = MapSizeY;
            HoldIndex = -1;

            UpNextSize = 6;
            PixelTypes = "OILJSZT";

            // Current info
            CurrentX = 0;
            CurrentY = 0;
            CurrentChar = 'O';
            CurrentRot = 0;

            // misc
            MaxTime = 20;
            Timer = 0;
            Amount = 0;
        }

        private int[,,,] GetBlocks()
        {
            int[,,,] blocks =
            {
                {//0   ██
                 //    ██
                    {//0
                        {//0
                            0,//0
                            0//1
                        },
                        {//1
                            1,//0
                            0//1
                        },{0,1},{1,1}},
                    {{0,0},{1,0},{0,1},{1,1}},
                    {{0,0},{1,0},{0,1},{1,1}},
                    {{0,0},{1,0},{0,1},{1,1}}
                },
                {//1   █
                 //    █
                 //    █
                 //    █
                    {//0
                        {//0
                            2,//0 X
                            0//1  Y
                        },{2,1},{2,2},{2,3}},
                    {{0,2},{1,2},{2,2},{3,2}},
                    {{1,0},{1,1},{1,2},{1,3}},
                    {{0,1},{1,1},{2,1},{3,1}},
                },
                {//2   █
                 //    █
                 //    ██
                    {//0
                        {//0
                            1,//0  X
                            0//1   Y
                        },
                        {//1
                            1,//0
                            1//1
                        },{1,2},{2,2}},
                    {{1,2},{1,1},{2,1},{3,1}},
                    {{1,1},{2,1},{2,2},{2,3}},
                    {{2,1},{2,2},{1,2},{0,2}}
                },
                {//3     █
                 //      █
                 //     ██
                 //   X,Y 
                    {{2,0},{2,1},{2,2},{1,2}},
                    {{1,1},{1,2},{2,2},{3,2}},
                    {{2,1},{1,1},{1,2},{1,3}},
                    {{0,1},{1,1},{2,1},{2,2}}
                },
                {//4     ██
                 //     ██             
                    {//0 
                     //   
                        {//0
                            2,//0 X
                            1//1  Y
                        },
                        {//1
                            1,//0 X
                            1//1  Y
                        },
                        {
                            1,
                            2
                        },
                        {
                            0,
                            2
                        }
                    },
                    {{1,0},{1,1},{2,1},{2,2}},
                    {{2,1},{1,1},{1,2},{0,2}},
                    {{1,0},{1,1},{2,1},{2,2}}
                },
                {//5    ██
                 //      ██
                    {{0,1},{1,1},{1,2},{2,2}},
                    {{1,0},{1,1},{0,1},{0,2}},
                    {{0,1},{1,1},{1,2},{2,2}},
                    {{1,0},{1,1},{0,1},{0,2}}
                },
                {//6     █
                 //     ███
                    {{0,1},{1,1},{1,0},{2,1}},
                    {{1,0},{1,1},{2,1},{1,2}},
                    {{0,1},{1,1},{1,2},{2,1}},
                    {{1,0},{1,1},{0,1},{1,2}}
                }
            };

            return blocks;
        }
    }
}
