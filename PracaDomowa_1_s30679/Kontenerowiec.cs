namespace PracaDomowa_1_s30679;

public class Kontenerowiec
{
    public static HashSet<string> kontenery = new HashSet<string>();
    public static List<Kontener> konteneryWszystkieIstniejace = new List<Kontener>();
    public List<Kontener> konteneryNaStatku = new List<Kontener>();
    private double max_predkosc{get;set;}
    private int max_kontenerow{get;set;}
    private double max_waga_kontenerow_lacznie{get;set;}

    public Kontenerowiec(double Max_predkosc, int maxKontenerow, double max_waga)
    {
        max_predkosc = Max_predkosc;
        max_kontenerow = maxKontenerow;
        max_waga_kontenerow_lacznie= max_waga;
    }

    public void StworzKontenerL(String nazwaLadunku,double masaLadunkuKg, double wysokoscKonteneraCm, double wagaWlasnaKonteneraKg, double glebokoscKonteneraCm, double maxLadownoscKonteneraKg, bool czyNiebezpiecznyLadunek)
    {
        Kontener_na_plyny a = new Kontener_na_plyny(nazwaLadunku,masaLadunkuKg, wysokoscKonteneraCm, wagaWlasnaKonteneraKg, glebokoscKonteneraCm, maxLadownoscKonteneraKg, czyNiebezpiecznyLadunek);
        kontenery.Add(a.GetNumerSeryjny);
        konteneryWszystkieIstniejace.Add(a);
    }
    public void StworzKontenerG(String nazwaLadunku, double masaLadunkuKg, double wysokoscKonteneraCm, double wagaWlasnaKonteneraKg, double glebokoscKonteneraCm, double maxLadownoscKonteneraKg, double cisnienieWAtmosferach)
    {
        Kontener_na_gaz a = new Kontener_na_gaz(nazwaLadunku,  masaLadunkuKg, wysokoscKonteneraCm, wagaWlasnaKonteneraKg, glebokoscKonteneraCm, maxLadownoscKonteneraKg, cisnienieWAtmosferach);
        kontenery.Add(a.GetNumerSeryjny);
        konteneryWszystkieIstniejace.Add(a);
    }

    public void StworzKontenerC(String nazwaLadunku, double masaLadunkuKg, double wysokoscKonteneraCm,
        double wagaWlasnaKonteneraKg, double glebokoscKonteneraCm, double maxLadownoscKonteneraKg,
        String Rodzaj_ladunku, double Temperatura_wew)
    {
        Kontener_chlodniczy a = new Kontener_chlodniczy(nazwaLadunku, masaLadunkuKg, wysokoscKonteneraCm,
            wagaWlasnaKonteneraKg, glebokoscKonteneraCm, maxLadownoscKonteneraKg, Rodzaj_ladunku, Temperatura_wew);
        kontenery.Add(a.GetNumerSeryjny);
        konteneryWszystkieIstniejace.Add(a);
    }

    public void ZaladujLadunekKontener(Kontener k, double dokladany_ladunek)
    {
        double waga = 0;
        foreach(Kontener kk in konteneryNaStatku)
        {
            waga += kk.Get_masa_ladunku_kg;
        }

        if (waga <= max_waga_kontenerow_lacznie + dokladany_ladunek)
        {
            k.zaladowanie(dokladany_ladunek);   
        }
        else
        {
            Console.WriteLine("Nie zmieszcze wiecej");
        }
    }

    public void ZaladowanieKonteneraNaStatek(Kontener k)
    {
        if (konteneryNaStatku.Count < max_kontenerow)
        {
            konteneryNaStatku.Add(k);  
            Console.WriteLine("Zaladowane!!");
        }
        else
        {
            Console.WriteLine("Nie zmieszcze wiecej, juz mam max");
        }
    }
    public void UsuniecieKonteneraZEStatku(Kontener k)
    {
        if (konteneryNaStatku.Contains(k))
        {
            konteneryNaStatku.Remove(k);
            Console.WriteLine("Usuniety");
        }
        else
        {
            Console.WriteLine("Nie mam takiego na tym statku");
        }
    }

    public void RozladowanieKontenera(Kontener k)
    {
        k.oproznianie_ladunku();
    }

    public void Zastapienie_kontenera(String nazwaKontenera, Kontener k)
    {
        double waga = 0;
        foreach(Kontener kk in konteneryNaStatku)
        {
            waga += kk.Get_masa_ladunku_kg;
        }
        foreach (Kontener kk in konteneryNaStatku)
        {
            if (kk.GetNumerSeryjny == nazwaKontenera && waga+k.Get_masa_ladunku_kg-kk.Get_masa_ladunku_kg<max_waga_kontenerow_lacznie)
            {
                konteneryNaStatku.Remove(kk);
                konteneryNaStatku.Add(k);
            }
        }
        Console.WriteLine("Zastapiony");
    }

    public void przeniesKontener(Kontener k, Kontenerowiec Kontenerowiec_do_ktorego)
    {
        if (Kontenerowiec_do_ktorego.konteneryNaStatku.Count < Kontenerowiec_do_ktorego.max_kontenerow)
        {
            konteneryNaStatku.Remove(k);
            Kontenerowiec_do_ktorego.konteneryNaStatku.Add(k);   
            Console.WriteLine("Przeniesiony");
        }
        else
        {
            Console.WriteLine("Nie przeniosę bo ten na który chcesz przenieść jest pełny");
        }
    }
    public void Wypisanie_informacji_o_danym_kontenerze(Kontener k)
    {
        Console.WriteLine("Informacje o kontenerze: "+k.GetNumerSeryjny+" Masa ladunku: "+k.Get_masa_ladunku_kg, " Max ladownosc: ",k.Get_max_ladownosc_kontenera_kg);
    }
    public void Wypisanie_informacji_o_danym_statku(Kontenerowiec k)
    {
        Console.WriteLine("Informacje o statku: "+" V max: "+ k.max_predkosc+" Max kontenerow: "+ k.max_kontenerow+ " Max ladownosc: "+k.max_waga_kontenerow_lacznie);
        foreach(Kontener kk in k.konteneryNaStatku)
        {
            Console.WriteLine("Ladunek: "+kk.GetNumerSeryjny);
        }       
    }
}