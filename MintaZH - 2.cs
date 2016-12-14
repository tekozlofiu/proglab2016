using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MintZH2
{
    class Program
    {
        static void Main(string[] args)
        {
            Szerkesztőség tesztSzerkesztőség = new Szerkesztőség();
            Console.WriteLine(tesztSzerkesztőség.Megjelenít());
            Console.WriteLine("Akkor vegyük fel új embereket!\n");

            ÜzenetFeldolgozó tesztAdatok = new ÜzenetFeldolgozó("bemenet.txt");
            Console.WriteLine(tesztAdatok.Megjelenít());

            while (tesztAdatok.VanÜzenet())
                tesztSzerkesztőség.ÚjCikk(tesztAdatok.ÜzenetFeldolgoz());

            Console.WriteLine(tesztSzerkesztőség.Megjelenít());

            string[,] összesCikk = tesztSzerkesztőség.ÖsszesCikk();
            int n = 0;
            foreach (var item in összesCikk)
            {
                Console.Write(item + "\t");
                n++;
                if (n % 4 == 0) Console.Write("\n");
            }
            Console.ReadKey();
        }
    }

    class ÜzenetFeldolgozó
    {
        // adattag - a még feldolgozatlan üzenetek
        string üzenet;

        public string Üzenet
        {
            // csak írható tulajdonság - a korábbi üzenethez fűzi az újat
            set { üzenet += value; }
        }

        public ÜzenetFeldolgozó(string üzenet)
        {
            /* konstruktor - kezdeti érték adható az üzenetnek
             * Amennyiben a paraméter *.txt formátumú, akkor azon fájl nevét jelöli,
             * melyben az edzések adatai található. 
             * Ilyen esetben a konstruktor a fájl egyes soraiból előállítja az üzenet adattagot 
             */

            if (!üzenet.EndsWith(".txt"))
                this.üzenet = üzenet;
            else
            {
                StreamReader sr = new StreamReader(üzenet);
                while (!sr.EndOfStream)
                    Üzenet = sr.ReadLine();
                sr.Close();
            }
        }

        public bool VanÜzenet()
        {
            // metódus - megadja, hogy van-e még feldolgozatlan üzenet?
            return (üzenet.Length > 0);
        }

        public string ÜzenetFeldolgoz()
        {
            // metódus - visszaad egy üzenetrészt, elhagyva az üzenet elejéről
            string egySor = üzenet.Split('@')[1];

            üzenet = üzenet.Substring(egySor.Length + 1);

            return egySor;
        }

        public string Megjelenít()
        {
            // medótud - visszaad egy szöveget az üzenet megjelenítése érdekében
            return "Feldolgozandó üzenet:\n\n" + üzenet + "\n";
        }
    }

    class Cikk
    {
        // random generátor
        static Random rng = new Random();

        // adattagok
        string cikkTípus;
        string nap;
        int tetszésiIndex;

        // osztályszintű tag, az összes létrehozott cikk számát tárolja
        static int cikkekÖsszSzáma = 0;
        
        public static int CikkekÖsszSzáma
        {
            get
            {
                return cikkekÖsszSzáma;
            }
        }

        // tulajdonságok - csak olvasható
        public string CikkTípus
        {
            get { return cikkTípus; }
        }

        public string Nap
        {
            get { return nap; }
        }

        public int TetszésiIndex
        {
            get { return tetszésiIndex; }
        }
        
        public Cikk(string cikk)
        {
            // konstruktor
            Feldolgoz(cikk);
            cikkekÖsszSzáma++;
        }

        void Feldolgoz(string cikk)
        {
            // Rejtett metódus - értéket ad a osztály adattagjainak
            string[] darabok = cikk.Split('!', ':');

            cikkTípus = darabok[0];
            nap = darabok[1];

            // Ha a szöveg nem tartalmaz tetszési indexet, 1 és 10 közötti véletlen értéket kap
            tetszésiIndex = (cikk.Contains(':')) ? int.Parse(darabok[2]) : rng.Next(1, 11);
        }

        public string Megjelenít()
        {
            // medótudus - visszaad egy szöveget az adatok megjelenítése érdekében
            return "Rovat: " + cikkTípus + "\tNap: " + nap + "\tIndex: " + tetszésiIndex + "\n";
        }
    }

    class Újságíró
    {
        // adattagok
        string név;
        Cikk[] hetiCikkek = new Cikk[10];
        int cikkekSzám;

        public string Név
        {
            // csak olvasható tulajdonság
            get { return név; }
        }

        public int CikkekSzám
        {
            get { return cikkekSzám; }
            set { CikkekSzám = value; }
        }

        public Cikk[] HetiCikkek
        {
            get { return hetiCikkek; }
        }

        public Újságíró(string név)
        {
            // konstruktor - a név értéket kapja meg
            this.név = név;
        }

        public void ÚjCikk(Cikk cikk)
        {
            // medódus - a hetiCikkek tömbbe vesz fel egy elemet
            hetiCikkek[cikkekSzám] = cikk;
            cikkekSzám++;
        }

        public int HetiÖsszTetszés()
        {
            // metódus - megadja az újságíró heti összesített tetszési indexét
            int összesítés = 0;

            foreach (var item in hetiCikkek)
                összesítés += item.TetszésiIndex;

            return összesítés;
        }

        public string Megjelenít()
        {
            // metódus - visszaadja az újságíró nevének és heti cikkeinek adatatit.
            string adatok = "Név: " + név + "\n";
            if (cikkekSzám > 0)
                for (int i = 0; i < cikkekSzám; i++)
                    adatok += "Rovat: " + hetiCikkek[i].CikkTípus + "\tNap: " + hetiCikkek[i].Nap + "\tIndex: " + hetiCikkek[i].TetszésiIndex + "\n";
            else
                adatok = "Nem írt még cikket.";
            return adatok + "\n";
        }
    }

    class Szerkesztőség
    {
        // adattagok
        Újságíró[] újságírók = new Újságíró[10];
        int újságírókSzáma;
        
        public Szerkesztőség()
        {
            // konstruktor
        }

        public void ÚjCikk(string üzenet)
        {
            // metódus - cikkre vonatkozó szöveget kap, hozzárendeli egy korábban szerkesztőségben lévő újságíróhoz vagy készít egy újat

            string név = üzenet.Split('#')[0];
            string cikk = üzenet.Split('#')[1];

            // ha nincs még ilyen, létrehozzuk
            if (!VanÚjságíró(név))
                ÚjÚjságíró(név);

            // hozzárendeljük
            újságírók[ÚjságíróIndex(név)].ÚjCikk(new Cikk(cikk));
        }

        bool VanÚjságíró(string név)
        {
            // rejtett metódus - megadja, hogy az adott újságíró tagja-e a szerkesztőségnek
            for (int i = 0; i < újságírókSzáma; i++)
                if (újságírók[i].Név == név)
                    return true;

            return false;
        }

        int ÚjságíróIndex(string név)
        {
            // rejtett metódus - megadja, az adott újságíró hányadik eleme a tömbnek
            for (int i = 0; i < újságírókSzáma; i++)
                if (újságírók[i].Név == név)
                    return i;
            return -1;
        }

        void ÚjÚjságíró(string név)
        {
            // rejtett metódus - felveszi az újságírót a szerkesztőségbe
            újságírók[újságírókSzáma] = new Újságíró(név);
            újságírókSzáma++;
        }

        public string Megjelenít()
        {
            // metódus - visszaadja a szerkesztőség adatait
            string szerkesztőség = "A szerkesztőség tagjai:\n";

            if (újságírókSzáma > 0)
            {
                for (int i = 0; i < újságírókSzáma; i++)
                    szerkesztőség += újságírók[i].Név + "\n";

                szerkesztőség += "Az átaluk írt cikkek:\n\n";

                for (int i = 0; i < újságírókSzáma; i++)
                    szerkesztőség += újságírók[i].Megjelenít();
            }
            else
                szerkesztőség += "Egyelőre senki";

            return szerkesztőség + "\n";
        }

        public string[,] ÖsszesCikk()
        {
            // Saját metódus, aggregálja a szerkesztőség összes cikkét

            string[,] cikkek = new string[Cikk.CikkekÖsszSzáma, 4];
            int k = 0;

            for (int i = 0; i < újságírókSzáma; i++)
            {
                for (int j = 0; j < újságírók[i].CikkekSzám; j++)
                {
                    cikkek[k, 3] = újságírók[i].Név;
                    cikkek[k, 2] = újságírók[i].HetiCikkek[j].CikkTípus;
                    cikkek[k, 1] = újságírók[i].HetiCikkek[j].Nap;
                    cikkek[k, 0] = újságírók[i].HetiCikkek[j].TetszésiIndex.ToString();
                    k++;
                }
            }
            
            return cikkek;
        }
    }
}
