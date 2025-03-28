namespace PracaDomowa_1_s30679;

public class Kontener_chlodniczy : Kontener
{
    private String rodzaj_ladunku { get; set; }
    private double temperatura_wew { get; set; }

    private static Dictionary<String, double> typy_produktow = new Dictionary<string, double>
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        {"Fish",2},
        {"Meat",-15},
        {"Ice Cream",-18},
        {"Frozen pizza",-30},
        {"Cheese",7.2},
        {"Sausages",5},
        {"Butter",20.5},
        {"Eggs",19}
    };
    public Kontener_chlodniczy(String nazwaLadunku, double masaLadunkuKg, double wysokoscKonteneraCm, double wagaWlasnaKonteneraKg, double glebokoscKonteneraCm, double maxLadownoscKonteneraKg, String Rodzaj_ladunku, double TempWew) : base(nazwaLadunku,masaLadunkuKg, wysokoscKonteneraCm, wagaWlasnaKonteneraKg, glebokoscKonteneraCm, maxLadownoscKonteneraKg)
    {
        if (typy_produktow.ContainsKey(Rodzaj_ladunku))
        {
            rodzaj_ladunku = Rodzaj_ladunku;
            if (temperatura_wew <= TempWew)
            {
                temperatura_wew = TempWew;
            }
            else
            {
                temperatura_wew=typy_produktow[Rodzaj_ladunku];   
            }
            int pom_numer_ser = 0;
            for (int i = 0; i < numery_seryjne.Capacity; i++)
            {
                if (numery_seryjne.Contains("KON-C-"+pom_numer_ser))
                {
                    pom_numer_ser++;
                }
            }
            SetNumerSeryjny = "KON-C-" + pom_numer_ser;
            numery_seryjne.Add(GetNumerSeryjny);   
        }
        else
        {
            throw new Exception("Nie mozna dodawac nieistniejacego rodzaju");
        }
    }
}