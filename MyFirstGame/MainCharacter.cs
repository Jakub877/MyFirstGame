using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame
{
    class MainCharacter
    {
        public string Name { get; }
        public int Level { get; private set; }
        public int Strength { get; private set; }
        public int Inteligence { get; private set; }
        public int Agility { get; private set; }
        public int Stamina { get; private set; }
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
        public int FreeAttributePoints { get; private set; }
        public int Dexterity { get; private set; }
        public int HitAccuracy { get; private set; }
        public int Evasion { get; private set; }
        public int MeleeWeaponMasteryLevel { get; private set; }
        public int DistanceWeaponMasteryLevel { get; private set; }
        public int MagicLevel { get; private set; }
        public int CurrentExperience { get; private set; }
        public int LevelUpExperience { get; private set; }
        public int GoldBalance { get; private set; }

        public Inventory CharacterInventory;

        public MainCharacter(string name)
        {
            Name = name;
            Level = 1;
            Strength = 10;
            Inteligence = 10;
            Agility = 10;
            Dexterity = 10;
            Stamina = 10;
            MaxHitPoints = Stamina * 10;
            MaxManaPoints = Inteligence * 10;
            HitPoints = MaxHitPoints;
            ManaPoints = MaxManaPoints;
            BasicPhysicalDamage = 1;
            BasicDistanceDamage = 0;
            BasicMagicalDamage = 0;
            MinimumPhysicalDamage = BasicPhysicalDamage;
            MaximumPhysicalDamage = BasicPhysicalDamage;
            PhysicalArmor = 0;
            MagicArmor = 0;
            FreeAttributePoints = 5;
            HitAccuracy = Dexterity;
            Evasion = Agility;
            MeleeWeaponMasteryLevel = 0;
            DistanceWeaponMasteryLevel = 0;
            MagicLevel = 0;
            CurrentExperience = 0;
            LevelUpExperience = 500;
            GoldBalance = 0;
            Inventory characterInventory = new Inventory();

            //characterInventory.InventoryList.Add(new LootsList() { Item = "cave rat tail", Count = 3 });
            //characterInventory.InventoryList.Add(new LootsList() { Item = "cave rat teeth", Count = 2 });
            //characterInventory.InventoryList.Add(new LootsList() { Item = "cave rat meat", Count = 1 });

            CharacterInventory = characterInventory;
        }


        public void ShowCharacterStatistics()
        {
            //int wyleczeniPacjenci =  IloscDostepnychLekarzy / 2;

            //if (wyleczeniPacjenci > IloscPacjentow)
            //    wyleczeniPacjenci = IloscPacjentow;

            Console.WriteLine("[Basic stats]");
            Console.WriteLine($"{Name} level: {Level} ");
            Console.WriteLine($"HP: {HitPoints}/{MaxHitPoints} ");
            Console.WriteLine($"MP: {ManaPoints}/{MaxManaPoints} ");
            Console.WriteLine($"EXP: {CurrentExperience}/{LevelUpExperience} [{LevelUpExperience - CurrentExperience} to next level]");
            Console.WriteLine($"Gold: {GoldBalance} ");

            Console.WriteLine(" ");
            Console.WriteLine("[Attributes]");
            Console.WriteLine($"Strength: {Strength} ");
            Console.WriteLine($"Inteligence: {Inteligence} ");
            Console.WriteLine($"Dexterity: {Dexterity} ");
            Console.WriteLine($"Agility: {Agility} ");
            Console.WriteLine($"Stamina: {Stamina} ");

            Console.WriteLine(" ");
            Console.WriteLine("[Secondary Offensive stats]");
            Console.WriteLine($"Physical Damage: {MinimumPhysicalDamage}-{MaximumPhysicalDamage} ");
            Console.WriteLine($"Distance Damage: {BasicDistanceDamage} ");
            Console.WriteLine($"Magical Damage: {BasicMagicalDamage} ");
            Console.WriteLine($"Hit Accuracy: {HitAccuracy} ");
            Console.WriteLine($"Melee Weapon Mastery Level: {MeleeWeaponMasteryLevel} ");
            Console.WriteLine($"Distance Weapon Mastery Level: {DistanceWeaponMasteryLevel} ");
            Console.WriteLine($"Magic Level: {MagicLevel} ");

            Console.WriteLine(" ");
            Console.WriteLine("[Secondary Defensive stats]");
            Console.WriteLine($"Physical Armor: {PhysicalArmor} ");
            Console.WriteLine($"Magic Armor: {MagicArmor} ");
            Console.WriteLine($"Evasion: {Evasion} ");

            Console.WriteLine(" ");
        }

        public void AddAttribute(string attribute, int value)
        {
            if (value < 0)
            {
                value = 0;
                Console.WriteLine("Negative values are treated as 0!");
            }

            if (value > FreeAttributePoints)
            {
                Console.WriteLine($"Not enough Attribute Points.");
                return;
            }
            //int wyleczeniPacjenci =  IloscDostepnychLekarzy / 2;

            //if (wyleczeniPacjenci > IloscPacjentow)
            //    wyleczeniPacjenci = IloscPacjentow;

            if (attribute == "Strength")
            {
                Strength += value;
                FreeAttributePoints -= value;
                Console.WriteLine($"Strength incresed by {value} to {Strength}.");
                BasicPhysicalDamage = 1 + (Strength - 10) / 3;
                MinimumPhysicalDamage = BasicPhysicalDamage;
                MaximumPhysicalDamage = 1 + (Strength - 10) / 2;
                return;
            }
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

        public void Heal(int value)
        {
            if (value < -1)
            {
                value = 0;
                Console.WriteLine("Negative values are treated as 0!");
            }

            HitPoints += value;
            if (HitPoints > MaxHitPoints)
            {
                HitPoints = MaxHitPoints;
            }
            if (value == -1)
            {
                HitPoints = MaxHitPoints;
            }
        }

        public void ManaPointsRestoration(int value)
        {
            if (value < -1)
            {
                value = 0;
                Console.WriteLine("Negative values are treated as 0!");
            }

            ManaPoints += value;
            if (ManaPoints > MaxManaPoints)
            {
                ManaPoints = MaxManaPoints;
            }
            if (value == -1)
            {
                ManaPoints = MaxManaPoints;
            }
        }

        public void GetExpierience(int value)
        {
            if (value < 0)
            {
                value = 0;
                Console.WriteLine("Negative values are treated as 0!");
            }

            CurrentExperience += value;


            while (CurrentExperience >= LevelUpExperience)
            {
                CurrentExperience -= LevelUpExperience;
                Level++;
                LevelUpExperience = Level * 500;
                Console.WriteLine($"Congratulations! You adcanced to level {Level}. You gained 3 attributes points to spend.");
                FreeAttributePoints += 3;
            }

        }


        public bool SubtractGold(int value)
        {
            if (value < 0)
            {
                value = 0;
                Console.WriteLine("Negative values are treated as 0!");
            }

            if (GoldBalance < value)
            {
                Console.WriteLine("You don`t have enough gold!");
                return false;
            }


            GoldBalance -= value;
            return true;
        }

        public void AddGold(int value)
        {
            if(value<0)
            {
                value = 0;
                Console.WriteLine("Negative values are treated as 0!");
            }
            else
            {
                GoldBalance += value;
            }          
        }

        public void AddInventory(List<LootsList> inventoryToInsert)
        {
            CharacterInventory.InventoryList = CharacterInventory.AddInventory(CharacterInventory.InventoryList, inventoryToInsert);
        }



    }
}
