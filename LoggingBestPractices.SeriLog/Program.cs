using Serilog;

var log = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .CreateLogger();

log.Information("Random number {RandomNumber}", Random.Shared.Next());
log.Information("We are walking in {city} for {hours} hours", "Antwerp", 2.5);