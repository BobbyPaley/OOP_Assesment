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
        public void update(int score, int game)
        {
            List<string> list = ReadFile();
            if (int.Parse(list[0]) < score && game == 1)
            {

                WriteFile(0, score.ToString());
            }
            if (game == 1)
            {
                WriteFile(1, (int.Parse(list[1]) + 1).ToString());
            }
            else if (game == 2)
            {
                WriteFile(2, (int.Parse(list[2]) + 1).ToString());
            }
            
        }
        private List<string> ReadFile()
        {
            var logFile = File.ReadAllLines("statistics.txt");
            var logList = new List<string>(logFile);
            //string[] new_array = File.ReadAllLines("statistics.txt").Select(int.Parse);
            return logList;
        }
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
