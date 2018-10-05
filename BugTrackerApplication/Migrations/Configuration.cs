namespace BugTrackerApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BugTrackerApplication.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<BugTrackerApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BugTrackerApplication.Models.ApplicationDbContext";
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                var role = new IdentityRole("Admin");

                roleManager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Project Manager"))
            {
                roleManager.Create(new IdentityRole { Name = "Project Manager" });
            }

            if (!context.Roles.Any(r => r.Name == "Developer"))
            {
                roleManager.Create(new IdentityRole { Name = "Developer" });
            }

            if (!context.Roles.Any(r => r.Name == "Submitter"))
            {
                roleManager.Create(new IdentityRole { Name = "Submitter" });
            }

            ApplicationUser adminUser = null;
            if (!context.Users.Any(p => p.UserName == "admin@myBugTracker.com"))
            {
                adminUser = new ApplicationUser();
                adminUser.UserName = "admin@myBugTracker.com";
                adminUser.Email = "admin@myBugTracker.com";
                adminUser.FirstName = "Admin";
                adminUser.LastName = "User";
                userManager.Create(adminUser, "Password-1");
            }
            else
            {
                adminUser = context.Users.Where(p => p.UserName == "admin@myBugTracker.com")
                    .FirstOrDefault();
            }

            if (!userManager.IsInRole(adminUser.Id, "Admin"))
            {
                userManager.AddToRole(adminUser.Id, "Admin");
            }
        }
    }
}
