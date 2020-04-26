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
        private int Position;
        public Space(int position)
        {
            Position = position;
        }
        public int getPosition()
        {
            return Position;
        }
    }
}
