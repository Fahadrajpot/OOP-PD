using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.BL
{
    internal class Cal
    {
        public float Number_1;
        public float Number_2;
        public Cal() { } 
        public float add()
        {
            return Number_1+Number_2;
        }
        public float subtract()
        {
            return Number_1-Number_2;
        }
        public float multiply()
        {
            return Number_1*Number_2;
        }
        public float divide()
        {
            return Number_1/Number_2;
        }
        public float modulo()
        {
            return Number_1 % Number_2;

        } 
    }
}
