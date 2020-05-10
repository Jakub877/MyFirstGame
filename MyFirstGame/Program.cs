using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame
{
    class Program
    {
        public static class Globals
        {
            public static int dzien = 1;
            public static Random rnd = new Random();
            public static int ItemId = 1;



            //Items small_rat_tail = new Items("Small Rat Tail", "Common", 0, 1, "Beast Trophy");
            //Items rat_tail = new Items("Rat Tail", "Common", 0, 2, "Beast Trophy");
            //Items cave_rat_tail = new Items("Cave Rat Tail", "Common", 0, 4, "Beast Trophy");
            //public enum Grades1 {
            //    Items small_rat_tail = new Items("Small Rat Tail", "Common", 0, 1, "Beast Trophy") = 1, 
            //    rat_tail = new Items() { ("Small Rat Tail", "Common", 0, 1, "Beast Trophy") }  = 2, 
            //    cave_rat_tail = 3 
            //            };

            public enum WeekDays
            {
                Monday = 0,
                Tuesday = 1,
                Wednesday = 2,
                Thursday = 3,
                Friday = 4,
                Saturday = 5,
                Sunday = 6
            }
        }

        public class Statistic
        {
            private int _month = 7;
        }
        static void Main()
        {




            Item small_rat_tail = new Item("Small Rat Tail", "Common", 0, 1, "Beast Trophy");
            Item rat_tail = new Item("Rat Tail", "Common", 0, 2, "Beast Trophy");
            Item cave_rat_tail = new Item("Cave Rat Tail", "Common", 0, 4, "Beast Trophy");
            List<Item> customItemList = new List<Item>();

            customItemList.Add(small_rat_tail);
            customItemList.Add(rat_tail);
            customItemList.Add(cave_rat_tail);



            //enum Grades { 
            //    small_rat_tail = 1, 
            //    rat_tail = 2, 
            //    cave_rat_tail = 3 
            //            };

            //customItemList.Add(new LootsList() { Item = "cave rat meat", Count = 1 });

            //public Random rnd = new Random();
            Console.Write("Write you character name: ");
            string name = Console.ReadLine();
            MainCharacter MainHero = new MainCharacter(name);

            Console.Write($"Your character name is {MainHero.Name}.");
            Monster Rat1 = new Monster("Rat", 1);
            Monster Rat2 = new Monster("Rat", 11);
            Monster Rat3 = new Monster("Rat", 21);
            List<Monster> MonstersList = new List<Monster>();

            while (true)
            {

                //string opcja = Menu(mojSzpital, pokazKoszty, pokazStan);
                string option = Menu();

                if (option == "1")
                {
                    MainHero.ShowCharacterStatistics();
                }
                else if (option == "2")
                    Rat1.ShowMonsterStatistics();

                else if (option == "3")
                    Rat2.ShowMonsterStatistics();

                else if (option == "4")
                    Rat3.ShowMonsterStatistics();

                else if (option == "5")
                    MainHero.AddAttribute("Strength", 5);

                else if (option == "6")
                {
                    Console.Clear();
                    Console.WriteLine("1.Small Rat");
                    Console.WriteLine("2.Rat");
                    Console.WriteLine("3.Cave Rat");
                    Console.WriteLine("4. 3 Small Rats");
                    Console.WriteLine("9.Back to Main Menu");

                    string explotarionOption = Console.ReadLine();

                    if (explotarionOption == "1")
                    {
                        Monster monster = new Monster("Rat", 1);
                        Combat customCombat = new Combat(MainHero, monster);
                        MonstersList.Add(monster);
                        customCombat.InitiateCombat(MonstersList);
                        //break;
                    }
                    else if (explotarionOption == "2")
                    {
                        Monster monster = new Monster("Rat", 11);
                        Combat customCombat = new Combat(MainHero, monster);
                        MonstersList.Add(monster);
                        customCombat.InitiateCombat(MonstersList);
                        //break;
                    }
                    else if (explotarionOption == "3")
                    {
                        Monster monster = new Monster("Rat", 21);
                        Combat customCombat = new Combat(MainHero, monster);
                        MonstersList.Add(monster);
                        customCombat.InitiateCombat(MonstersList);
                        //break;
                    }
                    else if (explotarionOption == "4")
                    {
                        Monster monster_1 = new Monster("Rat", 1);
                        Monster monster_2 = new Monster("Rat", 1);
                        Monster monster_3 = new Monster("Rat", 1);
                        Combat customCombat = new Combat(MainHero, monster_1);
                        MonstersList.Add(monster_1);
                        MonstersList.Add(monster_2);
                        MonstersList.Add(monster_3);
                        customCombat.InitiateCombat(MonstersList);
                        //break;
                    }

                    else
                    {
                        //break;
                    }


                }
                //     7. Restore Full Health       Console.WriteLine("8. Add Exp");

                else if (option == "7")
                {

                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("1. Restore Full Health and Mana");
                        Console.WriteLine("2. Add Exp");
                        Console.WriteLine("3. Add Gold");
                        Console.WriteLine("9. Back to Main Menu");
                        string readkey;
                        int value;
                        string cheatOption = Console.ReadLine();



                        if (cheatOption == "1")
                        {
                            MainHero.Heal(-1);
                            MainHero.ManaPointsRestoration(-1);
                            Console.WriteLine("HP and MP has been restored! Press any key to continue.");
                            Console.ReadKey();
                        }
                        else if (cheatOption == "2")
                        {
                            Console.WriteLine("Type exp value. ");
                            readkey = Console.ReadLine();
                            if (Int32.TryParse(readkey, out value) == false)
                            {
                                Console.WriteLine("Incorrect value! Press any key to continue.");
                                Console.ReadKey();
                            }
                            else
                            {
                                MainHero.GetExpierience(value);
                                Console.WriteLine("Exp has been added! Press any key to continue.");
                                Console.ReadKey();
                            }
                               
                        }
                        else if (cheatOption == "3")
                        {
                            Console.WriteLine("Type gold value to add. ");
                            readkey = Console.ReadLine();
                            if (Int32.TryParse(readkey, out value) == false)
                            {
                                Console.WriteLine("Incorrect value! Press any key to continue.");
                                Console.ReadKey();
                            }
                            else
                            {
                                MainHero.AddGold(value);
                                Console.WriteLine("Gold has been added! Press any key to continue.");
                                Console.ReadKey();
                            }

                        }
                        //Console.WriteLine("4. ");
                        else if (cheatOption == "9")
                        {
                            break;
                        }

                    }

                }

                else if (option == "8")
                {
                    int inventoryOption;
                    string inventoryLine;
                    List<int> indexListOfSellableItems = new List<int>();
                    int k = 0;
                    //Begin:

                    while(true)
                    {
                        Console.Clear();
                        Console.WriteLine("Your inventory:");
                        MainHero.CharacterInventory.GetInventory();
      
                        //(ItemList.Find(x => x.Name == item.ItemName)).Value
                        //MainHero.CharacterInventory.ItemList.
                    
                        //(MainHero.CharacterInventory.InventoryList.ElementAt(inventoryOption - 1)).ItemName;
                        //(MainHero.CharacterInventory.InventoryList.(x => x.ItemName == (MainHero.CharacterInventory.InventoryList.ElementAt(inventoryOption - 1).ItemName)))
                        //(MainHero.CharacterInventory.InventoryList.Find(x => x.ItemName == (MainHero.CharacterInventory.InventoryList.ElementAt(inventoryOption - 1).ItemName))).   
                    
                        //to nie zadziała, gdy niezerowa liczba samych niesselabble itemow
                        Console.WriteLine("");
                        if (MainHero.CharacterInventory.InventoryList?.Any() != false) //MainHero.CharacterInventory.InventoryList.Any() == false && MainHero.CharacterInventory.InventoryList.Count != 0) //MainHero.CharacterInventory.InventoryList != null &&
                        {
                            Console.WriteLine("Your sellable inventory:");
                            foreach (LootsList item in MainHero.CharacterInventory.InventoryList)
                            {
                                //Any(item => item.UniqueProperty == wonderIfItsPresent.UniqueProperty)
                                if (MainHero.CharacterInventory.ItemList.Any(x => x.Name == item.ItemName))
                                {
                                    Console.WriteLine($"{k}. {item.Count} {item.ItemName}");
                                    indexListOfSellableItems.Add(k);
                                }

                                k++;
                            }
                        
                            if (indexListOfSellableItems?.Any() != true)
                            {
                                Console.WriteLine("There are not any sellable items in your inventory!:");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                break;
                            }
                            else
                            { 
                                Console.WriteLine("Write item`s index to sell all items corresponding to it. Write 'E' to exit");
                                inventoryLine = Console.ReadLine();//.ToString();
                                //inventoryOption = Int32.Parse(inventoryLine);
                                if(inventoryLine=="e" || inventoryLine=="E")
                                {
                                    break;
                                }

                                if (Int32.TryParse(inventoryLine, out inventoryOption) == false) //|| indexListOfSellableItems.Exists(x => x == inventoryOption)==false)
                                {
                                    Console.WriteLine("Incorrect value! Press any key to continue.");
                                    Console.ReadKey();
                                    //goto Begin;
                                }

                                if (indexListOfSellableItems.Exists(x => x == inventoryOption) == false) //|| indexListOfSellableItems.Exists(x => x == inventoryOption)==false)
                                {
                                    Console.WriteLine("Unknown command! Press any key to continue.");
                                    Console.ReadKey();
                                    //goto Begin;
                                }
                                else
                                {
                                    MainHero.AddGold(MainHero.CharacterInventory.InventoryList.ElementAt(inventoryOption).Count * ((MainHero.CharacterInventory.ItemList.Find(x => x.Name == MainHero.CharacterInventory.InventoryList.ElementAt(inventoryOption).ItemName))).Value);
                                    Console.WriteLine($"You sold {MainHero.CharacterInventory.InventoryList.ElementAt(inventoryOption).Count} {MainHero.CharacterInventory.InventoryList.ElementAt(inventoryOption).ItemName} for {MainHero.CharacterInventory.InventoryList.ElementAt(inventoryOption).Count * ((MainHero.CharacterInventory.ItemList.Find(x => x.Name == MainHero.CharacterInventory.InventoryList.ElementAt(inventoryOption).ItemName))).Value} gold.");
                                    MainHero.CharacterInventory.InventoryList.RemoveAt(inventoryOption);
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey();
                                }
 
                            }
                            k = 0;
                            indexListOfSellableItems.Clear();
                            //( MainHero.CharacterInventory.InventoryList.ElementAt(k).ItemName )



                        }
                        else
                        {
                            //Console.WriteLine("Press any key to continue.");
                            break;
                        }


                    }
                    //(MainHero.CharacterInventory.InventoryList.ElementAt(inventoryOption - 1).ItemName);


                }

                else if (option == "9")
                {
                    Console.Clear();
                    Console.WriteLine("1.Small Rat");
                    Console.WriteLine("2.Rat");
                    Console.WriteLine("3.Cave Rat");
                    Console.WriteLine("4. 3 Small Rats");
                    Console.WriteLine("9.Back to Main Menu");
                    int i = 0;
                    Tavern tavern = new Tavern();
                    foreach (TavernMealOption tavernMealOption in tavern.TavernMealOptions)
                    {
                        Console.WriteLine($"{tavernMealOption.Name}");

                    }

                    foreach (string tavernMealOption in tavern.MealOptions())
                    {
                        Console.WriteLine($"{i}. {tavernMealOption}");
                        i++;
                    }

                    string tavernOption = Console.ReadLine();


                    if (Int32.Parse(tavernOption) <= i)
                    {
                        tavern.EatMeal(tavern.TavernMealOptions.ElementAt(Int32.Parse(tavernOption)).Name, MainHero);
                    }
                    //else if (tavernOption == "2")
                    //{

                    //}
                    //else if (tavernOption == "3")
                    //{

                    //}


                }

                //else if (opcja == "2")
                //{

                //    string wybranaOpcja = WyborTrudnosciWyprawy();

                //    Wyprawa wyprawa = new Wyprawa(mojSzpital);

                //    while (true)
                //    {
                //        if (wybranaOpcja == "1")
                //        {
                //            wyprawa.WyruszNaWyprawe("latwy");
                //            break;

                //        }
                //        else if (wybranaOpcja == "2")
                //        {
                //            wyprawa.WyruszNaWyprawe("normalny");
                //            break;
                //        }
                //        else if (wybranaOpcja == "3")
                //        {
                //            wyprawa.WyruszNaWyprawe("trudny");
                //            break;
                //        }
                //        else if (wybranaOpcja == "9")
                //        {
                //            break;
                //        }

                //    }
                //}


                //else if (opcja == "9")
                //{
                //    //przechodzimy do następnego dnia
                //    NextDay(mojSzpital);

                //}
                //else if (opcja == "7")
                //{
                //    while (true)
                //    {
                //        string OpcjaUstawien = Ustawienia(pokazStan, pokazKoszty);
                //        if (OpcjaUstawien == "1")
                //        {
                //            pokazStan = !pokazStan;
                //        }
                //        else if (OpcjaUstawien == "2")
                //        {
                //            pokazKoszty = !pokazKoszty;
                //        }
                //        else if (OpcjaUstawien == "9")
                //        {
                //            break;
                //        }

                //    }

                //}

                else if (option == "0")
                {
                    Console.WriteLine("Game end");
                    break;
                }
            }



            //static void Main()
            //{

            //    Console.Write("Nazwa Twojego szpitala: ");
            //    string nazwaSzpitala = Console.ReadLine();

            //    Szpital mojSzpital = new Szpital(nazwaSzpitala);
            //    bool pokazKoszty = false;
            //    bool pokazStan = false;
            //    while (true)
            //    {

            //        string opcja = Menu(mojSzpital, pokazKoszty, pokazStan);


            //        if (opcja == "1")
            //        {
            //            mojSzpital.PokazParametrySzpitala();
            //        }
            //        else if (opcja == "2")
            //        {

            //            string wybranaOpcja = WyborTrudnosciWyprawy();

            //            Wyprawa wyprawa = new Wyprawa(mojSzpital);

            //            while (true)
            //            {
            //                if (wybranaOpcja == "1")
            //                {
            //                    wyprawa.WyruszNaWyprawe("latwy");
            //                    break;

            //                }
            //                else if (wybranaOpcja == "2")
            //                {
            //                    wyprawa.WyruszNaWyprawe("normalny");
            //                    break;
            //                }
            //                else if (wybranaOpcja == "3")
            //                {
            //                    wyprawa.WyruszNaWyprawe("trudny");
            //                    break;
            //                }
            //                else if (wybranaOpcja == "9")
            //                {
            //                    break;
            //                }

            //            }
            //        }
            //        else if (opcja == "3")
            //        {
            //            mojSzpital.ZatrudnijLekarzy();

            //        }

            //        else if (opcja == "4")
            //        {
            //            mojSzpital.UlepszSzpital();
            //        }

            //        else if (opcja == "9")
            //        {
            //            //przechodzimy do następnego dnia
            //            NextDay(mojSzpital);

            //        }
            //        else if (opcja == "7")
            //        {
            //            while (true)
            //            {
            //                string OpcjaUstawien = Ustawienia(pokazStan, pokazKoszty);
            //                if (OpcjaUstawien == "1")
            //                {
            //                    pokazStan = !pokazStan;
            //                }
            //                else if (OpcjaUstawien == "2")
            //                {
            //                    pokazKoszty = !pokazKoszty;
            //                }
            //                else if (OpcjaUstawien == "9")
            //                {
            //                    break;
            //                }

            //            }

            //        }

            //        else if (opcja == "0")
            //        {
            //            Console.WriteLine("Koniec gry");
            //            break;
            //        }
            //    }
            //}

            //private static string Menu(Szpital mojSzpital, bool pokazKoszty, bool pokazStan)
            //{
            //    Console.WriteLine("Wduś Enter, żeby kontynuować...");
            //    Console.ReadLine();
            //    Console.Clear();

            //    if (pokazStan == true)
            //        mojSzpital.PokazPodstawoweParametrySzpitala();

            //    Console.WriteLine("1. Sprawdź parametry szpitala");
            //    if (pokazKoszty == true)
            //    {
            //        Console.WriteLine("2. Wyrusz na wyprawę [koszt: 50 bananowych złotych, 1 Lekarz] ");
            //        //[3. zatrudnij lekarza] 
            //        Console.WriteLine("3. Zatrudnij Lekarza [koszt: 30 bananowych złotych]");
            //        Console.WriteLine($"4. Ulepsz Szpital [koszt: {50 * (Math.Pow(mojSzpital.PoziomSzpitala + 1, 2))} bananowych złotych]");
            //    }
            //    else
            //    {
            //        Console.WriteLine("2. Wyrusz na wyprawę");
            //        Console.WriteLine("3. Zatrudnij Lekarza");
            //        Console.WriteLine("4. Ulepsz Szpital");
            //    }
            //    //3 rodzaje wypraw do wyboru
            //    //opcja 3. zatrudnij lekarza za 30bzł
            //    //opcja 8. ulepsz szpital
            //    //  -podnieść poziom szpitala
            //    //  -zwiększenie ilości łóżek
            //    //  -zwiększenie ilości możliwych dostępnych lekarzy
            //    //  -ulepszenie powinno być drogie :)

            //    Console.WriteLine("7. Ustawienia");
            //    Console.WriteLine("9. Następny dzień");
            //    Console.WriteLine("0. Koniec");

            //    return Console.ReadLine();
            //}

            //private static string Ustawienia(bool pokazStan, bool pokazKoszty)
            //{

            //    Console.Clear();
            //    if (pokazStan == false)
            //        Console.WriteLine("1. Pokaż pasek stanu nad menu");
            //    else
            //        Console.WriteLine("1. Ukryj pasek stanu nad menu");

            //    if (pokazKoszty == false)
            //        Console.WriteLine("2. Pokaż koszty opcji w menu");
            //    else
            //        Console.WriteLine("2. Ukryj koszty opcji w menu");
            //    Console.WriteLine("9. Powrót do menu");


            //    return Console.ReadLine();

            //}

            //private static string WyborTrudnosciWyprawy()
            //{

            //    Console.Clear();
            //    Console.WriteLine("1. Łatwa wyprawa");
            //    Console.WriteLine("2. Normalna wyprawa");
            //    Console.WriteLine("3. Trudna wyprawa");
            //    Console.WriteLine("9. Powrót do menu");

            //    return Console.ReadLine();
            //}

            //private static void NextDay(Szpital mojSzpital)
            //{
            //    Globals.dzien++;
            //    Console.WriteLine("Zaczyna się dzień " + Globals.dzien);

            //    mojSzpital.WyleczPacjentow();
            //    Random losowanie = new Random();
            //    if (losowanie.Next(0, 5) == 3)
            //    {
            //        int mnoznik = mojSzpital.PoziomSzpitala * 10;
            //        int kasa = losowanie.Next(mnoznik, mnoznik * 3);
            //        mojSzpital.WplywDoBudzetu(kasa);
            //        Console.WriteLine("Do budżetu skapnęły ochłapy z NFZ w wysokości (" + kasa + ").");
            //    }


            //    Console.WriteLine("Za wyleczenie pacjentów do budżetu skapnęły bananowe złote w wysokości (" + mojSzpital.Przychod() + ").");
            //}
        }
        private static string Menu()//(Szpital mojSzpital, bool pokazKoszty, bool pokazStan)
        {
            Console.WriteLine("Press any key, to continue...");
            Console.ReadLine();
            Console.Clear();

            //if (pokazStan == true)
            //    mojSzpital.PokazPodstawoweParametrySzpitala();

            Console.WriteLine("1. Show character statictics");
            Console.WriteLine("2. Show lvl 1 rat statictics");
            Console.WriteLine("3. Show lvl 11 rat statictics");
            Console.WriteLine("4. Show lvl 21 rat statictics");
            Console.WriteLine("5. Add 5 strength");
            Console.WriteLine("6. Exploration");
            Console.WriteLine("7. Cheats");
            Console.WriteLine("8. Inventory");
            Console.WriteLine("9. Tavern");
            Console.WriteLine("0. Exit");

            return Console.ReadLine();
        }
    }


}
