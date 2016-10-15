using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proglab20161004
{
    class Program
    {
        static Random RNG = new Random();

        static int[] arrayFill(int size)
        {
            /* 
             * Valósítsa meg a tömb véletlenszerű feltöltését!
             * 40% a valószínűsége, hogy egy mérési helyen szigetet találunk.
             * A sziget aktuális magassága 1 és 10 közötti véletlen szám
             */

            int[] array = new int[size];

            for (int i = 0; i < array.Length; i++)
                array[i] = (RNG.Next(1, 11) <= 4) ? RNG.Next(1, 11) : 0;

            return array;
        }

        static void display(int[] array)
        {
            /*
             * 2. Jelenítse meg a mérési eredményeket a képernyőn!
             */

            string output = "";

            for (int j = 10; j > 0; j--)
            {
                for (int i = 0; i < array.Length; i++)
                    output += (array[i] >= j) ? "[X]" : "   ";

                output += "\n";
            }

            Console.WriteLine(output);
        }

        static int Feladat3(int[] array)
        {
            /*
             * 3. Határozza meg, hogy hol található (először) a legmagasabb pont, és mennyi ennek a magassága!
             */

            int maxindex = 0;

            for (int i = 0; i < array.Length; i++)
                if (array[maxindex] < array[i])
                    maxindex = i;

            return maxindex;
        }

        static int Feladat4(int[] array, int height)
        {
            /*
             * 4. Adja meg, hogy a legmagasabb pont hányszor fordult elő a repülés során!
             */

            int coutner = 0;

            foreach (var item in array)
                if (item == height)
                    coutner++;

            return coutner;
        }

        static int Feladat5(int[] tomb)
        {
            /*
             * 5. Határozza meg a leghosszabb szigetszakasz hosszát!
             */

            int szigethossza = 0;
            int[] segedtomb = new int[tomb.Length];
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] == 0)
                    szigethossza = 0;
                else
                    szigethossza++;

                segedtomb[i] = szigethossza;
            }

            int max = 0;
            foreach (var item in segedtomb)
                if (item > max)
                    max = item;

            return max;
        }

        // Cserélgetős játék

        static void init(ref bool[,] game)
        {
            // A játéktábla kezdeti állapotát előállító metódus

            for (int i = 0; i < game.GetLength(0); i++)
                for (int j = 0; j < game.GetLength(1); j++)
                    game[i, j] = false;

            int x = game.GetLength(0) / 2;
            int y = game.GetLength(1) / 2;

            game[x, y] = true;
            game[x + 1, y] = true;
            game[x - 1, y] = true;
            game[x, y + 1] = true;
            game[x, y - 1] = true;
        }

        static string state(bool[,] game)
        {
            // A játéktábla aktuális állapotát string formában megadó metódus

            string state = "";

            for (int i = 0; i < game.GetLength(0); i++)
            {
                for (int j = 0; j < game.GetLength(1); j++)
                    state += (game[i, j]) ? "*" : "-";

                state += "\n";
            }

            return state;
        }

        static void shoot(bool[,] game, int x, int y)
        {
            // Kiválasztott pontra „lövést” megvalósító metódus

            if (x < game.GetLength(0) && x >= 0 && y < game.GetLength(1) && y >= 0)
                game[x, y] = !game[x, y];
            if (x > 0)
                game[x - 1, y] = !game[x - 1, y];
            if (y > 0)
                game[x, y - 1] = !game[x, y - 1];
            if (x < game.GetLength(0))
                game[x + 1, y] = !game[x + 1, y];
            if (y < game.GetLength(1))
                game[x, y + 1] = !game[x, y + 1];
        }

        static bool isOver(bool[,] game)
        {
            // A metódus vizsgálja, hogy minden mező *-gá vált-e
            
            bool gameover = false;
            
            for (int i = 0; i < game.GetLength(0); i++)
                for (int j = 0; j < game.GetLength(1); j++)
                    if (game[i, j] == true)
                        gameover false;
            
            return gameover;
        }


        static void Main(string[] args)
        {
            // Szigetek

            int[] tomb = arrayFill(15);
            display(tomb);
            int height = Feladat3(tomb);
            Console.WriteLine();
            Console.WriteLine("A legmagasabb pont helye {0}, a magassága {1}.", height + 1, tomb[height]);
            Console.WriteLine("A legmagasabb pont {0} alkalommal fordul elő.", Feladat4(tomb, height));
            Console.WriteLine("A legmagasabb pont {0} alkalommal fordul elő.", Feladat4(tomb, height));
            Console.WriteLine("A leghosszabb sziget hossza {0}.", Feladat5(tomb));
            Console.ReadLine();

            // Cserélgetős játék

            int size = 5;
            bool[,] game = new bool[size, size];
            init(ref game);
            Console.WriteLine(state(game));
            shoot(game, 2, 2);
            Console.WriteLine(state(game));
            Console.ReadLine();
        }
    }
}
