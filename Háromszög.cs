using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proglab20161108
{
    /* 
     * Készítsünk Háromszög osztályt, amely egy háromszöghöz tárolja a három oldal hosszúságát! Legyen képes kerület, terület számítására.
     */

    class Háromszög
    {
        private double a, b, c;
        
        // Konstruktor
        public Háromszög(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        
        // Kerület
        public double Kerület()
        {
            return a + b + c;
        }

        // Területszámítás Hérón-képlettel
        public double Terület()
        {
            double s = Kerület() / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        /*
         * Egészítse ki a Háromszög osztályt egy olyan konstruktorral, 
         * amely véletlenszerű (0-100 közötti) oldalhosszúsággal rendelkező háromszöget generál. 
         * A keletkező háromszögnek szerkeszthetőnek kell lennie! 
         */

        private static Random rng = new Random();

        // Konstruktor
        public Háromszög()
        {
            do
            {
                a = rng.Next(0, 101);
                b = rng.Next(0, 101);
                c = rng.Next(0, 101);
            }
            while (!Szerkeszthető());
        }

        // Szerkeszthető, ha bármely oldal kisebb a másik két oldal összegénél
        private bool Szerkeszthető()
        {
            return (a < b + c) && (b < a + c) && (c < b + a);
        }

        /*
         * Egészítse ki a Háromszög osztályt úgy, hogy módosíthatóak legyenek az oldalhosszak, 
         * de csak úgy, hogy a háromszög szerkeszthető maradjon!
         * (Rossz oldalhossz megadása esetén maradjon meg az eredeti hossz.)
         */

        public double A
        {
            get { return a; }
            set
            {
                // Eltároljuk az eredeti értéket.
                double regi = a;

                // Értékül adjuk az újat.
                a = value;

                // Ha az így képzett háromszög nem lenne szerkeszthető, visszatöltjük az eredeti értéket
                if (!Szerkeszthető())
                    a = regi;
            }
        }

        public double B
        {
            get { return b; }
            set
            {
                double regi = b;
                b = value;
                if (!Szerkeszthető())
                    b = regi;
            }
        }

        public double C
        {
            get { return c; }
            set
            {
                double regi = c;
                c = value;
                if (!Szerkeszthető())
                    c = regi;
            }
        }
    }
}
