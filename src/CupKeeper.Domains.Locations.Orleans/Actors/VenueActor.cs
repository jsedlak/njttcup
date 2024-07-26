using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Commands;
using CupKeeper.Domains.Locations.Events;
using CupKeeper.Domains.Locations.Model;
using Orleans.Runtime;
using Orleans.Streams;
using Petl.EventSourcing;

namespace CupKeeper.Domains.Locations.Actors;

public class VenueActor : EventSourcedGrain<Venue, VenueBaseEvent>, IVenueActor
{
    private IAsyncStream<VenueBaseEvent>? _eventStream;

    #region Grain Management

    public override async Task OnActivateAsync(CancellationToken cancellationToken)
    {
        await base.OnActivateAsync(cancellationToken);

        var streamProvider = this.GetStreamProvider("StreamProvider");

        var myId = this.GetGrainId().GetGuidKey();
        var streamId = StreamId.Create(ActorConstants.VenueEventEventStreamName, myId);

        _eventStream = streamProvider.GetStream<VenueBaseEvent>(streamId);
    }

    protected override async Task Raise(VenueBaseEvent @event)
    {
        await base.Raise(@event);
        await _eventStream!.OnNextAsync(@event);
    }

    protected override async Task Raise(IEnumerable<VenueBaseEvent> events)
    {
        var eventBatch = events as VenueBaseEvent[] ?? events.ToArray();

        await base.Raise(eventBatch);
        await _eventStream!.OnNextBatchAsync(eventBatch);
    }

    #endregion

    #region Venue Management

    public async Task<CommandResult> Create(CreateVenueCommand command)
    {
        var result = new VenueCreatedEvent(this.GetGrainId().GetGuidKey())
        {
            Name = command.Name,
            ParkingAddress = command.ParkingAddress,
        };

        await Raise(result);

        return CommandResult.Success();
    }

    public async Task<CommandResult> Delete(DeleteVenueCommand command)
    {
        if (State.IsDeleted)
        {
            return CommandResult.Failure("Cannot delete venue - it is already marked for deletion.");
        }

        await Raise(new VenueDeletedEvent(command.VenueId));

        return CommandResult.Success();
    }

    public async Task<CommandResult> SetName(SetVenueNameCommand command)
    {
        await Raise(new VenueNameSetEvent(command.VenueId)
        {
            Name = command.Name
        });

        return CommandResult.Success();
    }

    public async Task<CommandResult> SetParkingAddress(SetVenueParkingAddressCommand command)
    {
        await Raise(new VenueParkingAddressSetEvent(command.VenueId)
        {
            ParkingAddress = command.ParkingAddress
        });

        return CommandResult.Success();
    }

    #endregion

    #region Course Management

    public async Task<CommandResult> AddCourse(AddCourseToVenueCommand command)
    {
        await Raise(new CourseAddedToVenueEvent(command.VenueId)
        {
            CourseId = Guid.NewGuid(),
            Name = command.Name,
            Description = command.Description,
            Address = command.Address,
            Mileage = command.Mileage,
            RideWithGpsId = command.RideWithGpsId,
            RouteLink = command.RouteLink
        });

        return CommandResult.Success();
    }

    public async Task<CommandResult> DeleteCourse(DeleteCourseFromVenueCommand command)
    {
        await Raise(new CourseDeletedFromVenueEvent(command.VenueId)
        {
            CourseId = command.CourseId
        });

        return CommandResult.Success();
    }

    public async Task<CommandResult> SetCourseAddress(SetCourseAddressCommand command)
    {
        await Raise(new CourseAddressSetEvent(command.VenueId)
        {
            CourseId = command.CourseId,
            Address = command.Address
        });

        return CommandResult.Success();
    }

    public async Task<CommandResult> SetCourseMetaData(SetCourseMetaData command)
    {
        await Raise(new CourseMetaDataSetEvent(command.VenueId)
        {
            CourseId = command.CourseId,
            Name = command.Name,
            Description = command.Description
        });

        return CommandResult.Success();
    }

    public async Task<CommandResult> SetCourseRouteData(SetCourseRouteDataCommand command)
    {
        await Raise(new CourseRouteDataSetEvent(command.VenueId)
        {
            CourseId = command.CourseId,
            Mileage = command.Mileage,
            RouteLink = command.RouteLink,
            RideWithGpsId = command.RideWithGpsId
        });

        return CommandResult.Success();
    }
    #endregion
}