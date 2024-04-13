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
        private int[] _storedRolls = { };




        //Methods


        /* Mean method which can take 2 parameters (1 array and one possible bool),
       * and process the given array to calculate and outputs the mean and median
       */

        public void Mean(int[] DiceRollArray, bool Testing = false)
        {
            // The function initially uses the sort function to arrange the values in acsending order
            Array.Sort(DiceRollArray);
            // The variables Total and Count are instantiated for later use
            int Total = 0;
            int Count = 0;
            // It then iterates for each value in the array passing each given value to the vaiable DiceRoll
            foreach (int DiceRoll in DiceRollArray)
            {
                // Adds the given value to The Total variable
                Total += DiceRoll;
                // Adds 1 to count
                Count++;
            }
            // Calculates the mean by dividing the mean by the total
            float Mean = Total / Count;
            // Outputs the calculated mean in the console
            Console.WriteLine($"The average mean of the dice is: {Mean}");
            // Calculates the midpoint in the array and stores value in the variable midpoint 
            int midpoint = Count / 2;
            // Instantiates the variable median
            int median;
            // For if the midpoint is even or odd the middle most value is called
            if (Count % 2 != 0)
            {
                median = DiceRollArray[midpoint];
            }
            else
            {
                median = DiceRollArray[midpoint - 1];
            }
            // Outputs the calculated median into the console window
            Console.WriteLine($"The median of the dice is: {median}");
            // if testing is true it validates to make sure that both mean and median are in an acceptable range
            if (Testing)
            {
                Debug.Assert(median > 0 && median < 7);
                Debug.Assert(Mean > 0 && Mean < 7);
            }
        }

        /* Mode method takes 2 parameters (1 an array and one a bool variable) 
         * and calculates the given mode for the array returning the mode from the method
         */
        public int Mode(int[] DiceRollArray, bool Testing = false)
        {
            // The method initially uses the sort function to arrange the values in acsending order
            Array.Sort(DiceRollArray);
            // Initiallises 2 variables mode and Most
            int mode = 0;
            int Most = 0;
            // Iterates through the array storing the current value as j
            foreach (int j in DiceRollArray)
            {
                // instantiatescount seting it to 0
                int count = 0;
                // iterates through the list storing the values as i
                foreach (int i in DiceRollArray)
                {
                    // for each instance i and j are the same, increment count
                    if (i == j)
                    {
                        count++;
                        // if count exceeds most mode is set to the current value of j and sets Most to count
                        if (count > Most)
                        {
                            mode = j;
                            Most = count;
                        }
                    }
                }
            }
            // if testing is set to true then it tests to ensure mode is in its acceptable range
            if (Testing)
            {
                Debug.Assert(mode > 0 && mode < 7);
            }
            // returns the value of mode 
            return mode;

        }

    

    // Acts to rolls dice 3 at a time until the user stops the rolling
        public void RollingContinuous(bool val, bool testRun = false)
        {
            // Takes the first boolean parameter and whilst Val is true iterate the while loop
            while (val == true)
            {
                // Creates instance of the die class
                Die die1 = new Die();
                // calls the roll method Roll for the Die class for the instance
                die1.Roll();
                // The stored variable is called and its value is stored in the DieRoll variable
                int DieRoll = die1.rollNumber;
                // The value stored in DieRoll is appended to the array storedRolls
                _storedRolls = _storedRolls.Append(DieRoll).ToArray();
                // Outputs the current dice number with the dices curtrent value
                Console.WriteLine();
                Console.WriteLine($"Dice {_storedRolls.Count()} rolled a {DieRoll}");
                /*
                    for (int i = 0; i < 3; i++) 
                    {
                        die.Roll();
                        int DieRoll = die.RollNumber;
                        storedRolls = storedRolls.Append(DieRoll).ToArray();
                        Console.WriteLine();
                        Console.WriteLine($"Dice {storedRolls.Count()} rolled a {DieRoll}");
                    }
                */
                // Creates instance of the die class
                Die die2 = new Die();
                // calls the roll method Roll for the Die class for the instance
                die2.Roll();
                // The stored variable is called and its value is stored in the DieRoll variable
                DieRoll = die2.rollNumber;
                // The value stored in DieRoll is appended to the array storedRolls
                _storedRolls = _storedRolls.Append(DieRoll).ToArray();
                // Outputs the current dice number with the dices curtrent value
                Console.WriteLine();
                Console.WriteLine($"Dice {_storedRolls.Count()} rolled a {DieRoll}");
                // Creates instance of the die class
                Die die3 = new Die();
                // calls the roll method Roll for the Die class for the instance
                die3.Roll();
                // The stored variable is called and its value is stored in the DieRoll variable
                DieRoll = die3.rollNumber;
                // The value stored in DieRoll is appended to the array storedRolls
                _storedRolls = _storedRolls.Append(DieRoll).ToArray();
                // Outputs the current dice number with the dices curtrent value
                Console.WriteLine();
                Console.WriteLine($"Dice {_storedRolls.Count()} rolled a {DieRoll}");

                // instantiates a variable to store the total of the dice
                int Total = 0;
                // iterates through the list adding each roll stored to the total variable
                foreach (int previousRoll in _storedRolls)
                {
                    Total = Total + previousRoll;
                }
                // Ouputs the total of the dice in the command console
                Console.WriteLine();
                Console.WriteLine($"The current total of the dice is: {Total}");
                Console.WriteLine();
                // checks to see if the method is being called in test mode and setting the loop to end accordingly
                if (testRun)
                {
                    val = false;
                }
                else
                {
                    // if not in test mode the method Mean is called passing the array of stored rolls as a parameter
                    Mean(_storedRolls);
                    // The method mode is then called passing the stored array and outputting the result in the console window
                    Console.WriteLine($"The current mode of the dice is: {Mode(_storedRolls)}");
                    Console.WriteLine();
                    // An output is produced in the console asking if they want to roll 3 more dice
                    Console.WriteLine("Do you want to roll 3 more dice: X to quit");
                    //try is then used to ensure no errors are produced by the users input
                    try
                    {
                        // The console reads the users input and attempts to store the value as a string  in InputtedValue
                        string InputtedValue = Console.ReadLine();
                        // If the inputed value is an x Val is set to false ending the while loop 
                        if (InputtedValue == "x" || InputtedValue == "X")
                        {
                            val = false;
                            // A final message is produced in the command window to signify the end of the program
                            Console.WriteLine("Program end.");
                        }
                        else
                        {
                            throw new Exception();
                        }
                    //if inputted value was invalid or not x the program will roll 3 more dice
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("X has not been inputted, rolling 3 more dice. ");
                    }
                }
            }
        }

    }
}
