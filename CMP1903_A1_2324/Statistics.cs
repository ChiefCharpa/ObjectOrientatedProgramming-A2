﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Statistics
    {
        private int _Highscore = 0;
        private string _TopPlayer = "";
        private int _ComputerWins = 0;
        private int _GamesRan = 0;

        public int Highscore 
        { 
            get { return _Highscore; } 
            set { _Highscore = value; }
        }

        public string TopPlayer
        {
            get { return _TopPlayer; }
            set { _TopPlayer = value; }
        }

        public int ComputerWins
        {
            get { return _ComputerWins; }
            set { _ComputerWins = value; }
        }
    
        public int GamesRan
        {
            get { return _GamesRan; }
            set { _GamesRan = value; }
        }

        public void DisplayStats()
        {
            Console.WriteLine("Statistics:");
            Console.WriteLine($"The current Highscore holder on Seven Out is {TopPlayer} with {Highscore}.");
            Console.WriteLine($"The total amount of computer wins is {ComputerWins}.");
            Console.WriteLine($"A total of {GamesRan} games have been ran");
        }
    }
}
