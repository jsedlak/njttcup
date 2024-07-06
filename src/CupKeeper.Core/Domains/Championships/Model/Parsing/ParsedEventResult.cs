namespace CupKeeper.Domains.Championships.Model.Parsing;

[GenerateSerializer]
public class ParsedEventResult
{
    [Id(0)] public string Identifier { get; set; } = null!;
    
    [Id(1)] public ParsedCategoryResult[] Categories { get; set; } = [];
}