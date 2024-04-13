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
        private List<int> _storedRolls = new List<int> { };

        public List<int> rollNumbers
        {
            get { return _storedRolls; }
        }




        //Methods


        /* Mean method which can take 2 parameters (1 array and one possible bool),
       * and process the given array to calculate and outputs the mean and median
       */




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
                _storedRolls.Add(DieRoll);
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
                _storedRolls.Add(DieRoll);
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
                _storedRolls.Add(DieRoll);
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
                    Statistics.Mean(rollNumbers);
                    // The method mode is then called passing the stored array and outputting the result in the console window
                    Console.WriteLine($"The current mode of the dice is: {Statistics.Mode(rollNumbers)}");
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

        static void SevenOut()
        {
            //Rolls 2 dice
            Die die = new Die();

            for (int i = 0; i<2;  i++)
            {
                die.Roll();
                int DieRoll1 = die.rollNumber;
            }
            

        }

        static void Main(string[] args)
        {
            // initially initialises a boolean variable valid setting it to false
            bool valid = false;
            // Whilst the value is false iterate through the code
            while (!valid)
            {
                // A string variable InputtedValue is instantiated as an empty string
                string inputtedValue = "";
                // An output is produced in the console window asking if the user wants to run a test
                Console.WriteLine("Do you want to run the test: Y or N");
                // Try is used to ensure the user inputs a valid input and prevents any possible crashes
                try
                {
                    // The users input is taken and is attempted to be stored as a string in InputtedValue
                    inputtedValue = Console.ReadLine();
                    // Sets the given input to uppercase
                    inputtedValue = inputtedValue.ToUpper();
                    // The input is compared with the two valid answers and if it does valid is set to true
                    if (inputtedValue == "Y" || inputtedValue == "N")
                    {
                        valid = true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                // If an error is produced in try no code will be executed repeating the while loop
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid input, must be a character and be Y or X.");
                }

                // if the input was valid then the input is compared otherwise the code skips to the start of the while loop
                if (valid)
                {
                    // Compares the players input and if the value matches run the nested code
                    if (inputtedValue == "Y")
                    {
                        // Instaniates an object of the class testing
                        Testing testing = new Testing();
                        // the testing method test code is called
                        testing.TestCode();
                    }
                    // Create a Game object and call the RollingContinous method
                    Game game = new Game();
                    game.RollingContinuous(true);
                }
            }


        }

    }
}
