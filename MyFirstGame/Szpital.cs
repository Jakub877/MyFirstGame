using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame
{
    class Szpital
    {
        public string Nazwa { get; }
        public int Budzet { get; private set; }
        public int IloscDostepnychLekarzy { get; set; }
        public int IloscPacjentow { get; set; }
        public int PoziomSzpitala { get; set; }
        public int IloscLozek { get; set; }
        public int MaxIloscLekarzy { get; set; }

        public Szpital(string nazwa)
        {
            Nazwa = nazwa;
            Budzet = 100; //100
            IloscDostepnychLekarzy = 3; //3
            MaxIloscLekarzy = 10;
            IloscPacjentow = 0;
            IloscLozek = 30;
            PoziomSzpitala = 1;
        }

        public void PokazParametrySzpitala()
        {
            //int wyleczeniPacjenci =  IloscDostepnychLekarzy / 2;

            //if (wyleczeniPacjenci > IloscPacjentow)
            //    wyleczeniPacjenci = IloscPacjentow;

            Console.WriteLine(Nazwa + "   poziom: " + PoziomSzpitala);
            Console.WriteLine("Budżet " + Budzet + " bananowych złotych");
            Console.WriteLine("Lekarze: " + IloscDostepnychLekarzy + "/" + MaxIloscLekarzy);
            Console.WriteLine("Pacjenci: " + IloscPacjentow + "/" + IloscLozek);
            Console.WriteLine("Planowany przychód do budżetu następnego dnia to (" + Przychod() + ") bananowych złotych.");

        }

        public int Przychod()
        {
            int wyleczeniPacjenci = IloscDostepnychLekarzy / 2;

            if (wyleczeniPacjenci > IloscPacjentow)
                wyleczeniPacjenci = IloscPacjentow;
            return wyleczeniPacjenci * (9 + PoziomSzpitala);
        }

        public void UlepszSzpital()
        {
            if (Budzet < (50 * (Math.Pow(PoziomSzpitala + 1, 2))))
            {
                Console.WriteLine($"Dostępny budżet to ({Budzet}) bananowych złotych. Liczba potrzebnych bananowych złotych do ulepszenia to ({50 * (Math.Pow(PoziomSzpitala + 1, 2))}).");
                return;
            }
            IloscLozek += 10;
            MaxIloscLekarzy += 5;
            Budzet -= 50 * (PoziomSzpitala ^ 2);
            PoziomSzpitala++;
            Console.WriteLine($"Szpital pomyślnie ulepszono na poziom {PoziomSzpitala}.");
        }

        public void PokazPodstawoweParametrySzpitala()
        {
            Console.WriteLine("[" + Nazwa + "] [poziom: " + PoziomSzpitala + "] [Dzień " + Program.Globals.dzien + "] [Budżet: " + Budzet + " bananowych złotych" + "] [Lekarze: " + IloscDostepnychLekarzy + "/" + MaxIloscLekarzy + "] [Pacjenci: " + IloscPacjentow + "/" + IloscLozek + "]");
        }

        public void ZatrudnijLekarzy()
        {
            if (IloscDostepnychLekarzy == MaxIloscLekarzy)
            {
                Console.WriteLine($"Nie możesz zatrudnić więcej Lekarzy. Posiadani Lekarze: {IloscDostepnychLekarzy} / {MaxIloscLekarzy}.");
                return;
            }

            if (Budzet < 30)
            {
                Console.WriteLine("Dostępny budżet to (" + Budzet + ") bananowych złotych . Liczba potrzebnych bananowych złotych do zatrudnienia Lekarza to (30).");
                return;
            }

            else
            {
                Budzet -= 30;
                IloscDostepnychLekarzy += 1;
                Console.WriteLine("Lekarz został zatrudniony. Aktualna liczba Lekarzy to (" + IloscDostepnychLekarzy + ").");
                Console.WriteLine("Aktualny budżet to (" + Budzet + ") bananowych złotych.");
            }

        }


        //public void WyruszNaWyprawe()
        //{   
        //    // do ewentualnego wykorzystania później  throw new System.ArgumentException("Wartość pola nie może być nullem", "original");

        //    //zabezpieczenie się przed niewystarczającym budżetem lub lekarzami
        //    if (IloscDostepnychLekarzy == 0 || Budzet < 50)
        //    {
        //        if(IloscDostepnychLekarzy == 0)
        //        {
        //            Console.WriteLine("Liczba dostępnych Lekarzy to (0). Liczba potrzebnych Lekarzy do wyruszenia na wyprawę to (1).");
        //        }

        //        if (Budzet < 50)
        //        {
        //            Console.WriteLine("Dostępny budżet to (" + Budzet + ") bananowych złotych . Liczba potrzebnych bananowych złotych do wyruszenia na wyprawę to (50).");
        //        }

        //        return;

        //    }


        //    //zdobywamy kilku pacjentów
        //    Random zmiennaLosowa = new Random();
        //    int iloscZdobytychPacjentow;
        //    iloscZdobytychPacjentow = zmiennaLosowa.Next(5, 15);

        //    if (IloscLozek >= IloscPacjentow + iloscZdobytychPacjentow)
        //        IloscPacjentow += iloscZdobytychPacjentow;
        //    else
        //    {
        //        Console.WriteLine("Liczba zdobytych pacjentów przekroczyła liczbę dostępnych łóżek. Nie wszyscy mogli zostać zabrani do szpitala");
        //        IloscPacjentow = IloscLozek;

        //    }


        //    //tracimy jednego lekarza


        //    IloscDostepnychLekarzy -= 1;

        //    //koszt wyprawy = 50bzł

        //    Budzet -= 50;

        //    Console.WriteLine("Wyprawa powiodła się. Liczba znalezionych pacjentów to (" + iloscZdobytychPacjentow + "), a łączna liczba pacjentów to (" + IloscPacjentow + ").");
        //    Console.WriteLine("Budżet " + Budzet + " bananowych złotych");
        //    Console.WriteLine("Lekarze: " + IloscDostepnychLekarzy + "/" + MaxIloscLekarzy);

        //}


        public void WyleczPacjentow()
        {
            int wyleczeniPacjenci = (IloscDostepnychLekarzy / 2) + 1;

            if (wyleczeniPacjenci > IloscPacjentow)
                wyleczeniPacjenci = IloscPacjentow;

            IloscPacjentow -= wyleczeniPacjenci;
            Budzet += wyleczeniPacjenci * 10;
        }

        public bool PobierzZBudzetu(int kwota)
        {
            if (Budzet < kwota) return false;

            Budzet -= kwota;
            return true;
        }

        public void WplywDoBudzetu(int kwota)
        {
            Budzet += kwota;
        }
    }
}
