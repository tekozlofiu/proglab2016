using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proglab20161108
{
    /*
     * Készítsen Kör osztályt, amely egy kört a középpontja koordinátáival és a sugárral reprezentál!
     * Az osztályban legyen metódus, ami megállapítja, hogy egy adott pont benne van-e a körben vagy sem.
     */
    class Kör
    {
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
}
