using PlantShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantShop.Domain.Specifications
{
    public class PlantWithFiltersForCountSpecification : BaseSpecification<Plant>
    {
        public PlantWithFiltersForCountSpecification(PlantSpecParams plantParams)
        : base(x =>
            (string.IsNullOrEmpty(plantParams.Search) || x.Name.ToLower().Contains
            (plantParams.Search)) &&
            (!plantParams.CategoryId.HasValue || x.PlantCategoryId == plantParams.CategoryId) &&
            (!plantParams.TypeId.HasValue || x.PlantTypeId == plantParams.TypeId)
            )
        {
        }
    }
}
