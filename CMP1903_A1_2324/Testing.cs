using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */

        /// <summary>
        /// A Method to test the 2 game type classes to ensure they produce the desired output
        /// </summary>
        public static void TestCode()
        {
            // Passes the amount of die rolls that were the same and the current point total of 0
            // to test that the correct value is being added.
            // Debug.Assert is used to ensure that the value is the same as the expected value otherwise
            // an error is produced back to the user
            int Total = ThreeOrMore.PointAmounts(4,0);
            Debug.Assert(Total == 6);
            Total = ThreeOrMore.PointAmounts(5, 0);
            Debug.Assert(Total == 12);
            Total = ThreeOrMore.PointAmounts(3, 0);
            Debug.Assert(Total == 3);

            // An instance of the ThreeOrMore class is made
            ThreeOrMore TestObject = new ThreeOrMore();
            // the test integers of 1,2 and 3 are passed which will run 1 of 3 different if statements which set the player
            // totals to be either one above 20 or both above 20 and is checked to ensure the game ands and that the correct
            // end state is stored at index 0 in the returned array.
            // This is varified using Debug.Assert to raise an error if the wron value is passed
            int[] points = TestObject.ThreeOrMoreGame(false, 1);
            Debug.Assert(points[0] == 0);
            points = TestObject.ThreeOrMoreGame(false, 2);
            Debug.Assert(points[0] == 1);
            points = TestObject.ThreeOrMoreGame(false, 3);
            Debug.Assert(points[0] == 2);
            Console.WriteLine("ThreeOrMore Test completed. ");

            // Calls the object of sevenout and runs the game in test mode the values are then pulled
            // and added up to ensure they total up to be the correct amount
            SevenOut seven = new SevenOut();
            int sevenTotal = seven.SevenOutGame(false, true);
            List<int> currentNumbers = seven.rollNumbers;
            int valueTotal = 0;
            // A for loop increment by 2 where each if the adjacent rolled values are compared and if they are the same the total
            // is doubled otherwise the total is added dirrectly
            for (int i = 1; i < (currentNumbers.Count); i = i + 2)
            {
                if (currentNumbers[i] == currentNumbers[i-1])
                {
                    valueTotal = valueTotal + 2 * (currentNumbers[i] + currentNumbers[i - 1]);
                }
                else
                {
                    valueTotal = valueTotal + currentNumbers[i] + currentNumbers[i - 1]; ;
                }
                
            }
            Console.WriteLine(sevenTotal);
            Console.WriteLine(valueTotal);
            // Debug.assert is called to ensure that both the totalled value and returned value are the same.
            Debug.Assert(valueTotal == sevenTotal);

            // The dice roll should be set to be 3 and 4 so the game should end without the points increasing
            sevenTotal = seven.SevenOutGame(false, true, true);
            // Debug.Assert is called to ensure that the game ends correctly and hasn't continued or totaled for any rolls
            Debug.Assert(sevenTotal == 0);
            Console.WriteLine("SevenOut Test completed. ");




        }
    }
}   


