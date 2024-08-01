using System.Globalization;

namespace kuranmealuygulaması.Controllers
{
    public static class KelimeDuzenleme
    {
        public static string NormalizeText(this string text)
        {
            return text
                .Replace('â', 'a')
                .Replace('î', 'i')
                .Replace('û', 'u')
                .Replace('ç', 'c')
                .Replace('ğ', 'g')
                .Replace('ö', 'o')
                .Replace('ş', 's')
                .Replace('ü', 'u')
                .ToLower(new CultureInfo("tr-TR", false));
        }
    }
}
