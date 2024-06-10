using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Actors;
using CupKeeper.Domains.Locations.Commands;
using CupKeeper.Domains.Locations.Events;
using CupKeeper.Domains.Locations.Model;
using Orleans.Runtime;
using Petl.EventSourcing;

namespace CupKeeper.Domains.Locations.Orleans.Actors;

public class VenueActor : EventSourcedGrain<Venue, AggregateEvent>, IVenueActor
{
    #region Venue Management
    public Task<CommandResult> Create(CreateVenueCommand command)
    {
        var result = new VenueCreatedEvent(this.GetGrainId().GetGuidKey())
        {
            Name = command.Name,
            ParkingAddress = command.ParkingAddress,
        };
        
        Raise(result);

        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> Delete(DeleteVenueCommand command)
    {
        if (State.IsDeleted)
        {
            return Task.FromResult(
                CommandResult.Failure("Cannot delete venue - it is already marked for deletion.")
            );
        }
        
        Raise(new VenueDeletedEvent(command.VenueId));
        
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> SetName(SetVenueNameCommand command)
    {
        Raise(new VenueNameSetEvent(command.VenueId)
        {
            Name = command.Name
        });

        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> SetParkingAddress(SetVenueParkingAddressCommand command)
    {
        Raise(new VenueParkingAddressSetEvent(command.VenueId)
        {
            ParkingAddress = command.ParkingAddress
        });
        
        return Task.FromResult(CommandResult.Success());
    }
    #endregion

    #region Course Management
    public Task<CommandResult> AddCourse(AddCourseToVenueCommand command)
    {
        Raise(new CourseAddedToVenueEvent(command.VenueId)
        {
            CourseId = Guid.NewGuid(),
            Name = command.Name,
            Description = command.Description,
            Address = command.Address,
            Mileage = command.Mileage,
            RideWithGpsId = command.RideWithGpsId,
            RouteLink = command.RouteLink
        });
        
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> DeleteCourse(DeleteCourseFromVenueCommand command)
    {
        Raise(new CourseDeletedFromVenueEvent(command.VenueId)
        {
            CourseId = command.CourseId 
        });
        
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> SetCourseAddress(SetCourseAddressCommand command)
    {
        Raise(new CourseAddressSetEvent(command.VenueId)
        {
            CourseId = command.CourseId,
            Address = command.Address
        });
        
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> SetCourseMetaData(SetCourseMetaData command)
    {
        Raise(new CourseMetaDataSetEvent(command.VenueId)
        {
            CourseId = command.CourseId,
            Name = command.Name,
            Description = command.Description
        });
        
        return Task.FromResult(CommandResult.Success());
    }

    public Task<CommandResult> SetCourseRouteData(SetCourseRouteDataCommand command)
    {
        Raise(new CourseRouteDataSetEvent(command.VenueId)
        {
            CourseId = command.CourseId,
            Mileage = command.Mileage,
            RouteLink = command.RouteLink,
            RideWithGpsId = command.RideWithGpsId
        });
        
        return Task.FromResult(CommandResult.Success());
    }
    #endregion
}