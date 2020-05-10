using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame
{
    class Wyprawa
    {
        private Szpital mojSzpital;

        public Wyprawa(Szpital szpital)
        {
            mojSzpital = szpital;
        }

        public void WyruszNaWyprawe(string poziomTrudnosci)
        {
            if (mojSzpital.IloscDostepnychLekarzy > 0 && mojSzpital.PobierzZBudzetu(50))
            {
                int modyfikatorTrudnosci = 0;

                if (poziomTrudnosci == "latwy")
                {
                    modyfikatorTrudnosci = 0;
                }
                else if (poziomTrudnosci == "normalny")
                {
                    modyfikatorTrudnosci = 3;
                }
                else if (poziomTrudnosci == "trudny")
                {
                    modyfikatorTrudnosci = 6;
                }

                int nowiPacjenci;
                Random losowanie = new Random();
                nowiPacjenci = losowanie.Next(5, 14 + modyfikatorTrudnosci);

                Random losowanieStraty = new Random();

                if (losowanie.Next(1, 11) > (10 - modyfikatorTrudnosci))
                {
                    mojSzpital.IloscDostepnychLekarzy -= 1;
                    Console.WriteLine($"Wyprawa udana. Niestety jeden lekarz poświęcił się dla uratowania przed straszliwym wirusem ({nowiPacjenci}) nowych pacjentów.");
                }
                else
                {
                    Console.WriteLine($"Wyprawa udana. Lekarzowi udało się powrócić i uratować przed straszliwym wirusem ({nowiPacjenci}) nowych pacjentów.");
                }



                mojSzpital.IloscPacjentow += nowiPacjenci;
                if (mojSzpital.IloscPacjentow > mojSzpital.IloscLozek)
                {
                    mojSzpital.IloscPacjentow = mojSzpital.IloscLozek;
                    Console.WriteLine("Liczba znalezionych pacjentów przekroczyła liczbę dostępnych łóżek. Nie wszyscy mogli zostać zabrani do szpitala.");
                }




            }
            else if (mojSzpital.IloscDostepnychLekarzy == 0)
            {
                Console.WriteLine("Dopadła Cię choroba Polskiego NFZ - wszyscy lekarze są na Zachodzie");
            }
            else
            {
                Console.WriteLine("Zgłoś się do NFZ po fundusze, bo ten wyjazd nie będzie refundowany");
            }
        }
    }
}
