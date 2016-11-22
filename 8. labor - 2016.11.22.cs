using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proglab20151122
{

    class Program
    {
        /*
         * Egy kispályás focicsapatban 1 kapus, 1 védő, 2 center és 2 támadó játékos szerepel (5+1 fő).
         * A feladat az, hogy egy olyan programot készítsen, amely segítségével az elérhető játékosokból helyes felépítésű csapatot állítson elő!
         * Minden játékosról ismert a neve és a pozíciója, amely a fent felsorolt értékek egyike lehet.
         * Egy csapatba pontosan 6 játékos kell, a fentebb definiált módon.
         * A program indításkor generáljon játékosokat, és a felhasználónak legyen lehetősége csapatba rendelni őket.
         * 
         */

        static void Main(string[] args)
        {
            Csapat tesztcsapat = new Csapat();
            tesztcsapat.Hozzáad(new Játékos("aaa", "111", Pozíció.kapus));
            tesztcsapat.Hozzáad(new Játékos("aaa", "333", Pozíció.kapus));
            tesztcsapat.Hozzáad(new Játékos("bbb", "222", Pozíció.védő));
            tesztcsapat.Hozzáad(new Játékos("bbb", "222", Pozíció.védő));
            tesztcsapat.Hozzáad(new Játékos("bbb", "111", Pozíció.védő));
            Console.WriteLine(tesztcsapat.Lista());
            tesztcsapat.Hozzáad(new Játékos("eee", "444", Pozíció.támadó));
            tesztcsapat.Hozzáad(new Játékos("fff", "111", Pozíció.támadó));
            tesztcsapat.Hozzáad(new Játékos("ggg", "444", Pozíció.center));
            tesztcsapat.Hozzáad(new Játékos("hhh", "333", Pozíció.center));
            Console.WriteLine(tesztcsapat.Lista());
            Console.ReadLine();
        }
    }

    enum Pozíció
    {
        kapus = 0,
        védő = 1,
        center = 2,
        támadó = 3
    }

    class Csapat
    {
        /*
         * Egy kispályás focicsapatban 1 kapus, 1 védő, 2 center és 2 támadó játékos szerepel (5+1 fő).
         */

        const int CSAPATMÉRET = 6;                          // a csapat maximális mérete
        static int[] lehetségesPozíciók = { 1, 1, 2, 2 };   // a csapatban betölhető pozíciók maximális száma
        
        Játékos[] játékosok = new Játékos[CSAPATMÉRET];     // a csapatban levő játékosok tömbje
        int játékosokSzáma;                                 // a csapatban levő játékosok aktuális száma
        int[] aktuálisPozíciók = new int[4];                // a csapatban levő játékosok pozíciója

        bool Megtelt()                                      // a játékosok száma 6?
        {
            return játékosokSzáma == CSAPATMÉRET;
        }

        bool BenneVan(Játékos j)                            // eldönti, hogy j szerepel-e már a csapatban
        {
            for (int i = 0; i < játékosokSzáma; i++)
                if (játékosok[i].Nev == j.Nev && játékosok[i].Poz == j.Poz)
                    return true;

            return false;
        }

        bool Szerepelhet(Játékos j)                         // eldönti, hogy j pozíciója szabad-e
        {
            if (!Megtelt() && !BenneVan(j))
                if (aktuálisPozíciók[(int)j.Poz] < lehetségesPozíciók[(int)j.Poz])
                    return true;

            return false;
        }

        public void Hozzáad(Játékos j)                      // játékos hozzáadása a csapathoz
        {
            if (Szerepelhet(j))
            {
                játékosok[játékosokSzáma] = j;
                játékosokSzáma++;
                aktuálisPozíciók[(int)j.Poz]++;
            }
        }

        public string Lista()
        {
            string lista = "";
            for (int i = 0; i < játékosokSzáma; i++)
            {
                switch (játékosok[i].Poz)
                {
                    case Pozíció.kapus:
                        lista += "Kapus:  ";
                        break;
                    case Pozíció.védő:
                        lista += "Védő:   ";
                        break;
                    case Pozíció.center:
                        lista += "Center: ";
                        break;
                    case Pozíció.támadó:
                        lista += "Támadó: ";
                        break;
                    default:
                        break;
                }
                lista += játékosok[i].Nev + "\n";
            }
            return lista;
        }
    }
    
    class Játékos
    {
        string keresztnév;
        string vezetéknév;
        Pozíció poz;

        public Játékos(string vezetéknév, string keresztnév, Pozíció poz)
        {
            this.vezetéknév = vezetéknév;
            this.keresztnév = keresztnév;
            this.poz = poz;
        }

        public string Nev { get { return this.vezetéknév + " " + this.keresztnév; } }
        public Pozíció Poz { get { return this.poz; } }

    }
}
