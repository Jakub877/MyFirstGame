using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame
{
    class Tavern
    {
        public int UpgradeCost { get; private set; }
        public int Level { get; private set; }
        public List<TavernMealOption> TavernMealOptions { get; private set; }
        public decimal MealHitPointsRegenerationMultiplier { get; private set; }
        public decimal MealManaPointsRegenerationMultiplier { get; private set; }

        public Tavern()
        {
            Level = 1;
            UpgradeCost = 500;
            MealHitPointsRegenerationMultiplier = 1.0m;
            MealHitPointsRegenerationMultiplier = 1.0m;
            List<TavernMealOption> TavernMealOptions1 = new List<TavernMealOption>();
            TavernMealOptions1.Add(new TavernMealOption() { Name = "Poor Cucumber Soup", TavernLevel = 1, Cost = 2, BaseHitPointsRegeneration = 10, BaseManaPointsRegeneration = 0 });
            TavernMealOptions1.Add(new TavernMealOption() { Name = "Poor Tomato Soup", TavernLevel = 1, Cost = 2, BaseHitPointsRegeneration = 0, BaseManaPointsRegeneration = 8 });
            TavernMealOptions1.Add(new TavernMealOption() { Name = "Poor Potato Soup", TavernLevel = 2, Cost = 5, BaseHitPointsRegeneration = 30, BaseManaPointsRegeneration = 0 });
            TavernMealOptions1.Add(new TavernMealOption() { Name = "Poor Carrot Soup", TavernLevel = 2, Cost = 5, BaseHitPointsRegeneration = 0, BaseManaPointsRegeneration = 25 });
            TavernMealOptions1.Add(new TavernMealOption() { Name = "Poor Vegetable Soup", TavernLevel = 2, Cost = 6, BaseHitPointsRegeneration = 20, BaseManaPointsRegeneration = 16 });
            TavernMealOptions = TavernMealOptions1;
            //Cabbage soup – prepared using sauerkraut or white cabbage
            //Cream of asparagus soup.
            //Cream of broccoli soup.
            //Cream of mushroom soup.
        }

        //Console.WriteLine("\nFind: Part where name contains \"seat\": {0}",
        //    parts.Find(x => x.PartName.Contains("seat")));
        public void EatMeal(string meal, MainCharacter mainCharacter)
        {
            TavernMealOption tavernMealOption = new TavernMealOption();
            tavernMealOption = TavernMealOptions.Find(x => x.Name == meal);
            int mealCost = tavernMealOption.Cost;
            int mealHP = tavernMealOption.BaseHitPointsRegeneration;
            int mealMP = tavernMealOption.BaseManaPointsRegeneration;
            if (mainCharacter.SubtractGold(mealCost) == false)
            {
                return;
            }
            else
            {
                mainCharacter.Heal(mealHP);
                mainCharacter.ManaPointsRestoration(mealMP);
            }

        }

        public List<string> MealOptions()
        {
            List<string> mealOptions = new List<string>();
            foreach (TavernMealOption tavernMealOption in TavernMealOptions)
            {

                if (tavernMealOption.TavernLevel <= Level)
                {
                    mealOptions.Add($"{tavernMealOption.Name} [{tavernMealOption.Cost} gold]");
                }

            }

            //var fullName = string.Join(" ", source[i]
            //                                .Select(x => x.CardValue.ToString() + " " + x.Suit.ToString()));



            return mealOptions;
        }
    }
}
