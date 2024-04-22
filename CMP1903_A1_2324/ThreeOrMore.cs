using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class ThreeOrMore
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
        private static int[] ComparisonCheck(int[] rolledArray)
        {
            int[] placementArray = { 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 6; i++)
            {
                int currentCount = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (i + 1 == rolledArray[j])
                    {
                        currentCount++;
                    }
                }
                placementArray[i] = currentCount;
            }
            return placementArray;
        }

        private static int PointAmounts(int dieNumber ,int points)
        {
                if (dieNumber > 3)
                {
                    if (dieNumber > 4)
                    {
                        Console.WriteLine("5 of a kind. ");
                        points = points + 12;
                    }
                    else
                    {
                        Console.WriteLine("4 of a kind. ");
                        points = points + 6;
                    }
                }
                else
                {
                    Console.WriteLine("3 of a kind. ");
                    points = points + 3;
                }
                return points;
        }


        private int reRollDie(int points , int currentValue, bool player)
        {
            int[] diceAmount = { 0, 0, 0, 0, 0, 0 };
            Die die = new Die();
            bool invalid = true;
            string playerChoice = "";
            while (invalid && player)
            {
                Console.WriteLine ("You have rolled a pair so can reroll");
                Console.WriteLine ("1. to reroll the 3 nonmatching dice. ");
                Console.WriteLine ("2. to reroll all dice. ");
                playerChoice = Console.ReadLine();
                if (playerChoice == "1" || playerChoice == "2")
                {
                    invalid = false;
                }
            }
            if (!player)
            {
                Console.WriteLine("Rerolling the 3 dice. ");
                _rolledDice[0] = currentValue;
                _rolledDice[1] = currentValue;
                for (int i = 0; i < 3; i++)
                {
                    die.Roll();
                    int currentRoll = die.rollNumber;
                    _rolledDice[i + 2] = currentRoll;
                    Console.WriteLine($"Die {i + 1} has rolled {currentRoll}.");
                }
            }
            else
            {
                if (playerChoice == "1")
                {
                    Console.WriteLine("Rerolling the 3 dice. ");
                    _rolledDice[0] = currentValue;
                    _rolledDice[1] = currentValue;
                    for (int i = 0; i < 3; i++)
                    {
                        die.Roll();
                        int currentRoll = die.rollNumber;
                        _rolledDice[i + 2] = currentRoll;
                        Console.WriteLine($"Die {i + 1} has rolled {currentRoll}.");
                    }
                }
                else
                {
                    Roll5Die();
                }
            }
            diceAmount = ComparisonCheck(_rolledDice);
            for (int j = 0; j < diceAmount.Length; j++)
            {
                if (diceAmount[j] > 2)
                {
                    points = PointAmounts(diceAmount[j], points);
                }
            }

            return points;
        }

        private void Roll5Die()
        {
            Die die = new Die();
            for (int i = 0; i < 5; i++)
            {
                die.Roll();
                int currentRoll = die.rollNumber;
                _rolledDice[i] = currentRoll;
                Console.WriteLine($"Die {i + 1} has rolled {currentRoll}.");
            }
        }

        

        public int[] ThreeOrMoreGame(bool player = false)
        {
            int[] playerScore = { 0, 0 };
            bool endOfGame = false;

            ThreeOrMore player1 = new ThreeOrMore();
            ThreeOrMore player2 = new ThreeOrMore();
            bool player1Win = false;
            bool player2Win = false;
            int player1Points = 0; 
            int player2Points = 0;
            while (!endOfGame)
            {
                Console.WriteLine("Player 1. ");
                Console.WriteLine($"You have {player1Points}. ");
                player1Points = player1.ThreeOrMore1Player(player1Points,true);
                if (player)
                {
                    Console.WriteLine("Player 2. ");
                    Console.WriteLine($"You have {player2Points}. ");
                    player2Points = player2.ThreeOrMore1Player(player2Points, true);
                }
                else
                {
                    Console.WriteLine("Computer. ");
                    Console.WriteLine($"The computer has {player2Points}. ");;
                    player2Points = player2.ThreeOrMore1Player(player2Points, false);
                }
                if (player2Points >= 20 && player1Points >=20)
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
                playerScore[1] = player1Points;
            }
            else if (player1Win)
            {
                playerScore[0] = 1;
                playerScore[1] = player1Points;
            }
            else
            {
                playerScore[0] = 2;
                playerScore[1] = player2Points;
            }
            return playerScore;
        }

        public int ThreeOrMore1Player(int points , bool player = false)
        {
            Die die = new Die();
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
