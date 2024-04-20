using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assesment2
{
    internal class Testing : game
    {
        /// <summary>
        /// Test function
        /// </summary>
        public void Test() 
        {
            //introduction message
            Console.WriteLine("what would you like to test");
 
            //calling the user selection function
            int selection = NewSelection("1.Sevens out - 2.three or more - 3.exit", 3);
            
            //if user wants to sets sevens out
            if (selection == 1)
            {
                //creating a new array to store the returned die
                int[] die = NewArray(2);

                //creating a new instance of the sevens out class
                var sevens = new Sevens__out();

                //calling the Test class within the sevens__out class
                //setting the new array to the array of die
                die = sevens.Testing();

                //checking if the die equals 7
                Debug.Assert(die[0] + die[1] == 7);

                //outputting the 2 dice rolls
                DisplayRoll(die);

                //outputing the results of the test in the terminal
                Console.WriteLine("Die1(" + die[0] + ") + Die2("+ die[1] + ") = " + (die[1] + die[0]));

                //returning back to the Game class
                return;
            }
            //if user wants to test three or more Game
            else if (selection == 2)
            {
                //creating a new instance of the three or more class
                var threes = new Three_or_more();

                //running the Test function, taking the nececary
                //data and adding it to an array
                int[] results = threes.Testing();

                //checking that score adds correctly
                Debug.Assert((results[0] + results[2]) == results[1]);

                //outputing the results into the terminal
                Console.WriteLine("points before(" + results[0] + ") + points to add(" + results[2] + ") = " + results[1]);

                //checking that the right amount of score is added
                if (results[3] == 3)
                {
                    Debug.Assert(results[2] == 3);

                }
                else if (results[3] == 6) 
                {
                    Debug.Assert(results[2] == 6);                
                }
                else if (results[3] == 12)
                {
                    Debug.Assert(results[2] == 12);
                }

                //checking that the final score is >= 20
                Debug.Assert(results[1] >= 20);

                //outputting the final score to the user
                Console.WriteLine("final score = " + results[1]);

                //returning back to Game class
                return;
            }
            //if user wants to exit
            else if(selection == 3)
            {
                //exiting out of the class
                return;
            }
        }

    }
}
