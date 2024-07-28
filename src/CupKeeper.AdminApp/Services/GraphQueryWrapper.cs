namespace CupKeeper.AdminApp.Services;

internal sealed class GraphQueryWrapper<TEntity> 
    where TEntity : new() 
{
    public TEntity Data { get; set; } = new();
}