using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SuperShopManagementSystem.Models.DatabaseContex
{
    public class SuperShopDbContext : DbContext
    {
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}