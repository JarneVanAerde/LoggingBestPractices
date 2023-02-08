using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks;

[MemoryDiagnoser]
public class LoggingBenchmarks
{
    private const string LogMessageWithParameters = "This is a log message with parameters {0}, {1}";
    private const string LogMessage = "This is a log message";

    private readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
    });

    private readonly ILogger<LoggingBenchmarks> _logger;

    public LoggingBenchmarks()
    {
        _logger = new Logger<LoggingBenchmarks>(_loggerFactory);
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