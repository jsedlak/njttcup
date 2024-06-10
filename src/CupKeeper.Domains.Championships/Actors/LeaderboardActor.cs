using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Model;
using Petl.EventSourcing;

namespace CupKeeper.Domains.Championships.Actors;

public class LeaderboardActor : EventSourcedGrain<Leaderboard, AggregateEvent>, ILeaderboardActor
{
    
}