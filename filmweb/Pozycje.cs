using System;
namespace Projekt_OOP
{
    public class Pozycja
    {
        public string Tytul { get; set; }
        public int Data_wydania { get; set; }
        public int Ocena { get; set; }

        public Pozycja()
        {
            Tytul = "";
        }
    }

    public class Film : Pozycja
    {
        public string Rezyser { get; set; }
        public int Godziny { get; set; }
        public int Minuty { get; set; } //czas trwania

        public Film()
        {
            Rezyser = "";
        }
    }

    public class Ksiazka : Pozycja
    {
        public string Autor { get; set; }
        public int Strony { get; set; }

        public Ksiazka()
        {
            Autor = "";
        }
    }
    public class Osoba
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public int oceny { get; set; } //ilosc wystawionych ocen


        public Osoba()
        {
            imie = ""; nazwisko = "";
        }
    }
    public static class Menu
    {
        public static void pisz_Poczatek()
        {
            Console.Clear();
            Console.WriteLine("@~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~@");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|               NAZWA APLIKACJI               |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("@~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~@");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|    System do oceniania filmow i ksiazek !   |");
            Console.WriteLine("|    Oceniaj, pisz komentarze i przegladaj    |");//wyrownac pozniej ten tekst
            Console.WriteLine("|        wpisy innych urzytkownikow           |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("@~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~@");
            Console.WriteLine("\nWcisnij dowolny klawisz by kontynuowac...");
            Console.ReadKey();
            pisz_Menu();
        }
        public static void pisz_Menu()
        {
            Console.Clear();
            Console.WriteLine("[1] Zobacz tablice"); //wygenerowane wpisy (z 10 gotowych i random+switch+wyswietlanie ich pod soba)
            Console.WriteLine("[2] Dodaj wpis");
            Console.WriteLine("[3] Zarzadzaj profilem"); //zmien nazwe_urzytkownika, zmien haslo ? 
            Console.Write("Wybor : ");
            var wybor = int.Parse(Console.ReadLine());

            switch (wybor)
            {
                case 1: tablica(); break;
                case 2: dodaj_Wpis(); break;
                case 3: zarzadzaj_Profilem(); break;
                default: Console.WriteLine("Blad, nie ma takiej opcji!"); break;
            }

        }
        public static void tablica()
        {
            Console.WriteLine("Tu bedzie tablica jak na facebooku :)");
            Console.ReadKey();
            pisz_Menu();
        }
        public static void dodaj_Wpis()
        {
            Console.WriteLine("Dodaj wpis :)");
            Console.ReadKey();
            pisz_Menu();
        }
        public static void zarzadzaj_Profilem()
        {
            Console.WriteLine("Zarzadzanie profilem :)");
            Console.ReadKey();
            pisz_Menu();
        }
        }
    

} // koniec namespace
