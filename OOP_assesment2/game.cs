using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assesment2
{
    internal class game
    {
        /// <summary>
        /// creating a protected function to be inherited by the children
        /// classes Three_or_more and Sevens_out
        /// </summary>
        /// <returns>a new die number between 1 and 6</returns>
        protected int RollDice()
        {
            var Dice = new Die();
            return Dice.Roll();
        }

        /// <summary>
        /// creates a new array of size n
        /// </summary>
        /// <param name="n">size of the array</param>
        /// <returns>new array of length n</returns>
        protected int[] newArray(int n)
        {
            return new int[n];
        }
        /// <summary>
        /// getting user input for selections
        /// </summary>
        /// <param name="question">the string of text to be outputted on the terminal</param>
        /// <param name="num">the number of options to chose from</param>
        /// <returns>the user selection</returns>
        public static int newSelection(string question, int num)
        {
            //creating an empty int to store the selection value
            int selection = 0;

            //looping until it is broken out of
            while (true)
            {
                //adding try and catch block for errenous input
                try
                {
                    //outputting the question to the user
                    Console.WriteLine(question);

                    //taking the user input and turning it into an int
                    selection = int.Parse(Console.ReadLine());

                    //cheking if the user input is valid
                    if (selection >= 1 && selection <= num)
                    {
                        //breaking out of the loop
                        break;
                    }
                    //if user input is out of range
                    Console.WriteLine("please enter a number between 1 - " + num);
                }
                catch
                {
                    //outputting an error message
                    Console.WriteLine("invalid input");
                }
            }
            //returning the final user input
            return selection;

        }
        /// <summary>
        /// creating an instance of the random function so it isn't
        /// called multiple times throughout the code
        /// </summary>
        
        public static Random RandomInstance { get; } = new Random();

        /// <summary>
        /// the main function where all of the code is run from 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //creating an instance of the statistics class
            var stats = new statistics();

            //creating a variable to store the users input
            

            //setting the exit boolean to false 
            bool exit = false;

            //loop that will repeat until the user decides to exit
            while (exit == false) 
            {
                int selection = newSelection("1.Sevens out - 2.three or more - 3.statistics - 4.testing - 5.exit", 5);
                
                
                //if the user selects the number 1 it will run the sevens out game
                //then it will check if there is a new high score by calling the update
                //function from the statistics class
                if (selection == 1)
                {
                    //creating a new instance of the sevens out game
                    var sevens = new Sevens__out();

                    //running the game and storing the returned final score
                    int score = sevens.main();

                    //updating the statistics
                    stats.update(score, 1);
                }
                //if the user selects 2 it will run the three or more game
                else if(selection == 2)
                {
                    //creating a new instance of three or more
                    var threes = new Three_or_more();

                    //running the game
                    threes.main();

                    //updating the game accordingly
                    stats.update(0, 2);

                }
                //if the user selects 3 then it will call the stats function from the statistics class
                else if (selection == 3)
                {
                    //outputting the statistics
                    stats.stats();
                }
                //if 4 is selected it will test the code
                else if (selection == 4)
                {
                    //creating a new instance of the testing class
                    var test = new Testing();

                    //calling the testing function
                    test.testing();

                }
                //if selection is 5 it will end the code
                else if (selection == 5)
                {
                    //will exit the game class, in turn exiting the game
                    Console.WriteLine("exiting....");

                    return;
                }

            }
            
        }
    }
}
