//Wypisywanie na ekran w 3 stylach

using System;
using System.Threading.Channels;

class Program
{ 
    static void Main()
    {
        var imie = "Grzesiu";
        var wiek = 22;
        var kolor = "Niebieski";
        Console.WriteLine("Mam na imie " + imie);
        Console.WriteLine($"Mam {wiek} lat");
        Console.WriteLine("Mój ulubiony kolor to {0}", kolor);
    }
}
