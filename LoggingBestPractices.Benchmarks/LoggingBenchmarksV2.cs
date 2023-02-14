using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks;

[MemoryDiagnoser]
public class LoggingBenchmarksV2
{
    private const string LogMessageWithParameters = "This is a log message with parameters {0}, {1}";

    private readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
    });

    private readonly ILogger<LoggingBenchmarksV2> _logger;
    private readonly LoggerAdapter<LoggingBenchmarksV2> _loggerAdapter;

    public LoggingBenchmarksV2()
    {
        _logger = new Logger<LoggingBenchmarksV2>(_loggerFactory);
        _loggerAdapter = new LoggerAdapter<LoggingBenchmarksV2>(_logger);
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
            _loggerAdapter.LogInformation(LogMessageWithParameters, 69, 420);
        }
    }

    [Benchmark]
    public void LogAdapter_WithIf_WithParams()
    {
        _loggerAdapter.LogInformation(LogMessageWithParameters, 69, 420);
    }
}