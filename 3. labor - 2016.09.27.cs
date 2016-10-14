using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proglab20160927
{
    class Program
    {

        static void feladat()
        {
            /*
             * Készítsünk másodfokú egyenletet megoldó programot!
             * 
             */

            Console.WriteLine("A?");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("B?");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("C?");
            int c = int.Parse(Console.ReadLine());

            Console.Clear();

            double diszkriminans = Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);
            double eredmeny1, eredmeny2;

            eredmeny1 = (-b + diszkriminans) / (2 * a);
            eredmeny2 = (-b - diszkriminans) / (2 * a);

            if (diszkriminans > 0 && a != 0)
                Console.WriteLine("Az eredmény: {0} és {1}", eredmeny1, eredmeny2);
            else
                Console.WriteLine("Nincs megoldás");

            Console.ReadLine();
        }

        static int[] CreateArray()
        {
            /* 
             * Az A tömb adott számú egész számot tartalmaz.
             * A tömb elemei 0 és 100 között véletlen számok.
             * A tömb feltöltése érdekében készítsen önálló metódust!
             */

            Console.WriteLine("Mekkora legyen a tömb mérete?");
            int[] array = new int[int.Parse(Console.ReadLine())];
            Console.Clear();

            Random RNG = new Random();

            for (int i = 0; i < array.Length; i++)
                array[i] = RNG.Next(0, 101);

            return array;
        }

        static bool ModXY(int a, int b)
        {
            return a % b == 0;
        }

        static void ListArray(int[] array)
        {
            /*
             * Készítsen metódust, mely kilistázza tömb elemeit!
             */

            foreach (int i in array)
                Console.WriteLine(i);

            Console.ReadLine();
        }

        static int feladat1(int[] array)
        {
            /*
             * 1. Határozza meg a tömb elemeinek összegét!
             * (sorozatszámítás tétel)
             */

            int result = 0;

            foreach (int i in array)
                result += i;

            return result;
        }

        static bool feladat2(int[] array)
        {
            /* 
             * 2. Szerepel-e a tömbben öttel osztható szám?
             * (eldöntés tétel)
             */

            bool result = false;

            foreach (int item in array)
                if (ModXY(item, 5))
                    result = true;

            return result;
        }

        static int feladat3(int[] array)
        {
            /*
             * 3. Ha tudjuk, hogy szerepel a tömbben öttel osztható szám, akkor mi az indexe?
             * (kiválasztás tétel)
             */

            bool result = false;
            int i = 0;

            do
            {
                if (ModXY(array[i], 5))
                    result = true;
                else
                    i++;
            } while (i < array.Length && result == false);

            return i;
        }

        static int feladat5(int[] array)
        {
            /*
             * 5. Hány darab öttel osztható szám van a tömbben?
             * (megszámlálás tétel)
             */

            int result = 0;

            foreach (int item in array)
                if (ModXY(item, 5))
                    result++;

            return result;
        }

        static int feladat6(int[] array)
        {
            /*
             * 6. Határozza meg a tömb legkisebb értékének indexét!
             * (maximumkiválasztás tétel)
             */

            int index = 0;

            for (int i = 1; i < array.Length; i++)
                if (array[i] < array[index])
                    index = i;

            return index;
        }

        static void Main(string[] args)
        {
            int[] array = CreateArray();
            ListArray(array);

            Console.WriteLine("A tömb elemeinek összege {0}", feladat1(array));
            Console.ReadLine();

            Console.WriteLine("Szerepel-e a tömbben öttel osztható szám? ({0})", feladat2(array));
            Console.ReadLine();

            if (feladat2(array) == true)
            {
                Console.WriteLine("Az első öttel osztható szám indexe {0}", feladat3(array));
                Console.ReadLine();
            }

            Console.WriteLine("A tömmben {0} darab öttel osztható szám van", feladat5(array));
            Console.ReadLine();

            Console.WriteLine("A tömmb legkisebb elemének indexe {0}", feladat6(array));
            Console.ReadLine();

        }
    }
}
