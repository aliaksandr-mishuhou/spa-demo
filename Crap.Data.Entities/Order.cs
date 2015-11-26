using System;
using System.Collections;
using System.Collections.Generic;
using Crap.Data.Entities.Common;

namespace Crap.Data.Entities
{
    public class Order : Entity
    {
        public DateTime Created { get; set; }
        public DateTime? Paid { get; set; }
        public DateTime? Processed { get; set; }
        public OrderStatus Status { get; set; }
        public IList<OrderItem> Items { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
