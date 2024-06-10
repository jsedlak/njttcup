using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Commands;

namespace CupKeeper.Domains.Locations.Actors;

public interface IVenueActor : IGrainWithGuidKey
{
    Task<CommandResult> Create(CreateVenueCommand command);

    Task<CommandResult> Delete(DeleteVenueCommand command);

    Task<CommandResult> SetName(SetVenueNameCommand command);

    Task<CommandResult> SetParkingAddress(SetVenueParkingAddressCommand command);

    Task<CommandResult> AddCourse(AddCourseToVenueCommand command);

    Task<CommandResult> DeleteCourse(DeleteCourseFromVenueCommand command);

    Task<CommandResult> SetCourseAddress(SetCourseAddressCommand command);

    Task<CommandResult> SetCourseMetaData(SetCourseMetaData command);

    Task<CommandResult> SetCourseRouteData(SetCourseRouteDataCommand command);
}