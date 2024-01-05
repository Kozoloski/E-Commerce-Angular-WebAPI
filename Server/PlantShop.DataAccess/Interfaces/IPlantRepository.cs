using PlantShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantShop.DataAccess.Interfaces
{
    public interface IPlantRepository
    {
        Task<Plant> GetPlantByIdAsync(int id);
        Task<IReadOnlyList<Plant>> GetPlantsAsync();
        Task<IReadOnlyList<PlantCategory>> GetPlantCategoriesAsync();
        Task<IReadOnlyList<PlantType>> GetPlantTypesAsync();
    }
}
