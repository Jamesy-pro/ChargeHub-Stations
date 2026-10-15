using System;

public class ChargingStation
{
    public string Id { get; }
    public double MaxKw { get; }
    public bool IsAvailable { get; private set; } = true;

    public ChargingStation(string id, double maxKw)
    {
        if (maxKw <= 0)
        {
            throw new ArgumentException("MaxKw måste vara större än 0.");
        }

        Id = id;
        MaxKw = maxKw;
    }

    public void StartCharging()
    {
        if (!IsAvailable)
        {
            throw new InvalidOperationException("Kan inte starta laddning: Stationen är redan upptagen!");
        }

        IsAvailable = false;
    }

    public void StopCharging()
    {
        IsAvailable = true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Skapa station AC-01 med 11 kW
        var station = new ChargingStation("AC-01", 11);

        try
        {
            Console.WriteLine($"Startar första laddningen på {station.Id} ({station.MaxKw} kW)...");
            station.StartCharging();
            Console.WriteLine($"Laddning igång! Är stationen ledig? {station.IsAvailable}");

            Console.WriteLine("Försöker starta en andra laddning samtidigt...");
            station.StartCharging(); // Här kommer det smälla!
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Fel fångat: {ex.Message}");
        }
    }
}