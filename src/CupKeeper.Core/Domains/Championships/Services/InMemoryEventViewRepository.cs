using System.Collections.Concurrent;
using CupKeeper.Domains.Championships.ServiceModel;
using CupKeeper.Domains.Championships.ViewModel;

namespace CupKeeper.Domains.Championships.Services;

public class InMemoryEventViewRepository : IEventViewRepository
{
    private static readonly ConcurrentDictionary<Guid, EventViewModel> Events = new();

    public Task<IQueryable<EventViewModel>> QueryAsync()
    {
        return Task.FromResult(
            Events.Values.AsQueryable()
        );
    }

    public Task<EventViewModel?> GetAsync(Guid id)
    {
        Events.TryGetValue(id, out var result);
        return Task.FromResult(result);
    }

    public Task UpsertAsync(EventViewModel viewModel)
    {
        if (!Events.ContainsKey(viewModel.Id))
        {
            Events.TryAdd(viewModel.Id, viewModel);
            return Task.CompletedTask;
        }

        Events.TryRemove(viewModel.Id, out var _);
        Events.TryAdd(viewModel.Id, viewModel);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        Events.TryRemove(id, out var _);
        return Task.CompletedTask;
    }
}