using System.Globalization;

namespace LocalizationService
{
    public interface ILocalizationService
    {
        string GetString(string key, CultureInfo culture);
    }
}
