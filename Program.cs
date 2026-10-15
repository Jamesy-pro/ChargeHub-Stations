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

    // NY KOD FÖR STEG 3:
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
        // Vi fyller i testkoden här i Steg 4
    }
}