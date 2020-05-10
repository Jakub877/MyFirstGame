using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame
{
    class Loots
    {
        private Monster Monster;
        public List<string> LootList { get; private set; } //= new List<string, int>();
        public List<string> LootAmmount { get; private set; } //= new List<string, int>();
        public Loots() //MonsterSheet monster
        {
            //Monster = monster;
        }

        //public enum Grades { "Small rat" = small_rat, D = 1, C = 2, B = 3, A = 4 };
        //public var list { get; private set; } = new List<Tuple<string, int>>();
        //list.Add(Tuple.Create("hello", 1));
        public List<LootsList> GetLoot(string monster)
        {
            List<LootsList> customLootList = new List<LootsList>();

            //if (Monster.MonsterType == "Rat")

            if (monster == "Small Rat") //Monster.Name
            {
                customLootList.Add(new LootsList() { ItemName = "Small Rat Tail", Count = 1 });
                //customLootList.Add(new LootsList() { Item = "small rat teeth", Count = 1 });
            }
            else if (monster == "Rat")
            {
                customLootList.Add(new LootsList() { ItemName = "Rat Tail", Count = 2 });
                customLootList.Add(new LootsList() { ItemName = "Rat Teeth", Count = 1 });
            }
            else if (monster == "Cave Rat")
            {
                customLootList.Add(new LootsList() { ItemName = "Cave Rat Tail", Count = 3 });
                customLootList.Add(new LootsList() { ItemName = "Cave Rat Teeth", Count = 2 });
                customLootList.Add(new LootsList() { ItemName = "Cave Rat Meat", Count = 1 });
            }


            return customLootList;
        }


        //enum RatTypes { small_rat = small rat }

        //RatTypes.small_rat





        //lista dropow
        //to można Dictiopnary<Przedmiot, int>
        //ale to mi zawsze się w którymś momencie supie
        //i robię własny obiekt
        //który ma property Count
        //i Przedmiot
        //i mam List<MojaKlasa>
        //i tam mam MojaKlasa.Count
        //to ilosc
        //MojaKlasa.Przedmiot to wewnętrz tego mam co i jak
    }
}
