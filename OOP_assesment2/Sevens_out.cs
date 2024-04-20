using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assesment2
{
    internal class Sevens__out : game
    {
        // a public variable within the class to store the total score
        public int total = 0;
        
        /// <summary>
        /// will roll 2 dice until a 7 is rolled, if there is a 2
        /// of a kind the score will double
        /// </summary>
        /// <returns>the final score</returns>
        public int Main() 
        {
            //introductoary messages
            Console.WriteLine("Welcome to sevens out");
            Console.WriteLine("press enter to roll again");

           
            //looping until win condition is met    
            while (true)
            {
                //creating 2 dice objects
                int[] dice = RollDie(2);
                
                //outputting the results of the rolls and the roll number               
                DisplayRoll(dice);

                //calling the check function to do nececary actions on the 
                //result of the die rolls
                int check = CheckDice(dice[0], dice[1]);

                //if 0 is returned from the CheckDice function, the Game is
                //over as the result of the die is 7
                if (check == 0)
                {
                    //final output messages, displaying the final scores
                    Console.WriteLine("7 rolled, gameover");

                    Console.WriteLine("final score = " + total);

                    //returning the final score
                    return total;
                }

                //if 1 is returned, both die are the same so a message is outputted
                else if (check == 1)
                {
                    Console.WriteLine("double rolled, 2x score");
                }

                //outputting then current total
                Console.WriteLine("total = " + total);

                //waiting for the user to press a button before the next set of di are rolled
                Console.ReadLine();
            }
            

        }


        /// <summary>
        /// it will check the result of the 2 die rolled, if they are the same it 
        /// will add double the sum of the die to the total.
        /// if the sum is 7 it will return 7 to indicate that the Game is over
        /// else it will ad both dice to the sum
        /// </summary>
        /// <param name="die_1">the first die rolled</param>
        /// <param name="die_2">the seccond die rolled</param>
        /// <returns>an integer determining what state the Game is in</returns>
        private int CheckDice(int die_1, int die_2)
        {
            
            //if the sum of the die is 7, 1 is returned indicating that the Game is over
            if ((die_1 + die_2) == 7)
            {
                return 0;
            }

            //if both die are the same it will add double the sum of the dice to the total
            //returning 1 to indicate that a double has been rolled
            else if (die_1 == die_2)
            {
                
                total = total + (2 * (die_1 + die_2));
                return 1;
            }
            //adding the sum of the dice to the total
            else
            {
                total = total + die_1 + die_2;
                return 2;
            }

        }
        /// <summary>
        /// called when the code is being tested, returning the 
        /// 2 final dice values
        /// </summary>
        /// <returns>both final die values in an array</returns>
        public int[] Testing()
        {
            //keeping the code within a try block making sure no errors happen
            try
            {


                //a loop that will repeat the Game loop until a 7 is rolled
                while (true)
                {
                    //rolling 2 new dice objects
                    int[] dice = RollDie(2);

                    //cheking if the result of the dice roll is 7
                    int check = CheckDice(dice[0], dice[1]);

                    //if 7 it will add both numbers to an array and return them so they can be checked
                    if (check == 0)
                    {
                        //adding both die rolls to an array
                        int[] result = new int[2] { dice[0], dice[1] };

                        //returning the array
                        return result;


                    }

                }
            }
            //if an error occurs
            catch
            {
                //outputting an appropriate message
                Console.WriteLine("error has occured");

                //returning null
                return null;
            }

        }
    }
}
