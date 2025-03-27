namespace PracaDomowa_1_s30679;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message)
    {
    }
}

public class Kontener
{
    public static HashSet<string> numery_seryjne = new HashSet<string>();
    private double masa_ladunku_kg;
    public double Get_masa_ladunku_kg
    {
        get { return masa_ladunku_kg; }
    }
    public double Set_masa_ladunku_kg
    {
        set { masa_ladunku_kg = value; }
    }
    private double wysokosc_kontenera_cm{ get; set; }
    private double waga_wlasna_kontenera_kg{ get; set; }
    private double glebokosc_kontenera_cm{ get; set; }
    private string numer_seryjny { get; set; }

    public string GetNumerSeryjny
    {
        get { return numer_seryjny; }
    }
    public string SetNumerSeryjny
    {
        set
        {
            numer_seryjny = value; 
        }
    }
    private double max_ladownosc_kontenera_kg{ get; set; }

    public double Get_max_ladownosc_kontenera_kg
    {
        get { return max_ladownosc_kontenera_kg; }
    }
    public double Set_max_ladownosc_kontenera_kg
    {
        set { max_ladownosc_kontenera_kg = value; }
    }
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
    public virtual void zaladowanie(double dokladany_ladunek_kg)
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