//kalkulator wieku z poprawna koncowka

using System;
using System.Threading.Channels;

class Program
{ 
    static void Main()
    {
        do{
            int aktualny_rok = 2025;
            Console.WriteLine("Oblicze ile masz lat!");
            Console.Write("Wpisz rok urodzenia: ");
            var input = int.Parse(Console.ReadLine());
            string koncowka;
            int wynik = aktualny_rok - input;
            if(wynik == 1) { koncowka = "rok"; }
            else if (wynik >= 2 && wynik <= 4) { koncowka = "lata"; }
            else if (wynik >= 12 && wynik <= 14) { koncowka = "lat"; }
            else if(wynik%10 >= 2 && wynik%10 <= 4) { koncowka = "lata"; }
            else { koncowka = "lat"; }
            Console.WriteLine($"Masz {wynik} {koncowka}"); Console.WriteLine();
        }while (true);
    }
}
