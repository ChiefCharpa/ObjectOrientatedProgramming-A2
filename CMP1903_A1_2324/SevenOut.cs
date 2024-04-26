using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class SevenOut : Die
    {

        private List<int> _storedRolls = new List<int> { };

        public List<int> rollNumbers
        {
            get { return _storedRolls; }
            set { _storedRolls = value; }
        }

        /*
            Sevens Out
            2 x dice
            Rules:
	            Roll the two dice, noting the total rolled each time.
                 If it is a 7 - stop.
                 If it is any other number - add it to your total.
                    If it is a double - add double the total to your score(3,3 would add 12 to your total)
        */


        public int SevenOutGame(bool player, bool test = false, bool secondtest = false)
        {
            rollNumbers = new List<int> { };
            //Rolls 2 dice
            int dieTotal = 0;
            bool gameStop = false;
            int counter = 0;
            while (!gameStop)
            {
                if (player)
                {
                    Console.WriteLine("Roll the dice");
                    Console.ReadLine();
                }
                Roll();
                counter++;
                int DieRoll1 = rollNumber;
                Roll();
                int DieRoll2 = rollNumber;
                if(!test)
                {
                    Console.WriteLine($"Die pair {counter} rolled {DieRoll1} and {DieRoll2}");
                }
                if(secondtest)
                {
                    DieRoll1 = 3;
                    DieRoll2 = 4;
                }
                if (DieRoll1 + DieRoll2 != 7)
                {
                    _storedRolls.Add(DieRoll1);
                    _storedRolls.Add(DieRoll2);
                    if (DieRoll1 == DieRoll2)
                    {
                        dieTotal = dieTotal + 2 * (DieRoll1 + DieRoll2);
                    }
                    else
                    {
                        dieTotal = dieTotal + (DieRoll1 + DieRoll2);
                    }
                }
                else
                {
                    gameStop = true;
                    Console.WriteLine("The pair totalled to be 7.");
                    Console.WriteLine($"You scored a total of {dieTotal}");
                }
            }
            return dieTotal;

        }

    }
}
