using BenchmarkDotNet.Attributes;
using LoggingBestPractices.Benchmarks.Logging;
using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks;

[MemoryDiagnoser]
public class LoggingBenchmarksV3
{
    private const string LogMessageWithParameters = "This is a log message with parameters {First}, {Second}";

    private readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddFakeLogger().SetMinimumLevel(LogLevel.Information);
    });

    private readonly ILogger<LoggingBenchmarksV3> _logger;
    private readonly LoggerAdapter<LoggingBenchmarksV3> _loggerAdapter;

    public LoggingBenchmarksV3()
    {
        _logger = new Logger<LoggingBenchmarksV3>(_loggerFactory);
        _loggerAdapter = new LoggerAdapter<LoggingBenchmarksV3>(_logger);
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
    public void LogAdapter_WithoutIf_WithParams()
    {
        _loggerAdapter.LogInformation(LogMessageWithParameters, 69, 420);
    }
    
    [Benchmark]
    public void LoggerMessageDef_WithoutIf_WithParams()
    {
        _logger.LogBenchmarkMessage(69, 420);
    }
    
    [Benchmark]
    public void LoggerMessageDef_SourceGen_WithoutIf_WithParams()
    {
        _logger.LogBenchmarkMessageGen(69, 420);
    }
}