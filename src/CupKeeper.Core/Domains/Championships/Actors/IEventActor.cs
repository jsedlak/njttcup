using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Commands;

namespace CupKeeper.Domains.Championships.Actors;

public interface IEventActor : IGrainWithGuidKey
{
    #region Event Management
    Task<CommandResult> Create(CreateScheduledEventCommand command);

    Task<CommandResult> Delete(DeleteScheduledEventCommand command);

    Task<CommandResult> SetName(SetEventNameCommand command);

    Task<CommandResult> SetCourse(SetEventCourseCommand command);

    Task<CommandResult> SetRegistration(SetEventRegistrationLinkCommand command);

    Task<SetEventScheduledDateCommand> SetDate(SetEventScheduledDateCommand command);

    Task<SetEventUsacDataCommand> SetUsacData(SetEventUsacDataCommand command);
    #endregion
    
    #region Results Management
    Task<CommandResult> AddCategory(AddCategoryResultCommand command);
    
    Task<CommandResult> RemoveCategory(RemoveCategoryResultCommand command);

    Task<CommandResult> SetCategoryName(SetCategoryResultNameCommand command);

    Task<CommandResult> AddRider(AddRiderResultCommand command);

    Task<CommandResult> MoveRider(MoveRiderResultCommand command);

    Task<CommandResult> RemoveRider(RemoveRiderResultCommand command);

    Task<CommandResult> PublishResults(PublishEventResultsCommand command);

    #endregion
}