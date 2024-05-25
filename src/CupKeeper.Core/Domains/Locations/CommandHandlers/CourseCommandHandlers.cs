using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Commands;
using Petl;

namespace CupKeeper.Domains.Locations.CommandHandlers;

public sealed class CourseCommandHandlers :
     IRequestHandler<AddCourseToVenueCommand, CommandResult>,
    IRequestHandler<SetCourseNameCommand, CommandResult>,
    IRequestHandler<SetCourseDescriptionCommand, CommandResult>,
    IRequestHandler<SetCourseAddressCommand, CommandResult>,
    IRequestHandler<SetCourseRouteDataCommand, CommandResult>,
    IRequestHandler<DeleteCourseFromVenueCommand, CommandResult>
{
    public Task<CommandResult> ProcessAsync(RequestContext context, AddCourseToVenueCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> ProcessAsync(RequestContext context, SetCourseNameCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> ProcessAsync(RequestContext context, SetCourseDescriptionCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> ProcessAsync(RequestContext context, SetCourseAddressCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> ProcessAsync(RequestContext context, SetCourseRouteDataCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CommandResult> ProcessAsync(RequestContext context, DeleteCourseFromVenueCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}