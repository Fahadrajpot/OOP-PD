using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL
{
    internal class Stats
    {
        public string Description;
        public int Heal;
        public double Penetration;
        public int Damage;
        public int Cost;
        public string Name;
        public Stats() { }
        public Stats(string name, int damage, double penetration, int heal, int cost, string description)
        {
            Name = name;
            Damage = damage;
            Penetration = penetration;
            Heal = heal;
            Cost = cost;
            Description = description;
        }
    }
}
