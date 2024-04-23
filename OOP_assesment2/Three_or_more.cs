using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assesment2
{
    internal class Three_or_more : game
    {
        //creating ints to store the players score
        int player_1 = 0, player_2 = 0;

        /// <summary>
        /// lets the user select 1 or 2 player, calls the Game function
        /// and outputs the winner
        /// </summary>
        public void Main()
        {

                //getting the user selection
                int selection = NewSelection("1 or 2 player", 2, 1);

                //calling the Game function and setting the result to an integer
                int winner = Game(selection);

                //outputting the winner and their score, calling the getscore function
                //to get the corresponding score for the winner
                Console.WriteLine("player " + winner + " wins with a score of " + GetScore(winner));

        }
        
        /// <summary>
        /// will check for matches, the number with the most matches will be returned
        /// </summary>
        /// <param name="Dice">an array containing 5 die</param>
        /// <returns>an array with the number and its matches</returns>
        private int[] CheckDie(int[] Dice)
        {
            try
            {
                //creating 3 new ints set to 0
                int num = 0, matches = 0, temp = 0;

                //looping for all numbers 1 - 6
                for (int i = 1; i < 7; i++)
                {
                    //looping for the amount of dice
                    for (int j = 0; j < 5; j++)
                    {
                        //checking if the current number in the array is the
                        //same as the number being searched for
                        if (i == Dice[j])
                        {
                            //incrementing the temp int
                            temp++;
                        }
                    }
                    //if temp is greater than matches, it will replace matches with temp
                    //setting num to the current number being searched for
                    if (temp > matches)
                    {
                        matches = temp;
                        num = i;
                    }
                    //resetting temp
                    temp = 0;
                }
                //adding num and its matches to an array
                int[] results = new int[] { num, matches };

                //returning the results
                return results;
            }
            catch
            {
                Console.WriteLine("an error has occured");
                return  null;
            }
        }

        /// <summary>
        /// will take the user input and roll the nececary details
        /// if 1 it will roll the remaining die
        /// if 2 it will remain the non matching die
        /// </summary>
        /// <param name="selection">the user sekection</param>
        /// <param name="num">the number with the most matches</param>
        /// <param name="matches">the amount of matches</param>
        /// <returns>new array with corresponding numbers</returns>
        private int[] TwoMatch(int selection, int num, int matches)
        {
            try {
                //if 2 is selected it will return a new array of 5 die
                if (selection == 2)
                {
                    //rolling 5 die
                    return RollDie(5);
                }
                //if 1 is selected
                else
                {
                    //creating a new array to hold the current number with
                    //the most matches
                    int[] new_List = NewArray(matches);

                    //adding the num matches amount of times to an array
                    for (int i = 0; i < matches; i++)
                    {
                        new_List[i] = num;
                    }
                    //combining the array with an array with 3 / 4 die
                    new_List = new_List.Concat(RollDie(5 - matches)).ToArray();

                    //retuning the new array
                    return new_List;
                }
            }
            catch 
            {
                Console.WriteLine("an error has occured"); 
                return null;
            }
        }

        /// <summary>
        /// the Main Game function that will loop through the Main Game functions
        /// </summary>
        /// <param name="selection">the user selection for 1 or 2 player</param>
        /// <returns>the winning player</returns>
        private int Game(int selection)
        {
            try
            {
                //declaring the first turn
                int turn = 1;

                //looping until there is a winner
                while (true)
                {
                    //displaying the current turn
                    Console.WriteLine("turn = " + turn);

                    //creating an array with 5 new dice
                    int[] new_Die = RollDie(5);

                    //creating an array to hold the number with
                    //the most matches and its amount of matches
                    int[] results = CheckDie(new_Die);

                    //outputting the results of the roll
                    DisplayRoll(new_Die);

                    //waiting for the user press a button so the Game dosen't move to fast
                    Console.ReadLine();

                    //if the number of matches is 1 or 2 it will let the user roll
                    //new dice
                    if (results[1] == 2 || results[1] == 1)
                    {
                        //calling the selection function, checking if all dice are being rolled
                        //or just the non matching die
                        int selection_ = Selection(selection, turn);

                        //calling the two match function to create a new array of die
                        new_Die = TwoMatch(selection_, results[0], results[1]);

                        //checking the die for matches
                        results = CheckDie(new_Die);

                        //displaying the output of the new roll
                        DisplayRoll(new_Die);

                    }
                    //updating the current players score
                    UpdateScore(results[1], turn);

                    //outputting the current scores
                    Console.WriteLine("Player 1 = " + player_1 + " player 2 = " + player_2);

                    //checking if the win condition has been met
                    bool win = CheckWin();

                    //if it has it will break out of the Game loop
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
            catch
            {
                Console.WriteLine("an error has occured");
                return 0;
            }
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
                    ans = NewSelection("would you like to roll the 1.non matching die or 2.all ??", 2, 1);
                    //returning the users input
                    return ans;
                }

                //checking if it is one player and turn 2
                else if (selection == 1 && turn == 2)
                {
                    //getting a random number between 1 and 10
                    int random = RollNum(10);

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
                return 1;         
        }
        /// <summary>
        /// generates a random num taking num as parameter
        /// </summary>
        /// <param name="num">upper range for the random num</param>
        /// <returns>random number</returns>
        private int RollNum(int num)
        {
            //returning a random number between 1 and num
            return RandomInstance.Next(1, num);
        }
        /// <summary>
        /// displays all 5 dice objects, overriding the DisplayRoll function within game class
        /// </summary>
        /// <param name="new_Dice"></param>
        public override void DisplayRoll(int[] new_Dice)
        {
            //outputting all 5 dice
            Console.WriteLine("you rolled " + new_Dice[0] + ", " + new_Dice[1] + ", " + new_Dice[2] + ", " + new_Dice[3] + ", " + new_Dice[4]);
        }


        /// <summary>
        /// updates the players scores
        /// </summary>
        /// <param name="matches">the amount of matches</param>
        /// <param name="turn">the current turn</param>
        private int UpdateScore(int matches, int turn)
        {
            try
            {
                //if there is 3 matches it will add 3 to the current players score
                if (matches == 3)
                {
                    //caling thhe Update function
                    Update(turn, 3);
                    return 3;
                }
                //if 4 matches it will add 6
                else if (matches == 4)
                {
                    //calling the Update function
                    Update(turn, 6);
                    return 6;
                }
                //if all 5 match it will add 12 to score
                else if (matches == 5)
                {
                    //calling the Update function
                    Update(turn, 12);
                    return 12;
                }
                else { return 0; }
            }
            catch
            {
                Console.WriteLine("an error has occured");
                return 0;
            }

        }
        /// <summary>
        /// updates the current players score
        /// </summary>
        /// <param name="turn">the current turn</param>
        /// <param name="points">the amount of points to be added</param>
        private void Update(int turn, int points)
        {
            try
            {
                //if turn is one it will give them the points 
                if (turn == 1)
                {
                    player_1 = player_1 + points;
                }
                //if tuen is two it will give them the points
                else if (turn == 2)
                {
                    player_2 = player_2 + points;
                }
            }
            catch
            {
                Console.WriteLine("an error has occured");
            }
        }
        /// <summary>
        /// checking if either player has met the win condition
        /// </summary>
        /// <returns>bool saying if the win condition has been met</returns>
        private bool CheckWin()
        {
            try
            {
                //checking if either score is >= 20
                if (player_1 >= 20 || player_2 >= 20)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("an error has occured");
                return false;
            }
        }
        /// <summary>
        /// will return the selected users score
        /// </summary>
        /// <param name="turn">current turn</param>
        /// <returns>their score</returns>
        private int GetScore(int turn)
        {
            if(turn == 1)
            {
                return player_1;
            }
            else
            {
                return player_2;
            }
        }

      
        /// <summary>
        /// runs through the Game functions until a Game over is called
        /// and returning the nececarry data for Test purposes
        /// </summary>
        /// <returns></returns>
        public int[] Testing()
        {
            try {  
            //creating an int to store the score before points are added
            int score_Before = 0;

                //lloping until score is 20 or higher
                while (true)
                {
                    //creating a new array of 5 die
                    int[] new_Die = RollDie(5);

                    //checking for matches passing the new array through as a parameter
                    int[] check = CheckDie(new_Die);

                    //setting the current score 
                    score_Before = player_1;

                    //updating the score accordingly
                    int point_Add = UpdateScore(check[1], 1);

                    //if a win is found
                    if (CheckWin() == true)
                    {
                        //adding all of the nececary data to an array to pass back
                        int[] results = new int[4] { score_Before, player_1, point_Add, check[1] };

                        //returning the new array
                        return results;
                    }
                }
                
            }
            catch
            {
                Console.WriteLine("an error has occured");
                return null;
            }
        }
    }
}
