using Petl;

namespace CupKeeper.Cqrs;

public class CommandResult : IRequestResult
{
    public static CommandResult Success(params IResponse[] responses)
    {
        return new CommandResult { Responses = responses };
    }

    public IEnumerable<IResponse> Responses { get; set; } = Enumerable.Empty<IResponse>();
}
