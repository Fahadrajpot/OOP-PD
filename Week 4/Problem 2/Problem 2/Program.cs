using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.BL;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> PlayerData = new List<Player>();
            List<Stats> SkillData = new List<Stats>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("Press 1 to Add Player");
                Console.WriteLine("Press 2 to Add Skill Statistics");
                Console.WriteLine("Press 3 to Display Player Info");
                Console.WriteLine("Press 4 to Learn a Skill");
                Console.WriteLine("Press 5 to Attack");
                Console.WriteLine("Press 6 to Exit");

                Console.Write("Enter your option: ");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    Console.Clear();
                    Console.Write("Enter Player Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter player Health: ");
                    int health = int.Parse(Console.ReadLine());

                    Console.Write("Enter player Max Health: ");
                    int maxHealth = int.Parse(Console.ReadLine());

                    Console.Write("Enter player Energy: ");
                    int energy = int.Parse(Console.ReadLine());

                    Console.Write("Enter player Max Energy: ");
                    int maxEnergy = int.Parse(Console.ReadLine());

                    Console.Write("Enter player Armor: ");
                    int armor = int.Parse(Console.ReadLine());

                    Player player = new Player(name, health, maxHealth, energy, maxEnergy, armor);
                    PlayerData.Add(player);
                    Console.ReadKey();
                }
                if (option == "2")
                {
                    Console.Clear();
                    Console.Write("Enter Skill Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Damage: ");
                    int damage = int.Parse(Console.ReadLine());

                    Console.Write("Enter Penetration: ");
                    double penetration = double.Parse(Console.ReadLine());

                    Console.Write("Enter Heal: ");
                    int heal = int.Parse(Console.ReadLine());

                    Console.Write("Enter Cost: ");
                    int cost = int.Parse(Console.ReadLine());

                    Console.Write("Enter Description: ");
                    string description = Console.ReadLine();

                    Stats skill = new Stats(name, damage, penetration, heal, cost, description);
                    SkillData.Add(skill);
                    Console.WriteLine("Skill statistics added successfully!");
                    Console.ReadKey();
                }
                if (option == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Player Info:");
                    foreach (var player in PlayerData)
                    {

                        Console.WriteLine("Name: {0}, Health: {1}/{2}, Energy: {3}/{4}, Armor: {5}", player.Name, player.Hp, player.MaxHp, player.Energy, player.Maxenergy, player.Armor);
                    }
                    Console.ReadKey();
                }
                if (option == "4")
                {
                    Console.Clear();
                    Console.Write("Enter Player Name: ");
                    string playerName = Console.ReadLine();

                    Console.Write("Enter Skill Name: ");
                    string skillName = Console.ReadLine();

                    Player player = PlayerData.Find(p => p.Name == playerName);
                    if (player == null)
                    {
                        Console.WriteLine("Player not found!");
                        Console.ReadKey();
                    }

                    Stats skill = SkillData.Find(s => s.Name == skillName);
                    if (skill == null)
                    {
                        Console.WriteLine("Skill not found!");
                        Console.ReadKey();
                    }
                    if (player != null && skill != null)
                    {
                        player.LearnSkill(skill);
                        Console.WriteLine("{0} learned {1}!", playerName, skillName);
                    }
                    Console.ReadKey();

                }
                if (option == "5")
                {
                    Console.Clear();
                    Console.WriteLine("Choose Attacking Player:");
                    foreach (var player in PlayerData)
                    {

                        Console.WriteLine("Name: {0}, Health: {1}/{2}, Energy: {3}/{4}, Armor: {5}", player.Name, player.Hp, player.MaxHp, player.Energy, player.Maxenergy, player.Armor);
                    }
                    Console.Write("Enter Attacking Player Name: ");
                    string attackerName = Console.ReadLine();

                    Console.WriteLine("Choose Target Player:");
                    foreach (var player in PlayerData)
                    {

                        Console.WriteLine("Name: {0}, Health: {1}/{2}, Energy: {3}/{4}, Armor: {5}", player.Name, player.Hp, player.MaxHp, player.Energy, player.Maxenergy, player.Armor);
                    }
                    Console.Write("Enter Target Player Name: ");
                    string targetName = Console.ReadLine();

                    Player attacker = PlayerData.Find(p => p.Name == attackerName);
                    Player target = PlayerData.Find(p => p.Name == targetName);

                    if (attacker == null || target == null)
                    {
                        Console.WriteLine("Invalid player names!");
                        return;
                    }

                    Console.WriteLine(attacker.Attack(target, SkillData[0]));
                    Console.ReadKey();
                }
                if (option == "6")
                {
                    break;
                }


            }
        }
    }
}
