using System;
class Program
{ 
    class osoba
    {
        string imie;
        int wiek;

        public void przedstaw_sie()
        {
            Console.WriteLine($"Czesc, mam na imie {imie} i mam {wiek} lata");
        }

        public osoba(string i, int w) { imie = i; wiek = w; }
    }
    static void Main() {
        osoba o1 = new osoba("Grzesiu", 23);
        o1.przedstaw_sie();
    }
}
