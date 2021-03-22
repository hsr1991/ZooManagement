using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Zoo_Management.Data;
using Zoo_Management.Repositories;


namespace Zoo_Management
{
    public class Program
    {
        private readonly IAnimalsRepo _animals;
        public Program(IAnimalsRepo animals)
        {
            _animals = animals;
        }
        
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
             var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);
            
            host.Run();

        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ZooManagementDbContext>();
            context.Database.EnsureCreated();

            if (!context.Animals.Any())
            {
                
                    var species = SampleAnimal.GetSpecies();
                    context.Species.AddRange(species);
                    context.SaveChanges();

                    var animal = SampleAnimal.GetAnimals();
                    context.Animals.AddRange(animal);
                    context.SaveChanges();
                
                
                // var users = SampleUsers.GetUsers();
                // context.Users.AddRange(users);
                // context.SaveChanges();

                // var posts = SamplePosts.GetPosts();
                // context.Posts.AddRange(posts);
                // context.SaveChanges();

                // var interactions = SampleInteractions.GetInteractions();
                // context.Interactions.AddRange(interactions);
                // context.SaveChanges();
            }
        }

        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
