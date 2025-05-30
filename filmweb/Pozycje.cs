using System;
using System.Security.Cryptography.X509Certificates;
namespace Projekt_OOP
{
    public static class Statystyki
    {
        public static int licznik_filmow = 0;
        public static int licznik_ksiazek = 0;
        public static int licznik_uzytkownikow = 0;
    }
    public class Pozycja
    {
        public string Tytul { get; set; }
        public int Rok { get; set; }
        public int Ocena { get; set; }

        public Pozycja()
        {
            Tytul = "";
        }

        public virtual void wypisz()
        {
            Console.WriteLine("Przykladowy tekst do nadpisania");
        }
    }
    public class Film : Pozycja
    {
        public string Rezyser { get; set; }
        public int Godziny { get; set; }
        public int Minuty { get; set; } //czas trwania

        public Film(string tyt, int rok, string rez, int h, int min, int ocena)
        {
            Tytul = tyt; Rok = rok; Rezyser = rez; Godziny = h; Minuty = min; Ocena = ocena;
        }

        public override void wypisz()
        {
            Console.WriteLine($"Tytul: {Tytul}\nRok : {Rok} \nRezyser: {Rezyser} \nCzas trwania {Godziny}h {Minuty}min\n Ocena : {Ocena}");
        }
    }
    public class Ksiazka : Pozycja
    {
        public string Autor { get; set; }
        public int Strony { get; set; }

        public Ksiazka(string tyt, int rok, string Autor, int str, int ocena)
        {
            Tytul = tyt; Rok = rok; this.Autor = Autor; Strony = str; Ocena = ocena;
        }

        public override void wypisz()
        {
            Console.WriteLine($"Tytul: {Tytul}\nRok : {Rok} \nAutor: {Autor} \nLiczba stron: {Strony}\n Ocena : {Ocena}");
        }
    }

    public class Osoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Oceny { get; set; } //ilosc wystawionych ocen // dodac srednia ocen


        public Osoba()
        {
            Imie = ""; Nazwisko = "";
        }
    }
    public class Uzytkownik : Osoba
    {
        public string Login { get; set; }
        public string Haslo { get; set; }
        public int ID { get; set; }

        public Uzytkownik()
        {
            Login = "admin"; Haslo = "admin";
        }
    }
    public static class Baza_Danych
    {
        public static List<Uzytkownik> Uzytkownicy = new List<Uzytkownik>();
        public static List<Ksiazka> Ksiazki = new List<Ksiazka>();
        public static List<Film> Filmy = new List<Film>();
        public static Uzytkownik Zalogowany_Uzytkownik = null;
    }
    //Funkcje
    public static class Menu
    {
        public static void logowanie()
        {
            Console.WriteLine("[1] Zarejestruj sie \n[2] Zaloguj sie");
            Console.Write("Wybor : ");
            int wybor = int.Parse(Console.ReadLine());
            switch (wybor)
            {
                case 1:
                    Statystyki.licznik_uzytkownikow++;
                    Uzytkownik u = new Uzytkownik();
                    Console.WriteLine("Wybrales opcje rejestracji nowego konta!");
                    Console.Write("Podaj nazwe uzytkownika : ");
                    u.Login = Console.ReadLine();
                    Console.Write("Podaj imie : ");
                    u.Imie = Console.ReadLine();
                    Console.Write("Podaj nazwisk : ");
                    u.Nazwisko = Console.ReadLine();
                    Console.Write("Podaj haslo : ");
                    u.Haslo = Console.ReadLine();
                    u.ID = Statystyki.licznik_uzytkownikow;
                    Baza_Danych.Uzytkownicy.Add(u);
                    Console.WriteLine($"Zarejestrowano uzytkownika {u.Login} o ID {u.ID}");
                    break;
                case 2:
                    Console.WriteLine("Wybrales logowanie !");
                    Console.Write("Login : "); //czytanie loginu, dodac w clasie
                    string login = Console.ReadLine();
                    Console.Write("Haslo : "); //czytanie hasla, dodac w clasie
                    string haslo = Console.ReadLine();
                    Uzytkownik znaleziony = Baza_Danych.Uzytkownicy.Find(u => u.Login == login && u.Haslo == haslo);
                    if (znaleziony != null)
                    {
                        Baza_Danych.Zalogowany_Uzytkownik = znaleziony;
                        Console.WriteLine($"\nZalogowano poprawnie!\n Witaj {znaleziony.Imie} {znaleziony.Nazwisko}");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Nie znaleziono takiego uzytkownika !\n Sprobuj ponownie ");
                        logowanie();
                    }
                    break;
            }
        }
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
            Console.WriteLine("|        wpisy innych uzytkownikow           |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("@~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~@");
            Console.WriteLine("\nWcisnij dowolny klawisz by kontynuowac...");
            Console.ReadKey();
            pisz_Menu();
        }
        public static void pisz_Menu()
        {
            Console.Clear();
            Console.WriteLine($"zalogowany uzytkownik : {Baza_Danych.Zalogowany_Uzytkownik}");
            Console.WriteLine("[1] Zobacz tablice"); //wygenerowane wpisy (z 10 gotowych i random+switch+wyswietlanie ich pod soba)
            Console.WriteLine("[2] Dodaj wpis");
            Console.WriteLine("[3] Zarzadzaj profilem"); //zmien nazwe_uzytkownika, zmien haslo ? 
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

        public static void wypisz_Uzytkownikow()
        {
            Console.Clear();
            Console.WriteLine("Lista zarejestrowanych użytkowników:\n");
            Console.WriteLine("{0,-5} {1,-10} {2,-12} {3,-12}", "ID", "Login", "Imie", "Nazwisko");

            foreach (var u in Baza_Danych.Uzytkownicy)
            {
                Console.WriteLine("{0,-5} {1,-10} {2,-12} {3,-12}",u.ID, u.Login, u.Imie, u.Nazwisko);
            }

            Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić...");
            Console.ReadKey();
            pisz_Menu();
        }

        public static void tablica_przykladowe()
        {
        Console.WriteLine("Nazwa urzytkownika : user01");
        Console.WriteLine("Ocenil film Skazani na Shawshank rez. Frank Darabont na 9/10");
        Console.WriteLine("Mistrzostwo! Oglądałem z otwartą buzią. Takie filmy powinny być lekturą obowiązkową.");
            Console.WriteLine("");
        Console.WriteLine("Nazwa urzytkownika : user02");
        Console.WriteLine("Ocenil film Zielona mila rez. Frank Darabont na 8/10");
        Console.WriteLine("Płakałem jak dziecko. Ten film łamie serce i skleja je z powrotem");
            Console.WriteLine("");
        Console.WriteLine("Nazwa urzytkownika : user03");
        Console.WriteLine("Ocenil ksiazke Dziady cz.III - Adam Mickiewicz na 4/10");
        Console.WriteLine("Ciężko przebrnąć. Dużo symboli, odniesień historycznych i mistyki \ntrudno się wczuć, a język momentami nieczytelny.");
            Console.WriteLine("");
        Console.WriteLine("Nazwa urzytkownika : user04");
        Console.WriteLine("Ocenil film Nietykalni rez. Olivier Nakache, Éric Toledano na 8/10");
        Console.WriteLine("Śmiałem się i wzruszałem. Chemia między bohaterami to złoto!");
            Console.WriteLine("");
        Console.WriteLine("Nazwa urzytkownika : user05");
        Console.WriteLine("Ocenil film Ojciec chrzestny rez. Francis Ford Coppola na 9/10");
        Console.WriteLine("Ten klimat, ta muzyka... klasyka mafijna, która nigdy się nie zestarzeje.");
            Console.WriteLine("");
        Console.WriteLine("Nazwa urzytkownika : user06");
        Console.WriteLine("Ocenil ksiazke Lalka - Boleslaw Prus na 9/10");
        Console.WriteLine("Doceniam realizm, ale narracja była nużąca. Wokulski jako bohater mnie nie przekonał, \ncałość ciągnie się jak flaki z olejem.");
        }
    }
}// koniec namespace
