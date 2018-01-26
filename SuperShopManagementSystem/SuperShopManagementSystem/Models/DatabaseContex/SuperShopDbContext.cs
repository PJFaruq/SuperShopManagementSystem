using SuperShopManagementSystem.Models.Operation;
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
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<ExpenseItem> ExpenseItems { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Outlet> Outlets { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }

        

        public DbSet<Sales> Saleses { get; set; }
        public DbSet<SalesDetail> SalesDetails { get; set; }

        public System.Data.Entity.DbSet<SuperShopManagementSystem.Models.ViewModel.SalesReceipt_ViewModel> SalesReceipt_ViewModel { get; set; }

        public System.Data.Entity.DbSet<SuperShopManagementSystem.Models.ViewModel.PurchaseResultVM> PurchaseResultVMs { get; set; }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseDetail> ExpenseDetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>()
                .HasRequired(d => d.Outlet)
                .WithMany(w => w.Purchases)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sales>()
                .HasRequired(d => d.Outlet)
                .WithMany(w => w.Saleses)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expense>()
                .HasRequired(d => d.Outlet)
                .WithMany(w => w.Expenses)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<SuperShopManagementSystem.Models.ViewModel.ExpenseResultVM> ExpenseResultVMs { get; set; }
    }
}