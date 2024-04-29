using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class SevenOut : Die
    {
        // _storedRolls if a private list which is encapsulated and is accessed via the constructor rollNumbers
        private List<int> _storedRolls = new List<int> { };

        // constructor method rollNumbers to access and set _storedRolls
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
            // rolledNumbers is called to set _storedRolls
            rollNumbers = new List<int> { };
            // the total and counter are set to 0 and gamestop is created to be false
            int dieTotal = 0;
            bool gameStop = false;
            int counter = 0;
            // Whilst gameStopisnt try call the loop
            while (!gameStop)
            {
                //if player is true promt the user to roll the dice and red the users input
                //but dont store the given value
                if (player)
                {
                    Console.WriteLine("Roll the dice");
                    Console.ReadLine();
                }
                // Call the inherited roll method from the Die class 
                Roll();
                counter++;
                // retrieve the stored encapsulated variable for the rolled value from the Die class
                int DieRoll1 = rollNumber;
                // Call the inherited roll method from the Die class
                Roll();
                int DieRoll2 = rollNumber;
                // If test is not true output the rolled die values back to the user
                if(!test)
                {
                    Console.WriteLine($"Die pair {counter} rolled {DieRoll1} and {DieRoll2}");
                }
                // if the second test is true set the die rolls to total to add up to 7
                if(secondtest)
                {
                    DieRoll1 = 3;
                    DieRoll2 = 4;
                }
                // if the total of the two die rolls arent 7 then add the current rolls to stored rolls
                if (DieRoll1 + DieRoll2 != 7)
                {
                    _storedRolls.Add(DieRoll1);
                    _storedRolls.Add(DieRoll2);
                    // if the two die are the same double the total otherwise just add the total
                    if (DieRoll1 == DieRoll2)
                    {
                        dieTotal = dieTotal + 2 * (DieRoll1 + DieRoll2);
                    }
                    else
                    {
                        dieTotal = dieTotal + (DieRoll1 + DieRoll2);
                    }
                }
                // if the total added to be 7 set game stop to be true and output the total back to the user
                else
                {
                    gameStop = true;
                    Console.WriteLine("The pair totalled to be 7.");
                    Console.WriteLine($"You scored a total of {dieTotal}");
                }
            }
            // returns the total back to the user
            return dieTotal;

        }

    }
}
