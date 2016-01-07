using Crap.Data.Entities;
using Crap.Data.Providers;

namespace Crap.UI.Controllers
{
    public class ProductsController : BaseApiController
    {
        public ProductsController(IRepository<Error> errorRepository) : base(errorRepository)
        {
        }
    }
}