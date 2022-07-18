namespace ISO.Server.Models.Dto;

public record Iso
{
    public Iso4217? Iso4217   { get; init; }
    public Iso18245? Iso18245 { get; init; }
}

// ---- ISO 4217 ------ //
public record Iso4217
{
    public string? Published { get; init; }
    public string? Modified  { get; init; }
    public IEnumerable<Currency>? CurrencyEntries { get; init; }
}

// ------ ISO 18245 -------- //
public class Iso18245
{
    public string? Published { get; init; }
    public string? Modified  { get; init; }
    public IEnumerable<MerchantCategory>? MerchantEntries { get; init; }
}