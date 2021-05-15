using Domain.Enumerations;
using Infrastructure.Integration.CSV.TypeConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastructure.Tests.Integration.CSV.TypeConverters
{
    [TestClass]
    public class ProductionTypeEnumConverterTests
    {
        [TestMethod]
        public void ConvertFromString_EmptyString_ProductionTypeEnumUndefined()
        {
            var converter = new ProductionTypeEnumConverter();
            var expectedRes = ProductionTypeEnum.Undefined;
            var res = converter.ConvertFromString("", null, null);
            Assert.AreEqual(expectedRes, res);
        }

        [TestMethod]
        public void ConvertFromString_Movie_ProductionTypeEnumMovie()
        {
            var converter = new ProductionTypeEnumConverter();
            var expectedRes = ProductionTypeEnum.Movie;
            var res = converter.ConvertFromString("movie", null, null);
            Assert.AreEqual(expectedRes, res);
        }
    }
}