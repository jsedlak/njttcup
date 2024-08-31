using System.Linq.Expressions;
using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Model;

namespace CupKeeper.Domains.Championships.ServiceModel;

public interface IRiderLocatorService
{
    Task<Rider> GetAsync(string name, string? teamName, string? license);

    Task<Rider> GetAsync(Guid riderId);
}