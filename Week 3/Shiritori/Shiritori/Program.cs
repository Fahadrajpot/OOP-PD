using Shiritori.BL;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiritori
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Game game = new Game();
                Console.Write("Enter the word: ");
                game.words.Add(Console.ReadLine());
                while (true)
                {
                    Console.Write("Enter the word: ");
                    game.words.Add(Console.ReadLine());
                    game.game_over = game.check();


                    if (game.game_over == true)
                    {
                        Console.Write("Game Over");
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }
    }
}
