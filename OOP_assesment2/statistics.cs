using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_assesment2
{
    internal class statistics
    {
        /// <summary>
        /// will take the Game data and Update the score list accordingly
        /// </summary>
        /// <param name="score">the highscore</param>
        /// <param name="game">the Game type</param>
        public void Update(int score, int game)
        {
            try
            {
                //creating a list of strings from the items in statistics.txt
                List<string> list = ReadFile();


                int high_Score = int.Parse(list[0]);
                //cheking if the Game type is sevens and if the score is
                //higher than the current high score
                if (int.Parse(list[0]) < score && game == 1)
                {
                    //outputting an appropriate message
                    high_Score = score;
                }
                //if Game type is 1 it will increment the amount of sevens played
                if (game == 1)
                {
                    //incrementing the amount of games played
                    list[1] = (int.Parse(list[1]) + 1).ToString();
                }
                //if Game type is 2 it will increment the amount of threes played
                else if (game == 2)
                {
                    //incrementing the score
                    list[2] = (int.Parse(list[2]) + 1).ToString();
                }
                //writing the data to a new file
                WriteFile(high_Score, int.Parse(list[1]), int.Parse(list[2]));
            }
            catch 
            {
                //error message if the update function fails
                Console.WriteLine("ERROR - data could not be updated");
            }
        }
        /// <summary>
        /// returns the relevant data stored in the file
        /// </summary>
        /// <returns>a list of the data stored in statistics.txt</returns>
        private List<string> ReadFile()
        {
            try
            {
                if (File.Exists("statistics.txt") == false)
                {
                    //creating a new file conatining only 3 zeros
                    WriteFile(0, 0, 0);
                }

                //getting the file location of statistics.txt
                string fileName = Path.GetFullPath("statistics.txt");
                
                //reading the data in statistics.txt
                var log_File = File.ReadAllLines(fileName);
                
                //putting all of the data into a list of strings
                var log_List = new List<string>(log_File);

                //returning the final list of data
                return log_List;
            }
            //returns null if there is an error getting the file
            catch { return new List<string>(null); }
        }
            
        /// <summary>
        /// updates the data in the txt file accordingly
        /// </summary>
        /// <param name="high_Score">the current / new highscore</param>
        /// <param name="game_1">the amount of sevens played</param>
        /// <param name="game_2">the amount of threes played</param>
        private void WriteFile(int high_Score, int game_1, int game_2)
        {

            try
            {
                //using the stream writter to store the data in a txt file
                using (StreamWriter writer = new StreamWriter("statistics.txt", false))
                {
                    //writting out the highscore on the first line
                    writer.WriteLine(high_Score);

                    //the amount of sevens played
                    writer.WriteLine(game_1);

                    //the amount of threes played
                    writer.WriteLine(game_2);

                    //closing the writter
                    writer.Close();
                  
                }
            //outputting an error message if an exception is thrown
            }
            catch 
            { 
                //output message if the data could not be written to file
                Console.WriteLine("ERROR - could not write data to file");
            }
        }

        /// <summary>
        /// outputs the statistical data to the terminal
        /// </summary>
        public void Stats()
        {
            try
            {
                //reading the data
                List<string> data = ReadFile();

                //outputting the sevens highscore
                Console.WriteLine("Sevens out highscore = " + data[0]);

                //outputting the amount of sevens games played
                Console.WriteLine("Sevens out games played = " + data[1]);

                //outputting the amount of three or more games played
                Console.WriteLine("Three or more games played = " + data[2]);
            } 
            catch 
            { 
                //error message if the data couln't be displayed
                Console.WriteLine("ERROR - Couldn't read data"); 
            }
        }
        
    }
}
