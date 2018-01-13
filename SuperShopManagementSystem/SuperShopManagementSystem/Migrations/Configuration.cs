namespace SuperShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SuperShopManagementSystem.Models.DatabaseContex.SuperShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SuperShopManagementSystem.Models.DatabaseContex.SuperShopDbContext";
        }

        protected override void Seed(SuperShopManagementSystem.Models.DatabaseContex.SuperShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
