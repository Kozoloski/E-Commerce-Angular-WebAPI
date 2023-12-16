using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantShop.DataAccess.Interfaces;
using PlantShop.Domain.Entities;
using PlantShop.Domain.Specifications;
using PlantShop.DTOs;
using PlantShop.Helpers.Helpers;
using PlantShop.Shared.Errors;

namespace PlantShop.Controllers
{
    public class PlantsController : BaseApiController
    {
        private readonly IGenericRepository<Plant> _plantsRepo;
        private readonly IGenericRepository<PlantCategory> _plantCategoryRepo;
        private readonly IGenericRepository<PlantType> _plantTypeRepo;
        private readonly IMapper _mapper;

        public PlantsController(IGenericRepository<Plant> plantsRepo, IGenericRepository<PlantCategory> plantCategoryRepo,
            IGenericRepository<PlantType> plantTypeRepo, IMapper mapper)
        {
            _plantsRepo = plantsRepo;
            _plantCategoryRepo = plantCategoryRepo;
            _plantTypeRepo = plantTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<PlantToReturnDto>>> GetPlants([FromQuery] PlantSpecParams plantParams)
        {
            var spec = new PlantsWithTypesAndCategoriesSpecification(plantParams);
            var countSpec = new PlantWithFiltersForCountSpecification(plantParams);
            var totalItems = await _plantsRepo.CountAsync(countSpec);
            var plants = await _plantsRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Plant>, IReadOnlyList<PlantToReturnDto>>(plants);

            return Ok(new Pagination<PlantToReturnDto>(plantParams.PageIndex, plantParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PlantToReturnDto>> GetPlant(int id)
        {

            var spec = new PlantsWithTypesAndCategoriesSpecification(id);
            var plant = await _plantsRepo.GetEntityWithSpec(spec);

            if (plant == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<Plant, PlantToReturnDto>(plant);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<PlantCategory>>> GetPlantCategories()
        {
            return Ok(await _plantCategoryRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<PlantType>>> GetProductTypes()
        {
            return Ok(await _plantTypeRepo.ListAllAsync());
        }
    }
}
