namespace PracaDomowa_1_s30679;

public class Kontener_na_plyny : Kontener, IHazardNotifier
{
    private bool CzyNiebezpiecznyLadunek { get; set; }
    public Kontener_na_plyny(double masaLadunkuKg, double wysokoscKonteneraCm, double wagaWlasnaKonteneraKg, double glebokoscKonteneraCm, double maxLadownoscKonteneraKg, bool czyNiebezpiecznyLadunek) : base(masaLadunkuKg, wysokoscKonteneraCm, wagaWlasnaKonteneraKg, glebokoscKonteneraCm, maxLadownoscKonteneraKg)
    {
        CzyNiebezpiecznyLadunek = czyNiebezpiecznyLadunek;
        int pom_numer_ser = 0;
        for (int i = 0; i < numery_seryjne.Capacity; i++)
        {
            if (numery_seryjne.Contains("KON-L-"+pom_numer_ser))
            {
                pom_numer_ser++;
            }
        }
        SetNumerSeryjny = "KON-L-" + pom_numer_ser;
        numery_seryjne.Add(GetNumerSeryjny);
    }
    public void ZgloszenieNiebezpieczenstwa()
    {
        Console.WriteLine($"Niebezpieczna sytuacja kontener: "+GetNumerSeryjny);
    }

    public override void zaladowanie(double dokladany_ladunek_kg)
    {
        if (CzyNiebezpiecznyLadunek)
        {
            if (Get_max_ladownosc_kontenera_kg/2 <= (Get_masa_ladunku_kg + dokladany_ladunek_kg))
            {
                Set_masa_ladunku_kg= Get_masa_ladunku_kg+dokladany_ladunek_kg;
            }
            else
            {
                ZgloszenieNiebezpieczenstwa();
            }
        }
        else
        {
            if (Get_max_ladownosc_kontenera_kg*0.9 <= (Get_masa_ladunku_kg + dokladany_ladunek_kg))
            {
                Set_masa_ladunku_kg= Get_masa_ladunku_kg+dokladany_ladunek_kg;
            }
            else
            {
                ZgloszenieNiebezpieczenstwa();
            }   
        }
    }
}