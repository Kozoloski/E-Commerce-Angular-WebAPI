﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantShop.Domain.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string PlantName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
       
        public string Category  { get; set; }
        public string Type { get; set; }
    }
}
