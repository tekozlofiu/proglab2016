using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proglab20161108
{

    /* 
     * Módosítsa a Kör osztályt Céltábla osztállyá úgy, hogy legyen benne metódus, 
     * amelyegy adott pontnak a középponttól való távolsága szerint különböző pontszámokat ad!
     * 
     * Ezután készítsen céllövő játékot: hozzon létre egy véletlenszerű középpontú céltáblát, 
     * majd kérjen be a felhasználótól 15 lövést (pontot), 
     * számolja, hány pontnyi találata van a felhasználónak a 15 lövés után.
     * Minden lövés után segítségül közölje, mekkora volt a lövés távolsága a céltáblától.     */

    class Céltábla
    {
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

        public Céltábla(double r) : this(rng.Next(0, 101), rng.Next(0, 101), r) { }
        
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
