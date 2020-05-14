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
        /// <summary>
        /// this method returns the picked string
        /// </summary>
        /// <returns> The picked string</returns>
        public bool getPicked() {
            return picked;
        }
        /// <summary>
        /// this method gets the filepath for the game
        /// </summary>
        /// <returns> a string for of the filepath </returns>
        public String getfilePath() {
            return source;
        }
        /// <summary>
        /// this method checks to see if the piece can be selected
        /// </summary>
        /// <param name="val"> boolean</param>
        public void setPicked(bool val)
        {
          picked = val;
        }
        /// <summary>
        /// Returns the name of the piece
        /// </summary>
        /// <returns> string containing the name</returns>
        public string getName() {
            return name;
        }
    }

}
