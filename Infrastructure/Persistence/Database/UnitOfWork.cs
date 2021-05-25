using Infrastructure.Persistence;
using Infrastructure.Persistence.Database.Repositories;

public interface IUnitOfWork
{
    PublicationRepository Publications { get; }
    CaseTypeRepository CaseTypes { get; }
    CompanyRoleTypeRepository CompanyRoleTypes { get; }
    PublicationCompanyRoleRepository PublicationCompanyRoles { get; }
    CompanyRepository Companies { get; }
    ProductionTypeRepository ProductionTypes { get; }
    PublicationItemRepository PublicationItems { get; }
    PersonRepository Persons { get; }
    void SaveChanges();
}

/// <summary>
/// The unit of work class serves one purpose: to make sure that when you use multiple repositories, they share a single database context.
/// That way, when a unit of work is complete you can call the SaveChanges method on that instance of the context and be assured that all related changes will be coordinated. 
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    public PublicationRepository Publications { get; private set; }
    public CaseTypeRepository CaseTypes { get; private set; }
    public CompanyRoleTypeRepository CompanyRoleTypes { get; private set; }
    public PublicationCompanyRoleRepository PublicationCompanyRoles { get; private set; }
    public CompanyRepository Companies { get; private set; }
    public ProductionTypeRepository ProductionTypes { get; private set; }
    public PublicationItemRepository PublicationItems { get; private set; }
    public PersonRepository Persons { get; private set; }
    private readonly MoviesContext moviesContext;

    public UnitOfWork(MoviesContext moviesContext)
    {
        this.moviesContext = moviesContext;
        Publications = new PublicationRepository(moviesContext);
        CaseTypes = new CaseTypeRepository(moviesContext);
        CompanyRoleTypes = new CompanyRoleTypeRepository(moviesContext);
        PublicationCompanyRoles = new PublicationCompanyRoleRepository(moviesContext);
        Companies = new CompanyRepository(moviesContext);
        ProductionTypes = new ProductionTypeRepository(moviesContext);
        PublicationItems = new PublicationItemRepository(moviesContext);
        Persons = new PersonRepository(moviesContext);
    }

    public void SaveChanges()
    {
        moviesContext.SaveChanges();
    }
}