﻿// <auto-generated />
using ASP_Project.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASP_Project.Migrations
{
    [DbContext(typeof(ASP_ProjectContext))]
    [Migration("20220122150501_AddedBeverages")]
    partial class AddedBeverages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASP_Project.Entities.Beverage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Beverages");
                });

            modelBuilder.Entity("ASP_Project.Entities.Dish", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("ASP_Project.Entities.Location", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RestaurantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId")
                        .IsUnique()
                        .HasFilter("[RestaurantId] IS NOT NULL");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("ASP_Project.Entities.Partnership", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Partnerships");
                });

            modelBuilder.Entity("ASP_Project.Entities.Restaurant", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("ASP_Project.Entities.RestaurantPartnership", b =>
                {
                    b.Property<string>("RestaurantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PartnershipId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RestaurantId", "PartnershipId");

                    b.HasIndex("PartnershipId");

                    b.ToTable("RestaurantPartnerships");
                });

            modelBuilder.Entity("ASP_Project.Entities.Beverage", b =>
                {
                    b.HasOne("ASP_Project.Entities.Restaurant", "Restaurant")
                        .WithMany("Beverages")
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("ASP_Project.Entities.Dish", b =>
                {
                    b.HasOne("ASP_Project.Entities.Restaurant", "Restaurant")
                        .WithMany("Dishes")
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("ASP_Project.Entities.Location", b =>
                {
                    b.HasOne("ASP_Project.Entities.Restaurant", "Restaurant")
                        .WithOne("Location")
                        .HasForeignKey("ASP_Project.Entities.Location", "RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("ASP_Project.Entities.RestaurantPartnership", b =>
                {
                    b.HasOne("ASP_Project.Entities.Partnership", "Partnership")
                        .WithMany("RestaurantPartnerships")
                        .HasForeignKey("PartnershipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASP_Project.Entities.Restaurant", "Restaurant")
                        .WithMany("RestaurantPartnerships")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partnership");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("ASP_Project.Entities.Partnership", b =>
                {
                    b.Navigation("RestaurantPartnerships");
                });

            modelBuilder.Entity("ASP_Project.Entities.Restaurant", b =>
                {
                    b.Navigation("Beverages");

                    b.Navigation("Dishes");

                    b.Navigation("Location");

                    b.Navigation("RestaurantPartnerships");
                });
#pragma warning restore 612, 618
        }
    }
}
