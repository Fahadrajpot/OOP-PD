using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.BL
{
    internal class Ship
    {
        public Angle Latitude;
        public Angle Longitude;
        public string Serial_number;
        public Ship()
        { 
        }
        public Ship(int degrees, float minutes, char direction, int degrees_1, float minutes_1, char direction_1,string serial_number)
        {
            Latitude= new Angle(degrees, minutes, direction);
             Longitude = new Angle(degrees_1, minutes_1, direction_1);
             Serial_number = serial_number;
        }
        public string ship_position()
        {
            return "Ship is at " + Latitude.Print_position() + " and " + Longitude.Print_position();
        }
        public string ship_number()
        {
            return "Ship's Serial number is "+Serial_number;
        }
    }
}
