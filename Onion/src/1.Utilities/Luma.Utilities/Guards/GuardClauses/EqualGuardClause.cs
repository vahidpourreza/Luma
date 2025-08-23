namespace Luma.Utilities.Guards.GuardClauses;

/// <summary>
/// The method names (Equal and NotEqual) describe the condition being checked, 
/// but the exception is thrown when the opposite condition is true.
/// Equal throws when values are not equal.
/// </summary>
public static class EqualGuardClause
{
    public static void Equal<T>(this Guard guard, T value, T targetValue, string message)
    {
        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException("Message");

        if (!Equals(value, targetValue))
            throw new InvalidOperationException(message);
    }

    public static void Equal<T>(this Guard guard, T value, T targetValue, IEqualityComparer<T> equalityComparer, string message)
    {
        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException("Message");

        if (!equalityComparer.Equals(value, targetValue))
            throw new InvalidOperationException(message);
    }
}
