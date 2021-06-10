using LocalizationService.Tests.Mock;
using NUnit.Framework;
using System.Globalization;

namespace LocalizationService.Tests
{
    [TestFixture]
    public class LocalizationServiceTest
    {
        private LocalizationFactory _factory;
        private CultureInfo _ruCulture, _enCulture, _deCulture;

        [SetUp]
        public void TestSetUp()
        {
            this._factory = LocalizationFactory.GetInstance();
            this._factory.RegistrSource<DataSourceMock>();
            this._factory.RegistrSource(new DataBaseMock());
            this._ruCulture = new CultureInfo("ru-RU");
            this._enCulture = new CultureInfo("en-US");
            this._deCulture = new CultureInfo("de-DE");
        }

        [Test]
        public void TestGetString()
        {
            Assert.AreEqual("DataSourceMock_value_1", this._factory.GetString("key_1", this._enCulture));
            Assert.AreEqual("DataSourceMock_wert_1", this._factory.GetString("key_1", this._deCulture));
            Assert.AreEqual("DataSourceMock_значение_4", this._factory.GetString("key_4", this._ruCulture));
            
            Assert.AreEqual("DataBaseMock_value_1", this._factory.GetString("DataBaseMock_key_1", this._enCulture));
            Assert.AreEqual("DataBaseMock_значение_1", this._factory.GetString("DataBaseMock_key_1", this._ruCulture));

            Assert.AreEqual("DataBaseMock_wert_1", this._factory.GetString("key_1", this._deCulture));
            
            Assert.AreEqual("DataSourceMock_значение_1", this._factory.GetString("key_1", this._ruCulture));
            Assert.AreNotEqual("DataBaseMock_wert_1", this._factory.GetString("key_1", this._deCulture));
        }
    }
}
