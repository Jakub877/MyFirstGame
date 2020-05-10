using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame
{
    class Inventory
    {
        public List<LootsList> InventoryList { get; set; }
        
        public List<Item> ItemList { get; set; }


        public Inventory()
        {
            List<LootsList> inventoryList = new List<LootsList>();
            InventoryList = inventoryList;

            Item small_rat_tail = new Item("Small Rat Tail", "Common", 0, 1, "Beast Trophy");
            Item rat_tail = new Item("Rat Tail", "Common", 0, 2, "Beast Trophy");
            Item cave_rat_tail = new Item("Cave Rat Tail", "Common", 0, 4, "Beast Trophy");
            List<Item> customItemList = new List<Item>();

            customItemList.Add(small_rat_tail);
            customItemList.Add(rat_tail);
            customItemList.Add(cave_rat_tail);
            ItemList = customItemList;
        }

        public void GetInventory()
        {
            if(InventoryList.Count() ==0)
            {
                Console.WriteLine("There are no items in inventory!");
                return;
            }
            int i = 0;

            foreach (LootsList item in InventoryList)
            {
                //Any(item => item.UniqueProperty == wonderIfItsPresent.UniqueProperty)
                if (ItemList.Any(x => x.Name == item.ItemName))
                {
                    Console.WriteLine($"{i}. [{item.Count} x {item.ItemName}][value {(ItemList.Find(x => x.Name == item.ItemName)).Value}]");
                }
                else
                {
                    Console.WriteLine($"{i}. [{item.Count} x {item.ItemName}]");
                }
                i++;
            }
        }



        public List<LootsList> AddInventory(List<LootsList> inventoryBase, List<LootsList> inventoryToInsert)
        {
            //List<LootsList> inventory = new List<LootsList>();


            
            inventoryBase.AddRange(inventoryToInsert);
            inventoryBase=ReorganizeInventoryList(inventoryBase);
            return inventoryBase;
        }

        public List<LootsList> ReorganizeInventoryList(List<LootsList> inventoryToReorganize)
        {
            //tavernMealOption = TavernMealOptions.Find(x => x.Name == meal);
            if(inventoryToReorganize == null || inventoryToReorganize.Any()==false || inventoryToReorganize.Count == 1)
            {
                return inventoryToReorganize;
            }

            //var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here


            inventoryToReorganize = inventoryToReorganize.AsQueryable().GroupBy(u => u.ItemName).Select(cl => new LootsList
            {
                ItemName = cl.Key, // First().Item
                Count = cl.Sum(pc => pc.Count)
            }).ToList();

            

            // Other method
            //List<LootsList> inventory = new List<LootsList>();
            //foreach (LootsList item in inventoryToReorganize)
            //{
            //    if (inventory.Exists(x => x.Item == item.Item))
            //    {
            //        (inventory.Find(x => x.Item == item.Item)).Count += item.Count;
            //    }
            //    else
            //    {
            //        inventory.Add(item);
            //    }
            //}
            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //Console.WriteLine($"Time: {elapsedMs}");

            return inventoryToReorganize; //inventoryToReorganize inventory
        }

    }       
}
