using Domain.Entities;
using Domain.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options) {}
        public DbSet<ProductionRelease> Movies { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonRole> PersonRoles { get; set; }
        public DbSet<CollectionStatus> CollectionStatuses { get; set; }
        public DbSet<ConditionClass> ConditionClasses { get; set; }
        public DbSet<CaseType> CaseTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollectionStatus>().HasData(CreateCollectionStatuses());
            modelBuilder.Entity<ConditionClass>().HasData(CreateConditionClasses());
            modelBuilder.Entity<CaseType>().HasData(CreateCaseTypes());
            modelBuilder.Entity<ProductionType>().HasData(CreateProductionTypes());
            modelBuilder.Entity<MediaType>().HasData(CreateMediaTypes());
        }

        #region seed data
        private CollectionStatus[] CreateCollectionStatuses()
        {
            return new CollectionStatus[]
            {
                new CollectionStatus
                {
                    Id = (int) CollectionStatusEnum.Collection,
                    Name = "Collection item"
                },
                new CollectionStatus
                {
                    Id = (int) CollectionStatusEnum.PreviouslyOwned,
                    Name = "Previosly owned item"
                },
                new CollectionStatus
                {
                    Id = (int) CollectionStatusEnum.Trade,
                    Name = "Trade item"
                },
                new CollectionStatus
                {
                    Id = (int) CollectionStatusEnum.Want,
                    Name = "Wanted item"
                }
            };
        }

        private ConditionClass[] CreateConditionClasses()
        {
            return new ConditionClass[] 
            {
                new ConditionClass
                {
                    Id = (int) ConditionEnum.New,
                    Name = "New"
                },
                new ConditionClass
                {
                    Id = (int) ConditionEnum.Excellent,
                    Name = "Excellent"
                },
                new ConditionClass
                {
                    Id = (int) ConditionEnum.Good,
                    Name = "Good"
                },
                new ConditionClass
                {
                    Id = (int) ConditionEnum.Fair,
                    Name = "Fair"
                },
                new ConditionClass
                {
                    Id = (int) ConditionEnum.Poor,
                    Name = "Poor"
                },
                new ConditionClass
                {
                    Id = (int) ConditionEnum.Bad,
                    Name = "Bad"
                }
            };
        }
        private CaseType[] CreateCaseTypes()
        {
            return new CaseType[]
            {
                new CaseType
                {
                    Id = (int) CaseTypeEnum.KeepCase,
                    Name = "Keep Case"
                },
                new CaseType
                {
                    Id = (int) CaseTypeEnum.SnapperCase,
                    Name = "Snapper Case"
                },
                new CaseType
                {
                    Id = (int) CaseTypeEnum.Digipack,
                    Name = "Digipack"
                },
                new CaseType
                {
                    Id = (int) CaseTypeEnum.SteelBook,
                    Name = "Steelbook"
                },
                new CaseType
                {
                    Id = (int) CaseTypeEnum.SlimCase,
                    Name = "Keep case (slim)"
                },
                new CaseType
                {
                    Id = (int) CaseTypeEnum.MediaBook,
                    Name = "Mediabook"
                },
                new CaseType
                {
                    Id = (int) CaseTypeEnum.CardboardBox,
                    Name = "Cardboard box set"
                },
                new CaseType
                {
                    Id = (int) CaseTypeEnum.SpecialBox,
                    Name = "Special box set"
                }
            };
        }

        private ProductionType[] CreateProductionTypes() 
        {
            return new ProductionType[]
            {
                new ProductionType
                {
                    Id = (int) ProductionTypeEnum.Movie,
                    Name = "Movie"
                },
                new ProductionType
                {
                    Id = (int) ProductionTypeEnum.TvSerie,
                    Name = "TV Serie"
                },
                new ProductionType
                {
                    Id = (int) ProductionTypeEnum.Document,
                    Name = "Document"
                },
                new ProductionType
                {
                    Id = (int) ProductionTypeEnum.Music,
                    Name = "Music"
                }
            };
        }

        private MediaType[] CreateMediaTypes()
        {
            return new MediaType[]
            {
                new MediaType
                {
                    Id = (int) MediaTypeEnum.DVD,
                    Name = "DVD"
                },
                new MediaType
                {
                    Id = (int) MediaTypeEnum.BluRay,
                    Name = "Blu-ray"
                },
                new MediaType
                {
                    Id = (int) MediaTypeEnum.VHS,
                    Name = "VHS"
                },
                new MediaType
                {
                    Id = (int) MediaTypeEnum.UltraHD4K,
                    Name = "4K Ultra HD"
                },
                new MediaType
                {
                    Id = (int) MediaTypeEnum.HDDVD,
                    Name = "HD DVD"
                },
                new MediaType
                {
                    Id = (int) MediaTypeEnum.CD,
                    Name = "CD"
                },
                new MediaType
                {
                    Id = (int) MediaTypeEnum.BluRay3D,
                    Name = "Blu-ray 3D"
                }
            };
        }
        #endregion
    }
}