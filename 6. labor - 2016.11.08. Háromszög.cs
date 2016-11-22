using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proglab20161108_haromszog
{
    class Program
    {
        static void Main(string[] args)
        {
            // Háromszög készítése megadott oldalakkal
            Háromszög h1 = new Háromszög(3, 4, 5);
            h1.Kiírat();

            // Egészítse ki a Háromszög osztályt egy olyan konstruktorral amely véletlenszerű (0-100 közötti) oldalhosszúsággal rendelkező háromszöget generál. 
            Háromszög h2 = new Háromszög();
            h2.Kiírat();
            
            Console.ReadLine();
        }
    }
    
    class Háromszög
    {
        /* 
         * Készítsünk Háromszög osztályt, amely egy háromszöghöz tárolja a három oldal hosszúságát! Legyen képes kerület, terület számítására.
         */

        double a, b, c;

        // Konstruktor I.
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

        public void Kiírat()
        {
            Console.WriteLine("A háromszög kerülete: {0}", Kerület());
            Console.WriteLine("A háromszög területe: {0}", Terület());
            Console.WriteLine("A háromszög oldalai:  {0}, {1} és {2}.", A, B, C);
            Console.WriteLine();
        }

        /*
         * Egészítse ki a Háromszög osztályt egy olyan konstruktorral, 
         * amely véletlenszerű (0-100 közötti) oldalhosszúsággal rendelkező háromszöget generál. 
         * A keletkező háromszögnek szerkeszthetőnek kell lennie! 
         */

        static Random rng = new Random();

        // Konstruktor II.
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
        bool Szerkeszthető()
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
