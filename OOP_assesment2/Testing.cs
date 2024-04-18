using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assesment2
{
    internal class Testing
    {
        public void testing() 
        {
            int selection = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("what would you like to test");
                    Console.WriteLine("1.Sevens out - 2.three or more - 3.exit");
                    selection = int.Parse(Console.ReadLine());
                    if (selection == 1 || selection == 2 || selection == 3 )
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
                int[] die = { };
                var sevens = new Sevens__out();
                die = sevens.testing();
                
                Debug.Assert(die[0] + die[1] == 7);
                Console.WriteLine("Die1(" + die[0] + ") + Die2("+ die[1] + ") = " + (die[1] + die[0]));
                return;
            }
            else if (selection == 2)
            {
                var threes = new Three_or_more();
                int[] results = threes.testing();

                //checking that score adds correctly
                Debug.Assert((results[0] + results[2]) == results[1]);
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
                //checking that the final score is >= 20
                Debug.Assert(results[1] >= 20);
                return;
            }
            else if(selection == 3)
            {
                return;
            }
        }

    }
}
