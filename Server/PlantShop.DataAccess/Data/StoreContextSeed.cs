using PlantShop.Domain.Entities;
using PlantShop.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlantShop.DataAccess.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.PlantCategories.Any())
            {
                var categoriesData = File.ReadAllText("C:\\Users\\Tomo\\Desktop\\Angular-WebAPI-Repo\\E-Commerce-Angular-WebAPI\\Server\\PlantShop.DataAccess\\Data\\SeedData\\categories.json");
                var categories = JsonSerializer.Deserialize<List<PlantCategory>>(categoriesData);
                context.PlantCategories.AddRange(categories);
            }
            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();

            if (!context.PlantTypes.Any())
            {
                var typesData = File.ReadAllText("C:\\Users\\Tomo\\Desktop\\Angular-WebAPI-Repo\\E-Commerce-Angular-WebAPI\\Server\\PlantShop.DataAccess\\Data\\SeedData\\types.json");
                var types = JsonSerializer.Deserialize<List<PlantType>>(typesData);
                context.PlantTypes.AddRange(types);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();

            if (!context.Plants.Any())
            {
                try
                {
                    var plantsData = File.ReadAllText("C:\\Users\\Tomo\\Desktop\\Angular-WebAPI-Repo\\E-Commerce-Angular-WebAPI\\Server\\PlantShop.DataAccess\\Data\\SeedData\\plants.json");
                    var plants = JsonSerializer.Deserialize<List<Plant>>(plantsData);
                    context.Plants.AddRange(plants);

                    if (context.ChangeTracker.HasChanges())
                    {
                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred during seeding plants: {ex.Message}");
                  
                }
            }

            if (!context.DeliveryMethods.Any())
            {
                var deliveryData = File.ReadAllText("C:\\Users\\Tomo\\Desktop\\Angular-WebAPI-Repo\\E-Commerce-Angular-WebAPI\\Server\\PlantShop.DataAccess\\Data\\SeedData\\delivery.json");
                var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);
                context.DeliveryMethods.AddRange(methods);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}
