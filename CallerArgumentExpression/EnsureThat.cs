using System.Runtime.CompilerServices;

namespace CallerArgumentExpression;

public static class EnsureThat
{
    public static void ItIsEmpty<T>(IEnumerable<T> value)
    {
        if (value.Any())
        {
            throw new ArgumentException("Enumerable is not empty", nameof(value));
        }
    }
    
    public static void ItIsNotEmpty<T>(IEnumerable<T> value,
        [CallerArgumentExpression("value")] string message = "")
    {
        if (!value.Any())
        {
            throw new ArgumentException("Enumerable is empty", message);
        }
    }
    
    public static void ItIsNotNull<T>(T value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }
    }
    
    public static void ItIsTrue(bool value)
    {
        if (!value)
        {
            throw new ArgumentException("Value is false", nameof(value));
        }
    }
}