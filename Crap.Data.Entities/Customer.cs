using System.Collections;
using System.Collections.Generic;
using Crap.Data.Entities.Common;

namespace Crap.Data.Entities
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
