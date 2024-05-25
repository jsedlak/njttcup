using CupKeeper.Cqrs;
using CupKeeper.Domains.Locations.Commands;
using CupKeeper.Domains.Locations.Events;
using CupKeeper.Domains.Locations.Model;
using CupKeeper.Domains.Locations.ServiceModel;
using Petl;

namespace CupKeeper.Domains.Locations.CommandHandlers;

public class VenueCommandHandlers : 
    IRequestHandler<CreateVenueCommand, CommandResult>,
    IRequestHandler<SetVenueNameCommand, CommandResult>,
    IRequestHandler<SetVenueParkingAddressCommand, CommandResult>,
    IRequestHandler<SetVenueStartLineAddressCommand, CommandResult>,
    IRequestHandler<DeleteVenueCommand, CommandResult>

{
    private readonly IVenueRepository _venueRepository;

    public VenueCommandHandlers(IVenueRepository venueRepository)
    {
        _venueRepository = venueRepository;
    }

    public async Task<CommandResult> ProcessAsync(RequestContext context, CreateVenueCommand command, CancellationToken cancellationToken)
    {
        var newVenue = new Venue
        {
            Name = command.Name,
            ParkingAddress = command.ParkingAddress,
            StartLineAddress = command.StartLineAddress
        };

        await _venueRepository.Upsert(newVenue);

        return CommandResult.Success(new VenueCreatedEvent(newVenue.Id)
        {
            Name = command.Name,
            ParkingAddress = command.ParkingAddress,
            StartLineAddress = command.StartLineAddress
        });
    }

    public async Task<CommandResult> ProcessAsync(RequestContext context, SetVenueNameCommand command, CancellationToken cancellationToken)
    {
        var venue = await _venueRepository.GetById(command.VenueId);

        venue.Name = command.Name;  

        await _venueRepository.Upsert(venue);

        return CommandResult.Success(new VenueNameSetEvent(venue.Id)
        {
            Name = command.Name
        });
    }

    public async Task<CommandResult> ProcessAsync(RequestContext context, SetVenueParkingAddressCommand command, CancellationToken cancellationToken)
    {
        var venue = await _venueRepository.GetById(command.VenueId);

        venue.ParkingAddress = command.ParkingAddress;

        await _venueRepository.Upsert(venue);

        return CommandResult.Success(new VenueParkingAddressSetEvent(venue.Id)
        {
             ParkingAddress = command.ParkingAddress
        });
    }

    public async Task<CommandResult> ProcessAsync(RequestContext context, SetVenueStartLineAddressCommand command, CancellationToken cancellationToken)
    {
        var venue = await _venueRepository.GetById(command.VenueId);

        venue.StartLineAddress = command.StartLineAddress;

        await _venueRepository.Upsert(venue);

        return CommandResult.Success(new VenueStartLineAddressSetEvent(venue.Id)
        {
            StartLineAddress = command.StartLineAddress
        });
    }

    public async Task<CommandResult> ProcessAsync(RequestContext context, DeleteVenueCommand command, CancellationToken cancellationToken)
    {
        await _venueRepository.Delete(command.VenueId);

        return CommandResult.Success(new VenueDeletedEvent(command.VenueId));
    }
}
