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
            Console.WriteLine("success");
            var Dice = new Die();
            return Dice.Roll();
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
                int selection = 0;
                while (true)
                {
                    //getting user input for what they would like to do
                    try
                    {
                        Console.WriteLine("1.Sevens out - 2.three or more - 3.statistics - 4.testing - 5.exit");
                        selection = int.Parse(Console.ReadLine());
                        if (selection == 1 || selection == 2 || selection == 3 || selection == 4 || selection == 5)
                        {
                            break;
                        }
                        Console.WriteLine("please enter 1 2 3 4 or 5");
                    }
                    catch
                    {
                        Console.WriteLine("invalid input");
                    }
                }
                //if the user selects the number 1 it will run the sevens out game
                //then it will check if there is a new high score by calling the update
                //function from the statistics class
                if (selection == 1)
                {
                    var sevens = new Sevens__out();
                    int score = sevens.main();
                    stats.update(score, 1);
                }
                else if(selection == 2)
                {
                    var threes = new Three_or_more();
                    threes.main();
                    stats.update(0, 2);

                }
                //if the user selects 3 then it will call the stats function from the statistics class
                else if (selection == 3)
                {
                    
                    stats.stats();
                }
                //if 4 is selected it will test the code
                else if (selection == 4)
                {
                    //calling the testing class
                    var test = new Testing();
                    test.testing();

                }
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
