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

                //cheking if the Game type is sevens and if the score is
                //higher than the current high score
                if (int.Parse(list[0]) < score && game == 1)
                {
                    //outputting an appropriate message
                    Console.WriteLine("new high score");

                    //changing the highscore in the text file
                    WriteFile(0, score.ToString());
                }
                //if Game type is 1 it will increment the amount of sevens played
                if (game == 1)
                {
                    //incrementing the amount of games played
                    WriteFile(1, (int.Parse(list[1]) + 1).ToString());
                }
                //if Game type is 2 it will increment the amount of threes played
                else if (game == 2)
                {
                    //incrementing the score
                    WriteFile(2, (int.Parse(list[2]) + 1).ToString());
                }
            }
            catch 
            {
                Console.WriteLine("an error has occured");
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
                //reading the data in statistics.txt
                var log_File = File.ReadAllLines("statistics.txt");

                //putting all of the data into a list of strings
                var log_List = new List<string>(log_File);

                //returning the final list of data
                return log_List;
            }
            catch { return null; }
        }
            
        /// <summary>
        /// write the relevant data to statistics.txt
        /// </summary>
        /// <param name="line"></param>
        /// <param name="new_Num"></param>
        private void WriteFile(int line, string new_Num)
        {
            try
            {
                //creating a copy of the file
                string[] arr_Line = File.ReadAllLines("statistics.txt");

                //replacing the data
                arr_Line[line] = new_Num;

                //replacing the data in the file with the new data
                File.WriteAllLines("statistics.txt", arr_Line);
            }
            catch { Console.WriteLine("an error has occured"); }
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
                Console.WriteLine("an error has occured"); 
            }
        }
        
    }
}
