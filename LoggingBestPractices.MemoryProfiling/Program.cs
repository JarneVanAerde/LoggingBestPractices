using Microsoft.Extensions.Logging;

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
});

ILogger logger = new Logger<Program>(loggerFactory);

for (var i = 0; i < 75_000_000; i++)
{
    logger.LogInformation("Random number {RandomNumber}", Random.Shared.Next());
}