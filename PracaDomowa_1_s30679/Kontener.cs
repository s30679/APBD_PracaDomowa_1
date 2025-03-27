namespace PracaDomowa_1_s30679;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message)
    {
    }
}

public class Kontener
{
    private static HashSet<string> numery_seryjne = new HashSet<string>();
    private double masa_ladunku_kg { get; set; }
    private double wysokosc_kontenera_cm{ get; set; }
    private double waga_wlasna_kontenera_kg{ get; set; }
    private double glebokosc_kontenera_cm{ get; set; }
    private string numer_seryjny { get; set; }
    private double max_ladownosc_kontenera_kg{ get; set; }

    public Kontener(double masaLadunkuKg, double wysokoscKonteneraCm, double wagaWlasnaKonteneraKg, double glebokoscKonteneraCm,double maxLadownoscKonteneraKg)
    {
        masa_ladunku_kg = masaLadunkuKg;
        wysokosc_kontenera_cm = wysokoscKonteneraCm;
        waga_wlasna_kontenera_kg = wagaWlasnaKonteneraKg;
        glebokosc_kontenera_cm = glebokoscKonteneraCm;
        max_ladownosc_kontenera_kg=maxLadownoscKonteneraKg;
    }
    public void oproznianie_ladunku()
    {
        masa_ladunku_kg = 0;
        Console.WriteLine("Ładunek został opróżniony");
    }
    public void zaladowanie(double dokladany_ladunek_kg)
    {
        if (max_ladownosc_kontenera_kg <= (masa_ladunku_kg + dokladany_ladunek_kg))
        {
            masa_ladunku_kg += dokladany_ladunek_kg;
        }
        else
        {
            throw new OverfillException("Nie możesz dodać takiego ładunku, ponieważ przekroczysz ładowność kontenera");
        }
    }
}