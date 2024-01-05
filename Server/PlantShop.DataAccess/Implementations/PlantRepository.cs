using Microsoft.EntityFrameworkCore;
using PlantShop.DataAccess.Data;
using PlantShop.DataAccess.Interfaces;
using PlantShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantShop.DataAccess.Implementations
{
    public class PlantRepository : IPlantRepository
    {
        private readonly StoreContext _context;

        public PlantRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<PlantCategory>> GetPlantCategoriesAsync()
        {
            return await _context.PlantCategories.ToListAsync();
        }

        public async Task<Plant> GetPlantByIdAsync(int id)
        {
            return await _context.Plants
                .Include(p => p.PlantType)
                .Include(p => p.PlantCategory)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Plant>> GetPlantsAsync()
        {
            return await _context.Plants
                  .Include(p => p.PlantType)
                  .Include(p => p.PlantCategory)
                  .ToListAsync();
        }

        public async Task<IReadOnlyList<PlantType>> GetPlantTypesAsync()
        {
            return await _context.PlantTypes.ToListAsync();
        }
    }
}