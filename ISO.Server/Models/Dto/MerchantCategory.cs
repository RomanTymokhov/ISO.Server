namespace ISO.Server.Models.Dto;

public record MerchantCategory
{
    public string? MerchantCategoryCode { get; init; }
    public string? EditedDescription    { get; init; }
    public string? CombinedDescription  { get; init; }
    public string? UsdaDescription      { get; init; }
    public string? IrsDescription       { get; init; }
    public string? IrsReportable        { get; init; }
}

public record DefaultMerchantCategory : MerchantCategory
{
    public string NotFoundCategory(string code)
        => $"MerchantCategory with {nameof(MerchantCategoryCode)} --> {code} not found";
}
