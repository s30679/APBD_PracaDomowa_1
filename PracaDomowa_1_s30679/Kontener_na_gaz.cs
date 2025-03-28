namespace PracaDomowa_1_s30679;

public class Kontener_na_gaz : Kontener, IHazardNotifier
{
    private double CisnienieWAtmosferach { get; set; }

    public Kontener_na_gaz(String nazwaLadunku, double masaLadunkuKg, double wysokoscKonteneraCm, double wagaWlasnaKonteneraKg, double glebokoscKonteneraCm, double maxLadownoscKonteneraKg, double cisnienieWAtmosferach) : base(nazwaLadunku,masaLadunkuKg, wysokoscKonteneraCm, wagaWlasnaKonteneraKg, glebokoscKonteneraCm, maxLadownoscKonteneraKg)
    {
        CisnienieWAtmosferach = cisnienieWAtmosferach;
        int pom_numer_ser = 0;
        for (int i = 0; i < numery_seryjne.Capacity; i++)
        {
            if (numery_seryjne.Contains("KON-G-"+pom_numer_ser))
            {
                pom_numer_ser++;
            }
        }
        SetNumerSeryjny = "KON-G-" + pom_numer_ser;
        numery_seryjne.Add(GetNumerSeryjny);
    }
    public void ZgloszenieNiebezpieczenstwa()
    {
        Console.WriteLine($"Niebezpieczna sytuacja kontener: "+GetNumerSeryjny);
    }

    public override void oproznianie_ladunku()
    {
        Set_masa_ladunku_kg = Get_masa_ladunku_kg * 0.05;
    }

    public override void zaladowanie(double dokladany_ladunek_kg)
    {
        if (Get_max_ladownosc_kontenera_kg <= (Get_masa_ladunku_kg + dokladany_ladunek_kg))
        {
            Set_masa_ladunku_kg = Get_masa_ladunku_kg+dokladany_ladunek_kg;
        }
        else
        {
            ZgloszenieNiebezpieczenstwa();
            throw new OverfillException("Nie możesz dodać takiego ładunku, ponieważ przekroczysz ładowność kontenera");
        }
    }
}