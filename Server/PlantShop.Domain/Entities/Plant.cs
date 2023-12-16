

namespace PlantShop.Domain.Entities
{
    public class Plant : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public PlantType PlantType { get; set; }
        public int PlantTypeId { get; set; }
        public PlantCategory PlantCategory { get; set; }
        public int PlantCategoryId { get; set; }
    }
}
