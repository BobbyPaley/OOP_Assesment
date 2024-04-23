using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace OOP_assesment2
{
    internal class Testing : game
    {
        /// <summary>
        /// runs user selected testing
        /// </summary>
        public void Test() 
        {
            //keeping code within try and catch blocks
            try
            {
                //introduction message
                Console.WriteLine("what would you like to test");

                //calling the user selection function
                int selection = NewSelection("1.Sevens out - 2.three or more - 3.Die fairness - 4.exit", 4, 1);

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

                    WriteLog("sevens die adds to 7 "+die[0]+" + " + die[1] + " = 7");
                    //outputting the 2 dice rolls
                    DisplayRoll(die);

                    //outputing the results of the test in the terminal
                    Console.WriteLine("Die1(" + die[0] + ") + Die2(" + die[1] + ") = " + (die[1] + die[0]));

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

                    //updating the logbook
                    WriteLog("die add up to the correct values");

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
                    //updating the logbook

                    WriteLog("points match values as expeted");

                    //checking that the final score is >= 20

                    Debug.Assert(results[1] >= 20);

                    //outputting the final score to the user
                    Console.WriteLine("final score = " + results[1]);

                    //updating the logbook
                    WriteLog("threes score is >= 20");

                    //returning back to Game class
                    return;
                }
                //if user wants to check the fairness of the die
                else if (selection == 3)
                {
                    //creating ins to store the results of the die
                    int one = 0, two = 0, three = 0, four = 0, five = 0, six = 0;

                    //letting the user select a number of dice to roll
                    int roll_Num = NewSelection("how many dice would you like to roll", int.MaxValue, 2);

                    //setting temp to the amount of rolls
                    int temp = roll_Num;

                    //rolling user specified amount of dice
                    while (roll_Num != 0)
                    {
                        //rolling a new dice
                        int die = RollNum();

                        //incrementing the dice number counters                  
                        if (die == 1)
                        {
                            one++;
                        }
                        else if (die == 2)
                        {
                            two++;
                        }
                        else if (die == 3)
                        {
                            three++;
                        }
                        else if (die == 4)
                        {
                            four++;
                        }
                        else if (die == 5)
                        {
                            five++;
                        }
                        else if (die == 6)
                        {
                            six++;
                        }
                        //taking one away from number of die left to roll
                        roll_Num--;
                    }

                    //outputting the results of the rolls
                    Console.WriteLine("ones = " + one + "\ntwos = " + two + "\nthrees = " + three + "\nfours = " + four + "\nfives = " + five + "\nsixes = " + six);

                    //testing all of the results of the rolls for any outliers
                    //making sure they're all within 10% of the mean die roll
                    //in turn proving the die to be fair
                    Debug.Assert(CheckFair(one, temp));
                    Debug.Assert(CheckFair(two, temp));
                    Debug.Assert(CheckFair(three, temp));
                    Debug.Assert(CheckFair(four, temp));
                    Debug.Assert(CheckFair(five, temp));
                    Debug.Assert(CheckFair(six, temp));

                    //outputting appropriate message to the user
                    Console.WriteLine("die within 10% of expected values");

                    //updating the log book
                    WriteLog("die within expected range of values when testing with " + temp + " die.");

                    //returning out of test function
                    return;
                }
                //exiting if user selects 4
                else if (selection == 4)
                {
                    return;
                }
            }
            //outputting an appropriate error message
            catch
            {
                Console.WriteLine("an error has occured");
            }
            
        }
        /// <summary>
        /// checking if the dice are within expected range
        /// </summary>
        /// <param name="num">number of dice</param>
        /// <param name="mean">mean number</param>
        /// <returns>if within range</returns>
        private bool CheckFair(int num, int mean)
        {
            //checking if the number is 10% above the mean or below
            if (num < mean - (mean / 10) || num < mean + (mean / 10))
            {
                //returning true if so
                return true;
            }
            //else false
            else { return false; }

        }/// <summary>
        /// adding the testing messages to the log book
        /// </summary>
        /// <param name="message">message to be added to the logbook</param>
        public static void WriteLog(string message)
        {
            //creating a new instance of stream writter
            using (StreamWriter writer = new StreamWriter("logFile.txt", true))
            {
                //writing the message to the log file with the time of report
                writer.WriteLine($"{DateTime.Now} : {message}");
            }
        }

    }
}
