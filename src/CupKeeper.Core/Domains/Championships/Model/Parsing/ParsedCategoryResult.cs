namespace CupKeeper.Domains.Championships.Model.Parsing;

[GenerateSerializer]
public sealed class ParsedCategoryResult
{
    [Id(0)]
    public string Name { get; set; } = null!;

    [Id(1)]
    public ParsedRiderResult[] Results { get; set; } = [];
}