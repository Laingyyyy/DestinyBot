using DiscordBot.Exceptions;
using DSharpPlus;
using DSharpPlus.Commands;
using DSharpPlus.Commands.Processors.SlashCommands;
using DSharpPlus.Commands.Processors.TextCommands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
    
    public async Task Run(CancellationToken ct)
    {
        var builder = DiscordClientBuilder.CreateDefault(Token,
            SlashCommandProcessor.RequiredIntents | TextCommandProcessor.RequiredIntents);
        
        ConfigureServices(builder);
        ConfigureEvents(builder);
        ConfigureCommands(builder);

        var client = builder.Build();
        await client.ConnectAsync().ConfigureAwait(false);

        ct.Register(async void () =>
        {
            await client.DisconnectAsync().ConfigureAwait(false);
        });
    }

    private void ConfigureServices(DiscordClientBuilder builder)
    {
        builder.ConfigureLogging(loggingBuilder =>
        {
            loggingBuilder.SetMinimumLevel(LogLevel.Debug);
        });
        
        builder.ConfigureServices(services =>
        {

        });
    }

    private void ConfigureEvents(DiscordClientBuilder builder)
    {
        builder.ConfigureEventHandlers(handlers =>
        {

        });
    }
    
    private void ConfigureCommands(DiscordClientBuilder builder)
    {
        builder.UseCommands((provider, extension) =>
        {

        });
    }
}