using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
    // Minta ZH sor a Programozás I. tárgy első nagy zh-jához
    // (nem szeretem a magyarValtozoNeveket, de ha már a feladatot így adták meg, maradok ennél)

    class Program
    {
        // Randomgenerátor
        static Random rng = new Random();
        
        static int[,] TombVeletlenGeneral(int hetekSzama)
        {
            // A hétköznapi edzéseken 3 és 10 kilométer közötti távokat teljesít.
            // A hétvégi edzéseken 8 és 30 kilométer közötti távokat fut.
            int hetkoznapMin = 3;
            int hetkoznapMax = 10;
            int hetvegeMin = 8;
            int hetvegeMax = 30;
            int napokSzama = 7;
            
            // Minden héten legyen két olyan nap, amikor nem edz a futó.
            int egyikNapIndexe;
            int masikNapIndexe;
            
            // Előállít egy megfelelő méretű kétdimenziós tömböt
            int[,] tomb = new int[hetekSzama, napokSzama];

            // Feltöltjük véletlen adatokkal
            for (int i = 0; i < tomb.GetLength(0); i++)
            {
                for (int j = 2; j < tomb.GetLength(1); j++)
                    tomb[i, j] = (j < 5) ? rng.Next(hetkoznapMin, hetkoznapMax + 1) : rng.Next(hetvegeMin, hetvegeMax + 1);

                // Minden héten legyen két olyan nap, amikor nem edz a futó.
                egyikNapIndexe = rng.Next(hetkoznapMin, hetkoznapMax + 1);
                do
                    masikNapIndexe = rng.Next(hetkoznapMin, hetkoznapMax + 1);
                while(egyikNapIndexe == masikNapIndexe)

                tomb[i, egyikNapIndexe] = 0;
                tomb[i, masikNapIndexe] = 0;
            }

            return tomb;
        }

        static string TombKiir(int[,] lefutottTavok)
        {
            // A bemeneti tömb adataiból készített stringet ad vissza
            string egyesHetekFutasiAdatai = "";

            // Az egyes hetek futási adatai egymástól vesszővel vannak elválasztva, a hetek között pedig sörtörés van.
            for (int i = 0; i < lefutottTavok.GetLength(0); i++)
                for (int j = 0; j < lefutottTavok.GetLength(1); j++)
                    egyesHetekFutasiAdatai += (j < 6) ? lefutottTavok[i, j].ToString() + "," : lefutottTavok[i, j].ToString() + "\n";

            return egyesHetekFutasiAdatai;
        }

        static void TombModosit(int hetIndex, int napIndex, int[,] lefutottTavok)
        {
            // Az adott heti és adott napi edzés távját lehet módosítani a metódus segítségével.
            Console.WriteLine("Mire módosítod a(z) {0}. hét {1}. napjának értékét: ", hetIndex + 1, napIndex + 1);
            lefutottTavok[hetIndex, napIndex] = int.Parse(Console.ReadLine());
        }

        static int OsszesKilometer(int[,] lefutottTavok)
        {
            // Megadja, hogy a futó összesen hány kilométert futott le.
            int osszesTav = 0;

            for (int i = 0; i < lefutottTavok.GetLength(0); i++)
                for (int j = 0; j < lefutottTavok.GetLength(1); j++)
                    osszesTav += lefutottTavok[i, j];

            return osszesTav;
        }

        static int HosszuFutasokSzama(int[,] lefutottTavok)
        {
            // Megadja, hogy a futó hány alkalommal edzett 15 kilométernél hosszabb távon.
            int futasokSzama = 0;

            for (int i = 0; i < lefutottTavok.GetLength(0); i++)
                for (int j = 0; j < lefutottTavok.GetLength(1); j++)
                    if (lefutottTavok[i, j] > 15)
                        futasokSzama++;

            return futasokSzama;
        }

        static int[] HetiOsszesites(int[,] lefutottTavok)
        {
            // Egy tömbben visszaadja az egyes hetek összesített kilométer adatait.
            int[] osszesitettKilometer = new int[lefutottTavok.GetLength(0)];

            for (int i = 0; i < lefutottTavok.GetLength(0); i++)
                for (int j = 0; j < lefutottTavok.GetLength(1); j++)
                    osszesitettKilometer[i] += lefutottTavok[i, j];

            return osszesitettKilometer;
        }

        static bool NovekszikE(int[] hetiTavok)
        {
            // Eldönti, hogy a hetente lefutott távok folyamatosan növekednek-e.
            for (int i = 1; i < hetiTavok.Length; i++)
                if (hetiTavok[i] > hetiTavok[i - 1])
                    return false;

            return true;
        }
        
        static int[] CsokkenobeRendezes(int[] hetiTavok)
        {
            // A bemeneti tömb elemeit csökkenő sorrendben adja vissza.

            //A bemeneti tömb közben nem változhat meg, ezért segédtömbbe másoljuk
            int[] segedtomb = new int[hetiTavok.Length];

            for (int i = 0; i < hetiTavok.Length; i++)
                segedtomb[i] = hetiTavok[i];

            int seged;

            for (int i = 0; i < hetiTavok.Length - 1; i++)
                for (int j = i + 1; j < hetiTavok.Length; j++)
                    if(hetiTavok[i] < hetiTavok[j])
                    {
                        seged = hetiTavok[i];
                        hetiTavok[i] = hetiTavok[j];
                        hetiTavok[j] = seged;
                    }

            return hetiTavok;
        }

        static void Main(string[] args)
        {
            // A Main() függvényböl tesztelje mindegyik elkészített metódus működését!

            int[,] lefutottTavok = TombVeletlenGeneral(5);
            Console.WriteLine(TombKiir(lefutottTavok));

            TombModosit(0, 0, lefutottTavok);
            Console.Clear();

            Console.WriteLine(TombKiir(lefutottTavok));

            int osszTav = OsszesKilometer(lefutottTavok);
            Console.WriteLine("Összesen megtett kilometer: {0}", osszTav);

            int futasokSzama = HosszuFutasokSzama(lefutottTavok);
            Console.WriteLine("Hosszú futások száma: {0}", futasokSzama);

            int[] hetiOsszesites = HetiOsszesites(lefutottTavok);
            Console.Write("Hetiösszesítés:   ");
            foreach (int adat in hetiOsszesites)
                Console.Write(adat + " ");
            Console.Write("\n");

            bool novekedes = NovekszikE(hetiOsszesites);
            Console.WriteLine("A heti távok növekedése: {0}", novekedes);

            CsokkenobeRendezes(hetiOsszesites);
            Console.Write("Csökkenőrendezés: ");
            foreach (int adat in hetiOsszesites)
                Console.Write(adat + " ");
            Console.Write("\n");

            Console.ReadKey();
        }
    }
}
