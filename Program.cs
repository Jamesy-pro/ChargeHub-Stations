using System;
using System.Collections.Generic; // Behövs för att kunna använda List<>

public class ChargingStation : IReportable
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
    } // <-- Här slutar konstruktorn!

    // GetReport() ligger nu utanför konstruktorn, direkt i klassen:
    public string GetReport()
    {
        return $"Station {Id}: {MaxKw} kW";
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
        // Här i Main skapar vi listan med både bil och laddstationer
        List<IReportable> reportables = new List<IReportable>
        {
            new Vehicle { Id = 1, BatteryKwh = 75 },
            new ChargingStation("AC-01", 11),
            new ChargingStation("DC-01", 150)
        };

        // Och här loopar vi igenom listan och skriver ut varje rapport
        foreach (IReportable item in reportables)
        {
            Console.WriteLine(item.GetReport());
        }
    }
}