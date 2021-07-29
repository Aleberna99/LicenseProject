using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProvaConnessioneLicenze.Models;

#nullable disable

namespace ProvaConnessioneLicenze.Data
{
    public partial class licenseContext : DbContext
    {
        public licenseContext()
        {
        }

        public licenseContext(DbContextOptions<licenseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
        public virtual DbSet<LicenseModel> LicenseModels { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<NewsFeed> NewsFeeds { get; set; }
        public virtual DbSet<NewsFeedUser> NewsFeedUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersLicense> UsersLicenses { get; set; }
        public virtual DbSet<UsersLicensesToken> UsersLicensesTokens { get; set; }

        public virtual DbSet<LicenseExt> LicenseExt { get; set; }
        public virtual DbSet<CustomerExt> CustomerExt { get; set; }
        public virtual DbSet<UserExt> UsersExt { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;user=root;database=license;password=pc4centro;port=3306");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<License>(entity =>
            {
                entity.HasKey(e => e.Activationcode)
                    .HasName("PRIMARY");

                entity.Property(e => e.Locked).HasDefaultValueSql("'1'");

                entity.Property(e => e.Maxapikeys).HasDefaultValueSql("'1'");

                entity.Property(e => e.Maxpersonalcatalogs).HasDefaultValueSql("'1'");

                entity.Property(e => e.Maxpricelists).HasDefaultValueSql("'1'");

                entity.Property(e => e.Maxsuppliers).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<LicenseExt>(entity =>
            {
                entity.HasKey(e => e.Activationcode)
                .HasName("PRIMARY");

            });

            modelBuilder.Entity<LicenseModel>(entity =>
            {
                entity.HasKey(e => e.Productcode)
                    .HasName("PRIMARY");

                entity.Property(e => e.Maxapikeys).HasDefaultValueSql("'1'");

                entity.Property(e => e.Maxpersonalcatalogs).HasDefaultValueSql("'1'");

                entity.Property(e => e.Maxpricelists).HasDefaultValueSql("'1'");

                entity.Property(e => e.Maxsuppliers).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.Modulecode)
                    .HasName("PRIMARY");

                entity.Property(e => e.Active).HasDefaultValueSql("'1'");

                entity.Property(e => e.Moduletype).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<NewsFeed>(entity =>
            {
                entity.HasKey(e => e.Newsid)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<NewsFeedUser>(entity =>
            {
                entity.HasKey(e => new { e.Newsid, e.Userid })
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<UsersLicense>(entity =>
            {
                entity.HasKey(e => new { e.Activationcode, e.Userid })
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<UsersLicensesToken>(entity =>
            {
                entity.HasKey(e => e.Token)
                    .HasName("PRIMARY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        

    }
}
