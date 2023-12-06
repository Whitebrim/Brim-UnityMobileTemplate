public static class StringExtensions
{
    public static string Extract(this string input, int length)
    {
        if (string.IsNullOrEmpty(input) || input.Length < length)
        {
            return input;
        };

        return input.Substring(0, length);
    }
}
