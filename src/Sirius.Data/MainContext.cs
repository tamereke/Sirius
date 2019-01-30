using Sirius.Core.Data;
using Sirius.Core.Entities;
using Sirius.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Data
{
    public class MainContext : DbContextBase,IDbContext
    {
        public MainContext(DbContextOptions<MainContext> options) 
            : base(options )
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server = IST-TEKE\\SQLEXPRESS ; Database = Abc; User Id = sa;Password = Tamer2018-;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #region Business
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion

        #region Core
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #endregion

    }
}
