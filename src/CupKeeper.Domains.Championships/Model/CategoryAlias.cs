namespace CupKeeper.Domains.Championships.Model;

public class CategoryAlias
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;
    
    public IEnumerable<string> Aliases { get; set; } = [];
}