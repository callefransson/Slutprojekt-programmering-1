
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bussen
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Skapar ett objekt av klassen Buss som heter minbuss
            //Denna del av koden kan upplevas väldigt förvirrande. Men i sådana fall är det bara att "skriva av".
            var minbuss = new Buss();
            minbuss.Run();
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
    class Passagerare
    {
        private string? namn;
        private int ålder;
        private string? kön;


        public Passagerare(string? namn, int ålder, string kön)
        {
            this.aNamn = namn;
            this.aÅlder = ålder;
            this.akön = kön;

        }
        public string? aNamn
        {
            get { return namn; }
            set
            {
                namn = value;
            }
        }
        public int aÅlder
        {
            get { return ålder; }
            set { ålder = value; }
        }
        public string? akön
        {
            get { return kön; }
            set { kön = value; }
        }
        public string TypAvKön()
        {
            do
            {
                if (kön == "K")
                {
                    kön = "Kvinna";
                }
                else if (kön == "M")
                {
                    kön = "Man";
                }
            } while (kön == null);
            return kön;
        }
    }


    class Buss
    {
        Passagerare[] antalPlatser = new Passagerare[25];


        public void Run()
        {
            Console.WriteLine("Welcome to the awesome Buss-simulator");
            //Här ska menyn ligga för att göra saker
            //Jag rekommenderar switch och case här
            //I filmen nummer 1 för slutprojektet så skapar jag en meny på detta sätt.
            //Dessutom visar jag hur man anropar metoderna nedan via menyn
            //Börja nu med att köra koden för att se att det fungerar innan ni sätter igång med menyn.
            //Bygg sedan steg-för-steg och testkör koden.
            int meny;

            do
            {

                Console.WriteLine("Välj de alternativ du vill få reda på om bussen.");
                Console.WriteLine("[1] Lägg till passagerare. \n[2] Skriv ut alla på bussen. \n[3] Beräkna den totala åldern. \n[4] Beräkna genomsnittliga åldern" +
                "\n[5] Visa personen med lägsta/högsta åldern \n[6] Visa åldern mellan två värden. \n[7] Sortera bussen efter ålder " +
                "\n[8] Skriv ut alla kvinnor/män i bussen \n[9] Peta på en viss person \n[10] Be en passagerare kliva av bussen. \n[11] För att stänga programmet skriv in 0.");
                meny = Convert.ToInt32(Console.ReadLine());
                switch (meny)
                {
                    case 1:
                        add_passenger();
                        break;
                    case 2:
                        print_buss();
                        break;
                    case 3:
                        calc_total_age();
                        break;
                    case 4:
                        calc_average_age();
                        break;
                    case 5:
                        max_min_age();
                        break;
                    case 6:
                        find_age();
                        break;
                    case 7:
                        sort_buss();
                        break;
                    case 8:
                        print_sex();
                        break;
                    case 9:
                        poke();
                        break;
                    case 10:
                        getting_off();
                        break;
                    case 11:
                        Console.WriteLine("Vänligen skriv [0] för att stänga programmet.");
                        break;
                }



            }
            while (meny != 0);




        }


        //Metoder för betyget E

        private void add_passenger()
        {
            Console.Clear();
            //Lägg till passagerare. Här skriver man då in ålder men eventuell annan information.
            //Om bussen är full kan inte någon passagerare stiga på
            var namn = "";
            int ålder;
            string kön;

            ConsoleKeyInfo knappTryck;

            while (true)
            {

                Console.WriteLine("Lägg till passagerare! vänligen skriv namnet på passageraren.");
                try
                {
                    namn = Console.ReadLine();
                    break;

                }
                catch
                {
                    Console.WriteLine("Vänligen skriv in ett namn");
                }

            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Vänligen skriv in åldern på passageraren.");
                    ålder = Convert.ToInt32(Console.ReadLine());

                    if (ålder >= 100)
                    {
                        Console.WriteLine("Oj du var gammal! är det verkligen säkert för dig att åka buss?");
                        
                    }
                    else if (ålder <= 5)
                    {
                        Console.WriteLine("Är inte du för liten för att åka buss själv?");
                    }
                    else
                    {
                        Console.WriteLine("Välkommen ombord {0}", namn);
                        break;
                    }

                }
                catch
                {
                    Console.WriteLine("Skriv in ett tal..");
                }
            }
            while (true)
            {
                Console.WriteLine("Skriv in om personen är en kvinna eller man");
                Console.WriteLine("Vänligen skriv [M] för man eller [K] för kvinna");
                try
                {
                    knappTryck = Console.ReadKey(true);
                    kön = knappTryck.Key.ToString();
                    if (kön == "M" || kön == "K")
                    {

                        Console.WriteLine("Nu har {0} med åldern {1} klivit på bussen", namn,ålder);
                        break;

                    }
                }
                catch
                {
                    Console.WriteLine("Vänligen välj bland alternativen");
                }
            }

            for (int i = 0; i < antalPlatser.Length; i++)
            {

                if (antalPlatser[i] == null)
                {
                    antalPlatser[i] = new Passagerare(namn, ålder, kön);
                    break;

                }
            }

            Console.WriteLine("Klicka på valfri tangentknapp för att gå tillbaka till huvudmenyn.");
            Console.ReadKey(true);
        }

        public void print_buss()
        {
            int nummer = 0;
            Console.Clear();
            foreach (Passagerare personer in antalPlatser)
            {
                nummer++;
                if (personer == null)
                {
                    Console.WriteLine("På säte {0} sitter det ingen person", nummer);
                }
                else
                {
                    Console.WriteLine("på säte {0} sitter {1}", nummer, personer.aNamn);
                }
            }

            //Skriv ut alla värden ur vektorn. Alltså - skriv ut alla passagerare
            Console.WriteLine("Klicka på valfri tangentknapp för att gå tillbaka till huvudmenyn.");
            Console.ReadKey(true);
        }

        public void calc_total_age()
        {
            int totalaÅldern = 0;
            Console.Clear();
            foreach (Passagerare person in antalPlatser)
            {
                if (person != null)
                {
                    totalaÅldern += person.aÅlder;
                }
            }
            Console.WriteLine("Den totala åldern för alla passagerare är {0}", totalaÅldern);
            Console.WriteLine("Klicka på valfri tangentknapp för att gå tillbaka till huvudmenyn.");
            Console.ReadKey(true);
        }

        //Metoder för betyget C

        public void calc_average_age()
        {
            int summan = 0;
            int antalPassagerare = 0;
            foreach (Passagerare personer in antalPlatser)
            {
                if (personer == null) // Om platsen är tom
                {
                    continue;
                }
                else // Om det finns en person på platsen
                {
                    summan += personer.aÅlder;
                    antalPassagerare++;
                }
            }
            double summa = Convert.ToDouble(summan);
            double slutSumma = summa / antalPassagerare;
            Console.WriteLine("Den genomsnittliga åldern för alla passagerare är {0}", slutSumma);

            //Betyg C
            //Beräkna den genomsnittliga åldern. Kanske kan man tänka sig att denna metod ska returnera något annat värde än heltal?
            //För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void
            Console.WriteLine("Klicka på valfri tangentknapp för att gå tillbaka till huvudmenyn.");
            Console.ReadKey(true);
        }

        public void max_min_age()
        {
            Console.Clear();
            int maxÅlder = 0;
            int minÅlder = 100;
            foreach (Passagerare personer in antalPlatser)
            {
                if (personer == null)
                {
                    continue;
                }
                else if (personer.aÅlder < minÅlder)
                {
                    minÅlder = personer.aÅlder;

                }
                else if (personer.aÅlder > maxÅlder)
                {
                    maxÅlder = personer.aÅlder;

                }
            }
            foreach (Passagerare personer in antalPlatser)
            {
                if (personer == null)
                {
                    continue;
                }
                else if (maxÅlder == personer.aÅlder)
                {
                    Console.WriteLine("Personen som är älst är {0} med åldern {1}.", personer.aNamn, personer.aÅlder);
                }
            }
            foreach (Passagerare personer in antalPlatser)
            {
                if (personer == null)
                {
                    continue;
                }
                else if (minÅlder == personer.aÅlder)
                {
                    Console.WriteLine("Personen som är yngst är {0} med åldern {1}.", personer.aNamn, personer.aÅlder);
                }
            }

            //Betyg C
            //ta fram den passagerare med högst ålder. Detta ska ske med egen kod och är rätt klurigt.
            //För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void
            Console.WriteLine("Klicka på valfri tangentknapp för att gå tillbaka till huvudmenyn.");
            Console.ReadKey(true);
        }

        public void find_age()
        {
            Console.Clear();
            Console.WriteLine("Vänligen skriv in den lägsta åldern");
            int lägstaÅldern = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Vändligen skriv in den högsta åldern");
            int högstaÅldern = Convert.ToInt32(Console.ReadLine());
            foreach (Passagerare personer in antalPlatser)
            {
                if (personer == null)
                {
                    continue;
                }
                else if (personer.aÅlder > lägstaÅldern && personer.aÅlder < högstaÅldern)
                {
                    Console.WriteLine("personerna med åldern mellan {0} och {1} är {2} som är {3} år gammal", lägstaÅldern, högstaÅldern, personer.aNamn, personer.aÅlder);
                }
            }

            //Visa alla positioner med passagerare med en viss ålder
            //Man kan också söka efter åldersgränser - exempelvis 55 till 67
            //Betyg C
            //Beskrivs i läroboken på sidan 147 och framåt (kodexempel på sidan 149)
            Console.WriteLine("Klicka på valfri tangentknapp för att gå tillbaka till huvudmenyn.");
            Console.ReadKey(true);
        }

        public void sort_buss()
        {
            List<Passagerare> nyList = new List<Passagerare>();

            // Adds all passengers in the temporary list
            foreach (Passagerare personer in antalPlatser)
            {
                if (personer == null)
                {
                    continue;
                }
                else
                {
                    nyList.Add(personer);
                }
            }
            // Selection sort in temporary list
            for (int i = 0; i < nyList.Count; i++)
            {
                int indexNummer = i;
                for (int j = i + 1; j < nyList.Count; j++)
                {
                    if (nyList[j].aÅlder < nyList[indexNummer].aÅlder)
                    {
                        indexNummer = j;
                    }
                }
                if (indexNummer != i)
                {
                    Passagerare temporaryValueHolder = nyList[i];
                    nyList[i] = nyList[indexNummer];
                    nyList[indexNummer] = temporaryValueHolder;
                }
            }
            // Clear all seats
            Array.Clear(antalPlatser, 0, antalPlatser.Length - 1);
            // Add all passengers, now sorted in age
            for (int i = 0; i < nyList.Count; i++)
            {
                antalPlatser[i] = (nyList[i]);
            }
            // Print new passenger order
            int nummer = 0;
            foreach (Passagerare person in antalPlatser)
            {
                nummer++;
                if (person == null)
                {
                    Console.WriteLine("plats nr: {0} är tom", nummer);
                }
                else
                {
                    Console.WriteLine("På säte nr: {0} sitter {1} som är {2} år gammal.", nummer, person.aNamn, person.aÅlder);
                }
            }


            Console.WriteLine("Klicka på valfri tangentknapp för att gå tillbaka till huvudmenyn.");
            Console.ReadKey(true);
        }



        //Metoder för betyget A


        public void print_sex()
        {

            Console.Clear();
            //Betyg A
            //Denna metod är nödvändigtvis inte svårare än andra metoder men kräver att man skapar en klass för passagerare.
            //Skriv ut vilka positioner som har manliga respektive kvinnliga passagerare.
            Console.WriteLine("Skriver ut vart det sitter en man respektive kvinna i bussen.");
            int nummer = 0;
            foreach (Passagerare personer in antalPlatser)
            {
                if (personer != null)
                {
                    nummer++;
                    Console.WriteLine("På plats nr: {0} sitter {1} som är en {2}.", nummer, personer.aNamn, personer.TypAvKön());
                }

            }
            Console.WriteLine("Klicka på valfri tangentknapp för att gå tillbaka till huvudmenyn.");
            Console.ReadKey(true);
        }
        public void poke()
        {
            Console.Clear();
            int nummer = 0;
            int index;

            //Betyg A
            //Vilken passagerare ska vi peta på?
            //Denna metod är valfri om man vill skoja till det lite, men är också bra ur lärosynpunkt.
            //Denna metod ska anropa en passagerares metod för hur de reagerar om man petar på dom (eng: poke)
            //Som ni kan läsa i projektbeskrivningen så får detta beteende baseras på ålder och kön.
            Console.WriteLine("Välj en person i bussen som du vill peta på");

            for (int i = 0; i < antalPlatser.Length; i++)
            {
                nummer++;
                if (antalPlatser[i] == null)
                {
                    Console.WriteLine("På plats nr: {0} sitter det ingen person", nummer);
                    continue;
                }
                else
                {
                    Console.WriteLine("på plats nr: {0} sitter {1}", nummer, antalPlatser[i].aNamn);
                }
            }
            Console.WriteLine("Vänligen skriv in sittplatsen som passageraren sitter på");

            while (true)
            {
                try
                {
                    index = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (antalPlatser[index] == null)
                    {
                        Console.WriteLine("Här sitter det ingen person, försök igen");
                    }

                    else
                    {
                        Console.WriteLine("du valde {0}", antalPlatser[index].aNamn);
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Skriv ett tal mellan 1-25.");
                }
            }
            foreach (Passagerare personer in antalPlatser)
            {
                if (antalPlatser[index].aÅlder > 30 && antalPlatser[index].akön == "M")
                {
                    antalPlatser[index].akön = personer.TypAvKön();
                    Console.WriteLine("Hahah, du är rolig du");
                }
                else if (antalPlatser[index].aÅlder < 30 && antalPlatser[index].akön == "K")
                {
                    antalPlatser[index].akön = personer.TypAvKön();
                    Console.WriteLine("Ursäkta, vad vill du?");
                }
                else if (antalPlatser[index].aÅlder < 30 && antalPlatser[index].akön == "M")
                {
                    antalPlatser[index].akön = personer.TypAvKön();
                    Console.WriteLine("Det är inte kul, sluta!");
                }
                else if (antalPlatser[index].aÅlder > 30 && antalPlatser[index].akön == "K")
                {
                    antalPlatser[index].akön = personer.TypAvKön();
                    Console.WriteLine("Hej på dig, vad undrar du då?");
                }
            }
            Console.WriteLine("Klicka på valfri tangentknapp för att gå tillbaka till huvudmenyn.");
            Console.ReadKey(true);
        }

        public void getting_off()
        {
            Console.Clear();
            //Betyg A
            //En passagerare kan stiga av
            //Detta gör det svårare vid inmatning av nya passagerare (som sätter sig på första lediga plats)
            //Sortering blir också klurigare
            //Den mest lämpliga lösningen (men kanske inte mest realistisk) är att passagerare bakom den plats..
            //.. som tillhörde den som lämnade bussen, får flytta fram en plats.
            //Då finns aldrig någon tom plats mellan passagerare.

            int nummer = 0;
            int taBortIndex = -1;

            for (int i = 0; i < antalPlatser.Length; i++)
            {
                nummer++;
                if (antalPlatser[i] == null)
                {
                    Console.WriteLine("På plats nr: {0} sitter det ingen person", nummer);
                    continue;
                }
                else
                {
                    Console.WriteLine("på plats nr: {0} sitter {1}", nummer, antalPlatser[i].aNamn);
                }
            }

            Console.WriteLine("Vänligen skriv in sittplatsen som passageraren sitter på som du vill ska kliva av bussen");
            while (true)
            {
                taBortIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                if (taBortIndex < 0 || taBortIndex >= antalPlatser.Length)
                {
                    Console.WriteLine("Vänligen välj mellan 1-25");
                }
                else if (antalPlatser[taBortIndex] == null)
                {
                    Console.WriteLine("Denna platsen är tom");
                }
                else if (antalPlatser[taBortIndex] != null)
                {
                    Console.WriteLine("Nu har du {0} klivit av bussen", antalPlatser[taBortIndex].aNamn);
                    antalPlatser[taBortIndex] = null;
                    break;
                }
            }




















            /*if (taBortIndex >= 0 && taBortIndex < antalPlatser.Length)
            {
                for (int i = taBortIndex; i < antalPlatser.Length - 1; i++)
                {
                    antalPlatser[i] = antalPlatser[i + 1];
                }
                Array.Resize(ref antalPlatser, antalPlatser.Length - 1);
                Console.WriteLine("indexNummer {0} har tagits bort", taBortIndex);
            }
            else
            {
                Console.WriteLine("Välj där det sitter en person");
            }
            foreach (Passagerare personer in antalPlatser)
            {
                if (personer == null)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("på plats nr: {0} sitter {1}", nummer, personer.aNamn);
                }
            }
    /*



            /* while (true)
             {
                 for (int i = 0; i < antalPlatser.Length; i++)
                 {

                     if (antalPlatser[taBortIndex] == null)
                     {
                         Console.WriteLine("Denna platsen är redan tom");
                     }
                     else if (taBortIndex < 0 || taBortIndex > antalPlatser.Length)
                     {
                         Console.WriteLine("Välj mellan 1-25");
                     }
                     else
                     {
                         Console.WriteLine("Du valde personen {0} som satt på plats {1}.", antalPlatser[i].aNamn, nummer);
                     }

                 }


                 Console.WriteLine("Klicka på valfri tangentknapp för att gå tillbaka till huvudmenyn.");
                 Console.ReadKey(true);
             }
             */
            Console.WriteLine("Klicka på valfri tangentknapp för att gå tillbaka till huvudmenyn.");
            Console.ReadKey(true);
        }
    }
}