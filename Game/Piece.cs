using System;
using System.Collections.Generic;
using System.Text;

namespace Property_Tycoon
{
    public class Piece
    {
        string name;
        bool picked;
        string source;

        public Piece(string _name,String filepath) {
            name = _name;
            picked = false;
            source = filepath;
        }
        public bool getPicked() {
            return picked;
        }
        public String getfilePath() {
            return source;
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
