using System;
using System.Collections.Generic;
using System.Text;

namespace Property_Tycoon
{   
    /// <summary>
    /// parent class for both ownable and not ownable properties
    /// </summary>
    public abstract class Space

    {
        // variable for the positions of each space
        private int Position;
        /// <summary>
        /// constructor for the space tiles 
        /// </summary>
        /// <param name="position"></param>
        public Space(int position)
        {
            Position = position;
        }
        /// <summary>
        /// retruns the position of the space
        /// </summary>
        /// <returns></returns>
        public int getPosition()
        {
            return Position;
        }
    }
}
