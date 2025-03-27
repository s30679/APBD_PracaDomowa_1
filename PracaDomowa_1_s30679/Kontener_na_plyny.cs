namespace PracaDomowa_1_s30679;

public class Kontener_na_plyny : Kontener, IHazardNotifier
{
    private bool CzyNiebezpiecznyLadunek { get; set; }
    public Kontener_na_plyny(double masaLadunkuKg, double wysokoscKonteneraCm, double wagaWlasnaKonteneraKg, double glebokoscKonteneraCm, double maxLadownoscKonteneraKg, bool czyNiebezpiecznyLadunek) : base(masaLadunkuKg, wysokoscKonteneraCm, wagaWlasnaKonteneraKg, glebokoscKonteneraCm, maxLadownoscKonteneraKg)
    {
        czyNiebezpiecznyLadunek = czyNiebezpiecznyLadunek;
        int pom_numer_ser = 0;
        for (int i = 0; i < numery_seryjne.Capacity; i++)
        {
            pom_numer_ser++;
        }
        SetNumerSeryjny = "KON-L-" + pom_numer_ser;
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