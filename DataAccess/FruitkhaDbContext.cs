using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FruitkhaDbContext : IdentityDbContext<K205User>
    {
        public FruitkhaDbContext(DbContextOptions<FruitkhaDbContext> options)
         : base(options)
        {

        }

        public DbSet<K205User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Free> Frees { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Since> Sinces { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Fresh> Freshes { get; set; }
        public DbSet<Contact> Contacts { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<K205User>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}
