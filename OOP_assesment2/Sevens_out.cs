using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assesment2
{
    internal class Sevens__out
    {
        public int total = 0;
        
        public void main() 
        {
            Console.WriteLine("Welcome to sevens out");
            Console.WriteLine("press enter to roll again");
            
            int Die1, Die2;
            
            int RollNum = 1;
            while (true)
            {
                
               
              
                RollNum++;
                Console.WriteLine("total = " + total);
                Console.ReadLine();
            }

        }
        private int RollDice()
        {
            var Dice = new Die();
            return Dice.Roll();
        }
        private int checkDie(int Die1, int Die2)
        {
            if ((Die1 + Die2) == 7)
            {
                Console.WriteLine("7 ROLLED, GAME OVER");
                Console.WriteLine("final score = " + total);
                return 0;
            }
            else if (Die2 == Die1)
            {
                Console.WriteLine("Double rolled!!");
                total = total + (2 * (Die1 + Die2));
            }
            else
            {
                total = total + Die1 + Die2;
            }

        }
        

    }
}
