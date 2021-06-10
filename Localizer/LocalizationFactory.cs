using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using log4net;

namespace LocalizationService
{
    public class LocalizationFactory
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(LocalizationFactory));

        private static LocalizationFactory _factory;
        private readonly List<ILocalizationService> _registrations = new List<ILocalizationService>();

        private LocalizationFactory() { }

        public static LocalizationFactory GetInstance()
        {
            if (_factory == null)
            {
                _factory = new LocalizationFactory();
            }

            return _factory;
        }

        public void RegistrSource<TItem>() where TItem : ILocalizationService
        {
            this._registrations.Add((ILocalizationService)Activator.CreateInstance(typeof(TItem)));
        }

        public void RegistrSource(ILocalizationService instance)
        {
            this._registrations.Add(instance);
        }

        public string GetString(string key, CultureInfo culture = null)
        {
            var currentCulture = culture ?? Thread.CurrentThread.CurrentCulture;

            var result = string.Empty;
            foreach (var reg in this._registrations)
            {
                try
                {
                    result = reg.GetString(key, currentCulture);
                }
                catch (Exception ex)
                {
                    _log.ErrorFormat("Произошла ошибка при получении данных {0}", ex);
                }

                if (string.IsNullOrEmpty(result))
                {
                    continue;
                }

                this._registrations.Remove(reg);
                this._registrations.Insert(0, reg);
                return result;
            }

            return result;
        }
    }
}
