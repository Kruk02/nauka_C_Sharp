using System;
class Program
{ 
    class zwierze
    {
        int wiek;
        string nazwa;
        public zwierze(string nazwa, int wiek) { this.nazwa = nazwa; this.wiek = wiek; }
        public zwierze() { Console.WriteLine("Zwierze utowrzone\n"); }
        public virtual void pisz()
        {
            Console.WriteLine($"{nazwa} lvl{wiek} krzyczy z calych sil !");
        }
    }

    class kot : zwierze {
        string imie;
        int zycia;

        public kot(string imie, int zycia) { this.imie = imie; this.zycia = zycia; }
        public override void pisz()
        {
            Console.WriteLine($"Kot {imie} ma {zycia} zyc !\n");
        }
    }

    class pies : zwierze
    {
        string imie;
        int liczba_zabawek;

        public pies(string imie, int liczba_zabawek) { this.imie = imie; this.liczba_zabawek = liczba_zabawek; }
        public override void pisz()
        {
            Console.WriteLine($"Pies {imie} ma {liczba_zabawek} zabawek !\n");
        }
    }
    static void Main() {
        kot k1 = new kot("Ferdek", 9);
        pies p1 = new pies("Wupi", 100);
        k1.pisz();
        p1.pisz();
    }
}
