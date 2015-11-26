using System.Collections;
using System.Collections.Generic;
using Crap.Data.Entities.Common;

namespace Crap.Data.Entities
{
    public class Category : Entity
    {
        //public Category()
        //{
        //    Products = new List<Product>();
        //}

        public string Name { get; set; }

        public IList<Product> Products { get; set; }
    }
}
