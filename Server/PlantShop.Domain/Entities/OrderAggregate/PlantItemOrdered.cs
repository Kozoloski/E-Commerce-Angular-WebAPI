using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantShop.Domain.Entities.OrderAggregate
{
    public class PlantItemOrdered
    {
        public PlantItemOrdered()
        {
        }

        public PlantItemOrdered(int plantItemId, string plantName, string pictureUrl)
        {
            PlantItemId = plantItemId;
            PlantName = plantName;
            PictureUrl = pictureUrl;
        }

        public int PlantItemId { get; set; }
        public string PlantName { get; set; }
        public string PictureUrl { get; set; }
    }
}
