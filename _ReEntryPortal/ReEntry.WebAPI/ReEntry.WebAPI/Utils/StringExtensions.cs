using System;

namespace ReEntry.WebAPI.Utils
{
    public static class StringExtensions
    {
        public static bool NotBlank(this string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }
    }
}