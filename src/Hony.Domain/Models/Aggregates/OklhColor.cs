namespace Hony.Domain.Models.Aggregates;

public sealed class OklhColor
{
    public required float L { get; set; }
    public required float C { get; set; }
    public required float H { get; set; }
    public required float? A { get; set; }
}