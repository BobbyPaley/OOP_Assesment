using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assesment2
{
    internal class game
    {
        public static Random RandomInstance { get; } = new Random();
        static void Main(string[] args)
        {
   
            int selection = 0;
            bool exit = false;
            while (exit == false) 
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("1.Sevens out - 2.three or more - 3.statistics - 4.testing - 5.exit");
                        selection = int.Parse(Console.ReadLine());
                        if (selection == 1 || selection == 2 || selection == 3 || selection == 4 || selection == 5)
                        {
                            break;
                        }
                        Console.WriteLine("please enter 1 2 or 3");
                    }
                    catch
                    {
                        Console.WriteLine("invalid input");
                    }
                }                
                if (selection == 1)
                {
                    var sevens = new Sevens__out();
                    sevens.main();
                }
                else if(selection == 2)
                {

                }
                else if (selection == 3)
                {

                }
                else if (selection == 4)
                {

                }
                else if (selection == 5)
                {
                    Console.WriteLine("exiting....");
                    return;
                }

            }
            
        }
    }
}
