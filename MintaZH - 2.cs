using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH2
{
    class ÜzenetFeldolgozó
    {
        string üzenet;                              // a vezetőedzőtől érkezett még feldolgozatlan üzenetet tároljuk

        public ÜzenetFeldolgozó(string bemenet)     // Kosntruktor
        {
            /* ÜzenetFeldolgozó(string) konstruktor, melyben kezdeti érték adható az üzenetnek.
Amennyiben a paraméter *.txt formátumú, akkor azon fájl nevét jelöli, melyben az
edzések adatai található. Ilyen esetben a konstruktor a fájl egyes soraiból előállítja az üzenet
adattagot */
            this.üzenet = bemenet;
        }

        public string Üzenet
        {
            // Üzenet csak írható tulajdonság, mely a korábbi üzenethez hozzáfűzi az új üzenetet

            set { üzenet += value; }
        }

        public bool VanÜzenet()
        {
            // VanÜzenet() metódus, mely megadja, hogy van-e még feldolgozatlan üzenet
            return (üzenet.Length > 0); 
        }

        public string Feldolgoz()
        {
            // Feldolgoz() metódus, mely visszaad egy edzésre vonatkozó üzenetrészt elhagyva azt az üzenet elejéről 

            string aktuálisÜzenet = üzenet.Split('@')[1];

            üzenet = üzenet.Substring(aktuálisÜzenet.Length + 1);

            return aktuálisÜzenet;
        }

        public string Megjelenít()
        {
            // Megjelenít() metódus, mely visszaad egy szöveget az üzenet megjelenítése érdekében

            return üzenet;
        }
    }

    class Edzés
    {
        static Random randomgenerator = new Random();

        // sportág, nap és táv adattag

        string sportág;
        string nap;
        int táv;

        // Táv, Nap és Sportág csak olvasható tulajdonságok

        public string Sportág { get { return sportág; } }
        public string Nap { get { return nap; } }
        public int Táv { get { return táv; } }

        private void Feldolgoz(string bemenet)
        {            
            // a bemenetként kapott stringet feldaraboljuk a három elválasztó karakter [ #, !, : ] mentén

            string[] darabok = bemenet.Split('#', '!', ':');
            
            this.sportág    = darabok[1];
            this.nap        = darabok[2];

            if (bemenet.Contains(':'))
            {
                this.táv = int.Parse(darabok[3]);
            }
            else {
                this.táv = randomgenerator.Next(5, 11);
            }
        }

        public Edzés(string bemenet)
        {
            // Edzés(string) konstruktor, mely meghívja a Feldolgoz(string) metódust

            Feldolgoz(bemenet);

        }

        string Megjelenít()
        {
            //Megjelenít() metódus, mely visszaad egy szöveget az adatok megjelenítése érdekében

            return "";
        }
    }

    class Sportoló
    {
        // név, hetiEdzések (maximum 10 darab) és edzésSzám adattagok
        string név;
        Edzés[] hetiEdzések = new Edzés[10];
        int edzésSzám = 0;

        // Név csak olvasható tulajdonság
        public string Név
        {
            get { return név; }
        }

        public Sportoló(string név)
        {
            // Sportoló(string) konstruktor, mely a név értékét kapja meg
            this.név = név;
        }

        public void ÚjEdzés(string bemenet)
        {
            // ÚjEdzés(Edzés) metódus, mely a hetiEdzések tömbbe felvesz egy új elemet
            if (edzésSzám < 10)
            {
                hetiEdzések[edzésSzám] = new Edzés(bemenet);
                edzésSzám++;
            }
        }

        int HetiÖsszTáv()
        {
            // HetiÖsszTáv() metódus, mely meghatározza, hogy mennyi a sportoló heti össztávja

            int hetiÖsszTáv = 0;

            for (int i = 0; i < edzésSzám; i++)
            {
                hetiÖsszTáv += hetiEdzések[i].Táv;
            }

            return hetiÖsszTáv;
        }

        string HetiMaxÚszás()
        {
            int maxÚszásIndexe = 0;
            int maxÚszásÉrtéke = 0;

            // HetiMaxÚszás(), mely meghatározza, hogy melyik napon úszott a legtöbbet a sportoló

            for (int i = 0; i < edzésSzám; i++)
            {
                if (hetiEdzések[i].Sportág == "Úszás")
                {
                    if (hetiEdzések[i].Táv > maxÚszásÉrtéke)
                    {
                        maxÚszásÉrtéke = hetiEdzések[i].Táv;
                        maxÚszásIndexe = i;
                    }
                }
            }

            return hetiEdzések[maxÚszásIndexe].Nap;
        }

        public string Megjelenít()
        {
            string adatok = "Név: \t\t" + név + "\n";
            // Megjelenít() metódus, mely visszaad egy szöveget a sportoló nevének és heti edzés adatainak megjelenítése érdekében

            for (int i = 0; i < edzésSzám; i++)
            {
                adatok += "Sportág: " + hetiEdzések[i].Sportág + " Nap: " + hetiEdzések[i].Nap + " Táv: " + hetiEdzések[i].Táv + "\n";
            }

            adatok += "Edzésszám: \t" + edzésSzám + "\n";
            adatok += "HetiÖsszTáv: \t" + HetiÖsszTáv() + "\n";
            adatok += "HetiMaxÚszás: \t" + HetiMaxÚszás() + "\n";

            return adatok;

        }

    }

    class SportKlub
    {
        // sportolók (maximum 10 darab) és sportolókSzáma adattagok

        Sportoló[] sportolók = new Sportoló[10];
        int sportolókSzáma = 0;

        void ÚjEdzés(string bemenet)
        // ÚjEdzés(string) metódus, mely egy edzésre vonatkozó szöveget kap és ez alapján az edzés 
        // adatait hozzárendeli egy korábban is a klubban lévő sportolóhoz, vagy új sportolóhoz
        {
            if (!VanSportoló(bemenet))
            {
                ÚjSportoló(bemenet);
            }

            int indexe = SportolóIndex(bemenet);
            sportolók[indexe].ÚjEdzés(bemenet);

        }

        bool VanSportoló(string név)
        {
            // VanSportoló(string) rejtett metódus, mely megadja, hogy az adott sportoló tagja e már a klubnak
            for (int i = 0; i < sportolókSzáma; i++)
            {
                if (sportolók[i].Név == név)
                {
                    return true;
                }
            }

            return false;
        }

        int SportolóIndex(string név) 
        {
            for (int i = 0; i < sportolókSzáma; i++)
            {
                if (sportolók[i].Név == név)
                    return i;
            }

            return -1;  
        }

        void ÚjSportoló(string név)
        {
            // ÚjSportoló(string) rejtett metódus felveszi a sportolót a klubba
            if (sportolókSzáma < 10)
            {
                sportolók[sportolókSzáma] = new Sportoló(név);
                sportolókSzáma++;
            }
        } 

        string Megjelenít()
        {
            string adat = "";

            return adat;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            /*
            ÜzenetFeldolgozó adatok = new ÜzenetFeldolgozó("@Kiss_József#Futás!Szerda:14");

            Sportoló József = new Sportoló("Kiss József");

            József.ÚjEdzés("#Úszás!Hétfő:12");
            József.ÚjEdzés("#Úszás!Kedd:20");
            József.ÚjEdzés("#Úszás!Hétfő:12");
            József.ÚjEdzés("#Futás!Szerda:40");
            Console.WriteLine(József.Megjelenít());
            Console.ReadKey();
            */
            // @Kiss_József#Futás!Szerda:14@Nagy_Imre#Úszás!Kedd:12@Nagy_Imre#Úszás!Kedd:12@Nagy_Imre#Úszás!Kedd:12@Nagy_Imre#Úszás!Kedd:12@Nagy_Imre#Úszás!Kedd:12
        }
    }
}
