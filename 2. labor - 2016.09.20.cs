using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog20160920
{
    class Program
    {
        static void feladat01()
        {
            /*
             * Ha a hallgató neve Béla, akkor írjuk ki neki, hogy „SZIA”. Egyébként, írjuk ki, hogy „HELLO”!
             */

            Console.WriteLine("Mi a neved?");
            string name = Console.ReadLine();

            if (name.ToUpper() == "BÉLA")
                Console.WriteLine("Szia {0}!", name);
            else
                Console.WriteLine("HELLO");

            Console.ReadLine();
        }

        static void feladat02()
        {
            /*
             * A hallgató nevét addig kérjük be, amíg be nem ír valamit!
             * Ne fogadjuk el névnek, hogy „Shakespeare”!
             */

            string answer = "";

            do
            {
                answer = Console.ReadLine();
            } while (answer == "" || answer == "Shakespeare");

            Console.ReadLine();
        }

        static void feladat03()
        {
            /*
             * Írjunk külön-külön köszönést a következő nevekre:
             * Béla – Szia!
             * Bill – A király!
             * Joe – Szevasz!
             * Maldini – Ciao!
             * Mindenki más – Hello!
             */

            Console.WriteLine("Mi a neved?");
            string name = Console.ReadLine();
            string welcome;

            switch (name)
            {
                case "Béla":
                    welcome = "Szia";
                    break;
                case "Bill":
                    welcome = "A király";
                    break;
                case "Joe":
                    welcome = "Szevasz";
                    break;
                case "Maldini":
                    welcome = "Ciao";
                    break;
                default:
                    welcome = "Hello";
                    break;
            }

            Console.WriteLine(welcome + " " + name + "!");
            Console.ReadLine();

        }

        static int randomgenerator()
        {
            Random r = new Random();
            return r.Next(0, 101);
        }

        static void feladat04()
        {
            /* 
             * Írjon programot, amelynek kezdetén adott egy pozitív egész szám, a „gondolt szám”.
             * A felhasználónak ki kell találnia, hogy mi a gondolt szám.
             * Ehhez a felhasználó megadhat számokat, melyekről a program megmondja, hogy a gondolt számnál nagyobbak, vagy kisebbek-e.
             * A program akkor ér véget, ha a felhasználó kitalálta a gondolt számot.
             * A program jelenítse meg a felhasználó próbálkozásainak számát is.
             */

            int number = randomgenerator();
            string tipp;

            Console.WriteLine("Milyen számra gondoltam? (0-100)");

            do
            {

                tipp = Console.ReadLine();
                Console.Clear();

                if (int.Parse(tipp) < number)
                    Console.WriteLine("A {0} túl kicsi, mondj nagyobbat!", tipp);
                else if (int.Parse(tipp) > number)
                    Console.WriteLine("A {0} túl nagy, mondj kisebbet!", tipp);
                else
                    Console.WriteLine("Így van! A {0} volt, amire gondoltam!", number);
            }
            while (int.Parse(tipp) != number);

            Console.ReadLine();
        }

        static void feladat05()
        {
            /* 
             * Készítsünk programot, mely beolvas a billentyűzetről két számot és egy műveleti jelet, 
             * majd kiírja a két számmal elvégzett művelet eredményét. 
             * Aműveleti jelek megkülönböztetéséhez használjunk többágú (switch, case) elágaztatást.
             */

            int numberA, numberB, result;
            char muvelet;

            Console.WriteLine("Adj meg egy egész számot!");
            numberA = int.Parse(Console.ReadLine());
            Console.WriteLine("Adj meg még egy egész számot!");
            numberB = int.Parse(Console.ReadLine());
            Console.WriteLine("Adj meg egy műveleti jelet!");
            muvelet = char.Parse(Console.ReadLine());

            Console.Clear();

            switch (muvelet)
            {
                case '+':
                    result = numberA + numberB;
                    Console.WriteLine("A ({0} {1} {2}) kifejezés eredménye {3}.", numberA, muvelet, numberB, result);
                    break;
                case '-':
                    result = numberA - numberB;
                    Console.WriteLine("A ({0} {1} {2}) kifejezés eredménye {3}.", numberA, muvelet, numberB, result);
                    break;
                case '/':
                    if (numberB == 0)
                        Console.WriteLine("Nullával nem lehet osztani");
                    else
                    {
                        result = numberA / numberB;
                        Console.WriteLine("A ({0} {1} {2}) kifejezés eredménye {3}.", numberA, muvelet, numberB, result);
                    }
                    break;
                case '*':
                    result = numberA * numberB;
                    Console.WriteLine("A ({0} {1} {2}) kifejezés eredménye {3}.", numberA, muvelet, numberB, result);
                    break;
                case '%':
                    result = numberA % numberB;
                    Console.WriteLine("A ({0} {1} {2}) kifejezés eredménye {3}.", numberA, muvelet, numberB, result);
                    break;
                default:
                    Console.WriteLine("Nincs ilyen művelet!");
                    break;
            }

            Console.ReadLine();
        }

        static void feladat06()
        {
            /* 
             * Írjon programot, amely egy pozitív egész számnak kiszámítja
             * valamely pozitív egész kitevőjű hatványát, illetve a faktoriálisát!
             * Az aktuális értékeket a felhasználó adhatja meg.
            */

            int number, power, result, i = 1;

            Console.WriteLine("Adj meg egy számot!");
            number = int.Parse(Console.ReadLine());
            Console.WriteLine("Add meg a hatványkitevőt!");
            power = int.Parse(Console.ReadLine());
            Console.Clear();

            result = number;

            while (i < power)
            {
                result = result * number;
                i = i + 1;
            }

            Console.WriteLine("{0} szám {1}. hatványa {2}", number, power, result);

            result = number;
            i = number;

            while (i > 1)
            {
                i = i - 1;
                result = result * i;
            }

            Console.WriteLine("{0} szám faktoriálisa pedig {1}.", number, result);

            Console.ReadLine();
        }

        static void feladat07()
        {
            /* 
             * Készítsen programot, amely két bekért pozitív egész számnak
             * meghatározza a legnagyobb közös osztóját és a legkisebb közös többszörösét!
             */

            int numberA, numberB, r;

            Console.WriteLine("Adj meg egy számot!");
            numberA = int.Parse(Console.ReadLine());
            Console.WriteLine("Adj meg még egy számot");
            numberB = int.Parse(Console.ReadLine());
            Console.Clear();

            r = numberA;
            while (r != 0)
            {
                numberA = numberB;
                numberB = r;
                r = numberA % numberB;
            }
            Console.WriteLine("LNKO: " + numberB);
            Console.ReadLine();


        }

        static void feladat08()
        {
            /* Írjon programot, amely a Fibonacci sorozatnak meghatározza valamely elemét! */

        }

        static void feladat09()
        {
            /* 
             * Készítsen programot, mely egy pozitív egész számnak kiírja az összes osztóját! 
             */

            int A, B = 1;

            Console.WriteLine("Adj meg egy számot!");
            A = int.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine(A + " osztói");
            while (B < A)
            {
                if (A % B == 0)
                    Console.WriteLine(B);
                B++;
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            feladat01();
            feladat02();
            feladat03();
            feladat04();
            feladat05();
            feladat06();
            feladat07();
            feladat08();
            feladat09();
        }
    }
}
