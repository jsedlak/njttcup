namespace CupKeeper.Domains.Championships.Model.Parsing;

[GenerateSerializer]
public sealed class ParsedRiderResult
{
    [Id(0)] public string Place { get; set; } = null!;

    [Id(1)] public string Name { get; set; } = null!;

    [Id(2)] public string? License { get; set; }

    [Id(3)] public string? Team { get; set; }

    [Id(4)] public double Time { get; set; }
}