using System;
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
        private int _ = 0;

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
            set { _ComputerWins = _ComputerWins + 1; }
        }
    
        public int GamesRan
    }
}
