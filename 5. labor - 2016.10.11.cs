using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proglab20161011
{
    class Program
    {
        static Random R = new Random();

        static string generateNeptunCode(int size)
        {
            /*
             * Írjon programot, amely előállít egy véletlen Neptun kódot!
             */

            string neptun = "";
            string pool = "0123456789QWERTZUIOPASDFGHJKLYXCVBNM";

            for (int i = 0; i < size; i++)
                neptun += pool[R.Next(0, pool.Length)];

            return neptun;
        }

        static string reverseString(string source)
        {
            /*
             * Fordítsunk meg egy stringet!
             */

            string result = "";
            
            foreach (var item in source)
                result = item + result;

            return result;
        }

        static int countLetters(string source)
        {
            /*
             * 2. Írjon programot, amely egy szöveges változóban megszámolja a betűket!
             */

            int result = 0;

            foreach (var item in source)
                if (char.IsLetter(item))
                    result++;

            return result;
        }

        static bool isVowel(char source)
        {
            /*
             * Az átadott karakter magánhangzó-e?
             */

            bool result = false;
            string vowels = "aáeéiíuúüűoóöő";

            if (char.IsUpper(source))
                source = char.ToLower(source);

            foreach (var item in vowels)
                if (source == item)
                    result = true;

            return result;
        }

        static int countVowels(string source)
        {
            /*
             * Hány magánhangzót tartalmaz a string?
             */

            int result = 0;

            foreach (var item in source)
                if (isVowel(item))
                    result++;

            return result;
        }

        static string transformText(string source)
        {

            /*
             * 4. Írjon programot, amely egy szöveget átalakít „Teve tuvudsz ívígy beveszévélnivi” módon!
             */

            string result = "";

            foreach (var item in source)
            {
                result += item;

                if (isVowel(item))
                    result += "v" + char.ToLower(item);
            }

            return result;
        }

        static string trimText(string source)
        {

            /*
             * 4. Írjon programot, amely egy szövegből „eltünteti” a szóközöket!
             */

            string result = "";

            foreach (var item in source)
                if (item != ' ')
                    result += item;

            /*
             * Vagy ami minden nem-szöveget eltávolít
             */

            result = "";

            foreach (var item in source)
                if (char.IsLetter(item))
                    result += item;

            return result;
        }

        static bool palindrom(string source)
        {

            /*
             * 5. Írjon programot, amely egy szövegről megmondja, hogy palindrom-e.
             */

            bool result = true;

            // ez egy speciális eset, csak tökéletes egyezésre (pl. "gézakékazég")

            for (int i = 0; i < (source.Length) / 2 && result == true; i++)
                if (source[i] != source[source.Length - 1 - i])
                    result = false;

            // vagy általánosan és rövidebben, felhasználva a korábban megírt függvényeinket

            return (reverseString(trimText(source)).ToLower() == trimText(source).ToLower()) ? true : false;
        }

        static void Main(string[] args)
        {
            string neptuncode = generateNeptunCode(6);

            Console.WriteLine(neptuncode);
            Console.WriteLine(reverseString(neptuncode) + "<--");
            Console.WriteLine(countLetters(neptuncode) + " betű");
            Console.WriteLine(countVowels(neptuncode) + " magánhangzó");
            Console.WriteLine(transformText("Te tudsz így beszélni?"));
            Console.WriteLine(transformText("Így nem tudok..."));
            Console.WriteLine(trimText("No! Sikerült-e megcsinálni?"));
            Console.WriteLine(palindrom("Géza kék az ég."));
            Console.ReadLine();
        }
    }
}
