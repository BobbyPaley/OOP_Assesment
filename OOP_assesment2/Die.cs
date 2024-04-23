using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assesment2
{
    internal class Die
    {
        private int current_Value;

        /// <summary>
        /// exposes _current value whle not allowing it to be changed by anything 
        /// other than the class or its children
        /// </summary>
        private int CurrentValue
        {
            //getting the current value
            get => current_Value;

            //setting the current value
            set => current_Value = value;
        }



        /// <summary>
        /// picks a random number between 1 and 6, sets that to the current value and returns the result
        /// </summary>
        /// <returns>the random number</returns>
        public int Roll()
        {
            //rolling a number between 1 and 6
            int new_Roll = game.RandomInstance.Next(1, 7);

            //setting the roll to the current value
            current_Value = new_Roll;

            //returning the roll
            return new_Roll;
        }

    }
}