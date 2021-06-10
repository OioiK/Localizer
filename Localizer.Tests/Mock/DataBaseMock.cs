using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LocalizationService.Tests.Mock
{
    public class DataBaseMock : ILocalizationService
    {
        private readonly List<(string Culture, string Key, string Text)> _localizationsTableMock = new List<(string Culture, string Key, string Text)>();

        public DataBaseMock()
        {
            this._localizationsTableMock.Add((Culture: "en-US", Key: "DataBaseMock_key_1", Text: "DataBaseMock_value_1"));
            this._localizationsTableMock.Add((Culture: "en-US", Key: "DataBaseMock_key_2", Text: "DataBaseMock_value_2"));
            this._localizationsTableMock.Add((Culture: "ru-RU", Key: "DataBaseMock_key_1", Text: "DataBaseMock_значение_1"));
            this._localizationsTableMock.Add((Culture: "ru-RU", Key: "DataBaseMock_key_2", Text: "DataBaseMock_значение_2"));
            this._localizationsTableMock.Add((Culture: "de-DE", Key: "key_1", Text: "DataBaseMock_wert_1"));
            this._localizationsTableMock.Add((Culture: "de-DE", Key: "key_2", Text: "DataBaseMock_wert_2"));
        }

        public string GetString(string key, CultureInfo culture)
        {
            return this.SelectResourceFromTable(key, culture.Name);
        }

        private string SelectResourceFromTable(string key, string locale)
        {
            var localization = this._localizationsTableMock.FirstOrDefault(x => x.Culture == locale && x.Key == key);
            return localization.Text;
        }
    }
}
