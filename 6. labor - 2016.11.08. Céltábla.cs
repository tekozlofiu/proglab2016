using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proglab20161108
{
    class Program
    {
        static void Main(string[] args)
        {
            int sugár = 10;
            int lövésekSzáma = 10;
            int pontszám = 0;
            int u, v;

            Céltábla játék = new Céltábla(sugár);
            for (int i = 0; i < lövésekSzáma; i++)
            {
                Console.WriteLine("Adj meg két koordinátát!");
                u = int.Parse(Console.ReadLine());
                v = int.Parse(Console.ReadLine());

                Console.Clear();

                if (játék.CéltáblánVanE(u, v))
                    Console.WriteLine("Találat!");
                else
                    Console.WriteLine("Mellé!");

                Console.WriteLine("{0} távolságra dobtál a középponttól", (int)játék.KözépponttólVettTávolság(u, v));

                pontszám += játék.DobásÉrtéke(u, v);
            }
            Console.Clear();
            Console.WriteLine("Vége a játéknak. {0} pontot értél el. A helyes koordináták [{1};{2}]", pontszám, játék.X, játék.Y);

            Console.ReadLine();
        }
    }
    
    class Kör
    {
        /*
         * Készítsen Kör osztályt, amely egy kört a középpontja koordinátáival és a sugárral reprezentál!
         * Az osztályban legyen metódus, ami megállapítja, hogy egy adott pont benne van-e a körben vagy sem.
         */
        private double x, y, r;

        public Kör(double x, double y, double r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }

        public bool KörbenVanE(double u, double v)
        {
            return Math.Pow((x - u), 2) + Math.Pow((y - v), 2) < Math.Pow(r, 2);
        }

        /* 
         * Készítsen a Körhöz egy új konstruktort, amely megadott sugárral, de véletlenszerű középponttal hozza létre a példányt. 
         */

        public static Random rng = new Random();

        public Kör(double r) : this(rng.Next(-100, 101), rng.Next(-100, 101), r) { }

        /*
         * Egészítse ki a Kör osztályt úgy, hogy legyen metódusa, amely megállapítja, hogy egy adott pont a kör középpontjától pontosan mekkora távolságra van.
         */

        public double KözépponttólVettTávolság(double u, double v)
        {
            return Math.Sqrt(Math.Pow((x - u), 2) + Math.Pow((y - v), 2));
        }
    }
    
    class Céltábla
    {
       /* 
        * Módosítsa a Kör osztályt Céltábla osztállyá úgy, hogy legyen benne metódus, 
        * amelyegy adott pontnak a középponttól való távolsága szerint különböző pontszámokat ad!
        * 
        * Ezután készítsen céllövő játékot: hozzon létre egy véletlenszerű középpontú céltáblát, 
        * majd kérjen be a felhasználótól 15 lövést (pontot), 
        * számolja, hány pontnyi találata van a felhasználónak a 15 lövés után.
        * Minden lövés után segítségül közölje, mekkora volt a lövés távolsága a céltáblától.
        */

        public static Random rng = new Random();
        private double x, y, r;

        public double X { get { return x; } }
        public double Y { get { return y; } }

        public Céltábla(double x, double y, double r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }

        public Céltábla(double r) : this(rng.Next(0, 50), rng.Next(0, 50), r) { }

        public bool CéltáblánVanE(double u, double v)
        {
            return Math.Pow((x - u), 2) + Math.Pow((y - v), 2) < Math.Pow(r, 2);
        }

        public double KözépponttólVettTávolság(double u, double v)
        {
            return Math.Sqrt(Math.Pow((x - u), 2) + Math.Pow((y - v), 2));
        }

        public int DobásÉrtéke(double u, double v)
        {
            return CéltáblánVanE(u, v) ? (int)KözépponttólVettTávolság(u, v) * 2 : 0;
        }
    }
}
