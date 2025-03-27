namespace PracaDomowa_1_s30679;

public class Kontener_na_gaz : Kontener
{
    private double CisnienieWAtmosferach { get; set; }

    public Kontener_na_gaz(double masaLadunkuKg, double wysokoscKonteneraCm, double wagaWlasnaKonteneraKg, double glebokoscKonteneraCm, double maxLadownoscKonteneraKg, double cisnienieWAtmosferach) : base(masaLadunkuKg, wysokoscKonteneraCm, wagaWlasnaKonteneraKg, glebokoscKonteneraCm, maxLadownoscKonteneraKg)
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
}