using InvoiceSystem.Entities;
using InvoiceSystem.Entities.App;
// using InvoiceSystem.Entities.BaseInfo;
//using InvoiceSystem.Entities.Cars;
using InvoiceSystem.ViewModels.Identity.Settings;
using Microsoft.EntityFrameworkCore;
using System;

namespace InvoiceSystem.DataLayer.Mappings
{
    public static class AppMappings
    {
        /// <summary>
        /// Adds all of the ASP.NET Core Identity related mappings at once.
        /// More info: http://www.dotnettips.info/post/2577
        /// and http://www.dotnettips.info/post/2578
        /// </summary>
        public static void AddCustomAppMappings(this ModelBuilder modelBuilder, SiteSettings siteSettings)
        {
            // #region ContactUs
            // modelBuilder.Entity<ContactUs>(builder =>
            // {
            // });
            // #endregion

            #region Blog
            modelBuilder.Entity<Post>(builder =>
            {

            });
          
            modelBuilder.Entity<PostGroup>(builder =>
            {
                builder.HasOne(x => x.Parent)
                    .WithMany(x => x.Children)
                    .HasForeignKey(x => x.ParentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
          
            modelBuilder.Entity<PostPostGroup>(builder =>
            {
                builder.HasKey(x => new { x.PostId, x.PostGroupId });
            });
            #endregion
        }
    }
}