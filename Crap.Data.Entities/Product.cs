﻿using Crap.Data.Entities.Common;

namespace Crap.Data.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public int AvailableAmount { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
