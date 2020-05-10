using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame
{
    class Monster
    {
        public string MonsterType { get; }
        public string Name { get; }
        public int Level { get; }
        public int BasicPhysicalDamage { get; private set; }
        public int BasicMagicalDamage { get; private set; }
        public int BasicDistanceDamage { get; private set; }
        public int MaxHitPoints { get; private set; }
        public int MaxManaPoints { get; private set; }
        public int HitPoints { get; private set; }
        public int ManaPoints { get; private set; }
        public int MinimumPhysicalDamage { get; private set; }
        public int MaximumPhysicalDamage { get; private set; }
        public int PhysicalArmor { get; private set; }
        public int MagicArmor { get; private set; }
        public int HitAccuracy { get; private set; }
        public int Evasion { get; private set; }
        public int Experience { get; private set; }
        public string[] RatsTypes { get; private set; } = { "Small rat", "Rat", "Cave Rat" };//"Small rat", Late = -1, OnTime = 0, Early = 1 };

        public Monster(string monstertype, int level)
        {
            MonsterType = monstertype;

            //public enum Grades { F = 0, D = 1, C = 2, B = 3, A = 4 };
            //Grades.F;
            //public static Grades minPassing = Grades.A;


            if (monstertype == "Rat")
            {
                Level = level;
                if (Level < 11)
                {
                    Name = "Small Rat";
                    Experience = 10 + 1 * (Level - 1);
                }
                else if (level < 21)
                {
                    Name = "Rat";
                    Experience = 20 + 2 * (Level - 11);
                }
                else if (level < 31)
                {
                    Name = "Cave Rat";
                    Experience = 50 + 3 * (Level - 21);
                }

                MaxHitPoints = 10 + (Level - 1) * 2;
                MaxManaPoints = 0;
                HitPoints = MaxHitPoints;
                ManaPoints = MaxManaPoints;
                BasicPhysicalDamage = 1 + ((Level - 1) / 5);
                BasicMagicalDamage = 0;
                BasicDistanceDamage = 0;
                MinimumPhysicalDamage = BasicPhysicalDamage;
                MaximumPhysicalDamage = BasicPhysicalDamage + ((Level - 1) / 10);
                PhysicalArmor = (Level - 1) / 10;
                MagicArmor = 0;
                HitAccuracy = 10 + (Level - 1);
                Evasion = 10 + (Level - 1);
            }

        }

        public void ShowMonsterStatistics()
        {
            //int wyleczeniPacjenci =  IloscDostepnychLekarzy / 2;

            //if (wyleczeniPacjenci > IloscPacjentow)
            //    wyleczeniPacjenci = IloscPacjentow;

            Console.WriteLine($"{Name} level: {Level} ");
            Console.WriteLine($"HP: {HitPoints} ");
            Console.WriteLine($"MP: {ManaPoints} "); ;
            Console.WriteLine($"Physical Damage: {MinimumPhysicalDamage}-{MaximumPhysicalDamage} ");
            Console.WriteLine($"Magical Damage: {BasicMagicalDamage} ");
            Console.WriteLine($"Physical Armor: {PhysicalArmor} ");
            Console.WriteLine($"Magic Armor: {MagicArmor} ");
        }

        public bool GetDamage(int value)
        {
            if (value < 0)
            {
                value = 0;
                Console.WriteLine("Negative values are treated as 0!");
            }

            HitPoints -= value;
            if (HitPoints <= 0)
            {
                return false;
            }
            return true;
        }

    }
}
