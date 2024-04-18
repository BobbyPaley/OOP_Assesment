using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assesment2
{
    internal class Three_or_more : game
    {
        //creating ints to store the players score
        int player1 = 0, player2 = 0;

        /// <summary>
        /// lets the user select 1 or 2 player, calls the game function
        /// and outputs the winner
        /// </summary>
        public void main()
        {
            //getting the user selection
            int selection = newSelection("1 or 2 player", 2);

            //calling the game function and setting the result to an integer
            int winner = game(selection);

            //outputting the winner and their score, calling the getscore function
            //to get the corresponding score for the winner
            Console.WriteLine("player " + winner + " wins with a score of " + getScore(winner));
        }



        /// <summary>
        /// rolls an amount of dice specified by the x value 
        /// </summary>
        /// <param name="x">number of dice being rolled</param>
        /// <returns>an array containing the new dice</returns>
        private int[] rollDie(int x)
        {
            //creating a new array x length
            int[] NewArray = newArray(x);

            //looping x amount of times, adding a new dice to the 
            //array every time
            for (int i = 0; i < NewArray.Length; i++)
            {
                //adding the die to the array
                NewArray[i] = RollDice();
            }

            //returning the array containing the die
            return NewArray;  
        } 

        /// <summary>
        /// will check for matches, the number with the most matches will be returned
        /// </summary>
        /// <param name="Dice">an array containing 5 die</param>
        /// <returns>an array with the number and its instances</returns>
        private int[] checkDie(int[] Dice)
        {
            //creating a new array to be returned
            int[] results = newArray(2);

            //creating 3 new ints set to 0
            int num = 0, instances = 0, temp = 0;

            //looping for all numbers 1 - 6
            for(int i = 1;i < 7;i++) 
            {
                //looping for the amount of dice
                for (int j = 0; j < 5;j++)
                {
                    //checking if the current number in the array is the
                    //same as the number being searched for
                    if (i == Dice[j])
                    {
                        //incrementing the temp int
                        temp++;
                    }
                }
                //if temp is greater than instances, it will replace instances with temp
                //setting num to the current number being searched for
                if (temp > instances)
                {
                    instances = temp;
                    num = i;
                }
                //resetting temp
                temp = 0;
            }
            //adding num and its instances to an array
            results[0] = num;
            results[1] = instances;

            //returning the results
            return results;
        }

        /// <summary>
        /// will take the user input and roll the nececary details
        /// if 1 it will roll the remaining die
        /// if 2 it will remain the non matching die
        /// </summary>
        /// <param name="selection">the user sekection</param>
        /// <param name="num">the number with the most matches</param>
        /// <param name="instances">the amount of matches</param>
        /// <returns>new array with corresponding numbers</returns>
        private int[] twomatch(int selection, int num, int instances)
        {
            //if 2 is selected it will return a new array of 5 die
            if (selection == 2)
            {
                //rolling 5 die
                return rollDie(5);
            }
            //if 1 is selected
            else
            {
                //creating a new array to hold the current number with
                //the most matches
                int[] newList = newArray(instances);

                //adding the num instances amount of times to an array
                for (int i = 0;i < instances;i++)
                {
                    newList[i] = num;
                }
                //combining the array with an array with 3 / 4 die
                newList = newList.Concat(rollDie(5 - instances)).ToArray();

                //retuning the new array
                return newList;
            }
        }

        /// <summary>
        /// the main game function that will loop through the main game functions
        /// </summary>
        /// <param name="selection">the user selection for 1 or 2 player</param>
        /// <returns>the winning player</returns>
        private int game(int selection)
        {
            //declaring the first turn
            int turn = 1;

            //looping until there is a winner
            while (true)
            {
                //displaying the current turn
                Console.WriteLine("turn = " + turn);

                //creating an array with 5 new dice
                int[] newDie = rollDie(5);

                //creating an array to hold the number with
                //the most matches and its amount of matches
                int[] results = checkDie(newDie);

                //outputting the results of the roll
                displayRoll(newDie);

                //waiting for the user press a button so the game dosen't move to fast
                Console.ReadLine();

                //if the number of matches is 1 or 2 it will let the user roll
                //new dice
                if (results[1] == 2 || results[1] == 1)
                {
                    //calling the selection function, checking if all dice are being rolled
                    //or just the non matching die
                    int select = Selection(selection, turn);

                    //calling the two match function to create a new array of die
                    newDie = twomatch(select, results[0], results[1]);

                    //checking the die for matches
                    results = checkDie(newDie);

                    //displaying the output of the new roll
                    displayRoll(newDie);

                }
                //updating the current players score
                updateScore(results[1], turn);

                //outputting the current scores
                Console.WriteLine("Player 1 = " + player1 + " player 2 = " + player2);

                //checking if the win condition has been met
                bool win = checkWin();

                //if it has it will break out of the game loop
                if (win == true)
                {
                    break;
                }
                //if not, it will change the turn
                else
                {
                    if (turn == 1)
                    {
                        turn++;
                    }
                    else
                    {
                        turn--;
                    }
                }
            }
            //when the while loop is broken it will return the turn
            return turn;
        }

        /// <summary>
        /// checks wether it is one or 2 player, getting a selection 
        /// from the corresponding player count
        /// </summary>
        /// <param name="selection">the selection of 1 or 2 player</param>
        /// <param name="turn">the current turn</param>
        /// <returns>the selection to roll all die or roll unmatching</returns>
        private int Selection(int selection, int turn)
        {
            //creting an int to store the answer
            int ans = 0;

            //cheking if user input is needed
            if (selection == 2 && turn == 1 || selection == 2 && turn == 2 || selection == 1 && turn == 1) 
            {
                ans = newSelection("would you like to roll the 1.non matching die or 2.all ??", 2);
                //returning the users input
                return ans;
            }

            //checking if it is one player and turn 2
            else if(selection == 1 && turn == 2)
            {
                //getting a random number between 1 and 10
                int random = RandomInstance.Next(1, 10);
                
                //if the number is less than 3 it will roll all of the dice
                if (random < 3)
                {
                    Console.WriteLine("rolling all die ....");
                    return 2;
                }
                //if the number is greater than 3 it will roll the non matching dice
                else
                {
                    Console.WriteLine("rolling non matching...");
                    return 1;
                }
                
            }
            //returns one if its an error
            
            return 1;
        }

        /// <summary>
        /// displaying the dice rolled
        /// </summary>
        /// <param name="newDice">an array of 5 dice</param>
        private void displayRoll(int[] newDice)
        {
            //outputting all 5 dice
            Console.WriteLine("you rolled " + newDice[0] + ", " + newDice[1] + ", " + newDice[2] + ", " + newDice[3] + ", " + newDice[4]);
        }

        /// <summary>
        /// updates the players scores
        /// </summary>
        /// <param name="increments">the amount of matches</param>
        /// <param name="turn">the current turn</param>
        private int updateScore(int increments, int turn)
        {
            //if there is 3 matches it will add 3 to the current players score
            if (increments == 3)
            {
                //caling thhe update function
                update(turn, 3);
                return 3;
            }
            //if 4 matches it will add 6
            else if (increments == 4)
            {
                //calling the update function
                update(turn, 6);
                return 6;
            }
            //if all 5 match it will add 12 to score
            else if (increments == 5)
            {
                //calling the update function
                update(turn, 12);
                return 12;
            }
            else { return 0; }

        }
        /// <summary>
        /// updates the current players score
        /// </summary>
        /// <param name="turn">the current turn</param>
        /// <param name="points">the amount of points to be added</param>
        private void update(int turn, int points)
        {
            //if turn is one it will give them the points 
            if (turn == 1)
            {
                player1 = player1 +  points;
            }
            //if tuen is two it will give them the points
            else if (turn == 2)
            {
                player2 = player2 + points;
            }
        }
        /// <summary>
        /// checking if either player has met the win condition
        /// </summary>
        /// <returns>bool saying if the win condition has been met</returns>
        private bool checkWin()
        {
            //checking if either score is >= 20
            if(player1 >= 20 || player2 >= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// will return the selected users score
        /// </summary>
        /// <param name="turn">current turn</param>
        /// <returns>their score</returns>
        private int getScore(int turn)
        {
            if(turn == 1)
            {
                return player1;
            }
            else
            {
                return player2;
            }
        }
        /// <summary>
        /// runs through the game functions until a game over is called
        /// and returning the nececarry data for testing purposes
        /// </summary>
        /// <returns></returns>
        public int[] testing()
        {
            
            //creating an int to store the score before points are added
            int scorebf = 0;
            
            //lloping until score is 20 or higher
            while(true)
            {
                //creating a new array of 5 die
                int[] newDie = rollDie(5);

                //checking for matches passing the new array through as a parameter
                int[] check = checkDie(newDie);

                //setting the current score 
                scorebf = player1;

                //updating the score accordingly
                int pointAdd = updateScore(check[1], 1);
                
                //if a win is found
                if (checkWin() == true)
                {
                    //adding all of the nececary data to an array to pass back
                    int[] results = new int[4] { scorebf, player1, pointAdd, check[1] };

                    //returning the new array
                    return results;
                }
            }
        }
    }
}
