public class Vehicle : IReportable
{
    public int Id { get; set; }
    public double BatteryKwh { get; set; }
    public int Percent { get; set; }

    public double EnergyNeeded()
    {
        return BatteryKwh * (100 - Percent) / 100.0;
    }

    public string GetReport()
    {
        return $"Bil {Id}: {Percent} %";
    }
}