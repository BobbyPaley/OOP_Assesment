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
        /// will take the game data and update the score list accordingly
        /// </summary>
        /// <param name="score">the highscore</param>
        /// <param name="game">the game type</param>
        public void update(int score, int game)
        {
            //creating a list of strings from the items in statistics.txt
            List<string> list = ReadFile();

            //cheking if the game type is sevens and if the score is
            //higher than the current high score
            if (int.Parse(list[0]) < score && game == 1)
            {
                //changing the highscore in the text file
                WriteFile(0, score.ToString());
            }
            //if game type is 1 it will increment the amount of sevens played
            if (game == 1)
            {
                //incrementing the amount of games played
                WriteFile(1, (int.Parse(list[1]) + 1).ToString());
            }
            //if game type is 2 it will increment the amount of threes played
            else if (game == 2)
            {
                //incrementing the score
                WriteFile(2, (int.Parse(list[2]) + 1).ToString());
            }           
        }
        /// <summary>
        /// returns the relevant data stored in the file
        /// </summary>
        /// <returns>a list of the data stored in statistics.txt</returns>
        private List<string> ReadFile()
        {
            //reading the data in statistics.txt
            var logFile = File.ReadAllLines("statistics.txt");

            //putting all of the data into a list of strings
            var logList = new List<string>(logFile);
            
            //returning the final list of data
            return logList;
        }
        /// <summary>
        /// writed the relevant data to statistics.txt
        /// </summary>
        /// <param name="line"></param>
        /// <param name="newNum"></param>
        private void WriteFile(int line, string newNum)
        {
            string[] arrLine = File.ReadAllLines("statistics.txt");
            
            arrLine[line] = newNum;
            File.WriteAllLines("statistics.txt", arrLine);
        }
        public void stats()
        {
            List<string> data = ReadFile();
            Console.WriteLine("Sevens out highscore = " + data[0]);
            Console.WriteLine("Sevens out games played = " + data[1]);
            Console.WriteLine("Three or more games played = " + data[2]);
        }
        
    }
}
