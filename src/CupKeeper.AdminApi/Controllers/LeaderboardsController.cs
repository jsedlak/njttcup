using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Actors;
using CupKeeper.Domains.Championships.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CupKeeper.AdminApi.Controllers;

[ApiController]
[Route("/api/leaderboards")]
public class LeaderboardsController
{
    private readonly IClusterClient _clusterClient;

    public LeaderboardsController(IClusterClient clusterClient)
    {
        _clusterClient = clusterClient;
    }

    [HttpPost("{leaderboardId}/recalculate")]
    public async Task<CommandResult> RecalculateAsync([FromRoute] Guid leaderboardId,
        [FromBody] RecalculateLeaderboardCommand command)
    {
        var actor = _clusterClient.GetGrain<ILeaderboardActor>(command.LeaderboardId);
        return await actor.Recalculate(command);
    }
}