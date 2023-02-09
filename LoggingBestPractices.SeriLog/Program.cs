using Serilog;

var log = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .CreateLogger();

log.Information("Random number {RandomNumber}", Random.Shared.Next());