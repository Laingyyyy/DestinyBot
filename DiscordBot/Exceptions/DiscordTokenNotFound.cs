namespace DiscordBot.Exceptions;

public class DiscordTokenNotFound : Exception
{
    public DiscordTokenNotFound()
    {
        
    }

    public DiscordTokenNotFound(string message)
        : base(message)
    {
        
    }
    
    public DiscordTokenNotFound(string message, Exception innerException)
        : base(message, innerException)
    {
        
    }
}