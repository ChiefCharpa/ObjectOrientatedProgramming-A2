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

        //Method
        public static void TestCode()
        {
            int Total = ThreeOrMore.PointAmounts(4,0);
            Debug.Assert(Total == 6);
            Total = ThreeOrMore.PointAmounts(5, 0);
            Debug.Assert(Total == 12);
            Total = ThreeOrMore.PointAmounts(3, 0);
            Debug.Assert(Total == 3);
            ThreeOrMore TestObject = new ThreeOrMore();
            int[] points = TestObject.ThreeOrMoreGame(false, 1);
            Debug.Assert(points[0] == 0);
            points = TestObject.ThreeOrMoreGame(false, 2);
            Debug.Assert(points[0] == 1);
            points = TestObject.ThreeOrMoreGame(false, 3);
            Debug.Assert(points[0] == 2);

            // Calls the object of sevenout and runs the game in test mode the values are then pulled
            // and added up to ensure they total up to be the correct amount
            SevenOut seven = new SevenOut();
            int sevenTotal = seven.SevenOutGame(false, true);
            List<int> currentNumbers = seven.rollNumbers;
            int valueTotal = 0;
            for (int i = 0; i < (currentNumbers.Count); i++)
            {
                valueTotal = valueTotal + currentNumbers[i];
            }
            Console.WriteLine(valueTotal);
            Debug.Assert(valueTotal == sevenTotal);

            // The dice roll should be set to be 3 and 4 so the game should end without the points increasing
            sevenTotal = seven.SevenOutGame(false, true, true);
            Debug.Assert(sevenTotal == 0);




        }
    }
}   


