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
}

class Program
{
    static void Main(string[] args)
    {
        // Vi fyller i testkoden här i Steg 4
    }
}