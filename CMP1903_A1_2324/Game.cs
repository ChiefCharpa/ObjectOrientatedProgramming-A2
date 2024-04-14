using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        /*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continous, and the totals and other statistics could be summarised for example.
         */

        private static void MenuOutput()
        {
            Console.WriteLine("1. to play SevenOut");
            Console.WriteLine("2. to play ThreeOrMore");
            Console.WriteLine("3. to view that stored statistics for the games");
            Console.WriteLine("4. to run the testing class");
            Console.WriteLine("x. to end application");
        }

        private static void ComputerOrPlayer() 
        { 
            bool invalid = true;
            while (invalid)
            {
                Console.WriteLine("1. to play against a player");
                Console.WriteLine("2. to play against the computer");
                string playerInput = Console.ReadLine();
                if (playerInput == "1" || playerInput == "2")
                {
                    invalid = false;
                }
                else
                {
                    Console.WriteLine("Input was invalid");
                }
            }

        }

        //Methods


        /* Mean method which can take 2 parameters (1 array and one possible bool),
       * and process the given array to calculate and outputs the mean and median
       */




        // Acts to rolls dice 3 at a time until the user stops the rolling
           
        

        

        static void Main(string[] args)
        {
            bool end = false;
            while (end != true)
            {
                MenuOutput();
                string val = Console.ReadLine();
                if (val != null)
                {
                    if (val == "1")
                    {
                        SevenOut game = new SevenOut();

                    }
                    else if (val == "2")
                    {

                    }
                    else if (val == "3")
                    {

                    }
                    else if(val == "4")
                    {

                    }
                    else if (val == "x")
                    {

                    }
                    else
                    {

                    }

                }
            }




            game.SevenOutGame(false);


        }

    }
}
