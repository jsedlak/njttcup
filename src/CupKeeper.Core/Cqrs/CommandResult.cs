namespace CupKeeper.Cqrs;

[GenerateSerializer]
public class CommandResult
{
    public static CommandResult Success()
    {
        return new CommandResult { IsSuccess = true };
    }

    public static CommandResult Failure(params string[] messages)
    {
        return new CommandResult()
        {
            Messages = messages
        };
    }
    
    [Id(0)]
    public bool IsSuccess { get; set; }

    [Id(1)]
    public IEnumerable<string> Messages { get; set; } = [];
}

[GenerateSerializer]
public class CommandResult<TData> : CommandResult
{
    public static CommandResult<TData> Success(TData data)
    {
        return new CommandResult<TData> { Data = data };
    }

    [Id(0)]
    public TData? Data { get; set; }
}
