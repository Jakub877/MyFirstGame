using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame
{
    class Item
    {
        public int Id { get; private set; }
        public string Name { get; private set; } //lista?
        public string Rarity { get; private set; }
        public int LevelRequirement { get; private set; }
        public int Value { get; private set; }
        public string Type { get; private set; }



        public Item(string name, string rarity, int levelRequirement, int value, string type)
        {
            Id = Program.Globals.ItemId;
            Program.Globals.ItemId++;
            Name = name;
            Rarity = rarity;
            LevelRequirement = levelRequirement;
            Value = value;
            Type = type;

            //public enum Grades { F = 0, D = 1, C = 2, B = 3, A = 4 };
            //Grades.F;
            //public static Grades minPassing = Grades.A;


            //if (item == "Rat Tail")
            //{



            //}

        }

        //public Items rat_tail
        //{
        //    rat_tail.Name = "Rat Tail";
        //    rat_tail.Id = 1;
        //}

    }
}
