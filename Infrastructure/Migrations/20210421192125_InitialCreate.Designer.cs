﻿// <auto-generated />
using System;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(MoviesContext))]
    [Migration("20210421192125_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Domain.Entities.CaseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CaseTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Keep Case"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Snapper Case"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Digipack"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Steelbook"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Keep case (slim)"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Mediabook"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Cardboard box set"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Special box set"
                        });
                });

            modelBuilder.Entity("Domain.Entities.CollectionStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CollectionStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Collection item"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Previosly owned item"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Trade item"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Wanted item"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Domain.Entities.CompanyRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<int?>("MovieId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("MovieId");

                    b.HasIndex("RoleId");

                    b.ToTable("CompanyRoles");
                });

            modelBuilder.Entity("Domain.Entities.CompanyRoleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CompanyRoleTypes");
                });

            modelBuilder.Entity("Domain.Entities.ConditionClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ConditionClasses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "New"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Excellent"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Good"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Fair"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Poor"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Bad"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Domain.Entities.CoverLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("LanguageCode")
                        .HasColumnType("text");

                    b.Property<int?>("PublicationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PublicationId");

                    b.ToTable("CoverLanguages");
                });

            modelBuilder.Entity("Domain.Entities.MediaItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("MediaTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("PublicationItemId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MediaTypeId");

                    b.HasIndex("PublicationItemId");

                    b.ToTable("MediaItems");
                });

            modelBuilder.Entity("Domain.Entities.MediaType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MediaTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "DVD"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Blu-ray"
                        },
                        new
                        {
                            Id = 3,
                            Name = "VHS"
                        },
                        new
                        {
                            Id = 4,
                            Name = "4K Ultra HD"
                        },
                        new
                        {
                            Id = 5,
                            Name = "HD DVD"
                        },
                        new
                        {
                            Id = 6,
                            Name = "CD"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Blu-ray 3D"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("GivenName")
                        .HasColumnType("text");

                    b.Property<int?>("ProductionId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductionId1")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductionId2")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductionId");

                    b.HasIndex("ProductionId1");

                    b.HasIndex("ProductionId2");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Domain.Entities.PersonRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("MovieId")
                        .HasColumnType("integer");

                    b.Property<int?>("PersonId")
                        .HasColumnType("integer");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("PersonId");

                    b.HasIndex("RoleId");

                    b.ToTable("PersonRoles");
                });

            modelBuilder.Entity("Domain.Entities.PersonRoleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PersonRoleTypes");
                });

            modelBuilder.Entity("Domain.Entities.Production", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("CountryCode")
                        .HasColumnType("text");

                    b.Property<string>("OriginalTitle")
                        .HasColumnType("text");

                    b.Property<int?>("ProductionTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("StudioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductionTypeId");

                    b.HasIndex("StudioId");

                    b.ToTable("Productions");
                });

            modelBuilder.Entity("Domain.Entities.ProductionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Movie"
                        },
                        new
                        {
                            Id = 2,
                            Name = "TV Serie"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Document"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Music"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Publication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Barcode")
                        .HasColumnType("text");

                    b.Property<int?>("CaseTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("ConditionClassId")
                        .HasColumnType("integer");

                    b.Property<string>("CountryCode")
                        .HasColumnType("text");

                    b.Property<bool>("HasBooklet")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasHologram")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasSlipCover")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasTwoSidedCover")
                        .HasColumnType("boolean");

                    b.Property<int>("ImportOriginId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsRental")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("LocalTitle")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("OriginalTitle")
                        .HasColumnType("text");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CaseTypeId");

                    b.HasIndex("ConditionClassId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("Domain.Entities.PublicationItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("ImportOriginId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductionId")
                        .HasColumnType("integer");

                    b.Property<int?>("PublicationId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductionId");

                    b.HasIndex("PublicationId");

                    b.ToTable("PublicationItems");
                });

            modelBuilder.Entity("Domain.Entities.SpokenLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("LanguageCode")
                        .HasColumnType("text");

                    b.Property<int?>("PublicationItemId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PublicationItemId");

                    b.ToTable("SpokenLanguages");
                });

            modelBuilder.Entity("Domain.Entities.SubtitleLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("LanguageCode")
                        .HasColumnType("text");

                    b.Property<int?>("PublicationItemId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PublicationItemId");

                    b.ToTable("SubtitleLanguages");
                });

            modelBuilder.Entity("Domain.Entities.CompanyRole", b =>
                {
                    b.HasOne("Domain.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Entities.PublicationItem", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("Domain.Entities.CompanyRoleType", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Company");

                    b.Navigation("Movie");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Entities.CoverLanguage", b =>
                {
                    b.HasOne("Domain.Entities.Publication", "Publication")
                        .WithMany("CoverLanguages")
                        .HasForeignKey("PublicationId");

                    b.Navigation("Publication");
                });

            modelBuilder.Entity("Domain.Entities.MediaItem", b =>
                {
                    b.HasOne("Domain.Entities.MediaType", "MediaType")
                        .WithMany()
                        .HasForeignKey("MediaTypeId");

                    b.HasOne("Domain.Entities.PublicationItem", "PublicationItem")
                        .WithMany("MediaItems")
                        .HasForeignKey("PublicationItemId");

                    b.Navigation("MediaType");

                    b.Navigation("PublicationItem");
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.HasOne("Domain.Entities.Production", null)
                        .WithMany("Directors")
                        .HasForeignKey("ProductionId");

                    b.HasOne("Domain.Entities.Production", null)
                        .WithMany("Producers")
                        .HasForeignKey("ProductionId1");

                    b.HasOne("Domain.Entities.Production", null)
                        .WithMany("Writers")
                        .HasForeignKey("ProductionId2");
                });

            modelBuilder.Entity("Domain.Entities.PersonRole", b =>
                {
                    b.HasOne("Domain.Entities.Production", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("Domain.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("Domain.Entities.PersonRoleType", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Movie");

                    b.Navigation("Person");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Entities.Production", b =>
                {
                    b.HasOne("Domain.Entities.ProductionType", "ProductionType")
                        .WithMany()
                        .HasForeignKey("ProductionTypeId");

                    b.HasOne("Domain.Entities.Company", "Studio")
                        .WithMany()
                        .HasForeignKey("StudioId");

                    b.Navigation("ProductionType");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("Domain.Entities.Publication", b =>
                {
                    b.HasOne("Domain.Entities.CaseType", "CaseType")
                        .WithMany()
                        .HasForeignKey("CaseTypeId");

                    b.HasOne("Domain.Entities.ConditionClass", "ConditionClass")
                        .WithMany()
                        .HasForeignKey("ConditionClassId");

                    b.HasOne("Domain.Entities.Company", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId");

                    b.Navigation("CaseType");

                    b.Navigation("ConditionClass");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Domain.Entities.PublicationItem", b =>
                {
                    b.HasOne("Domain.Entities.Production", "Production")
                        .WithMany()
                        .HasForeignKey("ProductionId");

                    b.HasOne("Domain.Entities.Publication", "Publication")
                        .WithMany("PublicationItems")
                        .HasForeignKey("PublicationId");

                    b.Navigation("Production");

                    b.Navigation("Publication");
                });

            modelBuilder.Entity("Domain.Entities.SpokenLanguage", b =>
                {
                    b.HasOne("Domain.Entities.PublicationItem", "PublicationItem")
                        .WithMany()
                        .HasForeignKey("PublicationItemId");

                    b.Navigation("PublicationItem");
                });

            modelBuilder.Entity("Domain.Entities.SubtitleLanguage", b =>
                {
                    b.HasOne("Domain.Entities.PublicationItem", "PublicationItem")
                        .WithMany("SubtitleLanguages")
                        .HasForeignKey("PublicationItemId");

                    b.Navigation("PublicationItem");
                });

            modelBuilder.Entity("Domain.Entities.Production", b =>
                {
                    b.Navigation("Directors");

                    b.Navigation("Producers");

                    b.Navigation("Writers");
                });

            modelBuilder.Entity("Domain.Entities.Publication", b =>
                {
                    b.Navigation("CoverLanguages");

                    b.Navigation("PublicationItems");
                });

            modelBuilder.Entity("Domain.Entities.PublicationItem", b =>
                {
                    b.Navigation("MediaItems");

                    b.Navigation("SubtitleLanguages");
                });
#pragma warning restore 612, 618
        }
    }
}
