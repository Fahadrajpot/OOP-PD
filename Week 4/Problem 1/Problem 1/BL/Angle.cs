using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.BL
{
    internal class Angle
    {
        public int Degrees;
        public float Minutes;
        public char Direction;
        public Angle(int degrees, float minutes, char direction)
        {
            Degrees = degrees;
            Minutes = minutes;
            Direction = direction;
        }   
        public string Print_position()
        {
            return (Degrees + "\u00b0" + Minutes+"`"+Direction); 
        }
    }
}
