using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame
{
    class Combat
    {
        private MainCharacter Hero;
        private Monster Monster_1;

        public Combat(MainCharacter hero_1, Monster monster_1, Monster monster2 = null)
        {
            Hero = hero_1;
            Monster_1 = monster_1;
        }

        public bool HeroAttack(Monster attacked_monster)
        {
            //Random rnd = new Random();
            Monster_1 = attacked_monster;
            int damage = Program.Globals.rnd.Next(Hero.MinimumPhysicalDamage, Hero.MaximumPhysicalDamage + 1);

            Console.WriteLine($"{Hero.Name} dealts {damage} physical damage to {Monster_1.Name} [{Monster_1.HitPoints} hp]. {Monster_1.Name} remaining health is {Monster_1.HitPoints - damage}.");

            if (Monster_1.GetDamage(damage) == true)
            {
                return true;
                //Monster_1.GetDamage(damage);
            }
            else
            {
                return false;
                //Monster_1.GetDamage(damage);
            }
        }

        public bool MonsterAttack(List<Monster> attacking_monsters)
        {
            //Random rnd = new Random();
            //Monster_1 = attacking_monsters.E;



            foreach (Monster aMonster in attacking_monsters)
            {

                int damage = Program.Globals.rnd.Next(aMonster.MinimumPhysicalDamage, aMonster.MaximumPhysicalDamage + 1);

                Console.WriteLine($"{aMonster.Name} dealts {damage} physical damage to {Hero.Name} [{Hero.HitPoints} hp]. {Hero.Name} remaining health is {Hero.HitPoints - damage}.");
                if (Hero.GetDamage(damage) == false)
                {
                    return false;
                    //Monster_1.GetDamage(damage);
                }
            }

            return true;
            //if (Hero.GetDamage(damage) == true)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public void InitiateCombat(List<Monster> monsterList)
        {
            Console.Clear();
            if (monsterList.Count == 0)
            {
                throw new Exception("There are no monsters to fight with!");
            }

            Random rnd = new Random();
            //Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Blue;
            List<LootsList> customLootList = new List<LootsList>();
            Loots customLoots = new Loots();
            int totalExperience = 0;
            foreach (Monster aMonster in monsterList)
            {
                totalExperience += aMonster.Experience;
            }
            foreach (Monster aMonster in monsterList)
            {

                customLootList.AddRange(customLoots.GetLoot(aMonster.Name));
            }


            for (int turn = 1; ; turn++)
            {
                Console.WriteLine($"Turn {turn}: {Hero.Name}[{Hero.HitPoints} hp]");//, {Monster_1.Name}[{Monster_1.HitPoints} hp]");
                foreach (Monster aMonster in monsterList)
                {
                    Console.WriteLine($"{aMonster.Name}[{aMonster.HitPoints}]");
                }


                for (int i = 0; i < 4; i++)
                {
                    //damage = rnd.Next(Hero.MinimumPhysicalDamage, Hero.MaximumPhysicalDamage + 1);
                    //damaged_box = box - damage;
                    //Console.WriteLine($"{Hero.Name} dealts {damage} physical damage to box {box } hp). Box remaining health is {damaged_box}.");
                    //box = damaged_box;

                    if (HeroAttack(monsterList.ElementAt(0)) == false)
                    {
                        Console.WriteLine($"{Monster_1.Name} is slayed.");
                        monsterList.RemoveAt(0); //Count   
                    }

                    if (monsterList.Count == 0)
                    {
                        break;
                    }


                    if (MonsterAttack(monsterList) == false)
                    {
                        Console.WriteLine($"{Hero.Name} is defeated.");
                        break;
                    }
                }

                //if (box > 0)
                //{
                //    Console.ReadKey();
                //}
                if (Hero.HitPoints <= 0)
                {
                    Console.WriteLine($"{Hero.Name} loses combat!");
                    break;
                }
                else if (monsterList.Count == 0)//(Monster_1.HitPoints <= 0)
                {
                    Console.WriteLine($"All monsters are slayed. {Hero.Name} wins combat!");
                    Console.WriteLine("");
                    Console.WriteLine($"{Hero.Name} gained {totalExperience} experience points.");
                    Hero.GetExpierience(totalExperience);
                    Console.WriteLine($"{Hero.Name} get following items:");
                    foreach (LootsList aPart in customLootList)
                    {
                        Console.WriteLine($"{aPart.Count} {aPart.ItemName}");
                    }
                    Hero.AddInventory(customLootList);
                    break;
                }
                Console.WriteLine("");

            }




            Console.ReadKey();
            Console.ResetColor();
            return;
        }

    }
}
