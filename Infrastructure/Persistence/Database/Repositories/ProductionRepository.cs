using Application.Interfaces;
using Domain.Entities;
using Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Database.Repositories
{
    public class ProductionRepository : GenericRepository<Production>, IProductionRepository
    {
        public ProductionRepository(ApplicationContext context) : base(context)
        {}

        public List<Production> GetProductionsByNameAndType(string name, ProductionTypeEnum productionType)
        {
            return context.Productions
                .Include(p => p.ProductionType)
                .Include(p => p.ProductionCompanyRoles)
                .ThenInclude(companyRole => companyRole.Company)
                .Include(p => p.ProductionPersonRoles)
                .ThenInclude(personRole => personRole.Person)
                .Where(p => 
                    p.ProductionTypeId == (int) productionType && 
                    p.OriginalTitle.ToLower() == name.ToLower()
                )
                .ToList();
        }
    }
}