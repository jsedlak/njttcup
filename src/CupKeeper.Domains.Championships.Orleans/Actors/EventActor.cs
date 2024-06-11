using CupKeeper.Cqrs;
using CupKeeper.Domains.Championships.Commands;
using CupKeeper.Domains.Championships.Model;
using Petl.EventSourcing;

namespace CupKeeper.Domains.Championships.Actors;

public class EventActor : EventSourcedGrain<ScheduledEvent, AggregateEvent>, IEventActor
{
    public Task<CommandResult> Create(CreateScheduledEventCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> Delete(DeleteScheduledEventCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> SetName(SetEventNameCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> SetCourse(SetEventCourseCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> SetRegistration(SetEventRegistrationLinkCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<SetEventScheduledDateCommand> SetDate(SetEventScheduledDateCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<SetEventUsacDataCommand> SetUsacData(SetEventUsacDataCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> AddCategory(AddCategoryResultCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> RemoveCategory(RemoveCategoryResultCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> SetCategoryName(SetCategoryResultNameCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> AddRider(AddRiderResultCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> MoveRider(MoveRiderResultCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> RemoveRider(RemoveRiderResultCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> PublishResults(PublishEventResultsCommand command)
    {
        throw new NotImplementedException();
    }
}