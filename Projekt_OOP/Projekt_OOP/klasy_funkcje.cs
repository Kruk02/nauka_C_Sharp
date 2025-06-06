﻿using System;
namespace Projekt_OOP
{
    public static class Statystyki
    {
        public static int licznik_uzytkownikow = 0;
    }
    public class klasy_funkcje
    {
        public string Tytul { get; set; } = "";
        public int Rok { get; set; }
        public string opinia_txt { get; set; } = "";
        private int ocena;
        public int Ocena {
            get => ocena;
            set
            {
                if(value >= 1 && value <= 10) ocena = value;
            }
        }

        public klasy_funkcje() { }

        public virtual void wypisz()
        {
            Console.WriteLine("Przykladowy tekst do nadpisania");
        }
    }
    public class Film : klasy_funkcje, IWypisz
    {
        public string Rezyser { get; set; } = "";
        public int Godziny { get; set; }
        public int Minuty { get; set; } 
        public string autor_Opini { get; set; } = "";

        public Film(string tyt, int rok, string rez, int h, int min, int ocena)
        {
            Tytul = tyt; Rok = rok; Rezyser = rez; Godziny = h; Minuty = min; Ocena = ocena;
        }
        public Film(string tyt, int rok, int ocena)
        {
            Tytul = tyt; Rok = rok ; Ocena = ocena;
        }
        public Film() { }
        public override void wypisz()
        {
            Console.WriteLine($"{autor_Opini}, {Ocena} / 10");
            Console.WriteLine($"Tytul: {Tytul}, Rezyser: {Rezyser}");
            Console.WriteLine($"Czas trwania : {Godziny}h {Minuty}min");
            Console.WriteLine($"Opinia : {opinia_txt}");
        }
    }
    public class Ksiazka : klasy_funkcje, IWypisz
    {
        public string Autor { get; set; } = "";
        public int Strony { get; set; }
        public string autor_Opini { get; set; } = "";

        public Ksiazka(string tyt, int rok, string Autor, int str, int ocena)
        {
            Tytul = tyt; Rok = rok; this.Autor = Autor; Strony = str; Ocena = ocena;
        }
        public Ksiazka(string tyt, int ocena)
        {
            Tytul = tyt; Ocena = ocena;
        }
        public Ksiazka() { }

        public override void wypisz()
        {
            Console.WriteLine($"{autor_Opini}, {Ocena} / 10");
            Console.WriteLine($"Tytul: {Tytul}, Autor: {Autor}");
            Console.WriteLine($"Liczba stron : {Strony}");
            Console.WriteLine($"Opinia : {opinia_txt}");
        }
    }

    public class Osoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public Osoba()
        {
            Imie = ""; Nazwisko = "";
        }
    }
    public class Uzytkownik : Osoba
    {
        public string Login { get; set; } = "";
        private string haslo;
        public string Haslo
        {
            get => haslo;
            set { if(!string.IsNullOrWhiteSpace(value) && value.Length >= 5) haslo = value; }  
        }
        
        public void ustaw_haslo()
        {
            string nowe_haslo;
            do
            {
                Console.Write("Podaj haslo: ");
                nowe_haslo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nowe_haslo) || nowe_haslo.Length < 5) { Console.WriteLine("Haslo musi miec minimum 5 znakow"); }
            }
            while (string.IsNullOrWhiteSpace(nowe_haslo) || nowe_haslo.Length < 5);
            haslo = nowe_haslo;
        }
        public void zmien_Haslo()
        {
            string nowe_haslo;
            do
            {
                Console.Write("Podaj nowe haslo: ");
                nowe_haslo = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nowe_haslo) || nowe_haslo.Length < 5) { Console.WriteLine("Haslo musi miec minimum 5 znakow !"); }
            } while (string.IsNullOrWhiteSpace(nowe_haslo) || nowe_haslo.Length < 5);
            haslo = nowe_haslo; Console.WriteLine("Haslo zostalo zmienione pomyslnie");
        }
        public void pokaz_haslo()
        {
            Console.WriteLine($"{haslo}");
        }
        public int ID { get; set; }

        public Uzytkownik(){}
    }
    public static class Baza_Danych
    {
        public static List<IWypisz> Wszystkie_Pozycje = new List<IWypisz>();
        public static List<Uzytkownik> Uzytkownicy = new List<Uzytkownik>();
        public static Licznik_Wpisow Licznik = new Licznik_Wpisow();
        public static Film nowy_wpis_f = null;
        public static Ksiazka nowy_wpis_k = null;
        public static Uzytkownik Zalogowany_Uzytkownik = null;
    }

    public interface IWypisz
    {
        void wypisz();
    }
    public struct Licznik_Wpisow
    {
        public int Filmy;
        public int Ksiazki;

        public void Pokaz_Statystyki()
        {
            Console.Clear();
            Console.WriteLine($"Liczba dodanych opini\n Filmow : {Filmy}\n Ksiazek : {Ksiazki}");
            Menu.czekaj_Menu();
        }
    }

    //Funkcje
    public static class Menu
    {
        public static void logowanie()
        {
            Console.WriteLine("Witaj w aplikacji do oceniania Ksiazek i Filmow !");
            Console.WriteLine("[1] Zarejestruj sie \n[2] Zaloguj sie");
            Console.Write("Wybor : ");
            int wybor = int.Parse(Console.ReadLine());
            switch (wybor)
            {
                case 1:
                    Console.Clear();
                    Statystyki.licznik_uzytkownikow++;
                    Uzytkownik u = new Uzytkownik();
                    Console.WriteLine("Wybrales opcje rejestracji nowego konta!");
                    Console.Write("Podaj nazwe uzytkownika : ");
                    u.Login = Console.ReadLine();
                    Console.Write("Podaj imie : ");
                    u.Imie = Console.ReadLine();
                    Console.Write("Podaj nazwisko : ");
                    u.Nazwisko = Console.ReadLine();
                    u.ustaw_haslo();
                    u.ID = Statystyki.licznik_uzytkownikow;
                    Baza_Danych.Uzytkownicy.Add(u);
                    Baza_Danych.Zalogowany_Uzytkownik = u;
                    Console.WriteLine($"Zarejestrowano uzytkownika {u.Login} o ID {u.ID}");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Wybrales logowanie !");
                    Console.Write("Login : ");
                    string login = Console.ReadLine();
                    Console.Write("Haslo : "); 
                    string haslo = Console.ReadLine();
                    Uzytkownik znaleziony = Baza_Danych.Uzytkownicy.Find(u => u.Login == login && u.Haslo == haslo);
                    if (znaleziony != null)
                    {
                        Baza_Danych.Zalogowany_Uzytkownik = znaleziony;
                        Console.WriteLine($"\nZalogowano poprawnie!\n Witaj {znaleziony.Imie} {znaleziony.Nazwisko}");
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Nie znaleziono takiego uzytkownika !\n Jezeli nie masz jeszcze konta - Zarejestruj sie ! \n");
                        logowanie();
                    }
                    break;
            }
            Menu.pisz_Menu();
        } 
        public static void pisz_Poczatek()
        {
            Console.Clear();
            Console.WriteLine("@~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~@");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|                Zaliczenie OOP               |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("@~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~@");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|    System do oceniania filmow i ksiazek !   |");
            Console.WriteLine("|      Oceniaj, pisz opinie i przegladaj      |");
            Console.WriteLine("|         wpisy innych uzytkownikow           |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("@~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~@");
            Console.WriteLine("\nWcisnij dowolny klawisz by kontynuowac...");
            Console.ReadKey();
        } 
        public static void pisz_Menu()
        {
            int wybor;
            do
            {
                Console.Clear();
                Console.WriteLine($"zalogowany uzytkownik : {Baza_Danych.Zalogowany_Uzytkownik?.Login ?? "brak"}");
                Console.WriteLine("[1] Zobacz tablice");
                Console.WriteLine("[2] Dodaj wpis\n");
                Console.WriteLine("[3] Zarzadzaj profilem");
                Console.WriteLine("[4] Pokaz statystyki");

                Console.Write("Wybor : ");
                while (!int.TryParse(Console.ReadLine(), out wybor))
                {
                    Console.WriteLine("Do wyboru sa same cyfry !");
                    Console.Write("Wybor : ");
                }

                switch (wybor)
                {
                    case 1: tablica_Przykladowe(); break;
                    case 2: dodaj_Wpis(); break;
                    case 3: zarzadzaj_Profilem(); break;
                    case 4: Baza_Danych.Licznik.Pokaz_Statystyki(); break;
                    default: Console.WriteLine("Blad, nie ma takiej opcji!"); break;
                }

            } while (wybor != 0);
        } 
        public static void dodaj_Wpis()
        {
            int wybor_wpis;
            Console.Clear();
            Console.WriteLine("Dodaj swoja opinie !");
            Console.WriteLine("Najpierw wybierz czy dodajesz : \n[1] Ksiazke \n[2] Film");
            Console.Write("Wybor : ");
            while (!int.TryParse(Console.ReadLine(), out wybor_wpis))
            {
                Console.WriteLine("Do wyboru sa same cyfry !");
                Console.Write("Wybor : ");
            }

            switch (wybor_wpis)
            {
                case 1:
                    Baza_Danych.nowy_wpis_k = new Ksiazka();
                    Baza_Danych.nowy_wpis_k.autor_Opini = Baza_Danych.Zalogowany_Uzytkownik.Login;
                    Console.Clear();
                    Console.WriteLine("Wybrana opcja : Dodaj ksiazke !");

                    wyswietl_edytowany_wpis_ksiazka();
                    Console.Write("Podaj tytul : ");
                    Baza_Danych.nowy_wpis_k.Tytul = Console.ReadLine();
                    Console.Clear();

                    wyswietl_edytowany_wpis_ksiazka();
                    Console.Write("Podaj autora : ");
                    Baza_Danych.nowy_wpis_k.Autor = Console.ReadLine();
                    Console.Clear();

                    wyswietl_edytowany_wpis_ksiazka();
                    Console.Write("Podaj liczbe stron : ");
                    int strony;
                    while (!int.TryParse(Console.ReadLine(), out strony))
                    {
                        Console.WriteLine("Liczba stron musi byc liczba !");
                        Console.Write("Podaj liczbe stron : ");
                    }
                    Baza_Danych.nowy_wpis_k.Strony = strony;

                    int ocena_k;
                    do
                    {
                        Console.Clear();
                        wyswietl_edytowany_wpis_ksiazka();
                        Console.Write("Podaj swoja ocene (1-10) : ");
                    } while (!int.TryParse(Console.ReadLine(), out ocena_k) || ocena_k < 1 || ocena_k > 10);
                    Baza_Danych.nowy_wpis_k.Ocena = ocena_k;

                    Console.Clear();
                    wyswietl_edytowany_wpis_ksiazka();
                    Console.Write("Napisz swoja opinie: ");
                    Baza_Danych.nowy_wpis_k.opinia_txt = Console.ReadLine();
                    Console.Clear();
                    Baza_Danych.Wszystkie_Pozycje.Add(Baza_Danych.nowy_wpis_k);

                    wyswietl_edytowany_wpis_ksiazka();
                    Baza_Danych.Licznik.Ksiazki++;
                    Console.WriteLine("\nTwoj wpis pojawil sie na tablicy ([1] w menu) ");
                    czekaj_Menu();

                    break;
                case 2:
                    Baza_Danych.nowy_wpis_f = new Film();
                    Baza_Danych.nowy_wpis_f.autor_Opini = Baza_Danych.Zalogowany_Uzytkownik.Login;
                    Console.Clear();
                    Console.WriteLine("Wybrana opcja : Dodaj film !");

                    Console.Clear();
                    wyswietl_edytowany_wpis_film();
                    Console.Write("Podaj tytul : ");
                    Baza_Danych.nowy_wpis_f.Tytul = Console.ReadLine();

                    Console.Clear();
                    wyswietl_edytowany_wpis_film();
                    Console.Write("Podaj rezysera : ");
                    Baza_Danych.nowy_wpis_f.Rezyser = Console.ReadLine();

                    Console.Clear();
                    wyswietl_edytowany_wpis_film();
                    Console.Write("Dlugosc, podaj liczbe godzin : ");
                    int godziny_f;
                    while (!int.TryParse(Console.ReadLine(), out godziny_f))
                    {
                        Console.WriteLine("Liczba godzin musi byc cyfra !");
                        Console.Write("Dlugosc, podaj liczbe godzin : ");
                    }
                    Baza_Danych.nowy_wpis_f.Godziny = godziny_f;

                    Console.Clear();
                    wyswietl_edytowany_wpis_film();
                    Console.Write("Dlugosc, podaj liczbe minut : ");
                    int minuty_f;
                    while (!int.TryParse(Console.ReadLine(), out minuty_f) || minuty_f < 1 || minuty_f > 59)
                    {
                        Console.WriteLine("maksymalna ilosc minut to 59 !");
                        Console.Write("Dlugosc, podaj liczbe minut : ");
                    }
                    Baza_Danych.nowy_wpis_f.Minuty = minuty_f;

                    Console.Clear();
                    wyswietl_edytowany_wpis_film();
                    int ocena_f;
                    do
                    {
                        Console.Clear();
                        wyswietl_edytowany_wpis_film();
                        Console.Write("Podaj swoja ocene (1-10) : ");
                    } while (!int.TryParse(Console.ReadLine(), out ocena_f) || ocena_f < 1 || ocena_f > 10);
                    Baza_Danych.nowy_wpis_f.Ocena = ocena_f;

                    Console.Clear();
                    wyswietl_edytowany_wpis_film();
                    Console.Write("Napisz swoja opinie: ");
                    Baza_Danych.nowy_wpis_f.opinia_txt = Console.ReadLine();
                    Console.Clear();
                    Baza_Danych.Wszystkie_Pozycje.Add(Baza_Danych.nowy_wpis_f);

                    wyswietl_edytowany_wpis_film();
                    Baza_Danych.Licznik.Filmy++;
                    Console.WriteLine("\nTwoj wpis pojawil sie na tablicy ([1] w menu) \n");
                    czekaj_Menu();

                    break;
            }

            Console.ReadKey();
            pisz_Menu();
        }
        public static void zarzadzaj_Profilem()
        {
            Console.Clear();
            Console.WriteLine("Zarzadzanie profilem\n");
            Console.WriteLine($"Zalogowany uzytkownik : {Baza_Danych.Zalogowany_Uzytkownik?.Login?? "Brak"}");
            Console.WriteLine("Wybierz co chcesz zmienic\n");
            Console.WriteLine($"[1] Imie = {Baza_Danych.Zalogowany_Uzytkownik?.Imie?? "brak"} \n[2] Nazwisko = {Baza_Danych.Zalogowany_Uzytkownik?.Nazwisko?? "brak"}");
            Console.WriteLine($"[3] Login = {Baza_Danych.Zalogowany_Uzytkownik?.Login ?? "brak"}\n[4] Haslo = {Baza_Danych.Zalogowany_Uzytkownik?.Haslo?? "brak"}");
            Console.WriteLine("\n[8] Lista zarejestrowanych kont \n[9] Wyloguj \n[0] Powrot");
            int zarzadzaj_profilem_wybor;
            Console.Write("\nWybor : ");
            while (!int.TryParse(Console.ReadLine(), out zarzadzaj_profilem_wybor))
            {
                Console.WriteLine("Do wyboru sa same cyfry !");
                Console.Write("Wybor : ");
            }

            switch (zarzadzaj_profilem_wybor)
            {
                case 1:
                    Console.Write("Wpisz swoje nowe imie : "); string nowe1 = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nowe1))
                    {
                        Console.WriteLine("Imie nie moze byc puste!"); czekaj_Profil();
                    }
                    else
                    {
                        Baza_Danych.Zalogowany_Uzytkownik.Imie = nowe1; Console.WriteLine("Zmieniono pomyslnie !"); czekaj_Profil();
                    }
                    break;

                case 2:
                    Console.Write("Wpisz swoje nowe Nazwisko : "); string nowe2 = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nowe2))
                    {
                        Console.WriteLine("Nazwisko nie moze byc puste!"); czekaj_Profil();
                    }
                    else
                    {
                        Baza_Danych.Zalogowany_Uzytkownik.Nazwisko = nowe2; Console.WriteLine("Zmieniono pomyslnie !"); czekaj_Profil();
                    }
                    break;
                case 3:
                    Console.Write("Wpisz swoj nowy login : "); string nowe3 = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nowe3))
                    {
                        Console.WriteLine("Login nie moze byc pusty !"); czekaj_Profil();
                    }
                    else
                    {
                        Baza_Danych.Zalogowany_Uzytkownik.Login = nowe3; Console.WriteLine("Zmieniono pomyslnie !"); czekaj_Profil();
                    }
                    break; 
                case 4:
                    Baza_Danych.Zalogowany_Uzytkownik.zmien_Haslo(); czekaj_Profil(); break;
                case 8: Console.Clear(); wypisz_Uzytkownikow(); break;
                case 9: Baza_Danych.Zalogowany_Uzytkownik = null; Console.Clear(); logowanie(); break;
                case 0: Console.Clear(); Menu.pisz_Menu(); break;
                default: Console.WriteLine("Nie ma takiej opcji !"); Console.Clear(); zarzadzaj_Profilem(); break;
            }
            Console.WriteLine("Nacisnij dowolny klawisz by wroci do menu  . . ."); Console.ReadKey(); pisz_Menu();
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

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby wrócić..."); Console.ReadKey(); pisz_Menu();
        } 

        public static void tablica_Przykladowe()
        {
            //Tablica opini uzytkownikow, symuluje to jak aplikacja moglaby wygladac w rzeczywistosci
            //Wszystkie przyklady, opinie i opisy sa przykładowe
        Console.WriteLine("User01, 10 / 10");
        Console.WriteLine("Tytul : \"Skazani na Shawshank\" Rezyser : Frank Darabont");
        Console.WriteLine("Opinia : Mistrzostwo! Takie filmy powinny być obowiązkowe do obejrzenia!.");
            Console.WriteLine("----------------------------------------------------------------------------------------");
        Console.WriteLine("User02, 8 / 10");
        Console.WriteLine("Tytul : \"Zielona mila\" Rezyser : Frank Darabont");
        Console.WriteLine("Opinia : Płakałem jak dziecko. Ten film łamie serce i skleja je z powrotem");
            Console.WriteLine("----------------------------------------------------------------------------------------");
        Console.WriteLine("User03, 4 / 10");
        Console.WriteLine("Tytul : \"Dziady cz.III\" Autor : Adam Mickiewicz");
        Console.WriteLine("Opinia : Ciężko przebrnąć. Dużo symboli, odniesień historycznych i mistyki \ntrudno się wczuć, a język momentami nieczytelny.");
            Console.WriteLine("----------------------------------------------------------------------------------------");
        Console.WriteLine("User04, 8 / 10");
        Console.WriteLine("Tytul : \"Nietykalni\" Rezyser : Olivier Nakache, Éric Toledano");
        Console.WriteLine("Opinia : Śmiałem się i wzruszałem. Chemia między bohaterami to złoto!");
            Console.WriteLine("----------------------------------------------------------------------------------------");
        Console.WriteLine("User05, 8 / 10");
        Console.WriteLine("Tytul : \"Ojciec chrzestny\" Rezyser: Francis Ford Coppola");
        Console.WriteLine("Opinia : Ten klimat, ta muzyka... klasyka mafijna, która nigdy się nie zestarzeje.");
            Console.WriteLine("----------------------------------------------------------------------------------------");
        Console.WriteLine("User06, 9 / 10");
        Console.WriteLine("Tytul : \"Lalka\" Autor : Boleslaw Prus");
        Console.WriteLine("Opinia : Doceniam realizm, ale narracja była nużąca. Wokulski jako bohater mnie nie przekonał, \n\tcałość ciągnie się jak flaki z olejem.");
        Console.WriteLine("----------------------------------------------------------------------------------------");
            tablica_Uzytkownika();
            Console.ReadKey();
        } 
        public static void tablica_Uzytkownika()
        {
            foreach (var wpis in Baza_Danych.Wszystkie_Pozycje)
            {
                wpis.wypisz();
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }
        }
        public static void czekaj_Profil()
        { System.Threading.Thread.Sleep(2000); Console.Clear(); zarzadzaj_Profilem(); } 
        public static void czekaj_Menu()
        {
            Console.Write("Wcisnij dowolny klawisz zeby wrocic do menu . . .");
            Console.ReadKey();
            pisz_Menu();
        }

        public static void wyswietl_edytowany_wpis_film()
        {
            var film = Baza_Danych.nowy_wpis_f;
            Console.WriteLine($"Tytuł : {Baza_Danych.nowy_wpis_f?.Tytul?? "......."} \t,rez. {Baza_Danych.nowy_wpis_f?.Rezyser?? "......."}");
            Console.WriteLine($"Czas trwania: {(Baza_Danych.nowy_wpis_f?.Godziny > 0 || Baza_Danych.nowy_wpis_f?.Minuty > 0 ? $"{Baza_Danych.nowy_wpis_f?.Godziny?? 0}h " +
                $"{Baza_Danych.nowy_wpis_f?.Minuty?? 0}min" : ".......")} " + $"Ocena: {(Baza_Danych.nowy_wpis_f?.Ocena > 0 ? $"{Baza_Danych.nowy_wpis_f.Ocena}/10" : ".......")}");
            Console.WriteLine($"Opinia : {Baza_Danych.nowy_wpis_f?.opinia_txt?? "......."}");
        }
        public static void wyswietl_edytowany_wpis_ksiazka()
        {
            var ksiazka = Baza_Danych.nowy_wpis_k;
            Console.WriteLine($"Tytuł: {Baza_Danych.nowy_wpis_k?.Tytul?? "......."} \t,autor: {Baza_Danych.nowy_wpis_k?.Autor?? "......."}");
            Console.WriteLine( $"Liczba stron: {(Baza_Danych.nowy_wpis_k?.Strony > 0 ? $"{Baza_Danych.nowy_wpis_k.Strony}" : ".......")} " +
                $"Ocena: {(Baza_Danych.nowy_wpis_k?.Ocena > 0 ? $"{Baza_Danych.nowy_wpis_k.Ocena}/10" : ".......")}");
            Console.WriteLine($"Opinia: {Baza_Danych.nowy_wpis_k?.opinia_txt?? "......."}");
        }
    }
}