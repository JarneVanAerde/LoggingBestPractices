using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks;

[MemoryDiagnoser]
public class LoggingBenchmarksV1
{
    private const string LogMessageWithParameters = "This is a log message with parameters {First}, {Second}";
    private const string LogMessage = "This is a log message";

    private readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
    });

    private readonly ILogger<LoggingBenchmarksV1> _logger;

    public LoggingBenchmarksV1()
    {
        _logger = new Logger<LoggingBenchmarksV1>(_loggerFactory);
    }

    [Benchmark]
    public void Log_WithoutIf()
    {
        _logger.LogInformation(LogMessage);
    }
        
    [Benchmark]
    public void Log_WithIf()
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(LogMessage);
        }
    }
    
    [Benchmark]
    public void Log_WithoutIf_WithParams()
    {
        _logger.LogInformation(LogMessageWithParameters, 69, 420);
    }
        
    [Benchmark]
    public void Log_WithIf_WithParams()
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(LogMessageWithParameters, 69, 420);
        }
    }
}