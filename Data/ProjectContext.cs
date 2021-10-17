using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopigStore.Model;

namespace ShopigStore.Data
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions option):base(option)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Intrust> Intrust { get; set; }
        public DbSet<UserItem> UserItem { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserItem>()
                .HasKey(x=> new{x.UserId,x.ItemId});

            modelBuilder.Entity<UserItem>()
                .HasOne(x=>x.Users)
                .WithMany(x=>x.UserItem)
                .HasForeignKey(x=>x.UserId);

            modelBuilder.Entity<UserItem>()
                .HasOne(x=>x.Items)
                .WithMany(x=>x.UserItem)
                .HasForeignKey(x=>x.ItemId);
        }

    }
}