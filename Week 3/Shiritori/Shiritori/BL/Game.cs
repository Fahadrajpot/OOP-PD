using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiritori.BL
{
    internal class Game
    {
        public List<string> words = new List<string>();
        public bool game_over = false;
        public Game() { }
        public bool check()
        {
            int a = words.Count;
            
            string word_1 = words[a-2];
            string word_2 = words[a-1];
            int b = word_1.Length;

            if (word_1[b-1] != word_2[0])
            {
                return true;
            }
            else 
            {

                for (int i = 0; i < a; i++)
                {
                    if (words[a - 1] == words[i])
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
