namespace ISO.Server.Models.Dto;

public record Currency
{
    public string? CountryName        { get; init; }
    public string? CurrencyName       { get; init; }
    public string? CurrencySymbol     { get; init; }
    public string? CurrencyCode       { get; init; }
    public string? CurrencyMinorUnits { get; init; }
}

public record DefaultCurrency : Currency
{
    public string NotFoundCode(string code)
        => $"Currency with {nameof(CurrencyCode)} --> {code} not found";

    public string NotFoundSymbol(string symbol)
        => $"Currency with {nameof(CurrencySymbol)} --> {symbol} not found";
}
