using System.Collections.Generic;
using System.Globalization;

namespace LocalizationService.Tests.Mock
{
    public class DataSourceMock : ILocalizationService
    {
        private readonly Dictionary<string, Dictionary<string, string>> _localizations = new Dictionary<string, Dictionary<string, string>>
        {
            {
                "en-US", new Dictionary<string, string>
                {
                    { "key_1", "DataSourceMock_value_1" },
                    { "key_2", "DataSourceMock_value_2" },
                    { "key_3", "DataSourceMock_value_3" },
                    { "key_4", "DataSourceMock_value_4" },
                    { "key_5", "DataSourceMock_value_5" }
                }
            },
            {
                "ru-RU", new Dictionary<string, string>
                {
                    { "key_1", "DataSourceMock_значение_1" },
                    { "key_2", "DataSourceMock_значение_2" },
                    { "key_3", "DataSourceMock_значение_3" },
                    { "key_4", "DataSourceMock_значение_4" },
                    { "key_5", "DataSourceMock_значение_5" }
                }
            },
            {
                "de-DE", new Dictionary<string, string>
                {
                    { "key_1", "DataSourceMock_wert_1" },
                    { "key_2", "DataSourceMock_wert_2" },
                    { "key_3", "DataSourceMock_wert_3" },
                    { "key_4", "DataSourceMock_wert_4" },
                    { "key_5", "DataSourceMock_wert_5" }
                }
            }
        }; 

        public string GetString(string key, CultureInfo culture)
        {
            return this._localizations[culture.Name][key];
        }
    }
}
