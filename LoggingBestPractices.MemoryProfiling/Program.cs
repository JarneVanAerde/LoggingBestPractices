using Microsoft.Extensions.Logging;

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
});

ILogger logger = new Logger<Program>(loggerFactory);

for (var i = 0; i < 100_000_000; i++)
{
    logger.LogInformation("Random number {RandomNumber}", Random.Shared.Next());
    
    // This is better
    // if (logger.IsEnabled(LogLevel.Information))
    // {
    //     logger.LogInformation("Random number {RandomNumber}", Random.Shared.Next());
    // }
    
    // this is even worse!
    //logger.LogInformation($"Random number {Random.Shared.Next()}");
}