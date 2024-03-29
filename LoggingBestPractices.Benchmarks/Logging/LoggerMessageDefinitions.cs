﻿using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks.Logging;

public static class LoggerMessageDefinitions
{
    // Realistically this name reflects what you are actually logging.
    // The number represents the logging-group, you can also wrap it in an EventId to give it a readable name.
    // This operation is actually cached
    private static readonly Action<ILogger, int, int, Exception?> BenchmarkedLogMessageDefinition =
        LoggerMessage.Define<int, int>(LogLevel.Information, 0, 
            "This is a log message with parameters {First}, {Second}");

    public static void LogBenchmarkMessage(this ILogger logger, int first, int second)
    {
        BenchmarkedLogMessageDefinition(logger, first, second, null);
    }
}

public static partial class LoggerMessageDefinitionsGen
{
    [LoggerMessage(EventId = 0, Level = LogLevel.Information,
        Message = "This is a log message with parameters {First}, {Second}",
        SkipEnabledCheck = true)]
    public static partial void LogBenchmarkMessageGen(this ILogger logger, int first, int second);
}