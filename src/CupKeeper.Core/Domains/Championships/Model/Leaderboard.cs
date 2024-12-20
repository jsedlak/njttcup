﻿using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Events.Leaderboards;
using CupKeeper.Domains.Championships.Events.ScheduledEvents;

namespace CupKeeper.Domains.Championships.Model;

/// <summary>
/// Represents the complete championship rollup of results into a single leaderboard
/// </summary>
[GenerateSerializer]
public sealed class Leaderboard : IAggregateRoot
{
    /// <summary>
    /// Gets or Sets the unique identifier of the leaderboard
    /// </summary>
    [Id(0)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or Sets the year this leaderboard represents
    /// </summary>
    [Id(1)]
    public int Year { get; set; }

    /// <summary>
    /// Gets or Sets the list of result identifiers that make up this leaderboard
    /// </summary>
    [Id(2)]
    public Guid[] EventResultIds { get; set; } = [];

    /// <summary>
    /// Gets or Sets the list of category leaderboards that form the master leaderboard
    /// </summary>
    [Id(3)]
    public CategoryLeaderboard[] Categories { get; set; } = Array.Empty<CategoryLeaderboard>();

    /// <summary>
    /// Gets or Sets whether the leaderboard is deleted and is ready to be permanently removes
    /// </summary>
    [Id(4)]
    public bool IsDeleted { get; set; }
    
    [Id(5)]
    public bool IsPublished { get; set; }

    public void Apply(LeaderboardCreatedEvent @event)
    {
        Id = @event.AggregateId;
        Year = @event.Year;
    }

    public void Apply(LeaderboardDeletedEvent @event)
    {
        IsDeleted = true;
    }
    
    public void Apply(LeaderboardUndeletedEvent @event)
    {
        IsDeleted = false;
    }

    public void Apply(LeaderboardPublishedEvent @event)
    {
        IsPublished = true;
    }

    public void Apply(LeaderboardUnpublishedEvent @event)
    {
        IsPublished = false;
    }

    public void Apply(LeaderboardRecalculatedEvent @event)
    {
        Year = @event.Year;
        Categories = @event.Categories;
        EventResultIds = @event.EventResultIds;
    }
}