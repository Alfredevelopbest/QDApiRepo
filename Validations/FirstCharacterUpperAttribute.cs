using System;
using System.Linq;

namespace QD_API.Validations
{
    public static class TextHelpers
    {
        public static string CapitalizeWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return text;

            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return string.Join(' ', words.Select(word =>
                char.ToUpper(word[0]) + word.Substring(1).ToLower()));
        }
    }
}
