using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        /*
         * MenuOutput acts to display the menu options to the user upon being called
         */

        private static void MenuOutput()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. to play SevenOut");
            Console.WriteLine("2. to play ThreeOrMore");
            Console.WriteLine("3. to view that stored statistics for the games");
            Console.WriteLine("4. to run the testing class");
            Console.WriteLine("x. to end application");
        }


        /*
         * ComputerOrPlayer is a private method that acts to get the users choice for playing against 
         * a player or computer and performs whitelist validation on the input to prevent an error 
         * from being raised
         */
        private static string ComputerOrPlayer() 
        { 
            // Invalid is set to true and player input is set to empty
            bool invalid = true;
            string playerInput = "";
            // while invalid is true the player is asked to input 1 or 2 where the input will be stored
            while (invalid)
            {
                Console.WriteLine("1. to play against a player");
                Console.WriteLine("2. to play against the computer");
                playerInput = Console.ReadLine();
                // if the input is valid, then invalid is set to false 
                if (playerInput == "1" || playerInput == "2")
                {
                    invalid = false;
                }
                // if the input was invalid then an error message it outputted in the console window
                else
                {
                    Console.WriteLine("Input was invalid");
                }
            }
            // the users input is returned
            return playerInput;
        }


        /*
         * playerWin is a private static method that takes the players names and the array score to output the winner to the user in the console window 
         */
        private static void playerWin(int[] score, string player1Name, string player2Name = "Computer")
        {
            if (score[0] == 0)
            {
                Console.WriteLine("The game was a draw. ");
            }
            else if(score[0] == 1) 
            {
                Console.WriteLine($"{player1Name} has won. ");
            }
            else
            {
                Console.WriteLine($"{player2Name} has won. ");
            }
        }




        /*
        * The main class acts to output the menu and call the relevent class depending on the users choice
        */
        static void Main(string[] args)
        {
            // an object of statistics is instantiated
            Statistics stats = new Statistics();
            // A bool variable is set up to run the while loop until it is set to true
            bool end = false;
            while (end != true)
            {
                // Calls the menu output method and stores the users input as val
                MenuOutput();
                string val = Console.ReadLine();
                // whilst the input is valid
                if (val != null)
                {
                    // if the input was 1 then an instance of Seven out is made as an object
                    if (val == "1")
                    {
                        SevenOut game = new SevenOut();
                        // The method of ComputerOrPlayer is called and the value is stored in choice
                        string choice = ComputerOrPlayer();
                        // if choice is 1 then the players are both prompted to enter a name which is stored
                        if (choice == "1")
                        {
                            Console.WriteLine("Enter first players name.");
                            string player1 = Console.ReadLine();
                            Console.WriteLine("Enter second players name.");
                            string player2 = Console.ReadLine();
                            // Outputs to say it is player 1's turn and calls SevenOutGame in player mode and stores the value in player1Score
                            Console.WriteLine($"{player1}'s Turn. ");
                            int player1Score = game.SevenOutGame(true);
                            // Outputs to say it is player 2's turn and calls SevenOutGame in player mode and stores the value in player2Score
                            Console.WriteLine($"{player2}'s Turn. ");
                            int player2Score = game.SevenOutGame(true);
                            // Compares the players score and outputs the given winner or draw
                            if(player1Score > player2Score)
                            {
                                Console.WriteLine($"{player1} wins. ");
                                // if the value is greater than highscore a new value is set to the score and player name
                                if (player1Score > stats.Highscore)
                                {
                                    stats.Highscore = player1Score;
                                    stats.TopPlayer = player1;
                                }
                            }
                            else if(player2Score > player1Score)
                            {
                                Console.WriteLine($"{player2} wins. ");
                                // if the value is greater than highscore a new value is set to the score and player name
                                if (player2Score > stats.Highscore)
                                {
                                    stats.Highscore = player2Score;
                                    stats.TopPlayer = player2;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Draw. ");
                            }
                            // Increments the total of games played
                            stats.GamesRan = stats.GamesRan + 1;
                        }
                        // if choice is 2 then the player is prompted to enter a name which is stored
                        else
                        {
                            Console.WriteLine("Enter player's name.");
                            string player1 = Console.ReadLine();
                            // Outputs to say it is player 1's turn and calls SevenOutGame in player mode and stores the value in player1Score
                            Console.WriteLine($"{player1}'s Turn. ");
                            int player1Score = game.SevenOutGame(true);
                            // Outputs to say it is the computer's turn and calls SevenOutGame in computer mode and stores the value in player2Score
                            Console.WriteLine($"computer's Turn. ");
                            int player2Score = game.SevenOutGame(false);
                            // Compares the players score and outputs the given winner or draw
                            if (player1Score > player2Score)
                            {
                                Console.WriteLine($"{player1} wins. ");
                                // if the value is greater than highscore a new value is set to the score and player name
                                if (player1Score > stats.Highscore)
                                {
                                    stats.Highscore = player1Score;
                                    stats.TopPlayer = player1;
                                }
                            }
                            else if (player2Score > player1Score)
                            {
                                Console.WriteLine($"Computer wins. ");
                                stats.ComputerWins = stats.ComputerWins + 1;
                                if (player1Score > stats.Highscore)
                                {
                                    stats.Highscore = player1Score;
                                    stats.TopPlayer = player1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Draw. ");
                                if (player1Score > stats.Highscore)
                                {
                                    stats.Highscore = player1Score;
                                    stats.TopPlayer = player1;
                                }
                            }
                            // Increments the total of games played
                            stats.GamesRan = stats.GamesRan + 1;
                        }

                    }
                    // if the input was 1 then an instance of ThreeOrMore is made as an object
                    else if (val == "2")
                    {
                        // The method of ComputerOrPlayer is called and the value is stored in choice
                        string choice = ComputerOrPlayer();
                        ThreeOrMore game = new ThreeOrMore();
                        // if choice is 1 then the players are both prompted to enter a name which is stored
                        if (choice == "1")
                        {
                            Console.WriteLine("Enter first players name.");
                            string player1 = Console.ReadLine();
                            Console.WriteLine("Enter second players name.");
                            string player2 = Console.ReadLine();
                            // The method ThreeOrMoreGame is called in 2 player mode
                            int[] outcome = game.ThreeOrMoreGame(true);
                            // Games ran is incremented
                            stats.GamesRan = stats.GamesRan + 1;
                            // playerWin is called passing the array and 2 players names
                            playerWin(outcome, player1, player2);
                        }
                        // if choice is 2 then the player is prompted to enter a name which is stored
                        else
                        {
                            Console.WriteLine("Enter first players name.");
                            string player1 = Console.ReadLine();
                            // The method ThreeOrMoreGame is called in 2 player mode
                            int[] outcome = game.ThreeOrMoreGame(false);
                            // Games ran is incremented
                            stats.GamesRan = stats.GamesRan + 1;
                            // playerWin is called passing the array and players name
                            playerWin(outcome, player1);
                        }

                    }
                    // if val is 3 then call the method display stats
                    else if (val == "3")
                    {
                        stats.DisplayStats();
                    }
                    // if val is 4 then call method TestCode
                    else if(val == "4")
                    {
                        Testing.TestCode();
                    }
                    // if value is x then set end to be true
                    else if (val == "x")
                    {
                        end = true;
                    }
                    // output error for invalid input
                    else
                    {
                        Console.WriteLine("Invalid input. ");
                    }

                }
                // output error for input entered
                // output error for input entered
                else
                {
                    Console.WriteLine("No input was entered. ");
                }
            }



        }

    }
}
