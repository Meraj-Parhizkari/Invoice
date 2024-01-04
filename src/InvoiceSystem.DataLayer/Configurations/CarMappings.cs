using InvoiceSystem.Entities;
// using InvoiceSystem.Entities.BaseInfo;
using InvoiceSystem.Entities.Cars;
using InvoiceSystem.ViewModels.Identity.Settings;
using Microsoft.EntityFrameworkCore;
using System;

namespace InvoiceSystem.DataLayer.Mappings
{
    public static class CarMappings
    {
        /// <summary>
        /// Adds all of the ASP.NET Core Identity related mappings at once.
        /// More info: http://www.dotnettips.info/post/2577
        /// and http://www.dotnettips.info/post/2578
        /// </summary>
        public static void AddCustomCarMappings(this ModelBuilder modelBuilder, SiteSettings siteSettings)
        {

            // #region CarBrand
            // /////////////////////////////////////////
            // /// CarBrand
            // ////////////////////////////////////////
            // modelBuilder.Entity<CarBrand>(builder =>
            // {
            //     //  builder.ToTable("CarBrands");
            //     builder.HasIndex(x => new { x.Name, x.ManufacturerId })
            //       .IsUnique();

            // })
            // //.HasDefaultSchema("car")
            // ;
            // #endregion

            // #region Manufacurer
            // /////////////////////////////////////////
            // /// Manufacturer
            // ////////////////////////////////////////
            // modelBuilder.Entity<Manufacturer>(builder =>
            // {
            //     //  builder.ToTable("Manufacturers");
            //     builder.HasIndex(x => x.Name)
            //       .IsUnique();
            // })
            // //.HasDefaultSchema("car")
            // ;
            // #endregion

            #region CarColor
            /////////////////////////////////////////
            /// CarColor
            ////////////////////////////////////////
            modelBuilder.Entity<CarColor>(builder =>
            {
                //  builder.ToTable("Manufacturers");
                builder.HasIndex(x => x.Name)
                  .IsUnique();
            })
            //.HasDefaultSchema("car")
            ;
            #endregion

            #region CarDoc
            /////////////////////////////////////////
            /// CarDoc
            ////////////////////////////////////////
            modelBuilder.Entity<CarDoc>(builder =>
            {
                //  builder.ToTable("Manufacturers");
                builder.HasIndex(x => x.Name)
                  .IsUnique();
            })
            //.HasDefaultSchema("car")
            ;
            #endregion

            // #region Customers

            // modelBuilder.Entity<Customer>(c =>
            // {
            //     c.HasIndex(x => new { x.AgentId, x.AccountId }).IsUnique();
            //     c.HasIndex(x => new { x.AgentId, x.Name, x.AccountId, x.Code }).IsUnique();
            // });
            // #endregion

            // #region CarBuy
            // modelBuilder.Entity<CarBuy>(builder =>
            // {
            //     builder.HasIndex(x => x.InvoiceCode)
            //     .IsUnique();
            // });
            // #endregion

            #region CarBodyStatus
            modelBuilder.Entity<CarBodyStatus>(builder =>
            {

            });
            #endregion

            #region Car
            modelBuilder.Entity<Car>(builder =>
            {
                builder.HasOne(x => x.CarBodyStatus)
                    .WithMany(x => x.Cars)
                    .HasForeignKey(x => x.CarBodyStatusId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(x => x.BodyCarColor)
                    .WithMany(x => x.BodyCarColors)
                    .HasForeignKey(x => x.BodyCarColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(x => x.InsideCarColor)
                    .WithMany(x => x.InsideCarColors)
                    .HasForeignKey(x => x.InsideCarColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(x => x.CarBrand)
                    .WithMany(x => x.CarCarBrands)
                    .HasForeignKey(x => x.CarBrandId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(x => x.CarModel)
                    .WithMany(x => x.CarCarModels)
                    .HasForeignKey(x => x.CarModelId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(x => x.CarType)
                    .WithMany(x => x.CarCarTypes)
                    .HasForeignKey(x => x.CarTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(x => x.CreatedByUser)
                    .WithMany(x => x.CarUserCreators)
                    .HasForeignKey(x => x.CreatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            #endregion

            #region CarF
            modelBuilder.Entity<BaseCar>(builder =>
            {
                builder.HasOne(x => x.Parent)
                    .WithMany(x => x.Children)
                    .HasForeignKey(x => x.ParentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            #endregion

            #region CarImage
            modelBuilder.Entity<CarImage>(builder =>
            {
            });
            #endregion
        }
    }
}