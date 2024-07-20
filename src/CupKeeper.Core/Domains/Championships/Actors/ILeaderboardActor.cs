using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Commands;

namespace CupKeeper.Domains.Championships.Actors;

public interface ILeaderboardActor : IGrainWithGuidKey
{
    Task<CommandResult> Create(CreateLeaderboardCommand command);

    Task<CommandResult> Delete(DeleteLeaderboardCommand command);

    Task<CommandResult> Undelete(UndeleteLeaderboardCommand command);
    
    Task<CommandResult> Recalculate(RecalculateLeaderboardCommand command);

    Task<CommandResult> Publish(PublishLeaderboardCommand command);

    Task<CommandResult> Unpublish(UnpublishLeaderboardCommand command);
}