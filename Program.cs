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
        {/*
            Háromszög h1 = new Háromszög(3, 4, 5);
            Console.WriteLine("A háromszög kerülete: {0}", h1.Kerület());
            Console.WriteLine("A háromszög területe: {0}", h1.Terület());

            Háromszög h2 = new Háromszög();
            Console.WriteLine("A háromszög kerülete: {0}", h2.Kerület());
            Console.WriteLine("A háromszög területe: {0}", h2.Terület());

            Console.WriteLine("A háromszög oldalai {0}, {1} és {2}", h1.A, h1.B, h1.C); // getter
            h1.A = 6; // setter
            Console.WriteLine("A háromszög oldalai {0}, {1} és {2}", h1.A, h1.B, h1.C); // getter

            Console.WriteLine(h1.Kerület());
            Console.WriteLine(h1.Terület());

            Console.WriteLine("Add meg a kör középpontjának két koordinátáját és a kör sugarát!");
            Kör k1 = new Kör(
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine())
            );
            Console.WriteLine("Add meg egy pont két koordinátáját!");
            Console.WriteLine(k1.KözépponttólVettTávolság(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));
            */
            int sugár = 10;
            int lövésekSzáma = 15;
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
}
