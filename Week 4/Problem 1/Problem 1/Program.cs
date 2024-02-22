using Problem_1.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1
{
    internal class Program
    {
        static List <Ship>ship_list=new List <Ship> ();
        static void Main(string[] args)
        {
            int option=0;
            while(option != 5)
            {
                option=menu();
                if (option == 1)
                {
                    add_ship();
                }
                else if (option == 2)
                {
                    ship_position();
                }
                else if (option == 3)
                {
                    ship_number();
                }
                else if (option == 4)
                {
                    change_position();
                }
                else if(option == 5)
                {
                    return ;
                }
            }
        }
        static int menu()
        {
            int option = 0;
            Console.Clear();
            Console.WriteLine("1.Add Ship"); 
            Console.WriteLine("2.View Ship Position");
            Console.WriteLine("3.View Ship Serial Number");
            Console.WriteLine("4.Change Ship Position");
            Console.WriteLine("5.Exit");
            Console.Write("Select an option to continue...");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static void add_ship()
        {
            string ship_number;
            int degree;
            float minutes;
            char direction;
            int degree_1;
            float minutes_1;
            char direction_1;
            Console.Clear ();
            Console.Write("Enter Ship Number: ");
            ship_number=Console.ReadLine();
            Console.WriteLine("Enter Ship Latitude: ");
            Console.Write("Enter Latitude’s Degree: ");
            degree = int.Parse(Console.ReadLine());
            Console.Write("Enter Latitude’s Minute: ");
            minutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Latitude’s Direction: ");
            direction=char.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ship Longitude: ");
            Console.Write("Enter Longitude’s Degree: ");
            degree_1=int.Parse(Console.ReadLine());
            Console.Write("Enter Longitude’s Minute: ");
            minutes_1=float.Parse(Console.ReadLine());
            Console.Write("Enter Longitude’s Direction: ");
            direction_1 = char.Parse(Console.ReadLine());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Ship single = new Ship(degree, minutes, direction, degree_1, minutes_1, direction_1, ship_number);
            ship_list.Add(single);
        }
        static void ship_position()
        {
            string serial;
            Console.Clear();
            Console.Write("Enter the ship's serial number to find its position: ");
            serial = Console.ReadLine();
            foreach (Ship check in ship_list)
            {
                if (check.Serial_number == serial)
                {
                    Console.WriteLine(check.ship_position());
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("No ship found...");
            Console.ReadKey();
            return;
        }
        static void ship_number()
        {
            int degree ,degree_1;
            Console.Clear();
            Console.Write("Enter the Latitudinal Degree: ");
            degree_1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the longitudinal Degree: ");
            degree=int.Parse(Console.ReadLine());
            foreach(Ship check in ship_list)
            {
                if (check.Latitude.Degrees == degree_1 && check.Longitude.Degrees==degree)
                {
                    Console.WriteLine( check.ship_number());
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("No ship found...");
            Console.ReadKey();
            return;
        }
        static void change_position()
        {
            string serial;
            Console.Clear();
            Console.Write("Enter the ship's serial whose position you want to change: ");
            serial = Console.ReadLine();
            foreach (Ship check in ship_list)
            {
                if (check.Serial_number == serial)
                {
                    Console.WriteLine("Enter Ship Latitude: ");
                    Console.Write("Enter Latitude’s Degree: ");
                    check.Latitude.Degrees = int.Parse(Console.ReadLine());
                    Console.Write("Enter Latitude’s Minute: ");
                    check.Latitude.Minutes = float.Parse(Console.ReadLine());
                    Console.Write("Enter Latitude’s Direction: ");
                    check.Latitude.Direction = char.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Ship Longitude: ");
                    Console.Write("Enter Longitude’s Degree: ");
                    check.Longitude.Degrees = int.Parse(Console.ReadLine());
                    Console.Write("Enter Longitude’s Minute: ");
                    check.Longitude.Minutes = float.Parse(Console.ReadLine());
                    Console.Write("Enter Longitude’s Direction: ");
                    check.Longitude.Direction = char.Parse(Console.ReadLine());
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("No ship found...");
            Console.ReadKey();
            return;
        }
    }
}
