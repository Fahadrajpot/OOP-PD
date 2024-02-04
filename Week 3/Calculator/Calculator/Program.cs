using Calculator.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;
            Console.WriteLine("1.Basic Calculator");
            Console.WriteLine("2.Scientific Calculator");
            Console.Write("Select an option to continue...");
            option = int.Parse(Console.ReadLine());
            Console.Clear();
            if (option == 1)
            {
                Cal cal = new Cal();
                float number_1 = 0, number_2 = 0;
                char sign = '\0';
                Console.Write("Enter the first number: ");
                cal.Number_1 = float.Parse(Console.ReadLine());
                Console.Write("Enter the second number: ");
                cal.Number_2 = float.Parse(Console.ReadLine());
                Console.Write("Enter the required operation(+,-,*,/,%): ");
                sign = char.Parse(Console.ReadLine());

                if (sign == '+')
                {
                    Console.WriteLine(cal.add());
                }
                else if (sign == '-')
                {
                    Console.WriteLine(cal.subtract());

                }
                else if (sign == '*')
                {
                    Console.WriteLine(cal.multiply());

                }
                else if (sign == '/')
                {
                    if (number_2 == 0)
                    {
                        Console.Write("Zero must not be in denominator.");
                    }
                    else
                    {
                        Console.WriteLine(cal.divide());
                    }
                }
                else if (sign == '%')
                {
                    Console.WriteLine(cal.modulo());

                }
            }
            else if (option == 2)
            {
                int operation;
                float number = 0;
                int power;
                Console.WriteLine("1.Square Root");
                Console.WriteLine("2.Expponential Funciton");
                Console.WriteLine("3.Log");
                Console.WriteLine("4.Trigonometric Function");
                Console.Write("Selection the operation...");
                operation = int.Parse(Console.ReadLine());
                Console.Clear();
                if (operation == 1)
                {
                    Console.Write("Enter the number: ");
                    number = float.Parse(Console.ReadLine());
                    Console.WriteLine(Math.Sqrt(number));
                }
                else if (operation == 2)
                {

                    Console.Write("Enter the number: ");
                    number = float.Parse(Console.ReadLine());
                    Console.Write("Enter the power of number: ");
                    power = int.Parse(Console.ReadLine());
                    Console.WriteLine(Math.Pow(number, power));
                }
                else if (operation == 3)
                {
                    Console.Write("Enter the number: ");
                    number = int.Parse(Console.ReadLine());
                    Console.WriteLine(Math.Log10(number));
                }
                else if (operation == 4)
                {
                    Console.WriteLine("1.Cos");
                    Console.WriteLine("2.Sin");
                    Console.WriteLine("3.Tan");
                    Console.Write("Select an operation...");
                    operation = int.Parse(Console.ReadLine());
                    if (operation ==1)
                    {
                        Console.Write("Ente the value: ");
                        number = float.Parse(Console.ReadLine());
                        Console.WriteLine(Math.Cos(number));
                    }
                    else if (operation == 2)
                    {

                        Console.Write("Enter the value: ");
                        number = float.Parse(Console.ReadLine());
                        Console.WriteLine(Math.Sin(number));

                    }
                    else if (operation == 3)
                    {

                        Console.Write("Ente the value: ");
                        number = float.Parse(Console.ReadLine());
                        Console.WriteLine(Math.Tan(number));

                    }
                }
            }
            Console.ReadKey();
        }
    }
}
