using Microsoft.IdentityModel.Tokens;
using PlantShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantShop.Domain.Specifications
{
    public class PlantsWithTypesAndCategoriesSpecification : BaseSpecification<Plant>
    {
        public PlantsWithTypesAndCategoriesSpecification(PlantSpecParams plantParams)
            : base(x =>
            (string.IsNullOrEmpty(plantParams.Search) || x.Name.ToLower().Contains
            (plantParams.Search)) &&
            (!plantParams.CategoryId.HasValue || x.PlantCategoryId == plantParams.CategoryId) &&
            (!plantParams.TypeId.HasValue || x.PlantTypeId == plantParams.TypeId)
            )
        {
            AddInclude(x => x.PlantType);
            AddInclude(x => x.PlantCategory);
            AddOrderBy(x => x.Name);
            ApplyPaging(plantParams.PageSize * (plantParams.PageIndex - 1),
                plantParams.PageSize);


            if (!string.IsNullOrEmpty(plantParams.Sort))
            {
                switch (plantParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }

        public PlantsWithTypesAndCategoriesSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.PlantType);
            AddInclude(x => x.PlantCategory);
        }
    }
}
