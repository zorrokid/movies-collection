using System.Linq;
using Domain.Enumerations;
using Infrastructure.Integration.CSV.Importers.MediaItemsStrategy;
using Infrastructure.Integration.CSV.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastructure.Tests.Integration.CSV.Importers.MediaItemsStrategy
{
    [TestClass]
    public class MultipleMatchingCountMediaTypeStrategyTests
    {
        [TestMethod]
        public void Create_TwoMediaTypesAndDiscs_CreatesMediaItemsGivenMediaTypes()
        {
            var mediaTypes = new MediaTypeEnum[] { MediaTypeEnum.DVD, MediaTypeEnum.BluRay };
            var expectedCount = 2;
            var row = new CsvRow
            {
                Discs = expectedCount,
                MediaType = mediaTypes,
                Condition = ConditionClassEnum.Bad
            };

            var strategy = new MultipleMatchingCountMediaTypeStrategy();
            
            var result = strategy.Create(row);
            Assert.AreEqual(expectedCount, result.Count);
            Assert.IsNotNull(result.Where(r => r.MediaTypeId == (int) MediaTypeEnum.DVD).SingleOrDefault());
            Assert.IsNotNull(result.Where(r => r.MediaTypeId == (int) MediaTypeEnum.BluRay).SingleOrDefault());
        }
 
    }
}