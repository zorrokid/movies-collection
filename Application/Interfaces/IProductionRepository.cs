using System.Collections.Generic;
using Domain.Entities;
using Domain.Enumerations;

namespace Application.Interfaces
{
    public interface IProductionRepository : IRepository<Production> 
    {
        List<Production> GetProductionsByNameAndType(string name, ProductionTypeEnum productionType);
    }
}