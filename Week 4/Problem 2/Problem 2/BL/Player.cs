using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL
{
    internal class Player
    {
        public string Name;
        public int MaxHp;
        private int hp;
        public int Maxenergy;
        private int energy;
        private int armor;

        private List<Stats> learnedSkills = new List<Stats>();
        public Player(string name, int health, int maxHealth, int energy, int maxEnergy, int armor)
        {
            Name = name;
            MaxHp = maxHealth;
            Maxenergy = maxEnergy;
            Hp = health;
            Energy = energy;
            Armor = armor;
        }
        public int Hp
        {
            get { return hp; }
            set { hp = Math.Min(Math.Max(value, 0), MaxHp); }
        }
        public int Energy
        {
            get { return energy; }
            set { energy = Math.Min(Math.Max(value, 0), Maxenergy); }
        }
        public int Armor
        {
            get { return armor; }
            set { armor = value; }
        }
        public void LearnSkill(Stats skillStats)
        {

            if (learnedSkills.Contains(skillStats))
            {
                learnedSkills.Add(skillStats);

                Console.WriteLine("{0} learned {1}", Name, skillStats.Name);

            }
        }
        public string Attack(Player target, Stats skill)
        {
            int effectiveArmor = target.Armor - (int)skill.Penetration;
            effectiveArmor = Math.Max(effectiveArmor, 0);


            if (Energy < skill.Cost)
            {

                string answer;
                answer = Name + " attempted to use " + skill.Name + ", but didn't have enough energy!";
                return answer;

            }

            Energy -= skill.Cost;


            double calculatedDamage = skill.Damage * ((100.0 - effectiveArmor) / 100.0);
            int damageToDeal = (int)Math.Round(calculatedDamage);


            target.Hp -= damageToDeal;
            string attackString;
            attackString = Name + " used skill " + skill.Name + ", " + skill.Description + ", against " + target.Name + ", doing " + damageToDeal + " damage!";
            if (skill.Heal > 0)
            {
                Hp += skill.Heal;
                attackString += Name + " healed for " + skill.Heal + " health!";
            }
            if (target.Hp <= 0)
            {
                attackString += target.Name + " died!";
            }
            else
            {
                double targetHpPercentage = ((double)target.Hp / target.MaxHp) * 100.0;

                attackString += target.Name + " is at " + targetHpPercentage + "% health.";

            }

            return attackString;
        }
    }
}
