namespace eManager.Web.Migrations
{
    using eManager.Domain;
    using eManager.Web.App_Start;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<eManager.Web.Infrastructure.DepartmentDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(eManager.Web.Infrastructure.DepartmentDb context)
        {
            context.Departments.AddOrUpdate(d => d.Name,
                  new Department() { Name = "Engineering" },
                  new Department() { Name = "Sales" },
                  new Department() { Name = "Shipping" },
                  new Department() { Name = "Human Resources" }
          );

            context.videos.AddOrUpdate(v => v.Title,
                new Video() { Title = "MVC4" ,Length = 120},
                new Video() { Title= "LINQ" ,Length = 200}
                    );

            SeedMembership();  
        }

        private void SeedMembership()
        {
            if (!WebSecurity.Initialized)
            {
                Setup.SetupConfig();
                //throw new NotImplementedException();
            }
            var adminUser = "Admin";
            var user = "jcuevas";
            var strangeRol = "thisisatest";

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists(adminUser))
            {
                roles.CreateRole(adminUser);
            }
            if (membership.GetUser(user, false) == null)
            {
                membership.CreateUserAndAccount(user, strangeRol);
            }
            if (!roles.GetRolesForUser(user).Contains(adminUser))
            {
                roles.AddUsersToRoles(new[] { user }, new[] { adminUser });
            }
        }
    }
}
