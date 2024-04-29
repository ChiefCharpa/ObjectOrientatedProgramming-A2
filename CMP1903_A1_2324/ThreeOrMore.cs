using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class ThreeOrMore : Die
    {
        int[] _rolledDice = {0,0,0,0,0};

        /*Three or More
        5 x dice
        Rules:
	        Roll all 5 dice hoping for a 3-of-a-kind or better.
            If 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.
	        3-of-a-kind: 3 points
	        4-of-a-kind: 6 points
	        5-of-a-kind: 12 points
            First to a total of 20.
        */

        // Comparison check is a private static method that acts to take a fixed array and ensure
        // that for the 5 rolled values each amount of numbers of 1 - 6 are stored in a separate array
        // in a and the array 
        private static int[] ComparisonCheck(int[] rolledArray)
        {
            // placementArray is created with 6 index's set to 0
            int[] placementArray = { 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 6; i++)
            {
                int currentCount = 0;
                for (int j = 0; j < 5; j++)
                {
                    // the current value is the index's of the current index position
                    if (i + 1 == rolledArray[j])
                    {
                        // current count is incremented
                        currentCount++;
                    }
                }
                // the value is set to be the current stored count
                placementArray[i] = currentCount;
            }
            // the array is then returned back from the method
            return placementArray;
        }

        // PointAmounts is an internal static void which takes the number of die dupicates and
        // updates the point count accordingly
        internal static int PointAmounts(int dieNumber ,int points)
        {
            // if the number is greater than 3 then call the next if statement
                if (dieNumber > 3)
                {
                    // if the number is greater than 4 then call then the point total
                    // is updated by 12 and 5 of a kind is returned back to the user
                    if (dieNumber > 4)
                    {
                        Console.WriteLine("5 of a kind. ");
                        points = points + 12;
                    }
                    // the point total is updated by 6 and 4 of a kind is returned back to the user
                    else
                    {
                        Console.WriteLine("4 of a kind. ");
                        points = points + 6;
                    }
                }
                // the point total is updated by 3 and 3 of a kind is returned back to the user
                else
                {
                    Console.WriteLine("3 of a kind. ");
                    points = points + 3;
                }
                // the updated point total is returned back from the method
                return points;
        }

        // reRollDie is a private variable that takes the current value and point total and allows the
        // user to either reroll all or the other 3 values. It then rechecks to see if there is 3 or
        // more duplicates to then update points.
        private int reRollDie(int points , int currentValue, bool player)
        {
            // diceAmount is initiallied as an empty array along with creating a bool variable
            int[] diceAmount = { 0, 0, 0, 0, 0, 0 };
            bool invalid = true;
            string playerChoice = "";
            // invalid and player are true then display the roll options and store the value as player choice
            while (invalid && player)
            {
                Console.WriteLine ("You have rolled a pair so can reroll");
                Console.WriteLine ("1. to reroll the 3 nonmatching dice. ");
                Console.WriteLine ("2. to reroll all dice. ");
                playerChoice = Console.ReadLine();
                // if the players choice is an acceptable value set invalid to false
                if (playerChoice == "1" || playerChoice == "2")
                {
                    invalid = false;
                }
            }
            // if player is not true set the first 2 index's to be the current value
            if (!player)
            {
                Console.WriteLine("Rerolling the 3 dice. ");
                _rolledDice[0] = currentValue;
                _rolledDice[1] = currentValue;
                // for i from 0 to 2 roll call the roll mthod and store it in the variable current roll
                for (int i = 0; i < 3; i++)
                {
                    Roll();
                    int currentRoll = rollNumber;
                    // the current stored value is then added to the next available space in the array
                    _rolledDice[i + 2] = currentRoll;
                    Console.WriteLine($"Die {i + 1} has rolled {currentRoll}.");
                }
            }
            // if it is a player run if statement
            else
            {
                // if the player selected 1 then set the first 2 index's to be the current value
                if (playerChoice == "1")
                {
                    Console.WriteLine("Rerolling the 3 dice. ");
                    _rolledDice[0] = currentValue;
                    _rolledDice[1] = currentValue;
                    // for i from 0 to 2 roll call the roll mthod and store it in the variable current roll
                    for (int i = 0; i < 3; i++)
                    {
                        Roll();
                        int currentRoll = rollNumber;
                        // the current stored value is then added to the next available space in the array
                        _rolledDice[i + 2] = currentRoll;
                        Console.WriteLine($"Die {i + 1} has rolled {currentRoll}.");
                    }
                }
                // if the player inputs 2 then run Roll5Die
                else
                {
                    Roll5Die();
                }
            }
            // comparison check is then checked and stored in diceAmount
            diceAmount = ComparisonCheck(_rolledDice);
            for (int j = 0; j < diceAmount.Length; j++)
            {
                // if the amount of same values is greater than 2 then call the method diceAmounts
                if (diceAmount[j] > 2)
                {
                    points = PointAmounts(diceAmount[j], points);
                }
            }
            // rturn the point total
            return points;
        }
        // Roll5Die rolls 5 die and stores the value in _rolledDice
        private void Roll5Die()
        {
            // for i in the range of 0 to 4 then roll the dice and store the value in _rolledDice
            for (int i = 0; i < 5; i++)
            {
                Roll();
                int currentRoll = rollNumber;
                _rolledDice[i] = currentRoll;
                Console.WriteLine($"Die {i + 1} has rolled {currentRoll}.");
            }
        }

        
        // ThreeOrMoreGame is a public 
        public int[] ThreeOrMoreGame(bool player = false,int test = 0)
        {
            int[] playerScore = { 0, 0 };
            bool endOfGame = false;

            ThreeOrMore player1 = new ThreeOrMore();
            ThreeOrMore player2 = new ThreeOrMore();
            bool player1Win = false;
            bool player2Win = false;
            int player1Points = 0; 
            int player2Points = 0;
            int player1RoundNumber = 0;
            int player2RoundNumber = 0;
            while (!endOfGame)
            {
                if (test == 0)
                {
                    Console.WriteLine("Player 1. ");
                    Console.WriteLine($"You have {player1Points}. ");
                    player1Points = player1.ThreeOrMore1Player(player1Points, true);
                    player1RoundNumber++;
                    if (player)
                    {
                        Console.WriteLine("Player 2. ");
                        Console.WriteLine($"You have {player2Points}. ");
                        player2Points = player2.ThreeOrMore1Player(player2Points, true);
                        player2RoundNumber++;
                    }
                    else
                    {
                        Console.WriteLine("Computer. ");
                        Console.WriteLine($"The computer has {player2Points}. "); ;
                        player2Points = player2.ThreeOrMore1Player(player2Points, false);
                        player2RoundNumber++;
                    }
                    Console.WriteLine("Player 1. ");
                    Console.WriteLine($"You have {player1Points}. ");
                    player1Points = player1.ThreeOrMore1Player(player1Points, true);
                    player1RoundNumber++;
                    if (player)
                    {
                        Console.WriteLine("Player 2. ");
                        Console.WriteLine($"You have {player2Points}. ");
                        player2Points = player2.ThreeOrMore1Player(player2Points, true);
                        player2RoundNumber++;
                    }
                    else
                    {
                        Console.WriteLine("Computer. ");
                        Console.WriteLine($"The computer has {player2Points}. "); ;
                        player2Points = player2.ThreeOrMore1Player(player2Points, false);
                        player2RoundNumber++;
                    }
                }

                else if (test == 1)
                {
                    player1Points = 21;
                    player2Points = 20;
                }

                else if (test == 2)
                {
                    player1Points = 24;
                    player2Points = 19;
                }
                else
                {
                    player1Points = 6;
                    player2Points = 22;
                }
                

                if (player2Points >= 20 &&
                    player1Points >= 20)
                {
                    player1Win = true;
                    player2Win = true;
                    endOfGame = true;
                }
                if (player2Points >= 20)
                {
                    player2Win = true;
                    endOfGame = true;
                }
                if (player1Points >= 20)
                {
                    player1Win = true;
                    endOfGame = true;
                }
            }
            if (player1Win && player2Win)
            {
                playerScore[0] = 0;
                playerScore[1] = player1RoundNumber;
            }
            else if (player1Win)
            {
                playerScore[0] = 1;
                playerScore[1] = player1RoundNumber;
            }
            else
            {
                playerScore[0] = 2;
                playerScore[1] = player2RoundNumber;
            }
            return playerScore;
        }

        public int ThreeOrMore1Player(int points , bool player = false)
        {
            if (player)
            {
                Console.WriteLine("Roll 5 dice");
                Console.ReadLine();
            }
            Roll5Die();
            int[] diceAmount = ComparisonCheck(_rolledDice);
            bool reRoll = false;
            bool validRoll = false;
            int currentDuplicate = 0;
            for (int j = 0; j < diceAmount.Length; j++)
            {
                if (diceAmount[j] > 1)
                {
                    if (diceAmount[j] > 2)
                    {
                        points = PointAmounts(diceAmount[j],points);
                        validRoll = true;
                        break;
                    }
                    else
                    {
                        currentDuplicate = j;
                        reRoll = true;
                    }
                }
            }
            if ( reRoll && !validRoll)
            {
                if(player == true)
                {
                    points = reRollDie(points, currentDuplicate + 1, true);
                }
                else
                {
                    points = reRollDie(points, currentDuplicate + 1, false);
                }
            }
            return points;
        }
    }
}
