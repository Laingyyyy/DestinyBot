using DiscordBot.Exceptions;
using Microsoft.Extensions.Configuration;

namespace DiscordBot;

public class Bot
{
    // Discord Token Stored In Secrets Manager At "Discord:Token"
    private readonly string Token;
    
    // 
    
    public Bot()
    {
        var config = new ConfigurationBuilder();
        config.AddUserSecrets<Bot>();
        
        Token = config
            .Build()
            .GetSection("Discord:Token")
            .Value ?? throw new DiscordTokenNotFound();
    }
    
    
}