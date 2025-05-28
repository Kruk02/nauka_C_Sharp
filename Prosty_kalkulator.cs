using System;
class Program
{ 
    static void pauza()
    {
        Console.Write("\n\nKliknij dowolny klawisz...");
        Console.ReadKey();
        Console.Clear();
    }
    static int Main()
    {
        do{
            Console.WriteLine("Prosty kalkulator\n");
            Console.Write("Wpisz pierwsza liczbe : ");
            double pierwsza = double.Parse(Console.ReadLine());            
            
            Console.Write("Wpisz druga liczbe : ");
            double druga = double.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Wybierz dzialanie !\n\n[1] Dodawanie \n[2] Odejmowanie \n[3] Mnozenie \n[4] Dzielenie \n[5] Koniec");
            Console.Write("\nWybor : ");
            int wybor = int.Parse(Console.ReadLine());

            switch (wybor){
                case 1:
                    Console.Clear();
                    Console.WriteLine($"{pierwsza} + {druga} = {pierwsza + druga}");
                    pauza();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine($"{pierwsza} - {druga} = {pierwsza - druga}");
                    pauza();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine($"{pierwsza} * {druga} = {pierwsza * druga}");
                    pauza();
                    break;
                case 4:
                    Console.Clear();
                    if (druga == 0) { Console.WriteLine("Nie da sie dzbanie dzielic przez 0 !\nSprobuj ponownie...\n\n"); break; }
                    Console.WriteLine($"{pierwsza} / {druga} = {pierwsza / druga}");
                    pauza();
                    break;
                case 5: return 0;
            }
        }while (true);
    }
}
