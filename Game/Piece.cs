using System;
using System.Collections.Generic;
using System.Text;

namespace Property_Tycoon
{
    public class Piece
    {
        string name;
        bool picked;

        public Piece(string _name) {
            name = _name;
            picked = false;
        }
        public bool getPicked() {
            return picked;
        }
        public void setPicked(bool val)
        {
          picked = val;
        }
        public string getName() {
            return name;
        }
    }

}
