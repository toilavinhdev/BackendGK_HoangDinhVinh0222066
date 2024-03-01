using System.Diagnostics.CodeAnalysis;

namespace HoangDinhVinh0222066.Exceptions;

public class UserFriendlyException0222066(string message) : Exception(message)
{
    public static void ThrowIfNotFound([NotNull] object? value)
    {
        if (value is not null) return;
        throw new UserFriendlyException0222066("Not found");
    }
}