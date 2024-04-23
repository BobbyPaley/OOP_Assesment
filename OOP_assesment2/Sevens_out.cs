using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_assesment2
{
    internal class Sevens__out : game
    {
        // a public variable within the class to store the player_1 score
        public int player_1 = 0, player_2 = 0;
        
        //creating booleans to store if either player has rolled a seven
        public bool player_1_7 = false, player_2_7 = false;

        /// <summary>
        /// will roll 2 dice until a 7 is rolled, if there is a 2
        /// of a kind the score will double
        /// </summary>
        /// <returns>the final score</returns>
        public int Main() 
        {
            //introductoary messages
            Console.WriteLine("Welcome to sevens out");

            //asking the user if they would like one or 2 player
            int selection = NewSelection("1 or 2 player", 2, 1);

            //outputting a message telling the user to press enter to progress the game
            Console.WriteLine("press enter to roll");

            //setting the first turn
            int turn = 1;
           
            //looping until win condition is met    
            while (true)
            {
                //creating a new empty array to store 2 dice objects
                int[] dice = new int[2]; 

                //outputting the current turn
                Console.WriteLine("Player " + turn + "'s turn: ");


                //if it is one player and turn 2 the game will 
                //automaticly roll the dice with no user input
                if (turn == 2 && selection == 1) 
                {
                    //rolling new dice and setting to array
                    dice = RollDie(2);                   
                }
                //if it is wither 2 player or turn 1
                else
                {
                    //telling the user to press enter to roll a dice
                    Console.WriteLine("press enter to roll dice");

                    //waiting for input
                    Console.ReadLine();

                    //setting the new dice rolled to the array
                    dice = RollDie(2);

                }
                //outputting the results of the rolls and the roll number               
                DisplayRoll(dice);

                //calling the check function to add the scores
                int check = CheckDice(dice[0], dice[1]);

                //checking the turn
                if (turn == 1)
                {
                    //adding the neccecary score to player 1
                    player_1 = player_1 + check;
                }
                //if it is player 2's turn
                else
                {
                    //adding the neccecary score to player 2
                    player_2 = player_2 + check;
                }

                //if 0 is returned from the CheckDice function, the Game is
                //over as the result of the die is 7
                if (turn == 1 && check == 0 || turn == 2 && check == 0)
                {
                    //outputting a game over message for the current player
                    Console.WriteLine("7 rolled, player "+turn+" is out!!\n");

                    //outputting there final score
                    Console.WriteLine("final score = " + GetScore(turn));

                    //sleeping the program for half a seccond
                    Thread.Sleep(500);

                    //letting the game know to skip this players turn
                    GameOver(turn);
                }

                //if both players are out of the game
                if (player_1_7 == true && player_2_7 == true)
                {
                    //end of game messages
                    Console.WriteLine("Both player out, game over\n");

                    //displaying the final scores
                    Console.WriteLine("the final scores are: ");

                    //outputting both scores
                    DispScore();

                    //checking if player one has a higher score
                    if (player_1 > player_2)
                    {
                        //outputting a message to the user, saying player 
                        //one wins and displaying the score
                        Console.WriteLine("Player 1 wins with a score of " + player_1 + "\n");

                        //returning player ones score
                        return player_1;
                    }
                    //checking if player 2 has a higher score
                    else if(player_2 > player_1)
                    {
                        //outputting a message to the user, saying player 
                        //two wins and displaying the score
                        Console.WriteLine("Player 2 wins with a score of " + player_2 + "\n");

                        //returning player 2's score
                        return player_2;
                    }
                    //if both players have the same score
                    else
                    {
                        //outputting draw message
                        Console.WriteLine("DRAW!!\n");

                        //returning either score
                        return player_1;
                    }
                }

                //outputting then current scores
                DispScore();

                //changing the current turn
                turn = Turn(turn);

                //sleeping the application so it dosen't move to fast
                Thread.Sleep(500);
            }
        }
        /// <summary>
        /// returns the score of the current player
        /// </summary>
        /// <param name="turn">the current turn</param>
        /// <returns>score of current player</returns>
        private int GetScore(int turn)
        {
            //if turn is one
            if (turn == 1)
            {
                //return player ones score
                return player_1;
            }
            //if turn is 2
            else
            {
                //returning player twos score
                return player_2;
            }
        }
        /// <summary>
        /// lets the program know the current user has rolled a 7
        /// </summary>
        /// <param name="turn">current turn</param>
        private void GameOver(int turn)
        {
            //if it is player ones turn
            if(turn == 1)
            {
                //player one rolled 7 = true
                player_1_7 = true;
            }
            //if it is player twos turn
            else
            {
                //player 2 rolled 7 = true
                player_2_7 = true;
            }
        }
        /// <summary>
        /// displays the current scores
        /// </summary>
        private void DispScore()
        {
            //outputting an appropriate message
            Console.WriteLine("Player 1 = " + player_1 + "\nPlayer 2 = "+ player_2 + "\n");
        }
        /// <summary>
        /// changes the turn, checking if either player has rolled a 7
        /// </summary>
        /// <param name="turn">current turn</param>
        /// <returns></returns>
        private int Turn(int turn)
        {
            //if player one has rolled a 7
            if (player_1_7 == true)
            {
                //return 2(player 2's turn)
                return 2;
            }
            //if player 2 has rolled a 7
            else if (player_2_7 == true)
            {
                //returns 1 to indicate player ones turn
                return 1;
            }
            //if neither player has rolled a 7
            else
            {
                //if turn is 1
                if (turn == 1)
                {
                    //return player 2's turn
                    return 2;
                }
                //else return player 1
                else { return 1; }
            }

        }

        /// <summary>
        /// it will check the result of the 2 die rolled, if they are the same it 
        /// will add double the sum of the die to the player_1.
        /// if the sum is 7 it will return 7 to indicate that the Game is over
        /// else it will ad both dice to the sum
        /// </summary>
        /// <param name="die_1">the first die rolled</param>
        /// <param name="die_2">the seccond die rolled</param>
        /// <returns>an integer determining what state the Game is in</returns>
        private int CheckDice(int die_1, int die_2)
        {
            //creating a new int to store the new score
            int new_Score = 0;

            //if the sum of the die is 7, 1 is returned indicating that the Game is over
            if ((die_1 + die_2) == 7)
            {
                //returning 0 to indicate that a 7 has been rolled
                return new_Score;
            }

            //if both die are the same it will add double the sum of the dice to the player_1
            //returning 1 to indicate that a double has been rolled
            else if (die_1 == die_2)
            {
                //outputting appropriate message
                Console.WriteLine("double rolled 2x points!!");

                //updating the score accordingly
                new_Score  = new_Score + (2 * (die_1 + die_2));

                //returning the score to add
                return new_Score;
            }
            //adding the sum of the dice to the player_1
            else
            {
                //adding the values together
                new_Score = new_Score + die_1 + die_2;

                //returning the score to add to the current player
                return new_Score;
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
    }
}
