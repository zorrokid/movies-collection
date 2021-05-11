using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.Integration.CSV.Importers.MediaItemsStrategy;
using Infrastructure.Integration.CSV.Models;
using Domain.Enumerations;
using System.Linq;

namespace Infrastructure.Tests.Integration.CSV.Importers.MediaItemsStrategy
{
    [TestClass]
    public class SingleMediaTypeStrategyTests
    {
        [TestMethod]
        public void Create_SingleMediaTypeAndSingleDisc_CreatesGivenMediaType()
        {
            var mediaTypes = new MediaTypeEnum[] { MediaTypeEnum.DVD };
            var expectedCount = 3;
            CsvRow row = new CsvRow
            {
                Discs = expectedCount,
                MediaType = mediaTypes,
                Condition = ConditionClassEnum.Bad
            };

            var strategy = new SingleMediaTypeStrategy();
            
            var result = strategy.Create(row);
            Assert.AreEqual(expectedCount, result.Count);
            Assert.AreEqual((int) MediaTypeEnum.DVD, result.First().MediaTypeId);
        }
        
    }
}