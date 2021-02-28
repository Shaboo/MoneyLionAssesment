using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyLionAssesment.Models;
using System;
using System.Linq;

namespace MoneyLionAssesment.Data
{
    public class DatabasePrepare
    {
        public static void PreparePopilation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<DatabaseContext>());
            }
        }

        public static void SeedData(DatabaseContext context)
        {
            //Apply Migrations
            Console.WriteLine("Applying migration...");
            context.Database.Migrate();

            //adding some data
            if (!context.Features.Any() && !context.Users.Any())
            {
                Console.WriteLine("Seeding Data...");

                var feature1 = new Feature { Name = "AddUser" };
                var feature2 = new Feature { Name = "DeleteUser" };
                var feature3 = new Feature { Name = "UpdateUser" };
                var feature4 = new Feature { Name = "GetUser" };

                context.Features.Add(feature1);
                context.Features.Add(feature2);
                context.Features.Add(feature3);
                context.Features.Add(feature4);

                var user1 = new User { Email = "mohmdsh93@gmail.com" };
                var user2 = new User { Email = "example@gmail.com" };
                
                context.Users.Add(user1);
                context.Users.Add(user2);

                context.SaveChanges();
            }
        }
    }
}
